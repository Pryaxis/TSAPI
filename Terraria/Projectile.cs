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
			else if (this.type == 310)
			{
				this.netImportant = true;
				this.name = "Blue Flare";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 33;
				this.friendly = true;
				this.penetrate = -1;
				this.alpha = (int) byte.MaxValue;
				this.timeLeft = 36000;
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
			if (this.aiStyle == 1)
			{
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
				else
				{
					if (this.type == 176)
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
					int num5 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.6f);
					Main.dust[num5].noGravity = true;
					num5 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num5].noGravity = true;
				}
				else
				{
					if (this.type == 55)
					{
						int num6 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 18, 0f, 0f, 0, default(Color), 0.9f);
						Main.dust[num6].noGravity = true;
					}
					else
					{
						if (this.type == 91 && Main.rand.Next(2) == 0)
						{
							int num7;
							if (Main.rand.Next(2) == 0)
							{
								num7 = 15;
							}
							else
							{
								num7 = 58;
							}
							int num8 = Dust.NewDust(this.position, this.width, this.height, num7, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 150, default(Color), 0.9f);
							Main.dust[num8].velocity *= 0.25f;
						}
					}
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
					float num9 = (float)Math.Sqrt((double)(this.velocity.X * this.velocity.X + this.velocity.Y * this.velocity.Y));
					if (this.alpha > 0)
					{
						this.alpha -= (int)((byte)((double)num9 * 0.9));
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
				if (this.type != 5 && this.type != 14 && this.type != 270 && this.type != 180 && this.type != 259 && this.type != 242 && this.type != 302 && this.type != 20 && this.type != 36 && this.type != 38 && this.type != 55 && this.type != 83 && this.type != 84 && this.type != 88 && this.type != 89 && this.type != 98 && this.type != 100 && this.type != 265 && this.type != 104 && this.type != 110 && this.type != 184 && this.type != 257 && this.type != 248 && (this.type < 283 || this.type > 287) && this.type != 279 && this.type != 299 && (this.type < 158 || this.type > 161))
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
							int num10 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 181, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num10].velocity *= 3f;
							Main.dust[num10].velocity += this.velocity * 0.75f;
							Main.dust[num10].scale *= 1.2f;
							Main.dust[num10].noGravity = true;
						}
					}
					this.localAI[0] += 1f;
					if (this.localAI[0] > 6f)
					{
						for (int j = 0; j < 3; j++)
						{
							int num11 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 181, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 1f);
							Main.dust[num11].velocity *= 0.6f;
							Main.dust[num11].scale *= 1.4f;
							Main.dust[num11].noGravity = true;
						}
					}
				}
				else
				{
					if (this.type == 270)
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
							int num12 = Dust.NewDust(new Vector2(this.position.X + 4f, this.position.Y + 4f), this.width - 8, this.height - 8, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 2f);
							Main.dust[num12].position -= this.velocity * 2f;
							Main.dust[num12].noGravity = true;
							Dust expr_10A9_cp_0 = Main.dust[num12];
							expr_10A9_cp_0.velocity.X = expr_10A9_cp_0.velocity.X * 0.3f;
							Dust expr_10C7_cp_0 = Main.dust[num12];
							expr_10C7_cp_0.velocity.Y = expr_10C7_cp_0.velocity.Y * 0.3f;
						}
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
						int num13 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 163, this.velocity.X, this.velocity.Y, 100, default(Color), 1.2f);
						Main.dust[num13].noGravity = true;
						Main.dust[num13].velocity *= 0.3f;
						Main.dust[num13].velocity -= this.velocity * 0.4f;
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
							int num14 = Dust.NewDust(new Vector2(x, y), 1, 1, 75, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num14].alpha = this.alpha;
							Main.dust[num14].position.X = x;
							Main.dust[num14].position.Y = y;
							Main.dust[num14].velocity *= 0f;
							Main.dust[num14].noGravity = true;
						}
					}
					float num15 = (float)Math.Sqrt((double)(this.velocity.X * this.velocity.X + this.velocity.Y * this.velocity.Y));
					float num16 = this.localAI[0];
					if (num16 == 0f)
					{
						this.localAI[0] = num15;
						num16 = num15;
					}
					if (this.alpha > 0)
					{
						this.alpha -= 25;
					}
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
					float num17 = this.position.X;
					float num18 = this.position.Y;
					float num19 = 300f;
					bool flag = false;
					int num20 = 0;
					if (this.ai[1] == 0f)
					{
						for (int m = 0; m < 200; m++)
						{
							if (Main.npc[m].active && !Main.npc[m].dontTakeDamage && !Main.npc[m].friendly && Main.npc[m].lifeMax > 5 && (this.ai[1] == 0f || this.ai[1] == (float)(m + 1)))
							{
								float num21 = Main.npc[m].position.X + (float)(Main.npc[m].width / 2);
								float num22 = Main.npc[m].position.Y + (float)(Main.npc[m].height / 2);
								float num23 = Math.Abs(this.position.X + (float)(this.width / 2) - num21) + Math.Abs(this.position.Y + (float)(this.height / 2) - num22);
								if (num23 < num19 && Collision.CanHit(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2)), 1, 1, Main.npc[m].position, Main.npc[m].width, Main.npc[m].height))
								{
									num19 = num23;
									num17 = num21;
									num18 = num22;
									flag = true;
									num20 = m;
								}
							}
						}
						if (flag)
						{
							this.ai[1] = (float)(num20 + 1);
						}
						flag = false;
					}
					if (this.ai[1] != 0f)
					{
						int num24 = (int)(this.ai[1] - 1f);
						if (Main.npc[num24].active)
						{
							float num25 = Main.npc[num24].position.X + (float)(Main.npc[num24].width / 2);
							float num26 = Main.npc[num24].position.Y + (float)(Main.npc[num24].height / 2);
							float num27 = Math.Abs(this.position.X + (float)(this.width / 2) - num25) + Math.Abs(this.position.Y + (float)(this.height / 2) - num26);
							if (num27 < 1000f)
							{
								flag = true;
								num17 = Main.npc[num24].position.X + (float)(Main.npc[num24].width / 2);
								num18 = Main.npc[num24].position.Y + (float)(Main.npc[num24].height / 2);
							}
						}
					}
					if (flag)
					{
						float num28 = num16;
						Vector2 vector = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num29 = num17 - vector.X;
						float num30 = num18 - vector.Y;
						float num31 = (float)Math.Sqrt((double)(num29 * num29 + num30 * num30));
						num31 = num28 / num31;
						num29 *= num31;
						num30 *= num31;
						this.velocity.X = (this.velocity.X * 5f + num29) / 6f;
						this.velocity.Y = (this.velocity.Y * 5f + num30) / 6f;
					}
				}
				else
				{
					if (this.type == 81 || this.type == 91)
					{
						if (this.ai[0] >= 20f)
						{
							this.ai[0] = 20f;
							this.velocity.Y = this.velocity.Y + 0.07f;
						}
					}
					else
					{
						if (this.type == 174)
						{
							if (this.ai[0] >= 5f)
							{
								this.ai[0] = 5f;
								this.velocity.Y = this.velocity.Y + 0.15f;
							}
						}
						else
						{
							if (this.type == 246)
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
							else
							{
								if (this.type != 239 && this.type != 264)
								{
									if (this.type == 176)
									{
										if (this.ai[0] >= 15f)
										{
											this.ai[0] = 15f;
											this.velocity.Y = this.velocity.Y + 0.05f;
										}
									}
									else
									{
										if (this.type == 275 || this.type == 276)
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
										else
										{
											if (this.type == 172)
											{
												if (this.ai[0] >= 17f)
												{
													this.ai[0] = 17f;
													this.velocity.Y = this.velocity.Y + 0.085f;
												}
											}
											else
											{
												if (this.type == 117)
												{
													if (this.ai[0] >= 35f)
													{
														this.ai[0] = 35f;
														this.velocity.Y = this.velocity.Y + 0.06f;
													}
												}
												else
												{
													if (this.type == 120)
													{
														int num32 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 67, this.velocity.X, this.velocity.Y, 100, default(Color), 1.2f);
														Main.dust[num32].noGravity = true;
														Main.dust[num32].velocity *= 0.3f;
														if (this.ai[0] >= 30f)
														{
															this.ai[0] = 30f;
															this.velocity.Y = this.velocity.Y + 0.05f;
														}
													}
													else
													{
														if (this.type == 195)
														{
															if (this.ai[0] >= 20f)
															{
																this.ai[0] = 20f;
																this.velocity.Y = this.velocity.Y + 0.075f;
															}
														}
														else
														{
															if (this.type == 267)
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
															else
															{
																if (this.ai[0] >= 15f)
																{
																	this.ai[0] = 15f;
																	this.velocity.Y = this.velocity.Y + 0.1f;
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
			else
			{
				if (this.aiStyle == 2)
				{
					if (this.type == 93 && Main.rand.Next(5) == 0)
					{
						int num33 = Dust.NewDust(this.position, this.width, this.height, 57, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 0.3f);
						Dust expr_1D7C_cp_0 = Main.dust[num33];
						expr_1D7C_cp_0.velocity.X = expr_1D7C_cp_0.velocity.X * 0.3f;
						Dust expr_1D9A_cp_0 = Main.dust[num33];
						expr_1D9A_cp_0.velocity.Y = expr_1D9A_cp_0.velocity.Y * 0.3f;
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
									int num34 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
									Main.dust[num34].velocity *= 0.5f;
									Main.dust[num34].velocity += this.velocity * 0.1f;
								}
								for (int num35 = 0; num35 < 5; num35++)
								{
									int num36 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
									Main.dust[num36].noGravity = true;
									Main.dust[num36].velocity *= 3f;
									Main.dust[num36].velocity += this.velocity * 0.2f;
									num36 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
									Main.dust[num36].velocity *= 2f;
									Main.dust[num36].velocity += this.velocity * 0.3f;
								}
								for (int num37 = 0; num37 < 1; num37++)
								{
									int num38 = Gore.NewGore(new Vector2(this.position.X - 10f, this.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
									Main.gore[num38].position += this.velocity * 1.25f;
									Main.gore[num38].scale = 1.5f;
									Main.gore[num38].velocity += this.velocity * 0.5f;
									Main.gore[num38].velocity *= 0.02f;
								}
							}
						}
					}
					else
					{
						if (this.type == 281)
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
									for (int num39 = 0; num39 < 10; num39++)
									{
										int num40 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
										Main.dust[num40].velocity *= 0.5f;
										Main.dust[num40].velocity += this.velocity * 0.1f;
									}
									for (int num41 = 0; num41 < 5; num41++)
									{
										int num42 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
										Main.dust[num42].noGravity = true;
										Main.dust[num42].velocity *= 3f;
										Main.dust[num42].velocity += this.velocity * 0.2f;
										num42 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
										Main.dust[num42].velocity *= 2f;
										Main.dust[num42].velocity += this.velocity * 0.3f;
									}
									for (int num43 = 0; num43 < 1; num43++)
									{
										int num44 = Gore.NewGore(new Vector2(this.position.X - 10f, this.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
										Main.gore[num44].position += this.velocity * 1.25f;
										Main.gore[num44].scale = 1.5f;
										Main.gore[num44].velocity += this.velocity * 0.5f;
										Main.gore[num44].velocity *= 0.02f;
									}
								}
							}
						}
						else
						{
							if (this.type == 240)
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
										for (int num45 = 0; num45 < 7; num45++)
										{
											int num46 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
											Main.dust[num46].velocity *= 0.5f;
											Main.dust[num46].velocity += this.velocity * 0.1f;
										}
										for (int num47 = 0; num47 < 3; num47++)
										{
											int num48 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
											Main.dust[num48].noGravity = true;
											Main.dust[num48].velocity *= 3f;
											Main.dust[num48].velocity += this.velocity * 0.2f;
											num48 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
											Main.dust[num48].velocity *= 2f;
											Main.dust[num48].velocity += this.velocity * 0.3f;
										}
										for (int num49 = 0; num49 < 1; num49++)
										{
											int num50 = Gore.NewGore(new Vector2(this.position.X - 10f, this.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
											Main.gore[num50].position += this.velocity * 1.25f;
											Main.gore[num50].scale = 1.25f;
											Main.gore[num50].velocity += this.velocity * 0.5f;
											Main.gore[num50].velocity *= 0.02f;
										}
									}
								}
							}
							else
							{
								if (this.type == 249)
								{
									this.ai[0] += 1f;
									if (this.ai[0] >= 0f)
									{
										this.velocity.Y = this.velocity.Y + 0.25f;
									}
								}
								else
								{
									if (this.type == 69 || this.type == 70)
									{
										this.ai[0] += 1f;
										if (this.ai[0] >= 10f)
										{
											this.velocity.Y = this.velocity.Y + 0.25f;
											this.velocity.X = this.velocity.X * 0.99f;
										}
									}
									else
									{
										if (this.type == 166)
										{
											this.ai[0] += 1f;
											if (this.ai[0] >= 20f)
											{
												this.velocity.Y = this.velocity.Y + 0.3f;
												this.velocity.X = this.velocity.X * 0.98f;
											}
										}
										else
										{
											if (this.type == 300)
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
											else
											{
												if (this.type == 306)
												{
													if (this.alpha <= 200)
													{
														for (int num51 = 0; num51 < 4; num51++)
														{
															float num52 = this.velocity.X / 4f * (float)num51;
															float num53 = this.velocity.Y / 4f * (float)num51;
															int num54 = Dust.NewDust(this.position, this.width, this.height, 184, 0f, 0f, 0, default(Color), 1f);
															Main.dust[num54].position.X = this.center().X - num52;
															Main.dust[num54].position.Y = this.center().Y - num53;
															Main.dust[num54].velocity *= 0f;
															Main.dust[num54].scale = 0.7f;
														}
													}
													this.alpha -= 50;
													if (this.alpha < 0)
													{
														this.alpha = 0;
													}
													this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 0.785f;
												}
												else
												{
													if (this.type == 304)
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
														else
														{
															if (this.type == 48 || this.type == 54 || this.type == 93)
															{
																this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
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
				else
				{
					if (this.aiStyle == 3)
					{
						if (this.soundDelay == 0)
						{
							this.soundDelay = 8;
							Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 7);
						}
						if (this.type == 19)
						{
							for (int num55 = 0; num55 < 2; num55++)
							{
								int num56 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 2f);
								Main.dust[num56].noGravity = true;
								Dust expr_2F58_cp_0 = Main.dust[num56];
								expr_2F58_cp_0.velocity.X = expr_2F58_cp_0.velocity.X * 0.3f;
								Dust expr_2F76_cp_0 = Main.dust[num56];
								expr_2F76_cp_0.velocity.Y = expr_2F76_cp_0.velocity.Y * 0.3f;
							}
						}
						else
						{
							if (this.type == 33)
							{
								if (Main.rand.Next(1) == 0)
								{
									int num57 = Dust.NewDust(this.position, this.width, this.height, 40, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 0, default(Color), 1.4f);
									Main.dust[num57].noGravity = true;
								}
							}
							else
							{
								if (this.type == 6)
								{
									if (Main.rand.Next(5) == 0)
									{
										int num58 = Main.rand.Next(3);
										if (num58 == 0)
										{
											num58 = 15;
										}
										else
										{
											if (num58 == 1)
											{
												num58 = 57;
											}
											else
											{
												num58 = 58;
											}
										}
										Dust.NewDust(this.position, this.width, this.height, num58, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 150, default(Color), 0.7f);
									}
								}
								else
								{
									if (this.type == 113 && Main.rand.Next(1) == 0)
									{
										int num59 = Dust.NewDust(this.position, this.width, this.height, 76, this.velocity.X * 0.15f, this.velocity.Y * 0.15f, 0, default(Color), 1.1f);
										Main.dust[num59].noGravity = true;
										Dust.NewDust(this.position, this.width, this.height, 15, this.velocity.X * 0.05f, this.velocity.Y * 0.05f, 150, default(Color), 0.6f);
									}
								}
							}
						}
						if (this.ai[0] == 0f)
						{
							this.ai[1] += 1f;
							if (this.type == 106)
							{
								if (this.ai[1] >= 45f)
								{
									this.ai[0] = 1f;
									this.ai[1] = 0f;
									this.netUpdate = true;
								}
							}
							else
							{
								if (this.type == 182)
								{
									if (Main.rand.Next(2) == 0)
									{
										int num60 = Dust.NewDust(this.position, this.width, this.height, 57, 0f, 0f, 255, default(Color), 0.75f);
										Main.dust[num60].velocity *= 0.1f;
										Main.dust[num60].noGravity = true;
									}
									if (this.velocity.X > 0f)
									{
										this.spriteDirection = 1;
									}
									else
									{
										if (this.velocity.X < 0f)
										{
											this.spriteDirection = -1;
										}
									}
									float num61 = this.position.X;
									float num62 = this.position.Y;
									bool flag2 = false;
									if (this.ai[1] > 10f)
									{
										for (int num63 = 0; num63 < 200; num63++)
										{
											if (Main.npc[num63].active && !Main.npc[num63].dontTakeDamage && !Main.npc[num63].friendly && Main.npc[num63].lifeMax > 5)
											{
												float num64 = Main.npc[num63].position.X + (float)(Main.npc[num63].width / 2);
												float num65 = Main.npc[num63].position.Y + (float)(Main.npc[num63].height / 2);
												float num66 = Math.Abs(this.position.X + (float)(this.width / 2) - num64) + Math.Abs(this.position.Y + (float)(this.height / 2) - num65);
												if (num66 < 800f && Collision.CanHit(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2)), 1, 1, Main.npc[num63].position, Main.npc[num63].width, Main.npc[num63].height))
												{
													num61 = num64;
													num62 = num65;
													flag2 = true;
												}
											}
										}
									}
									if (!flag2)
									{
										num61 = this.position.X + (float)(this.width / 2) + this.velocity.X * 100f;
										num62 = this.position.Y + (float)(this.height / 2) + this.velocity.Y * 100f;
										if (this.ai[1] >= 30f)
										{
											this.ai[0] = 1f;
											this.ai[1] = 0f;
											this.netUpdate = true;
										}
									}
									float num67 = 12f;
									float num68 = 0.25f;
									Vector2 vector2 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
									float num69 = num61 - vector2.X;
									float num70 = num62 - vector2.Y;
									float num71 = (float)Math.Sqrt((double)(num69 * num69 + num70 * num70));
									num71 = num67 / num71;
									num69 *= num71;
									num70 *= num71;
									if (this.velocity.X < num69)
									{
										this.velocity.X = this.velocity.X + num68;
										if (this.velocity.X < 0f && num69 > 0f)
										{
											this.velocity.X = this.velocity.X + num68 * 2f;
										}
									}
									else
									{
										if (this.velocity.X > num69)
										{
											this.velocity.X = this.velocity.X - num68;
											if (this.velocity.X > 0f && num69 < 0f)
											{
												this.velocity.X = this.velocity.X - num68 * 2f;
											}
										}
									}
									if (this.velocity.Y < num70)
									{
										this.velocity.Y = this.velocity.Y + num68;
										if (this.velocity.Y < 0f && num70 > 0f)
										{
											this.velocity.Y = this.velocity.Y + num68 * 2f;
										}
									}
									else
									{
										if (this.velocity.Y > num70)
										{
											this.velocity.Y = this.velocity.Y - num68;
											if (this.velocity.Y > 0f && num70 < 0f)
											{
												this.velocity.Y = this.velocity.Y - num68 * 2f;
											}
										}
									}
								}
								else
								{
									if (this.type == 301)
									{
										if (this.ai[1] >= 20f)
										{
											this.ai[0] = 1f;
											this.ai[1] = 0f;
											this.netUpdate = true;
										}
									}
									else
									{
										if (this.ai[1] >= 30f)
										{
											this.ai[0] = 1f;
											this.ai[1] = 0f;
											this.netUpdate = true;
										}
									}
								}
							}
						}
						else
						{
							this.tileCollide = false;
							float num72 = 9f;
							float num73 = 0.4f;
							if (this.type == 19)
							{
								num72 = 13f;
								num73 = 0.6f;
							}
							else
							{
								if (this.type == 33)
								{
									num72 = 15f;
									num73 = 0.8f;
								}
								else
								{
									if (this.type == 182)
									{
										num72 = 16f;
										num73 = 1.2f;
									}
									else
									{
										if (this.type == 106)
										{
											num72 = 16f;
											num73 = 1.2f;
										}
										else
										{
											if (this.type == 272)
											{
												num72 = 15f;
												num73 = 1f;
											}
											else
											{
												if (this.type == 301)
												{
													num72 = 15f;
													num73 = 3f;
												}
											}
										}
									}
								}
							}
							Vector2 vector3 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num74 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector3.X;
							float num75 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector3.Y;
							float num76 = (float)Math.Sqrt((double)(num74 * num74 + num75 * num75));
							if (num76 > 3000f)
							{
								this.Kill();
							}
							num76 = num72 / num76;
							num74 *= num76;
							num75 *= num76;
							if (this.velocity.X < num74)
							{
								this.velocity.X = this.velocity.X + num73;
								if (this.velocity.X < 0f && num74 > 0f)
								{
									this.velocity.X = this.velocity.X + num73;
								}
							}
							else
							{
								if (this.velocity.X > num74)
								{
									this.velocity.X = this.velocity.X - num73;
									if (this.velocity.X > 0f && num74 < 0f)
									{
										this.velocity.X = this.velocity.X - num73;
									}
								}
							}
							if (this.velocity.Y < num75)
							{
								this.velocity.Y = this.velocity.Y + num73;
								if (this.velocity.Y < 0f && num75 > 0f)
								{
									this.velocity.Y = this.velocity.Y + num73;
								}
							}
							else
							{
								if (this.velocity.Y > num75)
								{
									this.velocity.Y = this.velocity.Y - num73;
									if (this.velocity.Y > 0f && num75 < 0f)
									{
										this.velocity.Y = this.velocity.Y - num73;
									}
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
					else
					{
						if (this.aiStyle == 4)
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
										int num77 = this.type;
										if (this.ai[1] >= 6f)
										{
											num77++;
										}
										int num78 = Projectile.NewProjectile(this.position.X + this.velocity.X + (float)(this.width / 2), this.position.Y + this.velocity.Y + (float)(this.height / 2), this.velocity.X, this.velocity.Y, num77, this.damage, this.knockBack, this.owner, 0f, 0f);
										Main.projectile[num78].damage = this.damage;
										Main.projectile[num78].ai[1] = this.ai[1] + 1f;
										NetMessage.SendData(27, -1, -1, "", num78, 0f, 0f, 0f, 0);
										return;
									}
									if ((this.type == 150 || this.type == 151) && Main.myPlayer == this.owner)
									{
										int num79 = this.type;
										if (this.type == 150)
										{
											num79 = 151;
										}
										else
										{
											if (this.type == 151)
											{
												num79 = 150;
											}
										}
										if (this.ai[1] >= 10f && this.type == 151)
										{
											num79 = 152;
										}
										int num80 = Projectile.NewProjectile(this.position.X + this.velocity.X + (float)(this.width / 2), this.position.Y + this.velocity.Y + (float)(this.height / 2), this.velocity.X, this.velocity.Y, num79, this.damage, this.knockBack, this.owner, 0f, 0f);
										Main.projectile[num80].damage = this.damage;
										Main.projectile[num80].ai[1] = this.ai[1] + 1f;
										NetMessage.SendData(27, -1, -1, "", num80, 0f, 0f, 0f, 0);
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
										for (int num81 = 0; num81 < 8; num81++)
										{
											int num82 = Dust.NewDust(this.position, this.width, this.height, 7, this.velocity.X * 0.025f, this.velocity.Y * 0.025f, 200, default(Color), 1.3f);
											Main.dust[num82].noGravity = true;
											Main.dust[num82].velocity *= 0.5f;
										}
									}
									else
									{
										for (int num83 = 0; num83 < 3; num83++)
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
						else
						{
							if (this.aiStyle == 5)
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
							else
							{
								if (this.aiStyle == 6)
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
										for (int num84 = 0; num84 < 30; num84++)
										{
											Dust.NewDust(this.position, this.width, this.height, 10 + this.type, this.velocity.X, this.velocity.Y, 50, default(Color), 1f);
										}
									}
									if (this.type == 10 || this.type == 11)
									{
										int num85 = (int)(this.position.X / 16f) - 1;
										int num86 = (int)((this.position.X + (float)this.width) / 16f) + 2;
										int num87 = (int)(this.position.Y / 16f) - 1;
										int num88 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
										if (num85 < 0)
										{
											num85 = 0;
										}
										if (num86 > Main.maxTilesX)
										{
											num86 = Main.maxTilesX;
										}
										if (num87 < 0)
										{
											num87 = 0;
										}
										if (num88 > Main.maxTilesY)
										{
											num88 = Main.maxTilesY;
										}
										for (int num89 = num85; num89 < num86; num89++)
										{
											for (int num90 = num87; num90 < num88; num90++)
											{
												Vector2 vector4;
												vector4.X = (float)(num89 * 16);
												vector4.Y = (float)(num90 * 16);
												if (this.position.X + (float)this.width > vector4.X && this.position.X < vector4.X + 16f && this.position.Y + (float)this.height > vector4.Y && this.position.Y < vector4.Y + 16f && Main.myPlayer == this.owner && Main.tile[num89, num90].active())
												{
													if (this.type == 10)
													{
														if (Main.tile[num89, num90].type == 23 || Main.tile[num89, num90].type == 199)
														{
															Main.tile[num89, num90].type = 2;
															WorldGen.SquareTileFrame(num89, num90, true);
															if (Main.netMode == 1)
															{
																NetMessage.SendTileSquare(-1, num89, num90, 1);
															}
														}
														if (Main.tile[num89, num90].type == 25 || Main.tile[num89, num90].type == 203)
														{
															Main.tile[num89, num90].type = 1;
															WorldGen.SquareTileFrame(num89, num90, true);
															if (Main.netMode == 1)
															{
																NetMessage.SendTileSquare(-1, num89, num90, 1);
															}
														}
														if (Main.tile[num89, num90].type == 112 || Main.tile[num89, num90].type == 234)
														{
															Main.tile[num89, num90].type = 53;
															WorldGen.SquareTileFrame(num89, num90, true);
															if (Main.netMode == 1)
															{
																NetMessage.SendTileSquare(-1, num89, num90, 1);
															}
														}
														if (Main.tile[num89, num90].type == 163)
														{
															Main.tile[num89, num90].type = 161;
															WorldGen.SquareTileFrame(num89, num90, true);
															if (Main.netMode == 1)
															{
																NetMessage.SendTileSquare(-1, num89, num90, 1);
															}
														}
													}
													else
													{
														if (this.type == 11)
														{
															if (Main.tile[num89, num90].type == 109)
															{
																Main.tile[num89, num90].type = 2;
																WorldGen.SquareTileFrame(num89, num90, true);
																if (Main.netMode == 1)
																{
																	NetMessage.SendTileSquare(-1, num89, num90, 1);
																}
															}
															if (Main.tile[num89, num90].type == 116)
															{
																Main.tile[num89, num90].type = 53;
																WorldGen.SquareTileFrame(num89, num90, true);
																if (Main.netMode == 1)
																{
																	NetMessage.SendTileSquare(-1, num89, num90, 1);
																}
															}
															if (Main.tile[num89, num90].type == 117)
															{
																Main.tile[num89, num90].type = 1;
																WorldGen.SquareTileFrame(num89, num90, true);
																if (Main.netMode == 1)
																{
																	NetMessage.SendTileSquare(-1, num89, num90, 1);
																}
															}
															if (Main.tile[num89, num90].type == 164)
															{
																Main.tile[num89, num90].type = 161;
																WorldGen.SquareTileFrame(num89, num90, true);
																if (Main.netMode == 1)
																{
																	NetMessage.SendTileSquare(-1, num89, num90, 1);
																}
															}
														}
													}
												}
											}
										}
										return;
									}
								}
								else
								{
									if (this.aiStyle == 7)
									{
										if (Main.player[this.owner].dead)
										{
											this.Kill();
											return;
										}
										Vector2 vector5 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
										float num91 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector5.X;
										float num92 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector5.Y;
										float num93 = (float)Math.Sqrt((double)(num91 * num91 + num92 * num92));
										this.rotation = (float)Math.Atan2((double)num92, (double)num91) - 1.57f;
										if (this.type == 256)
										{
											this.rotation = (float)Math.Atan2((double)num92, (double)num91) + 3.92500019f;
										}
										if (this.ai[0] == 0f)
										{
											if ((num93 > 300f && this.type == 13) || (num93 > 400f && this.type == 32) || (num93 > 440f && this.type == 73) || (num93 > 440f && this.type == 74) || (num93 > 250f && this.type == 165) || (num93 > 350f && this.type == 256))
											{
												this.ai[0] = 1f;
											}
											else
											{
												if (this.type >= 230 && this.type <= 235)
												{
													int num94 = 300 + (this.type - 230) * 30;
													if (num93 > (float)num94)
													{
														this.ai[0] = 1f;
													}
												}
											}
											int num95 = (int)(this.position.X / 16f) - 1;
											int num96 = (int)((this.position.X + (float)this.width) / 16f) + 2;
											int num97 = (int)(this.position.Y / 16f) - 1;
											int num98 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
											if (num95 < 0)
											{
												num95 = 0;
											}
											if (num96 > Main.maxTilesX)
											{
												num96 = Main.maxTilesX;
											}
											if (num97 < 0)
											{
												num97 = 0;
											}
											if (num98 > Main.maxTilesY)
											{
												num98 = Main.maxTilesY;
											}
											for (int num99 = num95; num99 < num96; num99++)
											{
												int num100 = num97;
												while (num100 < num98)
												{
													if (Main.tile[num99, num100] == null)
													{
														Main.tile[num99, num100] = new Tile();
													}
													Vector2 vector6;
													vector6.X = (float)(num99 * 16);
													vector6.Y = (float)(num100 * 16);
													if (this.position.X + (float)this.width > vector6.X && this.position.X < vector6.X + 16f && this.position.Y + (float)this.height > vector6.Y && this.position.Y < vector6.Y + 16f && Main.tile[num99, num100].nactive() && Main.tileSolid[(int)Main.tile[num99, num100].type])
													{
														if (Main.player[this.owner].grapCount < 10)
														{
															Main.player[this.owner].grappling[Main.player[this.owner].grapCount] = this.whoAmI;
															Main.player[this.owner].grapCount++;
														}
														if (Main.myPlayer == this.owner)
														{
															int num101 = 0;
															int num102 = -1;
															int num103 = 100000;
															if (this.type == 73 || this.type == 74)
															{
																for (int num104 = 0; num104 < 1000; num104++)
																{
																	if (num104 != this.whoAmI && Main.projectile[num104].active && Main.projectile[num104].owner == this.owner && Main.projectile[num104].aiStyle == 7 && Main.projectile[num104].ai[0] == 2f)
																	{
																		Main.projectile[num104].Kill();
																	}
																}
															}
															else
															{
																int num105 = 3;
																if (this.type == 165)
																{
																	num105 = 8;
																}
																if (this.type == 256)
																{
																	num105 = 2;
																}
																for (int num106 = 0; num106 < 1000; num106++)
																{
																	if (Main.projectile[num106].active && Main.projectile[num106].owner == this.owner && Main.projectile[num106].aiStyle == 7)
																	{
																		if (Main.projectile[num106].timeLeft < num103)
																		{
																			num102 = num106;
																			num103 = Main.projectile[num106].timeLeft;
																		}
																		num101++;
																	}
																}
																if (num101 > num105)
																{
																	Main.projectile[num102].Kill();
																}
															}
														}
														WorldGen.KillTile(num99, num100, true, true, false);
														Main.PlaySound(0, num99 * 16, num100 * 16, 1);
														this.velocity.X = 0f;
														this.velocity.Y = 0f;
														this.ai[0] = 2f;
														this.position.X = (float)(num99 * 16 + 8 - this.width / 2);
														this.position.Y = (float)(num100 * 16 + 8 - this.height / 2);
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
														num100++;
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
											float num107 = 11f;
											if (this.type == 32)
											{
												num107 = 15f;
											}
											if (this.type == 73 || this.type == 74)
											{
												num107 = 17f;
											}
											if (this.type >= 230 && this.type <= 235)
											{
												num107 = 11f + (float)(this.type - 230) * 0.75f;
											}
											if (num93 < 24f)
											{
												this.Kill();
											}
											num93 = num107 / num93;
											num91 *= num93;
											num92 *= num93;
											this.velocity.X = num91;
											this.velocity.Y = num92;
											return;
										}
										if (this.ai[0] == 2f)
										{
											int num108 = (int)(this.position.X / 16f) - 1;
											int num109 = (int)((this.position.X + (float)this.width) / 16f) + 2;
											int num110 = (int)(this.position.Y / 16f) - 1;
											int num111 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
											if (num108 < 0)
											{
												num108 = 0;
											}
											if (num109 > Main.maxTilesX)
											{
												num109 = Main.maxTilesX;
											}
											if (num110 < 0)
											{
												num110 = 0;
											}
											if (num111 > Main.maxTilesY)
											{
												num111 = Main.maxTilesY;
											}
											bool flag3 = true;
											for (int num112 = num108; num112 < num109; num112++)
											{
												for (int num113 = num110; num113 < num111; num113++)
												{
													if (Main.tile[num112, num113] == null)
													{
														Main.tile[num112, num113] = new Tile();
													}
													Vector2 vector7;
													vector7.X = (float)(num112 * 16);
													vector7.Y = (float)(num113 * 16);
													if (this.position.X + (float)(this.width / 2) > vector7.X && this.position.X + (float)(this.width / 2) < vector7.X + 16f && this.position.Y + (float)(this.height / 2) > vector7.Y && this.position.Y + (float)(this.height / 2) < vector7.Y + 16f && Main.tile[num112, num113].nactive() && Main.tileSolid[(int)Main.tile[num112, num113].type])
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
									else
									{
										if (this.aiStyle == 8)
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
												for (int num114 = 0; num114 < 5; num114++)
												{
													float num115 = this.velocity.X / 3f * (float)num114;
													float num116 = this.velocity.Y / 3f * (float)num114;
													int num117 = 4;
													int num118 = Dust.NewDust(new Vector2(this.position.X + (float)num117, this.position.Y + (float)num117), this.width - num117 * 2, this.height - num117 * 2, 172, 0f, 0f, 100, default(Color), 1.2f);
													Main.dust[num118].noGravity = true;
													Main.dust[num118].velocity *= 0.1f;
													Main.dust[num118].velocity += this.velocity * 0.1f;
													Dust expr_52BA_cp_0 = Main.dust[num118];
													expr_52BA_cp_0.position.X = expr_52BA_cp_0.position.X - num115;
													Dust expr_52D5_cp_0 = Main.dust[num118];
													expr_52D5_cp_0.position.Y = expr_52D5_cp_0.position.Y - num116;
												}
												if (Main.rand.Next(5) == 0)
												{
													int num119 = 4;
													int num120 = Dust.NewDust(new Vector2(this.position.X + (float)num119, this.position.Y + (float)num119), this.width - num119 * 2, this.height - num119 * 2, 172, 0f, 0f, 100, default(Color), 0.6f);
													Main.dust[num120].velocity *= 0.25f;
													Main.dust[num120].velocity += this.velocity * 0.5f;
												}
											}
											else
											{
												if (this.type == 95 || this.type == 96)
												{
													int num121 = Dust.NewDust(new Vector2(this.position.X + this.velocity.X, this.position.Y + this.velocity.Y), this.width, this.height, 75, this.velocity.X, this.velocity.Y, 100, default(Color), 3f * this.scale);
													Main.dust[num121].noGravity = true;
												}
												else
												{
													if (this.type == 253)
													{
														for (int num122 = 0; num122 < 2; num122++)
														{
															int num123 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 135, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 2f);
															Main.dust[num123].noGravity = true;
															Dust expr_54F3_cp_0 = Main.dust[num123];
															expr_54F3_cp_0.velocity.X = expr_54F3_cp_0.velocity.X * 0.3f;
															Dust expr_5511_cp_0 = Main.dust[num123];
															expr_5511_cp_0.velocity.Y = expr_5511_cp_0.velocity.Y * 0.3f;
														}
													}
													else
													{
														for (int num124 = 0; num124 < 2; num124++)
														{
															int num125 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 2f);
															Main.dust[num125].noGravity = true;
															Dust expr_55BE_cp_0 = Main.dust[num125];
															expr_55BE_cp_0.velocity.X = expr_55BE_cp_0.velocity.X * 0.3f;
															Dust expr_55DC_cp_0 = Main.dust[num125];
															expr_55DC_cp_0.velocity.Y = expr_55DC_cp_0.velocity.Y * 0.3f;
														}
													}
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
										else
										{
											if (this.aiStyle == 9)
											{
												if (this.type == 34)
												{
													int num126 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 3.5f);
													Main.dust[num126].noGravity = true;
													Main.dust[num126].velocity *= 1.4f;
													num126 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 1.5f);
												}
												else
												{
													if (this.type == 79)
													{
														if (this.soundDelay == 0 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 2f)
														{
															this.soundDelay = 10;
															Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 9);
														}
														for (int num127 = 0; num127 < 1; num127++)
														{
															int num128 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 66, 0f, 0f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 2.5f);
															Main.dust[num128].velocity *= 0.1f;
															Main.dust[num128].velocity += this.velocity * 0.2f;
															Main.dust[num128].position.X = this.position.X + (float)(this.width / 2) + 4f + (float)Main.rand.Next(-2, 3);
															Main.dust[num128].position.Y = this.position.Y + (float)(this.height / 2) + (float)Main.rand.Next(-2, 3);
															Main.dust[num128].noGravity = true;
														}
													}
													else
													{
														if (this.soundDelay == 0 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 2f)
														{
															this.soundDelay = 10;
															Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 9);
														}
														int num129 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 15, 0f, 0f, 100, default(Color), 2f);
														Main.dust[num129].velocity *= 0.3f;
														Main.dust[num129].position.X = this.position.X + (float)(this.width / 2) + 4f + (float)Main.rand.Next(-4, 5);
														Main.dust[num129].position.Y = this.position.Y + (float)(this.height / 2) + (float)Main.rand.Next(-4, 5);
														Main.dust[num129].noGravity = true;
													}
												}
												if (Main.myPlayer == this.owner && this.ai[0] == 0f)
												{
													if (Main.player[this.owner].channel)
													{
														float num130 = 12f;
														if (this.type == 16)
														{
															num130 = 15f;
														}
														Vector2 vector8 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
														float num131 = (float)Main.mouseX + Main.screenPosition.X - vector8.X;
														float num132 = (float)Main.mouseY + Main.screenPosition.Y - vector8.Y;
														if (Main.player[this.owner].gravDir == -1f)
														{
															num132 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector8.Y;
														}
														float num133 = (float)Math.Sqrt((double)(num131 * num131 + num132 * num132));
														num133 = (float)Math.Sqrt((double)(num131 * num131 + num132 * num132));
														if (num133 > num130)
														{
															num133 = num130 / num133;
															num131 *= num133;
															num132 *= num133;
															int num134 = (int)(num131 * 1000f);
															int num135 = (int)(this.velocity.X * 1000f);
															int num136 = (int)(num132 * 1000f);
															int num137 = (int)(this.velocity.Y * 1000f);
															if (num134 != num135 || num136 != num137)
															{
																this.netUpdate = true;
															}
															this.velocity.X = num131;
															this.velocity.Y = num132;
														}
														else
														{
															int num138 = (int)(num131 * 1000f);
															int num139 = (int)(this.velocity.X * 1000f);
															int num140 = (int)(num132 * 1000f);
															int num141 = (int)(this.velocity.Y * 1000f);
															if (num138 != num139 || num140 != num141)
															{
																this.netUpdate = true;
															}
															this.velocity.X = num131;
															this.velocity.Y = num132;
														}
													}
													else
													{
														if (this.ai[0] == 0f)
														{
															this.ai[0] = 1f;
															this.netUpdate = true;
															float num142 = 12f;
															Vector2 vector9 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
															float num143 = (float)Main.mouseX + Main.screenPosition.X - vector9.X;
															float num144 = (float)Main.mouseY + Main.screenPosition.Y - vector9.Y;
															float num145 = (float)Math.Sqrt((double)(num143 * num143 + num144 * num144));
															if (num145 == 0f)
															{
																vector9 = new Vector2(Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2), Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2));
																num143 = this.position.X + (float)this.width * 0.5f - vector9.X;
																num144 = this.position.Y + (float)this.height * 0.5f - vector9.Y;
																num145 = (float)Math.Sqrt((double)(num143 * num143 + num144 * num144));
															}
															num145 = num142 / num145;
															num143 *= num145;
															num144 *= num145;
															this.velocity.X = num143;
															this.velocity.Y = num144;
															if (this.velocity.X == 0f && this.velocity.Y == 0f)
															{
																this.Kill();
															}
														}
													}
												}
												if (this.type == 34)
												{
													this.rotation += 0.3f * (float)this.direction;
												}
												else
												{
													if (this.velocity.X != 0f || this.velocity.Y != 0f)
													{
														this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) - 2.355f;
													}
												}
												if (this.velocity.Y > 16f)
												{
													this.velocity.Y = 16f;
													return;
												}
											}
											else
											{
												if (this.aiStyle == 10)
												{
													if (this.type == 31 && this.ai[0] != 2f)
													{
														if (Main.rand.Next(2) == 0)
														{
															int num146 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 32, 0f, this.velocity.Y / 2f, 0, default(Color), 1f);
															Dust expr_5FBB_cp_0 = Main.dust[num146];
															expr_5FBB_cp_0.velocity.X = expr_5FBB_cp_0.velocity.X * 0.4f;
														}
													}
													else
													{
														if (this.type == 39)
														{
															if (Main.rand.Next(2) == 0)
															{
																int num147 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 38, 0f, this.velocity.Y / 2f, 0, default(Color), 1f);
																Dust expr_6055_cp_0 = Main.dust[num147];
																expr_6055_cp_0.velocity.X = expr_6055_cp_0.velocity.X * 0.4f;
															}
														}
														else
														{
															if (this.type == 40)
															{
																if (Main.rand.Next(2) == 0)
																{
																	int num148 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 36, 0f, this.velocity.Y / 2f, 0, default(Color), 1f);
																	Main.dust[num148].velocity *= 0.4f;
																}
															}
															else
															{
																if (this.type == 42 || this.type == 31)
																{
																	if (Main.rand.Next(2) == 0)
																	{
																		int num149 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 32, 0f, 0f, 0, default(Color), 1f);
																		Dust expr_6186_cp_0 = Main.dust[num149];
																		expr_6186_cp_0.velocity.X = expr_6186_cp_0.velocity.X * 0.4f;
																	}
																}
																else
																{
																	if (this.type == 56 || this.type == 65)
																	{
																		if (Main.rand.Next(2) == 0)
																		{
																			int num150 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 0, default(Color), 1f);
																			Dust expr_621E_cp_0 = Main.dust[num150];
																			expr_621E_cp_0.velocity.X = expr_621E_cp_0.velocity.X * 0.4f;
																		}
																	}
																	else
																	{
																		if (this.type == 67 || this.type == 68)
																		{
																			if (Main.rand.Next(2) == 0)
																			{
																				int num151 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 51, 0f, 0f, 0, default(Color), 1f);
																				Dust expr_62B6_cp_0 = Main.dust[num151];
																				expr_62B6_cp_0.velocity.X = expr_62B6_cp_0.velocity.X * 0.4f;
																			}
																		}
																		else
																		{
																			if (this.type == 71)
																			{
																				if (Main.rand.Next(2) == 0)
																				{
																					int num152 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 53, 0f, 0f, 0, default(Color), 1f);
																					Dust expr_6344_cp_0 = Main.dust[num152];
																					expr_6344_cp_0.velocity.X = expr_6344_cp_0.velocity.X * 0.4f;
																				}
																			}
																			else
																			{
																				if (this.type == 179)
																				{
																					if (Main.rand.Next(2) == 0)
																					{
																						int num153 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 149, 0f, 0f, 0, default(Color), 1f);
																						Dust expr_63D8_cp_0 = Main.dust[num153];
																						expr_63D8_cp_0.velocity.X = expr_63D8_cp_0.velocity.X * 0.4f;
																					}
																				}
																				else
																				{
																					if (this.type == 241)
																					{
																						if (Main.rand.Next(2) == 0)
																						{
																							int num154 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 36, 0f, 0f, 0, default(Color), 1f);
																							Dust expr_6466_cp_0 = Main.dust[num154];
																							expr_6466_cp_0.velocity.X = expr_6466_cp_0.velocity.X * 0.4f;
																						}
																					}
																					else
																					{
																						if (this.type != 109 && Main.rand.Next(20) == 0)
																						{
																							Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0, 0f, 0f, 0, default(Color), 1f);
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
													if (Main.myPlayer == this.owner && this.ai[0] == 0f)
													{
														if (Main.player[this.owner].channel)
														{
															float num155 = 12f;
															Vector2 vector10 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
															float num156 = (float)Main.mouseX + Main.screenPosition.X - vector10.X;
															float num157 = (float)Main.mouseY + Main.screenPosition.Y - vector10.Y;
															float num158 = (float)Math.Sqrt((double)(num156 * num156 + num157 * num157));
															num158 = (float)Math.Sqrt((double)(num156 * num156 + num157 * num157));
															if (num158 > num155)
															{
																num158 = num155 / num158;
																num156 *= num158;
																num157 *= num158;
																if (num156 != this.velocity.X || num157 != this.velocity.Y)
																{
																	this.netUpdate = true;
																}
																this.velocity.X = num156;
																this.velocity.Y = num157;
															}
															else
															{
																if (num156 != this.velocity.X || num157 != this.velocity.Y)
																{
																	this.netUpdate = true;
																}
																this.velocity.X = num156;
																this.velocity.Y = num157;
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
													else
													{
														if (this.ai[0] == 2f && this.type != 109)
														{
															this.velocity.Y = this.velocity.Y + 0.2f;
															if ((double)this.velocity.X < -0.04)
															{
																this.velocity.X = this.velocity.X + 0.04f;
															}
															else
															{
																if ((double)this.velocity.X > 0.04)
																{
																	this.velocity.X = this.velocity.X - 0.04f;
																}
																else
																{
																	this.velocity.X = 0f;
																}
															}
														}
													}
													this.rotation += 0.1f;
													if (this.velocity.Y > 10f)
													{
														this.velocity.Y = 10f;
														return;
													}
												}
												else
												{
													if (this.aiStyle == 11)
													{
														if (this.type == 72 || this.type == 86 || this.type == 87)
														{
															if (this.velocity.X > 0f)
															{
																this.spriteDirection = -1;
															}
															else
															{
																if (this.velocity.X < 0f)
																{
																	this.spriteDirection = 1;
																}
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
																int num159 = 56;
																if (this.type == 86)
																{
																	num159 = 73;
																}
																else
																{
																	if (this.type == 87)
																	{
																		num159 = 74;
																	}
																}
																int num160 = Dust.NewDust(this.position, this.width, this.height, num159, 0f, 0f, 200, default(Color), 0.8f);
																Main.dust[num160].velocity *= 0.3f;
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
															else
															{
																if (Main.player[Main.myPlayer].lightOrb)
																{
																	this.timeLeft = 2;
																}
															}
														}
														if (Main.player[this.owner].dead)
														{
															this.Kill();
															return;
														}
														float num161 = 3f;
														if (this.type == 72 || this.type == 86 || this.type == 87)
														{
															num161 = 3.75f;
														}
														Vector2 vector11 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
														float num162 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector11.X;
														float num163 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector11.Y;
														int num164 = 70;
														if (this.type == 18)
														{
															if (Main.player[this.owner].controlUp)
															{
																num163 = Main.player[this.owner].position.Y - 40f - vector11.Y;
																num162 -= 6f;
																num164 = 4;
															}
															else
															{
																if (Main.player[this.owner].controlDown)
																{
																	num163 = Main.player[this.owner].position.Y + (float)Main.player[this.owner].height + 40f - vector11.Y;
																	num162 -= 6f;
																	num164 = 4;
																}
															}
														}
														float num165 = (float)Math.Sqrt((double)(num162 * num162 + num163 * num163));
														num165 = (float)Math.Sqrt((double)(num162 * num162 + num163 * num163));
														if (this.type == 72 || this.type == 86 || this.type == 87)
														{
															num164 = 40;
														}
														if (num165 > 800f)
														{
															this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
															this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
															return;
														}
														if (num165 > (float)num164)
														{
															num165 = num161 / num165;
															num162 *= num165;
															num163 *= num165;
															this.velocity.X = num162;
															this.velocity.Y = num163;
															return;
														}
														this.velocity.X = 0f;
														this.velocity.Y = 0f;
														return;
													}
													else
													{
														if (this.aiStyle == 12)
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
																for (int num166 = 0; num166 < 3; num166++)
																{
																	float num167 = this.velocity.X / 3f * (float)num166;
																	float num168 = this.velocity.Y / 3f * (float)num166;
																	int num169 = 14;
																	int num170 = Dust.NewDust(new Vector2(this.position.X + (float)num169, this.position.Y + (float)num169), this.width - num169 * 2, this.height - num169 * 2, 170, 0f, 0f, 100, default(Color), 1f);
																	Main.dust[num170].noGravity = true;
																	Main.dust[num170].velocity *= 0.1f;
																	Main.dust[num170].velocity += this.velocity * 0.5f;
																	Dust expr_6E4D_cp_0 = Main.dust[num170];
																	expr_6E4D_cp_0.position.X = expr_6E4D_cp_0.position.X - num167;
																	Dust expr_6E68_cp_0 = Main.dust[num170];
																	expr_6E68_cp_0.position.Y = expr_6E68_cp_0.position.Y - num168;
																}
																if (Main.rand.Next(8) == 0)
																{
																	int num171 = 16;
																	int num172 = Dust.NewDust(new Vector2(this.position.X + (float)num171, this.position.Y + (float)num171), this.width - num171 * 2, this.height - num171 * 2, 170, 0f, 0f, 100, default(Color), 0.5f);
																	Main.dust[num172].velocity *= 0.25f;
																	Main.dust[num172].velocity += this.velocity * 0.5f;
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
																	for (int num173 = 0; num173 < 1; num173++)
																	{
																		for (int num174 = 0; num174 < 3; num174++)
																		{
																			float num175 = this.velocity.X / 3f * (float)num174;
																			float num176 = this.velocity.Y / 3f * (float)num174;
																			int num177 = 6;
																			int num178 = Dust.NewDust(new Vector2(this.position.X + (float)num177, this.position.Y + (float)num177), this.width - num177 * 2, this.height - num177 * 2, 172, 0f, 0f, 100, default(Color), 1.2f);
																			Main.dust[num178].noGravity = true;
																			Main.dust[num178].velocity *= 0.3f;
																			Main.dust[num178].velocity += this.velocity * 0.5f;
																			Dust expr_70B3_cp_0 = Main.dust[num178];
																			expr_70B3_cp_0.position.X = expr_70B3_cp_0.position.X - num175;
																			Dust expr_70CE_cp_0 = Main.dust[num178];
																			expr_70CE_cp_0.position.Y = expr_70CE_cp_0.position.Y - num176;
																		}
																		if (Main.rand.Next(8) == 0)
																		{
																			int num179 = 6;
																			int num180 = Dust.NewDust(new Vector2(this.position.X + (float)num179, this.position.Y + (float)num179), this.width - num179 * 2, this.height - num179 * 2, 172, 0f, 0f, 100, default(Color), 0.75f);
																			Main.dust[num180].velocity *= 0.5f;
																			Main.dust[num180].velocity += this.velocity * 0.5f;
																		}
																	}
																	return;
																}
																this.ai[0] += 1f;
																return;
															}
														}
														else
														{
															if (this.aiStyle == 13)
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
																float num181 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector12.X;
																float num182 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector12.Y;
																float num183 = (float)Math.Sqrt((double)(num181 * num181 + num182 * num182));
																if (this.ai[0] == 0f)
																{
																	if (num183 > 700f)
																	{
																		this.ai[0] = 1f;
																	}
																	else
																	{
																		if (this.type == 262 && num183 > 500f)
																		{
																			this.ai[0] = 1f;
																		}
																		else
																		{
																			if (this.type == 271 && num183 > 200f)
																			{
																				this.ai[0] = 1f;
																			}
																			else
																			{
																				if (this.type == 273 && num183 > 150f)
																				{
																					this.ai[0] = 1f;
																				}
																			}
																		}
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
																	else
																	{
																		if (this.type == 262)
																		{
																			this.spriteDirection = 1;
																		}
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
																else
																{
																	if (this.ai[0] == 1f)
																	{
																		this.tileCollide = false;
																		this.rotation = (float)Math.Atan2((double)num182, (double)num181) - 1.57f;
																		float num184 = 20f;
																		if (this.type == 262)
																		{
																			num184 = 30f;
																		}
																		if (num183 < 50f)
																		{
																			this.Kill();
																		}
																		num183 = num184 / num183;
																		num181 *= num183;
																		num182 *= num183;
																		this.velocity.X = num181;
																		this.velocity.Y = num182;
																		if (this.type == 262 && this.velocity.X < 0f)
																		{
																			this.spriteDirection = 1;
																		}
																		else
																		{
																			if (this.type == 262)
																			{
																				this.spriteDirection = -1;
																			}
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
															}
															else
															{
																if (this.aiStyle == 14)
																{
																	if (this.type == 196)
																	{
																		int num185 = Main.rand.Next(1, 3);
																		for (int num186 = 0; num186 < num185; num186++)
																		{
																			int num187 = Dust.NewDust(this.position, this.width, this.height, 31, 0f, 0f, 100, default(Color), 1f);
																			Main.dust[num187].alpha += Main.rand.Next(100);
																			Main.dust[num187].velocity *= 0.3f;
																			Dust expr_771E_cp_0 = Main.dust[num187];
																			expr_771E_cp_0.velocity.X = expr_771E_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.025f;
																			Dust expr_774C_cp_0 = Main.dust[num187];
																			expr_774C_cp_0.velocity.Y = expr_774C_cp_0.velocity.Y - (0.4f + (float)Main.rand.Next(-3, 14) * 0.15f);
																			Main.dust[num187].fadeIn = 1.25f + (float)Main.rand.Next(20) * 0.15f;
																		}
																	}
																	if (this.type == 53)
																	{
																		try
																		{
																			Vector2 value2 = Collision.TileCollision(this.position, this.velocity, this.width, this.height, false, false);
																			this.velocity = value2;
																			int num188 = (int)(this.position.X / 16f) - 1;
																			int num189 = (int)((this.position.X + (float)this.width) / 16f) + 2;
																			int num190 = (int)(this.position.Y / 16f) - 1;
																			int num191 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
																			if (num188 < 0)
																			{
																				num188 = 0;
																			}
																			if (num189 > Main.maxTilesX)
																			{
																				num189 = Main.maxTilesX;
																			}
																			if (num190 < 0)
																			{
																				num190 = 0;
																			}
																			if (num191 > Main.maxTilesY)
																			{
																				num191 = Main.maxTilesY;
																			}
																			for (int num192 = num188; num192 < num189; num192++)
																			{
																				for (int num193 = num190; num193 < num191; num193++)
																				{
																					if (Main.tile[num192, num193] != null && Main.tile[num192, num193].nactive() && (Main.tileSolid[(int)Main.tile[num192, num193].type] || (Main.tileSolidTop[(int)Main.tile[num192, num193].type] && Main.tile[num192, num193].frameY == 0)))
																					{
																						Vector2 vector13;
																						vector13.X = (float)(num192 * 16);
																						vector13.Y = (float)(num193 * 16);
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
																	if (this.velocity.Y > 16f)
																	{
																		this.velocity.Y = 16f;
																		return;
																	}
																}
																else
																{
																	if (this.aiStyle == 15)
																	{
																		if (this.type == 25)
																		{
																			if (Main.rand.Next(15) == 0)
																			{
																				Dust.NewDust(this.position, this.width, this.height, 14, 0f, 0f, 150, default(Color), 1.3f);
																			}
																		}
																		else
																		{
																			if (this.type == 26)
																			{
																				int num194 = Dust.NewDust(this.position, this.width, this.height, 172, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 100, default(Color), 1.5f);
																				Main.dust[num194].noGravity = true;
																				Dust expr_7D07_cp_0 = Main.dust[num194];
																				expr_7D07_cp_0.velocity.X = expr_7D07_cp_0.velocity.X / 2f;
																				Dust expr_7D25_cp_0 = Main.dust[num194];
																				expr_7D25_cp_0.velocity.Y = expr_7D25_cp_0.velocity.Y / 2f;
																			}
																			else
																			{
																				if (this.type == 35)
																				{
																					int num195 = Dust.NewDust(this.position, this.width, this.height, 6, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 100, default(Color), 3f);
																					Main.dust[num195].noGravity = true;
																					Dust expr_7DB4_cp_0 = Main.dust[num195];
																					expr_7DB4_cp_0.velocity.X = expr_7DB4_cp_0.velocity.X * 2f;
																					Dust expr_7DD2_cp_0 = Main.dust[num195];
																					expr_7DD2_cp_0.velocity.Y = expr_7DD2_cp_0.velocity.Y * 2f;
																				}
																				else
																				{
																					if (this.type == 154)
																					{
																						int num196 = Dust.NewDust(this.position, this.width, this.height, 115, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 140, default(Color), 1.5f);
																						Main.dust[num196].noGravity = true;
																						Main.dust[num196].velocity *= 0.25f;
																					}
																				}
																			}
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
																		float num197 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector14.X;
																		float num198 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector14.Y;
																		float num199 = (float)Math.Sqrt((double)(num197 * num197 + num198 * num198));
																		if (this.ai[0] == 0f)
																		{
																			float num200 = 160f;
																			if (this.type == 63)
																			{
																				num200 *= 1.5f;
																			}
																			if (this.type == 247)
																			{
																				num200 *= 1.5f;
																			}
																			this.tileCollide = true;
																			if (num199 > num200)
																			{
																				this.ai[0] = 1f;
																				this.netUpdate = true;
																			}
																			else
																			{
																				if (!Main.player[this.owner].channel)
																				{
																					if (this.velocity.Y < 0f)
																					{
																						this.velocity.Y = this.velocity.Y * 0.9f;
																					}
																					this.velocity.Y = this.velocity.Y + 1f;
																					this.velocity.X = this.velocity.X * 0.9f;
																				}
																			}
																		}
																		else
																		{
																			if (this.ai[0] == 1f)
																			{
																				float num201 = 14f / Main.player[this.owner].meleeSpeed;
																				float num202 = 0.9f / Main.player[this.owner].meleeSpeed;
																				float num203 = 300f;
																				if (this.type == 63)
																				{
																					num203 *= 1.5f;
																					num201 *= 1.5f;
																					num202 *= 1.5f;
																				}
																				if (this.type == 247)
																				{
																					num203 *= 1.5f;
																					num201 = 15.9f;
																					num202 *= 2f;
																				}
																				Math.Abs(num197);
																				Math.Abs(num198);
																				if (this.ai[1] == 1f)
																				{
																					this.tileCollide = false;
																				}
																				if (!Main.player[this.owner].channel || num199 > num203 || !this.tileCollide)
																				{
																					this.ai[1] = 1f;
																					if (this.tileCollide)
																					{
																						this.netUpdate = true;
																					}
																					this.tileCollide = false;
																					if (num199 < 20f)
																					{
																						this.Kill();
																					}
																				}
																				if (!this.tileCollide)
																				{
																					num202 *= 2f;
																				}
																				int num204 = 60;
																				if (this.type == 247)
																				{
																					num204 = 100;
																				}
																				if (num199 > (float)num204 || !this.tileCollide)
																				{
																					num199 = num201 / num199;
																					num197 *= num199;
																					num198 *= num199;
																					new Vector2(this.velocity.X, this.velocity.Y);
																					float num205 = num197 - this.velocity.X;
																					float num206 = num198 - this.velocity.Y;
																					float num207 = (float)Math.Sqrt((double)(num205 * num205 + num206 * num206));
																					num207 = num202 / num207;
																					num205 *= num207;
																					num206 *= num207;
																					this.velocity.X = this.velocity.X * 0.98f;
																					this.velocity.Y = this.velocity.Y * 0.98f;
																					this.velocity.X = this.velocity.X + num205;
																					this.velocity.Y = this.velocity.Y + num206;
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
																		}
																		if (this.type != 247)
																		{
																			this.rotation = (float)Math.Atan2((double)num198, (double)num197) - this.velocity.X * 0.1f;
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
																		float num208 = this.position.X;
																		float num209 = this.position.Y;
																		float num210 = 600f;
																		bool flag4 = false;
																		if (this.owner == Main.myPlayer)
																		{
																			this.localAI[1] += 1f;
																			if (this.localAI[1] > 20f)
																			{
																				this.localAI[1] = 20f;
																				for (int num211 = 0; num211 < 200; num211++)
																				{
																					if (Main.npc[num211].active && !Main.npc[num211].dontTakeDamage && !Main.npc[num211].friendly && Main.npc[num211].lifeMax > 5)
																					{
																						float num212 = Main.npc[num211].position.X + (float)(Main.npc[num211].width / 2);
																						float num213 = Main.npc[num211].position.Y + (float)(Main.npc[num211].height / 2);
																						float num214 = Math.Abs(this.position.X + (float)(this.width / 2) - num212) + Math.Abs(this.position.Y + (float)(this.height / 2) - num213);
																						if (num214 < num210 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num211].position, Main.npc[num211].width, Main.npc[num211].height))
																						{
																							num210 = num214;
																							num208 = num212;
																							num209 = num213;
																							flag4 = true;
																						}
																					}
																				}
																			}
																		}
																		if (flag4)
																		{
																			this.localAI[1] = 0f;
																			float num215 = 14f;
																			vector14 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
																			num197 = num208 - vector14.X;
																			num198 = num209 - vector14.Y;
																			num199 = (float)Math.Sqrt((double)(num197 * num197 + num198 * num198));
																			num199 = num215 / num199;
																			num197 *= num199;
																			num198 *= num199;
																			Projectile.NewProjectile(vector14.X, vector14.Y, num197, num198, 248, (int)((double)this.damage / 1.5), this.knockBack / 2f, Main.myPlayer, 0f, 0f);
																			return;
																		}
																	}
																	else
																	{
																		if (this.aiStyle == 16)
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
																					int num216 = (int)(this.position.X / 16f) - 1;
																					int num217 = (int)((this.position.X + (float)this.width) / 16f) + 2;
																					int num218 = (int)(this.position.Y / 16f) - 1;
																					int num219 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
																					if (num216 < 0)
																					{
																						num216 = 0;
																					}
																					if (num217 > Main.maxTilesX)
																					{
																						num217 = Main.maxTilesX;
																					}
																					if (num218 < 0)
																					{
																						num218 = 0;
																					}
																					if (num219 > Main.maxTilesY)
																					{
																						num219 = Main.maxTilesY;
																					}
																					for (int num220 = num216; num220 < num217; num220++)
																					{
																						for (int num221 = num218; num221 < num219; num221++)
																						{
																							if (Main.tile[num220, num221] != null && Main.tile[num220, num221].nactive() && (Main.tileSolid[(int)Main.tile[num220, num221].type] || (Main.tileSolidTop[(int)Main.tile[num220, num221].type] && Main.tile[num220, num221].frameY == 0)))
																							{
																								Vector2 vector15;
																								vector15.X = (float)(num220 * 16);
																								vector15.Y = (float)(num221 * 16);
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
																				else
																				{
																					if (this.type == 29)
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
																					else
																					{
																						if (this.type == 30)
																						{
																							this.position.X = this.position.X + (float)(this.width / 2);
																							this.position.Y = this.position.Y + (float)(this.height / 2);
																							this.width = 128;
																							this.height = 128;
																							this.position.X = this.position.X - (float)(this.width / 2);
																							this.position.Y = this.position.Y - (float)(this.height / 2);
																							this.knockBack = 8f;
																						}
																						else
																						{
																							if (this.type == 133 || this.type == 134 || this.type == 135 || this.type == 136 || this.type == 137 || this.type == 138)
																							{
																								this.position.X = this.position.X + (float)(this.width / 2);
																								this.position.Y = this.position.Y + (float)(this.height / 2);
																								this.width = 128;
																								this.height = 128;
																								this.position.X = this.position.X - (float)(this.width / 2);
																								this.position.Y = this.position.Y - (float)(this.height / 2);
																								this.knockBack = 8f;
																							}
																							else
																							{
																								if (this.type == 139 || this.type == 140 || this.type == 141 || this.type == 142 || this.type == 143 || this.type == 144)
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
																						}
																					}
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
																						for (int num222 = 0; num222 < 2; num222++)
																						{
																							float num223 = 0f;
																							float num224 = 0f;
																							if (num222 == 1)
																							{
																								num223 = this.velocity.X * 0.5f;
																								num224 = this.velocity.Y * 0.5f;
																							}
																							int num225 = Dust.NewDust(new Vector2(this.position.X + 3f + num223, this.position.Y + 3f + num224) - this.velocity * 0.5f, this.width - 8, this.height - 8, 6, 0f, 0f, 100, default(Color), 1f);
																							Main.dust[num225].scale *= 2f + (float)Main.rand.Next(10) * 0.1f;
																							Main.dust[num225].velocity *= 0.2f;
																							Main.dust[num225].noGravity = true;
																							num225 = Dust.NewDust(new Vector2(this.position.X + 3f + num223, this.position.Y + 3f + num224) - this.velocity * 0.5f, this.width - 8, this.height - 8, 31, 0f, 0f, 100, default(Color), 0.5f);
																							Main.dust[num225].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
																							Main.dust[num225].velocity *= 0.05f;
																						}
																					}
																					if (Math.Abs(this.velocity.X) < 15f && Math.Abs(this.velocity.Y) < 15f)
																					{
																						this.velocity *= 1.1f;
																					}
																				}
																				else
																				{
																					if (this.type == 133 || this.type == 136 || this.type == 139 || this.type == 142)
																					{
																						int num226 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1f);
																						Main.dust[num226].scale *= 1f + (float)Main.rand.Next(10) * 0.1f;
																						Main.dust[num226].velocity *= 0.2f;
																						Main.dust[num226].noGravity = true;
																					}
																					else
																					{
																						if (this.type == 135 || this.type == 138 || this.type == 141 || this.type == 144)
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
																								int num227 = Dust.NewDust(new Vector2(this.position.X + 3f, this.position.Y + 3f) - this.velocity * 0.5f, this.width - 8, this.height - 8, 31, 0f, 0f, 100, default(Color), 1f);
																								Main.dust[num227].scale *= 1.6f + (float)Main.rand.Next(5) * 0.1f;
																								Main.dust[num227].velocity *= 0.05f;
																								Main.dust[num227].noGravity = true;
																							}
																						}
																						else
																						{
																							if (this.type != 30 && Main.rand.Next(2) == 0)
																							{
																								int num228 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1f);
																								Main.dust[num228].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
																								Main.dust[num228].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
																								Main.dust[num228].noGravity = true;
																								if (Main.rand.Next(3) == 0)
																								{
																									num228 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
																									Main.dust[num228].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
																									Main.dust[num228].noGravity = true;
																								}
																							}
																						}
																					}
																				}
																			}
																			this.ai[0] += 1f;
																			if (this.type == 134 || this.type == 137 || this.type == 140 || this.type == 143 || this.type == 303)
																			{
																				this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
																			}
																			else
																			{
																				if (this.type == 135 || this.type == 138 || this.type == 141 || this.type == 144)
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
																				else
																				{
																					if (this.type == 133 || this.type == 136 || this.type == 139 || this.type == 142)
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
																					else
																					{
																						if ((this.type == 30 && this.ai[0] > 10f) || (this.type != 30 && this.ai[0] > 5f))
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
																					}
																				}
																			}
																			if (this.type != 134 && this.type != 137 && this.type != 140 && this.type != 143 && this.type != 303)
																			{
																				this.rotation += this.velocity.X * 0.1f;
																				return;
																			}
																		}
																		else
																		{
																			if (this.aiStyle == 17)
																			{
																				if (this.velocity.Y == 0f)
																				{
																					this.velocity.X = this.velocity.X * 0.98f;
																				}
																				this.rotation += this.velocity.X * 0.1f;
																				this.velocity.Y = this.velocity.Y + 0.2f;
																				if (this.owner == Main.myPlayer)
																				{
																					int num229 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
																					int num230 = (int)((this.position.Y + (float)this.height - 4f) / 16f);
																					if (Main.tile[num229, num230] != null && !Main.tile[num229, num230].active())
																					{
																						int num231 = 0;
																						if (this.type >= 201 && this.type <= 205)
																						{
																							num231 = this.type - 200;
																						}
																						WorldGen.PlaceTile(num229, num230, 85, false, false, this.owner, num231);
																						if (Main.tile[num229, num230].active())
																						{
																							if (Main.netMode != 0)
																							{
																								NetMessage.SendData(17, -1, -1, "", 1, (float)num229, (float)num230, 85f, num231);
																							}
																							int num232 = Sign.ReadSign(num229, num230);
																							if (num232 >= 0)
																							{
																								Sign.TextSign(num232, this.miscText);
																							}
																							this.Kill();
																							return;
																						}
																					}
																				}
																			}
																			else
																			{
																				if (this.aiStyle == 18)
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
																						for (int num233 = 0; num233 < 2; num233++)
																						{
																							int num234 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 27, 0f, 0f, 100, default(Color), 1f);
																							Main.dust[num234].noGravity = true;
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
																				else
																				{
																					if (this.aiStyle == 19)
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
																							else
																							{
																								if (this.type == 105)
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
																								else
																								{
																									if (this.type == 222)
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
																									else
																									{
																										if (this.type == 47)
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
																										else
																										{
																											if (this.type == 153)
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
																											else
																											{
																												if (this.type == 49)
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
																												else
																												{
																													if (this.type == 64 || this.type == 215)
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
																													else
																													{
																														if (this.type == 66 || this.type == 97 || this.type == 212 || this.type == 218)
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
																														else
																														{
																															if (this.type == 130)
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
																													}
																												}
																											}
																										}
																									}
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
																							int num235 = Dust.NewDust(this.position, this.width, this.height, 27, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.2f);
																							Main.dust[num235].noGravity = true;
																							Dust expr_A77D_cp_0 = Main.dust[num235];
																							expr_A77D_cp_0.velocity.X = expr_A77D_cp_0.velocity.X / 2f;
																							Dust expr_A79D_cp_0 = Main.dust[num235];
																							expr_A79D_cp_0.velocity.Y = expr_A79D_cp_0.velocity.Y / 2f;
																							num235 = Dust.NewDust(this.position - this.velocity * 2f, this.width, this.height, 27, 0f, 0f, 150, default(Color), 1.4f);
																							Dust expr_A811_cp_0 = Main.dust[num235];
																							expr_A811_cp_0.velocity.X = expr_A811_cp_0.velocity.X / 5f;
																							Dust expr_A831_cp_0 = Main.dust[num235];
																							expr_A831_cp_0.velocity.Y = expr_A831_cp_0.velocity.Y / 5f;
																							return;
																						}
																						if (this.type == 105)
																						{
																							if (Main.rand.Next(3) == 0)
																							{
																								int num236 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 57, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 200, default(Color), 1.2f);
																								Main.dust[num236].velocity += this.velocity * 0.3f;
																								Main.dust[num236].velocity *= 0.2f;
																							}
																							if (Main.rand.Next(4) == 0)
																							{
																								int num237 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 43, 0f, 0f, 254, default(Color), 0.3f);
																								Main.dust[num237].velocity += this.velocity * 0.5f;
																								Main.dust[num237].velocity *= 0.5f;
																								return;
																							}
																						}
																						else
																						{
																							if (this.type == 153)
																							{
																								int num238 = Dust.NewDust(this.position - this.velocity * 3f, this.width, this.height, 115, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 140, default(Color), 1f);
																								Main.dust[num238].noGravity = true;
																								Main.dust[num238].fadeIn = 1.25f;
																								Main.dust[num238].velocity *= 0.25f;
																								return;
																							}
																						}
																					}
																					else
																					{
																						if (this.aiStyle == 20)
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
																									float num239 = Main.player[this.owner].inventory[Main.player[this.owner].selectedItem].shootSpeed * this.scale;
																									Vector2 vector16 = new Vector2(Main.player[this.owner].position.X + (float)Main.player[this.owner].width * 0.5f, Main.player[this.owner].position.Y + (float)Main.player[this.owner].height * 0.5f);
																									float num240 = (float)Main.mouseX + Main.screenPosition.X - vector16.X;
																									float num241 = (float)Main.mouseY + Main.screenPosition.Y - vector16.Y;
																									float num242 = (float)Math.Sqrt((double)(num240 * num240 + num241 * num241));
																									num242 = (float)Math.Sqrt((double)(num240 * num240 + num241 * num241));
																									num242 = num239 / num242;
																									num240 *= num242;
																									num241 *= num242;
																									if (num240 != this.velocity.X || num241 != this.velocity.Y)
																									{
																										this.netUpdate = true;
																									}
																									this.velocity.X = num240;
																									this.velocity.Y = num241;
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
																							else
																							{
																								if (this.velocity.X < 0f)
																								{
																									Main.player[this.owner].ChangeDir(-1);
																								}
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
																								int num243 = Dust.NewDust(this.position + this.velocity * (float)Main.rand.Next(6, 10) * 0.1f, this.width, this.height, 31, 0f, 0f, 80, default(Color), 1.4f);
																								Dust expr_AF53_cp_0 = Main.dust[num243];
																								expr_AF53_cp_0.position.X = expr_AF53_cp_0.position.X - 4f;
																								Main.dust[num243].noGravity = true;
																								Main.dust[num243].velocity *= 0.2f;
																								Main.dust[num243].velocity.Y = (float)(-(float)Main.rand.Next(7, 13)) * 0.15f;
																								return;
																							}
																						}
																						else
																						{
																							if (this.aiStyle == 21)
																							{
																								this.rotation = this.velocity.X * 0.1f;
																								this.spriteDirection = -this.direction;
																								if (Main.rand.Next(3) == 0)
																								{
																									int num244 = Dust.NewDust(this.position, this.width, this.height, 27, 0f, 0f, 80, default(Color), 1f);
																									Main.dust[num244].noGravity = true;
																									Main.dust[num244].velocity *= 0.2f;
																								}
																								if (this.ai[1] == 1f)
																								{
																									this.ai[1] = 0f;
																									Main.harpNote = this.ai[0];
																									Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 26);
																									return;
																								}
																							}
																							else
																							{
																								if (this.aiStyle == 22)
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
																										int num245 = (int)(this.position.X / 16f) - 1;
																										int num246 = (int)((this.position.X + (float)this.width) / 16f) + 2;
																										int num247 = (int)(this.position.Y / 16f) - 1;
																										int num248 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
																										if (num245 < 0)
																										{
																											num245 = 0;
																										}
																										if (num246 > Main.maxTilesX)
																										{
																											num246 = Main.maxTilesX;
																										}
																										if (num247 < 0)
																										{
																											num247 = 0;
																										}
																										if (num248 > Main.maxTilesY)
																										{
																											num248 = Main.maxTilesY;
																										}
																										int num249 = (int)this.position.X + 4;
																										int num250 = (int)this.position.Y + 4;
																										for (int num251 = num245; num251 < num246; num251++)
																										{
																											for (int num252 = num247; num252 < num248; num252++)
																											{
																												if (Main.tile[num251, num252] != null && Main.tile[num251, num252].active() && Main.tile[num251, num252].type != 127 && Main.tileSolid[(int)Main.tile[num251, num252].type] && !Main.tileSolidTop[(int)Main.tile[num251, num252].type])
																												{
																													Vector2 vector17;
																													vector17.X = (float)(num251 * 16);
																													vector17.Y = (float)(num252 * 16);
																													if ((float)(num249 + 8) > vector17.X && (float)num249 < vector17.X + 16f && (float)(num250 + 8) > vector17.Y && (float)num250 < vector17.Y + 16f)
																													{
																														this.Kill();
																													}
																												}
																											}
																										}
																										int num253 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0f, 0f, 0, default(Color), 1f);
																										Main.dust[num253].noGravity = true;
																										Main.dust[num253].velocity *= 0.3f;
																										return;
																									}
																									if (this.ai[0] < 0f)
																									{
																										if (this.ai[0] == -1f)
																										{
																											for (int num254 = 0; num254 < 10; num254++)
																											{
																												int num255 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0f, 0f, 0, default(Color), 1.1f);
																												Main.dust[num255].noGravity = true;
																												Main.dust[num255].velocity *= 1.3f;
																											}
																										}
																										else
																										{
																											if (Main.rand.Next(30) == 0)
																											{
																												int num256 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0f, 0f, 100, default(Color), 1f);
																												Main.dust[num256].velocity *= 0.2f;
																											}
																										}
																										int num257 = (int)this.position.X / 16;
																										int num258 = (int)this.position.Y / 16;
																										if (Main.tile[num257, num258] == null || !Main.tile[num257, num258].active())
																										{
																											this.Kill();
																										}
																										this.ai[0] -= 1f;
																										if (this.ai[0] <= -300f && (Main.myPlayer == this.owner || Main.netMode == 2) && Main.tile[num257, num258].active() && Main.tile[num257, num258].type == 127)
																										{
																											WorldGen.KillTile(num257, num258, false, false, false);
																											if (Main.netMode == 1)
																											{
																												NetMessage.SendData(17, -1, -1, "", 0, (float)num257, (float)num258, 0f, 0);
																											}
																											this.Kill();
																											return;
																										}
																									}
																									else
																									{
																										int num259 = (int)(this.position.X / 16f) - 1;
																										int num260 = (int)((this.position.X + (float)this.width) / 16f) + 2;
																										int num261 = (int)(this.position.Y / 16f) - 1;
																										int num262 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
																										if (num259 < 0)
																										{
																											num259 = 0;
																										}
																										if (num260 > Main.maxTilesX)
																										{
																											num260 = Main.maxTilesX;
																										}
																										if (num261 < 0)
																										{
																											num261 = 0;
																										}
																										if (num262 > Main.maxTilesY)
																										{
																											num262 = Main.maxTilesY;
																										}
																										int num263 = (int)this.position.X + 4;
																										int num264 = (int)this.position.Y + 4;
																										for (int num265 = num259; num265 < num260; num265++)
																										{
																											for (int num266 = num261; num266 < num262; num266++)
																											{
																												if (Main.tile[num265, num266] != null && Main.tile[num265, num266].nactive() && Main.tile[num265, num266].type != 127 && Main.tileSolid[(int)Main.tile[num265, num266].type] && !Main.tileSolidTop[(int)Main.tile[num265, num266].type])
																												{
																													Vector2 vector18;
																													vector18.X = (float)(num265 * 16);
																													vector18.Y = (float)(num266 * 16);
																													if ((float)(num263 + 8) > vector18.X && (float)num263 < vector18.X + 16f && (float)(num264 + 8) > vector18.Y && (float)num264 < vector18.Y + 16f)
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
																											int num267 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0f, 0f, 0, default(Color), 1f);
																											Main.dust[num267].noGravity = true;
																											Main.dust[num267].velocity *= 0.3f;
																											int num268 = (int)this.ai[0];
																											int num269 = (int)this.ai[1];
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
																												int num270 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
																												int num271 = (int)((this.position.Y + (float)(this.height / 2)) / 16f);
																												bool flag5 = false;
																												if (num270 == num268 && num271 == num269)
																												{
																													flag5 = true;
																												}
																												if (((this.velocity.X <= 0f && num270 <= num268) || (this.velocity.X >= 0f && num270 >= num268)) && ((this.velocity.Y <= 0f && num271 <= num269) || (this.velocity.Y >= 0f && num271 >= num269)))
																												{
																													flag5 = true;
																												}
																												if (flag5)
																												{
																													if (WorldGen.PlaceTile(num268, num269, 127, false, false, this.owner, 0))
																													{
																														if (Main.netMode == 1)
																														{
																															NetMessage.SendData(17, -1, -1, "", 1, (float)((int)this.ai[0]), (float)((int)this.ai[1]), 127f, 0);
																														}
																														this.damage = 0;
																														this.ai[0] = -1f;
																														this.velocity *= 0f;
																														this.alpha = 255;
																														this.position.X = (float)(num268 * 16);
																														this.position.Y = (float)(num269 * 16);
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
																											float num272 = 1f;
																											if (this.ai[0] == 8f)
																											{
																												num272 = 0.25f;
																											}
																											else
																											{
																												if (this.ai[0] == 9f)
																												{
																													num272 = 0.5f;
																												}
																												else
																												{
																													if (this.ai[0] == 10f)
																													{
																														num272 = 0.75f;
																													}
																												}
																											}
																											this.ai[0] += 1f;
																											int num273 = 6;
																											if (this.type == 101)
																											{
																												num273 = 75;
																											}
																											if (num273 == 6 || Main.rand.Next(2) == 0)
																											{
																												for (int num274 = 0; num274 < 1; num274++)
																												{
																													int num275 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num273, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 1f);
																													if (Main.rand.Next(3) != 0 || (num273 == 75 && Main.rand.Next(3) == 0))
																													{
																														Main.dust[num275].noGravity = true;
																														Main.dust[num275].scale *= 3f;
																														Dust expr_BCBD_cp_0 = Main.dust[num275];
																														expr_BCBD_cp_0.velocity.X = expr_BCBD_cp_0.velocity.X * 2f;
																														Dust expr_BCDD_cp_0 = Main.dust[num275];
																														expr_BCDD_cp_0.velocity.Y = expr_BCDD_cp_0.velocity.Y * 2f;
																													}
																													if (this.type == 188)
																													{
																														Main.dust[num275].scale *= 1.25f;
																													}
																													else
																													{
																														Main.dust[num275].scale *= 1.5f;
																													}
																													Dust expr_BD42_cp_0 = Main.dust[num275];
																													expr_BD42_cp_0.velocity.X = expr_BD42_cp_0.velocity.X * 1.2f;
																													Dust expr_BD62_cp_0 = Main.dust[num275];
																													expr_BD62_cp_0.velocity.Y = expr_BD62_cp_0.velocity.Y * 1.2f;
																													Main.dust[num275].scale *= num272;
																													if (num273 == 75)
																													{
																														Main.dust[num275].velocity += this.velocity;
																														if (!Main.dust[num275].noGravity)
																														{
																															Main.dust[num275].velocity *= 0.5f;
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
																												int num276 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 70, 0f, 0f, 0, default(Color), 1f);
																												Main.dust[num276].noGravity = true;
																												Main.dust[num276].velocity *= 0.5f;
																												Main.dust[num276].scale *= 0.9f;
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
																												float num277 = 0.5f;
																												int i2 = (int)((this.position.X - 8f) / 16f);
																												int num278 = (int)(this.position.Y / 16f);
																												bool flag6 = false;
																												bool flag7 = false;
																												if (WorldGen.SolidTile(i2, num278) || WorldGen.SolidTile(i2, num278 + 1))
																												{
																													flag6 = true;
																												}
																												i2 = (int)((this.position.X + (float)this.width + 8f) / 16f);
																												if (WorldGen.SolidTile(i2, num278) || WorldGen.SolidTile(i2, num278 + 1))
																												{
																													flag7 = true;
																												}
																												if (flag6)
																												{
																													this.velocity.X = num277;
																												}
																												else
																												{
																													if (flag7)
																													{
																														this.velocity.X = -num277;
																													}
																													else
																													{
																														i2 = (int)((this.position.X - 8f - 16f) / 16f);
																														num278 = (int)(this.position.Y / 16f);
																														flag6 = false;
																														flag7 = false;
																														if (WorldGen.SolidTile(i2, num278) || WorldGen.SolidTile(i2, num278 + 1))
																														{
																															flag6 = true;
																														}
																														i2 = (int)((this.position.X + (float)this.width + 8f + 16f) / 16f);
																														if (WorldGen.SolidTile(i2, num278) || WorldGen.SolidTile(i2, num278 + 1))
																														{
																															flag7 = true;
																														}
																														if (flag6)
																														{
																															this.velocity.X = num277;
																														}
																														else
																														{
																															if (flag7)
																															{
																																this.velocity.X = -num277;
																															}
																															else
																															{
																																i2 = (int)((this.position.X + 4f) / 16f);
																																num278 = (int)((this.position.Y + (float)this.height + 8f) / 16f);
																																if (WorldGen.SolidTile(i2, num278) || WorldGen.SolidTile(i2, num278 + 1))
																																{
																																	flag6 = true;
																																}
																																if (!flag6)
																																{
																																	this.velocity.X = num277;
																																}
																																else
																																{
																																	this.velocity.X = -num277;
																																}
																															}
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
																											int num279 = 85;
																											if (this.type == 112)
																											{
																												num279 = 100;
																											}
																											if (this.type == 127)
																											{
																												num279 = 50;
																											}
																											if (this.type >= 191 && this.type <= 194)
																											{
																												if (this.lavaWet)
																												{
																													this.ai[0] = 1f;
																													this.ai[1] = 0f;
																												}
																												num279 = 60 + 30 * this.minionPos;
																											}
																											else
																											{
																												if (this.type == 266)
																												{
																													num279 = 60 + 30 * this.minionPos;
																												}
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
																												num279 = 10;
																												int num280 = 40 * (this.minionPos + 1) * Main.player[this.owner].direction;
																												if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) < this.position.X + (float)(this.width / 2) - (float)num279 + (float)num280)
																												{
																													flag8 = true;
																												}
																												else
																												{
																													if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) > this.position.X + (float)(this.width / 2) + (float)num279 + (float)num280)
																													{
																														flag9 = true;
																													}
																												}
																											}
																											else
																											{
																												if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) < this.position.X + (float)(this.width / 2) - (float)num279)
																												{
																													flag8 = true;
																												}
																												else
																												{
																													if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) > this.position.X + (float)(this.width / 2) + (float)num279)
																													{
																														flag9 = true;
																													}
																												}
																											}
																											if (this.type == 175)
																											{
																												float num281 = 0.1f;
																												this.tileCollide = false;
																												int num282 = 300;
																												Vector2 vector19 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
																												float num283 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector19.X;
																												float num284 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector19.Y;
																												if (this.type == 127)
																												{
																													num284 = Main.player[this.owner].position.Y - vector19.Y;
																												}
																												float num285 = (float)Math.Sqrt((double)(num283 * num283 + num284 * num284));
																												float num286 = 7f;
																												if (num285 < (float)num282 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
																												{
																													this.ai[0] = 0f;
																													if (this.velocity.Y < -6f)
																													{
																														this.velocity.Y = -6f;
																													}
																												}
																												if (num285 < 150f)
																												{
																													if (Math.Abs(this.velocity.X) > 2f || Math.Abs(this.velocity.Y) > 2f)
																													{
																														this.velocity *= 0.99f;
																													}
																													num281 = 0.01f;
																													if (num283 < -2f)
																													{
																														num283 = -2f;
																													}
																													if (num283 > 2f)
																													{
																														num283 = 2f;
																													}
																													if (num284 < -2f)
																													{
																														num284 = -2f;
																													}
																													if (num284 > 2f)
																													{
																														num284 = 2f;
																													}
																												}
																												else
																												{
																													if (num285 > 300f)
																													{
																														num281 = 0.2f;
																													}
																													num285 = num286 / num285;
																													num283 *= num285;
																													num284 *= num285;
																												}
																												if (Math.Abs(num283) > Math.Abs(num284) || num281 == 0.05f)
																												{
																													if (this.velocity.X < num283)
																													{
																														this.velocity.X = this.velocity.X + num281;
																														if (num281 > 0.05f && this.velocity.X < 0f)
																														{
																															this.velocity.X = this.velocity.X + num281;
																														}
																													}
																													if (this.velocity.X > num283)
																													{
																														this.velocity.X = this.velocity.X - num281;
																														if (num281 > 0.05f && this.velocity.X > 0f)
																														{
																															this.velocity.X = this.velocity.X - num281;
																														}
																													}
																												}
																												if (Math.Abs(num283) <= Math.Abs(num284) || num281 == 0.05f)
																												{
																													if (this.velocity.Y < num284)
																													{
																														this.velocity.Y = this.velocity.Y + num281;
																														if (num281 > 0.05f && this.velocity.Y < 0f)
																														{
																															this.velocity.Y = this.velocity.Y + num281;
																														}
																													}
																													if (this.velocity.Y > num284)
																													{
																														this.velocity.Y = this.velocity.Y - num281;
																														if (num281 > 0.05f && this.velocity.Y > 0f)
																														{
																															this.velocity.Y = this.velocity.Y - num281;
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
																											else
																											{
																												if (this.type == 197)
																												{
																													float num287 = 0.1f;
																													this.tileCollide = false;
																													int num288 = 300;
																													Vector2 vector20 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
																													float num289 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector20.X;
																													float num290 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector20.Y;
																													if (this.type == 127)
																													{
																														num290 = Main.player[this.owner].position.Y - vector20.Y;
																													}
																													float num291 = (float)Math.Sqrt((double)(num289 * num289 + num290 * num290));
																													float num292 = 3f;
																													if (num291 > 500f)
																													{
																														this.localAI[0] = 10000f;
																													}
																													if (this.localAI[0] >= 10000f)
																													{
																														num292 = 14f;
																													}
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
																														float num293 = this.velocity.X * 0.1f;
																														if (this.rotation > num293)
																														{
																															this.rotation -= (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.01f;
																															if (this.rotation < num293)
																															{
																																this.rotation = num293;
																															}
																														}
																														if (this.rotation < num293)
																														{
																															this.rotation += (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.01f;
																															if (this.rotation > num293)
																															{
																																this.rotation = num293;
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
																												else
																												{
																													if (this.type == 198)
																													{
																														float num294 = 0.4f;
																														this.tileCollide = false;
																														int num295 = 100;
																														Vector2 vector21 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
																														float num296 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector21.X;
																														float num297 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector21.Y;
																														num297 += (float)Main.rand.Next(-10, 21);
																														num296 += (float)Main.rand.Next(-10, 21);
																														num296 += (float)(60 * -(float)Main.player[this.owner].direction);
																														num297 -= 60f;
																														if (this.type == 127)
																														{
																															num297 = Main.player[this.owner].position.Y - vector21.Y;
																														}
																														float num298 = (float)Math.Sqrt((double)(num296 * num296 + num297 * num297));
																														float num299 = 14f;
																														if (num298 < (float)num295 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
																														{
																															this.ai[0] = 0f;
																															if (this.velocity.Y < -6f)
																															{
																																this.velocity.Y = -6f;
																															}
																														}
																														if (num298 < 50f)
																														{
																															if (Math.Abs(this.velocity.X) > 2f || Math.Abs(this.velocity.Y) > 2f)
																															{
																																this.velocity *= 0.99f;
																															}
																															num294 = 0.01f;
																														}
																														else
																														{
																															if (num298 < 100f)
																															{
																																num294 = 0.1f;
																															}
																															if (num298 > 300f)
																															{
																																num294 = 0.6f;
																															}
																															num298 = num299 / num298;
																															num296 *= num298;
																															num297 *= num298;
																														}
																														if (this.velocity.X < num296)
																														{
																															this.velocity.X = this.velocity.X + num294;
																															if (num294 > 0.05f && this.velocity.X < 0f)
																															{
																																this.velocity.X = this.velocity.X + num294;
																															}
																														}
																														if (this.velocity.X > num296)
																														{
																															this.velocity.X = this.velocity.X - num294;
																															if (num294 > 0.05f && this.velocity.X > 0f)
																															{
																																this.velocity.X = this.velocity.X - num294;
																															}
																														}
																														if (this.velocity.Y < num297)
																														{
																															this.velocity.Y = this.velocity.Y + num294;
																															if (num294 > 0.05f && this.velocity.Y < 0f)
																															{
																																this.velocity.Y = this.velocity.Y + num294 * 2f;
																															}
																														}
																														if (this.velocity.Y > num297)
																														{
																															this.velocity.Y = this.velocity.Y - num294;
																															if (num294 > 0.05f && this.velocity.Y > 0f)
																															{
																																this.velocity.Y = this.velocity.Y - num294 * 2f;
																															}
																														}
																														if ((double)this.velocity.X > 0.25)
																														{
																															this.direction = -1;
																														}
																														else
																														{
																															if ((double)this.velocity.X < -0.25)
																															{
																																this.direction = 1;
																															}
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
																													else
																													{
																														if (this.type == 211)
																														{
																															this.ignoreWater = false;
																															float num300 = 0.2f;
																															float num301 = 5f;
																															this.tileCollide = false;
																															Vector2 vector22 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
																															float num302 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector22.X;
																															float num303 = Main.player[this.owner].position.Y + Main.player[this.owner].gfxOffY + (float)(Main.player[this.owner].height / 2) - vector22.Y;
																															if (Main.player[this.owner].controlLeft)
																															{
																																num302 -= 120f;
																															}
																															else
																															{
																																if (Main.player[this.owner].controlRight)
																																{
																																	num302 += 120f;
																																}
																															}
																															if (Main.player[this.owner].controlDown)
																															{
																																num303 += 120f;
																															}
																															else
																															{
																																if (Main.player[this.owner].controlUp)
																																{
																																	num303 -= 120f;
																																}
																																num303 -= 60f;
																															}
																															float num304 = (float)Math.Sqrt((double)(num302 * num302 + num303 * num303));
																															if (num304 > 1000f)
																															{
																																this.position.X = this.position.X + num302;
																																this.position.Y = this.position.Y + num303;
																															}
																															if (this.localAI[0] == 1f)
																															{
																																if (num304 < 10f && Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y) < num301 && Main.player[this.owner].velocity.Y == 0f)
																																{
																																	this.localAI[0] = 0f;
																																}
																																num301 = 12f;
																																if (num304 < num301)
																																{
																																	this.velocity.X = num302;
																																	this.velocity.Y = num303;
																																}
																																else
																																{
																																	num304 = num301 / num304;
																																	this.velocity.X = num302 * num304;
																																	this.velocity.Y = num303 * num304;
																																}
																																if ((double)this.velocity.X > 0.5)
																																{
																																	this.direction = -1;
																																}
																																else
																																{
																																	if ((double)this.velocity.X < -0.5)
																																	{
																																		this.direction = 1;
																																	}
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
																																for (int num305 = 0; num305 < 2; num305++)
																																{
																																	int num306 = Dust.NewDust(new Vector2(this.position.X + 3f, this.position.Y + 4f), 14, 14, 156, 0f, 0f, 0, default(Color), 1f);
																																	Main.dust[num306].velocity *= 0.2f;
																																	Main.dust[num306].noGravity = true;
																																	Main.dust[num306].scale = 1.25f;
																																}
																																return;
																															}
																															if (num304 > 200f)
																															{
																																this.localAI[0] = 1f;
																															}
																															if ((double)this.velocity.X > 0.5)
																															{
																																this.direction = -1;
																															}
																															else
																															{
																																if ((double)this.velocity.X < -0.5)
																																{
																																	this.direction = 1;
																																}
																															}
																															this.spriteDirection = this.direction;
																															if (num304 < 10f)
																															{
																																this.velocity.X = num302;
																																this.velocity.Y = num303;
																																this.rotation = this.velocity.X * 0.05f;
																																if (num304 < num301)
																																{
																																	this.position += this.velocity;
																																	this.velocity *= 0f;
																																	num300 = 0f;
																																}
																																this.direction = -Main.player[this.owner].direction;
																															}
																															num304 = num301 / num304;
																															num302 *= num304;
																															num303 *= num304;
																															if (this.velocity.X < num302)
																															{
																																this.velocity.X = this.velocity.X + num300;
																																if (this.velocity.X < 0f)
																																{
																																	this.velocity.X = this.velocity.X * 0.99f;
																																}
																															}
																															if (this.velocity.X > num302)
																															{
																																this.velocity.X = this.velocity.X - num300;
																																if (this.velocity.X > 0f)
																																{
																																	this.velocity.X = this.velocity.X * 0.99f;
																																}
																															}
																															if (this.velocity.Y < num303)
																															{
																																this.velocity.Y = this.velocity.Y + num300;
																																if (this.velocity.Y < 0f)
																																{
																																	this.velocity.Y = this.velocity.Y * 0.99f;
																																}
																															}
																															if (this.velocity.Y > num303)
																															{
																																this.velocity.Y = this.velocity.Y - num300;
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
																														else
																														{
																															if (this.type == 199)
																															{
																																float num307 = 0.1f;
																																this.tileCollide = false;
																																int num308 = 200;
																																Vector2 vector23 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
																																float num309 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector23.X;
																																float num310 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector23.Y;
																																num310 -= 60f;
																																num309 -= 2f;
																																if (this.type == 127)
																																{
																																	num310 = Main.player[this.owner].position.Y - vector23.Y;
																																}
																																float num311 = (float)Math.Sqrt((double)(num309 * num309 + num310 * num310));
																																float num312 = 4f;
																																float num313 = num311;
																																if (num311 < (float)num308 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
																																{
																																	this.ai[0] = 0f;
																																	if (this.velocity.Y < -6f)
																																	{
																																		this.velocity.Y = -6f;
																																	}
																																}
																																if (num311 < 4f)
																																{
																																	this.velocity.X = num309;
																																	this.velocity.Y = num310;
																																	num307 = 0f;
																																}
																																else
																																{
																																	if (num311 > 350f)
																																	{
																																		num307 = 0.2f;
																																		num312 = 10f;
																																	}
																																	num311 = num312 / num311;
																																	num309 *= num311;
																																	num310 *= num311;
																																}
																																if (this.velocity.X < num309)
																																{
																																	this.velocity.X = this.velocity.X + num307;
																																	if (this.velocity.X < 0f)
																																	{
																																		this.velocity.X = this.velocity.X + num307;
																																	}
																																}
																																if (this.velocity.X > num309)
																																{
																																	this.velocity.X = this.velocity.X - num307;
																																	if (this.velocity.X > 0f)
																																	{
																																		this.velocity.X = this.velocity.X - num307;
																																	}
																																}
																																if (this.velocity.Y < num310)
																																{
																																	this.velocity.Y = this.velocity.Y + num307;
																																	if (this.velocity.Y < 0f)
																																	{
																																		this.velocity.Y = this.velocity.Y + num307;
																																	}
																																}
																																if (this.velocity.Y > num310)
																																{
																																	this.velocity.Y = this.velocity.Y - num307;
																																	if (this.velocity.Y > 0f)
																																	{
																																		this.velocity.Y = this.velocity.Y - num307;
																																	}
																																}
																																this.direction = -Main.player[this.owner].direction;
																																this.spriteDirection = 1;
																																this.rotation = this.velocity.Y * 0.05f * (float)(-(float)this.direction);
																																if (num313 >= 50f)
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
																																	int num314 = 500;
																																	if (this.type == 127)
																																	{
																																		num314 = 200;
																																	}
																																	if (this.type == 208)
																																	{
																																		num314 = 300;
																																	}
																																	if ((this.type >= 191 && this.type <= 194) || this.type == 266)
																																	{
																																		num314 += 40 * this.minionPos;
																																		if (this.localAI[0] > 0f)
																																		{
																																			num314 += 500;
																																		}
																																		if (this.type == 266 && this.localAI[0] > 0f)
																																		{
																																			num314 += 100;
																																		}
																																	}
																																	if (Main.player[this.owner].rocketDelay2 > 0)
																																	{
																																		this.ai[0] = 1f;
																																	}
																																	Vector2 vector24 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
																																	float num315 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector24.X;
																																	if (this.type >= 191)
																																	{
																																		int arg_E883_0 = this.type;
																																	}
																																	float num316 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector24.Y;
																																	float num317 = (float)Math.Sqrt((double)(num315 * num315 + num316 * num316));
																																	if (num317 > 2000f)
																																	{
																																		this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
																																		this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
																																	}
																																	else
																																	{
																																		if (num317 > (float)num314 || (Math.Abs(num316) > 300f && (((this.type < 191 || this.type > 194) && this.type != 266) || this.localAI[0] <= 0f)))
																																		{
																																			this.ai[0] = 1f;
																																			if (num316 > 0f && this.velocity.Y < 0f)
																																			{
																																				this.velocity.Y = 0f;
																																			}
																																			if (num316 < 0f && this.velocity.Y > 0f)
																																			{
																																				this.velocity.Y = 0f;
																																			}
																																		}
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
																																else
																																{
																																	if (this.ai[0] != 0f)
																																	{
																																		float num318 = 0.2f;
																																		int num319 = 200;
																																		if (this.type == 127)
																																		{
																																			num319 = 100;
																																		}
																																		if (this.type >= 191 && this.type <= 194)
																																		{
																																			num318 = 0.5f;
																																			num319 = 100;
																																		}
																																		this.tileCollide = false;
																																		Vector2 vector25 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
																																		float num320 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector25.X;
																																		if ((this.type >= 191 && this.type <= 194) || this.type == 266)
																																		{
																																			num320 -= (float)(40 * Main.player[this.owner].direction);
																																			float num321 = 600f;
																																			bool flag12 = false;
																																			for (int num322 = 0; num322 < 200; num322++)
																																			{
																																				if (Main.npc[num322].active && !Main.npc[num322].dontTakeDamage && !Main.npc[num322].friendly && Main.npc[num322].lifeMax > 5)
																																				{
																																					float num323 = Main.npc[num322].position.X + (float)(Main.npc[num322].width / 2);
																																					float num324 = Main.npc[num322].position.Y + (float)(Main.npc[num322].height / 2);
																																					float num325 = Math.Abs(Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - num323) + Math.Abs(Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - num324);
																																					if (num325 < num321)
																																					{
																																						flag12 = true;
																																						break;
																																					}
																																				}
																																			}
																																			if (!flag12)
																																			{
																																				num320 -= (float)(40 * this.minionPos * Main.player[this.owner].direction);
																																			}
																																		}
																																		float num326 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector25.Y;
																																		if (this.type == 127)
																																		{
																																			num326 = Main.player[this.owner].position.Y - vector25.Y;
																																		}
																																		float num327 = (float)Math.Sqrt((double)(num320 * num320 + num326 * num326));
																																		float num328 = 10f;
																																		if (this.type == 111)
																																		{
																																			num328 = 11f;
																																		}
																																		if (this.type == 127)
																																		{
																																			num328 = 9f;
																																		}
																																		if (this.type >= 191 && this.type <= 194)
																																		{
																																			num318 = 0.4f;
																																			num328 = 12f;
																																			if (num328 < Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y))
																																			{
																																				num328 = Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y);
																																			}
																																		}
																																		if (this.type == 208 && Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y) > 4f)
																																		{
																																			num319 = -1;
																																		}
																																		if (num327 < (float)num319 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
																																		{
																																			this.ai[0] = 0f;
																																			if (this.velocity.Y < -6f)
																																			{
																																				this.velocity.Y = -6f;
																																			}
																																		}
																																		if (num327 < 60f)
																																		{
																																			num320 = this.velocity.X;
																																			num326 = this.velocity.Y;
																																		}
																																		else
																																		{
																																			num327 = num328 / num327;
																																			num320 *= num327;
																																			num326 *= num327;
																																		}
																																		if (this.velocity.X < num320)
																																		{
																																			this.velocity.X = this.velocity.X + num318;
																																			if (this.velocity.X < 0f)
																																			{
																																				this.velocity.X = this.velocity.X + num318 * 1.5f;
																																			}
																																		}
																																		if (this.velocity.X > num320)
																																		{
																																			this.velocity.X = this.velocity.X - num318;
																																			if (this.velocity.X > 0f)
																																			{
																																				this.velocity.X = this.velocity.X - num318 * 1.5f;
																																			}
																																		}
																																		if (this.velocity.Y < num326)
																																		{
																																			this.velocity.Y = this.velocity.Y + num318;
																																			if (this.velocity.Y < 0f)
																																			{
																																				this.velocity.Y = this.velocity.Y + num318 * 1.5f;
																																			}
																																		}
																																		if (this.velocity.Y > num326)
																																		{
																																			this.velocity.Y = this.velocity.Y - num318;
																																			if (this.velocity.Y > 0f)
																																			{
																																				this.velocity.Y = this.velocity.Y - num318 * 1.5f;
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
																																		if ((double)this.velocity.X > 0.5)
																																		{
																																			this.spriteDirection = -1;
																																		}
																																		else
																																		{
																																			if ((double)this.velocity.X < -0.5)
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
																																		else
																																		{
																																			if (this.type == 127)
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
																																			else
																																			{
																																				if (this.type == 269)
																																				{
																																					if (this.frame == 6)
																																					{
																																						this.frameCounter = 0;
																																					}
																																					else
																																					{
																																						if (this.frame < 4 || this.frame > 6)
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
																																					}
																																					this.rotation = this.velocity.X * 0.05f;
																																				}
																																				else
																																				{
																																					if (this.type == 266)
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
																																					else
																																					{
																																						if (this.type == 268)
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
																																						else
																																						{
																																							if (this.type == 200)
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
																																							else
																																							{
																																								if (this.type == 208)
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
																																								else
																																								{
																																									if (this.type == 236)
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
																																									else
																																									{
																																										if (this.type == 210)
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
																																										else
																																										{
																																											if (this.spriteDirection == -1)
																																											{
																																												this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X);
																																											}
																																											else
																																											{
																																												this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 3.14f;
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
																																		if (this.type >= 191 && this.type <= 194)
																																		{
																																			return;
																																		}
																																		if (this.type != 127 && this.type != 200 && this.type != 208 && this.type != 210 && this.type != 236 && this.type != 266 && this.type != 268 && this.type != 269)
																																		{
																																			int num329 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) - 4f, this.position.Y + (float)(this.height / 2) - 4f) - this.velocity, 8, 8, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.7f);
																																			Main.dust[num329].velocity.X = Main.dust[num329].velocity.X * 0.2f;
																																			Main.dust[num329].velocity.Y = Main.dust[num329].velocity.Y * 0.2f;
																																			Main.dust[num329].noGravity = true;
																																			return;
																																		}
																																	}
																																	else
																																	{
																																		if (this.type >= 191 && this.type <= 194)
																																		{
																																			float num330 = (float)(40 * this.minionPos);
																																			int num331 = 30;
																																			int num332 = 60;
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
																																				float num333 = this.position.X;
																																				float num334 = this.position.Y;
																																				float num335 = 100000f;
																																				float num336 = num335;
																																				int num337 = -1;
																																				for (int num338 = 0; num338 < 200; num338++)
																																				{
																																					if (Main.npc[num338].active && !Main.npc[num338].dontTakeDamage && !Main.npc[num338].friendly && Main.npc[num338].lifeMax > 5)
																																					{
																																						float num339 = Main.npc[num338].position.X + (float)(Main.npc[num338].width / 2);
																																						float num340 = Main.npc[num338].position.Y + (float)(Main.npc[num338].height / 2);
																																						float num341 = Math.Abs(this.position.X + (float)(this.width / 2) - num339) + Math.Abs(this.position.Y + (float)(this.height / 2) - num340);
																																						if (num341 < num335)
																																						{
																																							if (num337 == -1 && num341 <= num336)
																																							{
																																								num336 = num341;
																																								num333 = num339;
																																								num334 = num340;
																																							}
																																							if (Collision.CanHit(this.position, this.width, this.height, Main.npc[num338].position, Main.npc[num338].width, Main.npc[num338].height))
																																							{
																																								num335 = num341;
																																								num333 = num339;
																																								num334 = num340;
																																								num337 = num338;
																																							}
																																						}
																																					}
																																				}
																																				if (num337 == -1 && num336 < num335)
																																				{
																																					num335 = num336;
																																				}
																																				float num342 = 400f;
																																				if ((double)this.position.Y > Main.worldSurface * 16.0)
																																				{
																																					num342 = 200f;
																																				}
																																				if (num335 < num342 + num330 && num337 == -1)
																																				{
																																					float num343 = num333 - (this.position.X + (float)(this.width / 2));
																																					if (num343 < -5f)
																																					{
																																						flag8 = true;
																																						flag9 = false;
																																					}
																																					else
																																					{
																																						if (num343 > 5f)
																																						{
																																							flag9 = true;
																																							flag8 = false;
																																						}
																																					}
																																				}
																																				else
																																				{
																																					if (num337 >= 0 && num335 < 800f + num330)
																																					{
																																						this.localAI[0] = (float)num332;
																																						float num344 = num333 - (this.position.X + (float)(this.width / 2));
																																						if (num344 > 300f || num344 < -300f)
																																						{
																																							if (num344 < -50f)
																																							{
																																								flag8 = true;
																																								flag9 = false;
																																							}
																																							else
																																							{
																																								if (num344 > 50f)
																																								{
																																									flag9 = true;
																																									flag8 = false;
																																								}
																																							}
																																						}
																																						else
																																						{
																																							if (this.owner == Main.myPlayer)
																																							{
																																								this.ai[1] = (float)num331;
																																								float num345 = 12f;
																																								Vector2 vector26 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)(this.height / 2) - 8f);
																																								float num346 = num333 - vector26.X + (float)Main.rand.Next(-20, 21);
																																								float num347 = Math.Abs(num346) * 0.1f;
																																								num347 = num347 * (float)Main.rand.Next(0, 100) * 0.001f;
																																								float num348 = num334 - vector26.Y + (float)Main.rand.Next(-20, 21) - num347;
																																								float num349 = (float)Math.Sqrt((double)(num346 * num346 + num348 * num348));
																																								num349 = num345 / num349;
																																								num346 *= num349;
																																								num348 *= num349;
																																								int num350 = this.damage;
																																								int num351 = 195;
																																								int num352 = Projectile.NewProjectile(vector26.X, vector26.Y, num346, num348, num351, num350, this.knockBack, Main.myPlayer, 0f, 0f);
																																								Main.projectile[num352].timeLeft = 300;
																																								if (num346 < 0f)
																																								{
																																									this.direction = -1;
																																								}
																																								if (num346 > 0f)
																																								{
																																									this.direction = 1;
																																								}
																																								this.netUpdate = true;
																																							}
																																						}
																																					}
																																				}
																																			}
																																		}
																																		if (this.type == 266)
																																		{
																																			float num353 = (float)(40 * this.minionPos);
																																			int num354 = 60;
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
																																				float num355 = this.position.X;
																																				float num356 = this.position.Y;
																																				float num357 = 100000f;
																																				float num358 = num357;
																																				int num359 = -1;
																																				for (int num360 = 0; num360 < 200; num360++)
																																				{
																																					if (Main.npc[num360].active && !Main.npc[num360].dontTakeDamage && !Main.npc[num360].friendly && Main.npc[num360].lifeMax > 5)
																																					{
																																						float num361 = Main.npc[num360].position.X + (float)(Main.npc[num360].width / 2);
																																						float num362 = Main.npc[num360].position.Y + (float)(Main.npc[num360].height / 2);
																																						float num363 = Math.Abs(this.position.X + (float)(this.width / 2) - num361) + Math.Abs(this.position.Y + (float)(this.height / 2) - num362);
																																						if (num363 < num357)
																																						{
																																							if (num359 == -1 && num363 <= num358)
																																							{
																																								num358 = num363;
																																								num355 = num361;
																																								num356 = num362;
																																							}
																																							if (Collision.CanHit(this.position, this.width, this.height, Main.npc[num360].position, Main.npc[num360].width, Main.npc[num360].height))
																																							{
																																								num357 = num363;
																																								num355 = num361;
																																								num356 = num362;
																																								num359 = num360;
																																							}
																																						}
																																					}
																																				}
																																				if (num359 == -1 && num358 < num357)
																																				{
																																					num357 = num358;
																																				}
																																				float num364 = 300f;
																																				if ((double)this.position.Y > Main.worldSurface * 16.0)
																																				{
																																					num364 = 150f;
																																				}
																																				if (num357 < num364 + num353 && num359 == -1)
																																				{
																																					float num365 = num355 - (this.position.X + (float)(this.width / 2));
																																					if (num365 < -5f)
																																					{
																																						flag8 = true;
																																						flag9 = false;
																																					}
																																					else
																																					{
																																						if (num365 > 5f)
																																						{
																																							flag9 = true;
																																							flag8 = false;
																																						}
																																					}
																																				}
																																				if (num359 >= 0 && num357 < 800f + num353)
																																				{
																																					this.friendly = true;
																																					this.localAI[0] = (float)num354;
																																					float num366 = num355 - (this.position.X + (float)(this.width / 2));
																																					if (num366 < -10f)
																																					{
																																						flag8 = true;
																																						flag9 = false;
																																					}
																																					else
																																					{
																																						if (num366 > 10f)
																																						{
																																							flag9 = true;
																																							flag8 = false;
																																						}
																																					}
																																					if (num356 < this.center().Y - 100f && num366 > -50f && num366 < 50f && this.velocity.Y == 0f)
																																					{
																																						float num367 = Math.Abs(num356 - this.center().Y);
																																						if (num367 < 120f)
																																						{
																																							this.velocity.Y = -10f;
																																						}
																																						else
																																						{
																																							if (num367 < 210f)
																																							{
																																								this.velocity.Y = -13f;
																																							}
																																							else
																																							{
																																								if (num367 < 270f)
																																								{
																																									this.velocity.Y = -15f;
																																								}
																																								else
																																								{
																																									if (num367 < 310f)
																																									{
																																										this.velocity.Y = -17f;
																																									}
																																									else
																																									{
																																										if (num367 < 380f)
																																										{
																																											this.velocity.Y = -18f;
																																										}
																																									}
																																								}
																																							}
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
																																		else
																																		{
																																			if (this.type >= 191 && this.type <= 195 && this.localAI[0] == 0f)
																																			{
																																				this.direction = Main.player[this.owner].direction;
																																			}
																																		}
																																		if (this.type == 127)
																																		{
																																			if ((double)this.rotation > -0.1 && (double)this.rotation < 0.1)
																																			{
																																				this.rotation = 0f;
																																			}
																																			else
																																			{
																																				if (this.rotation < 0f)
																																				{
																																					this.rotation += 0.1f;
																																				}
																																				else
																																				{
																																					this.rotation -= 0.1f;
																																				}
																																			}
																																		}
																																		else
																																		{
																																			this.rotation = 0f;
																																		}
																																		this.tileCollide = true;
																																		float num368 = 0.08f;
																																		float num369 = 6.5f;
																																		if (this.type == 127)
																																		{
																																			num369 = 2f;
																																			num368 = 0.04f;
																																		}
																																		if (this.type == 112)
																																		{
																																			num369 = 6f;
																																			num368 = 0.06f;
																																		}
																																		if (this.type == 268)
																																		{
																																			num369 = 8f;
																																			num368 = 0.4f;
																																		}
																																		if ((this.type >= 191 && this.type <= 194) || this.type == 266)
																																		{
																																			num369 = 6f;
																																			num368 = 0.2f;
																																			if (num369 < Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y))
																																			{
																																				num369 = Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y);
																																				num368 = 0.3f;
																																			}
																																		}
																																		if (flag8)
																																		{
																																			if ((double)this.velocity.X > -3.5)
																																			{
																																				this.velocity.X = this.velocity.X - num368;
																																			}
																																			else
																																			{
																																				this.velocity.X = this.velocity.X - num368 * 0.25f;
																																			}
																																		}
																																		else
																																		{
																																			if (flag9)
																																			{
																																				if ((double)this.velocity.X < 3.5)
																																				{
																																					this.velocity.X = this.velocity.X + num368;
																																				}
																																				else
																																				{
																																					this.velocity.X = this.velocity.X + num368 * 0.25f;
																																				}
																																			}
																																			else
																																			{
																																				this.velocity.X = this.velocity.X * 0.9f;
																																				if (this.velocity.X >= -num368 && this.velocity.X <= num368)
																																				{
																																					this.velocity.X = 0f;
																																				}
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
																																			int num370 = (int)(this.position.X + (float)(this.width / 2)) / 16;
																																			int j2 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
																																			if (this.type == 236)
																																			{
																																				num370 += this.direction;
																																			}
																																			if (flag8)
																																			{
																																				num370--;
																																			}
																																			if (flag9)
																																			{
																																				num370++;
																																			}
																																			num370 += (int)this.velocity.X;
																																			if (WorldGen.SolidTile(num370, j2))
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
																																			int num371 = 0;
																																			if (this.velocity.X < 0f)
																																			{
																																				num371 = -1;
																																			}
																																			if (this.velocity.X > 0f)
																																			{
																																				num371 = 1;
																																			}
																																			Vector2 vector27 = this.position;
																																			vector27.X += this.velocity.X;
																																			int num372 = (int)((vector27.X + (float)(this.width / 2) + (float)((this.width / 2 + 1) * num371)) / 16f);
																																			int num373 = (int)((vector27.Y + (float)this.height - 1f) / 16f);
																																			bool flag13 = false;
																																			if (Main.tile[num372, num373] == null)
																																			{
																																				Main.tile[num372, num373] = new Tile();
																																			}
																																			if (num373 - 1 > 0 && Main.tile[num372, num373 - 1] == null)
																																			{
																																				Main.tile[num372, num373 - 1] = new Tile();
																																			}
																																			if (num373 - 2 > 0 && Main.tile[num372, num373 - 2] == null)
																																			{
																																				Main.tile[num372, num373 - 2] = new Tile();
																																			}
																																			if (num373 - 3 > 0 && Main.tile[num372, num373 - 3] == null)
																																			{
																																				Main.tile[num372, num373 - 3] = new Tile();
																																			}
																																			if (num373 - 4 > 0 && Main.tile[num372, num373 - 4] == null)
																																			{
																																				Main.tile[num372, num373 - 4] = new Tile();
																																			}
																																			if (num373 - 3 > 0 && Main.tile[num372 - num371, num373 - 3] == null)
																																			{
																																				Main.tile[num372 - num371, num373 - 3] = new Tile();
																																			}
																																			if ((float)(num372 * 16) < vector27.X + (float)this.width && (float)(num372 * 16 + 16) > vector27.X && ((Main.tile[num372, num373].nactive() && (Main.tile[num372, num373].slope() == 0 || (Main.tile[num372, num373].slope() == 1 && this.position.X + (float)(this.width / 2) < (float)(num372 * 16)) || (Main.tile[num372, num373].slope() == 2 && this.position.X + (float)(this.width / 2) > (float)(num372 * 16 + 16))) && (Main.tile[num372, num373 - 1].slope() == 0 || this.position.Y + (float)this.height > (float)(num373 * 16)) && ((Main.tileSolid[(int)Main.tile[num372, num373].type] && !Main.tileSolidTop[(int)Main.tile[num372, num373].type]) || (flag13 && Main.tileSolidTop[(int)Main.tile[num372, num373].type] && Main.tile[num372, num373].frameY == 0 && (!Main.tileSolid[(int)Main.tile[num372, num373 - 1].type] || !Main.tile[num372, num373 - 1].nactive())))) || (Main.tile[num372, num373 - 1].halfBrick() && Main.tile[num372, num373 - 1].nactive())) && (!Main.tile[num372, num373 - 1].nactive() || !Main.tileSolid[(int)Main.tile[num372, num373 - 1].type] || Main.tileSolidTop[(int)Main.tile[num372, num373 - 1].type] || Main.tile[num372, num373 - 1].slope() != 0 || (Main.tile[num372, num373 - 1].halfBrick() && (!Main.tile[num372, num373 - 4].nactive() || !Main.tileSolid[(int)Main.tile[num372, num373 - 4].type] || Main.tileSolidTop[(int)Main.tile[num372, num373 - 4].type]))) && (!Main.tile[num372, num373 - 2].nactive() || !Main.tileSolid[(int)Main.tile[num372, num373 - 2].type] || Main.tileSolidTop[(int)Main.tile[num372, num373 - 2].type]) && (!Main.tile[num372, num373 - 3].nactive() || !Main.tileSolid[(int)Main.tile[num372, num373 - 3].type] || Main.tileSolidTop[(int)Main.tile[num372, num373 - 3].type]) && (!Main.tile[num372 - num371, num373 - 3].nactive() || !Main.tileSolid[(int)Main.tile[num372 - num371, num373 - 3].type] || Main.tileSolidTop[(int)Main.tile[num372 - num371, num373 - 3].type]))
																																			{
																																				float num374 = (float)(num373 * 16);
																																				if (Main.tile[num372, num373].halfBrick())
																																				{
																																					num374 += 8f;
																																				}
																																				if (Main.tile[num372, num373 - 1].halfBrick())
																																				{
																																					num374 -= 8f;
																																				}
																																				if (num374 < vector27.Y + (float)this.height)
																																				{
																																					float num375 = vector27.Y + (float)this.height - num374;
																																					if ((double)num375 <= 16.1)
																																					{
																																						this.gfxOffY += this.position.Y + (float)this.height - num374;
																																						this.position.Y = num374 - (float)this.height;
																																						if (num375 < 9f)
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
																																				int num376 = (int)(this.position.X + (float)(this.width / 2)) / 16;
																																				int j3 = (int)(this.position.Y + (float)(this.height / 2)) / 16 + 1;
																																				if (flag8)
																																				{
																																					num376--;
																																				}
																																				if (flag9)
																																				{
																																					num376++;
																																				}
																																				WorldGen.SolidTile(num376, j3);
																																			}
																																			if (flag11)
																																			{
																																				int num377 = (int)(this.position.X + (float)(this.width / 2)) / 16;
																																				int num378 = (int)(this.position.Y + (float)this.height) / 16 + 1;
																																				if (WorldGen.SolidTile(num377, num378) || Main.tile[num377, num378].halfBrick() || Main.tile[num377, num378].slope() > 0 || this.type == 200)
																																				{
																																					if (this.type == 200)
																																					{
																																						this.velocity.Y = -3.1f;
																																					}
																																					else
																																					{
																																						try
																																						{
																																							num377 = (int)(this.position.X + (float)(this.width / 2)) / 16;
																																							num378 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
																																							if (flag8)
																																							{
																																								num377--;
																																							}
																																							if (flag9)
																																							{
																																								num377++;
																																							}
																																							num377 += (int)this.velocity.X;
																																							if (!WorldGen.SolidTile(num377, num378 - 1) && !WorldGen.SolidTile(num377, num378 - 2))
																																							{
																																								this.velocity.Y = -5.1f;
																																							}
																																							else
																																							{
																																								if (!WorldGen.SolidTile(num377, num378 - 2))
																																								{
																																									this.velocity.Y = -7.1f;
																																								}
																																								else
																																								{
																																									if (WorldGen.SolidTile(num377, num378 - 5))
																																									{
																																										this.velocity.Y = -11.1f;
																																									}
																																									else
																																									{
																																										if (WorldGen.SolidTile(num377, num378 - 4))
																																										{
																																											this.velocity.Y = -10.1f;
																																										}
																																										else
																																										{
																																											this.velocity.Y = -9.1f;
																																										}
																																									}
																																								}
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
																																			else
																																			{
																																				if (this.type == 266 && (flag8 || flag9))
																																				{
																																					this.velocity.Y = this.velocity.Y - 6f;
																																				}
																																			}
																																		}
																																		if (this.velocity.X > num369)
																																		{
																																			this.velocity.X = num369;
																																		}
																																		if (this.velocity.X < -num369)
																																		{
																																			this.velocity.X = -num369;
																																		}
																																		if (this.velocity.X < 0f)
																																		{
																																			this.direction = -1;
																																		}
																																		if (this.velocity.X > 0f)
																																		{
																																			this.direction = 1;
																																		}
																																		if (this.velocity.X > num368 && flag9)
																																		{
																																			this.direction = 1;
																																		}
																																		if (this.velocity.X < -num368 && flag8)
																																		{
																																			this.direction = -1;
																																		}
																																		if (this.direction == -1)
																																		{
																																			this.spriteDirection = 1;
																																		}
																																		if (this.direction == 1)
																																		{
																																			this.spriteDirection = -1;
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
																																			else
																																			{
																																				if (this.velocity.Y == 0f)
																																				{
																																					this.localAI[1] = 0f;
																																					if (this.velocity.X == 0f)
																																					{
																																						this.frame = 0;
																																						this.frameCounter = 0;
																																					}
																																					else
																																					{
																																						if ((double)this.velocity.X < -0.8 || (double)this.velocity.X > 0.8)
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
																																				}
																																				else
																																				{
																																					if (this.velocity.Y < 0f)
																																					{
																																						this.frameCounter = 0;
																																						this.frame = 4;
																																					}
																																					else
																																					{
																																						if (this.velocity.Y > 0f)
																																						{
																																							this.frameCounter = 0;
																																							this.frame = 4;
																																						}
																																					}
																																				}
																																			}
																																			this.velocity.Y = this.velocity.Y + 0.4f;
																																			if (this.velocity.Y > 10f)
																																			{
																																				this.velocity.Y = 10f;
																																				return;
																																			}
																																		}
																																		else
																																		{
																																			if (this.type == 268)
																																			{
																																				if (this.velocity.Y == 0f)
																																				{
																																					if (this.frame > 5)
																																					{
																																						this.frameCounter = 0;
																																					}
																																					if (this.velocity.X == 0f)
																																					{
																																						int num379 = 3;
																																						this.frameCounter++;
																																						if (this.frameCounter < num379)
																																						{
																																							this.frame = 0;
																																						}
																																						else
																																						{
																																							if (this.frameCounter < num379 * 2)
																																							{
																																								this.frame = 1;
																																							}
																																							else
																																							{
																																								if (this.frameCounter < num379 * 3)
																																								{
																																									this.frame = 2;
																																								}
																																								else
																																								{
																																									if (this.frameCounter < num379 * 4)
																																									{
																																										this.frame = 3;
																																									}
																																									else
																																									{
																																										this.frameCounter = num379 * 4;
																																									}
																																								}
																																							}
																																						}
																																					}
																																					else
																																					{
																																						this.velocity.X = this.velocity.X * 0.8f;
																																						this.frameCounter++;
																																						int num380 = 3;
																																						if (this.frameCounter < num380)
																																						{
																																							this.frame = 0;
																																						}
																																						else
																																						{
																																							if (this.frameCounter < num380 * 2)
																																							{
																																								this.frame = 1;
																																							}
																																							else
																																							{
																																								if (this.frameCounter < num380 * 3)
																																								{
																																									this.frame = 2;
																																								}
																																								else
																																								{
																																									if (this.frameCounter < num380 * 4)
																																									{
																																										this.frame = 3;
																																									}
																																									else
																																									{
																																										if (flag8 || flag9)
																																										{
																																											this.velocity.X = this.velocity.X * 2f;
																																											this.frame = 4;
																																											this.velocity.Y = -6.1f;
																																											this.frameCounter = 0;
																																											for (int num381 = 0; num381 < 4; num381++)
																																											{
																																												int num382 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), this.width, 4, 5, 0f, 0f, 0, default(Color), 1f);
																																												Main.dust[num382].velocity += this.velocity;
																																												Main.dust[num382].velocity *= 0.4f;
																																											}
																																										}
																																										else
																																										{
																																											this.frameCounter = num380 * 4;
																																										}
																																									}
																																								}
																																							}
																																						}
																																					}
																																				}
																																				else
																																				{
																																					if (this.velocity.Y < 0f)
																																					{
																																						this.frameCounter = 0;
																																						this.frame = 5;
																																					}
																																					else
																																					{
																																						this.frame = 4;
																																						this.frameCounter = 3;
																																					}
																																				}
																																				this.velocity.Y = this.velocity.Y + 0.4f;
																																				if (this.velocity.Y > 10f)
																																				{
																																					this.velocity.Y = 10f;
																																					return;
																																				}
																																			}
																																			else
																																			{
																																				if (this.type == 269)
																																				{
																																					if (this.velocity.Y >= 0f && (double)this.velocity.Y <= 0.8)
																																					{
																																						if (this.velocity.X == 0f)
																																						{
																																							this.frame = 0;
																																							this.frameCounter = 0;
																																						}
																																						else
																																						{
																																							if ((double)this.velocity.X < -0.8 || (double)this.velocity.X > 0.8)
																																							{
																																								int num383 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), this.width, 6, 76, 0f, 0f, 0, default(Color), 1f);
																																								Main.dust[num383].noGravity = true;
																																								Main.dust[num383].velocity *= 0.3f;
																																								Main.dust[num383].noLight = true;
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
																																				else
																																				{
																																					if (this.type == 236)
																																					{
																																						if (this.velocity.Y >= 0f && (double)this.velocity.Y <= 0.8)
																																						{
																																							if (this.velocity.X == 0f)
																																							{
																																								this.frame = 0;
																																								this.frameCounter = 0;
																																							}
																																							else
																																							{
																																								if ((double)this.velocity.X < -0.8 || (double)this.velocity.X > 0.8)
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
																																					else
																																					{
																																						if (this.type == 266)
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
																																						else
																																						{
																																							if (this.type == 111)
																																							{
																																								if (this.velocity.Y == 0f)
																																								{
																																									if (this.velocity.X == 0f)
																																									{
																																										this.frame = 0;
																																										this.frameCounter = 0;
																																									}
																																									else
																																									{
																																										if ((double)this.velocity.X < -0.8 || (double)this.velocity.X > 0.8)
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
																																								}
																																								else
																																								{
																																									if (this.velocity.Y < 0f)
																																									{
																																										this.frameCounter = 0;
																																										this.frame = 4;
																																									}
																																									else
																																									{
																																										if (this.velocity.Y > 0f)
																																										{
																																											this.frameCounter = 0;
																																											this.frame = 6;
																																										}
																																									}
																																								}
																																								this.velocity.Y = this.velocity.Y + 0.4f;
																																								if (this.velocity.Y > 10f)
																																								{
																																									this.velocity.Y = 10f;
																																									return;
																																								}
																																							}
																																							else
																																							{
																																								if (this.type == 112)
																																								{
																																									if (this.velocity.Y == 0f)
																																									{
																																										if (this.velocity.X == 0f)
																																										{
																																											this.frame = 0;
																																											this.frameCounter = 0;
																																										}
																																										else
																																										{
																																											if ((double)this.velocity.X < -0.8 || (double)this.velocity.X > 0.8)
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
																																									}
																																									else
																																									{
																																										if (this.velocity.Y < 0f)
																																										{
																																											this.frameCounter = 0;
																																											this.frame = 2;
																																										}
																																										else
																																										{
																																											if (this.velocity.Y > 0f)
																																											{
																																												this.frameCounter = 0;
																																												this.frame = 2;
																																											}
																																										}
																																									}
																																									this.velocity.Y = this.velocity.Y + 0.4f;
																																									if (this.velocity.Y > 10f)
																																									{
																																										this.velocity.Y = 10f;
																																										return;
																																									}
																																								}
																																								else
																																								{
																																									if (this.type == 127)
																																									{
																																										if (this.velocity.Y == 0f)
																																										{
																																											if (this.velocity.X == 0f)
																																											{
																																												this.frame = 0;
																																												this.frameCounter = 0;
																																											}
																																											else
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
																																														this.frame = 0;
																																													}
																																												}
																																												else
																																												{
																																													this.frame = 0;
																																													this.frameCounter = 0;
																																												}
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
																																									else
																																									{
																																										if (this.type == 200)
																																										{
																																											if (this.velocity.Y == 0f)
																																											{
																																												if (this.velocity.X == 0f)
																																												{
																																													this.frame = 0;
																																													this.frameCounter = 0;
																																												}
																																												else
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
																																															this.frame = 0;
																																														}
																																													}
																																													else
																																													{
																																														this.frame = 0;
																																														this.frameCounter = 0;
																																													}
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
																																										else
																																										{
																																											if (this.type == 208)
																																											{
																																												if (this.velocity.Y == 0f && this.velocity.X == 0f)
																																												{
																																													if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) < this.position.X + (float)(this.width / 2))
																																													{
																																														this.direction = -1;
																																													}
																																													else
																																													{
																																														if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) > this.position.X + (float)(this.width / 2))
																																														{
																																															this.direction = 1;
																																														}
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
																																											else
																																											{
																																												if (this.type == 209)
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
																																														else
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
																																												else
																																												{
																																													if (this.type == 210)
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
																										else
																										{
																											if (this.aiStyle == 27)
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
																													for (int num384 = 5; num384 < 25; num384++)
																													{
																														float num385 = this.velocity.X * (30f / (float)num384);
																														float num386 = this.velocity.Y * (30f / (float)num384);
																														num385 *= 80f;
																														num386 *= 80f;
																														int num387 = Dust.NewDust(new Vector2(this.position.X - num385, this.position.Y - num386), 8, 8, 27, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 0.9f);
																														Main.dust[num387].velocity *= 0.25f;
																														Main.dust[num387].velocity -= this.velocity * 5f;
																													}
																												}
																												if (this.localAI[1] > 7f && this.type == 173)
																												{
																													int num388 = Main.rand.Next(3);
																													if (num388 == 0)
																													{
																														num388 = 15;
																													}
																													else
																													{
																														if (num388 == 1)
																														{
																															num388 = 57;
																														}
																														else
																														{
																															num388 = 58;
																														}
																													}
																													int num389 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 4f + 2f, this.position.Y + 2f - this.velocity.Y * 4f), 8, 8, num388, 0f, 0f, 100, default(Color), 1.25f);
																													Main.dust[num389].velocity *= 0.1f;
																												}
																												if (this.localAI[1] > 7f && this.type == 132)
																												{
																													int num390 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 4f + 2f, this.position.Y + 2f - this.velocity.Y * 4f), 8, 8, 107, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.25f);
																													Main.dust[num390].velocity *= -0.25f;
																													num390 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 4f + 2f, this.position.Y + 2f - this.velocity.Y * 4f), 8, 8, 107, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.25f);
																													Main.dust[num390].velocity *= -0.25f;
																													Main.dust[num390].position -= this.velocity * 0.5f;
																												}
																												if (this.localAI[1] < 15f)
																												{
																													this.localAI[1] += 1f;
																												}
																												else
																												{
																													if (this.type == 114 || this.type == 115)
																													{
																														int num391 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 4f), 8, 8, 27, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 0.6f);
																														Main.dust[num391].velocity *= -0.25f;
																													}
																													else
																													{
																														if (this.type == 116)
																														{
																															int num392 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 5f + 2f, this.position.Y + 2f - this.velocity.Y * 5f), 8, 8, 64, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.5f);
																															Main.dust[num392].velocity *= -0.25f;
																															Main.dust[num392].noGravity = true;
																														}
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
																													else
																													{
																														if (this.localAI[0] == 1f)
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
																											else
																											{
																												if (this.aiStyle == 28)
																												{
																													if (this.type == 177)
																													{
																														for (int num393 = 0; num393 < 3; num393++)
																														{
																															int num394 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 137, this.velocity.X, this.velocity.Y, Main.rand.Next(0, 101), default(Color), 1f + (float)Main.rand.Next(-20, 40) * 0.01f);
																															Main.dust[num394].noGravity = true;
																															Main.dust[num394].velocity *= 0.3f;
																														}
																													}
																													if (this.type == 118)
																													{
																														for (int num395 = 0; num395 < 2; num395++)
																														{
																															int num396 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 92, this.velocity.X, this.velocity.Y, 50, default(Color), 1.2f);
																															Main.dust[num396].noGravity = true;
																															Main.dust[num396].velocity *= 0.3f;
																														}
																													}
																													if (this.type == 119 || this.type == 128)
																													{
																														for (int num397 = 0; num397 < 3; num397++)
																														{
																															int num398 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 92, this.velocity.X, this.velocity.Y, 50, default(Color), 1.2f);
																															Main.dust[num398].noGravity = true;
																															Main.dust[num398].velocity *= 0.3f;
																														}
																													}
																													if (this.type == 309)
																													{
																														for (int num399 = 0; num399 < 3; num399++)
																														{
																															int num400 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 185, this.velocity.X, this.velocity.Y, 50, default(Color), 1.2f);
																															Main.dust[num400].noGravity = true;
																															Main.dust[num400].velocity *= 0.3f;
																														}
																													}
																													if (this.type == 129)
																													{
																														for (int num401 = 0; num401 < 6; num401++)
																														{
																															int num402 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 106, this.velocity.X, this.velocity.Y, 100, default(Color), 1f);
																															Main.dust[num402].noGravity = true;
																															Main.dust[num402].velocity *= 0.1f + (float)Main.rand.Next(4) * 0.1f;
																															Main.dust[num402].scale *= 1f + (float)Main.rand.Next(5) * 0.1f;
																														}
																													}
																													if (this.ai[1] == 0f)
																													{
																														this.ai[1] = 1f;
																														Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 28);
																														return;
																													}
																												}
																												else
																												{
																													if (this.aiStyle == 29)
																													{
																														int num403 = this.type - 121 + 86;
																														for (int num404 = 0; num404 < 2; num404++)
																														{
																															int num405 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num403, this.velocity.X, this.velocity.Y, 50, default(Color), 1.2f);
																															Main.dust[num405].noGravity = true;
																															Main.dust[num405].velocity *= 0.3f;
																														}
																														if (this.ai[1] == 0f)
																														{
																															this.ai[1] = 1f;
																															Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
																															return;
																														}
																													}
																													else
																													{
																														if (this.aiStyle == 30)
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
																																int num406 = 110;
																																int num407 = 0;
																																if (this.type == 146)
																																{
																																	num406 = 111;
																																	num407 = 2;
																																}
																																if (this.type == 147)
																																{
																																	num406 = 112;
																																	num407 = 1;
																																}
																																if (this.type == 148)
																																{
																																	num406 = 113;
																																	num407 = 3;
																																}
																																if (this.type == 149)
																																{
																																	num406 = 114;
																																	num407 = 4;
																																}
																																if (this.owner == Main.myPlayer)
																																{
																																	WorldGen.Convert((int)(this.position.X + (float)(this.width / 2)) / 16, (int)(this.position.Y + (float)(this.height / 2)) / 16, num407, 2);
																																}
																																if (this.timeLeft > 133)
																																{
																																	this.timeLeft = 133;
																																}
																																if (this.ai[0] > 7f)
																																{
																																	float num408 = 1f;
																																	if (this.ai[0] == 8f)
																																	{
																																		num408 = 0.2f;
																																	}
																																	else
																																	{
																																		if (this.ai[0] == 9f)
																																		{
																																			num408 = 0.4f;
																																		}
																																		else
																																		{
																																			if (this.ai[0] == 10f)
																																			{
																																				num408 = 0.6f;
																																			}
																																			else
																																			{
																																				if (this.ai[0] == 11f)
																																				{
																																					num408 = 0.8f;
																																				}
																																			}
																																		}
																																	}
																																	this.ai[0] += 1f;
																																	for (int num409 = 0; num409 < 1; num409++)
																																	{
																																		int num410 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num406, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 1f);
																																		Main.dust[num410].noGravity = true;
																																		Main.dust[num410].scale *= 1.75f;
																																		Dust expr_13506_cp_0 = Main.dust[num410];
																																		expr_13506_cp_0.velocity.X = expr_13506_cp_0.velocity.X * 2f;
																																		Dust expr_13526_cp_0 = Main.dust[num410];
																																		expr_13526_cp_0.velocity.Y = expr_13526_cp_0.velocity.Y * 2f;
																																		Main.dust[num410].scale *= num408;
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
																																	for (int num411 = 0; num411 < 255; num411++)
																																	{
																																		Rectangle rectangle2 = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
																																		if (Main.player[num411].active)
																																		{
																																			Rectangle value3 = new Rectangle((int)Main.player[num411].position.X, (int)Main.player[num411].position.Y, Main.player[num411].width, Main.player[num411].height);
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
																																				this.velocity.X = (this.velocity.X + (float)Main.player[num411].direction * 1.75f) / 2f;
																																				this.velocity.X = this.velocity.X + Main.player[num411].velocity.X * 3f;
																																				this.velocity.Y = this.velocity.Y + Main.player[num411].velocity.Y;
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
																																else
																																{
																																	if (this.wet)
																																	{
																																		this.velocity.X = this.velocity.X * 0.99f;
																																	}
																																	else
																																	{
																																		this.velocity.X = this.velocity.X * 0.995f;
																																	}
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
																																	float num412 = 4f;
																																	float num413 = this.ai[0];
																																	float num414 = this.ai[1];
																																	if (num413 == 0f && num414 == 0f)
																																	{
																																		num413 = 1f;
																																	}
																																	float num415 = (float)Math.Sqrt((double)(num413 * num413 + num414 * num414));
																																	num415 = num412 / num415;
																																	num413 *= num415;
																																	num414 *= num415;
																																	if (this.alpha < 70)
																																	{
																																		int someInt = 127;
																																		if (this.type == 310)
																																		{
																																			someInt = 187;
																																		}
																																		int num416 = Dust.NewDust(new Vector2(this.position.X, this.position.Y - 2f), 6, 6, someInt, this.velocity.X, this.velocity.Y, 100, default(Color), 1.6f);
																																		Main.dust[num416].noGravity = true;
																																		Dust expr_13AFD_cp_0 = Main.dust[num416];
																																		expr_13AFD_cp_0.position.X = expr_13AFD_cp_0.position.X - num413 * 1f;
																																		Dust expr_13B22_cp_0 = Main.dust[num416];
																																		expr_13B22_cp_0.position.Y = expr_13B22_cp_0.position.Y - num414 * 1f;
																																		Dust expr_13B47_cp_0 = Main.dust[num416];
																																		expr_13B47_cp_0.velocity.X = expr_13B47_cp_0.velocity.X - num413;
																																		Dust expr_13B66_cp_0 = Main.dust[num416];
																																		expr_13B66_cp_0.velocity.Y = expr_13B66_cp_0.velocity.Y - num414;
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
																																	int num417 = Dust.NewDust(new Vector2(this.position.X + 2f, this.position.Y + 20f), 8, 8, 6, this.velocity.X, this.velocity.Y, 100, default(Color), 1.2f);
																																	Main.dust[num417].noGravity = true;
																																	Main.dust[num417].velocity *= 0.2f;
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
																																		Vector2 vector28 = Collision.TileCollision(this.position, this.velocity, this.width, this.height, true, true);
																																		if (vector28 != this.velocity)
																																		{
																																			this.position += vector28;
																																			int num418 = (int)(this.position.X + (float)(this.width / 2)) / 16;
																																			int num419 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
																																			int num420 = 10;
																																			if (Main.tile[num418, num419] != null)
																																			{
																																				while (Main.tile[num418, num419] != null && Main.tile[num418, num419].active())
																																				{
																																					if (!Main.tileRope[(int)Main.tile[num418, num419].type])
																																					{
																																						break;
																																					}
																																					num419++;
																																				}
																																				while (num420 > 0)
																																				{
																																					num420--;
																																					if (Main.tile[num418, num419] == null)
																																					{
																																						break;
																																					}
																																					if (Main.tile[num418, num419].active() && (Main.tileCut[(int)Main.tile[num418, num419].type] || Main.tile[num418, num419].type == 165))
																																					{
																																						WorldGen.KillTile(num418, num419, false, false, false);
																																						NetMessage.SendData(17, -1, -1, "", 0, (float)num418, (float)num419, 0f, 0);
																																					}
																																					if (!Main.tile[num418, num419].active())
																																					{
																																						WorldGen.PlaceTile(num418, num419, 213, false, false, -1, 0);
																																						NetMessage.SendData(17, -1, -1, "", 1, (float)num418, (float)num419, 213f, 0);
																																						this.ai[1] += 1f;
																																					}
																																					else
																																					{
																																						num420 = 0;
																																					}
																																					num419++;
																																				}
																																				this.Kill();
																																				return;
																																			}
																																		}
																																	}
																																}
																																else
																																{
																																	if (this.aiStyle == 36)
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
																																			for (int num421 = 0; num421 < 3; num421++)
																																			{
																																				float num422 = this.velocity.X / 3f * (float)num421;
																																				float num423 = this.velocity.Y / 3f * (float)num421;
																																				int num424 = Dust.NewDust(this.position, this.width, this.height, 184, 0f, 0f, 0, default(Color), 1f);
																																				Main.dust[num424].position.X = this.center().X - num422;
																																				Main.dust[num424].position.Y = this.center().Y - num423;
																																				Main.dust[num424].velocity *= 0f;
																																				Main.dust[num424].scale = 0.5f;
																																			}
																																		}
																																		else
																																		{
																																			if (this.velocity.X > 0f)
																																			{
																																				this.spriteDirection = 1;
																																			}
																																			else
																																			{
																																				if (this.velocity.X < 0f)
																																				{
																																					this.spriteDirection = -1;
																																				}
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
																																		float num425 = this.position.X;
																																		float num426 = this.position.Y;
																																		float num427 = 100000f;
																																		bool flag14 = false;
																																		this.ai[0] += 1f;
																																		if (this.ai[0] > 30f)
																																		{
																																			this.ai[0] = 30f;
																																			for (int num428 = 0; num428 < 200; num428++)
																																			{
																																				if (Main.npc[num428].active && !Main.npc[num428].dontTakeDamage && !Main.npc[num428].friendly && Main.npc[num428].lifeMax > 5 && (!Main.npc[num428].wet || this.type == 307))
																																				{
																																					float num429 = Main.npc[num428].position.X + (float)(Main.npc[num428].width / 2);
																																					float num430 = Main.npc[num428].position.Y + (float)(Main.npc[num428].height / 2);
																																					float num431 = Math.Abs(this.position.X + (float)(this.width / 2) - num429) + Math.Abs(this.position.Y + (float)(this.height / 2) - num430);
																																					if (num431 < 800f && num431 < num427 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num428].position, Main.npc[num428].width, Main.npc[num428].height))
																																					{
																																						num427 = num431;
																																						num425 = num429;
																																						num426 = num430;
																																						flag14 = true;
																																					}
																																				}
																																			}
																																		}
																																		if (!flag14)
																																		{
																																			num425 = this.position.X + (float)(this.width / 2) + this.velocity.X * 100f;
																																			num426 = this.position.Y + (float)(this.height / 2) + this.velocity.Y * 100f;
																																		}
																																		else
																																		{
																																			if (this.type == 307)
																																			{
																																				this.friendly = true;
																																			}
																																		}
																																		float num432 = 6f;
																																		float num433 = 0.1f;
																																		if (this.type == 189)
																																		{
																																			num432 = 7f;
																																			num433 = 0.15f;
																																		}
																																		if (this.type == 307)
																																		{
																																		num432 = 9f;
																																			num433 = 0.2f;
																																		}
																																		Vector2 vector29 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
																																		float num434 = num425 - vector29.X;
																																		float num435 = num426 - vector29.Y;
																																		float num436 = (float)Math.Sqrt((double)(num434 * num434 + num435 * num435));
																																		num436 = num432 / num436;
																																		num434 *= num436;
																																		num435 *= num436;
																																		if (this.velocity.X < num434)
																																		{
																																			this.velocity.X = this.velocity.X + num433;
																																			if (this.velocity.X < 0f && num434 > 0f)
																																			{
																																				this.velocity.X = this.velocity.X + num433 * 2f;
																																			}
																																		}
																																		else
																																		{
																																			if (this.velocity.X > num434)
																																			{
																																				this.velocity.X = this.velocity.X - num433;
																																				if (this.velocity.X > 0f && num434 < 0f)
																																				{
																																					this.velocity.X = this.velocity.X - num433 * 2f;
																																				}
																																			}
																																		}
																																		if (this.velocity.Y < num435)
																																		{
																																			this.velocity.Y = this.velocity.Y + num433;
																																			if (this.velocity.Y < 0f && num435 > 0f)
																																			{
																																				this.velocity.Y = this.velocity.Y + num433 * 2f;
																																				return;
																																			}
																																		}
																																		else
																																		{
																																			if (this.velocity.Y > num435)
																																			{
																																				this.velocity.Y = this.velocity.Y - num433;
																																				if (this.velocity.Y > 0f && num435 < 0f)
																																				{
																																					this.velocity.Y = this.velocity.Y - num433 * 2f;
																																					return;
																																				}
																																			}
																																		}
																																	}
																																	else
																																	{
																																		if (this.aiStyle == 37)
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
																																				float num437 = this.position.Y - this.ai[1];
																																				if (num437 > 300f)
																																				{
																																					this.velocity.Y = this.velocity.Y * -1f;
																																					this.ai[0] += 1f;
																																					return;
																																				}
																																			}
																																			else
																																			{
																																				if (Collision.SolidCollision(this.position, this.width, this.height))
																																				{
																																					this.Kill();
																																					return;
																																				}
																																			}
																																		}
																																		else
																																		{
																																			if (this.aiStyle == 38)
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
																																			else
																																			{
																																				if (this.aiStyle == 39)
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
																																					Vector2 vector30 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
																																					float num438 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector30.X;
																																					float num439 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector30.Y;
																																					float num440 = (float)Math.Sqrt((double)(num438 * num438 + num439 * num439));
																																					if (!Main.player[this.owner].channel && this.alpha == 0)
																																					{
																																						this.ai[0] = 1f;
																																						this.ai[1] = -1f;
																																					}
																																					if (this.ai[1] > 0f && num440 > 1500f)
																																					{
																																						this.ai[1] = 0f;
																																						this.ai[0] = 1f;
																																					}
																																					if (this.ai[1] > 0f)
																																					{
																																						this.tileCollide = false;
																																						int num441 = (int)this.ai[1] - 1;
																																						if (Main.npc[num441].active && Main.npc[num441].life > 0)
																																						{
																																							float num442 = 16f;
																																							vector30 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
																																							num438 = Main.npc[num441].position.X + (float)(Main.npc[num441].width / 2) - vector30.X;
																																							num439 = Main.npc[num441].position.Y + (float)(Main.npc[num441].height / 2) - vector30.Y;
																																							num440 = (float)Math.Sqrt((double)(num438 * num438 + num439 * num439));
																																							if (num440 < num442)
																																							{
																																								this.velocity.X = num438;
																																								this.velocity.Y = num439;
																																								if (num440 > num442 / 2f)
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
																																								num440 = num442 / num440;
																																								num438 *= num440;
																																								num439 *= num440;
																																								this.velocity.X = num438;
																																								this.velocity.Y = num439;
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
																																							float num443 = this.position.X;
																																							float num444 = this.position.Y;
																																							float num445 = 3000f;
																																							int num446 = -1;
																																							for (int num447 = 0; num447 < 200; num447++)
																																							{
																																								if (Main.npc[num447].active && !Main.npc[num447].friendly && Main.npc[num447].lifeMax > 5)
																																								{
																																									float num448 = Main.npc[num447].position.X + (float)(Main.npc[num447].width / 2);
																																									float num449 = Main.npc[num447].position.Y + (float)(Main.npc[num447].height / 2);
																																									float num450 = Math.Abs(this.position.X + (float)(this.width / 2) - num448) + Math.Abs(this.position.Y + (float)(this.height / 2) - num449);
																																									if (num450 < num445 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num447].position, Main.npc[num447].width, Main.npc[num447].height))
																																									{
																																										num445 = num450;
																																										num443 = num448;
																																										num444 = num449;
																																										num446 = num447;
																																									}
																																								}
																																							}
																																							if (num446 >= 0)
																																							{
																																								float num451 = 16f;
																																								vector30 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
																																								num438 = num443 - vector30.X;
																																								num439 = num444 - vector30.Y;
																																								num440 = (float)Math.Sqrt((double)(num438 * num438 + num439 * num439));
																																								num440 = num451 / num440;
																																								num438 *= num440;
																																								num439 *= num440;
																																								this.velocity.X = num438;
																																								this.velocity.Y = num439;
																																								this.ai[0] = 0f;
																																								this.ai[1] = (float)(num446 + 1);
																																							}
																																						}
																																					}
																																					else
																																					{
																																						if (this.ai[0] == 0f)
																																						{
																																							if (num440 > 700f)
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
																																						else
																																						{
																																							if (this.ai[0] == 1f)
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
																																								float num452 = 20f;
																																								if (num440 < 70f)
																																								{
																																									this.Kill();
																																								}
																																								num440 = num452 / num440;
																																								num438 *= num440;
																																								num439 *= num440;
																																								this.velocity.X = num438;
																																								this.velocity.Y = num439;
																																							}
																																						}
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
																																						float num453 = (float)Main.mouseTextColor / 200f - 0.35f;
																																						num453 *= 0.2f;
																																						this.scale = num453 + 0.95f;
																																						if (this.owner == Main.myPlayer)
																																						{
																																							if (this.ai[0] != 0f)
																																							{
																																								this.ai[0] -= 1f;
																																								return;
																																							}
																																							float num454 = this.position.X;
																																							float num455 = this.position.Y;
																																							float num456 = 700f;
																																							bool flag15 = false;
																																							for (int num457 = 0; num457 < 200; num457++)
																																							{
																																								if (Main.npc[num457].active && !Main.npc[num457].friendly && Main.npc[num457].lifeMax > 5)
																																								{
																																									float num458 = Main.npc[num457].position.X + (float)(Main.npc[num457].width / 2);
																																									float num459 = Main.npc[num457].position.Y + (float)(Main.npc[num457].height / 2);
																																									float num460 = Math.Abs(this.position.X + (float)(this.width / 2) - num458) + Math.Abs(this.position.Y + (float)(this.height / 2) - num459);
																																									if (num460 < num456 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num457].position, Main.npc[num457].width, Main.npc[num457].height))
																																									{
																																										num456 = num460;
																																										num454 = num458;
																																										num455 = num459;
																																										flag15 = true;
																																									}
																																								}
																																							}
																																							if (flag15)
																																							{
																																								float num461 = 12f;
																																								Vector2 vector31 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
																																								float num462 = num454 - vector31.X;
																																								float num463 = num455 - vector31.Y;
																																								float num464 = (float)Math.Sqrt((double)(num462 * num462 + num463 * num463));
																																								num464 = num461 / num464;
																																								num462 *= num464;
																																								num463 *= num464;
																																								Projectile.NewProjectile(this.center().X - 4f, this.center().Y, num462, num463, 227, 40, 5f, this.owner, 0f, 0f);
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
																																								for (int num465 = 0; num465 < 5; num465++)
																																								{
																																									int num466 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 157, 0f, 0f, 0, default(Color), 1f);
																																									Main.dust[num466].noGravity = true;
																																									Main.dust[num466].velocity *= 3f;
																																									Main.dust[num466].scale = 1.5f;
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
																																							int num467 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 157, 0f, 0f, 0, default(Color), 1f);
																																							Main.dust[num467].noGravity = true;
																																							Main.dust[num467].velocity *= 0.1f;
																																							Main.dust[num467].scale = 1.5f;
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
																																							else
																																							{
																																								if (this.type == 229)
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
																																						else
																																						{
																																							if (this.aiStyle == 45)
																																							{
																																								if (this.type == 237 || this.type == 243)
																																								{
																																									float num468 = this.ai[0];
																																									float num469 = this.ai[1];
																																									if (num468 != 0f && num469 != 0f)
																																									{
																																										bool flag16 = false;
																																										bool flag17 = false;
																																										if ((this.velocity.X < 0f && this.center().X < num468) || (this.velocity.X > 0f && this.center().X > num468))
																																										{
																																											flag16 = true;
																																										}
																																										if ((this.velocity.Y < 0f && this.center().Y < num469) || (this.velocity.Y > 0f && this.center().Y > num469))
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
																																								else
																																								{
																																									if (this.type == 238 || this.type == 244)
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
																																										else
																																										{
																																											if (this.type == 238 && this.ai[1] >= 3600f)
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
																																															int num470 = (int)(this.position.X + 14f + (float)Main.rand.Next(this.width - 28));
																																															int num471 = (int)(this.position.Y + (float)this.height + 4f);
																																															Projectile.NewProjectile((float)num470, (float)num471, 0f, 5f, 245, this.damage, 0f, this.owner, 0f, 0f);
																																														}
																																													}
																																												}
																																												else
																																												{
																																													if (this.ai[0] > 8f)
																																													{
																																														this.ai[0] = 0f;
																																														if (this.owner == Main.myPlayer)
																																														{
																																															int num472 = (int)(this.position.X + 14f + (float)Main.rand.Next(this.width - 28));
																																															int num473 = (int)(this.position.Y + (float)this.height + 4f);
																																															Projectile.NewProjectile((float)num472, (float)num473, 0f, 5f, 239, this.damage, 0f, this.owner, 0f, 0f);
																																														}
																																													}
																																												}
																																											}
																																										}
																																										this.localAI[0] += 1f;
																																										if (this.localAI[0] >= 10f)
																																										{
																																											this.localAI[0] = 0f;
																																											int num474 = 0;
																																											int num475 = 0;
																																											float num476 = 0f;
																																											int num477 = this.type;
																																											for (int num478 = 0; num478 < 1000; num478++)
																																											{
																																												if (Main.projectile[num478].active && Main.projectile[num478].owner == this.owner && Main.projectile[num478].type == num477 && Main.projectile[num478].ai[1] < 3600f)
																																												{
																																													num474++;
																																													if (Main.projectile[num478].ai[1] > num476)
																																													{
																																														num475 = num478;
																																														num476 = Main.projectile[num478].ai[1];
																																													}
																																												}
																																											}
																																											if (this.type == 244)
																																											{
																																												if (num474 > 1)
																																												{
																																													Main.projectile[num475].netUpdate = true;
																																													Main.projectile[num475].ai[1] = 36000f;
																																													return;
																																												}
																																											}
																																											else
																																											{
																																												if (num474 > 2)
																																												{
																																													Main.projectile[num475].netUpdate = true;
																																													Main.projectile[num475].ai[1] = 36000f;
																																													return;
																																												}
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
																																							}
																																							else
																																							{
																																								if (this.aiStyle == 46)
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
																																										float num479 = 1f;
																																										if (this.velocity.Y < 0f)
																																										{
																																											num479 -= this.velocity.Y / 3f;
																																										}
																																										this.ai[0] += num479;
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
																																										float num480 = this.velocity.X;
																																										float num481 = this.velocity.Y;
																																										float num482 = (float)Math.Sqrt((double)(num480 * num480 + num481 * num481));
																																										num482 = 15.95f * this.scale / num482;
																																										num480 *= num482;
																																										num481 *= num482;
																																										this.velocity.X = num480;
																																										this.velocity.Y = num481;
																																										this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) - 1.57f;
																																										return;
																																									}
																																									int num483 = 300;
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
																																										this.timeLeft = num483;
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
																																									if (this.timeLeft > num483 - 10)
																																									{
																																										int num484 = num483 - this.timeLeft;
																																										this.alpha = 255 - (int)(255f * (float)num484 / 10f);
																																										return;
																																									}
																																									this.alpha = 0;
																																									return;
																																								}
																																								else
																																								{
																																									if (this.aiStyle == 47)
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
																																										for (int num485 = 0; num485 < 1000; num485++)
																																										{
																																											if (num485 != this.whoAmI && Main.projectile[num485].active && Main.projectile[num485].owner == this.owner && Main.projectile[num485].type == this.type && this.timeLeft > Main.projectile[num485].timeLeft && Main.projectile[num485].timeLeft > 30)
																																											{
																																												Main.projectile[num485].timeLeft = 30;
																																											}
																																										}
																																										int[] array = new int[20];
																																										int num486 = 0;
																																										float num487 = 300f;
																																										bool flag18 = false;
																																										for (int num488 = 0; num488 < 200; num488++)
																																										{
																																											if (Main.npc[num488].active && !Main.npc[num488].dontTakeDamage && !Main.npc[num488].friendly && Main.npc[num488].lifeMax > 5)
																																											{
																																												float num489 = Main.npc[num488].position.X + (float)(Main.npc[num488].width / 2);
																																												float num490 = Main.npc[num488].position.Y + (float)(Main.npc[num488].height / 2);
																																												float num491 = Math.Abs(this.position.X + (float)(this.width / 2) - num489) + Math.Abs(this.position.Y + (float)(this.height / 2) - num490);
																																												if (num491 < num487 && Collision.CanHit(this.center(), 1, 1, Main.npc[num488].center(), 1, 1))
																																												{
																																													if (num486 < 20)
																																													{
																																														array[num486] = num488;
																																														num486++;
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
																																											int num492 = Main.rand.Next(num486);
																																											num492 = array[num492];
																																											float num493 = Main.npc[num492].position.X + (float)(Main.npc[num492].width / 2);
																																											float num494 = Main.npc[num492].position.Y + (float)(Main.npc[num492].height / 2);
																																											this.localAI[0] += 1f;
																																											if (this.localAI[0] > 8f)
																																											{
																																												this.localAI[0] = 0f;
																																												float num495 = 6f;
																																												Vector2 value4 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
																																												value4 += this.velocity * 4f;
																																												float num496 = num493 - value4.X;
																																												float num497 = num494 - value4.Y;
																																												float num498 = (float)Math.Sqrt((double)(num496 * num496 + num497 * num497));
																																												num498 = num495 / num498;
																																												num496 *= num498;
																																												num497 *= num498;
																																												Projectile.NewProjectile(value4.X, value4.Y, num496, num497, 255, this.damage, this.knockBack, this.owner, 0f, 0f);
																																												return;
																																											}
																																										}
																																									}
																																									else
																																									{
																																										if (this.aiStyle == 48)
																																										{
																																											if (this.type == 255)
																																											{
																																												for (int num499 = 0; num499 < 4; num499++)
																																												{
																																													Vector2 value5 = this.position;
																																													value5 -= this.velocity * ((float)num499 * 0.25f);
																																													this.alpha = 255;
																																													int num500 = Dust.NewDust(value5, 1, 1, 160, 0f, 0f, 0, default(Color), 1f);
																																													Main.dust[num500].position = value5;
																																													Dust expr_16CF9_cp_0 = Main.dust[num500];
																																													expr_16CF9_cp_0.position.X = expr_16CF9_cp_0.position.X + (float)(this.width / 2);
																																													Dust expr_16D1D_cp_0 = Main.dust[num500];
																																													expr_16D1D_cp_0.position.Y = expr_16D1D_cp_0.position.Y + (float)(this.height / 2);
																																													Main.dust[num500].scale = (float)Main.rand.Next(70, 110) * 0.013f;
																																													Main.dust[num500].velocity *= 0.2f;
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
																																													for (int num501 = 0; num501 < 3; num501++)
																																													{
																																														Vector2 value6 = this.position;
																																														value6 -= this.velocity * ((float)num501 * 0.3334f);
																																														this.alpha = 255;
																																														int num502 = Dust.NewDust(value6, 1, 1, 173, 0f, 0f, 0, default(Color), 1f);
																																														Main.dust[num502].position = value6;
																																														Main.dust[num502].scale = (float)Main.rand.Next(70, 110) * 0.013f;
																																														Main.dust[num502].velocity *= 0.2f;
																																													}
																																													return;
																																												}
																																											}
																																											else
																																											{
																																												if (this.type == 294)
																																												{
																																													this.localAI[0] += 1f;
																																													if (this.localAI[0] > 9f)
																																													{
																																														for (int num503 = 0; num503 < 4; num503++)
																																														{
																																															Vector2 value7 = this.position;
																																															value7 -= this.velocity * ((float)num503 * 0.25f);
																																															this.alpha = 255;
																																															int num504 = Dust.NewDust(value7, 1, 1, 173, 0f, 0f, 0, default(Color), 1f);
																																															Main.dust[num504].position = value7;
																																															Main.dust[num504].scale = (float)Main.rand.Next(70, 110) * 0.013f;
																																															Main.dust[num504].velocity *= 0.2f;
																																														}
																																														return;
																																													}
																																												}
																																												else
																																												{
																																													this.localAI[0] += 1f;
																																													if (this.localAI[0] > 3f)
																																													{
																																														for (int num505 = 0; num505 < 4; num505++)
																																														{
																																															Vector2 value8 = this.position;
																																															value8 -= this.velocity * ((float)num505 * 0.25f);
																																															this.alpha = 255;
																																															int num506 = Dust.NewDust(value8, 1, 1, 162, 0f, 0f, 0, default(Color), 1f);
																																															Main.dust[num506].position = value8;
																																															Dust expr_170B9_cp_0 = Main.dust[num506];
																																															expr_170B9_cp_0.position.X = expr_170B9_cp_0.position.X + (float)(this.width / 2);
																																															Dust expr_170DD_cp_0 = Main.dust[num506];
																																															expr_170DD_cp_0.position.Y = expr_170DD_cp_0.position.Y + (float)(this.height / 2);
																																															Main.dust[num506].scale = (float)Main.rand.Next(70, 110) * 0.013f;
																																															Main.dust[num506].velocity *= 0.2f;
																																														}
																																														return;
																																													}
																																												}
																																											}
																																										}
																																										else
																																										{
																																											if (this.aiStyle == 49)
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
																																													else
																																													{
																																														if (this.velocity.X < 0f)
																																														{
																																															this.direction = -1;
																																														}
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
																																															for (int num507 = 0; num507 < 10; num507++)
																																															{
																																																int num508 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
																																																Main.dust[num508].velocity *= 0.5f;
																																																Main.dust[num508].velocity += this.velocity * 0.1f;
																																															}
																																															for (int num509 = 0; num509 < 5; num509++)
																																															{
																																																int num510 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
																																																Main.dust[num510].noGravity = true;
																																																Main.dust[num510].velocity *= 3f;
																																																Main.dust[num510].velocity += this.velocity * 0.2f;
																																																num510 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
																																																Main.dust[num510].velocity *= 2f;
																																																Main.dust[num510].velocity += this.velocity * 0.3f;
																																															}
																																															for (int num511 = 0; num511 < 1; num511++)
																																															{
																																																int num512 = Gore.NewGore(new Vector2(this.position.X - 10f, this.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
																																																Main.gore[num512].position += this.velocity * 1.25f;
																																																Main.gore[num512].scale = 1.5f;
																																																Main.gore[num512].velocity += this.velocity * 0.5f;
																																																Main.gore[num512].velocity *= 0.02f;
																																															}
																																															return;
																																														}
																																													}
																																												}
																																												else
																																												{
																																													if (this.ai[1] == 2f)
																																													{
																																														this.rotation = 0f;
																																														this.velocity.X = this.velocity.X * 0.95f;
																																														this.velocity.Y = this.velocity.Y + 0.2f;
																																														return;
																																													}
																																												}
																																											}
																																											else
																																											{
																																												if (this.aiStyle == 50)
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
																																														for (int num513 = 0; num513 < 10; num513++)
																																														{
																																															int num514 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 174, 0f, 0f, 100, default(Color), 1.2f);
																																															Main.dust[num514].noGravity = true;
																																															Main.dust[num514].velocity *= 0.5f;
																																															Main.dust[num514].velocity += this.velocity * 0.1f;
																																														}
																																														return;
																																													}
																																													if (this.type == 295)
																																													{
																																														for (int num515 = 0; num515 < 8; num515++)
																																														{
																																															int num516 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 174, 0f, 0f, 100, default(Color), 1.2f);
																																															Main.dust[num516].noGravity = true;
																																															Main.dust[num516].velocity *= 0.5f;
																																															Main.dust[num516].velocity += this.velocity * 0.1f;
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
																																													float num517 = 40f;
																																													if (this.ai[0] > 180f)
																																													{
																																														num517 -= (this.ai[0] - 180f) / 2f;
																																													}
																																													if (num517 <= 0f)
																																													{
																																														num517 = 0f;
																																														this.Kill();
																																													}
																																													if (this.type == 296)
																																													{
																																														num517 *= 0.7f;
																																													}
																																													int num518 = 0;
																																													while ((float)num518 < num517)
																																													{
																																														float num519 = (float)Main.rand.Next(-10, 11);
																																														float num520 = (float)Main.rand.Next(-10, 11);
																																														float num521 = (float)Main.rand.Next(3, 9);
																																														float num522 = (float)Math.Sqrt((double)(num519 * num519 + num520 * num520));
																																														num522 = num521 / num522;
																																														num519 *= num522;
																																														num520 *= num522;
																																														int num523 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 174, 0f, 0f, 100, default(Color), 1.5f);
																																														Main.dust[num523].noGravity = true;
																																														Main.dust[num523].position.X = this.center().X;
																																														Main.dust[num523].position.Y = this.center().Y;
																																														Dust expr_17B2C_cp_0 = Main.dust[num523];
																																														expr_17B2C_cp_0.position.X = expr_17B2C_cp_0.position.X + (float)Main.rand.Next(-10, 11);
																																														Dust expr_17B56_cp_0 = Main.dust[num523];
																																														expr_17B56_cp_0.position.Y = expr_17B56_cp_0.position.Y + (float)Main.rand.Next(-10, 11);
																																														Main.dust[num523].velocity.X = num519;
																																														Main.dust[num523].velocity.Y = num520;
																																														num518++;
																																													}
																																													return;
																																												}
																																												else
																																												{
																																													if (this.aiStyle == 51)
																																													{
																																														if (this.type == 297)
																																														{
																																															this.localAI[0] += 1f;
																																															if (this.localAI[0] > 4f)
																																															{
																																																for (int num524 = 0; num524 < 5; num524++)
																																																{
																																																	int num525 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 175, 0f, 0f, 100, default(Color), 2f);
																																																	Main.dust[num525].noGravity = true;
																																																	Main.dust[num525].velocity *= 0f;
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
																																															for (int num526 = 0; num526 < 10; num526++)
																																															{
																																																int num527 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 175, 0f, 0f, 100, default(Color), 1.3f);
																																																Main.dust[num527].noGravity = true;
																																																Main.dust[num527].velocity *= 0f;
																																															}
																																														}
																																														float num528 = this.center().X;
																																														float num529 = this.center().Y;
																																														float num530 = 400f;
																																														bool flag21 = false;
																																														if (this.type == 297)
																																														{
																																															for (int num531 = 0; num531 < 200; num531++)
																																															{
																																																if (Main.npc[num531].active && !Main.npc[num531].dontTakeDamage && !Main.npc[num531].friendly && Main.npc[num531].lifeMax > 5 && Collision.CanHit(this.center(), 1, 1, Main.npc[num531].center(), 1, 1))
																																																{
																																																	float num532 = Main.npc[num531].position.X + (float)(Main.npc[num531].width / 2);
																																																	float num533 = Main.npc[num531].position.Y + (float)(Main.npc[num531].height / 2);
																																																	float num534 = Math.Abs(this.position.X + (float)(this.width / 2) - num532) + Math.Abs(this.position.Y + (float)(this.height / 2) - num533);
																																																	if (num534 < num530)
																																																	{
																																																		num530 = num534;
																																																		num528 = num532;
																																																		num529 = num533;
																																																		flag21 = true;
																																																	}
																																																}
																																															}
																																														}
																																														else
																																														{
																																															num530 = 200f;
																																															for (int num535 = 0; num535 < 255; num535++)
																																															{
																																																if (Main.player[num535].active && !Main.player[num535].dead)
																																																{
																																																	float num536 = Main.player[num535].position.X + (float)(Main.player[num535].width / 2);
																																																	float num537 = Main.player[num535].position.Y + (float)(Main.player[num535].height / 2);
																																																	float num538 = Math.Abs(this.position.X + (float)(this.width / 2) - num536) + Math.Abs(this.position.Y + (float)(this.height / 2) - num537);
																																																	if (num538 < num530)
																																																	{
																																																		num530 = num538;
																																																		num528 = num536;
																																																		num529 = num537;
																																																		flag21 = true;
																																																	}
																																																}
																																															}
																																														}
																																														if (flag21)
																																														{
																																															float num539 = 3f;
																																															if (this.type == 297)
																																															{
																																																num539 = 6f;
																																															}
																																															Vector2 vector32 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
																																															float num540 = num528 - vector32.X;
																																															float num541 = num529 - vector32.Y;
																																															float num542 = (float)Math.Sqrt((double)(num540 * num540 + num541 * num541));
																																															num542 = num539 / num542;
																																															num540 *= num542;
																																															num541 *= num542;
																																															if (this.type == 297)
																																															{
																																																this.velocity.X = (this.velocity.X * 20f + num540) / 21f;
																																																this.velocity.Y = (this.velocity.Y * 20f + num541) / 21f;
																																																return;
																																															}
																																															this.velocity.X = (this.velocity.X * 100f + num540) / 101f;
																																															this.velocity.Y = (this.velocity.Y * 100f + num541) / 101f;
																																															return;
																																														}
																																													}
																																													else
																																													{
																																														if (this.aiStyle == 52)
																																														{
																																															int num543 = (int)this.ai[0];
																																															float num544 = 4f;
																																															Vector2 vector33 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
																																															float num545 = Main.player[num543].center().X - vector33.X;
																																															float num546 = Main.player[num543].center().Y - vector33.Y;
																																															float num547 = (float)Math.Sqrt((double)(num545 * num545 + num546 * num546));
																																															if (num547 < 50f && this.position.X < Main.player[num543].position.X + (float)Main.player[num543].width && this.position.X + (float)this.width > Main.player[num543].position.X && this.position.Y < Main.player[num543].position.Y + (float)Main.player[num543].height && this.position.Y + (float)this.height > Main.player[num543].position.Y)
																																															{
																																																if (this.owner == Main.myPlayer)
																																																{
																																																	int num548 = (int)this.ai[1];
																																																	Main.player[num543].HealEffect(num548, false);
																																																	Main.player[num543].statLife += num548;
																																																	if (Main.player[num543].statLife > Main.player[num543].statLifeMax)
																																																	{
																																																		Main.player[num543].statLife = Main.player[num543].statLifeMax;
																																																	}
																																																	NetMessage.SendData(66, -1, -1, "", num543, (float)num548, 0f, 0f, 0);
																																																}
																																																this.Kill();
																																															}
																																															num547 = num544 / num547;
																																															num545 *= num547;
																																															num546 *= num547;
																																															this.velocity.X = (this.velocity.X * 15f + num545) / 16f;
																																															this.velocity.Y = (this.velocity.Y * 15f + num546) / 16f;
																																															if (this.type == 305)
																																															{
																																																for (int num549 = 0; num549 < 3; num549++)
																																																{
																																																	float num550 = this.velocity.X * 0.334f * (float)num549;
																																																	float num551 = -(this.velocity.Y * 0.334f) * (float)num549;
																																																	int num552 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 183, 0f, 0f, 100, default(Color), 1.1f);
																																																	Main.dust[num552].noGravity = true;
																																																	Main.dust[num552].velocity *= 0f;
																																																	Dust expr_18553_cp_0 = Main.dust[num552];
																																																	expr_18553_cp_0.position.X = expr_18553_cp_0.position.X - num550;
																																																	Dust expr_18572_cp_0 = Main.dust[num552];
																																																	expr_18572_cp_0.position.Y = expr_18572_cp_0.position.Y - num551;
																																																}
																																																return;
																																															}
																																															for (int num553 = 0; num553 < 5; num553++)
																																															{
																																																float num554 = this.velocity.X * 0.2f * (float)num553;
																																																float num555 = -(this.velocity.Y * 0.2f) * (float)num553;
																																																int num556 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 175, 0f, 0f, 100, default(Color), 1.3f);
																																																Main.dust[num556].noGravity = true;
																																																Main.dust[num556].velocity *= 0f;
																																																Dust expr_1866A_cp_0 = Main.dust[num556];
																																																expr_1866A_cp_0.position.X = expr_1866A_cp_0.position.X - num554;
																																																Dust expr_18689_cp_0 = Main.dust[num556];
																																																expr_18689_cp_0.position.Y = expr_18689_cp_0.position.Y - num555;
																																															}
																																															return;
																																														}
																																														else
																																														{
																																															if (this.aiStyle == 53)
																																															{
																																																if (this.localAI[0] == 0f)
																																																{
																																																	this.localAI[1] = 1f;
																																																	this.localAI[0] = 1f;
																																																	this.ai[0] = 120f;
																																																	int num557 = 80;
																																																	Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 46);
																																																	for (int num558 = 0; num558 < num557; num558++)
																																																	{
																																																		int num559 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 16f), this.width, this.height - 16, 185, 0f, 0f, 0, default(Color), 1f);
																																																		Main.dust[num559].velocity *= 2f;
																																																		Main.dust[num559].noGravity = true;
																																																		Main.dust[num559].scale *= 1.15f;
																																																	}
																																																}
																																																this.velocity.X = 0f;
																																																this.velocity.Y = this.velocity.Y + 0.2f;
																																																if (this.velocity.Y > 16f)
																																																{
																																																	this.velocity.Y = 16f;
																																																}
																																																bool flag22 = false;
																																																float num560 = this.center().X;
																																																float num561 = this.center().Y;
																																																float num562 = 1000f;
																																																for (int num563 = 0; num563 < 200; num563++)
																																																{
																																																	if (Main.npc[num563].active && !Main.npc[num563].dontTakeDamage && !Main.npc[num563].friendly && Main.npc[num563].lifeMax > 5)
																																																	{
																																																		float num564 = Main.npc[num563].position.X + (float)(Main.npc[num563].width / 2);
																																																		float num565 = Main.npc[num563].position.Y + (float)(Main.npc[num563].height / 2);
																																																		float num566 = Math.Abs(this.position.X + (float)(this.width / 2) - num564) + Math.Abs(this.position.Y + (float)(this.height / 2) - num565);
																																																		if (num566 < num562 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num563].position, Main.npc[num563].width, Main.npc[num563].height))
																																																		{
																																																			num562 = num566;
																																																			num560 = num564;
																																																			num561 = num565;
																																																			flag22 = true;
																																																		}
																																																	}
																																																}
																																																if (flag22)
																																																{
																																																	float num567 = num560;
																																																	float num568 = num561;
																																																	num560 -= this.center().X;
																																																	num561 -= this.center().Y;
																																																	if (num560 < 0f)
																																																	{
																																																		this.spriteDirection = -1;
																																																	}
																																																	else
																																																	{
																																																		this.spriteDirection = 1;
																																																	}
																																																	int num569;
																																																	if (num561 > 0f)
																																																	{
																																																		num569 = 0;
																																																	}
																																																	else
																																																	{
																																																		if (Math.Abs(num561) > Math.Abs(num560) * 3f)
																																																		{
																																																			num569 = 4;
																																																		}
																																																		else
																																																		{
																																																			if (Math.Abs(num561) > Math.Abs(num560) * 2f)
																																																			{
																																																				num569 = 3;
																																																			}
																																																			else
																																																			{
																																																				if (Math.Abs(num560) > Math.Abs(num561) * 3f)
																																																				{
																																																					num569 = 0;
																																																				}
																																																				else
																																																				{
																																																					if (Math.Abs(num560) > Math.Abs(num561) * 2f)
																																																					{
																																																						num569 = 1;
																																																					}
																																																					else
																																																					{
																																																						num569 = 2;
																																																					}
																																																				}
																																																			}
																																																		}
																																																	}
																																																	this.frame = num569 * 2;
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
																																																			float num570 = 6f;
																																																			Vector2 vector34 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
																																																			if (num569 == 0)
																																																			{
																																																				vector34.Y += 12f;
																																																				vector34.X += (float)(24 * this.spriteDirection);
																																																			}
																																																			else
																																																			{
																																																				if (num569 == 1)
																																																				{
																																																					vector34.Y += 0f;
																																																					vector34.X += (float)(24 * this.spriteDirection);
																																																				}
																																																				else
																																																				{
																																																					if (num569 == 2)
																																																					{
																																																						vector34.Y -= 2f;
																																																						vector34.X += (float)(24 * this.spriteDirection);
																																																					}
																																																					else
																																																					{
																																																						if (num569 == 3)
																																																						{
																																																							vector34.Y -= 6f;
																																																							vector34.X += (float)(14 * this.spriteDirection);
																																																						}
																																																						else
																																																						{
																																																							if (num569 == 4)
																																																							{
																																																								vector34.Y -= 14f;
																																																								vector34.X += (float)(2 * this.spriteDirection);
																																																							}
																																																						}
																																																					}
																																																				}
																																																			}
																																																			if (this.spriteDirection < 0)
																																																			{
																																																				vector34.X += 10f;
																																																			}
																																																			float num571 = num567 - vector34.X;
																																																			float num572 = num568 - vector34.Y;
																																																			float num573 = (float)Math.Sqrt((double)(num571 * num571 + num572 * num572));
																																																			num573 = num570 / num573;
																																																			num571 *= num573;
																																																			num572 *= num573;
																																																			int num574 = this.damage;
																																																			int num575 = 309;
																																																			Projectile.NewProjectile(vector34.X, vector34.Y, num571, num572, num575, num574, this.knockBack, Main.myPlayer, 0f, 0f);
																																																		}
																																																	}
																																																}
																																																else
																																																{
																																																	if (this.ai[0] <= 60f && (this.frame == 1 || this.frame == 3 || this.frame == 5 || this.frame == 7 || this.frame == 9))
																																																	{
																																																		this.frame--;
																																																	}
																																																}
																																																if (this.ai[0] > 0f)
																																																{
																																																	this.ai[0] -= 1f;
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
									if (Main.tileDungeon[(int)Main.tile[i1, j1].type] || (int)Main.tile[i1, j1].type == 21 || ((int)Main.tile[i1, j1].type == 26 || (int)Main.tile[i1, j1].type == 107) || ((int)Main.tile[i1, j1].type == 108 || (int)Main.tile[i1, j1].type == 111 || ((int)Main.tile[i1, j1].type == 226 || (int)Main.tile[i1, j1].type == 237)) || ((int)Main.tile[i1, j1].type == 221 || (int)Main.tile[i1, j1].type == 222 || ((int)Main.tile[i1, j1].type == 223  || (int) Main.tile[i1, j1].type == 211)))
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
        		if (this.type == 5)
          			return new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 0);
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
