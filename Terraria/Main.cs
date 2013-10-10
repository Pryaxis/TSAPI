using Microsoft.Win32;
using System;
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
		public const int maxItemTypes = 1725;
		public const int maxProjectileTypes = 311;
		public const int maxNPCTypes = 301;
		public const int maxTileSets = 251;
		public const int maxWallTypes = 113;
		public const int maxGoreTypes = 438;
		public const int numArmorHead = 112;
		public const int numArmorBody = 75;
		public const int numArmorLegs = 64;
		public const int maxBuffs = 81;
		public const int maxWings = 21;
		public const int maxBackgrounds = 185;
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
		public const int maxGore = 500;
		public const int realInventory = 50;
		public const int maxInventory = 58;
		public const int maxItemSounds = 51;
		public const int maxNPCHitSounds = 13;
		public const int maxNPCKilledSounds = 19;
		public const int maxLiquidTypes = 12;
		public const int maxMusic = 30;
		public const double dayLength = 54000.0;
		public const double nightLength = 32400.0;
		public const int maxStars = 130;
		public const int maxStarTypes = 5;
		public const int maxClouds = 200;
		public const int maxCloudTypes = 22;
		public const int maxHair = 51;
		public static int curRelease = 71;
		public static string versionNumber = "v1.2.0.3.1";
		public static string versionNumber2 = "v1.2.0.3.1";
		public static bool ServerSideCharacter = false;
		public static string clientUUID;
		public static int maxMsg = 69;
		public static int npcStreamSpeed = 30;
		public static int musicError = 0;
		public static bool dedServFPS = false;
		public static int dedServCount1 = 0;
		public static int dedServCount2 = 0;
		public static bool superFast = false;
		public static bool[] hairLoaded = new bool[51];
		public static bool[] wingsLoaded = new bool[21];
		public static bool[] goreLoaded = new bool[438];
		public static bool[] projectileLoaded = new bool[311];
		public static bool[] itemFlameLoaded = new bool[1725];
		public static bool[] backgroundLoaded = new bool[185];
		public static bool[] tileSetsLoaded = new bool[251];
		public static bool[] wallLoaded = new bool[113];
		public static bool[] NPCLoaded = new bool[301];
		public static bool[] armorHeadLoaded = new bool[112];
		public static bool[] armorBodyLoaded = new bool[75];
		public static bool[] armorLegsLoaded = new bool[64];
		public static float zoomX;
		public static float zoomY;
		public static float sunCircle;
		public static int BlackFadeIn = 0;
		public static bool noWindowBorder = false;
		//private Matrix Transform = Matrix.CreateScale(1f, 1f, 1f) * Matrix.CreateRotationZ(0f) * Matrix.CreateTranslation(new Vector3(0f, 0f, 0f));
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
		public static bool[] nextNPC = new bool[301];
		public static int musicBox = -1;
		public static int musicBox2 = -1;
		public static byte hbPosition = 1;
		public static bool cEd = false;
		public static float wFrCounter = 0f;
		public static float wFrame = 0f;
		public static float wFallFrCounter = 0f;
		public static float wFallFrame = 0f;
		public static float wFallFrCounter2 = 0f;
		public static float wFallFrame2 = 0f;
		public static float wFallFrCounter3 = 0f;
		public static float wFallFrame3 = 0f;
		public static float wFallFrCounter4 = 0f;
		public static float wFallFrame4 = 0f;
		public static int findWaterfallCount = 0;
		public static int waterfallDist = 100;
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
		public static int snowDust = 0;
		public static bool chTitle = false;
		public static int keyCount = 0;
		public static string[] keyString = new string[10];
		public static int[] keyInt = new int[10];
		public static int wfTileMax = 200;
		public static int[] wfTileX = new int[Main.wfTileMax];
		public static int[] wfTileY = new int[Main.wfTileMax];
		public static int[] wfTileType = new int[Main.wfTileMax];
		public static int wfTileNum = 0;
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
		public static bool[] projHostile = new bool[311];
		public static bool[] pvpBuff = new bool[81];
		public static bool[] vanityPet = new bool[81];
		public static bool[] lightPet = new bool[81];
		public static bool[] meleeBuff = new bool[81];
		public static bool[] debuff = new bool[81];
		public static string[] buffName = new string[81];
		public static string[] buffTip = new string[81];
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
		private static int offScreenRange = 200;
		public static int maxMapUpdates = 250000;
		public static bool refreshMap = false;
		public static int loadMapLastX = 0;
		public static bool loadMapLock = false;
		public static bool loadMap = false;
		public static bool mapReady = false;
		public static int textureMax = 2000;
		public static bool updateMap = false;
		public static int mapMinX = 0;
		public static int mapMaxX = 0;
		public static int mapMinY = 0;
		public static int mapMaxY = 0;
		public static bool mapUnfinished;
		public static int mapTimeMax = 30;
		public static int mapTime = Main.mapTimeMax;
		public static bool clearMap;
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
		public static Color bgColor;
		public static bool mouseHC = false;
		public static string chestText = "Chest";
		public static bool craftingHide = false;
		public static bool armorHide = false;
		public static float craftingAlpha = 1f;
		public static float armorAlpha = 1f;
		public static float[] buffAlpha = new float[81];
		public static Item trashItem = new Item();
		public static bool hardMode = false;
		public float chestLootScale = 1f;
		public bool chestLootHover;
		public float chestStackScale = 1f;
		public bool chestStackHover;
		public float chestDepositScale = 1f;
		public bool chestDepositHover;
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
		public static string[] chrName = new string[301];
		public static int maxRain = 750;
		public int invBottom = 210;
		public static float cameraX = 0f;
		public static bool drewLava = false;
		public static float[] liquidAlpha = new float[12];
		public static int waterStyle = 0;
		public static int worldRate = 1;
		public static float caveParrallax = 1f;
		public static string[] tileName = new string[251];
		public static int dungeonX;
		public static int dungeonY;
		public static Liquid[] liquid = new Liquid[Liquid.resLiquid];
		public static LiquidBuffer[] liquidBuffer = new LiquidBuffer[10000];
		public static bool dedServ = false;
		public static int spamCount = 0;
		public static int curMusic = 0;
		public static int dayMusic = 0;
		public int newMusic;
		public static bool showItemText = true;
		public static bool autoSave = false;
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
		public static int[] projFrames = new int[311];
		public static bool[] projPet = new bool[311];
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
		public static Cloud[] cloud = new Cloud[200];
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
		public static int fadeCounter = 0;
		public static float invAlpha = 1f;
		public static float invDir = 1f;
		[ThreadStatic]
		public static Random rand;
		public static int maxMoons = 3;
		public static int moonType = 0;
		public static int numTileColors = 28;
		public static bool[,] tileAltTextureInit = new bool[251, Main.numTileColors];
		public static bool[,] tileAltTextureDrawn = new bool[251, Main.numTileColors];
		public static int numTreeStyles = 15;
		public static bool[,] treeAltTextureInit = new bool[Main.numTreeStyles, Main.numTileColors];
		public static bool[,] treeAltTextureDrawn = new bool[Main.numTreeStyles, Main.numTileColors];
		public static bool[,] checkTreeAlt = new bool[Main.numTreeStyles, Main.numTileColors];
		public static bool[,] wallAltTextureInit = new bool[113, Main.numTileColors];
		public static bool[,] wallAltTextureDrawn = new bool[113, Main.numTileColors];
		public static float[] musicFade = new float[30];
		public static float musicVolume = 0.75f;
		public static float soundVolume = 1f;
		public static bool[] tileLighted = new bool[251];
		public static bool[] tileMergeDirt = new bool[251];
		public static bool[] tileCut = new bool[251];
		public static bool[] tileAlch = new bool[251];
		public static int[] tileShine = new int[251];
		public static bool[] tileShine2 = new bool[251];
		public static bool[] wallHouse = new bool[113];
		public static bool[] wallDungeon = new bool[113];
		public static bool[] wallLight = new bool[113];
		public static int[] wallBlend = new int[113];
		public static bool[] tileStone = new bool[251];
		public static bool[] tilePick = new bool[251];
		public static bool[] tileAxe = new bool[251];
		public static bool[] tileHammer = new bool[251];
		public static bool[] tileWaterDeath = new bool[251];
		public static bool[] tileLavaDeath = new bool[251];
		public static bool[] tileTable = new bool[251];
		public static bool[] tileBlockLight = new bool[251];
		public static bool[] tileNoSunLight = new bool[251];
		public static bool[] tileDungeon = new bool[251];
		public static bool[] tileSolidTop = new bool[251];
		public static bool[] tileSolid = new bool[251];
		public static bool[] tileRope = new bool[251];
		public static bool[] tileBrick = new bool[251];
		public static bool[] tileMoss = new bool[251];
		public static bool[] tileNoAttach = new bool[251];
		public static bool[] tileNoFail = new bool[251];
		public static bool[] tileFrameImportant = new bool[251];
		public static bool[] tileSand = new bool[251];
		public static bool[] tileFlame = new bool[251];
		public static int[] tileFrame = new int[251];
		public static int[] tileFrameCounter = new int[251];
		public static int[] backgroundWidth = new int[185];
		public static int[] backgroundHeight = new int[185];
		public static bool tilesLoaded = false;
		public static Map[,] map = new Map[Main.maxTilesX, Main.maxTilesY];
		public static Tile[,] tile = new Tile[Main.maxTilesX, Main.maxTilesY];
		public static Dust[] dust = new Dust[6001];
		public static Star[] star = new Star[130];
		public static Item[] item = new Item[401];
		public static NPC[] npc = new NPC[201];
		public static Gore[] gore = new Gore[501];
		public static Rain[] rain = new Rain[Main.maxRain + 1];
		public static Projectile[] projectile = new Projectile[1001];
		public static CombatText[] combatText = new CombatText[100];
		public static ItemText[] itemText = new ItemText[20];
		public static Chest[] chest = new Chest[1000];
		public static Sign[] sign = new Sign[1000];
		public static Vector2 screenPosition;
		public static Vector2 screenLastPosition;
		public static int screenWidth = 1152;
		public static int screenHeight = 864;
		public static int chatLength = 600;
		public static bool chatMode = false;
		public static bool chatRelease = false;
		public static int showCount = 10;
		public static int numChatLines = 500;
		public static int startChatLine = 0;
		public static string chatText = "";
		public static ChatLine[] chatLine = new ChatLine[Main.numChatLines];
		public static bool inputTextEnter = false;
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
		public static string signText = "";
		public static string npcChatText = "";
		public static bool npcChatFocus1 = false;
		public static bool npcChatFocus2 = false;
		public static bool npcChatFocus3 = false;
		public static int npcShop = 0;
		public static int numShops = 18;
		public Chest[] shop = new Chest[Main.numShops];
		public static bool craftGuide = false;
		public static bool reforge = false;
		private static Item toolTip = new Item();
		private static int backSpaceCount = 0;
		public static string motd = "";
		public bool toggleFullscreen;
		private int numDisplayModes;
		private int[] displayWidth = new int[99];
		private int[] displayHeight = new int[99];
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
		public static string[] itemName = new string[1725];
		public static string[] npcName = new string[301];
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
			15
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
		private Color selColor = Color.White;
		private int focusColor;
		private int colorDelay;
		private int setKey = -1;
		private int bgScroll;
		public static bool autoPass = false;
		public static int menuFocus = 0;
		private float hBar = -1f;
		private float sBar = -1f;
		private float lBar = 1f;
		private int grabColorSlider;
		private bool blockMouse;
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
				try
				{
					using (FileStream fileStream = new FileStream(Main.loadWorldPath[i], FileMode.Open))
					{
						using (BinaryReader binaryReader = new BinaryReader(fileStream))
						{
							binaryReader.ReadInt32();
							Main.loadWorld[i] = binaryReader.ReadString();
							binaryReader.Close();
						}
					}
				}
				catch
				{
					Main.loadWorld[i] = Main.loadWorldPath[i];
				}
			}
			Main.numLoadWorlds = num;
		}
		private static void LoadPlayers()
		{
			Directory.CreateDirectory(Main.PlayerPath);
			string[] files = Directory.GetFiles(Main.PlayerPath, "*.plr");
			int num = files.Length;
			if (num > Main.maxLoadPlayer)
			{
				num = Main.maxLoadPlayer;
			}
			for (int i = 0; i < num; i++)
			{
				Main.loadPlayer[i] = new Player();
				if (i < num)
				{
					Main.loadPlayerPath[i] = files[i];
					Main.loadPlayer[i] = Player.LoadPlayer(Main.loadPlayerPath[i]);
				}
			}
			Main.numLoadPlayers = num;
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
		
		private static void ErasePlayer(int i)
		{
			try
			{
				File.Delete(Main.loadPlayerPath[i]);
				File.Delete(Main.loadPlayerPath[i] + ".bak");
			}
			catch
			{
			}
			try
			{
				string path = Main.loadPlayerPath[i].Substring(0, Main.loadPlayerPath[i].Length - 4);
				if (Directory.Exists(path))
				{
					Directory.Delete(path, true);
				}
				Main.LoadPlayers();
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
				else
				{
					if (text2 == " ")
					{
						str = "_";
					}
					else
					{
						str = "-";
					}
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
				else
				{
					if (text2 == " ")
					{
						str = "_";
					}
					else
					{
						str = "-";
					}
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
										else
										{
											if (num2 == 1)
											{
												currentProcess.PriorityClass = ProcessPriorityClass.High;
											}
											else
											{
												if (num2 == 2)
												{
													currentProcess.PriorityClass = ProcessPriorityClass.AboveNormal;
												}
												else
												{
													if (num2 == 3)
													{
														currentProcess.PriorityClass = ProcessPriorityClass.Normal;
													}
													else
													{
														if (num2 == 4)
														{
															currentProcess.PriorityClass = ProcessPriorityClass.BelowNormal;
														}
														else
														{
															if (num2 == 5)
															{
																currentProcess.PriorityClass = ProcessPriorityClass.Idle;
															}
														}
													}
												}
											}
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
								else
								{
									if (text5 == "1")
									{
										Main.maxTilesX = 4200;
										Main.maxTilesY = 1200;
										Main.autoGen = true;
									}
									else
									{
										if (text5 == "2")
										{
											Main.maxTilesX = 6300;
											Main.maxTilesY = 1800;
											Main.autoGen = true;
										}
										else
										{
											if (text5 == "3")
											{
												Main.maxTilesX = 8400;
												Main.maxTilesY = 2400;
												Main.autoGen = true;
											}
										}
									}
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
			for (int i = 0; i < 301; i++)
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
								else
								{
									if (num2 == 2)
									{
										Main.maxTilesX = 6400;
										Main.maxTilesY = 1800;
										flag2 = false;
									}
									else
									{
										if (num2 == 3)
										{
											Main.maxTilesX = 8400;
											Main.maxTilesY = 2400;
											flag2 = false;
										}
									}
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
						else
						{
							if (text == "fps")
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
							if (text == "settle")
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
							else
							{
								if (text == "dawn")
								{
									Main.dayTime = true;
									Main.time = 0.0;
									NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
								}
								else
								{
									if (text == "dusk")
									{
										Main.dayTime = false;
										Main.time = 0.0;
										NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
									}
									else
									{
										if (text == "noon")
										{
											Main.dayTime = true;
											Main.time = 27000.0;
											NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
										}
										else
										{
											if (text == "midnight")
											{
												Main.dayTime = false;
												Main.time = 16200.0;
												NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
											}
											else
											{
												if (text == "exit-nosave")
												{
													Netplay.disconnect = true;
												}
												else
												{
													if (text == "exit")
													{
														WorldGen.saveWorld(false);
														Netplay.disconnect = true;
													}
													else
													{
														if (text == "save")
														{
															WorldGen.saveWorld(false);
														}
														else
														{
															if (text == "time")
															{
																string text3 = "AM";
																double num = Main.time;
																if (!Main.dayTime)
																{
																	num += 54000.0;
																}
																num = num/86400.0*24.0;
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
																int num3 = (int) num;
																double num4 = num - (double) num3;
																num4 = (double) ((int) (num4*60.0));
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
															else
															{
																if (text == "maxplayers")
																{
																	Console.WriteLine("Player limit: " + Main.maxNetPlayers);
																}
																else
																{
																	if (text == "port")
																	{
																		Console.WriteLine("Port: " + Netplay.serverPort);
																	}
																	else
																	{
																		if (text == "version")
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
																				else
																				{
																					if (num5 == 1)
																					{
																						Console.WriteLine("1 player connected.");
																					}
																					else
																					{
																						Console.WriteLine(num5 + " players connected.");
																					}
																				}
																			}
																			else
																			{
																				if (!(text == ""))
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
																					else
																					{
																						if (text.Length >= 5 && text.Substring(0, 5) == "motd ")
																						{
																							string text5 = text2.Substring(5);
																							Main.motd = text5;
																						}
																						else
																						{
																							if (text.Length == 8 && text.Substring(0, 8) == "password")
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
																							else
																							{
																								if (text.Length >= 9 && text.Substring(0, 9) == "password ")
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
																								else
																								{
																									if (text == "say")
																									{
																										Console.WriteLine("Usage: say <words>");
																									}
																									else
																									{
																										if (text.Length >= 4 && text.Substring(0, 4) == "say ")
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
																										else
																										{
																											if (text.Length == 4 && text.Substring(0, 4) == "kick")
																											{
																												Console.WriteLine("Usage: kick <player>");
																											}
																											else
																											{
																												if (text.Length >= 5 && text.Substring(0, 5) == "kick ")
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
																												else
																												{
																													if (text.Length == 3 && text.Substring(0, 3) == "ban")
																													{
																														Console.WriteLine("Usage: ban <player>");
																													}
																													else
																													{
																														if (text.Length >= 4 && text.Substring(0, 4) == "ban ")
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
					catch
					{
						Console.WriteLine("Invalid command.");
					}
				}
			}
		}
		protected void SetTitle()
		{
		}
		protected void Initialize()
		{
			NPC.clrNames();
			NPC.setNames();
			WorldGen.randomBackgrounds();
			WorldGen.setCaveBacks();
			WorldGen.randMoon();
			Main.bgAlpha[0] = 1f;
			Main.bgAlpha2[0] = 1f;
			this.invBottom = 258;
			for (int i = 0; i < 311; i++)
			{
				Main.projFrames[i] = 1;
			}
			Main.projFrames[308] = 10;
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
			Main.projPet[266] = true;
			Main.tileLighted[237] = true;
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
			Main.pvpBuff[20] = true;
			Main.pvpBuff[24] = true;
			Main.pvpBuff[31] = true;
			Main.pvpBuff[39] = true;
			Main.pvpBuff[44] = true;
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
			Main.lightPet[19] = true;
			Main.lightPet[27] = true;
			Main.lightPet[57] = true;
			Main.tileFlame[4] = true;
			Main.tileFlame[33] = true;
			Main.tileFlame[34] = true;
			Main.tileFlame[35] = true;
			Main.tileFlame[36] = true;
			Main.tileFlame[49] = true;
			Main.tileFlame[93] = true;
			Main.tileFlame[98] = true;
			Main.tileFlame[100] = true;
			Main.tileFlame[170] = true;
			Main.tileFlame[171] = true;
			Main.tileFlame[172] = true;
			Main.tileFlame[173] = true;
			Main.tileFlame[174] = true;
			Main.tileRope[213] = true;
			Main.tileRope[214] = true;
			Main.tileSolid[232] = true;
			Main.tileShine[239] = 1100;
			Main.tileSolid[239] = true;
			Main.tileSolidTop[239] = true;
			Main.tileFrameImportant[247] = true;
			Main.tileFrameImportant[245] = true;
			Main.tileFrameImportant[246] = true;
			Main.tileFrameImportant[239] = true;
			Main.tileFrameImportant[240] = true;
			Main.tileFrameImportant[241] = true;
			Main.tileFrameImportant[242] = true;
			Main.tileFrameImportant[243] = true;
			Main.tileFrameImportant[244] = true;
			Main.tileSolid[221] = true;
			Main.tileBlockLight[221] = true;
			Main.tileMergeDirt[221] = true;
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
			Main.tileBlockLight[248] = true;
			Main.tileBlockLight[249] = true;
			Main.tileBlockLight[250] = true;
			Main.wallHouse[109] = true;
			Main.wallHouse[110] = true;
			Main.wallHouse[111] = true;
			Main.wallHouse[112] = true;
			for (int j = 0; j < 113; j++)
			{
				Main.wallDungeon[j] = false;
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
			for (int k = 0; k < 10; k++)
			{
				Main.recentWorld[k] = "";
				Main.recentIP[k] = "";
				Main.recentPort[k] = 0;
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
			Main.wallHouse[82] = true;
			Main.wallHouse[77] = true;
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
			Main.wallHouse[75] = true;
			Main.wallHouse[76] = true;
			Main.wallHouse[78] = true;
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
			Main.tileFrameImportant[170] = true;
			Main.tileFrameImportant[171] = true;
			Main.tileFrameImportant[172] = true;
			Main.tileFrameImportant[173] = true;
			Main.tileFrameImportant[174] = true;
			Main.tileLighted[170] = true;
			Main.tileLighted[171] = true;
			Main.tileLighted[172] = true;
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
			Main.tileLighted[36] = true;
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
			Main.tileFrameImportant[36] = true;
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
			Main.tileFrameImportant[126] = true;
			Main.tileFrameImportant[128] = true;
			Main.tileFrameImportant[129] = true;
			Main.tileFrameImportant[132] = true;
			Main.tileFrameImportant[133] = true;
			Main.tileFrameImportant[134] = true;
			Main.tileFrameImportant[135] = true;
			Main.tileFrameImportant[141] = true;
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
			Main.tileLavaDeath[104] = true;
			Main.tileLavaDeath[110] = true;
			Main.tileLavaDeath[113] = true;
			Main.tileLavaDeath[115] = true;
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
			Main.tileLavaDeath[86] = true;
			Main.tileLavaDeath[87] = true;
			Main.tileLavaDeath[88] = true;
			Main.tileLavaDeath[89] = true;
			Main.tileLavaDeath[125] = true;
			Main.tileLavaDeath[126] = true;
			Main.tileLavaDeath[101] = true;
			Main.tileTable[101] = true;
			Main.tileNoAttach[101] = true;
			Main.tileLavaDeath[102] = true;
			Main.tileNoAttach[102] = true;
			Main.tileNoAttach[94] = true;
			Main.tileNoAttach[95] = true;
			Main.tileNoAttach[96] = true;
			Main.tileNoAttach[97] = true;
			Main.tileNoAttach[98] = true;
			Main.tileNoAttach[99] = true;
			Main.tileLavaDeath[94] = true;
			Main.tileLavaDeath[95] = true;
			Main.tileLavaDeath[96] = true;
			Main.tileLavaDeath[97] = true;
			Main.tileLavaDeath[98] = true;
			Main.tileLavaDeath[99] = true;
			Main.tileLavaDeath[100] = true;
			Main.tileLavaDeath[103] = true;
			Main.tileTable[87] = true;
			Main.tileTable[88] = true;
			Main.tileSolidTop[87] = true;
			Main.tileSolidTop[88] = true;
			Main.tileSolidTop[101] = true;
			Main.tileNoAttach[91] = true;
			Main.tileLavaDeath[91] = true;
			Main.tileNoAttach[92] = true;
			Main.tileLavaDeath[92] = true;
			Main.tileNoAttach[93] = true;
			Main.tileLavaDeath[93] = true;
			Main.tileLighted[190] = true;
			Main.tileBlockLight[192] = true;
			Main.tileBrick[192] = false;
			Main.tileWaterDeath[4] = true;
			Main.tileWaterDeath[51] = true;
			Main.tileWaterDeath[93] = true;
			Main.tileWaterDeath[98] = true;
			Main.tileLavaDeath[201] = true;
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
			Main.tileLavaDeath[106] = true;
			Main.tileLavaDeath[205] = true;
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
			for (int l = 0; l < 113; l++)
			{
				if (l == 20)
				{
					Main.wallBlend[l] = 14;
				}
				else
				{
					if (l == 19)
					{
						Main.wallBlend[l] = 9;
					}
					else
					{
						if (l == 18)
						{
							Main.wallBlend[l] = 8;
						}
						else
						{
							if (l == 17)
							{
								Main.wallBlend[l] = 7;
							}
							else
							{
								if (l == 16 || l == 59)
								{
									Main.wallBlend[l] = 2;
								}
								else
								{
									if (l == 1 || (l >= 48 && l <= 53))
									{
										Main.wallBlend[l] = 1;
									}
									else
									{
										Main.wallBlend[l] = l;
									}
								}
							}
						}
					}
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
			for (int m = 0; m < 251; m++)
			{
				Main.tileName[m] = "";
				if (Main.tileSolid[m])
				{
					Main.tileNoSunLight[m] = true;
				}
				Main.tileFrame[m] = 0;
				Main.tileFrameCounter[m] = 0;
			}
			Main.tileNoSunLight[19] = false;
			Main.tileNoSunLight[11] = true;
			Main.tileNoSunLight[189] = false;
			Main.tileNoSunLight[196] = false;
			for (int n = 0; n < Main.maxMenuItems; n++)
			{
				this.menuItemScale[n] = 0.8f;
			}
			for (int num = 0; num < 6001; num++)
			{
				Main.dust[num] = new Dust();
			}
			for (int num2 = 0; num2 < 401; num2++)
			{
				Main.item[num2] = new Item();
			}
			for (int num3 = 0; num3 < 201; num3++)
			{
				Main.npc[num3] = new NPC();
				Main.npc[num3].whoAmI = num3;
			}
			for (int num4 = 0; num4 < 256; num4++)
			{
				Main.player[num4] = new Player();
			}
			for (int num5 = 0; num5 < 1001; num5++)
			{
				Main.projectile[num5] = new Projectile();
			}
			for (int num6 = 0; num6 < 501; num6++)
			{
				Main.gore[num6] = new Gore();
			}
			for (int num7 = 0; num7 < Main.maxRain + 1; num7++)
			{
				Main.rain[num7] = new Rain();
			}
			for (int num8 = 0; num8 < 200; num8++)
			{
				Main.cloud[num8] = new Cloud();
			}
			for (int num9 = 0; num9 < 100; num9++)
			{
				Main.combatText[num9] = new CombatText();
			}
			for (int num10 = 0; num10 < 20; num10++)
			{
				Main.itemText[num10] = new ItemText();
			}
			for (int num11 = 0; num11 < 1725; num11++)
			{
				Item item = new Item();
				item.SetDefaults(num11, false);
				Main.itemName[num11] = item.name;
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
			for (int num12 = 0; num12 < Recipe.maxRecipes; num12++)
			{
				Main.recipe[num12] = new Recipe();
				Main.availableRecipeY[num12] = (float)(65 * num12);
			}
			Recipe.SetupRecipes();
			for (int num13 = 0; num13 < Main.numChatLines; num13++)
			{
				Main.chatLine[num13] = new ChatLine();
			}
			for (int num14 = 0; num14 < Liquid.resLiquid; num14++)
			{
				Main.liquid[num14] = new Liquid();
			}
			for (int num15 = 0; num15 < 10000; num15++)
			{
				Main.liquidBuffer[num15] = new LiquidBuffer();
			}
			this.shop[0] = new Chest();
			for (int num16 = 1; num16 < Main.numShops; num16++)
			{
				this.shop[num16] = new Chest();
				this.shop[num16].SetupShop(num16);
			}
			Main.teamColor[0] = Color.White;
			Main.teamColor[1] = new Color(230, 40, 20);
			Main.teamColor[2] = new Color(20, 200, 30);
			Main.teamColor[3] = new Color(75, 90, 255);
			Main.teamColor[4] = new Color(200, 180, 0);
			if (Main.menuMode == 1)
			{
				Main.LoadPlayers();
			}
			for (int num17 = 1; num17 < 311; num17++)
			{
				Projectile projectile = new Projectile();
				projectile.SetDefaults(num17);
				if (projectile.hostile)
				{
					Main.projHostile[num17] = true;
				}
			}
			Netplay.Init();
			if (Main.skipMenu)
			{
				WorldGen.clearWorld();
				Main.gameMenu = false;
				Main.LoadPlayers();
				Main.player[Main.myPlayer] = (Player)Main.loadPlayer[0].Clone();
				Main.PlayerPath = Main.loadPlayerPath[0];
				Main.LoadWorlds();
				WorldGen.generateWorld(-1);
				WorldGen.EveryTileFrame();
				Main.player[Main.myPlayer].Spawn();
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
			}
			/*if (Main.screenWidth > GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width)
			{
				Main.screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
			}
			if (Main.screenHeight > GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height)
			{
				Main.screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
			}
			this.graphics.PreferredBackBufferWidth = Main.screenWidth;
			this.graphics.PreferredBackBufferHeight = Main.screenHeight;
			this.graphics.ApplyChanges();
			base.Initialize();
			base.Window.AllowUserResizing = true;
			this.OpenSettings();
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
					for (int num18 = 0; num18 < this.numDisplayModes; num18++)
					{
						if (current.Width == this.displayWidth[num18] && current.Height == this.displayHeight[num18])
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						this.displayHeight[this.numDisplayModes] = current.Height;
						this.displayWidth[this.numDisplayModes] = current.Width;
						this.numDisplayModes++;
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
		protected void LoadContent()
		{
			/*try
			{
				Main.pixelShader = base.Content.Load<Effect>("pixelShader");
				Main.tileShader = base.Content.Load<Effect>("tileShader");
				Main.engine = new AudioEngine("Content" + Path.DirectorySeparatorChar + "TerrariaMusic.xgs");
				Main.soundBank = new SoundBank(Main.engine, "Content" + Path.DirectorySeparatorChar + "Sound Bank.xsb");
				Main.waveBank = new WaveBank(Main.engine, "Content" + Path.DirectorySeparatorChar + "Wave Bank.xwb");
				for (int i = 1; i < 30; i++)
				{
					Main.music[i] = Main.soundBank.GetCue("Music_" + i);
				}
				Main.soundMech[0] = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Mech_0");
				Main.soundInstanceMech[0] = Main.soundMech[0].CreateInstance();
				Main.soundGrab = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Grab");
				Main.soundInstanceGrab = Main.soundGrab.CreateInstance();
				Main.soundPixie = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Pixie");
				Main.soundInstancePixie = Main.soundGrab.CreateInstance();
				Main.soundDig[0] = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Dig_0");
				Main.soundInstanceDig[0] = Main.soundDig[0].CreateInstance();
				Main.soundDig[1] = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Dig_1");
				Main.soundInstanceDig[1] = Main.soundDig[1].CreateInstance();
				Main.soundDig[2] = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Dig_2");
				Main.soundInstanceDig[2] = Main.soundDig[2].CreateInstance();
				Main.soundTink[0] = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Tink_0");
				Main.soundInstanceTink[0] = Main.soundTink[0].CreateInstance();
				Main.soundTink[1] = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Tink_1");
				Main.soundInstanceTink[1] = Main.soundTink[1].CreateInstance();
				Main.soundTink[2] = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Tink_2");
				Main.soundInstanceTink[2] = Main.soundTink[2].CreateInstance();
				Main.soundPlayerHit[0] = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Player_Hit_0");
				Main.soundInstancePlayerHit[0] = Main.soundPlayerHit[0].CreateInstance();
				Main.soundPlayerHit[1] = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Player_Hit_1");
				Main.soundInstancePlayerHit[1] = Main.soundPlayerHit[1].CreateInstance();
				Main.soundPlayerHit[2] = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Player_Hit_2");
				Main.soundInstancePlayerHit[2] = Main.soundPlayerHit[2].CreateInstance();
				Main.soundFemaleHit[0] = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Female_Hit_0");
				Main.soundInstanceFemaleHit[0] = Main.soundFemaleHit[0].CreateInstance();
				Main.soundFemaleHit[1] = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Female_Hit_1");
				Main.soundInstanceFemaleHit[1] = Main.soundFemaleHit[1].CreateInstance();
				Main.soundFemaleHit[2] = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Female_Hit_2");
				Main.soundInstanceFemaleHit[2] = Main.soundFemaleHit[2].CreateInstance();
				Main.soundPlayerKilled = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Player_Killed");
				Main.soundInstancePlayerKilled = Main.soundPlayerKilled.CreateInstance();
				Main.soundChat = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Chat");
				Main.soundInstanceChat = Main.soundChat.CreateInstance();
				Main.soundGrass = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Grass");
				Main.soundInstanceGrass = Main.soundGrass.CreateInstance();
				Main.soundDoorOpen = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Door_Opened");
				Main.soundInstanceDoorOpen = Main.soundDoorOpen.CreateInstance();
				Main.soundDoorClosed = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Door_Closed");
				Main.soundInstanceDoorClosed = Main.soundDoorClosed.CreateInstance();
				Main.soundMenuTick = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Menu_Tick");
				Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
				Main.soundMenuOpen = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Menu_Open");
				Main.soundInstanceMenuOpen = Main.soundMenuOpen.CreateInstance();
				Main.soundMenuClose = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Menu_Close");
				Main.soundInstanceMenuClose = Main.soundMenuClose.CreateInstance();
				Main.soundShatter = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Shatter");
				Main.soundInstanceShatter = Main.soundShatter.CreateInstance();
				Main.soundZombie[0] = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Zombie_0");
				Main.soundInstanceZombie[0] = Main.soundZombie[0].CreateInstance();
				Main.soundZombie[1] = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Zombie_1");
				Main.soundInstanceZombie[1] = Main.soundZombie[1].CreateInstance();
				Main.soundZombie[2] = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Zombie_2");
				Main.soundInstanceZombie[2] = Main.soundZombie[2].CreateInstance();
				Main.soundZombie[3] = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Zombie_3");
				Main.soundInstanceZombie[3] = Main.soundZombie[3].CreateInstance();
				Main.soundZombie[4] = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Zombie_4");
				Main.soundInstanceZombie[4] = Main.soundZombie[4].CreateInstance();
				Main.soundRoar[0] = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Roar_0");
				Main.soundInstanceRoar[0] = Main.soundRoar[0].CreateInstance();
				Main.soundRoar[1] = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Roar_1");
				Main.soundInstanceRoar[1] = Main.soundRoar[1].CreateInstance();
				Main.soundSplash[0] = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Splash_0");
				Main.soundInstanceSplash[0] = Main.soundRoar[0].CreateInstance();
				Main.soundSplash[1] = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Splash_1");
				Main.soundInstanceSplash[1] = Main.soundSplash[1].CreateInstance();
				Main.soundDoubleJump = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Double_Jump");
				Main.soundInstanceDoubleJump = Main.soundRoar[0].CreateInstance();
				Main.soundRun = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Run");
				Main.soundInstanceRun = Main.soundRun.CreateInstance();
				Main.soundCoins = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Coins");
				Main.soundInstanceCoins = Main.soundCoins.CreateInstance();
				Main.soundUnlock = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Unlock");
				Main.soundInstanceUnlock = Main.soundUnlock.CreateInstance();
				Main.soundMaxMana = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "MaxMana");
				Main.soundInstanceMaxMana = Main.soundMaxMana.CreateInstance();
				Main.soundDrown = base.Content.Load<SoundEffect>("Sounds" + Path.DirectorySeparatorChar + "Drown");
				Main.soundInstanceDrown = Main.soundDrown.CreateInstance();
				for (int j = 1; j < 52; j++)
				{
					Main.soundItem[j] = base.Content.Load<SoundEffect>(string.Concat(new object[]
					{
						"Sounds",
						Path.DirectorySeparatorChar,
						"Item_",
						j
					}));
					Main.soundInstanceItem[j] = Main.soundItem[j].CreateInstance();
				}
				for (int k = 1; k < 14; k++)
				{
					Main.soundNPCHit[k] = base.Content.Load<SoundEffect>(string.Concat(new object[]
					{
						"Sounds",
						Path.DirectorySeparatorChar,
						"NPC_Hit_",
						k
					}));
					Main.soundInstanceNPCHit[k] = Main.soundNPCHit[k].CreateInstance();
				}
				for (int l = 1; l < 20; l++)
				{
					Main.soundNPCKilled[l] = base.Content.Load<SoundEffect>(string.Concat(new object[]
					{
						"Sounds",
						Path.DirectorySeparatorChar,
						"NPC_Killed_",
						l
					}));
					Main.soundInstanceNPCKilled[l] = Main.soundNPCKilled[l].CreateInstance();
				}
			}
			catch
			{
				Main.musicVolume = 0f;
				Main.soundVolume = 0f;
			}
			this.iceBarrierTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "IceBarrier");
			Main.frozenTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Frozen");
			Main.craftButtonTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "CraftButton");
			Main.craftUpButtonTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "RecUp");
			Main.craftDownButtonTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "RecDown");
			Main.pulleyTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "PlayerPulley");
			Main.reforgeTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Reforge");
			Main.timerTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Timer");
			Main.wofTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "WallOfFlesh");
			Main.wallOutlineTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Wall_Outline");
			Main.fadeTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "fade-out");
			Main.ghostTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Ghost");
			Main.evilCactusTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Evil_Cactus");
			Main.goodCactusTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Good_Cactus");
			Main.crimsonCactusTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Crimson_Cactus");
			Main.wraithEyeTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Wraith_Eyes");
			Main.reaperEyeTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Reaper_Eyes");
			Main.MusicBoxTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Music_Box");
			this.mapTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Map");
			this.mapBG1Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "MapBG1");
			this.mapBG2Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "MapBG2");
			this.mapBG3Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "MapBG3");
			this.mapBG4Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "MapBG4");
			this.mapBG5Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "MapBG5");
			this.mapBG6Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "MapBG6");
			this.mapBG7Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "MapBG7");
			this.mapBG8Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "MapBG8");
			this.mapBG9Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "MapBG9");
			this.mapBG10Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "MapBG10");
			this.mapBG11Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "MapBG11");
			this.mapBG12Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "MapBG12");
			this.hueTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Hue");
			this.colorSliderTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "ColorSlider");
			this.colorBarTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "ColorBar");
			this.colorBlipTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "ColorBlip");
			Main.rainTexture[0] = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Rain_0");
			Main.rainTexture[1] = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Rain_1");
			Main.rainTexture[2] = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Rain_2");
			Main.magicPixel = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "MagicPixel");
			Main.miniMapFrameTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "MiniMapFrame");
			Main.miniMapFrame2Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "MiniMapFrame2");
			for (int m = 0; m < Main.FlameTexture.Length; m++)
			{
				Main.FlameTexture[m] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Flame_",
					m
				}));
			}
			for (int n = 0; n < 3; n++)
			{
				Main.miniMapButtonTexture[n] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"MiniMapButton_",
					n
				}));
			}
			for (int num = 0; num < 8; num++)
			{
				this.mapIconTexture[num] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Map_",
					num
				}));
			}
			Main.destTexture[0] = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Dest1");
			Main.destTexture[1] = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Dest2");
			Main.destTexture[2] = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Dest3");
			Main.actuatorTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Actuator");
			Main.wireTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Wires");
			Main.wire2Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Wires2");
			Main.wire3Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Wires3");
			Main.flyingCarpetTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "FlyingCarpet");
			Main.hbTexture1 = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "HealthBar1");
			Main.hbTexture2 = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "HealthBar2");
			Main.loTexture = base.Content.Load<Texture2D>(string.Concat(new object[]
			{
				"Images",
				Path.DirectorySeparatorChar,
				"logo_",
				Main.rand.Next(1, 9)
			}));
			this.spriteBatch = new SpriteBatch(base.GraphicsDevice);
			for (int num2 = 1; num2 < 2; num2++)
			{
				Main.bannerTexture[num2] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"House_Banner_",
					num2
				}));
			}
			for (int num3 = 0; num3 < Main.npcHeadTexture.Length; num3++)
			{
				Main.npcHeadTexture[num3] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"NPC_Head_",
					num3
				}));
			}
			for (int num4 = 1; num4 < Main.BackPackTexture.Length; num4++)
			{
				Main.BackPackTexture[num4] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"BackPack_",
					num4
				}));
			}
			for (int num5 = 1; num5 < 81; num5++)
			{
				Main.buffTexture[num5] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Buff_",
					num5
				}));
			}
			this.LoadBackground(0);
			this.LoadBackground(49);
			for (int num6 = 0; num6 < 1725; num6++)
			{
				Main.itemTexture[num6] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Item_",
					num6
				}));
			}
			for (int num7 = 0; num7 < 6; num7++)
			{
				Main.gemTexture[num7] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Gem_",
					num7
				}));
			}
			for (int num8 = 0; num8 < 301; num8++)
			{
				NPC nPC = new NPC();
				nPC.SetDefaults(num8, -1f);
				Main.npcName[num8] = nPC.name;
			}
			for (int num9 = 0; num9 < 22; num9++)
			{
				Main.cloudTexture[num9] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Cloud_",
					num9
				}));
			}
			for (int num10 = 0; num10 < 5; num10++)
			{
				Main.starTexture[num10] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Star_",
					num10
				}));
			}
			for (int num11 = 0; num11 < 12; num11++)
			{
				Main.liquidTexture[num11] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Liquid_",
					num11
				}));
				Main.waterfallTexture[num11] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Waterfall_",
					num11
				}));
			}
			Main.waterfallTexture[12] = base.Content.Load<Texture2D>(string.Concat(new object[]
			{
				"Images",
				Path.DirectorySeparatorChar,
				"Waterfall_",
				12
			}));
			Main.waterfallTexture[13] = base.Content.Load<Texture2D>(string.Concat(new object[]
			{
				"Images",
				Path.DirectorySeparatorChar,
				"Waterfall_",
				13
			}));
			Main.waterfallTexture[14] = base.Content.Load<Texture2D>(string.Concat(new object[]
			{
				"Images",
				Path.DirectorySeparatorChar,
				"Waterfall_",
				14
			}));
			Main.npcToggleTexture[0] = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "House_1");
			Main.npcToggleTexture[1] = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "House_2");
			Main.HBLockTexture[0] = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Lock_0");
			Main.HBLockTexture[1] = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Lock_1");
			Main.gridTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Grid");
			Main.trashTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Trash");
			Main.cdTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "CoolDown");
			Main.logoTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Logo");
			Main.logo2Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Logo2");
			Main.dustTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Dust");
			Main.sunTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Sun");
			Main.sun2Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Sun2");
			Main.sun3Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Sun3");
			Main.blackTileTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Black_Tile");
			Main.heartTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Heart");
			Main.heart2Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Heart2");
			Main.bubbleTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Bubble");
			Main.flameTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Flame");
			Main.manaTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Mana");
			Main.cursorTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Cursor");
			Main.ninjaTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Ninja");
			Main.antLionTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "AntlionBody");
			Main.spikeBaseTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Spike_Base");
			Main.woodTexture[0] = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Tiles_5_0");
			Main.woodTexture[1] = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Tiles_5_1");
			Main.woodTexture[2] = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Tiles_5_2");
			Main.woodTexture[3] = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Tiles_5_3");
			Main.woodTexture[4] = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Tiles_5_4");
			Main.woodTexture[5] = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Tiles_5_5");
			Main.woodTexture[6] = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Tiles_5_6");
			for (int num12 = 0; num12 < Main.moonTexture.Length; num12++)
			{
				Main.moonTexture[num12] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Moon_",
					num12
				}));
			}
			for (int num13 = 0; num13 < Main.treeTopTexture.Length; num13++)
			{
				Main.treeTopTexture[num13] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Tree_Tops_",
					num13
				}));
			}
			for (int num14 = 0; num14 < Main.treeBranchTexture.Length; num14++)
			{
				Main.treeBranchTexture[num14] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Tree_Branches_",
					num14
				}));
			}
			Main.shroomCapTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Shroom_Tops");
			Main.inventoryBackTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Inventory_Back");
			Main.inventoryBack2Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Inventory_Back2");
			Main.inventoryBack3Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Inventory_Back3");
			Main.inventoryBack4Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Inventory_Back4");
			Main.inventoryBack5Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Inventory_Back5");
			Main.inventoryBack6Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Inventory_Back6");
			Main.inventoryBack7Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Inventory_Back7");
			Main.inventoryBack8Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Inventory_Back8");
			Main.inventoryBack9Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Inventory_Back9");
			Main.inventoryBack10Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Inventory_Back10");
			Main.inventoryBack11Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Inventory_Back11");
			Main.inventoryBack12Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Inventory_Back12");
			Main.textBackTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Text_Back");
			Main.chatTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chat");
			Main.chat2Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chat2");
			Main.chatBackTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chat_Back");
			Main.teamTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Team");
			Main.skinBodyTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Skin_Body");
			Main.skinLegsTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Skin_Legs");
			Main.playerEyeWhitesTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Player_Eye_Whites");
			Main.playerEyesTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Player_Eyes");
			Main.playerHandsTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Player_Hands");
			Main.playerHands2Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Player_Hands2");
			Main.playerHeadTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Player_Head");
			Main.playerPantsTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Player_Pants");
			Main.playerShirtTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Player_Shirt");
			Main.playerShoesTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Player_Shoes");
			Main.playerUnderShirtTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Player_Undershirt");
			Main.playerUnderShirt2Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Player_Undershirt2");
			Main.femalePantsTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Female_Pants");
			Main.femaleShirtTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Female_Shirt");
			Main.femaleShoesTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Female_Shoes");
			Main.femaleUnderShirtTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Female_Undershirt");
			Main.femaleUnderShirt2Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Female_Undershirt2");
			Main.femaleShirt2Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Female_Shirt2");
			Main.chaosTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chaos");
			Main.EyeLaserTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Eye_Laser");
			Main.BoneEyesTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Bone_eyes");
			Main.BoneLaserTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Bone_Laser");
			Main.lightDiscTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Light_Disc");
			Main.confuseTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Confuse");
			Main.probeTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Probe");
			Main.sunOrbTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "SunOrb");
			Main.sunAltarTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "SunAltar");
			Main.chainTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain");
			Main.chain2Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain2");
			Main.chain3Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain3");
			Main.chain4Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain4");
			Main.chain5Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain5");
			Main.chain6Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain6");
			Main.chain7Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain7");
			Main.chain8Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain8");
			Main.chain9Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain9");
			Main.chain10Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain10");
			Main.chain11Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain11");
			Main.chain12Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain12");
			Main.chain13Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain13");
			Main.chain14Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain14");
			Main.chain15Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain15");
			Main.chain16Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain16");
			Main.chain17Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain17");
			Main.chain18Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain18");
			Main.chain19Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain19");
			Main.chain20Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain20");
			Main.chain21Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain21");
			Main.chain22Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain22");
			Main.chain23Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain23");
			Main.chain24Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain24");
			Main.chain25Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain25");
			Main.chain26Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain26");
			Main.chain27Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Chain27");
			Main.boneArmTexture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Arm_Bone");
			Main.boneArm2Texture = base.Content.Load<Texture2D>("Images" + Path.DirectorySeparatorChar + "Arm_Bone_2");
			for (int num15 = 1; num15 < Main.gemChainTexture.Length; num15++)
			{
				Main.gemChainTexture[num15] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"GemChain_",
					num15
				}));
			}
			for (int num16 = 1; num16 < Main.golemTexture.Length; num16++)
			{
				Main.golemTexture[num16] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"GolemLights",
					num16
				}));
			}
			Main.fontItemStack = base.Content.Load<SpriteFont>("Fonts" + Path.DirectorySeparatorChar + "Item_Stack");
			Main.fontMouseText = base.Content.Load<SpriteFont>("Fonts" + Path.DirectorySeparatorChar + "Mouse_Text");
			Main.fontDeathText = base.Content.Load<SpriteFont>("Fonts" + Path.DirectorySeparatorChar + "Death_Text");
			Main.fontCombatText[0] = base.Content.Load<SpriteFont>("Fonts" + Path.DirectorySeparatorChar + "Combat_Text");
			Main.fontCombatText[1] = base.Content.Load<SpriteFont>("Fonts" + Path.DirectorySeparatorChar + "Combat_Crit");*/
		}
		protected void UnloadContent()
		{
		}
		protected void UpdateMusic()
		{
			if (Main.musicVolume == 0f)
			{
				Main.curMusic = 0;
			}
			try
			{
				if (!Main.dedServ)
				{/*
					if (Main.curMusic > 0)
					{
						if (!base.IsActive)
						{
							if (!Main.music[Main.curMusic].IsPaused && Main.music[Main.curMusic].IsPlaying)
							{
								try
								{
									Main.music[Main.curMusic].Pause();
								}
								catch
								{
								}
							}
							return;
						}
						if (Main.music[Main.curMusic].IsPaused)
						{
							Main.music[Main.curMusic].Resume();
						}
					}
					bool flag = false;
					bool flag2 = false;
					bool flag3 = false;
					bool flag4 = false;
					bool flag5 = false;
					bool flag6 = false;
					Rectangle rectangle = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
					int num = 5000;
					for (int i = 0; i < 200; i++)
					{
						if (Main.npc[i].active)
						{
							if (Main.npc[i].type == 262 || Main.npc[i].type == 263 || Main.npc[i].type == 264)
							{
								Rectangle value = new Rectangle((int)(Main.npc[i].position.X + (float)(Main.npc[i].width / 2)) - num, (int)(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2)) - num, num * 2, num * 2);
								if (rectangle.Intersects(value))
								{
									flag6 = true;
									break;
								}
							}
							else
							{
								if (Main.npc[i].type == 134 || Main.npc[i].type == 143 || Main.npc[i].type == 144 || Main.npc[i].type == 145 || Main.npc[i].type == 266)
								{
									Rectangle value2 = new Rectangle((int)(Main.npc[i].position.X + (float)(Main.npc[i].width / 2)) - num, (int)(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2)) - num, num * 2, num * 2);
									if (rectangle.Intersects(value2))
									{
										flag3 = true;
										break;
									}
								}
								else
								{
									if ((Main.npc[i].type >= 212 && Main.npc[i].type <= 216) || Main.npc[i].type == 245)
									{
										Rectangle value3 = new Rectangle((int)(Main.npc[i].position.X + (float)(Main.npc[i].width / 2)) - num, (int)(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2)) - num, num * 2, num * 2);
										if (rectangle.Intersects(value3))
										{
											flag4 = true;
											break;
										}
									}
									else
									{
										if (Main.npc[i].type == 113 || Main.npc[i].type == 114 || Main.npc[i].type == 125 || Main.npc[i].type == 126)
										{
											Rectangle value4 = new Rectangle((int)(Main.npc[i].position.X + (float)(Main.npc[i].width / 2)) - num, (int)(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2)) - num, num * 2, num * 2);
											if (rectangle.Intersects(value4))
											{
												flag2 = true;
												break;
											}
										}
										else
										{
											if (Main.npc[i].type == 222)
											{
												Rectangle value5 = new Rectangle((int)(Main.npc[i].position.X + (float)(Main.npc[i].width / 2)) - num, (int)(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2)) - num, num * 2, num * 2);
												if (rectangle.Intersects(value5))
												{
													flag5 = true;
													break;
												}
											}
											else
											{
												if (Main.npc[i].boss || Main.npc[i].type == 13 || Main.npc[i].type == 14 || Main.npc[i].type == 15 || Main.npc[i].type == 134 || Main.npc[i].type == 26 || Main.npc[i].type == 27 || Main.npc[i].type == 28 || Main.npc[i].type == 29 || Main.npc[i].type == 111)
												{
													Rectangle value6 = new Rectangle((int)(Main.npc[i].position.X + (float)(Main.npc[i].width / 2)) - num, (int)(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2)) - num, num * 2, num * 2);
													if (rectangle.Intersects(value6))
													{
														flag = true;
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
					int num2 = (int)((Main.screenPosition.X + (float)(Main.screenWidth / 2)) / 16f);
					if (Main.musicVolume == 0f)
					{
						this.newMusic = 0;
					}
					else
					{
						if (Main.gameMenu)
						{
							if (Main.netMode != 2)
							{
								this.newMusic = 6;
							}
							else
							{
								this.newMusic = 0;
							}
						}
						else
						{
							float num3 = (float)(Main.maxTilesX / 4200);
							num3 *= num3;
							float num4 = (float)((double)((Main.screenPosition.Y + (float)(Main.screenHeight / 2)) / 16f - (65f + 10f * num3)) / (Main.worldSurface / 5.0));
							if (flag6)
							{
								this.newMusic = 24;
							}
							else
							{
								if (flag2)
								{
									this.newMusic = 12;
								}
								else
								{
									if (flag)
									{
										this.newMusic = 5;
									}
									else
									{
										if (flag3)
										{
											this.newMusic = 13;
										}
										else
										{
											if (flag4)
											{
												this.newMusic = 17;
											}
											else
											{
												if (flag5)
												{
													this.newMusic = 25;
												}
												else
												{
													if (Main.player[Main.myPlayer].position.Y > (float)((Main.maxTilesY - 200) * 16))
													{
														this.newMusic = 2;
													}
													else
													{
														if (Main.eclipse && (double)Main.player[Main.myPlayer].position.Y < Main.worldSurface * 16.0 + (double)(Main.screenHeight / 2))
														{
															this.newMusic = 27;
														}
														else
														{
															if (num4 < 1f)
															{
																this.newMusic = 15;
															}
															else
															{
																if (Main.tile[(int)(Main.player[Main.myPlayer].Center().X / 16f), (int)(Main.player[Main.myPlayer].Center().Y / 16f)].wall == 87)
																{
																	this.newMusic = 26;
																}
																else
																{
																	if ((Main.bgStyle == 9 && (double)Main.player[Main.myPlayer].position.Y < Main.worldSurface * 16.0 + (double)(Main.screenHeight / 2)) || Main.ugBack == 2)
																	{
																		this.newMusic = 29;
																	}
																	else
																	{
																		if (Main.player[Main.myPlayer].zoneEvil)
																		{
																			if ((double)Main.player[Main.myPlayer].position.Y > Main.worldSurface * 16.0 + (double)(Main.screenHeight / 2))
																			{
																				this.newMusic = 10;
																			}
																			else
																			{
																				this.newMusic = 8;
																			}
																		}
																		else
																		{
																			if (Main.player[Main.myPlayer].zoneBlood)
																			{
																				if ((double)Main.player[Main.myPlayer].position.Y > Main.worldSurface * 16.0 + (double)(Main.screenHeight / 2))
																				{
																					this.newMusic = 16;
																				}
																				else
																				{
																					this.newMusic = 16;
																				}
																			}
																			else
																			{
																				if (Main.player[Main.myPlayer].zoneDungeon)
																				{
																					this.newMusic = 23;
																				}
																				else
																				{
																					if (Main.player[Main.myPlayer].zoneMeteor)
																					{
																						this.newMusic = 2;
																					}
																					else
																					{
																						if (Main.player[Main.myPlayer].zoneJungle)
																						{
																							this.newMusic = 7;
																						}
																						else
																						{
																							if (Main.player[Main.myPlayer].zoneSnow)
																							{
																								if ((double)Main.player[Main.myPlayer].position.Y > Main.worldSurface * 16.0 + (double)(Main.screenHeight / 2))
																								{
																									this.newMusic = 20;
																								}
																								else
																								{
																									this.newMusic = 14;
																								}
																							}
																							else
																							{
																								if ((double)Main.player[Main.myPlayer].position.Y > Main.worldSurface * 16.0 + (double)(Main.screenHeight / 2))
																								{
																									if (Main.player[Main.myPlayer].zoneHoly)
																									{
																										this.newMusic = 11;
																									}
																									else
																									{
																										this.newMusic = 4;
																									}
																								}
																								else
																								{
																									if (Main.dayTime && Main.player[Main.myPlayer].zoneHoly)
																									{
																										if (Main.cloudAlpha > 0f && !Main.gameMenu)
																										{
																											this.newMusic = 19;
																										}
																										else
																										{
																											this.newMusic = 9;
																										}
																									}
																									else
																									{
																										if ((double)(Main.screenPosition.Y / 16f) < Main.worldSurface + 10.0 && (num2 < 380 || num2 > Main.maxTilesX - 380))
																										{
																											this.newMusic = 22;
																										}
																										else
																										{
																											if (Main.sandTiles > 1000)
																											{
																												this.newMusic = 21;
																											}
																											else
																											{
																												if (Main.dayTime)
																												{
																													if (Main.cloudAlpha > 0f && !Main.gameMenu)
																													{
																														this.newMusic = 19;
																													}
																													else
																													{
																														if (Main.dayMusic == 0)
																														{
																															Main.dayMusic = 1;
																														}
																														if (!Main.music[1].IsPlaying && !Main.music[18].IsPlaying)
																														{
																															int num5 = Main.rand.Next(2);
																															if (num5 == 0)
																															{
																																Main.dayMusic = 1;
																															}
																															else
																															{
																																if (num5 == 1)
																																{
																																	Main.dayMusic = 18;
																																}
																															}
																														}
																														this.newMusic = Main.dayMusic;
																													}
																												}
																												else
																												{
																													if (!Main.dayTime)
																													{
																														if (Main.bloodMoon)
																														{
																															this.newMusic = 2;
																														}
																														else
																														{
																															if (Main.cloudAlpha > 0f && !Main.gameMenu)
																															{
																																this.newMusic = 19;
																															}
																															else
																															{
																																this.newMusic = 3;
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
					}
					Main.curMusic = this.newMusic;
					for (int j = 1; j < 30; j++)
					{
						if (j == 28)
						{
							if (Main.cloudAlpha > 0f && (double)Main.player[Main.myPlayer].position.Y < Main.worldSurface * 16.0 + (double)(Main.screenHeight / 2) && !Main.player[Main.myPlayer].zoneSnow)
							{
								if (!Main.music[j].IsPlaying)
								{
									Main.music[j] = Main.soundBank.GetCue("Music_" + j);
									Main.music[j].Play();
									Main.music[j].SetVariable("Volume", Main.musicFade[j] * Main.musicVolume);
								}
								else
								{
									Main.musicFade[j] += 0.005f;
									if (Main.musicFade[j] > 1f)
									{
										Main.musicFade[j] = 1f;
									}
									Main.music[j].SetVariable("Volume", Main.musicFade[j] * Main.musicVolume);
								}
							}
							else
							{
								if (Main.music[j].IsPlaying)
								{
									if (Main.musicFade[Main.curMusic] > 0.25f)
									{
										Main.musicFade[j] -= 0.005f;
									}
									else
									{
										if (Main.curMusic == 0)
										{
											Main.musicFade[j] = 0f;
										}
									}
									if (Main.musicFade[j] <= 0f)
									{
										Main.musicFade[j] -= 0f;
										Main.music[j].Stop(AudioStopOptions.Immediate);
									}
									else
									{
										Main.music[j].SetVariable("Volume", Main.musicFade[j] * Main.musicVolume);
									}
								}
								else
								{
									Main.musicFade[j] = 0f;
								}
							}
						}
						else
						{
							if (j == Main.curMusic)
							{
								if (!Main.music[j].IsPlaying)
								{
									Main.music[j] = Main.soundBank.GetCue("Music_" + j);
									Main.music[j].Play();
									Main.music[j].SetVariable("Volume", Main.musicFade[j] * Main.musicVolume);
								}
								else
								{
									Main.musicFade[j] += 0.005f;
									if (Main.musicFade[j] > 1f)
									{
										Main.musicFade[j] = 1f;
									}
									Main.music[j].SetVariable("Volume", Main.musicFade[j] * Main.musicVolume);
								}
							}
							else
							{
								if (Main.music[j].IsPlaying)
								{
									if (Main.musicFade[Main.curMusic] > 0.25f)
									{
										Main.musicFade[j] -= 0.005f;
									}
									else
									{
										if (Main.curMusic == 0)
										{
											Main.musicFade[j] = 0f;
										}
									}
									if (Main.musicFade[j] <= 0f)
									{
										Main.musicFade[j] -= 0f;
										Main.music[j].Stop(AudioStopOptions.Immediate);
									}
									else
									{
										Main.music[j].SetVariable("Volume", Main.musicFade[j] * Main.musicVolume);
									}
								}
								else
								{
									Main.musicFade[j] = 0f;
								}
							}
						}
					}
					if (Main.musicError > 0)
					{
						Main.musicError--;
					}
				*/}
			}
			catch
			{
				Main.musicError++;
				if (Main.musicError >= 100)
				{
					Main.musicError = 0;
					Main.musicVolume = 0f;
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
				while ((float)num4 < num3 && (float)Main.snowDust < (float)num2 * (Main.gfxQuality / 2f + 0.5f) + (float)num2 * 0.1f)
				{
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
						else
						{
							if (Main.rand.Next(5) == 0)
							{
								num5 = Main.rand.Next(500) + Main.screenWidth;
							}
						}
						if (num5 < 0 || num5 > Main.screenWidth)
						{
							num6 += Main.rand.Next((int)((double)Main.screenHeight * 0.5)) + (int)((double)Main.screenHeight * 0.1);
						}
						num5 += (int)Main.screenPosition.X;
						int num7 = num5 / 16;
						int num8 = num6 / 16;
						if (Main.tile[num7, num8].wall == 0)
						{
							int num9 = Dust.NewDust(new Vector2((float)num5, (float)num6), 10, 10, 76, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num9].scale += Main.cloudAlpha * 0.2f;
							Main.dust[num9].velocity.Y = 3f + (float)Main.rand.Next(30) * 0.1f;
							Dust expr_27E_cp_0 = Main.dust[num9];
							expr_27E_cp_0.velocity.Y = expr_27E_cp_0.velocity.Y * Main.dust[num9].scale;
							Main.dust[num9].velocity.X = Main.windSpeed + (float)Main.rand.Next(-10, 10) * 0.1f;
							Dust expr_2D1_cp_0 = Main.dust[num9];
							expr_2D1_cp_0.velocity.X = expr_2D1_cp_0.velocity.X + Main.windSpeed * Main.cloudAlpha * 10f;
							Dust expr_2FB_cp_0 = Main.dust[num9];
							expr_2FB_cp_0.velocity.Y = expr_2FB_cp_0.velocity.Y * (1f + 0.3f * Main.cloudAlpha);
							Main.dust[num9].scale += Main.cloudAlpha * 0.2f;
							Main.dust[num9].velocity *= 1f + Main.cloudAlpha * 0.5f;
						}
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
		protected void Update()
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
			if (Main.netMode != 2)
			{
				Main.snowing();
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
			
			if (Main.netMode == 1)
			{
				for (int k = 0; k < 59; k++)
				{
					if (Main.player[Main.myPlayer].inventory[k].IsNotTheSameAs(Main.clientPlayer.inventory[k]))
					{
						NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].inventory[k].name, Main.myPlayer, (float)k, (float)Main.player[Main.myPlayer].inventory[k].prefix, 0f, 0);
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
				if (Main.player[Main.myPlayer].dye[0].IsNotTheSameAs(Main.clientPlayer.dye[0]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].dye[0].name, Main.myPlayer, 70f, (float)Main.player[Main.myPlayer].dye[0].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].dye[1].IsNotTheSameAs(Main.clientPlayer.dye[1]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].dye[1].name, Main.myPlayer, 71f, (float)Main.player[Main.myPlayer].dye[1].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].dye[2].IsNotTheSameAs(Main.clientPlayer.dye[2]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].dye[2].name, Main.myPlayer, 72f, (float)Main.player[Main.myPlayer].dye[2].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].chest != Main.clientPlayer.chest)
				{
					NetMessage.SendData(33, -1, -1, "", Main.player[Main.myPlayer].chest, 0f, 0f, 0f, 0);
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
				bool flag = false;
				for (int l = 0; l < 10; l++)
				{
					if (Main.player[Main.myPlayer].buffType[l] != Main.clientPlayer.buffType[l])
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
			if (Main.netMode == 0 && (Main.playerInventory || Main.npcChatText != "" || Main.player[Main.myPlayer].sign >= 0) && Main.autoPause)
			{/*
				Keys[] pressedKeys = Main.keyState.GetPressedKeys();
				Main.player[Main.myPlayer].controlInv = false;
				for (int m = 0; m < pressedKeys.Length; m++)
				{
					string text2 = string.Concat(pressedKeys[m]);
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
				if (Main.playerInventory)
				{
					int num7 = (Main.mouseState.ScrollWheelValue - Main.oldMouseState.ScrollWheelValue) / 120;
					Main.focusRecipe += num7;
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
					}
				}
				Main.gamePaused = true;
				return;*/
			}
			Main.gamePaused = false;
			if (!Main.dedServ && (double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0 && Main.netMode != 2)
			{
				Star.UpdateStars();
				Cloud.UpdateClouds();
			}
			Main.numPlayers = 0;
			int n = 0;
			while (n < 255)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.player[n].UpdatePlayer(n);
						goto IL_2463;
					}
					catch
					{
						goto IL_2463;
					}
					goto IL_2454;
				}
				goto IL_2454;
				IL_2463:
				n++;
				continue;
				IL_2454:
				Main.player[n].UpdatePlayer(n);
				goto IL_2463;
			}
			if (Main.netMode != 1)
			{
				NPC.SpawnNPC();
			}
			for (int num8 = 0; num8 < 255; num8++)
			{
				Main.player[num8].activeNPCs = 0f;
				Main.player[num8].townNPCs = 0f;
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
						goto IL_2573;
					}
					catch (Exception)
					{
						Main.npc[num9] = new NPC();
						goto IL_2573;
					}
					goto IL_2564;
				}
				goto IL_2564;
				IL_2573:
				num9++;
				continue;
				IL_2564:
				Main.npc[num9].UpdateNPC(num9);
				goto IL_2573;
			}
			int num10 = 0;
			while (num10 < 500)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.gore[num10].Update();
						goto IL_25BA;
					}
					catch
					{
						Main.gore[num10] = new Gore();
						goto IL_25BA;
					}
					goto IL_25AD;
				}
				goto IL_25AD;
				IL_25BA:
				num10++;
				continue;
				IL_25AD:
				Main.gore[num10].Update();
				goto IL_25BA;
			}
			int num11 = 0;
			while (num11 < 1000)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.projectile[num11].Update(num11);
						goto IL_2605;
					}
					catch
					{
						Main.projectile[num11] = new Projectile();
						goto IL_2605;
					}
					goto IL_25F6;
				}
				goto IL_25F6;
				IL_2605:
				num11++;
				continue;
				IL_25F6:
				Main.projectile[num11].Update(num11);
				goto IL_2605;
			}
			int num12 = 0;
			while (num12 < 400)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.item[num12].UpdateItem(num12);
						goto IL_2650;
					}
					catch
					{
						Main.item[num12] = new Item();
						goto IL_2650;
					}
					goto IL_2641;
				}
				goto IL_2641;
				IL_2650:
				num12++;
				continue;
				IL_2641:
				Main.item[num12].UpdateItem(num12);
				goto IL_2650;
			}
			if (Main.ignoreErrors)
			{
				try
				{
					Dust.UpdateDust();
					goto IL_2696;
				}
				catch
				{
					for (int num13 = 0; num13 < 6000; num13++)
					{
						Main.dust[num13] = new Dust();
					}
					goto IL_2696;
				}
			}
			Dust.UpdateDust();
			IL_2696:
			if (Main.netMode != 2)
			{
				/*CombatText.UpdateCombatText();
				ItemText.UpdateItemText();*/
			}
			if (Main.ignoreErrors)
			{
				try
				{
					Main.UpdateTime();
					goto IL_26C4;
				}
				catch
				{
					Main.checkForSpawns = 0;
					goto IL_26C4;
				}
			}
			Main.UpdateTime();
			IL_26C4:
			if (Main.netMode != 1)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						WorldGen.UpdateWorld();
						Main.UpdateInvasion();
						goto IL_26EC;
					}
					catch
					{
						goto IL_26EC;
					}
				}
				WorldGen.UpdateWorld();
				Main.UpdateInvasion();
			}
			IL_26EC:
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
					goto IL_2734;
				}
				catch
				{
					int arg_2717_0 = Main.netMode;
					goto IL_2734;
				}
			}
			if (Main.netMode == 2)
			{
				Main.UpdateServer();
				goto IL_2727;
			}
			goto IL_2727;
			IL_2734:
			if (Main.ignoreErrors)
			{
				try
				{
					for (int num14 = 0; num14 < Main.numChatLines; num14++)
					{
						if (Main.chatLine[num14].showTime > 0)
						{
							Main.chatLine[num14].showTime--;
						}
					}
					goto IL_27D3;
				}
				catch
				{
					for (int num15 = 0; num15 < Main.numChatLines; num15++)
					{
						Main.chatLine[num15] = new ChatLine();
					}
					goto IL_27D3;
				}
				goto IL_279A;
			}
			goto IL_279A;
			IL_27D3:
			Main.upTimer = (float)stopwatch.ElapsedMilliseconds;
			if (Main.upTimerMaxDelay > 0f)
			{
				Main.upTimerMaxDelay -= 1f;
				goto IL_2807;
			}
			Main.upTimerMax = 0f;
			goto IL_2807;
			IL_279A:
			for (int num16 = 0; num16 < Main.numChatLines; num16++)
			{
				if (Main.chatLine[num16].showTime > 0)
				{
					Main.chatLine[num16].showTime--;
				}
			}
			goto IL_27D3;
			IL_2727:
			if (Main.netMode == 1)
			{
				Main.UpdateClient();
				goto IL_2734;
			}
			goto IL_2734;
			IL_2807:
			if (Main.upTimer > Main.upTimerMax)
			{
				Main.upTimerMax = Main.upTimer;
				Main.upTimerMaxDelay = 400f;
			}
			//base.Update();
		}
		private static void UpdateMenu()
		{/*
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
					else
					{
						if (Main.time > 54000.0)
						{
							Main.time = 0.0;
							Main.dayTime = false;
							return;
						}
					}
				}
			}
			else
			{
				if (Main.netMode == 1)
				{
					Main.UpdateTime();
				}
			}*/
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
			else
			{
				if (type == 117)
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
					else
					{
						if (type == 147 || type == 161)
						{
							num = (int)((float)newColor.R * 1.1f);
							num2 = (int)((float)newColor.G * 1.12f);
							num3 = (int)((double)((float)newColor.B) * 1.15);
						}
						else
						{
							if (type == 163)
							{
								num = (int)((float)newColor.R * 1.05f);
								num2 = (int)((float)newColor.G * 1.1f);
								num3 = (int)((double)((float)newColor.B) * 1.15);
							}
							else
							{
								if (type == 164)
								{
									num = (int)((float)newColor.R * 1.1f);
									num2 = (int)((float)newColor.G * 1.1f);
									num3 = (int)((double)((float)newColor.B) * 1.2);
								}
								else
								{
									if (type == 178)
									{
										num4 = 0.5f;
										num = (int)((float)newColor.R * (1f + num4));
										num2 = (int)((float)newColor.G * (1f + num4));
										num3 = (int)((float)newColor.B * (1f + num4));
									}
									else
									{
										if (type == 185 || type == 186)
										{
											num4 = 0.3f;
											num = (int)((float)newColor.R * (1f + num4));
											num2 = (int)((float)newColor.G * (1f + num4));
											num3 = (int)((float)newColor.B * (1f + num4));
										}
										else
										{
											num = (int)((float)newColor.R * (1f + num4));
											num2 = (int)((float)newColor.G * (1f + num4));
											num3 = (int)((float)newColor.B * (1f + num4));
										}
									}
								}
							}
						}
					}
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
		public static bool canDrawColorTile(int i, int j)
		{
			return Main.tile[i, j] != null && Main.tile[i, j].color() > 0 && (int)Main.tile[i, j].color() < Main.numTileColors && Main.tileAltTextureDrawn[(int)Main.tile[i, j].type, (int)Main.tile[i, j].color()] && Main.tileAltTextureInit[(int)Main.tile[i, j].type, (int)Main.tile[i, j].color()];
		}
		public static bool canDrawColorWall(int i, int j)
		{
			return Main.tile[i, j] != null && Main.tile[i, j].wallColor() > 0 && Main.wallAltTextureDrawn[(int)Main.tile[i, j].wall, (int)Main.tile[i, j].wallColor()] && Main.wallAltTextureInit[(int)Main.tile[i, j].wall, (int)Main.tile[i, j].wallColor()];
		}
		public static float NPCAddHeight(int i)
		{
			float num = 0f;
			if (Main.npc[i].type == 125)
			{
				num = 30f;
			}
			else
			{
				if (Main.npc[i].type == 205)
				{
					num = 8f;
				}
				else
				{
					if (Main.npc[i].type == 182)
					{
						num = 24f;
					}
					else
					{
						if (Main.npc[i].type == 178)
						{
							num = 2f;
						}
						else
						{
							if (Main.npc[i].type == 126)
							{
								num = 30f;
							}
							else
							{
								if (Main.npc[i].type == 6 || Main.npc[i].type == 173)
								{
									num = 26f;
								}
								else
								{
									if (Main.npc[i].type == 94)
									{
										num = 14f;
									}
									else
									{
										if (Main.npc[i].type == 7 || Main.npc[i].type == 8 || Main.npc[i].type == 9)
										{
											num = 13f;
										}
										else
										{
											if (Main.npc[i].type == 98 || Main.npc[i].type == 99 || Main.npc[i].type == 100)
											{
												num = 13f;
											}
											else
											{
												if (Main.npc[i].type == 95 || Main.npc[i].type == 96 || Main.npc[i].type == 97)
												{
													num = 13f;
												}
												else
												{
													if (Main.npc[i].type == 10 || Main.npc[i].type == 11 || Main.npc[i].type == 12)
													{
														num = 8f;
													}
													else
													{
														if (Main.npc[i].type == 13 || Main.npc[i].type == 14 || Main.npc[i].type == 15)
														{
															num = 26f;
														}
														else
														{
															if (Main.npc[i].type == 175)
															{
																num = 4f;
															}
															else
															{
																if (Main.npc[i].type == 48)
																{
																	num = 32f;
																}
																else
																{
																	if (Main.npc[i].type == 49 || Main.npc[i].type == 51)
																	{
																		num = 4f;
																	}
																	else
																	{
																		if (Main.npc[i].type == 60)
																		{
																			num = 10f;
																		}
																		else
																		{
																			if (Main.npc[i].type == 62 || Main.npc[i].type == 66 || Main.npc[i].type == 156)
																			{
																				num = 14f;
																			}
																			else
																			{
																				if (Main.npc[i].type == 63 || Main.npc[i].type == 64 || Main.npc[i].type == 103)
																				{
																					num = 4f;
																				}
																				else
																				{
																					if (Main.npc[i].type == 65)
																					{
																						num = 14f;
																					}
																					else
																					{
																						if (Main.npc[i].type == 69)
																						{
																							num = 4f;
																						}
																						else
																						{
																							if (Main.npc[i].type == 70)
																							{
																								num = -4f;
																							}
																							else
																							{
																								if (Main.npc[i].type == 72)
																								{
																									num = -2f;
																								}
																								else
																								{
																									if (Main.npc[i].type == 83 || Main.npc[i].type == 84)
																									{
																										num = 20f;
																									}
																									else
																									{
																										if (Main.npc[i].type == 150 || Main.npc[i].type == 151 || Main.npc[i].type == 158)
																										{
																											num = 10f;
																										}
																										else
																										{
																											if (Main.npc[i].type == 152)
																											{
																												num = 6f;
																											}
																											else
																											{
																												if (Main.npc[i].type == 153 || Main.npc[i].type == 154)
																												{
																													num = 4f;
																												}
																												else
																												{
																													if (Main.npc[i].type == 165 || Main.npc[i].type == 237 || Main.npc[i].type == 238 || Main.npc[i].type == 240)
																													{
																														num = 10f;
																													}
																													else
																													{
																														if (Main.npc[i].type == 39 || Main.npc[i].type == 40 || Main.npc[i].type == 41)
																														{
																															num = 26f;
																														}
																														else
																														{
																															if (Main.npc[i].type >= 87 && Main.npc[i].type <= 92)
																															{
																																num = 56f;
																															}
																															else
																															{
																																if (Main.npc[i].type >= 134 && Main.npc[i].type <= 136)
																																{
																																	num = 30f;
																																}
																																else
																																{
																																	if (Main.npc[i].type == 169)
																																	{
																																		num = 8f;
																																	}
																																	else
																																	{
																																		if (Main.npc[i].type == 174)
																																		{
																																			num = 6f;
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
				if (Main.player[Main.myPlayer].inventory[i].type == 75)
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
				if (Main.helpText == 1002 && !NPC.downedBoss3)
				{
					goto Block_102;
				}
				if (Main.helpText == 1050 && !NPC.downedBoss1 && Main.player[Main.myPlayer].statLifeMax < 200)
				{
					goto Block_105;
				}
				if (Main.helpText == 1051 && !NPC.downedBoss1 && Main.player[Main.myPlayer].statDefense <= 10)
				{
					goto Block_108;
				}
				if (Main.helpText == 1052 && !NPC.downedBoss1 && Main.player[Main.myPlayer].statLifeMax >= 200 && Main.player[Main.myPlayer].statDefense > 10)
				{
					goto Block_112;
				}
				if (Main.helpText == 1053 && NPC.downedBoss1 && !NPC.downedBoss2 && Main.player[Main.myPlayer].statLifeMax < 300)
				{
					goto Block_116;
				}
				if (Main.helpText == 1054 && NPC.downedBoss1 && !NPC.downedBoss2 && Main.player[Main.myPlayer].statLifeMax >= 300)
				{
					goto Block_120;
				}
				if (Main.helpText == 1055 && NPC.downedBoss1 && !NPC.downedBoss2 && Main.player[Main.myPlayer].statLifeMax >= 300)
				{
					goto Block_124;
				}
				if (Main.helpText == 1056 && NPC.downedBoss1 && NPC.downedBoss2 && !NPC.downedBoss3)
				{
					goto Block_128;
				}
				if (Main.helpText == 1057 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax < 400)
				{
					goto Block_134;
				}
				if (Main.helpText == 1058 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax >= 400)
				{
					goto Block_140;
				}
				if (Main.helpText == 1059 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax >= 400)
				{
					goto Block_146;
				}
				if (Main.helpText == 1060 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax >= 400)
				{
					goto Block_152;
				}
				if (Main.helpText == 1061 && Main.hardMode)
				{
					goto Block_154;
				}
				if (Main.helpText == 1062 && Main.hardMode)
				{
					goto Block_156;
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
			Main.npcChatText = Lang.dialog(210, false);
			return;
			Block_105:
			Main.npcChatText = Lang.dialog(211, false);
			return;
			Block_108:
			Main.npcChatText = Lang.dialog(212, false);
			return;
			Block_112:
			Main.npcChatText = Lang.dialog(213, false);
			return;
			Block_116:
			Main.npcChatText = Lang.dialog(214, false);
			return;
			Block_120:
			Main.npcChatText = Lang.dialog(215, false);
			return;
			Block_124:
			Main.npcChatText = Lang.dialog(216, false);
			return;
			Block_128:
			Main.npcChatText = Lang.dialog(217, false);
			return;
			Block_134:
			Main.npcChatText = Lang.dialog(218, false);
			return;
			Block_140:
			Main.npcChatText = Lang.dialog(219, false);
			return;
			Block_146:
			Main.npcChatText = Lang.dialog(220, false);
			return;
			Block_152:
			Main.npcChatText = Lang.dialog(221, false);
			return;
			Block_154:
			Main.npcChatText = Lang.dialog(222, false);
			return;
			Block_156:
			Main.npcChatText = Lang.dialog(223, false);
		}
		protected void DrawChat()
		{/*
			if (Main.player[Main.myPlayer].talkNPC < 0 && Main.player[Main.myPlayer].sign == -1)
			{
				Main.npcChatText = "";
				return;
			}
			if (Main.netMode == 0 && Main.autoPause && Main.player[Main.myPlayer].talkNPC >= 0)
			{
				if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 105)
				{
					Main.npc[Main.player[Main.myPlayer].talkNPC].Transform(107);
				}
				if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 106)
				{
					Main.npc[Main.player[Main.myPlayer].talkNPC].Transform(108);
				}
				if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 123)
				{
					Main.npc[Main.player[Main.myPlayer].talkNPC].Transform(124);
				}
			}
			Color color = new Color(200, 200, 200, 200);
			int num = (int)((Main.mouseTextColor * 2 + 255) / 3);
			Color color2 = new Color(num, num, num, num);
			int num2 = 10;
			int num3 = 0;
			string[] array = new string[num2];
			int num4 = 0;
			int num5 = 0;
			if (Main.npcChatText == null)
			{
				Main.npcChatText = "";
			}
			for (int i = 0; i < Main.npcChatText.Length; i++)
			{
				byte[] bytes = Encoding.ASCII.GetBytes(Main.npcChatText.Substring(i, 1));
				if (bytes[0] == 10)
				{
					array[num3] = Main.npcChatText.Substring(num4, i - num4);
					num3++;
					num4 = i + 1;
					num5 = i + 1;
				}
				else
				{
					if (Main.npcChatText.Substring(i, 1) == " " || i == Main.npcChatText.Length - 1)
					{
						if (Main.fontMouseText.MeasureString(Main.npcChatText.Substring(num4, i - num4)).X > 470f)
						{
							array[num3] = Main.npcChatText.Substring(num4, num5 - num4);
							num3++;
							num4 = num5 + 1;
						}
						num5 = i;
					}
				}
				if (num3 == 10)
				{
					Main.npcChatText = Main.npcChatText.Substring(0, i - 1);
					num4 = i - 1;
					num3 = 9;
					break;
				}
			}
			if (num3 < 10)
			{
				array[num3] = Main.npcChatText.Substring(num4, Main.npcChatText.Length - num4);
			}
			if (Main.editSign)
			{
				this.textBlinkerCount++;
				if (this.textBlinkerCount >= 20)
				{
					if (this.textBlinkerState == 0)
					{
						this.textBlinkerState = 1;
					}
					else
					{
						this.textBlinkerState = 0;
					}
					this.textBlinkerCount = 0;
				}
				if (this.textBlinkerState == 1)
				{
					string[] array2;
					IntPtr intPtr;
					(array2 = array)[(int)(intPtr = (IntPtr)num3)] = array2[(int)intPtr] + "|";
				}
			}
			num3++;
			this.spriteBatch.Draw(Main.chatBackTexture, new Vector2((float)(Main.screenWidth / 2 - Main.chatBackTexture.Width / 2), 100f), new Rectangle?(new Rectangle(0, 0, Main.chatBackTexture.Width, (num3 + 1) * 30)), color, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
			this.spriteBatch.Draw(Main.chatBackTexture, new Vector2((float)(Main.screenWidth / 2 - Main.chatBackTexture.Width / 2), (float)(100 + (num3 + 1) * 30)), new Rectangle?(new Rectangle(0, Main.chatBackTexture.Height - 30, Main.chatBackTexture.Width, 30)), color, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
			for (int j = 0; j < num3; j++)
			{
				for (int k = 0; k < 5; k++)
				{
					Color color3 = Color.Black;
					int num6 = 170 + (Main.screenWidth - 800) / 2;
					int num7 = 120 + j * 30;
					if (k == 0)
					{
						num6 -= 2;
					}
					if (k == 1)
					{
						num6 += 2;
					}
					if (k == 2)
					{
						num7 -= 2;
					}
					if (k == 3)
					{
						num7 += 2;
					}
					if (k == 4)
					{
						color3 = color2;
					}
					this.spriteBatch.DrawString(Main.fontMouseText, array[j], new Vector2((float)num6, (float)num7), color3, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
				}
			}
			num = (int)Main.mouseTextColor;
			color2 = new Color(num, (int)((double)num / 1.1), num / 2, num);
			string text = "";
			string text2 = "";
			int num8 = Main.player[Main.myPlayer].statLifeMax - Main.player[Main.myPlayer].statLife;
			for (int l = 0; l < 10; l++)
			{
				int num9 = Main.player[Main.myPlayer].buffType[l];
				if (Main.debuff[num9] && Main.player[Main.myPlayer].buffTime[l] > 0 && num9 != 28 && num9 != 34)
				{
					num8 += 1000;
				}
			}
			if (Main.player[Main.myPlayer].sign > -1)
			{
				if (Main.editSign)
				{
					text = Lang.inter[47];
				}
				else
				{
					text = Lang.inter[48];
				}
			}
			else
			{
				if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 20)
				{
					text = Lang.inter[28];
					text2 = Lang.inter[49];
				}
				else
				{
					if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 17 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 19 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 38 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 54 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 107 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 108 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 124 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 142 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 160 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 178 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 207 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 208 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 209 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 227 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 228 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 229)
					{
						text = Lang.inter[28];
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 107)
						{
							text2 = Lang.inter[19];
						}
					}
					else
					{
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 37)
						{
							if (!Main.dayTime)
							{
								text = Lang.inter[50];
							}
						}
						else
						{
							if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 22)
							{
								text = Lang.inter[51];
								text2 = Lang.inter[25];
							}
							else
							{
								if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 18)
								{
									string text3 = "";
									int num10 = 0;
									int num11 = 0;
									int num12 = 0;
									int num13 = 0;
									int num14 = num8;
									if (num14 > 0)
									{
										num14 = (int)((double)num14 * 0.75);
										if (num14 < 1)
										{
											num14 = 1;
										}
									}
									if (num14 < 0)
									{
										num14 = 0;
									}
									num8 = num14;
									if (num14 >= 1000000)
									{
										num10 = num14 / 1000000;
										num14 -= num10 * 1000000;
									}
									if (num14 >= 10000)
									{
										num11 = num14 / 10000;
										num14 -= num11 * 10000;
									}
									if (num14 >= 100)
									{
										num12 = num14 / 100;
										num14 -= num12 * 100;
									}
									if (num14 >= 1)
									{
										num13 = num14;
									}
									if (num10 > 0)
									{
										object obj = text3;
										text3 = string.Concat(new object[]
										{
											obj,
											num10,
											" ",
											Lang.inter[15],
											" "
										});
									}
									if (num11 > 0)
									{
										object obj2 = text3;
										text3 = string.Concat(new object[]
										{
											obj2,
											num11,
											" ",
											Lang.inter[16],
											" "
										});
									}
									if (num12 > 0)
									{
										object obj = text3;
										text3 = string.Concat(new object[]
										{
											obj,
											num12,
											" ",
											Lang.inter[17],
											" "
										});
									}
									if (num13 > 0)
									{
										object obj = text3;
										text3 = string.Concat(new object[]
										{
											obj,
											num13,
											" ",
											Lang.inter[18],
											" "
										});
									}
									float num15 = (float)Main.mouseTextColor / 255f;
									if (num10 > 0)
									{
										color2 = new Color((int)((byte)(220f * num15)), (int)((byte)(220f * num15)), (int)((byte)(198f * num15)), (int)Main.mouseTextColor);
									}
									else
									{
										if (num11 > 0)
										{
											color2 = new Color((int)((byte)(224f * num15)), (int)((byte)(201f * num15)), (int)((byte)(92f * num15)), (int)Main.mouseTextColor);
										}
										else
										{
											if (num12 > 0)
											{
												color2 = new Color((int)((byte)(181f * num15)), (int)((byte)(192f * num15)), (int)((byte)(193f * num15)), (int)Main.mouseTextColor);
											}
											else
											{
												if (num13 > 0)
												{
													color2 = new Color((int)((byte)(246f * num15)), (int)((byte)(138f * num15)), (int)((byte)(96f * num15)), (int)Main.mouseTextColor);
												}
											}
										}
									}
									text = Lang.inter[54] + " (" + text3 + ")";
									if (num14 == 0)
									{
										text = Lang.inter[54];
									}
								}
							}
						}
					}
				}
			}
			int num16 = 180 + (Main.screenWidth - 800) / 2;
			int num17 = 130 + num3 * 30;
			float scale = 0.9f;
			if (Main.mouseX > num16 && (float)Main.mouseX < (float)num16 + Main.fontMouseText.MeasureString(text).X && Main.mouseY > num17 && (float)Main.mouseY < (float)num17 + Main.fontMouseText.MeasureString(text).Y)
			{
				Main.player[Main.myPlayer].mouseInterface = true;
				scale = 1.1f;
				if (!Main.npcChatFocus2)
				{
					Main.PlaySound(12, -1, -1, 1);
				}
				Main.npcChatFocus2 = true;
				Main.player[Main.myPlayer].releaseUseItem = false;
			}
			else
			{
				if (Main.npcChatFocus2)
				{
					Main.PlaySound(12, -1, -1, 1);
				}
				Main.npcChatFocus2 = false;
			}
			for (int m = 0; m < 5; m++)
			{
				int num18 = num16;
				int num19 = num17;
				Color color4 = Color.Black;
				if (m == 0)
				{
					num18 -= 2;
				}
				if (m == 1)
				{
					num18 += 2;
				}
				if (m == 2)
				{
					num19 -= 2;
				}
				if (m == 3)
				{
					num19 += 2;
				}
				if (m == 4)
				{
					color4 = color2;
				}
				Vector2 vector = Main.fontMouseText.MeasureString(text);
				vector *= 0.5f;
				this.spriteBatch.DrawString(Main.fontMouseText, text, new Vector2((float)num18 + vector.X, (float)num19 + vector.Y), color4, 0f, vector, scale, SpriteEffects.None, 0f);
			}
			string text4 = Lang.inter[52];
			color2 = new Color(num, (int)((double)num / 1.1), num / 2, num);
			num16 = num16 + (int)Main.fontMouseText.MeasureString(text).X + 20;
			int num20 = num16 + (int)Main.fontMouseText.MeasureString(text4).X;
			num17 = 130 + num3 * 30;
			scale = 0.9f;
			if (Main.mouseX > num16 && (float)Main.mouseX < (float)num16 + Main.fontMouseText.MeasureString(text4).X && Main.mouseY > num17 && (float)Main.mouseY < (float)num17 + Main.fontMouseText.MeasureString(text4).Y)
			{
				scale = 1.1f;
				if (!Main.npcChatFocus1)
				{
					Main.PlaySound(12, -1, -1, 1);
				}
				Main.npcChatFocus1 = true;
				Main.player[Main.myPlayer].releaseUseItem = false;
				Main.player[Main.myPlayer].controlUseItem = false;
			}
			else
			{
				if (Main.npcChatFocus1)
				{
					Main.PlaySound(12, -1, -1, 1);
				}
				Main.npcChatFocus1 = false;
			}
			for (int n = 0; n < 5; n++)
			{
				int num21 = num16;
				int num22 = num17;
				Color color5 = Color.Black;
				if (n == 0)
				{
					num21 -= 2;
				}
				if (n == 1)
				{
					num21 += 2;
				}
				if (n == 2)
				{
					num22 -= 2;
				}
				if (n == 3)
				{
					num22 += 2;
				}
				if (n == 4)
				{
					color5 = color2;
				}
				Vector2 vector2 = Main.fontMouseText.MeasureString(text4);
				vector2 *= 0.5f;
				this.spriteBatch.DrawString(Main.fontMouseText, text4, new Vector2((float)num21 + vector2.X, (float)num22 + vector2.Y), color5, 0f, vector2, scale, SpriteEffects.None, 0f);
			}
			if (text2 != "")
			{
				num16 = num20 + (int)Main.fontMouseText.MeasureString(text2).X / 3;
				num17 = 130 + num3 * 30;
				scale = 0.9f;
				if (Main.mouseX > num16 && (float)Main.mouseX < (float)num16 + Main.fontMouseText.MeasureString(text2).X && Main.mouseY > num17 && (float)Main.mouseY < (float)num17 + Main.fontMouseText.MeasureString(text2).Y)
				{
					Main.player[Main.myPlayer].mouseInterface = true;
					scale = 1.1f;
					if (!Main.npcChatFocus3)
					{
						Main.PlaySound(12, -1, -1, 1);
					}
					Main.npcChatFocus3 = true;
					Main.player[Main.myPlayer].releaseUseItem = false;
				}
				else
				{
					if (Main.npcChatFocus3)
					{
						Main.PlaySound(12, -1, -1, 1);
					}
					Main.npcChatFocus3 = false;
				}
				for (int num23 = 0; num23 < 5; num23++)
				{
					int num24 = num16;
					int num25 = num17;
					Color color6 = Color.Black;
					if (num23 == 0)
					{
						num24 -= 2;
					}
					if (num23 == 1)
					{
						num24 += 2;
					}
					if (num23 == 2)
					{
						num25 -= 2;
					}
					if (num23 == 3)
					{
						num25 += 2;
					}
					if (num23 == 4)
					{
						color6 = color2;
					}
					Vector2 vector3 = Main.fontMouseText.MeasureString(text);
					vector3 *= 0.5f;
					this.spriteBatch.DrawString(Main.fontMouseText, text2, new Vector2((float)num24 + vector3.X, (float)num25 + vector3.Y), color6, 0f, vector3, scale, SpriteEffects.None, 0f);
				}
			}
			if (Main.mouseLeft && Main.mouseLeftRelease)
			{
				Main.mouseLeftRelease = false;
				Main.player[Main.myPlayer].releaseUseItem = false;
				Main.player[Main.myPlayer].mouseInterface = true;
				if (Main.npcChatFocus1)
				{
					Main.player[Main.myPlayer].talkNPC = -1;
					Main.player[Main.myPlayer].sign = -1;
					Main.editSign = false;
					Main.npcChatText = "";
					Main.PlaySound(11, -1, -1, 1);
					return;
				}
				if (Main.npcChatFocus2)
				{
					if (Main.player[Main.myPlayer].sign != -1)
					{
						if (!Main.editSign)
						{
							Main.PlaySound(12, -1, -1, 1);
							Main.editSign = true;
							Main.clrInput();
							return;
						}
						Main.PlaySound(12, -1, -1, 1);
						int num26 = Main.player[Main.myPlayer].sign;
						Sign.TextSign(num26, Main.npcChatText);
						Main.editSign = false;
						if (Main.netMode == 1)
						{
							NetMessage.SendData(47, -1, -1, "", num26, 0f, 0f, 0f, 0);
							return;
						}
					}
					else
					{
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 17)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 1;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 19)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 2;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 124)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 8;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 142)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 9;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 37)
						{
							if (Main.netMode == 0)
							{
								NPC.SpawnSkeletron();
							}
							else
							{
								NetMessage.SendData(51, -1, -1, "", Main.myPlayer, 1f, 0f, 0f, 0);
							}
							Main.npcChatText = "";
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 20)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 3;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 38)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 4;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 54)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 5;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 107)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 6;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 108)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 7;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 160)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 10;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 178)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 11;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 207)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 12;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 208)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 13;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 209)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 14;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 227)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 15;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 228)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 16;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 229)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 17;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 22)
						{
							Main.PlaySound(12, -1, -1, 1);
							Main.HelpText();
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 18)
						{
							Main.PlaySound(12, -1, -1, 1);
							if (num8 > 0)
							{
								if (Main.player[Main.myPlayer].BuyItem(num8))
								{
									Main.PlaySound(2, -1, -1, 4);
									Main.player[Main.myPlayer].HealEffect(Main.player[Main.myPlayer].statLifeMax - Main.player[Main.myPlayer].statLife, true);
									if ((double)Main.player[Main.myPlayer].statLife < (double)Main.player[Main.myPlayer].statLifeMax * 0.25)
									{
										Main.npcChatText = Lang.dialog(227, false);
									}
									else
									{
										if ((double)Main.player[Main.myPlayer].statLife < (double)Main.player[Main.myPlayer].statLifeMax * 0.5)
										{
											Main.npcChatText = Lang.dialog(228, false);
										}
										else
										{
											if ((double)Main.player[Main.myPlayer].statLife < (double)Main.player[Main.myPlayer].statLifeMax * 0.75)
											{
												Main.npcChatText = Lang.dialog(229, false);
											}
											else
											{
												Main.npcChatText = Lang.dialog(230, false);
											}
										}
									}
									Main.player[Main.myPlayer].statLife = Main.player[Main.myPlayer].statLifeMax;
									for (int num27 = 0; num27 < 10; num27++)
									{
										int num28 = Main.player[Main.myPlayer].buffType[num27];
										if (Main.debuff[num28] && Main.player[Main.myPlayer].buffTime[num27] > 0 && num28 != 28 && num28 != 34)
										{
											Main.player[Main.myPlayer].DelBuff(num27);
										}
									}
									return;
								}
								int num29 = Main.rand.Next(3);
								if (num29 == 0)
								{
									Main.npcChatText = Lang.dialog(52, false);
								}
								if (num29 == 1)
								{
									Main.npcChatText = Lang.dialog(53, false);
								}
								if (num29 == 2)
								{
									Main.npcChatText = Lang.dialog(54, false);
									return;
								}
							}
							else
							{
								int num30 = Main.rand.Next(3);
								if (num30 == 0)
								{
									Main.npcChatText = Lang.dialog(55, false);
								}
								if (num30 == 1)
								{
									Main.npcChatText = Lang.dialog(56, false);
								}
								if (num30 == 2)
								{
									Main.npcChatText = Lang.dialog(57, false);
									return;
								}
							}
						}
					}
				}
				else
				{
					if (Main.npcChatFocus3 && Main.player[Main.myPlayer].talkNPC >= 0)
					{
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 20)
						{
							Main.PlaySound(12, -1, -1, 1);
							Main.npcChatText = Lang.evilGood();
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 22)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.PlaySound(12, -1, -1, 1);
							Main.craftGuide = true;
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 107)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.PlaySound(12, -1, -1, 1);
							Main.reforge = true;
						}
					}
				}
			}*/
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
			for (int i = 0; i < 3; i++)
			{
				if (Main.player[Main.myPlayer].dye[i].type == 0)
				{
					Main.dyeSlotCount = i;
					break;
				}
			}
			if (Main.dyeSlotCount >= 3)
			{
				Main.dyeSlotCount = 0;
			}
			if (Main.dyeSlotCount < 0)
			{
				Main.dyeSlotCount = 2;
			}
			Item result = (Item)Main.player[Main.myPlayer].dye[Main.dyeSlotCount].Clone();
			Main.player[Main.myPlayer].dye[Main.dyeSlotCount] = (Item)newItem.Clone();
			Main.dyeSlotCount++;
			if (Main.dyeSlotCount >= 3)
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
				result = (Item)Main.player[Main.myPlayer].armor[0].Clone();
				Main.player[Main.myPlayer].armor[0] = (Item)newItem.Clone();
			}
			else
			{
				if (newItem.bodySlot != -1)
				{
					result = (Item)Main.player[Main.myPlayer].armor[1].Clone();
					Main.player[Main.myPlayer].armor[1] = (Item)newItem.Clone();
				}
				else
				{
					if (newItem.legSlot != -1)
					{
						result = (Item)Main.player[Main.myPlayer].armor[2].Clone();
						Main.player[Main.myPlayer].armor[2] = (Item)newItem.Clone();
					}
					else
					{
						if (newItem.accessory)
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
							result = (Item)Main.player[Main.myPlayer].armor[3 + Main.accSlotCount].Clone();
							Main.player[Main.myPlayer].armor[3 + Main.accSlotCount] = (Item)newItem.Clone();
							Main.accSlotCount++;
							if (Main.accSlotCount >= 5)
							{
								Main.accSlotCount = 0;
							}
						}
					}
				}
			}
			Main.PlaySound(7, -1, -1, 1);
			Recipe.FindRecipes();
			return result;
		}
		public static void BankCoins()
		{
			for (int i = 0; i < 40; i++)
			{
				if (Main.player[Main.myPlayer].bank[i].type >= 71 && Main.player[Main.myPlayer].bank[i].type <= 73 && Main.player[Main.myPlayer].bank[i].stack == Main.player[Main.myPlayer].bank[i].maxStack)
				{
					Main.player[Main.myPlayer].bank[i].SetDefaults(Main.player[Main.myPlayer].bank[i].type + 1, false);
					for (int j = 0; j < 40; j++)
					{
						if (j != i && Main.player[Main.myPlayer].bank[j].type == Main.player[Main.myPlayer].bank[i].type && Main.player[Main.myPlayer].bank[j].stack < Main.player[Main.myPlayer].bank[j].maxStack)
						{
							Main.player[Main.myPlayer].bank[j].stack++;
							Main.player[Main.myPlayer].bank[i].SetDefaults(0, false);
							Main.BankCoins();
						}
					}
				}
			}
		}
		public static void ChestCoins()
		{
			for (int i = 0; i < 40; i++)
			{
				if (Main.chest[Main.player[Main.myPlayer].chest].item[i].type >= 71 && Main.chest[Main.player[Main.myPlayer].chest].item[i].type <= 73 && Main.chest[Main.player[Main.myPlayer].chest].item[i].stack == Main.chest[Main.player[Main.myPlayer].chest].item[i].maxStack)
				{
					Main.chest[Main.player[Main.myPlayer].chest].item[i].SetDefaults(Main.chest[Main.player[Main.myPlayer].chest].item[i].type + 1, false);
					for (int j = 0; j < 40; j++)
					{
						if (j != i && Main.chest[Main.player[Main.myPlayer].chest].item[j].type == Main.chest[Main.player[Main.myPlayer].chest].item[i].type && Main.chest[Main.player[Main.myPlayer].chest].item[j].stack < Main.chest[Main.player[Main.myPlayer].chest].item[j].maxStack)
						{
							if (Main.netMode == 1)
							{
								NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)j, 0f, 0f, 0);
							}
							Main.chest[Main.player[Main.myPlayer].chest].item[j].stack++;
							Main.chest[Main.player[Main.myPlayer].chest].item[i].SetDefaults(0, false);
							Main.ChestCoins();
						}
					}
				}
			}
		}
		protected void QuitGame()
		{
			//base.Exit();
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
		
		protected bool FullTile(int x, int y)
		{
			if (Main.tile[x - 1, y].halfBrick() || Main.tile[x - 1, y].slope() != 0)
			{
				return false;
			}
			if (Main.tile[x + 1, y].halfBrick() || Main.tile[x + 1, y].slope() != 0)
			{
				return false;
			}
			if (Main.tile[x, y].active() && Main.tileSolid[(int)Main.tile[x, y].type] && !Main.tileSolidTop[(int)Main.tile[x, y].type] && Main.tile[x, y].type != 10 && Main.tile[x, y].type != 54 && Main.tile[x, y].type != 138 && Main.tile[x, y].type != 191)
			{
				int frameX = (int)Main.tile[x, y].frameX;
				int frameY = (int)Main.tile[x, y].frameY;
				if (frameY == 18)
				{
					if (frameX >= 18 && frameX <= 54)
					{
						return true;
					}
					if (frameX >= 108 && frameX <= 144)
					{
						return true;
					}
				}
				else
				{
					if (frameY >= 90 && frameY <= 196)
					{
						if (frameX <= 70)
						{
							return true;
						}
						if (frameX >= 144 && frameX <= 232)
						{
							return true;
						}
					}
				}
			}
			return false;
		}
		
		
		
		public static void FindWaterfalls()
		{
			Main.waterfallDist = (int)(75f * Main.gfxQuality) + 25;
			Main.wfTileMax = (int)(175f * Main.gfxQuality) + 25;
			int num = 160;
			Main.wfTileNum = 0;
			int num2 = (int)(Main.screenPosition.X / 16f - 1f);
			int num3 = (int)((Main.screenPosition.X + (float)Main.screenWidth) / 16f) + 2;
			int num4 = (int)(Main.screenPosition.Y / 16f - 1f);
			int num5 = (int)((Main.screenPosition.Y + (float)Main.screenHeight) / 16f) + 2;
			num2 -= Main.waterfallDist;
			num3 += Main.waterfallDist;
			num4 -= Main.waterfallDist;
			num5 += 20;
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num3 > Main.maxTilesX)
			{
				num3 = Main.maxTilesX;
			}
			if (num4 < 0)
			{
				num4 = 0;
			}
			if (num5 > Main.maxTilesY)
			{
				num5 = Main.maxTilesY;
			}
			for (int i = num2; i < num3; i++)
			{
				for (int j = num4; j < num5; j++)
				{
					if (Main.tile[i, j] == null)
					{
						Main.tile[i, j] = new Tile();
					}
					if (Main.tile[i, j].active())
					{
						if (Main.tile[i, j].halfBrick() && (Main.tile[i, j - 1].liquid < 16 || WorldGen.SolidTile(i, j - 1)))
						{
							if (Main.tile[i - 1, j] == null)
							{
								return;
							}
							if (Main.tile[i + 1, j] == null)
							{
								return;
							}
							if (((int)Main.tile[i - 1, j].liquid > num || (int)Main.tile[i + 1, j].liquid > num) && ((Main.tile[i - 1, j].liquid == 0 && !WorldGen.SolidTile(i - 1, j) && Main.tile[i - 1, j].slope() == 0) || (Main.tile[i + 1, j].liquid == 0 && !WorldGen.SolidTile(i + 1, j) && Main.tile[i + 1, j].slope() == 0)) && Main.wfTileNum < Main.wfTileMax)
							{
								Main.wfTileType[Main.wfTileNum] = 0;
								if (Main.tile[i, j - 1].lava())
								{
									Main.wfTileType[Main.wfTileNum] = 1;
								}
								if (Main.tile[i + 1, j].lava())
								{
									Main.wfTileType[Main.wfTileNum] = 1;
								}
								if (Main.tile[i - 1, j].lava())
								{
									Main.wfTileType[Main.wfTileNum] = 1;
								}
								if (Main.tile[i, j - 1].honey())
								{
									Main.wfTileType[Main.wfTileNum] = 14;
								}
								if (Main.tile[i + 1, j].honey())
								{
									Main.wfTileType[Main.wfTileNum] = 14;
								}
								if (Main.tile[i - 1, j].honey())
								{
									Main.wfTileType[Main.wfTileNum] = 14;
								}
								Main.wfTileX[Main.wfTileNum] = i;
								Main.wfTileY[Main.wfTileNum] = j;
								Main.wfTileNum++;
							}
						}
						if (Main.tile[i, j].type == 196 && !WorldGen.SolidTile(i, j + 1) && Main.wfTileNum < Main.wfTileMax)
						{
							Main.wfTileType[Main.wfTileNum] = 11;
							Main.wfTileX[Main.wfTileNum] = i;
							Main.wfTileY[Main.wfTileNum] = j + 1;
							Main.wfTileNum++;
						}
					}
				}
			}
		}
		
		public static int GetTreeStyle(int X)
		{
			int num;
			if (X <= Main.treeX[0])
			{
				num = Main.treeStyle[0];
			}
			else
			{
				if (X <= Main.treeX[1])
				{
					num = Main.treeStyle[1];
				}
				else
				{
					if (X <= Main.treeX[2])
					{
						num = Main.treeStyle[2];
					}
					else
					{
						num = Main.treeStyle[3];
					}
				}
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
		protected void lookForColorTiles()
		{
			int num = (int)(Main.screenPosition.X / 16f - 2f);
			int num2 = (int)((Main.screenPosition.X + (float)Main.screenWidth) / 16f) + 3;
			int num3 = (int)(Main.screenPosition.Y / 16f - 2f);
			int num4 = (int)((Main.screenPosition.Y + (float)Main.screenHeight) / 16f) + 3;
			if (num < 1)
			{
				num = 1;
			}
			if (num2 > Main.maxTilesX - 2)
			{
				num = Main.maxTilesX - 2;
			}
			for (int i = num; i < num2; i++)
			{
				if (i > 0)
				{
					for (int j = num3; j < num4; j++)
					{
						if (Main.tile[i, j] != null)
						{
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
		protected void tileColorCheck(int t, int c)
		{/*
			this.LoadTiles(t);
			if (c >= Main.numTileColors)
			{
				return;
			}
			if (!Main.tileAltTextureInit[t, c])
			{
				Main.tileAltTexture[t, c] = new RenderTarget2D(base.GraphicsDevice, Main.tileTexture[t].Width, Main.tileTexture[t].Height, false, base.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24, 0, RenderTargetUsage.PreserveContents);
				Main.tileAltTextureInit[t, c] = true;
			}
			if (Main.tileAltTexture[t, c].IsContentLost)
			{
				Main.tileAltTextureDrawn[t, c] = false;
			}
			if (!Main.tileAltTextureDrawn[t, c])
			{
				base.GraphicsDevice.SetRenderTarget(Main.tileAltTexture[t, c]);
				base.GraphicsDevice.Clear(new Color(0, 0, 0, 0));
				this.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
				if (c > 0 && c < 13 && (t == 0 || t == 2 || t == 5 || t == 23 || t == 59 || t == 60 || t == 70 || t == 109 || t == 199))
				{
					int index = c + 27;
					Main.tileShader.CurrentTechnique.Passes[index].Apply();
				}
				else
				{
					Main.tileShader.CurrentTechnique.Passes[c].Apply();
				}
				this.spriteBatch.Draw(Main.tileTexture[t], new Rectangle(0, 0, Main.tileTexture[t].Width, Main.tileTexture[t].Height), Color.White);
				this.spriteBatch.End();
				base.GraphicsDevice.SetRenderTarget(null);
				Main.tileAltTextureDrawn[t, c] = true;
			}*/
		}
		protected void treeColorCheck(int t, int c)
		{/*
			if (!Main.treeAltTextureInit[t, c])
			{
				Main.treeTopAltTexture[t, c] = new RenderTarget2D(base.GraphicsDevice, Main.treeTopTexture[t].Width, Main.treeTopTexture[t].Height, false, base.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24, 0, RenderTargetUsage.PreserveContents);
				Main.treeBranchAltTexture[t, c] = new RenderTarget2D(base.GraphicsDevice, Main.treeBranchTexture[t].Width, Main.treeBranchTexture[t].Height, false, base.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24, 0, RenderTargetUsage.PreserveContents);
				Main.treeAltTextureInit[t, c] = true;
			}
			if (Main.treeTopAltTexture[t, c].IsContentLost || Main.treeBranchAltTexture[t, c].IsContentLost)
			{
				Main.treeAltTextureDrawn[t, c] = false;
			}
			if (!Main.treeAltTextureDrawn[t, c])
			{
				base.GraphicsDevice.SetRenderTarget(Main.treeTopAltTexture[t, c]);
				base.GraphicsDevice.Clear(new Color(0, 0, 0, 0));
				this.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
				if (c > 0 && c < 13)
				{
					int index = c + 27;
					Main.tileShader.CurrentTechnique.Passes[index].Apply();
				}
				else
				{
					Main.tileShader.CurrentTechnique.Passes[c].Apply();
				}
				this.spriteBatch.Draw(Main.treeTopTexture[t], new Rectangle(0, 0, Main.treeTopTexture[t].Width, Main.treeTopTexture[t].Height), Color.White);
				this.spriteBatch.End();
				base.GraphicsDevice.SetRenderTarget(null);
				base.GraphicsDevice.SetRenderTarget(Main.treeBranchAltTexture[t, c]);
				base.GraphicsDevice.Clear(new Color(0, 0, 0, 0));
				this.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
				if (c > 0 && c < 13)
				{
					int index2 = c + 27;
					Main.tileShader.CurrentTechnique.Passes[index2].Apply();
				}
				else
				{
					Main.tileShader.CurrentTechnique.Passes[c].Apply();
				}
				this.spriteBatch.Draw(Main.treeBranchTexture[t], new Rectangle(0, 0, Main.treeBranchTexture[t].Width, Main.treeBranchTexture[t].Height), Color.White);
				this.spriteBatch.End();
				base.GraphicsDevice.SetRenderTarget(null);
				Main.treeAltTextureDrawn[t, c] = true;
			}*/
		}
		protected void wallColorCheck(int t, int c)
		{/*
			this.LoadWall(t);
			if (!Main.wallAltTextureInit[t, c])
			{
				Main.wallAltTexture[t, c] = new RenderTarget2D(base.GraphicsDevice, Main.wallTexture[t].Width, Main.wallTexture[t].Height, false, base.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24, 0, RenderTargetUsage.PreserveContents);
				Main.wallAltTextureInit[t, c] = true;
			}
			if (Main.wallAltTexture[t, c].IsContentLost)
			{
				Main.wallAltTextureDrawn[t, c] = false;
			}
			if (!Main.wallAltTextureDrawn[t, c])
			{
				base.GraphicsDevice.SetRenderTarget(Main.wallAltTexture[t, c]);
				base.GraphicsDevice.Clear(new Color(0, 0, 0, 0));
				this.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
				Main.tileShader.CurrentTechnique.Passes[c].Apply();
				this.spriteBatch.Draw(Main.wallTexture[t], new Rectangle(0, 0, Main.wallTexture[t].Width, Main.wallTexture[t].Height), Color.White);
				this.spriteBatch.End();
				base.GraphicsDevice.SetRenderTarget(null);
				Main.wallAltTextureDrawn[t, c] = true;
			}*/
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
			else
			{
				if (Main.windSpeed > Main.windSpeedSet)
				{
					Main.windSpeed -= 0.001f * (float)Main.dayRate;
					if (Main.windSpeed < Main.windSpeedSet)
					{
						Main.windSpeed = Main.windSpeedSet;
					}
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
		protected void LoadBackground(int i)
		{
			/*if (i >= 0 && !Main.backgroundLoaded[i])
			{
				Main.backgroundTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Background_",
					i
				}));
				Main.backgroundWidth[i] = Main.backgroundTexture[i].Width;
				Main.backgroundHeight[i] = Main.backgroundTexture[i].Height;
				Main.backgroundLoaded[i] = true;
			}*/
		}
		
		protected void LoadNPC(int i)
		{
			/*if (!Main.NPCLoaded[i] || Main.npcTexture[i] == null)
			{
				Main.npcTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"NPC_",
					i
				}));
				Main.NPCLoaded[i] = true;
			}*/
		}
		protected void LoadProjectile(int i)
		{
			/*if (!Main.projectileLoaded[i])
			{
				Main.projectileTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Projectile_",
					i
				}));
				Main.projectileLoaded[i] = true;
			}*/
		}
		protected void LoadGore(int i)
		{
			/*if (!Main.goreLoaded[i])
			{
				Main.goreTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Gore_",
					i
				}));
				Main.goreLoaded[i] = true;
			}*/
		}
		protected void LoadWall(int i)
		{
			/*if (!Main.wallLoaded[i])
			{
				Main.wallTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Wall_",
					i
				}));
				Main.wallLoaded[i] = true;
			}*/
		}
		protected void LoadTiles(int i)
		{
			/*if (!Main.tileSetsLoaded[i])
			{
				Main.tileTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Tiles_",
					i
				}));
				Main.tileSetsLoaded[i] = true;
			}*/
		}
		protected void LoadItemFlames(int i)
		{
			/*if (!Main.itemFlameLoaded[i])
			{
				try
				{
					Main.itemFlameTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
					{
						"Images",
						Path.DirectorySeparatorChar,
						"ItemFlame_",
						i
					}));
				}
				catch
				{
				}
				Main.itemFlameLoaded[i] = true;
			}*/
		}
		protected void LoadWings(int i)
		{
			/*if (!Main.wingsLoaded[i])
			{
				Main.wingsTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Wings_",
					i
				}));
				Main.wingsLoaded[i] = true;
			}*/
		}
		protected void LoadHair(int i)
		{
			/*if (!Main.hairLoaded[i])
			{
				Main.playerHairTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Player_Hair_",
					i + 1
				}));
				Main.playerHairAltTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Player_HairAlt_",
					i + 1
				}));
				Main.hairLoaded[i] = true;
			}*/
		}
		protected void LoadArmorHead(int i)
		{
			/*if (!Main.armorHeadLoaded[i])
			{
				Main.armorHeadTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Armor_Head_",
					i
				}));
				Main.armorHeadLoaded[i] = true;
			}*/
		}
		protected void LoadArmorBody(int i)
		{
			/*if (!Main.armorBodyLoaded[i])
			{
				Main.femaleBodyTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Female_Body_",
					i
				}));
				Main.armorBodyTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Armor_Body_",
					i
				}));
				Main.armorArmTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Armor_Arm_",
					i
				}));
				Main.armorBodyLoaded[i] = true;
			}*/
		}
		protected void LoadArmorLegs(int i)
		{
			/*if (!Main.armorLegsLoaded[i])
			{
				Main.armorLegTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Armor_Legs_",
					i
				}));
				Main.armorLegsLoaded[i] = true;
			}*/
		}
		protected void DrawSurfaceBG()
		{/*
			if (!Main.mapFullscreen && (double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
			{
				for (int i = 0; i < 200; i++)
				{
					if (Main.cloud[i].active && Main.cloud[i].scale < 1f)
					{
						Color color = Main.cloud[i].cloudColor(Main.bgColor);
						float num = Main.cloud[i].scale * 0.8f;
						float num2 = (Main.cloud[i].scale + 1f) / 2f * 0.9f;
						color.R = (byte)((float)color.R * num);
						color.G = (byte)((float)color.G * num2);
						Main.atmo = 1f;
						if (Main.atmo < 1f)
						{
							color.R = (byte)((float)color.R * Main.atmo);
							color.G = (byte)((float)color.G * Main.atmo);
							color.B = (byte)((float)color.B * Main.atmo);
							color.A = (byte)((float)color.A * Main.atmo);
						}
						float num3 = Main.cloud[i].position.Y * ((float)Main.screenHeight / 600f);
						num3 = Main.cloud[i].position.Y + (float)((int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 750.0 + 830.0)) + (float)((int)this.scAdj);
						this.spriteBatch.Draw(Main.cloudTexture[Main.cloud[i].type], new Vector2(Main.cloud[i].position.X + (float)Main.cloudTexture[Main.cloud[i].type].Width * 0.5f, num3 + (float)Main.cloudTexture[Main.cloud[i].type].Height * 0.5f), new Rectangle?(new Rectangle(0, 0, Main.cloudTexture[Main.cloud[i].type].Width, Main.cloudTexture[Main.cloud[i].type].Height)), color, Main.cloud[i].rotation, new Vector2((float)Main.cloudTexture[Main.cloud[i].type].Width * 0.5f, (float)Main.cloudTexture[Main.cloud[i].type].Height * 0.5f), Main.cloud[i].scale, Main.cloud[i].spriteDir, 0f);
					}
				}
			}
			Main.atmo = 1f;
			Main.bgScale *= 2f;
			this.bgParrallax = 0.15;
			if (Main.atmo < 1f)
			{
				Main.backColor.R = (byte)((float)Main.backColor.R * Main.atmo);
				Main.backColor.G = (byte)((float)Main.backColor.G * Main.atmo);
				Main.backColor.B = (byte)((float)Main.backColor.B * Main.atmo);
				Main.backColor.A = (byte)((float)Main.backColor.A * Main.atmo);
			}
			if (!Main.mapFullscreen && (double)(Main.screenPosition.Y / 16f) <= Main.worldSurface + 10.0)
			{
				if (Main.owBack)
				{
					if (Main.cloudBGActive > 0f)
					{
						Main.cloudBGAlpha += 0.0005f * (float)Main.dayRate;
						if (Main.cloudBGAlpha > 1f)
						{
							Main.cloudBGAlpha = 1f;
						}
					}
					else
					{
						Main.cloudBGAlpha -= 0.0005f * (float)Main.dayRate;
						if (Main.cloudBGAlpha < 0f)
						{
							Main.cloudBGAlpha = 0f;
						}
					}
					if (Main.cloudBGAlpha > 0f)
					{
						this.LoadBackground(Main.cloudBG[0]);
						this.LoadBackground(Main.cloudBG[1]);
						Main.bgScale *= 2f;
						this.bgParrallax = 0.15;
						float num4 = Main.cloudBGAlpha;
						if (num4 > 1f)
						{
							num4 = 1f;
						}
						Main.bgScale = 1.65f;
						this.bgParrallax = 0.090000003576278687;
						if (base.IsActive)
						{
							Main.cloudBGX[0] += Main.windSpeed * (float)this.bgParrallax * 5f * (float)Main.dayRate;
						}
						if (Main.cloudBGX[0] > (float)Main.backgroundWidth[Main.cloudBG[0]] * Main.bgScale)
						{
							Main.cloudBGX[0] -= (float)Main.backgroundWidth[Main.cloudBG[0]] * Main.bgScale;
						}
						if (Main.cloudBGX[0] < (float)(-(float)Main.backgroundWidth[Main.cloudBG[0]]) * Main.bgScale)
						{
							Main.cloudBGX[0] += (float)Main.backgroundWidth[Main.cloudBG[0]] * Main.bgScale;
						}
						Main.bgW = (int)((float)Main.backgroundWidth[Main.cloudBG[0]] * Main.bgScale);
						this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 900.0 + 600.0) + (int)this.scAdj;
						if (Main.gameMenu)
						{
							this.bgTop = -150;
						}
						this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2) - (double)Main.bgW);
						this.bgStart += (int)Main.cloudBGX[0];
						this.bgLoops = Main.screenWidth / Main.bgW + 2 + 2;
						Main.backColor = Main.trueBackColor;
						Main.backColor.R = (byte)((float)Main.backColor.R * num4);
						Main.backColor.G = (byte)((float)Main.backColor.G * num4);
						Main.backColor.B = (byte)((float)Main.backColor.B * num4);
						Main.backColor.A = (byte)((float)Main.backColor.A * num4);
						for (int j = 0; j < this.bgLoops; j++)
						{
							this.spriteBatch.Draw(Main.backgroundTexture[Main.cloudBG[0]], new Vector2((float)(this.bgStart + Main.bgW * j), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.cloudBG[0]], Main.backgroundHeight[Main.cloudBG[0]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
						}
						num4 = Main.cloudBGAlpha * 1.5f;
						if (num4 > 1f)
						{
							num4 = 1f;
						}
						Main.backColor = Main.trueBackColor;
						Main.backColor.R = (byte)((float)Main.backColor.R * num4);
						Main.backColor.G = (byte)((float)Main.backColor.G * num4);
						Main.backColor.B = (byte)((float)Main.backColor.B * num4);
						Main.backColor.A = (byte)((float)Main.backColor.A * num4);
						Main.bgScale = 1.85f;
						this.bgParrallax = 0.12;
						if (base.IsActive)
						{
							Main.cloudBGX[1] += Main.windSpeed * (float)this.bgParrallax * 5f * (float)Main.dayRate;
						}
						if (Main.cloudBGX[1] > (float)Main.backgroundWidth[Main.cloudBG[1]] * Main.bgScale)
						{
							Main.cloudBGX[1] -= (float)Main.backgroundWidth[Main.cloudBG[1]] * Main.bgScale;
						}
						if (Main.cloudBGX[1] < (float)(-(float)Main.backgroundWidth[Main.cloudBG[1]]) * Main.bgScale)
						{
							Main.cloudBGX[1] += (float)Main.backgroundWidth[Main.cloudBG[1]] * Main.bgScale;
						}
						Main.bgW = (int)((float)Main.backgroundWidth[Main.cloudBG[1]] * Main.bgScale);
						this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1100.0 + 750.0) + (int)this.scAdj;
						if (Main.gameMenu)
						{
							this.bgTop = -50;
						}
						this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2) - (double)Main.bgW);
						this.bgStart += (int)Main.cloudBGX[1];
						this.bgLoops = Main.screenWidth / Main.bgW + 2 + 2;
						for (int k = 0; k < this.bgLoops; k++)
						{
							this.spriteBatch.Draw(Main.backgroundTexture[Main.cloudBG[1]], new Vector2((float)(this.bgStart + Main.bgW * k), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.cloudBG[1]], Main.backgroundHeight[Main.cloudBG[1]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
						}
					}
					this.LoadBackground(Main.treeMntBG[0]);
					this.LoadBackground(Main.treeMntBG[1]);
					Main.bgScale = 1f;
					this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1300.0 + 1090.0) + (int)this.scAdj;
					Main.bgScale *= 2f;
					this.bgParrallax = 0.15;
					Main.bgW = (int)((float)Main.backgroundWidth[Main.treeMntBG[0]] * Main.bgScale);
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
					this.bgLoops = Main.screenWidth / Main.bgW + 2;
					if (Main.gameMenu)
					{
						this.bgTop = 100;
					}
					if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
					{
						Main.backColor = Main.trueBackColor;
						Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha2[0]);
						Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha2[0]);
						Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha2[0]);
						Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha2[0]);
						if (Main.bgAlpha2[0] > 0f)
						{
							if (Main.treeMntBG[0] == 93 || (Main.treeMntBG[0] >= 168 && Main.treeMntBG[0] <= 170))
							{
								this.bgTop -= 50;
							}
							if (Main.treeMntBG[0] == 171)
							{
								this.bgTop -= 100;
							}
							if (Main.treeMntBG[0] == 176)
							{
								this.bgTop += 250;
							}
							if (Main.treeMntBG[0] == 179)
							{
								this.bgTop -= 100;
							}
							for (int l = 0; l < this.bgLoops; l++)
							{
								this.spriteBatch.Draw(Main.backgroundTexture[Main.treeMntBG[0]], new Vector2((float)(this.bgStart + Main.bgW * l), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.treeMntBG[0]], Main.backgroundHeight[Main.treeMntBG[0]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
							}
							if (Main.treeMntBG[0] == 93 || (Main.treeMntBG[0] >= 168 && Main.treeMntBG[0] <= 170))
							{
								this.bgTop += 50;
							}
							if (Main.treeMntBG[0] == 171)
							{
								this.bgTop += 100;
							}
							if (Main.treeMntBG[0] == 176)
							{
								this.bgTop -= 250;
							}
							if (Main.treeMntBG[0] == 179)
							{
								this.bgTop += 100;
							}
						}
						Main.backColor = Main.trueBackColor;
						Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha2[1]);
						Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha2[1]);
						Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha2[1]);
						Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha2[1]);
						if (Main.bgAlpha2[1] > 0f)
						{
							this.LoadBackground(23);
							for (int m = 0; m < this.bgLoops; m++)
							{
								this.spriteBatch.Draw(Main.backgroundTexture[23], new Vector2((float)(this.bgStart + Main.bgW * m), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[23], Main.backgroundHeight[23])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
							}
						}
						Main.backColor = Main.trueBackColor;
						Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha2[2]);
						Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha2[2]);
						Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha2[2]);
						Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha2[2]);
						if (Main.bgAlpha2[2] > 0f)
						{
							this.LoadBackground(24);
							for (int n = 0; n < this.bgLoops; n++)
							{
								this.spriteBatch.Draw(Main.backgroundTexture[24], new Vector2((float)(this.bgStart + Main.bgW * n), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[24], Main.backgroundHeight[24])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
							}
						}
						Main.backColor = Main.trueBackColor;
						Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha2[4]);
						Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha2[4]);
						Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha2[4]);
						Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha2[4]);
						if (Main.bgAlpha2[4] > 0f)
						{
							this.LoadBackground(Main.snowMntBG[0]);
							for (int num5 = 0; num5 < this.bgLoops; num5++)
							{
								this.spriteBatch.Draw(Main.backgroundTexture[Main.snowMntBG[0]], new Vector2((float)(this.bgStart + Main.bgW * num5), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.snowMntBG[0]], Main.backgroundHeight[Main.snowMntBG[0]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
							}
						}
						Main.backColor = Main.trueBackColor;
						Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha2[5]);
						Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha2[5]);
						Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha2[5]);
						Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha2[5]);
						if (Main.bgAlpha2[5] > 0f)
						{
							this.LoadBackground(24);
							for (int num6 = 0; num6 < this.bgLoops; num6++)
							{
								this.spriteBatch.Draw(Main.backgroundTexture[24], new Vector2((float)(this.bgStart + Main.bgW * num6), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[24], Main.backgroundHeight[24])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
							}
						}
					}
				}
				this.cTop = (float)(this.bgTop - 50);
				if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
				{
					for (int num7 = 0; num7 < 200; num7++)
					{
						if (Main.cloud[num7].active && (double)Main.cloud[num7].scale < 1.15 && Main.cloud[num7].scale >= 1f)
						{
							Color color2 = Main.cloud[num7].cloudColor(Main.bgColor);
							if (Main.atmo < 1f)
							{
								color2.R = (byte)((float)color2.R * Main.atmo);
								color2.G = (byte)((float)color2.G * Main.atmo);
								color2.B = (byte)((float)color2.B * Main.atmo);
								color2.A = (byte)((float)color2.A * Main.atmo);
							}
							float num8 = Main.cloud[num7].position.Y * ((float)Main.screenHeight / 600f);
							float num9 = (float)((double)(Main.screenPosition.Y / 16f - 24f) / Main.worldSurface);
							if (num9 < 0f)
							{
								num9 = 0f;
							}
							if (num9 <= 1f)
							{
								goto IL_134F;
							}
							IL_134F:
							if (!Main.gameMenu)
							{
								goto IL_135D;
							}
							IL_135D:
							this.spriteBatch.Draw(Main.cloudTexture[Main.cloud[num7].type], new Vector2(Main.cloud[num7].position.X + (float)Main.cloudTexture[Main.cloud[num7].type].Width * 0.5f, num8 + (float)Main.cloudTexture[Main.cloud[num7].type].Height * 0.5f + this.cTop + 200f), new Rectangle?(new Rectangle(0, 0, Main.cloudTexture[Main.cloud[num7].type].Width, Main.cloudTexture[Main.cloud[num7].type].Height)), color2, Main.cloud[num7].rotation, new Vector2((float)Main.cloudTexture[Main.cloud[num7].type].Width * 0.5f, (float)Main.cloudTexture[Main.cloud[num7].type].Height * 0.5f), Main.cloud[num7].scale, Main.cloud[num7].spriteDir, 0f);
						}
					}
				}
				if (Main.holyTiles > 0 && Main.owBack)
				{
					this.bgParrallax = 0.17;
					Main.bgScale = 1.1f;
					Main.bgScale *= 2f;
					Main.bgW = (int)((double)(3500f * Main.bgScale) * 1.05);
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
					this.bgLoops = Main.screenWidth / Main.bgW + 2;
					this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1400.0 + 900.0) + (int)this.scAdj;
					if (Main.gameMenu)
					{
						this.bgTop = 230;
						this.bgStart -= 500;
					}
					Color color3 = Main.trueBackColor;
					float num10 = (float)Main.holyTiles / 400f;
					if (num10 > 0.5f)
					{
						num10 = 0.5f;
					}
					color3.R = (byte)((float)color3.R * num10);
					color3.G = (byte)((float)color3.G * num10);
					color3.B = (byte)((float)color3.B * num10);
					color3.A = (byte)((float)color3.A * num10 * 0.8f);
					if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
					{
						this.LoadBackground(18);
						this.LoadBackground(19);
						for (int num11 = 0; num11 < this.bgLoops; num11++)
						{
							this.spriteBatch.Draw(Main.backgroundTexture[18], new Vector2((float)(this.bgStart + Main.bgW * num11), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[18], Main.backgroundHeight[18])), color3, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
							this.spriteBatch.Draw(Main.backgroundTexture[19], new Vector2((float)(this.bgStart + Main.bgW * num11 + 1700), (float)(this.bgTop + 100)), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[19], Main.backgroundHeight[19])), color3, 0f, default(Vector2), Main.bgScale * 0.9f, SpriteEffects.None, 0f);
						}
					}
				}
				if (Main.treeMntBG[1] > -1)
				{
					this.LoadBackground(Main.treeMntBG[1]);
					this.bgParrallax = 0.2;
					Main.bgScale = 1.15f;
					Main.bgScale *= 2f;
					Main.bgW = (int)((float)Main.backgroundWidth[Main.treeMntBG[1]] * Main.bgScale);
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
					this.bgLoops = Main.screenWidth / Main.bgW + 2;
					this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1400.0 + 1260.0) + (int)this.scAdj;
				}
				if (Main.owBack)
				{
					if (Main.gameMenu)
					{
						this.bgTop = 230;
						this.bgStart -= 500;
					}
					if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
					{
						Main.backColor = Main.trueBackColor;
						Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha2[0]);
						Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha2[0]);
						Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha2[0]);
						Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha2[0]);
						if (Main.bgAlpha2[0] > 0f && Main.treeMntBG[1] > -1)
						{
							if (Main.treeMntBG[1] == 172)
							{
								this.bgTop += 130;
							}
							if (Main.treeMntBG[1] == 177)
							{
								this.bgTop += 200;
							}
							if (Main.treeMntBG[1] >= 180 && Main.treeMntBG[1] <= 183)
							{
								this.bgTop -= 350;
							}
							for (int num12 = 0; num12 < this.bgLoops; num12++)
							{
								this.spriteBatch.Draw(Main.backgroundTexture[Main.treeMntBG[1]], new Vector2((float)(this.bgStart + Main.bgW * num12), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.treeMntBG[1]], Main.backgroundHeight[Main.treeMntBG[1]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
							}
							if (Main.treeMntBG[1] == 172)
							{
								this.bgTop -= 130;
							}
							if (Main.treeMntBG[1] == 177)
							{
								this.bgTop -= 200;
							}
							if (Main.treeMntBG[1] >= 180 && Main.treeMntBG[1] <= 183)
							{
								this.bgTop += 350;
							}
						}
						Main.backColor = Main.trueBackColor;
						Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha2[1]);
						Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha2[1]);
						Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha2[1]);
						Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha2[1]);
						if (Main.bgAlpha2[1] > 0f)
						{
							this.LoadBackground(22);
							for (int num13 = 0; num13 < this.bgLoops; num13++)
							{
								this.spriteBatch.Draw(Main.backgroundTexture[22], new Vector2((float)(this.bgStart + Main.bgW * num13), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[22], Main.backgroundHeight[22])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
							}
						}
						Main.backColor = Main.trueBackColor;
						Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha2[2]);
						Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha2[2]);
						Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha2[2]);
						Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha2[2]);
						if (Main.bgAlpha2[2] > 0f)
						{
							this.LoadBackground(25);
							for (int num14 = 0; num14 < this.bgLoops; num14++)
							{
								this.spriteBatch.Draw(Main.backgroundTexture[25], new Vector2((float)(this.bgStart + Main.bgW * num14), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[25], Main.backgroundHeight[25])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
							}
						}
						Main.backColor = Main.trueBackColor;
						Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha2[3]);
						Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha2[3]);
						Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha2[3]);
						Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha2[3]);
						if (Main.bgAlpha2[3] > 0f)
						{
							this.LoadBackground(Main.oceanBG);
							for (int num15 = 0; num15 < this.bgLoops; num15++)
							{
								this.spriteBatch.Draw(Main.backgroundTexture[Main.oceanBG], new Vector2((float)(this.bgStart + Main.bgW * num15), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.oceanBG], Main.backgroundHeight[Main.oceanBG])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
							}
						}
						Main.backColor = Main.trueBackColor;
						Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha2[4]);
						Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha2[4]);
						Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha2[4]);
						Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha2[4]);
						if (Main.bgAlpha2[4] > 0f)
						{
							this.LoadBackground(Main.snowMntBG[1]);
							for (int num16 = 0; num16 < this.bgLoops; num16++)
							{
								this.spriteBatch.Draw(Main.backgroundTexture[Main.snowMntBG[1]], new Vector2((float)(this.bgStart + Main.bgW * num16), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.snowMntBG[1]], Main.backgroundHeight[Main.snowMntBG[1]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
							}
						}
						Main.backColor = Main.trueBackColor;
						Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha2[5]);
						Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha2[5]);
						Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha2[5]);
						Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha2[5]);
						if (Main.bgAlpha2[5] > 0f)
						{
							this.LoadBackground(42);
							for (int num17 = 0; num17 < this.bgLoops; num17++)
							{
								this.spriteBatch.Draw(Main.backgroundTexture[42], new Vector2((float)(this.bgStart + Main.bgW * num17), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[42], Main.backgroundHeight[42])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
							}
						}
					}
				}
				this.cTop = (float)this.bgTop * 1.01f - 150f;
				if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
				{
					for (int num18 = 0; num18 < 200; num18++)
					{
						if (Main.cloud[num18].active && Main.cloud[num18].scale >= 1.15f)
						{
							Color color4 = Main.cloud[num18].cloudColor(Main.bgColor);
							if (Main.atmo < 1f)
							{
								color4.R = (byte)((float)color4.R * Main.atmo);
								color4.G = (byte)((float)color4.G * Main.atmo);
								color4.B = (byte)((float)color4.B * Main.atmo);
								color4.A = (byte)((float)color4.A * Main.atmo);
							}
							float num19 = Main.cloud[num18].position.Y * ((float)Main.screenHeight / 600f) - 100f;
							float num20 = (float)((double)(Main.screenPosition.Y / 16f - 24f) / Main.worldSurface);
							if (num20 < 0f)
							{
								num20 = 0f;
							}
							if (num20 <= 1f)
							{
								goto IL_219B;
							}
							IL_219B:
							if (!Main.gameMenu)
							{
								goto IL_21A9;
							}
							IL_21A9:
							this.spriteBatch.Draw(Main.cloudTexture[Main.cloud[num18].type], new Vector2(Main.cloud[num18].position.X + (float)Main.cloudTexture[Main.cloud[num18].type].Width * 0.5f, num19 + (float)Main.cloudTexture[Main.cloud[num18].type].Height * 0.5f + this.cTop), new Rectangle?(new Rectangle(0, 0, Main.cloudTexture[Main.cloud[num18].type].Width, Main.cloudTexture[Main.cloud[num18].type].Height)), color4, Main.cloud[num18].rotation, new Vector2((float)Main.cloudTexture[Main.cloud[num18].type].Width * 0.5f, (float)Main.cloudTexture[Main.cloud[num18].type].Height * 0.5f), Main.cloud[num18].scale, Main.cloud[num18].spriteDir, 0f);
						}
					}
				}
			}
			if (!Main.mapFullscreen)
			{
				for (int num21 = 0; num21 < 10; num21++)
				{
					if (Main.bgStyle == num21)
					{
						Main.bgAlpha[num21] += Main.tranSpeed;
						if (Main.bgAlpha[num21] > 1f)
						{
							Main.bgAlpha[num21] = 1f;
						}
					}
					else
					{
						Main.bgAlpha[num21] -= Main.tranSpeed;
						if (Main.bgAlpha[num21] < 0f)
						{
							Main.bgAlpha[num21] = 0f;
						}
					}
					if (Main.owBack)
					{
						Main.backColor = Main.trueBackColor;
						Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha[num21]);
						Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha[num21]);
						Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha[num21]);
						Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha[num21]);
						if (Main.bgAlpha[num21] > 0f && num21 == 3)
						{
							this.LoadBackground(Main.jungleBG[0]);
							Main.bgScale = 1.25f;
							Main.bgScale *= 2f;
							Main.bgW = (int)((float)Main.backgroundWidth[Main.jungleBG[0]] * Main.bgScale);
							this.bgParrallax = 0.4;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
							this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1660.0) + (int)this.scAdj;
							if (Main.gameMenu)
							{
								this.bgTop = 320;
							}
							if (Main.jungleBG[0] == 59)
							{
								this.bgTop -= 200;
							}
							this.bgLoops = Main.screenWidth / Main.bgW + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num22 = 0; num22 < this.bgLoops; num22++)
								{
									this.spriteBatch.Draw(Main.backgroundTexture[Main.jungleBG[0]], new Vector2((float)(this.bgStart + Main.bgW * num22), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.jungleBG[0]], Main.backgroundHeight[Main.jungleBG[0]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
								}
							}
							this.LoadBackground(Main.jungleBG[1]);
							Main.bgScale = 1.31f;
							Main.bgScale *= 2f;
							Main.bgW = (int)((float)Main.backgroundWidth[Main.jungleBG[1]] * Main.bgScale);
							this.bgParrallax = 0.43;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
							this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1950.0 + 1840.0) + (int)this.scAdj;
							if (Main.gameMenu)
							{
								this.bgTop = 400;
								this.bgStart -= 80;
							}
							if (Main.jungleBG[1] == 60)
							{
								this.bgTop -= 175;
							}
							this.bgLoops = Main.screenWidth / Main.bgW + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num23 = 0; num23 < this.bgLoops; num23++)
								{
									this.spriteBatch.Draw(Main.backgroundTexture[Main.jungleBG[1]], new Vector2((float)(this.bgStart + Main.bgW * num23), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.jungleBG[1]], Main.backgroundHeight[Main.jungleBG[1]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.FlipHorizontally, 0f);
								}
							}
							Main.bgScale = 1.34f;
							Main.bgScale *= 2f;
							this.LoadBackground(Main.jungleBG[2]);
							Main.bgW = (int)((float)Main.backgroundWidth[Main.jungleBG[2]] * Main.bgScale);
							this.bgParrallax = 0.49;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
							this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 2060.0) + (int)this.scAdj;
							if (Main.gameMenu)
							{
								this.bgTop = 480;
								this.bgStart -= 120;
							}
							if (Main.jungleBG[2] == 61)
							{
								this.bgTop -= 150;
							}
							this.bgLoops = Main.screenWidth / Main.bgW + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num24 = 0; num24 < this.bgLoops; num24++)
								{
									this.spriteBatch.Draw(Main.backgroundTexture[Main.jungleBG[2]], new Vector2((float)(this.bgStart + Main.bgW * num24), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.jungleBG[2]], Main.backgroundHeight[Main.jungleBG[2]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
								}
							}
						}
						if (Main.bgAlpha[num21] > 0f && num21 == 2)
						{
							this.LoadBackground(Main.desertBG[0]);
							Main.bgScale = 1.25f;
							Main.bgScale *= 2f;
							Main.bgW = (int)((float)Main.backgroundWidth[Main.desertBG[0]] * Main.bgScale);
							this.bgParrallax = 0.37;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
							this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1750.0) + (int)this.scAdj;
							if (Main.gameMenu)
							{
								this.bgTop = 320;
							}
							this.bgLoops = Main.screenWidth / Main.bgW + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num25 = 0; num25 < this.bgLoops; num25++)
								{
									this.spriteBatch.Draw(Main.backgroundTexture[Main.desertBG[0]], new Vector2((float)(this.bgStart + Main.bgW * num25), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.desertBG[0]], Main.backgroundHeight[Main.desertBG[0]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
								}
							}
							Main.bgScale = 1.34f;
							Main.bgScale *= 2f;
							this.LoadBackground(Main.desertBG[1]);
							Main.bgW = (int)((float)Main.backgroundWidth[Main.desertBG[1]] * Main.bgScale);
							this.bgParrallax = 0.49;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
							this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 2150.0) + (int)this.scAdj;
							if (Main.gameMenu)
							{
								this.bgTop = 480;
								this.bgStart -= 120;
							}
							this.bgLoops = Main.screenWidth / Main.bgW + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num26 = 0; num26 < this.bgLoops; num26++)
								{
									this.spriteBatch.Draw(Main.backgroundTexture[Main.desertBG[1]], new Vector2((float)(this.bgStart + Main.bgW * num26), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.desertBG[1]], Main.backgroundHeight[Main.desertBG[1]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
								}
							}
						}
						if (Main.bgAlpha[num21] > 0f && num21 == 5)
						{
							this.LoadBackground(26);
							Main.bgScale = 1.25f;
							Main.bgScale *= 2f;
							Main.bgW = (int)((float)Main.backgroundWidth[26] * Main.bgScale);
							this.bgParrallax = 0.37;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
							this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1750.0) + (int)this.scAdj;
							if (Main.gameMenu)
							{
								this.bgTop = 320;
							}
							this.bgLoops = Main.screenWidth / Main.bgW + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num27 = 0; num27 < this.bgLoops; num27++)
								{
									this.spriteBatch.Draw(Main.backgroundTexture[26], new Vector2((float)(this.bgStart + Main.bgW * num27), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[26], Main.backgroundHeight[26])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
								}
							}
							Main.bgScale = 1.34f;
							Main.bgScale *= 2f;
							this.LoadBackground(27);
							Main.bgW = (int)((float)Main.backgroundWidth[27] * Main.bgScale);
							this.bgParrallax = 0.49;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
							this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 2150.0) + (int)this.scAdj;
							if (Main.gameMenu)
							{
								this.bgTop = 480;
								this.bgStart -= 120;
							}
							this.bgLoops = Main.screenWidth / Main.bgW + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num28 = 0; num28 < this.bgLoops; num28++)
								{
									this.spriteBatch.Draw(Main.backgroundTexture[27], new Vector2((float)(this.bgStart + Main.bgW * num28), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[27], Main.backgroundHeight[27])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
								}
							}
						}
						if (Main.bgAlpha[num21] > 0f && num21 == 1)
						{
							Main.bgScale = 1.25f;
							Main.bgScale *= 2f;
							this.LoadBackground(Main.corruptBG[0]);
							Main.bgW = (int)((float)Main.backgroundWidth[Main.corruptBG[0]] * Main.bgScale);
							this.bgParrallax = 0.4;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
							this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1500.0) + (int)this.scAdj;
							if (Main.gameMenu)
							{
								this.bgTop = 320;
							}
							if (Main.corruptBG[0] == 56)
							{
								this.bgTop -= 100;
							}
							this.bgLoops = Main.screenWidth / Main.bgW + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num29 = 0; num29 < this.bgLoops; num29++)
								{
									this.spriteBatch.Draw(Main.backgroundTexture[Main.corruptBG[0]], new Vector2((float)(this.bgStart + Main.bgW * num29), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.corruptBG[0]], Main.backgroundHeight[Main.corruptBG[0]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
								}
							}
							Main.bgScale = 1.31f;
							Main.bgScale *= 2f;
							this.LoadBackground(Main.corruptBG[1]);
							Main.bgW = (int)((float)Main.backgroundWidth[Main.corruptBG[1]] * Main.bgScale);
							this.bgParrallax = 0.43;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
							this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1950.0 + 1750.0) + (int)this.scAdj;
							if (Main.gameMenu)
							{
								this.bgTop = 400;
								this.bgStart -= 80;
							}
							if (Main.corruptBG[0] == 56)
							{
								this.bgTop -= 100;
							}
							this.bgLoops = Main.screenWidth / Main.bgW + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								try
								{
									for (int num30 = 0; num30 < this.bgLoops; num30++)
									{
										this.spriteBatch.Draw(Main.backgroundTexture[Main.corruptBG[1]], new Vector2((float)(this.bgStart + Main.bgW * num30), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.corruptBG[1]], Main.backgroundHeight[Main.corruptBG[1]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.FlipHorizontally, 0f);
									}
								}
								catch
								{
									this.LoadBackground(Main.corruptBG[1]);
								}
							}
							Main.bgScale = 1.34f;
							Main.bgScale *= 2f;
							this.LoadBackground(Main.corruptBG[2]);
							Main.bgW = (int)((float)Main.backgroundWidth[Main.corruptBG[2]] * Main.bgScale);
							this.bgParrallax = 0.49;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
							this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 2000.0) + (int)this.scAdj;
							if (Main.gameMenu)
							{
								this.bgTop = 480;
								this.bgStart -= 120;
							}
							if (Main.corruptBG[0] == 56)
							{
								this.bgTop -= 100;
							}
							this.bgLoops = Main.screenWidth / Main.bgW + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num31 = 0; num31 < this.bgLoops; num31++)
								{
									this.spriteBatch.Draw(Main.backgroundTexture[Main.corruptBG[2]], new Vector2((float)(this.bgStart + Main.bgW * num31), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.corruptBG[2]], Main.backgroundHeight[Main.corruptBG[2]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
								}
							}
						}
						if (Main.bgAlpha[num21] > 0f && num21 == 6)
						{
							Main.bgScale = 1.25f;
							Main.bgScale *= 2f;
							this.LoadBackground(Main.hallowBG[0]);
							Main.bgW = (int)((float)Main.backgroundWidth[Main.hallowBG[0]] * Main.bgScale);
							this.bgParrallax = 0.4;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
							this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1500.0) + (int)this.scAdj;
							if (Main.gameMenu)
							{
								this.bgTop = 320;
							}
							this.bgLoops = Main.screenWidth / Main.bgW + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num32 = 0; num32 < this.bgLoops; num32++)
								{
									this.spriteBatch.Draw(Main.backgroundTexture[Main.hallowBG[0]], new Vector2((float)(this.bgStart + Main.bgW * num32), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.hallowBG[0]], Main.backgroundHeight[Main.hallowBG[0]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
								}
							}
							Main.bgScale = 1.31f;
							Main.bgScale *= 2f;
							this.LoadBackground(Main.hallowBG[1]);
							Main.bgW = (int)((float)Main.backgroundWidth[Main.hallowBG[1]] * Main.bgScale);
							this.bgParrallax = 0.43;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
							this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1950.0 + 1750.0) + (int)this.scAdj;
							if (Main.gameMenu)
							{
								this.bgTop = 400;
								this.bgStart -= 80;
							}
							this.bgLoops = Main.screenWidth / Main.bgW + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num33 = 0; num33 < this.bgLoops; num33++)
								{
									this.spriteBatch.Draw(Main.backgroundTexture[Main.hallowBG[1]], new Vector2((float)(this.bgStart + Main.bgW * num33), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.hallowBG[1]], Main.backgroundHeight[Main.hallowBG[1]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
								}
							}
							Main.bgScale = 1.34f;
							Main.bgScale *= 2f;
							this.LoadBackground(Main.hallowBG[2]);
							Main.bgW = (int)((float)Main.backgroundWidth[Main.hallowBG[2]] * Main.bgScale);
							this.bgParrallax = 0.49;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
							this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 2000.0) + (int)this.scAdj;
							if (Main.gameMenu)
							{
								this.bgTop = 480;
								this.bgStart -= 120;
							}
							this.bgLoops = Main.screenWidth / Main.bgW + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num34 = 0; num34 < this.bgLoops; num34++)
								{
									this.spriteBatch.Draw(Main.backgroundTexture[Main.hallowBG[2]], new Vector2((float)(this.bgStart + Main.bgW * num34), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.hallowBG[2]], Main.backgroundHeight[Main.hallowBG[2]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
								}
							}
						}
						if (Main.bgAlpha[num21] > 0f && num21 == 0)
						{
							Main.bgScale = 1.25f;
							Main.bgScale *= 2f;
							this.bgParrallax = 0.4;
							if (Main.treeBG[0] == 91)
							{
								this.bgParrallax = 0.27000001072883606;
								Main.bgScale = 1.2f;
								Main.bgScale *= 2f;
							}
							if (Main.treeBG[0] == 173)
							{
								this.bgParrallax = 0.25;
								Main.bgScale = 1.3f;
								Main.bgScale *= 2f;
							}
							if (Main.treeBG[0] == 178)
							{
								this.bgParrallax = 0.30000001192092896;
								Main.bgScale = 1.2f;
								Main.bgScale *= 2f;
							}
							if (Main.treeBG[0] == 184)
							{
								this.bgParrallax = 0.25;
								Main.bgScale = 1.2f;
								Main.bgScale *= 2f;
							}
							if (Main.treeBG[0] >= 0)
							{
								this.LoadBackground(Main.treeBG[0]);
								Main.bgW = (int)((float)Main.backgroundWidth[Main.treeBG[0]] * Main.bgScale);
								this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
								this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1500.0) + (int)this.scAdj;
								if (Main.treeBG[0] == 91)
								{
									this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1600.0 + 1400.0) + (int)this.scAdj;
								}
								if (Main.treeBG[0] == 173)
								{
									this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1600.0 + 1400.0) + (int)this.scAdj;
								}
								if (Main.treeBG[0] == 184)
								{
									this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1600.0 + 1400.0) + (int)this.scAdj;
								}
								if (Main.gameMenu)
								{
									this.bgTop = 320;
								}
								if (Main.treeBG[0] == 50)
								{
									this.bgTop -= 50;
								}
								if (Main.treeBG[0] == 53)
								{
									this.bgTop -= 100;
								}
								if (Main.treeBG[0] == 91)
								{
									this.bgTop += 200;
								}
								if (Main.treeBG[0] == 173)
								{
									this.bgTop += 200;
								}
								if (Main.treeBG[0] == 178)
								{
									this.bgTop += 75;
								}
								this.bgLoops = Main.screenWidth / Main.bgW + 2;
								if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
								{
									for (int num35 = 0; num35 < this.bgLoops; num35++)
									{
										this.spriteBatch.Draw(Main.backgroundTexture[Main.treeBG[0]], new Vector2((float)(this.bgStart + Main.bgW * num35), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.treeBG[0]], Main.backgroundHeight[Main.treeBG[0]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
									}
								}
							}
							if (Main.treeBG[1] >= 0)
							{
								this.LoadBackground(Main.treeBG[1]);
								Main.bgScale = 1.31f;
								Main.bgScale *= 2f;
								Main.bgW = (int)((float)Main.backgroundWidth[Main.treeBG[1]] * Main.bgScale);
								this.bgParrallax = 0.43;
								this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
								this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1950.0 + 1750.0) + (int)this.scAdj;
								if (Main.gameMenu)
								{
									this.bgTop = 400;
									this.bgStart -= 80;
								}
								if (Main.treeBG[1] == 51)
								{
									this.bgTop -= 50;
								}
								if (Main.treeBG[1] == 54)
								{
									this.bgTop -= 100;
								}
								this.bgLoops = Main.screenWidth / Main.bgW + 2;
								if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
								{
									for (int num36 = 0; num36 < this.bgLoops; num36++)
									{
										this.spriteBatch.Draw(Main.backgroundTexture[Main.treeBG[1]], new Vector2((float)(this.bgStart + Main.bgW * num36), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.treeBG[1]], Main.backgroundHeight[Main.treeBG[1]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.FlipHorizontally, 0f);
									}
								}
							}
							if (Main.treeBG[2] >= 0)
							{
								this.LoadBackground(Main.treeBG[2]);
								Main.bgScale = 1.34f;
								Main.bgScale *= 2f;
								this.bgParrallax = 0.49;
								if (Main.treeBG[0] == 91)
								{
									Main.bgScale = 1.3f;
									Main.bgScale *= 2f;
									this.bgParrallax = 0.42;
								}
								Main.bgW = (int)((float)Main.backgroundWidth[Main.treeBG[2]] * Main.bgScale);
								this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
								this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 2000.0) + (int)this.scAdj;
								if (Main.gameMenu)
								{
									this.bgTop = 480;
									this.bgStart -= 120;
								}
								if (Main.treeBG[2] == 52)
								{
									this.bgTop -= 50;
								}
								if (Main.treeBG[2] == 55)
								{
									this.bgTop -= 100;
								}
								if (Main.treeBG[2] == 92)
								{
									this.bgTop += 150;
								}
								this.bgLoops = Main.screenWidth / Main.bgW + 2;
								if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
								{
									for (int num37 = 0; num37 < this.bgLoops; num37++)
									{
										this.spriteBatch.Draw(Main.backgroundTexture[Main.treeBG[2]], new Vector2((float)(this.bgStart + Main.bgW * num37), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.treeBG[2]], Main.backgroundHeight[Main.treeBG[2]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
									}
								}
							}
						}
						if (Main.bgAlpha[num21] > 0f && num21 == 7)
						{
							if (Main.snowBG[0] >= 0)
							{
								Main.bgScale = 1.25f;
								Main.bgScale *= 2f;
								this.LoadBackground(Main.snowBG[0]);
								Main.bgW = (int)((float)Main.backgroundWidth[Main.snowBG[0]] * Main.bgScale);
								this.bgParrallax = 0.4;
								this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
								this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1500.0) + (int)this.scAdj;
								if (Main.gameMenu)
								{
									this.bgTop = 320;
								}
								this.bgLoops = Main.screenWidth / Main.bgW + 2;
								if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
								{
									for (int num38 = 0; num38 < this.bgLoops; num38++)
									{
										this.spriteBatch.Draw(Main.backgroundTexture[Main.snowBG[0]], new Vector2((float)(this.bgStart + Main.bgW * num38), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.snowBG[0]], Main.backgroundHeight[Main.snowBG[0]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
									}
								}
							}
							if (Main.snowBG[1] >= 0)
							{
								Main.bgScale = 1.31f;
								Main.bgScale *= 2f;
								this.LoadBackground(Main.snowBG[1]);
								Main.bgW = (int)((float)Main.backgroundWidth[Main.snowBG[1]] * Main.bgScale);
								this.bgParrallax = 0.43;
								this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
								this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1950.0 + 1750.0) + (int)this.scAdj;
								if (Main.gameMenu)
								{
									this.bgTop = 400;
									this.bgStart -= 80;
								}
								this.bgLoops = Main.screenWidth / Main.bgW + 2;
								if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
								{
									for (int num39 = 0; num39 < this.bgLoops; num39++)
									{
										this.spriteBatch.Draw(Main.backgroundTexture[Main.snowBG[1]], new Vector2((float)(this.bgStart + Main.bgW * num39), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.snowBG[1]], Main.backgroundHeight[Main.snowBG[1]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
									}
								}
							}
							if (Main.snowBG[2] >= 0)
							{
								Main.bgScale = 1.34f;
								Main.bgScale *= 2f;
								this.LoadBackground(Main.snowBG[2]);
								Main.bgW = (int)((float)Main.backgroundWidth[Main.snowBG[2]] * Main.bgScale);
								this.bgParrallax = 0.49;
								this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
								this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 2000.0) + (int)this.scAdj;
								if (Main.gameMenu)
								{
									this.bgTop = 480;
									this.bgStart -= 120;
								}
								this.bgLoops = Main.screenWidth / Main.bgW + 2;
								if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
								{
									for (int num40 = 0; num40 < this.bgLoops; num40++)
									{
										this.spriteBatch.Draw(Main.backgroundTexture[Main.snowBG[2]], new Vector2((float)(this.bgStart + Main.bgW * num40), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.snowBG[2]], Main.backgroundHeight[Main.snowBG[2]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
									}
								}
							}
						}
						if (Main.bgAlpha[num21] > 0f && num21 == 8)
						{
							Main.bgScale = 1.25f;
							Main.bgScale *= 2f;
							this.LoadBackground(Main.crimsonBG[0]);
							Main.bgW = (int)((float)Main.backgroundWidth[Main.crimsonBG[0]] * Main.bgScale);
							this.bgParrallax = 0.4;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
							this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1500.0) + (int)this.scAdj;
							if (Main.crimsonBG[0] == 105)
							{
								this.bgTop += 50;
							}
							if (Main.crimsonBG[0] == 174)
							{
								this.bgTop -= 350;
							}
							if (Main.gameMenu)
							{
								this.bgTop = 320;
							}
							this.bgLoops = Main.screenWidth / Main.bgW + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num41 = 0; num41 < this.bgLoops; num41++)
								{
									this.spriteBatch.Draw(Main.backgroundTexture[Main.crimsonBG[0]], new Vector2((float)(this.bgStart + Main.bgW * num41), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.crimsonBG[0]], Main.backgroundHeight[Main.crimsonBG[0]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
								}
							}
							Main.bgScale = 1.31f;
							Main.bgScale *= 2f;
							if (Main.crimsonBG[1] > -1)
							{
								this.LoadBackground(Main.crimsonBG[1]);
								Main.bgW = (int)((float)Main.backgroundWidth[Main.crimsonBG[1]] * Main.bgScale);
								this.bgParrallax = 0.43;
								this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
								this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1950.0 + 1750.0) + (int)this.scAdj;
								if (Main.gameMenu)
								{
									this.bgTop = 400;
									this.bgStart -= 80;
								}
								this.bgLoops = Main.screenWidth / Main.bgW + 2;
								if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
								{
									for (int num42 = 0; num42 < this.bgLoops; num42++)
									{
										this.spriteBatch.Draw(Main.backgroundTexture[Main.crimsonBG[1]], new Vector2((float)(this.bgStart + Main.bgW * num42), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.crimsonBG[1]], Main.backgroundHeight[Main.crimsonBG[1]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
									}
								}
							}
							Main.bgScale = 1.34f;
							Main.bgScale *= 2f;
							this.LoadBackground(Main.crimsonBG[2]);
							Main.bgW = (int)((float)Main.backgroundWidth[Main.crimsonBG[2]] * Main.bgScale);
							this.bgParrallax = 0.49;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
							this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 2000.0) + (int)this.scAdj;
							if (Main.gameMenu)
							{
								this.bgTop = 480;
								this.bgStart -= 120;
							}
							if (Main.crimsonBG[2] == 175)
							{
								this.bgStart -= 1000;
								this.bgTop -= 400;
							}
							this.bgLoops = Main.screenWidth / Main.bgW + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num43 = 0; num43 < this.bgLoops; num43++)
								{
									this.spriteBatch.Draw(Main.backgroundTexture[Main.crimsonBG[2]], new Vector2((float)(this.bgStart + Main.bgW * num43), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.crimsonBG[2]], Main.backgroundHeight[Main.crimsonBG[2]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
								}
							}
						}
						if (Main.bgAlpha[num21] > 0f && num21 == 9)
						{
							float num44 = (float)Main.backColor.A / 255f;
							Color color5 = Main.backColor;
							float num45 = (float)Main.rand.Next(28, 42) * 0.001f;
							num45 += (float)(270 - (int)Main.mouseTextColor) / 5000f;
							float num46 = 0.1f;
							float num47 = 0.15f + num45 / 2f;
							float num48 = 0.3f + num45;
							num46 *= 255f;
							num47 *= 255f;
							num48 *= 255f;
							num46 *= 0.33f * num44;
							num47 *= 0.33f * num44;
							num48 *= 0.33f * num44;
							if (num46 > 255f)
							{
								num46 = 255f;
							}
							if (num47 > 255f)
							{
								num47 = 255f;
							}
							if (num48 > 255f)
							{
								num48 = 255f;
							}
							if (num46 > (float)color5.R)
							{
								color5.R = (byte)num46;
							}
							if (num47 > (float)color5.G)
							{
								color5.G = (byte)num47;
							}
							if (num48 > (float)color5.B)
							{
								color5.B = (byte)num48;
							}
							Main.bgScale = 1.25f;
							Main.bgScale *= 2f;
							this.LoadBackground(46);
							Main.bgW = (int)((float)Main.backgroundWidth[46] * Main.bgScale);
							this.bgParrallax = 0.4;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
							this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1400.0) + (int)this.scAdj;
							if (Main.gameMenu)
							{
								this.bgTop = 320;
							}
							this.bgLoops = Main.screenWidth / Main.bgW + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num49 = 0; num49 < this.bgLoops; num49++)
								{
									this.spriteBatch.Draw(Main.backgroundTexture[46], new Vector2((float)(this.bgStart + Main.bgW * num49), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[46], Main.backgroundHeight[46])), color5, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
								}
							}
							color5 = Main.backColor;
							num45 = (float)Main.rand.Next(28, 42) * 0.001f;
							num45 += (float)(270 - (int)Main.mouseTextColor) / 5000f;
							num46 = 0.1f;
							num47 = 0.175f + num45 / 2f;
							num48 = 0.3f + num45;
							num46 *= 255f;
							num47 *= 255f;
							num48 *= 255f;
							num46 *= 0.5f * num44;
							num47 *= 0.5f * num44;
							num48 *= 0.5f * num44;
							if (num46 > 255f)
							{
								num46 = 255f;
							}
							if (num47 > 255f)
							{
								num47 = 255f;
							}
							if (num48 > 255f)
							{
								num48 = 255f;
							}
							if (num46 > (float)color5.R)
							{
								color5.R = (byte)num46;
							}
							if (num47 > (float)color5.G)
							{
								color5.G = (byte)num47;
							}
							if (num48 > (float)color5.B)
							{
								color5.B = (byte)num48;
							}
							Main.bgScale = 1.32f;
							Main.bgScale *= 2f;
							this.LoadBackground(47);
							Main.bgW = (int)((float)Main.backgroundWidth[47] * Main.bgScale);
							this.bgParrallax = 0.43;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
							this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1950.0 + 1675.0) + (int)this.scAdj;
							if (Main.gameMenu)
							{
								this.bgTop = 400;
								this.bgStart -= 80;
							}
							this.bgLoops = Main.screenWidth / Main.bgW + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num50 = 0; num50 < this.bgLoops; num50++)
								{
									this.spriteBatch.Draw(Main.backgroundTexture[47], new Vector2((float)(this.bgStart + Main.bgW * num50), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[47], Main.backgroundHeight[47])), color5, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
								}
							}
							color5 = Main.backColor;
							num45 = (float)Main.rand.Next(28, 42) * 0.001f;
							num45 += (float)(270 - (int)Main.mouseTextColor) / 3000f;
							num46 = 0.125f;
							num47 = 0.2f + num45 / 2f;
							num48 = 0.3f + num45;
							num46 *= 255f * num44 * 0.75f;
							num47 *= 255f * num44 * 0.75f;
							num48 *= 255f * num44 * 0.75f;
							if (num46 > 255f)
							{
								num46 = 255f;
							}
							if (num47 > 255f)
							{
								num47 = 255f;
							}
							if (num48 > 255f)
							{
								num48 = 255f;
							}
							if (num46 > (float)color5.R)
							{
								color5.R = (byte)num46;
							}
							if (num47 > (float)color5.G)
							{
								color5.G = (byte)num47;
							}
							if (num48 > (float)color5.B)
							{
								color5.B = (byte)num48;
							}
							Main.bgScale = 1.36f;
							Main.bgScale *= 2f;
							this.LoadBackground(48);
							Main.bgW = (int)((float)Main.backgroundWidth[48] * Main.bgScale);
							this.bgParrallax = 0.49;
							this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
							this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 1950.0) + (int)this.scAdj;
							if (Main.gameMenu)
							{
								this.bgTop = 480;
								this.bgStart -= 120;
							}
							this.bgLoops = Main.screenWidth / Main.bgW + 2;
							if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
							{
								for (int num51 = 0; num51 < this.bgLoops; num51++)
								{
									this.spriteBatch.Draw(Main.backgroundTexture[48], new Vector2((float)(this.bgStart + Main.bgW * num51), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[48], Main.backgroundHeight[48])), color5, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
								}
							}
						}
					}
				}
			}
			if (!Main.mapFullscreen && Main.cloudAlpha > 0f && (double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
			{
				this.bgParrallax = 0.1;
				this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.backgroundWidth[Main.background]) - (double)(Main.backgroundWidth[Main.background] / 2));
				this.bgLoops = Main.screenWidth / Main.backgroundWidth[Main.background] + 2;
				this.bgStartY = 0;
				this.bgLoopsY = 0;
				this.bgTop = (int)((double)(-(double)Main.screenPosition.Y) / (Main.worldSurface * 16.0 - 600.0) * 200.0);
				for (int num52 = 0; num52 < this.bgLoops; num52++)
				{
					Color color6 = Main.bgColor;
					this.bgStart = 0;
					float num53 = Main.cloudAlpha;
					color6.R = (byte)((float)color6.R * num53);
					color6.G = (byte)((float)color6.G * num53);
					color6.B = (byte)((float)color6.B * num53);
					color6.A = (byte)((float)color6.A * num53);
					this.spriteBatch.Draw(Main.backgroundTexture[49], new Rectangle(this.bgStart + Main.backgroundWidth[49] * num52, this.bgTop, Main.backgroundWidth[49], Main.backgroundHeight[49]), color6);
				}
			}*/
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
					else
					{
						if (Main.invasionType == 2)
						{
							NPC.downedFrost = true;
						}
						else
						{
							if (Main.invasionType == 3)
							{
								NPC.downedPirates = true;
							}
						}
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
				else
				{
					if (Main.invasionX < (double)Main.spawnTileX)
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
				else
				{
					if (Main.invasionType == 3)
					{
						text = Lang.misc[24];
					}
					else
					{
						text = Lang.misc[0];
					}
				}
			}
			else
			{
				if (Main.invasionX < (double)Main.spawnTileX)
				{
					if (Main.invasionType == 2)
					{
						text = Lang.misc[5];
					}
					else
					{
						if (Main.invasionType == 3)
						{
							text = Lang.misc[25];
						}
						else
						{
							text = Lang.misc[1];
						}
					}
				}
				else
				{
					if (Main.invasionX > (double)Main.spawnTileX)
					{
						if (Main.invasionType == 2)
						{
							text = Lang.misc[6];
						}
						else
						{
							if (Main.invasionType == 3)
							{
								text = Lang.misc[26];
							}
							else
							{
								text = Lang.misc[2];
							}
						}
					}
					else
					{
						if (Main.invasionType == 2)
						{
							text = Lang.misc[7];
						}
						else
						{
							if (Main.invasionType == 3)
							{
								text = Lang.misc[27];
							}
							else
							{
								text = Lang.misc[3];
							}
						}
					}
				}
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
			for (int i = Main.numChatLines - 1; i > 0; i--)
			{
				Main.chatLine[i].text = Main.chatLine[i - 1].text;
				Main.chatLine[i].showTime = Main.chatLine[i - 1].showTime;
				Main.chatLine[i].color = Main.chatLine[i - 1].color;
			}
			if (R == 0 && G == 0 && B == 0)
			{
				Main.chatLine[0].color = Color.White;
			}
			else
			{
				Main.chatLine[0].color = new Color((int)R, (int)G, (int)B);
			}
			Main.chatLine[0].text = newText;
			Main.chatLine[0].showTime = Main.chatLength;
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
				Main.rainTime += Main.rand.Next(0, num2 * 3);
			}
			if (Main.rand.Next(6) == 0)
			{
				Main.rainTime += Main.rand.Next(0, num2 * 4);
			}
			if (Main.rand.Next(7) == 0)
			{
				Main.rainTime += Main.rand.Next(0, num2 * 5);
			}
			if (Main.rand.Next(8) == 0)
			{
				Main.rainTime += Main.rand.Next(0, num2 * 6);
			}
			float num3 = 1f;
			if (Main.rand.Next(2) == 0)
			{
				num3 += 0.1f;
			}
			if (Main.rand.Next(3) == 0)
			{
				num3 += 0.2f;
			}
			if (Main.rand.Next(4) == 0)
			{
				num3 += 0.3f;
			}
			if (Main.rand.Next(5) == 0)
			{
				num3 += 0.4f;
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
			else
			{
				if ((double)Main.numClouds > 100.0)
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
		}
		private static void UpdateTime()
		{
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
					else
					{
						if (Main.rand.Next(num2 * 2) == 0)
						{
							Main.ChangeRain();
						}
					}
				}
				else
				{
					int num3 = 86400;
					num3 /= Main.dayRate;
					if (Main.rand.Next(num3 * 5) == 0)
					{
						Main.StartRain();
					}
					else
					{
						if (Main.cloudBGActive >= 1f && Main.rand.Next(num3 * 4) == 0)
						{
							Main.StartRain();
						}
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
			if (!Main.dayTime)
			{
				Main.eclipse = false;
				if (WorldGen.spawnEye && Main.netMode != 1 && Main.time > 4860.0)
				{
					for (int i = 0; i < 255; i++)
					{
						if (Main.player[i].active && !Main.player[i].dead && (double)Main.player[i].position.Y < Main.worldSurface * 16.0)
						{
							NPC.SpawnOnPlayer(i, 4);
							WorldGen.spawnEye = false;
							break;
						}
					}
				}
				if (WorldGen.spawnHardBoss > 0 && Main.netMode != 1 && Main.time > 4860.0)
				{
					for (int j = 0; j < 255; j++)
					{
						if (Main.player[j].active && !Main.player[j].dead && (double)Main.player[j].position.Y < Main.worldSurface * 16.0)
						{
							if (WorldGen.spawnHardBoss == 1)
							{
								NPC.SpawnOnPlayer(j, 134);
							}
							else
							{
								if (WorldGen.spawnHardBoss == 2)
								{
									NPC.SpawnOnPlayer(j, 125);
									NPC.SpawnOnPlayer(j, 126);
								}
								else
								{
									if (WorldGen.spawnHardBoss == 3)
									{
										NPC.SpawnOnPlayer(j, 127);
									}
								}
							}
							WorldGen.spawnHardBoss = 0;
							break;
						}
					}
				}
				if (Main.time > 32400.0)
				{
					Main.checkXMas();
					if (Main.invasionDelay > 0)
					{
						Main.invasionDelay--;
					}
					WorldGen.spawnNPC = 0;
					Main.checkForSpawns = 0;
					Main.time = 0.0;
					Main.bloodMoon = false;
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
						else
						{
							if ((Main.hardMode && Main.rand.Next(60) == 0) || (!Main.hardMode && Main.rand.Next(30) == 0))
							{
								Main.StartInvasion(1);
							}
						}
						if (Main.invasionType == 0 && Main.hardMode && NPC.downedPirates && Main.rand.Next(60) == 0)
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
							else
							{
								if (Main.netMode == 2)
								{
									NetMessage.SendData(25, -1, -1, Lang.misc[20], 255, 50f, 255f, 130f, 0);
								}
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
				if (Main.time > 54000.0)
				{
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
						for (int k = 0; k < 255; k++)
						{
							if (Main.player[k].active && Main.player[k].statLifeMax >= 200 && Main.player[k].statDefense > 10)
							{
								flag = true;
								break;
							}
						}
						if (flag && Main.rand.Next(3) == 0)
						{
							int num4 = 0;
							for (int l = 0; l < 200; l++)
							{
								if (Main.npc[l].active && Main.npc[l].townNPC)
								{
									num4++;
								}
							}
							if (num4 >= 4)
							{
								WorldGen.spawnEye = true;
								if (Main.netMode == 0)
								{
									Main.NewText(Lang.misc[9], 50, 255, 130, false);
								}
								else
								{
									if (Main.netMode == 2)
									{
										NetMessage.SendData(25, -1, -1, Lang.misc[9], 255, 50f, 255f, 130f, 0);
									}
								}
							}
						}
					}
					if (Main.netMode != 1 && Main.hardMode && !WorldGen.spawnEye && WorldGen.altarCount > 0 && Main.rand.Next(10) == 0 && (!NPC.downedMechBoss1 || !NPC.downedMechBoss2 || !NPC.downedMechBoss3))
					{
						int m = 0;
						while (m < 1000)
						{
							int num5 = Main.rand.Next(3) + 1;
							if (num5 == 1 && !NPC.downedMechBoss1)
							{
								WorldGen.spawnHardBoss = num5;
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
							else
							{
								if (num5 == 2 && !NPC.downedMechBoss2)
								{
									WorldGen.spawnHardBoss = num5;
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
								else
								{
									if (num5 == 3 && !NPC.downedMechBoss3)
									{
										WorldGen.spawnHardBoss = num5;
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
										m++;
									}
								}
							}
						}
					}
					if (!WorldGen.spawnEye && Main.moonPhase != 4 && Main.rand.Next(9) == 0 && Main.netMode != 1)
					{
						for (int n = 0; n < 255; n++)
						{
							if (Main.player[n].active && Main.player[n].statLifeMax > 120)
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
							else
							{
								if (Main.netMode == 2)
								{
									NetMessage.SendData(25, -1, -1, Lang.misc[8], 255, 50f, 255f, 130f, 0);
								}
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
				if (Main.netMode != 1)
				{
					Main.checkForSpawns++;
					if (Main.checkForSpawns >= 7200 / Main.worldRate)
					{
						int num6 = 0;
						for (int num7 = 0; num7 < 255; num7++)
						{
							if (Main.player[num7].active)
							{
								num6++;
							}
						}
						for (int num8 = 0; num8 < 301; num8++)
						{
							Main.nextNPC[num8] = false;
						}
						Main.checkForSpawns = 0;
						WorldGen.spawnNPC = 0;
						int num9 = 0;
						int num10 = 0;
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
						for (int num30 = 0; num30 < 200; num30++)
						{
							if (Main.npc[num30].active && Main.npc[num30].townNPC)
							{
								if (Main.npc[num30].type != 37 && !Main.npc[num30].homeless)
								{
									WorldGen.QuickFindHome(num30);
								}
								if (Main.npc[num30].type == 37)
								{
									num14++;
								}
								if (Main.npc[num30].type == 17)
								{
									num9++;
								}
								if (Main.npc[num30].type == 18)
								{
									num10++;
								}
								if (Main.npc[num30].type == 19)
								{
									num12++;
								}
								if (Main.npc[num30].type == 20)
								{
									num11++;
								}
								if (Main.npc[num30].type == 22)
								{
									num13++;
								}
								if (Main.npc[num30].type == 38)
								{
									num15++;
								}
								if (Main.npc[num30].type == 54)
								{
									num16++;
								}
								if (Main.npc[num30].type == 107)
								{
									num18++;
								}
								if (Main.npc[num30].type == 108)
								{
									num17++;
								}
								if (Main.npc[num30].type == 124)
								{
									num19++;
								}
								if (Main.npc[num30].type == 142)
								{
									num20++;
								}
								if (Main.npc[num30].type == 160)
								{
									num21++;
								}
								if (Main.npc[num30].type == 178)
								{
									num22++;
								}
								if (Main.npc[num30].type == 207)
								{
									num23++;
								}
								if (Main.npc[num30].type == 208)
								{
									num24++;
								}
								if (Main.npc[num30].type == 209)
								{
									num25++;
								}
								if (Main.npc[num30].type == 227)
								{
									num26++;
								}
								if (Main.npc[num30].type == 228)
								{
									num27++;
								}
								if (Main.npc[num30].type == 229)
								{
									num28++;
								}
								num29++;
							}
						}
						if (WorldGen.spawnNPC == 0)
						{
							int num31 = 0;
							bool flag2 = false;
							int num32 = 0;
							bool flag3 = false;
							bool flag4 = false;
							bool flag5 = false;
							for (int num33 = 0; num33 < 255; num33++)
							{
								if (Main.player[num33].active)
								{
									for (int num34 = 0; num34 < 58; num34++)
									{
										if (Main.player[num33].inventory[num34] != null & Main.player[num33].inventory[num34].stack > 0)
										{
											if (Main.player[num33].inventory[num34].type == 71)
											{
												num31 += Main.player[num33].inventory[num34].stack;
											}
											if (Main.player[num33].inventory[num34].type == 72)
											{
												num31 += Main.player[num33].inventory[num34].stack * 100;
											}
											if (Main.player[num33].inventory[num34].type == 73)
											{
												num31 += Main.player[num33].inventory[num34].stack * 10000;
											}
											if (Main.player[num33].inventory[num34].type == 74)
											{
												num31 += Main.player[num33].inventory[num34].stack * 1000000;
											}
											if (Main.player[num33].inventory[num34].ammo == 14 || Main.player[num33].inventory[num34].useAmmo == 14)
											{
												flag3 = true;
											}
											if (Main.player[num33].inventory[num34].type == 166 || Main.player[num33].inventory[num34].type == 167 || Main.player[num33].inventory[num34].type == 168 || Main.player[num33].inventory[num34].type == 235)
											{
												flag4 = true;
											}
											if (Main.player[num33].inventory[num34].dye > 0 || (Main.player[num33].inventory[num34].type >= 1107 && Main.player[num33].inventory[num34].type <= 1120))
											{
												flag5 = true;
											}
										}
									}
									int num35 = Main.player[num33].statLifeMax / 20;
									if (num35 > 5)
									{
										flag2 = true;
									}
									num32 += num35;
									if (!flag5)
									{
										for (int num36 = 0; num36 < 3; num36++)
										{
											if (Main.player[num33].dye[num36] != null && Main.player[num33].dye[num36].stack > 0 && Main.player[num33].dye[num36].dye > 0)
											{
												flag5 = true;
											}
										}
									}
								}
							}
							if (!NPC.downedBoss3 && num14 == 0)
							{
								int num37 = NPC.NewNPC(Main.dungeonX * 16 + 8, Main.dungeonY * 16, 37, 0);
								Main.npc[num37].homeless = false;
								Main.npc[num37].homeTileX = Main.dungeonX;
								Main.npc[num37].homeTileY = Main.dungeonY;
							}
							bool flag6 = false;
							if (Main.rand.Next(50) == 0)
							{
								flag6 = true;
							}
							if (num13 < 1)
							{
								Main.nextNPC[22] = true;
							}
							if ((double)num31 > 5000.0 && num9 < 1)
							{
								Main.nextNPC[17] = true;
							}
							if (flag2 && num10 < 1 && num9 > 0)
							{
								Main.nextNPC[18] = true;
							}
							if (flag3 && num12 < 1)
							{
								Main.nextNPC[19] = true;
							}
							if ((NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3) && num11 < 1)
							{
								Main.nextNPC[20] = true;
							}
							if (flag4 && num9 > 0 && num15 < 1)
							{
								Main.nextNPC[38] = true;
							}
							if (NPC.downedBoss3 && num16 < 1)
							{
								Main.nextNPC[54] = true;
							}
							if (NPC.savedGoblin && num18 < 1)
							{
								Main.nextNPC[107] = true;
							}
							if (NPC.savedWizard && num17 < 1)
							{
								Main.nextNPC[108] = true;
							}
							if (NPC.savedMech && num19 < 1)
							{
								Main.nextNPC[124] = true;
							}
							if (NPC.downedFrost && num20 < 1 && Main.xMas)
							{
								Main.nextNPC[142] = true;
							}
							if (NPC.downedMechBossAny && num22 < 1)
							{
								Main.nextNPC[178] = true;
							}
							if (flag5 && num23 < 1)
							{
								Main.nextNPC[207] = true;
							}
							if (NPC.downedQueenBee && num27 < 1)
							{
								Main.nextNPC[228] = true;
							}
							if (NPC.downedPirates && num28 < 1)
							{
								Main.nextNPC[229] = true;
							}
							if (num21 < 1 && Main.hardMode)
							{
								Main.nextNPC[160] = true;
							}
							if (Main.hardMode && NPC.downedPlantBoss && num25 < 1)
							{
								Main.nextNPC[209] = true;
							}
							if (num29 >= 4 && num26 < 1)
							{
								Main.nextNPC[227] = true;
							}
							if (flag6 && num24 < 1 && num29 >= 8)
							{
								Main.nextNPC[208] = true;
							}
							if (WorldGen.spawnNPC == 0 && num13 < 1)
							{
								WorldGen.spawnNPC = 22;
							}
							if (WorldGen.spawnNPC == 0 && (double)num31 > 5000.0 && num9 < 1)
							{
								WorldGen.spawnNPC = 17;
							}
							if (WorldGen.spawnNPC == 0 && flag2 && num10 < 1 && num9 > 0)
							{
								WorldGen.spawnNPC = 18;
							}
							if (WorldGen.spawnNPC == 0 && flag3 && num12 < 1)
							{
								WorldGen.spawnNPC = 19;
							}
							if (WorldGen.spawnNPC == 0 && (NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3) && num11 < 1)
							{
								WorldGen.spawnNPC = 20;
							}
							if (WorldGen.spawnNPC == 0 && flag4 && num9 > 0 && num15 < 1)
							{
								WorldGen.spawnNPC = 38;
							}
							if (WorldGen.spawnNPC == 0 && NPC.downedBoss3 && num16 < 1)
							{
								WorldGen.spawnNPC = 54;
							}
							if (WorldGen.spawnNPC == 0 && NPC.savedGoblin && num18 < 1)
							{
								WorldGen.spawnNPC = 107;
							}
							if (WorldGen.spawnNPC == 0 && NPC.savedWizard && num17 < 1)
							{
								WorldGen.spawnNPC = 108;
							}
							if (WorldGen.spawnNPC == 0 && NPC.savedMech && num19 < 1)
							{
								WorldGen.spawnNPC = 124;
							}
							if (WorldGen.spawnNPC == 0 && NPC.downedFrost && num20 < 1 && Main.xMas)
							{
								WorldGen.spawnNPC = 142;
							}
							if (WorldGen.spawnNPC == 0 && NPC.downedMechBossAny && num22 < 1)
							{
								WorldGen.spawnNPC = 178;
							}
							if (WorldGen.spawnNPC == 0 && flag5 && num23 < 1)
							{
								WorldGen.spawnNPC = 207;
							}
							if (NPC.downedQueenBee && WorldGen.spawnNPC == 0 && num27 < 1)
							{
								WorldGen.spawnNPC = 228;
							}
							if (NPC.downedPirates && WorldGen.spawnNPC == 0 && num28 < 1)
							{
								WorldGen.spawnNPC = 229;
							}
							if (WorldGen.spawnNPC == 0 && Main.hardMode && num21 < 1)
							{
								WorldGen.spawnNPC = 160;
							}
							if (Main.hardMode && NPC.downedPlantBoss && WorldGen.spawnNPC == 0 && num25 < 1)
							{
								WorldGen.spawnNPC = 209;
							}
							if (WorldGen.spawnNPC == 0 && num29 >= 4 && num26 < 1)
							{
								WorldGen.spawnNPC = 227;
							}
							if (flag6 && WorldGen.spawnNPC == 0 && num29 >= 8 && num24 < 1)
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
			// Kept because it does nothing but is called by a million other things
		}
	}
}
