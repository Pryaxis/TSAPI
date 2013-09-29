using System;

namespace Terraria
{
	public class Projectile
	{
		public static int maxAI = 2;
		public float scale = 1f;
		public int owner = (int)byte.MaxValue;
		public string name = "";
		public float[] ai = new float[Projectile.maxAI];
		public float[] localAI = new float[Projectile.maxAI];
		public float stepSpeed = 1f;
		public int spriteDirection = 1;
		public int penetrate = 1;
		public Vector2[] oldPos = new Vector2[10];
		public int[] playerImmune = new int[(int)byte.MaxValue];
		public string miscText = "";
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
				this.timeLeft = 80;
				this.alpha = 100;
				this.ignoreWater = true;
				this.ranged = true;
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
				this.alpha = (int)byte.MaxValue;
				this.penetrate = 3;
				this.maxUpdates = 2;
				this.magic = true;
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
				this.alpha = (int)byte.MaxValue;
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
			else
				this.active = false;
			this.width = (int)((double)this.width * (double)this.scale);
			this.height = (int)((double)this.height * (double)this.scale);
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
			if (this.type == 163)
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
			if (this.type == 163)
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
			float ai1 = (float)dmg * 0.1f;
			if ((int)ai1 == 0 || !this.magic)
				return;
			float num1 = 0.0f;
			int num2 = this.owner;
			for (int index = 0; index < (int)byte.MaxValue; ++index)
			{
				if (Main.player[index].active && !Main.player[index].dead && (!Main.player[this.owner].hostile && !Main.player[index].hostile || Main.player[this.owner].team == Main.player[index].team) && ((double)(Math.Abs(Main.player[index].position.X + (float)(Main.player[index].width / 2) - this.position.X + (float)(this.width / 2)) + Math.Abs(Main.player[index].position.Y + (float)(Main.player[index].height / 2) - this.position.Y + (float)(this.height / 2))) < 800.0 && (double)(Main.player[index].statLifeMax - Main.player[index].statLife) > (double)num1))
				{
					num1 = (float)(Main.player[index].statLifeMax - Main.player[index].statLife);
					num2 = index;
				}
			}
			Projectile.NewProjectile(Position.X, Position.Y, 0.0f, 0.0f, 298, 0, 0.0f, this.owner, (float)num2, ai1);
		}

		public void vampireHeal(int dmg, Vector2 Position)
		{
			float ai1 = (float)dmg * 0.1f;
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
			if (this.type == 18 || this.type == 72 || (this.type == 86 || this.type == 87) || (this.aiStyle == 31 || this.aiStyle == 32 || this.type == 226) || Main.projPet[this.type] && this.type != 266)
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
									int dmg = (int)Main.npc[index].StrikeNPC(Damage, this.knockBack, this.direction, crit, false);
									if (dmg > 0 && Main.npc[index].lifeMax > 5 && Main.player[this.owner].ghostHeal)
										this.ghostHeal(dmg, new Vector2(Main.npc[index].center().X, Main.npc[index].center().Y));
									if (this.type == 304 && dmg > 0 && Main.npc[index].lifeMax > 5)
										this.vampireHeal(dmg, new Vector2(Main.npc[index].center().X, Main.npc[index].center().Y));
									if (this.melee && (int)Main.player[this.owner].meleeEnchant == 7)
										Projectile.NewProjectile(Main.npc[index].center().X, Main.npc[index].center().Y, Main.npc[index].velocity.X, Main.npc[index].velocity.Y, 289, 0, 0.0f, this.owner, 0.0f, 0.0f);
									if (Main.player[this.owner].coins && Main.rand.Next(5) == 0)
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
									else if (this.penetrate != 1)
										Main.npc[index].immune[this.owner] = 10;
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
			Lighting.addLight((int)(((double)this.position.X + (double)(this.width / 2)) / 16.0), (int)(((double)this.position.Y + (double)(this.height / 2)) / 16.0), R, G, B);
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
			if (Main.player[this.owner].frostBurn && (this.melee || this.ranged) && Main.rand.Next(2 * (1 + this.maxUpdates)) == 0)
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
					else if (this.type == 250 || this.type == 267 || this.type == 297)
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
					else if (this.type == 106 || this.type == 262 || (this.type == 271 || this.type == 270) || (this.type == 272 || this.type == 273 || (this.type == 274 || this.type == 280)) || (this.type == 288 || this.type == 301))
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
					if (flag3 && !Main.projPet[this.type])
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
								if (this.type == 50)
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
			// ISSUE: unable to decompile the method.
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
			else if (Main.projPet[this.type])
			{
				int index = Gore.NewGore(new Vector2(this.position.X - (float)(this.width / 2), this.position.Y - (float)(this.height / 2)), new Vector2(0.0f, 0.0f), Main.rand.Next(11, 14), this.scale);
				Main.gore[index].velocity *= 0.1f;
			}
			else if (this.type == 93)
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
			else if (this.type == 15 || this.type == 34)
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
									if (Main.tileDungeon[(int)Main.tile[i1, j1].type] || (int)Main.tile[i1, j1].type == 21 || ((int)Main.tile[i1, j1].type == 26 || (int)Main.tile[i1, j1].type == 107) || ((int)Main.tile[i1, j1].type == 108 || (int)Main.tile[i1, j1].type == 111 || ((int)Main.tile[i1, j1].type == 226 || (int)Main.tile[i1, j1].type == 237)) || ((int)Main.tile[i1, j1].type == 221 || (int)Main.tile[i1, j1].type == 222 || (int)Main.tile[i1, j1].type == 223))
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
					NetMessage.SendData(29, -1, -1, "", this.identity, (float)this.owner, 0.0f, 0.0f, 0);
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
								NetMessage.SendData(17, -1, -1, "", 1, (float)i, (float)j, (float)type, 0);
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
									else if ((int)Main.tile[index1, index2].type == 53)
									{
										Main.tile[index1, index2].type = (byte)116;
										WorldGen.SquareTileFrame(index1, index2, true);
										NetMessage.SendTileSquare(-1, index1, index2, 1);
									}
									else if ((int)Main.tile[index1, index2].type == 23)
									{
										Main.tile[index1, index2].type = (byte)109;
										WorldGen.SquareTileFrame(index1, index2, true);
										NetMessage.SendTileSquare(-1, index1, index2, 1);
									}
									else if ((int)Main.tile[index1, index2].type == 25)
									{
										Main.tile[index1, index2].type = (byte)117;
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
								else if ((int)Main.tile[index1, index2].type == 161 || (int)Main.tile[index1, index2].type == 164)
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
			if (this.type == 16)
				return new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, 0);
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
					if (this.type == 207)
						return new Color(0, 0, 0, 0);
					if (this.type == 242)
					{
						if (this.alpha < 140)
							return new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, 100);
						else
							return new Color(0, 0, 0, 0);
					}
					else
					{
						int num1;
						int num2;
						int num3;
						if (this.type == 209)
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
