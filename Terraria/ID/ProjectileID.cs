namespace Terraria.ID
{
	public class ProjectileID
	{
		public static class Sets
		{
			public static SetFactory Factory = new SetFactory(Count);

			public static bool?[] ForcePlateDetection = Factory.CreateCustomSet<bool?>(null, new object[]
			{
				397,
				true,
				37,
				true,
				470,
				true,
				53,
				true,
				519,
				true,
				171,
				true,
				505,
				true,
				475,
				true,
				506,
				true,
				186,
				true,
				80,
				true,
				40,
				true,
				241,
				true,
				411,
				true,
				56,
				true,
				413,
				true,
				67,
				true,
				414,
				true,
				31,
				true,
				412,
				true,
				17,
				true,
				166,
				true,
				109,
				true,
				354,
				true,
				65,
				true,
				68,
				true,
				42,
				true,
				99,
				false,
				655,
				false
			});

			public static int[] TrailingMode;

			public static int[] TrailCacheLength;

			public static bool[] LightPet;

			public static bool[] Homing;

			public static bool[] MinionSacrificable;

			public static bool[] DontAttachHideToAlpha;

			public static bool[] NeedsUUID;

			public static bool[] StardustDragon;

			static Sets()
			{
				// Note: this type is marked as 'beforefieldinit'.
				SetFactory arg_3E9_0 = Factory;
				int arg_3E9_1 = -1;
				int[] array = new int[68];
				array[0] = 94;
				array[2] = 301;
				array[4] = 388;
				array[6] = 385;
				array[8] = 408;
				array[10] = 409;
				array[12] = 435;
				array[14] = 436;
				array[16] = 437;
				array[18] = 438;
				array[20] = 452;
				array[22] = 459;
				array[24] = 462;
				array[26] = 502;
				array[28] = 503;
				array[30] = 466;
				array[31] = 1;
				array[32] = 532;
				array[34] = 533;
				array[36] = 573;
				array[38] = 580;
				array[39] = 1;
				array[40] = 582;
				array[42] = 585;
				array[44] = 592;
				array[46] = 601;
				array[48] = 617;
				array[50] = 636;
				array[52] = 638;
				array[54] = 639;
				array[56] = 640;
				array[58] = 424;
				array[60] = 425;
				array[62] = 426;
				array[64] = 660;
				array[66] = 661;
				TrailingMode = arg_3E9_0.CreateIntSet(arg_3E9_1, array);
				TrailCacheLength = Factory.CreateIntSet(10, new int[]
				{
					466,
					20,
					502,
					25,
					580,
					20,
					636,
					20,
					640,
					20
				});
				LightPet = Factory.CreateBoolSet(new int[]
				{
					18,
					500,
					72,
					87,
					86,
					211,
					492,
					650
				});
				Homing = Factory.CreateBoolSet(new int[]
				{
					207,
					182,
					247,
					338,
					339,
					340,
					341,
					191,
					192,
					193,
					194,
					266,
					390,
					391,
					392,
					307,
					316,
					190,
					227,
					226,
					254,
					255,
					297,
					308,
					317,
					321,
					407,
					423,
					375,
					373,
					376,
					374,
					379,
					387,
					408,
					389,
					388,
					405,
					409,
					451,
					535,
					536,
					483,
					484,
					477
				});
				MinionSacrificable = Factory.CreateBoolSet(new int[]
				{
					191,
					192,
					193,
					194,
					266,
					317,
					373,
					375,
					387,
					388,
					390,
					393,
					407,
					423,
					533,
					613,
					625,
					626,
					627,
					628
				});
				DontAttachHideToAlpha = Factory.CreateBoolSet(new int[]
				{
					598,
					641,
					617,
					636,
					579,
					578,
					625,
					626,
					627,
					628
				});
				NeedsUUID = Factory.CreateBoolSet(new int[]
				{
					625,
					626,
					627,
					628
				});
				StardustDragon = Factory.CreateBoolSet(new int[]
				{
					625,
					626,
					627,
					628
				});
			}
		}

		public const short None = 0;

		public const short WoodenArrowFriendly = 1;

		public const short FireArrow = 2;

		public const short Shuriken = 3;

		public const short UnholyArrow = 4;

		public const short JestersArrow = 5;

		public const short EnchantedBoomerang = 6;

		public const short VilethornBase = 7;

		public const short VilethornTip = 8;

		public const short Starfury = 9;

		public const short PurificationPowder = 10;

		public const short VilePowder = 11;

		public const short FallingStar = 12;

		public const short Hook = 13;

		public const short Bullet = 14;

		public const short BallofFire = 15;

		public const short MagicMissile = 16;

		public const short DirtBall = 17;

		public const short ShadowOrb = 18;

		public const short Flamarang = 19;

		public const short GreenLaser = 20;

		public const short Bone = 21;

		public const short WaterStream = 22;

		public const short Harpoon = 23;

		public const short SpikyBall = 24;

		public const short BallOHurt = 25;

		public const short BlueMoon = 26;

		public const short WaterBolt = 27;

		public const short Bomb = 28;

		public const short Dynamite = 29;

		public const short Grenade = 30;

		public const short SandBallFalling = 31;

		public const short IvyWhip = 32;

		public const short ThornChakram = 33;

		public const short Flamelash = 34;

		public const short Sunfury = 35;

		public const short MeteorShot = 36;

		public const short StickyBomb = 37;

		public const short HarpyFeather = 38;

		public const short MudBall = 39;

		public const short AshBallFalling = 40;

		public const short HellfireArrow = 41;

		public const short SandBallGun = 42;

		public const short Tombstone = 43;

		public const short DemonSickle = 44;

		public const short DemonScythe = 45;

		public const short DarkLance = 46;

		public const short Trident = 47;

		public const short ThrowingKnife = 48;

		public const short Spear = 49;

		public const short Glowstick = 50;

		public const short Seed = 51;

		public const short WoodenBoomerang = 52;

		public const short StickyGlowstick = 53;

		public const short PoisonedKnife = 54;

		public const short Stinger = 55;

		public const short EbonsandBallFalling = 56;

		public const short CobaltChainsaw = 57;

		public const short MythrilChainsaw = 58;

		public const short CobaltDrill = 59;

		public const short MythrilDrill = 60;

		public const short AdamantiteChainsaw = 61;

		public const short AdamantiteDrill = 62;

		public const short TheDaoofPow = 63;

		public const short MythrilHalberd = 64;

		public const short EbonsandBallGun = 65;

		public const short AdamantiteGlaive = 66;

		public const short PearlSandBallFalling = 67;

		public const short PearlSandBallGun = 68;

		public const short HolyWater = 69;

		public const short UnholyWater = 70;

		public const short SiltBall = 71;

		public const short BlueFairy = 72;

		public const short DualHookBlue = 73;

		public const short DualHookRed = 74;

		public const short HappyBomb = 75;

		public const short QuarterNote = 76;

		public const short EighthNote = 77;

		public const short TiedEighthNote = 78;

		public const short RainbowRodBullet = 79;

		public const short IceBlock = 80;

		public const short WoodenArrowHostile = 81;

		public const short FlamingArrow = 82;

		public const short EyeLaser = 83;

		public const short PinkLaser = 84;

		public const short Flames = 85;

		public const short PinkFairy = 86;

		public const short GreenFairy = 87;

		public const short PurpleLaser = 88;

		public const short CrystalBullet = 89;

		public const short CrystalShard = 90;

		public const short HolyArrow = 91;

		public const short HallowStar = 92;

		public const short MagicDagger = 93;

		public const short CrystalStorm = 94;

		public const short CursedFlameFriendly = 95;

		public const short CursedFlameHostile = 96;

		public const short CobaltNaginata = 97;

		public const short PoisonDart = 98;

		public const short Boulder = 99;

		public const short DeathLaser = 100;

		public const short EyeFire = 101;

		public const short BombSkeletronPrime = 102;

		public const short CursedArrow = 103;

		public const short CursedBullet = 104;

		public const short Gungnir = 105;

		public const short LightDisc = 106;

		public const short Hamdrax = 107;

		public const short Explosives = 108;

		public const short SnowBallHostile = 109;

		public const short BulletSnowman = 110;

		public const short Bunny = 111;

		public const short Penguin = 112;

		public const short IceBoomerang = 113;

		public const short UnholyTridentFriendly = 114;

		public const short UnholyTridentHostile = 115;

		public const short SwordBeam = 116;

		public const short BoneArrow = 117;

		public const short IceBolt = 118;

		public const short FrostBoltSword = 119;

		public const short FrostArrow = 120;

		public const short AmethystBolt = 121;

		public const short TopazBolt = 122;

		public const short SapphireBolt = 123;

		public const short EmeraldBolt = 124;

		public const short RubyBolt = 125;

		public const short DiamondBolt = 126;

		public const short Turtle = 127;

		public const short FrostBlastHostile = 128;

		public const short RuneBlast = 129;

		public const short MushroomSpear = 130;

		public const short Mushroom = 131;

		public const short TerraBeam = 132;

		public const short GrenadeI = 133;

		public const short RocketI = 134;

		public const short ProximityMineI = 135;

		public const short GrenadeII = 136;

		public const short RocketII = 137;

		public const short ProximityMineII = 138;

		public const short GrenadeIII = 139;

		public const short RocketIII = 140;

		public const short ProximityMineIII = 141;

		public const short GrenadeIV = 142;

		public const short RocketIV = 143;

		public const short ProximityMineIV = 144;

		public const short PureSpray = 145;

		public const short HallowSpray = 146;

		public const short CorruptSpray = 147;

		public const short MushroomSpray = 148;

		public const short CrimsonSpray = 149;

		public const short NettleBurstRight = 150;

		public const short NettleBurstLeft = 151;

		public const short NettleBurstEnd = 152;

		public const short TheRottedFork = 153;

		public const short TheMeatball = 154;

		public const short BeachBall = 155;

		public const short LightBeam = 156;

		public const short NightBeam = 157;

		public const short CopperCoin = 158;

		public const short SilverCoin = 159;

		public const short GoldCoin = 160;

		public const short PlatinumCoin = 161;

		public const short CannonballFriendly = 162;

		public const short Flare = 163;

		public const short Landmine = 164;

		public const short Web = 165;

		public const short SnowBallFriendly = 166;

		public const short RocketFireworkRed = 167;

		public const short RocketFireworkGreen = 168;

		public const short RocketFireworkBlue = 169;

		public const short RocketFireworkYellow = 170;

		public const short RopeCoil = 171;

		public const short FrostburnArrow = 172;

		public const short EnchantedBeam = 173;

		public const short IceSpike = 174;

		public const short BabyEater = 175;

		public const short JungleSpike = 176;

		public const short IcewaterSpit = 177;

		public const short ConfettiGun = 178;

		public const short SlushBall = 179;

		public const short BulletDeadeye = 180;

		public const short Bee = 181;

		public const short PossessedHatchet = 182;

		public const short Beenade = 183;

		public const short PoisonDartTrap = 184;

		public const short SpikyBallTrap = 185;

		public const short SpearTrap = 186;

		public const short FlamethrowerTrap = 187;

		public const short FlamesTrap = 188;

		public const short Wasp = 189;

		public const short MechanicalPiranha = 190;

		public const short Pygmy = 191;

		public const short Pygmy2 = 192;

		public const short Pygmy3 = 193;

		public const short Pygmy4 = 194;

		public const short PygmySpear = 195;

		public const short SmokeBomb = 196;

		public const short BabySkeletronHead = 197;

		public const short BabyHornet = 198;

		public const short TikiSpirit = 199;

		public const short PetLizard = 200;

		public const short GraveMarker = 201;

		public const short CrossGraveMarker = 202;

		public const short Headstone = 203;

		public const short Gravestone = 204;

		public const short Obelisk = 205;

		public const short Leaf = 206;

		public const short ChlorophyteBullet = 207;

		public const short Parrot = 208;

		public const short Truffle = 209;

		public const short Sapling = 210;

		public const short Wisp = 211;

		public const short PalladiumPike = 212;

		public const short PalladiumDrill = 213;

		public const short PalladiumChainsaw = 214;

		public const short OrichalcumHalberd = 215;

		public const short OrichalcumDrill = 216;

		public const short OrichalcumChainsaw = 217;

		public const short TitaniumTrident = 218;

		public const short TitaniumDrill = 219;

		public const short TitaniumChainsaw = 220;

		public const short FlowerPetal = 221;

		public const short ChlorophytePartisan = 222;

		public const short ChlorophyteDrill = 223;

		public const short ChlorophyteChainsaw = 224;

		public const short ChlorophyteArrow = 225;

		public const short CrystalLeaf = 226;

		public const short CrystalLeafShot = 227;

		public const short SporeCloud = 228;

		public const short ChlorophyteOrb = 229;

		public const short GemHookAmethyst = 230;

		public const short GemHookTopaz = 231;

		public const short GemHookSapphire = 232;

		public const short GemHookEmerald = 233;

		public const short GemHookRuby = 234;

		public const short GemHookDiamond = 235;

		public const short BabyDino = 236;

		public const short RainCloudMoving = 237;

		public const short RainCloudRaining = 238;

		public const short RainFriendly = 239;

		public const short CannonballHostile = 240;

		public const short CrimsandBallFalling = 241;

		public const short BulletHighVelocity = 242;

		public const short BloodCloudMoving = 243;

		public const short BloodCloudRaining = 244;

		public const short BloodRain = 245;

		public const short Stynger = 246;

		public const short FlowerPow = 247;

		public const short FlowerPowPetal = 248;

		public const short StyngerShrapnel = 249;

		public const short RainbowFront = 250;

		public const short RainbowBack = 251;

		public const short ChlorophyteJackhammer = 252;

		public const short BallofFrost = 253;

		public const short MagnetSphereBall = 254;

		public const short MagnetSphereBolt = 255;

		public const short SkeletronHand = 256;

		public const short FrostBeam = 257;

		public const short Fireball = 258;

		public const short EyeBeam = 259;

		public const short HeatRay = 260;

		public const short BoulderStaffOfEarth = 261;

		public const short GolemFist = 262;

		public const short IceSickle = 263;

		public const short RainNimbus = 264;

		public const short PoisonFang = 265;

		public const short BabySlime = 266;

		public const short PoisonDartBlowgun = 267;

		public const short EyeSpring = 268;

		public const short BabySnowman = 269;

		public const short Skull = 270;

		public const short BoxingGlove = 271;

		public const short Bananarang = 272;

		public const short ChainKnife = 273;

		public const short DeathSickle = 274;

		public const short SeedPlantera = 275;

		public const short PoisonSeedPlantera = 276;

		public const short ThornBall = 277;

		public const short IchorArrow = 278;

		public const short IchorBullet = 279;

		public const short GoldenShowerFriendly = 280;

		public const short ExplosiveBunny = 281;

		public const short VenomArrow = 282;

		public const short VenomBullet = 283;

		public const short PartyBullet = 284;

		public const short NanoBullet = 285;

		public const short ExplosiveBullet = 286;

		public const short GoldenBullet = 287;

		public const short GoldenShowerHostile = 288;

		public const short ConfettiMelee = 289;

		public const short ShadowBeamHostile = 290;

		public const short InfernoHostileBolt = 291;

		public const short InfernoHostileBlast = 292;

		public const short LostSoulHostile = 293;

		public const short ShadowBeamFriendly = 294;

		public const short InfernoFriendlyBolt = 295;

		public const short InfernoFriendlyBlast = 296;

		public const short LostSoulFriendly = 297;

		public const short SpiritHeal = 298;

		public const short Shadowflames = 299;

		public const short PaladinsHammerHostile = 300;

		public const short PaladinsHammerFriendly = 301;

		public const short SniperBullet = 302;

		public const short RocketSkeleton = 303;

		public const short VampireKnife = 304;

		public const short VampireHeal = 305;

		public const short EatersBite = 306;

		public const short TinyEater = 307;

		public const short FrostHydra = 308;

		public const short FrostBlastFriendly = 309;

		public const short BlueFlare = 310;

		public const short CandyCorn = 311;

		public const short JackOLantern = 312;

		public const short Spider = 313;

		public const short Squashling = 314;

		public const short BatHook = 315;

		public const short Bat = 316;

		public const short Raven = 317;

		public const short RottenEgg = 318;

		public const short BlackCat = 319;

		public const short BloodyMachete = 320;

		public const short FlamingJack = 321;

		public const short WoodHook = 322;

		public const short Stake = 323;

		public const short CursedSapling = 324;

		public const short FlamingWood = 325;

		public const short GreekFire1 = 326;

		public const short GreekFire2 = 327;

		public const short GreekFire3 = 328;

		public const short FlamingScythe = 329;

		public const short StarAnise = 330;

		public const short CandyCaneHook = 331;

		public const short ChristmasHook = 332;

		public const short FruitcakeChakram = 333;

		public const short Puppy = 334;

		public const short OrnamentFriendly = 335;

		public const short PineNeedleFriendly = 336;

		public const short Blizzard = 337;

		public const short RocketSnowmanI = 338;

		public const short RocketSnowmanII = 339;

		public const short RocketSnowmanIII = 340;

		public const short RocketSnowmanIV = 341;

		public const short NorthPoleWeapon = 342;

		public const short NorthPoleSpear = 343;

		public const short NorthPoleSnowflake = 344;

		public const short PineNeedleHostile = 345;

		public const short OrnamentHostile = 346;

		public const short OrnamentHostileShrapnel = 347;

		public const short FrostWave = 348;

		public const short FrostShard = 349;

		public const short Missile = 350;

		public const short Present = 351;

		public const short Spike = 352;

		public const short BabyGrinch = 353;

		public const short CrimsandBallGun = 354;

		public const short VenomFang = 355;

		public const short SpectreWrath = 356;

		public const short PulseBolt = 357;

		public const short WaterGun = 358;

		public const short FrostBoltStaff = 359;

		public const short BobberWooden = 360;

		public const short BobberReinforced = 361;

		public const short BobberFiberglass = 362;

		public const short BobberFisherOfSouls = 363;

		public const short BobberGolden = 364;

		public const short BobberMechanics = 365;

		public const short BobbersittingDuck = 366;

		public const short ObsidianSwordfish = 367;

		public const short Swordfish = 368;

		public const short SawtoothShark = 369;

		public const short LovePotion = 370;

		public const short FoulPotion = 371;

		public const short FishHook = 372;

		public const short Hornet = 373;

		public const short HornetStinger = 374;

		public const short FlyingImp = 375;

		public const short ImpFireball = 376;

		public const short SpiderHiver = 377;

		public const short SpiderEgg = 378;

		public const short BabySpider = 379;

		public const short ZephyrFish = 380;

		public const short BobberFleshcatcher = 381;

		public const short BobberHotline = 382;

		public const short Anchor = 383;

		public const short Sharknado = 384;

		public const short SharknadoBolt = 385;

		public const short Cthulunado = 386;

		public const short Retanimini = 387;

		public const short Spazmamini = 388;

		public const short MiniRetinaLaser = 389;

		public const short VenomSpider = 390;

		public const short JumperSpider = 391;

		public const short DangerousSpider = 392;

		public const short OneEyedPirate = 393;

		public const short SoulscourgePirate = 394;

		public const short PirateCaptain = 395;

		public const short SlimeHook = 396;

		public const short StickyGrenade = 397;

		public const short MiniMinotaur = 398;

		public const short MolotovCocktail = 399;

		public const short MolotovFire = 400;

		public const short MolotovFire2 = 401;

		public const short MolotovFire3 = 402;

		public const short TrackHook = 403;

		public const short Flairon = 404;

		public const short FlaironBubble = 405;

		public const short SlimeGun = 406;

		public const short Tempest = 407;

		public const short MiniSharkron = 408;

		public const short Typhoon = 409;

		public const short Bubble = 410;

		public const short CopperCoinsFalling = 411;

		public const short SilverCoinsFalling = 412;

		public const short GoldCoinsFalling = 413;

		public const short PlatinumCoinsFalling = 414;

		public const short RocketFireworksBoxRed = 415;

		public const short RocketFireworksBoxGreen = 416;

		public const short RocketFireworksBoxBlue = 417;

		public const short RocketFireworksBoxYellow = 418;

		public const short FireworkFountainYellow = 419;

		public const short FireworkFountainRed = 420;

		public const short FireworkFountainBlue = 421;

		public const short FireworkFountainRainbow = 422;

		public const short UFOMinion = 423;

		public const short Meteor1 = 424;

		public const short Meteor2 = 425;

		public const short Meteor3 = 426;

		public const short VortexChainsaw = 427;

		public const short VortexDrill = 428;

		public const short NebulaChainsaw = 429;

		public const short NebulaDrill = 430;

		public const short SolarFlareChainsaw = 431;

		public const short SolarFlareDrill = 432;

		public const short UFOLaser = 433;

		public const short ScutlixLaserFriendly = 434;

		public const short MartianTurretBolt = 435;

		public const short BrainScramblerBolt = 436;

		public const short GigaZapperSpear = 437;

		public const short RayGunnerLaser = 438;

		public const short LaserMachinegun = 439;

		public const short LaserMachinegunLaser = 440;

		public const short ScutlixLaserCrosshair = 441;

		public const short ElectrosphereMissile = 442;

		public const short Electrosphere = 443;

		public const short Xenopopper = 444;

		public const short LaserDrill = 445;

		public const short AntiGravityHook = 446;

		public const short SaucerDeathray = 447;

		public const short SaucerMissile = 448;

		public const short SaucerLaser = 449;

		public const short SaucerScrap = 450;

		public const short InfluxWaver = 451;

		public const short PhantasmalEye = 452;

		public const short DrillMountCrosshair = 453;

		public const short PhantasmalSphere = 454;

		public const short PhantasmalDeathray = 455;

		public const short MoonLeech = 456;

		public const short PhasicWarpEjector = 457;

		public const short PhasicWarpDisc = 458;

		public const short ChargedBlasterOrb = 459;

		public const short ChargedBlasterCannon = 460;

		public const short ChargedBlasterLaser = 461;

		public const short PhantasmalBolt = 462;

		public const short ViciousPowder = 463;

		public const short CultistBossIceMist = 464;

		public const short CultistBossLightningOrb = 465;

		public const short CultistBossLightningOrbArc = 466;

		public const short CultistBossFireBall = 467;

		public const short CultistBossFireBallClone = 468;

		public const short BeeArrow = 469;

		public const short StickyDynamite = 470;

		public const short SkeletonBone = 471;

		public const short WebSpit = 472;

		public const short SpelunkerGlowstick = 473;

		public const short BoneArrowFromMerchant = 474;

		public const short VineRopeCoil = 475;

		public const short SoulDrain = 476;

		public const short CrystalDart = 477;

		public const short CursedDart = 478;

		public const short IchorDart = 479;

		public const short CursedDartFlame = 480;

		public const short ChainGuillotine = 481;

		public const short ClingerStaff = 482;

		public const short SeedlerNut = 483;

		public const short SeedlerThorn = 484;

		public const short Hellwing = 485;

		public const short TendonHook = 486;

		public const short ThornHook = 487;

		public const short IlluminantHook = 488;

		public const short WormHook = 489;

		public const short CultistRitual = 490;

		public const short FlyingKnife = 491;

		public const short MagicLantern = 492;

		public const short CrystalVileShardHead = 493;

		public const short CrystalVileShardShaft = 494;

		public const short ShadowFlameArrow = 495;

		public const short ShadowFlame = 496;

		public const short ShadowFlameKnife = 497;

		public const short Nail = 498;

		public const short BabyFaceMonster = 499;

		public const short CrimsonHeart = 500;

		public const short DrManFlyFlask = 501;

		public const short Meowmere = 502;

		public const short StarWrath = 503;

		public const short Spark = 504;

		public const short SilkRopeCoil = 505;

		public const short WebRopeCoil = 506;

		public const short JavelinFriendly = 507;

		public const short JavelinHostile = 508;

		public const short ButchersChainsaw = 509;

		public const short ToxicFlask = 510;

		public const short ToxicCloud = 511;

		public const short ToxicCloud2 = 512;

		public const short ToxicCloud3 = 513;

		public const short NailFriendly = 514;

		public const short BouncyGlowstick = 515;

		public const short BouncyBomb = 516;

		public const short BouncyGrenade = 517;

		public const short CoinPortal = 518;

		public const short BombFish = 519;

		public const short FrostDaggerfish = 520;

		public const short CrystalPulse = 521;

		public const short CrystalPulse2 = 522;

		public const short ToxicBubble = 523;

		public const short IchorSplash = 524;

		public const short FlyingPiggyBank = 525;

		public const short CultistBossParticle = 526;

		public const short RichGravestone1 = 527;

		public const short RichGravestone2 = 528;

		public const short RichGravestone3 = 529;

		public const short RichGravestone4 = 530;

		public const short RichGravestone5 = 531;

		public const short BoneGloveProj = 532;

		public const short DeadlySphere = 533;

		public const short Code1 = 534;

		public const short MedusaHead = 535;

		public const short MedusaHeadRay = 536;

		public const short StardustSoldierLaser = 537;

		public const short Twinkle = 538;

		public const short StardustJellyfishSmall = 539;

		public const short StardustTowerMark = 540;

		public const short WoodYoyo = 541;

		public const short CorruptYoyo = 542;

		public const short CrimsonYoyo = 543;

		public const short JungleYoyo = 544;

		public const short Cascade = 545;

		public const short Chik = 546;

		public const short Code2 = 547;

		public const short Rally = 548;

		public const short Yelets = 549;

		public const short RedsYoyo = 550;

		public const short ValkyrieYoyo = 551;

		public const short Amarok = 552;

		public const short HelFire = 553;

		public const short Kraken = 554;

		public const short TheEyeOfCthulhu = 555;

		public const short BlackCounterweight = 556;

		public const short BlueCounterweight = 557;

		public const short GreenCounterweight = 558;

		public const short PurpleCounterweight = 559;

		public const short RedCounterweight = 560;

		public const short YellowCounterweight = 561;

		public const short FormatC = 562;

		public const short Gradient = 563;

		public const short Valor = 564;

		public const short BrainOfConfusion = 565;

		public const short GiantBee = 566;

		public const short SporeTrap = 567;

		public const short SporeTrap2 = 568;

		public const short SporeGas = 569;

		public const short SporeGas2 = 570;

		public const short SporeGas3 = 571;

		public const short SalamanderSpit = 572;

		public const short NebulaBolt = 573;

		public const short NebulaEye = 574;

		public const short NebulaSphere = 575;

		public const short NebulaLaser = 576;

		public const short VortexLaser = 577;

		public const short VortexVortexLightning = 578;

		public const short VortexVortexPortal = 579;

		public const short VortexLightning = 580;

		public const short VortexAcid = 581;

		public const short MechanicWrench = 582;

		public const short NurseSyringeHurt = 583;

		public const short NurseSyringeHeal = 584;

		public const short ClothiersCurse = 585;

		public const short DryadsWardCircle = 586;

		public const short PainterPaintball = 587;

		public const short PartyGirlGrenade = 588;

		public const short SantaBombs = 589;

		public const short TruffleSpore = 590;

		public const short MinecartMechLaser = 591;

		public const short MartianWalkerLaser = 592;

		public const short AncientDoomProjectile = 593;

		public const short BlowupSmoke = 594;

		public const short Arkhalis = 595;

		public const short DesertDjinnCurse = 596;

		public const short AmberBolt = 597;

		public const short BoneJavelin = 598;

		public const short BoneDagger = 599;

		public const short PortalGun = 600;

		public const short PortalGunBolt = 601;

		public const short PortalGunGate = 602;

		public const short Terrarian = 603;

		public const short TerrarianBeam = 604;

		public const short SpikedSlimeSpike = 605;

		public const short ScutlixLaser = 606;

		public const short SolarFlareRay = 607;

		public const short SolarCounter = 608;

		public const short StardustDrill = 609;

		public const short StardustChainsaw = 610;

		public const short SolarWhipSword = 611;

		public const short SolarWhipSwordExplosion = 612;

		public const short StardustCellMinion = 613;

		public const short StardustCellMinionShot = 614;

		public const short VortexBeater = 615;

		public const short VortexBeaterRocket = 616;

		public const short NebulaArcanum = 617;

		public const short NebulaArcanumSubshot = 618;

		public const short NebulaArcanumExplosionShot = 619;

		public const short NebulaArcanumExplosionShotShard = 620;

		public const short BloodWater = 621;

		public const short BlowupSmokeMoonlord = 622;

		public const short StardustGuardian = 623;

		public const short StardustGuardianExplosion = 624;

		public const short StardustDragon1 = 625;

		public const short StardustDragon2 = 626;

		public const short StardustDragon3 = 627;

		public const short StardustDragon4 = 628;

		public const short TowerDamageBolt = 629;

		public const short Phantasm = 630;

		public const short PhantasmArrow = 631;

		public const short LastPrismLaser = 632;

		public const short LastPrism = 633;

		public const short NebulaBlaze1 = 634;

		public const short NebulaBlaze2 = 635;

		public const short Daybreak = 636;

		public const short BouncyDynamite = 637;

		public const short MoonlordBullet = 638;

		public const short MoonlordArrow = 639;

		public const short MoonlordArrowTrail = 640;

		public const short MoonlordTurret = 641;

		public const short MoonlordTurretLaser = 642;

		public const short RainbowCrystal = 643;

		public const short RainbowCrystalExplosion = 644;

		public const short LunarFlare = 645;

		public const short LunarHookSolar = 646;

		public const short LunarHookVortex = 647;

		public const short LunarHookNebula = 648;

		public const short LunarHookStardust = 649;

		public const short SuspiciousTentacle = 650;

		public const short WireKite = 651;

		public const short StaticHook = 652;

		public const short CompanionCube = 653;

		public const short GeyserTrap = 654;

		public const short BeeHive = 655;

		public const short SandnadoFriendly = 656;

		public const short SandnadoHostile = 657;

		public const short SandnadoHostileMark = 658;

		public const short SpiritFlame = 659;

		public const short SkyFracture = 660;

		public const short BlackBolt = 661;

		public const short Count = 662;
	}
}
