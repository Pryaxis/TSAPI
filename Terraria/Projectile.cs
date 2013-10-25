using System;
using TerrariaApi.Server;

namespace Terraria
{
	public class Projectile
	{
		public static int maxAI = 2;
		public float scale = 1f;
		public int owner = (int)byte.MaxValue;
		public string name = "";
		public float[] )ai = new float[Projectile.maxAI];
		public float[] localAI = new float[Projectile.maxAI];
		public float stepSpeed = 1f;
		public int spriteDirection = 1;
		public int penetrate = 1;
		public Vector2[] oldPos = new Vector2[10];
		public int[] playerImmune = new int[(int)byte.MaxValue];
		public string miscText = "";
		public int numHits;
		public bool netImportant;
		public bool noDropItem;
		public bool wet;
		public bool honeyWet;
		public byte wetCount;
		public bool lavaWet;
		public int whoAmI;
		public Vector2 position;
		public Vector2 lastPosition;
		public Vector2 velocity;
		public Vector2 lastVelocity;
		public int width;
		public int height;
		public float rotation;
		public int type;
		public int alpha;
		public bool active;
		public float gfxOffY;
		public int aiStyle;
		public int timeLeft;
		public int soundDelay;
		public int damage;
		public int direction;
		public bool hostile;
		public float knockBack;
		public bool friendly;
		public int identity;
		public float light;
		public bool netUpdate;
		public bool netUpdate2;
		public int netSpam;
		public bool minion;
		public int minionPos;
		public int restrikeDelay;
		public bool tileCollide;
		public int maxUpdates;
		public int numUpdates;
		public bool ignoreWater;
		public bool hide;
		public bool ownerHitCheck;
		public bool melee;
		public bool ranged;
		public bool magic;
		public int frameCounter;
		public int frame;

		static Projectile()
		{
		}

		public void SetDefaults(int Type)
		{
			this.numHits = 0;
			this.netImportant = false;
			for (int index = 0; index < this.oldPos.Length; ++index)
			{
				this.oldPos[index].X = 0.0f;
				this.oldPos[index].Y = 0.0f;
			}
			for (int index = 0; index < Projectile.maxAI; ++index)
			{
				this.ai[index] = 0.0f;
				this.localAI[index] = 0.0f;
			}
			for (int index = 0; index < (int)byte.MaxValue; ++index)
				this.playerImmune[index] = 0;
			this.noDropItem = false;
			this.minion = false;
			this.soundDelay = 0;
			this.spriteDirection = 1;
			this.melee = false;
			this.ranged = false;
			this.magic = false;
			this.ownerHitCheck = false;
			this.hide = false;
			this.lavaWet = false;
			this.wetCount = (byte)0;
			this.wet = false;
			this.ignoreWater = false;
			this.hostile = false;
			this.netUpdate = false;
			this.netUpdate2 = false;
			this.netSpam = 0;
			this.numUpdates = 0;
			this.maxUpdates = 0;
			this.identity = 0;
			this.restrikeDelay = 0;
			this.light = 0.0f;
			this.penetrate = 1;
			this.tileCollide = true;
			this.position = new Vector2();
			this.velocity = new Vector2();
			this.aiStyle = 0;
			this.alpha = 0;
			this.type = Type;
			this.active = true;
			this.rotation = 0.0f;
			this.scale = 1f;
			this.owner = (int)byte.MaxValue;
			this.timeLeft = 3600;
			this.name = "";
			this.friendly = false;
			this.damage = 0;
			this.knockBack = 0.0f;
			this.miscText = "";
			if (this.type == 1)
			{
				this.name = "Wooden Arrow";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.ranged = true;
			}
			else if (this.type == 2)
			{
				this.name = "Fire Arrow";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.light = 1f;
				this.ranged = true;
			}
			else if (this.type == 3)
			{
				this.name = "Shuriken";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 2;
				this.friendly = true;
				this.penetrate = 4;
				this.ranged = true;
			}
			else if (this.type == 4)
			{
				this.name = "Unholy Arrow";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.light = 0.35f;
				this.penetrate = 5;
				this.ranged = true;
			}
			else if (this.type == 5)
			{
				this.name = "Jester's Arrow";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.light = 0.4f;
				this.penetrate = -1;
				this.timeLeft = 120;
				this.alpha = 100;
				this.ignoreWater = true;
				this.ranged = true;
				this.maxUpdates = 1;
			}
			else if (this.type == 6)
			{
				this.name = "Enchanted Boomerang";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 3;
				this.friendly = true;
				this.penetrate = -1;
				this.melee = true;
				this.light = 0.4f;
			}
			else if (this.type == 7 || this.type == 8)
			{
				this.name = "Vilethorn";
				this.width = 28;
				this.height = 28;
				this.aiStyle = 4;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.alpha = (int)byte.MaxValue;
				this.ignoreWater = true;
				this.magic = true;
			}
			else if (this.type == 9)
			{
				this.name = "Starfury";
				this.width = 24;
				this.height = 24;
				this.aiStyle = 5;
				this.friendly = true;
				this.penetrate = 2;
				this.alpha = 50;
				this.scale = 0.8f;
				this.tileCollide = false;
				this.magic = true;
			}
			else if (this.type == 10)
			{
				this.name = "Purification Powder";
				this.width = 64;
				this.height = 64;
				this.aiStyle = 6;
				this.friendly = true;
				this.tileCollide = false;
				this.penetrate = -1;
				this.alpha = (int)byte.MaxValue;
				this.ignoreWater = true;
			}
			else if (this.type == 11)
			{
				this.name = "Vile Powder";
				this.width = 48;
				this.height = 48;
				this.aiStyle = 6;
				this.friendly = true;
				this.tileCollide = false;
				this.penetrate = -1;
				this.alpha = (int)byte.MaxValue;
				this.ignoreWater = true;
			}
			else if (this.type == 12)
			{
				this.name = "Falling Star";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 5;
				this.friendly = true;
				this.penetrate = -1;
				this.alpha = 50;
				this.light = 1f;
			}
			else if (this.type == 13)
			{
				this.netImportant = true;
				this.name = "Hook";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 7;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.timeLeft *= 10;
			}
			else if (this.type == 14)
			{
				this.name = "Bullet";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 1;
				this.light = 0.5f;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 1;
				this.scale = 1.2f;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else if (this.type == 15)
			{
				this.name = "Ball of Fire";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 8;
				this.friendly = true;
				this.light = 0.8f;
				this.alpha = 100;
				this.magic = true;
			}
			else if (this.type == 16)
			{
				this.name = "Magic Missile";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 9;
				this.friendly = true;
				this.light = 0.8f;
				this.alpha = 100;
				this.magic = true;
			}
			else if (this.type == 17)
			{
				this.name = "Dirt Ball";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.friendly = true;
			}
			else if (this.type == 18)
			{
				this.netImportant = true;
				this.name = "Shadow Orb";
				this.width = 32;
				this.height = 32;
				this.aiStyle = 11;
				this.friendly = true;
				this.light = 0.9f;
				this.alpha = 150;
				this.tileCollide = false;
				this.penetrate = -1;
				this.timeLeft *= 5;
				this.ignoreWater = true;
				this.scale = 0.8f;
			}
			else if (this.type == 19)
			{
				this.name = "Flamarang";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 3;
				this.friendly = true;
				this.penetrate = -1;
				this.light = 1f;
				this.melee = true;
			}
			else if (this.type == 20)
			{
				this.name = "Green Laser";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 3;
				this.light = 0.75f;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 2;
				this.scale = 1.4f;
				this.timeLeft = 600;
				this.magic = true;
			}
			else if (this.type == 21)
			{
				this.name = "Bone";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 2;
				this.scale = 1.2f;
				this.friendly = true;
				this.ranged = true;
			}
			else if (this.type == 22)
			{
				this.name = "Water Stream";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 12;
				this.friendly = true;
				this.alpha = (int)byte.MaxValue;
				this.penetrate = -1;
				this.maxUpdates = 2;
				this.ignoreWater = true;
				this.magic = true;
			}
			else if (this.type == 23)
			{
				this.name = "Harpoon";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 13;
				this.friendly = true;
				this.penetrate = -1;
				this.alpha = (int)byte.MaxValue;
				this.ranged = true;
			}
			else if (this.type == 24)
			{
				this.name = "Spiky Ball";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 14;
				this.friendly = true;
				this.penetrate = 6;
				this.ranged = true;
			}
			else if (this.type == 25)
			{
				this.name = "Ball 'O Hurt";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 15;
				this.friendly = true;
				this.penetrate = -1;
				this.melee = true;
				this.scale = 0.8f;
			}
			else if (this.type == 26)
			{
				this.name = "Blue Moon";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 15;
				this.friendly = true;
				this.penetrate = -1;
				this.melee = true;
				this.scale = 0.8f;
			}
			else if (this.type == 27)
			{
				this.name = "Water Bolt";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 8;
				this.friendly = true;
				this.alpha = (int)byte.MaxValue;
				this.timeLeft /= 2;
				this.penetrate = 10;
				this.magic = true;
			}
			else if (this.type == 28)
			{
				this.name = "Bomb";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 16;
				this.friendly = true;
				this.penetrate = -1;
			}
			else if (this.type == 29)
			{
				this.name = "Dynamite";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 16;
				this.friendly = true;
				this.penetrate = -1;
			}
			else if (this.type == 30)
			{
				this.name = "Grenade";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 16;
				this.friendly = true;
				this.penetrate = -1;
				this.ranged = true;
			}
			else if (this.type == 31)
			{
				this.name = "Sand Ball";
				this.knockBack = 6f;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.friendly = true;
				this.hostile = true;
				this.penetrate = -1;
			}
			else if (this.type == 32)
			{
				this.name = "Ivy Whip";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 7;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.timeLeft *= 10;
			}
			else if (this.type == 33)
			{
				this.name = "Thorn Chakrum";
				this.width = 38;
				this.height = 38;
				this.aiStyle = 3;
				this.friendly = true;
				this.scale = 0.9f;
				this.penetrate = -1;
				this.melee = true;
			}
			else if (this.type == 34)
			{
				this.name = "Flamelash";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 9;
				this.friendly = true;
				this.light = 0.8f;
				this.alpha = 100;
				this.penetrate = 1;
				this.magic = true;
			}
			else if (this.type == 35)
			{
				this.name = "Sunfury";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 15;
				this.friendly = true;
				this.penetrate = -1;
				this.melee = true;
				this.scale = 0.8f;
			}
			else if (this.type == 36)
			{
				this.name = "Meteor Shot";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 2;
				this.light = 0.6f;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 1;
				this.scale = 1.4f;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else if (this.type == 37)
			{
				this.name = "Sticky Bomb";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 16;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
			}
			else if (this.type == 38)
			{
				this.name = "Harpy Feather";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 0;
				this.hostile = true;
				this.penetrate = -1;
				this.aiStyle = 1;
				this.tileCollide = true;
			}
			else if (this.type == 39)
			{
				this.name = "Mud Ball";
				this.knockBack = 6f;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.friendly = true;
				this.hostile = true;
				this.penetrate = -1;
			}
			else if (this.type == 40)
			{
				this.name = "Ash Ball";
				this.knockBack = 6f;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.friendly = true;
				this.hostile = true;
				this.penetrate = -1;
			}
			else if (this.type == 41)
			{
				this.name = "Hellfire Arrow";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = -1;
				this.ranged = true;
				this.light = 0.3f;
			}
			else if (this.type == 42)
			{
				this.name = "Sand Ball";
				this.knockBack = 8f;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.friendly = true;
				this.maxUpdates = 1;
			}
			else if (this.type == 43)
			{
				this.name = "Tombstone";
				this.knockBack = 12f;
				this.width = 24;
				this.height = 24;
				this.aiStyle = 17;
				this.penetrate = -1;
			}
			else if (this.type == 44)
			{
				this.name = "Demon Sickle";
				this.width = 48;
				this.height = 48;
				this.alpha = 100;
				this.light = 0.2f;
				this.aiStyle = 18;
				this.hostile = true;
				this.penetrate = -1;
				this.tileCollide = true;
				this.scale = 0.9f;
			}
			else if (this.type == 45)
			{
				this.name = "Demon Scythe";
				this.width = 48;
				this.height = 48;
				this.alpha = 100;
				this.light = 0.2f;
				this.aiStyle = 18;
				this.friendly = true;
				this.penetrate = 5;
				this.tileCollide = true;
				this.scale = 0.9f;
				this.magic = true;
			}
			else if (this.type == 46)
			{
				this.name = "Dark Lance";
				this.width = 20;
				this.height = 20;
				this.aiStyle = 19;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.scale = 1.1f;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 47)
			{
				this.name = "Trident";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 19;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.scale = 1.1f;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 48)
			{
				this.name = "Throwing Knife";
				this.width = 12;
				this.height = 12;
				this.aiStyle = 2;
				this.friendly = true;
				this.penetrate = 2;
				this.ranged = true;
			}
			else if (this.type == 49)
			{
				this.name = "Spear";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 19;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.scale = 1.2f;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 50)
			{
				this.netImportant = true;
				this.name = "Glowstick";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 14;
				this.penetrate = -1;
				this.alpha = 75;
				this.light = 1f;
				this.timeLeft *= 5;
			}
			else if (this.type == 51)
			{
				this.name = "Seed";
				this.width = 8;
				this.height = 8;
				this.aiStyle = 1;
				this.friendly = true;
			}
			else if (this.type == 52)
			{
				this.name = "Wooden Boomerang";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 3;
				this.friendly = true;
				this.penetrate = -1;
				this.melee = true;
			}
			else if (this.type == 53)
			{
				this.netImportant = true;
				this.name = "Sticky Glowstick";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 14;
				this.penetrate = -1;
				this.alpha = 75;
				this.light = 1f;
				this.timeLeft *= 5;
				this.tileCollide = false;
			}
			else if (this.type == 54)
			{
				this.name = "Poisoned Knife";
				this.width = 12;
				this.height = 12;
				this.aiStyle = 2;
				this.friendly = true;
				this.penetrate = 2;
				this.ranged = true;
			}
			else if (this.type == 55)
			{
				this.name = "Stinger";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 0;
				this.hostile = true;
				this.penetrate = -1;
				this.aiStyle = 1;
				this.tileCollide = true;
			}
			else if (this.type == 56)
			{
				this.name = "Ebonsand Ball";
				this.knockBack = 6f;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.friendly = true;
				this.hostile = true;
				this.penetrate = -1;
			}
			else if (this.type == 57)
			{
				this.name = "Cobalt Chainsaw";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 58)
			{
				this.name = "Mythril Chainsaw";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
				this.scale = 1.08f;
			}
			else if (this.type == 59)
			{
				this.name = "Cobalt Drill";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
				this.scale = 0.9f;
			}
			else if (this.type == 60)
			{
				this.name = "Mythril Drill";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
				this.scale = 0.9f;
			}
			else if (this.type == 61)
			{
				this.name = "Adamantite Chainsaw";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
				this.scale = 1.16f;
			}
			else if (this.type == 62)
			{
				this.name = "Adamantite Drill";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
				this.scale = 0.9f;
			}
			else if (this.type == 63)
			{
				this.name = "The Dao of Pow";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 15;
				this.friendly = true;
				this.penetrate = -1;
				this.melee = true;
			}
			else if (this.type == 64)
			{
				this.name = "Mythril Halberd";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 19;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.scale = 1.25f;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 65)
			{
				this.name = "Ebonsand Ball";
				this.knockBack = 6f;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.friendly = true;
				this.penetrate = -1;
				this.maxUpdates = 1;
			}
			else if (this.type == 66)
			{
				this.name = "Adamantite Glaive";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 19;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.scale = 1.27f;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 67)
			{
				this.name = "Pearl Sand Ball";
				this.knockBack = 6f;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.friendly = true;
				this.hostile = true;
				this.penetrate = -1;
			}
			else if (this.type == 68)
			{
				this.name = "Pearl Sand Ball";
				this.knockBack = 6f;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.friendly = true;
				this.penetrate = -1;
				this.maxUpdates = 1;
			}
			else if (this.type == 69)
			{
				this.name = "Holy Water";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 2;
				this.friendly = true;
				this.penetrate = 1;
			}
			else if (this.type == 70)
			{
				this.name = "Unholy Water";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 2;
				this.friendly = true;
				this.penetrate = 1;
			}
			else if (this.type == 71)
			{
				this.name = "Silt Ball";
				this.knockBack = 6f;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.friendly = true;
				this.hostile = true;
				this.penetrate = -1;
			}
			else if (this.type == 72)
			{
				this.netImportant = true;
				this.name = "Blue Fairy";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 11;
				this.friendly = true;
				this.light = 0.9f;
				this.tileCollide = false;
				this.penetrate = -1;
				this.timeLeft *= 5;
				this.ignoreWater = true;
				this.scale = 0.8f;
			}
			else if (this.type == 73 || this.type == 74)
			{
				this.netImportant = true;
				this.name = "Hook";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 7;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.timeLeft *= 10;
				this.light = 0.4f;
			}
			else if (this.type == 75)
			{
				this.name = "Happy Bomb";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 16;
				this.hostile = true;
				this.penetrate = -1;
			}
			else if (this.type == 76 || this.type == 77 || this.type == 78)
			{
				if (this.type == 76)
				{
					this.width = 10;
					this.height = 22;
				}
				else if (this.type == 77)
				{
					this.width = 18;
					this.height = 24;
				}
				else
				{
					this.width = 22;
					this.height = 24;
				}
				this.name = "Note";
				this.aiStyle = 21;
				this.friendly = true;
				this.ranged = true;
				this.alpha = 100;
				this.light = 0.3f;
				this.penetrate = -1;
				this.timeLeft = 180;
				this.magic = true;
			}
			else if (this.type == 79)
			{
				this.name = "Rainbow";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 9;
				this.friendly = true;
				this.light = 0.8f;
				this.alpha = (int)byte.MaxValue;
				this.magic = true;
			}
			else if (this.type == 80)
			{
				this.name = "Ice Block";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 22;
				this.friendly = true;
				this.magic = true;
				this.tileCollide = false;
				this.light = 0.5f;
			}
			else if (this.type == 81)
			{
				this.name = "Wooden Arrow";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.hostile = true;
				this.ranged = true;
			}
			else if (this.type == 82)
			{
				this.name = "Flaming Arrow";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.hostile = true;
				this.ranged = true;
			}
			else if (this.type == 83)
			{
				this.name = "Eye Laser";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.hostile = true;
				this.penetrate = 3;
				this.light = 0.75f;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 2;
				this.scale = 1.7f;
				this.timeLeft = 600;
				this.magic = true;
			}
			else if (this.type == 84)
			{
				this.name = "Pink Laser";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.hostile = true;
				this.penetrate = 3;
				this.light = 0.75f;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 2;
				this.scale = 1.2f;
				this.timeLeft = 600;
				this.magic = true;
			}
			else if (this.type == 85)
			{
				this.name = "Flames";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 23;
				this.friendly = true;
				this.alpha = 255;
				this.penetrate = 3;
				this.maxUpdates = 2;
				this.ranged = true;
			}
			else if (this.type == 86)
			{
				this.netImportant = true;
				this.name = "Pink Fairy";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 11;
				this.friendly = true;
				this.light = 0.9f;
				this.tileCollide = false;
				this.penetrate = -1;
				this.timeLeft *= 5;
				this.ignoreWater = true;
				this.scale = 0.8f;
			}
			else if (this.type == 87)
			{
				this.netImportant = true;
				this.name = "Pink Fairy";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 11;
				this.friendly = true;
				this.light = 0.9f;
				this.tileCollide = false;
				this.penetrate = -1;
				this.timeLeft *= 5;
				this.ignoreWater = true;
				this.scale = 0.8f;
			}
			else if (this.type == 88)
			{
				this.name = "Purple Laser";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 3;
				this.light = 0.75f;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 4;
				this.scale = 1.4f;
				this.timeLeft = 600;
				this.magic = true;
			}
			else if (this.type == 89)
			{
				this.name = "Crystal Bullet";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 1;
				this.light = 0.5f;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 1;
				this.scale = 1.2f;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else if (this.type == 90)
			{
				this.name = "Crystal Shard";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 24;
				this.friendly = true;
				this.penetrate = 1;
				this.light = 0.5f;
				this.alpha = 50;
				this.scale = 1.2f;
				this.timeLeft = 600;
				this.ranged = true;
				this.tileCollide = false;
			}
			else if (this.type == 91)
			{
				this.name = "Holy Arrow";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.ranged = true;
			}
			else if (this.type == 92)
			{
				this.name = "Hallow Star";
				this.width = 24;
				this.height = 24;
				this.aiStyle = 5;
				this.friendly = true;
				this.penetrate = 2;
				this.alpha = 50;
				this.scale = 0.8f;
				this.tileCollide = false;
				this.magic = true;
			}
			else if (this.type == 93)
			{
				this.light = 0.15f;
				this.name = "Magic Dagger";
				this.width = 12;
				this.height = 12;
				this.aiStyle = 2;
				this.friendly = true;
				this.penetrate = 2;
				this.magic = true;
			}
			else if (this.type == 94)
			{
				this.ignoreWater = true;
				this.name = "Crystal Storm";
				this.width = 8;
				this.height = 8;
				this.aiStyle = 24;
				this.friendly = true;
				this.light = 0.5f;
				this.alpha = 50;
				this.scale = 1.2f;
				this.timeLeft = 600;
				this.magic = true;
				this.tileCollide = true;
				this.penetrate = 1;
			}
			else if (this.type == 95)
			{
				this.name = "Cursed Flame";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 8;
				this.friendly = true;
				this.light = 0.8f;
				this.alpha = 100;
				this.magic = true;
				this.penetrate = 2;
			}
			else if (this.type == 96)
			{
				this.name = "Cursed Flame";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 8;
				this.hostile = true;
				this.light = 0.8f;
				this.alpha = 100;
				this.magic = true;
				this.penetrate = -1;
				this.scale = 0.9f;
				this.scale = 1.3f;
			}
			else if (this.type == 97)
			{
				this.name = "Cobalt Naginata";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 19;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.scale = 1.1f;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 98)
			{
				this.name = "Poison Dart";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.hostile = true;
				this.ranged = true;
				this.penetrate = -1;
			}
			else if (this.type == 99)
			{
				this.name = "Boulder";
				this.width = 31;
				this.height = 31;
				this.aiStyle = 25;
				this.friendly = true;
				this.hostile = true;
				this.ranged = true;
				this.penetrate = -1;
			}
			else if (this.type == 100)
			{
				this.name = "Death Laser";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.hostile = true;
				this.penetrate = 3;
				this.light = 0.75f;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 2;
				this.scale = 1.8f;
				this.timeLeft = 1200;
				this.magic = true;
			}
			else if (this.type == 101)
			{
				this.name = "Eye Fire";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 23;
				this.hostile = true;
				this.alpha = (int)byte.MaxValue;
				this.penetrate = -1;
				this.maxUpdates = 3;
				this.magic = true;
			}
			else if (this.type == 102)
			{
				this.name = "Bomb";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 16;
				this.hostile = true;
				this.penetrate = -1;
				this.ranged = true;
			}
			else if (this.type == 103)
			{
				this.name = "Cursed Arrow";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.light = 1f;
				this.ranged = true;
			}
			else if (this.type == 104)
			{
				this.name = "Cursed Bullet";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 1;
				this.light = 0.5f;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 1;
				this.scale = 1.2f;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else if (this.type == 105)
			{
				this.name = "Gungnir";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 19;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.scale = 1.3f;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 106)
			{
				this.name = "Light Disc";
				this.width = 32;
				this.height = 32;
				this.aiStyle = 3;
				this.friendly = true;
				this.penetrate = -1;
				this.melee = true;
				this.light = 0.4f;
			}
			else if (this.type == 107)
			{
				this.name = "Hamdrax";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
				this.scale = 1.1f;
			}
			else if (this.type == 108)
			{
				this.name = "Explosives";
				this.width = 260;
				this.height = 260;
				this.aiStyle = 16;
				this.friendly = true;
				this.hostile = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.alpha = (int)byte.MaxValue;
				this.timeLeft = 2;
			}
			else if (this.type == 109)
			{
				this.name = "Snow Ball";
				this.knockBack = 6f;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.hostile = true;
				this.scale = 0.9f;
				this.penetrate = -1;
			}
			else if (this.type == 110)
			{
				this.name = "Bullet";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.hostile = true;
				this.penetrate = -1;
				this.light = 0.5f;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 1;
				this.scale = 1.2f;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else if (this.type == 111)
			{
				this.netImportant = true;
				this.name = "Bunny";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 26;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft *= 5;
			}
			else if (this.type == 112)
			{
				this.netImportant = true;
				this.name = "Penguin";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 26;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft *= 5;
			}
			else if (this.type == 113)
			{
				this.name = "Ice Boomerang";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 3;
				this.friendly = true;
				this.penetrate = -1;
				this.melee = true;
				this.light = 0.4f;
			}
			else if (this.type == 114)
			{
				this.name = "Unholy Trident";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 27;
				this.magic = true;
				this.penetrate = 3;
				this.light = 0.5f;
				this.alpha = (int)byte.MaxValue;
				this.friendly = true;
			}
			else if (this.type == 115)
			{
				this.name = "Unholy Trident";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 27;
				this.hostile = true;
				this.magic = true;
				this.penetrate = -1;
				this.light = 0.5f;
				this.alpha = (int)byte.MaxValue;
			}
			else if (this.type == 116)
			{
				this.name = "Sword Beam";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 27;
				this.melee = true;
				this.penetrate = 1;
				this.light = 0.5f;
				this.alpha = (int)byte.MaxValue;
				this.friendly = true;
			}
			else if (this.type == 117)
			{
				this.name = "Bone Arrow";
				this.maxUpdates = 2;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.ranged = true;
			}
			else if (this.type == 118)
			{
				this.name = "Ice Bolt";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 28;
				this.alpha = (int)byte.MaxValue;
				this.melee = true;
				this.penetrate = 1;
				this.friendly = true;
			}
			else if (this.type == 119)
			{
				this.name = "Frost Bolt";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 28;
				this.alpha = (int)byte.MaxValue;
				this.melee = true;
				this.penetrate = 2;
				this.friendly = true;
			}
			else if (this.type == 120)
			{
				this.name = "Frost Arrow";
				this.maxUpdates = 1;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.ranged = true;
			}
			else if (this.type == 121)
			{
				this.name = "Amethyst Bolt";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 29;
				this.alpha = (int)byte.MaxValue;
				this.magic = true;
				this.penetrate = 1;
				this.friendly = true;
			}
			else if (this.type == 122)
			{
				this.name = "Topaz Bolt";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 29;
				this.alpha = (int)byte.MaxValue;
				this.magic = true;
				this.penetrate = 2;
				this.friendly = true;
			}
			else if (this.type == 123)
			{
				this.name = "Sapphire Bolt";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 29;
				this.alpha = (int)byte.MaxValue;
				this.magic = true;
				this.penetrate = 2;
				this.friendly = true;
			}
			else if (this.type == 124)
			{
				this.name = "Emerald Bolt";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 29;
				this.alpha = (int)byte.MaxValue;
				this.magic = true;
				this.penetrate = 3;
				this.friendly = true;
			}
			else if (this.type == 125)
			{
				this.name = "Ruby Bolt";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 29;
				this.alpha = (int)byte.MaxValue;
				this.magic = true;
				this.penetrate = 3;
				this.friendly = true;
			}
			else if (this.type == 126)
			{
				this.name = "Diamond Bolt";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 29;
				this.alpha = (int)byte.MaxValue;
				this.magic = true;
				this.penetrate = 4;
				this.friendly = true;
			}
			else if (this.type == (int)sbyte.MaxValue)
			{
				this.netImportant = true;
				this.name = "Turtle";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 26;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft *= 5;
			}
			else if (this.type == 128)
			{
				this.name = "Frost Blast";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 28;
				this.alpha = (int)byte.MaxValue;
				this.penetrate = -1;
				this.friendly = false;
				this.hostile = true;
			}
			else if (this.type == 129)
			{
				this.name = "Rune Blast";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 28;
				this.alpha = (int)byte.MaxValue;
				this.penetrate = -1;
				this.friendly = false;
				this.hostile = true;
				this.tileCollide = false;
			}
			else if (this.type == 130)
			{
				this.name = "Mushroom Spear";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 19;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.scale = 1.2f;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 131)
			{
				this.name = "Mushroom";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 30;
				this.friendly = true;
				this.penetrate = 1;
				this.tileCollide = false;
				this.melee = true;
				this.light = 0.5f;
			}
			else if (this.type == 132)
			{
				this.name = "Terra Beam";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 27;
				this.melee = true;
				this.penetrate = 3;
				this.light = 0.5f;
				this.alpha = (int)byte.MaxValue;
				this.friendly = true;
			}
			else if (this.type == 133)
			{
				this.name = "Grenade";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 16;
				this.friendly = true;
				this.penetrate = -1;
				this.ranged = true;
			}
			else if (this.type == 134)
			{
				this.name = "Rocket";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 16;
				this.friendly = true;
				this.penetrate = -1;
				this.ranged = true;
			}
			else if (this.type == 135)
			{
				this.name = "Proximity Mine";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 16;
				this.friendly = true;
				this.penetrate = -1;
				this.ranged = true;
			}
			else if (this.type == 136)
			{
				this.name = "Grenade";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 16;
				this.friendly = true;
				this.penetrate = -1;
				this.ranged = true;
			}
			else if (this.type == 137)
			{
				this.name = "Rocket";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 16;
				this.friendly = true;
				this.penetrate = -1;
				this.ranged = true;
			}
			else if (this.type == 138)
			{
				this.name = "Proximity Mine";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 16;
				this.friendly = true;
				this.penetrate = -1;
				this.ranged = true;
			}
			else if (this.type == 139)
			{
				this.name = "Grenade";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 16;
				this.friendly = true;
				this.penetrate = -1;
				this.ranged = true;
			}
			else if (this.type == 140)
			{
				this.name = "Rocket";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 16;
				this.friendly = true;
				this.penetrate = -1;
				this.ranged = true;
			}
			else if (this.type == 141)
			{
				this.name = "Proximity Mine";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 16;
				this.friendly = true;
				this.penetrate = -1;
				this.ranged = true;
			}
			else if (this.type == 142)
			{
				this.name = "Grenade";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 16;
				this.friendly = true;
				this.penetrate = -1;
				this.ranged = true;
			}
			else if (this.type == 143)
			{
				this.name = "Rocket";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 16;
				this.friendly = true;
				this.penetrate = -1;
				this.ranged = true;
			}
			else if (this.type == 144)
			{
				this.name = "Proximity Mine";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 16;
				this.friendly = true;
				this.penetrate = -1;
				this.ranged = true;
			}
			else if (this.type == 145)
			{
				this.name = "Pure Spray";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 31;
				this.friendly = true;
				this.alpha = (int)byte.MaxValue;
				this.penetrate = -1;
				this.maxUpdates = 2;
				this.tileCollide = false;
				this.ignoreWater = true;
			}
			else if (this.type == 146)
			{
				this.name = "Hallow Spray";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 31;
				this.friendly = true;
				this.alpha = (int)byte.MaxValue;
				this.penetrate = -1;
				this.maxUpdates = 2;
				this.tileCollide = false;
				this.ignoreWater = true;
			}
			else if (this.type == 147)
			{
				this.name = "Corrupt Spray";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 31;
				this.friendly = true;
				this.alpha = (int)byte.MaxValue;
				this.penetrate = -1;
				this.maxUpdates = 2;
				this.tileCollide = false;
				this.ignoreWater = true;
			}
			else if (this.type == 148)
			{
				this.name = "Mushroom Spray";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 31;
				this.friendly = true;
				this.alpha = (int)byte.MaxValue;
				this.penetrate = -1;
				this.maxUpdates = 2;
				this.tileCollide = false;
				this.ignoreWater = true;
			}
			else if (this.type == 149)
			{
				this.name = "Crimson Spray";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 31;
				this.friendly = true;
				this.alpha = (int)byte.MaxValue;
				this.penetrate = -1;
				this.maxUpdates = 2;
				this.tileCollide = false;
				this.ignoreWater = true;
			}
			else if (this.type == 150 || this.type == 151 || this.type == 152)
			{
				this.name = "Nettle Burst";
				this.width = 28;
				this.height = 28;
				this.aiStyle = 4;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.alpha = (int)byte.MaxValue;
				this.ignoreWater = true;
				this.magic = true;
			}
			else if (this.type == 153)
			{
				this.name = "The Rotted Fork";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 19;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.scale = 1.1f;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 154)
			{
				this.name = "The Meatball";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 15;
				this.friendly = true;
				this.penetrate = -1;
				this.melee = true;
				this.scale = 0.8f;
			}
			else if (this.type == 155)
			{
				this.netImportant = true;
				this.name = "Beach Ball";
				this.width = 44;
				this.height = 44;
				this.aiStyle = 32;
				this.friendly = true;
			}
			else if (this.type == 156)
			{
				this.name = "Light Beam";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 27;
				this.melee = true;
				this.light = 0.5f;
				this.alpha = (int)byte.MaxValue;
				this.friendly = true;
			}
			else if (this.type == 157)
			{
				this.name = "Night Beam";
				this.width = 32;
				this.height = 32;
				this.aiStyle = 27;
				this.melee = true;
				this.light = 0.5f;
				this.alpha = (int)byte.MaxValue;
				this.friendly = true;
				this.scale = 1.2f;
			}
			else if (this.type == 158)
			{
				this.name = "Copper Coin";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 1;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 1;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else if (this.type == 159)
			{
				this.name = "Silver Coin";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 1;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 1;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else if (this.type == 160)
			{
				this.name = "Gold Coin";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 1;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 1;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else if (this.type == 161)
			{
				this.name = "Platinum Coin";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 1;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 1;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else if (this.type == 162)
			{
				this.name = "Cannonball";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 2;
				this.friendly = true;
				this.penetrate = 4;
				this.alpha = (int)byte.MaxValue;
			}
			else if (this.type == 163)
			{
				this.netImportant = true;
				this.name = "Flare";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 33;
				this.friendly = true;
				this.penetrate = -1;
				this.alpha = (int)byte.MaxValue;
				this.timeLeft = 36000;
			}
			else if (this.type == 164)
			{
				this.name = "Landmine";
				this.width = 128;
				this.height = 128;
				this.aiStyle = 16;
				this.friendly = true;
				this.hostile = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.alpha = (int)byte.MaxValue;
				this.timeLeft = 2;
			}
			else if (this.type == 165)
			{
				this.netImportant = true;
				this.name = "Web";
				this.width = 12;
				this.height = 12;
				this.aiStyle = 7;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.timeLeft *= 10;
			}
			else if (this.type == 166)
			{
				this.name = "Snow Ball";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 2;
				this.friendly = true;
				this.ranged = true;
			}
			else if (this.type == 167 || this.type == 168 || (this.type == 169 || this.type == 170))
			{
				this.name = "Rocket";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 34;
				this.friendly = true;
				this.ranged = true;
				this.timeLeft = 45;
			}
			else if (this.type == 171)
			{
				this.name = "Rope Coil";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 35;
				this.penetrate = -1;
				this.tileCollide = false;
				this.timeLeft = 400;
			}
			else if (this.type == 172)
			{
				this.name = "Frostburn Arrow";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.light = 1f;
				this.ranged = true;
			}
			else if (this.type == 173)
			{
				this.name = "Enchanted Beam";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 27;
				this.melee = true;
				this.penetrate = 1;
				this.light = 0.2f;
				this.alpha = (int)byte.MaxValue;
				this.friendly = true;
			}
			else if (this.type == 174)
			{
				this.name = "Ice Spike";
				this.alpha = (int)byte.MaxValue;
				this.width = 6;
				this.height = 6;
				this.aiStyle = 1;
				this.hostile = true;
				this.penetrate = -1;
			}
			else if (this.type == 175)
			{
				this.name = "Baby Eater";
				this.width = 34;
				this.height = 34;
				this.aiStyle = 26;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft *= 5;
			}
			else if (this.type == 176)
			{
				this.name = "Jungle Spike";
				this.alpha = (int)byte.MaxValue;
				this.width = 6;
				this.height = 6;
				this.aiStyle = 1;
				this.hostile = true;
				this.penetrate = -1;
			}
			else if (this.type == 177)
			{
				this.name = "Icewater Spit";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 28;
				this.alpha = (int)byte.MaxValue;
				this.penetrate = -1;
				this.friendly = false;
				this.hostile = true;
			}
			else if (this.type == 178)
			{
				this.name = "Confetti";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.alpha = (int)byte.MaxValue;
				this.penetrate = -1;
				this.timeLeft = 2;
			}
			else if (this.type == 179)
			{
				this.name = "Slush Ball";
				this.knockBack = 6f;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.friendly = true;
				this.hostile = true;
				this.penetrate = -1;
			}
			else if (this.type == 180)
			{
				this.name = "Bullet";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.hostile = true;
				this.penetrate = -1;
				this.light = 0.5f;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 1;
				this.scale = 1.2f;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else if (this.type == 181)
			{
				this.name = "Bee";
				this.width = 8;
				this.height = 8;
				this.aiStyle = 36;
				this.friendly = true;
				this.penetrate = 3;
				this.alpha = (int)byte.MaxValue;
				this.timeLeft = 600;
				this.magic = true;
				this.maxUpdates = 3;
			}
			else if (this.type == 182)
			{
				this.light = 0.15f;
				this.name = "Possessed Hatchet";
				this.width = 30;
				this.height = 30;
				this.aiStyle = 3;
				this.friendly = true;
				this.penetrate = 10;
				this.melee = true;
				this.maxUpdates = 1;
			}
			else if (this.type == 183)
			{
				this.name = "Beenade";
				this.width = 14;
				this.height = 22;
				this.aiStyle = 14;
				this.penetrate = 1;
				this.ranged = true;
				this.timeLeft = 180;
				this.friendly = true;
			}
			else if (this.type == 184)
			{
				this.name = "Poison Dart";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 1;
				this.friendly = true;
				this.hostile = true;
				this.ranged = true;
				this.penetrate = -1;
			}
			else if (this.type == 185)
			{
				this.name = "Spiky Ball";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 14;
				this.friendly = true;
				this.hostile = true;
				this.penetrate = -1;
				this.ranged = true;
				this.timeLeft = 900;
			}
			else if (this.type == 186)
			{
				this.name = "Spear";
				this.width = 10;
				this.height = 14;
				this.aiStyle = 37;
				this.friendly = true;
				this.tileCollide = false;
				this.ignoreWater = true;
				this.hostile = true;
				this.penetrate = -1;
				this.ranged = true;
				this.timeLeft = 300;
			}
			else if (this.type == 187)
			{
				this.name = "Flamethrower";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 38;
				this.alpha = (int)byte.MaxValue;
				this.tileCollide = false;
				this.ignoreWater = true;
				this.timeLeft = 60;
			}
			else if (this.type == 188)
			{
				this.name = "Flames";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 23;
				this.friendly = true;
				this.hostile = true;
				this.alpha = 255;
				this.penetrate = -1;
				this.maxUpdates = 2;
				this.magic = true;
			}
			else if (this.type == 189)
			{
				this.name = "Wasp";
				this.width = 8;
				this.height = 8;
				this.aiStyle = 36;
				this.friendly = true;
				this.penetrate = 4;
				this.alpha = (int)byte.MaxValue;
				this.timeLeft = 600;
				this.magic = true;
				this.maxUpdates = 3;
			}
			else if (this.type == 190)
			{
				this.name = "Mechanical Piranha";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 39;
				this.friendly = true;
				this.penetrate = -1;
				this.alpha = (int)byte.MaxValue;
				this.ranged = true;
			}
			else if (this.type >= 191 && this.type <= 194)
			{
				this.netImportant = true;
				this.name = "Pygmy";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 26;
				this.penetrate = -1;
				this.timeLeft *= 5;
				this.minion = true;
				if (this.type == 192)
					this.scale = 1.025f;
				if (this.type == 193)
					this.scale = 1.05f;
				if (this.type == 194)
					this.scale = 1.075f;
			}
			else if (this.type == 195)
			{
				this.name = "Pygmy";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
			}
			else if (this.type == 196)
			{
				this.name = "Smoke Bomb";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 14;
				this.penetrate = -1;
				this.scale = 0.8f;
			}
			else if (this.type == 197)
			{
				this.netImportant = true;
				this.name = "Baby Skeletron Head";
				this.width = 42;
				this.height = 42;
				this.aiStyle = 26;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft *= 5;
			}
			else if (this.type == 198)
			{
				this.netImportant = true;
				this.name = "Baby Hornet";
				this.width = 26;
				this.height = 26;
				this.aiStyle = 26;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft *= 5;
			}
			else if (this.type == 199)
			{
				this.netImportant = true;
				this.name = "Tiki Spirit";
				this.width = 28;
				this.height = 28;
				this.aiStyle = 26;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft *= 5;
			}
			else if (this.type == 200)
			{
				this.netImportant = true;
				this.name = "Pet Lizard";
				this.width = 28;
				this.height = 28;
				this.aiStyle = 26;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft *= 5;
			}
			else if (this.type == 201)
			{
				this.name = "Tombstone";
				this.knockBack = 12f;
				this.width = 24;
				this.height = 24;
				this.aiStyle = 17;
				this.penetrate = -1;
			}
			else if (this.type == 202)
			{
				this.name = "Tombstone";
				this.knockBack = 12f;
				this.width = 24;
				this.height = 24;
				this.aiStyle = 17;
				this.penetrate = -1;
			}
			else if (this.type == 203)
			{
				this.name = "Tombstone";
				this.knockBack = 12f;
				this.width = 24;
				this.height = 24;
				this.aiStyle = 17;
				this.penetrate = -1;
			}
			else if (this.type == 204)
			{
				this.name = "Tombstone";
				this.knockBack = 12f;
				this.width = 24;
				this.height = 24;
				this.aiStyle = 17;
				this.penetrate = -1;
			}
			else if (this.type == 205)
			{
				this.name = "Tombstone";
				this.knockBack = 12f;
				this.width = 24;
				this.height = 24;
				this.aiStyle = 17;
				this.penetrate = -1;
			}
			else if (this.type == 206)
			{
				this.name = "Leaf";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 40;
				this.friendly = true;
				this.penetrate = 1;
				this.alpha = (int)byte.MaxValue;
				this.timeLeft = 600;
				this.magic = true;
			}
			else if (this.type == 207)
			{
				this.name = "Bullet";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 1;
				this.light = 0.5f;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 2;
				this.scale = 1.2f;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else if (this.type == 208)
			{
				this.netImportant = true;
				this.name = "Parrot";
				this.width = 18;
				this.height = 36;
				this.aiStyle = 26;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft *= 5;
			}
			else if (this.type == 209)
			{
				this.name = "Truffle";
				this.width = 12;
				this.height = 32;
				this.aiStyle = 26;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft *= 5;
				this.light = 0.5f;
			}
			else if (this.type == 210)
			{
				this.netImportant = true;
				this.name = "Sapling";
				this.width = 14;
				this.height = 30;
				this.aiStyle = 26;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft *= 5;
			}
			else if (this.type == 211)
			{
				this.netImportant = true;
				this.name = "Wisp";
				this.width = 24;
				this.height = 24;
				this.aiStyle = 26;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft *= 5;
				this.light = 1f;
			}
			else if (this.type == 212)
			{
				this.name = "Palladium Pike";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 19;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.scale = 1.12f;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 213)
			{
				this.name = "Palladium Drill";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
				this.scale = 0.92f;
			}
			else if (this.type == 214)
			{
				this.name = "Palladium Chainsaw";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 215)
			{
				this.name = "Orichalcum Halberd";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 19;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.scale = 1.27f;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 216)
			{
				this.name = "Orichalcum Drill";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
				this.scale = 0.93f;
			}
			else if (this.type == 217)
			{
				this.name = "Orichalcum Chainsaw";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
				this.scale = 1.12f;
			}
			else if (this.type == 218)
			{
				this.name = "Titanium Trident";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 19;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.scale = 1.28f;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 219)
			{
				this.name = "Titanium Drill";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
				this.scale = 0.95f;
			}
			else if (this.type == 220)
			{
				this.name = "Titanium Chainsaw";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
				this.scale = 1.2f;
			}
			else if (this.type == 221)
			{
				this.name = "Flower Petal";
				this.width = 20;
				this.height = 20;
				this.aiStyle = 41;
				this.friendly = true;
				this.tileCollide = false;
				this.ignoreWater = true;
				this.timeLeft = 120;
				this.penetrate = -1;
				this.scale = (float)(1.0 + (double)Main.rand.Next(30) * 0.00999999977648258);
				this.maxUpdates = 2;
			}
			else if (this.type == 222)
			{
				this.name = "Chlorophyte Partisan";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 19;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.scale = 1.3f;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 223)
			{
				this.name = "Chlorophyte Drill";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
				this.scale = 1f;
			}
			else if (this.type == 224)
			{
				this.name = "Chlorophyte Chainsaw";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
				this.scale = 1.1f;
			}
			else if (this.type == 225)
			{
				this.penetrate = 2;
				this.name = "Chlorophyte Arrow";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.ranged = true;
			}
			else if (this.type == 226)
			{
				this.netImportant = true;
				this.name = "Crystal Leaf";
				this.width = 22;
				this.height = 42;
				this.aiStyle = 42;
				this.friendly = true;
				this.tileCollide = false;
				this.penetrate = -1;
				this.timeLeft *= 5;
				this.light = 0.4f;
				this.ignoreWater = true;
			}
			else if (this.type == 227)
			{
				this.netImportant = true;
				this.tileCollide = false;
				this.light = 0.1f;
				this.name = "Crystal Leaf";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 43;
				this.friendly = true;
				this.penetrate = 1;
				this.timeLeft = 180;
			}
			else if (this.type == 228)
			{
				this.tileCollide = false;
				this.name = "Spore Cloud";
				this.width = 30;
				this.height = 30;
				this.aiStyle = 44;
				this.friendly = true;
				this.scale = 1.1f;
				this.penetrate = -1;
			}
			else if (this.type == 229)
			{
				this.name = "Chlorophyte Orb";
				this.width = 30;
				this.height = 30;
				this.aiStyle = 44;
				this.friendly = true;
				this.penetrate = -1;
				this.light = 0.2f;
			}
			else if (this.type >= 230 && this.type <= 235)
			{
				this.netImportant = true;
				this.name = "Gem Hook";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 7;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.timeLeft *= 10;
			}
			else if (this.type == 236)
			{
				this.netImportant = true;
				this.name = "Baby Dino";
				this.width = 34;
				this.height = 34;
				this.aiStyle = 26;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft *= 5;
			}
			else if (this.type == 237)
			{
				this.netImportant = true;
				this.name = "Rain Cloud";
				this.width = 28;
				this.height = 28;
				this.aiStyle = 45;
				this.penetrate = -1;
			}
			else if (this.type == 238)
			{
				this.tileCollide = false;
				this.ignoreWater = true;
				this.name = "Rain Cloud";
				this.width = 54;
				this.height = 28;
				this.aiStyle = 45;
				this.penetrate = -1;
			}
			else if (this.type == 239)
			{
				this.ignoreWater = true;
				this.name = "Rain";
				this.width = 4;
				this.height = 40;
				this.aiStyle = 45;
				this.friendly = true;
				this.penetrate = -1;
				this.maxUpdates = 1;
				this.timeLeft = 300;
				this.scale = 1.1f;
				this.magic = true;
			}
			else if (this.type == 240)
			{
				this.name = "Cannonball";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 2;
				this.hostile = true;
				this.penetrate = -1;
				this.alpha = (int)byte.MaxValue;
			}
			else if (this.type == 241)
			{
				this.name = "Crimsand Ball";
				this.knockBack = 6f;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.friendly = true;
				this.hostile = true;
				this.penetrate = -1;
			}
			else if (this.type == 242)
			{
				this.name = "Bullet";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 1;
				this.light = 0.5f;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 7;
				this.scale = 1.18f;
				this.timeLeft = 600;
				this.ranged = true;
				this.ignoreWater = true;
			}
			else if (this.type == 243)
			{
				this.name = "Blood Cloud";
				this.width = 28;
				this.height = 28;
				this.aiStyle = 45;
				this.penetrate = -1;
			}
			else if (this.type == 244)
			{
				this.tileCollide = false;
				this.ignoreWater = true;
				this.name = "Blood Cloud";
				this.width = 54;
				this.height = 28;
				this.aiStyle = 45;
				this.penetrate = -1;
			}
			else if (this.type == 245)
			{
				this.ignoreWater = true;
				this.name = "Blood Rain";
				this.width = 4;
				this.height = 40;
				this.aiStyle = 45;
				this.friendly = true;
				this.penetrate = 2;
				this.maxUpdates = 1;
				this.timeLeft = 300;
				this.scale = 1.1f;
				this.magic = true;
			}
			else if (this.type == 246)
			{
				this.name = "Stynger";
				this.maxUpdates = 1;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.ranged = true;
				this.alpha = (int)byte.MaxValue;
			}
			else if (this.type == 247)
			{
				this.name = "Flower Pow";
				this.width = 34;
				this.height = 34;
				this.aiStyle = 15;
				this.friendly = true;
				this.penetrate = -1;
				this.melee = true;
			}
			else if (this.type == 248)
			{
				this.name = "Flower Pow";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 1;
				this.friendly = true;
				this.ranged = true;
			}
			else if (this.type == 249)
			{
				this.name = "Stynger";
				this.width = 12;
				this.height = 12;
				this.aiStyle = 2;
				this.friendly = true;
				this.ranged = true;
			}
			else if (this.type == 250)
			{
				this.name = "Rainbow";
				this.width = 12;
				this.height = 12;
				this.aiStyle = 46;
				this.penetrate = -1;
				this.magic = true;
				this.alpha = (int)byte.MaxValue;
				this.ignoreWater = true;
				this.scale = 1.25f;
			}
			else if (this.type == 251)
			{
				this.name = "Rainbow";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 46;
				this.friendly = true;
				this.penetrate = -1;
				this.magic = true;
				this.alpha = (int)byte.MaxValue;
				this.light = 0.3f;
				this.tileCollide = false;
				this.ignoreWater = true;
				this.scale = 1.25f;
			}
			else if (this.type == 252)
			{
				this.name = "Chlorophyte Jackhammer";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
				this.scale = 1.1f;
			}
			else if (this.type == 253)
			{
				this.name = "Ball of Frost";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 8;
				this.friendly = true;
				this.light = 0.8f;
				this.alpha = 100;
				this.magic = true;
			}
			else if (this.type == 254)
			{
				this.name = "Magnet Sphere";
				this.width = 38;
				this.height = 38;
				this.aiStyle = 47;
				this.magic = true;
				this.timeLeft = 420;
				this.light = 0.5f;
			}
			else if (this.type == (int)byte.MaxValue)
			{
				this.name = "Magnet Sphere";
				this.width = 8;
				this.height = 8;
				this.aiStyle = 48;
				this.friendly = true;
				this.magic = true;
				this.maxUpdates = 100;
				this.timeLeft = 100;
			}
			else if (this.type == 256)
			{
				this.netImportant = true;
				this.tileCollide = false;
				this.name = "Skeletron Hand";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 7;
				this.friendly = true;
				this.penetrate = -1;
				this.melee = true;
				this.scale = 1f;
			}
			else if (this.type == 257)
			{
				this.name = "Frost Beem";
				this.ignoreWater = true;
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.hostile = true;
				this.penetrate = -1;
				this.light = 0.75f;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 1;
				this.scale = 1.2f;
				this.timeLeft = 600;
				this.magic = true;
			}
			else if (this.type == 258)
			{
				this.name = "Fireball";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 8;
				this.hostile = true;
				this.penetrate = -1;
				this.alpha = 100;
				this.timeLeft = 300;
			}
			else if (this.type == 259)
			{
				this.name = "Eye Beam";
				this.ignoreWater = true;
				this.tileCollide = false;
				this.width = 8;
				this.height = 8;
				this.aiStyle = 1;
				this.hostile = true;
				this.penetrate = -1;
				this.light = 0.3f;
				this.scale = 1.1f;
				this.magic = true;
				this.maxUpdates = 1;
			}
			else if (this.type == 260)
			{
				this.name = "Heat Ray";
				this.width = 8;
				this.height = 8;
				this.aiStyle = 48;
				this.friendly = true;
				this.magic = true;
				this.maxUpdates = 100;
				this.timeLeft = 200;
				this.penetrate = -1;
			}
			else if (this.type == 261)
			{
				this.name = "Boulder";
				this.width = 32;
				this.height = 34;
				this.aiStyle = 14;
				this.friendly = true;
				this.penetrate = 6;
				this.magic = true;
			}
			else if (this.type == 262)
			{
				this.name = "Golem Fist";
				this.width = 30;
				this.height = 30;
				this.aiStyle = 13;
				this.friendly = true;
				this.penetrate = -1;
				this.alpha = (int)byte.MaxValue;
				this.melee = true;
				this.maxUpdates = 1;
			}
			else if (this.type == 263)
			{
				this.name = "Ice Sickle";
				this.width = 34;
				this.height = 34;
				this.alpha = 100;
				this.light = 0.5f;
				this.aiStyle = 18;
				this.friendly = true;
				this.penetrate = 5;
				this.tileCollide = true;
				this.scale = 1f;
				this.melee = true;
				this.timeLeft = 180;
			}
			else if (this.type == 264)
			{
				this.ignoreWater = true;
				this.name = "Rain";
				this.width = 4;
				this.height = 40;
				this.aiStyle = 45;
				this.hostile = true;
				this.penetrate = -1;
				this.maxUpdates = 1;
				this.timeLeft = 120;
				this.scale = 1.1f;
			}
			else if (this.type == 265)
			{
				this.name = "Poison Fang";
				this.width = 12;
				this.height = 12;
				this.aiStyle = 1;
				this.alpha = (int)byte.MaxValue;
				this.friendly = true;
				this.magic = true;
				this.penetrate = 6;
			}
			else if (this.type == 266)
			{
				this.netImportant = true;
				this.alpha = 75;
				this.name = "Baby Slime";
				this.width = 24;
				this.height = 16;
				this.aiStyle = 26;
				this.penetrate = -1;
				this.timeLeft *= 5;
				this.minion = true;
			}
			else if (this.type == 267)
			{
				this.alpha = (int)byte.MaxValue;
				this.name = "Poison Dart";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 1;
				this.friendly = true;
			}
			else if (this.type == 268)
			{
				this.netImportant = true;
				this.name = "Eye Spring";
				this.width = 18;
				this.height = 32;
				this.aiStyle = 26;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft *= 5;
			}
			else if (this.type == 269)
			{
				this.netImportant = true;
				this.name = "Baby Snowman";
				this.width = 20;
				this.height = 26;
				this.aiStyle = 26;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft *= 5;
			}
			else if (this.type == 270)
			{
				this.name = "Skull";
				this.width = 26;
				this.height = 26;
				this.aiStyle = 1;
				this.alpha = (int)byte.MaxValue;
				this.friendly = true;
				this.magic = true;
				this.penetrate = 6;
			}
			else if (this.type == 271)
			{
				this.name = "Boxing Glove";
				this.width = 20;
				this.height = 20;
				this.aiStyle = 13;
				this.friendly = true;
				this.penetrate = -1;
				this.alpha = (int)byte.MaxValue;
				this.melee = true;
				this.scale = 1.2f;
			}
			else if (this.type == 272)
			{
				this.name = "Bananarang";
				this.width = 32;
				this.height = 32;
				this.aiStyle = 3;
				this.friendly = true;
				this.scale = 0.9f;
				this.penetrate = -1;
				this.melee = true;
			}
			else if (this.type == 273)
			{
				this.name = "Chain Knife";
				this.width = 26;
				this.height = 26;
				this.aiStyle = 13;
				this.friendly = true;
				this.penetrate = -1;
				this.alpha = (int)byte.MaxValue;
				this.melee = true;
			}
			else if (this.type == 274)
			{
				this.name = "Death Sickle";
				this.width = 42;
				this.height = 42;
				this.alpha = 100;
				this.light = 0.5f;
				this.aiStyle = 18;
				this.friendly = true;
				this.penetrate = 5;
				this.tileCollide = false;
				this.scale = 1.1f;
				this.melee = true;
				this.timeLeft = 180;
			}
			else if (this.type == 275)
			{
				this.alpha = (int)byte.MaxValue;
				this.name = "Seed";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 1;
				this.hostile = true;
			}
			else if (this.type == 276)
			{
				this.alpha = (int)byte.MaxValue;
				this.name = "Poison Seed";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 1;
				this.hostile = true;
			}
			else if (this.type == 277)
			{
				this.alpha = (int)byte.MaxValue;
				this.name = "Thorn Ball";
				this.width = 38;
				this.height = 38;
				this.aiStyle = 14;
				this.hostile = true;
			}
			else if (this.type == 278)
			{
				this.name = "Ichor Arrow";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.light = 1f;
				this.ranged = true;
				this.maxUpdates = 1;
			}
			else if (this.type == 279)
			{
				this.name = "Ichor Bullet";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 1;
				this.light = 0.5f;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 2;
				this.scale = 1.25f;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else if (this.type == 280)
			{
				this.name = "Golden Shower";
				this.width = 32;
				this.height = 32;
				this.aiStyle = 12;
				this.friendly = true;
				this.alpha = (int)byte.MaxValue;
				this.penetrate = -1;
				this.maxUpdates = 2;
				this.ignoreWater = true;
				this.magic = true;
			}
			else if (this.type == 281)
			{
				this.name = "Explosive Bunny";
				this.width = 28;
				this.height = 28;
				this.aiStyle = 49;
				this.friendly = true;
				this.penetrate = 1;
				this.alpha = (int)byte.MaxValue;
				this.timeLeft = 600;
			}
			else if (this.type == 282)
			{
				this.name = "Venom Arrow";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.ranged = true;
				this.maxUpdates = 1;
			}
			else if (this.type == 283)
			{
				this.name = "Venom Bullet";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 1;
				this.light = 0.5f;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 2;
				this.scale = 1.25f;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else if (this.type == 284)
			{
				this.name = "Party Bullet";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 1;
				this.light = 0.5f;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 2;
				this.scale = 1.3f;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else if (this.type == 285)
			{
				this.name = "Nano Bullet";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 1;
				this.light = 0.5f;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 2;
				this.scale = 1.3f;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else if (this.type == 286)
			{
				this.name = "Explosive Bullet";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 1;
				this.light = 0.5f;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 2;
				this.scale = 1.3f;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else if (this.type == 287)
			{
				this.name = "Golden Bullet";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 1;
				this.light = 0.5f;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 2;
				this.scale = 1.3f;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else if (this.type == 288)
			{
				this.name = "Golden Shower";
				this.width = 32;
				this.height = 32;
				this.aiStyle = 12;
				this.hostile = true;
				this.alpha = (int)byte.MaxValue;
				this.penetrate = -1;
				this.maxUpdates = 2;
				this.ignoreWater = true;
				this.magic = true;
			}
			else if (this.type == 289)
			{
				this.name = "Confetti";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.alpha = (int)byte.MaxValue;
				this.penetrate = -1;
				this.timeLeft = 2;
			}
			else if (this.type == 290)
			{
				this.name = "Shadow Beam";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 48;
				this.hostile = true;
				this.magic = true;
				this.maxUpdates = 100;
				this.timeLeft = 100;
				this.penetrate = -1;
			}
			else if (this.type == 291)
			{
				this.name = "Inferno";
				this.width = 12;
				this.height = 12;
				this.aiStyle = 50;
				this.hostile = true;
				this.alpha = (int)byte.MaxValue;
				this.magic = true;
				this.tileCollide = false;
				this.penetrate = -1;
			}
			else if (this.type == 292)
			{
				this.name = "Inferno";
				this.width = 130;
				this.height = 130;
				this.aiStyle = 50;
				this.hostile = true;
				this.alpha = (int)byte.MaxValue;
				this.magic = true;
				this.tileCollide = false;
				this.penetrate = -1;
			}
			else if (this.type == 293)
			{
				this.name = "Lost Soul";
				this.width = 12;
				this.height = 12;
				this.aiStyle = 51;
				this.hostile = true;
				this.alpha = (int)byte.MaxValue;
				this.magic = true;
				this.tileCollide = false;
				this.maxUpdates = 1;
				this.penetrate = -1;
			}
			else if (this.type == 294)
			{
				this.name = "Shadow Beam";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 48;
				this.friendly = true;
				this.magic = true;
				this.maxUpdates = 100;
				this.timeLeft = 300;
				this.penetrate = -1;
			}
			else if (this.type == 295)
			{
				this.name = "Inferno";
				this.width = 12;
				this.height = 12;
				this.aiStyle = 50;
				this.friendly = true;
				this.alpha = (int)byte.MaxValue;
				this.magic = true;
				this.tileCollide = true;
			}
			else if (this.type == 296)
			{
				this.name = "Inferno";
				this.width = 150;
				this.height = 150;
				this.aiStyle = 50;
				this.friendly = true;
				this.alpha = (int)byte.MaxValue;
				this.magic = true;
				this.tileCollide = false;
				this.penetrate = -1;
			}
			else if (this.type == 297)
			{
				this.name = "Lost Soul";
				this.width = 12;
				this.height = 12;
				this.aiStyle = 51;
				this.friendly = true;
				this.alpha = (int)byte.MaxValue;
				this.magic = true;
				this.maxUpdates = 1;
			}
			else if (this.type == 298)
			{
				this.name = "Spirit Heal";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 52;
				this.alpha = (int)byte.MaxValue;
				this.magic = true;
				this.tileCollide = false;
				this.maxUpdates = 3;
			}
			else if (this.type == 299)
			{
				this.name = "Shadowflames";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 1;
				this.hostile = true;
				this.alpha = (int)byte.MaxValue;
				this.penetrate = -1;
				this.maxUpdates = 2;
				this.magic = true;
				this.ignoreWater = true;
				this.tileCollide = false;
			}
			else if (this.type == 300)
			{
				this.name = "Paladin's Hammer";
				this.width = 38;
				this.height = 38;
				this.aiStyle = 2;
				this.hostile = true;
				this.penetrate = -1;
				this.ignoreWater = true;
				this.tileCollide = false;
			}
			else if (this.type == 301)
			{
				this.name = "Paladin's Hammer";
				this.width = 38;
				this.height = 38;
				this.aiStyle = 3;
				this.friendly = true;
				this.penetrate = -1;
				this.melee = true;
				this.maxUpdates = 2;
			}
			else if (this.type == 302)
			{
				this.name = "Sniper Bullet";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.hostile = true;
				this.penetrate = -1;
				this.light = 0.3f;
				this.alpha = (int)byte.MaxValue;
				this.maxUpdates = 7;
				this.scale = 1.18f;
				this.timeLeft = 300;
				this.ranged = true;
				this.ignoreWater = true;
			}
			else if (this.type == 303)
			{
				this.name = "Rocket";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 16;
				this.hostile = true;
				this.penetrate = -1;
				this.ranged = true;
			}
			else if (this.type == 304)
			{
				this.name = "Vampire Knife";
				this.alpha = (int)byte.MaxValue;
				this.width = 30;
				this.height = 30;
				this.aiStyle = 2;
				this.friendly = true;
				this.penetrate = 1;
				this.melee = true;
				this.light = 0.2f;
				this.ignoreWater = true;
				this.maxUpdates = 0;
			}
			else if (this.type == 305)
			{
				this.name = "Vampire Heal";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 52;
				this.alpha = (int)byte.MaxValue;
				this.tileCollide = false;
				this.maxUpdates = 10;
			}
			else if (this.type == 306)
			{
				this.name = "Eater's Bite";
				this.alpha = (int)byte.MaxValue;
				this.width = 14;
				this.height = 14;
				this.aiStyle = 2;
				this.friendly = true;
				this.penetrate = 1;
				this.melee = true;
				this.ignoreWater = true;
				this.maxUpdates = 1;
			}
			else if (this.type == 307)
			{
				this.name = "Tiny Eater";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 36;
				this.penetrate = 1;
				this.alpha = (int)byte.MaxValue;
				this.timeLeft = 600;
				this.melee = true;
				this.maxUpdates = 3;
			}
			else if (this.type == 308)
			{
				this.name = "Frost Hydra";
				this.width = 80;
				this.height = 74;
				this.aiStyle = 53;
				this.timeLeft = 3600;
				this.light = 0.25f;
				this.ignoreWater = true;
			}
			else if (this.type == 309)
			{
				this.name = "Frost Blast";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 28;
				this.alpha = (int)byte.MaxValue;
				this.penetrate = 1;
				this.friendly = true;
				this.maxUpdates = 3;
			}
			else if (this.type == 310)
			{
				this.netImportant = true;
				this.name = "Blue Flare";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 33;
				this.friendly = true;
				this.penetrate = -1;
				this.alpha = (int)byte.MaxValue;
				this.timeLeft = 36000;
			}
			else if (this.type == 311)
			{
				this.name = "Candy Corn";
				this.width = 10;
				this.height = 12;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 3;
				this.alpha = 255;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else if (this.type == 312)
			{
				this.name = "Jack 'O Lantern";
				this.alpha = 255;
				this.width = 32;
				this.height = 32;
				this.aiStyle = 1;
				this.friendly = true;
				this.ranged = true;
				this.timeLeft = 300;
			}
			else if (this.type == 313)
			{
				this.netImportant = true;
				this.name = "Spider";
				this.width = 30;
				this.height = 30;
				this.aiStyle = 26;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft *= 5;
			}
			else if (this.type == 314)
			{
				this.netImportant = true;
				this.name = "Squashling";
				this.width = 24;
				this.height = 40;
				this.aiStyle = 26;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft *= 5;
			}
			else if (this.type == 315)
			{
				this.netImportant = true;
				this.name = "Bat Hook";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 7;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.timeLeft *= 10;
			}
			else if (this.type == 316)
			{
				this.alpha = 255;
				this.name = "Bat";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 36;
				this.friendly = true;
				this.penetrate = 1;
				this.timeLeft = 600;
				this.magic = true;
			}
			else if (this.type == 317)
			{
				this.netImportant = true;
				this.name = "Raven";
				this.width = 28;
				this.height = 28;
				this.aiStyle = 54;
				this.penetrate = 1;
				this.timeLeft *= 5;
				this.minion = true;
			}
			else if (this.type == 318)
			{
				this.name = "Rotten Egg";
				this.width = 12;
				this.height = 14;
				this.aiStyle = 2;
				this.friendly = true;
				this.ranged = true;
			}
			else if (this.type == 319)
			{
				this.netImportant = true;
				this.name = "Black Cat";
				this.width = 36;
				this.height = 30;
				this.aiStyle = 26;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft *= 5;
			}
			else if (this.type == 320)
			{
				this.name = "Bloody Machete";
				this.width = 34;
				this.height = 34;
				this.aiStyle = 3;
				this.friendly = true;
				this.penetrate = -1;
				this.melee = true;
			}
			else if (this.type == 321)
			{
				this.name = "Flaming Jack";
				this.width = 30;
				this.height = 30;
				this.aiStyle = 55;
				this.friendly = true;
				this.melee = true;
				this.tileCollide = false;
				this.ignoreWater = true;
			}
			else if (this.type == 322)
			{
				this.netImportant = true;
				this.name = "Wood Hook";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 7;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.timeLeft *= 10;
			}
			else if (this.type == 323)
			{
				this.penetrate = 10;
				this.name = "Stake";
				this.maxUpdates = 3;
				this.width = 14;
				this.height = 14;
				this.aiStyle = 1;
				this.alpha = 255;
				this.friendly = true;
				this.ranged = true;
				this.scale = 0.8f;
			}
			else if (this.type == 324)
			{
				this.netImportant = true;
				this.name = "Cursed Sapling";
				this.width = 26;
				this.height = 38;
				this.aiStyle = 26;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft *= 5;
			}
			else if (this.type == 325)
			{
				this.alpha = 255;
				this.penetrate = -1;
				this.name = "Flaming Wood";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 1;
				this.hostile = true;
				this.tileCollide = false;
			}
			else if (this.type >= 326 && this.type <= 328)
			{
				this.name = "Greek Fire";
				if (this.type == 326)
				{
					this.width = 14;
					this.height = 16;
				}
				else if (this.type == 327)
				{
					this.width = 12;
					this.height = 14;
				}
				else
				{
					this.width = 6;
					this.height = 12;
				}
				this.aiStyle = 14;
				this.hostile = true;
				this.penetrate = -1;
				this.timeLeft = 360;
			}
			else if (this.type == 329)
			{
				this.name = "Flaming Scythe";
				this.width = 80;
				this.height = 80;
				this.light = 0.25f;
				this.aiStyle = 56;
				this.hostile = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.timeLeft = 600;
			}
			else
				this.active = false;
			this.width = (int)((double)this.width * (double)this.scale);
			this.height = (int)((double)this.height * (double)this.scale);
			ServerApi.Hooks.InvokeProjectileSetDefaults(ref Type, this);
		}

		public static int NewProjectile(float X, float Y, float SpeedX, float SpeedY, int Type, int Damage, float KnockBack, int Owner = 255, float ai0 = 0.0f, float ai1 = 0.0f)
		{
			int number = 1000;
			for (int index = 0; index < 1000; ++index)
			{
				if (!Main.projectile[index].active)
				{
					number = index;
					break;
				}
			}
			if (number == 1000)
				return number;
			Main.projectile[number].SetDefaults(Type);
			Main.projectile[number].position.X = X - (float)Main.projectile[number].width * 0.5f;
			Main.projectile[number].position.Y = Y - (float)Main.projectile[number].height * 0.5f;
			Main.projectile[number].owner = Owner;
			Main.projectile[number].velocity.X = SpeedX;
			Main.projectile[number].velocity.Y = SpeedY;
			Main.projectile[number].damage = Damage;
			Main.projectile[number].knockBack = KnockBack;
			Main.projectile[number].identity = number;
			Main.projectile[number].gfxOffY = 0.0f;
			Main.projectile[number].stepSpeed = 1f;
			Main.projectile[number].wet = Collision.WetCollision(Main.projectile[number].position, Main.projectile[number].width, Main.projectile[number].height);
			if (Main.projectile[number].ignoreWater)
				Main.projectile[number].wet = false;
			Main.projectile[number].honeyWet = Collision.honey;
			if (Owner == Main.myPlayer)
			{
				if (Type == 206)
				{
					Main.projectile[number].ai[0] = (float)Main.rand.Next(-100, 101) * 0.0005f;
					Main.projectile[number].ai[1] = (float)Main.rand.Next(-100, 101) * 0.0005f;
				}
				else
				{
					Main.projectile[number].ai[0] = ai0;
					Main.projectile[number].ai[1] = ai1;
				}
			}
			if (Main.netMode != 0 && Owner == Main.myPlayer)
				NetMessage.SendData(27, -1, -1, "", number, 0.0f, 0.0f, 0.0f, 0);
			if (Owner == Main.myPlayer)
			{
				if (Type == 28)
					Main.projectile[number].timeLeft = 180;
				if (Type == 29)
					Main.projectile[number].timeLeft = 300;
				if (Type == 30)
					Main.projectile[number].timeLeft = 180;
				if (Type == 37)
					Main.projectile[number].timeLeft = 180;
				if (Type == 75)
					Main.projectile[number].timeLeft = 180;
				if (Type == 133)
					Main.projectile[number].timeLeft = 180;
				if (Type == 136)
					Main.projectile[number].timeLeft = 180;
				if (Type == 139)
					Main.projectile[number].timeLeft = 180;
				if (Type == 142)
					Main.projectile[number].timeLeft = 180;
			}
			if (Type == 249)
				Main.projectile[number].frame = Main.rand.Next(5);
			return number;
		}

		public void StatusNPC(int i)
		{
			if (this.melee && (int)Main.player[this.owner].meleeEnchant > 0)
			{
				int num = (int)Main.player[this.owner].meleeEnchant;
				if (num == 1)
					Main.npc[i].AddBuff(70, 60 * Main.rand.Next(5, 10), false);
				if (num == 2)
					Main.npc[i].AddBuff(39, 60 * Main.rand.Next(3, 7), false);
				if (num == 3)
					Main.npc[i].AddBuff(24, 60 * Main.rand.Next(3, 7), false);
				if (num == 5)
					Main.npc[i].AddBuff(69, 60 * Main.rand.Next(10, 20), false);
				if (num == 6)
					Main.npc[i].AddBuff(31, 60 * Main.rand.Next(1, 4), false);
				if (num == 8)
					Main.npc[i].AddBuff(20, 60 * Main.rand.Next(5, 10), false);
				if (num == 4)
					Main.npc[i].AddBuff(69, 120, false);
			}
			if ((this.melee || this.ranged) && Main.player[this.owner].frostBurn)
				Main.npc[i].AddBuff(44, 60 * Main.rand.Next(5, 15), false);
			if (this.melee && Main.player[this.owner].magmaStone)
			{
				if (Main.rand.Next(7) == 0)
					Main.npc[i].AddBuff(24, 360, false);
				else if (Main.rand.Next(3) == 0)
					Main.npc[i].AddBuff(24, 120, false);
				else
					Main.npc[i].AddBuff(24, 60, false);
			}
			if (this.type == 295 || this.type == 296)
				Main.npc[i].AddBuff(24, 60 * Main.rand.Next(8, 16), false);
			if (this.type == 2 && Main.rand.Next(3) == 0)
				Main.npc[i].AddBuff(24, 180, false);
			if (this.type == 287)
				Main.npc[i].AddBuff(72, 120, false);
			if (this.type == 285)
			{
				if (Main.rand.Next(3) == 0)
					Main.npc[i].AddBuff(31, 180, false);
				else
					Main.npc[i].AddBuff(31, 60, false);
			}
			if (this.type == 172)
			{
				if (Main.rand.Next(3) == 0)
					Main.npc[i].AddBuff(44, 240, false);
			}
			else if (this.type == 15)
			{
				if (Main.rand.Next(2) == 0)
					Main.npc[i].AddBuff(24, 300, false);
			}
			else if (this.type == 253)
			{
				if (Main.rand.Next(2) == 0)
					Main.npc[i].AddBuff(44, 600, false);
			}
			else if (this.type == 19)
			{
				if (Main.rand.Next(5) == 0)
					Main.npc[i].AddBuff(24, 180, false);
			}
			else if (this.type == 33)
			{
				if (Main.rand.Next(5) == 0)
					Main.npc[i].AddBuff(20, 420, false);
			}
			else if (this.type == 34)
			{
				if (Main.rand.Next(2) == 0)
					Main.npc[i].AddBuff(24, 240, false);
			}
			else if (this.type == 35)
			{
				if (Main.rand.Next(4) == 0)
					Main.npc[i].AddBuff(24, 180, false);
			}
			else if (this.type == 54)
			{
				if (Main.rand.Next(2) == 0)
					Main.npc[i].AddBuff(20, 600, false);
			}
			else if (this.type == 267)
			{
				if (Main.rand.Next(3) == 0)
					Main.npc[i].AddBuff(20, 3600, false);
				else
					Main.npc[i].AddBuff(20, 1800, false);
			}
			else if (this.type == 63)
			{
				if (Main.rand.Next(3) != 0)
					Main.npc[i].AddBuff(31, 120, false);
			}
			else if (this.type == 85 || this.type == 188)
				Main.npc[i].AddBuff(24, 1200, false);
			else if (this.type == 95 || this.type == 103 || this.type == 104)
				Main.npc[i].AddBuff(39, 420, false);
			else if (this.type == 278 || this.type == 279 || this.type == 280)
				Main.npc[i].AddBuff(69, 900, false);
			else if (this.type == 282 || this.type == 283)
				Main.npc[i].AddBuff(70, 600, false);
			else if (this.type == 98)
				Main.npc[i].AddBuff(20, 600, false);
			else if (this.type == 184)
				Main.npc[i].AddBuff(20, 900, false);
			if (this.type == 163 || this.type == 310)
			{
				if (Main.rand.Next(3) == 0)
					Main.npc[i].AddBuff(24, 600, false);
				else
					Main.npc[i].AddBuff(24, 300, false);
			}
			else
			{
				if (this.type != 265)
					return;
				Main.npc[i].AddBuff(20, 3600, false);
			}
		}

		public void StatusPvP(int i)
		{
			if (this.melee && (int)Main.player[this.owner].meleeEnchant > 0)
			{
				int num = (int)Main.player[this.owner].meleeEnchant;
				if (num == 1)
					Main.player[i].AddBuff(70, 60 * Main.rand.Next(5, 10), true);
				if (num == 2)
					Main.player[i].AddBuff(39, 60 * Main.rand.Next(3, 7), true);
				if (num == 3)
					Main.player[i].AddBuff(24, 60 * Main.rand.Next(3, 7), true);
				if (num == 5)
					Main.player[i].AddBuff(69, 60 * Main.rand.Next(10, 20), true);
				if (num == 6)
					Main.player[i].AddBuff(31, 60 * Main.rand.Next(1, 4), true);
				if (num == 8)
					Main.player[i].AddBuff(20, 60 * Main.rand.Next(5, 10), true);
			}
			if (this.type == 295 || this.type == 296)
				Main.player[i].AddBuff(24, 60 * Main.rand.Next(8, 16), true);
			if ((this.melee || this.ranged) && Main.player[this.owner].frostBurn)
				Main.player[i].AddBuff(44, 60 * Main.rand.Next(1, 8), false);
			if (this.melee && Main.player[this.owner].magmaStone)
			{
				if (Main.rand.Next(7) == 0)
					Main.player[i].AddBuff(24, 360, true);
				else if (Main.rand.Next(3) == 0)
					Main.player[i].AddBuff(24, 120, true);
				else
					Main.player[i].AddBuff(24, 60, true);
			}
			if (this.type == 2 && Main.rand.Next(3) == 0)
				Main.player[i].AddBuff(24, 180, false);
			if (this.type == 172)
			{
				if (Main.rand.Next(3) == 0)
					Main.player[i].AddBuff(44, 240, false);
			}
			else if (this.type == 15)
			{
				if (Main.rand.Next(2) == 0)
					Main.player[i].AddBuff(24, 300, false);
			}
			else if (this.type == 267)
			{
				if (Main.rand.Next(3) == 0)
					Main.player[i].AddBuff(20, 3600, true);
				else
					Main.player[i].AddBuff(20, 1800, true);
			}
			else if (this.type == 19)
			{
				if (Main.rand.Next(5) == 0)
					Main.player[i].AddBuff(24, 180, false);
			}
			else if (this.type == 33)
			{
				if (Main.rand.Next(5) == 0)
					Main.player[i].AddBuff(20, 420, false);
			}
			else if (this.type == 34)
			{
				if (Main.rand.Next(2) == 0)
					Main.player[i].AddBuff(24, 240, false);
			}
			else if (this.type == 35)
			{
				if (Main.rand.Next(4) == 0)
					Main.player[i].AddBuff(24, 180, false);
			}
			else if (this.type == 54)
			{
				if (Main.rand.Next(2) == 0)
					Main.player[i].AddBuff(20, 600, false);
			}
			else if (this.type == 63)
			{
				if (Main.rand.Next(3) != 0)
					Main.player[i].AddBuff(31, 120, true);
			}
			else if (this.type == 85 || this.type == 188)
				Main.player[i].AddBuff(24, 1200, false);
			else if (this.type == 95 || this.type == 103 || this.type == 104)
				Main.player[i].AddBuff(39, 420, true);
			else if (this.type == 278 || this.type == 279 || this.type == 280)
				Main.player[i].AddBuff(69, 900, true);
			else if (this.type == 282 || this.type == 283)
				Main.player[i].AddBuff(70, 600, true);
			if (this.type == 163 || this.type == 310)
			{
				if (Main.rand.Next(3) == 0)
					Main.player[i].AddBuff(24, 600, true);
				else
					Main.player[i].AddBuff(24, 300, true);
			}
			else
			{
				if (this.type != 265)
					return;
				Main.player[i].AddBuff(20, 1800, true);
			}
		}

		public void ghostHeal(int dmg, Vector2 Position)
		{
			float num1 = 0.08f - (float)this.numHits * 0.02f;
			if ((double)num1 <= 0.0)
				return;
			float ai1 = (float)dmg * num1;
			if ((int)ai1 <= 0 || !this.magic)
				return;
			float num2 = 0.0f;
			int num3 = this.owner;
			for (int index = 0; index < (int)byte.MaxValue; ++index)
			{
				if (Main.player[index].active && !Main.player[index].dead && (!Main.player[this.owner].hostile && !Main.player[index].hostile || Main.player[this.owner].team == Main.player[index].team) && ((double)(Math.Abs(Main.player[index].position.X + (float)(Main.player[index].width / 2) - this.position.X + (float)(this.width / 2)) + Math.Abs(Main.player[index].position.Y + (float)(Main.player[index].height / 2) - this.position.Y + (float)(this.height / 2))) < 800.0 && (double)(Main.player[index].statLifeMax - Main.player[index].statLife) > (double)num2))
				{
					num2 = (float)(Main.player[index].statLifeMax - Main.player[index].statLife);
					num3 = index;
				}
			}
			Projectile.NewProjectile(Position.X, Position.Y, 0.0f, 0.0f, 298, 0, 0.0f, this.owner, (float)num3, ai1);
		}

		public void vampireHeal(int dmg, Vector2 Position)
		{
			float ai1 = (float)dmg * 0.075f;
			if ((int)ai1 == 0)
				return;
			int num = this.owner;
			Projectile.NewProjectile(Position.X, Position.Y, 0.0f, 0.0f, 305, 0, 0.0f, this.owner, (float)num, ai1);
		}

		public void StatusPlayer(int i)
		{
			if (this.type == 55 && Main.rand.Next(3) == 0)
				Main.player[i].AddBuff(20, 600, true);
			if (this.type == 44 && Main.rand.Next(3) == 0)
				Main.player[i].AddBuff(22, 900, true);
			if (this.type == 293)
				Main.player[i].AddBuff(80, 60 * Main.rand.Next(2, 7), true);
			if (this.type == 82 && Main.rand.Next(3) == 0)
				Main.player[i].AddBuff(24, 420, true);
			if (this.type == 285)
			{
				if (Main.rand.Next(3) == 0)
					Main.player[i].AddBuff(31, 180, true);
				else
					Main.player[i].AddBuff(31, 60, true);
			}
			if (this.type == 96 || this.type == 101)
			{
				if (Main.rand.Next(3) == 0)
					Main.player[i].AddBuff(39, 480, true);
			}
			else if (this.type == 288)
				Main.player[i].AddBuff(69, 900, true);
			else if (this.type == 253 && Main.rand.Next(2) == 0)
				Main.player[i].AddBuff(44, 600, true);
			if (this.type == 291 || this.type == 292)
				Main.player[i].AddBuff(24, 60 * Main.rand.Next(8, 16), true);
			if (this.type == 98)
				Main.player[i].AddBuff(20, 600, true);
			if (this.type == 184)
				Main.player[i].AddBuff(20, 900, true);
			if (this.type == 290)
				Main.player[i].AddBuff(32, 60 * Main.rand.Next(5, 16), true);
			if (this.type == 174)
			{
				Main.player[i].AddBuff(46, 1200, true);
				if (!Main.player[i].frozen && Main.rand.Next(20) == 0)
					Main.player[i].AddBuff(47, 90, true);
			}
			if (this.type == 257)
			{
				Main.player[i].AddBuff(46, 2700, true);
				if (!Main.player[i].frozen && Main.rand.Next(5) == 0)
					Main.player[i].AddBuff(47, 60, true);
			}
			if (this.type == 177)
			{
				Main.player[i].AddBuff(46, 1500, true);
				if (!Main.player[i].frozen && Main.rand.Next(10) == 0)
					Main.player[i].AddBuff(47, Main.rand.Next(30, 120), true);
			}
			if (this.type != 176)
				return;
			if (Main.rand.Next(4) == 0)
			{
				Main.player[i].AddBuff(20, 1200, true);
			}
			else
			{
				if (Main.rand.Next(2) != 0)
					return;
				Main.player[i].AddBuff(20, 300, true);
			}
		}

		public void Damage()
		{
			if (this.type == 18 || this.type == 72 || (this.type == 86 || this.type == 87) || (this.aiStyle == 31 || this.aiStyle == 32 || this.type == 226) || Main.projPet[this.type] && this.type != 266 && this.type != 317)
				return;
			Rectangle rectangle1 = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
			if (this.type == 85 || this.type == 101)
			{
				int num = 30;
				rectangle1.X -= num;
				rectangle1.Y -= num;
				rectangle1.Width += num * 2;
				rectangle1.Height += num * 2;
			}
			if (this.type == 188)
			{
				int num = 20;
				rectangle1.X -= num;
				rectangle1.Y -= num;
				rectangle1.Width += num * 2;
				rectangle1.Height += num * 2;
			}
			if (this.aiStyle == 29)
			{
				int num = 4;
				rectangle1.X -= num;
				rectangle1.Y -= num;
				rectangle1.Width += num * 2;
				rectangle1.Height += num * 2;
			}
			if (this.friendly && this.owner == Main.myPlayer)
			{
				if ((this.aiStyle == 16 || this.type == 41) && (this.timeLeft <= 1 || this.type == 108 || this.type == 164) || this.type == 286 && (double)this.localAI[1] == -1.0)
				{
					int index = Main.myPlayer;
					if (Main.player[index].active && !Main.player[index].dead && !Main.player[index].immune && (!this.ownerHitCheck || Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, Main.player[index].position, Main.player[index].width, Main.player[index].height)))
					{
						Rectangle rectangle2 = new Rectangle((int)Main.player[index].position.X, (int)Main.player[index].position.Y, Main.player[index].width, Main.player[index].height);
						if (rectangle1.Intersects(rectangle2))
						{
							this.direction = (double)Main.player[index].position.X + (double)(Main.player[index].width / 2) >= (double)this.position.X + (double)(this.width / 2) ? 1 : -1;
							int Damage = Main.DamageVar((float)this.damage);
							this.StatusPlayer(index);
							Main.player[index].Hurt(Damage, this.direction, true, false, Lang.deathMsg(this.owner, -1, this.whoAmI, -1), false);
							if (Main.netMode != 0)
								NetMessage.SendData(26, -1, -1, Lang.deathMsg(this.owner, -1, this.whoAmI, -1), index, (float)this.direction, (float)Damage, 1f, 0);
						}
					}
				}
				if (this.type != 69 && this.type != 70 && (this.type != 10 && this.type != 11) && this.aiStyle != 45)
				{
					int num1 = (int)((double)this.position.X / 16.0);
					int num2 = (int)(((double)this.position.X + (double)this.width) / 16.0) + 1;
					int num3 = (int)((double)this.position.Y / 16.0);
					int num4 = (int)(((double)this.position.Y + (double)this.height) / 16.0) + 1;
					if (num1 < 0)
						num1 = 0;
					if (num2 > Main.maxTilesX)
						num2 = Main.maxTilesX;
					if (num3 < 0)
						num3 = 0;
					if (num4 > Main.maxTilesY)
						num4 = Main.maxTilesY;
					for (int i = num1; i < num2; ++i)
					{
						for (int j = num3; j < num4; ++j)
						{
							if (Main.tile[i, j] != null && Main.tileCut[(int)Main.tile[i, j].type] && (Main.tile[i, j + 1] != null && (int)Main.tile[i, j + 1].type != 78))
							{
								WorldGen.KillTile(i, j, false, false, false);
								if (Main.netMode != 0)
									NetMessage.SendData(17, -1, -1, "", 0, (float)i, (float)j, 0.0f, 0);
							}
						}
					}
				}
			}
			if (this.owner == Main.myPlayer)
			{
				if (this.damage > 0)
				{
					for (int index = 0; index < 200; ++index)
					{
						if (Main.npc[index].active && !Main.npc[index].dontTakeDamage && ((!Main.npc[index].friendly || Main.npc[index].type == 22 && this.owner < (int)byte.MaxValue && Main.player[this.owner].killGuide) && this.friendly || Main.npc[index].friendly && this.hostile) && (this.owner < 0 || Main.npc[index].immune[this.owner] == 0))
						{
							bool flag = false;
							if (this.type == 11 && (Main.npc[index].type == 47 || Main.npc[index].type == 57))
								flag = true;
							else if (this.type == 31 && Main.npc[index].type == 69)
								flag = true;
							if (!flag && (Main.npc[index].noTileCollide || !this.ownerHitCheck || Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, Main.npc[index].position, Main.npc[index].width, Main.npc[index].height)))
							{
								Rectangle rectangle2 = new Rectangle((int)Main.npc[index].position.X, (int)Main.npc[index].position.Y, Main.npc[index].width, Main.npc[index].height);
								if (rectangle1.Intersects(rectangle2))
								{
									if (this.aiStyle == 3 && this.type != 301)
									{
										if ((double)this.ai[0] == 0.0)
										{
											this.velocity.X = -this.velocity.X;
											this.velocity.Y = -this.velocity.Y;
											this.netUpdate = true;
										}
										this.ai[0] = 1f;
									}
									else if (this.aiStyle == 16)
									{
										if (this.timeLeft > 3)
											this.timeLeft = 3;
										this.direction = (double)Main.npc[index].position.X + (double)(Main.npc[index].width / 2) >= (double)this.position.X + (double)(this.width / 2) ? 1 : -1;
									}
									else if (this.aiStyle == 50)
										this.direction = (double)Main.npc[index].position.X + (double)(Main.npc[index].width / 2) >= (double)this.position.X + (double)(this.width / 2) ? 1 : -1;
									if (this.aiStyle == 39)
									{
										if ((double)this.ai[1] == 0.0)
										{
											this.ai[1] = (float)(index + 1);
											this.netUpdate = true;
										}
										this.direction = (double)Main.player[this.owner].position.X + (double)(Main.player[this.owner].width / 2) >= (double)this.position.X + (double)(this.width / 2) ? -1 : 1;
									}
									if (this.type == 41 && this.timeLeft > 1)
										this.timeLeft = 1;
									bool crit = false;
									if (this.melee && Main.rand.Next(1, 101) <= Main.player[this.owner].meleeCrit)
										crit = true;
									if (this.ranged && Main.rand.Next(1, 101) <= Main.player[this.owner].rangedCrit)
										crit = true;
									if (this.magic && Main.rand.Next(1, 101) <= Main.player[this.owner].magicCrit)
										crit = true;
									int Damage = Main.DamageVar((float)this.damage);
									if (this.type == 323 && (Main.npc[index].type == 158 || Main.npc[index].type == 159))
										Damage *= 10;
									if (this.type == 294)
										this.damage = (int)((double)this.damage * 0.8);
									if (this.type == 261)
									{
										float num = (float)Math.Sqrt((double)this.velocity.X * (double)this.velocity.X + (double)this.velocity.Y * (double)this.velocity.Y);
										if ((double)num < 1.0)
											num = 1f;
										Damage = (int)((double)Damage * (double)num / 8.0);
									}
									this.StatusNPC(index);
									if (this.type != 221 && this.type != 227)
										Main.player[this.owner].onHit(Main.npc[index].center().X, Main.npc[index].center().Y);
									if (this.type == 317)
									{
										this.ai[1] = -1f;
										this.netUpdate = true;
									} 
									int dmg = (int)Main.npc[index].StrikeNPC(Damage, this.knockBack, this.direction, crit, false);
									if (dmg > 0 && Main.npc[index].lifeMax > 5 && Main.player[this.owner].ghostHeal)
										this.ghostHeal(dmg, new Vector2(Main.npc[index].center().X, Main.npc[index].center().Y));
									if (this.type == 304 && dmg > 0 && Main.npc[index].lifeMax > 5)
										this.vampireHeal(dmg, new Vector2(Main.npc[index].center().X, Main.npc[index].center().Y));
									if (this.melee && (int)Main.player[this.owner].meleeEnchant == 7)
										Projectile.NewProjectile(Main.npc[index].center().X, Main.npc[index].center().Y, Main.npc[index].velocity.X, Main.npc[index].velocity.Y, 289, 0, 0.0f, this.owner, 0.0f, 0.0f);
									if ((double)Main.npc[index].value > 0.0 && Main.player[this.owner].coins && Main.rand.Next(5) == 0)
									{
										int Type = 71;
										if (Main.rand.Next(10) == 0)
											Type = 72;
										if (Main.rand.Next(100) == 0)
											Type = 73;
										int number = Item.NewItem((int)Main.npc[index].position.X, (int)Main.npc[index].position.Y, Main.npc[index].width, Main.npc[index].height, Type, 1, false, 0, false);
										Main.item[number].stack = Main.rand.Next(1, 11);
										Main.item[number].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
										Main.item[number].velocity.X = (float)Main.rand.Next(10, 31) * 0.2f * (float)this.direction;
										if (Main.netMode == 1)
											NetMessage.SendData(21, -1, -1, "", number, 0.0f, 0.0f, 0.0f, 0);
									}
									if (Main.netMode != 0)
									{
										if (crit)
											NetMessage.SendData(28, -1, -1, "", index, (float)Damage, this.knockBack, (float)this.direction, 1);
										else
											NetMessage.SendData(28, -1, -1, "", index, (float)Damage, this.knockBack, (float)this.direction, 0);
									}
									if (this.type == 286)
										Main.npc[index].immune[this.owner] = 5;
									else if (this.type == 311)
										Main.npc[index].immune[this.owner] = 7;
									else if (this.penetrate != 1)
										Main.npc[index].immune[this.owner] = 10;
									if (this.penetrate > 0 && this.type != 317)
									{
										--this.penetrate;
										if (this.penetrate == 0)
											break;
									}
									if (this.aiStyle == 7)
									{
										this.ai[0] = 1f;
										this.damage = 0;
										this.netUpdate = true;
									}
									else if (this.aiStyle == 13)
									{
										this.ai[0] = 1f;
										this.netUpdate = true;
									}
									++this.numHits;
								}
							}
						}
					}
				}
				if (this.damage > 0 && Main.player[Main.myPlayer].hostile)
				{
					for (int index = 0; index < (int)byte.MaxValue; ++index)
					{
						if (index != this.owner && Main.player[index].active && (!Main.player[index].dead && !Main.player[index].immune) && (Main.player[index].hostile && this.playerImmune[index] <= 0 && (Main.player[Main.myPlayer].team == 0 || Main.player[Main.myPlayer].team != Main.player[index].team)) && (!this.ownerHitCheck || Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, Main.player[index].position, Main.player[index].width, Main.player[index].height)))
						{
							Rectangle rectangle2 = new Rectangle((int)Main.player[index].position.X, (int)Main.player[index].position.Y, Main.player[index].width, Main.player[index].height);
							if (rectangle1.Intersects(rectangle2))
							{
								if (this.aiStyle == 3)
								{
									if ((double)this.ai[0] == 0.0)
									{
										this.velocity.X = -this.velocity.X;
										this.velocity.Y = -this.velocity.Y;
										this.netUpdate = true;
									}
									this.ai[0] = 1f;
								}
								else if (this.aiStyle == 16)
								{
									if (this.timeLeft > 3)
										this.timeLeft = 3;
									this.direction = (double)Main.player[index].position.X + (double)(Main.player[index].width / 2) >= (double)this.position.X + (double)(this.width / 2) ? 1 : -1;
								}
								if (this.type == 41 && this.timeLeft > 1)
									this.timeLeft = 1;
								bool Crit = false;
								if (this.melee && Main.rand.Next(1, 101) <= Main.player[this.owner].meleeCrit)
									Crit = true;
								int Damage = Main.DamageVar((float)this.damage);
								if (!Main.player[index].immune)
									this.StatusPvP(index);
								if (this.type != 221 && this.type != 227)
									Main.player[this.owner].onHit(Main.player[index].center().X, Main.player[index].center().Y);
								int dmg = (int)Main.player[index].Hurt(Damage, this.direction, true, false, Lang.deathMsg(this.owner, -1, this.whoAmI, -1), Crit);
								if (dmg > 0 && Main.player[this.owner].ghostHeal)
									this.ghostHeal(dmg, new Vector2(Main.player[index].center().X, Main.player[index].center().Y));
								if (this.type == 304 && dmg > 0)
									this.vampireHeal(dmg, new Vector2(Main.player[index].center().X, Main.player[index].center().Y));
								if (this.melee && (int)Main.player[this.owner].meleeEnchant == 7)
									Projectile.NewProjectile(Main.player[index].center().X, Main.player[index].center().Y, Main.player[index].velocity.X, Main.player[index].velocity.Y, 289, 0, 0.0f, this.owner, 0.0f, 0.0f);
								if (Main.netMode != 0)
								{
									if (Crit)
										NetMessage.SendData(26, -1, -1, Lang.deathMsg(this.owner, -1, this.whoAmI, -1), index, (float)this.direction, (float)Damage, 1f, 1);
									else
										NetMessage.SendData(26, -1, -1, Lang.deathMsg(this.owner, -1, this.whoAmI, -1), index, (float)this.direction, (float)Damage, 1f, 0);
								}
								this.playerImmune[index] = 40;
								if (this.penetrate > 0)
								{
									--this.penetrate;
									if (this.penetrate == 0)
										break;
								}
								if (this.aiStyle == 7)
								{
									this.ai[0] = 1f;
									this.damage = 0;
									this.netUpdate = true;
								}
								else if (this.aiStyle == 13)
								{
									this.ai[0] = 1f;
									this.netUpdate = true;
								}
							}
						}
					}
				}
			}
			if (this.type == 11 && Main.netMode != 1)
			{
				for (int index = 0; index < 200; ++index)
				{
					if (Main.npc[index].active)
					{
						if (Main.npc[index].type == 46)
						{
							Rectangle rectangle2 = new Rectangle((int)Main.npc[index].position.X, (int)Main.npc[index].position.Y, Main.npc[index].width, Main.npc[index].height);
							if (rectangle1.Intersects(rectangle2))
								Main.npc[index].Transform(47);
						}
						else if (Main.npc[index].type == 55)
						{
							Rectangle rectangle2 = new Rectangle((int)Main.npc[index].position.X, (int)Main.npc[index].position.Y, Main.npc[index].width, Main.npc[index].height);
							if (rectangle1.Intersects(rectangle2))
								Main.npc[index].Transform(57);
						}
					}
				}
			}
			if (Main.netMode == 2 || !this.hostile || (Main.myPlayer >= (int)byte.MaxValue || this.damage <= 0))
				return;
			int i1 = Main.myPlayer;
			if (!Main.player[i1].active || Main.player[i1].dead || Main.player[i1].immune)
				return;
			Rectangle rectangle3 = new Rectangle((int)Main.player[i1].position.X, (int)Main.player[i1].position.Y, Main.player[i1].width, Main.player[i1].height);
			if (!rectangle1.Intersects(rectangle3))
				return;
			int num5 = this.direction;
			int hitDirection = (double)Main.player[i1].position.X + (double)(Main.player[i1].width / 2) >= (double)this.position.X + (double)(this.width / 2) ? 1 : -1;
			int num6 = Main.DamageVar((float)this.damage);
			if (!Main.player[i1].immune)
				this.StatusPlayer(i1);
			Main.player[i1].Hurt(num6 * 2, hitDirection, false, false, Lang.deathMsg(-1, -1, this.whoAmI, -1), false);
		}

		public void ProjLight()
		{
			if ((double)this.light <= 0.0)
				return;
			float R = this.light;
			float G = this.light;
			float B = this.light;
			if (this.type == 259)
				B *= 0.1f;
			else if (this.type == 329)
			{
				B *= 0.1f;
				G *= 0.9f;
			}
			else if (this.type == 2 || this.type == 82)
			{
				G *= 0.75f;
				B *= 0.55f;
			}
			else if (this.type == 172)
			{
				G *= 0.55f;
				R *= 0.35f;
			}
			else if (this.type == 308)
			{
				G *= 0.7f;
				R *= 0.1f;
			}
			else if (this.type == 304)
			{
				G *= 0.2f;
				B *= 0.1f;
			}
			else if (this.type == 263)
			{
				G *= 0.7f;
				R *= 0.1f;
			}
			else if (this.type == 274)
			{
				G *= 0.1f;
				R *= 0.7f;
			}
			else if (this.type == 254)
				R *= 0.1f;
			else if (this.type == 94)
			{
				R *= 0.5f;
				G *= 0.0f;
			}
			else if (this.type == 95 || this.type == 96 || (this.type == 103 || this.type == 104))
			{
				R *= 0.35f;
				G *= 1f;
				B *= 0.0f;
			}
			else if (this.type == 4)
			{
				G *= 0.1f;
				R *= 0.5f;
			}
			else if (this.type == 257)
			{
				G *= 0.9f;
				R *= 0.1f;
			}
			else if (this.type == 9)
			{
				G *= 0.1f;
				B *= 0.6f;
			}
			else if (this.type == 92)
			{
				G *= 0.6f;
				R *= 0.8f;
			}
			else if (this.type == 93)
			{
				G *= 1f;
				R *= 1f;
				B *= 0.01f;
			}
			else if (this.type == 12)
			{
				R *= 0.9f;
				G *= 0.8f;
				B *= 0.1f;
			}
			else if (this.type == 14 || this.type == 110 || (this.type == 180 || this.type == 242) || this.type == 302)
			{
				G *= 0.7f;
				B *= 0.1f;
			}
			else if (this.type == 15)
			{
				G *= 0.4f;
				B *= 0.1f;
				R = 1f;
			}
			else if (this.type == 16)
			{
				R *= 0.1f;
				G *= 0.4f;
				B = 1f;
			}
			else if (this.type == 18)
			{
				G *= 0.1f;
				R *= 0.6f;
			}
			else if (this.type == 19)
			{
				G *= 0.5f;
				B *= 0.1f;
			}
			else if (this.type == 20)
			{
				R *= 0.1f;
				B *= 0.3f;
			}
			else if (this.type == 22)
			{
				R = 0.0f;
				G = 0.0f;
			}
			else if (this.type == 27)
			{
				R *= 0.0f;
				G *= 0.3f;
				B = 1f;
			}
			else if (this.type == 34)
			{
				G *= 0.1f;
				B *= 0.1f;
			}
			else if (this.type == 36)
			{
				R = 0.8f;
				G *= 0.2f;
				B *= 0.6f;
			}
			else if (this.type == 41)
			{
				G *= 0.8f;
				B *= 0.6f;
			}
			else if (this.type == 44 || this.type == 45)
			{
				B = 1f;
				R *= 0.6f;
				G *= 0.1f;
			}
			else if (this.type == 50)
			{
				R *= 0.7f;
				B *= 0.8f;
			}
			else if (this.type == 53)
			{
				R *= 0.7f;
				G *= 0.8f;
			}
			else if (this.type == 72)
			{
				R *= 0.45f;
				G *= 0.75f;
				B = 1f;
			}
			else if (this.type == 86)
			{
				R *= 1f;
				G *= 0.45f;
				B = 0.75f;
			}
			else if (this.type == 87)
			{
				R *= 0.45f;
				G = 1f;
				B *= 0.75f;
			}
			else if (this.type == 73)
			{
				R *= 0.4f;
				G *= 0.6f;
				B *= 1f;
			}
			else if (this.type == 74)
			{
				R *= 1f;
				G *= 0.4f;
				B *= 0.6f;
			}
			else if (this.type == 284)
			{
				R *= 1f;
				G *= 0.1f;
				B *= 0.8f;
			}
			else if (this.type == 285)
			{
				R *= 0.1f;
				G *= 0.5f;
				B *= 1f;
			}
			else if (this.type == 286)
			{
				R *= 1f;
				G *= 0.5f;
				B *= 0.1f;
			}
			else if (this.type == 287)
			{
				R *= 0.9f;
				G *= 1f;
				B *= 0.4f;
			}
			else if (this.type == 283)
			{
				R *= 0.8f;
				G *= 0.1f;
			}
			else if (this.type == 76 || this.type == 77 || this.type == 78)
			{
				R *= 1f;
				G *= 0.3f;
				B *= 0.6f;
			}
			else if (this.type == 79)
			{
				R = (float)Main.DiscoR / (float)byte.MaxValue;
				G = (float)Main.DiscoG / (float)byte.MaxValue;
				B = (float)Main.DiscoB / (float)byte.MaxValue;
			}
			else if (this.type == 80)
			{
				R *= 0.0f;
				G *= 0.8f;
				B *= 1f;
			}
			else if (this.type == 83 || this.type == 88)
			{
				R *= 0.7f;
				G *= 0.0f;
				B *= 1f;
			}
			else if (this.type == 100)
			{
				R *= 1f;
				G *= 0.5f;
				B *= 0.0f;
			}
			else if (this.type == 84)
			{
				R *= 0.8f;
				G *= 0.0f;
				B *= 0.5f;
			}
			else if (this.type == 89 || this.type == 90)
			{
				G *= 0.2f;
				B *= 1f;
				R *= 0.05f;
			}
			else if (this.type == 106)
			{
				R *= 0.0f;
				G *= 0.5f;
				B *= 1f;
			}
			else if (this.type == 113)
			{
				R *= 0.25f;
				G *= 0.75f;
				B *= 1f;
			}
			else if (this.type == 114 || this.type == 115)
			{
				R *= 0.5f;
				G *= 0.05f;
				B *= 1f;
			}
			else if (this.type == 116)
				B *= 0.25f;
			else if (this.type == 131)
			{
				R *= 0.1f;
				G *= 0.4f;
			}
			else if (this.type == 132 || this.type == 157)
			{
				R *= 0.2f;
				B *= 0.6f;
			}
			else if (this.type == 156)
			{
				R *= 1f;
				B *= 0.6f;
				G = 0.0f;
			}
			else if (this.type == 173)
			{
				R *= 0.3f;
				B *= 1f;
				G = 0.4f;
			}
			else if (this.type == 207)
			{
				R *= 0.4f;
				B *= 0.4f;
			}
			else if (this.type == 253)
			{
				R = 0.0f;
				G *= 0.4f;
			}
			else if (this.type == 211)
			{
				R *= 0.5f;
				G *= 0.9f;
				B *= 1f;
				this.light = (double)this.localAI[0] != 0.0 ? 1f : 1.5f;
			}
			else if (this.type == 209)
			{
				float num1 = (float)(((double)byte.MaxValue - (double)this.alpha) / (double)byte.MaxValue);
				float num2 = R * 0.3f;
				float num3 = G * 0.4f;
				B = B * 1.75f * num1;
				R = num2 * num1;
				G = num3 * num1;
			}
			else if (this.type == 226 || this.type == 227 | this.type == 229)
			{
				R *= 0.25f;
				G *= 1f;
				B *= 0.5f;
			}
			else if (this.type == 251)
			{
				float num1 = (float)Main.DiscoR / (float)byte.MaxValue;
				float num2 = (float)Main.DiscoG / (float)byte.MaxValue;
				float num3 = (float)Main.DiscoB / (float)byte.MaxValue;
				float num4 = (float)(((double)num1 + 1.0) / 2.0);
				float num5 = (float)(((double)num2 + 1.0) / 2.0);
				float num6 = (float)(((double)num3 + 1.0) / 2.0);
				R = num4 * this.light;
				G = num5 * this.light;
				B = num6 * this.light;
			}
			else if (this.type == 278 || this.type == 279)
			{
				R *= 1f;
				G *= 1f;
				B *= 0.0f;
			}
			//Lighting.addLight((int)(((double)this.position.X + (double)(this.width / 2)) / 16.0), (int)(((double)this.position.Y + (double)(this.height / 2)) / 16.0), R, G, B);
		}

		public Vector2 center()
		{
			return new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2));
		}

		public Rectangle getRect()
		{
			return new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
		}

		public void Update(int i)
		{
			if (!this.active)
				return;
			if (Main.player[this.owner].frostBurn && (this.melee || this.ranged) && (this.friendly && !this.hostile && Main.rand.Next(2 * (1 + this.maxUpdates)) == 0))
			{
				int index = Dust.NewDust(this.position, this.width, this.height, 135, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, new Color(), 2f);
				Main.dust[index].noGravity = true;
				Main.dust[index].velocity *= 0.7f;
				Main.dust[index].velocity.Y -= 0.5f;
			}
			if (this.melee && (int)Main.player[this.owner].meleeEnchant > 0)
			{
				if ((int)Main.player[this.owner].meleeEnchant == 1 && Main.rand.Next(3) == 0)
				{
					int index = Dust.NewDust(this.position, this.width, this.height, 171, 0.0f, 0.0f, 100, new Color(), 1f);
					Main.dust[index].noGravity = true;
					Main.dust[index].fadeIn = 1.5f;
					Main.dust[index].velocity *= 0.25f;
				}
				if ((int)Main.player[this.owner].meleeEnchant == 1)
				{
					if (Main.rand.Next(3) == 0)
					{
						int index = Dust.NewDust(this.position, this.width, this.height, 171, 0.0f, 0.0f, 100, new Color(), 1f);
						Main.dust[index].noGravity = true;
						Main.dust[index].fadeIn = 1.5f;
						Main.dust[index].velocity *= 0.25f;
					}
				}
				else if ((int)Main.player[this.owner].meleeEnchant == 2)
				{
					if (Main.rand.Next(2) == 0)
					{
						int index = Dust.NewDust(this.position, this.width, this.height, 75, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, new Color(), 2.5f);
						Main.dust[index].noGravity = true;
						Main.dust[index].velocity *= 0.7f;
						Main.dust[index].velocity.Y -= 0.5f;
					}
				}
				else if ((int)Main.player[this.owner].meleeEnchant == 3)
				{
					if (Main.rand.Next(2) == 0)
					{
						int index = Dust.NewDust(this.position, this.width, this.height, 6, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, new Color(), 2.5f);
						Main.dust[index].noGravity = true;
						Main.dust[index].velocity *= 0.7f;
						Main.dust[index].velocity.Y -= 0.5f;
					}
				}
				else if ((int)Main.player[this.owner].meleeEnchant == 4)
				{
					if (Main.rand.Next(2) == 0)
					{
						int index = Dust.NewDust(this.position, this.width, this.height, 57, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, new Color(), 1.1f);
						Main.dust[index].noGravity = true;
						Main.dust[index].velocity.X /= 2f;
						Main.dust[index].velocity.Y /= 2f;
					}
				}
				else if ((int)Main.player[this.owner].meleeEnchant == 5)
				{
					if (Main.rand.Next(2) == 0)
					{
						int index = Dust.NewDust(this.position, this.width, this.height, 169, 0.0f, 0.0f, 100, new Color(), 1f);
						Main.dust[index].velocity.X += (float)this.direction;
						Main.dust[index].velocity.Y += 0.2f;
						Main.dust[index].noGravity = true;
					}
				}
				else if ((int)Main.player[this.owner].meleeEnchant == 6)
				{
					if (Main.rand.Next(2) == 0)
					{
						int index = Dust.NewDust(this.position, this.width, this.height, 135, 0.0f, 0.0f, 100, new Color(), 1f);
						Main.dust[index].velocity.X += (float)this.direction;
						Main.dust[index].velocity.Y += 0.2f;
						Main.dust[index].noGravity = true;
					}
				}
				else if ((int)Main.player[this.owner].meleeEnchant == 7)
				{
					if (Main.rand.Next(20) == 0)
					{
						int index = Dust.NewDust(this.position, this.width, this.height, Main.rand.Next(139, 143), this.velocity.X, this.velocity.Y, 0, new Color(), 1.2f);
						Main.dust[index].velocity.X *= (float)(1.0 + (double)Main.rand.Next(-50, 51) * 0.00999999977648258);
						Main.dust[index].velocity.Y *= (float)(1.0 + (double)Main.rand.Next(-50, 51) * 0.00999999977648258);
						Main.dust[index].velocity.X += (float)Main.rand.Next(-50, 51) * 0.05f;
						Main.dust[index].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.05f;
						Main.dust[index].scale *= (float)(1.0 + (double)Main.rand.Next(-30, 31) * 0.00999999977648258);
					}
					if (Main.rand.Next(40) == 0)
					{
						int index = Gore.NewGore(this.position, this.velocity, Main.rand.Next(276, 283), 1f);
						Main.gore[index].velocity.X *= (float)(1.0 + (double)Main.rand.Next(-50, 51) * 0.00999999977648258);
						Main.gore[index].velocity.Y *= (float)(1.0 + (double)Main.rand.Next(-50, 51) * 0.00999999977648258);
						Main.gore[index].scale *= (float)(1.0 + (double)Main.rand.Next(-20, 21) * 0.00999999977648258);
						Main.gore[index].velocity.X += (float)Main.rand.Next(-50, 51) * 0.05f;
						Main.gore[index].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.05f;
					}
				}
				else if ((int)Main.player[this.owner].meleeEnchant == 8 && Main.rand.Next(4) == 0)
				{
					int index = Dust.NewDust(this.position, this.width, this.height, 46, 0.0f, 0.0f, 100, new Color(), 1f);
					Main.dust[index].noGravity = true;
					Main.dust[index].fadeIn = 1.5f;
					Main.dust[index].velocity *= 0.25f;
				}
			}
			if (this.melee && Main.player[this.owner].magmaStone && Main.rand.Next(3) != 0)
			{
				int index = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y - 4f), this.width + 8, this.height + 8, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, new Color(), 2f);
				if (Main.rand.Next(2) == 0)
					Main.dust[index].scale = 1.5f;
				Main.dust[index].noGravity = true;
				Main.dust[index].velocity.X *= 2f;
				Main.dust[index].velocity.Y *= 2f;
			}
			if (this.minion)
			{
				this.minionPos = Main.player[this.owner].numMinions;
				if (this.minionPos >= Main.player[this.owner].maxMinions)
					this.Kill();
				++Main.player[this.owner].numMinions;
			}
			this.lastVelocity = this.velocity;
			float num1 = (float)(1.0 + (double)Math.Abs(this.velocity.X) / 3.0);
			if ((double)this.gfxOffY > 0.0)
			{
				this.gfxOffY -= num1 * this.stepSpeed;
				if ((double)this.gfxOffY < 0.0)
					this.gfxOffY = 0.0f;
			}
			else if ((double)this.gfxOffY < 0.0)
			{
				this.gfxOffY += num1 * this.stepSpeed;
				if ((double)this.gfxOffY > 0.0)
					this.gfxOffY = 0.0f;
			}
			if ((double)this.gfxOffY > 16.0)
				this.gfxOffY = 16f;
			if ((double)this.gfxOffY < -16.0)
				this.gfxOffY = -16f;
			Vector2 vector2_1 = this.velocity;
			if ((double)this.position.X <= (double)Main.leftWorld || (double)this.position.X + (double)this.width >= (double)Main.rightWorld || ((double)this.position.Y <= (double)Main.topWorld || (double)this.position.Y + (double)this.height >= (double)Main.bottomWorld))
			{
				this.active = false;
			}
			else
			{
				this.whoAmI = i;
				if (this.soundDelay > 0)
					--this.soundDelay;
				this.netUpdate = false;
				for (int index = 0; index < (int)byte.MaxValue; ++index)
				{
					if (this.playerImmune[index] > 0)
						--this.playerImmune[index];
				}
				this.AI();
				if (this.owner < (int)byte.MaxValue && !Main.player[this.owner].active)
					this.Kill();
				if (this.type == 242 || this.type == 302)
					this.wet = false;
				if (!this.ignoreWater)
				{
					bool flag1;
					bool flag2;
					try
					{
						flag1 = Collision.LavaCollision(this.position, this.width, this.height);
						flag2 = Collision.WetCollision(this.position, this.width, this.height);
						if (flag1)
							this.lavaWet = true;
						if (Collision.honey)
							this.honeyWet = true;
					}
					catch
					{
						this.active = false;
						return;
					}
					if (this.wet && !this.lavaWet)
					{
						if (this.type == 85 || this.type == 15 || (this.type == 34 || this.type == 188))
							this.Kill();
						if (this.type == 2)
						{
							this.type = 1;
							this.light = 0.0f;
						}
					}
					if (this.type == 80)
					{
						flag2 = false;
						this.wet = false;
						if (flag1 && (double)this.ai[0] >= 0.0)
							this.Kill();
					}
					if (flag2)
					{
						if (this.type != 155 && (int)this.wetCount == 0 && !this.wet)
						{
							if (!flag1)
							{
								if (this.honeyWet)
								{
									for (int index1 = 0; index1 < 10; ++index1)
									{
										int index2 = Dust.NewDust(new Vector2(this.position.X - 6f, (float)((double)this.position.Y + (double)(this.height / 2) - 8.0)), this.width + 12, 24, 152, 0.0f, 0.0f, 0, new Color(), 1f);
										--Main.dust[index2].velocity.Y;
										Main.dust[index2].velocity.X *= 2.5f;
										Main.dust[index2].scale = 1.3f;
										Main.dust[index2].alpha = 100;
										Main.dust[index2].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
								else
								{
									for (int index1 = 0; index1 < 10; ++index1)
									{
										int index2 = Dust.NewDust(new Vector2(this.position.X - 6f, (float)((double)this.position.Y + (double)(this.height / 2) - 8.0)), this.width + 12, 24, Dust.dustWater(), 0.0f, 0.0f, 0, new Color(), 1f);
										Main.dust[index2].velocity.Y -= 4f;
										Main.dust[index2].velocity.X *= 2.5f;
										Main.dust[index2].scale = 1.3f;
										Main.dust[index2].alpha = 100;
										Main.dust[index2].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
							}
							else
							{
								for (int index1 = 0; index1 < 10; ++index1)
								{
									int index2 = Dust.NewDust(new Vector2(this.position.X - 6f, (float)((double)this.position.Y + (double)(this.height / 2) - 8.0)), this.width + 12, 24, 35, 0.0f, 0.0f, 0, new Color(), 1f);
									Main.dust[index2].velocity.Y -= 1.5f;
									Main.dust[index2].velocity.X *= 2.5f;
									Main.dust[index2].scale = 1.3f;
									Main.dust[index2].alpha = 100;
									Main.dust[index2].noGravity = true;
								}
								Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
							}
						}
						this.wet = true;
					}
					else if (this.wet)
					{
						this.wet = false;
						if (this.type == 155)
							this.velocity.Y *= 0.5f;
						else if ((int)this.wetCount == 0)
						{
							this.wetCount = (byte)10;
							if (!this.lavaWet)
							{
								if (this.honeyWet)
								{
									for (int index1 = 0; index1 < 10; ++index1)
									{
										int index2 = Dust.NewDust(new Vector2(this.position.X - 6f, (float)((double)this.position.Y + (double)(this.height / 2) - 8.0)), this.width + 12, 24, 152, 0.0f, 0.0f, 0, new Color(), 1f);
										--Main.dust[index2].velocity.Y;
										Main.dust[index2].velocity.X *= 2.5f;
										Main.dust[index2].scale = 1.3f;
										Main.dust[index2].alpha = 100;
										Main.dust[index2].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
								else
								{
									for (int index1 = 0; index1 < 10; ++index1)
									{
										int index2 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2)), this.width + 12, 24, Dust.dustWater(), 0.0f, 0.0f, 0, new Color(), 1f);
										Main.dust[index2].velocity.Y -= 4f;
										Main.dust[index2].velocity.X *= 2.5f;
										Main.dust[index2].scale = 1.3f;
										Main.dust[index2].alpha = 100;
										Main.dust[index2].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
							}
							else
							{
								for (int index1 = 0; index1 < 10; ++index1)
								{
									int index2 = Dust.NewDust(new Vector2(this.position.X - 6f, (float)((double)this.position.Y + (double)(this.height / 2) - 8.0)), this.width + 12, 24, 35, 0.0f, 0.0f, 0, new Color(), 1f);
									Main.dust[index2].velocity.Y -= 1.5f;
									Main.dust[index2].velocity.X *= 2.5f;
									Main.dust[index2].scale = 1.3f;
									Main.dust[index2].alpha = 100;
									Main.dust[index2].noGravity = true;
								}
								Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
							}
						}
					}
					if (!this.wet)
					{
						this.lavaWet = false;
						this.honeyWet = false;
					}
					if ((int)this.wetCount > 0)
						--this.wetCount;
				}
				this.lastPosition = this.position;
				bool flag3 = false;
				if (this.tileCollide)
				{
					Vector2 vector2_2 = this.velocity;
					bool flag1 = true;
					if (this.type == 9 || this.type == 12 || (this.type == 15 || this.type == 13) || (this.type == 31 || this.type == 39 || this.type == 40))
						flag1 = false;
					if (Main.projPet[this.type])
					{
						flag1 = false;
						if ((double)Main.player[this.owner].position.Y + (double)Main.player[this.owner].height - 12.0 > (double)this.position.Y + (double)this.height)
							flag1 = true;
					}
					if (this.type == 317)
						flag1 = true;
					if (this.aiStyle == 10)
						this.velocity = this.type == 42 || this.type == 65 || this.type == 68 || this.type == 31 && (double)this.ai[0] == 2.0 ? Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag1, flag1) : Collision.AnyCollision(this.position, this.velocity, this.width, this.height);
					else if (this.aiStyle == 29)
					{
						int Width = this.width - 8;
						int Height = this.height - 8;
						this.velocity = Collision.TileCollision(new Vector2(this.position.X + (float)(this.width / 2) - (float)(Width / 2), this.position.Y + (float)(this.height / 2) - (float)(Height / 2)), this.velocity, Width, Height, flag1, flag1);
					}
					else if (this.aiStyle == 49)
					{
						int Width = this.width - 8;
						int Height = this.height - 8;
						this.velocity = Collision.TileCollision(new Vector2(this.position.X + (float)(this.width / 2) - (float)(Width / 2), this.position.Y + (float)(this.height / 2) - (float)(Height / 2)), this.velocity, Width, Height, flag1, flag1);
					}
					else if (this.type == 250 || this.type == 267 || (this.type == 297 || this.type == 323))
					{
						int Width = 2;
						int Height = 2;
						this.velocity = Collision.TileCollision(new Vector2(this.position.X + (float)(this.width / 2) - (float)(Width / 2), this.position.Y + (float)(this.height / 2) - (float)(Height / 2)), this.velocity, Width, Height, flag1, flag1);
					}
					else if (this.type == 308)
					{
						int Width = 26;
						int Height = this.height;
						this.velocity = Collision.TileCollision(new Vector2(this.position.X + (float)(this.width / 2) - (float)(Width / 2), this.position.Y + (float)(this.height / 2) - (float)(Height / 2)), this.velocity, Width, Height, flag1, flag1);
					}
					else if (this.type == 261 || this.type == 277)
					{
						int Width = 26;
						int Height = 26;
						this.velocity = Collision.TileCollision(new Vector2(this.position.X + (float)(this.width / 2) - (float)(Width / 2), this.position.Y + (float)(this.height / 2) - (float)(Height / 2)), this.velocity, Width, Height, flag1, flag1);
					}
					else if (this.type == 106 || this.type == 262 || (this.type == 271 || this.type == 270) || (this.type == 272 || this.type == 273 || (this.type == 274 || this.type == 280)) || (this.type == 288 || this.type == 301 || this.type == 320))
					{
						int Width = 10;
						int Height = 10;
						this.velocity = Collision.TileCollision(new Vector2(this.position.X + (float)(this.width / 2) - (float)(Width / 2), this.position.Y + (float)(this.height / 2) - (float)(Height / 2)), this.velocity, Width, Height, flag1, flag1);
					}
					else if (this.type == 248 || this.type == 247)
					{
						int Width = this.width - 12;
						int Height = this.height - 12;
						this.velocity = Collision.TileCollision(new Vector2(this.position.X + (float)(this.width / 2) - (float)(Width / 2), this.position.Y + (float)(this.height / 2) - (float)(Height / 2)), this.velocity, Width, Height, flag1, flag1);
					}
					else if (this.aiStyle == 18 || this.type == 254)
					{
						int Width = this.width - 36;
						int Height = this.height - 36;
						this.velocity = Collision.TileCollision(new Vector2(this.position.X + (float)(this.width / 2) - (float)(Width / 2), this.position.Y + (float)(this.height / 2) - (float)(Height / 2)), this.velocity, Width, Height, flag1, flag1);
					}
					else if (this.type == 182 || this.type == 190 || (this.type == 33 || this.type == 229) || (this.type == 237 || this.type == 243))
					{
						int Width = this.width - 20;
						int Height = this.height - 20;
						this.velocity = Collision.TileCollision(new Vector2(this.position.X + (float)(this.width / 2) - (float)(Width / 2), this.position.Y + (float)(this.height / 2) - (float)(Height / 2)), this.velocity, Width, Height, flag1, flag1);
					}
					else if (this.aiStyle == 27)
					{
						int num2 = 6;
						this.velocity = Collision.TileCollision(new Vector2(this.position.X + (float)num2, this.position.Y + (float)num2), this.velocity, this.width - num2 * 2, this.height - num2 * 2, flag1, flag1);
					}
					else if (this.wet)
					{
						if (this.honeyWet)
						{
							Vector2 vector2_3 = this.velocity;
							this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag1, flag1);
							vector2_1 = this.velocity * 0.25f;
							if ((double)this.velocity.X != (double)vector2_3.X)
								vector2_1.X = this.velocity.X;
							if ((double)this.velocity.Y != (double)vector2_3.Y)
								vector2_1.Y = this.velocity.Y;
						}
						else
						{
							Vector2 vector2_3 = this.velocity;
							this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag1, flag1);
							vector2_1 = this.velocity * 0.5f;
							if ((double)this.velocity.X != (double)vector2_3.X)
								vector2_1.X = this.velocity.X;
							if ((double)this.velocity.Y != (double)vector2_3.Y)
								vector2_1.Y = this.velocity.Y;
						}
					}
					else
					{
						this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag1, flag1);
						if (!Main.projPet[this.type])
						{
							Vector4 vector4 = Collision.SlopeCollision(this.position, this.velocity, this.width, this.height, 0.0f);
							if ((double)this.position.X != (double)vector4.X)
								flag3 = true;
							if ((double)this.position.Y != (double)vector4.Y)
								flag3 = true;
							if ((double)this.velocity.X != (double)vector4.Z)
								flag3 = true;
							if ((double)this.velocity.Y != (double)vector4.W)
								flag3 = true;
							this.position.X = vector4.X;
							this.position.Y = vector4.Y;
							this.velocity.X = vector4.Z;
							this.velocity.Y = vector4.W;
						}
					}
					if (vector2_2 != this.velocity)
						flag3 = true;
					if (flag3)
					{
						if (this.aiStyle == 54)
						{
							if ((double) this.velocity.X != (double) vector2_2.X)
							this.velocity.X = vector2_2.X * -0.6f;
							if ((double) this.velocity.Y != (double) vector2_2.Y)
							this.velocity.Y = vector2_2.Y * -0.6f;
						}
						else if (!Main.projPet[this.type])
						{
							if (this.type == 254)
							{
								this.tileCollide = false;
								this.velocity = this.lastVelocity;
								if (this.timeLeft > 30)
									this.timeLeft = 30;
							}
							else if (this.type == 225 && this.penetrate > 0)
							{
								this.velocity.X = -vector2_2.X;
								this.velocity.Y = -vector2_2.Y;
								--this.penetrate;
							}
							else if (this.type == 155)
							{
								if ((double)this.ai[1] > 10.0)
								{
									string str = string.Concat(new object[4]
					{
					  (object) this.name,
					  (object) " was hit ",
					  (object) this.ai[1],
					  (object) " times before touching the ground!"
					});
									if (Main.netMode == 0)
										Main.NewText(str, byte.MaxValue, (byte)240, (byte)20, false);
									else if (Main.netMode == 2)
										NetMessage.SendData(25, -1, -1, str, (int)byte.MaxValue, (float)byte.MaxValue, 240f, 20f, 0);
								}
								this.ai[1] = 0.0f;
								if ((double)this.velocity.X != (double)vector2_2.X)
									this.velocity.X = vector2_2.X * -0.6f;
								if ((double)this.velocity.Y != (double)vector2_2.Y && (double)vector2_2.Y > 2.0)
									this.velocity.Y = vector2_2.Y * -0.6f;
							}
							else if (this.aiStyle == 33)
							{
								if ((double)this.localAI[0] == 0.0)
								{
									if (this.wet)
										this.position += vector2_2 / 2f;
									else
										this.position += vector2_2;
									this.velocity *= 0.0f;
									this.localAI[0] = 1f;
								}
							}
							else if (this.type != 308)
							{
								if (this.type == 94)
								{
									if ((double)this.velocity.X != (double)vector2_2.X)
										this.velocity.X = -vector2_2.X;
									if ((double)this.velocity.Y != (double)vector2_2.Y)
										this.velocity.Y = -vector2_2.Y;
								 }
								else if (this.type == 311)
								{
									if ((double) this.velocity.X != (double) vector2_2.X)
									{
									this.velocity.X = -vector2_2.X;
									++this.ai[1];
									}
									if ((double) this.velocity.Y != (double) vector2_2.Y)
									{
									this.velocity.Y = -vector2_2.Y;
									++this.ai[1];
									}
									if ((double) this.ai[1] > 4.0)
									this.Kill();
								}
								else if (this.type == 312)
								{
									if ((double) this.velocity.X != (double) vector2_2.X)
									{
									this.velocity.X = -vector2_2.X;
									++this.ai[1];
									}
									if ((double) this.velocity.Y != (double) vector2_2.Y)
									{
									this.velocity.Y = -vector2_2.Y;
									++this.ai[1];
									}
								}
								else if (this.type == 281)
								{
									if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) < 2.0 || (double)this.ai[1] == 2.0)
									{
										this.ai[1] = 2f;
									}
									else
									{
										if ((double)this.velocity.X != (double)vector2_2.X)
											this.velocity.X = (float)(-(double)vector2_2.X * 0.5);
										if ((double)this.velocity.Y != (double)vector2_2.Y)
											this.velocity.Y = (float)(-(double)vector2_2.Y * 0.5);
									}
								}
								else if (this.type == 290 || this.type == 294)
								{
									if ((double)this.velocity.X != (double)vector2_2.X)
									{
										this.position.X += this.velocity.X;
										this.velocity.X = -vector2_2.X;
									}
									if ((double)this.velocity.Y != (double)vector2_2.Y)
									{
										this.position.Y += this.velocity.Y;
										this.velocity.Y = -vector2_2.Y;
									}
								}
								else if ((this.type == 181 || this.type == 189) && this.penetrate > 0)
								{
									--this.penetrate;
									if ((double)this.velocity.X != (double)vector2_2.X)
										this.velocity.X = -vector2_2.X;
									if ((double)this.velocity.Y != (double)vector2_2.Y)
										this.velocity.Y = -vector2_2.Y;
								}
								else if (this.type == 307 && (double)this.ai[1] < 5.0)
								{
									++this.ai[1];
									if ((double)this.velocity.X != (double)vector2_2.X)
										this.velocity.X = -vector2_2.X;
									if ((double)this.velocity.Y != (double)vector2_2.Y)
										this.velocity.Y = -vector2_2.Y;
								}
								else if (this.type == 99)
								{
									if ((double)this.velocity.Y != (double)vector2_2.Y && (double)vector2_2.Y > 5.0)
									{
										Collision.HitTiles(this.position, this.velocity, this.width, this.height);
										Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
										this.velocity.Y = (float)(-(double)vector2_2.Y * 0.200000002980232);
									}
									if ((double)this.velocity.X != (double)vector2_2.X)
										this.Kill();
								}
								else if (this.type == 36)
								{
									if (this.penetrate > 1)
									{
										Collision.HitTiles(this.position, this.velocity, this.width, this.height);
										Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
										--this.penetrate;
										if ((double)this.velocity.X != (double)vector2_2.X)
											this.velocity.X = -vector2_2.X;
										if ((double)this.velocity.Y != (double)vector2_2.Y)
											this.velocity.Y = -vector2_2.Y;
									}
									else
										this.Kill();
								}
								else if (this.aiStyle == 21)
								{
									if ((double)this.velocity.X != (double)vector2_2.X)
										this.velocity.X = -vector2_2.X;
									if ((double)this.velocity.Y != (double)vector2_2.Y)
										this.velocity.Y = -vector2_2.Y;
								}
								else if (this.aiStyle == 17)
								{
									if ((double)this.velocity.X != (double)vector2_2.X)
										this.velocity.X = vector2_2.X * -0.75f;
									if ((double)this.velocity.Y != (double)vector2_2.Y && (double)vector2_2.Y > 1.5)
										this.velocity.Y = vector2_2.Y * -0.7f;
								}
								else if (this.aiStyle == 15)
								{
									bool flag2 = false;
									if ((double)vector2_2.X != (double)this.velocity.X)
									{
										if ((double)Math.Abs(vector2_2.X) > 4.0)
											flag2 = true;
										this.position.X += this.velocity.X;
										this.velocity.X = (float)(-(double)vector2_2.X * 0.200000002980232);
									}
									if ((double)vector2_2.Y != (double)this.velocity.Y)
									{
										if ((double)Math.Abs(vector2_2.Y) > 4.0)
											flag2 = true;
										this.position.Y += this.velocity.Y;
										this.velocity.Y = (float)(-(double)vector2_2.Y * 0.200000002980232);
									}
									this.ai[0] = 1f;
									if (flag2)
									{
										this.netUpdate = true;
										Collision.HitTiles(this.position, this.velocity, this.width, this.height);
										Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
									}
								}
								else if (this.aiStyle == 39)
								{
									Collision.HitTiles(this.position, this.velocity, this.width, this.height);
									if (this.type == 33 || this.type == 106)
									{
										if ((double)this.velocity.X != (double)vector2_2.X)
											this.velocity.X = -vector2_2.X;
										if ((double)this.velocity.Y != (double)vector2_2.Y)
											this.velocity.Y = -vector2_2.Y;
									}
									else
									{
										this.ai[0] = 1f;
										if (this.aiStyle == 3)
										{
											this.velocity.X = -vector2_2.X;
											this.velocity.Y = -vector2_2.Y;
										}
									}
									this.netUpdate = true;
									Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
								}
								else if (this.aiStyle == 3 || this.aiStyle == 13)
								{
									Collision.HitTiles(this.position, this.velocity, this.width, this.height);
									if (this.type == 33 || this.type == 106)
									{
										if ((double)this.velocity.X != (double)vector2_2.X)
											this.velocity.X = -vector2_2.X;
										if ((double)this.velocity.Y != (double)vector2_2.Y)
											this.velocity.Y = -vector2_2.Y;
									}
									else
									{
										this.ai[0] = 1f;
										if (this.aiStyle == 3)
										{
											this.velocity.X = -vector2_2.X;
											this.velocity.Y = -vector2_2.Y;
										}
									}
									this.netUpdate = true;
									Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
								}
								else if (this.aiStyle == 8 && this.type != 96)
								{
									Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
									++this.ai[0];
									if ((double)this.ai[0] >= 5.0 && this.type != 253 || this.type == 253 && (double)this.ai[0] >= 8.0)
									{
										this.position += this.velocity;
										this.Kill();
									}
									else
									{
										if (this.type == 15 && (double)this.velocity.Y > 4.0)
										{
											if ((double)this.velocity.Y != (double)vector2_2.Y)
												this.velocity.Y = (float)(-(double)vector2_2.Y * 0.800000011920929);
										}
										else if ((double)this.velocity.Y != (double)vector2_2.Y)
											this.velocity.Y = -vector2_2.Y;
										if ((double)this.velocity.X != (double)vector2_2.X)
											this.velocity.X = -vector2_2.X;
									}
								}
								else if (this.aiStyle == 14)
								{
									if (this.type == 261 && ((double)this.velocity.X != (double)vector2_2.X && ((double)vector2_2.X < -3.0 || (double)vector2_2.X > 3.0) || (double)this.velocity.Y != (double)vector2_2.Y && ((double)vector2_2.Y < -3.0 || (double)vector2_2.Y > 3.0)))
									{
										Collision.HitTiles(this.position, this.velocity, this.width, this.height);
										Main.PlaySound(0, (int)this.center().X, (int)this.center().Y, 1);
									}
									if (this.type >= 326 && this.type <= 328)
									{
										if ((double) this.velocity.X != (double) vector2_2.X)
											this.velocity.X = vector2_2.X * -0.1f;
									}
									else if (this.type == 50)
									{
										if ((double)this.velocity.X != (double)vector2_2.X)
											this.velocity.X = vector2_2.X * -0.2f;
										if ((double)this.velocity.Y != (double)vector2_2.Y && (double)vector2_2.Y > 1.5)
											this.velocity.Y = vector2_2.Y * -0.2f;
									}
									else if (this.type == 185)
									{
										if ((double)this.velocity.X != (double)vector2_2.X)
											this.velocity.X = vector2_2.X * -0.9f;
										if ((double)this.velocity.Y != (double)vector2_2.Y && (double)vector2_2.Y > 1.0)
											this.velocity.Y = vector2_2.Y * -0.9f;
									}
									else if (this.type == 277)
									{
										if ((double)this.velocity.X != (double)vector2_2.X)
											this.velocity.X = vector2_2.X * -0.9f;
										if ((double)this.velocity.Y != (double)vector2_2.Y && (double)vector2_2.Y > 3.0)
											this.velocity.Y = vector2_2.Y * -0.9f;
									}
									else
									{
										if ((double)this.velocity.X != (double)vector2_2.X)
											this.velocity.X = vector2_2.X * -0.5f;
										if ((double)this.velocity.Y != (double)vector2_2.Y && (double)vector2_2.Y > 1.0)
											this.velocity.Y = vector2_2.Y * -0.5f;
									}
								}
								else if (this.aiStyle == 16)
								{
									if ((double)this.velocity.X != (double)vector2_2.X)
									{
										this.velocity.X = vector2_2.X * -0.4f;
										if (this.type == 29)
											this.velocity.X = this.velocity.X * 0.8f;
									}
									if ((double)this.velocity.Y != (double)vector2_2.Y && (double)vector2_2.Y > 0.7 && this.type != 102)
									{
										this.velocity.Y = vector2_2.Y * -0.4f;
										if (this.type == 29)
											this.velocity.Y = this.velocity.Y * 0.8f;
									}
									if (this.type == 134 || this.type == 137 || (this.type == 140 || this.type == 143) || this.type == 303)
									{
										this.velocity *= 0.0f;
										this.alpha = (int)byte.MaxValue;
										this.timeLeft = 3;
									}
								}
								else if (this.aiStyle != 9 || this.owner == Main.myPlayer)
								{
									this.position += this.velocity;
									this.Kill();
								}
							}
						}
					}
				}
				if (this.aiStyle != 4 && this.aiStyle != 38)
				{
					if (this.wet)
						this.position += vector2_1;
					else
						this.position += this.velocity;
					if (Main.projPet[this.type] && this.tileCollide)
					{
						Vector4 vector4 = Collision.SlopeCollision(this.position, this.velocity, this.width, this.height, 0.0f);
						bool flag1;
						if ((double)this.position.X != (double)vector4.X)
							flag1 = true;
						if ((double)this.position.Y != (double)vector4.Y)
							flag1 = true;
						if ((double)this.velocity.X != (double)vector4.Z)
							flag1 = true;
						if ((double)this.velocity.Y != (double)vector4.W)
							flag1 = true;
						this.position.X = vector4.X;
						this.position.Y = vector4.Y;
						this.velocity.X = vector4.Z;
						this.velocity.Y = vector4.W;
					}
				}
				if ((this.aiStyle != 3 || (double)this.ai[0] != 1.0) && (this.aiStyle != 7 || (double)this.ai[0] != 1.0) && ((this.aiStyle != 13 || (double)this.ai[0] != 1.0) && (this.aiStyle != 15 || (double)this.ai[0] != 1.0)) && (this.aiStyle != 15 && this.aiStyle != 26))
					this.direction = (double)this.velocity.X >= 0.0 ? 1 : -1;
				if (!this.active)
					return;
				this.ProjLight();
				if (this.type == 2 || this.type == 82)
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 1f);
				else if (this.type == 172)
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 135, 0.0f, 0.0f, 100, new Color(), 1f);
				else if (this.type == 103)
				{
					int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 75, 0.0f, 0.0f, 100, new Color(), 1f);
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[index].noGravity = true;
						Main.dust[index].scale *= 2f;
					}
				}
				else if (this.type == 278)
				{
					int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 169, 0.0f, 0.0f, 100, new Color(), 1f);
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[index].noGravity = true;
						Main.dust[index].scale *= 1.5f;
					}
				}
				else if (this.type == 4)
				{
					if (Main.rand.Next(5) == 0)
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0.0f, 0.0f, 150, new Color(), 1.1f);
				}
				else if (this.type == 5)
				{
					int Type;
					switch (Main.rand.Next(3))
					{
						case 0:
							Type = 15;
							break;
						case 1:
							Type = 57;
							break;
						default:
							Type = 58;
							break;
					}
					Dust.NewDust(this.position, this.width, this.height, Type, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, new Color(), 1.2f);
				}
				this.Damage();
				if (Main.netMode != 1 && this.type == 99)
					Collision.SwitchTiles(this.position, this.width, this.height, this.lastPosition, 3);
				if (this.type == 94 || this.type == 301)
				{
					for (int index = this.oldPos.Length - 1; index > 0; --index)
						this.oldPos[index] = this.oldPos[index - 1];
					this.oldPos[0] = this.position;
				}
				--this.timeLeft;
				if (this.timeLeft <= 0)
					this.Kill();
				if (this.penetrate == 0)
					this.Kill();
				if (this.active && this.owner == Main.myPlayer)
				{
					if (this.netUpdate2)
						this.netUpdate = true;
					if (!this.active)
						this.netSpam = 0;
					if (this.netUpdate)
					{
						if (this.netSpam < 60)
						{
							this.netSpam += 5;
							NetMessage.SendData(27, -1, -1, "", i, 0.0f, 0.0f, 0.0f, 0);
							this.netUpdate2 = false;
						}
						else
							this.netUpdate2 = true;
					}
					if (this.netSpam > 0)
						--this.netSpam;
				}
				if (this.active && this.maxUpdates > 0)
				{
					--this.numUpdates;
					if (this.numUpdates >= 0)
						this.Update(i);
					else
						this.numUpdates = this.maxUpdates;
				}
				this.netUpdate = false;
			}
		}

		public void AI()
		{
			if (this.aiStyle == 1)
			{
				if (this.type == 323)
				{
					this.alpha -= 50;
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
				}
				if (this.type == 282)
				{
					int num = Dust.NewDust(this.position, this.width, this.height, 171, 0f, 0f, 100, default(Color), 1f);
					Main.dust[num].scale = (float)Main.rand.Next(1, 10) * 0.1f;
					Main.dust[num].noGravity = true;
					Main.dust[num].fadeIn = 1.5f;
					Main.dust[num].velocity *= 0.25f;
					Main.dust[num].velocity += this.velocity * 0.25f;
				}
				if (this.type == 275 || this.type == 276)
				{
					this.frameCounter++;
					if (this.frameCounter > 1)
					{
						this.frameCounter = 0;
						this.frame++;
						if (this.frame > 1)
						{
							this.frame = 0;
						}
					}
				}
				if (this.type == 225)
				{
					int num2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 40, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num2].noGravity = true;
					Main.dust[num2].scale = 1.3f;
					Main.dust[num2].velocity *= 0.5f;
				}
				if (this.type == 174)
				{
					if (this.alpha == 0)
					{
						int num3 = Dust.NewDust(this.lastPosition - this.velocity * 3f, this.width, this.height, 76, 0f, 0f, 50, default(Color), 1f);
						Main.dust[num3].noGravity = true;
						Main.dust[num3].noLight = true;
						Main.dust[num3].velocity *= 0.5f;
					}
					this.alpha -= 50;
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
					if (this.ai[1] == 0f)
					{
						this.ai[1] = 1f;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 17);
					}
				}
				else if (this.type == 176)
				{
					if (this.alpha == 0)
					{
						int num4 = Dust.NewDust(this.lastPosition, this.width, this.height, 22, 0f, 0f, 100, default(Color), 0.5f);
						Main.dust[num4].noGravity = true;
						Main.dust[num4].noLight = true;
						Main.dust[num4].velocity *= 0.15f;
						Main.dust[num4].fadeIn = 0.8f;
					}
					this.alpha -= 50;
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
					if (this.ai[1] == 0f)
					{
						this.ai[1] = 1f;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 17);
					}
				}
				if (this.type == 325)
				{
					this.alpha -= 100;
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
					Lighting.addLight((int)this.center().X / 16, (int)this.center().Y / 16, 0.9f, 0.6f, 0.2f);
					if (this.alpha == 0)
					{
						int num5 = 2;
						if (Main.rand.Next(2) == 0)
						{
							int num6 = Dust.NewDust(new Vector2(this.center().X - (float)num5, this.center().Y - (float)num5 - 2f) - this.velocity * 0.5f, num5 * 2, num5 * 2, 6, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num6].scale *= 1.8f + (float)Main.rand.Next(10) * 0.1f;
							Main.dust[num6].velocity *= 0.2f;
							Main.dust[num6].noGravity = true;
						}
						if (Main.rand.Next(4) == 0)
						{
							int num7 = Dust.NewDust(new Vector2(this.center().X - (float)num5, this.center().Y - (float)num5 - 2f) - this.velocity * 0.5f, num5 * 2, num5 * 2, 31, 0f, 0f, 100, default(Color), 0.5f);
							Main.dust[num7].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
							Main.dust[num7].velocity *= 0.05f;
						}
					}
					if (this.ai[1] == 0f)
					{
						this.ai[1] = 1f;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 42);
					}
				}
				if (this.type == 83 && this.ai[1] == 0f)
				{
					this.ai[1] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 33);
				}
				if (this.type == 259 && this.ai[1] == 0f)
				{
					this.ai[1] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 33);
				}
				if (this.type == 110 && this.ai[1] == 0f)
				{
					this.ai[1] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 11);
				}
				if (this.type == 302 && this.ai[1] == 0f)
				{
					this.ai[1] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 11);
				}
				if (this.type == 84 && this.ai[1] == 0f)
				{
					this.ai[1] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 12);
				}
				if (this.type == 257 && this.ai[1] == 0f)
				{
					this.ai[1] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 12);
				}
				if (this.type == 100 && this.ai[1] == 0f)
				{
					this.ai[1] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 33);
				}
				if (this.type == 98 && this.ai[1] == 0f)
				{
					this.ai[1] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 17);
				}
				if (this.type == 184 && this.ai[1] == 0f)
				{
					this.ai[1] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 17);
				}
				if (this.type == 195 && this.ai[1] == 0f)
				{
					this.ai[1] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 17);
				}
				if (this.type == 275 && this.ai[1] == 0f)
				{
					this.ai[1] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 17);
				}
				if (this.type == 276 && this.ai[1] == 0f)
				{
					this.ai[1] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 17);
				}
				if ((this.type == 81 || this.type == 82) && this.ai[1] == 0f)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 5);
					this.ai[1] = 1f;
				}
				if (this.type == 180 && this.ai[1] == 0f)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 11);
					this.ai[1] = 1f;
				}
				if (this.type == 248 && this.ai[1] == 0f)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 17);
					this.ai[1] = 1f;
				}
				if (this.type == 41)
				{
					int num8 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.6f);
					Main.dust[num8].noGravity = true;
					num8 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num8].noGravity = true;
				}
				else if (this.type == 55)
				{
					int num9 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 18, 0f, 0f, 0, default(Color), 0.9f);
					Main.dust[num9].noGravity = true;
				}
				else if (this.type == 91 && Main.rand.Next(2) == 0)
				{
					int num10;
					if (Main.rand.Next(2) == 0)
					{
						num10 = 15;
					}
					else
					{
						num10 = 58;
					}
					int num11 = Dust.NewDust(this.position, this.width, this.height, num10, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 150, default(Color), 0.9f);
					Main.dust[num11].velocity *= 0.25f;
				}
				if (this.type == 163 || this.type == 310)
				{
					if (this.alpha > 0)
					{
						this.alpha -= 25;
					}
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
				}
				if (this.type == 20 || this.type == 14 || this.type == 36 || this.type == 83 || this.type == 84 || this.type == 89 || this.type == 100 || this.type == 104 || this.type == 110 || this.type == 180 || this.type == 279 || (this.type >= 158 && this.type <= 161) || (this.type >= 283 && this.type <= 287))
				{
					if (this.alpha > 0)
					{
						this.alpha -= 15;
					}
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
				}
				if (this.type == 242 || this.type == 302)
				{
					float num12 = (float)Math.Sqrt((double)(this.velocity.X * this.velocity.X + this.velocity.Y * this.velocity.Y));
					if (this.alpha > 0)
					{
						this.alpha -= (int)((byte)((double)num12 * 0.9));
					}
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
				}
				if (this.type == 257)
				{
					if (this.alpha > 0)
					{
						this.alpha -= 10;
					}
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
				}
				if (this.type == 88)
				{
					if (this.alpha > 0)
					{
						this.alpha -= 10;
					}
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
				}
				if (this.type != 5 && this.type != 325 && this.type != 323 && this.type != 14 && this.type != 270 && this.type != 180 && this.type != 259 && this.type != 242 && this.type != 302 && this.type != 20 && this.type != 36 && this.type != 38 && this.type != 55 && this.type != 83 && this.type != 84 && this.type != 88 && this.type != 89 && this.type != 98 && this.type != 100 && this.type != 265 && this.type != 104 && this.type != 110 && this.type != 184 && this.type != 257 && this.type != 248 && (this.type < 283 || this.type > 287) && this.type != 279 && this.type != 299 && (this.type < 158 || this.type > 161))
				{
					this.ai[0] += 1f;
				}
				if (this.type == 299)
				{
					if (this.localAI[0] == 6f)
					{
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
						for (int i = 0; i < 40; i++)
						{
							int num13 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 181, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num13].velocity *= 3f;
							Main.dust[num13].velocity += this.velocity * 0.75f;
							Main.dust[num13].scale *= 1.2f;
							Main.dust[num13].noGravity = true;
						}
					}
					this.localAI[0] += 1f;
					if (this.localAI[0] > 6f)
					{
						for (int j = 0; j < 3; j++)
						{
							int num14 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 181, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 1f);
							Main.dust[num14].velocity *= 0.6f;
							Main.dust[num14].scale *= 1.4f;
							Main.dust[num14].noGravity = true;
						}
					}
				}
				else if (this.type == 270)
				{
					if (this.alpha > 0)
					{
						this.alpha -= 50;
					}
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
					this.frame++;
					if (this.frame > 2)
					{
						this.frame = 0;
					}
					for (int k = 0; k < 2; k++)
					{
						int num15 = Dust.NewDust(new Vector2(this.position.X + 4f, this.position.Y + 4f), this.width - 8, this.height - 8, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num15].position -= this.velocity * 2f;
						Main.dust[num15].noGravity = true;
						Dust expr_1345_cp_0 = Main.dust[num15];
						expr_1345_cp_0.velocity.X = expr_1345_cp_0.velocity.X * 0.3f;
						Dust expr_1363_cp_0 = Main.dust[num15];
						expr_1363_cp_0.velocity.Y = expr_1363_cp_0.velocity.Y * 0.3f;
					}
				}
				if (this.type == 259)
				{
					if (this.alpha > 0)
					{
						this.alpha -= 10;
					}
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
				}
				if (this.type == 265)
				{
					if (this.alpha > 0)
					{
						this.alpha -= 50;
					}
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
					if (this.alpha == 0)
					{
						int num16 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 163, this.velocity.X, this.velocity.Y, 100, default(Color), 1.2f);
						Main.dust[num16].noGravity = true;
						Main.dust[num16].velocity *= 0.3f;
						Main.dust[num16].velocity -= this.velocity * 0.4f;
					}
				}
				if (this.type == 207)
				{
					if (this.alpha < 170)
					{
						for (int l = 0; l < 10; l++)
						{
							float x = this.position.X - this.velocity.X / 10f * (float)l;
							float y = this.position.Y - this.velocity.Y / 10f * (float)l;
							int num17 = Dust.NewDust(new Vector2(x, y), 1, 1, 75, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num17].alpha = this.alpha;
							Main.dust[num17].position.X = x;
							Main.dust[num17].position.Y = y;
							Main.dust[num17].velocity *= 0f;
							Main.dust[num17].noGravity = true;
						}
					}
					float num18 = (float)Math.Sqrt((double)(this.velocity.X * this.velocity.X + this.velocity.Y * this.velocity.Y));
					float num19 = this.localAI[0];
					if (num19 == 0f)
					{
						this.localAI[0] = num18;
						num19 = num18;
					}
					if (this.alpha > 0)
					{
						this.alpha -= 25;
					}
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
					float num20 = this.position.X;
					float num21 = this.position.Y;
					float num22 = 300f;
					bool flag = false;
					int num23 = 0;
					if (this.ai[1] == 0f)
					{
						for (int m = 0; m < 200; m++)
						{
							if (Main.npc[m].active && !Main.npc[m].dontTakeDamage && !Main.npc[m].friendly && Main.npc[m].lifeMax > 5 && (this.ai[1] == 0f || this.ai[1] == (float)(m + 1)))
							{
								float num24 = Main.npc[m].position.X + (float)(Main.npc[m].width / 2);
								float num25 = Main.npc[m].position.Y + (float)(Main.npc[m].height / 2);
								float num26 = Math.Abs(this.position.X + (float)(this.width / 2) - num24) + Math.Abs(this.position.Y + (float)(this.height / 2) - num25);
								if (num26 < num22 && Collision.CanHit(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2)), 1, 1, Main.npc[m].position, Main.npc[m].width, Main.npc[m].height))
								{
									num22 = num26;
									num20 = num24;
									num21 = num25;
									flag = true;
									num23 = m;
								}
							}
						}
						if (flag)
						{
							this.ai[1] = (float)(num23 + 1);
						}
						flag = false;
					}
					if (this.ai[1] != 0f)
					{
						int num27 = (int)(this.ai[1] - 1f);
						if (Main.npc[num27].active)
						{
							float num28 = Main.npc[num27].position.X + (float)(Main.npc[num27].width / 2);
							float num29 = Main.npc[num27].position.Y + (float)(Main.npc[num27].height / 2);
							float num30 = Math.Abs(this.position.X + (float)(this.width / 2) - num28) + Math.Abs(this.position.Y + (float)(this.height / 2) - num29);
							if (num30 < 1000f)
							{
								flag = true;
								num20 = Main.npc[num27].position.X + (float)(Main.npc[num27].width / 2);
								num21 = Main.npc[num27].position.Y + (float)(Main.npc[num27].height / 2);
							}
						}
					}
					if (flag)
					{
						float num31 = num19;
						Vector2 vector = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num32 = num20 - vector.X;
						float num33 = num21 - vector.Y;
						float num34 = (float)Math.Sqrt((double)(num32 * num32 + num33 * num33));
						num34 = num31 / num34;
						num32 *= num34;
						num33 *= num34;
						this.velocity.X = (this.velocity.X * 5f + num32) / 6f;
						this.velocity.Y = (this.velocity.Y * 5f + num33) / 6f;
					}
				}
				else if (this.type == 81 || this.type == 91)
				{
					if (this.ai[0] >= 20f)
					{
						this.ai[0] = 20f;
						this.velocity.Y = this.velocity.Y + 0.07f;
					}
				}
				else if (this.type == 174)
				{
					if (this.ai[0] >= 5f)
					{
						this.ai[0] = 5f;
						this.velocity.Y = this.velocity.Y + 0.15f;
					}
				}
				else if (this.type == 246)
				{
					this.alpha -= 20;
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
					if (this.ai[0] >= 60f)
					{
						this.ai[0] = 60f;
						this.velocity.Y = this.velocity.Y + 0.15f;
					}
				}
				else if (this.type == 311)
				{
					if (this.alpha > 0)
					{
						this.alpha -= 50;
					}
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
					if (this.ai[0] >= 30f)
					{
						this.ai[0] = 30f;
						if (this.ai[1] == 0f)
						{
							this.ai[1] = 1f;
						}
						this.velocity.Y = this.velocity.Y + 0.5f;
					}
				}
				else if (this.type == 312)
				{
					if (this.ai[0] >= 5f)
					{
						this.alpha = 0;
					}
					if (this.ai[0] >= 20f)
					{
						this.ai[0] = 30f;
						this.velocity.Y = this.velocity.Y + 0.5f;
					}
				}
				else if (this.type != 239 && this.type != 264)
				{
					if (this.type == 176)
					{
						if (this.ai[0] >= 15f)
						{
							this.ai[0] = 15f;
							this.velocity.Y = this.velocity.Y + 0.05f;
						}
					}
					else if (this.type == 275 || this.type == 276)
					{
						if (this.alpha > 0)
						{
							this.alpha -= 30;
						}
						if (this.alpha < 0)
						{
							this.alpha = 0;
						}
						if (this.ai[0] >= 35f)
						{
							this.ai[0] = 35f;
							this.velocity.Y = this.velocity.Y + 0.025f;
						}
					}
					else if (this.type == 172)
					{
						if (this.ai[0] >= 17f)
						{
							this.ai[0] = 17f;
							this.velocity.Y = this.velocity.Y + 0.085f;
						}
					}
					else if (this.type == 117)
					{
						if (this.ai[0] >= 35f)
						{
							this.ai[0] = 35f;
							this.velocity.Y = this.velocity.Y + 0.06f;
						}
					}
					else if (this.type == 120)
					{
						int num35 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 67, this.velocity.X, this.velocity.Y, 100, default(Color), 1.2f);
						Main.dust[num35].noGravity = true;
						Main.dust[num35].velocity *= 0.3f;
						if (this.ai[0] >= 30f)
						{
							this.ai[0] = 30f;
							this.velocity.Y = this.velocity.Y + 0.05f;
						}
					}
					else if (this.type == 195)
					{
						if (this.ai[0] >= 20f)
						{
							this.ai[0] = 20f;
							this.velocity.Y = this.velocity.Y + 0.075f;
						}
					}
					else if (this.type == 267)
					{
						this.localAI[0] += 1f;
						if (this.localAI[0] > 3f)
						{
							this.alpha = 0;
						}
						if (this.ai[0] >= 20f)
						{
							this.ai[0] = 20f;
							this.velocity.Y = this.velocity.Y + 0.075f;
						}
					}
					else if (this.ai[0] >= 15f)
					{
						this.ai[0] = 15f;
						this.velocity.Y = this.velocity.Y + 0.1f;
					}
				}
				if (this.type == 248)
				{
					if (this.velocity.X < 0f)
					{
						this.rotation -= (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.05f;
					}
					else
					{
						this.rotation += (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.05f;
					}
				}
				if (this.type == 270)
				{
					this.spriteDirection = this.direction;
					if (this.direction < 0)
					{
						this.rotation = (float)Math.Atan2((double)(-(double)this.velocity.Y), (double)(-(double)this.velocity.X));
					}
					else
					{
						this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X);
					}
				}
				else if (this.type == 311)
				{
					if (this.ai[1] != 0f)
					{
						this.rotation += this.velocity.X * 0.1f + (float)Main.rand.Next(-10, 11) * 0.025f;
					}
					else
					{
						this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
					}
				}
				else if (this.type == 312)
				{
					this.rotation += this.velocity.X * 0.02f;
				}
				else
				{
					this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
				}
				if (this.velocity.Y > 16f)
				{
					this.velocity.Y = 16f;
					return;
				}
			}
			else if (this.aiStyle == 2)
			{
				if (this.type == 93 && Main.rand.Next(5) == 0)
				{
					int num36 = Dust.NewDust(this.position, this.width, this.height, 57, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 0.3f);
					Dust expr_21B6_cp_0 = Main.dust[num36];
					expr_21B6_cp_0.velocity.X = expr_21B6_cp_0.velocity.X * 0.3f;
					Dust expr_21D4_cp_0 = Main.dust[num36];
					expr_21D4_cp_0.velocity.Y = expr_21D4_cp_0.velocity.Y * 0.3f;
				}
				if (this.type == 304 && this.localAI[0] == 0f)
				{
					this.localAI[0] += 1f;
					this.alpha = 0;
				}
				this.rotation += (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.03f * (float)this.direction;
				if (this.type == 162)
				{
					if (this.ai[1] == 0f)
					{
						this.ai[1] = 1f;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					}
					this.ai[0] += 1f;
					if (this.ai[0] >= 18f)
					{
						this.velocity.Y = this.velocity.Y + 0.28f;
						this.velocity.X = this.velocity.X * 0.99f;
					}
					if (this.ai[0] > 2f)
					{
						this.alpha = 0;
						if (this.ai[0] == 3f)
						{
							for (int n = 0; n < 10; n++)
							{
								int num37 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
								Main.dust[num37].velocity *= 0.5f;
								Main.dust[num37].velocity += this.velocity * 0.1f;
							}
							for (int num38 = 0; num38 < 5; num38++)
							{
								int num39 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
								Main.dust[num39].noGravity = true;
								Main.dust[num39].velocity *= 3f;
								Main.dust[num39].velocity += this.velocity * 0.2f;
								num39 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
								Main.dust[num39].velocity *= 2f;
								Main.dust[num39].velocity += this.velocity * 0.3f;
							}
							for (int num40 = 0; num40 < 1; num40++)
							{
								int num41 = Gore.NewGore(new Vector2(this.position.X - 10f, this.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
								Main.gore[num41].position += this.velocity * 1.25f;
								Main.gore[num41].scale = 1.5f;
								Main.gore[num41].velocity += this.velocity * 0.5f;
								Main.gore[num41].velocity *= 0.02f;
							}
						}
					}
				}
				else if (this.type == 281)
				{
					if (this.ai[1] == 0f)
					{
						this.ai[1] = 1f;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					}
					this.ai[0] += 1f;
					if (this.ai[0] >= 18f)
					{
						this.velocity.Y = this.velocity.Y + 0.28f;
						this.velocity.X = this.velocity.X * 0.99f;
					}
					if (this.ai[0] > 2f)
					{
						this.alpha = 0;
						if (this.ai[0] == 3f)
						{
							for (int num42 = 0; num42 < 10; num42++)
							{
								int num43 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
								Main.dust[num43].velocity *= 0.5f;
								Main.dust[num43].velocity += this.velocity * 0.1f;
							}
							for (int num44 = 0; num44 < 5; num44++)
							{
								int num45 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
								Main.dust[num45].noGravity = true;
								Main.dust[num45].velocity *= 3f;
								Main.dust[num45].velocity += this.velocity * 0.2f;
								num45 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
								Main.dust[num45].velocity *= 2f;
								Main.dust[num45].velocity += this.velocity * 0.3f;
							}
							for (int num46 = 0; num46 < 1; num46++)
							{
								int num47 = Gore.NewGore(new Vector2(this.position.X - 10f, this.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
								Main.gore[num47].position += this.velocity * 1.25f;
								Main.gore[num47].scale = 1.5f;
								Main.gore[num47].velocity += this.velocity * 0.5f;
								Main.gore[num47].velocity *= 0.02f;
							}
						}
					}
				}
				else if (this.type == 240)
				{
					if (this.ai[1] == 0f)
					{
						this.ai[1] = 1f;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					}
					this.ai[0] += 1f;
					if (this.ai[0] >= 16f)
					{
						this.velocity.Y = this.velocity.Y + 0.18f;
						this.velocity.X = this.velocity.X * 0.991f;
					}
					if (this.ai[0] > 2f)
					{
						this.alpha = 0;
						if (this.ai[0] == 3f)
						{
							for (int num48 = 0; num48 < 7; num48++)
							{
								int num49 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
								Main.dust[num49].velocity *= 0.5f;
								Main.dust[num49].velocity += this.velocity * 0.1f;
							}
							for (int num50 = 0; num50 < 3; num50++)
							{
								int num51 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
								Main.dust[num51].noGravity = true;
								Main.dust[num51].velocity *= 3f;
								Main.dust[num51].velocity += this.velocity * 0.2f;
								num51 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
								Main.dust[num51].velocity *= 2f;
								Main.dust[num51].velocity += this.velocity * 0.3f;
							}
							for (int num52 = 0; num52 < 1; num52++)
							{
								int num53 = Gore.NewGore(new Vector2(this.position.X - 10f, this.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
								Main.gore[num53].position += this.velocity * 1.25f;
								Main.gore[num53].scale = 1.25f;
								Main.gore[num53].velocity += this.velocity * 0.5f;
								Main.gore[num53].velocity *= 0.02f;
							}
						}
					}
				}
				else if (this.type == 249)
				{
					this.ai[0] += 1f;
					if (this.ai[0] >= 0f)
					{
						this.velocity.Y = this.velocity.Y + 0.25f;
					}
				}
				else if (this.type == 69 || this.type == 70)
				{
					this.ai[0] += 1f;
					if (this.ai[0] >= 10f)
					{
						this.velocity.Y = this.velocity.Y + 0.25f;
						this.velocity.X = this.velocity.X * 0.99f;
					}
				}
				else if (this.type == 166)
				{
					this.ai[0] += 1f;
					if (this.ai[0] >= 20f)
					{
						this.velocity.Y = this.velocity.Y + 0.3f;
						this.velocity.X = this.velocity.X * 0.98f;
					}
				}
				else if (this.type == 300)
				{
					if (this.ai[0] == 0f)
					{
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 1);
					}
					this.ai[0] += 1f;
					if (this.ai[0] >= 60f)
					{
						this.velocity.Y = this.velocity.Y + 0.2f;
						this.velocity.X = this.velocity.X * 0.99f;
					}
				}
				else if (this.type == 306)
				{
					if (this.alpha <= 200)
					{
						for (int num54 = 0; num54 < 4; num54++)
						{
							float num55 = this.velocity.X / 4f * (float)num54;
							float num56 = this.velocity.Y / 4f * (float)num54;
							int num57 = Dust.NewDust(this.position, this.width, this.height, 184, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num57].position.X = this.center().X - num55;
							Main.dust[num57].position.Y = this.center().Y - num56;
							Main.dust[num57].velocity *= 0f;
							Main.dust[num57].scale = 0.7f;
						}
					}
					this.alpha -= 50;
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
					this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 0.785f;
				}
				else if (this.type == 304)
				{
					this.ai[0] += 1f;
					if (this.ai[0] >= 30f)
					{
						this.alpha += 10;
						this.damage = (int)((double)this.damage * 0.9);
						this.knockBack = (float)((int)((double)this.knockBack * 0.9));
						if (this.alpha >= 255)
						{
							this.active = false;
						}
					}
					if (this.ai[0] < 30f)
					{
						this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
					}
				}
				else
				{
					this.ai[0] += 1f;
					if (this.ai[0] >= 20f)
					{
						this.velocity.Y = this.velocity.Y + 0.4f;
						this.velocity.X = this.velocity.X * 0.97f;
					}
					else if (this.type == 48 || this.type == 54 || this.type == 93)
					{
						this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
					}
				}
				if (this.velocity.Y > 16f)
				{
					this.velocity.Y = 16f;
				}
				if (this.type == 54 && Main.rand.Next(20) == 0)
				{
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 40, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 0, default(Color), 0.75f);
					return;
				}
			}
			else if (this.aiStyle == 3)
			{
				if (this.soundDelay == 0)
				{
					this.soundDelay = 8;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 7);
				}
				if (this.type == 19)
				{
					for (int num58 = 0; num58 < 2; num58++)
					{
						int num59 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num59].noGravity = true;
						Dust expr_3392_cp_0 = Main.dust[num59];
						expr_3392_cp_0.velocity.X = expr_3392_cp_0.velocity.X * 0.3f;
						Dust expr_33B0_cp_0 = Main.dust[num59];
						expr_33B0_cp_0.velocity.Y = expr_33B0_cp_0.velocity.Y * 0.3f;
					}
				}
				else if (this.type == 33)
				{
					if (Main.rand.Next(1) == 0)
					{
						int num60 = Dust.NewDust(this.position, this.width, this.height, 40, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 0, default(Color), 1.4f);
						Main.dust[num60].noGravity = true;
					}
				}
				else if (this.type == 320)
				{
					if (Main.rand.Next(3) == 0)
					{
						int num61 = Dust.NewDust(this.position, this.width, this.height, 5, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 0, default(Color), 1.1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num61].scale = 0.9f;
							Main.dust[num61].velocity *= 0.2f;
						}
						else
						{
							Main.dust[num61].noGravity = true;
						}
					}
				}
				else if (this.type == 6)
				{
					if (Main.rand.Next(5) == 0)
					{
						int num62 = Main.rand.Next(3);
						if (num62 == 0)
						{
							num62 = 15;
						}
						else if (num62 == 1)
						{
							num62 = 57;
						}
						else
						{
							num62 = 58;
						}
						Dust.NewDust(this.position, this.width, this.height, num62, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 150, default(Color), 0.7f);
					}
				}
				else if (this.type == 113 && Main.rand.Next(1) == 0)
				{
					int num63 = Dust.NewDust(this.position, this.width, this.height, 76, this.velocity.X * 0.15f, this.velocity.Y * 0.15f, 0, default(Color), 1.1f);
					Main.dust[num63].noGravity = true;
					Dust.NewDust(this.position, this.width, this.height, 15, this.velocity.X * 0.05f, this.velocity.Y * 0.05f, 150, default(Color), 0.6f);
				}
				if (this.ai[0] == 0f)
				{
					this.ai[1] += 1f;
					if (this.type == 106 && this.ai[1] >= 45f)
					{
						this.ai[0] = 1f;
						this.ai[1] = 0f;
						this.netUpdate = true;
					}
					if (this.type == 320)
					{
						if (this.ai[1] >= 10f)
						{
							this.velocity.Y = this.velocity.Y + 0.5f;
							this.velocity.X = this.velocity.X * 0.95f;
							if (this.velocity.Y > 16f)
							{
								this.velocity.Y = 16f;
							}
						}
					}
					else if (this.type == 182)
					{
						if (Main.rand.Next(2) == 0)
						{
							int num64 = Dust.NewDust(this.position, this.width, this.height, 57, 0f, 0f, 255, default(Color), 0.75f);
							Main.dust[num64].velocity *= 0.1f;
							Main.dust[num64].noGravity = true;
						}
						if (this.velocity.X > 0f)
						{
							this.spriteDirection = 1;
						}
						else if (this.velocity.X < 0f)
						{
							this.spriteDirection = -1;
						}
						float num65 = this.position.X;
						float num66 = this.position.Y;
						bool flag2 = false;
						if (this.ai[1] > 10f)
						{
							for (int num67 = 0; num67 < 200; num67++)
							{
								if (Main.npc[num67].active && !Main.npc[num67].dontTakeDamage && !Main.npc[num67].friendly && Main.npc[num67].lifeMax > 5)
								{
									float num68 = Main.npc[num67].position.X + (float)(Main.npc[num67].width / 2);
									float num69 = Main.npc[num67].position.Y + (float)(Main.npc[num67].height / 2);
									float num70 = Math.Abs(this.position.X + (float)(this.width / 2) - num68) + Math.Abs(this.position.Y + (float)(this.height / 2) - num69);
									if (num70 < 800f && Collision.CanHit(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2)), 1, 1, Main.npc[num67].position, Main.npc[num67].width, Main.npc[num67].height))
									{
										num65 = num68;
										num66 = num69;
										flag2 = true;
									}
								}
							}
						}
						if (!flag2)
						{
							num65 = this.position.X + (float)(this.width / 2) + this.velocity.X * 100f;
							num66 = this.position.Y + (float)(this.height / 2) + this.velocity.Y * 100f;
							if (this.ai[1] >= 30f)
							{
								this.ai[0] = 1f;
								this.ai[1] = 0f;
								this.netUpdate = true;
							}
						}
						float num71 = 12f;
						float num72 = 0.25f;
						Vector2 vector2 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num73 = num65 - vector2.X;
						float num74 = num66 - vector2.Y;
						float num75 = (float)Math.Sqrt((double)(num73 * num73 + num74 * num74));
						num75 = num71 / num75;
						num73 *= num75;
						num74 *= num75;
						if (this.velocity.X < num73)
						{
							this.velocity.X = this.velocity.X + num72;
							if (this.velocity.X < 0f && num73 > 0f)
							{
								this.velocity.X = this.velocity.X + num72 * 2f;
							}
						}
						else if (this.velocity.X > num73)
						{
							this.velocity.X = this.velocity.X - num72;
							if (this.velocity.X > 0f && num73 < 0f)
							{
								this.velocity.X = this.velocity.X - num72 * 2f;
							}
						}
						if (this.velocity.Y < num74)
						{
							this.velocity.Y = this.velocity.Y + num72;
							if (this.velocity.Y < 0f && num74 > 0f)
							{
								this.velocity.Y = this.velocity.Y + num72 * 2f;
							}
						}
						else if (this.velocity.Y > num74)
						{
							this.velocity.Y = this.velocity.Y - num72;
							if (this.velocity.Y > 0f && num74 < 0f)
							{
								this.velocity.Y = this.velocity.Y - num72 * 2f;
							}
						}
					}
					else if (this.type == 301)
					{
						if (this.ai[1] >= 20f)
						{
							this.ai[0] = 1f;
							this.ai[1] = 0f;
							this.netUpdate = true;
						}
					}
					else if (this.ai[1] >= 30f)
					{
						this.ai[0] = 1f;
						this.ai[1] = 0f;
						this.netUpdate = true;
					}
				}
				else
				{
					this.tileCollide = false;
					float num76 = 9f;
					float num77 = 0.4f;
					if (this.type == 19)
					{
						num76 = 13f;
						num77 = 0.6f;
					}
					else if (this.type == 33)
					{
						num76 = 15f;
						num77 = 0.8f;
					}
					else if (this.type == 182)
					{
						num76 = 16f;
						num77 = 1.2f;
					}
					else if (this.type == 106)
					{
						num76 = 16f;
						num77 = 1.2f;
					}
					else if (this.type == 272)
					{
						num76 = 15f;
						num77 = 1f;
					}
					else if (this.type == 301)
					{
						num76 = 15f;
						num77 = 3f;
					}
					else if (this.type == 320)
					{
						num76 = 15f;
						num77 = 3f;
					}
					Vector2 vector3 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num78 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector3.X;
					float num79 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector3.Y;
					float num80 = (float)Math.Sqrt((double)(num78 * num78 + num79 * num79));
					if (num80 > 3000f)
					{
						this.Kill();
					}
					num80 = num76 / num80;
					num78 *= num80;
					num79 *= num80;
					if (this.velocity.X < num78)
					{
						this.velocity.X = this.velocity.X + num77;
						if (this.velocity.X < 0f && num78 > 0f)
						{
							this.velocity.X = this.velocity.X + num77;
						}
					}
					else if (this.velocity.X > num78)
					{
						this.velocity.X = this.velocity.X - num77;
						if (this.velocity.X > 0f && num78 < 0f)
						{
							this.velocity.X = this.velocity.X - num77;
						}
					}
					if (this.velocity.Y < num79)
					{
						this.velocity.Y = this.velocity.Y + num77;
						if (this.velocity.Y < 0f && num79 > 0f)
						{
							this.velocity.Y = this.velocity.Y + num77;
						}
					}
					else if (this.velocity.Y > num79)
					{
						this.velocity.Y = this.velocity.Y - num77;
						if (this.velocity.Y > 0f && num79 < 0f)
						{
							this.velocity.Y = this.velocity.Y - num77;
						}
					}
					if (Main.myPlayer == this.owner)
					{
						Rectangle rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
						Rectangle value = new Rectangle((int)Main.player[this.owner].position.X, (int)Main.player[this.owner].position.Y, Main.player[this.owner].width, Main.player[this.owner].height);
						if (rectangle.Intersects(value))
						{
							this.Kill();
						}
					}
				}
				if (this.type == 106)
				{
					this.rotation += 0.3f * (float)this.direction;
					return;
				}
				this.rotation += 0.4f * (float)this.direction;
				return;
			}
			else if (this.aiStyle == 4)
			{
				this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
				if (this.ai[0] == 0f)
				{
					if (this.type >= 150 && this.type <= 152 && this.ai[1] == 0f && this.alpha == 255 && Main.rand.Next(2) == 0)
					{
						this.type++;
						this.netUpdate = true;
					}
					this.alpha -= 50;
					if (this.type >= 150 && this.type <= 152)
					{
						this.alpha -= 25;
					}
					if (this.alpha <= 0)
					{
						this.alpha = 0;
						this.ai[0] = 1f;
						if (this.ai[1] == 0f)
						{
							this.ai[1] += 1f;
							this.position += this.velocity * 1f;
						}
						if (this.type == 7 && Main.myPlayer == this.owner)
						{
							int num81 = this.type;
							if (this.ai[1] >= 6f)
							{
								num81++;
							}
							int num82 = Projectile.NewProjectile(this.position.X + this.velocity.X + (float)(this.width / 2), this.position.Y + this.velocity.Y + (float)(this.height / 2), this.velocity.X, this.velocity.Y, num81, this.damage, this.knockBack, this.owner, 0f, 0f);
							Main.projectile[num82].damage = this.damage;
							Main.projectile[num82].ai[1] = this.ai[1] + 1f;
							NetMessage.SendData(27, -1, -1, "", num82, 0f, 0f, 0f, 0);
							return;
						}
						if ((this.type == 150 || this.type == 151) && Main.myPlayer == this.owner)
						{
							int num83 = this.type;
							if (this.type == 150)
							{
								num83 = 151;
							}
							else if (this.type == 151)
							{
								num83 = 150;
							}
							if (this.ai[1] >= 10f && this.type == 151)
							{
								num83 = 152;
							}
							int num84 = Projectile.NewProjectile(this.position.X + this.velocity.X + (float)(this.width / 2), this.position.Y + this.velocity.Y + (float)(this.height / 2), this.velocity.X, this.velocity.Y, num83, this.damage, this.knockBack, this.owner, 0f, 0f);
							Main.projectile[num84].damage = this.damage;
							Main.projectile[num84].ai[1] = this.ai[1] + 1f;
							NetMessage.SendData(27, -1, -1, "", num84, 0f, 0f, 0f, 0);
							return;
						}
					}
				}
				else
				{
					if (this.alpha < 170 && this.alpha + 5 >= 170)
					{
						if (this.type >= 150 && this.type <= 152)
						{
							for (int num85 = 0; num85 < 8; num85++)
							{
								int num86 = Dust.NewDust(this.position, this.width, this.height, 7, this.velocity.X * 0.025f, this.velocity.Y * 0.025f, 200, default(Color), 1.3f);
								Main.dust[num86].noGravity = true;
								Main.dust[num86].velocity *= 0.5f;
							}
						}
						else
						{
							for (int num87 = 0; num87 < 3; num87++)
							{
								Dust.NewDust(this.position, this.width, this.height, 18, this.velocity.X * 0.025f, this.velocity.Y * 0.025f, 170, default(Color), 1.2f);
							}
							Dust.NewDust(this.position, this.width, this.height, 14, 0f, 0f, 170, default(Color), 1.1f);
						}
					}
					if (this.type >= 150 && this.type <= 152)
					{
						this.alpha += 3;
					}
					else
					{
						this.alpha += 5;
					}
					if (this.alpha >= 255)
					{
						this.Kill();
						return;
					}
				}
			}
			else if (this.aiStyle == 5)
			{
				if (this.type == 92)
				{
					if (this.position.Y > this.ai[1])
					{
						this.tileCollide = true;
					}
				}
				else
				{
					if (this.ai[1] == 0f && !Collision.SolidCollision(this.position, this.width, this.height))
					{
						this.ai[1] = 1f;
						this.netUpdate = true;
					}
					if (this.ai[1] != 0f)
					{
						this.tileCollide = true;
					}
				}
				if (this.soundDelay == 0)
				{
					this.soundDelay = 20 + Main.rand.Next(40);
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 9);
				}
				if (this.localAI[0] == 0f)
				{
					this.localAI[0] = 1f;
				}
				this.alpha += (int)(25f * this.localAI[0]);
				if (this.alpha > 200)
				{
					this.alpha = 200;
					this.localAI[0] = -1f;
				}
				if (this.alpha < 0)
				{
					this.alpha = 0;
					this.localAI[0] = 1f;
				}
				this.rotation += (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.01f * (float)this.direction;
				if (this.ai[1] == 1f || this.type == 92)
				{
					this.light = 0.9f;
					if (Main.rand.Next(10) == 0)
					{
						Dust.NewDust(this.position, this.width, this.height, 58, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, default(Color), 1.2f);
					}
					if (Main.rand.Next(20) == 0)
					{
						Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.2f, this.velocity.Y * 0.2f), Main.rand.Next(16, 18), 1f);
						return;
					}
				}
			}
			else if (this.aiStyle == 6)
			{
				this.velocity *= 0.95f;
				this.ai[0] += 1f;
				if (this.ai[0] == 180f)
				{
					this.Kill();
				}
				if (this.ai[1] == 0f)
				{
					this.ai[1] = 1f;
					for (int num88 = 0; num88 < 30; num88++)
					{
						Dust.NewDust(this.position, this.width, this.height, 10 + this.type, this.velocity.X, this.velocity.Y, 50, default(Color), 1f);
					}
				}
				if (this.type == 10 || this.type == 11)
				{
					int num89 = (int)(this.position.X / 16f) - 1;
					int num90 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num91 = (int)(this.position.Y / 16f) - 1;
					int num92 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num89 < 0)
					{
						num89 = 0;
					}
					if (num90 > Main.maxTilesX)
					{
						num90 = Main.maxTilesX;
					}
					if (num91 < 0)
					{
						num91 = 0;
					}
					if (num92 > Main.maxTilesY)
					{
						num92 = Main.maxTilesY;
					}
					for (int num93 = num89; num93 < num90; num93++)
					{
						for (int num94 = num91; num94 < num92; num94++)
						{
							Vector2 vector4;
							vector4.X = (float)(num93 * 16);
							vector4.Y = (float)(num94 * 16);
							if (this.position.X + (float)this.width > vector4.X && this.position.X < vector4.X + 16f && this.position.Y + (float)this.height > vector4.Y && this.position.Y < vector4.Y + 16f && Main.myPlayer == this.owner && Main.tile[num93, num94].active())
							{
								if (this.type == 10)
								{
									if (Main.tile[num93, num94].type == 23 || Main.tile[num93, num94].type == 199)
									{
										Main.tile[num93, num94].type = 2;
										WorldGen.SquareTileFrame(num93, num94, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num93, num94, 1);
										}
									}
									if (Main.tile[num93, num94].type == 25 || Main.tile[num93, num94].type == 203)
									{
										Main.tile[num93, num94].type = 1;
										WorldGen.SquareTileFrame(num93, num94, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num93, num94, 1);
										}
									}
									if (Main.tile[num93, num94].type == 112 || Main.tile[num93, num94].type == 234)
									{
										Main.tile[num93, num94].type = 53;
										WorldGen.SquareTileFrame(num93, num94, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num93, num94, 1);
										}
									}
									if (Main.tile[num93, num94].type == 163 || Main.tile[num93, num94].type == 200)
									{
										Main.tile[num93, num94].type = 161;
										WorldGen.SquareTileFrame(num93, num94, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num93, num94, 1);
										}
									}
								}
								else if (this.type == 11)
								{
									if (Main.tile[num93, num94].type == 109)
									{
										Main.tile[num93, num94].type = 2;
										WorldGen.SquareTileFrame(num93, num94, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num93, num94, 1);
										}
									}
									if (Main.tile[num93, num94].type == 116)
									{
										Main.tile[num93, num94].type = 53;
										WorldGen.SquareTileFrame(num93, num94, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num93, num94, 1);
										}
									}
									if (Main.tile[num93, num94].type == 117)
									{
										Main.tile[num93, num94].type = 1;
										WorldGen.SquareTileFrame(num93, num94, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num93, num94, 1);
										}
									}
									if (Main.tile[num93, num94].type == 164)
									{
										Main.tile[num93, num94].type = 161;
										WorldGen.SquareTileFrame(num93, num94, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num93, num94, 1);
										}
									}
								}
							}
						}
					}
					return;
				}
			}
			else if (this.aiStyle == 7)
			{
				if (Main.player[this.owner].dead)
				{
					this.Kill();
					return;
				}
				Vector2 vector5 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float num95 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector5.X;
				float num96 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector5.Y;
				float num97 = (float)Math.Sqrt((double)(num95 * num95 + num96 * num96));
				this.rotation = (float)Math.Atan2((double)num96, (double)num95) - 1.57f;
				if (this.type == 256)
				{
					this.rotation = (float)Math.Atan2((double)num96, (double)num95) + 3.92500019f;
				}
				if (this.ai[0] == 0f)
				{
					if ((num97 > 300f && this.type == 13) || (num97 > 400f && this.type == 32) || (num97 > 440f && this.type == 73) || (num97 > 440f && this.type == 74) || (num97 > 250f && this.type == 165) || (num97 > 350f && this.type == 256) || (num97 > 500f && this.type == 315) || (num97 > 550f && this.type == 322))
					{
						this.ai[0] = 1f;
					}
					else if (this.type >= 230 && this.type <= 235)
					{
						int num98 = 300 + (this.type - 230) * 30;
						if (num97 > (float)num98)
						{
							this.ai[0] = 1f;
						}
					}
					int num99 = (int)(this.position.X / 16f) - 1;
					int num100 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num101 = (int)(this.position.Y / 16f) - 1;
					int num102 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num99 < 0)
					{
						num99 = 0;
					}
					if (num100 > Main.maxTilesX)
					{
						num100 = Main.maxTilesX;
					}
					if (num101 < 0)
					{
						num101 = 0;
					}
					if (num102 > Main.maxTilesY)
					{
						num102 = Main.maxTilesY;
					}
					for (int num103 = num99; num103 < num100; num103++)
					{
						int num104 = num101;
						while (num104 < num102)
						{
							if (Main.tile[num103, num104] == null)
							{
								Main.tile[num103, num104] = new Tile();
							}
							Vector2 vector6;
							vector6.X = (float)(num103 * 16);
							vector6.Y = (float)(num104 * 16);
							if (this.position.X + (float)this.width > vector6.X && this.position.X < vector6.X + 16f && this.position.Y + (float)this.height > vector6.Y && this.position.Y < vector6.Y + 16f && Main.tile[num103, num104].nactive() && Main.tileSolid[(int)Main.tile[num103, num104].type])
							{
								if (Main.player[this.owner].grapCount < 10)
								{
									Main.player[this.owner].grappling[Main.player[this.owner].grapCount] = this.whoAmI;
									Main.player[this.owner].grapCount++;
								}
								if (Main.myPlayer == this.owner)
								{
									int num105 = 0;
									int num106 = -1;
									int num107 = 100000;
									if (this.type == 73 || this.type == 74)
									{
										for (int num108 = 0; num108 < 1000; num108++)
										{
											if (num108 != this.whoAmI && Main.projectile[num108].active && Main.projectile[num108].owner == this.owner && Main.projectile[num108].aiStyle == 7 && Main.projectile[num108].ai[0] == 2f)
											{
												Main.projectile[num108].Kill();
											}
										}
									}
									else
									{
										int num109 = 3;
										if (this.type == 165)
										{
											num109 = 8;
										}
										if (this.type == 256)
										{
											num109 = 2;
										}
										for (int num110 = 0; num110 < 1000; num110++)
										{
											if (Main.projectile[num110].active && Main.projectile[num110].owner == this.owner && Main.projectile[num110].aiStyle == 7)
											{
												if (Main.projectile[num110].timeLeft < num107)
												{
													num106 = num110;
													num107 = Main.projectile[num110].timeLeft;
												}
												num105++;
											}
										}
										if (num105 > num109)
										{
											Main.projectile[num106].Kill();
										}
									}
								}
								WorldGen.KillTile(num103, num104, true, true, false);
								Main.PlaySound(0, num103 * 16, num104 * 16, 1);
								this.velocity.X = 0f;
								this.velocity.Y = 0f;
								this.ai[0] = 2f;
								this.position.X = (float)(num103 * 16 + 8 - this.width / 2);
								this.position.Y = (float)(num104 * 16 + 8 - this.height / 2);
								this.damage = 0;
								this.netUpdate = true;
								if (Main.myPlayer == this.owner)
								{
									NetMessage.SendData(13, -1, -1, "", this.owner, 0f, 0f, 0f, 0);
									break;
								}
								break;
							}
							else
							{
								num104++;
							}
						}
						if (this.ai[0] == 2f)
						{
							return;
						}
					}
					return;
				}
				if (this.ai[0] == 1f)
				{
					float num111 = 11f;
					if (this.type == 32)
					{
						num111 = 15f;
					}
					if (this.type == 73 || this.type == 74)
					{
						num111 = 17f;
					}
					if (this.type == 315)
					{
						num111 = 20f;
					}
					if (this.type == 322)
					{
						num111 = 22f;
					}
					if (this.type >= 230 && this.type <= 235)
					{
						num111 = 11f + (float)(this.type - 230) * 0.75f;
					}
					if (num97 < 24f)
					{
						this.Kill();
					}
					num97 = num111 / num97;
					num95 *= num97;
					num96 *= num97;
					this.velocity.X = num95;
					this.velocity.Y = num96;
					return;
				}
				if (this.ai[0] == 2f)
				{
					int num112 = (int)(this.position.X / 16f) - 1;
					int num113 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num114 = (int)(this.position.Y / 16f) - 1;
					int num115 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num112 < 0)
					{
						num112 = 0;
					}
					if (num113 > Main.maxTilesX)
					{
						num113 = Main.maxTilesX;
					}
					if (num114 < 0)
					{
						num114 = 0;
					}
					if (num115 > Main.maxTilesY)
					{
						num115 = Main.maxTilesY;
					}
					bool flag3 = true;
					for (int num116 = num112; num116 < num113; num116++)
					{
						for (int num117 = num114; num117 < num115; num117++)
						{
							if (Main.tile[num116, num117] == null)
							{
								Main.tile[num116, num117] = new Tile();
							}
							Vector2 vector7;
							vector7.X = (float)(num116 * 16);
							vector7.Y = (float)(num117 * 16);
							if (this.position.X + (float)(this.width / 2) > vector7.X && this.position.X + (float)(this.width / 2) < vector7.X + 16f && this.position.Y + (float)(this.height / 2) > vector7.Y && this.position.Y + (float)(this.height / 2) < vector7.Y + 16f && Main.tile[num116, num117].nactive() && Main.tileSolid[(int)Main.tile[num116, num117].type])
							{
								flag3 = false;
							}
						}
					}
					if (flag3)
					{
						this.ai[0] = 1f;
						return;
					}
					if (Main.player[this.owner].grapCount < 10)
					{
						Main.player[this.owner].grappling[Main.player[this.owner].grapCount] = this.whoAmI;
						Main.player[this.owner].grapCount++;
						return;
					}
				}
			}
			else if (this.aiStyle == 8)
			{
				if (this.type == 258 && this.localAI[0] == 0f)
				{
					this.localAI[0] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 20);
				}
				if (this.type == 96 && this.localAI[0] == 0f)
				{
					this.localAI[0] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 20);
				}
				if (this.type == 27)
				{
					for (int num118 = 0; num118 < 5; num118++)
					{
						float num119 = this.velocity.X / 3f * (float)num118;
						float num120 = this.velocity.Y / 3f * (float)num118;
						int num121 = 4;
						int num122 = Dust.NewDust(new Vector2(this.position.X + (float)num121, this.position.Y + (float)num121), this.width - num121 * 2, this.height - num121 * 2, 172, 0f, 0f, 100, default(Color), 1.2f);
						Main.dust[num122].noGravity = true;
						Main.dust[num122].velocity *= 0.1f;
						Main.dust[num122].velocity += this.velocity * 0.1f;
						Dust expr_58B8_cp_0 = Main.dust[num122];
						expr_58B8_cp_0.position.X = expr_58B8_cp_0.position.X - num119;
						Dust expr_58D3_cp_0 = Main.dust[num122];
						expr_58D3_cp_0.position.Y = expr_58D3_cp_0.position.Y - num120;
					}
					if (Main.rand.Next(5) == 0)
					{
						int num123 = 4;
						int num124 = Dust.NewDust(new Vector2(this.position.X + (float)num123, this.position.Y + (float)num123), this.width - num123 * 2, this.height - num123 * 2, 172, 0f, 0f, 100, default(Color), 0.6f);
						Main.dust[num124].velocity *= 0.25f;
						Main.dust[num124].velocity += this.velocity * 0.5f;
					}
				}
				else if (this.type == 95 || this.type == 96)
				{
					int num125 = Dust.NewDust(new Vector2(this.position.X + this.velocity.X, this.position.Y + this.velocity.Y), this.width, this.height, 75, this.velocity.X, this.velocity.Y, 100, default(Color), 3f * this.scale);
					Main.dust[num125].noGravity = true;
				}
				else if (this.type == 253)
				{
					for (int num126 = 0; num126 < 2; num126++)
					{
						int num127 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 135, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num127].noGravity = true;
						Dust expr_5AF1_cp_0 = Main.dust[num127];
						expr_5AF1_cp_0.velocity.X = expr_5AF1_cp_0.velocity.X * 0.3f;
						Dust expr_5B0F_cp_0 = Main.dust[num127];
						expr_5B0F_cp_0.velocity.Y = expr_5B0F_cp_0.velocity.Y * 0.3f;
					}
				}
				else
				{
					for (int num128 = 0; num128 < 2; num128++)
					{
						int num129 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num129].noGravity = true;
						Dust expr_5BBC_cp_0 = Main.dust[num129];
						expr_5BBC_cp_0.velocity.X = expr_5BBC_cp_0.velocity.X * 0.3f;
						Dust expr_5BDA_cp_0 = Main.dust[num129];
						expr_5BDA_cp_0.velocity.Y = expr_5BDA_cp_0.velocity.Y * 0.3f;
					}
				}
				if (this.type != 27 && this.type != 96 && this.type != 258)
				{
					this.ai[1] += 1f;
				}
				if (this.ai[1] >= 20f)
				{
					this.velocity.Y = this.velocity.Y + 0.2f;
				}
				this.rotation += 0.3f * (float)this.direction;
				if (this.velocity.Y > 16f)
				{
					this.velocity.Y = 16f;
					return;
				}
			}
			else if (this.aiStyle == 9)
			{
				if (this.type == 34)
				{
					int num130 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 3.5f);
					Main.dust[num130].noGravity = true;
					Main.dust[num130].velocity *= 1.4f;
					num130 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 1.5f);
				}
				else if (this.type == 79)
				{
					if (this.soundDelay == 0 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 2f)
					{
						this.soundDelay = 10;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 9);
					}
					for (int num131 = 0; num131 < 1; num131++)
					{
						int num132 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 66, 0f, 0f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 2.5f);
						Main.dust[num132].velocity *= 0.1f;
						Main.dust[num132].velocity += this.velocity * 0.2f;
						Main.dust[num132].position.X = this.position.X + (float)(this.width / 2) + 4f + (float)Main.rand.Next(-2, 3);
						Main.dust[num132].position.Y = this.position.Y + (float)(this.height / 2) + (float)Main.rand.Next(-2, 3);
						Main.dust[num132].noGravity = true;
					}
				}
				else
				{
					if (this.soundDelay == 0 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 2f)
					{
						this.soundDelay = 10;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 9);
					}
					int num133 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 15, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num133].velocity *= 0.3f;
					Main.dust[num133].position.X = this.position.X + (float)(this.width / 2) + 4f + (float)Main.rand.Next(-4, 5);
					Main.dust[num133].position.Y = this.position.Y + (float)(this.height / 2) + (float)Main.rand.Next(-4, 5);
					Main.dust[num133].noGravity = true;
				}
				if (Main.myPlayer == this.owner && this.ai[0] == 0f)
				{
					if (Main.player[this.owner].channel)
					{
						float num134 = 12f;
						if (this.type == 16)
						{
							num134 = 15f;
						}
						Vector2 vector8 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num135 = (float)Main.mouseX + Main.screenPosition.X - vector8.X;
						float num136 = (float)Main.mouseY + Main.screenPosition.Y - vector8.Y;
						if (Main.player[this.owner].gravDir == -1f)
						{
							num136 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector8.Y;
						}
						float num137 = (float)Math.Sqrt((double)(num135 * num135 + num136 * num136));
						num137 = (float)Math.Sqrt((double)(num135 * num135 + num136 * num136));
						if (num137 > num134)
						{
							num137 = num134 / num137;
							num135 *= num137;
							num136 *= num137;
							int num138 = (int)(num135 * 1000f);
							int num139 = (int)(this.velocity.X * 1000f);
							int num140 = (int)(num136 * 1000f);
							int num141 = (int)(this.velocity.Y * 1000f);
							if (num138 != num139 || num140 != num141)
							{
								this.netUpdate = true;
							}
							this.velocity.X = num135;
							this.velocity.Y = num136;
						}
						else
						{
							int num142 = (int)(num135 * 1000f);
							int num143 = (int)(this.velocity.X * 1000f);
							int num144 = (int)(num136 * 1000f);
							int num145 = (int)(this.velocity.Y * 1000f);
							if (num142 != num143 || num144 != num145)
							{
								this.netUpdate = true;
							}
							this.velocity.X = num135;
							this.velocity.Y = num136;
						}
					}
					else if (this.ai[0] == 0f)
					{
						this.ai[0] = 1f;
						this.netUpdate = true;
						float num146 = 12f;
						Vector2 vector9 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num147 = (float)Main.mouseX + Main.screenPosition.X - vector9.X;
						float num148 = (float)Main.mouseY + Main.screenPosition.Y - vector9.Y;
						float num149 = (float)Math.Sqrt((double)(num147 * num147 + num148 * num148));
						if (num149 == 0f)
						{
							vector9 = new Vector2(Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2), Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2));
							num147 = this.position.X + (float)this.width * 0.5f - vector9.X;
							num148 = this.position.Y + (float)this.height * 0.5f - vector9.Y;
							num149 = (float)Math.Sqrt((double)(num147 * num147 + num148 * num148));
						}
						num149 = num146 / num149;
						num147 *= num149;
						num148 *= num149;
						this.velocity.X = num147;
						this.velocity.Y = num148;
						if (this.velocity.X == 0f && this.velocity.Y == 0f)
						{
							this.Kill();
						}
					}
				}
				if (this.type == 34)
				{
					this.rotation += 0.3f * (float)this.direction;
				}
				else if (this.velocity.X != 0f || this.velocity.Y != 0f)
				{
					this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) - 2.355f;
				}
				if (this.velocity.Y > 16f)
				{
					this.velocity.Y = 16f;
					return;
				}
			}
			else if (this.aiStyle == 10)
			{
				if (this.type == 31 && this.ai[0] != 2f)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num150 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 32, 0f, this.velocity.Y / 2f, 0, default(Color), 1f);
						Dust expr_65B9_cp_0 = Main.dust[num150];
						expr_65B9_cp_0.velocity.X = expr_65B9_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 39)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num151 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 38, 0f, this.velocity.Y / 2f, 0, default(Color), 1f);
						Dust expr_6653_cp_0 = Main.dust[num151];
						expr_6653_cp_0.velocity.X = expr_6653_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 40)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num152 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 36, 0f, this.velocity.Y / 2f, 0, default(Color), 1f);
						Main.dust[num152].velocity *= 0.4f;
					}
				}
				else if (this.type == 42 || this.type == 31)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num153 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 32, 0f, 0f, 0, default(Color), 1f);
						Dust expr_6784_cp_0 = Main.dust[num153];
						expr_6784_cp_0.velocity.X = expr_6784_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 56 || this.type == 65)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num154 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 0, default(Color), 1f);
						Dust expr_681C_cp_0 = Main.dust[num154];
						expr_681C_cp_0.velocity.X = expr_681C_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 67 || this.type == 68)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num155 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 51, 0f, 0f, 0, default(Color), 1f);
						Dust expr_68B4_cp_0 = Main.dust[num155];
						expr_68B4_cp_0.velocity.X = expr_68B4_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 71)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num156 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 53, 0f, 0f, 0, default(Color), 1f);
						Dust expr_6942_cp_0 = Main.dust[num156];
						expr_6942_cp_0.velocity.X = expr_6942_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 179)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num157 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 149, 0f, 0f, 0, default(Color), 1f);
						Dust expr_69D6_cp_0 = Main.dust[num157];
						expr_69D6_cp_0.velocity.X = expr_69D6_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 241)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num158 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 36, 0f, 0f, 0, default(Color), 1f);
						Dust expr_6A64_cp_0 = Main.dust[num158];
						expr_6A64_cp_0.velocity.X = expr_6A64_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type != 109 && Main.rand.Next(20) == 0)
				{
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0, 0f, 0f, 0, default(Color), 1f);
				}
				if (Main.myPlayer == this.owner && this.ai[0] == 0f)
				{
					if (Main.player[this.owner].channel)
					{
						float num159 = 12f;
						Vector2 vector10 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num160 = (float)Main.mouseX + Main.screenPosition.X - vector10.X;
						float num161 = (float)Main.mouseY + Main.screenPosition.Y - vector10.Y;
						float num162 = (float)Math.Sqrt((double)(num160 * num160 + num161 * num161));
						num162 = (float)Math.Sqrt((double)(num160 * num160 + num161 * num161));
						if (num162 > num159)
						{
							num162 = num159 / num162;
							num160 *= num162;
							num161 *= num162;
							if (num160 != this.velocity.X || num161 != this.velocity.Y)
							{
								this.netUpdate = true;
							}
							this.velocity.X = num160;
							this.velocity.Y = num161;
						}
						else
						{
							if (num160 != this.velocity.X || num161 != this.velocity.Y)
							{
								this.netUpdate = true;
							}
							this.velocity.X = num160;
							this.velocity.Y = num161;
						}
					}
					else
					{
						this.ai[0] = 1f;
						this.netUpdate = true;
					}
				}
				if (this.ai[0] == 1f && this.type != 109)
				{
					if (this.type == 42 || this.type == 65 || this.type == 68)
					{
						this.ai[1] += 1f;
						if (this.ai[1] >= 60f)
						{
							this.ai[1] = 60f;
							this.velocity.Y = this.velocity.Y + 0.2f;
						}
					}
					else
					{
						this.velocity.Y = this.velocity.Y + 0.41f;
					}
				}
				else if (this.ai[0] == 2f && this.type != 109)
				{
					this.velocity.Y = this.velocity.Y + 0.2f;
					if ((double)this.velocity.X < -0.04)
					{
						this.velocity.X = this.velocity.X + 0.04f;
					}
					else if ((double)this.velocity.X > 0.04)
					{
						this.velocity.X = this.velocity.X - 0.04f;
					}
					else
					{
						this.velocity.X = 0f;
					}
				}
				this.rotation += 0.1f;
				if (this.velocity.Y > 10f)
				{
					this.velocity.Y = 10f;
					return;
				}
			}
			else if (this.aiStyle == 11)
			{
				if (this.type == 72 || this.type == 86 || this.type == 87)
				{
					if (this.velocity.X > 0f)
					{
						this.spriteDirection = -1;
					}
					else if (this.velocity.X < 0f)
					{
						this.spriteDirection = 1;
					}
					this.rotation = this.velocity.X * 0.1f;
					this.frameCounter++;
					if (this.frameCounter >= 4)
					{
						this.frame++;
						this.frameCounter = 0;
					}
					if (this.frame >= 4)
					{
						this.frame = 0;
					}
					if (Main.rand.Next(6) == 0)
					{
						int num163 = 56;
						if (this.type == 86)
						{
							num163 = 73;
						}
						else if (this.type == 87)
						{
							num163 = 74;
						}
						int num164 = Dust.NewDust(this.position, this.width, this.height, num163, 0f, 0f, 200, default(Color), 0.8f);
						Main.dust[num164].velocity *= 0.3f;
					}
				}
				else
				{
					this.rotation += 0.02f;
				}
				if (Main.myPlayer == this.owner)
				{
					if (this.type == 72 || this.type == 86 || this.type == 87)
					{
						if (Main.player[Main.myPlayer].fairy)
						{
							this.timeLeft = 2;
						}
					}
					else if (Main.player[Main.myPlayer].lightOrb)
					{
						this.timeLeft = 2;
					}
				}
				if (Main.player[this.owner].dead)
				{
					this.Kill();
					return;
				}
				float num165 = 3f;
				if (this.type == 72 || this.type == 86 || this.type == 87)
				{
					num165 = 3.75f;
				}
				Vector2 vector11 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float num166 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector11.X;
				float num167 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector11.Y;
				int num168 = 70;
				if (this.type == 18)
				{
					if (Main.player[this.owner].controlUp)
					{
						num167 = Main.player[this.owner].position.Y - 40f - vector11.Y;
						num166 -= 6f;
						num168 = 4;
					}
					else if (Main.player[this.owner].controlDown)
					{
						num167 = Main.player[this.owner].position.Y + (float)Main.player[this.owner].height + 40f - vector11.Y;
						num166 -= 6f;
						num168 = 4;
					}
				}
				float num169 = (float)Math.Sqrt((double)(num166 * num166 + num167 * num167));
				num169 = (float)Math.Sqrt((double)(num166 * num166 + num167 * num167));
				if (this.type == 72 || this.type == 86 || this.type == 87)
				{
					num168 = 40;
				}
				if (num169 > 800f)
				{
					this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
					this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
					return;
				}
				if (num169 > (float)num168)
				{
					num169 = num165 / num169;
					num166 *= num169;
					num167 *= num169;
					this.velocity.X = num166;
					this.velocity.Y = num167;
					return;
				}
				this.velocity.X = 0f;
				this.velocity.Y = 0f;
				return;
			}
			else if (this.aiStyle == 12)
			{
				if (this.type == 288 && this.localAI[0] == 0f)
				{
					this.localAI[0] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 17);
				}
				if (this.type == 280 || this.type == 288)
				{
					this.scale -= 0.002f;
					if (this.scale <= 0f)
					{
						this.Kill();
					}
					if (this.type == 288)
					{
						this.ai[0] = 4f;
					}
					if (this.ai[0] <= 3f)
					{
						this.ai[0] += 1f;
						return;
					}
					this.velocity.Y = this.velocity.Y + 0.075f;
					for (int num170 = 0; num170 < 3; num170++)
					{
						float num171 = this.velocity.X / 3f * (float)num170;
						float num172 = this.velocity.Y / 3f * (float)num170;
						int num173 = 14;
						int num174 = Dust.NewDust(new Vector2(this.position.X + (float)num173, this.position.Y + (float)num173), this.width - num173 * 2, this.height - num173 * 2, 170, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num174].noGravity = true;
						Main.dust[num174].velocity *= 0.1f;
						Main.dust[num174].velocity += this.velocity * 0.5f;
						Dust expr_744B_cp_0 = Main.dust[num174];
						expr_744B_cp_0.position.X = expr_744B_cp_0.position.X - num171;
						Dust expr_7466_cp_0 = Main.dust[num174];
						expr_7466_cp_0.position.Y = expr_7466_cp_0.position.Y - num172;
					}
					if (Main.rand.Next(8) == 0)
					{
						int num175 = 16;
						int num176 = Dust.NewDust(new Vector2(this.position.X + (float)num175, this.position.Y + (float)num175), this.width - num175 * 2, this.height - num175 * 2, 170, 0f, 0f, 100, default(Color), 0.5f);
						Main.dust[num176].velocity *= 0.25f;
						Main.dust[num176].velocity += this.velocity * 0.5f;
						return;
					}
				}
				else
				{
					this.scale -= 0.02f;
					if (this.scale <= 0f)
					{
						this.Kill();
					}
					if (this.ai[0] > 3f)
					{
						this.velocity.Y = this.velocity.Y + 0.2f;
						for (int num177 = 0; num177 < 1; num177++)
						{
							for (int num178 = 0; num178 < 3; num178++)
							{
								float num179 = this.velocity.X / 3f * (float)num178;
								float num180 = this.velocity.Y / 3f * (float)num178;
								int num181 = 6;
								int num182 = Dust.NewDust(new Vector2(this.position.X + (float)num181, this.position.Y + (float)num181), this.width - num181 * 2, this.height - num181 * 2, 172, 0f, 0f, 100, default(Color), 1.2f);
								Main.dust[num182].noGravity = true;
								Main.dust[num182].velocity *= 0.3f;
								Main.dust[num182].velocity += this.velocity * 0.5f;
								Dust expr_76B1_cp_0 = Main.dust[num182];
								expr_76B1_cp_0.position.X = expr_76B1_cp_0.position.X - num179;
								Dust expr_76CC_cp_0 = Main.dust[num182];
								expr_76CC_cp_0.position.Y = expr_76CC_cp_0.position.Y - num180;
							}
							if (Main.rand.Next(8) == 0)
							{
								int num183 = 6;
								int num184 = Dust.NewDust(new Vector2(this.position.X + (float)num183, this.position.Y + (float)num183), this.width - num183 * 2, this.height - num183 * 2, 172, 0f, 0f, 100, default(Color), 0.75f);
								Main.dust[num184].velocity *= 0.5f;
								Main.dust[num184].velocity += this.velocity * 0.5f;
							}
						}
						return;
					}
					this.ai[0] += 1f;
					return;
				}
			}
			else if (this.aiStyle == 13)
			{
				if (Main.player[this.owner].dead)
				{
					this.Kill();
					return;
				}
				Main.player[this.owner].itemAnimation = 5;
				Main.player[this.owner].itemTime = 5;
				if (this.alpha == 0)
				{
					if (this.position.X + (float)(this.width / 2) > Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2))
					{
						Main.player[this.owner].ChangeDir(1);
					}
					else
					{
						Main.player[this.owner].ChangeDir(-1);
					}
				}
				Vector2 vector12 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float num185 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector12.X;
				float num186 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector12.Y;
				float num187 = (float)Math.Sqrt((double)(num185 * num185 + num186 * num186));
				if (this.ai[0] == 0f)
				{
					if (num187 > 700f)
					{
						this.ai[0] = 1f;
					}
					else if (this.type == 262 && num187 > 500f)
					{
						this.ai[0] = 1f;
					}
					else if (this.type == 271 && num187 > 200f)
					{
						this.ai[0] = 1f;
					}
					else if (this.type == 273 && num187 > 150f)
					{
						this.ai[0] = 1f;
					}
					this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
					this.ai[1] += 1f;
					if (this.ai[1] > 5f)
					{
						this.alpha = 0;
					}
					if (this.type == 262 && this.ai[1] > 8f)
					{
						this.ai[1] = 8f;
					}
					if (this.type == 271 && this.ai[1] > 8f)
					{
						this.ai[1] = 8f;
					}
					if (this.type == 273 && this.ai[1] > 8f)
					{
						this.ai[1] = 8f;
					}
					if (this.ai[1] >= 10f)
					{
						this.ai[1] = 15f;
						this.velocity.Y = this.velocity.Y + 0.3f;
					}
					if (this.type == 262 && this.velocity.X < 0f)
					{
						this.spriteDirection = -1;
					}
					else if (this.type == 262)
					{
						this.spriteDirection = 1;
					}
					if (this.type == 271 && this.velocity.X < 0f)
					{
						this.spriteDirection = -1;
						return;
					}
					if (this.type == 271)
					{
						this.spriteDirection = 1;
						return;
					}
				}
				else if (this.ai[0] == 1f)
				{
					this.tileCollide = false;
					this.rotation = (float)Math.Atan2((double)num186, (double)num185) - 1.57f;
					float num188 = 20f;
					if (this.type == 262)
					{
						num188 = 30f;
					}
					if (num187 < 50f)
					{
						this.Kill();
					}
					num187 = num188 / num187;
					num185 *= num187;
					num186 *= num187;
					this.velocity.X = num185;
					this.velocity.Y = num186;
					if (this.type == 262 && this.velocity.X < 0f)
					{
						this.spriteDirection = 1;
					}
					else if (this.type == 262)
					{
						this.spriteDirection = -1;
					}
					if (this.type == 271 && this.velocity.X < 0f)
					{
						this.spriteDirection = 1;
						return;
					}
					if (this.type == 271)
					{
						this.spriteDirection = -1;
						return;
					}
				}
			}
			else if (this.aiStyle == 14)
			{
				if (this.type == 196)
				{
					int num189 = Main.rand.Next(1, 3);
					for (int num190 = 0; num190 < num189; num190++)
					{
						int num191 = Dust.NewDust(this.position, this.width, this.height, 31, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num191].alpha += Main.rand.Next(100);
						Main.dust[num191].velocity *= 0.3f;
						Dust expr_7D1C_cp_0 = Main.dust[num191];
						expr_7D1C_cp_0.velocity.X = expr_7D1C_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.025f;
						Dust expr_7D4A_cp_0 = Main.dust[num191];
						expr_7D4A_cp_0.velocity.Y = expr_7D4A_cp_0.velocity.Y - (0.4f + (float)Main.rand.Next(-3, 14) * 0.15f);
						Main.dust[num191].fadeIn = 1.25f + (float)Main.rand.Next(20) * 0.15f;
					}
				}
				if (this.type == 53)
				{
					try
					{
						Vector2 value2 = Collision.TileCollision(this.position, this.velocity, this.width, this.height, false, false);
						this.velocity != value2;
						int num192 = (int)(this.position.X / 16f) - 1;
						int num193 = (int)((this.position.X + (float)this.width) / 16f) + 2;
						int num194 = (int)(this.position.Y / 16f) - 1;
						int num195 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
						if (num192 < 0)
						{
							num192 = 0;
						}
						if (num193 > Main.maxTilesX)
						{
							num193 = Main.maxTilesX;
						}
						if (num194 < 0)
						{
							num194 = 0;
						}
						if (num195 > Main.maxTilesY)
						{
							num195 = Main.maxTilesY;
						}
						for (int num196 = num192; num196 < num193; num196++)
						{
							for (int num197 = num194; num197 < num195; num197++)
							{
								if (Main.tile[num196, num197] != null && Main.tile[num196, num197].nactive() && (Main.tileSolid[(int)Main.tile[num196, num197].type] || (Main.tileSolidTop[(int)Main.tile[num196, num197].type] && Main.tile[num196, num197].frameY == 0)))
								{
									Vector2 vector13;
									vector13.X = (float)(num196 * 16);
									vector13.Y = (float)(num197 * 16);
									if (this.position.X + (float)this.width > vector13.X && this.position.X < vector13.X + 16f && this.position.Y + (float)this.height > vector13.Y && this.position.Y < vector13.Y + 16f)
									{
										this.velocity.X = 0f;
										this.velocity.Y = -0.2f;
									}
								}
							}
						}
					}
					catch
					{
					}
				}
				if (this.type == 277 && this.alpha > 0)
				{
					this.alpha -= 30;
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
				}
				if (this.type == 261 || this.type == 277)
				{
					this.ai[0] += 1f;
					if (this.ai[0] > 15f)
					{
						this.ai[0] = 15f;
						if (this.velocity.Y == 0f && this.velocity.X != 0f)
						{
							this.velocity.X = this.velocity.X * 0.97f;
							if ((double)this.velocity.X > -0.01 && (double)this.velocity.X < 0.01)
							{
								this.Kill();
							}
						}
						this.velocity.Y = this.velocity.Y + 0.2f;
					}
					this.rotation += this.velocity.X * 0.05f;
				}
				else
				{
					this.ai[0] += 1f;
					if (this.ai[0] > 5f)
					{
						this.ai[0] = 5f;
						if (this.velocity.Y == 0f && this.velocity.X != 0f)
						{
							this.velocity.X = this.velocity.X * 0.97f;
							if ((double)this.velocity.X > -0.01 && (double)this.velocity.X < 0.01)
							{
								this.velocity.X = 0f;
								this.netUpdate = true;
							}
						}
						this.velocity.Y = this.velocity.Y + 0.2f;
					}
					this.rotation += this.velocity.X * 0.1f;
				}
				if (this.type >= 326 && this.type <= 328)
				{
					if (this.wet)
					{
						this.Kill();
					}
					if (this.ai[1] == 0f)
					{
						this.ai[1] = 1f;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 13);
					}
					int num198 = Dust.NewDust(this.position, this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
					Dust expr_82A9_cp_0 = Main.dust[num198];
					expr_82A9_cp_0.position.X = expr_82A9_cp_0.position.X - 2f;
					Dust expr_82C7_cp_0 = Main.dust[num198];
					expr_82C7_cp_0.position.Y = expr_82C7_cp_0.position.Y + 2f;
					Main.dust[num198].scale += (float)Main.rand.Next(50) * 0.01f;
					Main.dust[num198].noGravity = true;
					Dust expr_831A_cp_0 = Main.dust[num198];
					expr_831A_cp_0.velocity.Y = expr_831A_cp_0.velocity.Y - 2f;
					if (Main.rand.Next(2) == 0)
					{
						int num199 = Dust.NewDust(this.position, this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
						Dust expr_8381_cp_0 = Main.dust[num199];
						expr_8381_cp_0.position.X = expr_8381_cp_0.position.X - 2f;
						Dust expr_839F_cp_0 = Main.dust[num199];
						expr_839F_cp_0.position.Y = expr_839F_cp_0.position.Y + 2f;
						Main.dust[num199].scale += 0.3f + (float)Main.rand.Next(50) * 0.01f;
						Main.dust[num199].noGravity = true;
						Main.dust[num199].velocity *= 0.1f;
					}
					if ((double)this.velocity.Y < 0.25 && (double)this.velocity.Y > 0.15)
					{
						this.velocity.X = this.velocity.X * 0.8f;
					}
					this.rotation = -this.velocity.X * 0.05f;
				}
				if (this.velocity.Y > 16f)
				{
					this.velocity.Y = 16f;
					return;
				}
			}
			else if (this.aiStyle == 15)
			{
				if (this.type == 25)
				{
					if (Main.rand.Next(15) == 0)
					{
						Dust.NewDust(this.position, this.width, this.height, 14, 0f, 0f, 150, default(Color), 1.3f);
					}
				}
				else if (this.type == 26)
				{
					int num200 = Dust.NewDust(this.position, this.width, this.height, 172, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 100, default(Color), 1.5f);
					Main.dust[num200].noGravity = true;
					Dust expr_8571_cp_0 = Main.dust[num200];
					expr_8571_cp_0.velocity.X = expr_8571_cp_0.velocity.X / 2f;
					Dust expr_858F_cp_0 = Main.dust[num200];
					expr_858F_cp_0.velocity.Y = expr_858F_cp_0.velocity.Y / 2f;
				}
				else if (this.type == 35)
				{
					int num201 = Dust.NewDust(this.position, this.width, this.height, 6, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 100, default(Color), 3f);
					Main.dust[num201].noGravity = true;
					Dust expr_861E_cp_0 = Main.dust[num201];
					expr_861E_cp_0.velocity.X = expr_861E_cp_0.velocity.X * 2f;
					Dust expr_863C_cp_0 = Main.dust[num201];
					expr_863C_cp_0.velocity.Y = expr_863C_cp_0.velocity.Y * 2f;
				}
				else if (this.type == 154)
				{
					int num202 = Dust.NewDust(this.position, this.width, this.height, 115, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 140, default(Color), 1.5f);
					Main.dust[num202].noGravity = true;
					Main.dust[num202].velocity *= 0.25f;
				}
				if (Main.player[this.owner].dead)
				{
					this.Kill();
					return;
				}
				Main.player[this.owner].itemAnimation = 10;
				Main.player[this.owner].itemTime = 10;
				if (this.position.X + (float)(this.width / 2) > Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2))
				{
					Main.player[this.owner].ChangeDir(1);
					this.direction = 1;
				}
				else
				{
					Main.player[this.owner].ChangeDir(-1);
					this.direction = -1;
				}
				Vector2 vector14 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float num203 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector14.X;
				float num204 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector14.Y;
				float num205 = (float)Math.Sqrt((double)(num203 * num203 + num204 * num204));
				if (this.ai[0] == 0f)
				{
					float num206 = 160f;
					if (this.type == 63)
					{
						num206 *= 1.5f;
					}
					if (this.type == 247)
					{
						num206 *= 1.5f;
					}
					this.tileCollide = true;
					if (num205 > num206)
					{
						this.ai[0] = 1f;
						this.netUpdate = true;
					}
					else if (!Main.player[this.owner].channel)
					{
						if (this.velocity.Y < 0f)
						{
							this.velocity.Y = this.velocity.Y * 0.9f;
						}
						this.velocity.Y = this.velocity.Y + 1f;
						this.velocity.X = this.velocity.X * 0.9f;
					}
				}
				else if (this.ai[0] == 1f)
				{
					float num207 = 14f / Main.player[this.owner].meleeSpeed;
					float num208 = 0.9f / Main.player[this.owner].meleeSpeed;
					float num209 = 300f;
					if (this.type == 63)
					{
						num209 *= 1.5f;
						num207 *= 1.5f;
						num208 *= 1.5f;
					}
					if (this.type == 247)
					{
						num209 *= 1.5f;
						num207 = 15.9f;
						num208 *= 2f;
					}
					Math.Abs(num203);
					Math.Abs(num204);
					if (this.ai[1] == 1f)
					{
						this.tileCollide = false;
					}
					if (!Main.player[this.owner].channel || num205 > num209 || !this.tileCollide)
					{
						this.ai[1] = 1f;
						if (this.tileCollide)
						{
							this.netUpdate = true;
						}
						this.tileCollide = false;
						if (num205 < 20f)
						{
							this.Kill();
						}
					}
					if (!this.tileCollide)
					{
						num208 *= 2f;
					}
					int num210 = 60;
					if (this.type == 247)
					{
						num210 = 100;
					}
					if (num205 > (float)num210 || !this.tileCollide)
					{
						num205 = num207 / num205;
						num203 *= num205;
						num204 *= num205;
						new Vector2(this.velocity.X, this.velocity.Y);
						float num211 = num203 - this.velocity.X;
						float num212 = num204 - this.velocity.Y;
						float num213 = (float)Math.Sqrt((double)(num211 * num211 + num212 * num212));
						num213 = num208 / num213;
						num211 *= num213;
						num212 *= num213;
						this.velocity.X = this.velocity.X * 0.98f;
						this.velocity.Y = this.velocity.Y * 0.98f;
						this.velocity.X = this.velocity.X + num211;
						this.velocity.Y = this.velocity.Y + num212;
					}
					else
					{
						if (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) < 6f)
						{
							this.velocity.X = this.velocity.X * 0.96f;
							this.velocity.Y = this.velocity.Y + 0.2f;
						}
						if (Main.player[this.owner].velocity.X == 0f)
						{
							this.velocity.X = this.velocity.X * 0.96f;
						}
					}
				}
				if (this.type != 247)
				{
					this.rotation = (float)Math.Atan2((double)num204, (double)num203) - this.velocity.X * 0.1f;
					return;
				}
				if (this.velocity.X < 0f)
				{
					this.rotation -= (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.01f;
				}
				else
				{
					this.rotation += (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.01f;
				}
				float num214 = this.position.X;
				float num215 = this.position.Y;
				float num216 = 600f;
				bool flag4 = false;
				if (this.owner == Main.myPlayer)
				{
					this.localAI[1] += 1f;
					if (this.localAI[1] > 20f)
					{
						this.localAI[1] = 20f;
						for (int num217 = 0; num217 < 200; num217++)
						{
							if (Main.npc[num217].active && !Main.npc[num217].dontTakeDamage && !Main.npc[num217].friendly && Main.npc[num217].lifeMax > 5)
							{
								float num218 = Main.npc[num217].position.X + (float)(Main.npc[num217].width / 2);
								float num219 = Main.npc[num217].position.Y + (float)(Main.npc[num217].height / 2);
								float num220 = Math.Abs(this.position.X + (float)(this.width / 2) - num218) + Math.Abs(this.position.Y + (float)(this.height / 2) - num219);
								if (num220 < num216 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num217].position, Main.npc[num217].width, Main.npc[num217].height))
								{
									num216 = num220;
									num214 = num218;
									num215 = num219;
									flag4 = true;
								}
							}
						}
					}
				}
				if (flag4)
				{
					this.localAI[1] = 0f;
					float num221 = 14f;
					vector14 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					num203 = num214 - vector14.X;
					num204 = num215 - vector14.Y;
					num205 = (float)Math.Sqrt((double)(num203 * num203 + num204 * num204));
					num205 = num221 / num205;
					num203 *= num205;
					num204 *= num205;
					Projectile.NewProjectile(vector14.X, vector14.Y, num203, num204, 248, (int)((double)this.damage / 1.5), this.knockBack / 2f, Main.myPlayer, 0f, 0f);
					return;
				}
			}
			else if (this.aiStyle == 16)
			{
				if (this.type == 108 || this.type == 164)
				{
					this.ai[0] += 1f;
					if (this.ai[0] > 3f)
					{
						this.Kill();
					}
				}
				if (this.type == 37)
				{
					try
					{
						int num222 = (int)(this.position.X / 16f) - 1;
						int num223 = (int)((this.position.X + (float)this.width) / 16f) + 2;
						int num224 = (int)(this.position.Y / 16f) - 1;
						int num225 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
						if (num222 < 0)
						{
							num222 = 0;
						}
						if (num223 > Main.maxTilesX)
						{
							num223 = Main.maxTilesX;
						}
						if (num224 < 0)
						{
							num224 = 0;
						}
						if (num225 > Main.maxTilesY)
						{
							num225 = Main.maxTilesY;
						}
						for (int num226 = num222; num226 < num223; num226++)
						{
							for (int num227 = num224; num227 < num225; num227++)
							{
								if (Main.tile[num226, num227] != null && Main.tile[num226, num227].nactive() && (Main.tileSolid[(int)Main.tile[num226, num227].type] || (Main.tileSolidTop[(int)Main.tile[num226, num227].type] && Main.tile[num226, num227].frameY == 0)))
								{
									Vector2 vector15;
									vector15.X = (float)(num226 * 16);
									vector15.Y = (float)(num227 * 16);
									if (this.position.X + (float)this.width - 4f > vector15.X && this.position.X + 4f < vector15.X + 16f && this.position.Y + (float)this.height - 4f > vector15.Y && this.position.Y + 4f < vector15.Y + 16f)
									{
										this.velocity.X = 0f;
										this.velocity.Y = -0.2f;
									}
								}
							}
						}
					}
					catch
					{
					}
				}
				if (this.type == 102)
				{
					if (this.velocity.Y > 10f)
					{
						this.velocity.Y = 10f;
					}
					if (this.localAI[0] == 0f)
					{
						this.localAI[0] = 1f;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					}
					this.frameCounter++;
					if (this.frameCounter > 3)
					{
						this.frame++;
						this.frameCounter = 0;
					}
					if (this.frame > 1)
					{
						this.frame = 0;
					}
					if (this.velocity.Y == 0f)
					{
						this.position.X = this.position.X + (float)(this.width / 2);
						this.position.Y = this.position.Y + (float)(this.height / 2);
						this.width = 128;
						this.height = 128;
						this.position.X = this.position.X - (float)(this.width / 2);
						this.position.Y = this.position.Y - (float)(this.height / 2);
						this.damage = 40;
						this.knockBack = 8f;
						this.timeLeft = 3;
						this.netUpdate = true;
					}
				}
				if (this.type == 303 && this.timeLeft <= 3 && this.hostile)
				{
					this.position.X = this.position.X + (float)(this.width / 2);
					this.position.Y = this.position.Y + (float)(this.height / 2);
					this.width = 128;
					this.height = 128;
					this.position.X = this.position.X - (float)(this.width / 2);
					this.position.Y = this.position.Y - (float)(this.height / 2);
				}
				if (this.owner == Main.myPlayer && this.timeLeft <= 3)
				{
					this.tileCollide = false;
					this.ai[1] = 0f;
					this.alpha = 255;
					if (this.type == 28 || this.type == 37 || this.type == 75)
					{
						this.position.X = this.position.X + (float)(this.width / 2);
						this.position.Y = this.position.Y + (float)(this.height / 2);
						this.width = 128;
						this.height = 128;
						this.position.X = this.position.X - (float)(this.width / 2);
						this.position.Y = this.position.Y - (float)(this.height / 2);
						this.damage = 100;
						this.knockBack = 8f;
					}
					else if (this.type == 29)
					{
						this.position.X = this.position.X + (float)(this.width / 2);
						this.position.Y = this.position.Y + (float)(this.height / 2);
						this.width = 250;
						this.height = 250;
						this.position.X = this.position.X - (float)(this.width / 2);
						this.position.Y = this.position.Y - (float)(this.height / 2);
						this.damage = 250;
						this.knockBack = 10f;
					}
					else if (this.type == 30)
					{
						this.position.X = this.position.X + (float)(this.width / 2);
						this.position.Y = this.position.Y + (float)(this.height / 2);
						this.width = 128;
						this.height = 128;
						this.position.X = this.position.X - (float)(this.width / 2);
						this.position.Y = this.position.Y - (float)(this.height / 2);
						this.knockBack = 8f;
					}
					else if (this.type == 133 || this.type == 134 || this.type == 135 || this.type == 136 || this.type == 137 || this.type == 138)
					{
						this.position.X = this.position.X + (float)(this.width / 2);
						this.position.Y = this.position.Y + (float)(this.height / 2);
						this.width = 128;
						this.height = 128;
						this.position.X = this.position.X - (float)(this.width / 2);
						this.position.Y = this.position.Y - (float)(this.height / 2);
						this.knockBack = 8f;
					}
					else if (this.type == 139 || this.type == 140 || this.type == 141 || this.type == 142 || this.type == 143 || this.type == 144)
					{
						this.position.X = this.position.X + (float)(this.width / 2);
						this.position.Y = this.position.Y + (float)(this.height / 2);
						this.width = 200;
						this.height = 200;
						this.position.X = this.position.X - (float)(this.width / 2);
						this.position.Y = this.position.Y - (float)(this.height / 2);
						this.knockBack = 10f;
					}
				}
				else
				{
					if (this.type != 30 && this.type != 108 && this.type != 133 && this.type != 134 && this.type != 135 && this.type != 136 && this.type != 137 && this.type != 138 && this.type != 139 && this.type != 140 && this.type != 141 && this.type != 142 && this.type != 143 && this.type != 144 && this.type != 164 && this.type != 303)
					{
						this.damage = 0;
					}
					if (this.type == 134 || this.type == 137 || this.type == 140 || this.type == 143 || this.type == 303)
					{
						if (Math.Abs(this.velocity.X) >= 8f || Math.Abs(this.velocity.Y) >= 8f)
						{
							for (int num228 = 0; num228 < 2; num228++)
							{
								float num229 = 0f;
								float num230 = 0f;
								if (num228 == 1)
								{
									num229 = this.velocity.X * 0.5f;
									num230 = this.velocity.Y * 0.5f;
								}
								int num231 = Dust.NewDust(new Vector2(this.position.X + 3f + num229, this.position.Y + 3f + num230) - this.velocity * 0.5f, this.width - 8, this.height - 8, 6, 0f, 0f, 100, default(Color), 1f);
								Main.dust[num231].scale *= 2f + (float)Main.rand.Next(10) * 0.1f;
								Main.dust[num231].velocity *= 0.2f;
								Main.dust[num231].noGravity = true;
								num231 = Dust.NewDust(new Vector2(this.position.X + 3f + num229, this.position.Y + 3f + num230) - this.velocity * 0.5f, this.width - 8, this.height - 8, 31, 0f, 0f, 100, default(Color), 0.5f);
								Main.dust[num231].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
								Main.dust[num231].velocity *= 0.05f;
							}
						}
						if (Math.Abs(this.velocity.X) < 15f && Math.Abs(this.velocity.Y) < 15f)
						{
							this.velocity *= 1.1f;
						}
					}
					else if (this.type == 133 || this.type == 136 || this.type == 139 || this.type == 142)
					{
						int num232 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num232].scale *= 1f + (float)Main.rand.Next(10) * 0.1f;
						Main.dust[num232].velocity *= 0.2f;
						Main.dust[num232].noGravity = true;
					}
					else if (this.type == 135 || this.type == 138 || this.type == 141 || this.type == 144)
					{
						if ((double)this.velocity.X > -0.2 && (double)this.velocity.X < 0.2 && (double)this.velocity.Y > -0.2 && (double)this.velocity.Y < 0.2)
						{
							this.alpha += 2;
							if (this.alpha > 200)
							{
								this.alpha = 200;
							}
						}
						else
						{
							this.alpha = 0;
							int num233 = Dust.NewDust(new Vector2(this.position.X + 3f, this.position.Y + 3f) - this.velocity * 0.5f, this.width - 8, this.height - 8, 31, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num233].scale *= 1.6f + (float)Main.rand.Next(5) * 0.1f;
							Main.dust[num233].velocity *= 0.05f;
							Main.dust[num233].noGravity = true;
						}
					}
					else if (this.type != 30 && Main.rand.Next(2) == 0)
					{
						int num234 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num234].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
						Main.dust[num234].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
						Main.dust[num234].noGravity = true;
						if (Main.rand.Next(3) == 0)
						{
							num234 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num234].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
							Main.dust[num234].noGravity = true;
						}
					}
				}
				this.ai[0] += 1f;
				if (this.type == 134 || this.type == 137 || this.type == 140 || this.type == 143 || this.type == 303)
				{
					this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
				}
				else if (this.type == 135 || this.type == 138 || this.type == 141 || this.type == 144)
				{
					this.velocity.Y = this.velocity.Y + 0.2f;
					this.velocity *= 0.97f;
					if ((double)this.velocity.X > -0.1 && (double)this.velocity.X < 0.1)
					{
						this.velocity.X = 0f;
					}
					if ((double)this.velocity.Y > -0.1 && (double)this.velocity.Y < 0.1)
					{
						this.velocity.Y = 0f;
					}
				}
				else if (this.type == 133 || this.type == 136 || this.type == 139 || this.type == 142)
				{
					if (this.ai[0] > 15f)
					{
						if (this.velocity.Y == 0f)
						{
							this.velocity.X = this.velocity.X * 0.95f;
						}
						this.velocity.Y = this.velocity.Y + 0.2f;
					}
				}
				else if ((this.type == 30 && this.ai[0] > 10f) || (this.type != 30 && this.ai[0] > 5f))
				{
					this.ai[0] = 10f;
					if (this.velocity.Y == 0f && this.velocity.X != 0f)
					{
						this.velocity.X = this.velocity.X * 0.97f;
						if (this.type == 29)
						{
							this.velocity.X = this.velocity.X * 0.99f;
						}
						if ((double)this.velocity.X > -0.01 && (double)this.velocity.X < 0.01)
						{
							this.velocity.X = 0f;
							this.netUpdate = true;
						}
					}
					this.velocity.Y = this.velocity.Y + 0.2f;
				}
				if (this.type != 134 && this.type != 137 && this.type != 140 && this.type != 143 && this.type != 303)
				{
					this.rotation += this.velocity.X * 0.1f;
					return;
				}
			}
			else if (this.aiStyle == 17)
			{
				if (this.velocity.Y == 0f)
				{
					this.velocity.X = this.velocity.X * 0.98f;
				}
				this.rotation += this.velocity.X * 0.1f;
				this.velocity.Y = this.velocity.Y + 0.2f;
				if (this.owner == Main.myPlayer)
				{
					int num235 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
					int num236 = (int)((this.position.Y + (float)this.height - 4f) / 16f);
					if (Main.tile[num235, num236] != null && !Main.tile[num235, num236].active())
					{
						int num237 = 0;
						if (this.type >= 201 && this.type <= 205)
						{
							num237 = this.type - 200;
						}
						WorldGen.PlaceTile(num235, num236, 85, false, false, this.owner, num237);
						if (Main.tile[num235, num236].active())
						{
							if (Main.netMode != 0)
							{
								NetMessage.SendData(17, -1, -1, "", 1, (float)num235, (float)num236, 85f, num237);
							}
							int num238 = Sign.ReadSign(num235, num236);
							if (num238 >= 0)
							{
								Sign.TextSign(num238, this.miscText);
							}
							this.Kill();
							return;
						}
					}
				}
			}
			else if (this.aiStyle == 18)
			{
				if (this.ai[1] == 0f && this.type == 44)
				{
					this.ai[1] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
				}
				if (this.type != 263 && this.type != 274)
				{
					this.rotation += (float)this.direction * 0.8f;
					this.ai[0] += 1f;
					if (this.ai[0] >= 30f)
					{
						if (this.ai[0] < 100f)
						{
							this.velocity *= 1.06f;
						}
						else
						{
							this.ai[0] = 200f;
						}
					}
					for (int num239 = 0; num239 < 2; num239++)
					{
						int num240 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 27, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num240].noGravity = true;
					}
					return;
				}
				if (this.type == 274 && this.velocity.X < 0f)
				{
					this.spriteDirection = -1;
				}
				this.rotation += (float)this.direction * 0.05f;
				this.rotation += (float)this.direction * 0.5f * ((float)this.timeLeft / 180f);
				if (this.type == 274)
				{
					this.velocity *= 0.96f;
					return;
				}
				this.velocity *= 0.95f;
				return;
			}
			else if (this.aiStyle == 19)
			{
				this.direction = Main.player[this.owner].direction;
				Main.player[this.owner].heldProj = this.whoAmI;
				Main.player[this.owner].itemTime = Main.player[this.owner].itemAnimation;
				this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
				this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
				if (!Main.player[this.owner].frozen)
				{
					if (this.type == 46)
					{
						if (this.ai[0] == 0f)
						{
							this.ai[0] = 3f;
							this.netUpdate = true;
						}
						if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
						{
							this.ai[0] -= 1.6f;
						}
						else
						{
							this.ai[0] += 1.4f;
						}
					}
					else if (this.type == 105)
					{
						if (this.ai[0] == 0f)
						{
							this.ai[0] = 3f;
							this.netUpdate = true;
						}
						if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
						{
							this.ai[0] -= 2.4f;
						}
						else
						{
							this.ai[0] += 2.1f;
						}
					}
					else if (this.type == 222)
					{
						if (this.ai[0] == 0f)
						{
							this.ai[0] = 3f;
							this.netUpdate = true;
						}
						if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
						{
							this.ai[0] -= 2.4f;
							if (this.localAI[0] == 0f && Main.myPlayer == this.owner)
							{
								this.localAI[0] = 1f;
								Projectile.NewProjectile(this.center().X + this.velocity.X * this.ai[0], this.center().Y + this.velocity.Y * this.ai[0], this.velocity.X, this.velocity.Y, 228, this.damage, this.knockBack, this.owner, 0f, 0f);
							}
						}
						else
						{
							this.ai[0] += 2.1f;
						}
					}
					else if (this.type == 47)
					{
						if (this.ai[0] == 0f)
						{
							this.ai[0] = 4f;
							this.netUpdate = true;
						}
						if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
						{
							this.ai[0] -= 1.2f;
						}
						else
						{
							this.ai[0] += 0.9f;
						}
					}
					else if (this.type == 153)
					{
						this.spriteDirection = -this.direction;
						if (this.ai[0] == 0f)
						{
							this.ai[0] = 4f;
							this.netUpdate = true;
						}
						if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
						{
							this.ai[0] -= 1.5f;
						}
						else
						{
							this.ai[0] += 1.3f;
						}
					}
					else if (this.type == 49)
					{
						if (this.ai[0] == 0f)
						{
							this.ai[0] = 4f;
							this.netUpdate = true;
						}
						if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
						{
							this.ai[0] -= 1.1f;
						}
						else
						{
							this.ai[0] += 0.85f;
						}
					}
					else if (this.type == 64 || this.type == 215)
					{
						this.spriteDirection = -this.direction;
						if (this.ai[0] == 0f)
						{
							this.ai[0] = 3f;
							this.netUpdate = true;
						}
						if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
						{
							this.ai[0] -= 1.9f;
						}
						else
						{
							this.ai[0] += 1.7f;
						}
					}
					else if (this.type == 66 || this.type == 97 || this.type == 212 || this.type == 218)
					{
						this.spriteDirection = -this.direction;
						if (this.ai[0] == 0f)
						{
							this.ai[0] = 3f;
							this.netUpdate = true;
						}
						if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
						{
							this.ai[0] -= 2.1f;
						}
						else
						{
							this.ai[0] += 1.9f;
						}
					}
					else if (this.type == 130)
					{
						this.spriteDirection = -this.direction;
						if (this.ai[0] == 0f)
						{
							this.ai[0] = 3f;
							this.netUpdate = true;
						}
						if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
						{
							this.ai[0] -= 1.3f;
						}
						else
						{
							this.ai[0] += 1f;
						}
					}
				}
				this.position += this.velocity * this.ai[0];
				if (this.type == 130)
				{
					if (this.ai[1] == 0f || this.ai[1] == 4f || this.ai[1] == 8f || this.ai[1] == 12f || this.ai[1] == 16f || this.ai[1] == 20f || this.ai[1] == 24f)
					{
						Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), this.velocity.X, this.velocity.Y, 131, this.damage / 2, 0f, this.owner, 0f, 0f);
					}
					this.ai[1] += 1f;
				}
				if (Main.player[this.owner].itemAnimation == 0)
				{
					this.Kill();
				}
				this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 2.355f;
				if (this.spriteDirection == -1)
				{
					this.rotation -= 1.57f;
				}
				if (this.type == 46)
				{
					if (Main.rand.Next(5) == 0)
					{
						Dust.NewDust(this.position, this.width, this.height, 14, 0f, 0f, 150, default(Color), 1.4f);
					}
					int num241 = Dust.NewDust(this.position, this.width, this.height, 27, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.2f);
					Main.dust[num241].noGravity = true;
					Dust expr_B02B_cp_0 = Main.dust[num241];
					expr_B02B_cp_0.velocity.X = expr_B02B_cp_0.velocity.X / 2f;
					Dust expr_B04B_cp_0 = Main.dust[num241];
					expr_B04B_cp_0.velocity.Y = expr_B04B_cp_0.velocity.Y / 2f;
					num241 = Dust.NewDust(this.position - this.velocity * 2f, this.width, this.height, 27, 0f, 0f, 150, default(Color), 1.4f);
					Dust expr_B0BF_cp_0 = Main.dust[num241];
					expr_B0BF_cp_0.velocity.X = expr_B0BF_cp_0.velocity.X / 5f;
					Dust expr_B0DF_cp_0 = Main.dust[num241];
					expr_B0DF_cp_0.velocity.Y = expr_B0DF_cp_0.velocity.Y / 5f;
					return;
				}
				if (this.type == 105)
				{
					if (Main.rand.Next(3) == 0)
					{
						int num242 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 57, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 200, default(Color), 1.2f);
						Main.dust[num242].velocity += this.velocity * 0.3f;
						Main.dust[num242].velocity *= 0.2f;
					}
					if (Main.rand.Next(4) == 0)
					{
						int num243 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 43, 0f, 0f, 254, default(Color), 0.3f);
						Main.dust[num243].velocity += this.velocity * 0.5f;
						Main.dust[num243].velocity *= 0.5f;
						return;
					}
				}
				else if (this.type == 153)
				{
					int num244 = Dust.NewDust(this.position - this.velocity * 3f, this.width, this.height, 115, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 140, default(Color), 1f);
					Main.dust[num244].noGravity = true;
					Main.dust[num244].fadeIn = 1.25f;
					Main.dust[num244].velocity *= 0.25f;
					return;
				}
			}
			else if (this.aiStyle == 20)
			{
				if (this.type == 252)
				{
					this.frameCounter++;
					if (this.frameCounter >= 4)
					{
						this.frameCounter = 0;
						this.frame++;
					}
					if (this.frame > 3)
					{
						this.frame = 0;
					}
				}
				if (this.soundDelay <= 0)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 22);
					this.soundDelay = 30;
				}
				if (Main.myPlayer == this.owner)
				{
					if (Main.player[this.owner].channel)
					{
						float num245 = Main.player[this.owner].inventory[Main.player[this.owner].selectedItem].shootSpeed * this.scale;
						Vector2 vector16 = new Vector2(Main.player[this.owner].position.X + (float)Main.player[this.owner].width * 0.5f, Main.player[this.owner].position.Y + (float)Main.player[this.owner].height * 0.5f);
						float num246 = (float)Main.mouseX + Main.screenPosition.X - vector16.X;
						float num247 = (float)Main.mouseY + Main.screenPosition.Y - vector16.Y;
						float num248 = (float)Math.Sqrt((double)(num246 * num246 + num247 * num247));
						num248 = (float)Math.Sqrt((double)(num246 * num246 + num247 * num247));
						num248 = num245 / num248;
						num246 *= num248;
						num247 *= num248;
						if (num246 != this.velocity.X || num247 != this.velocity.Y)
						{
							this.netUpdate = true;
						}
						this.velocity.X = num246;
						this.velocity.Y = num247;
					}
					else
					{
						this.Kill();
					}
				}
				if (this.velocity.X > 0f)
				{
					Main.player[this.owner].ChangeDir(1);
				}
				else if (this.velocity.X < 0f)
				{
					Main.player[this.owner].ChangeDir(-1);
				}
				this.spriteDirection = this.direction;
				Main.player[this.owner].ChangeDir(this.direction);
				Main.player[this.owner].heldProj = this.whoAmI;
				Main.player[this.owner].itemTime = 2;
				Main.player[this.owner].itemAnimation = 2;
				this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
				this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
				this.rotation = (float)(Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.5700000524520874);
				if (Main.player[this.owner].direction == 1)
				{
					Main.player[this.owner].itemRotation = (float)Math.Atan2((double)(this.velocity.Y * (float)this.direction), (double)(this.velocity.X * (float)this.direction));
				}
				else
				{
					Main.player[this.owner].itemRotation = (float)Math.Atan2((double)(this.velocity.Y * (float)this.direction), (double)(this.velocity.X * (float)this.direction));
				}
				this.velocity.X = this.velocity.X * (1f + (float)Main.rand.Next(-3, 4) * 0.01f);
				if (Main.rand.Next(6) == 0)
				{
					int num249 = Dust.NewDust(this.position + this.velocity * (float)Main.rand.Next(6, 10) * 0.1f, this.width, this.height, 31, 0f, 0f, 80, default(Color), 1.4f);
					Dust expr_B801_cp_0 = Main.dust[num249];
					expr_B801_cp_0.position.X = expr_B801_cp_0.position.X - 4f;
					Main.dust[num249].noGravity = true;
					Main.dust[num249].velocity *= 0.2f;
					Main.dust[num249].velocity.Y = (float)(-(float)Main.rand.Next(7, 13)) * 0.15f;
					return;
				}
			}
			else if (this.aiStyle == 21)
			{
				this.rotation = this.velocity.X * 0.1f;
				this.spriteDirection = -this.direction;
				if (Main.rand.Next(3) == 0)
				{
					int num250 = Dust.NewDust(this.position, this.width, this.height, 27, 0f, 0f, 80, default(Color), 1f);
					Main.dust[num250].noGravity = true;
					Main.dust[num250].velocity *= 0.2f;
				}
				if (this.ai[1] == 1f)
				{
					this.ai[1] = 0f;
					Main.harpNote = this.ai[0];
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 26);
					return;
				}
			}
			else if (this.aiStyle == 22)
			{
				if (this.velocity.X == 0f && this.velocity.Y == 0f)
				{
					this.alpha = 255;
				}
				if (this.ai[1] < 0f)
				{
					if (this.velocity.X > 0f)
					{
						this.rotation += 0.3f;
					}
					else
					{
						this.rotation -= 0.3f;
					}
					int num251 = (int)(this.position.X / 16f) - 1;
					int num252 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num253 = (int)(this.position.Y / 16f) - 1;
					int num254 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num251 < 0)
					{
						num251 = 0;
					}
					if (num252 > Main.maxTilesX)
					{
						num252 = Main.maxTilesX;
					}
					if (num253 < 0)
					{
						num253 = 0;
					}
					if (num254 > Main.maxTilesY)
					{
						num254 = Main.maxTilesY;
					}
					int num255 = (int)this.position.X + 4;
					int num256 = (int)this.position.Y + 4;
					for (int num257 = num251; num257 < num252; num257++)
					{
						for (int num258 = num253; num258 < num254; num258++)
						{
							if (Main.tile[num257, num258] != null && Main.tile[num257, num258].active() && Main.tile[num257, num258].type != 127 && Main.tileSolid[(int)Main.tile[num257, num258].type] && !Main.tileSolidTop[(int)Main.tile[num257, num258].type])
							{
								Vector2 vector17;
								vector17.X = (float)(num257 * 16);
								vector17.Y = (float)(num258 * 16);
								if ((float)(num255 + 8) > vector17.X && (float)num255 < vector17.X + 16f && (float)(num256 + 8) > vector17.Y && (float)num256 < vector17.Y + 16f)
								{
									this.Kill();
								}
							}
						}
					}
					int num259 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num259].noGravity = true;
					Main.dust[num259].velocity *= 0.3f;
					return;
				}
				if (this.ai[0] < 0f)
				{
					if (this.ai[0] == -1f)
					{
						for (int num260 = 0; num260 < 10; num260++)
						{
							int num261 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0f, 0f, 0, default(Color), 1.1f);
							Main.dust[num261].noGravity = true;
							Main.dust[num261].velocity *= 1.3f;
						}
					}
					else if (Main.rand.Next(30) == 0)
					{
						int num262 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num262].velocity *= 0.2f;
					}
					int num263 = (int)this.position.X / 16;
					int num264 = (int)this.position.Y / 16;
					if (Main.tile[num263, num264] == null || !Main.tile[num263, num264].active())
					{
						this.Kill();
					}
					this.ai[0] -= 1f;
					if (this.ai[0] <= -300f && (Main.myPlayer == this.owner || Main.netMode == 2) && Main.tile[num263, num264].active() && Main.tile[num263, num264].type == 127)
					{
						WorldGen.KillTile(num263, num264, false, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(17, -1, -1, "", 0, (float)num263, (float)num264, 0f, 0);
						}
						this.Kill();
						return;
					}
				}
				else
				{
					int num265 = (int)(this.position.X / 16f) - 1;
					int num266 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num267 = (int)(this.position.Y / 16f) - 1;
					int num268 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num265 < 0)
					{
						num265 = 0;
					}
					if (num266 > Main.maxTilesX)
					{
						num266 = Main.maxTilesX;
					}
					if (num267 < 0)
					{
						num267 = 0;
					}
					if (num268 > Main.maxTilesY)
					{
						num268 = Main.maxTilesY;
					}
					int num269 = (int)this.position.X + 4;
					int num270 = (int)this.position.Y + 4;
					for (int num271 = num265; num271 < num266; num271++)
					{
						for (int num272 = num267; num272 < num268; num272++)
						{
							if (Main.tile[num271, num272] != null && Main.tile[num271, num272].nactive() && Main.tile[num271, num272].type != 127 && Main.tileSolid[(int)Main.tile[num271, num272].type] && !Main.tileSolidTop[(int)Main.tile[num271, num272].type])
							{
								Vector2 vector18;
								vector18.X = (float)(num271 * 16);
								vector18.Y = (float)(num272 * 16);
								if ((float)(num269 + 8) > vector18.X && (float)num269 < vector18.X + 16f && (float)(num270 + 8) > vector18.Y && (float)num270 < vector18.Y + 16f)
								{
									this.Kill();
								}
							}
						}
					}
					if (this.lavaWet)
					{
						this.Kill();
					}
					if (this.active)
					{
						int num273 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num273].noGravity = true;
						Main.dust[num273].velocity *= 0.3f;
						int num274 = (int)this.ai[0];
						int num275 = (int)this.ai[1];
						if (this.velocity.X > 0f)
						{
							this.rotation += 0.3f;
						}
						else
						{
							this.rotation -= 0.3f;
						}
						if (Main.myPlayer == this.owner)
						{
							int num276 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
							int num277 = (int)((this.position.Y + (float)(this.height / 2)) / 16f);
							bool flag5 = false;
							if (num276 == num274 && num277 == num275)
							{
								flag5 = true;
							}
							if (((this.velocity.X <= 0f && num276 <= num274) || (this.velocity.X >= 0f && num276 >= num274)) && ((this.velocity.Y <= 0f && num277 <= num275) || (this.velocity.Y >= 0f && num277 >= num275)))
							{
								flag5 = true;
							}
							if (flag5)
							{
								if (WorldGen.PlaceTile(num274, num275, 127, false, false, this.owner, 0))
								{
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 1, (float)((int)this.ai[0]), (float)((int)this.ai[1]), 127f, 0);
									}
									this.damage = 0;
									this.ai[0] = -1f;
									this.velocity *= 0f;
									this.alpha = 255;
									this.position.X = (float)(num274 * 16);
									this.position.Y = (float)(num275 * 16);
									this.netUpdate = true;
									return;
								}
								this.ai[1] = -1f;
								return;
							}
						}
					}
				}
			}
			else
			{
				if (this.aiStyle == 23)
				{
					if (this.type == 188 && this.ai[0] < 8f)
					{
						this.ai[0] = 8f;
					}
					if (this.timeLeft > 60)
					{
						this.timeLeft = 60;
					}
					if (this.ai[0] > 7f)
					{
						float num278 = 1f;
						if (this.ai[0] == 8f)
						{
							num278 = 0.25f;
						}
						else if (this.ai[0] == 9f)
						{
							num278 = 0.5f;
						}
						else if (this.ai[0] == 10f)
						{
							num278 = 0.75f;
						}
						this.ai[0] += 1f;
						int num279 = 6;
						if (this.type == 101)
						{
							num279 = 75;
						}
						if (num279 == 6 || Main.rand.Next(2) == 0)
						{
							for (int num280 = 0; num280 < 1; num280++)
							{
								int num281 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num279, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 1f);
								if (Main.rand.Next(3) != 0 || (num279 == 75 && Main.rand.Next(3) == 0))
								{
									Main.dust[num281].noGravity = true;
									Main.dust[num281].scale *= 3f;
									Dust expr_C56B_cp_0 = Main.dust[num281];
									expr_C56B_cp_0.velocity.X = expr_C56B_cp_0.velocity.X * 2f;
									Dust expr_C58B_cp_0 = Main.dust[num281];
									expr_C58B_cp_0.velocity.Y = expr_C58B_cp_0.velocity.Y * 2f;
								}
								if (this.type == 188)
								{
									Main.dust[num281].scale *= 1.25f;
								}
								else
								{
									Main.dust[num281].scale *= 1.5f;
								}
								Dust expr_C5F0_cp_0 = Main.dust[num281];
								expr_C5F0_cp_0.velocity.X = expr_C5F0_cp_0.velocity.X * 1.2f;
								Dust expr_C610_cp_0 = Main.dust[num281];
								expr_C610_cp_0.velocity.Y = expr_C610_cp_0.velocity.Y * 1.2f;
								Main.dust[num281].scale *= num278;
								if (num279 == 75)
								{
									Main.dust[num281].velocity += this.velocity;
									if (!Main.dust[num281].noGravity)
									{
										Main.dust[num281].velocity *= 0.5f;
									}
								}
							}
						}
					}
					else
					{
						this.ai[0] += 1f;
					}
					this.rotation += 0.3f * (float)this.direction;
					return;
				}
				if (this.aiStyle == 24)
				{
					this.light = this.scale * 0.5f;
					this.rotation += this.velocity.X * 0.2f;
					this.ai[1] += 1f;
					if (this.type == 94)
					{
						if (Main.rand.Next(4) == 0)
						{
							int num282 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 70, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num282].noGravity = true;
							Main.dust[num282].velocity *= 0.5f;
							Main.dust[num282].scale *= 0.9f;
						}
						this.velocity *= 0.985f;
						if (this.ai[1] > 130f)
						{
							this.scale -= 0.05f;
							if ((double)this.scale <= 0.2)
							{
								this.scale = 0.2f;
								this.Kill();
								return;
							}
						}
					}
					else
					{
						this.velocity *= 0.96f;
						if (this.ai[1] > 15f)
						{
							this.scale -= 0.05f;
							if ((double)this.scale <= 0.2)
							{
								this.scale = 0.2f;
								this.Kill();
								return;
							}
						}
					}
				}
				else
				{
					if (this.aiStyle == 25)
					{
						if (this.ai[0] != 0f && this.velocity.Y <= 0f && this.velocity.X == 0f)
						{
							float num283 = 0.5f;
							int i2 = (int)((this.position.X - 8f) / 16f);
							int num284 = (int)(this.position.Y / 16f);
							bool flag6 = false;
							bool flag7 = false;
							if (WorldGen.SolidTile(i2, num284) || WorldGen.SolidTile(i2, num284 + 1))
							{
								flag6 = true;
							}
							i2 = (int)((this.position.X + (float)this.width + 8f) / 16f);
							if (WorldGen.SolidTile(i2, num284) || WorldGen.SolidTile(i2, num284 + 1))
							{
								flag7 = true;
							}
							if (flag6)
							{
								this.velocity.X = num283;
							}
							else if (flag7)
							{
								this.velocity.X = -num283;
							}
							else
							{
								i2 = (int)((this.position.X - 8f - 16f) / 16f);
								num284 = (int)(this.position.Y / 16f);
								flag6 = false;
								flag7 = false;
								if (WorldGen.SolidTile(i2, num284) || WorldGen.SolidTile(i2, num284 + 1))
								{
									flag6 = true;
								}
								i2 = (int)((this.position.X + (float)this.width + 8f + 16f) / 16f);
								if (WorldGen.SolidTile(i2, num284) || WorldGen.SolidTile(i2, num284 + 1))
								{
									flag7 = true;
								}
								if (flag6)
								{
									this.velocity.X = num283;
								}
								else if (flag7)
								{
									this.velocity.X = -num283;
								}
								else
								{
									i2 = (int)((this.position.X + 4f) / 16f);
									num284 = (int)((this.position.Y + (float)this.height + 8f) / 16f);
									if (WorldGen.SolidTile(i2, num284) || WorldGen.SolidTile(i2, num284 + 1))
									{
										flag6 = true;
									}
									if (!flag6)
									{
										this.velocity.X = num283;
									}
									else
									{
										this.velocity.X = -num283;
									}
								}
							}
						}
						this.rotation += this.velocity.X * 0.06f;
						this.ai[0] = 1f;
						if (this.velocity.Y > 16f)
						{
							this.velocity.Y = 16f;
						}
						if (this.velocity.Y <= 6f)
						{
							if (this.velocity.X > 0f && this.velocity.X < 7f)
							{
								this.velocity.X = this.velocity.X + 0.05f;
							}
							if (this.velocity.X < 0f && this.velocity.X > -7f)
							{
								this.velocity.X = this.velocity.X - 0.05f;
							}
						}
						this.velocity.Y = this.velocity.Y + 0.3f;
						return;
					}
					if (this.aiStyle == 26)
					{
						if (!Main.player[this.owner].active)
						{
							this.active = false;
							return;
						}
						bool flag8 = false;
						bool flag9 = false;
						bool flag10 = false;
						bool flag11 = false;
						int num285 = 85;
						if (this.type == 324)
						{
							num285 = 120;
						}
						if (this.type == 112)
						{
							num285 = 100;
						}
						if (this.type == 127)
						{
							num285 = 50;
						}
						if (this.type >= 191 && this.type <= 194)
						{
							if (this.lavaWet)
							{
								this.ai[0] = 1f;
								this.ai[1] = 0f;
							}
							num285 = 60 + 30 * this.minionPos;
						}
						else if (this.type == 266)
						{
							num285 = 60 + 30 * this.minionPos;
						}
						if (Main.myPlayer == this.owner)
						{
							if (this.type == 111)
							{
								if (Main.player[Main.myPlayer].dead)
								{
									Main.player[Main.myPlayer].bunny = false;
								}
								if (Main.player[Main.myPlayer].bunny)
								{
									this.timeLeft = 2;
								}
							}
							if (this.type == 112)
							{
								if (Main.player[Main.myPlayer].dead)
								{
									Main.player[Main.myPlayer].penguin = false;
								}
								if (Main.player[Main.myPlayer].penguin)
								{
									this.timeLeft = 2;
								}
							}
							if (this.type == 127)
							{
								if (Main.player[Main.myPlayer].dead)
								{
									Main.player[Main.myPlayer].turtle = false;
								}
								if (Main.player[Main.myPlayer].turtle)
								{
									this.timeLeft = 2;
								}
							}
							if (this.type == 175)
							{
								if (Main.player[Main.myPlayer].dead)
								{
									Main.player[Main.myPlayer].eater = false;
								}
								if (Main.player[Main.myPlayer].eater)
								{
									this.timeLeft = 2;
								}
							}
							if (this.type == 197)
							{
								if (Main.player[Main.myPlayer].dead)
								{
									Main.player[Main.myPlayer].skeletron = false;
								}
								if (Main.player[Main.myPlayer].skeletron)
								{
									this.timeLeft = 2;
								}
							}
							if (this.type == 198)
							{
								if (Main.player[Main.myPlayer].dead)
								{
									Main.player[Main.myPlayer].hornet = false;
								}
								if (Main.player[Main.myPlayer].hornet)
								{
									this.timeLeft = 2;
								}
							}
							if (this.type == 199)
							{
								if (Main.player[Main.myPlayer].dead)
								{
									Main.player[Main.myPlayer].tiki = false;
								}
								if (Main.player[Main.myPlayer].tiki)
								{
									this.timeLeft = 2;
								}
							}
							if (this.type == 200)
							{
								if (Main.player[Main.myPlayer].dead)
								{
									Main.player[Main.myPlayer].lizard = false;
								}
								if (Main.player[Main.myPlayer].lizard)
								{
									this.timeLeft = 2;
								}
							}
							if (this.type == 208)
							{
								if (Main.player[Main.myPlayer].dead)
								{
									Main.player[Main.myPlayer].parrot = false;
								}
								if (Main.player[Main.myPlayer].parrot)
								{
									this.timeLeft = 2;
								}
							}
							if (this.type == 209)
							{
								if (Main.player[Main.myPlayer].dead)
								{
									Main.player[Main.myPlayer].truffle = false;
								}
								if (Main.player[Main.myPlayer].truffle)
								{
									this.timeLeft = 2;
								}
							}
							if (this.type == 210)
							{
								if (Main.player[Main.myPlayer].dead)
								{
									Main.player[Main.myPlayer].sapling = false;
								}
								if (Main.player[Main.myPlayer].sapling)
								{
									this.timeLeft = 2;
								}
							}
							if (this.type == 324)
							{
								if (Main.player[Main.myPlayer].dead)
								{
									Main.player[Main.myPlayer].cSapling = false;
								}
								if (Main.player[Main.myPlayer].cSapling)
								{
									this.timeLeft = 2;
								}
							}
							if (this.type == 313)
							{
								if (Main.player[Main.myPlayer].dead)
								{
									Main.player[Main.myPlayer].spider = false;
								}
								if (Main.player[Main.myPlayer].spider)
								{
									this.timeLeft = 2;
								}
							}
							if (this.type == 314)
							{
								if (Main.player[Main.myPlayer].dead)
								{
									Main.player[Main.myPlayer].squashling = false;
								}
								if (Main.player[Main.myPlayer].squashling)
								{
									this.timeLeft = 2;
								}
							}
							if (this.type == 211)
							{
								if (Main.player[Main.myPlayer].dead)
								{
									Main.player[Main.myPlayer].wisp = false;
								}
								if (Main.player[Main.myPlayer].wisp)
								{
									this.timeLeft = 2;
								}
							}
							if (this.type == 236)
							{
								if (Main.player[Main.myPlayer].dead)
								{
									Main.player[Main.myPlayer].dino = false;
								}
								if (Main.player[Main.myPlayer].dino)
								{
									this.timeLeft = 2;
								}
							}
							if (this.type == 266)
							{
								if (Main.player[Main.myPlayer].dead)
								{
									Main.player[Main.myPlayer].slime = false;
								}
								if (Main.player[Main.myPlayer].slime)
								{
									this.timeLeft = 2;
								}
							}
							if (this.type == 268)
							{
								if (Main.player[Main.myPlayer].dead)
								{
									Main.player[Main.myPlayer].eyeSpring = false;
								}
								if (Main.player[Main.myPlayer].eyeSpring)
								{
									this.timeLeft = 2;
								}
							}
							if (this.type == 269)
							{
								if (Main.player[Main.myPlayer].dead)
								{
									Main.player[Main.myPlayer].snowman = false;
								}
								if (Main.player[Main.myPlayer].snowman)
								{
									this.timeLeft = 2;
								}
							}
							if (this.type == 319)
							{
								if (Main.player[Main.myPlayer].dead)
								{
									Main.player[Main.myPlayer].blackCat = false;
								}
								if (Main.player[Main.myPlayer].blackCat)
								{
									this.timeLeft = 2;
								}
							}
							if (this.type >= 191 && this.type <= 194)
							{
								if (Main.player[Main.myPlayer].dead)
								{
									Main.player[Main.myPlayer].pygmy = false;
								}
								if (Main.player[Main.myPlayer].pygmy)
								{
									this.timeLeft = Main.rand.Next(2, 10);
								}
							}
						}
						if ((this.type >= 191 && this.type <= 194) || this.type == 266)
						{
							num285 = 10;
							int num286 = 40 * (this.minionPos + 1) * Main.player[this.owner].direction;
							if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) < this.position.X + (float)(this.width / 2) - (float)num285 + (float)num286)
							{
								flag8 = true;
							}
							else if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) > this.position.X + (float)(this.width / 2) + (float)num285 + (float)num286)
							{
								flag9 = true;
							}
						}
						else if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) < this.position.X + (float)(this.width / 2) - (float)num285)
						{
							flag8 = true;
						}
						else if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) > this.position.X + (float)(this.width / 2) + (float)num285)
						{
							flag9 = true;
						}
						if (this.type == 175)
						{
							float num287 = 0.1f;
							this.tileCollide = false;
							int num288 = 300;
							Vector2 vector19 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num289 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector19.X;
							float num290 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector19.Y;
							if (this.type == 127)
							{
								num290 = Main.player[this.owner].position.Y - vector19.Y;
							}
							float num291 = (float)Math.Sqrt((double)(num289 * num289 + num290 * num290));
							float num292 = 7f;
							if (num291 < (float)num288 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
							{
								this.ai[0] = 0f;
								if (this.velocity.Y < -6f)
								{
									this.velocity.Y = -6f;
								}
							}
							if (num291 < 150f)
							{
								if (Math.Abs(this.velocity.X) > 2f || Math.Abs(this.velocity.Y) > 2f)
								{
									this.velocity *= 0.99f;
								}
								num287 = 0.01f;
								if (num289 < -2f)
								{
									num289 = -2f;
								}
								if (num289 > 2f)
								{
									num289 = 2f;
								}
								if (num290 < -2f)
								{
									num290 = -2f;
								}
								if (num290 > 2f)
								{
									num290 = 2f;
								}
							}
							else
							{
								if (num291 > 300f)
								{
									num287 = 0.2f;
								}
								num291 = num292 / num291;
								num289 *= num291;
								num290 *= num291;
							}
							if (Math.Abs(num289) > Math.Abs(num290) || num287 == 0.05f)
							{
								if (this.velocity.X < num289)
								{
									this.velocity.X = this.velocity.X + num287;
									if (num287 > 0.05f && this.velocity.X < 0f)
									{
										this.velocity.X = this.velocity.X + num287;
									}
								}
								if (this.velocity.X > num289)
								{
									this.velocity.X = this.velocity.X - num287;
									if (num287 > 0.05f && this.velocity.X > 0f)
									{
										this.velocity.X = this.velocity.X - num287;
									}
								}
							}
							if (Math.Abs(num289) <= Math.Abs(num290) || num287 == 0.05f)
							{
								if (this.velocity.Y < num290)
								{
									this.velocity.Y = this.velocity.Y + num287;
									if (num287 > 0.05f && this.velocity.Y < 0f)
									{
										this.velocity.Y = this.velocity.Y + num287;
									}
								}
								if (this.velocity.Y > num290)
								{
									this.velocity.Y = this.velocity.Y - num287;
									if (num287 > 0.05f && this.velocity.Y > 0f)
									{
										this.velocity.Y = this.velocity.Y - num287;
									}
								}
							}
							this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) - 1.57f;
							this.frameCounter++;
							if (this.frameCounter > 6)
							{
								this.frame++;
								this.frameCounter = 0;
							}
							if (this.frame > 1)
							{
								this.frame = 0;
								return;
							}
						}
						else if (this.type == 197)
						{
							float num293 = 0.1f;
							this.tileCollide = false;
							int num294 = 300;
							Vector2 vector20 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num295 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector20.X;
							float num296 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector20.Y;
							if (this.type == 127)
							{
								num296 = Main.player[this.owner].position.Y - vector20.Y;
							}
							float num297 = (float)Math.Sqrt((double)(num295 * num295 + num296 * num296));
							float num298 = 3f;
							if (num297 > 500f)
							{
								this.localAI[0] = 10000f;
							}
							if (this.localAI[0] >= 10000f)
							{
								num298 = 14f;
							}
							if (num297 < (float)num294 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
							{
								this.ai[0] = 0f;
								if (this.velocity.Y < -6f)
								{
									this.velocity.Y = -6f;
								}
							}
							if (num297 < 150f)
							{
								if (Math.Abs(this.velocity.X) > 2f || Math.Abs(this.velocity.Y) > 2f)
								{
									this.velocity *= 0.99f;
								}
								num293 = 0.01f;
								if (num295 < -2f)
								{
									num295 = -2f;
								}
								if (num295 > 2f)
								{
									num295 = 2f;
								}
								if (num296 < -2f)
								{
									num296 = -2f;
								}
								if (num296 > 2f)
								{
									num296 = 2f;
								}
							}
							else
							{
								if (num297 > 300f)
								{
									num293 = 0.2f;
								}
								num297 = num298 / num297;
								num295 *= num297;
								num296 *= num297;
							}
							if (this.velocity.X < num295)
							{
								this.velocity.X = this.velocity.X + num293;
								if (num293 > 0.05f && this.velocity.X < 0f)
								{
									this.velocity.X = this.velocity.X + num293;
								}
							}
							if (this.velocity.X > num295)
							{
								this.velocity.X = this.velocity.X - num293;
								if (num293 > 0.05f && this.velocity.X > 0f)
								{
									this.velocity.X = this.velocity.X - num293;
								}
							}
							if (this.velocity.Y < num296)
							{
								this.velocity.Y = this.velocity.Y + num293;
								if (num293 > 0.05f && this.velocity.Y < 0f)
								{
									this.velocity.Y = this.velocity.Y + num293;
								}
							}
							if (this.velocity.Y > num296)
							{
								this.velocity.Y = this.velocity.Y - num293;
								if (num293 > 0.05f && this.velocity.Y > 0f)
								{
									this.velocity.Y = this.velocity.Y - num293;
								}
							}
							this.localAI[0] += (float)Main.rand.Next(10);
							if (this.localAI[0] > 10000f)
							{
								if (this.localAI[1] == 0f)
								{
									if (this.velocity.X < 0f)
									{
										this.localAI[1] = -1f;
									}
									else
									{
										this.localAI[1] = 1f;
									}
								}
								this.rotation += 0.25f * this.localAI[1];
								if (this.localAI[0] > 12000f)
								{
									this.localAI[0] = 0f;
								}
							}
							else
							{
								this.localAI[1] = 0f;
								float num299 = this.velocity.X * 0.1f;
								if (this.rotation > num299)
								{
									this.rotation -= (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.01f;
									if (this.rotation < num299)
									{
										this.rotation = num299;
									}
								}
								if (this.rotation < num299)
								{
									this.rotation += (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.01f;
									if (this.rotation > num299)
									{
										this.rotation = num299;
									}
								}
							}
							if ((double)this.rotation > 6.28)
							{
								this.rotation -= 6.28f;
							}
							if ((double)this.rotation < -6.28)
							{
								this.rotation += 6.28f;
								return;
							}
						}
						else if (this.type == 198)
						{
							float num300 = 0.4f;
							this.tileCollide = false;
							int num301 = 100;
							Vector2 vector21 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num302 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector21.X;
							float num303 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector21.Y;
							num303 += (float)Main.rand.Next(-10, 21);
							num302 += (float)Main.rand.Next(-10, 21);
							num302 += (float)(60 * -(float)Main.player[this.owner].direction);
							num303 -= 60f;
							if (this.type == 127)
							{
								num303 = Main.player[this.owner].position.Y - vector21.Y;
							}
							float num304 = (float)Math.Sqrt((double)(num302 * num302 + num303 * num303));
							float num305 = 14f;
							if (num304 < (float)num301 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
							{
								this.ai[0] = 0f;
								if (this.velocity.Y < -6f)
								{
									this.velocity.Y = -6f;
								}
							}
							if (num304 < 50f)
							{
								if (Math.Abs(this.velocity.X) > 2f || Math.Abs(this.velocity.Y) > 2f)
								{
									this.velocity *= 0.99f;
								}
								num300 = 0.01f;
							}
							else
							{
								if (num304 < 100f)
								{
									num300 = 0.1f;
								}
								if (num304 > 300f)
								{
									num300 = 0.6f;
								}
								num304 = num305 / num304;
								num302 *= num304;
								num303 *= num304;
							}
							if (this.velocity.X < num302)
							{
								this.velocity.X = this.velocity.X + num300;
								if (num300 > 0.05f && this.velocity.X < 0f)
								{
									this.velocity.X = this.velocity.X + num300;
								}
							}
							if (this.velocity.X > num302)
							{
								this.velocity.X = this.velocity.X - num300;
								if (num300 > 0.05f && this.velocity.X > 0f)
								{
									this.velocity.X = this.velocity.X - num300;
								}
							}
							if (this.velocity.Y < num303)
							{
								this.velocity.Y = this.velocity.Y + num300;
								if (num300 > 0.05f && this.velocity.Y < 0f)
								{
									this.velocity.Y = this.velocity.Y + num300 * 2f;
								}
							}
							if (this.velocity.Y > num303)
							{
								this.velocity.Y = this.velocity.Y - num300;
								if (num300 > 0.05f && this.velocity.Y > 0f)
								{
									this.velocity.Y = this.velocity.Y - num300 * 2f;
								}
							}
							if ((double)this.velocity.X > 0.25)
							{
								this.direction = -1;
							}
							else if ((double)this.velocity.X < -0.25)
							{
								this.direction = 1;
							}
							this.spriteDirection = this.direction;
							this.rotation = this.velocity.X * 0.05f;
							this.frameCounter++;
							if (this.frameCounter > 2)
							{
								this.frame++;
								this.frameCounter = 0;
							}
							if (this.frame > 3)
							{
								this.frame = 0;
								return;
							}
						}
						else if (this.type == 211)
						{
							this.ignoreWater = false;
							float num306 = 0.2f;
							float num307 = 5f;
							this.tileCollide = false;
							Vector2 vector22 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num308 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector22.X;
							float num309 = Main.player[this.owner].position.Y + Main.player[this.owner].gfxOffY + (float)(Main.player[this.owner].height / 2) - vector22.Y;
							if (Main.player[this.owner].controlLeft)
							{
								num308 -= 120f;
							}
							else if (Main.player[this.owner].controlRight)
							{
								num308 += 120f;
							}
							if (Main.player[this.owner].controlDown)
							{
								num309 += 120f;
							}
							else
							{
								if (Main.player[this.owner].controlUp)
								{
									num309 -= 120f;
								}
								num309 -= 60f;
							}
							float num310 = (float)Math.Sqrt((double)(num308 * num308 + num309 * num309));
							if (num310 > 1000f)
							{
								this.position.X = this.position.X + num308;
								this.position.Y = this.position.Y + num309;
							}
							if (this.localAI[0] == 1f)
							{
								if (num310 < 10f && Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y) < num307 && Main.player[this.owner].velocity.Y == 0f)
								{
									this.localAI[0] = 0f;
								}
								num307 = 12f;
								if (num310 < num307)
								{
									this.velocity.X = num308;
									this.velocity.Y = num309;
								}
								else
								{
									num310 = num307 / num310;
									this.velocity.X = num308 * num310;
									this.velocity.Y = num309 * num310;
								}
								if ((double)this.velocity.X > 0.5)
								{
									this.direction = -1;
								}
								else if ((double)this.velocity.X < -0.5)
								{
									this.direction = 1;
								}
								this.spriteDirection = this.direction;
								this.rotation -= (0.2f + Math.Abs(this.velocity.X) * 0.025f) * (float)this.direction;
								this.frameCounter++;
								if (this.frameCounter > 3)
								{
									this.frame++;
									this.frameCounter = 0;
								}
								if (this.frame < 5)
								{
									this.frame = 5;
								}
								if (this.frame > 9)
								{
									this.frame = 5;
								}
								for (int num311 = 0; num311 < 2; num311++)
								{
									int num312 = Dust.NewDust(new Vector2(this.position.X + 3f, this.position.Y + 4f), 14, 14, 156, 0f, 0f, 0, default(Color), 1f);
									Main.dust[num312].velocity *= 0.2f;
									Main.dust[num312].noGravity = true;
									Main.dust[num312].scale = 1.25f;
								}
								return;
							}
							if (num310 > 200f)
							{
								this.localAI[0] = 1f;
							}
							if ((double)this.velocity.X > 0.5)
							{
								this.direction = -1;
							}
							else if ((double)this.velocity.X < -0.5)
							{
								this.direction = 1;
							}
							this.spriteDirection = this.direction;
							if (num310 < 10f)
							{
								this.velocity.X = num308;
								this.velocity.Y = num309;
								this.rotation = this.velocity.X * 0.05f;
								if (num310 < num307)
								{
									this.position += this.velocity;
									this.velocity *= 0f;
									num306 = 0f;
								}
								this.direction = -Main.player[this.owner].direction;
							}
							num310 = num307 / num310;
							num308 *= num310;
							num309 *= num310;
							if (this.velocity.X < num308)
							{
								this.velocity.X = this.velocity.X + num306;
								if (this.velocity.X < 0f)
								{
									this.velocity.X = this.velocity.X * 0.99f;
								}
							}
							if (this.velocity.X > num308)
							{
								this.velocity.X = this.velocity.X - num306;
								if (this.velocity.X > 0f)
								{
									this.velocity.X = this.velocity.X * 0.99f;
								}
							}
							if (this.velocity.Y < num309)
							{
								this.velocity.Y = this.velocity.Y + num306;
								if (this.velocity.Y < 0f)
								{
									this.velocity.Y = this.velocity.Y * 0.99f;
								}
							}
							if (this.velocity.Y > num309)
							{
								this.velocity.Y = this.velocity.Y - num306;
								if (this.velocity.Y > 0f)
								{
									this.velocity.Y = this.velocity.Y * 0.99f;
								}
							}
							if (this.velocity.X != 0f || this.velocity.Y != 0f)
							{
								this.rotation = this.velocity.X * 0.05f;
							}
							this.frameCounter++;
							if (this.frameCounter > 3)
							{
								this.frame++;
								this.frameCounter = 0;
							}
							if (this.frame > 4)
							{
								this.frame = 0;
								return;
							}
						}
						else if (this.type == 199)
						{
							float num313 = 0.1f;
							this.tileCollide = false;
							int num314 = 200;
							Vector2 vector23 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num315 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector23.X;
							float num316 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector23.Y;
							num316 -= 60f;
							num315 -= 2f;
							if (this.type == 127)
							{
								num316 = Main.player[this.owner].position.Y - vector23.Y;
							}
							float num317 = (float)Math.Sqrt((double)(num315 * num315 + num316 * num316));
							float num318 = 4f;
							float num319 = num317;
							if (num317 < (float)num314 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
							{
								this.ai[0] = 0f;
								if (this.velocity.Y < -6f)
								{
									this.velocity.Y = -6f;
								}
							}
							if (num317 < 4f)
							{
								this.velocity.X = num315;
								this.velocity.Y = num316;
								num313 = 0f;
							}
							else
							{
								if (num317 > 350f)
								{
									num313 = 0.2f;
									num318 = 10f;
								}
								num317 = num318 / num317;
								num315 *= num317;
								num316 *= num317;
							}
							if (this.velocity.X < num315)
							{
								this.velocity.X = this.velocity.X + num313;
								if (this.velocity.X < 0f)
								{
									this.velocity.X = this.velocity.X + num313;
								}
							}
							if (this.velocity.X > num315)
							{
								this.velocity.X = this.velocity.X - num313;
								if (this.velocity.X > 0f)
								{
									this.velocity.X = this.velocity.X - num313;
								}
							}
							if (this.velocity.Y < num316)
							{
								this.velocity.Y = this.velocity.Y + num313;
								if (this.velocity.Y < 0f)
								{
									this.velocity.Y = this.velocity.Y + num313;
								}
							}
							if (this.velocity.Y > num316)
							{
								this.velocity.Y = this.velocity.Y - num313;
								if (this.velocity.Y > 0f)
								{
									this.velocity.Y = this.velocity.Y - num313;
								}
							}
							this.direction = -Main.player[this.owner].direction;
							this.spriteDirection = 1;
							this.rotation = this.velocity.Y * 0.05f * (float)(-(float)this.direction);
							if (num319 >= 50f)
							{
								this.frameCounter++;
								if (this.frameCounter > 6)
								{
									this.frameCounter = 0;
									if (this.velocity.X < 0f)
									{
										if (this.frame < 2)
										{
											this.frame++;
										}
										if (this.frame > 2)
										{
											this.frame--;
											return;
										}
									}
									else
									{
										if (this.frame < 6)
										{
											this.frame++;
										}
										if (this.frame > 6)
										{
											this.frame--;
											return;
										}
									}
								}
							}
							else
							{
								this.frameCounter++;
								if (this.frameCounter > 6)
								{
									this.frame += this.direction;
									this.frameCounter = 0;
								}
								if (this.frame > 7)
								{
									this.frame = 0;
								}
								if (this.frame < 0)
								{
									this.frame = 7;
									return;
								}
							}
						}
						else
						{
							if (this.ai[1] == 0f)
							{
								int num320 = 500;
								if (this.type == 127)
								{
									num320 = 200;
								}
								if (this.type == 208)
								{
									num320 = 300;
								}
								if ((this.type >= 191 && this.type <= 194) || this.type == 266)
								{
									num320 += 40 * this.minionPos;
									if (this.localAI[0] > 0f)
									{
										num320 += 500;
									}
									if (this.type == 266 && this.localAI[0] > 0f)
									{
										num320 += 100;
									}
								}
								if (Main.player[this.owner].rocketDelay2 > 0)
								{
									this.ai[0] = 1f;
								}
								Vector2 vector24 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
								float num321 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector24.X;
								if (this.type >= 191)
								{
									int arg_F268_0 = this.type;
								}
								float num322 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector24.Y;
								float num323 = (float)Math.Sqrt((double)(num321 * num321 + num322 * num322));
								if (num323 > 2000f)
								{
									this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
									this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
								}
								else if (num323 > (float)num320 || (Math.Abs(num322) > 300f && (((this.type < 191 || this.type > 194) && this.type != 266) || this.localAI[0] <= 0f)))
								{
									if (this.type != 324)
									{
										if (num322 > 0f && this.velocity.Y < 0f)
										{
											this.velocity.Y = 0f;
										}
										if (num322 < 0f && this.velocity.Y > 0f)
										{
											this.velocity.Y = 0f;
										}
									}
									this.ai[0] = 1f;
								}
							}
							if (this.type == 209 && this.ai[0] != 0f)
							{
								if (Main.player[this.owner].velocity.Y == 0f && this.alpha >= 100)
								{
									this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
									this.position.Y = Main.player[this.owner].position.Y + (float)Main.player[this.owner].height - (float)this.height;
									this.ai[0] = 0f;
									return;
								}
								this.velocity.X = 0f;
								this.velocity.Y = 0f;
								this.alpha += 5;
								if (this.alpha > 255)
								{
									this.alpha = 255;
									return;
								}
							}
							else if (this.ai[0] != 0f)
							{
								float num324 = 0.2f;
								int num325 = 200;
								if (this.type == 127)
								{
									num325 = 100;
								}
								if (this.type >= 191 && this.type <= 194)
								{
									num324 = 0.5f;
									num325 = 100;
								}
								this.tileCollide = false;
								Vector2 vector25 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
								float num326 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector25.X;
								if ((this.type >= 191 && this.type <= 194) || this.type == 266)
								{
									num326 -= (float)(40 * Main.player[this.owner].direction);
									float num327 = 600f;
									bool flag12 = false;
									for (int num328 = 0; num328 < 200; num328++)
									{
										if (Main.npc[num328].active && !Main.npc[num328].dontTakeDamage && !Main.npc[num328].friendly && Main.npc[num328].lifeMax > 5)
										{
											float num329 = Main.npc[num328].position.X + (float)(Main.npc[num328].width / 2);
											float num330 = Main.npc[num328].position.Y + (float)(Main.npc[num328].height / 2);
											float num331 = Math.Abs(Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - num329) + Math.Abs(Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - num330);
											if (num331 < num327)
											{
												flag12 = true;
												break;
											}
										}
									}
									if (!flag12)
									{
										num326 -= (float)(40 * this.minionPos * Main.player[this.owner].direction);
									}
								}
								float num332 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector25.Y;
								if (this.type == 127)
								{
									num332 = Main.player[this.owner].position.Y - vector25.Y;
								}
								float num333 = (float)Math.Sqrt((double)(num326 * num326 + num332 * num332));
								float num334 = 10f;
								float num335 = num333;
								if (this.type == 111)
								{
									num334 = 11f;
								}
								if (this.type == 127)
								{
									num334 = 9f;
								}
								if (this.type == 324)
								{
									num334 = 20f;
								}
								if (this.type >= 191 && this.type <= 194)
								{
									num324 = 0.4f;
									num334 = 12f;
									if (num334 < Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y))
									{
										num334 = Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y);
									}
								}
								if (this.type == 208 && Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y) > 4f)
								{
									num325 = -1;
								}
								if (num333 < (float)num325 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
								{
									this.ai[0] = 0f;
									if (this.velocity.Y < -6f)
									{
										this.velocity.Y = -6f;
									}
								}
								if (num333 < 60f)
								{
									num326 = this.velocity.X;
									num332 = this.velocity.Y;
								}
								else
								{
									num333 = num334 / num333;
									num326 *= num333;
									num332 *= num333;
								}
								if (this.type == 324)
								{
									if (num335 > 1000f)
									{
										if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) < (double)num334 - 1.25)
										{
											this.velocity *= 1.025f;
										}
										if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) > (double)num334 + 1.25)
										{
											this.velocity *= 0.975f;
										}
									}
									else if (num335 > 600f)
									{
										if (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) < num334 - 1f)
										{
											this.velocity *= 1.05f;
										}
										if (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > num334 + 1f)
										{
											this.velocity *= 0.95f;
										}
									}
									else if (num335 > 400f)
									{
										if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) < (double)num334 - 0.5)
										{
											this.velocity *= 1.075f;
										}
										if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) > (double)num334 + 0.5)
										{
											this.velocity *= 0.925f;
										}
									}
									else
									{
										if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) < (double)num334 - 0.25)
										{
											this.velocity *= 1.1f;
										}
										if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) > (double)num334 + 0.25)
										{
											this.velocity *= 0.9f;
										}
									}
									this.velocity.X = (this.velocity.X * 34f + num326) / 35f;
									this.velocity.Y = (this.velocity.Y * 34f + num332) / 35f;
								}
								else
								{
									if (this.velocity.X < num326)
									{
										this.velocity.X = this.velocity.X + num324;
										if (this.velocity.X < 0f)
										{
											this.velocity.X = this.velocity.X + num324 * 1.5f;
										}
									}
									if (this.velocity.X > num326)
									{
										this.velocity.X = this.velocity.X - num324;
										if (this.velocity.X > 0f)
										{
											this.velocity.X = this.velocity.X - num324 * 1.5f;
										}
									}
									if (this.velocity.Y < num332)
									{
										this.velocity.Y = this.velocity.Y + num324;
										if (this.velocity.Y < 0f)
										{
											this.velocity.Y = this.velocity.Y + num324 * 1.5f;
										}
									}
									if (this.velocity.Y > num332)
									{
										this.velocity.Y = this.velocity.Y - num324;
										if (this.velocity.Y > 0f)
										{
											this.velocity.Y = this.velocity.Y - num324 * 1.5f;
										}
									}
								}
								if (this.type == 111)
								{
									this.frame = 7;
								}
								if (this.type == 112)
								{
									this.frame = 2;
								}
								if (this.type >= 191 && this.type <= 194 && this.frame < 12)
								{
									this.frame = Main.rand.Next(12, 18);
									this.frameCounter = 0;
								}
								if (this.type != 313)
								{
									if ((double)this.velocity.X > 0.5)
									{
										this.spriteDirection = -1;
									}
									else if ((double)this.velocity.X < -0.5)
									{
										this.spriteDirection = 1;
									}
								}
								if (this.type == 112)
								{
									if (this.spriteDirection == -1)
									{
										this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
									}
									else
									{
										this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
									}
								}
								else if (this.type == 127)
								{
									this.frameCounter += 3;
									if (this.frameCounter > 6)
									{
										this.frame++;
										this.frameCounter = 0;
									}
									if (this.frame <= 5 || this.frame > 15)
									{
										this.frame = 6;
									}
									this.rotation = this.velocity.X * 0.1f;
								}
								else if (this.type == 269)
								{
									if (this.frame == 6)
									{
										this.frameCounter = 0;
									}
									else if (this.frame < 4 || this.frame > 6)
									{
										this.frameCounter = 0;
										this.frame = 4;
									}
									else
									{
										this.frameCounter++;
										if (this.frameCounter > 6)
										{
											this.frame++;
											this.frameCounter = 0;
										}
									}
									this.rotation = this.velocity.X * 0.05f;
								}
								else if (this.type == 266)
								{
									this.frameCounter++;
									if (this.frameCounter > 6)
									{
										this.frame++;
										this.frameCounter = 0;
									}
									if (this.frame < 2 || this.frame > 5)
									{
										this.frame = 2;
									}
									this.rotation = this.velocity.X * 0.1f;
								}
								else if (this.type == 324)
								{
									this.frameCounter++;
									if (this.frameCounter > 1)
									{
										this.frame++;
										this.frameCounter = 0;
									}
									if (this.frame < 6 || this.frame > 9)
									{
										this.frame = 6;
									}
									this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.58f;
									Lighting.addLight((int)this.center().X / 16, (int)this.center().Y / 16, 0.9f, 0.6f, 0.2f);
									for (int num336 = 0; num336 < 2; num336++)
									{
										int num337 = 4;
										int num338 = Dust.NewDust(new Vector2(this.center().X - (float)num337, this.center().Y - (float)num337) - this.velocity * 0f, num337 * 2, num337 * 2, 6, 0f, 0f, 100, default(Color), 1f);
										Main.dust[num338].scale *= 1.8f + (float)Main.rand.Next(10) * 0.1f;
										Main.dust[num338].velocity *= 0.2f;
										if (num336 == 1)
										{
											Main.dust[num338].position -= this.velocity * 0.5f;
										}
										Main.dust[num338].noGravity = true;
										num338 = Dust.NewDust(new Vector2(this.center().X - (float)num337, this.center().Y - (float)num337) - this.velocity * 0f, num337 * 2, num337 * 2, 31, 0f, 0f, 100, default(Color), 0.5f);
										Main.dust[num338].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
										Main.dust[num338].velocity *= 0.05f;
										if (num336 == 1)
										{
											Main.dust[num338].position -= this.velocity * 0.5f;
										}
									}
								}
								else if (this.type == 268)
								{
									this.frameCounter++;
									if (this.frameCounter > 4)
									{
										this.frame++;
										this.frameCounter = 0;
									}
									if (this.frame < 6 || this.frame > 7)
									{
										this.frame = 6;
									}
									this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.58f;
								}
								else if (this.type == 200)
								{
									this.frameCounter += 3;
									if (this.frameCounter > 6)
									{
										this.frame++;
										this.frameCounter = 0;
									}
									if (this.frame <= 5 || this.frame > 9)
									{
										this.frame = 6;
									}
									this.rotation = this.velocity.X * 0.1f;
								}
								else if (this.type == 208)
								{
									this.rotation = this.velocity.X * 0.075f;
									this.frameCounter++;
									if (this.frameCounter > 6)
									{
										this.frame++;
										this.frameCounter = 0;
									}
									if (this.frame > 4)
									{
										this.frame = 1;
									}
									if (this.frame < 1)
									{
										this.frame = 1;
									}
								}
								else if (this.type == 236)
								{
									this.rotation = this.velocity.Y * 0.05f * (float)this.direction;
									if (this.velocity.Y < 0f)
									{
										this.frameCounter += 2;
									}
									else
									{
										this.frameCounter++;
									}
									if (this.frameCounter >= 6)
									{
										this.frame++;
										this.frameCounter = 0;
									}
									if (this.frame > 12)
									{
										this.frame = 9;
									}
									if (this.frame < 9)
									{
										this.frame = 9;
									}
								}
								else if (this.type == 314)
								{
									this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.58f;
									this.frameCounter++;
									if (this.frameCounter >= 3)
									{
										this.frame++;
										this.frameCounter = 0;
									}
									if (this.frame > 12)
									{
										this.frame = 7;
									}
									if (this.frame < 7)
									{
										this.frame = 7;
									}
								}
								else if (this.type == 319)
								{
									this.rotation = this.velocity.X * 0.05f;
									this.frameCounter++;
									if (this.frameCounter >= 6)
									{
										this.frame++;
										this.frameCounter = 0;
									}
									if (this.frame > 10)
									{
										this.frame = 6;
									}
									if (this.frame < 6)
									{
										this.frame = 6;
									}
								}
								else if (this.type == 210)
								{
									this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.58f;
									this.frameCounter += 3;
									if (this.frameCounter > 6)
									{
										this.frame++;
										this.frameCounter = 0;
									}
									if (this.frame > 11)
									{
										this.frame = 7;
									}
									if (this.frame < 7)
									{
										this.frame = 7;
									}
								}
								else if (this.type == 313)
								{
									this.position.Y = this.position.Y + (float)this.height;
									this.height = 54;
									this.position.Y = this.position.Y - (float)this.height;
									this.position.X = this.position.X + (float)(this.width / 2);
									this.width = 54;
									this.position.X = this.position.X - (float)(this.width / 2);
									this.rotation += this.velocity.X * 0.01f;
									this.frameCounter = 0;
									this.frame = 11;
								}
								else if (this.spriteDirection == -1)
								{
									this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X);
								}
								else
								{
									this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 3.14f;
								}
								if (this.type >= 191 && this.type <= 194)
								{
									return;
								}
								if (this.type != 127 && this.type != 200 && this.type != 208 && this.type != 210 && this.type != 236 && this.type != 266 && this.type != 268 && this.type != 269 && this.type != 313 && this.type != 314 && this.type != 319 && this.type != 324)
								{
									int num339 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) - 4f, this.position.Y + (float)(this.height / 2) - 4f) - this.velocity, 8, 8, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.7f);
									Main.dust[num339].velocity.X = Main.dust[num339].velocity.X * 0.2f;
									Main.dust[num339].velocity.Y = Main.dust[num339].velocity.Y * 0.2f;
									Main.dust[num339].noGravity = true;
									return;
								}
							}
							else
							{
								if (this.type >= 191 && this.type <= 194)
								{
									float num340 = (float)(40 * this.minionPos);
									int num341 = 30;
									int num342 = 60;
									this.localAI[0] -= 1f;
									if (this.localAI[0] < 0f)
									{
										this.localAI[0] = 0f;
									}
									if (this.ai[1] > 0f)
									{
										this.ai[1] -= 1f;
									}
									else
									{
										float num343 = this.position.X;
										float num344 = this.position.Y;
										float num345 = 100000f;
										float num346 = num345;
										int num347 = -1;
										for (int num348 = 0; num348 < 200; num348++)
										{
											if (Main.npc[num348].active && !Main.npc[num348].dontTakeDamage && !Main.npc[num348].friendly && Main.npc[num348].lifeMax > 5)
											{
												float num349 = Main.npc[num348].position.X + (float)(Main.npc[num348].width / 2);
												float num350 = Main.npc[num348].position.Y + (float)(Main.npc[num348].height / 2);
												float num351 = Math.Abs(this.position.X + (float)(this.width / 2) - num349) + Math.Abs(this.position.Y + (float)(this.height / 2) - num350);
												if (num351 < num345)
												{
													if (num347 == -1 && num351 <= num346)
													{
														num346 = num351;
														num343 = num349;
														num344 = num350;
													}
													if (Collision.CanHit(this.position, this.width, this.height, Main.npc[num348].position, Main.npc[num348].width, Main.npc[num348].height))
													{
														num345 = num351;
														num343 = num349;
														num344 = num350;
														num347 = num348;
													}
												}
											}
										}
										if (num347 == -1 && num346 < num345)
										{
											num345 = num346;
										}
										float num352 = 400f;
										if ((double)this.position.Y > Main.worldSurface * 16.0)
										{
											num352 = 200f;
										}
										if (num345 < num352 + num340 && num347 == -1)
										{
											float num353 = num343 - (this.position.X + (float)(this.width / 2));
											if (num353 < -5f)
											{
												flag8 = true;
												flag9 = false;
											}
											else if (num353 > 5f)
											{
												flag9 = true;
												flag8 = false;
											}
										}
										else if (num347 >= 0 && num345 < 800f + num340)
										{
											this.localAI[0] = (float)num342;
											float num354 = num343 - (this.position.X + (float)(this.width / 2));
											if (num354 > 300f || num354 < -300f)
											{
												if (num354 < -50f)
												{
													flag8 = true;
													flag9 = false;
												}
												else if (num354 > 50f)
												{
													flag9 = true;
													flag8 = false;
												}
											}
											else if (this.owner == Main.myPlayer)
											{
												this.ai[1] = (float)num341;
												float num355 = 12f;
												Vector2 vector26 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)(this.height / 2) - 8f);
												float num356 = num343 - vector26.X + (float)Main.rand.Next(-20, 21);
												float num357 = Math.Abs(num356) * 0.1f;
												num357 = num357 * (float)Main.rand.Next(0, 100) * 0.001f;
												float num358 = num344 - vector26.Y + (float)Main.rand.Next(-20, 21) - num357;
												float num359 = (float)Math.Sqrt((double)(num356 * num356 + num358 * num358));
												num359 = num355 / num359;
												num356 *= num359;
												num358 *= num359;
												int num360 = this.damage;
												int num361 = 195;
												int num362 = Projectile.NewProjectile(vector26.X, vector26.Y, num356, num358, num361, num360, this.knockBack, Main.myPlayer, 0f, 0f);
												Main.projectile[num362].timeLeft = 300;
												if (num356 < 0f)
												{
													this.direction = -1;
												}
												if (num356 > 0f)
												{
													this.direction = 1;
												}
												this.netUpdate = true;
											}
										}
									}
								}
								if (this.type == 266)
								{
									float num363 = (float)(40 * this.minionPos);
									int num364 = 60;
									this.localAI[0] -= 1f;
									if (this.localAI[0] < 0f)
									{
										this.localAI[0] = 0f;
									}
									if (this.ai[1] > 0f)
									{
										this.ai[1] -= 1f;
									}
									else
									{
										float num365 = this.position.X;
										float num366 = this.position.Y;
										float num367 = 100000f;
										float num368 = num367;
										int num369 = -1;
										for (int num370 = 0; num370 < 200; num370++)
										{
											if (Main.npc[num370].active && !Main.npc[num370].dontTakeDamage && !Main.npc[num370].friendly && Main.npc[num370].lifeMax > 5)
											{
												float num371 = Main.npc[num370].position.X + (float)(Main.npc[num370].width / 2);
												float num372 = Main.npc[num370].position.Y + (float)(Main.npc[num370].height / 2);
												float num373 = Math.Abs(this.position.X + (float)(this.width / 2) - num371) + Math.Abs(this.position.Y + (float)(this.height / 2) - num372);
												if (num373 < num367)
												{
													if (num369 == -1 && num373 <= num368)
													{
														num368 = num373;
														num365 = num371;
														num366 = num372;
													}
													if (Collision.CanHit(this.position, this.width, this.height, Main.npc[num370].position, Main.npc[num370].width, Main.npc[num370].height))
													{
														num367 = num373;
														num365 = num371;
														num366 = num372;
														num369 = num370;
													}
												}
											}
										}
										if (num369 == -1 && num368 < num367)
										{
											num367 = num368;
										}
										float num374 = 300f;
										if ((double)this.position.Y > Main.worldSurface * 16.0)
										{
											num374 = 150f;
										}
										if (num367 < num374 + num363 && num369 == -1)
										{
											float num375 = num365 - (this.position.X + (float)(this.width / 2));
											if (num375 < -5f)
											{
												flag8 = true;
												flag9 = false;
											}
											else if (num375 > 5f)
											{
												flag9 = true;
												flag8 = false;
											}
										}
										if (num369 >= 0 && num367 < 800f + num363)
										{
											this.friendly = true;
											this.localAI[0] = (float)num364;
											float num376 = num365 - (this.position.X + (float)(this.width / 2));
											if (num376 < -10f)
											{
												flag8 = true;
												flag9 = false;
											}
											else if (num376 > 10f)
											{
												flag9 = true;
												flag8 = false;
											}
											if (num366 < this.center().Y - 100f && num376 > -50f && num376 < 50f && this.velocity.Y == 0f)
											{
												float num377 = Math.Abs(num366 - this.center().Y);
												if (num377 < 120f)
												{
													this.velocity.Y = -10f;
												}
												else if (num377 < 210f)
												{
													this.velocity.Y = -13f;
												}
												else if (num377 < 270f)
												{
													this.velocity.Y = -15f;
												}
												else if (num377 < 310f)
												{
													this.velocity.Y = -17f;
												}
												else if (num377 < 380f)
												{
													this.velocity.Y = -18f;
												}
											}
										}
										else
										{
											this.friendly = false;
										}
									}
								}
								if (this.ai[1] != 0f)
								{
									flag8 = false;
									flag9 = false;
								}
								else if (this.type >= 191 && this.type <= 195 && this.localAI[0] == 0f)
								{
									this.direction = Main.player[this.owner].direction;
								}
								if (this.type == 127)
								{
									if ((double)this.rotation > -0.1 && (double)this.rotation < 0.1)
									{
										this.rotation = 0f;
									}
									else if (this.rotation < 0f)
									{
										this.rotation += 0.1f;
									}
									else
									{
										this.rotation -= 0.1f;
									}
								}
								else if (this.type != 313)
								{
									this.rotation = 0f;
								}
								this.tileCollide = true;
								float num378 = 0.08f;
								float num379 = 6.5f;
								if (this.type == 127)
								{
									num379 = 2f;
									num378 = 0.04f;
								}
								if (this.type == 112)
								{
									num379 = 6f;
									num378 = 0.06f;
								}
								if (this.type == 268)
								{
									num379 = 8f;
									num378 = 0.4f;
								}
								if (this.type == 324)
								{
									num378 = 0.1f;
									num379 = 3f;
								}
								if ((this.type >= 191 && this.type <= 194) || this.type == 266)
								{
									num379 = 6f;
									num378 = 0.2f;
									if (num379 < Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y))
									{
										num379 = Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y);
										num378 = 0.3f;
									}
								}
								if (flag8)
								{
									if ((double)this.velocity.X > -3.5)
									{
										this.velocity.X = this.velocity.X - num378;
									}
									else
									{
										this.velocity.X = this.velocity.X - num378 * 0.25f;
									}
								}
								else if (flag9)
								{
									if ((double)this.velocity.X < 3.5)
									{
										this.velocity.X = this.velocity.X + num378;
									}
									else
									{
										this.velocity.X = this.velocity.X + num378 * 0.25f;
									}
								}
								else
								{
									this.velocity.X = this.velocity.X * 0.9f;
									if (this.velocity.X >= -num378 && this.velocity.X <= num378)
									{
										this.velocity.X = 0f;
									}
								}
								if (this.type == 208)
								{
									this.velocity.X = this.velocity.X * 0.95f;
									if ((double)this.velocity.X > -0.1 && (double)this.velocity.X < 0.1)
									{
										this.velocity.X = 0f;
									}
									flag8 = false;
									flag9 = false;
								}
								if (flag8 || flag9)
								{
									int num380 = (int)(this.position.X + (float)(this.width / 2)) / 16;
									int j2 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
									if (this.type == 236)
									{
										num380 += this.direction;
									}
									if (flag8)
									{
										num380--;
									}
									if (flag9)
									{
										num380++;
									}
									num380 += (int)this.velocity.X;
									if (WorldGen.SolidTile(num380, j2))
									{
										flag11 = true;
									}
								}
								if (Main.player[this.owner].position.Y + (float)Main.player[this.owner].height - 8f > this.position.Y + (float)this.height)
								{
									flag10 = true;
								}
								if (this.type == 268 && this.frameCounter < 10)
								{
									flag11 = false;
								}
								if (this.velocity.Y >= 0f)
								{
									int num381 = 0;
									if (this.velocity.X < 0f)
									{
										num381 = -1;
									}
									if (this.velocity.X > 0f)
									{
										num381 = 1;
									}
									Vector2 vector27 = this.position;
									vector27.X += this.velocity.X;
									int num382 = (int)((vector27.X + (float)(this.width / 2) + (float)((this.width / 2 + 1) * num381)) / 16f);
									int num383 = (int)((vector27.Y + (float)this.height - 1f) / 16f);
									bool flag13 = false;
									if (Main.tile[num382, num383] == null)
									{
										Main.tile[num382, num383] = new Tile();
									}
									if (num383 - 1 > 0 && Main.tile[num382, num383 - 1] == null)
									{
										Main.tile[num382, num383 - 1] = new Tile();
									}
									if (num383 - 2 > 0 && Main.tile[num382, num383 - 2] == null)
									{
										Main.tile[num382, num383 - 2] = new Tile();
									}
									if (num383 - 3 > 0 && Main.tile[num382, num383 - 3] == null)
									{
										Main.tile[num382, num383 - 3] = new Tile();
									}
									if (num383 - 4 > 0 && Main.tile[num382, num383 - 4] == null)
									{
										Main.tile[num382, num383 - 4] = new Tile();
									}
									if (num383 - 3 > 0 && Main.tile[num382 - num381, num383 - 3] == null)
									{
										Main.tile[num382 - num381, num383 - 3] = new Tile();
									}
									if ((float)(num382 * 16) < vector27.X + (float)this.width && (float)(num382 * 16 + 16) > vector27.X && ((Main.tile[num382, num383].nactive() && (Main.tile[num382, num383].slope() == 0 || (Main.tile[num382, num383].slope() == 1 && this.position.X + (float)(this.width / 2) < (float)(num382 * 16)) || (Main.tile[num382, num383].slope() == 2 && this.position.X + (float)(this.width / 2) > (float)(num382 * 16 + 16))) && (Main.tile[num382, num383 - 1].slope() == 0 || this.position.Y + (float)this.height > (float)(num383 * 16)) && ((Main.tileSolid[(int)Main.tile[num382, num383].type] && !Main.tileSolidTop[(int)Main.tile[num382, num383].type]) || (flag13 && Main.tileSolidTop[(int)Main.tile[num382, num383].type] && Main.tile[num382, num383].frameY == 0 && (!Main.tileSolid[(int)Main.tile[num382, num383 - 1].type] || !Main.tile[num382, num383 - 1].nactive())))) || (Main.tile[num382, num383 - 1].halfBrick() && Main.tile[num382, num383 - 1].nactive())) && (!Main.tile[num382, num383 - 1].nactive() || !Main.tileSolid[(int)Main.tile[num382, num383 - 1].type] || Main.tileSolidTop[(int)Main.tile[num382, num383 - 1].type] || Main.tile[num382, num383 - 1].slope() != 0 || (Main.tile[num382, num383 - 1].halfBrick() && (!Main.tile[num382, num383 - 4].nactive() || !Main.tileSolid[(int)Main.tile[num382, num383 - 4].type] || Main.tileSolidTop[(int)Main.tile[num382, num383 - 4].type]))) && (!Main.tile[num382, num383 - 2].nactive() || !Main.tileSolid[(int)Main.tile[num382, num383 - 2].type] || Main.tileSolidTop[(int)Main.tile[num382, num383 - 2].type]) && (!Main.tile[num382, num383 - 3].nactive() || !Main.tileSolid[(int)Main.tile[num382, num383 - 3].type] || Main.tileSolidTop[(int)Main.tile[num382, num383 - 3].type]) && (!Main.tile[num382 - num381, num383 - 3].nactive() || !Main.tileSolid[(int)Main.tile[num382 - num381, num383 - 3].type] || Main.tileSolidTop[(int)Main.tile[num382 - num381, num383 - 3].type]))
									{
										float num384 = (float)(num383 * 16);
										if (Main.tile[num382, num383].halfBrick())
										{
											num384 += 8f;
										}
										if (Main.tile[num382, num383 - 1].halfBrick())
										{
											num384 -= 8f;
										}
										if (num384 < vector27.Y + (float)this.height)
										{
											float num385 = vector27.Y + (float)this.height - num384;
											if ((double)num385 <= 16.1)
											{
												this.gfxOffY += this.position.Y + (float)this.height - num384;
												this.position.Y = num384 - (float)this.height;
												if (num385 < 9f)
												{
													this.stepSpeed = 1f;
												}
												else
												{
													this.stepSpeed = 2f;
												}
											}
										}
									}
								}
								if (this.velocity.Y == 0f || this.type == 200)
								{
									if (!flag10 && (this.velocity.X < 0f || this.velocity.X > 0f))
									{
										int num386 = (int)(this.position.X + (float)(this.width / 2)) / 16;
										int j3 = (int)(this.position.Y + (float)(this.height / 2)) / 16 + 1;
										if (flag8)
										{
											num386--;
										}
										if (flag9)
										{
											num386++;
										}
										WorldGen.SolidTile(num386, j3);
									}
									if (flag11)
									{
										int num387 = (int)(this.position.X + (float)(this.width / 2)) / 16;
										int num388 = (int)(this.position.Y + (float)this.height) / 16 + 1;
										if (WorldGen.SolidTile(num387, num388) || Main.tile[num387, num388].halfBrick() || Main.tile[num387, num388].slope() > 0 || this.type == 200)
										{
											if (this.type == 200)
											{
												this.velocity.Y = -3.1f;
											}
											else
											{
												try
												{
													num387 = (int)(this.position.X + (float)(this.width / 2)) / 16;
													num388 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
													if (flag8)
													{
														num387--;
													}
													if (flag9)
													{
														num387++;
													}
													num387 += (int)this.velocity.X;
													if (!WorldGen.SolidTile(num387, num388 - 1) && !WorldGen.SolidTile(num387, num388 - 2))
													{
														this.velocity.Y = -5.1f;
													}
													else if (!WorldGen.SolidTile(num387, num388 - 2))
													{
														this.velocity.Y = -7.1f;
													}
													else if (WorldGen.SolidTile(num387, num388 - 5))
													{
														this.velocity.Y = -11.1f;
													}
													else if (WorldGen.SolidTile(num387, num388 - 4))
													{
														this.velocity.Y = -10.1f;
													}
													else
													{
														this.velocity.Y = -9.1f;
													}
												}
												catch
												{
													this.velocity.Y = -9.1f;
												}
											}
											if (this.type == 127)
											{
												this.ai[0] = 1f;
											}
										}
									}
									else if (this.type == 266 && (flag8 || flag9))
									{
										this.velocity.Y = this.velocity.Y - 6f;
									}
								}
								if (this.velocity.X > num379)
								{
									this.velocity.X = num379;
								}
								if (this.velocity.X < -num379)
								{
									this.velocity.X = -num379;
								}
								if (this.velocity.X < 0f)
								{
									this.direction = -1;
								}
								if (this.velocity.X > 0f)
								{
									this.direction = 1;
								}
								if (this.velocity.X > num378 && flag9)
								{
									this.direction = 1;
								}
								if (this.velocity.X < -num378 && flag8)
								{
									this.direction = -1;
								}
								if (this.type != 313)
								{
									if (this.direction == -1)
									{
										this.spriteDirection = 1;
									}
									if (this.direction == 1)
									{
										this.spriteDirection = -1;
									}
								}
								if (this.type >= 191 && this.type <= 194)
								{
									if (this.ai[1] > 0f)
									{
										if (this.localAI[1] == 0f)
										{
											this.localAI[1] = 1f;
											this.frame = 1;
										}
										if (this.frame != 0)
										{
											this.frameCounter++;
											if (this.frameCounter > 4)
											{
												this.frame++;
												this.frameCounter = 0;
											}
											if (this.frame == 4)
											{
												this.frame = 0;
											}
										}
									}
									else if (this.velocity.Y == 0f)
									{
										this.localAI[1] = 0f;
										if (this.velocity.X == 0f)
										{
											this.frame = 0;
											this.frameCounter = 0;
										}
										else if ((double)this.velocity.X < -0.8 || (double)this.velocity.X > 0.8)
										{
											this.frameCounter += (int)Math.Abs(this.velocity.X);
											this.frameCounter++;
											if (this.frameCounter > 6)
											{
												this.frame++;
												this.frameCounter = 0;
											}
											if (this.frame < 5)
											{
												this.frame = 5;
											}
											if (this.frame >= 11)
											{
												this.frame = 5;
											}
										}
										else
										{
											this.frame = 0;
											this.frameCounter = 0;
										}
									}
									else if (this.velocity.Y < 0f)
									{
										this.frameCounter = 0;
										this.frame = 4;
									}
									else if (this.velocity.Y > 0f)
									{
										this.frameCounter = 0;
										this.frame = 4;
									}
									this.velocity.Y = this.velocity.Y + 0.4f;
									if (this.velocity.Y > 10f)
									{
										this.velocity.Y = 10f;
										return;
									}
								}
								else if (this.type == 268)
								{
									if (this.velocity.Y == 0f)
									{
										if (this.frame > 5)
										{
											this.frameCounter = 0;
										}
										if (this.velocity.X == 0f)
										{
											int num389 = 3;
											this.frameCounter++;
											if (this.frameCounter < num389)
											{
												this.frame = 0;
											}
											else if (this.frameCounter < num389 * 2)
											{
												this.frame = 1;
											}
											else if (this.frameCounter < num389 * 3)
											{
												this.frame = 2;
											}
											else if (this.frameCounter < num389 * 4)
											{
												this.frame = 3;
											}
											else
											{
												this.frameCounter = num389 * 4;
											}
										}
										else
										{
											this.velocity.X = this.velocity.X * 0.8f;
											this.frameCounter++;
											int num390 = 3;
											if (this.frameCounter < num390)
											{
												this.frame = 0;
											}
											else if (this.frameCounter < num390 * 2)
											{
												this.frame = 1;
											}
											else if (this.frameCounter < num390 * 3)
											{
												this.frame = 2;
											}
											else if (this.frameCounter < num390 * 4)
											{
												this.frame = 3;
											}
											else if (flag8 || flag9)
											{
												this.velocity.X = this.velocity.X * 2f;
												this.frame = 4;
												this.velocity.Y = -6.1f;
												this.frameCounter = 0;
												for (int num391 = 0; num391 < 4; num391++)
												{
													int num392 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), this.width, 4, 5, 0f, 0f, 0, default(Color), 1f);
													Main.dust[num392].velocity += this.velocity;
													Main.dust[num392].velocity *= 0.4f;
												}
											}
											else
											{
												this.frameCounter = num390 * 4;
											}
										}
									}
									else if (this.velocity.Y < 0f)
									{
										this.frameCounter = 0;
										this.frame = 5;
									}
									else
									{
										this.frame = 4;
										this.frameCounter = 3;
									}
									this.velocity.Y = this.velocity.Y + 0.4f;
									if (this.velocity.Y > 10f)
									{
										this.velocity.Y = 10f;
										return;
									}
								}
								else if (this.type == 269)
								{
									if (this.velocity.Y >= 0f && (double)this.velocity.Y <= 0.8)
									{
										if (this.velocity.X == 0f)
										{
											this.frame = 0;
											this.frameCounter = 0;
										}
										else if ((double)this.velocity.X < -0.8 || (double)this.velocity.X > 0.8)
										{
											int num393 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), this.width, 6, 76, 0f, 0f, 0, default(Color), 1f);
											Main.dust[num393].noGravity = true;
											Main.dust[num393].velocity *= 0.3f;
											Main.dust[num393].noLight = true;
											this.frameCounter += (int)Math.Abs(this.velocity.X);
											this.frameCounter++;
											if (this.frameCounter > 6)
											{
												this.frame++;
												this.frameCounter = 0;
											}
											if (this.frame > 3)
											{
												this.frame = 0;
											}
										}
										else
										{
											this.frame = 0;
											this.frameCounter = 0;
										}
									}
									else
									{
										this.frameCounter = 0;
										this.frame = 2;
									}
									this.velocity.Y = this.velocity.Y + 0.4f;
									if (this.velocity.Y > 10f)
									{
										this.velocity.Y = 10f;
										return;
									}
								}
								else if (this.type == 313)
								{
									int num394 = (int)(this.center().X / 16f);
									int num395 = (int)(this.center().Y / 16f);
									if (Main.tile[num394, num395] != null && Main.tile[num394, num395].wall > 0)
									{
										this.position.Y = this.position.Y + (float)this.height;
										this.height = 34;
										this.position.Y = this.position.Y - (float)this.height;
										this.position.X = this.position.X + (float)(this.width / 2);
										this.width = 34;
										this.position.X = this.position.X - (float)(this.width / 2);
										float num396 = 4f;
										Vector2 vector28 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
										float num397 = Main.player[this.owner].center().X - vector28.X;
										float num398 = Main.player[this.owner].center().Y - vector28.Y;
										float num399 = (float)Math.Sqrt((double)(num397 * num397 + num398 * num398));
										float num400 = num396 / num399;
										num397 *= num400;
										num398 *= num400;
										if (num399 < 120f)
										{
											this.velocity.X = this.velocity.X * 0.9f;
											this.velocity.Y = this.velocity.Y * 0.9f;
											if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) < 0.1)
											{
												this.velocity *= 0f;
											}
										}
										else
										{
											this.velocity.X = (this.velocity.X * 9f + num397) / 10f;
											this.velocity.Y = (this.velocity.Y * 9f + num398) / 10f;
										}
										if (num399 >= 120f)
										{
											this.spriteDirection = this.direction;
											this.rotation = (float)Math.Atan2((double)(this.velocity.Y * (float)(-(float)this.direction)), (double)(this.velocity.X * (float)(-(float)this.direction)));
										}
										this.frameCounter += (int)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y));
										if (this.frameCounter > 6)
										{
											this.frame++;
											this.frameCounter = 0;
										}
										if (this.frame > 10)
										{
											this.frame = 5;
										}
										if (this.frame < 5)
										{
											this.frame = 10;
											return;
										}
									}
									else
									{
										this.rotation = 0f;
										if (this.direction == -1)
										{
											this.spriteDirection = 1;
										}
										if (this.direction == 1)
										{
											this.spriteDirection = -1;
										}
										this.position.Y = this.position.Y + (float)this.height;
										this.height = 30;
										this.position.Y = this.position.Y - (float)this.height;
										this.position.X = this.position.X + (float)(this.width / 2);
										this.width = 30;
										this.position.X = this.position.X - (float)(this.width / 2);
										if (this.velocity.Y >= 0f && (double)this.velocity.Y <= 0.8)
										{
											if (this.velocity.X == 0f)
											{
												this.frame = 0;
												this.frameCounter = 0;
											}
											else if ((double)this.velocity.X < -0.8 || (double)this.velocity.X > 0.8)
											{
												this.frameCounter += (int)Math.Abs(this.velocity.X);
												this.frameCounter++;
												if (this.frameCounter > 6)
												{
													this.frame++;
													this.frameCounter = 0;
												}
												if (this.frame > 3)
												{
													this.frame = 0;
												}
											}
											else
											{
												this.frame = 0;
												this.frameCounter = 0;
											}
										}
										else
										{
											this.frameCounter = 0;
											this.frame = 4;
										}
										this.velocity.Y = this.velocity.Y + 0.4f;
										if (this.velocity.Y > 10f)
										{
											this.velocity.Y = 10f;
											return;
										}
									}
								}
								else if (this.type == 314)
								{
									if (this.velocity.Y >= 0f && (double)this.velocity.Y <= 0.8)
									{
										if (this.velocity.X == 0f)
										{
											this.frame = 0;
											this.frameCounter = 0;
										}
										else if ((double)this.velocity.X < -0.8 || (double)this.velocity.X > 0.8)
										{
											this.frameCounter += (int)Math.Abs(this.velocity.X);
											this.frameCounter++;
											if (this.frameCounter > 6)
											{
												this.frame++;
												this.frameCounter = 0;
											}
											if (this.frame > 6)
											{
												this.frame = 1;
											}
										}
										else
										{
											this.frame = 0;
											this.frameCounter = 0;
										}
									}
									else
									{
										this.frameCounter = 0;
										this.frame = 7;
									}
									this.velocity.Y = this.velocity.Y + 0.4f;
									if (this.velocity.Y > 10f)
									{
										this.velocity.Y = 10f;
										return;
									}
								}
								else if (this.type == 319)
								{
									if (this.velocity.Y >= 0f && (double)this.velocity.Y <= 0.8)
									{
										if (this.velocity.X == 0f)
										{
											this.frame = 0;
											this.frameCounter = 0;
										}
										else if ((double)this.velocity.X < -0.8 || (double)this.velocity.X > 0.8)
										{
											this.frameCounter += (int)Math.Abs(this.velocity.X);
											this.frameCounter++;
											if (this.frameCounter > 8)
											{
												this.frame++;
												this.frameCounter = 0;
											}
											if (this.frame > 5)
											{
												this.frame = 2;
											}
										}
										else
										{
											this.frame = 0;
											this.frameCounter = 0;
										}
									}
									else
									{
										this.frameCounter = 0;
										this.frame = 1;
									}
									this.velocity.Y = this.velocity.Y + 0.4f;
									if (this.velocity.Y > 10f)
									{
										this.velocity.Y = 10f;
										return;
									}
								}
								else if (this.type == 236)
								{
									if (this.velocity.Y >= 0f && (double)this.velocity.Y <= 0.8)
									{
										if (this.velocity.X == 0f)
										{
											this.frame = 0;
											this.frameCounter = 0;
										}
										else if ((double)this.velocity.X < -0.8 || (double)this.velocity.X > 0.8)
										{
											if (this.frame < 2)
											{
												this.frame = 2;
											}
											this.frameCounter += (int)Math.Abs(this.velocity.X);
											this.frameCounter++;
											if (this.frameCounter > 6)
											{
												this.frame++;
												this.frameCounter = 0;
											}
											if (this.frame > 8)
											{
												this.frame = 2;
											}
										}
										else
										{
											this.frame = 0;
											this.frameCounter = 0;
										}
									}
									else
									{
										this.frameCounter = 0;
										this.frame = 1;
									}
									this.velocity.Y = this.velocity.Y + 0.4f;
									if (this.velocity.Y > 10f)
									{
										this.velocity.Y = 10f;
										return;
									}
								}
								else if (this.type == 266)
								{
									if (this.velocity.Y >= 0f && (double)this.velocity.Y <= 0.8)
									{
										if (this.velocity.X == 0f)
										{
											this.frameCounter++;
										}
										else
										{
											this.frameCounter += 3;
										}
									}
									else
									{
										this.frameCounter += 5;
									}
									if (this.frameCounter >= 20)
									{
										this.frameCounter -= 20;
										this.frame++;
									}
									if (this.frame > 1)
									{
										this.frame = 0;
									}
									if (this.wet && Main.player[this.owner].position.Y + (float)Main.player[this.owner].height < this.position.Y + (float)this.height && this.localAI[0] == 0f)
									{
										if (this.velocity.Y > -4f)
										{
											this.velocity.Y = this.velocity.Y - 0.2f;
										}
										if (this.velocity.Y > 0f)
										{
											this.velocity.Y = this.velocity.Y * 0.95f;
										}
									}
									else
									{
										this.velocity.Y = this.velocity.Y + 0.4f;
									}
									if (this.velocity.Y > 10f)
									{
										this.velocity.Y = 10f;
										return;
									}
								}
								else if (this.type == 111)
								{
									if (this.velocity.Y == 0f)
									{
										if (this.velocity.X == 0f)
										{
											this.frame = 0;
											this.frameCounter = 0;
										}
										else if ((double)this.velocity.X < -0.8 || (double)this.velocity.X > 0.8)
										{
											this.frameCounter += (int)Math.Abs(this.velocity.X);
											this.frameCounter++;
											if (this.frameCounter > 6)
											{
												this.frame++;
												this.frameCounter = 0;
											}
											if (this.frame >= 7)
											{
												this.frame = 0;
											}
										}
										else
										{
											this.frame = 0;
											this.frameCounter = 0;
										}
									}
									else if (this.velocity.Y < 0f)
									{
										this.frameCounter = 0;
										this.frame = 4;
									}
									else if (this.velocity.Y > 0f)
									{
										this.frameCounter = 0;
										this.frame = 6;
									}
									this.velocity.Y = this.velocity.Y + 0.4f;
									if (this.velocity.Y > 10f)
									{
										this.velocity.Y = 10f;
										return;
									}
								}
								else if (this.type == 112)
								{
									if (this.velocity.Y == 0f)
									{
										if (this.velocity.X == 0f)
										{
											this.frame = 0;
											this.frameCounter = 0;
										}
										else if ((double)this.velocity.X < -0.8 || (double)this.velocity.X > 0.8)
										{
											this.frameCounter += (int)Math.Abs(this.velocity.X);
											this.frameCounter++;
											if (this.frameCounter > 6)
											{
												this.frame++;
												this.frameCounter = 0;
											}
											if (this.frame >= 3)
											{
												this.frame = 0;
											}
										}
										else
										{
											this.frame = 0;
											this.frameCounter = 0;
										}
									}
									else if (this.velocity.Y < 0f)
									{
										this.frameCounter = 0;
										this.frame = 2;
									}
									else if (this.velocity.Y > 0f)
									{
										this.frameCounter = 0;
										this.frame = 2;
									}
									this.velocity.Y = this.velocity.Y + 0.4f;
									if (this.velocity.Y > 10f)
									{
										this.velocity.Y = 10f;
										return;
									}
								}
								else if (this.type == 127)
								{
									if (this.velocity.Y == 0f)
									{
										if (this.velocity.X == 0f)
										{
											this.frame = 0;
											this.frameCounter = 0;
										}
										else if ((double)this.velocity.X < -0.1 || (double)this.velocity.X > 0.1)
										{
											this.frameCounter += (int)Math.Abs(this.velocity.X);
											this.frameCounter++;
											if (this.frameCounter > 6)
											{
												this.frame++;
												this.frameCounter = 0;
											}
											if (this.frame > 5)
											{
												this.frame = 0;
											}
										}
										else
										{
											this.frame = 0;
											this.frameCounter = 0;
										}
									}
									else
									{
										this.frame = 0;
										this.frameCounter = 0;
									}
									this.velocity.Y = this.velocity.Y + 0.4f;
									if (this.velocity.Y > 10f)
									{
										this.velocity.Y = 10f;
										return;
									}
								}
								else if (this.type == 200)
								{
									if (this.velocity.Y == 0f)
									{
										if (this.velocity.X == 0f)
										{
											this.frame = 0;
											this.frameCounter = 0;
										}
										else if ((double)this.velocity.X < -0.1 || (double)this.velocity.X > 0.1)
										{
											this.frameCounter += (int)Math.Abs(this.velocity.X);
											this.frameCounter++;
											if (this.frameCounter > 6)
											{
												this.frame++;
												this.frameCounter = 0;
											}
											if (this.frame > 5)
											{
												this.frame = 0;
											}
										}
										else
										{
											this.frame = 0;
											this.frameCounter = 0;
										}
									}
									else
									{
										this.rotation = this.velocity.X * 0.1f;
										this.frameCounter++;
										if (this.velocity.Y < 0f)
										{
											this.frameCounter += 2;
										}
										if (this.frameCounter > 6)
										{
											this.frame++;
											this.frameCounter = 0;
										}
										if (this.frame > 9)
										{
											this.frame = 6;
										}
										if (this.frame < 6)
										{
											this.frame = 6;
										}
									}
									this.velocity.Y = this.velocity.Y + 0.1f;
									if (this.velocity.Y > 4f)
									{
										this.velocity.Y = 4f;
										return;
									}
								}
								else if (this.type == 208)
								{
									if (this.velocity.Y == 0f && this.velocity.X == 0f)
									{
										if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) < this.position.X + (float)(this.width / 2))
										{
											this.direction = -1;
										}
										else if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) > this.position.X + (float)(this.width / 2))
										{
											this.direction = 1;
										}
										this.rotation = 0f;
										this.frame = 0;
									}
									else
									{
										this.rotation = this.velocity.X * 0.075f;
										this.frameCounter++;
										if (this.frameCounter > 6)
										{
											this.frame++;
											this.frameCounter = 0;
										}
										if (this.frame > 4)
										{
											this.frame = 1;
										}
										if (this.frame < 1)
										{
											this.frame = 1;
										}
									}
									this.velocity.Y = this.velocity.Y + 0.1f;
									if (this.velocity.Y > 4f)
									{
										this.velocity.Y = 4f;
										return;
									}
								}
								else if (this.type == 209)
								{
									if (this.alpha > 0)
									{
										this.alpha -= 5;
										if (this.alpha < 0)
										{
											this.alpha = 0;
										}
									}
									if (this.velocity.Y == 0f)
									{
										if (this.velocity.X == 0f)
										{
											this.frame = 0;
											this.frameCounter = 0;
										}
										else if ((double)this.velocity.X < -0.1 || (double)this.velocity.X > 0.1)
										{
											this.frameCounter += (int)Math.Abs(this.velocity.X);
											this.frameCounter++;
											if (this.frameCounter > 6)
											{
												this.frame++;
												this.frameCounter = 0;
											}
											if (this.frame > 11)
											{
												this.frame = 2;
											}
											if (this.frame < 2)
											{
												this.frame = 2;
											}
										}
										else
										{
											this.frame = 0;
											this.frameCounter = 0;
										}
									}
									else
									{
										this.frame = 1;
										this.frameCounter = 0;
										this.rotation = 0f;
									}
									this.velocity.Y = this.velocity.Y + 0.4f;
									if (this.velocity.Y > 10f)
									{
										this.velocity.Y = 10f;
										return;
									}
								}
								else if (this.type == 324)
								{
									if (this.velocity.Y == 0f)
									{
										if ((double)this.velocity.X < -0.1 || (double)this.velocity.X > 0.1)
										{
											this.frameCounter += (int)Math.Abs(this.velocity.X);
											this.frameCounter++;
											if (this.frameCounter > 6)
											{
												this.frame++;
												this.frameCounter = 0;
											}
											if (this.frame > 5)
											{
												this.frame = 2;
											}
											if (this.frame < 2)
											{
												this.frame = 2;
											}
										}
										else
										{
											this.frame = 0;
											this.frameCounter = 0;
										}
									}
									else
									{
										this.frameCounter = 0;
										this.frame = 1;
									}
									this.velocity.Y = this.velocity.Y + 0.4f;
									if (this.velocity.Y > 14f)
									{
										this.velocity.Y = 14f;
										return;
									}
								}
								else if (this.type == 210)
								{
									if (this.velocity.Y == 0f)
									{
										if ((double)this.velocity.X < -0.1 || (double)this.velocity.X > 0.1)
										{
											this.frameCounter += (int)Math.Abs(this.velocity.X);
											this.frameCounter++;
											if (this.frameCounter > 6)
											{
												this.frame++;
												this.frameCounter = 0;
											}
											if (this.frame > 6)
											{
												this.frame = 0;
											}
										}
										else
										{
											this.frame = 0;
											this.frameCounter = 0;
										}
									}
									else
									{
										this.rotation = this.velocity.X * 0.05f;
										this.frameCounter++;
										if (this.frameCounter > 6)
										{
											this.frame++;
											this.frameCounter = 0;
										}
										if (this.frame > 11)
										{
											this.frame = 7;
										}
										if (this.frame < 7)
										{
											this.frame = 7;
										}
									}
									this.velocity.Y = this.velocity.Y + 0.4f;
									if (this.velocity.Y > 10f)
									{
										this.velocity.Y = 10f;
										return;
									}
								}
							}
						}
					}
					else if (this.aiStyle == 27)
					{
						if (this.type == 115)
						{
							this.ai[0] += 1f;
							if (this.ai[0] < 30f)
							{
								this.velocity *= 1.125f;
							}
						}
						if (this.type == 115 && this.localAI[1] < 5f)
						{
							this.localAI[1] = 5f;
							for (int num401 = 5; num401 < 25; num401++)
							{
								float num402 = this.velocity.X * (30f / (float)num401);
								float num403 = this.velocity.Y * (30f / (float)num401);
								num402 *= 80f;
								num403 *= 80f;
								int num404 = Dust.NewDust(new Vector2(this.position.X - num402, this.position.Y - num403), 8, 8, 27, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 0.9f);
								Main.dust[num404].velocity *= 0.25f;
								Main.dust[num404].velocity -= this.velocity * 5f;
							}
						}
						if (this.localAI[1] > 7f && this.type == 173)
						{
							int num405 = Main.rand.Next(3);
							if (num405 == 0)
							{
								num405 = 15;
							}
							else if (num405 == 1)
							{
								num405 = 57;
							}
							else
							{
								num405 = 58;
							}
							int num406 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 4f + 2f, this.position.Y + 2f - this.velocity.Y * 4f), 8, 8, num405, 0f, 0f, 100, default(Color), 1.25f);
							Main.dust[num406].velocity *= 0.1f;
						}
						if (this.localAI[1] > 7f && this.type == 132)
						{
							int num407 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 4f + 2f, this.position.Y + 2f - this.velocity.Y * 4f), 8, 8, 107, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.25f);
							Main.dust[num407].velocity *= -0.25f;
							num407 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 4f + 2f, this.position.Y + 2f - this.velocity.Y * 4f), 8, 8, 107, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.25f);
							Main.dust[num407].velocity *= -0.25f;
							Main.dust[num407].position -= this.velocity * 0.5f;
						}
						if (this.localAI[1] < 15f)
						{
							this.localAI[1] += 1f;
						}
						else
						{
							if (this.type == 114 || this.type == 115)
							{
								int num408 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 4f), 8, 8, 27, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 0.6f);
								Main.dust[num408].velocity *= -0.25f;
							}
							else if (this.type == 116)
							{
								int num409 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 5f + 2f, this.position.Y + 2f - this.velocity.Y * 5f), 8, 8, 64, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.5f);
								Main.dust[num409].velocity *= -0.25f;
								Main.dust[num409].noGravity = true;
							}
							if (this.localAI[0] == 0f)
							{
								this.scale -= 0.02f;
								this.alpha += 30;
								if (this.alpha >= 250)
								{
									this.alpha = 255;
									this.localAI[0] = 1f;
								}
							}
							else if (this.localAI[0] == 1f)
							{
								this.scale += 0.02f;
								this.alpha -= 30;
								if (this.alpha <= 0)
								{
									this.alpha = 0;
									this.localAI[0] = 0f;
								}
							}
						}
						if (this.ai[1] == 0f)
						{
							this.ai[1] = 1f;
							Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
						}
						if (this.type == 157)
						{
							this.rotation += (float)this.direction * 0.4f;
							this.spriteDirection = this.direction;
						}
						else
						{
							this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 0.785f;
						}
						if (this.velocity.Y > 16f)
						{
							this.velocity.Y = 16f;
							return;
						}
					}
					else if (this.aiStyle == 28)
					{
						if (this.type == 177)
						{
							for (int num410 = 0; num410 < 3; num410++)
							{
								int num411 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 137, this.velocity.X, this.velocity.Y, Main.rand.Next(0, 101), default(Color), 1f + (float)Main.rand.Next(-20, 40) * 0.01f);
								Main.dust[num411].noGravity = true;
								Main.dust[num411].velocity *= 0.3f;
							}
						}
						if (this.type == 118)
						{
							for (int num412 = 0; num412 < 2; num412++)
							{
								int num413 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 92, this.velocity.X, this.velocity.Y, 50, default(Color), 1.2f);
								Main.dust[num413].noGravity = true;
								Main.dust[num413].velocity *= 0.3f;
							}
						}
						if (this.type == 119 || this.type == 128)
						{
							for (int num414 = 0; num414 < 3; num414++)
							{
								int num415 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 92, this.velocity.X, this.velocity.Y, 50, default(Color), 1.2f);
								Main.dust[num415].noGravity = true;
								Main.dust[num415].velocity *= 0.3f;
							}
						}
						if (this.type == 309)
						{
							for (int num416 = 0; num416 < 3; num416++)
							{
								int num417 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 185, this.velocity.X, this.velocity.Y, 50, default(Color), 1.2f);
								Main.dust[num417].noGravity = true;
								Main.dust[num417].velocity *= 0.3f;
							}
						}
						if (this.type == 129)
						{
							for (int num418 = 0; num418 < 6; num418++)
							{
								int num419 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 106, this.velocity.X, this.velocity.Y, 100, default(Color), 1f);
								Main.dust[num419].noGravity = true;
								Main.dust[num419].velocity *= 0.1f + (float)Main.rand.Next(4) * 0.1f;
								Main.dust[num419].scale *= 1f + (float)Main.rand.Next(5) * 0.1f;
							}
						}
						if (this.ai[1] == 0f)
						{
							this.ai[1] = 1f;
							Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 28);
							return;
						}
					}
					else if (this.aiStyle == 29)
					{
						int num420 = this.type - 121 + 86;
						for (int num421 = 0; num421 < 2; num421++)
						{
							int num422 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num420, this.velocity.X, this.velocity.Y, 50, default(Color), 1.2f);
							Main.dust[num422].noGravity = true;
							Main.dust[num422].velocity *= 0.3f;
						}
						if (this.ai[1] == 0f)
						{
							this.ai[1] = 1f;
							Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
							return;
						}
					}
					else if (this.aiStyle == 30)
					{
						this.velocity *= 0.8f;
						this.rotation += 0.2f;
						this.alpha += 4;
						if (this.alpha >= 255)
						{
							this.Kill();
							return;
						}
					}
					else
					{
						if (this.aiStyle == 31)
						{
							int num423 = 110;
							int num424 = 0;
							if (this.type == 146)
							{
								num423 = 111;
								num424 = 2;
							}
							if (this.type == 147)
							{
								num423 = 112;
								num424 = 1;
							}
							if (this.type == 148)
							{
								num423 = 113;
								num424 = 3;
							}
							if (this.type == 149)
							{
								num423 = 114;
								num424 = 4;
							}
							if (this.owner == Main.myPlayer)
							{
								WorldGen.Convert((int)(this.position.X + (float)(this.width / 2)) / 16, (int)(this.position.Y + (float)(this.height / 2)) / 16, num424, 2);
							}
							if (this.timeLeft > 133)
							{
								this.timeLeft = 133;
							}
							if (this.ai[0] > 7f)
							{
								float num425 = 1f;
								if (this.ai[0] == 8f)
								{
									num425 = 0.2f;
								}
								else if (this.ai[0] == 9f)
								{
									num425 = 0.4f;
								}
								else if (this.ai[0] == 10f)
								{
									num425 = 0.6f;
								}
								else if (this.ai[0] == 11f)
								{
									num425 = 0.8f;
								}
								this.ai[0] += 1f;
								for (int num426 = 0; num426 < 1; num426++)
								{
									int num427 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num423, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 1f);
									Main.dust[num427].noGravity = true;
									Main.dust[num427].scale *= 1.75f;
									Dust expr_14FCF_cp_0 = Main.dust[num427];
									expr_14FCF_cp_0.velocity.X = expr_14FCF_cp_0.velocity.X * 2f;
									Dust expr_14FEF_cp_0 = Main.dust[num427];
									expr_14FEF_cp_0.velocity.Y = expr_14FEF_cp_0.velocity.Y * 2f;
									Main.dust[num427].scale *= num425;
								}
							}
							else
							{
								this.ai[0] += 1f;
							}
							this.rotation += 0.3f * (float)this.direction;
							return;
						}
						if (this.aiStyle == 32)
						{
							this.timeLeft = 10;
							this.ai[0] += 1f;
							if (this.ai[0] >= 20f)
							{
								this.ai[0] = 15f;
								for (int num428 = 0; num428 < 255; num428++)
								{
									Rectangle rectangle2 = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
									if (Main.player[num428].active)
									{
										Rectangle value3 = new Rectangle((int)Main.player[num428].position.X, (int)Main.player[num428].position.Y, Main.player[num428].width, Main.player[num428].height);
										if (rectangle2.Intersects(value3))
										{
											this.ai[0] = 0f;
											this.velocity.Y = -4.5f;
											if (this.velocity.X > 2f)
											{
												this.velocity.X = 2f;
											}
											if (this.velocity.X < -2f)
											{
												this.velocity.X = -2f;
											}
											this.velocity.X = (this.velocity.X + (float)Main.player[num428].direction * 1.75f) / 2f;
											this.velocity.X = this.velocity.X + Main.player[num428].velocity.X * 3f;
											this.velocity.Y = this.velocity.Y + Main.player[num428].velocity.Y;
											if (this.velocity.X > 6f)
											{
												this.velocity.X = 6f;
											}
											if (this.velocity.X < -6f)
											{
												this.velocity.X = -6f;
											}
											this.netUpdate = true;
											this.ai[1] += 1f;
										}
									}
								}
							}
							if (this.velocity.X == 0f && this.velocity.Y == 0f)
							{
								this.Kill();
							}
							this.rotation += 0.02f * this.velocity.X;
							if (this.velocity.Y == 0f)
							{
								this.velocity.X = this.velocity.X * 0.98f;
							}
							else if (this.wet)
							{
								this.velocity.X = this.velocity.X * 0.99f;
							}
							else
							{
								this.velocity.X = this.velocity.X * 0.995f;
							}
							if ((double)this.velocity.X > -0.03 && (double)this.velocity.X < 0.03)
							{
								this.velocity.X = 0f;
							}
							if (this.wet)
							{
								this.ai[1] = 0f;
								if (this.velocity.Y > 0f)
								{
									this.velocity.Y = this.velocity.Y * 0.95f;
								}
								this.velocity.Y = this.velocity.Y - 0.1f;
								if (this.velocity.Y < -4f)
								{
									this.velocity.Y = -4f;
								}
								if (this.velocity.X == 0f)
								{
									this.Kill();
								}
							}
							else
							{
								this.velocity.Y = this.velocity.Y + 0.1f;
							}
							if (this.velocity.Y > 10f)
							{
								this.velocity.Y = 10f;
								return;
							}
						}
						else
						{
							if (this.aiStyle == 33)
							{
								if (this.alpha > 0)
								{
									this.alpha -= 50;
									if (this.alpha < 0)
									{
										this.alpha = 0;
									}
								}
								float num429 = 4f;
								float num430 = this.ai[0];
								float num431 = this.ai[1];
								if (num430 == 0f && num431 == 0f)
								{
									num430 = 1f;
								}
								float num432 = (float)Math.Sqrt((double)(num430 * num430 + num431 * num431));
								num432 = num429 / num432;
								num430 *= num432;
								num431 *= num432;
								if (this.alpha < 70)
								{
									int num433 = 127;
									if (this.type == 310)
									{
										num433 = 187;
									}
									int num434 = Dust.NewDust(new Vector2(this.position.X, this.position.Y - 2f), 6, 6, num433, this.velocity.X, this.velocity.Y, 100, default(Color), 1.6f);
									Main.dust[num434].noGravity = true;
									Dust expr_155E4_cp_0 = Main.dust[num434];
									expr_155E4_cp_0.position.X = expr_155E4_cp_0.position.X - num430 * 1f;
									Dust expr_15609_cp_0 = Main.dust[num434];
									expr_15609_cp_0.position.Y = expr_15609_cp_0.position.Y - num431 * 1f;
									Dust expr_1562E_cp_0 = Main.dust[num434];
									expr_1562E_cp_0.velocity.X = expr_1562E_cp_0.velocity.X - num430;
									Dust expr_1564D_cp_0 = Main.dust[num434];
									expr_1564D_cp_0.velocity.Y = expr_1564D_cp_0.velocity.Y - num431;
								}
								if (this.localAI[0] == 0f)
								{
									this.ai[0] = this.velocity.X;
									this.ai[1] = this.velocity.Y;
									this.localAI[1] += 1f;
									if (this.localAI[1] >= 30f)
									{
										this.velocity.Y = this.velocity.Y + 0.09f;
										this.localAI[1] = 30f;
									}
								}
								else
								{
									if (!Collision.SolidCollision(this.position, this.width, this.height))
									{
										this.localAI[0] = 0f;
										this.localAI[1] = 30f;
									}
									this.damage = 0;
								}
								if (this.velocity.Y > 16f)
								{
									this.velocity.Y = 16f;
								}
								this.rotation = (float)Math.Atan2((double)this.ai[1], (double)this.ai[0]) + 1.57f;
								return;
							}
							if (this.aiStyle == 34)
							{
								int num435 = Dust.NewDust(new Vector2(this.position.X + 2f, this.position.Y + 20f), 8, 8, 6, this.velocity.X, this.velocity.Y, 100, default(Color), 1.2f);
								Main.dust[num435].noGravity = true;
								Main.dust[num435].velocity *= 0.2f;
								return;
							}
							if (this.aiStyle == 35)
							{
								this.ai[0] += 1f;
								if (this.ai[0] > 30f)
								{
									this.velocity.Y = this.velocity.Y + 0.2f;
									this.velocity.X = this.velocity.X * 0.985f;
									if (this.velocity.Y > 14f)
									{
										this.velocity.Y = 14f;
									}
								}
								this.rotation += (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * (float)this.direction * 0.02f;
								if (this.owner == Main.myPlayer)
								{
									Vector2 vector29 = Collision.TileCollision(this.position, this.velocity, this.width, this.height, true, true);
									if (vector29 != this.velocity)
									{
										this.position += vector29;
										int num436 = (int)(this.position.X + (float)(this.width / 2)) / 16;
										int num437 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
										int num438 = 10;
										if (Main.tile[num436, num437] != null)
										{
											while (Main.tile[num436, num437] != null && Main.tile[num436, num437].active())
											{
												if (!Main.tileRope[(int)Main.tile[num436, num437].type])
												{
													break;
												}
												num437++;
											}
											while (num438 > 0)
											{
												num438--;
												if (Main.tile[num436, num437] == null)
												{
													break;
												}
												if (Main.tile[num436, num437].active() && (Main.tileCut[(int)Main.tile[num436, num437].type] || Main.tile[num436, num437].type == 165))
												{
													WorldGen.KillTile(num436, num437, false, false, false);
													NetMessage.SendData(17, -1, -1, "", 0, (float)num436, (float)num437, 0f, 0);
												}
												if (!Main.tile[num436, num437].active())
												{
													WorldGen.PlaceTile(num436, num437, 213, false, false, -1, 0);
													NetMessage.SendData(17, -1, -1, "", 1, (float)num436, (float)num437, 213f, 0);
													this.ai[1] += 1f;
												}
												else
												{
													num438 = 0;
												}
												num437++;
											}
											this.Kill();
											return;
										}
									}
								}
							}
							else if (this.aiStyle == 36)
							{
								if (this.type != 307 && this.wet && !this.honeyWet)
								{
									this.Kill();
								}
								if (this.alpha > 0)
								{
									this.alpha -= 50;
								}
								else
								{
									this.maxUpdates = 0;
								}
								if (this.alpha < 0)
								{
									this.alpha = 0;
								}
								if (this.type == 307)
								{
									this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) - 1.57f;
									this.frameCounter++;
									if (this.frameCounter >= 6)
									{
										this.frame++;
										this.frameCounter = 0;
									}
									if (this.frame >= 2)
									{
										this.frame = 0;
									}
									for (int num439 = 0; num439 < 3; num439++)
									{
										float num440 = this.velocity.X / 3f * (float)num439;
										float num441 = this.velocity.Y / 3f * (float)num439;
										int num442 = Dust.NewDust(this.position, this.width, this.height, 184, 0f, 0f, 0, default(Color), 1f);
										Main.dust[num442].position.X = this.center().X - num440;
										Main.dust[num442].position.Y = this.center().Y - num441;
										Main.dust[num442].velocity *= 0f;
										Main.dust[num442].scale = 0.5f;
									}
								}
								else
								{
									if (this.type == 316)
									{
										if (this.velocity.X > 0f)
										{
											this.spriteDirection = -1;
										}
										else if (this.velocity.X < 0f)
										{
											this.spriteDirection = 1;
										}
									}
									else if (this.velocity.X > 0f)
									{
										this.spriteDirection = 1;
									}
									else if (this.velocity.X < 0f)
									{
										this.spriteDirection = -1;
									}
									this.rotation = this.velocity.X * 0.1f;
									this.frameCounter++;
									if (this.frameCounter >= 3)
									{
										this.frame++;
										this.frameCounter = 0;
									}
									if (this.frame >= 3)
									{
										this.frame = 0;
									}
								}
								float num443 = this.position.X;
								float num444 = this.position.Y;
								float num445 = 100000f;
								bool flag14 = false;
								this.ai[0] += 1f;
								if (this.ai[0] > 30f)
								{
									this.ai[0] = 30f;
									for (int num446 = 0; num446 < 200; num446++)
									{
										if (Main.npc[num446].active && !Main.npc[num446].dontTakeDamage && !Main.npc[num446].friendly && Main.npc[num446].lifeMax > 5 && (!Main.npc[num446].wet || this.type == 307))
										{
											float num447 = Main.npc[num446].position.X + (float)(Main.npc[num446].width / 2);
											float num448 = Main.npc[num446].position.Y + (float)(Main.npc[num446].height / 2);
											float num449 = Math.Abs(this.position.X + (float)(this.width / 2) - num447) + Math.Abs(this.position.Y + (float)(this.height / 2) - num448);
											if (num449 < 800f && num449 < num445 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num446].position, Main.npc[num446].width, Main.npc[num446].height))
											{
												num445 = num449;
												num443 = num447;
												num444 = num448;
												flag14 = true;
											}
										}
									}
								}
								if (!flag14)
								{
									num443 = this.position.X + (float)(this.width / 2) + this.velocity.X * 100f;
									num444 = this.position.Y + (float)(this.height / 2) + this.velocity.Y * 100f;
								}
								else if (this.type == 307)
								{
									this.friendly = true;
								}
								float num450 = 6f;
								float num451 = 0.1f;
								if (this.type == 189)
								{
									num450 = 7f;
									num451 = 0.15f;
								}
								if (this.type == 307)
								{
									num450 = 9f;
									num451 = 0.2f;
								}
								if (this.type == 316)
								{
									num450 = 10f;
									num451 = 0.25f;
								}
								Vector2 vector30 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
								float num452 = num443 - vector30.X;
								float num453 = num444 - vector30.Y;
								float num454 = (float)Math.Sqrt((double)(num452 * num452 + num453 * num453));
								num454 = num450 / num454;
								num452 *= num454;
								num453 *= num454;
								if (this.velocity.X < num452)
								{
									this.velocity.X = this.velocity.X + num451;
									if (this.velocity.X < 0f && num452 > 0f)
									{
										this.velocity.X = this.velocity.X + num451 * 2f;
									}
								}
								else if (this.velocity.X > num452)
								{
									this.velocity.X = this.velocity.X - num451;
									if (this.velocity.X > 0f && num452 < 0f)
									{
										this.velocity.X = this.velocity.X - num451 * 2f;
									}
								}
								if (this.velocity.Y < num453)
								{
									this.velocity.Y = this.velocity.Y + num451;
									if (this.velocity.Y < 0f && num453 > 0f)
									{
										this.velocity.Y = this.velocity.Y + num451 * 2f;
										return;
									}
								}
								else if (this.velocity.Y > num453)
								{
									this.velocity.Y = this.velocity.Y - num451;
									if (this.velocity.Y > 0f && num453 < 0f)
									{
										this.velocity.Y = this.velocity.Y - num451 * 2f;
										return;
									}
								}
							}
							else if (this.aiStyle == 37)
							{
								if (this.ai[1] == 0f)
								{
									this.ai[1] = this.position.Y - 5f;
								}
								if (this.ai[0] == 0f)
								{
									if (Collision.SolidCollision(this.position, this.width, this.height))
									{
										this.velocity.Y = this.velocity.Y * -1f;
										this.ai[0] += 1f;
										return;
									}
									float num455 = this.position.Y - this.ai[1];
									if (num455 > 300f)
									{
										this.velocity.Y = this.velocity.Y * -1f;
										this.ai[0] += 1f;
										return;
									}
								}
								else if (Collision.SolidCollision(this.position, this.width, this.height))
								{
									this.Kill();
									return;
								}
							}
							else if (this.aiStyle == 38)
							{
								this.ai[0] += 1f;
								if (this.ai[0] >= 6f)
								{
									this.ai[0] = 0f;
									Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 34);
									if (Main.myPlayer == this.owner)
									{
										Projectile.NewProjectile(this.position.X, this.position.Y, this.velocity.X, this.velocity.Y, 188, this.damage, this.knockBack, this.owner, 0f, 0f);
										return;
									}
								}
							}
							else if (this.aiStyle == 39)
							{
								this.alpha -= 50;
								if (this.alpha < 0)
								{
									this.alpha = 0;
								}
								if (Main.player[this.owner].dead)
								{
									this.Kill();
									return;
								}
								if (this.alpha == 0)
								{
									Main.player[this.owner].itemAnimation = 5;
									Main.player[this.owner].itemTime = 5;
									if (this.position.X + (float)(this.width / 2) > Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2))
									{
										Main.player[this.owner].ChangeDir(1);
									}
									else
									{
										Main.player[this.owner].ChangeDir(-1);
									}
								}
								Vector2 vector31 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
								float num456 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector31.X;
								float num457 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector31.Y;
								float num458 = (float)Math.Sqrt((double)(num456 * num456 + num457 * num457));
								if (!Main.player[this.owner].channel && this.alpha == 0)
								{
									this.ai[0] = 1f;
									this.ai[1] = -1f;
								}
								if (this.ai[1] > 0f && num458 > 1500f)
								{
									this.ai[1] = 0f;
									this.ai[0] = 1f;
								}
								if (this.ai[1] > 0f)
								{
									this.tileCollide = false;
									int num459 = (int)this.ai[1] - 1;
									if (Main.npc[num459].active && Main.npc[num459].life > 0)
									{
										float num460 = 16f;
										vector31 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
										num456 = Main.npc[num459].position.X + (float)(Main.npc[num459].width / 2) - vector31.X;
										num457 = Main.npc[num459].position.Y + (float)(Main.npc[num459].height / 2) - vector31.Y;
										num458 = (float)Math.Sqrt((double)(num456 * num456 + num457 * num457));
										if (num458 < num460)
										{
											this.velocity.X = num456;
											this.velocity.Y = num457;
											if (num458 > num460 / 2f)
											{
												if (this.velocity.X < 0f)
												{
													this.spriteDirection = -1;
													this.rotation = (float)Math.Atan2((double)(-(double)this.velocity.Y), (double)(-(double)this.velocity.X));
												}
												else
												{
													this.spriteDirection = 1;
													this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X);
												}
											}
										}
										else
										{
											num458 = num460 / num458;
											num456 *= num458;
											num457 *= num458;
											this.velocity.X = num456;
											this.velocity.Y = num457;
											if (this.velocity.X < 0f)
											{
												this.spriteDirection = -1;
												this.rotation = (float)Math.Atan2((double)(-(double)this.velocity.Y), (double)(-(double)this.velocity.X));
											}
											else
											{
												this.spriteDirection = 1;
												this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X);
											}
										}
										this.ai[0] = 1f;
									}
									else
									{
										this.ai[1] = 0f;
										float num461 = this.position.X;
										float num462 = this.position.Y;
										float num463 = 3000f;
										int num464 = -1;
										for (int num465 = 0; num465 < 200; num465++)
										{
											if (Main.npc[num465].active && !Main.npc[num465].friendly && Main.npc[num465].lifeMax > 5)
											{
												float num466 = Main.npc[num465].position.X + (float)(Main.npc[num465].width / 2);
												float num467 = Main.npc[num465].position.Y + (float)(Main.npc[num465].height / 2);
												float num468 = Math.Abs(this.position.X + (float)(this.width / 2) - num466) + Math.Abs(this.position.Y + (float)(this.height / 2) - num467);
												if (num468 < num463 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num465].position, Main.npc[num465].width, Main.npc[num465].height))
												{
													num463 = num468;
													num461 = num466;
													num462 = num467;
													num464 = num465;
												}
											}
										}
										if (num464 >= 0)
										{
											float num469 = 16f;
											vector31 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
											num456 = num461 - vector31.X;
											num457 = num462 - vector31.Y;
											num458 = (float)Math.Sqrt((double)(num456 * num456 + num457 * num457));
											num458 = num469 / num458;
											num456 *= num458;
											num457 *= num458;
											this.velocity.X = num456;
											this.velocity.Y = num457;
											this.ai[0] = 0f;
											this.ai[1] = (float)(num464 + 1);
										}
									}
								}
								else if (this.ai[0] == 0f)
								{
									if (num458 > 700f)
									{
										this.ai[0] = 1f;
									}
									if (this.velocity.X < 0f)
									{
										this.spriteDirection = -1;
										this.rotation = (float)Math.Atan2((double)(-(double)this.velocity.Y), (double)(-(double)this.velocity.X));
									}
									else
									{
										this.spriteDirection = 1;
										this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X);
									}
								}
								else if (this.ai[0] == 1f)
								{
									this.tileCollide = false;
									if (this.velocity.X < 0f)
									{
										this.spriteDirection = 1;
										this.rotation = (float)Math.Atan2((double)(-(double)this.velocity.Y), (double)(-(double)this.velocity.X));
									}
									else
									{
										this.spriteDirection = -1;
										this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X);
									}
									if (this.velocity.X < 0f)
									{
										this.spriteDirection = -1;
										this.rotation = (float)Math.Atan2((double)(-(double)this.velocity.Y), (double)(-(double)this.velocity.X));
									}
									else
									{
										this.spriteDirection = 1;
										this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X);
									}
									float num470 = 20f;
									if (num458 < 70f)
									{
										this.Kill();
									}
									num458 = num470 / num458;
									num456 *= num458;
									num457 *= num458;
									this.velocity.X = num456;
									this.velocity.Y = num457;
								}
								this.frameCounter++;
								if (this.frameCounter >= 4)
								{
									this.frame++;
									this.frameCounter = 0;
								}
								if (this.frame >= 4)
								{
									this.frame = 0;
									return;
								}
							}
							else
							{
								if (this.aiStyle == 40)
								{
									this.localAI[0] += 1f;
									if (this.localAI[0] > 3f)
									{
										this.localAI[0] = 100f;
										this.alpha -= 50;
										if (this.alpha < 0)
										{
											this.alpha = 0;
										}
									}
									this.frameCounter++;
									if (this.frameCounter >= 3)
									{
										this.frame++;
										this.frameCounter = 0;
									}
									if (this.frame >= 5)
									{
										this.frame = 0;
									}
									this.velocity.X = this.velocity.X + this.ai[0];
									this.velocity.Y = this.velocity.Y + this.ai[1];
									this.localAI[1] += 1f;
									if (this.localAI[1] == 50f)
									{
										this.localAI[1] = 51f;
										this.ai[0] = (float)Main.rand.Next(-100, 101) * 6E-05f;
										this.ai[1] = (float)Main.rand.Next(-100, 101) * 6E-05f;
									}
									if (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 16f)
									{
										this.velocity.X = this.velocity.X * 0.95f;
										this.velocity.Y = this.velocity.Y * 0.95f;
									}
									if (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) < 12f)
									{
										this.velocity.X = this.velocity.X * 1.05f;
										this.velocity.Y = this.velocity.Y * 1.05f;
									}
									this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 3.14f;
									return;
								}
								if (this.aiStyle == 41)
								{
									if (this.localAI[0] == 0f)
									{
										this.localAI[0] = 1f;
										this.frame = Main.rand.Next(3);
									}
									this.rotation += this.velocity.X * 0.01f;
									return;
								}
								if (this.aiStyle == 42)
								{
									if (!Main.player[this.owner].crystalLeaf)
									{
										this.Kill();
										return;
									}
									this.position.X = Main.player[this.owner].center().X - (float)(this.width / 2);
									this.position.Y = Main.player[this.owner].center().Y - (float)(this.height / 2) + Main.player[this.owner].gfxOffY - 60f;
									if (Main.player[this.owner].gravDir == -1f)
									{
										this.position.Y = this.position.Y + 120f;
										this.rotation = 3.14f;
									}
									else
									{
										this.rotation = 0f;
									}
									this.position.X = (float)((int)this.position.X);
									this.position.Y = (float)((int)this.position.Y);
									float num471 = (float)Main.mouseTextColor / 200f - 0.35f;
									num471 *= 0.2f;
									this.scale = num471 + 0.95f;
									if (this.owner == Main.myPlayer)
									{
										if (this.ai[0] != 0f)
										{
											this.ai[0] -= 1f;
											return;
										}
										float num472 = this.position.X;
										float num473 = this.position.Y;
										float num474 = 700f;
										bool flag15 = false;
										for (int num475 = 0; num475 < 200; num475++)
										{
											if (Main.npc[num475].active && !Main.npc[num475].friendly && Main.npc[num475].lifeMax > 5)
											{
												float num476 = Main.npc[num475].position.X + (float)(Main.npc[num475].width / 2);
												float num477 = Main.npc[num475].position.Y + (float)(Main.npc[num475].height / 2);
												float num478 = Math.Abs(this.position.X + (float)(this.width / 2) - num476) + Math.Abs(this.position.Y + (float)(this.height / 2) - num477);
												if (num478 < num474 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num475].position, Main.npc[num475].width, Main.npc[num475].height))
												{
													num474 = num478;
													num472 = num476;
													num473 = num477;
													flag15 = true;
												}
											}
										}
										if (flag15)
										{
											float num479 = 12f;
											Vector2 vector32 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
											float num480 = num472 - vector32.X;
											float num481 = num473 - vector32.Y;
											float num482 = (float)Math.Sqrt((double)(num480 * num480 + num481 * num481));
											num482 = num479 / num482;
											num480 *= num482;
											num481 *= num482;
											Projectile.NewProjectile(this.center().X - 4f, this.center().Y, num480, num481, 227, 40, 5f, this.owner, 0f, 0f);
											this.ai[0] = 60f;
											return;
										}
									}
								}
								else
								{
									if (this.aiStyle == 43)
									{
										if (this.localAI[1] == 0f)
										{
											Main.PlaySound(6, (int)this.position.X, (int)this.position.Y, 1);
											this.localAI[1] += 1f;
											for (int num483 = 0; num483 < 5; num483++)
											{
												int num484 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 157, 0f, 0f, 0, default(Color), 1f);
												Main.dust[num484].noGravity = true;
												Main.dust[num484].velocity *= 3f;
												Main.dust[num484].scale = 1.5f;
											}
										}
										this.ai[0] = (float)Main.rand.Next(-100, 101) * 0.0025f;
										this.ai[1] = (float)Main.rand.Next(-100, 101) * 0.0025f;
										if (this.localAI[0] == 0f)
										{
											this.scale += 0.05f;
											if ((double)this.scale > 1.2)
											{
												this.localAI[0] = 1f;
											}
										}
										else
										{
											this.scale -= 0.05f;
											if ((double)this.scale < 0.8)
											{
												this.localAI[0] = 0f;
											}
										}
										this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 3.14f;
										int num485 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 157, 0f, 0f, 0, default(Color), 1f);
										Main.dust[num485].noGravity = true;
										Main.dust[num485].velocity *= 0.1f;
										Main.dust[num485].scale = 1.5f;
										return;
									}
									if (this.aiStyle == 44)
									{
										if (this.type == 228)
										{
											this.velocity *= 0.96f;
											this.alpha += 4;
											if (this.alpha > 255)
											{
												this.Kill();
											}
										}
										else if (this.type == 229)
										{
											if (this.ai[0] == 0f)
											{
												Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
											}
											this.ai[0] += 1f;
											if (this.ai[0] > 20f)
											{
												this.velocity.Y = this.velocity.Y + 0.3f;
												this.velocity.X = this.velocity.X * 0.98f;
											}
										}
										this.frameCounter++;
										if (this.frameCounter > 5)
										{
											this.frame++;
											this.frameCounter = 0;
										}
										if (this.frame >= Main.projFrames[this.type])
										{
											this.frame = 0;
											return;
										}
									}
									else if (this.aiStyle == 45)
									{
										if (this.type == 237 || this.type == 243)
										{
											float num486 = this.ai[0];
											float num487 = this.ai[1];
											if (num486 != 0f && num487 != 0f)
											{
												bool flag16 = false;
												bool flag17 = false;
												if ((this.velocity.X < 0f && this.center().X < num486) || (this.velocity.X > 0f && this.center().X > num486))
												{
													flag16 = true;
												}
												if ((this.velocity.Y < 0f && this.center().Y < num487) || (this.velocity.Y > 0f && this.center().Y > num487))
												{
													flag17 = true;
												}
												if (flag16 && flag17)
												{
													this.Kill();
												}
											}
											this.rotation += this.velocity.X * 0.02f;
											this.frameCounter++;
											if (this.frameCounter > 4)
											{
												this.frameCounter = 0;
												this.frame++;
												if (this.frame > 3)
												{
													this.frame = 0;
													return;
												}
											}
										}
										else if (this.type == 238 || this.type == 244)
										{
											this.frameCounter++;
											if (this.frameCounter > 8)
											{
												this.frameCounter = 0;
												this.frame++;
												if (this.frame > 5)
												{
													this.frame = 0;
												}
											}
											this.ai[1] += 1f;
											if (this.type == 244 && this.ai[1] >= 1800f)
											{
												this.alpha += 5;
												if (this.alpha > 255)
												{
													this.alpha = 255;
													this.Kill();
												}
											}
											else if (this.type == 238 && this.ai[1] >= 3600f)
											{
												this.alpha += 5;
												if (this.alpha > 255)
												{
													this.alpha = 255;
													this.Kill();
												}
											}
											else
											{
												this.ai[0] += 1f;
												if (this.type == 244)
												{
													if (this.ai[0] > 10f)
													{
														this.ai[0] = 0f;
														if (this.owner == Main.myPlayer)
														{
															int num488 = (int)(this.position.X + 14f + (float)Main.rand.Next(this.width - 28));
															int num489 = (int)(this.position.Y + (float)this.height + 4f);
															Projectile.NewProjectile((float)num488, (float)num489, 0f, 5f, 245, this.damage, 0f, this.owner, 0f, 0f);
														}
													}
												}
												else if (this.ai[0] > 8f)
												{
													this.ai[0] = 0f;
													if (this.owner == Main.myPlayer)
													{
														int num490 = (int)(this.position.X + 14f + (float)Main.rand.Next(this.width - 28));
														int num491 = (int)(this.position.Y + (float)this.height + 4f);
														Projectile.NewProjectile((float)num490, (float)num491, 0f, 5f, 239, this.damage, 0f, this.owner, 0f, 0f);
													}
												}
											}
											this.localAI[0] += 1f;
											if (this.localAI[0] >= 10f)
											{
												this.localAI[0] = 0f;
												int num492 = 0;
												int num493 = 0;
												float num494 = 0f;
												int num495 = this.type;
												for (int num496 = 0; num496 < 1000; num496++)
												{
													if (Main.projectile[num496].active && Main.projectile[num496].owner == this.owner && Main.projectile[num496].type == num495 && Main.projectile[num496].ai[1] < 3600f)
													{
														num492++;
														if (Main.projectile[num496].ai[1] > num494)
														{
															num493 = num496;
															num494 = Main.projectile[num496].ai[1];
														}
													}
												}
												if (this.type == 244)
												{
													if (num492 > 1)
													{
														Main.projectile[num493].netUpdate = true;
														Main.projectile[num493].ai[1] = 36000f;
														return;
													}
												}
												else if (num492 > 2)
												{
													Main.projectile[num493].netUpdate = true;
													Main.projectile[num493].ai[1] = 36000f;
													return;
												}
											}
										}
										else
										{
											if (this.type == 239)
											{
												this.alpha = 50;
												return;
											}
											if (this.type == 245)
											{
												this.alpha = 100;
												return;
											}
											if (this.type == 264)
											{
												this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
												return;
											}
										}
									}
									else if (this.aiStyle == 46)
									{
										if (this.type == 250)
										{
											if (this.owner == Main.myPlayer)
											{
												this.localAI[0] += 1f;
												if (this.localAI[0] > 4f)
												{
													this.localAI[0] = 3f;
													Projectile.NewProjectile(this.center().X, this.center().Y, this.velocity.X * 0.001f, this.velocity.Y * 0.001f, 251, this.damage, this.knockBack, this.owner, 0f, 0f);
												}
												if (this.timeLeft > 150)
												{
													this.timeLeft = 150;
												}
											}
											float num497 = 1f;
											if (this.velocity.Y < 0f)
											{
												num497 -= this.velocity.Y / 3f;
											}
											this.ai[0] += num497;
											if (this.ai[0] > 30f)
											{
												this.velocity.Y = this.velocity.Y + 0.5f;
												if (this.velocity.Y > 0f)
												{
													this.velocity.X = this.velocity.X * 0.95f;
												}
												else
												{
													this.velocity.X = this.velocity.X * 1.05f;
												}
											}
											float num498 = this.velocity.X;
											float num499 = this.velocity.Y;
											float num500 = (float)Math.Sqrt((double)(num498 * num498 + num499 * num499));
											num500 = 15.95f * this.scale / num500;
											num498 *= num500;
											num499 *= num500;
											this.velocity.X = num498;
											this.velocity.Y = num499;
											this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) - 1.57f;
											return;
										}
										int num501 = 300;
										if (this.localAI[0] == 0f)
										{
											if (this.velocity.X > 0f)
											{
												this.spriteDirection = -1;
												this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) - 1.57f;
											}
											else
											{
												this.spriteDirection = 1;
												this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) - 1.57f;
											}
											this.localAI[0] = 1f;
											this.timeLeft = num501;
										}
										this.velocity.X = this.velocity.X * 0.98f;
										this.velocity.Y = this.velocity.Y * 0.98f;
										if (this.rotation == 0f)
										{
											this.alpha = 255;
											return;
										}
										if (this.timeLeft < 10)
										{
											this.alpha = 255 - (int)(255f * (float)this.timeLeft / 10f);
											return;
										}
										if (this.timeLeft > num501 - 10)
										{
											int num502 = num501 - this.timeLeft;
											this.alpha = 255 - (int)(255f * (float)num502 / 10f);
											return;
										}
										this.alpha = 0;
										return;
									}
									else if (this.aiStyle == 47)
									{
										if (this.ai[0] == 0f)
										{
											this.ai[0] = this.velocity.X;
											this.ai[1] = this.velocity.Y;
										}
										if (this.velocity.X > 0f)
										{
											this.rotation += (Math.Abs(this.velocity.Y) + Math.Abs(this.velocity.X)) * 0.001f;
										}
										else
										{
											this.rotation -= (Math.Abs(this.velocity.Y) + Math.Abs(this.velocity.X)) * 0.001f;
										}
										this.frameCounter++;
										if (this.frameCounter > 6)
										{
											this.frameCounter = 0;
											this.frame++;
											if (this.frame > 4)
											{
												this.frame = 0;
											}
										}
										if (Math.Sqrt((double)(this.velocity.X * this.velocity.X + this.velocity.Y * this.velocity.Y)) > 2.0)
										{
											this.velocity *= 0.98f;
										}
										for (int num503 = 0; num503 < 1000; num503++)
										{
											if (num503 != this.whoAmI && Main.projectile[num503].active && Main.projectile[num503].owner == this.owner && Main.projectile[num503].type == this.type && this.timeLeft > Main.projectile[num503].timeLeft && Main.projectile[num503].timeLeft > 30)
											{
												Main.projectile[num503].timeLeft = 30;
											}
										}
										int[] array = new int[20];
										int num504 = 0;
										float num505 = 300f;
										bool flag18 = false;
										for (int num506 = 0; num506 < 200; num506++)
										{
											if (Main.npc[num506].active && !Main.npc[num506].dontTakeDamage && !Main.npc[num506].friendly && Main.npc[num506].lifeMax > 5)
											{
												float num507 = Main.npc[num506].position.X + (float)(Main.npc[num506].width / 2);
												float num508 = Main.npc[num506].position.Y + (float)(Main.npc[num506].height / 2);
												float num509 = Math.Abs(this.position.X + (float)(this.width / 2) - num507) + Math.Abs(this.position.Y + (float)(this.height / 2) - num508);
												if (num509 < num505 && Collision.CanHit(this.center(), 1, 1, Main.npc[num506].center(), 1, 1))
												{
													if (num504 < 20)
													{
														array[num504] = num506;
														num504++;
													}
													flag18 = true;
												}
											}
										}
										if (this.timeLeft < 30)
										{
											flag18 = false;
										}
										if (flag18)
										{
											int num510 = Main.rand.Next(num504);
											num510 = array[num510];
											float num511 = Main.npc[num510].position.X + (float)(Main.npc[num510].width / 2);
											float num512 = Main.npc[num510].position.Y + (float)(Main.npc[num510].height / 2);
											this.localAI[0] += 1f;
											if (this.localAI[0] > 8f)
											{
												this.localAI[0] = 0f;
												float num513 = 6f;
												Vector2 value4 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
												value4 += this.velocity * 4f;
												float num514 = num511 - value4.X;
												float num515 = num512 - value4.Y;
												float num516 = (float)Math.Sqrt((double)(num514 * num514 + num515 * num515));
												num516 = num513 / num516;
												num514 *= num516;
												num515 *= num516;
												Projectile.NewProjectile(value4.X, value4.Y, num514, num515, 255, this.damage, this.knockBack, this.owner, 0f, 0f);
												return;
											}
										}
									}
									else if (this.aiStyle == 48)
									{
										if (this.type == 255)
										{
											for (int num517 = 0; num517 < 4; num517++)
											{
												Vector2 value5 = this.position;
												value5 -= this.velocity * ((float)num517 * 0.25f);
												this.alpha = 255;
												int num518 = Dust.NewDust(value5, 1, 1, 160, 0f, 0f, 0, default(Color), 1f);
												Main.dust[num518].position = value5;
												Dust expr_18842_cp_0 = Main.dust[num518];
												expr_18842_cp_0.position.X = expr_18842_cp_0.position.X + (float)(this.width / 2);
												Dust expr_18866_cp_0 = Main.dust[num518];
												expr_18866_cp_0.position.Y = expr_18866_cp_0.position.Y + (float)(this.height / 2);
												Main.dust[num518].scale = (float)Main.rand.Next(70, 110) * 0.013f;
												Main.dust[num518].velocity *= 0.2f;
											}
											return;
										}
										if (this.type == 290)
										{
											if (this.localAI[0] == 0f)
											{
												Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
											}
											this.localAI[0] += 1f;
											if (this.localAI[0] > 3f)
											{
												for (int num519 = 0; num519 < 3; num519++)
												{
													Vector2 value6 = this.position;
													value6 -= this.velocity * ((float)num519 * 0.3334f);
													this.alpha = 255;
													int num520 = Dust.NewDust(value6, 1, 1, 173, 0f, 0f, 0, default(Color), 1f);
													Main.dust[num520].position = value6;
													Main.dust[num520].scale = (float)Main.rand.Next(70, 110) * 0.013f;
													Main.dust[num520].velocity *= 0.2f;
												}
												return;
											}
										}
										else if (this.type == 294)
										{
											this.localAI[0] += 1f;
											if (this.localAI[0] > 9f)
											{
												for (int num521 = 0; num521 < 4; num521++)
												{
													Vector2 value7 = this.position;
													value7 -= this.velocity * ((float)num521 * 0.25f);
													this.alpha = 255;
													int num522 = Dust.NewDust(value7, 1, 1, 173, 0f, 0f, 0, default(Color), 1f);
													Main.dust[num522].position = value7;
													Main.dust[num522].scale = (float)Main.rand.Next(70, 110) * 0.013f;
													Main.dust[num522].velocity *= 0.2f;
												}
												return;
											}
										}
										else
										{
											this.localAI[0] += 1f;
											if (this.localAI[0] > 3f)
											{
												for (int num523 = 0; num523 < 4; num523++)
												{
													Vector2 value8 = this.position;
													value8 -= this.velocity * ((float)num523 * 0.25f);
													this.alpha = 255;
													int num524 = Dust.NewDust(value8, 1, 1, 162, 0f, 0f, 0, default(Color), 1f);
													Main.dust[num524].position = value8;
													Dust expr_18C02_cp_0 = Main.dust[num524];
													expr_18C02_cp_0.position.X = expr_18C02_cp_0.position.X + (float)(this.width / 2);
													Dust expr_18C26_cp_0 = Main.dust[num524];
													expr_18C26_cp_0.position.Y = expr_18C26_cp_0.position.Y + (float)(this.height / 2);
													Main.dust[num524].scale = (float)Main.rand.Next(70, 110) * 0.013f;
													Main.dust[num524].velocity *= 0.2f;
												}
												return;
											}
										}
									}
									else if (this.aiStyle == 49)
									{
										if (this.ai[1] == 0f)
										{
											this.ai[1] = 1f;
											Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
										}
										if (this.ai[1] == 1f)
										{
											if (this.velocity.X > 0f)
											{
												this.direction = 1;
											}
											else if (this.velocity.X < 0f)
											{
												this.direction = -1;
											}
											this.spriteDirection = this.direction;
											this.ai[0] += 1f;
											this.rotation += this.velocity.X * 0.05f + (float)this.direction * 0.05f;
											if (this.ai[0] >= 18f)
											{
												this.velocity.Y = this.velocity.Y + 0.28f;
												this.velocity.X = this.velocity.X * 0.99f;
											}
											if ((double)this.velocity.Y > 15.9)
											{
												this.velocity.Y = 15.9f;
											}
											if (this.ai[0] > 2f)
											{
												this.alpha = 0;
												if (this.ai[0] == 3f)
												{
													for (int num525 = 0; num525 < 10; num525++)
													{
														int num526 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
														Main.dust[num526].velocity *= 0.5f;
														Main.dust[num526].velocity += this.velocity * 0.1f;
													}
													for (int num527 = 0; num527 < 5; num527++)
													{
														int num528 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
														Main.dust[num528].noGravity = true;
														Main.dust[num528].velocity *= 3f;
														Main.dust[num528].velocity += this.velocity * 0.2f;
														num528 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
														Main.dust[num528].velocity *= 2f;
														Main.dust[num528].velocity += this.velocity * 0.3f;
													}
													for (int num529 = 0; num529 < 1; num529++)
													{
														int num530 = Gore.NewGore(new Vector2(this.position.X - 10f, this.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
														Main.gore[num530].position += this.velocity * 1.25f;
														Main.gore[num530].scale = 1.5f;
														Main.gore[num530].velocity += this.velocity * 0.5f;
														Main.gore[num530].velocity *= 0.02f;
													}
													return;
												}
											}
										}
										else if (this.ai[1] == 2f)
										{
											this.rotation = 0f;
											this.velocity.X = this.velocity.X * 0.95f;
											this.velocity.Y = this.velocity.Y + 0.2f;
											return;
										}
									}
									else if (this.aiStyle == 50)
									{
										if (this.type == 291)
										{
											if (this.localAI[0] == 0f)
											{
												Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 20);
												this.localAI[0] += 1f;
											}
											bool flag19 = false;
											bool flag20 = false;
											if (this.velocity.X < 0f && this.position.X < this.ai[0])
											{
												flag19 = true;
											}
											if (this.velocity.X > 0f && this.position.X > this.ai[0])
											{
												flag19 = true;
											}
											if (this.velocity.Y < 0f && this.position.Y < this.ai[1])
											{
												flag20 = true;
											}
											if (this.velocity.Y > 0f && this.position.Y > this.ai[1])
											{
												flag20 = true;
											}
											if (flag19 && flag20)
											{
												this.Kill();
											}
											for (int num531 = 0; num531 < 10; num531++)
											{
												int num532 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 174, 0f, 0f, 100, default(Color), 1.2f);
												Main.dust[num532].noGravity = true;
												Main.dust[num532].velocity *= 0.5f;
												Main.dust[num532].velocity += this.velocity * 0.1f;
											}
											return;
										}
										if (this.type == 295)
										{
											for (int num533 = 0; num533 < 8; num533++)
											{
												int num534 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 174, 0f, 0f, 100, default(Color), 1.2f);
												Main.dust[num534].noGravity = true;
												Main.dust[num534].velocity *= 0.5f;
												Main.dust[num534].velocity += this.velocity * 0.1f;
											}
											return;
										}
										if (this.localAI[0] == 0f)
										{
											Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
											this.localAI[0] += 1f;
										}
										this.ai[0] += 1f;
										if (this.type == 296)
										{
											this.ai[0] += 3f;
										}
										float num535 = 25f;
										if (this.ai[0] > 180f)
										{
											num535 -= (this.ai[0] - 180f) / 2f;
										}
										if (num535 <= 0f)
										{
											num535 = 0f;
											this.Kill();
										}
										if (this.type == 296)
										{
											num535 *= 0.7f;
										}
										int num536 = 0;
										while ((float)num536 < num535)
										{
											float num537 = (float)Main.rand.Next(-10, 11);
											float num538 = (float)Main.rand.Next(-10, 11);
											float num539 = (float)Main.rand.Next(3, 9);
											float num540 = (float)Math.Sqrt((double)(num537 * num537 + num538 * num538));
											num540 = num539 / num540;
											num537 *= num540;
											num538 *= num540;
											int num541 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 174, 0f, 0f, 100, default(Color), 1.5f);
											Main.dust[num541].noGravity = true;
											Main.dust[num541].position.X = this.center().X;
											Main.dust[num541].position.Y = this.center().Y;
											Dust expr_19675_cp_0 = Main.dust[num541];
											expr_19675_cp_0.position.X = expr_19675_cp_0.position.X + (float)Main.rand.Next(-10, 11);
											Dust expr_1969F_cp_0 = Main.dust[num541];
											expr_1969F_cp_0.position.Y = expr_1969F_cp_0.position.Y + (float)Main.rand.Next(-10, 11);
											Main.dust[num541].velocity.X = num537;
											Main.dust[num541].velocity.Y = num538;
											num536++;
										}
										return;
									}
									else if (this.aiStyle == 51)
									{
										if (this.type == 297)
										{
											this.localAI[0] += 1f;
											if (this.localAI[0] > 4f)
											{
												for (int num542 = 0; num542 < 5; num542++)
												{
													int num543 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 175, 0f, 0f, 100, default(Color), 2f);
													Main.dust[num543].noGravity = true;
													Main.dust[num543].velocity *= 0f;
												}
											}
										}
										else
										{
											if (this.localAI[0] == 0f)
											{
												Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
												this.localAI[0] += 1f;
											}
											for (int num544 = 0; num544 < 9; num544++)
											{
												int num545 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 175, 0f, 0f, 100, default(Color), 1.3f);
												Main.dust[num545].noGravity = true;
												Main.dust[num545].velocity *= 0f;
											}
										}
										float num546 = this.center().X;
										float num547 = this.center().Y;
										float num548 = 400f;
										bool flag21 = false;
										if (this.type == 297)
										{
											for (int num549 = 0; num549 < 200; num549++)
											{
												if (Main.npc[num549].active && !Main.npc[num549].dontTakeDamage && !Main.npc[num549].friendly && Main.npc[num549].lifeMax > 5 && Collision.CanHit(this.center(), 1, 1, Main.npc[num549].center(), 1, 1))
												{
													float num550 = Main.npc[num549].position.X + (float)(Main.npc[num549].width / 2);
													float num551 = Main.npc[num549].position.Y + (float)(Main.npc[num549].height / 2);
													float num552 = Math.Abs(this.position.X + (float)(this.width / 2) - num550) + Math.Abs(this.position.Y + (float)(this.height / 2) - num551);
													if (num552 < num548)
													{
														num548 = num552;
														num546 = num550;
														num547 = num551;
														flag21 = true;
													}
												}
											}
										}
										else
										{
											num548 = 200f;
											for (int num553 = 0; num553 < 255; num553++)
											{
												if (Main.player[num553].active && !Main.player[num553].dead)
												{
													float num554 = Main.player[num553].position.X + (float)(Main.player[num553].width / 2);
													float num555 = Main.player[num553].position.Y + (float)(Main.player[num553].height / 2);
													float num556 = Math.Abs(this.position.X + (float)(this.width / 2) - num554) + Math.Abs(this.position.Y + (float)(this.height / 2) - num555);
													if (num556 < num548)
													{
														num548 = num556;
														num546 = num554;
														num547 = num555;
														flag21 = true;
													}
												}
											}
										}
										if (flag21)
										{
											float num557 = 3f;
											if (this.type == 297)
											{
												num557 = 6f;
											}
											Vector2 vector33 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
											float num558 = num546 - vector33.X;
											float num559 = num547 - vector33.Y;
											float num560 = (float)Math.Sqrt((double)(num558 * num558 + num559 * num559));
											num560 = num557 / num560;
											num558 *= num560;
											num559 *= num560;
											if (this.type == 297)
											{
												this.velocity.X = (this.velocity.X * 20f + num558) / 21f;
												this.velocity.Y = (this.velocity.Y * 20f + num559) / 21f;
												return;
											}
											this.velocity.X = (this.velocity.X * 100f + num558) / 101f;
											this.velocity.Y = (this.velocity.Y * 100f + num559) / 101f;
											return;
										}
									}
									else if (this.aiStyle == 52)
									{
										int num561 = (int)this.ai[0];
										float num562 = 4f;
										Vector2 vector34 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
										float num563 = Main.player[num561].center().X - vector34.X;
										float num564 = Main.player[num561].center().Y - vector34.Y;
										float num565 = (float)Math.Sqrt((double)(num563 * num563 + num564 * num564));
										if (num565 < 50f && this.position.X < Main.player[num561].position.X + (float)Main.player[num561].width && this.position.X + (float)this.width > Main.player[num561].position.X && this.position.Y < Main.player[num561].position.Y + (float)Main.player[num561].height && this.position.Y + (float)this.height > Main.player[num561].position.Y)
										{
											if (this.owner == Main.myPlayer)
											{
												int num566 = (int)this.ai[1];
												Main.player[num561].HealEffect(num566, false);
												Main.player[num561].statLife += num566;
												if (Main.player[num561].statLife > Main.player[num561].statLifeMax)
												{
													Main.player[num561].statLife = Main.player[num561].statLifeMax;
												}
												NetMessage.SendData(66, -1, -1, "", num561, (float)num566, 0f, 0f, 0);
											}
											this.Kill();
										}
										num565 = num562 / num565;
										num563 *= num565;
										num564 *= num565;
										this.velocity.X = (this.velocity.X * 15f + num563) / 16f;
										this.velocity.Y = (this.velocity.Y * 15f + num564) / 16f;
										if (this.type == 305)
										{
											for (int num567 = 0; num567 < 3; num567++)
											{
												float num568 = this.velocity.X * 0.334f * (float)num567;
												float num569 = -(this.velocity.Y * 0.334f) * (float)num567;
												int num570 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 183, 0f, 0f, 100, default(Color), 1.1f);
												Main.dust[num570].noGravity = true;
												Main.dust[num570].velocity *= 0f;
												Dust expr_1A09C_cp_0 = Main.dust[num570];
												expr_1A09C_cp_0.position.X = expr_1A09C_cp_0.position.X - num568;
												Dust expr_1A0BB_cp_0 = Main.dust[num570];
												expr_1A0BB_cp_0.position.Y = expr_1A0BB_cp_0.position.Y - num569;
											}
											return;
										}
										for (int num571 = 0; num571 < 5; num571++)
										{
											float num572 = this.velocity.X * 0.2f * (float)num571;
											float num573 = -(this.velocity.Y * 0.2f) * (float)num571;
											int num574 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 175, 0f, 0f, 100, default(Color), 1.3f);
											Main.dust[num574].noGravity = true;
											Main.dust[num574].velocity *= 0f;
											Dust expr_1A1B3_cp_0 = Main.dust[num574];
											expr_1A1B3_cp_0.position.X = expr_1A1B3_cp_0.position.X - num572;
											Dust expr_1A1D2_cp_0 = Main.dust[num574];
											expr_1A1D2_cp_0.position.Y = expr_1A1D2_cp_0.position.Y - num573;
										}
										return;
									}
									else if (this.aiStyle == 53)
									{
										if (this.localAI[0] == 0f)
										{
											this.localAI[1] = 1f;
											this.localAI[0] = 1f;
											this.ai[0] = 120f;
											int num575 = 80;
											Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 46);
											for (int num576 = 0; num576 < num575; num576++)
											{
												int num577 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 16f), this.width, this.height - 16, 185, 0f, 0f, 0, default(Color), 1f);
												Main.dust[num577].velocity *= 2f;
												Main.dust[num577].noGravity = true;
												Main.dust[num577].scale *= 1.15f;
											}
										}
										this.velocity.X = 0f;
										this.velocity.Y = this.velocity.Y + 0.2f;
										if (this.velocity.Y > 16f)
										{
											this.velocity.Y = 16f;
										}
										bool flag22 = false;
										float num578 = this.center().X;
										float num579 = this.center().Y;
										float num580 = 1000f;
										for (int num581 = 0; num581 < 200; num581++)
										{
											if (Main.npc[num581].active && !Main.npc[num581].dontTakeDamage && !Main.npc[num581].friendly && Main.npc[num581].lifeMax > 5)
											{
												float num582 = Main.npc[num581].position.X + (float)(Main.npc[num581].width / 2);
												float num583 = Main.npc[num581].position.Y + (float)(Main.npc[num581].height / 2);
												float num584 = Math.Abs(this.position.X + (float)(this.width / 2) - num582) + Math.Abs(this.position.Y + (float)(this.height / 2) - num583);
												if (num584 < num580 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num581].position, Main.npc[num581].width, Main.npc[num581].height))
												{
													num580 = num584;
													num578 = num582;
													num579 = num583;
													flag22 = true;
												}
											}
										}
										if (flag22)
										{
											float num585 = num578;
											float num586 = num579;
											num578 -= this.center().X;
											num579 -= this.center().Y;
											if (num578 < 0f)
											{
												this.spriteDirection = -1;
											}
											else
											{
												this.spriteDirection = 1;
											}
											int num587;
											if (num579 > 0f)
											{
												num587 = 0;
											}
											else if (Math.Abs(num579) > Math.Abs(num578) * 3f)
											{
												num587 = 4;
											}
											else if (Math.Abs(num579) > Math.Abs(num578) * 2f)
											{
												num587 = 3;
											}
											else if (Math.Abs(num578) > Math.Abs(num579) * 3f)
											{
												num587 = 0;
											}
											else if (Math.Abs(num578) > Math.Abs(num579) * 2f)
											{
												num587 = 1;
											}
											else
											{
												num587 = 2;
											}
											this.frame = num587 * 2;
											if (this.ai[0] > 40f && this.localAI[1] == 0f)
											{
												this.frame++;
											}
											if (this.ai[0] <= 0f)
											{
												this.localAI[1] = 0f;
												this.ai[0] = 60f;
												if (Main.myPlayer == this.owner)
												{
													float num588 = 6f;
													Vector2 vector35 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
													if (num587 == 0)
													{
														vector35.Y += 12f;
														vector35.X += (float)(24 * this.spriteDirection);
													}
													else if (num587 == 1)
													{
														vector35.Y += 0f;
														vector35.X += (float)(24 * this.spriteDirection);
													}
													else if (num587 == 2)
													{
														vector35.Y -= 2f;
														vector35.X += (float)(24 * this.spriteDirection);
													}
													else if (num587 == 3)
													{
														vector35.Y -= 6f;
														vector35.X += (float)(14 * this.spriteDirection);
													}
													else if (num587 == 4)
													{
														vector35.Y -= 14f;
														vector35.X += (float)(2 * this.spriteDirection);
													}
													if (this.spriteDirection < 0)
													{
														vector35.X += 10f;
													}
													float num589 = num585 - vector35.X;
													float num590 = num586 - vector35.Y;
													float num591 = (float)Math.Sqrt((double)(num589 * num589 + num590 * num590));
													num591 = num588 / num591;
													num589 *= num591;
													num590 *= num591;
													int num592 = this.damage;
													int num593 = 309;
													Projectile.NewProjectile(vector35.X, vector35.Y, num589, num590, num593, num592, this.knockBack, Main.myPlayer, 0f, 0f);
												}
											}
										}
										else if (this.ai[0] <= 60f && (this.frame == 1 || this.frame == 3 || this.frame == 5 || this.frame == 7 || this.frame == 9))
										{
											this.frame--;
										}
										if (this.ai[0] > 0f)
										{
											this.ai[0] -= 1f;
											return;
										}
									}
									else if (this.aiStyle == 54)
									{
										if (this.type == 317)
										{
											if (Main.player[Main.myPlayer].dead)
											{
												Main.player[Main.myPlayer].raven = false;
											}
											if (Main.player[Main.myPlayer].raven)
											{
												this.timeLeft = 2;
											}
										}
										for (int num594 = 0; num594 < 1000; num594++)
										{
											if (num594 != this.whoAmI && Main.projectile[num594].active && Main.projectile[num594].owner == this.owner && Main.projectile[num594].type == this.type && Math.Abs(this.position.X - Main.projectile[num594].position.X) + Math.Abs(this.position.Y - Main.projectile[num594].position.Y) < (float)this.width)
											{
												if (this.position.X < Main.projectile[num594].position.X)
												{
													this.velocity.X = this.velocity.X - 0.05f;
												}
												else
												{
													this.velocity.X = this.velocity.X + 0.05f;
												}
												if (this.position.Y < Main.projectile[num594].position.Y)
												{
													this.velocity.Y = this.velocity.Y - 0.05f;
												}
												else
												{
													this.velocity.Y = this.velocity.Y + 0.05f;
												}
											}
										}
										float num595 = this.position.X;
										float num596 = this.position.Y;
										float num597 = 800f;
										bool flag23 = false;
										int num598 = 500;
										if (this.ai[1] != 0f || this.friendly)
										{
											num598 = 1400;
										}
										if (Math.Abs(this.center().X - Main.player[this.owner].center().X) + Math.Abs(this.center().Y - Main.player[this.owner].center().Y) > (float)num598)
										{
											this.ai[0] = 1f;
										}
										if (this.ai[0] == 0f)
										{
											this.tileCollide = true;
											for (int num599 = 0; num599 < 200; num599++)
											{
												if (Main.npc[num599].active && !Main.npc[num599].dontTakeDamage && !Main.npc[num599].friendly && Main.npc[num599].lifeMax > 5)
												{
													float num600 = Main.npc[num599].position.X + (float)(Main.npc[num599].width / 2);
													float num601 = Main.npc[num599].position.Y + (float)(Main.npc[num599].height / 2);
													float num602 = Math.Abs(this.position.X + (float)(this.width / 2) - num600) + Math.Abs(this.position.Y + (float)(this.height / 2) - num601);
													if (num602 < num597 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num599].position, Main.npc[num599].width, Main.npc[num599].height))
													{
														num597 = num602;
														num595 = num600;
														num596 = num601;
														flag23 = true;
													}
												}
											}
										}
										else
										{
											this.tileCollide = false;
										}
										if (!flag23)
										{
											this.friendly = true;
											float num603 = 8f;
											if (this.ai[0] == 1f)
											{
												num603 = 12f;
											}
											Vector2 vector36 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
											float num604 = Main.player[this.owner].center().X - vector36.X;
											float num605 = Main.player[this.owner].center().Y - vector36.Y - 60f;
											float num606 = (float)Math.Sqrt((double)(num604 * num604 + num605 * num605));
											if (num606 < 100f && this.ai[0] == 1f && !Collision.SolidCollision(this.position, this.width, this.height))
											{
												this.ai[0] = 0f;
											}
											if (num606 > 2000f)
											{
												this.position.X = Main.player[this.owner].center().X - (float)(this.width / 2);
												this.position.Y = Main.player[this.owner].center().Y - (float)(this.width / 2);
											}
											if (num606 > 70f)
											{
												num606 = num603 / num606;
												num604 *= num606;
												num605 *= num606;
												this.velocity.X = (this.velocity.X * 20f + num604) / 21f;
												this.velocity.Y = (this.velocity.Y * 20f + num605) / 21f;
											}
											else
											{
												if (this.velocity.X == 0f && this.velocity.Y == 0f)
												{
													this.velocity.X = -0.15f;
													this.velocity.Y = -0.05f;
												}
												this.velocity *= 1.01f;
											}
											this.friendly = false;
											this.rotation = this.velocity.X * 0.05f;
											this.frameCounter++;
											if (this.frameCounter >= 4)
											{
												this.frameCounter = 0;
												this.frame++;
											}
											if (this.frame > 3)
											{
												this.frame = 0;
											}
											if ((double)Math.Abs(this.velocity.X) > 0.2)
											{
												this.spriteDirection = -this.direction;
												return;
											}
										}
										else
										{
											if (this.ai[1] == -1f)
											{
												this.ai[1] = 17f;
											}
											if (this.ai[1] > 0f)
											{
												this.ai[1] -= 1f;
											}
											if (this.ai[1] == 0f)
											{
												this.friendly = true;
												float num607 = 8f;
												Vector2 vector37 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
												float num608 = num595 - vector37.X;
												float num609 = num596 - vector37.Y;
												float num610 = (float)Math.Sqrt((double)(num608 * num608 + num609 * num609));
												if (num610 < 100f)
												{
													num607 = 10f;
												}
												num610 = num607 / num610;
												num608 *= num610;
												num609 *= num610;
												this.velocity.X = (this.velocity.X * 14f + num608) / 15f;
												this.velocity.Y = (this.velocity.Y * 14f + num609) / 15f;
											}
											else
											{
												this.friendly = false;
												if (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) < 10f)
												{
													this.velocity *= 1.05f;
												}
											}
											this.rotation = this.velocity.X * 0.05f;
											this.frameCounter++;
											if (this.frameCounter >= 4)
											{
												this.frameCounter = 0;
												this.frame++;
											}
											if (this.frame < 4)
											{
												this.frame = 4;
											}
											if (this.frame > 7)
											{
												this.frame = 4;
											}
											if ((double)Math.Abs(this.velocity.X) > 0.2)
											{
												this.spriteDirection = -this.direction;
												return;
											}
										}
									}
									else if (this.aiStyle == 55)
									{
										this.frameCounter++;
										if (this.frameCounter > 0)
										{
											this.frame++;
											this.frameCounter = 0;
											if (this.frame > 2)
											{
												this.frame = 0;
											}
										}
										if (this.velocity.X < 0f)
										{
											this.spriteDirection = -1;
											this.rotation = (float)Math.Atan2((double)(-(double)this.velocity.Y), (double)(-(double)this.velocity.X));
										}
										else
										{
											this.spriteDirection = 1;
											this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X);
										}
										if (this.ai[0] >= 0f && this.ai[0] < 200f)
										{
											int num611 = (int)this.ai[0];
											if (Main.npc[num611].active)
											{
												float num612 = 8f;
												Vector2 vector38 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
												float num613 = Main.npc[num611].position.X - vector38.X;
												float num614 = Main.npc[num611].position.Y - vector38.Y;
												float num615 = (float)Math.Sqrt((double)(num613 * num613 + num614 * num614));
												num615 = num612 / num615;
												num613 *= num615;
												num614 *= num615;
												this.velocity.X = (this.velocity.X * 14f + num613) / 15f;
												this.velocity.Y = (this.velocity.Y * 14f + num614) / 15f;
											}
											else
											{
												float num616 = 1000f;
												for (int num617 = 0; num617 < 200; num617++)
												{
													if (Main.npc[num617].active && !Main.npc[num617].dontTakeDamage && !Main.npc[num617].friendly && Main.npc[num617].lifeMax > 5)
													{
														float num618 = Main.npc[num617].position.X + (float)(Main.npc[num617].width / 2);
														float num619 = Main.npc[num617].position.Y + (float)(Main.npc[num617].height / 2);
														float num620 = Math.Abs(this.position.X + (float)(this.width / 2) - num618) + Math.Abs(this.position.Y + (float)(this.height / 2) - num619);
														if (num620 < num616 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num617].position, Main.npc[num617].width, Main.npc[num617].height))
														{
															num616 = num620;
															this.ai[0] = (float)num617;
														}
													}
												}
											}
											int num621 = 8;
											int num622 = Dust.NewDust(new Vector2(this.position.X + (float)num621, this.position.Y + (float)num621), this.width - num621 * 2, this.height - num621 * 2, 6, 0f, 0f, 0, default(Color), 1f);
											Main.dust[num622].velocity *= 0.5f;
											Main.dust[num622].velocity += this.velocity * 0.5f;
											Main.dust[num622].noGravity = true;
											Main.dust[num622].noLight = true;
											Main.dust[num622].scale = 1.4f;
											return;
										}
										this.Kill();
										return;
									}
									else if (this.aiStyle == 56)
									{
										if (this.localAI[0] == 0f)
										{
											this.localAI[0] = 1f;
											this.rotation = this.ai[0];
											this.spriteDirection = -(int)this.ai[1];
										}
										if (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) < 16f)
										{
											this.velocity *= 1.05f;
										}
										if (this.velocity.X < 0f)
										{
											this.direction = -1;
										}
										else
										{
											this.direction = 1;
										}
										this.rotation += (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.025f * (float)this.direction;
									}
								}
							}
						}
					}
				}
			}
		}

		public void Kill()
		{
			if (!this.active)
				return;
			this.timeLeft = 0;
			if (this.type == 1 || this.type == 81 || this.type == 98)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int index = 0; index < 10; ++index)
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 7, 0.0f, 0.0f, 0, new Color(), 1f);
			}
			if (this.type == 323)
			{
				Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
				for (int index1 = 0; index1 < 20; ++index1)
				{
					int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 7, 0.0f, 0.0f, 0, new Color(), 1f);
					if (Main.rand.Next(2) == 0)
					{
					Main.dust[index2].noGravity = true;
					Main.dust[index2].scale = 1.3f;
					Main.dust[index2].velocity *= 1.5f;
					Main.dust[index2].velocity -= this.lastVelocity * 0.5f;
					Main.dust[index2].velocity *= 1.5f;
					}
					else
					{
					Main.dust[index2].velocity *= 0.75f;
					Main.dust[index2].velocity -= this.lastVelocity * 0.25f;
					Main.dust[index2].scale = 0.8f;
					}
				}
			}
			if (this.type == 318)
			{
				Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
				for (int index1 = 0; index1 < 10; ++index1)
				{
					int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 30, 0.0f, 0.0f, 0, new Color(), 1f);
					if (Main.rand.Next(2) == 0)
					Main.dust[index2].noGravity = true;
				}
			}
			else if (this.type == 311)
			{
				for (int index1 = 0; index1 < 5; ++index1)
				{
					int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 189, 0.0f, 0.0f, 0, new Color(), 1f);
					Main.dust[index2].scale = 0.85f;
					Main.dust[index2].noGravity = true;
					Main.dust[index2].velocity += this.velocity * 0.5f;
				}
			}
			else if (this.type == 316)
			{
				for (int index1 = 0; index1 < 5; ++index1)
				{
					int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 195, 0.0f, 0.0f, 0, new Color(), 1f);
					Main.dust[index2].scale = 0.85f;
					Main.dust[index2].noGravity = true;
					Main.dust[index2].velocity += this.velocity * 0.5f;
				}
			}
			else if (this.type == 184 || this.type == 195)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int index = 0; index < 5; ++index)
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 7, 0.0f, 0.0f, 0, new Color(), 1f);
			}
			else if (this.type == 275 || this.type == 276)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int index = 0; index < 5; ++index)
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 7, 0.0f, 0.0f, 0, new Color(), 1f);
			}
			else if (this.type == 291)
			{
				if (this.owner == Main.myPlayer)
					Projectile.NewProjectile(this.center().X, this.center().Y, 0.0f, 0.0f, 292, this.damage, this.knockBack, this.owner, 0.0f, 0.0f);
			}
			else if (this.type == 295)
			{
				if (this.owner == Main.myPlayer)
					Projectile.NewProjectile(this.center().X, this.center().Y, 0.0f, 0.0f, 296, (int)((double)this.damage * 0.65), this.knockBack, this.owner, 0.0f, 0.0f);
			}
			else if (this.type == 270)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 27);
				for (int index1 = 0; index1 < 20; ++index1)
				{
					int index2 = Dust.NewDust(this.position, this.width, this.height, 26, 0.0f, 0.0f, 100, new Color(), 1f);
					Main.dust[index2].noGravity = true;
					Main.dust[index2].velocity *= 1.2f;
					Main.dust[index2].scale = 1.3f;
					Main.dust[index2].velocity -= this.lastVelocity * 0.3f;
					int index3 = Dust.NewDust(new Vector2(this.position.X + 4f, this.position.Y + 4f), this.width - 8, this.height - 8, 6, 0.0f, 0.0f, 100, new Color(), 2f);
					Main.dust[index3].noGravity = true;
					Main.dust[index3].velocity *= 3f;
				}
			}
			else if (this.type == 265)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 27);
				for (int index1 = 0; index1 < 15; ++index1)
				{
					int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 163, 0.0f, 0.0f, 100, new Color(), 1.2f);
					Main.dust[index2].noGravity = true;
					Main.dust[index2].velocity *= 1.2f;
					Main.dust[index2].velocity -= this.lastVelocity * 0.3f;
				}
			}
			else if (this.type == 304)
			{
				for (int index1 = 0; index1 < 3; ++index1)
				{
					int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 182, 0.0f, 0.0f, 100, new Color(), 0.8f);
					Main.dust[index2].noGravity = true;
					Main.dust[index2].velocity *= 1.2f;
					Main.dust[index2].velocity -= this.lastVelocity * 0.3f;
				}
			}
			else if (this.type == 263)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
				for (int index1 = 0; index1 < 15; ++index1)
				{
					int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 92, this.velocity.X, this.velocity.Y, Main.rand.Next(0, 101), new Color(), (float)(1.0 + (double)Main.rand.Next(40) * 0.00999999977648258));
					Main.dust[index2].noGravity = true;
					Main.dust[index2].velocity *= 2f;
				}
			}
			else if (this.type == 261)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int index = 0; index < 5; ++index)
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 148, 0.0f, 0.0f, 0, new Color(), 1f);
			}
			else if (this.type == 229)
			{
				for (int index1 = 0; index1 < 25; ++index1)
				{
					int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 157, 0.0f, 0.0f, 0, new Color(), 1f);
					Main.dust[index2].noGravity = true;
					Main.dust[index2].velocity *= 1.5f;
					Main.dust[index2].scale = 1.5f;
				}
			}
			else if (this.type == 239)
			{
				int index = Dust.NewDust(new Vector2(this.position.X, (float)((double)this.position.Y + (double)this.height - 2.0)), 2, 2, 154, 0.0f, 0.0f, 0, new Color(), 1f);
				Main.dust[index].position.X -= 2f;
				Main.dust[index].alpha = 38;
				Main.dust[index].velocity *= 0.1f;
				Main.dust[index].velocity += -this.lastVelocity * 0.25f;
				Main.dust[index].scale = 0.95f;
			}
			else if (this.type == 245)
			{
				int index = Dust.NewDust(new Vector2(this.position.X, (float)((double)this.position.Y + (double)this.height - 2.0)), 2, 2, 114, 0.0f, 0.0f, 0, new Color(), 1f);
				Main.dust[index].noGravity = true;
				Main.dust[index].position.X -= 2f;
				Main.dust[index].alpha = 38;
				Main.dust[index].velocity *= 0.1f;
				Main.dust[index].velocity += -this.lastVelocity * 0.25f;
				Main.dust[index].scale = 0.95f;
			}
			else if (this.type == 264)
			{
				int index = Dust.NewDust(new Vector2(this.position.X, (float)((double)this.position.Y + (double)this.height - 2.0)), 2, 2, 54, 0.0f, 0.0f, 0, new Color(), 1f);
				Main.dust[index].noGravity = true;
				Main.dust[index].position.X -= 2f;
				Main.dust[index].alpha = 38;
				Main.dust[index].velocity *= 0.1f;
				Main.dust[index].velocity += -this.lastVelocity * 0.25f;
				Main.dust[index].scale = 0.95f;
			}
			else if (this.type == 206 || this.type == 225)
			{
				Main.PlaySound(6, (int)this.position.X, (int)this.position.Y, 1);
				for (int index = 0; index < 5; ++index)
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 40, 0.0f, 0.0f, 0, new Color(), 1f);
			}
			else if (this.type == 227)
			{
				Main.PlaySound(6, (int)this.position.X, (int)this.position.Y, 1);
				for (int index1 = 0; index1 < 15; ++index1)
				{
					int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 157, 0.0f, 0.0f, 0, new Color(), 1f);
					Main.dust[index2].noGravity = true;
					Main.dust[index2].velocity += this.lastVelocity;
					Main.dust[index2].scale = 1.5f;
				}
			}
			else if (this.type == 237 && this.owner == Main.myPlayer)
				Projectile.NewProjectile(this.center().X, this.center().Y, 0.0f, 0.0f, 238, this.damage, this.knockBack, this.owner, 0.0f, 0.0f);
			else if (this.type == 243 && this.owner == Main.myPlayer)
				Projectile.NewProjectile(this.center().X, this.center().Y, 0.0f, 0.0f, 244, this.damage, this.knockBack, this.owner, 0.0f, 0.0f);
			else if (this.type == 120)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int index1 = 0; index1 < 10; ++index1)
				{
					int index2 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 67, this.velocity.X, this.velocity.Y, 100, new Color(), 1f);
					if (index1 < 5)
						Main.dust[index2].noGravity = true;
					Main.dust[index2].velocity *= 0.2f;
				}
			}
			else if (this.type == 181 || this.type == 189)
			{
				for (int index1 = 0; index1 < 6; ++index1)
				{
					int index2 = Dust.NewDust(this.position, this.width, this.height, 150, this.velocity.X, this.velocity.Y, 50, new Color(), 1f);
					Main.dust[index2].noGravity = true;
					Main.dust[index2].scale = 1f;
				}
			}
			else if (this.type == 178)
			{
				for (int index1 = 0; index1 < 85; ++index1)
				{
					int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, Main.rand.Next(139, 143), this.velocity.X, this.velocity.Y, 0, new Color(), 1.2f);
					Main.dust[index2].velocity.X += (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.dust[index2].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.dust[index2].velocity.X *= (float)(1.0 + (double)Main.rand.Next(-50, 51) * 0.00999999977648258);
					Main.dust[index2].velocity.Y *= (float)(1.0 + (double)Main.rand.Next(-50, 51) * 0.00999999977648258);
					Main.dust[index2].velocity.X += (float)Main.rand.Next(-50, 51) * 0.05f;
					Main.dust[index2].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.05f;
					Main.dust[index2].scale *= (float)(1.0 + (double)Main.rand.Next(-30, 31) * 0.00999999977648258);
				}
				for (int index1 = 0; index1 < 40; ++index1)
				{
					int index2 = Gore.NewGore(this.position, this.velocity, Main.rand.Next(276, 283), 1f);
					Main.gore[index2].velocity.X += (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.gore[index2].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.gore[index2].velocity.X *= (float)(1.0 + (double)Main.rand.Next(-50, 51) * 0.00999999977648258);
					Main.gore[index2].velocity.Y *= (float)(1.0 + (double)Main.rand.Next(-50, 51) * 0.00999999977648258);
					Main.gore[index2].scale *= (float)(1.0 + (double)Main.rand.Next(-20, 21) * 0.00999999977648258);
					Main.gore[index2].velocity.X += (float)Main.rand.Next(-50, 51) * 0.05f;
					Main.gore[index2].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.05f;
				}
			}
			else if (this.type == 289)
			{
				for (int index1 = 0; index1 < 30; ++index1)
				{
					int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, Main.rand.Next(139, 143), this.velocity.X, this.velocity.Y, 0, new Color(), 1.2f);
					Main.dust[index2].velocity.X += (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.dust[index2].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.dust[index2].velocity.X *= (float)(1.0 + (double)Main.rand.Next(-50, 51) * 0.00999999977648258);
					Main.dust[index2].velocity.Y *= (float)(1.0 + (double)Main.rand.Next(-50, 51) * 0.00999999977648258);
					Main.dust[index2].velocity.X += (float)Main.rand.Next(-50, 51) * 0.05f;
					Main.dust[index2].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.05f;
					Main.dust[index2].scale *= (float)(1.0 + (double)Main.rand.Next(-30, 31) * 0.00999999977648258);
				}
				for (int index1 = 0; index1 < 15; ++index1)
				{
					int index2 = Gore.NewGore(this.position, this.velocity, Main.rand.Next(276, 283), 1f);
					Main.gore[index2].velocity.X += (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.gore[index2].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.gore[index2].velocity.X *= (float)(1.0 + (double)Main.rand.Next(-50, 51) * 0.00999999977648258);
					Main.gore[index2].velocity.Y *= (float)(1.0 + (double)Main.rand.Next(-50, 51) * 0.00999999977648258);
					Main.gore[index2].scale *= (float)(1.0 + (double)Main.rand.Next(-20, 21) * 0.00999999977648258);
					Main.gore[index2].velocity.X += (float)Main.rand.Next(-50, 51) * 0.05f;
					Main.gore[index2].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.05f;
				}
			}
			else if (this.type == 171)
			{
				if ((double)this.ai[1] == 0.0)
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				if ((double)this.ai[1] < 10.0)
				{
					Vector2 Position = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num1 = -this.velocity.X;
					float num2 = -this.velocity.Y;
					float num3 = 1f;
					if ((double)this.ai[0] <= 17.0)
						num3 = this.ai[0] / 17f;
					int num4 = (int)(30.0 * (double)num3);
					float num5 = 1f;
					if ((double)this.ai[0] <= 30.0)
						num5 = this.ai[0] / 30f;
					float num6 = 0.4f * num5;
					float num7 = num6;
					float num8 = num2 + num7;
					for (int index1 = 0; index1 < num4; ++index1)
					{
						float num9 = (float)Math.Sqrt((double)num1 * (double)num1 + (double)num8 * (double)num8);
						float num10 = 5.6f;
						if ((double)Math.Abs(num1) + (double)Math.Abs(num8) < 1.0)
							num10 *= Math.Abs(num1) + Math.Abs(num8) / 1f;
						float num11 = num10 / num9;
						float num12 = num1 * num11;
						float num13 = num8 * num11;
						Math.Atan2((double)num13, (double)num12);
						if ((double)index1 > (double)this.ai[1])
						{
							for (int index2 = 0; index2 < 4; ++index2)
							{
								int index3 = Dust.NewDust(Position, this.width, this.height, 129, 0.0f, 0.0f, 0, new Color(), 1f);
								Main.dust[index3].noGravity = true;
								Main.dust[index3].velocity *= 0.3f;
							}
						}
						Position.X += num12;
						Position.Y += num13;
						num1 = -this.velocity.X;
						float num14 = -this.velocity.Y;
						num7 += num6;
						num8 = num14 + num7;
					}
				}
			}
			else if (this.type == 117)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int index = 0; index < 10; ++index)
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 26, 0.0f, 0.0f, 0, new Color(), 1f);
			}
			else if (this.type == 166)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 51);
				for (int index1 = 0; index1 < 10; ++index1)
				{
					int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 76, 0.0f, 0.0f, 0, new Color(), 1f);
					Main.dust[index2].noGravity = true;
					Main.dust[index2].velocity -= this.lastVelocity * 0.25f;
				}
			}
			else if (this.type == 158)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int index1 = 0; index1 < 10; ++index1)
				{
					int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 9, 0.0f, 0.0f, 0, new Color(), 1f);
					Main.dust[index2].noGravity = true;
					Main.dust[index2].velocity -= this.velocity * 0.5f;
				}
			}
			else if (this.type == 159)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int index1 = 0; index1 < 10; ++index1)
				{
					int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 11, 0.0f, 0.0f, 0, new Color(), 1f);
					Main.dust[index2].noGravity = true;
					Main.dust[index2].velocity -= this.velocity * 0.5f;
				}
			}
			else if (this.type == 160)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int index1 = 0; index1 < 10; ++index1)
				{
					int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 19, 0.0f, 0.0f, 0, new Color(), 1f);
					Main.dust[index2].noGravity = true;
					Main.dust[index2].velocity -= this.velocity * 0.5f;
				}
			}
			else if (this.type == 161)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int index1 = 0; index1 < 10; ++index1)
				{
					int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 11, 0.0f, 0.0f, 0, new Color(), 1f);
					Main.dust[index2].noGravity = true;
					Main.dust[index2].velocity -= this.velocity * 0.5f;
				}
			}
			else if (this.type >= 191 && this.type <= 194)
			{
				int index = Gore.NewGore(new Vector2(this.position.X - (float)(this.width / 2), this.position.Y - (float)(this.height / 2)), new Vector2(0.0f, 0.0f), Main.rand.Next(61, 64), this.scale);
				Main.gore[index].velocity *= 0.1f;
			}
			else if (!Main.projPet[this.type])
			{
				if (this.type == 93)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int index1 = 0; index1 < 10; ++index1)
					{
						int index2 = Dust.NewDust(this.position, this.width, this.height, 57, 0.0f, 0.0f, 100, new Color(), 0.5f);
						Main.dust[index2].velocity.X *= 2f;
						Main.dust[index2].velocity.Y *= 2f;
					}
				}
				else if (this.type == 99)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int index1 = 0; index1 < 30; ++index1)
					{
						int index2 = Dust.NewDust(this.position, this.width, this.height, 1, 0.0f, 0.0f, 0, new Color(), 1f);
						if (Main.rand.Next(2) == 0)
							Main.dust[index2].scale *= 1.4f;
						this.velocity *= 1.9f;
					}
				}
				else if (this.type == 91 || this.type == 92)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int index = 0; index < 10; ++index)
						Dust.NewDust(this.position, this.width, this.height, 58, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, new Color(), 1.2f);
					for (int index = 0; index < 3; ++index)
						Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
					if (this.type == 12 && this.damage < 500)
					{
						for (int index = 0; index < 10; ++index)
							Dust.NewDust(this.position, this.width, this.height, 57, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, new Color(), 1.2f);
						for (int index = 0; index < 3; ++index)
							Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
					}
					if ((this.type == 91 || this.type == 92 && (double)this.ai[0] > 0.0) && this.owner == Main.myPlayer)
					{
						float num1 = this.position.X + (float)Main.rand.Next(-400, 400);
						float num2 = this.position.Y - (float)Main.rand.Next(600, 900);
						Vector2 vector2 = new Vector2(num1, num2);
						float num3 = this.position.X + (float)(this.width / 2) - vector2.X;
						float num4 = this.position.Y + (float)(this.height / 2) - vector2.Y;
						float num5 = 22f / (float)Math.Sqrt((double)num3 * (double)num3 + (double)num4 * (double)num4);
						float SpeedX = num3 * num5;
						float SpeedY = num4 * num5;
						int Damage = this.damage;
						if (this.type == 91)
							Damage = (int)((double)Damage * 0.5);
						int index = Projectile.NewProjectile(num1, num2, SpeedX, SpeedY, 92, Damage, this.knockBack, this.owner, 0.0f, 0.0f);
						if (this.type == 91)
						{
							Main.projectile[index].ai[1] = this.position.Y;
							Main.projectile[index].ai[0] = 1f;
						}
						else
							Main.projectile[index].ai[1] = this.position.Y;
					}
				}
				else if (this.type == 89)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int index1 = 0; index1 < 5; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 68, 0.0f, 0.0f, 0, new Color(), 1f);
						Main.dust[index2].noGravity = true;
						Main.dust[index2].velocity *= 1.5f;
						Main.dust[index2].scale *= 0.9f;
					}
					if (this.type == 89 && this.owner == Main.myPlayer)
					{
						for (int index = 0; index < 3; ++index)
						{
							float SpeedX = (float)(-(double)this.velocity.X * (double)Main.rand.Next(40, 70) * 0.00999999977648258 + (double)Main.rand.Next(-20, 21) * 0.400000005960464);
							float SpeedY = (float)(-(double)this.velocity.Y * (double)Main.rand.Next(40, 70) * 0.00999999977648258 + (double)Main.rand.Next(-20, 21) * 0.400000005960464);
							Projectile.NewProjectile(this.position.X + SpeedX, this.position.Y + SpeedY, SpeedX, SpeedY, 90, (int)((double)this.damage * 0.5), 0.0f, this.owner, 0.0f, 0.0f);
						}
					}
				}
				else if (this.type == 177)
				{
					for (int index1 = 0; index1 < 20; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 137, 0.0f, 0.0f, Main.rand.Next(0, 101), new Color(), (float)(1.0 + (double)Main.rand.Next(-20, 40) * 0.00999999977648258));
						Main.dust[index2].velocity -= this.lastVelocity * 0.2f;
						if (Main.rand.Next(3) == 0)
						{
							Main.dust[index2].scale *= 0.8f;
							Main.dust[index2].velocity *= 0.5f;
						}
						else
							Main.dust[index2].noGravity = true;
					}
				}
				else if (this.type == 119 || this.type == 118 || this.type == 128)
				{
					int num = 10;
					if (this.type == 119)
						num = 20;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
					for (int index1 = 0; index1 < num; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 92, 0.0f, 0.0f, 0, new Color(), 1f);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[index2].velocity *= 2f;
							Main.dust[index2].noGravity = true;
							Main.dust[index2].scale *= 1.75f;
						}
						else
							Main.dust[index2].scale *= 0.5f;
					}
				}
				else if (this.type == 309)
				{
					int num = 10;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
					for (int index1 = 0; index1 < num; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 185, 0.0f, 0.0f, 0, new Color(), 1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[index2].velocity *= 2f;
							Main.dust[index2].noGravity = true;
							Main.dust[index2].scale *= 1.75f;
						}
					}
				}
				else if (this.type == 308)
				{
					int num = 80;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
					for (int index1 = 0; index1 < num; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 16f), this.width, this.height - 16, 185, 0.0f, 0.0f, 0, new Color(), 1f);
						Main.dust[index2].velocity *= 2f;
						Main.dust[index2].noGravity = true;
						Main.dust[index2].scale *= 1.15f;
					}
				}
				else if (this.aiStyle == 29)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					int Type = this.type - 121 + 86;
					for (int index1 = 0; index1 < 15; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, Type, this.lastVelocity.X, this.lastVelocity.Y, 50, new Color(), 1.2f);
						Main.dust[index2].noGravity = true;
						Main.dust[index2].scale *= 1.25f;
						Main.dust[index2].velocity *= 0.5f;
					}
				}
				else if (this.type == 80)
				{
					if ((double)this.ai[0] >= 0.0)
					{
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
						for (int index = 0; index < 10; ++index)
							Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0.0f, 0.0f, 0, new Color(), 1f);
					}
					int i = (int)this.position.X / 16;
					int j = (int)this.position.Y / 16;
					if (Main.tile[i, j] == null)
						Main.tile[i, j] = new Tile();
					if ((int)Main.tile[i, j].type == (int)sbyte.MaxValue && Main.tile[i, j].active())
						WorldGen.KillTile(i, j, false, false, false);
				}
				else if (this.type == 76 || this.type == 77 || this.type == 78)
				{
					for (int index1 = 0; index1 < 5; ++index1)
					{
						int index2 = Dust.NewDust(this.position, this.width, this.height, 27, 0.0f, 0.0f, 80, new Color(), 1.5f);
						Main.dust[index2].noGravity = true;
					}
				}
				else if (this.type == 55)
				{
					for (int index1 = 0; index1 < 5; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 18, 0.0f, 0.0f, 0, new Color(), 1.5f);
						Main.dust[index2].noGravity = true;
					}
				}
				else if (this.type == 51 || this.type == 267)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int index = 0; index < 5; ++index)
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0, 0.0f, 0.0f, 0, new Color(), 0.7f);
				}
				else if (this.type == 2 || this.type == 82)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int index = 0; index < 20; ++index)
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 1f);
				}
				else if (this.type == 172)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int index = 0; index < 20; ++index)
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 135, 0.0f, 0.0f, 100, new Color(), 1f);
				}
				else if (this.type == 103)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int index1 = 0; index1 < 20; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 75, 0.0f, 0.0f, 100, new Color(), 1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[index2].scale *= 2.5f;
							Main.dust[index2].noGravity = true;
							Main.dust[index2].velocity *= 5f;
						}
					}
				}
				else if (this.type == 278)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int index1 = 0; index1 < 20; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 169, 0.0f, 0.0f, 100, new Color(), 1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[index2].scale *= 1.5f;
							Main.dust[index2].noGravity = true;
							Main.dust[index2].velocity *= 5f;
						}
					}
				}
				else if (this.type == 3 || this.type == 48 || this.type == 54)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int index = 0; index < 10; ++index)
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 1, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 0, new Color(), 0.75f);
				}
				else if (this.type == 4)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int index = 0; index < 10; ++index)
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0.0f, 0.0f, 150, new Color(), 1.1f);
				}
				else if (this.type == 5)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int index = 0; index < 60; ++index)
					{
						int Type;
						switch (Main.rand.Next(3))
						{
							case 0:
								Type = 15;
								break;
							case 1:
								Type = 57;
								break;
							default:
								Type = 58;
								break;
						}
						Dust.NewDust(this.position, this.width, this.height, Type, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, new Color(), 1.5f);
					}
				}
				else if (this.type == 9 || this.type == 12)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int index = 0; index < 10; ++index)
						Dust.NewDust(this.position, this.width, this.height, 58, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, new Color(), 1.2f);
					for (int index = 0; index < 3; ++index)
						Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
					if (this.type == 12 && this.damage < 100)
					{
						for (int index = 0; index < 10; ++index)
							Dust.NewDust(this.position, this.width, this.height, 57, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, new Color(), 1.2f);
						for (int index = 0; index < 3; ++index)
							Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
					}
				}
				else if (this.type == 281)
				{
					Main.PlaySound(4, (int)this.position.X, (int)this.position.Y, 1);
					int index1 = Gore.NewGore(this.position, new Vector2((float)Main.rand.Next(-20, 21) * 0.2f, (float)Main.rand.Next(-20, 21) * 0.2f), 76, 1f);
					Main.gore[index1].velocity -= this.velocity * 0.5f;
					int index2 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2((float)Main.rand.Next(-20, 21) * 0.2f, (float)Main.rand.Next(-20, 21) * 0.2f), 77, 1f);
					Main.gore[index2].velocity -= this.velocity * 0.5f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int index3 = 0; index3 < 20; ++index3)
					{
						int index4 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
						Main.dust[index4].velocity *= 1.4f;
					}
					for (int index3 = 0; index3 < 10; ++index3)
					{
						int index4 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 2.5f);
						Main.dust[index4].noGravity = true;
						Main.dust[index4].velocity *= 5f;
						int index5 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 1.5f);
						Main.dust[index5].velocity *= 3f;
					}
					int index6 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					Main.gore[index6].velocity *= 0.4f;
					++Main.gore[index6].velocity.X;
					++Main.gore[index6].velocity.Y;
					int index7 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					Main.gore[index7].velocity *= 0.4f;
					--Main.gore[index7].velocity.X;
					++Main.gore[index7].velocity.Y;
					int index8 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					Main.gore[index8].velocity *= 0.4f;
					++Main.gore[index8].velocity.X;
					--Main.gore[index8].velocity.Y;
					int index9 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					Main.gore[index9].velocity *= 0.4f;
					--Main.gore[index9].velocity.X;
					--Main.gore[index9].velocity.Y;
					this.position.X += (float)(this.width / 2);
					this.position.Y += (float)(this.height / 2);
					this.width = 128;
					this.height = 128;
					this.position.X -= (float)(this.width / 2);
					this.position.Y -= (float)(this.height / 2);
					this.Damage();
				}
				else if (this.type == 162)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int index1 = 0; index1 < 20; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
						Main.dust[index2].velocity *= 1.4f;
					}
					for (int index1 = 0; index1 < 10; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 2.5f);
						Main.dust[index2].noGravity = true;
						Main.dust[index2].velocity *= 5f;
						int index3 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 1.5f);
						Main.dust[index3].velocity *= 3f;
					}
					int index4 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					Main.gore[index4].velocity *= 0.4f;
					++Main.gore[index4].velocity.X;
					++Main.gore[index4].velocity.Y;
					int index5 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					Main.gore[index5].velocity *= 0.4f;
					--Main.gore[index5].velocity.X;
					++Main.gore[index5].velocity.Y;
					int index6 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					Main.gore[index6].velocity *= 0.4f;
					++Main.gore[index6].velocity.X;
					--Main.gore[index6].velocity.Y;
					int index7 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					Main.gore[index7].velocity *= 0.4f;
					--Main.gore[index7].velocity.X;
					--Main.gore[index7].velocity.Y;
					this.position.X += (float)(this.width / 2);
					this.position.Y += (float)(this.height / 2);
					this.width = 128;
					this.height = 128;
					this.position.X -= (float)(this.width / 2);
					this.position.Y -= (float)(this.height / 2);
					this.Damage();
				}
				else if (this.type == 240)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int index1 = 0; index1 < 20; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
						Main.dust[index2].velocity *= 1.4f;
					}
					for (int index1 = 0; index1 < 10; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 2.5f);
						Main.dust[index2].noGravity = true;
						Main.dust[index2].velocity *= 5f;
						int index3 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 1.5f);
						Main.dust[index3].velocity *= 3f;
					}
					int index4 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					Main.gore[index4].velocity *= 0.4f;
					++Main.gore[index4].velocity.X;
					++Main.gore[index4].velocity.Y;
					int index5 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					Main.gore[index5].velocity *= 0.4f;
					--Main.gore[index5].velocity.X;
					++Main.gore[index5].velocity.Y;
					int index6 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					Main.gore[index6].velocity *= 0.4f;
					++Main.gore[index6].velocity.X;
					--Main.gore[index6].velocity.Y;
					int index7 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					Main.gore[index7].velocity *= 0.4f;
					--Main.gore[index7].velocity.X;
					--Main.gore[index7].velocity.Y;
					this.position.X += (float)(this.width / 2);
					this.position.Y += (float)(this.height / 2);
					this.width = 96;
					this.height = 96;
					this.position.X -= (float)(this.width / 2);
					this.position.Y -= (float)(this.height / 2);
					this.Damage();
				}
				else if (this.type == 283 || this.type == 282)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int index1 = 0; index1 < 10; ++index1)
					{
						int index2 = Dust.NewDust(this.position, this.width, this.height, 171, 0.0f, 0.0f, 100, new Color(), 1f);
						Main.dust[index2].scale = (float)Main.rand.Next(1, 10) * 0.1f;
						Main.dust[index2].noGravity = true;
						Main.dust[index2].fadeIn = 1.5f;
						Main.dust[index2].velocity *= 0.75f;
					}
				}
				else if (this.type == 284)
				{
					for (int index1 = 0; index1 < 10; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, Main.rand.Next(139, 143), (float)(-(double)this.velocity.X * 0.300000011920929), (float)(-(double)this.velocity.Y * 0.300000011920929), 0, new Color(), 1.2f);
						Main.dust[index2].velocity.X += (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.dust[index2].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.dust[index2].velocity.X *= (float)(1.0 + (double)Main.rand.Next(-50, 51) * 0.00999999977648258);
						Main.dust[index2].velocity.Y *= (float)(1.0 + (double)Main.rand.Next(-50, 51) * 0.00999999977648258);
						Main.dust[index2].velocity.X += (float)Main.rand.Next(-50, 51) * 0.05f;
						Main.dust[index2].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.05f;
						Main.dust[index2].scale *= (float)(1.0 + (double)Main.rand.Next(-30, 31) * 0.00999999977648258);
					}
					for (int index1 = 0; index1 < 5; ++index1)
					{
						int index2 = Gore.NewGore(this.position, -this.velocity * 0.3f, Main.rand.Next(276, 283), 1f);
						Main.gore[index2].velocity.X += (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.gore[index2].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.gore[index2].velocity.X *= (float)(1.0 + (double)Main.rand.Next(-50, 51) * 0.00999999977648258);
						Main.gore[index2].velocity.Y *= (float)(1.0 + (double)Main.rand.Next(-50, 51) * 0.00999999977648258);
						Main.gore[index2].scale *= (float)(1.0 + (double)Main.rand.Next(-20, 21) * 0.00999999977648258);
						Main.gore[index2].velocity.X += (float)Main.rand.Next(-50, 51) * 0.05f;
						Main.gore[index2].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.05f;
					}
				}
				else if (this.type == 286)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int index = 0; index < 7; ++index)
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
					for (int index1 = 0; index1 < 3; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 2.5f);
						Main.dust[index2].noGravity = true;
						Main.dust[index2].velocity *= 3f;
						int index3 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 1.5f);
						Main.dust[index3].velocity *= 2f;
					}
					int index4 = Gore.NewGore(new Vector2(this.position.X - 10f, this.position.Y - 10f), new Vector2(), Main.rand.Next(61, 64), 1f);
					Main.gore[index4].velocity *= 0.3f;
					Main.gore[index4].velocity.X += (float)Main.rand.Next(-10, 11) * 0.05f;
					Main.gore[index4].velocity.Y += (float)Main.rand.Next(-10, 11) * 0.05f;
					if (this.owner == Main.myPlayer)
					{
						this.localAI[1] = -1f;
						this.position.X += (float)(this.width / 2);
						this.position.Y += (float)(this.height / 2);
						this.width = 80;
						this.height = 80;
						this.position.X -= (float)(this.width / 2);
						this.position.Y -= (float)(this.height / 2);
						this.Damage();
					}
				}
				else if (this.type == 14 || this.type == 20 || (this.type == 36 || this.type == 83) || (this.type == 84 || this.type == 104 || (this.type == 279 || this.type == 100)) || (this.type == 110 || this.type == 180 || (this.type == 207 || this.type == 242) || (this.type == 302 || this.type == 257 || (this.type == 259 || this.type == 285))) || this.type == 287)
				{
					Collision.HitTiles(this.position, this.velocity, this.width, this.height);
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
				}
				else if (this.type == 15 || this.type == 34 || this.type == 321)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int index1 = 0; index1 < 20; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, (float)(-(double)this.velocity.X * 0.200000002980232), (float)(-(double)this.velocity.Y * 0.200000002980232), 100, new Color(), 2f);
						Main.dust[index2].noGravity = true;
						Main.dust[index2].velocity *= 2f;
						int index3 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, (float)(-(double)this.velocity.X * 0.200000002980232), (float)(-(double)this.velocity.Y * 0.200000002980232), 100, new Color(), 1f);
						Main.dust[index3].velocity *= 2f;
					}
				}
				else if (this.type == 253)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int index1 = 0; index1 < 20; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 135, (float)(-(double)this.velocity.X * 0.200000002980232), (float)(-(double)this.velocity.Y * 0.200000002980232), 100, new Color(), 2f);
						Main.dust[index2].noGravity = true;
						Main.dust[index2].velocity *= 2f;
						int index3 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 135, (float)(-(double)this.velocity.X * 0.200000002980232), (float)(-(double)this.velocity.Y * 0.200000002980232), 100, new Color(), 1f);
						Main.dust[index3].velocity *= 2f;
					}
				}
				else if (this.type == 95 || this.type == 96)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int index1 = 0; index1 < 20; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 75, (float)(-(double)this.velocity.X * 0.200000002980232), (float)(-(double)this.velocity.Y * 0.200000002980232), 100, new Color(), 2f * this.scale);
						Main.dust[index2].noGravity = true;
						Main.dust[index2].velocity *= 2f;
						int index3 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 75, (float)(-(double)this.velocity.X * 0.200000002980232), (float)(-(double)this.velocity.Y * 0.200000002980232), 100, new Color(), 1f * this.scale);
						Main.dust[index3].velocity *= 2f;
					}
				}
				else if (this.type == 79)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int index1 = 0; index1 < 20; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 66, 0.0f, 0.0f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 2f);
						Main.dust[index2].noGravity = true;
						Main.dust[index2].velocity *= 4f;
					}
				}
				else if (this.type == 16)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int index1 = 0; index1 < 20; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 15, 0.0f, 0.0f, 100, new Color(), 2f);
						Main.dust[index2].noGravity = true;
						Main.dust[index2].velocity *= 2f;
						Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 15, 0.0f, 0.0f, 100, new Color(), 1f);
					}
				}
				else if (this.type == 17)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int index = 0; index < 5; ++index)
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0, 0.0f, 0.0f, 0, new Color(), 1f);
				}
				else if (this.type == 31 || this.type == 42)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int index1 = 0; index1 < 5; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 32, 0.0f, 0.0f, 0, new Color(), 1f);
						Main.dust[index2].velocity *= 0.6f;
					}
				}
				else if (this.type == 109)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int index1 = 0; index1 < 5; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 51, 0.0f, 0.0f, 0, new Color(), 0.6f);
						Main.dust[index2].velocity *= 0.6f;
					}
				}
				else if (this.type == 39)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int index1 = 0; index1 < 5; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 38, 0.0f, 0.0f, 0, new Color(), 1f);
						Main.dust[index2].velocity *= 0.6f;
					}
				}
				else if (this.type == 71)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int index1 = 0; index1 < 5; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 53, 0.0f, 0.0f, 0, new Color(), 1f);
						Main.dust[index2].velocity *= 0.6f;
					}
				}
				else if (this.type == 40)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int index1 = 0; index1 < 5; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 36, 0.0f, 0.0f, 0, new Color(), 1f);
						Main.dust[index2].velocity *= 0.6f;
					}
				}
				else if (this.type == 21)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int index = 0; index < 10; ++index)
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 26, 0.0f, 0.0f, 0, new Color(), 0.8f);
				}
				else if (this.type == 24)
				{
					for (int index = 0; index < 10; ++index)
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 1, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 0, new Color(), 0.75f);
				}
				else if (this.type == 27)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int index1 = 0; index1 < 30; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 172, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 100, new Color(), 1f);
						Main.dust[index2].noGravity = true;
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 172, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 100, new Color(), 0.5f);
					}
				}
				else if (this.type == 38)
				{
					for (int index = 0; index < 10; ++index)
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 42, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 0, new Color(), 1f);
				}
				else if (this.type == 44 || this.type == 45)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int index1 = 0; index1 < 30; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 27, this.velocity.X, this.velocity.Y, 100, new Color(), 1.7f);
						Main.dust[index2].noGravity = true;
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 27, this.velocity.X, this.velocity.Y, 100, new Color(), 1f);
					}
				}
				else if (this.type == 41)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int index = 0; index < 10; ++index)
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
					for (int index1 = 0; index1 < 5; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 2.5f);
						Main.dust[index2].noGravity = true;
						Main.dust[index2].velocity *= 3f;
						int index3 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 1.5f);
						Main.dust[index3].velocity *= 2f;
					}
					int index4 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					Main.gore[index4].velocity *= 0.4f;
					Main.gore[index4].velocity.X += (float)Main.rand.Next(-10, 11) * 0.1f;
					Main.gore[index4].velocity.Y += (float)Main.rand.Next(-10, 11) * 0.1f;
					int index5 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					Main.gore[index5].velocity *= 0.4f;
					Main.gore[index5].velocity.X += (float)Main.rand.Next(-10, 11) * 0.1f;
					Main.gore[index5].velocity.Y += (float)Main.rand.Next(-10, 11) * 0.1f;
					if (this.owner == Main.myPlayer)
					{
						this.penetrate = -1;
						this.position.X += (float)(this.width / 2);
						this.position.Y += (float)(this.height / 2);
						this.width = 64;
						this.height = 64;
						this.position.X -= (float)(this.width / 2);
						this.position.Y -= (float)(this.height / 2);
						this.Damage();
					}
				}
				else if (this.type == 306)
				{
					Main.PlaySound(3, (int)this.position.X, (int)this.position.Y, 1);
					for (int index1 = 0; index1 < 20; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 184, 0.0f, 0.0f, 0, new Color(), 1f);
						Main.dust[index2].scale *= 1.1f;
						Main.dust[index2].noGravity = true;
					}
					for (int index1 = 0; index1 < 30; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 184, 0.0f, 0.0f, 0, new Color(), 1f);
						Main.dust[index2].velocity *= 2.5f;
						Main.dust[index2].scale *= 0.8f;
						Main.dust[index2].noGravity = true;
					}
					if (this.owner == Main.myPlayer)
					{
						int num = 2;
						if (Main.rand.Next(10) == 0)
							++num;
						if (Main.rand.Next(10) == 0)
							++num;
						for (int index = 0; index < num; ++index)
							Projectile.NewProjectile(this.position.X, this.position.Y, (float)Main.rand.Next(-35, 36) * 0.02f * 10f, (float)Main.rand.Next(-35, 36) * 0.02f * 10f, 307, (int)((double)this.damage * 0.55), (float)(int)((double)this.knockBack * 0.3), Main.myPlayer, 0.0f, 0.0f);
					}
				}
				else if (this.type == 183)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int index1 = 0; index1 < 20; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
						Main.dust[index2].velocity *= 1f;
					}
					int index3 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					++Main.gore[index3].velocity.X;
					++Main.gore[index3].velocity.Y;
					Main.gore[index3].velocity *= 0.3f;
					int index4 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					--Main.gore[index4].velocity.X;
					++Main.gore[index4].velocity.Y;
					Main.gore[index4].velocity *= 0.3f;
					int index5 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					++Main.gore[index5].velocity.X;
					--Main.gore[index5].velocity.Y;
					Main.gore[index5].velocity *= 0.3f;
					int index6 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					--Main.gore[index6].velocity.X;
					--Main.gore[index6].velocity.Y;
					Main.gore[index6].velocity *= 0.3f;
					if (this.owner == Main.myPlayer)
					{
						int num = Main.rand.Next(15, 25);
						for (int index1 = 0; index1 < num; ++index1)
							Projectile.NewProjectile(this.position.X, this.position.Y, (float)Main.rand.Next(-35, 36) * 0.02f, (float)Main.rand.Next(-35, 36) * 0.02f, 181, this.damage, 0.0f, Main.myPlayer, 0.0f, 0.0f);
					}
				}
				else if (this.aiStyle == 34)
				{
					if (this.owner != Main.myPlayer)
						this.timeLeft = 60;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					if (this.type == 167)
					{
						for (int index1 = 0; index1 < 400; ++index1)
						{
							float num1 = 16f;
							if (index1 < 300)
								num1 = 12f;
							if (index1 < 200)
								num1 = 8f;
							if (index1 < 100)
								num1 = 4f;
							int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, 130, 0.0f, 0.0f, 100, new Color(), 1f);
							float num2 = Main.dust[index2].velocity.X;
							float num3 = Main.dust[index2].velocity.Y;
							if ((double)num2 == 0.0 && (double)num3 == 0.0)
								num2 = 1f;
							float num4 = (float)Math.Sqrt((double)num2 * (double)num2 + (double)num3 * (double)num3);
							float num5 = num1 / num4;
							float num6 = num2 * num5;
							float num7 = num3 * num5;
							Main.dust[index2].velocity *= 0.5f;
							Main.dust[index2].velocity.X += num6;
							Main.dust[index2].velocity.Y += num7;
							Main.dust[index2].scale = 1.3f;
							Main.dust[index2].noGravity = true;
						}
					}
					if (this.type == 168)
					{
						for (int index1 = 0; index1 < 400; ++index1)
						{
							float num1 = (float)(2.0 * ((double)index1 / 100.0));
							if (index1 > 100)
								num1 = 10f;
							if (index1 > 250)
								num1 = 13f;
							int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, 131, 0.0f, 0.0f, 100, new Color(), 1f);
							float num2 = Main.dust[index2].velocity.X;
							float num3 = Main.dust[index2].velocity.Y;
							if ((double)num2 == 0.0 && (double)num3 == 0.0)
								num2 = 1f;
							float num4 = (float)Math.Sqrt((double)num2 * (double)num2 + (double)num3 * (double)num3);
							float num5 = num1 / num4;
							float num6;
							float num7;
							if (index1 <= 200)
							{
								num6 = num2 * num5;
								num7 = num3 * num5;
							}
							else
							{
								num6 = (float)((double)num2 * (double)num5 * 1.25);
								num7 = (float)((double)num3 * (double)num5 * 0.75);
							}
							Main.dust[index2].velocity *= 0.5f;
							Main.dust[index2].velocity.X += num6;
							Main.dust[index2].velocity.Y += num7;
							if (index1 > 100)
							{
								Main.dust[index2].scale = 1.3f;
								Main.dust[index2].noGravity = true;
							}
						}
					}
					if (this.type == 169)
					{
						for (int index1 = 0; index1 < 400; ++index1)
						{
							int Type = 132;
							float num1 = 14f;
							if (index1 > 100)
								num1 = 10f;
							if (index1 > 100)
								Type = 133;
							if (index1 > 200)
								num1 = 6f;
							if (index1 > 200)
								Type = 132;
							if (index1 > 300)
								num1 = 6f;
							if (index1 > 300)
								Type = 133;
							int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, Type, 0.0f, 0.0f, 100, new Color(), 1f);
							float num2 = Main.dust[index2].velocity.X;
							float num3 = Main.dust[index2].velocity.Y;
							if ((double)num2 == 0.0 && (double)num3 == 0.0)
								num2 = 1f;
							float num4 = (float)Math.Sqrt((double)num2 * (double)num2 + (double)num3 * (double)num3);
							float num5 = num1 / num4;
							float num6;
							float num7;
							if (index1 > 300)
							{
								num6 = (float)((double)num2 * (double)num5 * 0.5);
								num7 = num3 * num5;
							}
							else if (index1 > 200)
							{
								num6 = num2 * num5;
								num7 = (float)((double)num3 * (double)num5 * 0.5);
							}
							else
							{
								num6 = num2 * num5;
								num7 = num3 * num5;
							}
							Main.dust[index2].velocity *= 0.5f;
							Main.dust[index2].velocity.X += num6;
							Main.dust[index2].velocity.Y += num7;
							if (index1 <= 200)
							{
								Main.dust[index2].scale = 1.3f;
								Main.dust[index2].noGravity = true;
							}
						}
					}
					if (this.type == 170)
					{
						for (int index1 = 0; index1 < 400; ++index1)
						{
							int Type = 133;
							float num1 = 16f;
							if (index1 > 100)
								num1 = 11f;
							if (index1 > 100)
								Type = 134;
							if (index1 > 200)
								num1 = 8f;
							if (index1 > 200)
								Type = 133;
							if (index1 > 300)
								num1 = 5f;
							if (index1 > 300)
								Type = 134;
							int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, Type, 0.0f, 0.0f, 100, new Color(), 1f);
							float num2 = Main.dust[index2].velocity.X;
							float num3 = Main.dust[index2].velocity.Y;
							if ((double)num2 == 0.0 && (double)num3 == 0.0)
								num2 = 1f;
							float num4 = (float)Math.Sqrt((double)num2 * (double)num2 + (double)num3 * (double)num3);
							float num5 = num1 / num4;
							float num6;
							float num7;
							if (index1 > 300)
							{
								num6 = (float)((double)num2 * (double)num5 * 0.699999988079071);
								num7 = num3 * num5;
							}
							else if (index1 > 200)
							{
								num6 = num2 * num5;
								num7 = (float)((double)num3 * (double)num5 * 0.699999988079071);
							}
							else if (index1 > 100)
							{
								num6 = (float)((double)num2 * (double)num5 * 0.699999988079071);
								num7 = num3 * num5;
							}
							else
							{
								num6 = num2 * num5;
								num7 = (float)((double)num3 * (double)num5 * 0.699999988079071);
							}
							Main.dust[index2].velocity *= 0.5f;
							Main.dust[index2].velocity.X += num6;
							Main.dust[index2].velocity.Y += num7;
							if (Main.rand.Next(3) != 0)
							{
								Main.dust[index2].scale = 1.3f;
								Main.dust[index2].noGravity = true;
							}
						}
					}
					this.position.X += (float)(this.width / 2);
					this.position.Y += (float)(this.height / 2);
					this.width = 192;
					this.height = 192;
					this.position.X -= (float)(this.width / 2);
					this.position.Y -= (float)(this.height / 2);
					this.penetrate = -1;
					this.Damage();
				}
				else if (this.type == 312)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					this.position.X += (float)(this.width / 2);
					this.position.Y += (float)(this.height / 2);
					this.width = 22;
					this.height = 22;
					this.position.X -= (float)(this.width / 2);
					this.position.Y -= (float)(this.height / 2);
					for (int index1 = 0; index1 < 30; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
						Main.dust[index2].velocity *= 1.4f;
					}
					for (int index1 = 0; index1 < 20; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 3.5f);
						Main.dust[index2].noGravity = true;
						Main.dust[index2].velocity *= 7f;
						int index3 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 1.5f);
						Main.dust[index3].velocity *= 3f;
					}
					for (int index1 = 0; index1 < 2; ++index1)
					{
						float num = 0.4f;
						if (index1 == 1)
							num = 0.8f;
						int index2 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
						Main.gore[index2].velocity *= num;
						++Main.gore[index2].velocity.X;
						++Main.gore[index2].velocity.Y;
						int index3 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
						Main.gore[index3].velocity *= num;
						--Main.gore[index3].velocity.X;
						++Main.gore[index3].velocity.Y;
						int index4 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
						Main.gore[index4].velocity *= num;
						++Main.gore[index4].velocity.X;
						--Main.gore[index4].velocity.Y;
						int index5 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
						Main.gore[index5].velocity *= num;
						--Main.gore[index5].velocity.X;
						--Main.gore[index5].velocity.Y;
					}
					this.position.X += (float)(this.width / 2);
					this.position.Y += (float)(this.height / 2);
					this.width = 128;
					this.height = 128;
					this.position.X -= (float)(this.width / 2);
					this.position.Y -= (float)(this.height / 2);
					this.Damage();
				}
				else if (this.type == 133 || this.type == 134 || (this.type == 135 || this.type == 136) || (this.type == 137 || this.type == 138 || this.type == 303))
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					this.position.X += (float)(this.width / 2);
					this.position.Y += (float)(this.height / 2);
					this.width = 22;
					this.height = 22;
					this.position.X -= (float)(this.width / 2);
					this.position.Y -= (float)(this.height / 2);
					for (int index1 = 0; index1 < 30; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
						Main.dust[index2].velocity *= 1.4f;
					}
					for (int index1 = 0; index1 < 20; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 3.5f);
						Main.dust[index2].noGravity = true;
						Main.dust[index2].velocity *= 7f;
						int index3 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 1.5f);
						Main.dust[index3].velocity *= 3f;
					}
					for (int index1 = 0; index1 < 2; ++index1)
					{
						float num = 0.4f;
						if (index1 == 1)
							num = 0.8f;
						int index2 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
						Main.gore[index2].velocity *= num;
						++Main.gore[index2].velocity.X;
						++Main.gore[index2].velocity.Y;
						int index3 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
						Main.gore[index3].velocity *= num;
						--Main.gore[index3].velocity.X;
						++Main.gore[index3].velocity.Y;
						int index4 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
						Main.gore[index4].velocity *= num;
						++Main.gore[index4].velocity.X;
						--Main.gore[index4].velocity.Y;
						int index5 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
						Main.gore[index5].velocity *= num;
						--Main.gore[index5].velocity.X;
						--Main.gore[index5].velocity.Y;
					}
				}
				else if (this.type == 139 || this.type == 140 || (this.type == 141 || this.type == 142) || (this.type == 143 || this.type == 144))
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					this.position.X += (float)(this.width / 2);
					this.position.Y += (float)(this.height / 2);
					this.width = 80;
					this.height = 80;
					this.position.X -= (float)(this.width / 2);
					this.position.Y -= (float)(this.height / 2);
					for (int index1 = 0; index1 < 40; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0.0f, 0.0f, 100, new Color(), 2f);
						Main.dust[index2].velocity *= 3f;
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[index2].scale = 0.5f;
							Main.dust[index2].fadeIn = (float)(1.0 + (double)Main.rand.Next(10) * 0.100000001490116);
						}
					}
					for (int index1 = 0; index1 < 70; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 3f);
						Main.dust[index2].noGravity = true;
						Main.dust[index2].velocity *= 5f;
						int index3 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 2f);
						Main.dust[index3].velocity *= 2f;
					}
					for (int index1 = 0; index1 < 3; ++index1)
					{
						float num = 0.33f;
						if (index1 == 1)
							num = 0.66f;
						if (index1 == 2)
							num = 1f;
						int index2 = Gore.NewGore(new Vector2((float)((double)this.position.X + (double)(this.width / 2) - 24.0), (float)((double)this.position.Y + (double)(this.height / 2) - 24.0)), new Vector2(), Main.rand.Next(61, 64), 1f);
						Main.gore[index2].velocity *= num;
						++Main.gore[index2].velocity.X;
						++Main.gore[index2].velocity.Y;
						int index3 = Gore.NewGore(new Vector2((float)((double)this.position.X + (double)(this.width / 2) - 24.0), (float)((double)this.position.Y + (double)(this.height / 2) - 24.0)), new Vector2(), Main.rand.Next(61, 64), 1f);
						Main.gore[index3].velocity *= num;
						--Main.gore[index3].velocity.X;
						++Main.gore[index3].velocity.Y;
						int index4 = Gore.NewGore(new Vector2((float)((double)this.position.X + (double)(this.width / 2) - 24.0), (float)((double)this.position.Y + (double)(this.height / 2) - 24.0)), new Vector2(), Main.rand.Next(61, 64), 1f);
						Main.gore[index4].velocity *= num;
						++Main.gore[index4].velocity.X;
						--Main.gore[index4].velocity.Y;
						int index5 = Gore.NewGore(new Vector2((float)((double)this.position.X + (double)(this.width / 2) - 24.0), (float)((double)this.position.Y + (double)(this.height / 2) - 24.0)), new Vector2(), Main.rand.Next(61, 64), 1f);
						Main.gore[index5].velocity *= num;
						--Main.gore[index5].velocity.X;
						--Main.gore[index5].velocity.Y;
					}
					this.position.X += (float)(this.width / 2);
					this.position.Y += (float)(this.height / 2);
					this.width = 10;
					this.height = 10;
					this.position.X -= (float)(this.width / 2);
					this.position.Y -= (float)(this.height / 2);
				}
				else if (this.type == 246)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int index1 = 0; index1 < 10; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
						Main.dust[index2].velocity *= 0.9f;
					}
					for (int index1 = 0; index1 < 5; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 2.5f);
						Main.dust[index2].noGravity = true;
						Main.dust[index2].velocity *= 3f;
						int index3 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 1.5f);
						Main.dust[index3].velocity *= 2f;
					}
					int index4 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					Main.gore[index4].velocity *= 0.3f;
					Main.gore[index4].velocity.X += (float)Main.rand.Next(-1, 2);
					Main.gore[index4].velocity.Y += (float)Main.rand.Next(-1, 2);
					if (this.owner == Main.myPlayer)
					{
						int num1 = Main.rand.Next(2, 6);
						for (int index1 = 0; index1 < num1; ++index1)
						{
							float num2 = (float)Main.rand.Next(-100, 101) + 0.01f;
							float num3 = (float)Main.rand.Next(-100, 101);
							float num4 = num2 - 0.01f;
							float num5 = 8f / (float)Math.Sqrt((double)num4 * (double)num4 + (double)num3 * (double)num3);
							Projectile.NewProjectile(this.center().X - this.lastVelocity.X, this.center().Y - this.lastVelocity.Y, num4 * num5, num3 * num5, 249, this.damage, this.knockBack, this.owner, 0.0f, 0.0f);
						}
					}
					this.position.X += (float)(this.width / 2);
					this.position.Y += (float)(this.height / 2);
					this.width = 150;
					this.height = 150;
					this.position.X -= (float)(this.width / 2);
					this.position.Y -= (float)(this.height / 2);
					this.penetrate = -1;
					this.Damage();
				}
				else if (this.type == 249)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int index1 = 0; index1 < 7; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
						Main.dust[index2].velocity *= 0.8f;
					}
					for (int index1 = 0; index1 < 2; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 2.5f);
						Main.dust[index2].noGravity = true;
						Main.dust[index2].velocity *= 2.5f;
						int index3 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 1.5f);
						Main.dust[index3].velocity *= 1.5f;
					}
					int index = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					Main.gore[index].velocity *= 0.2f;
					Main.gore[index].velocity.X += (float)Main.rand.Next(-1, 2);
					Main.gore[index].velocity.Y += (float)Main.rand.Next(-1, 2);
					this.position.X += (float)(this.width / 2);
					this.position.Y += (float)(this.height / 2);
					this.width = 100;
					this.height = 100;
					this.position.X -= (float)(this.width / 2);
					this.position.Y -= (float)(this.height / 2);
					this.penetrate = -1;
					this.Damage();
				}
				else if (this.type == 28 || this.type == 30 || (this.type == 37 || this.type == 75) || (this.type == 102 || this.type == 164))
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					this.position.X += (float)(this.width / 2);
					this.position.Y += (float)(this.height / 2);
					this.width = 22;
					this.height = 22;
					this.position.X -= (float)(this.width / 2);
					this.position.Y -= (float)(this.height / 2);
					for (int index1 = 0; index1 < 20; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
						Main.dust[index2].velocity *= 1.4f;
					}
					for (int index1 = 0; index1 < 10; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 2.5f);
						Main.dust[index2].noGravity = true;
						Main.dust[index2].velocity *= 5f;
						int index3 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 1.5f);
						Main.dust[index3].velocity *= 3f;
					}
					int index4 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					Main.gore[index4].velocity *= 0.4f;
					++Main.gore[index4].velocity.X;
					++Main.gore[index4].velocity.Y;
					int index5 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					Main.gore[index5].velocity *= 0.4f;
					--Main.gore[index5].velocity.X;
					++Main.gore[index5].velocity.Y;
					int index6 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					Main.gore[index6].velocity *= 0.4f;
					++Main.gore[index6].velocity.X;
					--Main.gore[index6].velocity.Y;
					int index7 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
					Main.gore[index7].velocity *= 0.4f;
					--Main.gore[index7].velocity.X;
					--Main.gore[index7].velocity.Y;
				}
				else if (this.type == 29 || this.type == 108)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					if (this.type == 29)
					{
						this.position.X += (float)(this.width / 2);
						this.position.Y += (float)(this.height / 2);
						this.width = 200;
						this.height = 200;
						this.position.X -= (float)(this.width / 2);
						this.position.Y -= (float)(this.height / 2);
					}
					for (int index1 = 0; index1 < 50; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0.0f, 0.0f, 100, new Color(), 2f);
						Main.dust[index2].velocity *= 1.4f;
					}
					for (int index1 = 0; index1 < 80; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 3f);
						Main.dust[index2].noGravity = true;
						Main.dust[index2].velocity *= 5f;
						int index3 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 2f);
						Main.dust[index3].velocity *= 3f;
					}
					for (int index1 = 0; index1 < 2; ++index1)
					{
						int index2 = Gore.NewGore(new Vector2((float)((double)this.position.X + (double)(this.width / 2) - 24.0), (float)((double)this.position.Y + (double)(this.height / 2) - 24.0)), new Vector2(), Main.rand.Next(61, 64), 1f);
						Main.gore[index2].scale = 1.5f;
						Main.gore[index2].velocity.X += 1.5f;
						Main.gore[index2].velocity.Y += 1.5f;
						int index3 = Gore.NewGore(new Vector2((float)((double)this.position.X + (double)(this.width / 2) - 24.0), (float)((double)this.position.Y + (double)(this.height / 2) - 24.0)), new Vector2(), Main.rand.Next(61, 64), 1f);
						Main.gore[index3].scale = 1.5f;
						Main.gore[index3].velocity.X -= 1.5f;
						Main.gore[index3].velocity.Y += 1.5f;
						int index4 = Gore.NewGore(new Vector2((float)((double)this.position.X + (double)(this.width / 2) - 24.0), (float)((double)this.position.Y + (double)(this.height / 2) - 24.0)), new Vector2(), Main.rand.Next(61, 64), 1f);
						Main.gore[index4].scale = 1.5f;
						Main.gore[index4].velocity.X += 1.5f;
						Main.gore[index4].velocity.Y -= 1.5f;
						int index5 = Gore.NewGore(new Vector2((float)((double)this.position.X + (double)(this.width / 2) - 24.0), (float)((double)this.position.Y + (double)(this.height / 2) - 24.0)), new Vector2(), Main.rand.Next(61, 64), 1f);
						Main.gore[index5].scale = 1.5f;
						Main.gore[index5].velocity.X -= 1.5f;
						Main.gore[index5].velocity.Y -= 1.5f;
					}
					this.position.X += (float)(this.width / 2);
					this.position.Y += (float)(this.height / 2);
					this.width = 10;
					this.height = 10;
					this.position.X -= (float)(this.width / 2);
					this.position.Y -= (float)(this.height / 2);
				}
				else if (this.type == 69)
				{
					Main.PlaySound(13, (int)this.position.X, (int)this.position.Y, 1);
					for (int index = 0; index < 5; ++index)
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 13, 0.0f, 0.0f, 0, new Color(), 1f);
					for (int index1 = 0; index1 < 30; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 33, 0.0f, -2f, 0, new Color(), 1.1f);
						Main.dust[index2].alpha = 100;
						Main.dust[index2].velocity.X *= 1.5f;
						Main.dust[index2].velocity *= 3f;
					}
				}
				else if (this.type == 70)
				{
					Main.PlaySound(13, (int)this.position.X, (int)this.position.Y, 1);
					for (int index = 0; index < 5; ++index)
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 13, 0.0f, 0.0f, 0, new Color(), 1f);
					for (int index1 = 0; index1 < 30; ++index1)
					{
						int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 52, 0.0f, -2f, 0, new Color(), 1.1f);
						Main.dust[index2].alpha = 100;
						Main.dust[index2].velocity.X *= 1.5f;
						Main.dust[index2].velocity *= 3f;
					}
				}
				else if (this.type == 114 || this.type == 115)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int index1 = 4; index1 < 31; ++index1)
					{
						float num1 = this.lastVelocity.X * (30f / (float)index1);
						float num2 = this.lastVelocity.Y * (30f / (float)index1);
						int index2 = Dust.NewDust(new Vector2(this.position.X - num1, this.position.Y - num2), 8, 8, 27, this.lastVelocity.X, this.lastVelocity.Y, 100, new Color(), 1.4f);
						Main.dust[index2].noGravity = true;
						Main.dust[index2].velocity *= 0.5f;
						int index3 = Dust.NewDust(new Vector2(this.position.X - num1, this.position.Y - num2), 8, 8, 27, this.lastVelocity.X, this.lastVelocity.Y, 100, new Color(), 0.9f);
						Main.dust[index3].velocity *= 0.5f;
					}
				}
				else if (this.type == 116)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int index1 = 4; index1 < 31; ++index1)
					{
						float num1 = this.lastVelocity.X * (30f / (float)index1);
						float num2 = this.lastVelocity.Y * (30f / (float)index1);
						int index2 = Dust.NewDust(new Vector2(this.position.X - num1, this.position.Y - num2), 8, 8, 64, this.lastVelocity.X, this.lastVelocity.Y, 100, new Color(), 1.8f);
						Main.dust[index2].noGravity = true;
						int index3 = Dust.NewDust(new Vector2(this.position.X - num1, this.position.Y - num2), 8, 8, 64, this.lastVelocity.X, this.lastVelocity.Y, 100, new Color(), 1.4f);
						Main.dust[index3].noGravity = true;
					}
				}
				else if (this.type == 173)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int index1 = 4; index1 < 24; ++index1)
					{
						float num1 = this.lastVelocity.X * (30f / (float)index1);
						float num2 = this.lastVelocity.Y * (30f / (float)index1);
						int Type;
						switch (Main.rand.Next(3))
						{
							case 0:
								Type = 15;
								break;
							case 1:
								Type = 57;
								break;
							default:
								Type = 58;
								break;
						}
						int index2 = Dust.NewDust(new Vector2(this.position.X - num1, this.position.Y - num2), 8, 8, Type, this.lastVelocity.X * 0.2f, this.lastVelocity.Y * 0.2f, 100, new Color(), 1.8f);
						Main.dust[index2].velocity *= 1.5f;
						Main.dust[index2].noGravity = true;
					}
				}
				else if (this.type == 132)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int index1 = 4; index1 < 31; ++index1)
					{
						float num1 = this.lastVelocity.X * (30f / (float)index1);
						float num2 = this.lastVelocity.Y * (30f / (float)index1);
						int index2 = Dust.NewDust(new Vector2(this.lastPosition.X - num1, this.lastPosition.Y - num2), 8, 8, 107, this.lastVelocity.X, this.lastVelocity.Y, 100, new Color(), 1.8f);
						Main.dust[index2].noGravity = true;
						Main.dust[index2].velocity *= 0.5f;
						int index3 = Dust.NewDust(new Vector2(this.lastPosition.X - num1, this.lastPosition.Y - num2), 8, 8, 107, this.lastVelocity.X, this.lastVelocity.Y, 100, new Color(), 1.4f);
						Main.dust[index3].velocity *= 0.05f;
					}
				}
				else if (this.type == 156)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int index1 = 4; index1 < 31; ++index1)
					{
						float num1 = this.lastVelocity.X * (30f / (float)index1);
						float num2 = this.lastVelocity.Y * (30f / (float)index1);
						int index2 = Dust.NewDust(new Vector2(this.lastPosition.X - num1, this.lastPosition.Y - num2), 8, 8, 73, this.lastVelocity.X, this.lastVelocity.Y, (int)byte.MaxValue, new Color(), 1.8f);
						Main.dust[index2].noGravity = true;
						Main.dust[index2].velocity *= 0.5f;
						int index3 = Dust.NewDust(new Vector2(this.lastPosition.X - num1, this.lastPosition.Y - num2), 8, 8, 73, this.lastVelocity.X, this.lastVelocity.Y, (int)byte.MaxValue, new Color(), 1.4f);
						Main.dust[index3].velocity *= 0.05f;
						Main.dust[index3].noGravity = true;
					}
				}
				else if (this.type == 157)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int index1 = 4; index1 < 31; ++index1)
					{
						int index2 = Dust.NewDust(this.position, this.width, this.height, 107, this.lastVelocity.X, this.lastVelocity.Y, 100, new Color(), 1.8f);
						Main.dust[index2].noGravity = true;
						Main.dust[index2].velocity *= 0.5f;
					}
				}
			}
			if (this.owner == Main.myPlayer)
			{
				if (this.type == 28 || this.type == 29 || (this.type == 37 || this.type == 108) || (this.type == 136 || this.type == 137 || (this.type == 138 || this.type == 142)) || (this.type == 143 || this.type == 144))
				{
					int num1 = 3;
					if (this.type == 28 || this.type == 37)
						num1 = 4;
					if (this.type == 29)
						num1 = 7;
					if (this.type == 142 || this.type == 143 || this.type == 144)
						num1 = 5;
					if (this.type == 108)
						num1 = 10;
					int num2 = (int)((double)this.position.X / 16.0 - (double)num1);
					int num3 = (int)((double)this.position.X / 16.0 + (double)num1);
					int num4 = (int)((double)this.position.Y / 16.0 - (double)num1);
					int num5 = (int)((double)this.position.Y / 16.0 + (double)num1);
					if (num2 < 0)
						num2 = 0;
					if (num3 > Main.maxTilesX)
						num3 = Main.maxTilesX;
					if (num4 < 0)
						num4 = 0;
					if (num5 > Main.maxTilesY)
						num5 = Main.maxTilesY;
					bool flag1 = false;
					for (int index1 = num2; index1 <= num3; ++index1)
					{
						for (int index2 = num4; index2 <= num5; ++index2)
						{
							float num6 = Math.Abs((float)index1 - this.position.X / 16f);
							float num7 = Math.Abs((float)index2 - this.position.Y / 16f);
							if (Math.Sqrt((double)num6 * (double)num6 + (double)num7 * (double)num7) < (double)num1 && Main.tile[index1, index2] != null && (int)Main.tile[index1, index2].wall == 0)
							{
								flag1 = true;
								break;
							}
						}
					}
					for (int i1 = num2; i1 <= num3; ++i1)
					{
						for (int j1 = num4; j1 <= num5; ++j1)
						{
							float num6 = Math.Abs((float)i1 - this.position.X / 16f);
							float num7 = Math.Abs((float)j1 - this.position.Y / 16f);
							if (Math.Sqrt((double)num6 * (double)num6 + (double)num7 * (double)num7) < (double)num1)
							{
								bool flag2 = true;
								if (Main.tile[i1, j1] != null && Main.tile[i1, j1].active())
								{
									flag2 = true;
									if (Main.tileDungeon[(int)Main.tile[i1, j1].type] || (int)Main.tile[i1, j1].type == 21 || ((int)Main.tile[i1, j1].type == 26 || (int)Main.tile[i1, j1].type == 107) || ((int)Main.tile[i1, j1].type == 108 || (int)Main.tile[i1, j1].type == 111 || ((int)Main.tile[i1, j1].type == 226 || (int)Main.tile[i1, j1].type == 237)) || ((int)Main.tile[i1, j1].type == 221 || (int)Main.tile[i1, j1].type == 222 || ((int)Main.tile[i1, j1].type == 223 || (int)Main.tile[i1, j1].type == 211)))
										flag2 = false;
									if (!Main.hardMode && (int)Main.tile[i1, j1].type == 58)
										flag2 = false;
									if (flag2)
									{
										WorldGen.KillTile(i1, j1, false, false, false);
										if (!Main.tile[i1, j1].active() && Main.netMode != 0)
											NetMessage.SendData(17, -1, -1, "", 0, (float)i1, (float)j1, 0.0f, 0);
									}
								}
								if (flag2)
								{
									for (int i2 = i1 - 1; i2 <= i1 + 1; ++i2)
									{
										for (int j2 = j1 - 1; j2 <= j1 + 1; ++j2)
										{
											if (Main.tile[i2, j2] != null && (int)Main.tile[i2, j2].wall > 0 && flag1)
											{
												WorldGen.KillWall(i2, j2, false);
												if ((int)Main.tile[i2, j2].wall == 0 && Main.netMode != 0)
													NetMessage.SendData(17, -1, -1, "", 2, (float)i2, (float)j2, 0.0f, 0);
											}
										}
									}
								}
							}
						}
					}
				}
				if (Main.netMode != 0)
				{
					NetMessage.SendData(29, -1, -1, "", this.identity, (float)this.owner, 0.0f, 0.0f, 0);
				}
				if (!this.noDropItem)
				{
					int number = -1;
					if (this.aiStyle == 10)
					{
						int i = (int)((double)this.position.X + (double)(this.width / 2)) / 16;
						int j = (int)((double)this.position.Y + (double)(this.width / 2)) / 16;
						int type = 0;
						int Type = 2;
						if (this.type == 109)
						{
							type = 147;
							Type = 0;
						}
						if (this.type == 31)
						{
							type = 53;
							Type = 0;
						}
						if (this.type == 42)
						{
							type = 53;
							Type = 0;
						}
						if (this.type == 56)
						{
							type = 112;
							Type = 0;
						}
						if (this.type == 65)
						{
							type = 112;
							Type = 0;
						}
						if (this.type == 67)
						{
							type = 116;
							Type = 0;
						}
						if (this.type == 68)
						{
							type = 116;
							Type = 0;
						}
						if (this.type == 71)
						{
							type = 123;
							Type = 0;
						}
						if (this.type == 39)
						{
							type = 59;
							Type = 176;
						}
						if (this.type == 40)
						{
							type = 57;
							Type = 172;
						}
						if (this.type == 179)
						{
							type = 224;
							Type = 0;
						}
						if (this.type == 241)
						{
							type = 234;
							Type = 0;
						}
						if (Main.tile[i, j].halfBrick() && (double)this.velocity.Y > 0.0 && (double)Math.Abs(this.velocity.Y) > (double)Math.Abs(this.velocity.X))
							--j;
						if (!Main.tile[i, j].active())
						{
							WorldGen.PlaceTile(i, j, type, false, true, -1, 0);
							if (Main.tile[i, j].active() && (int)Main.tile[i, j].type == type)
							{
								NetMessage.SendData(17, -1, -1, "", 1, (float)i, (float)j, (float)type, 0);
							}
							else if (Type > 0)
								number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, Type, 1, false, 0, false);
						}
						else if (Type > 0)
							number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, Type, 1, false, 0, false);
					}
					if (this.type == 1 && Main.rand.Next(3) == 0)
						number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0, false);
					if (this.type == 103 && Main.rand.Next(6) == 0)
						number = Main.rand.Next(3) != 0 ? Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0, false) : Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 545, 1, false, 0, false);
					if (this.type == 2 && Main.rand.Next(3) == 0)
						number = Main.rand.Next(3) != 0 ? Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0, false) : Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 41, 1, false, 0, false);
					if (this.type == 172 && Main.rand.Next(3) == 0)
						number = Main.rand.Next(3) != 0 ? Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0, false) : Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 988, 1, false, 0, false);
					if (this.type == 171)
					{
						if ((double)this.ai[1] == 0.0)
							number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 985, 1, false, 0, false);
						else if ((double)this.ai[1] < 10.0)
							number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 965, (int)(10.0 - (double)this.ai[1]), false, 0, false);
					}
					if (this.type == 91 && Main.rand.Next(6) == 0)
						number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 516, 1, false, 0, false);
					if (this.type == 50 && Main.rand.Next(3) == 0)
						number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 282, 1, false, 0, false);
					if (this.type == 53 && Main.rand.Next(3) == 0)
						number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 286, 1, false, 0, false);
					if (this.type == 48 && Main.rand.Next(2) == 0)
						number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 279, 1, false, 0, false);
					if (this.type == 54 && Main.rand.Next(2) == 0)
						number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 287, 1, false, 0, false);
					if (this.type == 3 && Main.rand.Next(2) == 0)
						number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 42, 1, false, 0, false);
					if (this.type == 4 && Main.rand.Next(4) == 0)
						number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 47, 1, false, 0, false);
					if (this.type == 12 && this.damage > 100)
						number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 75, 1, false, 0, false);
					if (this.type == 155)
						number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 859, 1, false, 0, false);
					if (this.type == 21 && Main.rand.Next(2) == 0)
						number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 154, 1, false, 0, false);
					if (Main.netMode == 1 && number >= 0)
						NetMessage.SendData(21, -1, -1, "", number, 0.0f, 0.0f, 0.0f, 0);
				}
				if (this.type == 69 || this.type == 70)
				{
					int num1 = (int)((double)this.position.X + (double)(this.width / 2)) / 16;
					int num2 = (int)((double)this.position.Y + (double)(this.height / 2)) / 16;
					for (int index1 = num1 - 4; index1 <= num1 + 4; ++index1)
					{
						for (int index2 = num2 - 4; index2 <= num2 + 4; ++index2)
						{
							if (Math.Abs(index1 - num1) + Math.Abs(index2 - num2) < 6)
							{
								if (this.type == 69)
								{
									if ((int)Main.tile[index1, index2].type == 2)
									{
										Main.tile[index1, index2].type = (byte)109;
										WorldGen.SquareTileFrame(index1, index2, true);
										NetMessage.SendTileSquare(-1, index1, index2, 1);
									}
									else if ((int)Main.tile[index1, index2].type == 1 || Main.tileMoss[(int)Main.tile[index1, index2].type])
									{
										Main.tile[index1, index2].type = (byte)117;
										WorldGen.SquareTileFrame(index1, index2, true);
										NetMessage.SendTileSquare(-1, index1, index2, 1);
									}
									else if ((int)Main.tile[index1, index2].type == 53 || (int)Main.tile[index1, index2].type == 234)
									{
										Main.tile[index1, index2].type = (byte)116;
										WorldGen.SquareTileFrame(index1, index2, true);
										NetMessage.SendTileSquare(-1, index1, index2, 1);
									}
									else if ((int)Main.tile[index1, index2].type == 23 || (int)Main.tile[index1, index2].type == 199)
									{
										Main.tile[index1, index2].type = (byte)109;
										WorldGen.SquareTileFrame(index1, index2, true);
										NetMessage.SendTileSquare(-1, index1, index2, 1);
									}
									else if ((int)Main.tile[index1, index2].type == 25 || (int)Main.tile[index1, index2].type == 203)
									{
										Main.tile[index1, index2].type = (byte)117;
										WorldGen.SquareTileFrame(index1, index2, true);
										NetMessage.SendTileSquare(-1, index1, index2, 1);
									}
									else if ((int)Main.tile[index1, index2].type == 161 || (int)Main.tile[index1, index2].type == 163 || (int)Main.tile[index1, index2].type == 200)
									{
										Main.tile[index1, index2].type = (byte)164;
										WorldGen.SquareTileFrame(index1, index2, true);
										NetMessage.SendTileSquare(-1, index1, index2, 1);
									}
									else if ((int)Main.tile[index1, index2].type == 112)
									{
										Main.tile[index1, index2].type = (byte)116;
										WorldGen.SquareTileFrame(index1, index2, true);
										NetMessage.SendTileSquare(-1, index1, index2, 1);
									}
									else if ((int)Main.tile[index1, index2].type == 161 || (int)Main.tile[index1, index2].type == 163)
									{
										Main.tile[index1, index2].type = (byte)164;
										WorldGen.SquareTileFrame(index1, index2, true);
										NetMessage.SendTileSquare(-1, index1, index2, 1);
									}
								}
								else if ((int)Main.tile[index1, index2].type == 2)
								{
									Main.tile[index1, index2].type = (byte)23;
									WorldGen.SquareTileFrame(index1, index2, true);
									NetMessage.SendTileSquare(-1, index1, index2, 1);
								}
								else if ((int)Main.tile[index1, index2].type == 1 || Main.tileMoss[(int)Main.tile[index1, index2].type])
								{
									Main.tile[index1, index2].type = (byte)25;
									WorldGen.SquareTileFrame(index1, index2, true);
									NetMessage.SendTileSquare(-1, index1, index2, 1);
								}
								else if ((int)Main.tile[index1, index2].type == 53)
								{
									Main.tile[index1, index2].type = (byte)112;
									WorldGen.SquareTileFrame(index1, index2, true);
									NetMessage.SendTileSquare(-1, index1, index2, 1);
								}
								else if ((int)Main.tile[index1, index2].type == 109)
								{
									Main.tile[index1, index2].type = (byte)23;
									WorldGen.SquareTileFrame(index1, index2, true);
									NetMessage.SendTileSquare(-1, index1, index2, 1);
								}
								else if ((int)Main.tile[index1, index2].type == 117)
								{
									Main.tile[index1, index2].type = (byte)25;
									WorldGen.SquareTileFrame(index1, index2, true);
									NetMessage.SendTileSquare(-1, index1, index2, 1);
								}
								else if ((int)Main.tile[index1, index2].type == 116)
								{
									Main.tile[index1, index2].type = (byte)112;
									WorldGen.SquareTileFrame(index1, index2, true);
									NetMessage.SendTileSquare(-1, index1, index2, 1);
								}
								else if ((int)Main.tile[index1, index2].type == 161 || (int)Main.tile[index1, index2].type == 164 || (int)Main.tile[index1, index2].type == 200)
								{
									Main.tile[index1, index2].type = (byte)163;
									WorldGen.SquareTileFrame(index1, index2, true);
									NetMessage.SendTileSquare(-1, index1, index2, 1);
								}
							}
						}
					}
				}
			}
			this.active = false;
		}

		public Color GetAlpha(Color newColor)
		{
			if (this.type == 34 || this.type == 15 || (this.type == 93 || this.type == 94) || (this.type == 95 || this.type == 96 || (this.type == 253 || this.type == 258)) || this.type == 102 && this.alpha < (int)byte.MaxValue)
				return new Color(200, 200, 200, 25);
			if (this.type == 329)
				return new Color(200, 200, 200, 50);
			if (this.type >= 326 && this.type <= 328)
				return new Color(0, 0, 0, 0);
			if (this.type == 324 && this.frame >= 6 && this.frame <= 9)
				return new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
			if (this.type == 16)
				return new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, 0);
    		if (this.type == 321)
    			return new Color(200, 200, 200, 0);
			if (this.type == 76 || this.type == 77 || this.type == 78)
				return new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, 0);
			if (this.type == 308)
				return new Color(200, 200, (int)byte.MaxValue, 125);
			if (this.type == 263)
			{
				if (this.timeLeft < (int)byte.MaxValue)
					return new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)(byte)this.timeLeft);
				else
					return new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
			}
			else if (this.type == 274)
			{
				if (this.timeLeft >= 85)
					return new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, 100);
				byte num1 = (byte)(this.timeLeft * 3);
				byte num2 = (byte)(100.0 * ((double)num1 / (double)byte.MaxValue));
				return new Color((int)num1, (int)num1, (int)num1, (int)num2);
			}
			else
			{
				if (this.type == 5)
					return new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, 0);
				if (this.type == 300 || this.type == 301)
					return new Color(250, 250, 250, 50);
				if (this.type == 304)
					return new Color((int)byte.MaxValue - this.alpha, (int)byte.MaxValue - this.alpha, (int)byte.MaxValue - this.alpha, (int)(byte)((double)((int)byte.MaxValue - this.alpha) / 3.0));
				if (this.type == 116 || this.type == 132 || (this.type == 156 || this.type == 157) || (this.type == 157 || this.type == 173))
				{
					if ((double)this.localAI[1] >= 15.0)
						return new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, this.alpha);
					if ((double)this.localAI[1] < 5.0)
						return new Color(0, 0, 0, 0);
					int num = (int)(((double)this.localAI[1] - 5.0) / 10.0 * (double)byte.MaxValue);
					return new Color(num, num, num, num);
				}
				else if (this.type == 254)
				{
					if (this.timeLeft < 30)
						this.alpha = (int)((double)byte.MaxValue - (double)byte.MaxValue * (double)((float)this.timeLeft / 30f));
					return new Color((int)byte.MaxValue - this.alpha, (int)byte.MaxValue - this.alpha, (int)byte.MaxValue - this.alpha, 0);
				}
				else if (this.type == 265)
				{
					if (this.alpha > 0)
						return new Color(0, 0, 0, 0);
					else
						return new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, 0);
				}
				else if (this.type == 270)
				{
					if (this.alpha > 0)
						return new Color(0, 0, 0, 0);
					else
						return new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, 200);
				}
				else if (this.type == 257)
				{
					if (this.alpha > 200)
						return new Color(0, 0, 0, 0);
					else
						return new Color((int)byte.MaxValue - this.alpha, (int)byte.MaxValue - this.alpha, (int)byte.MaxValue - this.alpha, 0);
				}
				else if (this.type == 259)
				{
					if (this.alpha > 200)
						return new Color(0, 0, 0, 0);
					else
						return new Color((int)byte.MaxValue - this.alpha, (int)byte.MaxValue - this.alpha, (int)byte.MaxValue - this.alpha, 0);
				}
				else
				{
					if (this.type >= 150 && this.type <= 152)
						return new Color((int)byte.MaxValue - this.alpha, (int)byte.MaxValue - this.alpha, (int)byte.MaxValue - this.alpha, (int)byte.MaxValue - this.alpha);
					if (this.type == 250)
						return new Color(0, 0, 0, 0);
					if (this.type == 251)
						return new Color((int)byte.MaxValue - this.alpha, (int)byte.MaxValue - this.alpha, (int)byte.MaxValue - this.alpha, 0);
					if (this.type == 131)
						return new Color((int)byte.MaxValue - this.alpha, (int)byte.MaxValue - this.alpha, (int)byte.MaxValue - this.alpha, 0);
					if (this.type == 211)
						return new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, 0);
					if (this.type == 229)
						return new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, 50);
					if (this.type == 221)
						return new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, 200);
					int num1;
					int num2;
					int num3;
					if (this.type == 207)
					{
						num1 = (int) byte.MaxValue - this.alpha;
						num2 = (int) byte.MaxValue - this.alpha;
						num3 = (int) byte.MaxValue - this.alpha;
					}
					else if (this.type == 242)
					{
						if (this.alpha < 140)
							return new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, 100);
						else
							return new Color(0, 0, 0, 0);
					}
					else if (this.type == 209)
						{
							num1 = (int)newColor.R - this.alpha;
							num2 = (int)newColor.G - this.alpha;
							num3 = (int)newColor.B - this.alpha / 2;
						}
						else
						{
							if (this.type == 130)
								return new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, 175);
							if (this.type == 182)
								return new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, 200);
							if (this.type == 226)
							{
								int num4 = (int)byte.MaxValue;
								int num5 = (int)byte.MaxValue;
								int num6 = (int)byte.MaxValue;
								float num7 = (float)((double)Main.mouseTextColor / 200.0 - 0.300000011920929);
								int num8 = (int)((double)num4 * (double)num7);
								int num9 = (int)((double)num5 * (double)num7);
								int num10 = (int)((double)num6 * (double)num7);
								int r = num8 + 50;
								if (r > (int)byte.MaxValue)
									r = (int)byte.MaxValue;
								int g = num9 + 50;
								if (g > (int)byte.MaxValue)
									g = (int)byte.MaxValue;
								int b = num10 + 50;
								if (b > (int)byte.MaxValue)
									b = (int)byte.MaxValue;
								return new Color(r, g, b, 200);
							}
							else if (this.type == 227)
							{
								int num4;
								int num5 = num4 = (int)byte.MaxValue;
								int num6 = num4;
								int num7 = num4;
								float num8 = (float)((double)Main.mouseTextColor / 100.0 - 1.60000002384186);
								int num9 = (int)((double)num7 * (double)num8);
								int num10 = (int)((double)num6 * (double)num8);
								int num11 = (int)((double)num5 * (double)num8);
								int a = (int)(100.0 * (double)num8);
								int r = num9 + 50;
								if (r > (int)byte.MaxValue)
									r = (int)byte.MaxValue;
								int g = num10 + 50;
								if (g > (int)byte.MaxValue)
									g = (int)byte.MaxValue;
								int b = num11 + 50;
								if (b > (int)byte.MaxValue)
									b = (int)byte.MaxValue;
								return new Color(r, g, b, a);
							}
							else if (this.type == 114 || this.type == 115)
							{
								if ((double)this.localAI[1] >= 15.0)
									return new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, this.alpha);
								if ((double)this.localAI[1] < 5.0)
									return new Color(0, 0, 0, 0);
								int num4 = (int)(((double)this.localAI[1] - 5.0) / 10.0 * (double)byte.MaxValue);
								return new Color(num4, num4, num4, num4);
							}
							else if (this.type == 83 || this.type == 88 || (this.type == 89 || this.type == 90) || (this.type == 100 || this.type == 104 || this.type == 279) || this.type >= 283 && this.type <= 287)
							{
								if (this.alpha < 200)
									return new Color((int)byte.MaxValue - this.alpha, (int)byte.MaxValue - this.alpha, (int)byte.MaxValue - this.alpha, 0);
								else
									return new Color(0, 0, 0, 0);
							}
							else
							{
								if (this.type == 34 || this.type == 35 || (this.type == 15 || this.type == 19) || (this.type == 44 || this.type == 45))
									return Color.White;
								if (this.type == 79)
								{
									num1 = Main.DiscoR;
									num2 = Main.DiscoG;
									num3 = Main.DiscoB;
									return new Color();
								}
								else if (this.type == 9 || this.type == 15 || (this.type == 34 || this.type == 50) || (this.type == 53 || this.type == 76 || (this.type == 77 || this.type == 78)) || (this.type == 92 || this.type == 91))
								{
									num1 = (int)newColor.R - this.alpha / 3;
									num2 = (int)newColor.G - this.alpha / 3;
									num3 = (int)newColor.B - this.alpha / 3;
								}
								else
								{
									if (this.type == 18)
										return new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, 50);
									if (this.type == 16 || this.type == 44 || this.type == 45)
									{
										num1 = (int)newColor.R;
										num2 = (int)newColor.G;
										num3 = (int)newColor.B;
									}
									else if (this.type == 12 || this.type == 72 || (this.type == 86 || this.type == 87))
										return new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)newColor.A - this.alpha);
								}
							}
						}
						float num12 = (float)((int)byte.MaxValue - this.alpha) / (float)byte.MaxValue;
						int r1 = (int)((double)newColor.R * (double)num12);
						int g1 = (int)((double)newColor.G * (double)num12);
						int b1 = (int)((double)newColor.B * (double)num12);
						int a1 = (int)newColor.A - this.alpha;
						if (a1 < 0)
							a1 = 0;
						if (a1 > (int)byte.MaxValue)
							a1 = (int)byte.MaxValue;
						return new Color(r1, g1, b1, a1);
					}
				}
			}
		}
	}
}
