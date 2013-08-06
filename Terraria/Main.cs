using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using ServerApi;

namespace Terraria
{
    public class Main
    {
        public static int curRelease = 39;
        public static string versionNumber = "v1.1.2";
        public static string versionNumber2 = "v1.1.2";
        public static bool skipMenu = false;
        public static bool verboseNetplay = false;
        public static bool stopTimeOuts = false;
        public static bool showSpam = false;
        public static bool showItemOwner = false;
        public static int oldTempLightCount = 0;
        public static int musicBox = -1;
        public static int musicBox2 = -1;
        public static bool cEd = false;
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
        public static float essScale = 1f;
        public static int essDir = -1;
        public static string debugWords = "";
        public static bool gamePad = false;
        public static bool xMas = false;
        public static int snowDust = 0;
        public static bool chTitle = false;
        public static int keyCount = 0;
        public static string[] keyString = new string[10];
        public static int[] keyInt = new int[10];
        public static bool netDiag = false;
        public static int txData = 0;
        public static int rxData = 0;
        public static int txMsg = 0;
        public static int rxMsg = 0;
        public static int maxMsg = 62;
        public static int[] rxMsgType = new int[Main.maxMsg];
        public static int[] rxDataType = new int[Main.maxMsg];
        public static int[] txMsgType = new int[Main.maxMsg];
        public static int[] txDataType = new int[Main.maxMsg];
        public static float uCarry = 0.0f;
        public static bool drawSkip = false;
        public static int fpsCount = 0;
        public static Stopwatch fpsTimer = new Stopwatch();
        public static Stopwatch updateTimer = new Stopwatch();
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
        public static float harpNote = 0.0f;
        public static bool[] projHostile = new bool[112];
        public static bool[] pvpBuff = new bool[41];
        public static bool[] debuff = new bool[41];
        public static string[] buffName = new string[41];
        public static string[] buffTip = new string[41];
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
        public static int wof = -1;
        public static int wofF = 0;
        private static int offScreenRange = 200;
        public static int renderCount = 99;
        private static Stopwatch saveTime = new Stopwatch();
        public static bool mouseHC = false;
        public static string chestText = "Chest";
        public static bool craftingHide = false;
        public static bool armorHide = false;
        public static float craftingAlpha = 1f;
        public static float armorAlpha = 1f;
        public static float[] buffAlpha = new float[41];
        public static Item trashItem = new Item();
        public static bool hardMode = false;
        public static bool drawScene = false;
        public static Vector2 sceneWaterPos = new Vector2();
        public static Vector2 sceneTilePos = new Vector2();
        public static Vector2 sceneTile2Pos = new Vector2();
        public static Vector2 sceneWallPos = new Vector2();
        public static Vector2 sceneBackgroundPos = new Vector2();
        public static bool maxQ = true;
        public static float gfxQuality = 1f;
        public static float gfxRate = 0.01f;
        public static int DiscoR = (int) byte.MaxValue;
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
        public static float leftWorld = 0.0f;
        public static float rightWorld = 134400f;
        public static float topWorld = 0.0f;
        public static float bottomWorld = 38400f;
        public static int maxTilesX = (int) Main.rightWorld/16 + 1;
        public static int maxTilesY = (int) Main.bottomWorld/16 + 1;
        public static int maxSectionsX = Main.maxTilesX/200;
        public static int maxSectionsY = Main.maxTilesY/150;
        public static int numDust = 2000;
        public static int maxNetPlayers = (int) byte.MaxValue;
        public static string[] chrName = new string[147];
        public static int worldRate = 1;
        public static float caveParrallax = 1f;
        public static string[] tileName = new string[150];
        public static Liquid[] liquid = new Liquid[Liquid.resLiquid];
        public static LiquidBuffer[] liquidBuffer = new LiquidBuffer[10000];
        public static bool dedServ = false;
        public static int spamCount = 0;
        public static int curMusic = 0;
        public static bool showItemText = true;
        public static bool autoSave = true;
        public static string buffString = "";
        public static string libPath = "";
        public static int lo = 0;
        public static int LogoA = (int) byte.MaxValue;
        public static int LogoB = 0;
        public static bool LogoT = false;
        public static string statusText = "";
        public static string worldName = "";
        public static int background = 0;
        public static bool dayTime = true;
        public static double time = 13500.0;
        public static int moonPhase = 0;
        public static short sunModY = (short) 0;
        public static short moonModY = (short) 0;
        public static bool grabSky = false;
        public static bool bloodMoon = false;
        public static int checkForSpawns = 0;
        public static int helpText = 0;
        public static bool autoGen = false;
        public static bool autoPause = false;
        public static int[] projFrames = new int[112];
        public static float demonTorch = 1f;
        public static int demonTorchDir = 1;
        public static int cloudLimit = 100;
        public static int numClouds = Main.cloudLimit;
        public static float windSpeed = 0.0f;
        public static float windSpeedSpeed = 0.0f;
        public static Cloud[] cloud = new Cloud[100];
        public static bool resetClouds = true;
        public static int fadeCounter = 0;
        public static float invAlpha = 1f;
        public static float invDir = 1f;
        public static float[] musicFade = new float[14];
        public static float musicVolume = 0.75f;
        public static float soundVolume = 1f;
        public static bool[] tileLighted = new bool[150];
        public static bool[] tileMergeDirt = new bool[150];
        public static bool[] tileCut = new bool[150];
        public static bool[] tileAlch = new bool[150];
        public static int[] tileShine = new int[150];
        public static bool[] tileShine2 = new bool[150];
        public static bool[] wallHouse = new bool[32];
        public static int[] wallBlend = new int[32];
        public static bool[] tileStone = new bool[150];
        public static bool[] tilePick = new bool[150];
        public static bool[] tileAxe = new bool[150];
        public static bool[] tileHammer = new bool[150];
        public static bool[] tileWaterDeath = new bool[150];
        public static bool[] tileLavaDeath = new bool[150];
        public static bool[] tileTable = new bool[150];
        public static bool[] tileBlockLight = new bool[150];
        public static bool[] tileNoSunLight = new bool[150];
        public static bool[] tileDungeon = new bool[150];
        public static bool[] tileSolidTop = new bool[150];
        public static bool[] tileSolid = new bool[150];
        public static bool[] tileNoAttach = new bool[150];
        public static bool[] tileNoFail = new bool[150];
        public static bool[] tileFrameImportant = new bool[150];
        public static int[] backgroundWidth = new int[32];
        public static int[] backgroundHeight = new int[32];
        public static bool tilesLoaded = false;
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
        public static int screenWidth = 800;
        public static int screenHeight = 600;
        public static int chatLength = 600;
        public static bool chatMode = false;
        public static bool chatRelease = false;
        public static int numChatLines = 7;
        public static string chatText = "";
        public static ChatLine[] chatLine = new ChatLine[Main.numChatLines];
        public static bool inputTextEnter = false;

        public static float[] hotbarScale = new float[10]
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

        public static byte mouseTextColor = (byte) 0;
        public static int mouseTextColorChange = 1;
        public static bool mouseLeftRelease = false;
        public static bool mouseRightRelease = false;
        public static bool playerInventory = false;
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
        public static int myPlayer = 0;
        public static Player[] player = new Player[256];
        public static bool npcChatRelease = false;
        public static bool editSign = false;
        public static string signText = "";
        public static string npcChatText = "";
        public static bool npcChatFocus1 = false;
        public static bool npcChatFocus2 = false;
        public static bool npcChatFocus3 = false;
        public static int npcShop = 0;
        public static bool craftGuide = false;
        public static bool reforge = false;
        private static Item toolTip = new Item();
        private static int backSpaceCount = 0;
        public static string motd = "";
        public static bool gameMenu = true;
        public static Player[] loadPlayer = new Player[5];
        public static string[] loadPlayerPath = new string[5];
        private static int numLoadPlayers = 0;
        public static string[] loadWorld = new string[999];
        public static string[] loadWorldPath = new string[999];
        private static int numLoadWorlds = 0;
        public static string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + Path.DirectorySeparatorChar + "My Games" + Path.DirectorySeparatorChar + "Terraria";
        public static string WorldPath = Main.SavePath + (object) Path.DirectorySeparatorChar + "Worlds";
            public static string PlayerPath = Main.SavePath + (object) Path.DirectorySeparatorChar + "Players";
        public static string[] itemName = new string[604];
        public static string[] npcName = new string[147];
        public static int invasionType = 0;
        public static double invasionX = 0.0;
        public static int invasionSize = 0;
        public static int invasionDelay = 0;
        public static int invasionWarn = 0;

        public static int[] npcFrameCount = new int[147]
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
                                                    3,
                                                    16,
                                                    4,
                                                    5,
                                                    7,
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
        public static int cursorColorDirection = 1;
        public static float cursorAlpha = 0.0f;
        public static float cursorScale = 0.0f;
        public static bool signBubble = false;
        public static int signX = 0;
        public static int signY = 0;
        public static bool hideUI = false;
        public static bool releaseUI = false;
        public static bool fixedTiming = false;
        public static string oldStatusText = "";
        public static bool autoShutdown = false;
        private static int maxMenuItems = 14;
        public static int menuMode = 0;
        private static Item cpItem = new Item();
        public static string newWorldName = "";
        private static int accSlotCount = 0;
        public static bool autoPass = false;
        public static int menuFocus = 0;
        public int mouseNPC = -1;
        private Process tServer = new Process();
        public float chestLootScale = 1f;
        public float chestStackScale = 1f;
        public float chestDepositScale = 1f;
        public Chest[] shop = new Chest[10];
        private int[] displayWidth = new int[99];
        private int[] displayHeight = new int[99];
        private float logoRotationDirection = 1f;
        private float logoRotationSpeed = 1f;
        private float logoScale = 1f;
        private float logoScaleDirection = 1f;
        private float logoScaleSpeed = 1f;
        private float[] menuItemScale = new float[Main.maxMenuItems];
        private int focusMenu = -1;
        private int selectedMenu = -1;
        private int selectedMenu2 = -1;
        private int setKey = -1;
        private const int MF_BYPOSITION = 1024;
        public const int sectionWidth = 200;
        public const int sectionHeight = 150;
        public const int maxTileSets = 150;
        public const int maxWallTypes = 32;
        public const int maxBackgrounds = 32;
        public const int maxDust = 2000;
        public const int maxCombatText = 100;
        public const int maxItemText = 20;
        public const int maxPlayers = 255;
        public const int maxChests = 1000;
        public const int maxItemTypes = 604;
        public const int maxItems = 200;
        public const int maxBuffs = 41;
        public const int maxProjectileTypes = 112;
        public const int maxProjectiles = 1000;
        public const int maxNPCTypes = 147;
        public const int maxNPCs = 200;
        public const int maxGoreTypes = 160;
        public const int maxGore = 200;
        public const int maxInventory = 48;
        public const int maxItemSounds = 37;
        public const int maxNPCHitSounds = 11;
        public const int maxNPCKilledSounds = 15;
        public const int maxLiquidTypes = 2;
        public const int maxMusic = 14;
        public const int numArmorHead = 45;
        public const int numArmorBody = 26;
        public const int numArmorLegs = 25;
        public const double dayLength = 54000.0;
        public const double nightLength = 32400.0;
        public const int maxStars = 130;
        public const int maxStarTypes = 5;
        public const int maxClouds = 100;
        public const int maxCloudTypes = 4;
        public const int maxHair = 36;
        public static float upTimer;
        public static float upTimerMax;
        public static float upTimerMaxDelay;
        public static int mouseX;
        public static int mouseY;
        public static bool mouseLeft;
        public static bool mouseRight;
        public bool gammaTest;
        public bool showNPCs;
        public static int wofT;
        public static int wofB;
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
        public bool chestLootHover;
        public bool chestStackHover;
        public bool chestDepositHover;
        public int DiscoStyle;
        public static int dungeonX;
        public static int dungeonY;
        public int newMusic;
        public static int worldID;
        public static double worldSurface;
        public static double rockLayer;
        public static int numStars;
        public static int sandTiles;
        public static int evilTiles;
        public static int snowTiles;
        public static int holyTiles;
        public static int meteorTiles;
        public static int jungleTiles;
        public static int dungeonTiles;
        [ThreadStatic] public static Random rand;
        public static Vector2 screenPosition;
        public static Vector2 screenLastPosition;
        public static int stackSplit;
        public static int numAvailableRecipes;
        public static int focusRecipe;
        public static int spawnTileX;
        public static int spawnTileY;
        public bool toggleFullscreen;
        private int numDisplayModes;
        public static string playerPathName;
        public static string worldPathName;
        public static int netPlayCounter;
        public static int lastNPCUpdate;
        public static int lastItemUpdate;
        private int splashCounter;
        private float logoRotation;
        private int selectedPlayer;
        private int selectedWorld;
        private int textBlinkerCount;
        private int textBlinkerState;
        private int focusColor;
        private int colorDelay;
        private int bgScroll;
        public static Color mcColor = new Color(125, 125, 255);
        public static Color hcColor = new Color(200, 125, 255);
        public static Color[] teamColor = new Color[5];
        public static Color mouseColor = new Color(255, 50, 95);
        public static Color cursorColor = Color.White;
        public static Color tileColor;
        public static bool runningMono = false;
        public static bool forceUpdate = false;

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
            while (File.Exists(Path.Combine(
                Main.PlayerPath,
                "player" +
                    num.ToString() +
                        ".plr")))
            {
                num++;
            }
            return Path.Combine(
                Main.PlayerPath,
                "player" +
                    num.ToString() +
                        ".plr");
        }

        private static string nextLoadWorld()
        {
            int num = 1;
            while (File.Exists(Path.Combine(
                Main.WorldPath,
                "world" + num.ToString() + ".wld")))
            {
                num++;
            }
            return Path.Combine(
                Main.WorldPath,
                "world" + num.ToString() + ".wld");
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
                            if (text.Length > 11 && text.Substring(0, 9).ToLower() == "priority=")
                            {
                                string value3 = text.Substring(9);
                                try
                                {
                                    int num2 = Convert.ToInt32(value3);
                                    if (num2 >= 0 && num2 <= 5)
                                    {
                                        Process currentProcess = Process.GetCurrentProcess();
                                        switch (num2)
                                        {
                                            case 0:
                                                currentProcess.PriorityClass = ProcessPriorityClass.RealTime;
                                                break;
                                            case 1:
                                                currentProcess.PriorityClass = ProcessPriorityClass.High;
                                                break;
                                            case 2:
                                                currentProcess.PriorityClass = ProcessPriorityClass.AboveNormal;
                                                break;
                                            case 3:
                                                currentProcess.PriorityClass = ProcessPriorityClass.Normal;
                                                break;
                                            case 4:
                                                currentProcess.PriorityClass = ProcessPriorityClass.BelowNormal;
                                                break;
                                            case 5:
                                                currentProcess.PriorityClass = ProcessPriorityClass.Idle;
                                                break;
                                        }
                                    }
                                }
                                catch
                                {
                                }
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
                            if (text.Length > 11 && text.Substring(0, 11).ToLower() == "autocreate=")
                            {
                                string a = text.Substring(11);
                                switch (a)
                                {
                                    case "0":
                                        Main.autoGen = false;
                                        break;
                                    case "1":
                                        Main.maxTilesX = 4200;
                                        Main.maxTilesY = 1200;
                                        Main.autoGen = true;
                                        break;
                                    case "2":
                                        Main.maxTilesX = 6300;
                                        Main.maxTilesY = 1800;
                                        Main.autoGen = true;
                                        break;
                                    case "3":
                                        Main.maxTilesX = 8400;
                                        Main.maxTilesY = 2400;
                                        Main.autoGen = true;
                                        break;
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

        public void SetWorld(string world)
        {
            Main.worldPathName = world;
        }

        public void SetWorldName(string world)
        {
            Main.worldName = world;
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
            Type t = Type.GetType("Mono.Runtime");
            Main.runningMono = (t != null);
            PluginApi.Hooks.InvokeGameInitialize();
            Main.rand = new Random();
            Console.Title = "Terraria Server " + Main.versionNumber2;
            Main.dedServ = true;
            Main.showSplash = false;
            this.Initialize();
            Lang.setLang();
            for (int i = 0; i < 147; i++)
            {
                NPC nPC = new NPC();
                nPC.SetDefaults(i, -1f);
                Main.npcName[i] = nPC.name;
            }
            PluginApi.Profiler.EndMeasureServerInitTime();
            while (Main.worldPathName == null || Main.worldPathName == "")
            {
                Main.LoadWorlds();
                bool flag = true;
                while (flag)
                {
                    //Console.WriteLine("Terraria Server " + Main.versionNumber2);
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
            Console.WriteLine("Listening on {0}:{1}",
                Netplay.serverListenIP != System.Net.IPAddress.Any ? Netplay.serverListenIP.ToString() : "*", Netplay.serverPort);
            Console.WriteLine("Type 'help' for a list of commands.");
            Console.WriteLine("");
            Console.Title = "Terraria Server: " + Main.worldName;
            Stopwatch stopwatch = new Stopwatch();
            if (!Main.autoShutdown)
            {
                Main.startDedInput();
            }
            PluginApi.Hooks.InvokeGamePostInitialize();
            stopwatch.Start();
            double num6 = 16.666666666666668;
            double num7 = 0.0;
            int num8 = 0;
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            while (!Netplay.disconnect)
            {
                double num9 = (double) stopwatch.ElapsedMilliseconds;
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
                    if (Netplay.anyClients || Main.forceUpdate)
                    {
                        Stopwatch updateWatch = new Stopwatch();
                        updateWatch.Start();

                        PluginApi.Hooks.InvokeGameUpdate();
                        this.Update();
                        PluginApi.Hooks.InvokeGamePostUpdate();

                        updateWatch.Stop();
                        PluginApi.Profiler.InputServerGameUpdateTime(updateWatch.Elapsed);
                    }
                    double num10 = (double) stopwatch.ElapsedMilliseconds + num7;
                    if (num10 < num6)
                    {
                        int num11 = (int) (num6 - num10) - 1;
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
                if (!PluginApi.Hooks.InvokeServerCommand(text))
                {
                    string text2 = text;
                    text = text.ToLower();
                    try
                    {
                        switch (text)
                        {
                            case "help":
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
                                Console.WriteLine(string.Concat(new object[]
                                                                    {
                                                                        "reload",
                                                                        '\t',
                                                                        '\t',
                                                                        " Reloads plugins."
                                                                    }));
                                break;
                            case "settle":
                                if (!Liquid.panicMode)
                                {
                                    Liquid.StartPanic();
                                }
                                else
                                {
                                    Console.WriteLine("Water is already settling");
                                }
                                break;
                            case "dawn":
                                Main.dayTime = true;
                                Main.time = 0.0;
                                NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                                break;
                            case "dusk":
                                Main.dayTime = false;
                                Main.time = 0.0;
                                NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                                break;
                            case "noon":
                                Main.dayTime = true;
                                Main.time = 27000.0;
                                NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                                break;
                            case "midnight":
                                Main.dayTime = false;
                                Main.time = 16200.0;
                                NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                                break;
                            case "exit-nosave":
                                Netplay.disconnect = true;
                                break;
                            case "exit":
                                WorldGen.saveWorld(false);
                                Netplay.disconnect = true;
                                break;
                            case "save":
                                WorldGen.saveWorld(false);
                                break;
                            case "time":
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
                                break;
                            case "maxplayers":
                                Console.WriteLine("Player limit: " + Main.maxNetPlayers);
                                break;
                            case "port":
                                Console.WriteLine("Port: " + Netplay.serverPort);
                                break;
                            case "version":
                                Console.WriteLine("Terraria Server " + Main.versionNumber);
                                break;
                            case "reload":
                                Console.WriteLine("Reloading plugins");
                                try
                                {
                                    ProgramServer.ReloadPlugins();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex);
                                }
                                break;
                            default:
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
                                break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Invalid command.");
                    }
                }
            }
        }

        protected void Initialize()
        {
            NPC.clrNames();
            NPC.setNames();
            Main.bgAlpha[0] = 1f;
            Main.bgAlpha2[0] = 1f;
            for (int index = 0; index < 112; ++index)
                Main.projFrames[index] = 1;
            Main.projFrames[72] = 4;
            Main.projFrames[86] = 4;
            Main.projFrames[87] = 4;
            Main.projFrames[102] = 2;
            Main.projFrames[111] = 8;
            Main.pvpBuff[20] = true;
            Main.pvpBuff[24] = true;
            Main.pvpBuff[31] = true;
            Main.pvpBuff[39] = true;
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
            for (int index = 0; index < 10; ++index)
            {
                Main.recentWorld[index] = "";
                Main.recentIP[index] = "";
                Main.recentPort[index] = 0;
            }
            if (Main.rand == null)
                Main.rand = new Random((int)DateTime.Now.Ticks);
            if (WorldGen.genRand == null)
                WorldGen.genRand = new Random((int)DateTime.Now.Ticks);
            this.SetTitle();
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
            Main.tileLighted[149] = true;
            Main.tileFrameImportant[149] = true;
            Main.tileHammer[149] = true;
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
            Main.tileBlockLight[145] = true;
            Main.tileSolid[145] = true;
            Main.tileMergeDirt[145] = true;
            Main.tileBlockLight[146] = true;
            Main.tileSolid[146] = true;
            Main.tileMergeDirt[146] = true;
            Main.tileBlockLight[147] = true;
            Main.tileSolid[147] = true;
            Main.tileMergeDirt[147] = true;
            Main.tileBlockLight[148] = true;
            Main.tileSolid[148] = true;
            Main.tileMergeDirt[148] = true;
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
            Main.tileSolid[(int)sbyte.MaxValue] = true;
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
            Main.wallHouse[29] = true;
            Main.wallHouse[30] = true;
            Main.wallHouse[31] = true;
            for (int index = 0; index < 32; ++index)
                Main.wallBlend[index] = index != 20 ? (index != 19 ? (index != 18 ? (index != 17 ? (index != 16 ? index : 2) : 7) : 8) : 9) : 14;
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
            for (int index = 0; index < 150; ++index)
            {
                Main.tileName[index] = "";
                if (Main.tileSolid[index])
                    Main.tileNoSunLight[index] = true;
            }
            Main.tileNoSunLight[19] = false;
            Main.tileNoSunLight[11] = true;
            for (int index = 0; index < Main.maxMenuItems; ++index)
                this.menuItemScale[index] = 0.8f;
            for (int index = 0; index < 2001; ++index)
                Main.dust[index] = new Dust();
            for (int index = 0; index < 201; ++index)
                Main.item[index] = new Item();
            for (int index = 0; index < 201; ++index)
            {
                Main.npc[index] = new NPC();
                Main.npc[index].whoAmI = index;
            }
            for (int index = 0; index < 256; ++index)
                Main.player[index] = new Player();
            for (int index = 0; index < 1001; ++index)
                Main.projectile[index] = new Projectile();
            for (int index = 0; index < 201; ++index)
                Main.gore[index] = new Gore();
            for (int index = 0; index < 100; ++index)
                Main.cloud[index] = new Cloud();
            for (int index = 0; index < 100; ++index)
                Main.combatText[index] = new CombatText();
            for (int index = 0; index < 20; ++index)
                Main.itemText[index] = new ItemText();
            var orilang = Lang.lang;
            Lang.lang = 1;
            for (int Type = 0; Type < 604; ++Type)
            {
                Item obj = new Item();
                obj.SetDefaults(Type, false);
                Main.itemName[Type] = obj.name;
                if (obj.headSlot > 0)
                    Item.headType[obj.headSlot] = obj.type;
                if (obj.bodySlot > 0)
                    Item.bodyType[obj.bodySlot] = obj.type;
                if (obj.legSlot > 0)
                    Item.legType[obj.legSlot] = obj.type;
            }
            Lang.lang = orilang;
            for (int index = 0; index < Recipe.maxRecipes; ++index)
            {
                Main.recipe[index] = new Recipe();
                Main.availableRecipeY[index] = (float)(65 * index);
            }
            Recipe.SetupRecipes();
            for (int index = 0; index < Main.numChatLines; ++index)
                Main.chatLine[index] = new ChatLine();
            for (int index = 0; index < Liquid.resLiquid; ++index)
                Main.liquid[index] = new Liquid();
            for (int index = 0; index < 10000; ++index)
                Main.liquidBuffer[index] = new LiquidBuffer();
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
            this.shop[9] = new Chest();
            this.shop[9].SetupShop(9);
            Main.teamColor[0] = Color.White;
            Main.teamColor[1] = new Color(230, 40, 20);
            Main.teamColor[2] = new Color(20, 200, 30);
            Main.teamColor[3] = new Color(75, 90, (int)byte.MaxValue);
            Main.teamColor[4] = new Color(200, 180, 0);
            if (Main.menuMode == 1)
                Main.LoadPlayers();
            for (int Type = 1; Type < 112; ++Type)
            {
                Projectile projectile = new Projectile();
                projectile.SetDefaults(Type);
                if (projectile.hostile)
                    Main.projHostile[Type] = true;
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
        }

        public static void checkXMas()
        {
            DateTime now = DateTime.Now;
            int day = now.Day;
            int month = now.Month;
            bool xmas = ((day >= 15) && (month == 12));

            PluginApi.Hooks.InvokeWorldChristmasCheck(ref xmas);
            Main.xMas = xmas;
        }

        protected void Update()
        {
            if (Main.chTitle)
            {
                Main.chTitle = false;
                this.SetTitle();
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            WorldGen.destroyObject = false;
            Main.gamePaused = false;
            int n = 0;
            while (n < 255)
            {
                if (Main.ignoreErrors)
                {
                    try
                    {
                        Main.player[n].UpdatePlayer(n);
                        goto IL_15A6;
                    }
                    catch
                    {
                        goto IL_15A6;
                    }
                    goto IL_1597;
                }
                goto IL_1597;
                IL_15A6:
                n++;
                continue;
                IL_1597:
                Main.player[n].UpdatePlayer(n);
                goto IL_15A6;
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
                        goto IL_1656;
                    }
                    catch (Exception)
                    {
                        Main.npc[num8] = new NPC();
                        goto IL_1656;
                    }
                    goto IL_1647;
                }
                goto IL_1647;
                IL_1656:
                num8++;
                continue;
                IL_1647:
                Main.npc[num8].UpdateNPC(num8);
                goto IL_1656;
            }
            int num9 = 0;
            while (num9 < 200)
            {
                if (Main.ignoreErrors)
                {
                    try
                    {
                        Main.gore[num9].Update();
                        goto IL_169D;
                    }
                    catch
                    {
                        Main.gore[num9] = new Gore();
                        goto IL_169D;
                    }
                    goto IL_1690;
                }
                goto IL_1690;
                IL_169D:
                num9++;
                continue;
                IL_1690:
                Main.gore[num9].Update();
                goto IL_169D;
            }
            int num10 = 0;
            while (num10 < 1000)
            {
                if (Main.ignoreErrors)
                {
                    try
                    {
                        Main.projectile[num10].Update(num10);
                        goto IL_16E8;
                    }
                    catch
                    {
                        Main.projectile[num10] = new Projectile();
                        goto IL_16E8;
                    }
                    goto IL_16D9;
                }
                goto IL_16D9;
                IL_16E8:
                num10++;
                continue;
                IL_16D9:
                Main.projectile[num10].Update(num10);
                goto IL_16E8;
            }
            int num11 = 0;
            while (num11 < 200)
            {
                if (Main.ignoreErrors)
                {
                    try
                    {
                        Main.item[num11].UpdateItem(num11);
                        goto IL_1733;
                    }
                    catch
                    {
                        Main.item[num11] = new Item();
                        goto IL_1733;
                    }
                    goto IL_1724;
                }
                goto IL_1724;
                IL_1733:
                num11++;
                continue;
                IL_1724:
                Main.item[num11].UpdateItem(num11);
                goto IL_1733;
            }
            if (Main.ignoreErrors)
            {
                try
                {
                    Dust.UpdateDust();
                    goto IL_1779;
                }
                catch
                {
                    for (int num12 = 0; num12 < 2000; num12++)
                    {
                        Main.dust[num12] = new Dust();
                    }
                    goto IL_1779;
                }
            }
            Dust.UpdateDust();
            IL_1779:
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
                    goto IL_17A7;
                }
                catch
                {
                    Main.checkForSpawns = 0;
                    goto IL_17A7;
                }
            }
            Main.UpdateTime();
            IL_17A7:
            if (Main.netMode != 1)
            {
                if (Main.ignoreErrors)
                {
                    try
                    {
                        WorldGen.UpdateWorld();
                        Main.UpdateInvasion();
                        goto IL_17CF;
                    }
                    catch
                    {
                        goto IL_17CF;
                    }
                }
                WorldGen.UpdateWorld();
                Main.UpdateInvasion();
            }
            IL_17CF:
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
                    }
                    goto IL_1817;
                }
                catch
                {
                    int arg_17FA_0 = Main.netMode;
                    goto IL_1817;
                }
            }
            if (Main.netMode == 2)
            {
                Main.UpdateServer();
                goto IL_180A;
            }
            goto IL_180A;
            IL_1817:
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
                    goto IL_18B6;
                }
                catch
                {
                    for (int num14 = 0; num14 < Main.numChatLines; num14++)
                    {
                        Main.chatLine[num14] = new ChatLine();
                    }
                    goto IL_18B6;
                }
                goto IL_187D;
            }
            goto IL_187D;
            IL_18B6:
            Main.upTimer = (float) stopwatch.ElapsedMilliseconds;
            if (Main.upTimerMaxDelay > 0f)
            {
                Main.upTimerMaxDelay -= 1f;
                goto IL_18EA;
            }
            Main.upTimerMax = 0f;
            goto IL_18EA;
            IL_187D:
            for (int num15 = 0; num15 < Main.numChatLines; num15++)
            {
                if (Main.chatLine[num15].showTime > 0)
                {
                    Main.chatLine[num15].showTime--;
                }
            }
            goto IL_18B6;
            IL_180A:
            if (Main.netMode == 1)
            {
                goto IL_1817;
            }
            goto IL_1817;
            IL_18EA:
            if (Main.upTimer > Main.upTimerMax)
            {
                Main.upTimerMax = Main.upTimer;
                Main.upTimerMaxDelay = 400f;
            }
        }

        public static Color shine(Color newColor, int type)
        {
            int num = (int) newColor.R;
            int num2 = (int) newColor.R;
            int num3 = (int) newColor.R;
            float num4 = 0.6f;
            if (type == 25)
            {
                num = (int) ((float) newColor.R*0.95f);
                num2 = (int) ((float) newColor.G*0.85f);
                num3 = (int) ((double) ((float) newColor.B)*1.1);
            }
            else
            {
                if (type == 117)
                {
                    num = (int) ((float) newColor.R*1.1f);
                    num2 = (int) ((float) newColor.G*1f);
                    num3 = (int) ((double) ((float) newColor.B)*1.2);
                }
                else
                {
                    num = (int) ((float) newColor.R*(1f + num4));
                    num2 = (int) ((float) newColor.G*(1f + num4));
                    num3 = (int) ((float) newColor.B*(1f + num4));
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
            newColor.R = (byte) num;
            newColor.G = (byte) num2;
            newColor.B = (byte) num3;
            return new Color((int) ((byte) num), (int) ((byte) num2), (int) ((byte) num3), (int) newColor.A);
        }

        private static Color buffColor(Color newColor, float R, float G, float B, float A)
        {
            newColor.R = (byte) ((float) newColor.R*R);
            newColor.G = (byte) ((float) newColor.G*G);
            newColor.B = (byte) ((float) newColor.B*B);
            newColor.A = (byte) ((float) newColor.A*A);
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
                result = (Item) Main.player[Main.myPlayer].armor[0].Clone();
                Main.player[Main.myPlayer].armor[0] = (Item) newItem.Clone();
            }
            else
            {
                if (newItem.bodySlot != -1)
                {
                    result = (Item) Main.player[Main.myPlayer].armor[1].Clone();
                    Main.player[Main.myPlayer].armor[1] = (Item) newItem.Clone();
                }
                else
                {
                    if (newItem.legSlot != -1)
                    {
                        result = (Item) Main.player[Main.myPlayer].armor[2].Clone();
                        Main.player[Main.myPlayer].armor[2] = (Item) newItem.Clone();
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
                            result = (Item) Main.player[Main.myPlayer].armor[3 + Main.accSlotCount].Clone();
                            Main.player[Main.myPlayer].armor[3 + Main.accSlotCount] = (Item) newItem.Clone();
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
                            if (Main.netMode == 1)
                            {
                                NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float) j, 0f, 0f, 0);
                            }
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
            Main.cursorAlpha += (float) Main.cursorColorDirection*0.015f;
            if (Main.cursorAlpha >= 1f)
            {
                Main.cursorAlpha = 1f;
                Main.cursorColorDirection = -1;
            }
            if ((double) Main.cursorAlpha <= 0.6)
            {
                Main.cursorAlpha = 0.6f;
                Main.cursorColorDirection = 1;
            }
            float num = Main.cursorAlpha*0.3f + 0.7f;
            byte r = (byte) ((float) Main.mouseColor.R*Main.cursorAlpha);
            byte g = (byte) ((float) Main.mouseColor.G*Main.cursorAlpha);
            byte b = (byte) ((float) Main.mouseColor.B*Main.cursorAlpha);
            byte a = (byte) (255f*num);
            Main.cursorColor = new Color((int) r, (int) g, (int) b, (int) a);
            Main.cursorScale = Main.cursorAlpha*0.3f + 0.7f + 0.1f;
        }

        protected bool FullTile(int x, int y)
        {
            if (Main.tile[x, y].active && Main.tileSolid[(int) Main.tile[x, y].type] && !Main.tileSolidTop[(int) Main.tile[x, y].type] && Main.tile[x, y].type != 10 && Main.tile[x, y].type != 54 && Main.tile[x, y].type != 138)
            {
                int frameX = (int) Main.tile[x, y].frameX;
                int frameY = (int) Main.tile[x, y].frameY;
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
                    }
                    Main.InvasionWarning();
                    Main.invasionType = 0;
                    Main.invasionDelay = 7;
                }
                if (Main.invasionX == (double) Main.spawnTileX)
                {
                    return;
                }
                float num = 1f;
                if (Main.invasionX > (double) Main.spawnTileX)
                {
                    Main.invasionX -= (double) num;
                    if (Main.invasionX <= (double) Main.spawnTileX)
                    {
                        Main.invasionX = (double) Main.spawnTileX;
                        Main.InvasionWarning();
                    }
                    else
                    {
                        Main.invasionWarn--;
                    }
                }
                else
                {
                    if (Main.invasionX < (double) Main.spawnTileX)
                    {
                        Main.invasionX += (double) num;
                        if (Main.invasionX >= (double) Main.spawnTileX)
                        {
                            Main.invasionX = (double) Main.spawnTileX;
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
            string str1 = "";
            string str2 = Main.invasionSize > 0 ? (Main.invasionX >= (double)Main.spawnTileX ? (Main.invasionX <= (double)Main.spawnTileX ? (Main.invasionType != 2 ? (str1 = Lang.misc[3]) : Lang.misc[7]) : (Main.invasionType != 2 ? (str1 = Lang.misc[2]) : Lang.misc[6])) : (Main.invasionType != 2 ? (str1 = Lang.misc[1]) : Lang.misc[5])) : (Main.invasionType != 2 ? (str1 = Lang.misc[0]) : Lang.misc[4]);
            if (Main.netMode == 0)
            {
                Main.NewText(str2, (byte)175, (byte)75, byte.MaxValue);
            }
            else
            {
                if (Main.netMode != 2)
                    return;
                NetMessage.SendData(25, -1, -1, str2, (int)byte.MaxValue, 175f, 75f, (float)byte.MaxValue, 0);
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
                    Main.invasionSize = 80 + 40*num;
                    Main.invasionWarn = 0;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.invasionX = 0.0;
                        return;
                    }
                    Main.invasionX = (double) Main.maxTilesX;
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
            if (Math.IEEERemainder((double) Main.netPlayCounter, 900.0) == 0.0)
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
                    if (!Main.stopTimeOuts && Netplay.serverSock[k].timeOut > 60*Main.timeOut)
                    {
                        Netplay.serverSock[k].kill = true;
                    }
                }
                if (Main.player[k].active)
                {
                    int sectionX = Netplay.GetSectionX((int) (Main.player[k].position.X/16f));
                    int sectionY = Netplay.GetSectionY((int) (Main.player[k].position.Y/16f));
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
                        int num4 = num3*150;
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
                                    NetMessage.SendData(11, k, -1, "", n, (float) num5, (float) n, (float) num5, 0);
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
                Main.chatLine[0].color = new Color((int) R, (int) G, (int) B);
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
                    for (int plr = 0; plr < (int)byte.MaxValue; ++plr)
                    {
                        if (Main.player[plr].active && !Main.player[plr].dead && (double)Main.player[plr].position.Y < Main.worldSurface * 16.0)
                        {
                            NPC.SpawnOnPlayer(plr, 4);
                            WorldGen.spawnEye = false;
                            break;
                        }
                    }
                }
                if (Main.time > 32400.0)
                {
                    Main.checkXMas();
                    if (Main.invasionDelay > 0)
                        --Main.invasionDelay;
                    WorldGen.spawnNPC = 0;
                    Main.checkForSpawns = 0;
                    Main.time = 0.0;
                    Main.bloodMoon = false;
                    Main.dayTime = true;
                    ++Main.moonPhase;
                    if (Main.moonPhase >= 8)
                        Main.moonPhase = 0;
                    if (Main.netMode == 2)
                    {
                        NetMessage.SendData(7, -1, -1, "", 0, 0.0f, 0.0f, 0.0f, 0);
                        WorldGen.saveAndPlay();
                    }
                    if (Main.netMode != 1 && WorldGen.shadowOrbSmashed)
                    {
                        if (!NPC.downedGoblins)
                        {
                            if (Main.rand.Next(3) == 0)
                                Main.StartInvasion(1);
                        }
                        else if (Main.rand.Next(15) == 0)
                            Main.StartInvasion(1);
                    }
                }
                if (Main.time <= 16200.0 || !WorldGen.spawnMeteor)
                    return;
                WorldGen.spawnMeteor = false;
                WorldGen.dropMeteor();
            }
            else
            {
                Main.bloodMoon = false;
                if (Main.time > 54000.0)
                {
                    WorldGen.spawnNPC = 0;
                    Main.checkForSpawns = 0;
                    if (Main.rand.Next(50) == 0 && Main.netMode != 1 && WorldGen.shadowOrbSmashed)
                        WorldGen.spawnMeteor = true;
                    if (!NPC.downedBoss1 && Main.netMode != 1)
                    {
                        bool flag = false;
                        for (int index = 0; index < (int)byte.MaxValue; ++index)
                        {
                            if (Main.player[index].active && Main.player[index].statLifeMax >= 200 && Main.player[index].statDefense > 10)
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag && Main.rand.Next(3) == 0)
                        {
                            int num = 0;
                            for (int index = 0; index < 200; ++index)
                            {
                                if (Main.npc[index].active && Main.npc[index].townNPC)
                                    ++num;
                            }
                            if (num >= 4)
                            {
                                WorldGen.spawnEye = true;
                                if (Main.netMode == 0)
                                    Main.NewText(Lang.misc[9], (byte)50, byte.MaxValue, (byte)130);
                                else if (Main.netMode == 2)
                                    NetMessage.SendData(25, -1, -1, Lang.misc[9], (int)byte.MaxValue, 50f, (float)byte.MaxValue, 130f, 0);
                            }
                        }
                    }
                    if (!WorldGen.spawnEye && Main.moonPhase != 4 && (Main.rand.Next(9) == 0 && Main.netMode != 1))
                    {
                        for (int index = 0; index < (int)byte.MaxValue; ++index)
                        {
                            if (Main.player[index].active && Main.player[index].statLifeMax > 120)
                            {
                                Main.bloodMoon = true;
                                break;
                            }
                        }
                        if (Main.bloodMoon)
                        {
                            if (Main.netMode == 0)
                                Main.NewText(Lang.misc[8], (byte)50, byte.MaxValue, (byte)130);
                            else if (Main.netMode == 2)
                                NetMessage.SendData(25, -1, -1, Lang.misc[8], (int)byte.MaxValue, 50f, (float)byte.MaxValue, 130f, 0);
                        }
                    }
                    Main.time = 0.0;
                    Main.dayTime = false;
                    if (Main.netMode == 2)
                        NetMessage.SendData(7, -1, -1, "", 0, 0.0f, 0.0f, 0.0f, 0);
                }
                if (Main.netMode == 1)
                    return;
                ++Main.checkForSpawns;
                if (Main.checkForSpawns < 7200)
                    return;
                int num1 = 0;
                for (int index = 0; index < (int)byte.MaxValue; ++index)
                {
                    if (Main.player[index].active)
                        ++num1;
                }
                Main.checkForSpawns = 0;
                WorldGen.spawnNPC = 0;
                int num2 = 0;
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
                for (int npc = 0; npc < 200; ++npc)
                {
                    if (Main.npc[npc].active && Main.npc[npc].townNPC)
                    {
                        if (Main.npc[npc].type != 37 && !Main.npc[npc].homeless)
                            WorldGen.QuickFindHome(npc);
                        if (Main.npc[npc].type == 37)
                            ++num7;
                        if (Main.npc[npc].type == 17)
                            ++num2;
                        if (Main.npc[npc].type == 18)
                            ++num3;
                        if (Main.npc[npc].type == 19)
                            ++num5;
                        if (Main.npc[npc].type == 20)
                            ++num4;
                        if (Main.npc[npc].type == 22)
                            ++num6;
                        if (Main.npc[npc].type == 38)
                            ++num8;
                        if (Main.npc[npc].type == 54)
                            ++num9;
                        if (Main.npc[npc].type == 107)
                            ++num11;
                        if (Main.npc[npc].type == 108)
                            ++num10;
                        if (Main.npc[npc].type == 124)
                            ++num12;
                        if (Main.npc[npc].type == 142)
                            ++num13;
                        ++num14;
                    }
                }
                if (WorldGen.spawnNPC != 0)
                    return;
                int num15 = 0;
                bool flag1 = false;
                int num16 = 0;
                bool flag2 = false;
                bool flag3 = false;
                for (int index1 = 0; index1 < (int)byte.MaxValue; ++index1)
                {
                    if (Main.player[index1].active)
                    {
                        for (int index2 = 0; index2 < 48; ++index2)
                        {
                            if (Main.player[index1].inventory[index2] != null & Main.player[index1].inventory[index2].stack > 0)
                            {
                                if (Main.player[index1].inventory[index2].type == 71)
                                    num15 += Main.player[index1].inventory[index2].stack;
                                if (Main.player[index1].inventory[index2].type == 72)
                                    num15 += Main.player[index1].inventory[index2].stack * 100;
                                if (Main.player[index1].inventory[index2].type == 73)
                                    num15 += Main.player[index1].inventory[index2].stack * 10000;
                                if (Main.player[index1].inventory[index2].type == 74)
                                    num15 += Main.player[index1].inventory[index2].stack * 1000000;
                                if (Main.player[index1].inventory[index2].ammo == 14 || Main.player[index1].inventory[index2].useAmmo == 14)
                                    flag2 = true;
                                if (Main.player[index1].inventory[index2].type == 166 || Main.player[index1].inventory[index2].type == 167 || (Main.player[index1].inventory[index2].type == 168 || Main.player[index1].inventory[index2].type == 235))
                                    flag3 = true;
                            }
                        }
                        int num17 = Main.player[index1].statLifeMax / 20;
                        if (num17 > 5)
                            flag1 = true;
                        num16 += num17;
                    }
                }
                if (!NPC.downedBoss3 && num7 == 0)
                {
                    int index = NPC.NewNPC(Main.dungeonX * 16 + 8, Main.dungeonY * 16, 37, 0);
                    Main.npc[index].homeless = false;
                    Main.npc[index].homeTileX = Main.dungeonX;
                    Main.npc[index].homeTileY = Main.dungeonY;
                }
                if (WorldGen.spawnNPC == 0 && num6 < 1)
                    WorldGen.spawnNPC = 22;
                if (WorldGen.spawnNPC == 0 && (double)num15 > 5000.0 && num2 < 1)
                    WorldGen.spawnNPC = 17;
                if (WorldGen.spawnNPC == 0 && flag1 && num3 < 1)
                    WorldGen.spawnNPC = 18;
                if (WorldGen.spawnNPC == 0 && flag2 && num5 < 1)
                    WorldGen.spawnNPC = 19;
                if (WorldGen.spawnNPC == 0 && (NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3) && num4 < 1)
                    WorldGen.spawnNPC = 20;
                if (WorldGen.spawnNPC == 0 && flag3 && (num2 > 0 && num8 < 1))
                    WorldGen.spawnNPC = 38;
                if (WorldGen.spawnNPC == 0 && NPC.downedBoss3 && num9 < 1)
                    WorldGen.spawnNPC = 54;
                if (WorldGen.spawnNPC == 0 && NPC.savedGoblin && num11 < 1)
                    WorldGen.spawnNPC = 107;
                if (WorldGen.spawnNPC == 0 && NPC.savedWizard && num10 < 1)
                    WorldGen.spawnNPC = 108;
                if (WorldGen.spawnNPC == 0 && NPC.savedMech && num12 < 1)
                    WorldGen.spawnNPC = 124;
                if (WorldGen.spawnNPC != 0 || !NPC.downedFrost || (num13 >= 1 || !Main.xMas))
                    return;
                WorldGen.spawnNPC = 142;
            }
        }

        public static int DamageVar(float dmg)
        {
            float num = dmg*(1f + (float) Main.rand.Next(-15, 16)*0.01f);
            return (int) Math.Round((double) num);
        }

        public static double CalculateDamage(int Damage, int Defense)
        {
            double num = (double) Damage - (double) Defense*0.5;
            if (num < 1.0)
            {
                num = 1.0;
            }
            return num;
        }

        public static void PlaySound(int type, int x = -1, int y = -1, int Style = 1)
        {
        }

        protected void SetTitle()
        {
        }
    }
}
