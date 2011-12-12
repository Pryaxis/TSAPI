using Hooks;




using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
namespace Terraria
{
	public class Main : Game
	{
		private const int MF_BYPOSITION = 1024;
		public const int sectionWidth = 200;
		public const int sectionHeight = 150;
		public const int maxTileSets = 145;
		public const int maxWallTypes = 29;
		public const int maxBackgrounds = 32;
		public const int maxDust = 2000;
		public const int maxCombatText = 100;
		public const int maxItemText = 20;
		public const int maxPlayers = 255;
		public const int maxChests = 1000;
		public const int maxItemTypes = 586;
		public const int maxItems = 200;
		public const int maxBuffs = 40;
		public const int maxProjectileTypes = 109;
		public const int maxProjectiles = 1000;
		public const int maxNPCTypes = 142;
		public const int maxNPCs = 200;
		public const int maxGoreTypes = 157;
		public const int maxGore = 200;
		public const int maxInventory = 48;
		public const int maxItemSounds = 37;
		public const int maxNPCHitSounds = 10;
		public const int maxNPCKilledSounds = 14;
		public const int maxLiquidTypes = 2;
		public const int maxMusic = 14;
		public const int numArmorHead = 44;
		public const int numArmorBody = 25;
		public const int numArmorLegs = 24;
		public const double dayLength = 54000.0;
		public const double nightLength = 32400.0;
		public const int maxStars = 130;
		public const int maxStarTypes = 5;
		public const int maxClouds = 100;
		public const int maxCloudTypes = 4;
		public const int maxHair = 36;
		public static int curRelease = 36;
		public static string versionNumber = "v1.1";
		public static string versionNumber2 = "v1.1";
		public static bool skipMenu = false;
		public static bool verboseNetplay = false;
		public static bool stopTimeOuts = false;
		public static bool showSpam = false;
		public static bool showItemOwner = false;
		public static int oldTempLightCount = 0;
		public static int musicBox = -1;
		public static int musicBox2 = -1;
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
		public static string debugWords = "";
		public static bool gamePad = false;
		public static bool netDiag = false;
		public static int txData = 0;
		public static int rxData = 0;
		public static int txMsg = 0;
		public static int rxMsg = 0;
		public static int maxMsg = 61;
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
		public static bool[] debuff = new bool[40];
		public static string[] buffName = new string[40];
		public static string[] buffTip = new string[40];
		public static int maxMP = 10;
		public static string[] recentWorld = new string[Main.maxMP];
		public static string[] recentIP = new string[Main.maxMP];
		public static int[] recentPort = new int[Main.maxMP];
		public static bool shortRender = true;
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
		public static float[] buffAlpha = new float[40];
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
		public static int numDust = 2000;
		public static int maxNetPlayers = 255;
		public static string[] chrName = new string[142];
		public static int worldRate = 1;
		public static float caveParrallax = 1f;
		public static string[] tileName = new string[145];
		public static int dungeonX;
		public static int dungeonY;
		public static Liquid[] liquid = new Liquid[Liquid.resLiquid];
		public static LiquidBuffer[] liquidBuffer = new LiquidBuffer[10000];
		public static bool dedServ = false;
		public static int spamCount = 0;
		public static int curMusic = 0;
		public int newMusic;
		public static bool showItemText = true;
		public static bool autoSave = true;
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
		public static int checkForSpawns = 0;
		public static int helpText = 0;
		public static bool autoGen = false;
		public static bool autoPause = false;
		public static int[] projFrames = new int[109];
		public static float demonTorch = 1f;
		public static int demonTorchDir = 1;
		public static int numStars;
		public static int cloudLimit = 100;
		public static int numClouds = Main.cloudLimit;
		public static float windSpeed = 0f;
		public static float windSpeedSpeed = 0f;
		public static Cloud[] cloud = new Cloud[100];
		public static bool resetClouds = true;
		public static int sandTiles;
		public static int evilTiles;
		public static int holyTiles;
		public static int meteorTiles;
		public static int jungleTiles;
		public static int dungeonTiles;
		public static int fadeCounter = 0;
		public static float invAlpha = 1f;
		public static float invDir = 1f;
		[ThreadStatic]
		public static Random rand;
		public static float[] musicFade = new float[14];
		public static float musicVolume = 0.75f;
		public static float soundVolume = 1f;
		public static bool[] tileLighted = new bool[145];
		public static bool[] tileMergeDirt = new bool[145];
		public static bool[] tileCut = new bool[145];
		public static bool[] tileAlch = new bool[145];
		public static int[] tileShine = new int[145];
		public static bool[] tileShine2 = new bool[145];
		public static bool[] wallHouse = new bool[29];
		public static int[] wallBlend = new int[29];
		public static bool[] tileStone = new bool[145];
		public static bool[] tilePick = new bool[145];
		public static bool[] tileAxe = new bool[145];
		public static bool[] tileHammer = new bool[145];
		public static bool[] tileWaterDeath = new bool[145];
		public static bool[] tileLavaDeath = new bool[145];
		public static bool[] tileTable = new bool[145];
		public static bool[] tileBlockLight = new bool[145];
		public static bool[] tileNoSunLight = new bool[145];
		public static bool[] tileDungeon = new bool[145];
		public static bool[] tileSolidTop = new bool[145];
		public static bool[] tileSolid = new bool[145];
		public static bool[] tileNoAttach = new bool[145];
		public static bool[] tileNoFail = new bool[145];
		public static bool[] tileFrameImportant = new bool[145];
		public static int[] backgroundWidth = new int[32];
		public static int[] backgroundHeight = new int[32];
		public static bool tilesLoaded = false;
		//public static Tile[,] tile = new Tile[Main.maxTilesX, Main.maxTilesY];
        public static TileCollection tile = new TileCollection();
		public static Dust[] dust = new Dust[2001];
		public static Star[] star = new Star[130];
		public static Item[] item = new Item[201];
		public static NPC[] npc = new NPC[201];
		public static Gore[] gore = new Gore[201];
		public static Projectile[] projectile = new Projectile[1001];
		public static CombatText[] combatText = new CombatText[100];
		public static ItemText[] itemText = new ItemText[20];
		public static Chest[] chest = new Chest[1000];
		public static Sign[] sign = new Sign[1000];
		public static Vector2 screenPosition;
		public static Vector2 screenLastPosition;
		public static int screenWidth = 800;
		public static int screenHeight = 600;
		public static int chatLength = 600;
		public static bool chatMode = false;
		public static bool chatRelease = false;
		public static int numChatLines = 7;
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
		public static Item mouseItem = new Item();
		public static Item guideItem = new Item();
		public static Item reforgeItem = new Item();
		private static float inventoryScale = 0.75f;
		public static bool hasFocus = true;
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
		public Chest[] shop = new Chest[9];
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
		public static Player[] loadPlayer = new Player[5];
		public static string[] loadPlayerPath = new string[5];
		private static int numLoadPlayers = 0;
		public static string playerPathName;
		public static string[] loadWorld = new string[999];
		public static string[] loadWorldPath = new string[999];
		private static int numLoadWorlds = 0;
		public static string worldPathName;
		public static string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\My Games\\Terraria";
		public static string WorldPath = Main.SavePath + "\\Worlds";
		public static string PlayerPath = Main.SavePath + "\\Players";
		public static string[] itemName = new string[586];
		public static string[] npcName = new string[142];
		private static KeyboardState inputText;
		private static KeyboardState oldInputText;
		public static int invasionType = 0;
		public static double invasionX = 0.0;
		public static int invasionSize = 0;
		public static int invasionDelay = 0;
		public static int invasionWarn = 0;
		public static bool invasionDefeat = false;
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
			18, 
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
			3
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
		public static string cInv = "Escape";
		public static string cHeal = "H";
		public static string cMana = "M";
		public static string cBuff = "B";
		public static string cHook = "E";
		public static string cTorch = "LeftShift";
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
		private static Item cpItem = new Item();
		private int textBlinkerCount;
		private int textBlinkerState;
		public static string newWorldName = "";
		private static int accSlotCount = 0;
		private Color selColor = Color.White;
		private int focusColor;
		private int colorDelay;
		private int setKey = -1;
		private int bgScroll;
		public static bool autoPass = false;
		public static int menuFocus = 0;
		public static void LoadWorlds()
		{
			Directory.CreateDirectory(Main.WorldPath);
			string[] files = Directory.GetFiles(Main.WorldPath, "*.wld");
			int num = files.Length;
			if (!Main.dedServ && num > 5)
			{
				num = 5;
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
			if (num > 5)
			{
				num = 5;
			}
			for (int i = 0; i < 5; i++)
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
				if (File.Exists(Main.SavePath + "\\servers.dat"))
				{
					using (FileStream fileStream = new FileStream(Main.SavePath + "\\servers.dat", FileMode.Open))
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
				File.SetAttributes(Main.SavePath + "\\servers.dat", FileAttributes.Normal);
			}
			catch
			{
			}
			try
			{
				using (FileStream fileStream = new FileStream(Main.SavePath + "\\servers.dat", FileMode.Create))
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
		protected void SaveSettings()
		{
			Directory.CreateDirectory(Main.SavePath);
			try
			{
				File.SetAttributes(Main.SavePath + "\\config.dat", FileAttributes.Normal);
			}
			catch
			{
			}
			try
			{
				using (FileStream fileStream = new FileStream(Main.SavePath + "\\config.dat", FileMode.Create))
				{
					using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
					{
						binaryWriter.Write(Main.curRelease);
						binaryWriter.Write(this.graphics.IsFullScreen);
						binaryWriter.Write(Main.mouseColor.R);
						binaryWriter.Write(Main.mouseColor.G);
						binaryWriter.Write(Main.mouseColor.B);
						binaryWriter.Write(Main.soundVolume);
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
						binaryWriter.Write(this.graphics.PreferredBackBufferWidth);
						binaryWriter.Write(this.graphics.PreferredBackBufferHeight);
						binaryWriter.Write(Main.autoSave);
						binaryWriter.Write(Main.autoPause);
						binaryWriter.Write(Main.showItemText);
						binaryWriter.Write(Main.cTorch);
						binaryWriter.Write((byte)Lighting.lightMode);
						binaryWriter.Write((byte)Main.qaStyle);
						binaryWriter.Close();
					}
				}
			}
			catch
			{
			}
		}
		protected void OpenSettings()
		{
			try
			{
				if (File.Exists(Main.SavePath + "\\config.dat"))
				{
					using (FileStream fileStream = new FileStream(Main.SavePath + "\\config.dat", FileMode.Open))
					{
						using (BinaryReader binaryReader = new BinaryReader(fileStream))
						{
							int num = binaryReader.ReadInt32();
							bool flag = binaryReader.ReadBoolean();
							Main.mouseColor.R = binaryReader.ReadByte();
							Main.mouseColor.G = binaryReader.ReadByte();
							Main.mouseColor.B = binaryReader.ReadByte();
							Main.soundVolume = binaryReader.ReadSingle();
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
							if (num >= 4)
							{
								this.graphics.PreferredBackBufferWidth = binaryReader.ReadInt32();
								this.graphics.PreferredBackBufferHeight = binaryReader.ReadInt32();
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
							binaryReader.Close();
							if (flag && !this.graphics.IsFullScreen)
							{
								this.graphics.ToggleFullScreen();
							}
						}
					}
				}
			}
			catch
			{
			}
		}
		private static void ErasePlayer(int i)
		{
			try
			{
				File.Delete(Main.loadPlayerPath[i]);
				File.Delete(Main.loadPlayerPath[i] + ".bak");
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
		private static string nextLoadPlayer()
		{
			int num = 1;
			while (File.Exists(string.Concat(new object[]
			{
				Main.PlayerPath, 
				"\\player", 
				num, 
				".plr"
			})))
			{
				num++;
			}
			return string.Concat(new object[]
			{
				Main.PlayerPath, 
				"\\player", 
				num, 
				".plr"
			});
		}
		private static string nextLoadWorld()
		{
			int num = 1;
			while (File.Exists(string.Concat(new object[]
			{
				Main.WorldPath, 
				"\\world", 
				num, 
				".wld"
			})))
			{
				num++;
			}
			return string.Concat(new object[]
			{
				Main.WorldPath, 
				"\\world", 
				num, 
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
								string a = text.Substring(11);
								if (a == "0")
								{
									Main.autoGen = false;
								}
								else
								{
									if (a == "1")
									{
										Main.maxTilesX = 4200;
										Main.maxTilesY = 1200;
										Main.autoGen = true;
									}
									else
									{
										if (a == "2")
										{
											Main.maxTilesX = 6300;
											Main.maxTilesY = 1800;
											Main.autoGen = true;
										}
										else
										{
											if (a == "3")
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
								string a2 = text.Substring(7);
								if (a2 == "1")
								{
									Netplay.spamCheck = true;
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
            GameHooks.OnInitialize(true);
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
            /*var npcstring = "";
            for (int i = -17; i < Terraria.Main.maxNPCTypes; i++)
            {
                var Npc = new Terraria.NPC();
                Npc.netDefaults(i);
                npcstring += string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}\t{14}\t{15}\t{16}\t{17}\n",
                    Npc.type, Npc.netID, Npc.name, Npc.life, Npc.damage, Npc.defense, Npc.knockBackResist, Npc.noGravity, Npc.value,
                    Npc.friendly, Npc.noTileCollide, Npc.aiStyle, Npc.scale, Npc.boss, Npc.lavaImmune, Npc.townNPC,
                    Npc.height, Npc.width);
            }
            File.WriteAllText("npc.txt", npcstring);
            var itemstring = "";
            for (int i = -24; i < Terraria.Main.maxItemTypes; i++)
            {
                var item = new Terraria.Item();
                item.netDefaults(i);
                itemstring += item.type + "\t" + item.name + "\n";
            }
            File.WriteAllText("item.txt", itemstring);
            var prefixstring = "";
            for (int i = 1; i < 84; i++)
            {
                Item item = new Item();
                item.SetDefaults(0);
                item.prefix = (byte)i;
                prefixstring += i + "\t" + item.AffixName() + "\n";
            }
		    File.WriteAllText("prefix.txt", prefixstring);*/
			for (int i = 0; i < 142; i++)
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
                                        Main.maxTilesX = 6300;
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
                        Main.worldPathName = Main.nextLoadWorld();
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
                                Console.Write("Max players (press enter for 8): ");
                                string text4 = Console.ReadLine();
                                try
                                {
                                    if (text4 == "")
                                    {
                                        text4 = "8";
                                    }
                                    int num4 = Convert.ToInt32(text4);
                                    if (num4 <= 255 && num4 >= 1)
                                    {
                                        Main.maxNetPlayers = num4;
                                        flag3 = false;
                                    }
                                    flag3 = false;
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
                            flag3 = true;
                            while (flag3)
                            {
                                Console.WriteLine("Terraria Server " + Main.versionNumber2);
                                Console.WriteLine("");
                                Console.Write("Server port (press enter for 7777): ");
                                string text5 = Console.ReadLine();
                                try
                                {
                                    if (text5 == "")
                                    {
                                        text5 = "7777";
                                    }
                                    int num5 = Convert.ToInt32(text5);
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
                            Console.WriteLine("Terraria Server " + Main.versionNumber2);
                            Console.WriteLine("");
                            Console.Write("Server password (press enter for none): ");
                            Netplay.password = Console.ReadLine();
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
            GameHooks.OnInitialize(false);
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
					if (num7 > 1000.0)
					{
						num7 = 1000.0;
					}
					if (Netplay.anyClients)
					{
                        GameHooks.OnUpdate(true);
						this.Update(new GameTime());
                        GameHooks.OnUpdate(false);
					}
					double num10 = (double)stopwatch.ElapsedMilliseconds + num7;
					if (num10 < num6)
					{
						int num11 = (int)(num6 - num10) - 1;
						if (num11 > 1)
						{
							Thread.Sleep(num11);
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
                if (!ServerHooks.OnCommand(text))
                {
                    string text2 = text;
                    text = text.ToLower();
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
                                                                                                    string text6 = text2.Substring(9);
                                                                                                    if (text6 == "")
                                                                                                    {
                                                                                                        Netplay.password = "";
                                                                                                        Console.WriteLine("Password disabled.");
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        Netplay.password = text6;
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
                                                                                                            string text7 = text2.Substring(4);
                                                                                                            if (text7 == "")
                                                                                                            {
                                                                                                                Console.WriteLine("Usage: say <words>");
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                Console.WriteLine("<Server> " + text7);
                                                                                                                NetMessage.SendData(25, -1, -1, "<Server> " + text7, 255, 255f, 240f, 20f, 0);
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
                                                                                                                    string text8 = text.Substring(5);
                                                                                                                    text8 = text8.ToLower();
                                                                                                                    if (text8 == "")
                                                                                                                    {
                                                                                                                        Console.WriteLine("Usage: kick <player>");
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        for (int j = 0; j < 255; j++)
                                                                                                                        {
                                                                                                                            if (Main.player[j].active && Main.player[j].name.ToLower() == text8)
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
                                                                                                                            string text9 = text.Substring(4);
                                                                                                                            text9 = text9.ToLower();
                                                                                                                            if (text9 == "")
                                                                                                                            {
                                                                                                                                Console.WriteLine("Usage: ban <player>");
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                for (int k = 0; k < 255; k++)
                                                                                                                                {
                                                                                                                                    if (Main.player[k].active && Main.player[k].name.ToLower() == text9)
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
		public Main()
		{
			this.graphics = new GraphicsDeviceManager(this);
			base.Content.RootDirectory = "Content";
		}
		protected void Initialize()
		{
			NPC.clrNames();
			NPC.setNames();
			Main.bgAlpha[0] = 1f;
			Main.bgAlpha2[0] = 1f;
			for (int i = 0; i < 109; i++)
			{
				Main.projFrames[i] = 1;
			}
			Main.projFrames[72] = 4;
			Main.projFrames[86] = 4;
			Main.projFrames[87] = 4;
			Main.projFrames[102] = 2;
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
			Main.buffName[1] = "Obsidian Skin";
			Main.buffTip[1] = "Immune to lava";
			Main.buffName[2] = "Regeneration";
			Main.buffTip[2] = "Provides life regeneration";
			Main.buffName[3] = "Swiftness";
			Main.buffTip[3] = "25% increased movement speed";
			Main.buffName[4] = "Gills";
			Main.buffTip[4] = "Breathe water instead of air";
			Main.buffName[5] = "Ironskin";
			Main.buffTip[5] = "Increase defense by 8";
			Main.buffName[6] = "Mana Regeneration";
			Main.buffTip[6] = "Increased mana regeneration";
			Main.buffName[7] = "Magic Power";
			Main.buffTip[7] = "20% increased magic damage";
			Main.buffName[8] = "Featherfall";
			Main.buffTip[8] = "Press UP or DOWN to control speed of descent";
			Main.buffName[9] = "Spelunker";
			Main.buffTip[9] = "Shows the location of treasure and ore";
			Main.buffName[10] = "Invisibility";
			Main.buffTip[10] = "Grants invisibility";
			Main.buffName[11] = "Shine";
			Main.buffTip[11] = "Emitting light";
			Main.buffName[12] = "Night Owl";
			Main.buffTip[12] = "Increased night vision";
			Main.buffName[13] = "Battle";
			Main.buffTip[13] = "Increased enemy spawn rate";
			Main.buffName[14] = "Thorns";
			Main.buffTip[14] = "Attackers also take damage";
			Main.buffName[15] = "Water Walking";
			Main.buffTip[15] = "Press DOWN to enter water";
			Main.buffName[16] = "Archery";
			Main.buffTip[16] = "20% increased arrow damage and speed";
			Main.buffName[17] = "Hunter";
			Main.buffTip[17] = "Shows the location of enemies";
			Main.buffName[18] = "Gravitation";
			Main.buffTip[18] = "Press UP or DOWN to reverse gravity";
			Main.buffName[19] = "Orb of Light";
			Main.buffTip[19] = "A magical orb that provides light";
			Main.buffName[20] = "Poisoned";
			Main.buffTip[20] = "Slowly losing life";
			Main.buffName[21] = "Potion Sickness";
			Main.buffTip[21] = "Cannot consume anymore healing items";
			Main.buffName[22] = "Darkness";
			Main.buffTip[22] = "Decreased light vision";
			Main.buffName[23] = "Cursed";
			Main.buffTip[23] = "Cannot use any items";
			Main.buffName[24] = "On Fire!";
			Main.buffTip[24] = "Slowly losing life";
			Main.buffName[25] = "Tipsy";
			Main.buffTip[25] = "Increased melee abilities, lowered defense";
			Main.buffName[26] = "Well Fed";
			Main.buffTip[26] = "Minor improvements to all stats";
			Main.buffName[27] = "Fairy";
			Main.buffTip[27] = "A fairy is following you";
			Main.buffName[28] = "Werewolf";
			Main.buffTip[28] = "Physical abilities are increased";
			Main.buffName[29] = "Clairvoyance";
			Main.buffTip[29] = "Magic powers are increased";
			Main.buffName[30] = "Bleeding";
			Main.buffTip[30] = "Cannot regenerate life";
			Main.buffName[31] = "Confused";
			Main.buffTip[31] = "Movement is reversed";
			Main.buffName[32] = "Slow";
			Main.buffTip[32] = "Movement speed is reduced";
			Main.buffName[33] = "Weak";
			Main.buffTip[33] = "Physical abilities are decreased";
			Main.buffName[34] = "Merfolk";
			Main.buffTip[34] = "Can breathe and move easily underwater";
			Main.buffName[35] = "Silenced";
			Main.buffTip[35] = "Cannot use items that require mana";
			Main.buffName[36] = "Broken Armor";
			Main.buffTip[36] = "Defense is cut in half";
			Main.buffName[37] = "Horrified";
			Main.buffTip[37] = "You have seen something nasty, there is no escape.";
			Main.buffName[38] = "The Tongue";
			Main.buffTip[38] = "You are being sucked into the mouth";
			Main.buffName[39] = "Cursed Inferno";
			Main.buffTip[39] = "Losing life";
			for (int j = 0; j < 10; j++)
			{
				Main.recentWorld[j] = "";
				Main.recentIP[j] = "";
				Main.recentPort[j] = 0;
			}
			if (Main.rand == null)
			{
				Main.rand = new Random((int)DateTime.Now.Ticks);
			}
			if (WorldGen.genRand == null)
			{
				WorldGen.genRand = new Random((int)DateTime.Now.Ticks);
			}
			int num = Main.rand.Next(15);
			if (num == 0)
			{
				base.Window.Title = "Terraria: Dig Peon, Dig!";
			}
			else
			{
				if (num == 1)
				{
					base.Window.Title = "Terraria: Epic Dirt";
				}
				else
				{
					if (num == 2)
					{
						base.Window.Title = "Terraria: Hey Guys!";
					}
					else
					{
						if (num == 3)
						{
							base.Window.Title = "Terraria: Sand is Overpowered";
						}
						else
						{
							if (num == 4)
							{
								base.Window.Title = "Terraria Part 3: The Return of the Guide";
							}
							else
							{
								if (num == 5)
								{
									base.Window.Title = "Terraria: A Bunnies Tale";
								}
								else
								{
									if (num == 6)
									{
										base.Window.Title = "Terraria: Dr. Bones and The Temple of Blood Moon";
									}
									else
									{
										if (num == 7)
										{
											base.Window.Title = "Terraria: Slimeassic Park";
										}
										else
										{
											if (num == 8)
											{
												base.Window.Title = "Terraria: The Grass is Greener on This Side";
											}
											else
											{
												if (num == 9)
												{
													base.Window.Title = "Terraria: Small Blocks, Not for Children Under the Age of 5";
												}
												else
												{
													if (num == 10)
													{
														base.Window.Title = "Terraria: Digger T' Blocks";
													}
													else
													{
														if (num == 11)
														{
															base.Window.Title = "Terraria: There is No Cow Layer";
														}
														else
														{
															if (num == 12)
															{
																base.Window.Title = "Terraria: Suspicous Looking Eyeballs";
															}
															else
															{
																if (num == 13)
																{
																	base.Window.Title = "Terraria: Purple Grass!";
																}
																else
																{
																	if (num == 14)
																	{
																		base.Window.Title = "Terraria: Noone Dug Behind!";
																	}
																	else
																	{
																		base.Window.Title = "Terraria: Shut Up and Dig Gaiden!";
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
			Main.lo = Main.rand.Next(6);
			Main.tileShine2[6] = true;
			Main.tileShine2[7] = true;
			Main.tileShine2[8] = true;
			Main.tileShine2[9] = true;
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
			Main.tileShine[129] = 300;
			Main.tileHammer[141] = true;
			Main.tileHammer[4] = true;
			Main.tileHammer[10] = true;
			Main.tileHammer[11] = true;
			Main.tileHammer[12] = true;
			Main.tileHammer[13] = true;
			Main.tileHammer[14] = true;
			Main.tileHammer[15] = true;
			Main.tileHammer[16] = true;
			Main.tileHammer[17] = true;
			Main.tileHammer[18] = true;
			Main.tileHammer[19] = true;
			Main.tileHammer[21] = true;
			Main.tileHammer[26] = true;
			Main.tileHammer[28] = true;
			Main.tileHammer[29] = true;
			Main.tileHammer[31] = true;
			Main.tileHammer[33] = true;
			Main.tileHammer[34] = true;
			Main.tileHammer[35] = true;
			Main.tileHammer[36] = true;
			Main.tileHammer[42] = true;
			Main.tileHammer[48] = true;
			Main.tileHammer[49] = true;
			Main.tileHammer[50] = true;
			Main.tileHammer[54] = true;
			Main.tileHammer[55] = true;
			Main.tileHammer[77] = true;
			Main.tileHammer[78] = true;
			Main.tileHammer[79] = true;
			Main.tileHammer[81] = true;
			Main.tileHammer[85] = true;
			Main.tileHammer[86] = true;
			Main.tileHammer[87] = true;
			Main.tileHammer[88] = true;
			Main.tileHammer[89] = true;
			Main.tileHammer[90] = true;
			Main.tileHammer[91] = true;
			Main.tileHammer[92] = true;
			Main.tileHammer[93] = true;
			Main.tileHammer[94] = true;
			Main.tileHammer[95] = true;
			Main.tileHammer[96] = true;
			Main.tileHammer[97] = true;
			Main.tileHammer[98] = true;
			Main.tileHammer[99] = true;
			Main.tileHammer[100] = true;
			Main.tileHammer[101] = true;
			Main.tileHammer[102] = true;
			Main.tileHammer[103] = true;
			Main.tileHammer[104] = true;
			Main.tileHammer[105] = true;
			Main.tileHammer[106] = true;
			Main.tileHammer[114] = true;
			Main.tileHammer[125] = true;
			Main.tileHammer[126] = true;
			Main.tileHammer[128] = true;
			Main.tileHammer[129] = true;
			Main.tileHammer[132] = true;
			Main.tileHammer[133] = true;
			Main.tileHammer[134] = true;
			Main.tileHammer[135] = true;
			Main.tileHammer[136] = true;
			Main.tileFrameImportant[139] = true;
			Main.tileHammer[139] = true;
			Main.tileFrameImportant[142] = true;
			Main.tileHammer[142] = true;
			Main.tileFrameImportant[143] = true;
			Main.tileHammer[143] = true;
			Main.tileFrameImportant[144] = true;
			Main.tileHammer[144] = true;
			Main.tileStone[131] = true;
			Main.tileFrameImportant[136] = true;
			Main.tileFrameImportant[137] = true;
			Main.tileFrameImportant[138] = true;
			Main.tileBlockLight[137] = true;
			Main.tileSolid[137] = true;
			Main.tileBlockLight[138] = true;
			Main.tileSolid[138] = true;
			Main.tileBlockLight[140] = true;
			Main.tileSolid[140] = true;
			Main.tileAxe[5] = true;
			Main.tileAxe[30] = true;
			Main.tileAxe[72] = true;
			Main.tileAxe[80] = true;
			Main.tileAxe[124] = true;
			Main.tileShine[22] = 1150;
			Main.tileShine[6] = 1150;
			Main.tileShine[7] = 1100;
			Main.tileShine[8] = 1000;
			Main.tileShine[9] = 1050;
			Main.tileShine[12] = 1000;
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
			Main.tileBlockLight[115] = true;
			Main.tileSolid[0] = true;
			Main.tileBlockLight[0] = true;
			Main.tileSolid[1] = true;
			Main.tileBlockLight[1] = true;
			Main.tileSolid[2] = true;
			Main.tileBlockLight[2] = true;
			Main.tileSolid[3] = false;
			Main.tileNoAttach[3] = true;
			Main.tileNoFail[3] = true;
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
			Main.tileSolidTop[114] = true;
			Main.tileNoAttach[20] = true;
			Main.tileNoAttach[19] = true;
			Main.tileNoAttach[13] = true;
			Main.tileNoAttach[14] = true;
			Main.tileNoAttach[15] = true;
			Main.tileNoAttach[16] = true;
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
			for (int k = 0; k < 29; k++)
			{
				if (k == 20)
				{
					Main.wallBlend[k] = 14;
				}
				else
				{
					if (k == 19)
					{
						Main.wallBlend[k] = 9;
					}
					else
					{
						if (k == 18)
						{
							Main.wallBlend[k] = 8;
						}
						else
						{
							if (k == 17)
							{
								Main.wallBlend[k] = 7;
							}
							else
							{
								if (k == 16)
								{
									Main.wallBlend[k] = 2;
								}
								else
								{
									Main.wallBlend[k] = k;
								}
							}
						}
					}
				}
			}
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
			for (int l = 0; l < 145; l++)
			{
				Main.tileName[l] = "";
				if (Main.tileSolid[l])
				{
					Main.tileNoSunLight[l] = true;
				}
			}
			Main.tileNoSunLight[19] = false;
			Main.tileNoSunLight[11] = true;
			Main.tileName[13] = "Bottle";
			Main.tileName[14] = "Table";
			Main.tileName[15] = "Chair";
			Main.tileName[16] = "Anvil";
			Main.tileName[17] = "Furnace";
			Main.tileName[18] = "Workbench";
			Main.tileName[26] = "Demon Altar";
			Main.tileName[77] = "Hellforge";
			Main.tileName[86] = "Loom";
			Main.tileName[94] = "Keg";
			Main.tileName[96] = "Cooking Pot";
			Main.tileName[101] = "Bookcase";
			Main.tileName[106] = "Sawmill";
			Main.tileName[114] = "Tinkerer's Workshop";
			Main.tileName[133] = "Adamantite Forge";
			Main.tileName[134] = "Mythril Anvil";
			for (int m = 0; m < Main.maxMenuItems; m++)
			{
				this.menuItemScale[m] = 0.8f;
			}
			for (int n = 0; n < 2001; n++)
			{
				Main.dust[n] = new Dust();
			}
			for (int num2 = 0; num2 < 201; num2++)
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
			for (int num6 = 0; num6 < 201; num6++)
			{
				Main.gore[num6] = new Gore();
			}
			for (int num7 = 0; num7 < 100; num7++)
			{
				Main.cloud[num7] = new Cloud();
			}
			for (int num8 = 0; num8 < 100; num8++)
			{
				Main.combatText[num8] = new CombatText();
			}
			for (int num9 = 0; num9 < 20; num9++)
			{
				Main.itemText[num9] = new ItemText();
			}
			for (int num10 = 0; num10 < 586; num10++)
			{
				Item item = new Item();
				item.SetDefaults(num10, false);
				Main.itemName[num10] = item.name;
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
			for (int num11 = 0; num11 < Recipe.maxRecipes; num11++)
			{
				Main.recipe[num11] = new Recipe();
				Main.availableRecipeY[num11] = (float)(65 * num11);
			}
			Recipe.SetupRecipes();
			for (int num12 = 0; num12 < Main.numChatLines; num12++)
			{
				Main.chatLine[num12] = new ChatLine();
			}
			for (int num13 = 0; num13 < Liquid.resLiquid; num13++)
			{
				Main.liquid[num13] = new Liquid();
			}
			for (int num14 = 0; num14 < 10000; num14++)
			{
				Main.liquidBuffer[num14] = new LiquidBuffer();
			}
			this.shop[0] = new Chest();
			this.shop[1] = new Chest();
			this.shop[1].SetupShop(1);
			this.shop[2] = new Chest();
			this.shop[2].SetupShop(2);
			this.shop[3] = new Chest();
			this.shop[3].SetupShop(3);
			this.shop[4] = new Chest();
			this.shop[4].SetupShop(4);
			this.shop[5] = new Chest();
			this.shop[5].SetupShop(5);
			this.shop[6] = new Chest();
			this.shop[6].SetupShop(6);
			this.shop[7] = new Chest();
			this.shop[7].SetupShop(7);
			this.shop[8] = new Chest();
			this.shop[8].SetupShop(8);
			Main.teamColor[0] = Color.White;
			Main.teamColor[1] = new Color(230, 40, 20);
			Main.teamColor[2] = new Color(20, 200, 30);
			Main.teamColor[3] = new Color(75, 90, 255);
			Main.teamColor[4] = new Color(200, 180, 0);
			if (Main.menuMode == 1)
			{
				Main.LoadPlayers();
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
				IntPtr systemMenu = Main.GetSystemMenu(base.Window.Handle, false);
				int menuItemCount = Main.GetMenuItemCount(systemMenu);
				Main.RemoveMenu(systemMenu, menuItemCount - 1, 1024);
			}
			if (Main.dedServ)
			{
				return;
			}
			this.graphics.PreferredBackBufferWidth = Main.screenWidth;
			this.graphics.PreferredBackBufferHeight = Main.screenHeight;
			this.graphics.ApplyChanges();
			base.Initialize();
			base.Window.AllowUserResizing = true;
			this.OpenSettings();
			this.OpenRecent();
			Star.SpawnStars();
			foreach (DisplayMode current in GraphicsAdapter.DefaultAdapter.SupportedDisplayModes)
			{
				if (current.Width >= Main.minScreenW && current.Height >= Main.minScreenH && current.Width <= Main.maxScreenW && current.Height <= Main.maxScreenH)
				{
					bool flag = true;
					for (int num15 = 0; num15 < this.numDisplayModes; num15++)
					{
						if (current.Width == this.displayWidth[num15] && current.Height == this.displayHeight[num15])
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
			Main.updateTimer.Start();
		}
		protected override void Update(GameTime gameTime)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			WorldGen.destroyObject = false;
			if (!Main.dedServ)
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
				}
				this.graphics.SynchronizeWithVerticalRetrace = true;
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
				else
				{
					if (!Main.gameMenu && Main.autoSave)
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
					else
					{
						if (Main.saveTime.IsRunning)
						{
							Main.saveTime.Stop();
						}
					}
				}
				if (Main.teamCooldown > 0)
				{
					Main.teamCooldown--;
				}
				Main.updateTime++;
				if (Main.fpsTimer.ElapsedMilliseconds >= 1000L)
				{
					if (Main.fpsCount >= 60)
					{
						Main.gfxQuality += Main.gfxRate;
						Main.gfxRate += 0.005f;
					}
					else
					{
						if (Main.fpsCount < 59)
						{
							Main.gfxRate = 0.01f;
							if (Main.fpsCount <= 50)
							{
								Main.gfxQuality -= 0.15f;
							}
							else
							{
								if (Main.fpsCount <= 55)
								{
									Main.gfxQuality -= 0.1f;
								}
								else
								{
									if (Main.fpsCount <= 58)
									{
										Main.gfxQuality -= 0.05f;
									}
									else
									{
										Main.gfxQuality -= 0.01f;
									}
								}
							}
						}
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
					if (Main.netMode == 2)
					{
						Main.cloudLimit = 0;
					}
				}
				if (Main.fixedTiming)
				{
					float num = 16f;
					float num2 = (float)Main.updateTimer.ElapsedMilliseconds;
					if (num2 + Main.uCarry < num)
					{
						Main.drawSkip = true;
						return;
					}
					Main.uCarry += num2 - num;
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
				else
				{
					if (Main.qaStyle == 2)
					{
						Main.gfxQuality = 0.5f;
					}
					else
					{
						if (Main.qaStyle == 3)
						{
							Main.gfxQuality = 0f;
						}
					}
				}
				Main.numDust = (int)(2000f * (Main.gfxQuality * 0.75f + 0.25f));
				Gore.goreTime = (int)(600f * Main.gfxQuality);
				Main.cloudLimit = (int)(100f * Main.gfxQuality);
				Liquid.maxLiquid = (int)(2500f + 2500f * Main.gfxQuality);
				Liquid.cycles = (int)(17f - 10f * Main.gfxQuality);
				if ((double)Main.gfxQuality < 0.5)
				{
					this.graphics.SynchronizeWithVerticalRetrace = false;
				}
				else
				{
					this.graphics.SynchronizeWithVerticalRetrace = true;
				}
				if ((double)Main.gfxQuality < 0.05)
				{
					Lighting.maxRenderCount = 9;
				}
				else
				{
					if ((double)Main.gfxQuality < 0.25)
					{
						Lighting.maxRenderCount = 8;
					}
					else
					{
						if ((double)Main.gfxQuality < 0.5)
						{
							Lighting.maxRenderCount = 7;
						}
						else
						{
							if ((double)Main.gfxQuality < 0.75)
							{
								Lighting.maxRenderCount = 6;
							}
							else
							{
								if ((double)Main.gfxQuality < 0.95)
								{
									Lighting.maxRenderCount = 5;
								}
								else
								{
									Lighting.maxRenderCount = 4;
								}
							}
						}
					}
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
				int num3 = 7;
				if (this.DiscoStyle == 0)
				{
					Main.DiscoG += num3;
					if (Main.DiscoG >= 255)
					{
						Main.DiscoG = 255;
						this.DiscoStyle++;
					}
					Main.DiscoR -= num3;
					if (Main.DiscoR <= 0)
					{
						Main.DiscoR = 0;
					}
				}
				else
				{
					if (this.DiscoStyle == 1)
					{
						Main.DiscoB += num3;
						if (Main.DiscoB >= 255)
						{
							Main.DiscoB = 255;
							this.DiscoStyle++;
						}
						Main.DiscoG -= num3;
						if (Main.DiscoG <= 0)
						{
							Main.DiscoG = 0;
						}
					}
					else
					{
						Main.DiscoR += num3;
						if (Main.DiscoR >= 255)
						{
							Main.DiscoR = 255;
							this.DiscoStyle = 0;
						}
						Main.DiscoB -= num3;
						if (Main.DiscoB <= 0)
						{
							Main.DiscoB = 0;
						}
					}
				}
				if (Main.keyState.IsKeyDown(Keys.F10) && !Main.chatMode && !Main.editSign)
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
				if (Main.keyState.IsKeyDown(Keys.F9) && !Main.chatMode && !Main.editSign)
				{
					if (Main.RGBRelease)
					{
						Lighting.lightCounter += 100;
						Main.PlaySound(12, -1, -1, 1);
						Lighting.lightMode++;
						if (Lighting.lightMode >= 4)
						{
							Lighting.lightMode = 0;
						}
						if (Lighting.lightMode == 2 || Lighting.lightMode == 0)
						{
							Main.renderCount = 0;
							Main.renderNow = true;
							int num4 = Main.screenWidth / 16 + Lighting.offScreenTiles * 2;
							int num5 = Main.screenHeight / 16 + Lighting.offScreenTiles * 2;
							for (int i = 0; i < num4; i++)
							{
								for (int j = 0; j < num5; j++)
								{
									Lighting.color[i, j] = 0f;
									Lighting.colorG[i, j] = 0f;
									Lighting.colorB[i, j] = 0f;
								}
							}
						}
					}
					Main.RGBRelease = false;
				}
				else
				{
					Main.RGBRelease = true;
				}
				if (Main.keyState.IsKeyDown(Keys.F8) && !Main.chatMode && !Main.editSign)
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
				if (Main.keyState.IsKeyDown(Keys.F7) && !Main.chatMode && !Main.editSign)
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
					if (this.toggleFullscreen)
					{
						this.graphics.ToggleFullScreen();
						Main.chatRelease = false;
					}
					this.toggleFullscreen = false;
				}
				else
				{
					this.toggleFullscreen = true;
				}
				if (!Main.gamePad || Main.gameMenu)
				{
					Main.oldMouseState = Main.mouseState;
					Main.mouseState = Mouse.GetState();
					Main.mouseX = Main.mouseState.X;
					Main.mouseY = Main.mouseState.Y;
					Main.mouseLeft = false;
					Main.mouseRight = false;
					if (Main.mouseState.LeftButton == ButtonState.Pressed)
					{
						Main.mouseLeft = true;
					}
					if (Main.mouseState.RightButton == ButtonState.Pressed)
					{
						Main.mouseRight = true;
					}
				}
				Main.keyState = Keyboard.GetState();
				if (Main.editSign)
				{
					Main.chatMode = false;
				}
				if (Main.chatMode)
				{
					if (Main.keyState.IsKeyDown(Keys.Escape))
					{
						Main.chatMode = false;
					}
					string a = Main.chatText;
					Main.chatText = Main.GetInputText(Main.chatText);
					while (Main.fontMouseText.MeasureString(Main.chatText).X > 470f)
					{
						Main.chatText = Main.chatText.Substring(0, Main.chatText.Length - 1);
					}
					if (a != Main.chatText)
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
					if (Main.chatRelease && !Main.chatMode && !Main.editSign && !Main.keyState.IsKeyDown(Keys.Escape))
					{
						Main.PlaySound(10, -1, -1, 1);
						Main.chatMode = true;
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
				for (int k = 0; k < 49; k++)
				{
					if (Main.player[Main.myPlayer].inventory[k].IsNotTheSameAs(Main.clientPlayer.inventory[k]))
					{
						NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].inventory[k].name, Main.myPlayer, (float)k, (float)Main.player[Main.myPlayer].inventory[k].prefix, 0f, 0);
					}
				}
				if (Main.player[Main.myPlayer].armor[0].IsNotTheSameAs(Main.clientPlayer.armor[0]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[0].name, Main.myPlayer, 49f, (float)Main.player[Main.myPlayer].armor[0].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[1].IsNotTheSameAs(Main.clientPlayer.armor[1]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[1].name, Main.myPlayer, 50f, (float)Main.player[Main.myPlayer].armor[1].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[2].IsNotTheSameAs(Main.clientPlayer.armor[2]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[2].name, Main.myPlayer, 51f, (float)Main.player[Main.myPlayer].armor[2].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[3].IsNotTheSameAs(Main.clientPlayer.armor[3]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[3].name, Main.myPlayer, 52f, (float)Main.player[Main.myPlayer].armor[3].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[4].IsNotTheSameAs(Main.clientPlayer.armor[4]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[4].name, Main.myPlayer, 53f, (float)Main.player[Main.myPlayer].armor[4].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[5].IsNotTheSameAs(Main.clientPlayer.armor[5]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[5].name, Main.myPlayer, 54f, (float)Main.player[Main.myPlayer].armor[5].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[6].IsNotTheSameAs(Main.clientPlayer.armor[6]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[6].name, Main.myPlayer, 55f, (float)Main.player[Main.myPlayer].armor[6].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[7].IsNotTheSameAs(Main.clientPlayer.armor[7]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[7].name, Main.myPlayer, 56f, (float)Main.player[Main.myPlayer].armor[7].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[8].IsNotTheSameAs(Main.clientPlayer.armor[8]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[8].name, Main.myPlayer, 57f, (float)Main.player[Main.myPlayer].armor[8].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[9].IsNotTheSameAs(Main.clientPlayer.armor[9]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[9].name, Main.myPlayer, 58f, (float)Main.player[Main.myPlayer].armor[9].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[10].IsNotTheSameAs(Main.clientPlayer.armor[10]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[10].name, Main.myPlayer, 59f, (float)Main.player[Main.myPlayer].armor[10].prefix, 0f, 0);
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
			{
				Keys[] pressedKeys = Main.keyState.GetPressedKeys();
				Main.player[Main.myPlayer].controlInv = false;
				for (int m = 0; m < pressedKeys.Length; m++)
				{
					string a2 = string.Concat(pressedKeys[m]);
					if (a2 == Main.cInv)
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
					int num6 = (Main.mouseState.ScrollWheelValue - Main.oldMouseState.ScrollWheelValue) / 120;
					Main.focusRecipe += num6;
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
				return;
			}
			Main.gamePaused = false;
			if (!Main.dedServ && (double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0 && Main.netMode != 2)
			{
				Star.UpdateStars();
				Cloud.UpdateClouds();
			}
			int n = 0;
			while (n < 255)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.player[n].UpdatePlayer(n);
						goto IL_15E4;
					}
					catch
					{
						goto IL_15E4;
					}
					goto IL_15D5;
				}
				goto IL_15D5;
				IL_15E4:
				n++;
				continue;
				IL_15D5:
				Main.player[n].UpdatePlayer(n);
				goto IL_15E4;
			}
			if (Main.netMode != 1)
			{
				NPC.SpawnNPC();
			}
			for (int num7 = 0; num7 < 255; num7++)
			{
				Main.player[num7].activeNPCs = 0f;
				Main.player[num7].townNPCs = 0f;
			}
			if (Main.wof >= 0 && !Main.npc[Main.wof].active)
			{
				Main.wof = -1;
			}
			int num8 = 0;
			while (num8 < 200)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.npc[num8].UpdateNPC(num8);
						goto IL_1694;
					}
					catch (Exception)
					{
						Main.npc[num8] = new NPC();
						goto IL_1694;
					}
					goto IL_1685;
				}
				goto IL_1685;
				IL_1694:
				num8++;
				continue;
				IL_1685:
				Main.npc[num8].UpdateNPC(num8);
				goto IL_1694;
			}
			int num9 = 0;
			while (num9 < 200)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.gore[num9].Update();
						goto IL_16DB;
					}
					catch
					{
						Main.gore[num9] = new Gore();
						goto IL_16DB;
					}
					goto IL_16CE;
				}
				goto IL_16CE;
				IL_16DB:
				num9++;
				continue;
				IL_16CE:
				Main.gore[num9].Update();
				goto IL_16DB;
			}
			int num10 = 0;
			while (num10 < 1000)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.projectile[num10].Update(num10);
						goto IL_1726;
					}
					catch
					{
						Main.projectile[num10] = new Projectile();
						goto IL_1726;
					}
					goto IL_1717;
				}
				goto IL_1717;
				IL_1726:
				num10++;
				continue;
				IL_1717:
				Main.projectile[num10].Update(num10);
				goto IL_1726;
			}
			int num11 = 0;
			while (num11 < 200)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.item[num11].UpdateItem(num11);
						goto IL_1771;
					}
					catch
					{
						Main.item[num11] = new Item();
						goto IL_1771;
					}
					goto IL_1762;
				}
				goto IL_1762;
				IL_1771:
				num11++;
				continue;
				IL_1762:
				Main.item[num11].UpdateItem(num11);
				goto IL_1771;
			}
			if (Main.ignoreErrors)
			{
				try
				{
					Dust.UpdateDust();
					goto IL_17B7;
				}
				catch
				{
					for (int num12 = 0; num12 < 2000; num12++)
					{
						Main.dust[num12] = new Dust();
					}
					goto IL_17B7;
				}
			}
			Dust.UpdateDust();
			IL_17B7:
			if (Main.netMode != 2)
			{
				CombatText.UpdateCombatText();
				ItemText.UpdateItemText();
			}
			if (Main.ignoreErrors)
			{
				try
				{
					Main.UpdateTime();
					goto IL_17E5;
				}
				catch
				{
					Main.checkForSpawns = 0;
					goto IL_17E5;
				}
			}
			Main.UpdateTime();
			IL_17E5:
			if (Main.netMode != 1)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						WorldGen.UpdateWorld();
						Main.UpdateInvasion();
						goto IL_180D;
					}
					catch
					{
						goto IL_180D;
					}
				}
				WorldGen.UpdateWorld();
				Main.UpdateInvasion();
			}
			IL_180D:
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
					goto IL_1855;
				}
				catch
				{
					int arg_1838_0 = Main.netMode;
					goto IL_1855;
				}
			}
			if (Main.netMode == 2)
			{
				Main.UpdateServer();
				goto IL_1848;
			}
			goto IL_1848;
			IL_1855:
			if (Main.ignoreErrors)
			{
				try
				{
					for (int num13 = 0; num13 < Main.numChatLines; num13++)
					{
						if (Main.chatLine[num13].showTime > 0)
						{
							Main.chatLine[num13].showTime--;
						}
					}
					goto IL_18F4;
				}
				catch
				{
					for (int num14 = 0; num14 < Main.numChatLines; num14++)
					{
						Main.chatLine[num14] = new ChatLine();
					}
					goto IL_18F4;
				}
				goto IL_18BB;
			}
			goto IL_18BB;
			IL_18F4:
			Main.upTimer = (float)stopwatch.ElapsedMilliseconds;
			if (Main.upTimerMaxDelay > 0f)
			{
				Main.upTimerMaxDelay -= 1f;
				goto IL_1928;
			}
			Main.upTimerMax = 0f;
			goto IL_1928;
			IL_18BB:
			for (int num15 = 0; num15 < Main.numChatLines; num15++)
			{
				if (Main.chatLine[num15].showTime > 0)
				{
					Main.chatLine[num15].showTime--;
				}
			}
			goto IL_18F4;
			IL_1848:
			if (Main.netMode == 1)
			{
				Main.UpdateClient();
				goto IL_1855;
			}
			goto IL_1855;
			IL_1928:
			if (Main.upTimer > Main.upTimerMax)
			{
				Main.upTimerMax = Main.upTimer;
				Main.upTimerMaxDelay = 400f;
			}
			base.Update(gameTime);
		}
		private static void UpdateMenu()
		{
			Main.playerInventory = false;
			Main.exitScale = 0.8f;
			if (Main.netMode == 0)
			{
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
			}
		}
		protected void MouseText(string cursorText, int rare = 0, byte diff = 0)
		{
			if (this.mouseNPC > -1)
			{
				return;
			}
			if (cursorText == null)
			{
				return;
			}
			int num = Main.mouseX + 10;
			int num2 = Main.mouseY + 10;
			Color color = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
			float num20;
			Vector2 origin;
			if (Main.toolTip.type > 0)
			{
				if (Main.player[Main.myPlayer].kbGlove)
				{
					Main.toolTip.knockBack *= 1.7f;
				}
				rare = Main.toolTip.rare;
				int num3 = 20;
				int num4 = 1;
				string[] array = new string[num3];
				bool[] array2 = new bool[num3];
				bool[] array3 = new bool[num3];
				for (int i = 0; i < num3; i++)
				{
					array2[i] = false;
					array3[i] = false;
				}
				array[0] = Main.toolTip.AffixName();
				if (Main.toolTip.stack > 1)
				{
					string[] array4;
					string[] expr_DB = array4 = array;
					int arg_11F_1 = 0;
					object obj = array4[0];
					expr_DB[arg_11F_1] = string.Concat(new object[]
					{
						obj, 
						" (", 
						Main.toolTip.stack, 
						")"
					});
				}
				if (Main.toolTip.social)
				{
					array[num4] = "Equipped in social slot";
					num4++;
					array[num4] = "No stats will be gained";
					num4++;
				}
				else
				{
					if (Main.toolTip.damage > 0)
					{
						int damage = Main.toolTip.damage;
						if (Main.toolTip.melee)
						{
							array[num4] = string.Concat((int)(Main.player[Main.myPlayer].meleeDamage * (float)damage));
							string[] array5;
							IntPtr intPtr;
							(array5 = array)[(int)(intPtr = (IntPtr)num4)] = array5[(int)intPtr] + " melee";
						}
						else
						{
							if (Main.toolTip.ranged)
							{
								array[num4] = string.Concat((int)(Main.player[Main.myPlayer].rangedDamage * (float)damage));
								string[] array6;
								IntPtr intPtr2;
								(array6 = array)[(int)(intPtr2 = (IntPtr)num4)] = array6[(int)intPtr2] + " ranged";
							}
							else
							{
								if (Main.toolTip.magic)
								{
									array[num4] = string.Concat((int)(Main.player[Main.myPlayer].magicDamage * (float)damage));
									string[] array7;
									IntPtr intPtr3;
									(array7 = array)[(int)(intPtr3 = (IntPtr)num4)] = array7[(int)intPtr3] + " magic";
								}
								else
								{
									array[num4] = string.Concat(damage);
								}
							}
						}
						string[] array8;
						IntPtr intPtr4;
						(array8 = array)[(int)(intPtr4 = (IntPtr)num4)] = array8[(int)intPtr4] + " damage";
						num4++;
						if (Main.toolTip.melee)
						{
							int num5 = Main.player[Main.myPlayer].meleeCrit - Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].crit + Main.toolTip.crit;
							array[num4] = num5 + "% critical strike chance";
							num4++;
						}
						else
						{
							if (Main.toolTip.ranged)
							{
								int num6 = Main.player[Main.myPlayer].rangedCrit - Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].crit + Main.toolTip.crit;
								array[num4] = num6 + "% critical strike chance";
								num4++;
							}
							else
							{
								if (Main.toolTip.magic)
								{
									int num7 = Main.player[Main.myPlayer].magicCrit - Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].crit + Main.toolTip.crit;
									array[num4] = num7 + "% critical strike chance";
									num4++;
								}
							}
						}
						if (Main.toolTip.useStyle > 0)
						{
							if (Main.toolTip.useAnimation <= 8)
							{
								array[num4] = "Insanely fast";
							}
							else
							{
								if (Main.toolTip.useAnimation <= 20)
								{
									array[num4] = "Very fast";
								}
								else
								{
									if (Main.toolTip.useAnimation <= 25)
									{
										array[num4] = "Fast";
									}
									else
									{
										if (Main.toolTip.useAnimation <= 30)
										{
											array[num4] = "Average";
										}
										else
										{
											if (Main.toolTip.useAnimation <= 35)
											{
												array[num4] = "Slow";
											}
											else
											{
												if (Main.toolTip.useAnimation <= 45)
												{
													array[num4] = "Very slow";
												}
												else
												{
													if (Main.toolTip.useAnimation <= 55)
													{
														array[num4] = "Extremely slow";
													}
													else
													{
														array[num4] = "Snail";
													}
												}
											}
										}
									}
								}
							}
							string[] array9;
							IntPtr intPtr5;
							(array9 = array)[(int)(intPtr5 = (IntPtr)num4)] = array9[(int)intPtr5] + " speed";
							num4++;
						}
						if (Main.toolTip.knockBack == 0f)
						{
							array[num4] = "No";
						}
						else
						{
							if ((double)Main.toolTip.knockBack <= 1.5)
							{
								array[num4] = "Extremely weak";
							}
							else
							{
								if (Main.toolTip.knockBack <= 3f)
								{
									array[num4] = "Very weak";
								}
								else
								{
									if (Main.toolTip.knockBack <= 4f)
									{
										array[num4] = "Weak";
									}
									else
									{
										if (Main.toolTip.knockBack <= 6f)
										{
											array[num4] = "Average";
										}
										else
										{
											if (Main.toolTip.knockBack <= 7f)
											{
												array[num4] = "Strong";
											}
											else
											{
												if (Main.toolTip.knockBack <= 9f)
												{
													array[num4] = "Very strong";
												}
												else
												{
													if (Main.toolTip.knockBack <= 11f)
													{
														array[num4] = "Extremely strong";
													}
													else
													{
														array[num4] = "Insane";
													}
												}
											}
										}
									}
								}
							}
						}
						string[] array10;
						IntPtr intPtr6;
						(array10 = array)[(int)(intPtr6 = (IntPtr)num4)] = array10[(int)intPtr6] + " knockback";
						num4++;
					}
					if (Main.toolTip.headSlot > 0 || Main.toolTip.bodySlot > 0 || Main.toolTip.legSlot > 0 || Main.toolTip.accessory)
					{
						array[num4] = "Equipable";
						num4++;
					}
					if (Main.toolTip.vanity)
					{
						array[num4] = "Vanity Item";
						num4++;
					}
					if (Main.toolTip.defense > 0)
					{
						array[num4] = Main.toolTip.defense + " defense";
						num4++;
					}
					if (Main.toolTip.pick > 0)
					{
						array[num4] = Main.toolTip.pick + "% pickaxe power";
						num4++;
					}
					if (Main.toolTip.axe > 0)
					{
						array[num4] = Main.toolTip.axe * 5 + "% axe power";
						num4++;
					}
					if (Main.toolTip.hammer > 0)
					{
						array[num4] = Main.toolTip.hammer + "% hammer power";
						num4++;
					}
					if (Main.toolTip.healLife > 0)
					{
						array[num4] = "Restores " + Main.toolTip.healLife + " life";
						num4++;
					}
					if (Main.toolTip.healMana > 0)
					{
						array[num4] = "Restores " + Main.toolTip.healMana + " mana";
						num4++;
					}
					if (Main.toolTip.mana > 0 && (Main.toolTip.type != 127 || !Main.player[Main.myPlayer].spaceGun))
					{
						array[num4] = "Uses " + (int)((float)Main.toolTip.mana * Main.player[Main.myPlayer].manaCost) + " mana";
						num4++;
					}
					if (Main.toolTip.createWall > 0 || Main.toolTip.createTile > -1)
					{
						if (Main.toolTip.type != 213)
						{
							array[num4] = "Can be placed";
							num4++;
						}
					}
					else
					{
						if (Main.toolTip.ammo > 0)
						{
							array[num4] = "Ammo";
							num4++;
						}
						else
						{
							if (Main.toolTip.consumable)
							{
								array[num4] = "Consumable";
								num4++;
							}
						}
					}
					if (Main.toolTip.material)
					{
						array[num4] = "Material";
						num4++;
					}
					if (Main.toolTip.toolTip != null)
					{
						array[num4] = Main.toolTip.toolTip;
						num4++;
					}
					if (Main.toolTip.toolTip2 != null)
					{
						array[num4] = Main.toolTip.toolTip2;
						num4++;
					}
					if (Main.toolTip.buffTime > 0)
					{
						string text = "0 s";
						if (Main.toolTip.buffTime / 60 >= 60)
						{
							text = Math.Round((double)(Main.toolTip.buffTime / 60) / 60.0) + " minute duration";
						}
						else
						{
							text = Math.Round((double)Main.toolTip.buffTime / 60.0) + " second duration";
						}
						array[num4] = text;
						num4++;
					}
					if (Main.toolTip.prefix > 0)
					{
						if (Main.cpItem == null || Main.cpItem.name != Main.toolTip.name)
						{
							Main.cpItem = new Item();
							Main.cpItem.SetDefaults(Main.toolTip.name);
						}
						if (Main.cpItem.damage != Main.toolTip.damage)
						{
							double num8 = (double)((float)Main.toolTip.damage - (float)Main.cpItem.damage);
							num8 = num8 / (double)((float)Main.cpItem.damage) * 100.0;
							num8 = Math.Round(num8);
							if (num8 > 0.0)
							{
								array[num4] = "+" + num8 + "% damage";
							}
							else
							{
								array[num4] = num8 + "% damage";
							}
							if (num8 < 0.0)
							{
								array3[num4] = true;
							}
							array2[num4] = true;
							num4++;
						}
						if (Main.cpItem.useAnimation != Main.toolTip.useAnimation)
						{
							double num9 = (double)((float)Main.toolTip.useAnimation - (float)Main.cpItem.useAnimation);
							num9 = num9 / (double)((float)Main.cpItem.useAnimation) * 100.0;
							num9 = Math.Round(num9);
							num9 *= -1.0;
							if (num9 > 0.0)
							{
								array[num4] = "+" + num9 + "% speed";
							}
							else
							{
								array[num4] = num9 + "% speed";
							}
							if (num9 < 0.0)
							{
								array3[num4] = true;
							}
							array2[num4] = true;
							num4++;
						}
						if (Main.cpItem.crit != Main.toolTip.crit)
						{
							double num10 = (double)((float)Main.toolTip.crit - (float)Main.cpItem.crit);
							if (num10 > 0.0)
							{
								array[num4] = "+" + num10 + "% critical strike chance";
							}
							else
							{
								array[num4] = num10 + "% critical strike chance";
							}
							if (num10 < 0.0)
							{
								array3[num4] = true;
							}
							array2[num4] = true;
							num4++;
						}
						if (Main.cpItem.mana != Main.toolTip.mana)
						{
							double num11 = (double)((float)Main.toolTip.mana - (float)Main.cpItem.mana);
							num11 = num11 / (double)((float)Main.cpItem.mana) * 100.0;
							num11 = Math.Round(num11);
							if (num11 > 0.0)
							{
								array[num4] = "+" + num11 + "% mana cost";
							}
							else
							{
								array[num4] = num11 + "% mana cost";
							}
							if (num11 > 0.0)
							{
								array3[num4] = true;
							}
							array2[num4] = true;
							num4++;
						}
						if (Main.cpItem.scale != Main.toolTip.scale)
						{
							double num12 = (double)(Main.toolTip.scale - Main.cpItem.scale);
							num12 = num12 / (double)Main.cpItem.scale * 100.0;
							num12 = Math.Round(num12);
							if (num12 > 0.0)
							{
								array[num4] = "+" + num12 + "% size";
							}
							else
							{
								array[num4] = num12 + "% size";
							}
							if (num12 < 0.0)
							{
								array3[num4] = true;
							}
							array2[num4] = true;
							num4++;
						}
						if (Main.cpItem.shootSpeed != Main.toolTip.shootSpeed)
						{
							double num13 = (double)(Main.toolTip.shootSpeed - Main.cpItem.shootSpeed);
							num13 = num13 / (double)Main.cpItem.shootSpeed * 100.0;
							num13 = Math.Round(num13);
							if (num13 > 0.0)
							{
								array[num4] = "+" + num13 + "% velocity";
							}
							else
							{
								array[num4] = num13 + "% velocity";
							}
							if (num13 < 0.0)
							{
								array3[num4] = true;
							}
							array2[num4] = true;
							num4++;
						}
						if (Main.cpItem.knockBack != Main.toolTip.knockBack)
						{
							double num14 = (double)(Main.toolTip.knockBack - Main.cpItem.knockBack);
							num14 = num14 / (double)Main.cpItem.knockBack * 100.0;
							num14 = Math.Round(num14);
							if (num14 > 0.0)
							{
								array[num4] = "+" + num14 + "% knockback";
							}
							else
							{
								array[num4] = num14 + "% knockback";
							}
							if (num14 < 0.0)
							{
								array3[num4] = true;
							}
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 62)
						{
							array[num4] = "+1 defense";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 63)
						{
							array[num4] = "+2 defense";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 64)
						{
							array[num4] = "+3 defense";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 65)
						{
							array[num4] = "+4 defense";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 66)
						{
							array[num4] = "+20 mana";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 67)
						{
							array[num4] = "+1% critical strike chance";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 68)
						{
							array[num4] = "+2% critical strike chance";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 69)
						{
							array[num4] = "+1% damage";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 70)
						{
							array[num4] = "+2% damage";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 71)
						{
							array[num4] = "+3% damage";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 72)
						{
							array[num4] = "+4% damage";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 73)
						{
							array[num4] = "+1% movement speed";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 74)
						{
							array[num4] = "+2% movement speed";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 75)
						{
							array[num4] = "+3% movement speed";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 76)
						{
							array[num4] = "+4% movement speed";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 77)
						{
							array[num4] = "+1% melee speed";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 78)
						{
							array[num4] = "+2% melee speed";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 79)
						{
							array[num4] = "+3% melee speed";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 80)
						{
							array[num4] = "+4% melee speed";
							array2[num4] = true;
							num4++;
						}
					}
					if (Main.toolTip.wornArmor && Main.player[Main.myPlayer].setBonus != "")
					{
						array[num4] = "Set bonus: " + Main.player[Main.myPlayer].setBonus;
						num4++;
					}
				}
				if (Main.npcShop > 0)
				{
					if (Main.toolTip.value > 0)
					{
						string text2 = "";
						int num15 = 0;
						int num16 = 0;
						int num17 = 0;
						int num18 = 0;
						int num19 = Main.toolTip.value * Main.toolTip.stack;
						if (!Main.toolTip.buy)
						{
							num19 = Main.toolTip.value / 5 * Main.toolTip.stack;
						}
						if (num19 < 1)
						{
							num19 = 1;
						}
						if (num19 >= 1000000)
						{
							num15 = num19 / 1000000;
							num19 -= num15 * 1000000;
						}
						if (num19 >= 10000)
						{
							num16 = num19 / 10000;
							num19 -= num16 * 10000;
						}
						if (num19 >= 100)
						{
							num17 = num19 / 100;
							num19 -= num17 * 100;
						}
						if (num19 >= 1)
						{
							num18 = num19;
						}
						if (num15 > 0)
						{
							text2 = text2 + num15 + " platinum ";
						}
						if (num16 > 0)
						{
							text2 = text2 + num16 + " gold ";
						}
						if (num17 > 0)
						{
							text2 = text2 + num17 + " silver ";
						}
						if (num18 > 0)
						{
							text2 = text2 + num18 + " copper ";
						}
						if (!Main.toolTip.buy)
						{
							array[num4] = "Sell price: " + text2;
						}
						else
						{
							array[num4] = "Buy price: " + text2;
						}
						num4++;
						num20 = (float)Main.mouseTextColor / 255f;
						if (num15 > 0)
						{
							color = new Color((int)((byte)(220f * num20)), (int)((byte)(220f * num20)), (int)((byte)(198f * num20)), (int)Main.mouseTextColor);
						}
						else
						{
							if (num16 > 0)
							{
								color = new Color((int)((byte)(224f * num20)), (int)((byte)(201f * num20)), (int)((byte)(92f * num20)), (int)Main.mouseTextColor);
							}
							else
							{
								if (num17 > 0)
								{
									color = new Color((int)((byte)(181f * num20)), (int)((byte)(192f * num20)), (int)((byte)(193f * num20)), (int)Main.mouseTextColor);
								}
								else
								{
									if (num18 > 0)
									{
										color = new Color((int)((byte)(246f * num20)), (int)((byte)(138f * num20)), (int)((byte)(96f * num20)), (int)Main.mouseTextColor);
									}
								}
							}
						}
					}
					else
					{
						num20 = (float)Main.mouseTextColor / 255f;
						array[num4] = "No value";
						num4++;
						color = new Color((int)((byte)(120f * num20)), (int)((byte)(120f * num20)), (int)((byte)(120f * num20)), (int)Main.mouseTextColor);
					}
				}
				Vector2 vector = default(Vector2);
				int num21 = 0;
				for (int j = 0; j < num4; j++)
				{
					Vector2 vector2 = Main.fontMouseText.MeasureString(array[j]);
					if (vector2.X > vector.X)
					{
						vector.X = vector2.X;
					}
					vector.Y += vector2.Y + (float)num21;
				}
				if ((float)num + vector.X + 4f > (float)Main.screenWidth)
				{
					num = (int)((float)Main.screenWidth - vector.X - 4f);
				}
				if ((float)num2 + vector.Y + 4f > (float)Main.screenHeight)
				{
					num2 = (int)((float)Main.screenHeight - vector.Y - 4f);
				}
				int num22 = 0;
				num20 = (float)Main.mouseTextColor / 255f;
				for (int k = 0; k < num4; k++)
				{
					for (int l = 0; l < 5; l++)
					{
						int num23 = num;
						int num24 = num2 + num22;
						Color color2 = Color.Black;
						if (l == 0)
						{
							num23 -= 2;
						}
						else
						{
							if (l == 1)
							{
								num23 += 2;
							}
							else
							{
								if (l == 2)
								{
									num24 -= 2;
								}
								else
								{
									if (l == 3)
									{
										num24 += 2;
									}
									else
									{
										color2 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
										if (k == 0)
										{
											if (rare == -1)
											{
												color2 = new Color((int)((byte)(130f * num20)), (int)((byte)(130f * num20)), (int)((byte)(130f * num20)), (int)Main.mouseTextColor);
											}
											if (rare == 1)
											{
												color2 = new Color((int)((byte)(150f * num20)), (int)((byte)(150f * num20)), (int)((byte)(255f * num20)), (int)Main.mouseTextColor);
											}
											if (rare == 2)
											{
												color2 = new Color((int)((byte)(150f * num20)), (int)((byte)(255f * num20)), (int)((byte)(150f * num20)), (int)Main.mouseTextColor);
											}
											if (rare == 3)
											{
												color2 = new Color((int)((byte)(255f * num20)), (int)((byte)(200f * num20)), (int)((byte)(150f * num20)), (int)Main.mouseTextColor);
											}
											if (rare == 4)
											{
												color2 = new Color((int)((byte)(255f * num20)), (int)((byte)(150f * num20)), (int)((byte)(150f * num20)), (int)Main.mouseTextColor);
											}
											if (rare == 5)
											{
												color2 = new Color((int)((byte)(255f * num20)), (int)((byte)(150f * num20)), (int)((byte)(255f * num20)), (int)Main.mouseTextColor);
											}
											if (rare == 6)
											{
												color2 = new Color((int)((byte)(210f * num20)), (int)((byte)(160f * num20)), (int)((byte)(255f * num20)), (int)Main.mouseTextColor);
											}
											if (diff == 1)
											{
												color2 = new Color((int)((byte)((float)Main.mcColor.R * num20)), (int)((byte)((float)Main.mcColor.G * num20)), (int)((byte)((float)Main.mcColor.B * num20)), (int)Main.mouseTextColor);
											}
											if (diff == 2)
											{
												color2 = new Color((int)((byte)((float)Main.hcColor.R * num20)), (int)((byte)((float)Main.hcColor.G * num20)), (int)((byte)((float)Main.hcColor.B * num20)), (int)Main.mouseTextColor);
											}
										}
										else
										{
											if (array2[k])
											{
												if (array3[k])
												{
													color2 = new Color((int)((byte)(190f * num20)), (int)((byte)(120f * num20)), (int)((byte)(120f * num20)), (int)Main.mouseTextColor);
												}
												else
												{
													color2 = new Color((int)((byte)(120f * num20)), (int)((byte)(190f * num20)), (int)((byte)(120f * num20)), (int)Main.mouseTextColor);
												}
											}
											else
											{
												if (k == num4 - 1)
												{
													color2 = color;
												}
											}
										}
									}
								}
							}
						}
						SpriteBatch arg_175D_0 = this.spriteBatch;
						SpriteFont arg_175D_1 = Main.fontMouseText;
						string arg_175D_2 = array[k];
						Vector2 arg_175D_3 = new Vector2((float)num23, (float)num24);
						Color arg_175D_4 = color2;
						float arg_175D_5 = 0f;
						origin = default(Vector2);
						arg_175D_0.DrawString(arg_175D_1, arg_175D_2, arg_175D_3, arg_175D_4, arg_175D_5, origin, 1f, SpriteEffects.None, 0f);
					}
					num22 += (int)(Main.fontMouseText.MeasureString(array[k]).Y + (float)num21);
				}
				return;
			}
			if (Main.buffString != "" && Main.buffString != null)
			{
				for (int m = 0; m < 5; m++)
				{
					int num25 = num;
					int num26 = num2 + (int)Main.fontMouseText.MeasureString(Main.buffString).Y;
					Color black = Color.Black;
					if (m == 0)
					{
						num25 -= 2;
					}
					else
					{
						if (m == 1)
						{
							num25 += 2;
						}
						else
						{
							if (m == 2)
							{
								num26 -= 2;
							}
							else
							{
								if (m == 3)
								{
									num26 += 2;
								}
								else
								{
									black = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
								}
							}
						}
					}
					this.spriteBatch.DrawString(Main.fontMouseText, Main.buffString, new Vector2((float)num25, (float)num26), black, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
				}
			}
			Vector2 vector3 = Main.fontMouseText.MeasureString(cursorText);
			if ((float)num + vector3.X + 4f > (float)Main.screenWidth)
			{
				num = (int)((float)Main.screenWidth - vector3.X - 4f);
			}
			if ((float)num2 + vector3.Y + 4f > (float)Main.screenHeight)
			{
				num2 = (int)((float)Main.screenHeight - vector3.Y - 4f);
			}
			SpriteBatch arg_191E_0 = this.spriteBatch;
			SpriteFont arg_191E_1 = Main.fontMouseText;
			Vector2 arg_191E_3 = new Vector2((float)num, (float)(num2 - 2));
			Color arg_191E_4 = Color.Black;
			float arg_191E_5 = 0f;
			origin = default(Vector2);
			arg_191E_0.DrawString(arg_191E_1, cursorText, arg_191E_3, arg_191E_4, arg_191E_5, origin, 1f, SpriteEffects.None, 0f);
			SpriteBatch arg_1959_0 = this.spriteBatch;
			SpriteFont arg_1959_1 = Main.fontMouseText;
			Vector2 arg_1959_3 = new Vector2((float)num, (float)(num2 + 2));
			Color arg_1959_4 = Color.Black;
			float arg_1959_5 = 0f;
			origin = default(Vector2);
			arg_1959_0.DrawString(arg_1959_1, cursorText, arg_1959_3, arg_1959_4, arg_1959_5, origin, 1f, SpriteEffects.None, 0f);
			SpriteBatch arg_1994_0 = this.spriteBatch;
			SpriteFont arg_1994_1 = Main.fontMouseText;
			Vector2 arg_1994_3 = new Vector2((float)(num - 2), (float)num2);
			Color arg_1994_4 = Color.Black;
			float arg_1994_5 = 0f;
			origin = default(Vector2);
			arg_1994_0.DrawString(arg_1994_1, cursorText, arg_1994_3, arg_1994_4, arg_1994_5, origin, 1f, SpriteEffects.None, 0f);
			SpriteBatch arg_19CF_0 = this.spriteBatch;
			SpriteFont arg_19CF_1 = Main.fontMouseText;
			Vector2 arg_19CF_3 = new Vector2((float)(num + 2), (float)num2);
			Color arg_19CF_4 = Color.Black;
			float arg_19CF_5 = 0f;
			origin = default(Vector2);
			arg_19CF_0.DrawString(arg_19CF_1, cursorText, arg_19CF_3, arg_19CF_4, arg_19CF_5, origin, 1f, SpriteEffects.None, 0f);
			num20 = (float)Main.mouseTextColor / 255f;
			Color color3 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
			if (rare == -1)
			{
				color3 = new Color((int)((byte)(130f * num20)), (int)((byte)(130f * num20)), (int)((byte)(130f * num20)), (int)Main.mouseTextColor);
			}
			if (rare == 6)
			{
				color3 = new Color((int)((byte)(210f * num20)), (int)((byte)(160f * num20)), (int)((byte)(255f * num20)), (int)Main.mouseTextColor);
			}
			if (rare == 1)
			{
				color3 = new Color((int)((byte)(150f * num20)), (int)((byte)(150f * num20)), (int)((byte)(255f * num20)), (int)Main.mouseTextColor);
			}
			if (rare == 2)
			{
				color3 = new Color((int)((byte)(150f * num20)), (int)((byte)(255f * num20)), (int)((byte)(150f * num20)), (int)Main.mouseTextColor);
			}
			if (rare == 3)
			{
				color3 = new Color((int)((byte)(255f * num20)), (int)((byte)(200f * num20)), (int)((byte)(150f * num20)), (int)Main.mouseTextColor);
			}
			if (rare == 4)
			{
				color3 = new Color((int)((byte)(255f * num20)), (int)((byte)(150f * num20)), (int)((byte)(150f * num20)), (int)Main.mouseTextColor);
			}
			if (rare == 5)
			{
				color3 = new Color((int)((byte)(255f * num20)), (int)((byte)(150f * num20)), (int)((byte)(255f * num20)), (int)Main.mouseTextColor);
			}
			if (diff == 1)
			{
				color3 = new Color((int)((byte)((float)Main.mcColor.R * num20)), (int)((byte)((float)Main.mcColor.G * num20)), (int)((byte)((float)Main.mcColor.B * num20)), (int)Main.mouseTextColor);
			}
			if (diff == 2)
			{
				color3 = new Color((int)((byte)((float)Main.hcColor.R * num20)), (int)((byte)((float)Main.hcColor.G * num20)), (int)((byte)((float)Main.hcColor.B * num20)), (int)Main.mouseTextColor);
			}
			SpriteBatch arg_1BB9_0 = this.spriteBatch;
			SpriteFont arg_1BB9_1 = Main.fontMouseText;
			Vector2 arg_1BB9_3 = new Vector2((float)num, (float)num2);
			Color arg_1BB9_4 = color3;
			float arg_1BB9_5 = 0f;
			origin = default(Vector2);
			arg_1BB9_0.DrawString(arg_1BB9_1, cursorText, arg_1BB9_3, arg_1BB9_4, arg_1BB9_5, origin, 1f, SpriteEffects.None, 0f);
		}
		public static Color shine(Color newColor, int type)
		{
			int num = (int)newColor.R;
			int num2 = (int)newColor.R;
			int num3 = (int)newColor.R;
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
		private static Color buffColor(Color newColor, float R, float G, float B, float A)
		{
			newColor.R = (byte)((float)newColor.R * R);
			newColor.G = (byte)((float)newColor.G * G);
			newColor.B = (byte)((float)newColor.B * B);
			newColor.A = (byte)((float)newColor.A * A);
			return newColor;
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
			for (int i = 0; i < 48; i++)
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
			Main.npcChatText = "You can use your pickaxe to dig through dirt, and your axe to chop down trees. Just place your cursor over the tile and click!";
			return;
			Block_31:
			Main.npcChatText = "If you want to survive, you will need to create weapons and shelter. Start by chopping down trees and gathering wood.";
			return;
			Block_32:
			Main.npcChatText = "Press ESC to access your crafting menu. When you have enough wood, create a workbench. This will allow you to create more complicated things, as long as you are standing close to it.";
			return;
			Block_33:
			Main.npcChatText = "You can build a shelter by placing wood or other blocks in the world. Don't forget to create and place walls.";
			return;
			Block_34:
			Main.npcChatText = "Once you have a wooden sword, you might try to gather some gel from the slimes. Combine wood and gel to make a torch!";
			return;
			Block_35:
			Main.npcChatText = "To interact with backgrounds and placed objects, use a hammer!";
			return;
			Block_39:
			Main.npcChatText = "You should do some mining to find metal ore. You can craft very useful things with it.";
			return;
			Block_43:
			Main.npcChatText = "Now that you have some ore, you will need to turn it into a bar in order to make items with it. This requires a furnace!";
			return;
			Block_44:
			Main.npcChatText = "You can create a furnace out of torches, wood, and stone. Make sure you are standing near a work bench.";
			return;
			Block_47:
			Main.npcChatText = "You will need an anvil to make most things out of metal bars.";
			return;
			Block_48:
			Main.npcChatText = "Anvils can be crafted out of iron, or purchased from a merchant.";
			return;
			Block_50:
			Main.npcChatText = "Underground are crystal hearts that can be used to increase your max life. You will need a hammer to obtain them.";
			return;
			Block_52:
			Main.npcChatText = "If you gather 10 fallen stars, they can be combined to create an item that will increase your magic capacity.";
			return;
			Block_55:
			Main.npcChatText = "Stars fall all over the world at night. They can be used for all sorts of usefull things. If you see one, be sure to grab it because they disappear after sunrise.";
			return;
			Block_58:
			Main.npcChatText = "There are many different ways you can attract people to move in to our town. They will of course need a home to live in.";
			return;
			Block_59:
			Main.npcChatText = "In order for a room to be considered a home, it needs to have a door, chair, table, and a light source.  Make sure the house has walls as well.";
			return;
			Block_60:
			Main.npcChatText = "Two people will not live in the same home. Also, if their home is destroyed, they will look for a new place to live.";
			return;
			Block_61:
			Main.npcChatText = "You can use the housing interface to assign and view housing. Open you inventory and click the house icon.";
			return;
			Block_63:
			Main.npcChatText = "If you want a merchant to move in, you will need to gather plenty of money. 50 silver coins should do the trick!";
			return;
			Block_65:
			Main.npcChatText = "For a nurse to move in, you might want to increase your maximum life.";
			return;
			Block_67:
			Main.npcChatText = "If you had a gun, I bet an arms dealer might show up to sell you some ammo!";
			return;
			Block_69:
			Main.npcChatText = "You should prove yourself by defeating a strong monster. That will get the attention of a dryad.";
			return;
			Block_72:
			Main.npcChatText = "Make sure to explore the dungeon thoroughly. There may be prisoners held deep within.";
			return;
			Block_75:
			Main.npcChatText = "Perhaps the old man by the dungeon would like to join us now that his curse has been lifted.";
			return;
			Block_77:
			Main.npcChatText = "Hang on to any bombs you might find. A demolitionist may want to have a look at them.";
			return;
			Block_80:
			Main.npcChatText = "Are goblins really so different from us that we couldn't live together peacefully?";
			return;
			Block_83:
			Main.npcChatText = "I heard there was a powerfully wizard who lives in these parts.  Make sure to keep an eye out for him next time you go underground.";
			return;
			Block_85:
			Main.npcChatText = "If you combine lenses at a demon altar, you might be able to find a way to summon a powerful monster. You will want to wait until night before using it, though.";
			return;
			Block_87:
			Main.npcChatText = "You can create worm bait with rotten chunks and vile powder. Make sure you are in a corrupt area before using it.";
			return;
			Block_89:
			Main.npcChatText = "Demonic altars can usually be found in the corruption. You will need to be near them to craft some items.";
			return;
			Block_94:
			Main.npcChatText = "You can make a grappling hook from a hook and 3 chains. Skeletons found deep underground usually carry hooks, and chains can be made from iron bars.";
			return;
			Block_97:
			Main.npcChatText = "If you see a pot, be sure to smash it open. They contain all sorts of useful supplies.";
			return;
			Block_100:
			Main.npcChatText = "There is treasure hidden all over the world. Some amazing things can be found deep underground!";
			return;
			Block_102:
			Main.npcChatText = "Smashing a shadow orb will sometimes cause a meteor to fall out of the sky. Shadow orbs can usually be found in the chasms around corrupt areas.";
			return;
			Block_105:
			Main.npcChatText = "You should focus on gathering more heart crystals to increase your maximum life.";
			return;
			Block_108:
			Main.npcChatText = "Your current equipment simply won't do. You need to make better armor.";
			return;
			Block_112:
			Main.npcChatText = "I think you are ready for your first major battle. Gather some lenses from the eyeballs at night and take them to a demon altar.";
			return;
			Block_116:
			Main.npcChatText = "You wil want to increase your life before facing your next challenge. Fifteen hearts should be enough.";
			return;
			Block_120:
			Main.npcChatText = "The ebonstone in the corruption can be purified using some powder from a dryad, or it can be destroyed with explosives.";
			return;
			Block_124:
			Main.npcChatText = "Your next step should be to explore the corrupt chasms.  Find and destroy any shadow orb you find.";
			return;
			Block_128:
			Main.npcChatText = "There is a old dungeon not far from here. Now would be a good time to go check it out.";
			return;
			Block_134:
			Main.npcChatText = "You should make an attempt to max out your available life. Try to gather twenty hearts.";
			return;
			Block_140:
			Main.npcChatText = "There are many treasures to be discovered in the jungle, if you are willing to dig deep enough.";
			return;
			Block_146:
			Main.npcChatText = "The underworld is made of a material called hellstone. It's perfect for making weapons and armor.";
			return;
			Block_152:
			Main.npcChatText = "When you are ready to challenge the keeper of the underworld, you will have to make a living sacrifice. Everything you need for it can be found in the underworld.";
			return;
			Block_154:
			Main.npcChatText = "Make sure to smash any demon altar you can find. Something good is bound to happen if you do!";
			return;
			Block_156:
			Main.npcChatText = "Souls can sometimes be gathered from fallen creatures in places of extreme light or dark.";
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
			for (int i = 0; i < 20; i++)
			{
				if (Main.player[Main.myPlayer].bank[i].type >= 71 && Main.player[Main.myPlayer].bank[i].type <= 73 && Main.player[Main.myPlayer].bank[i].stack == Main.player[Main.myPlayer].bank[i].maxStack)
				{
					Main.player[Main.myPlayer].bank[i].SetDefaults(Main.player[Main.myPlayer].bank[i].type + 1, false);
					for (int j = 0; j < 20; j++)
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
			for (int i = 0; i < 20; i++)
			{
				if (Main.chest[Main.player[Main.myPlayer].chest].item[i].type >= 71 && Main.chest[Main.player[Main.myPlayer].chest].item[i].type <= 73 && Main.chest[Main.player[Main.myPlayer].chest].item[i].stack == Main.chest[Main.player[Main.myPlayer].chest].item[i].maxStack)
				{
					Main.chest[Main.player[Main.myPlayer].chest].item[i].SetDefaults(Main.chest[Main.player[Main.myPlayer].chest].item[i].type + 1, false);
					for (int j = 0; j < 20; j++)
					{
						if (j != i && Main.chest[Main.player[Main.myPlayer].chest].item[j].type == Main.chest[Main.player[Main.myPlayer].chest].item[i].type && Main.chest[Main.player[Main.myPlayer].chest].item[j].stack < Main.chest[Main.player[Main.myPlayer].chest].item[j].maxStack)
						{
							Main.chest[Main.player[Main.myPlayer].chest].item[j].stack++;
							Main.chest[Main.player[Main.myPlayer].chest].item[i].SetDefaults(0, false);
							Main.ChestCoins();
						}
					}
				}
			}
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
		public static void CursorColor()
		{
			Main.cursorAlpha += (float)Main.cursorColorDirection * 0.015f;
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
			float num = Main.cursorAlpha * 0.3f + 0.7f;
			byte r = (byte)((float)Main.mouseColor.R * Main.cursorAlpha);
			byte g = (byte)((float)Main.mouseColor.G * Main.cursorAlpha);
			byte b = (byte)((float)Main.mouseColor.B * Main.cursorAlpha);
			byte a = (byte)(255f * num);
			Main.cursorColor = new Color((int)r, (int)g, (int)b, (int)a);
			Main.cursorScale = Main.cursorAlpha * 0.3f + 0.7f + 0.1f;
		}
		protected bool FullTile(int x, int y)
		{
			if (Main.tile[x, y].active && Main.tileSolid[(int)Main.tile[x, y].type] && !Main.tileSolidTop[(int)Main.tile[x, y].type] && Main.tile[x, y].type != 10 && Main.tile[x, y].type != 138)
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
		private static void UpdateInvasion()
		{
			if (Main.invasionDefeat)
			{
				Main.invasionDefeat = false;
				for (int i = 0; i < 200; i++)
				{
					if (Main.npc[i].active && ((Main.npc[i].type >= 26 && Main.npc[i].type <= 29) || Main.npc[i].type == 111))
					{
						Main.invasionDefeat = true;
					}
				}
				if (!Main.invasionDefeat)
				{
					Main.InvasionWarning();
					NPC.downedGoblins = true;
					if (Main.netMode == 2)
					{
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
					}
				}
			}
			if (Main.invasionType > 0)
			{
				if (Main.invasionSize <= 0)
				{
					Main.invasionType = 0;
					Main.invasionDelay = 7;
					Main.invasionDefeat = true;
				}
				else
				{
					Main.invasionDefeat = false;
				}
				if (Main.invasionX == (double)Main.spawnTileX)
				{
					return;
				}
				float num = 0.4f;
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
			string text = "";
			if (Main.invasionSize <= 0)
			{
				text = "The goblin army has been defeated!";
			}
			else
			{
				if (Main.invasionX < (double)Main.spawnTileX)
				{
					text = "A goblin army is approaching from the west!";
				}
				else
				{
					if (Main.invasionX > (double)Main.spawnTileX)
					{
						text = "A goblin army is approaching from the east!";
					}
					else
					{
						text = "The goblin army has arrived!";
					}
				}
			}
			if (Main.netMode == 0)
			{
				Main.NewText(text, 175, 75, 255);
				return;
			}
			if (Main.netMode == 2)
			{
				NetMessage.SendData(25, -1, -1, text, 255, 175f, 75f, 255f, 0);
			}
		}
		public static void StartInvasion()
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
					Main.invasionType = 1;
					Main.invasionSize = 80 + 40 * num;
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
			if (Math.IEEERemainder((double)Main.netPlayCounter, 300.0) == 0.0)
			{
				NetMessage.SendData(13, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
			}
			if (Math.IEEERemainder((double)Main.netPlayCounter, 600.0) == 0.0)
			{
				NetMessage.SendData(16, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				NetMessage.SendData(40, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
			}
			if (Netplay.clientSock.active)
			{
				Netplay.clientSock.timeOut++;
				if (!Main.stopTimeOuts && Netplay.clientSock.timeOut > 60 * Main.timeOut)
				{
					Main.statusText = "Connection timed out";
					Netplay.disconnect = true;
				}
			}
			for (int i = 0; i < 200; i++)
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
					if (num >= 200)
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
			for (int j = 0; j < 200; j++)
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
					int sectionX = Netplay.GetSectionX((int)(Main.player[k].position.X / 16f));
					int sectionY = Netplay.GetSectionY((int)(Main.player[k].position.Y / 16f));
					int num3 = 0;
					for (int l = sectionX - 1; l < sectionX + 2; l++)
					{
						for (int m = sectionY - 1; m < sectionY + 2; m++)
						{
							if (l >= 0 && l < Main.maxSectionsX && m >= 0 && m < Main.maxSectionsY && !Netplay.serverSock[k].tileSection[l, m])
							{
								num3++;
							}
						}
					}
					if (num3 > 0)
					{
						int num4 = num3 * 150;
						NetMessage.SendData(9, k, -1, "Receiving tile data", num4, 0f, 0f, 0f, 0);
						Netplay.serverSock[k].statusText2 = "is receiving tile data";
						Netplay.serverSock[k].statusMax += num4;
						for (int n = sectionX - 1; n < sectionX + 2; n++)
						{
							for (int num5 = sectionY - 1; num5 < sectionY + 2; num5++)
							{
								if (n >= 0 && n < Main.maxSectionsX && num5 >= 0 && num5 < Main.maxSectionsY && !Netplay.serverSock[k].tileSection[n, num5])
								{
									NetMessage.SendSection(k, n, num5);
									NetMessage.SendData(11, k, -1, "", n, (float)num5, (float)n, (float)num5, 0);
								}
							}
						}
					}
				}
			}
		}
		public static void NewText(string newText, byte R = 255, byte G = 255, byte B = 255)
		{
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
		private static void UpdateTime()
		{
			Main.time += (double)Main.dayRate;
			if (!Main.dayTime)
			{
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
				if (Main.time > 32400.0)
				{
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
								Main.StartInvasion();
							}
						}
						else
						{
							if (Main.rand.Next(15) == 0)
							{
								Main.StartInvasion();
							}
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
					if (!NPC.downedBoss1 && Main.netMode != 1)
					{
						bool flag = false;
						for (int j = 0; j < 255; j++)
						{
							if (Main.player[j].active && Main.player[j].statLifeMax >= 200 && Main.player[j].statDefense > 10)
							{
								flag = true;
								break;
							}
						}
						if (flag && Main.rand.Next(3) == 0)
						{
							int num = 0;
							for (int k = 0; k < 200; k++)
							{
								if (Main.npc[k].active && Main.npc[k].townNPC)
								{
									num++;
								}
							}
							if (num >= 4)
							{
								WorldGen.spawnEye = true;
								if (Main.netMode == 0)
								{
									Main.NewText("You feel an evil presence watching you...", 50, 255, 130);
								}
								else
								{
									if (Main.netMode == 2)
									{
										NetMessage.SendData(25, -1, -1, "You feel an evil presence watching you...", 255, 50f, 255f, 130f, 0);
									}
								}
							}
						}
					}
					if (!WorldGen.spawnEye && Main.moonPhase != 4 && Main.rand.Next(9) == 0 && Main.netMode != 1)
					{
						for (int l = 0; l < 255; l++)
						{
							if (Main.player[l].active && Main.player[l].statLifeMax > 120)
							{
								Main.bloodMoon = true;
								break;
							}
						}
						if (Main.bloodMoon)
						{
							if (Main.netMode == 0)
							{
								Main.NewText("The Blood Moon is rising...", 50, 255, 130);
							}
							else
							{
								if (Main.netMode == 2)
								{
									NetMessage.SendData(25, -1, -1, "The Blood Moon is rising...", 255, 50f, 255f, 130f, 0);
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
					if (Main.checkForSpawns >= 7200)
					{
						int num2 = 0;
						for (int m = 0; m < 255; m++)
						{
							if (Main.player[m].active)
							{
								num2++;
							}
						}
						Main.checkForSpawns = 0;
						WorldGen.spawnNPC = 0;
						int num3 = 0;
						int num4 = 0;
						int num5 = 0;
						int num6 = 0;
						int num7 = 0;
						int num8 = 0;
						int num9 = 0;
						int num10 = 0;
						int num11 = 0;
						int num12 = 0;
						int num13 = 0;
						int num14 = 0;
						for (int n = 0; n < 200; n++)
						{
							if (Main.npc[n].active && Main.npc[n].townNPC)
							{
								if (Main.npc[n].type != 37 && !Main.npc[n].homeless)
								{
									WorldGen.QuickFindHome(n);
								}
								if (Main.npc[n].type == 37)
								{
									num8++;
								}
								if (Main.npc[n].type == 17)
								{
									num3++;
								}
								if (Main.npc[n].type == 18)
								{
									num4++;
								}
								if (Main.npc[n].type == 19)
								{
									num6++;
								}
								if (Main.npc[n].type == 20)
								{
									num5++;
								}
								if (Main.npc[n].type == 22)
								{
									num7++;
								}
								if (Main.npc[n].type == 38)
								{
									num9++;
								}
								if (Main.npc[n].type == 54)
								{
									num10++;
								}
								if (Main.npc[n].type == 107)
								{
									num12++;
								}
								if (Main.npc[n].type == 108)
								{
									num11++;
								}
								if (Main.npc[n].type == 124)
								{
									num13++;
								}
								num14++;
							}
						}
						if (WorldGen.spawnNPC == 0)
						{
							int num15 = 0;
							bool flag2 = false;
							int num16 = 0;
							bool flag3 = false;
							bool flag4 = false;
							for (int num17 = 0; num17 < 255; num17++)
							{
								if (Main.player[num17].active)
								{
									for (int num18 = 0; num18 < 48; num18++)
									{
										if (Main.player[num17].inventory[num18] != null & Main.player[num17].inventory[num18].stack > 0)
										{
											if (Main.player[num17].inventory[num18].type == 71)
											{
												num15 += Main.player[num17].inventory[num18].stack;
											}
											if (Main.player[num17].inventory[num18].type == 72)
											{
												num15 += Main.player[num17].inventory[num18].stack * 100;
											}
											if (Main.player[num17].inventory[num18].type == 73)
											{
												num15 += Main.player[num17].inventory[num18].stack * 10000;
											}
											if (Main.player[num17].inventory[num18].type == 74)
											{
												num15 += Main.player[num17].inventory[num18].stack * 1000000;
											}
											if (Main.player[num17].inventory[num18].ammo == 14 || Main.player[num17].inventory[num18].useAmmo == 14)
											{
												flag3 = true;
											}
											if (Main.player[num17].inventory[num18].type == 166 || Main.player[num17].inventory[num18].type == 167 || Main.player[num17].inventory[num18].type == 168 || Main.player[num17].inventory[num18].type == 235)
											{
												flag4 = true;
											}
										}
									}
									int num19 = Main.player[num17].statLifeMax / 20;
									if (num19 > 5)
									{
										flag2 = true;
									}
									num16 += num19;
								}
							}
							if (!NPC.downedBoss3 && num8 == 0)
							{
								int num20 = NPC.NewNPC(Main.dungeonX * 16 + 8, Main.dungeonY * 16, 37, 0);
								Main.npc[num20].homeless = false;
								Main.npc[num20].homeTileX = Main.dungeonX;
								Main.npc[num20].homeTileY = Main.dungeonY;
							}
							if (WorldGen.spawnNPC == 0 && num7 < 1)
							{
								WorldGen.spawnNPC = 22;
							}
							if (WorldGen.spawnNPC == 0 && (double)num15 > 5000.0 && num3 < 1)
							{
								WorldGen.spawnNPC = 17;
							}
							if (WorldGen.spawnNPC == 0 && flag2 && num4 < 1)
							{
								WorldGen.spawnNPC = 18;
							}
							if (WorldGen.spawnNPC == 0 && flag3 && num6 < 1)
							{
								WorldGen.spawnNPC = 19;
							}
							if (WorldGen.spawnNPC == 0 && (NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3) && num5 < 1)
							{
								WorldGen.spawnNPC = 20;
							}
							if (WorldGen.spawnNPC == 0 && flag4 && num3 > 0 && num9 < 1)
							{
								WorldGen.spawnNPC = 38;
							}
							if (WorldGen.spawnNPC == 0 && NPC.downedBoss3 && num10 < 1)
							{
								WorldGen.spawnNPC = 54;
							}
							if (WorldGen.spawnNPC == 0 && NPC.savedGoblin && num12 < 1)
							{
								WorldGen.spawnNPC = 107;
							}
							if (WorldGen.spawnNPC == 0 && NPC.savedWizard && num11 < 1)
							{
								WorldGen.spawnNPC = 108;
							}
							if (WorldGen.spawnNPC == 0 && NPC.savedMech && num13 < 1)
							{
								WorldGen.spawnNPC = 124;
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
			int num = Style;
			try
			{
				if (!Main.dedServ)
				{
					if (Main.soundVolume != 0f)
					{
						bool flag = false;
						float num2 = 1f;
						float num3 = 0f;
						if (x == -1 || y == -1)
						{
							flag = true;
						}
						else
						{
							if (WorldGen.gen)
							{
								return;
							}
							if (Main.netMode == 2)
							{
								return;
							}
							Rectangle value = new Rectangle((int)(Main.screenPosition.X - (float)(Main.screenWidth * 2)), (int)(Main.screenPosition.Y - (float)(Main.screenHeight * 2)), Main.screenWidth * 5, Main.screenHeight * 5);
							Rectangle rectangle = new Rectangle(x, y, 1, 1);
							Vector2 vector = new Vector2(Main.screenPosition.X + (float)Main.screenWidth * 0.5f, Main.screenPosition.Y + (float)Main.screenHeight * 0.5f);
							if (rectangle.Intersects(value))
							{
								flag = true;
							}
							if (flag)
							{
								num3 = ((float)x - vector.X) / ((float)Main.screenWidth * 0.5f);
								float num4 = Math.Abs((float)x - vector.X);
								float num5 = Math.Abs((float)y - vector.Y);
								float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
								num2 = 1f - num6 / ((float)Main.screenWidth * 1.5f);
							}
						}
						if (num3 < -1f)
						{
							num3 = -1f;
						}
						if (num3 > 1f)
						{
							num3 = 1f;
						}
						if (num2 > 1f)
						{
							num2 = 1f;
						}
						if (num2 > 0f)
						{
							if (flag)
							{
								num2 *= Main.soundVolume;
								if (type == 0)
								{
									int num7 = Main.rand.Next(3);
									Main.soundInstanceDig[num7].Stop();
									Main.soundInstanceDig[num7] = Main.soundDig[num7].CreateInstance();
									Main.soundInstanceDig[num7].Volume = num2;
									Main.soundInstanceDig[num7].Pan = num3;
									Main.soundInstanceDig[num7].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
									Main.soundInstanceDig[num7].Play();
								}
								else
								{
									if (type == 1)
									{
										int num8 = Main.rand.Next(3);
										Main.soundInstancePlayerHit[num8].Stop();
										Main.soundInstancePlayerHit[num8] = Main.soundPlayerHit[num8].CreateInstance();
										Main.soundInstancePlayerHit[num8].Volume = num2;
										Main.soundInstancePlayerHit[num8].Pan = num3;
										Main.soundInstancePlayerHit[num8].Play();
									}
									else
									{
										if (type == 2)
										{
											if (num == 1)
											{
												int num9 = Main.rand.Next(3);
												if (num9 == 1)
												{
													num = 18;
												}
												if (num9 == 2)
												{
													num = 19;
												}
											}
											if (num != 9 && num != 10 && num != 24 && num != 26 && num != 34)
											{
												Main.soundInstanceItem[num].Stop();
											}
											Main.soundInstanceItem[num] = Main.soundItem[num].CreateInstance();
											Main.soundInstanceItem[num].Volume = num2;
											Main.soundInstanceItem[num].Pan = num3;
											Main.soundInstanceItem[num].Pitch = (float)Main.rand.Next(-6, 7) * 0.01f;
											if (num == 26 || num == 35)
											{
												Main.soundInstanceItem[num].Volume = num2 * 0.75f;
												Main.soundInstanceItem[num].Pitch = Main.harpNote;
											}
											Main.soundInstanceItem[num].Play();
										}
										else
										{
											if (type == 3)
											{
												Main.soundInstanceNPCHit[num].Stop();
												Main.soundInstanceNPCHit[num] = Main.soundNPCHit[num].CreateInstance();
												Main.soundInstanceNPCHit[num].Volume = num2;
												Main.soundInstanceNPCHit[num].Pan = num3;
												Main.soundInstanceNPCHit[num].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
												Main.soundInstanceNPCHit[num].Play();
											}
											else
											{
												if (type == 4)
												{
													if (num != 10 || Main.soundInstanceNPCKilled[num].State != SoundState.Playing)
													{
														Main.soundInstanceNPCKilled[num] = Main.soundNPCKilled[num].CreateInstance();
														Main.soundInstanceNPCKilled[num].Volume = num2;
														Main.soundInstanceNPCKilled[num].Pan = num3;
														Main.soundInstanceNPCKilled[num].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
														Main.soundInstanceNPCKilled[num].Play();
													}
												}
												else
												{
													if (type == 5)
													{
														Main.soundInstancePlayerKilled.Stop();
														Main.soundInstancePlayerKilled = Main.soundPlayerKilled.CreateInstance();
														Main.soundInstancePlayerKilled.Volume = num2;
														Main.soundInstancePlayerKilled.Pan = num3;
														Main.soundInstancePlayerKilled.Play();
													}
													else
													{
														if (type == 6)
														{
															Main.soundInstanceGrass.Stop();
															Main.soundInstanceGrass = Main.soundGrass.CreateInstance();
															Main.soundInstanceGrass.Volume = num2;
															Main.soundInstanceGrass.Pan = num3;
															Main.soundInstanceGrass.Pitch = (float)Main.rand.Next(-30, 31) * 0.01f;
															Main.soundInstanceGrass.Play();
														}
														else
														{
															if (type == 7)
															{
																Main.soundInstanceGrab.Stop();
																Main.soundInstanceGrab = Main.soundGrab.CreateInstance();
																Main.soundInstanceGrab.Volume = num2;
																Main.soundInstanceGrab.Pan = num3;
																Main.soundInstanceGrab.Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
																Main.soundInstanceGrab.Play();
															}
															else
															{
																if (type == 8)
																{
																	Main.soundInstanceDoorOpen.Stop();
																	Main.soundInstanceDoorOpen = Main.soundDoorOpen.CreateInstance();
																	Main.soundInstanceDoorOpen.Volume = num2;
																	Main.soundInstanceDoorOpen.Pan = num3;
																	Main.soundInstanceDoorOpen.Pitch = (float)Main.rand.Next(-20, 21) * 0.01f;
																	Main.soundInstanceDoorOpen.Play();
																}
																else
																{
																	if (type == 9)
																	{
																		Main.soundInstanceDoorClosed.Stop();
																		Main.soundInstanceDoorClosed = Main.soundDoorClosed.CreateInstance();
																		Main.soundInstanceDoorClosed.Volume = num2;
																		Main.soundInstanceDoorClosed.Pan = num3;
																		Main.soundInstanceDoorOpen.Pitch = (float)Main.rand.Next(-20, 21) * 0.01f;
																		Main.soundInstanceDoorClosed.Play();
																	}
																	else
																	{
																		if (type == 10)
																		{
																			Main.soundInstanceMenuOpen.Stop();
																			Main.soundInstanceMenuOpen = Main.soundMenuOpen.CreateInstance();
																			Main.soundInstanceMenuOpen.Volume = num2;
																			Main.soundInstanceMenuOpen.Pan = num3;
																			Main.soundInstanceMenuOpen.Play();
																		}
																		else
																		{
																			if (type == 11)
																			{
																				Main.soundInstanceMenuClose.Stop();
																				Main.soundInstanceMenuClose = Main.soundMenuClose.CreateInstance();
																				Main.soundInstanceMenuClose.Volume = num2;
																				Main.soundInstanceMenuClose.Pan = num3;
																				Main.soundInstanceMenuClose.Play();
																			}
																			else
																			{
																				if (type == 12)
																				{
																					Main.soundInstanceMenuTick.Stop();
																					Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
																					Main.soundInstanceMenuTick.Volume = num2;
																					Main.soundInstanceMenuTick.Pan = num3;
																					Main.soundInstanceMenuTick.Play();
																				}
																				else
																				{
																					if (type == 13)
																					{
																						Main.soundInstanceShatter.Stop();
																						Main.soundInstanceShatter = Main.soundShatter.CreateInstance();
																						Main.soundInstanceShatter.Volume = num2;
																						Main.soundInstanceShatter.Pan = num3;
																						Main.soundInstanceShatter.Play();
																					}
																					else
																					{
																						if (type == 14)
																						{
																							int num10 = Main.rand.Next(3);
																							Main.soundInstanceZombie[num10] = Main.soundZombie[num10].CreateInstance();
																							Main.soundInstanceZombie[num10].Volume = num2 * 0.4f;
																							Main.soundInstanceZombie[num10].Pan = num3;
																							Main.soundInstanceZombie[num10].Play();
																						}
																						else
																						{
																							if (type == 15)
																							{
																								if (Main.soundInstanceRoar[num].State == SoundState.Stopped)
																								{
																									Main.soundInstanceRoar[num] = Main.soundRoar[num].CreateInstance();
																									Main.soundInstanceRoar[num].Volume = num2;
																									Main.soundInstanceRoar[num].Pan = num3;
																									Main.soundInstanceRoar[num].Play();
																								}
																							}
																							else
																							{
																								if (type == 16)
																								{
																									Main.soundInstanceDoubleJump.Stop();
																									Main.soundInstanceDoubleJump = Main.soundDoubleJump.CreateInstance();
																									Main.soundInstanceDoubleJump.Volume = num2;
																									Main.soundInstanceDoubleJump.Pan = num3;
																									Main.soundInstanceDoubleJump.Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
																									Main.soundInstanceDoubleJump.Play();
																								}
																								else
																								{
																									if (type == 17)
																									{
																										Main.soundInstanceRun.Stop();
																										Main.soundInstanceRun = Main.soundRun.CreateInstance();
																										Main.soundInstanceRun.Volume = num2;
																										Main.soundInstanceRun.Pan = num3;
																										Main.soundInstanceRun.Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
																										Main.soundInstanceRun.Play();
																									}
																									else
																									{
																										if (type == 18)
																										{
																											Main.soundInstanceCoins = Main.soundCoins.CreateInstance();
																											Main.soundInstanceCoins.Volume = num2;
																											Main.soundInstanceCoins.Pan = num3;
																											Main.soundInstanceCoins.Play();
																										}
																										else
																										{
																											if (type == 19)
																											{
																												if (Main.soundInstanceSplash[num].State == SoundState.Stopped)
																												{
																													Main.soundInstanceSplash[num] = Main.soundSplash[num].CreateInstance();
																													Main.soundInstanceSplash[num].Volume = num2;
																													Main.soundInstanceSplash[num].Pan = num3;
																													Main.soundInstanceSplash[num].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
																													Main.soundInstanceSplash[num].Play();
																												}
																											}
																											else
																											{
																												if (type == 20)
																												{
																													int num11 = Main.rand.Next(3);
																													Main.soundInstanceFemaleHit[num11].Stop();
																													Main.soundInstanceFemaleHit[num11] = Main.soundFemaleHit[num11].CreateInstance();
																													Main.soundInstanceFemaleHit[num11].Volume = num2;
																													Main.soundInstanceFemaleHit[num11].Pan = num3;
																													Main.soundInstanceFemaleHit[num11].Play();
																												}
																												else
																												{
																													if (type == 21)
																													{
																														int num12 = Main.rand.Next(3);
																														Main.soundInstanceTink[num12].Stop();
																														Main.soundInstanceTink[num12] = Main.soundTink[num12].CreateInstance();
																														Main.soundInstanceTink[num12].Volume = num2;
																														Main.soundInstanceTink[num12].Pan = num3;
																														Main.soundInstanceTink[num12].Play();
																													}
																													else
																													{
																														if (type == 22)
																														{
																															Main.soundInstanceUnlock.Stop();
																															Main.soundInstanceUnlock = Main.soundUnlock.CreateInstance();
																															Main.soundInstanceUnlock.Volume = num2;
																															Main.soundInstanceUnlock.Pan = num3;
																															Main.soundInstanceUnlock.Play();
																														}
																														else
																														{
																															if (type == 23)
																															{
																																Main.soundInstanceDrown.Stop();
																																Main.soundInstanceDrown = Main.soundDrown.CreateInstance();
																																Main.soundInstanceDrown.Volume = num2;
																																Main.soundInstanceDrown.Pan = num3;
																																Main.soundInstanceDrown.Play();
																															}
																															else
																															{
																																if (type == 24)
																																{
																																	Main.soundInstanceChat = Main.soundChat.CreateInstance();
																																	Main.soundInstanceChat.Volume = num2;
																																	Main.soundInstanceChat.Pan = num3;
																																	Main.soundInstanceChat.Play();
																																}
																																else
																																{
																																	if (type == 25)
																																	{
																																		Main.soundInstanceMaxMana = Main.soundMaxMana.CreateInstance();
																																		Main.soundInstanceMaxMana.Volume = num2;
																																		Main.soundInstanceMaxMana.Pan = num3;
																																		Main.soundInstanceMaxMana.Play();
																																	}
																																	else
																																	{
																																		if (type == 26)
																																		{
																																			int num13 = Main.rand.Next(3, 5);
																																			Main.soundInstanceZombie[num13] = Main.soundZombie[num13].CreateInstance();
																																			Main.soundInstanceZombie[num13].Volume = num2 * 0.9f;
																																			Main.soundInstanceZombie[num13].Pan = num3;
																																			Main.soundInstanceSplash[num].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
																																			Main.soundInstanceZombie[num13].Play();
																																		}
																																		else
																																		{
																																			if (type == 27)
																																			{
																																				if (Main.soundInstancePixie.State == SoundState.Playing)
																																				{
																																					Main.soundInstancePixie.Volume = num2;
																																					Main.soundInstancePixie.Pan = num3;
																																					Main.soundInstancePixie.Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
																																				}
																																				else
																																				{
																																					Main.soundInstancePixie.Stop();
																																					Main.soundInstancePixie = Main.soundPixie.CreateInstance();
																																					Main.soundInstancePixie.Volume = num2;
																																					Main.soundInstancePixie.Pan = num3;
																																					Main.soundInstancePixie.Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
																																					Main.soundInstancePixie.Play();
																																				}
																																			}
																																			else
																																			{
																																				if (type == 28)
																																				{
																																					if (Main.soundInstanceMech[num].State != SoundState.Playing)
																																					{
																																						Main.soundInstanceMech[num] = Main.soundMech[num].CreateInstance();
																																						Main.soundInstanceMech[num].Volume = num2;
																																						Main.soundInstanceMech[num].Pan = num3;
																																						Main.soundInstanceMech[num].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
																																						Main.soundInstanceMech[num].Play();
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
			catch
			{
			}
		}
	}
}
