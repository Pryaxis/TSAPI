using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Terraria.DataStructures;
using TerrariaApi.Server;
using XNA;

namespace Terraria
{
	public class Main
	{
		public static int maxItemTypes = 2749;
		public static int maxProjectileTypes = 423;
		public static int maxNPCTypes = 378;
		public static int maxTileSets = 340;
		public static int maxWallTypes = 172;
		public static int maxGoreTypes = 587;
		public static int numArmorHead = 169;
		public static int numArmorBody = 175;
		public static int numArmorLegs = 110;
		public static int numAccHandsOn = 18;
		public static int numAccHandsOff = 11;
		public static int numAccNeck = 7;
		public static int numAccBack = 8;
		public static int numAccFront = 5;
		public static int numAccShoes = 16;
		public static int numAccWaist = 11;
		public static int numAccShield = 5;
		public static int numAccFace = 9;
		public static int numAccBalloon = 11;
		public static int maxBuffTypes = 140;
		public static int maxWings = 27;
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
		public static int maxItemSounds = 56;
		public static int maxNPCHitSounds = 14;
		public static int maxNPCKilledSounds = 20;
		public static int maxLiquidTypes = 12;
		public static int maxMusic = 34;
		public static double dayLength = 54000.0;
		public static double nightLength = 32400.0;
		public static int maxStars = 130;
		public static int maxStarTypes = 5;
		public static int maxClouds = 200;
		public static int maxCloudTypes = 22;
		public static int maxHair = 123;
		public static int maxCharSelectHair = 51;
		public static int curRelease = 102;
		public static string versionNumber = "v1.2.4.1";
		public static string versionNumber2 = "v1.2.4.1";
		public static WorldSections sectionManager;
		public static bool ServerSideCharacter = false;
		public static string clientUUID;
		public static int maxMsg = 78;
		public static int npcStreamSpeed = 60;
		public static int musicError = 0;
		public static bool dedServFPS = false;
		public static int dedServCount1 = 0;
		public static int dedServCount2 = 0;
		public static bool superFast = false;
		public static bool[] hairLoaded = new bool[123];
		public static bool[] wingsLoaded = new bool[27];
		public static bool[] goreLoaded = new bool[587];
		public static bool[] projectileLoaded = new bool[423];
		public static bool[] itemFlameLoaded = new bool[2749];
		public static bool[] backgroundLoaded = new bool[185];
		public static bool[] tileSetsLoaded = new bool[340];
		public static bool[] wallLoaded = new bool[172];
		public static bool[] NPCLoaded = new bool[378];
		public static bool[] armorHeadLoaded = new bool[169];
		public static bool[] armorBodyLoaded = new bool[175];
		public static bool[] armorLegsLoaded = new bool[110];
		public static bool[] accHandsOnLoaded = new bool[18];
		public static bool[] accHandsOffLoaded = new bool[11];
		public static bool[] accBackLoaded = new bool[8];
		public static bool[] accFrontLoaded = new bool[5];
		public static bool[] accShoesLoaded = new bool[16];
		public static bool[] accWaistLoaded = new bool[11];
		public static bool[] accShieldLoaded = new bool[5];
		public static bool[] accNeckLoaded = new bool[7];
		public static bool[] accFaceLoaded = new bool[9];
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
		private Matrix Transform = Matrix.CreateScale(1f, 1f, 1f) * Matrix.CreateRotationZ(0f) * Matrix.CreateTranslation(new Vector3(0f, 0f, 0f));
		public static int ugBack = 0;
		public static int oldUgBack = 0;
		public static int[] bgFrame = new int[1];
		public static int[] bgFrameCounter = new int[1];
		public static bool skipMenu = false;
		public static bool verboseNetplay = false;
		public static bool stopTimeOuts = false;
		public static bool showSpam = false;
		public static bool showItemOwner = false;
		public static bool[] nextNPC = new bool[378];
		public static int musicBox = -1;
		public static int musicBox2 = -1;
		public static byte hbPosition = 1;
		public static bool cEd = false;
		public static float wFrCounter = 0f;
		public static float wFrame = 0f;
		public static float upTimer;
		public static float upTimerMax;
		public static float upTimerMaxDelay;
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
		public static bool[] projHostile = new bool[423];
		public static bool[] pvpBuff = new bool[140];
		public static bool[] vanityPet = new bool[140];
		public static bool[] lightPet = new bool[140];
		public static bool[] meleeBuff = new bool[140];
		public static bool[] debuff = new bool[140];
		public static string[] buffName = new string[140];
		public static string[] buffTip = new string[140];
		public static bool[] buffNoSave = new bool[140];
		public static bool[] buffNoTimeDisplay = new bool[140];
		public static bool[] buffDoubleApply = new bool[140];
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
		private static bool flameRingLoaded;
		public static bool[,] initMap = new bool[Main.mapTargetX, Main.mapTargetY];
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
		public static float[] buffAlpha = new float[140];
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
		public static Vector2 sceneWaterPos = Vector2.Zero;
		public static Vector2 sceneTilePos = Vector2.Zero;
		public static Vector2 sceneTile2Pos = Vector2.Zero;
		public static Vector2 sceneWallPos = Vector2.Zero;
		public static Vector2 sceneBackgroundPos = Vector2.Zero;
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
		public static int[] projFrames = new int[423];
		public static bool[] projPet = new bool[423];
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
		public static int numTreeStyles = 16;
		public static bool[,] treeAltTextureInit = new bool[Main.numTreeStyles, Main.numTileColors];
		public static bool[,] treeAltTextureDrawn = new bool[Main.numTreeStyles, Main.numTileColors];
		public static bool[,] checkTreeAlt = new bool[Main.numTreeStyles, Main.numTileColors];
		public static bool[,] wallAltTextureInit = new bool[172, Main.numTileColors];
		public static bool[,] wallAltTextureDrawn = new bool[172, Main.numTileColors];
		public static float[] musicFade = new float[34];
		public static float musicVolume = 0.75f;
		public static float ambientVolume = 0.75f;
		public static float soundVolume = 1f;
		public static bool[] tileLighted = new bool[340];
		public static bool[] tileMergeDirt = new bool[340];
		public static bool[] tileCut = new bool[340];
		public static bool[] tileAlch = new bool[340];
		public static int[] tileShine = new int[340];
		public static bool[] tileShine2 = new bool[340];
		public static bool[] wallHouse = new bool[172];
		public static bool[] wallDungeon = new bool[172];
		public static bool[] wallLight = new bool[172];
		public static int[] wallBlend = new int[172];
		public static bool[] tileStone = new bool[340];
		public static bool[] tilePick = new bool[340];
		public static bool[] tileAxe = new bool[340];
		public static bool[] tileHammer = new bool[340];
		public static bool[] tileWaterDeath = new bool[340];
		public static bool[] tileLavaDeath = new bool[340];
		public static bool[] tileTable = new bool[340];
		public static bool[] tileBlockLight = new bool[340];
		public static bool[] tileNoSunLight = new bool[340];
		public static bool[] tileDungeon = new bool[340];
		public static bool[] tileSolidTop = new bool[340];
		public static bool[] tileSolid = new bool[340];
		public static byte[] tileLargeFrames = new byte[340];
		public static byte[] wallLargeFrames = new byte[172];
		public static bool[] tileRope = new bool[340];
		public static bool[] tileBrick = new bool[340];
		public static bool[] tileMoss = new bool[340];
		public static bool[] tileNoAttach = new bool[340];
		public static bool[] tileNoFail = new bool[340];
		public static bool[] tileObsidianKill = new bool[340];
		public static bool[] tileFrameImportant = new bool[340];
		public static bool[] tilePile = new bool[340];
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
		public static byte[,] jellyfishCageMode = new byte[3, Main.cageFrames];
		public static int[,] jellyfishCageFrame = new int[3, Main.cageFrames];
		public static int[,] jellyfishCageFrameCounter = new int[3, Main.cageFrames];
		public static int[] wormCageFrame = new int[Main.cageFrames];
		public static int[] wormCageFrameCounter = new int[Main.cageFrames];
		public static int[] penguinCageFrame = new int[Main.cageFrames];
		public static int[] penguinCageFrameCounter = new int[Main.cageFrames];
		public static int[] grasshopperCageFrame = new int[Main.cageFrames];
		public static int[] grasshopperCageFrameCounter = new int[Main.cageFrames];
		public static bool[] tileSand = new bool[340];
		public static bool[] tileFlame = new bool[340];
		public static bool[] npcCatchable = new bool[378];
		public static int[] tileFrame = new int[340];
		public static int[] tileFrameCounter = new int[340];
		public static byte[] wallFrame = new byte[172];
		public static byte[] wallFrameCounter = new byte[172];
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
		public static List<int> playerDrawDust = new List<int>();
		public static List<int> playerDrawGore = new List<int>();
		public static int spawnTileX;
		public static int spawnTileY;
		public static bool npcChatRelease = false;
		public static bool editSign = false;
		public static bool editChest = false;
		public static bool blockInput = false;
		public static string defaultChestName = string.Empty;
		public static string npcChatText = "";
		public static bool npcChatFocus1 = false;
		public static bool npcChatFocus2 = false;
		public static bool npcChatFocus3 = false;
		public static int npcShop = 0;
		public static int numShops = 20;
		public static int npcChatCornerItem = 0;
		public Chest[] shop = new Chest[Main.numShops];
		public static int[] travelShop = new int[Chest.maxItems];
		public static List<string> anglerWhoFinishedToday = new List<string>();
		public static bool anglerQuestFinished;
		public static int anglerQuest = 0;
		public static int[] anglerQuestItemNetIDs = new int[]
		{
			2450,
			2451,
			2452,
			2453,
			2454,
			2455,
			2456,
			2457,
			2458,
			2459,
			2460,
			2461,
			2462,
			2463,
			2464,
			2465,
			2466,
			2467,
			2468,
			2469,
			2470,
			2471,
			2472,
			2473,
			2474,
			2475,
			2476,
			2477,
			2478,
			2479,
			2480,
			2481,
			2482,
			2483,
			2484,
			2485,
			2486,
			2487,
			2488
		};
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
		public static string[] itemName = new string[2749];
		public static string[] npcName = new string[378];
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
			16,
			14,
			8,
			2,
			4,
			4,
			4,
			4,
			2,
			2
		};
		public static Dictionary<int, byte> npcLifeBytes = new Dictionary<int, byte>();
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
		public static string cSmart = "LeftControl";
		public static bool cSmartToggle = true;
		public static bool smartDigEnabled = false;
		public static bool smartDigShowing = false;
		public static int smartDigX;
		public static int smartDigY;
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
		private static int maxMenuItems = 15;
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

		[DllImport("User32")]
		private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
		[DllImport("User32")]
		private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
		[DllImport("User32")]
		private static extern int GetMenuItemCount(IntPtr hWnd);
		[DllImport("kernel32.dll")]
		public static extern IntPtr LoadLibrary(string dllToLoad);
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
				Main.anglerQuest = Main.rand.Next(Main.anglerQuestItemNetIDs.Length);
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
				if (num == 2485 && WorldGen.crimson)
				{
					flag = true;
				}
			}
			NetMessage.SendAnglerQuest();
		}
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
		
		protected void OpenRecent()
		{
			try
			{
				if (File.Exists(Main.SavePath + Path.DirectorySeparatorChar + "servers.dat"))
				{
					using (FileStream fileStream = new FileStream(Main.SavePath + Path.DirectorySeparatorChar + "servers.dat", FileMode.Open))
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
			catch
			{
			}
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
		public static void SaveSettings()
		{/*
			Directory.CreateDirectory(Main.SavePath);
			try
			{
				File.SetAttributes(Main.SavePath + Path.DirectorySeparatorChar + "config.dat", FileAttributes.Normal);
			}
			catch
			{
			}
			try
			{
				using (FileStream fileStream = new FileStream(Main.SavePath + Path.DirectorySeparatorChar + "config.dat", FileMode.Create))
				{
					using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
					{
						binaryWriter.Write(Main.curRelease);
						binaryWriter.Write(Main.clientUUID);
						binaryWriter.Write(Main.graphics.IsFullScreen);
						binaryWriter.Write(Main.mouseColor.R);
						binaryWriter.Write(Main.mouseColor.G);
						binaryWriter.Write(Main.mouseColor.B);
						binaryWriter.Write(Main.soundVolume);
						binaryWriter.Write(Main.ambientVolume);
						binaryWriter.Write(Main.musicVolume);
						binaryWriter.Write(Main.cUp);
						binaryWriter.Write(Main.cDown);
						binaryWriter.Write(Main.cLeft);
						binaryWriter.Write(Main.cRight);
						binaryWriter.Write(Main.cJump);
						binaryWriter.Write(Main.cThrowItem);
						binaryWriter.Write(Main.cInv);
						binaryWriter.Write(Main.cHeal);
						binaryWriter.Write(Main.cMana);
						binaryWriter.Write(Main.cBuff);
						binaryWriter.Write(Main.cHook);
						binaryWriter.Write(Main.caveParrallax);
						binaryWriter.Write(Main.fixedTiming);
						binaryWriter.Write(Main.screenMaximized);
						binaryWriter.Write(Main.graphics.PreferredBackBufferWidth);
						binaryWriter.Write(Main.graphics.PreferredBackBufferHeight);
						binaryWriter.Write(Main.autoSave);
						binaryWriter.Write(Main.autoPause);
						binaryWriter.Write(Main.showItemText);
						binaryWriter.Write(Main.cTorch);
						binaryWriter.Write((byte)Lighting.lightMode);
						binaryWriter.Write((byte)Main.qaStyle);
						binaryWriter.Write(Main.owBack);
						binaryWriter.Write((byte)Lang.lang);
						binaryWriter.Write(Main.mapEnabled);
						binaryWriter.Write(Main.cMapStyle);
						binaryWriter.Write(Main.cMapFull);
						binaryWriter.Write(Main.cMapZoomIn);
						binaryWriter.Write(Main.cMapZoomOut);
						binaryWriter.Write(Main.cMapAlphaUp);
						binaryWriter.Write(Main.cMapAlphaDown);
						binaryWriter.Write(Lighting.LightingThreads);
						binaryWriter.Write(Main.cSmart);
						binaryWriter.Write(Main.cSmartToggle);
						binaryWriter.Close();
					}
				}
			}
			catch
			{
			}*/
		}
		protected void CheckBunny()
		{
			try
			{
				RegistryKey registryKey = Registry.CurrentUser;
				registryKey = registryKey.CreateSubKey("Software\\Terraria");
				if (registryKey != null && registryKey.GetValue("Bunny") != null && registryKey.GetValue("Bunny").ToString() == "1")
				{
					Main.cEd = true;
				}
			}
			catch
			{
				Main.cEd = false;
			}
		}
		protected void OpenSettings()
		{/*
			try
			{
				bool flag = false;
				if (File.Exists(Main.SavePath + Path.DirectorySeparatorChar + "config.dat"))
				{
					using (FileStream fileStream = new FileStream(Main.SavePath + Path.DirectorySeparatorChar + "config.dat", FileMode.Open))
					{
						using (BinaryReader binaryReader = new BinaryReader(fileStream))
						{
							int num = binaryReader.ReadInt32();
							if (num < 68)
							{
								flag = true;
							}
							else
							{
								if (num >= 67)
								{
									Main.clientUUID = binaryReader.ReadString();
								}
								else
								{
									flag = true;
								}
								bool flag2 = binaryReader.ReadBoolean();
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
								Main.caveParrallax = binaryReader.ReadSingle();
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
									Main.graphics.PreferredBackBufferWidth = binaryReader.ReadInt32();
									Main.graphics.PreferredBackBufferHeight = binaryReader.ReadInt32();
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
									Lighting.lightMode = (int)binaryReader.ReadByte();
									Main.qaStyle = (int)binaryReader.ReadByte();
								}
								if (num >= 37)
								{
									Main.owBack = binaryReader.ReadBoolean();
								}
								if (num >= 39)
								{
									Lang.lang = (int)binaryReader.ReadByte();
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
									Lighting.LightingThreads = binaryReader.ReadInt32();
									if (Lighting.LightingThreads >= Environment.ProcessorCount)
									{
										Lighting.LightingThreads = Environment.ProcessorCount - 1;
									}
								}
								if (num >= 100)
								{
									Main.cSmart = binaryReader.ReadString();
									Main.cSmartToggle = binaryReader.ReadBoolean();
								}
								if (flag2 && !Main.graphics.IsFullScreen)
								{
									Main.graphics.ToggleFullScreen();
								}
							}
							binaryReader.Close();
						}
					}
				}
				if (flag)
				{
					Main.SaveSettings();
				}
			}
			catch
			{
			}*/
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
		private static string getPlayerPathName(string playerName)
		{
			string text = "";
			for (int i = 0; i < playerName.Length; i++)
			{
				string text2 = playerName.Substring(i, 1);
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
				Main.PlayerPath,
				Path.DirectorySeparatorChar,
				text,
				".plr"
			})))
			{
				int num = 2;
				while (File.Exists(string.Concat(new object[]
				{
					Main.PlayerPath,
					Path.DirectorySeparatorChar,
					text,
					num,
					".plr"
				})))
				{
					num++;
				}
				text += num;
			}
			return string.Concat(new object[]
			{
				Main.PlayerPath,
				Path.DirectorySeparatorChar,
				text,
				".plr"
			});
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
			string path = string.Concat(new object[]
			{
				Main.WorldPath,
				Path.DirectorySeparatorChar,
				text,
				".wld"
			});
			string fullPath = Path.GetFullPath(path);
			if (fullPath.StartsWith("\\\\.\\", StringComparison.Ordinal))
			{
				text += "_";
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
			for (int i = 0; i < 378; i++)
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
					if (Netplay.anyClients || ServerApi.ForceUpdate)
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
				}
			}
		}

		public void Initialize()
		{
			Main.netMode = 2;
			Chest.Initialize();
			Framing.Initialize();
			Mount.Initialize();
			Minecart.Initialize();
			WorldGen.randomBackgrounds();
			WorldGen.setCaveBacks();
			WorldGen.randMoon();
			Main.bgAlpha[0] = 1f;
			Main.bgAlpha2[0] = 1f;
			this.invBottom = 258;
			for (int i = 0; i < 423; i++)
			{
				Main.projFrames[i] = 1;
			}
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
			Main.debuff[119] = true;
			Main.debuff[120] = true;
			Main.debuff[137] = true;
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
			Main.buffNoSave[137] = true;
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
			Main.buffNoTimeDisplay[138] = true;
			Main.buffNoTimeDisplay[139] = true;
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
			Main.vanityPet[127] = true;
			Main.vanityPet[136] = true;
			Main.lightPet[19] = true;
			Main.lightPet[27] = true;
			Main.lightPet[101] = true;
			Main.lightPet[102] = true;
			Main.lightPet[57] = true;
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
			Main.tileRope[213] = true;
			Main.tileRope[214] = true;
			Main.tilePile[330] = true;
			Main.tilePile[331] = true;
			Main.tilePile[332] = true;
			Main.tilePile[333] = true;
			for (int j = 0; j < 378; j++)
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
			Main.npcCatchable[374] = true;
			Main.npcCatchable[377] = true;
			Main.tileSolid[232] = true;
			Main.tileSolid[311] = true;
			Main.tileSolid[312] = true;
			Main.tileSolid[313] = true;
			Main.tileMergeDirt[311] = true;
			Main.tileSolid[315] = true;
			Main.tileMergeDirt[315] = true;
			Main.tileSolid[321] = true;
			Main.tileSolid[322] = true;
			Main.tileMergeDirt[321] = true;
			Main.tileMergeDirt[322] = true;
			Main.tileShine[239] = 1100;
			Main.tileSolid[239] = true;
			Main.tileSolidTop[239] = true;
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
			Main.tileLargeFrames[325] = 1;
			Main.tileSolid[325] = true;
			Main.tileBlockLight[325] = true;
			Main.wallLargeFrames[146] = 1;
			Main.wallLargeFrames[147] = 1;
			Main.wallLargeFrames[167] = 1;
			Main.tileSolid[326] = true;
			Main.tileBlockLight[326] = true;
			Main.tileSolid[327] = true;
			Main.tileBlockLight[327] = true;
			Main.tileLighted[327] = true;
			Main.tileSolid[328] = true;
			Main.tileBrick[328] = true;
			Main.tileSolid[329] = true;
			Main.tileBrick[329] = true;
			Main.tileBlockLight[329] = true;
			Main.tileLighted[336] = true;
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
			Main.tileFrameImportant[339] = true;
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
			Main.tileFrameImportant[334] = true;
			Main.wallHouse[168] = true;
			Main.wallHouse[169] = true;
			Main.wallHouse[142] = true;
			Main.wallHouse[143] = true;
			Main.wallHouse[144] = true;
			Main.wallHouse[149] = true;
			Main.wallHouse[151] = true;
			Main.wallHouse[150] = true;
			Main.wallHouse[152] = true;
			for (int l = 153; l < 167; l++)
			{
				Main.wallHouse[l] = true;
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
			for (int m = 0; m < 172; m++)
			{
				Main.wallDungeon[m] = false;
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
			for (int n = 0; n < 10; n++)
			{
				Main.recentWorld[n] = "";
				Main.recentIP[n] = "";
				Main.recentPort[n] = 0;
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
			for (int num = 0; num < 3600; num++)
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
			Main.tileFrameImportant[319] = true;
			Main.tileFrameImportant[323] = true;
			Main.tileFrameImportant[335] = true;
			Main.tileFrameImportant[337] = true;
			Main.tileFrameImportant[141] = true;
			Main.tileFrameImportant[270] = true;
			Main.tileFrameImportant[271] = true;
			Main.tileFrameImportant[314] = true;
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
			Main.tileLavaDeath[316] = true;
			Main.tileLavaDeath[317] = true;
			Main.tileLavaDeath[318] = true;
			Main.tileLavaDeath[319] = true;
			Main.tileLavaDeath[323] = true;
			Main.tileLavaDeath[335] = true;
			Main.tileLavaDeath[338] = true;
			Main.tileLavaDeath[339] = true;
			Main.tileLighted[316] = true;
			Main.tileLighted[317] = true;
			Main.tileLighted[318] = true;
			for (int num2 = 0; num2 < 340; num2++)
			{
				if (Main.tileLavaDeath[num2])
				{
					Main.tileObsidianKill[num2] = true;
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
			for (int num3 = 0; num3 < 172; num3++)
			{
				if (num3 == 20)
				{
					Main.wallBlend[num3] = 14;
				}
				else if (num3 == 19)
				{
					Main.wallBlend[num3] = 9;
				}
				else if (num3 == 18)
				{
					Main.wallBlend[num3] = 8;
				}
				else if (num3 == 17)
				{
					Main.wallBlend[num3] = 7;
				}
				else if (num3 == 16 || num3 == 59)
				{
					Main.wallBlend[num3] = 2;
				}
				else if (num3 == 1 || (num3 >= 48 && num3 <= 53))
				{
					Main.wallBlend[num3] = 1;
				}
				else
				{
					Main.wallBlend[num3] = num3;
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
			for (int num4 = 0; num4 < 340; num4++)
			{
				if (Main.tileSolid[num4])
				{
					Main.tileNoSunLight[num4] = true;
				}
				Main.tileFrame[num4] = 0;
				Main.tileFrameCounter[num4] = 0;
			}
			Main.tileNoSunLight[54] = false;
			Main.tileNoSunLight[328] = false;
			Main.tileNoSunLight[19] = false;
			Main.tileNoSunLight[11] = true;
			Main.tileNoSunLight[189] = false;
			Main.tileNoSunLight[196] = false;
			for (int num5 = 0; num5 < Main.maxMenuItems; num5++)
			{
				this.menuItemScale[num5] = 0.8f;
			}
			for (int num6 = 0; num6 < 6001; num6++)
			{
				Main.dust[num6] = new Dust();
			}
			for (int num7 = 0; num7 < 401; num7++)
			{
				Main.item[num7] = new Item();
			}
			for (int num8 = 0; num8 < 201; num8++)
			{
				Main.npc[num8] = new NPC();
				Main.npc[num8].whoAmI = num8;
			}
			for (int num9 = 0; num9 < 256; num9++)
			{
				Main.player[num9] = new Player();
			}
			for (int num10 = 0; num10 < 1001; num10++)
			{
				Main.projectile[num10] = new Projectile();
			}
			for (int num11 = 0; num11 < 501; num11++)
			{
				Main.gore[num11] = new Gore();
			}
			for (int num12 = 0; num12 < Main.maxRain + 1; num12++)
			{
				Main.rain[num12] = new Rain();
			}
			for (int num16 = 0; num16 < 2749; num16++)
			{
				Item item = new Item();
				item.SetDefaults(num16, false);
				Main.itemName[num16] = item.name;
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
			NPC nPC = new NPC();
			for (int num17 = -65; num17 < 378; num17++)
			{
				if (num17 != 0)
				{
					nPC.netDefaults(num17);
					if (nPC.lifeMax > 32767)
					{
						Main.npcLifeBytes[num17] = 4;
					}
					else if (nPC.lifeMax > 127)
					{
						Main.npcLifeBytes[num17] = 2;
					}
					else
					{
						Main.npcLifeBytes[num17] = 1;
					}
				}
			}
			for (int num18 = 0; num18 < Recipe.maxRecipes; num18++)
			{
				Main.recipe[num18] = new Recipe();
				Main.availableRecipeY[num18] = (float)(65 * num18);
			}
			Recipe.SetupRecipes();
			for (int num20 = 0; num20 < Liquid.resLiquid; num20++)
			{
				Main.liquid[num20] = new Liquid();
			}
			for (int num21 = 0; num21 < 10000; num21++)
			{
				Main.liquidBuffer[num21] = new LiquidBuffer();
			}
			Lighting.LightingThreads = Environment.ProcessorCount - 1;
			this.shop[0] = new Chest(false);
			Chest.SetupTravelShop();
			for (int num22 = 1; num22 < Main.numShops; num22++)
			{
				this.shop[num22] = new Chest(false);
				this.shop[num22].SetupShop(num22);
			}
			Main.teamColor[0] = Color.White;
			Main.teamColor[1] = new Color(230, 40, 20);
			Main.teamColor[2] = new Color(20, 200, 30);
			Main.teamColor[3] = new Color(75, 90, 255);
			Main.teamColor[4] = new Color(200, 180, 0);
			/*if (Main.menuMode == 1)
			{
				Main.LoadPlayers();
			}*/
			for (int num23 = 1; num23 < 423; num23++)
			{
				Projectile projectile = new Projectile();
				projectile.SetDefaults(num23);
				if (projectile.hostile)
				{
					Main.projHostile[num23] = true;
				}
			}
			Netplay.Init();
			if (Main.skipMenu)
			{
				WorldGen.clearWorld();
				Main.gameMenu = false;
				/*Main.LoadPlayers();
				Main.player[Main.myPlayer] = (Player)Main.loadPlayer[0].Clone();
				Main.PlayerPath = Main.loadPlayerPath[0];*/
				Main.LoadWorlds();
				WorldGen.generateWorld(-1);
				WorldGen.EveryTileFrame();
				//Main.player[Main.myPlayer].Spawn();
			}
			else
			{
				/*IntPtr systemMenu = Main.GetSystemMenu(base.Window.Handle, false);
				int menuItemCount = Main.GetMenuItemCount(systemMenu);
				Main.RemoveMenu(systemMenu, menuItemCount - 1, 1024);*/
			}
			if (Main.dedServ)
			{
				return;
			}/*
			Main.clientUUID = Guid.NewGuid().ToString();
			base.Initialize();
			base.Window.AllowUserResizing = true;
			this.OpenSettings();
			if (Main.screenWidth > GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width)
			{
				Main.screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
			}
			if (Main.screenHeight > GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height)
			{
				Main.screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
			}
			Main.graphics.ApplyChanges();
			this.CheckBunny();
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
			this.OpenRecent();
			Star.SpawnStars();
			WorldGen.RandomWeather();
			foreach (DisplayMode current in GraphicsAdapter.DefaultAdapter.SupportedDisplayModes)
			{
				if (current.Width >= Main.minScreenW && current.Height >= Main.minScreenH && current.Width <= Main.maxScreenW && current.Height <= Main.maxScreenH)
				{
					bool flag = true;
					for (int num24 = 0; num24 < Main.numDisplayModes; num24++)
					{
						if (current.Width == Main.displayWidth[num24] && current.Height == Main.displayHeight[num24])
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						Main.displayHeight[Main.numDisplayModes] = current.Height;
						Main.displayWidth[Main.numDisplayModes] = current.Width;
						Main.numDisplayModes++;
					}
				}
			}
			if (Main.autoJoin)
			{
				Main.LoadPlayers();
				Main.menuMode = 1;
				Main.menuMultiplayer = true;
			}
			Main.fpsTimer.Start();
			Main.updateTimer.Start();*/
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
			bool xmas = false;
			if (day >= 15 && month == 12)
			{
				xmas = true;
			}

			ServerApi.Hooks.InvokeWorldChristmasCheck(ref xmas);

			Main.xMas = xmas;
		}
		public static void checkHalloween()
		{
			DateTime now = DateTime.Now;
			int day = now.Day;
			int month = now.Month;
			bool halloween = false;
			if (day >= 20 && month == 10)
			{
				halloween = true;
			}
			if (day <= 10 && month == 11)
			{
				halloween = true;
			}

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
				if (Main.cloudBGActive == 0f && Main.rand.Next((int)((float)(num2 * 8 / ((Main.dayRate == 0) ? 1 : Main.dayRate)) / num3)) == 0)
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
			if (Style == 2)
			{
				for (int j = 0; j < 50; j++)
				{
					Main.dust[Dust.NewDust(new Vector2((float)effectRect.X, (float)effectRect.Y), effectRect.Width, effectRect.Height, 58, 0f, 0f, 150, Color.GhostWhite, 1.2f)].velocity *= 0.5f;
				}
				return;
			}
			if (Style == 0)
			{
				Main.PlaySound(2, effectRect.X + effectRect.Width / 2, effectRect.Y + effectRect.Height / 2, 6);
				int num3 = effectRect.Width * effectRect.Height / 5;
				for (int k = 0; k < num3; k++)
				{
					int num4 = Dust.NewDust(new Vector2((float)effectRect.X, (float)effectRect.Y), effectRect.Width, effectRect.Height, 159, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num4].scale = (float)Main.rand.Next(20, 70) * 0.01f;
					if (k < 10)
					{
						Main.dust[num4].scale += 0.25f;
					}
					if (k < 5)
					{
						Main.dust[num4].scale += 0.25f;
					}
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
					if (Main.grasshopperCageFrame[num11] >= 0 && Main.grasshopperCageFrame[num11] <= 1)
					{
						Main.grasshopperCageFrameCounter[num11]++;
						if (Main.grasshopperCageFrameCounter[num11] >= 5)
						{
							Main.grasshopperCageFrame[num11]++;
							if (Main.grasshopperCageFrame[num11] > 1)
							{
								Main.grasshopperCageFrame[num11] = 0;
							}
							Main.grasshopperCageFrameCounter[num11] = 0;
							if (Main.rand.Next(15) == 0)
							{
								Main.grasshopperCageFrame[num11] = 2;
							}
						}
					}
					else if (Main.grasshopperCageFrame[num11] >= 2 && Main.grasshopperCageFrame[num11] <= 5)
					{
						Main.grasshopperCageFrameCounter[num11]++;
						if (Main.grasshopperCageFrameCounter[num11] >= 5)
						{
							Main.grasshopperCageFrameCounter[num11] = 0;
							Main.grasshopperCageFrame[num11]++;
						}
						if (Main.grasshopperCageFrame[num11] > 5)
						{
							Main.grasshopperCageFrame[num11] = 6;
						}
					}
					else if (Main.grasshopperCageFrame[num11] >= 6 && Main.grasshopperCageFrame[num11] <= 7)
					{
						Main.grasshopperCageFrameCounter[num11]++;
						if (Main.grasshopperCageFrameCounter[num11] >= 5)
						{
							Main.grasshopperCageFrame[num11]++;
							if (Main.grasshopperCageFrame[num11] > 7)
							{
								Main.grasshopperCageFrame[num11] = 6;
							}
							Main.grasshopperCageFrameCounter[num11] = 0;
							if (Main.rand.Next(15) == 0)
							{
								Main.grasshopperCageFrame[num11] = 8;
							}
						}
					}
					else if (Main.grasshopperCageFrame[num11] >= 8 && Main.grasshopperCageFrame[num11] <= 11)
					{
						Main.grasshopperCageFrameCounter[num11]++;
						if (Main.grasshopperCageFrameCounter[num11] >= 5)
						{
							Main.grasshopperCageFrameCounter[num11] = 0;
							Main.grasshopperCageFrame[num11]++;
						}
						if (Main.grasshopperCageFrame[num11] > 11)
						{
							Main.grasshopperCageFrame[num11] = 0;
						}
					}
				}
				for (int num12 = 0; num12 < Main.cageFrames; num12++)
				{
					byte maxValue = 5;
					if (Main.fishBowlFrameMode[num12] == 1)
					{
						if (Main.rand.Next(900) == 0)
						{
							Main.fishBowlFrameMode[num12] = (byte)Main.rand.Next((int)maxValue);
						}
						Main.fishBowlFrameCounter[num12]++;
						if (Main.fishBowlFrameCounter[num12] >= 5)
						{
							Main.fishBowlFrameCounter[num12] = 0;
							if (Main.fishBowlFrame[num12] == 10)
							{
								if (Main.rand.Next(20) == 0)
								{
									Main.fishBowlFrame[num12] = 11;
									Main.fishBowlFrameMode[num12] = 0;
								}
								else
								{
									Main.fishBowlFrame[num12] = 1;
								}
							}
							else
							{
								Main.fishBowlFrame[num12]++;
							}
						}
					}
					else if (Main.fishBowlFrameMode[num12] == 2)
					{
						if (Main.rand.Next(3600) == 0)
						{
							Main.fishBowlFrameMode[num12] = (byte)Main.rand.Next((int)maxValue);
						}
						Main.fishBowlFrameCounter[num12]++;
						if (Main.fishBowlFrameCounter[num12] >= 20)
						{
							Main.fishBowlFrameCounter[num12] = 0;
							if (Main.fishBowlFrame[num12] == 10)
							{
								if (Main.rand.Next(20) == 0)
								{
									Main.fishBowlFrame[num12] = 11;
									Main.fishBowlFrameMode[num12] = 0;
								}
								else
								{
									Main.fishBowlFrame[num12] = 1;
								}
							}
							else
							{
								Main.fishBowlFrame[num12]++;
							}
						}
					}
					else if (Main.fishBowlFrameMode[num12] == 3)
					{
						if (Main.rand.Next(3600) == 0)
						{
							Main.fishBowlFrameMode[num12] = (byte)Main.rand.Next((int)maxValue);
						}
						Main.fishBowlFrameCounter[num12]++;
						if (Main.fishBowlFrameCounter[num12] >= Main.rand.Next(5, 3600))
						{
							Main.fishBowlFrameCounter[num12] = 0;
							if (Main.fishBowlFrame[num12] == 10)
							{
								if (Main.rand.Next(20) == 0)
								{
									Main.fishBowlFrame[num12] = 11;
									Main.fishBowlFrameMode[num12] = 0;
								}
								else
								{
									Main.fishBowlFrame[num12] = 1;
								}
							}
							else
							{
								Main.fishBowlFrame[num12]++;
							}
						}
					}
					else if (Main.fishBowlFrame[num12] <= 10)
					{
						if (Main.rand.Next(3600) == 0)
						{
							Main.fishBowlFrameMode[num12] = (byte)Main.rand.Next((int)maxValue);
						}
						Main.fishBowlFrameCounter[num12]++;
						if (Main.fishBowlFrameCounter[num12] >= 10)
						{
							Main.fishBowlFrameCounter[num12] = 0;
							if (Main.fishBowlFrame[num12] == 10)
							{
								if (Main.rand.Next(12) == 0)
								{
									Main.fishBowlFrame[num12] = 11;
								}
								else
								{
									Main.fishBowlFrame[num12] = 1;
								}
							}
							else
							{
								Main.fishBowlFrame[num12]++;
							}
						}
					}
					else if (Main.fishBowlFrame[num12] == 12 || Main.fishBowlFrame[num12] == 13)
					{
						Main.fishBowlFrameCounter[num12]++;
						if (Main.fishBowlFrameCounter[num12] >= 10)
						{
							Main.fishBowlFrameCounter[num12] = 0;
							Main.fishBowlFrame[num12]++;
							if (Main.fishBowlFrame[num12] > 13)
							{
								if (Main.rand.Next(20) == 0)
								{
									Main.fishBowlFrame[num12] = 14;
								}
								else
								{
									Main.fishBowlFrame[num12] = 12;
								}
							}
						}
					}
					else if (Main.fishBowlFrame[num12] >= 11)
					{
						Main.fishBowlFrameCounter[num12]++;
						if (Main.fishBowlFrameCounter[num12] >= 10)
						{
							Main.fishBowlFrameCounter[num12] = 0;
							Main.fishBowlFrame[num12]++;
							if (Main.fishBowlFrame[num12] > 16)
							{
								Main.fishBowlFrame[num12] = 4;
							}
						}
					}
				}
				for (int num13 = 0; num13 < 8; num13++)
				{
					for (int num14 = 0; num14 < Main.cageFrames; num14++)
					{
						Main.butterflyCageFrameCounter[num13, num14]++;
						if (Main.rand.Next(3600) == 0)
						{
							Main.butterflyCageMode[num13, num14] = (byte)Main.rand.Next(5);
							if (Main.rand.Next(2) == 0)
							{
								Main.butterflyCageMode[num13, num14] += 10;
							}
						}
						int num15 = Main.rand.Next(3, 16);
						if (Main.butterflyCageMode[num13, num14] == 1 || Main.butterflyCageMode[num13, num14] == 11)
						{
							num15 = 3;
						}
						if (Main.butterflyCageMode[num13, num14] == 2 || Main.butterflyCageMode[num13, num14] == 12)
						{
							num15 = 5;
						}
						if (Main.butterflyCageMode[num13, num14] == 3 || Main.butterflyCageMode[num13, num14] == 13)
						{
							num15 = 10;
						}
						if (Main.butterflyCageMode[num13, num14] == 4 || Main.butterflyCageMode[num13, num14] == 14)
						{
							num15 = 15;
						}
						if (Main.butterflyCageMode[num13, num14] >= 10)
						{
							if (Main.butterflyCageFrame[num13, num14] <= 7)
							{
								if (Main.butterflyCageFrameCounter[num13, num14] >= num15)
								{
									Main.butterflyCageFrameCounter[num13, num14] = 0;
									Main.butterflyCageFrame[num13, num14]--;
									if (Main.butterflyCageFrame[num13, num14] < 0)
									{
										Main.butterflyCageFrame[num13, num14] = 7;
									}
									if (Main.butterflyCageFrame[num13, num14] == 1 || Main.butterflyCageFrame[num13, num14] == 4 || Main.butterflyCageFrame[num13, num14] == 6)
									{
										if (Main.rand.Next(20) == 0)
										{
											Main.butterflyCageFrame[num13, num14] += 8;
										}
										else if (Main.rand.Next(6) == 0)
										{
											if (Main.butterflyCageMode[num13, num14] >= 10)
											{
												Main.butterflyCageMode[num13, num14] -= 10;
											}
											else
											{
												Main.butterflyCageMode[num13, num14] += 10;
											}
										}
									}
								}
							}
							else if (Main.butterflyCageFrameCounter[num13, num14] >= num15)
							{
								Main.butterflyCageFrameCounter[num13, num14] = 0;
								Main.butterflyCageFrame[num13, num14]--;
								if (Main.butterflyCageFrame[num13, num14] < 8)
								{
									Main.butterflyCageFrame[num13, num14] = 14;
								}
								if (Main.butterflyCageFrame[num13, num14] == 9 || Main.butterflyCageFrame[num13, num14] == 12 || Main.butterflyCageFrame[num13, num14] == 14)
								{
									if (Main.rand.Next(20) == 0)
									{
										Main.butterflyCageFrame[num13, num14] -= 8;
									}
									else if (Main.rand.Next(6) == 0)
									{
										if (Main.butterflyCageMode[num13, num14] >= 10)
										{
											Main.butterflyCageMode[num13, num14] -= 10;
										}
										else
										{
											Main.butterflyCageMode[num13, num14] += 10;
										}
									}
								}
							}
						}
						else if (Main.butterflyCageFrame[num13, num14] <= 7)
						{
							if (Main.butterflyCageFrameCounter[num13, num14] >= num15)
							{
								Main.butterflyCageFrameCounter[num13, num14] = 0;
								Main.butterflyCageFrame[num13, num14]++;
								if (Main.butterflyCageFrame[num13, num14] > 7)
								{
									Main.butterflyCageFrame[num13, num14] = 0;
								}
								if ((Main.butterflyCageFrame[num13, num14] == 1 || Main.butterflyCageFrame[num13, num14] == 4 || Main.butterflyCageFrame[num13, num14] == 6) && Main.rand.Next(10) == 0)
								{
									Main.butterflyCageFrame[num13, num14] += 8;
								}
							}
						}
						else if (Main.butterflyCageFrameCounter[num13, num14] >= num15)
						{
							Main.butterflyCageFrameCounter[num13, num14] = 0;
							Main.butterflyCageFrame[num13, num14]++;
							if (Main.butterflyCageFrame[num13, num14] > 15)
							{
								Main.butterflyCageFrame[num13, num14] = 8;
							}
							if ((Main.butterflyCageFrame[num13, num14] == 9 || Main.butterflyCageFrame[num13, num14] == 12 || Main.butterflyCageFrame[num13, num14] == 14) && Main.rand.Next(10) == 0)
							{
								Main.butterflyCageFrame[num13, num14] -= 8;
							}
						}
					}
				}
				for (int num16 = 0; num16 < 3; num16++)
				{
					for (int num17 = 0; num17 < Main.cageFrames; num17++)
					{
						Main.jellyfishCageFrameCounter[num16, num17]++;
						if (Main.jellyfishCageMode[num16, num17] == 0 && Main.rand.Next(1800) == 0)
						{
							Main.jellyfishCageMode[num16, num17] = 1;
						}
						if (Main.jellyfishCageMode[num16, num17] == 2 && Main.rand.Next(60) == 0)
						{
							Main.jellyfishCageMode[num16, num17] = 3;
						}
						int num18 = 1;
						if (Main.jellyfishCageMode[num16, num17] == 0)
						{
							num18 = Main.rand.Next(10, 20);
						}
						if (Main.jellyfishCageMode[num16, num17] == 1)
						{
							num18 = Main.rand.Next(15, 25);
						}
						if (Main.jellyfishCageMode[num16, num17] == 2)
						{
							num18 = Main.rand.Next(4, 9);
						}
						if (Main.jellyfishCageMode[num16, num17] == 3)
						{
							num18 = Main.rand.Next(15, 25);
						}
						if (Main.jellyfishCageMode[num16, num17] == 0 && Main.jellyfishCageFrame[num16, num17] <= 3 && Main.jellyfishCageFrameCounter[num16, num17] >= num18)
						{
							Main.jellyfishCageFrameCounter[num16, num17] = 0;
							Main.jellyfishCageFrame[num16, num17]++;
							if (Main.jellyfishCageFrame[num16, num17] >= 4)
							{
								Main.jellyfishCageFrame[num16, num17] = 0;
							}
						}
						if (Main.jellyfishCageMode[num16, num17] == 1 && Main.jellyfishCageFrame[num16, num17] <= 7 && Main.jellyfishCageFrameCounter[num16, num17] >= num18)
						{
							Main.jellyfishCageFrameCounter[num16, num17] = 0;
							Main.jellyfishCageFrame[num16, num17]++;
							if (Main.jellyfishCageFrame[num16, num17] >= 7)
							{
								Main.jellyfishCageMode[num16, num17] = 2;
							}
						}
						if (Main.jellyfishCageMode[num16, num17] == 2 && Main.jellyfishCageFrame[num16, num17] <= 9 && Main.jellyfishCageFrameCounter[num16, num17] >= num18)
						{
							Main.jellyfishCageFrameCounter[num16, num17] = 0;
							Main.jellyfishCageFrame[num16, num17]++;
							if (Main.jellyfishCageFrame[num16, num17] >= 9)
							{
								Main.jellyfishCageFrame[num16, num17] = 7;
							}
						}
						if (Main.jellyfishCageMode[num16, num17] == 3 && Main.jellyfishCageFrame[num16, num17] <= 10 && Main.jellyfishCageFrameCounter[num16, num17] >= num18)
						{
							Main.jellyfishCageFrameCounter[num16, num17] = 0;
							Main.jellyfishCageFrame[num16, num17]++;
							if (Main.jellyfishCageFrame[num16, num17] >= 10)
							{
								Main.jellyfishCageFrame[num16, num17] = 3;
								Main.jellyfishCageMode[num16, num17] = 0;
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
			if (Main.chTitle)
			{
				Main.chTitle = false;
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
			/*if (!Main.dedServ)
			{
				if (Main.superFast)
				{
					base.IsFixedTimeStep = false;
					Main.graphics.SynchronizeWithVerticalRetrace = false;
				}
				else
				{
					if (Main.fixedTiming)
					{
						if (base.IsActive)
						{
							base.IsFixedTimeStep = false;
						}
						else
						{
							base.IsFixedTimeStep = true;
						}
					}
					else
					{
						base.IsFixedTimeStep = true;
						Main.graphics.SynchronizeWithVerticalRetrace = true;
					}
					Main.graphics.SynchronizeWithVerticalRetrace = true;
				}
				if (Main.treeMntBG[1] == 94 || (Main.treeMntBG[1] >= 114 && Main.treeMntBG[1] <= 116))
				{
					Main.bgFrameCounter[0]++;
					if (Main.bgFrameCounter[0] >= 6)
					{
						Main.bgFrameCounter[0] = 0;
						Main.bgFrame[0]++;
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
					else if (Main.bgFrame[0] == 2)
					{
						Main.treeMntBG[1] = 115;
					}
					else
					{
						Main.treeMntBG[1] = 116;
					}
					if (Main.bgFrame[0] == 0)
					{
						Main.treeMntBG[0] = 93;
					}
					else if (Main.bgFrame[0] == 1)
					{
						Main.treeMntBG[0] = 168;
					}
					else if (Main.bgFrame[0] == 2)
					{
						Main.treeMntBG[0] = 169;
					}
					else
					{
						Main.treeMntBG[0] = 170;
					}
				}
				if (Main.treeMntBG[1] >= 180 && Main.treeMntBG[1] <= 183)
				{
					Main.bgFrameCounter[0]++;
					if (Main.bgFrameCounter[0] >= 6)
					{
						Main.bgFrameCounter[0] = 0;
						Main.bgFrame[0]++;
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
					else if (Main.bgFrame[0] == 2)
					{
						Main.treeMntBG[1] = 182;
					}
					else
					{
						Main.treeMntBG[1] = 183;
					}
				}
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
					if (Main.saveTime.ElapsedMilliseconds > 300000L)
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
					if (Main.saveTime.ElapsedMilliseconds > 600000L)
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
					Main.teamCooldown--;
				}
				Main.updateTime++;
				if (Main.fpsTimer.ElapsedMilliseconds >= 1000L)
				{
					if ((float)Main.fpsCount >= 30f + 30f * Main.gfxQuality)
					{
						Main.gfxQuality += Main.gfxRate;
						Main.gfxRate += 0.005f;
					}
					else if ((float)Main.fpsCount < 29f + 30f * Main.gfxQuality)
					{
						Main.gfxRate = 0.01f;
						Main.gfxQuality -= 0.1f;
					}
					if (Main.gfxQuality < 0f)
					{
						Main.gfxQuality = 0f;
					}
					if (Main.gfxQuality > 1f)
					{
						Main.gfxQuality = 1f;
					}
					if (Main.maxQ && base.IsActive)
					{
						Main.gfxQuality = 1f;
						Main.maxQ = false;
					}
					Main.updateRate = Main.uCount;
					Main.frameRate = Main.fpsCount;
					Main.fpsCount = 0;
					Main.fpsTimer.Restart();
					Main.updateTime = 0;
					Main.drawTime = 0;
					Main.uCount = 0;
					if ((double)Main.gfxQuality < 0.8)
					{
						Main.mapTimeMax = (int)((1f - Main.gfxQuality) * 60f);
					}
					else
					{
						Main.mapTimeMax = 0;
					}
					int arg_5DA_0 = Main.netMode;
				}
				if (Main.fixedTiming)
				{
					float num2 = 16f;
					float num3 = (float)Main.updateTimer.ElapsedMilliseconds;
					if (num3 + Main.uCarry < num2 && !Main.superFast)
					{
						Main.drawSkip = true;
						return;
					}
					Main.uCarry += num3 - num2;
					if (Main.uCarry > 1000f)
					{
						Main.uCarry = 1000f;
					}
					Main.updateTimer.Restart();
				}
				Main.uCount++;
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
				Gore.goreTime = (int)(600f * Main.gfxQuality);
				Liquid.maxLiquid = (int)(2500f + 2500f * Main.gfxQuality);
				Liquid.cycles = (int)(17f - 10f * Main.gfxQuality);
				if ((double)Main.gfxQuality < 0.5)
				{
					Main.graphics.SynchronizeWithVerticalRetrace = false;
				}
				else
				{
					Main.graphics.SynchronizeWithVerticalRetrace = true;
				}
				if (Main.superFast)
				{
					Main.graphics.SynchronizeWithVerticalRetrace = false;
					Main.drawSkip = false;
				}
				if ((double)Main.gfxQuality < 0.2)
				{
					Lighting.maxRenderCount = 8;
				}
				else if ((double)Main.gfxQuality < 0.4)
				{
					Lighting.maxRenderCount = 7;
				}
				else if ((double)Main.gfxQuality < 0.6)
				{
					Lighting.maxRenderCount = 6;
				}
				else if ((double)Main.gfxQuality < 0.8)
				{
					Lighting.maxRenderCount = 5;
				}
				else
				{
					Lighting.maxRenderCount = 4;
				}
				if (Liquid.quickSettle)
				{
					Liquid.maxLiquid = Liquid.resLiquid;
					Liquid.cycles = 1;
				}
				if (!base.IsActive)
				{
					Main.hasFocus = false;
				}
				else
				{
					Main.hasFocus = true;
				}
				if (!Main.gameMenu || Main.netMode == 2)
				{
					WorldFile.tempRaining = Main.raining;
					WorldFile.tempRainTime = Main.rainTime;
					WorldFile.tempMaxRain = Main.maxRaining;
				}
				if (!base.IsActive && Main.netMode == 0)
				{
					base.IsMouseVisible = true;
					if (Main.netMode != 2 && Main.myPlayer >= 0)
					{
						Main.player[Main.myPlayer].delayUseItem = true;
					}
					Main.mouseLeftRelease = false;
					Main.mouseRightRelease = false;
					if (Main.gameMenu)
					{
						Main.UpdateMenu();
					}
					Main.gamePaused = true;
					return;
				}
				base.IsMouseVisible = false;
				Main.demonTorch += (float)Main.demonTorchDir * 0.01f;
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
				int num4 = 7;
				if (this.DiscoStyle == 0)
				{
					Main.DiscoG += num4;
					if (Main.DiscoG >= 255)
					{
						Main.DiscoG = 255;
						this.DiscoStyle++;
					}
				}
				if (this.DiscoStyle == 1)
				{
					Main.DiscoR -= num4;
					if (Main.DiscoR <= 0)
					{
						Main.DiscoR = 0;
						this.DiscoStyle++;
					}
				}
				if (this.DiscoStyle == 2)
				{
					Main.DiscoB += num4;
					if (Main.DiscoB >= 255)
					{
						Main.DiscoB = 255;
						this.DiscoStyle++;
					}
				}
				if (this.DiscoStyle == 3)
				{
					Main.DiscoG -= num4;
					if (Main.DiscoG <= 0)
					{
						Main.DiscoG = 0;
						this.DiscoStyle++;
					}
				}
				if (this.DiscoStyle == 4)
				{
					Main.DiscoR += num4;
					if (Main.DiscoR >= 255)
					{
						Main.DiscoR = 255;
						this.DiscoStyle++;
					}
				}
				if (this.DiscoStyle == 5)
				{
					Main.DiscoB -= num4;
					if (Main.DiscoB <= 0)
					{
						Main.DiscoB = 0;
						this.DiscoStyle = 0;
					}
				}
				if (Main.gFadeDir == 1)
				{
					Main.gFader += 0.1f;
					Main.gFade = (byte)Main.gFader;
					if (Main.gFade > 150)
					{
						Main.gFadeDir = 0;
					}
				}
				else
				{
					Main.gFader -= 0.1f;
					Main.gFade = (byte)Main.gFader;
					if (Main.gFade < 100)
					{
						Main.gFadeDir = 1;
					}
				}
				Main.wFrCounter += Main.windSpeed * 2f;
				if (Main.wFrCounter > 4f)
				{
					Main.wFrCounter = 0f;
					Main.wFrame += 1f;
				}
				if (Main.wFrCounter < 0f)
				{
					Main.wFrCounter = 4f;
					Main.wFrame -= 1f;
				}
				if (Main.wFrame > 16f)
				{
					Main.wFrame = 1f;
				}
				if (Main.wFrame < 1f)
				{
					Main.wFrame = 16f;
				}
				byte[] expr_B14_cp_0 = Main.wallFrameCounter;
				int expr_B14_cp_1 = 136;
				expr_B14_cp_0[expr_B14_cp_1] += 1;
				if (Main.wallFrameCounter[136] >= 5)
				{
					Main.wallFrameCounter[136] = 0;
					byte[] expr_B4B_cp_0 = Main.wallFrame;
					int expr_B4B_cp_1 = 136;
					expr_B4B_cp_0[expr_B4B_cp_1] += 1;
					if (Main.wallFrame[136] > 7)
					{
						Main.wallFrame[136] = 0;
					}
				}
				byte[] expr_B82_cp_0 = Main.wallFrameCounter;
				int expr_B82_cp_1 = 137;
				expr_B82_cp_0[expr_B82_cp_1] += 1;
				if (Main.wallFrameCounter[137] >= 10)
				{
					Main.wallFrameCounter[137] = 0;
					byte[] expr_BBA_cp_0 = Main.wallFrame;
					int expr_BBA_cp_1 = 137;
					expr_BBA_cp_0[expr_BBA_cp_1] += 1;
					if (Main.wallFrame[137] > 7)
					{
						Main.wallFrame[137] = 0;
					}
				}
				byte[] expr_BF1_cp_0 = Main.wallFrameCounter;
				int expr_BF1_cp_1 = 168;
				expr_BF1_cp_0[expr_BF1_cp_1] += 1;
				if (Main.wallFrameCounter[168] >= 5)
				{
					Main.wallFrameCounter[168] = 0;
					byte[] expr_C28_cp_0 = Main.wallFrame;
					int expr_C28_cp_1 = 168;
					expr_C28_cp_0[expr_C28_cp_1] += 1;
					if (Main.wallFrame[168] > 7)
					{
						Main.wallFrame[168] = 0;
					}
				}
				byte[] expr_C5F_cp_0 = Main.wallFrameCounter;
				int expr_C5F_cp_1 = 169;
				expr_C5F_cp_0[expr_C5F_cp_1] += 1;
				if (Main.wallFrameCounter[169] >= 5)
				{
					Main.wallFrameCounter[169] = 0;
					byte[] expr_C96_cp_0 = Main.wallFrame;
					int expr_C96_cp_1 = 169;
					expr_C96_cp_0[expr_C96_cp_1] += 1;
					if (Main.wallFrame[169] > 7)
					{
						Main.wallFrame[169] = 0;
					}
				}
				byte[] expr_CCD_cp_0 = Main.wallFrameCounter;
				int expr_CCD_cp_1 = 144;
				expr_CCD_cp_0[expr_CCD_cp_1] += 1;
				int num5 = 5;
				int num6 = 10;
				if ((int)Main.wallFrameCounter[144] < num5)
				{
					Main.wallFrame[144] = 0;
				}
				else if ((int)Main.wallFrameCounter[144] < num5)
				{
					Main.wallFrame[144] = 1;
				}
				else if ((int)Main.wallFrameCounter[144] < num5 * 2)
				{
					Main.wallFrame[144] = 2;
				}
				else if ((int)Main.wallFrameCounter[144] < num5 * 3)
				{
					Main.wallFrame[144] = 3;
				}
				else if ((int)Main.wallFrameCounter[144] < num5 * 4)
				{
					Main.wallFrame[144] = 4;
				}
				else if ((int)Main.wallFrameCounter[144] < num5 * 5)
				{
					Main.wallFrame[144] = 5;
				}
				else if ((int)Main.wallFrameCounter[144] < num5 * 6)
				{
					Main.wallFrame[144] = 6;
				}
				else if ((int)Main.wallFrameCounter[144] < num5 * 7)
				{
					Main.wallFrame[144] = 7;
				}
				else if ((int)Main.wallFrameCounter[144] < num5 * (8 + num6))
				{
					Main.wallFrame[144] = 8;
				}
				else if ((int)Main.wallFrameCounter[144] < num5 * (9 + num6))
				{
					Main.wallFrame[144] = 7;
				}
				else if ((int)Main.wallFrameCounter[144] < num5 * (10 + num6))
				{
					Main.wallFrame[144] = 6;
				}
				else if ((int)Main.wallFrameCounter[144] < num5 * (11 + num6))
				{
					Main.wallFrame[144] = 5;
				}
				else if ((int)Main.wallFrameCounter[144] < num5 * (12 + num6))
				{
					Main.wallFrame[144] = 4;
				}
				else if ((int)Main.wallFrameCounter[144] < num5 * (13 + num6))
				{
					Main.wallFrame[144] = 3;
				}
				else if ((int)Main.wallFrameCounter[144] < num5 * (14 + num6))
				{
					Main.wallFrame[144] = 2;
				}
				else if ((int)Main.wallFrameCounter[144] < num5 * (15 + num6))
				{
					Main.wallFrame[144] = 1;
				}
				else
				{
					Main.wallFrame[144] = 0;
					if ((int)Main.wallFrameCounter[144] > num5 * (16 + num6 * 2))
					{
						Main.wallFrameCounter[144] = 0;
					}
				}
				Main.tileFrameCounter[12]++;
				if (Main.tileFrameCounter[12] > 5)
				{
					Main.tileFrameCounter[12] = 0;
					Main.tileFrame[12]++;
					if (Main.tileFrame[12] >= 10)
					{
						Main.tileFrame[12] = 0;
					}
				}
				Main.tileFrameCounter[17]++;
				if (Main.tileFrameCounter[17] > 5)
				{
					Main.tileFrameCounter[17] = 0;
					Main.tileFrame[17]++;
					if (Main.tileFrame[17] >= 12)
					{
						Main.tileFrame[17] = 0;
					}
				}
				Main.tileFrameCounter[31]++;
				if (Main.tileFrameCounter[31] > 10)
				{
					Main.tileFrameCounter[31] = 0;
					Main.tileFrame[31]++;
					if (Main.tileFrame[31] > 1)
					{
						Main.tileFrame[31] = 0;
					}
				}
				Main.tileFrameCounter[77]++;
				if (Main.tileFrameCounter[77] > 5)
				{
					Main.tileFrameCounter[77] = 0;
					Main.tileFrame[77]++;
					if (Main.tileFrame[77] >= 12)
					{
						Main.tileFrame[77] = 0;
					}
				}
				Main.tileFrameCounter[106]++;
				if (Main.tileFrameCounter[106] > 4)
				{
					Main.tileFrameCounter[106] = 0;
					Main.tileFrame[106]++;
					if (Main.tileFrame[106] >= 2)
					{
						Main.tileFrame[106] = 0;
					}
				}
				Main.tileFrameCounter[207]++;
				if (Main.tileFrameCounter[207] > 4)
				{
					Main.tileFrameCounter[207] = 0;
					Main.tileFrame[207]++;
					if (Main.tileFrame[207] >= 6)
					{
						Main.tileFrame[207] = 0;
					}
				}
				Main.tileFrameCounter[215]++;
				if (Main.tileFrameCounter[215] > 4)
				{
					Main.tileFrameCounter[215] = 0;
					Main.tileFrame[215]++;
					if (Main.tileFrame[215] >= 4)
					{
						Main.tileFrame[215] = 0;
					}
				}
				Main.tileFrameCounter[217]++;
				if (Main.tileFrameCounter[217] > 4)
				{
					Main.tileFrameCounter[217] = 0;
					Main.tileFrame[217]++;
					if (Main.tileFrame[217] >= 5)
					{
						Main.tileFrame[217] = 0;
					}
				}
				Main.tileFrameCounter[218]++;
				if (Main.tileFrameCounter[218] > 4)
				{
					Main.tileFrameCounter[218] = 0;
					Main.tileFrame[218]++;
					if (Main.tileFrame[218] >= 2)
					{
						Main.tileFrame[218] = 0;
					}
				}
				Main.tileFrameCounter[219]++;
				if (Main.tileFrameCounter[219] > 4)
				{
					Main.tileFrameCounter[219] = 0;
					Main.tileFrame[219]++;
					if (Main.tileFrame[219] >= 10)
					{
						Main.tileFrame[219] = 0;
					}
				}
				Main.tileFrameCounter[220]++;
				if (Main.tileFrameCounter[220] > 4)
				{
					Main.tileFrameCounter[220] = 0;
					Main.tileFrame[220]++;
					if (Main.tileFrame[220] >= 4)
					{
						Main.tileFrame[220] = 0;
					}
				}
				Main.tileFrameCounter[231]++;
				if (Main.tileFrameCounter[231] > 16)
				{
					Main.tileFrameCounter[231] = 0;
					Main.tileFrame[231]++;
					if (Main.tileFrame[231] >= 7)
					{
						Main.tileFrame[231] = 0;
					}
				}
				Main.tileFrameCounter[235]++;
				if (Main.tileFrameCounter[235] > 20)
				{
					Main.tileFrameCounter[235] = 0;
					Main.tileFrame[235]++;
					if (Main.tileFrame[235] >= 4)
					{
						Main.tileFrame[235] = 0;
					}
					if (Main.tileFrame[235] > 1)
					{
						Main.tileLighted[235] = true;
					}
					else
					{
						Main.tileLighted[235] = false;
					}
				}
				Main.tileFrameCounter[238]++;
				if (Main.tileFrameCounter[238] > 20)
				{
					Main.tileFrameCounter[238] = 0;
					Main.tileFrame[238]++;
					if (Main.tileFrame[238] >= 4)
					{
						Main.tileFrame[238] = 0;
					}
				}
				Main.tileFrameCounter[243]++;
				if (Main.tileFrameCounter[243] > 4)
				{
					Main.tileFrameCounter[243] = 0;
					Main.tileFrame[243]++;
					if (Main.tileFrame[243] >= 6)
					{
						Main.tileFrame[243] = 0;
					}
				}
				Main.tileFrameCounter[244]++;
				if (Main.tileFrameCounter[244] > 4)
				{
					Main.tileFrameCounter[244] = 0;
					Main.tileFrame[244]++;
					if (Main.tileFrame[244] >= 6)
					{
						Main.tileFrame[244] = 0;
					}
				}
				Main.tileFrameCounter[247]++;
				if (Main.tileFrameCounter[247] > 4)
				{
					Main.tileFrameCounter[247] = 0;
					Main.tileFrame[247]++;
					if (Main.tileFrame[247] > 7)
					{
						Main.tileFrame[247] = 0;
					}
				}
				Main.tileFrameCounter[96]++;
				if (Main.tileFrameCounter[96] > 4)
				{
					Main.tileFrameCounter[96] = 0;
					Main.tileFrame[96]++;
					if (Main.tileFrame[96] > 3)
					{
						Main.tileFrame[96] = 0;
					}
				}
				Main.tileFrameCounter[171]++;
				if (Main.tileFrameCounter[171] > 16)
				{
					Main.tileFrameCounter[171] = 0;
					Main.tileFrame[171]++;
					if (Main.tileFrame[171] > 3)
					{
						Main.tileFrame[171] = 0;
					}
				}
				Main.tileFrameCounter[270]++;
				if (Main.tileFrameCounter[270] > 8)
				{
					Main.tileFrameCounter[270] = 0;
					Main.tileFrame[270]++;
					if (Main.tileFrame[270] > 5)
					{
						Main.tileFrame[270] = 0;
					}
				}
				Main.tileFrame[271] = Main.tileFrame[270];
				Main.tileFrameCounter[272]++;
				if (Main.tileFrameCounter[272] >= 10)
				{
					Main.tileFrameCounter[272] = 0;
					Main.tileFrame[272]++;
					if (Main.tileFrame[272] > 1)
					{
						Main.tileFrame[272] = 0;
					}
				}
				Main.tileFrameCounter[300]++;
				if (Main.tileFrameCounter[300] >= 5)
				{
					Main.tileFrameCounter[300] = 0;
					Main.tileFrame[300]++;
					if (Main.tileFrame[300] > 6)
					{
						Main.tileFrame[300] = 0;
					}
				}
				Main.tileFrameCounter[301]++;
				if (Main.tileFrameCounter[301] >= 5)
				{
					Main.tileFrameCounter[301] = 0;
					Main.tileFrame[301]++;
					if (Main.tileFrame[301] > 7)
					{
						Main.tileFrame[301] = 0;
					}
				}
				Main.tileFrameCounter[302]++;
				if (Main.tileFrameCounter[302] >= 5)
				{
					Main.tileFrameCounter[302] = 0;
					Main.tileFrame[302]++;
					if (Main.tileFrame[302] > 3)
					{
						Main.tileFrame[302] = 0;
					}
				}
				Main.tileFrameCounter[303]++;
				if (Main.tileFrameCounter[303] >= 5)
				{
					Main.tileFrameCounter[303] = 0;
					Main.tileFrame[303]++;
					if (Main.tileFrame[303] > 4)
					{
						Main.tileFrame[303] = 0;
					}
				}
				Main.tileFrameCounter[305]++;
				if (Main.tileFrameCounter[305] >= 5)
				{
					Main.tileFrameCounter[305] = 0;
					Main.tileFrame[305]++;
					if (Main.tileFrame[305] > 11)
					{
						Main.tileFrame[305] = 0;
					}
				}
				Main.tileFrameCounter[306]++;
				if (Main.tileFrameCounter[306] >= 5)
				{
					Main.tileFrameCounter[306] = 0;
					Main.tileFrame[306]++;
					if (Main.tileFrame[306] > 11)
					{
						Main.tileFrame[306] = 0;
					}
				}
				Main.tileFrameCounter[307]++;
				if (Main.tileFrameCounter[307] >= 5)
				{
					Main.tileFrameCounter[307] = 0;
					Main.tileFrame[307]++;
					if (Main.tileFrame[307] > 1)
					{
						Main.tileFrame[307] = 0;
					}
				}
				Main.tileFrameCounter[308]++;
				if (Main.tileFrameCounter[308] >= 5)
				{
					Main.tileFrameCounter[308] = 0;
					Main.tileFrame[308]++;
					if (Main.tileFrame[308] > 7)
					{
						Main.tileFrame[308] = 0;
					}
				}
				Main.tileFrameCounter[314]++;
				if (Main.tileFrameCounter[314] >= 10)
				{
					Main.tileFrameCounter[314] = 0;
					Main.tileFrame[314]++;
					if (Main.tileFrame[314] > 4)
					{
						Main.tileFrame[314] = 0;
					}
				}
				Main.tileFrameCounter[326]++;
				if (Main.tileFrameCounter[326] >= 5)
				{
					Main.tileFrameCounter[326] = 0;
					Main.tileFrame[326]++;
					if (Main.tileFrame[326] > 7)
					{
						Main.tileFrame[326] = 0;
					}
				}
				Main.tileFrameCounter[327]++;
				if (Main.tileFrameCounter[327] >= 10)
				{
					Main.tileFrameCounter[327] = 0;
					Main.tileFrame[327]++;
					if (Main.tileFrame[327] > 7)
					{
						Main.tileFrame[327] = 0;
					}
				}
				Main.tileFrameCounter[336]++;
				if (Main.tileFrameCounter[336] >= 5)
				{
					Main.tileFrameCounter[336] = 0;
					Main.tileFrame[336]++;
					if (Main.tileFrame[336] > 3)
					{
						Main.tileFrame[336] = 0;
					}
				}
				Main.tileFrameCounter[328]++;
				if (Main.tileFrameCounter[328] >= 5)
				{
					Main.tileFrameCounter[328] = 0;
					Main.tileFrame[328]++;
					if (Main.tileFrame[328] > 7)
					{
						Main.tileFrame[328] = 0;
					}
				}
				Main.tileFrameCounter[329]++;
				if (Main.tileFrameCounter[329] >= 5)
				{
					Main.tileFrameCounter[329] = 0;
					Main.tileFrame[329]++;
					if (Main.tileFrame[329] > 7)
					{
						Main.tileFrame[329] = 0;
					}
				}
				Main.CritterCages();
				if (Main.keyState.IsKeyDown(Keys.F10) && !Main.chatMode && !Main.editSign && !Main.editChest)
				{
					if (Main.frameRelease)
					{
						Main.PlaySound(12, -1, -1, 1);
						if (Main.showFrameRate)
						{
							Main.showFrameRate = false;
						}
						else
						{
							Main.showFrameRate = true;
						}
					}
					Main.frameRelease = false;
				}
				else
				{
					Main.frameRelease = true;
				}
				if (Main.keyState.IsKeyDown(Keys.F9) && !Main.chatMode && !Main.editSign && !Main.editChest)
				{
					if (Main.RGBRelease)
					{
						Main.PlaySound(12, -1, -1, 1);
						Lighting.NextLightMode();
					}
					Main.RGBRelease = false;
				}
				else
				{
					Main.RGBRelease = true;
				}
				if (Main.keyState.IsKeyDown(Keys.F8) && !Main.chatMode && !Main.editSign && !Main.editChest)
				{
					if (Main.netRelease)
					{
						Main.PlaySound(12, -1, -1, 1);
						if (Main.netDiag)
						{
							Main.netDiag = false;
						}
						else
						{
							Main.netDiag = true;
						}
					}
					Main.netRelease = false;
				}
				else
				{
					Main.netRelease = true;
				}
				if (Main.keyState.IsKeyDown(Keys.F7) && !Main.chatMode && !Main.editSign && !Main.editChest)
				{
					if (Main.drawRelease)
					{
						Main.PlaySound(12, -1, -1, 1);
						if (Main.drawDiag)
						{
							Main.drawDiag = false;
						}
						else
						{
							Main.drawDiag = true;
						}
					}
					Main.drawRelease = false;
				}
				else
				{
					Main.drawRelease = true;
				}
				if (Main.keyState.IsKeyDown(Keys.F11))
				{
					if (Main.releaseUI)
					{
						if (Main.hideUI)
						{
							Main.hideUI = false;
						}
						else
						{
							Main.hideUI = true;
						}
					}
					Main.releaseUI = false;
				}
				else
				{
					Main.releaseUI = true;
				}
				if ((Main.keyState.IsKeyDown(Keys.LeftAlt) || Main.keyState.IsKeyDown(Keys.RightAlt)) && Main.keyState.IsKeyDown(Keys.Enter))
				{
					if (Main.toggleFullscreen)
					{
						Main.graphics.ToggleFullScreen();
						Main.chatRelease = false;
					}
					Main.toggleFullscreen = false;
				}
				else
				{
					Main.toggleFullscreen = true;
				}
				if (!Main.gamePad || Main.gameMenu)
				{
					Main.oldMouseState = Main.mouseState;
					Main.mouseState = Mouse.GetState();
					Main.mouseX = Main.mouseState.X;
					Main.mouseY = Main.mouseState.Y;
					Main.mouseLeft = false;
					Main.mouseRight = false;
					if (base.IsActive)
					{
						if (Main.mouseState.LeftButton == ButtonState.Pressed)
						{
							Main.mouseLeft = true;
						}
						if (Main.mouseState.RightButton == ButtonState.Pressed)
						{
							Main.mouseRight = true;
						}
					}
				}
				Main.keyState = Keyboard.GetState();
				if (Main.editSign)
				{
					Main.chatMode = false;
				}
				if (!Main.chatMode)
				{
					Main.startChatLine = 0;
				}
				if (Main.chatMode)
				{
					Main.showCount = (int)((float)(Main.screenHeight / 3) / Main.fontMouseText.MeasureString("1").Y) - 1;
					if (Main.keyState.IsKeyDown(Keys.Up))
					{
						Main.startChatLine++;
						if (Main.startChatLine + Main.showCount >= Main.numChatLines - 1)
						{
							Main.startChatLine = Main.numChatLines - Main.showCount - 1;
						}
						if (Main.chatLine[Main.startChatLine + Main.showCount].text == "")
						{
							Main.startChatLine--;
						}
					}
					else if (Main.keyState.IsKeyDown(Keys.Down))
					{
						Main.startChatLine--;
						if (Main.startChatLine < 0)
						{
							Main.startChatLine = 0;
						}
					}
					if (Main.keyState.IsKeyDown(Keys.Escape))
					{
						Main.chatMode = false;
					}
					string text = Main.chatText;
					Main.chatText = Main.GetInputText(Main.chatText);
					int num7 = Main.screenWidth - 330;
					while (Main.fontMouseText.MeasureString(Main.chatText).X > (float)num7)
					{
						Main.chatText = Main.chatText.Substring(0, Main.chatText.Length - 1);
					}
					if (text != Main.chatText)
					{
						Main.PlaySound(12, -1, -1, 1);
					}
					if (Main.inputTextEnter && Main.chatRelease)
					{
						if (Main.chatText != "")
						{
							NetMessage.SendData(25, -1, -1, Main.chatText, Main.myPlayer, 0f, 0f, 0f, 0);
						}
						Main.chatText = "";
						Main.chatMode = false;
						Main.chatRelease = false;
						Main.player[Main.myPlayer].releaseHook = false;
						Main.player[Main.myPlayer].releaseThrow = false;
						Main.PlaySound(11, -1, -1, 1);
					}
				}
				if (Main.keyState.IsKeyDown(Keys.Enter) && Main.netMode == 1 && !Main.keyState.IsKeyDown(Keys.LeftAlt) && !Main.keyState.IsKeyDown(Keys.RightAlt))
				{
					if (Main.chatRelease && !Main.chatMode && !Main.editSign && !Main.editChest && !Main.gameMenu && !Main.keyState.IsKeyDown(Keys.Escape))
					{
						Main.PlaySound(10, -1, -1, 1);
						Main.chatMode = true;
						Main.clrInput();
						Main.chatText = "";
					}
					Main.chatRelease = false;
				}
				else
				{
					Main.chatRelease = true;
				}
				if (Main.gameMenu)
				{
					Main.UpdateMenu();
					if (Main.netMode != 2)
					{
						return;
					}
					Main.gamePaused = false;
				}
			}
			if (Main.netMode == 1)
			{
				for (int i = 0; i < 59; i++)
				{
					if (Main.player[Main.myPlayer].inventory[i].IsNotTheSameAs(Main.clientPlayer.inventory[i]))
					{
						NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].inventory[i].name, Main.myPlayer, (float)i, (float)Main.player[Main.myPlayer].inventory[i].prefix, 0f, 0);
					}
				}
				if (Main.player[Main.myPlayer].armor[0].IsNotTheSameAs(Main.clientPlayer.armor[0]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[0].name, Main.myPlayer, 59f, (float)Main.player[Main.myPlayer].armor[0].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[1].IsNotTheSameAs(Main.clientPlayer.armor[1]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[1].name, Main.myPlayer, 60f, (float)Main.player[Main.myPlayer].armor[1].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[2].IsNotTheSameAs(Main.clientPlayer.armor[2]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[2].name, Main.myPlayer, 61f, (float)Main.player[Main.myPlayer].armor[2].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[3].IsNotTheSameAs(Main.clientPlayer.armor[3]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[3].name, Main.myPlayer, 62f, (float)Main.player[Main.myPlayer].armor[3].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[4].IsNotTheSameAs(Main.clientPlayer.armor[4]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[4].name, Main.myPlayer, 63f, (float)Main.player[Main.myPlayer].armor[4].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[5].IsNotTheSameAs(Main.clientPlayer.armor[5]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[5].name, Main.myPlayer, 64f, (float)Main.player[Main.myPlayer].armor[5].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[6].IsNotTheSameAs(Main.clientPlayer.armor[6]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[6].name, Main.myPlayer, 65f, (float)Main.player[Main.myPlayer].armor[6].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[7].IsNotTheSameAs(Main.clientPlayer.armor[7]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[7].name, Main.myPlayer, 66f, (float)Main.player[Main.myPlayer].armor[7].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[8].IsNotTheSameAs(Main.clientPlayer.armor[8]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[8].name, Main.myPlayer, 67f, (float)Main.player[Main.myPlayer].armor[8].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[9].IsNotTheSameAs(Main.clientPlayer.armor[9]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[9].name, Main.myPlayer, 68f, (float)Main.player[Main.myPlayer].armor[9].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[10].IsNotTheSameAs(Main.clientPlayer.armor[10]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[10].name, Main.myPlayer, 69f, (float)Main.player[Main.myPlayer].armor[10].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[11].IsNotTheSameAs(Main.clientPlayer.armor[11]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[11].name, Main.myPlayer, 70f, (float)Main.player[Main.myPlayer].armor[11].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[12].IsNotTheSameAs(Main.clientPlayer.armor[12]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[12].name, Main.myPlayer, 71f, (float)Main.player[Main.myPlayer].armor[12].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[13].IsNotTheSameAs(Main.clientPlayer.armor[13]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[13].name, Main.myPlayer, 72f, (float)Main.player[Main.myPlayer].armor[13].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[14].IsNotTheSameAs(Main.clientPlayer.armor[14]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[14].name, Main.myPlayer, 73f, (float)Main.player[Main.myPlayer].armor[14].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[15].IsNotTheSameAs(Main.clientPlayer.armor[15]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[15].name, Main.myPlayer, 74f, (float)Main.player[Main.myPlayer].armor[15].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].dye[0].IsNotTheSameAs(Main.clientPlayer.dye[0]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].dye[0].name, Main.myPlayer, 75f, (float)Main.player[Main.myPlayer].dye[0].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].dye[1].IsNotTheSameAs(Main.clientPlayer.dye[1]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].dye[1].name, Main.myPlayer, 76f, (float)Main.player[Main.myPlayer].dye[1].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].dye[2].IsNotTheSameAs(Main.clientPlayer.dye[2]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].dye[2].name, Main.myPlayer, 77f, (float)Main.player[Main.myPlayer].dye[2].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].dye[3].IsNotTheSameAs(Main.clientPlayer.dye[3]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].dye[3].name, Main.myPlayer, 78f, (float)Main.player[Main.myPlayer].dye[3].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].dye[4].IsNotTheSameAs(Main.clientPlayer.dye[4]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].dye[4].name, Main.myPlayer, 79f, (float)Main.player[Main.myPlayer].dye[4].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].dye[5].IsNotTheSameAs(Main.clientPlayer.dye[5]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].dye[5].name, Main.myPlayer, 80f, (float)Main.player[Main.myPlayer].dye[5].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].dye[6].IsNotTheSameAs(Main.clientPlayer.dye[6]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].dye[6].name, Main.myPlayer, 81f, (float)Main.player[Main.myPlayer].dye[6].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].dye[7].IsNotTheSameAs(Main.clientPlayer.dye[7]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].dye[7].name, Main.myPlayer, 82f, (float)Main.player[Main.myPlayer].dye[7].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].chest != Main.clientPlayer.chest && Main.player[Main.myPlayer].chest < 0)
				{
					if (Main.player[Main.myPlayer].editedChestName)
					{
						NetMessage.SendData(33, -1, -1, Main.chest[Main.clientPlayer.chest].name, Main.player[Main.myPlayer].chest, 1f, 0f, 0f, 0);
						Main.player[Main.myPlayer].editedChestName = false;
					}
					else
					{
						NetMessage.SendData(33, -1, -1, "", Main.player[Main.myPlayer].chest, 0f, 0f, 0f, 0);
					}
				}
				if (Main.player[Main.myPlayer].talkNPC != Main.clientPlayer.talkNPC)
				{
					NetMessage.SendData(40, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
				if (Main.player[Main.myPlayer].zoneEvil != Main.clientPlayer.zoneEvil)
				{
					NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
				if (Main.player[Main.myPlayer].zoneMeteor != Main.clientPlayer.zoneMeteor)
				{
					NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
				if (Main.player[Main.myPlayer].zoneDungeon != Main.clientPlayer.zoneDungeon)
				{
					NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
				if (Main.player[Main.myPlayer].zoneJungle != Main.clientPlayer.zoneJungle)
				{
					NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
				if (Main.player[Main.myPlayer].zoneHoly != Main.clientPlayer.zoneHoly)
				{
					NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
				if (Main.player[Main.myPlayer].zoneSnow != Main.clientPlayer.zoneSnow)
				{
					NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
				if (Main.player[Main.myPlayer].zoneBlood != Main.clientPlayer.zoneBlood)
				{
					NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
				if (Main.player[Main.myPlayer].zoneCandle != Main.clientPlayer.zoneCandle)
				{
					NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
				if (Main.player[Main.myPlayer].statLife != Main.clientPlayer.statLife || Main.player[Main.myPlayer].statLifeMax != Main.clientPlayer.statLifeMax)
				{
					Main.player[Main.myPlayer].netLife = true;
				}
				if (Main.player[Main.myPlayer].netLifeTime > 0)
				{
					Main.player[Main.myPlayer].netLifeTime--;
				}
				else if (Main.player[Main.myPlayer].netLife)
				{
					Main.player[Main.myPlayer].netLife = false;
					Main.player[Main.myPlayer].netLifeTime = 60;
					NetMessage.SendData(16, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
				if (Main.player[Main.myPlayer].statMana != Main.clientPlayer.statMana || Main.player[Main.myPlayer].statManaMax != Main.clientPlayer.statManaMax)
				{
					Main.player[Main.myPlayer].netMana = true;
				}
				if (Main.player[Main.myPlayer].netManaTime > 0)
				{
					Main.player[Main.myPlayer].netManaTime--;
				}
				else if (Main.player[Main.myPlayer].netMana)
				{
					Main.player[Main.myPlayer].netMana = false;
					Main.player[Main.myPlayer].netManaTime = 60;
					NetMessage.SendData(42, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
				bool flag = false;
				for (int j = 0; j < 22; j++)
				{
					if (Main.player[Main.myPlayer].buffType[j] != Main.clientPlayer.buffType[j])
					{
						flag = true;
					}
				}
				if (flag)
				{
					NetMessage.SendData(50, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
					NetMessage.SendData(13, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
			}
			if (Main.netMode == 1)
			{
				Main.clientPlayer = (Player)Main.player[Main.myPlayer].clientClone();
			}
			if (Main.netMode == 0 && (Main.playerInventory || Main.npcChatText != "" || Main.player[Main.myPlayer].sign >= 0 || Main.ingameOptionsWindow) && Main.autoPause)
			{
				if (!Main.chatMode && !Main.editSign && !Main.editChest && !Main.blockInput)
				{
					Keys[] pressedKeys = Main.keyState.GetPressedKeys();
					if (Main.blockKey != Keys.None)
					{
						bool flag2 = false;
						for (int k = 0; k < pressedKeys.Length; k++)
						{
							if (pressedKeys[k] == Main.blockKey)
							{
								pressedKeys[k] = Keys.None;
								flag2 = true;
							}
						}
						if (!flag2)
						{
							Main.blockKey = Keys.None;
						}
					}
					Main.player[Main.myPlayer].controlInv = false;
					for (int l = 0; l < pressedKeys.Length; l++)
					{
						string text2 = string.Concat(pressedKeys[l]);
						if (text2 == Main.cInv)
						{
							Main.player[Main.myPlayer].controlInv = true;
						}
					}
					if (Main.player[Main.myPlayer].controlInv)
					{
						if (Main.player[Main.myPlayer].releaseInventory)
						{
							Main.player[Main.myPlayer].toggleInv();
						}
						Main.player[Main.myPlayer].releaseInventory = false;
					}
					else
					{
						Main.player[Main.myPlayer].releaseInventory = true;
					}
				}
				if (Main.playerInventory)
				{
					int num8 = (Main.mouseState.ScrollWheelValue - Main.oldMouseState.ScrollWheelValue) / 120;
					Main.focusRecipe += num8;
					if (Main.focusRecipe > Main.numAvailableRecipes - 1)
					{
						Main.focusRecipe = Main.numAvailableRecipes - 1;
					}
					if (Main.focusRecipe < 0)
					{
						Main.focusRecipe = 0;
					}
					Main.player[Main.myPlayer].dropItemCheck();
				}
				Main.player[Main.myPlayer].head = Main.player[Main.myPlayer].armor[0].headSlot;
				Main.player[Main.myPlayer].body = Main.player[Main.myPlayer].armor[1].bodySlot;
				Main.player[Main.myPlayer].legs = Main.player[Main.myPlayer].armor[2].legSlot;
				if (!Main.player[Main.myPlayer].hostile)
				{
					if (Main.player[Main.myPlayer].armor[8].headSlot >= 0)
					{
						Main.player[Main.myPlayer].head = Main.player[Main.myPlayer].armor[8].headSlot;
					}
					if (Main.player[Main.myPlayer].armor[9].bodySlot >= 0)
					{
						Main.player[Main.myPlayer].body = Main.player[Main.myPlayer].armor[9].bodySlot;
					}
					if (Main.player[Main.myPlayer].armor[10].legSlot >= 0)
					{
						Main.player[Main.myPlayer].legs = Main.player[Main.myPlayer].armor[10].legSlot;
					}
				}
				if (Main.editSign)
				{
					if (Main.player[Main.myPlayer].sign == -1)
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
						else if (Main.inputTextEscape)
						{
							Main.PlaySound(12, -1, -1, 1);
							Main.editSign = false;
							Main.blockKey = Keys.Escape;
							Main.npcChatText = Main.sign[Main.player[Main.myPlayer].sign].text;
						}
					}
				}
				else if (Main.editChest)
				{
					string text3 = Main.GetInputText(Main.npcChatText);
					if (Main.inputTextEnter)
					{
						Main.PlaySound(12, -1, -1, 1);
						Main.editChest = false;
						int num9 = Main.player[Main.myPlayer].chest;
						if (Main.npcChatText == Main.defaultChestName)
						{
							Main.npcChatText = "";
						}
						if (Main.chest[num9].name != Main.npcChatText)
						{
							Main.chest[num9].name = Main.npcChatText;
							if (Main.netMode == 1)
							{
								Main.player[Main.myPlayer].editedChestName = true;
							}
						}
					}
					else if (Main.inputTextEscape)
					{
						Main.PlaySound(12, -1, -1, 1);
						Main.editChest = false;
						Main.npcChatText = string.Empty;
						Main.blockKey = Keys.Escape;
					}
					else if (text3.Length <= 20)
					{
						Main.npcChatText = text3;
					}
				}
				Main.gamePaused = true;
				return;
			}
			Main.gamePaused = false;
			if (!Main.dedServ && (double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0 && Main.netMode != 2)
			{
				Star.UpdateStars();
				Cloud.UpdateClouds();
			}*/
			Main.numPlayers = 0;
			int m = 0;
			while (m < 255)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.player[m].UpdatePlayer(m);
						goto IL_3825;
					}
					catch
					{
						goto IL_3825;
					}
					goto IL_3816;
				}
				goto IL_3816;
				IL_3825:
				m++;
				continue;
				IL_3816:
				Main.player[m].UpdatePlayer(m);
				goto IL_3825;
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
			int num10 = 0;
			while (num10 < 200)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.npc[num10].UpdateNPC(num10);
						goto IL_393A;
					}
					catch (Exception)
					{
						Main.npc[num10] = new NPC();
						goto IL_393A;
					}
					goto IL_392B;
				}
				goto IL_392B;
				IL_393A:
				num10++;
				continue;
				IL_392B:
				Main.npc[num10].UpdateNPC(num10);
				goto IL_393A;
			}
			int num11 = 0;
			while (num11 < 500)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.gore[num11].Update();
						goto IL_3981;
					}
					catch
					{
						Main.gore[num11] = new Gore();
						goto IL_3981;
					}
					goto IL_3974;
				}
				goto IL_3974;
				IL_3981:
				num11++;
				continue;
				IL_3974:
				Main.gore[num11].Update();
				goto IL_3981;
			}
			int num12 = 0;
			while (num12 < 1000)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.projectile[num12].Update(num12);
						goto IL_39CC;
					}
					catch
					{
						Main.projectile[num12] = new Projectile();
						goto IL_39CC;
					}
					goto IL_39BD;
				}
				goto IL_39BD;
				IL_39CC:
				num12++;
				continue;
				IL_39BD:
				Main.projectile[num12].Update(num12);
				goto IL_39CC;
			}
			int num13 = 0;
			while (num13 < 400)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.item[num13].UpdateItem(num13);
						goto IL_3A17;
					}
					catch
					{
						Main.item[num13] = new Item();
						goto IL_3A17;
					}
					goto IL_3A08;
				}
				goto IL_3A08;
				IL_3A17:
				num13++;
				continue;
				IL_3A08:
				Main.item[num13].UpdateItem(num13);
				goto IL_3A17;
			}
			if (Main.ignoreErrors)
			{
				try
				{
					Dust.UpdateDust();
					goto IL_3A5D;
				}
				catch
				{
					for (int num14 = 0; num14 < 6000; num14++)
					{
						Main.dust[num14] = new Dust();
					}
					goto IL_3A5D;
				}
			}
			Dust.UpdateDust();
			IL_3A5D:
			if (Main.netMode != 2)
			{
				//CombatText.UpdateCombatText();
				//ItemText.UpdateItemText();
			}
			if (Main.ignoreErrors)
			{
				try
				{
					Main.UpdateTime();
					goto IL_3A8B;
				}
				catch
				{
					Main.checkForSpawns = 0;
					goto IL_3A8B;
				}
			}
			Main.UpdateTime();
			IL_3A8B:
			if (Main.netMode != 1)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						WorldGen.UpdateWorld();
						Main.UpdateInvasion();
						goto IL_3AB3;
					}
					catch
					{
						goto IL_3AB3;
					}
				}
				WorldGen.UpdateWorld();
				Main.UpdateInvasion();
			}
			IL_3AB3:
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
					goto IL_3AFB;
				}
				catch
				{
					int arg_3ADE_0 = Main.netMode;
					goto IL_3AFB;
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
			IL_3AFB:
			if (Main.ignoreErrors)
			{
			}
			IL_3B9A:
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
		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern short GetKeyState(int keyCode);
		public static string GetInputText(string oldString)
		{
			return "";
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
			else if (Main.npc[i].type == 369)
			{
				num = 2f;
			}
			else if (Main.npc[i].type == 376)
			{
				num = 6f;
			}
			return num * Main.npc[i].scale;
		}
		
		private static Color buffColor(Color newColor, float R, float G, float B, float A)
		{
			newColor.R = (byte)((float)newColor.R * R);
			newColor.G = (byte)((float)newColor.G * G);
			newColor.B = (byte)((float)newColor.B * B);
			newColor.A = (byte)((float)newColor.A * A);
			return newColor;
		}
		protected Color quickAlpha(Color oldColor, float Alpha)
		{
			Color result = oldColor;
			result.R = (byte)((float)result.R * Alpha);
			result.G = (byte)((float)result.G * Alpha);
			result.B = (byte)((float)result.B * Alpha);
			result.A = (byte)((float)result.A * Alpha);
			return result;
		}
		
		protected Color randColor()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			while (num + num3 + num2 <= 150)
			{
				num = Main.rand.Next(256);
				num2 = Main.rand.Next(256);
				num3 = Main.rand.Next(256);
			}
			return new Color(num, num2, num3, 255);
		}
		public static Color hslToRgb(float Hue, float Saturation, float Luminosity)
		{
			byte r;
			byte g;
			byte b;
			if (Saturation == 0f)
			{
				r = (byte)Math.Round((double)Luminosity * 255.0);
				g = (byte)Math.Round((double)Luminosity * 255.0);
				b = (byte)Math.Round((double)Luminosity * 255.0);
			}
			else
			{
				double num = (double)Hue;
				double num2;
				if ((double)Luminosity < 0.5)
				{
					num2 = (double)Luminosity * (1.0 + (double)Saturation);
				}
				else
				{
					num2 = (double)(Luminosity + Saturation - Luminosity * Saturation);
				}
				double t = 2.0 * (double)Luminosity - num2;
				double num3 = num + 0.33333333333333331;
				double num4 = num;
				double num5 = num - 0.33333333333333331;
				num3 = Main.hue2rgb(num3, t, num2);
				num4 = Main.hue2rgb(num4, t, num2);
				num5 = Main.hue2rgb(num5, t, num2);
				r = (byte)Math.Round(num3 * 255.0);
				g = (byte)Math.Round(num4 * 255.0);
				b = (byte)Math.Round(num5 * 255.0);
			}
			return new Color((int)r, (int)g, (int)b);
		}
		public static double hue2rgb(double c, double t1, double t2)
		{
			if (c < 0.0)
			{
				c += 1.0;
			}
			if (c > 1.0)
			{
				c -= 1.0;
			}
			if (6.0 * c < 1.0)
			{
				return t1 + (t2 - t1) * 6.0 * c;
			}
			if (2.0 * c < 1.0)
			{
				return t2;
			}
			if (3.0 * c < 2.0)
			{
				return t1 + (t2 - t1) * (0.66666666666666663 - c) * 6.0;
			}
			return t1;
		}
		public static Vector3 rgbToHsl(Color newColor)
		{
			float num = (float)newColor.R;
			float num2 = (float)newColor.G;
			float num3 = (float)newColor.B;
			num /= 255f;
			num2 /= 255f;
			num3 /= 255f;
			float num4 = Math.Max(num, num2);
			num4 = Math.Max(num4, num3);
			float num5 = Math.Min(num, num2);
			num5 = Math.Min(num5, num3);
			float num6 = 0f;
			float num7 = (num4 + num5) / 2f;
			float y;
			if (num4 == num5)
			{
				y = (num6 = 0f);
			}
			else
			{
				float num8 = num4 - num5;
				y = (((double)num7 > 0.5) ? (num8 / (2f - num4 - num5)) : (num8 / (num4 + num5)));
				if (num4 == num)
				{
					num6 = (num2 - num3) / num8 + (float)((num2 < num3) ? 6 : 0);
				}
				if (num4 == num2)
				{
					num6 = (num3 - num) / num8 + 2f;
				}
				if (num4 == num3)
				{
					num6 = (num - num2) / num8 + 4f;
				}
				num6 /= 6f;
			}
			return new Vector3(num6, y, num7);
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
				//NetMessage.syncPlayers();
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
			int num = 80;
			if (!force && newText.Length > num)
			{
				string text = newText;
				while (text.Length > num)
				{
					int num2 = num;
					int num3 = num2;
					while (text.Substring(num3, 1) != " ")
					{
						num3--;
						if (num3 < 1)
						{
							break;
						}
					}
					if (num3 == 0)
					{
						while (text.Substring(num2, 1) != " ")
						{
							num2++;
							if (num2 >= text.Length - 1)
							{
								break;
							}
						}
					}
					else
					{
						num2 = num3;
					}
					if (num2 >= text.Length - 1)
					{
						num2 = text.Length;
					}
					string newText2 = text.Substring(0, num2);
					Main.NewText(newText2, R, G, B, true);
					text = text.Substring(num2);
					if (text.Length > 0)
					{
						while (text.Substring(0, 1) == " ")
						{
							text = text.Substring(1);
						}
					}
				}
				if (text.Length > 0)
				{
					Main.NewText(text, R, G, B, true);
				}
				return;
			}
			Main.PlaySound(12, -1, -1, 1);
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
					num3 /= ((Main.dayRate != 0) ? Main.dayRate : 1);
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
				if (WorldGen.spawnEye && Main.netMode != 1 && Main.time > 4860.0)
				{
					for (int j = 0; j < 255; j++)
					{
						if (Main.player[j].active && !Main.player[j].dead && (double)Main.player[j].position.Y < Main.worldSurface * 16.0)
						{
							NPC.SpawnOnPlayer(j, 4);
							WorldGen.spawnEye = false;
							break;
						}
					}
				}
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
					Main.AnglerQuestSwap();
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
					if (Main.netMode != 1)
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
							else if ((Main.hardMode && Main.rand.Next(60) == 0) || (!Main.hardMode && Main.rand.Next(30) == 0))
							{
								Main.StartInvasion(1);
							}
						}
						if (Main.invasionType == 0 && Main.hardMode && WorldGen.altarCount > 0 && ((NPC.downedPirates && Main.rand.Next(50) == 0) || (!NPC.downedPirates && Main.rand.Next(30) == 0)))
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
						bool flag2 = false;
						for (int m = 0; m < 255; m++)
						{
							if (Main.player[m].active && Main.player[m].statLifeMax >= 200 && Main.player[m].statDefense > 10)
							{
								flag2 = true;
								break;
							}
						}
						if (flag2 && Main.rand.Next(3) == 0)
						{
							int num6 = 0;
							for (int n = 0; n < 200; n++)
							{
								if (Main.npc[n].active && Main.npc[n].townNPC)
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
						for (int num13 = 0; num13 < 378; num13++)
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
						int num36 = 0;
						for (int num37 = 0; num37 < 200; num37++)
						{
							if (Main.npc[num37].active && Main.npc[num37].townNPC)
							{
								if (Main.npc[num37].type != 368 && Main.npc[num37].type != 37 && !Main.npc[num37].homeless)
								{
									WorldGen.QuickFindHome(num37);
								}
								if (Main.npc[num37].type == 37)
								{
									num19++;
								}
								if (Main.npc[num37].type == 17)
								{
									num14++;
								}
								if (Main.npc[num37].type == 18)
								{
									num15++;
								}
								if (Main.npc[num37].type == 19)
								{
									num17++;
								}
								if (Main.npc[num37].type == 20)
								{
									num16++;
								}
								if (Main.npc[num37].type == 22)
								{
									num18++;
								}
								if (Main.npc[num37].type == 38)
								{
									num20++;
								}
								if (Main.npc[num37].type == 54)
								{
									num21++;
								}
								if (Main.npc[num37].type == 107)
								{
									num23++;
								}
								if (Main.npc[num37].type == 108)
								{
									num22++;
								}
								if (Main.npc[num37].type == 124)
								{
									num24++;
								}
								if (Main.npc[num37].type == 142)
								{
									num25++;
								}
								if (Main.npc[num37].type == 160)
								{
									num26++;
								}
								if (Main.npc[num37].type == 178)
								{
									num27++;
								}
								if (Main.npc[num37].type == 207)
								{
									num28++;
								}
								if (Main.npc[num37].type == 208)
								{
									num29++;
								}
								if (Main.npc[num37].type == 209)
								{
									num30++;
								}
								if (Main.npc[num37].type == 227)
								{
									num31++;
								}
								if (Main.npc[num37].type == 228)
								{
									num32++;
								}
								if (Main.npc[num37].type == 229)
								{
									num33++;
								}
								if (Main.npc[num37].type == 353)
								{
									num34++;
								}
								if (Main.npc[num37].type == 369)
								{
									num35++;
								}
								num36++;
							}
						}
						if (WorldGen.spawnNPC == 0)
						{
							int num38 = 0;
							bool flag4 = false;
							int num39 = 0;
							bool flag5 = false;
							bool flag6 = false;
							bool flag7 = false;
							for (int num40 = 0; num40 < 255; num40++)
							{
								if (Main.player[num40].active)
								{
									for (int num41 = 0; num41 < 58; num41++)
									{
										if (Main.player[num40].inventory[num41] != null & Main.player[num40].inventory[num41].stack > 0)
										{
											if (num38 < 2000000000)
											{
												if (Main.player[num40].inventory[num41].type == 71)
												{
													num38 += Main.player[num40].inventory[num41].stack;
												}
												if (Main.player[num40].inventory[num41].type == 72)
												{
													num38 += Main.player[num40].inventory[num41].stack * 100;
												}
												if (Main.player[num40].inventory[num41].type == 73)
												{
													num38 += Main.player[num40].inventory[num41].stack * 10000;
												}
												if (Main.player[num40].inventory[num41].type == 74)
												{
													num38 += Main.player[num40].inventory[num41].stack * 1000000;
												}
											}
											if (Main.player[num40].inventory[num41].ammo == 14 || Main.player[num40].inventory[num41].useAmmo == 14)
											{
												flag5 = true;
											}
											if (Main.player[num40].inventory[num41].type == 166 || Main.player[num40].inventory[num41].type == 167 || Main.player[num40].inventory[num41].type == 168 || Main.player[num40].inventory[num41].type == 235)
											{
												flag6 = true;
											}
											if (Main.player[num40].inventory[num41].dye > 0 || (Main.player[num40].inventory[num41].type >= 1107 && Main.player[num40].inventory[num41].type <= 1120))
											{
												flag7 = true;
											}
										}
									}
									int num42 = Main.player[num40].statLifeMax / 20;
									if (num42 > 5)
									{
										flag4 = true;
									}
									num39 += num42;
									if (!flag7)
									{
										for (int num43 = 0; num43 < 3; num43++)
										{
											if (Main.player[num40].dye[num43] != null && Main.player[num40].dye[num43].stack > 0 && Main.player[num40].dye[num43].dye > 0)
											{
												flag7 = true;
											}
										}
									}
								}
							}
							if (!NPC.downedBoss3 && num19 == 0)
							{
								int num44 = NPC.NewNPC(Main.dungeonX * 16 + 8, Main.dungeonY * 16, 37, 0);
								Main.npc[num44].homeless = false;
								Main.npc[num44].homeTileX = Main.dungeonX;
								Main.npc[num44].homeTileY = Main.dungeonY;
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
							if ((double)num38 > 5000.0 && num14 < 1)
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
							if (NPC.savedAngler && num35 < 1)
							{
								Main.nextNPC[369] = true;
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
							if (num36 >= 4 && num31 < 1)
							{
								Main.nextNPC[227] = true;
							}
							if (flag8 && num29 < 1 && num36 >= 8)
							{
								Main.nextNPC[208] = true;
							}
							if (WorldGen.spawnNPC == 0 && num18 < 1)
							{
								WorldGen.spawnNPC = 22;
							}
							if (WorldGen.spawnNPC == 0 && (double)num38 > 5000.0 && num14 < 1)
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
							if (WorldGen.spawnNPC == 0 && NPC.savedAngler && num35 < 1)
							{
								WorldGen.spawnNPC = 369;
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
							if (WorldGen.spawnNPC == 0 && num36 >= 4 && num31 < 1)
							{
								WorldGen.spawnNPC = 227;
							}
							if (WorldGen.spawnNPC == 0 && flag8 && num36 >= 8 && num29 < 1)
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
		public static void PlaySound(int type, int x = -1, int y = -1, int Style = 1) { }
	}
}
