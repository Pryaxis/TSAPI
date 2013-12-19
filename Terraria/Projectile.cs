using System;
using TerrariaApi.Server;
namespace Terraria
{
	public class Projectile
	{
		public int numHits;
		public bool netImportant;
		public bool noDropItem;
		public bool wet;
		public bool honeyWet;
		public byte wetCount;
		public bool lavaWet;
		public int whoAmI;
		public static int maxAI = 2;
		public Vector2 position;
		public Vector2 lastPosition;
		public Vector2 velocity;
		public Vector2 lastVelocity;
		public int width;
		public int height;
		public float scale = 1f;
		public float rotation;
		public int type;
		public int alpha;
		public int owner = 255;
		public bool active;
		public string name = "";
		public float[] ai = new float[Projectile.maxAI];
		public float[] localAI = new float[Projectile.maxAI];
		public float gfxOffY;
		public float stepSpeed = 1f;
		public int aiStyle;
		public int timeLeft;
		public int soundDelay;
		public int damage;
		public int direction;
		public int spriteDirection = 1;
		public bool hostile;
		public float knockBack;
		public bool friendly;
		public int penetrate = 1;
		public int identity;
		public float light;
		public bool netUpdate;
		public bool netUpdate2;
		public int netSpam;
		public Vector2[] oldPos = new Vector2[10];
		public bool minion;
		public int minionPos;
		public int restrikeDelay;
		public bool tileCollide;
		public int maxUpdates;
		public int numUpdates;
		public bool ignoreWater;
		public bool hide;
		public bool ownerHitCheck;
		public int[] playerImmune = new int[255];
		public string miscText = "";
		public bool melee;
		public bool ranged;
		public bool magic;
		public int frameCounter;
		public int frame;
		public void SetDefaults(int Type)
		{
			this.numHits = 0;
			this.netImportant = false;
			for (int i = 0; i < this.oldPos.Length; i++)
			{
				this.oldPos[i].X = 0f;
				this.oldPos[i].Y = 0f;
			}
			for (int j = 0; j < Projectile.maxAI; j++)
			{
				this.ai[j] = 0f;
				this.localAI[j] = 0f;
			}
			for (int k = 0; k < 255; k++)
			{
				this.playerImmune[k] = 0;
			}
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
			this.wetCount = 0;
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
			this.light = 0f;
			this.penetrate = 1;
			this.tileCollide = true;
			this.position = default(Vector2);
			this.velocity = default(Vector2);
			this.aiStyle = 0;
			this.alpha = 0;
			this.type = Type;
			this.active = true;
			this.rotation = 0f;
			this.scale = 1f;
			this.owner = 255;
			this.timeLeft = 3600;
			this.name = "";
			this.friendly = false;
			this.damage = 0;
			this.knockBack = 0f;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.name = "Thorn Chakram";
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
				this.magic = true;
				this.penetrate = 4;
				this.friendly = true;
			}
			else if (this.type == 127)
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
			else if (this.type == 167 || this.type == 168 || this.type == 169 || this.type == 170)
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
				this.alpha = 255;
				this.friendly = true;
			}
			else if (this.type == 174)
			{
				this.name = "Ice Spike";
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
			}
			else if (this.type == 189)
			{
				this.name = "Wasp";
				this.width = 8;
				this.height = 8;
				this.aiStyle = 36;
				this.friendly = true;
				this.penetrate = 4;
				this.alpha = 255;
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
				this.alpha = 255;
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
				{
					this.scale = 1.025f;
				}
				if (this.type == 193)
				{
					this.scale = 1.05f;
				}
				if (this.type == 194)
				{
					this.scale = 1.075f;
				}
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.scale = 1f + (float)Main.rand.Next(30) * 0.01f;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
			else if (this.type == 255)
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
				this.name = "Frost Beam";
				this.ignoreWater = true;
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.hostile = true;
				this.penetrate = -1;
				this.light = 0.75f;
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
				this.name = "Seed";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 1;
				this.hostile = true;
			}
			else if (this.type == 276)
			{
				this.alpha = 255;
				this.name = "Poison Seed";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 1;
				this.hostile = true;
			}
			else if (this.type == 277)
			{
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
				this.magic = true;
				this.maxUpdates = 1;
			}
			else if (this.type == 298)
			{
				this.name = "Spirit Heal";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 52;
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
				this.tileCollide = false;
				this.maxUpdates = 10;
			}
			else if (this.type == 306)
			{
				this.name = "Eater's Bite";
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.alpha = 255;
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
				this.timeLeft = 420;
			}
			else if (this.type == 330)
			{
				this.name = "Star Anise";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 2;
				this.friendly = true;
				this.penetrate = 6;
				this.ranged = true;
			}
			else if (this.type == 331)
			{
				this.netImportant = true;
				this.name = "Candy Cane Hook";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 7;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.timeLeft *= 10;
			}
			else if (this.type == 332)
			{
				this.netImportant = true;
				this.name = "Christmas Hook";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 7;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.timeLeft *= 10;
				this.light = 0.5f;
			}
			else if (this.type == 333)
			{
				this.name = "Fruitcake Chakram";
				this.width = 38;
				this.height = 38;
				this.aiStyle = 3;
				this.friendly = true;
				this.scale = 0.9f;
				this.penetrate = -1;
				this.melee = true;
			}
			else if (this.type == 334)
			{
				this.netImportant = true;
				this.name = "Puppy";
				this.width = 28;
				this.height = 28;
				this.aiStyle = 26;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft *= 5;
			}
			else if (this.type == 335)
			{
				this.name = "Ornament";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 2;
				this.friendly = true;
				this.penetrate = 1;
				this.melee = true;
			}
			else if (this.type == 336)
			{
				this.name = "Pine Needle";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.magic = true;
				this.scale = 0.8f;
				this.maxUpdates = 1;
			}
			else if (this.type == 337)
			{
				this.name = "Blizzard";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.magic = true;
				this.maxUpdates = 1;
				this.tileCollide = false;
			}
			else if (this.type == 338 || this.type == 339 || this.type == 340 || this.type == 341)
			{
				this.name = "Rocket";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 16;
				this.penetrate = -1;
				this.friendly = true;
				this.ranged = true;
				this.scale = 0.9f;
			}
			else if (this.type == 342)
			{
				this.name = "North Pole";
				this.width = 22;
				this.height = 2;
				this.aiStyle = 19;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.scale = 1.1f;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 343)
			{
				this.alpha = 255;
				this.name = "North Pole";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 57;
				this.friendly = true;
				this.melee = true;
				this.scale = 1.1f;
				this.penetrate = -1;
			}
			else if (this.type == 344)
			{
				this.name = "North Pole";
				this.width = 26;
				this.height = 26;
				this.aiStyle = 1;
				this.friendly = true;
				this.scale = 0.9f;
				this.alpha = 255;
			}
			else if (this.type == 345)
			{
				this.name = "Pine Needle";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.hostile = true;
				this.scale = 0.8f;
			}
			else if (this.type == 346)
			{
				this.name = "Ornament";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 14;
				this.hostile = true;
				this.penetrate = -1;
				this.timeLeft = 300;
			}
			else if (this.type == 347)
			{
				this.name = "Ornament";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 2;
				this.hostile = true;
				this.penetrate = -1;
			}
			else if (this.type == 348)
			{
				this.name = "Frost Wave";
				this.aiStyle = 1;
				this.width = 48;
				this.height = 48;
				this.hostile = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.maxUpdates = 1;
			}
			else if (this.type == 349)
			{
				this.name = "Frost Shard";
				this.aiStyle = 1;
				this.width = 12;
				this.height = 12;
				this.hostile = true;
				this.penetrate = -1;
			}
			else if (this.type == 350)
			{
				this.alpha = 255;
				this.penetrate = -1;
				this.name = "Missile";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 1;
				this.hostile = true;
				this.tileCollide = false;
				this.timeLeft /= 2;
			}
			else if (this.type == 351)
			{
				this.alpha = 255;
				this.penetrate = -1;
				this.name = "Present";
				this.width = 24;
				this.height = 24;
				this.aiStyle = 58;
				this.hostile = true;
				this.tileCollide = false;
			}
			else if (this.type == 352)
			{
				this.name = "Spike";
				this.width = 30;
				this.height = 30;
				this.aiStyle = 14;
				this.hostile = true;
				this.penetrate = -1;
				this.timeLeft /= 3;
			}
			else if (this.type == 353)
			{
				this.netImportant = true;
				this.name = "Baby Grinch";
				this.width = 18;
				this.height = 28;
				this.aiStyle = 26;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft *= 5;
			}
			else
			{
				this.active = false;
			}
			this.width = (int)((float)this.width * this.scale);
			this.height = (int)((float)this.height * this.scale);
			ServerApi.Hooks.InvokeProjectileSetDefaults(ref Type, this);
		}
		public static int NewProjectile(float X, float Y, float SpeedX, float SpeedY, int Type, int Damage, float KnockBack, int Owner = 255, float ai0 = 0.0f, float ai1 = 0.0f)
		{
			int num = 1000;
			for (int i = 0; i < 1000; i++)
			{
				if (!Main.projectile[i].active)
				{
					num = i;
					break;
				}
			}
			if (num == 1000)
			{
				return num;
			}
			Main.projectile[num].SetDefaults(Type);
			Main.projectile[num].position.X = X - (float)Main.projectile[num].width * 0.5f;
			Main.projectile[num].position.Y = Y - (float)Main.projectile[num].height * 0.5f;
			Main.projectile[num].owner = Owner;
			Main.projectile[num].velocity.X = SpeedX;
			Main.projectile[num].velocity.Y = SpeedY;
			Main.projectile[num].damage = Damage;
			Main.projectile[num].knockBack = KnockBack;
			Main.projectile[num].identity = num;
			Main.projectile[num].gfxOffY = 0f;
			Main.projectile[num].stepSpeed = 1f;
			Main.projectile[num].wet = Collision.WetCollision(Main.projectile[num].position, Main.projectile[num].width, Main.projectile[num].height);
			if (Main.projectile[num].ignoreWater)
			{
				Main.projectile[num].wet = false;
			}
			Main.projectile[num].honeyWet = Collision.honey;
			if (Main.projectile[num].aiStyle == 1)
			{
				if ((double)Main.projectile[num].velocity.X > 15.9)
				{
					Main.projectile[num].velocity.X = 15.9f;
				}
				if ((double)Main.projectile[num].velocity.X < -15.9)
				{
					Main.projectile[num].velocity.X = -15.9f;
				}
				if ((double)Main.projectile[num].velocity.Y > 15.9)
				{
					Main.projectile[num].velocity.Y = 15.9f;
				}
				if ((double)Main.projectile[num].velocity.Y < -15.9)
				{
					Main.projectile[num].velocity.Y = -15.9f;
				}
			}
			if (Owner == Main.myPlayer)
			{
				if (Type == 206)
				{
					Main.projectile[num].ai[0] = (float)Main.rand.Next(-100, 101) * 0.0005f;
					Main.projectile[num].ai[1] = (float)Main.rand.Next(-100, 101) * 0.0005f;
				}
				else if (Type == 335)
				{
					Main.projectile[num].ai[1] = (float)Main.rand.Next(4);
				}
				else
				{
					Main.projectile[num].ai[0] = ai0;
					Main.projectile[num].ai[1] = ai1;
				}
			}
			if (Main.netMode != 0 && Owner == Main.myPlayer)
			{
				NetMessage.SendData(27, -1, -1, "", num, 0f, 0f, 0f, 0);
			}
			if (Owner == Main.myPlayer)
			{
				if (Type == 28)
				{
					Main.projectile[num].timeLeft = 180;
				}
				if (Type == 29)
				{
					Main.projectile[num].timeLeft = 300;
				}
				if (Type == 30)
				{
					Main.projectile[num].timeLeft = 180;
				}
				if (Type == 37)
				{
					Main.projectile[num].timeLeft = 180;
				}
				if (Type == 75)
				{
					Main.projectile[num].timeLeft = 180;
				}
				if (Type == 133)
				{
					Main.projectile[num].timeLeft = 180;
				}
				if (Type == 136)
				{
					Main.projectile[num].timeLeft = 180;
				}
				if (Type == 139)
				{
					Main.projectile[num].timeLeft = 180;
				}
				if (Type == 142)
				{
					Main.projectile[num].timeLeft = 180;
				}
			}
			if (Type == 249)
			{
				Main.projectile[num].frame = Main.rand.Next(5);
			}
			return num;
		}
		public void StatusNPC(int i)
		{
			if (this.melee && Main.player[this.owner].meleeEnchant > 0)
			{
				int meleeEnchant = (int)Main.player[this.owner].meleeEnchant;
				if (meleeEnchant == 1)
				{
					Main.npc[i].AddBuff(70, 60 * Main.rand.Next(5, 10), false);
				}
				if (meleeEnchant == 2)
				{
					Main.npc[i].AddBuff(39, 60 * Main.rand.Next(3, 7), false);
				}
				if (meleeEnchant == 3)
				{
					Main.npc[i].AddBuff(24, 60 * Main.rand.Next(3, 7), false);
				}
				if (meleeEnchant == 5)
				{
					Main.npc[i].AddBuff(69, 60 * Main.rand.Next(10, 20), false);
				}
				if (meleeEnchant == 6)
				{
					Main.npc[i].AddBuff(31, 60 * Main.rand.Next(1, 4), false);
				}
				if (meleeEnchant == 8)
				{
					Main.npc[i].AddBuff(20, 60 * Main.rand.Next(5, 10), false);
				}
				if (meleeEnchant == 4)
				{
					Main.npc[i].AddBuff(69, 120, false);
				}
			}
			if ((this.melee || this.ranged) && Main.player[this.owner].frostBurn)
			{
				Main.npc[i].AddBuff(44, 60 * Main.rand.Next(5, 15), false);
			}
			if (this.melee && Main.player[this.owner].magmaStone)
			{
				if (Main.rand.Next(7) == 0)
				{
					Main.npc[i].AddBuff(24, 360, false);
				}
				else if (Main.rand.Next(3) == 0)
				{
					Main.npc[i].AddBuff(24, 120, false);
				}
				else
				{
					Main.npc[i].AddBuff(24, 60, false);
				}
			}
			if (this.type == 295 || this.type == 296)
			{
				Main.npc[i].AddBuff(24, 60 * Main.rand.Next(8, 16), false);
			}
			if (this.type == 2 && Main.rand.Next(3) == 0)
			{
				Main.npc[i].AddBuff(24, 180, false);
			}
			if (this.type == 287)
			{
				Main.npc[i].AddBuff(72, 120, false);
			}
			if (this.type == 285)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.npc[i].AddBuff(31, 180, false);
				}
				else
				{
					Main.npc[i].AddBuff(31, 60, false);
				}
			}
			if (this.type == 172)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.npc[i].AddBuff(44, 240, false);
				}
			}
			else if (this.type == 15)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.npc[i].AddBuff(24, 300, false);
				}
			}
			else if (this.type == 253)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.npc[i].AddBuff(44, 600, false);
				}
			}
			else if (this.type == 19)
			{
				if (Main.rand.Next(5) == 0)
				{
					Main.npc[i].AddBuff(24, 180, false);
				}
			}
			else if (this.type == 33)
			{
				if (Main.rand.Next(5) == 0)
				{
					Main.npc[i].AddBuff(20, 420, false);
				}
			}
			else if (this.type == 34)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.npc[i].AddBuff(24, 240, false);
				}
			}
			else if (this.type == 35)
			{
				if (Main.rand.Next(4) == 0)
				{
					Main.npc[i].AddBuff(24, 180, false);
				}
			}
			else if (this.type == 54)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.npc[i].AddBuff(20, 600, false);
				}
			}
			else if (this.type == 267)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.npc[i].AddBuff(20, 3600, false);
				}
				else
				{
					Main.npc[i].AddBuff(20, 1800, false);
				}
			}
			else if (this.type == 63)
			{
				if (Main.rand.Next(3) != 0)
				{
					Main.npc[i].AddBuff(31, 120, false);
				}
			}
			else if (this.type == 85 || this.type == 188)
			{
				Main.npc[i].AddBuff(24, 1200, false);
			}
			else if (this.type == 95 || this.type == 103 || this.type == 104)
			{
				Main.npc[i].AddBuff(39, 420, false);
			}
			else if (this.type == 278 || this.type == 279 || this.type == 280)
			{
				Main.npc[i].AddBuff(69, 900, false);
			}
			else if (this.type == 282 || this.type == 283)
			{
				Main.npc[i].AddBuff(70, 600, false);
			}
			else if (this.type == 98)
			{
				Main.npc[i].AddBuff(20, 600, false);
			}
			else if (this.type == 184)
			{
				Main.npc[i].AddBuff(20, 900, false);
			}
			if (this.type != 163 && this.type != 310)
			{
				if (this.type == 265)
				{
					Main.npc[i].AddBuff(20, 3600, false);
				}
				return;
			}
			if (Main.rand.Next(3) == 0)
			{
				Main.npc[i].AddBuff(24, 600, false);
				return;
			}
			Main.npc[i].AddBuff(24, 300, false);
		}
		public void StatusPvP(int i)
		{
			if (this.melee && Main.player[this.owner].meleeEnchant > 0)
			{
				int meleeEnchant = (int)Main.player[this.owner].meleeEnchant;
				if (meleeEnchant == 1)
				{
					Main.player[i].AddBuff(70, 60 * Main.rand.Next(5, 10), true);
				}
				if (meleeEnchant == 2)
				{
					Main.player[i].AddBuff(39, 60 * Main.rand.Next(3, 7), true);
				}
				if (meleeEnchant == 3)
				{
					Main.player[i].AddBuff(24, 60 * Main.rand.Next(3, 7), true);
				}
				if (meleeEnchant == 5)
				{
					Main.player[i].AddBuff(69, 60 * Main.rand.Next(10, 20), true);
				}
				if (meleeEnchant == 6)
				{
					Main.player[i].AddBuff(31, 60 * Main.rand.Next(1, 4), true);
				}
				if (meleeEnchant == 8)
				{
					Main.player[i].AddBuff(20, 60 * Main.rand.Next(5, 10), true);
				}
			}
			if (this.type == 295 || this.type == 296)
			{
				Main.player[i].AddBuff(24, 60 * Main.rand.Next(8, 16), true);
			}
			if ((this.melee || this.ranged) && Main.player[this.owner].frostBurn)
			{
				Main.player[i].AddBuff(44, 60 * Main.rand.Next(1, 8), false);
			}
			if (this.melee && Main.player[this.owner].magmaStone)
			{
				if (Main.rand.Next(7) == 0)
				{
					Main.player[i].AddBuff(24, 360, true);
				}
				else if (Main.rand.Next(3) == 0)
				{
					Main.player[i].AddBuff(24, 120, true);
				}
				else
				{
					Main.player[i].AddBuff(24, 60, true);
				}
			}
			if (this.type == 2 && Main.rand.Next(3) == 0)
			{
				Main.player[i].AddBuff(24, 180, false);
			}
			if (this.type == 172)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.player[i].AddBuff(44, 240, false);
				}
			}
			else if (this.type == 15)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(24, 300, false);
				}
			}
			else if (this.type == 267)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.player[i].AddBuff(20, 3600, true);
				}
				else
				{
					Main.player[i].AddBuff(20, 1800, true);
				}
			}
			else if (this.type == 19)
			{
				if (Main.rand.Next(5) == 0)
				{
					Main.player[i].AddBuff(24, 180, false);
				}
			}
			else if (this.type == 33)
			{
				if (Main.rand.Next(5) == 0)
				{
					Main.player[i].AddBuff(20, 420, false);
				}
			}
			else if (this.type == 34)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(24, 240, false);
				}
			}
			else if (this.type == 35)
			{
				if (Main.rand.Next(4) == 0)
				{
					Main.player[i].AddBuff(24, 180, false);
				}
			}
			else if (this.type == 54)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(20, 600, false);
				}
			}
			else if (this.type == 63)
			{
				if (Main.rand.Next(3) != 0)
				{
					Main.player[i].AddBuff(31, 120, true);
				}
			}
			else if (this.type == 85 || this.type == 188)
			{
				Main.player[i].AddBuff(24, 1200, false);
			}
			else if (this.type == 95 || this.type == 103 || this.type == 104)
			{
				Main.player[i].AddBuff(39, 420, true);
			}
			else if (this.type == 278 || this.type == 279 || this.type == 280)
			{
				Main.player[i].AddBuff(69, 900, true);
			}
			else if (this.type == 282 || this.type == 283)
			{
				Main.player[i].AddBuff(70, 600, true);
			}
			if (this.type != 163 && this.type != 310)
			{
				if (this.type == 265)
				{
					Main.player[i].AddBuff(20, 1800, true);
				}
				return;
			}
			if (Main.rand.Next(3) == 0)
			{
				Main.player[i].AddBuff(24, 600, true);
				return;
			}
			Main.player[i].AddBuff(24, 300, true);
		}
		public void ghostHeal(int dmg, Vector2 Position)
		{
			float num = 0.08f;
			num -= (float)this.numHits * 0.02f;
			if (num <= 0f)
			{
				return;
			}
			float num2 = (float)dmg * num;
			if ((int)num2 <= 0)
			{
				return;
			}
			if (Main.player[Main.myPlayer].lifeSteal <= 0f)
			{
				return;
			}
			Main.player[Main.myPlayer].lifeSteal -= num2;
			if (!this.magic)
			{
				return;
			}
			float num3 = 0f;
			int num4 = this.owner;
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].active && !Main.player[i].dead && ((!Main.player[this.owner].hostile && !Main.player[i].hostile) || Main.player[this.owner].team == Main.player[i].team))
				{
					float num5 = Math.Abs(Main.player[i].position.X + (float)(Main.player[i].width / 2) - this.position.X + (float)(this.width / 2)) + Math.Abs(Main.player[i].position.Y + (float)(Main.player[i].height / 2) - this.position.Y + (float)(this.height / 2));
					if (num5 < 800f && (float)(Main.player[i].statLifeMax - Main.player[i].statLife) > num3)
					{
						num3 = (float)(Main.player[i].statLifeMax - Main.player[i].statLife);
						num4 = i;
					}
				}
			}
			Projectile.NewProjectile(Position.X, Position.Y, 0f, 0f, 298, 0, 0f, this.owner, (float)num4, num2);
		}
		public void vampireHeal(int dmg, Vector2 Position)
		{
			float num = (float)dmg * 0.075f;
			if ((int)num == 0)
			{
				return;
			}
			if (Main.player[Main.myPlayer].lifeSteal <= 0f)
			{
				return;
			}
			Main.player[Main.myPlayer].lifeSteal -= num;
			int num2 = this.owner;
			Projectile.NewProjectile(Position.X, Position.Y, 0f, 0f, 305, 0, 0f, this.owner, (float)num2, num);
		}
		public void StatusPlayer(int i)
		{
			if (this.type == 348)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(46, 600, true);
				}
				else
				{
					Main.player[i].AddBuff(46, 300, true);
				}
				if (Main.rand.Next(3) != 0)
				{
					if (Main.rand.Next(16) == 0)
					{
						Main.player[i].AddBuff(47, 60, true);
					}
					else if (Main.rand.Next(12) == 0)
					{
						Main.player[i].AddBuff(47, 40, true);
					}
					else if (Main.rand.Next(8) == 0)
					{
						Main.player[i].AddBuff(47, 20, true);
					}
				}
			}
			if (this.type == 349)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.player[i].AddBuff(46, 600, true);
				}
				else if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(46, 300, true);
				}
			}
			if (this.type == 55 && Main.rand.Next(3) == 0)
			{
				Main.player[i].AddBuff(20, 600, true);
			}
			if (this.type == 44 && Main.rand.Next(3) == 0)
			{
				Main.player[i].AddBuff(22, 900, true);
			}
			if (this.type == 293)
			{
				Main.player[i].AddBuff(80, 60 * Main.rand.Next(2, 7), true);
			}
			if (this.type == 82 && Main.rand.Next(3) == 0)
			{
				Main.player[i].AddBuff(24, 420, true);
			}
			if (this.type == 285)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.player[i].AddBuff(31, 180, true);
				}
				else
				{
					Main.player[i].AddBuff(31, 60, true);
				}
			}
			if (this.type == 96 || this.type == 101)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.player[i].AddBuff(39, 480, true);
				}
			}
			else if (this.type == 288)
			{
				Main.player[i].AddBuff(69, 900, true);
			}
			else if (this.type == 253 && Main.rand.Next(2) == 0)
			{
				Main.player[i].AddBuff(44, 600, true);
			}
			if (this.type == 291 || this.type == 292)
			{
				Main.player[i].AddBuff(24, 60 * Main.rand.Next(8, 16), true);
			}
			if (this.type == 98)
			{
				Main.player[i].AddBuff(20, 600, true);
			}
			if (this.type == 184)
			{
				Main.player[i].AddBuff(20, 900, true);
			}
			if (this.type == 290)
			{
				Main.player[i].AddBuff(32, 60 * Main.rand.Next(5, 16), true);
			}
			if (this.type == 174)
			{
				Main.player[i].AddBuff(46, 1200, true);
				if (!Main.player[i].frozen && Main.rand.Next(20) == 0)
				{
					Main.player[i].AddBuff(47, 90, true);
				}
			}
			if (this.type == 257)
			{
				Main.player[i].AddBuff(46, 2700, true);
				if (!Main.player[i].frozen && Main.rand.Next(5) == 0)
				{
					Main.player[i].AddBuff(47, 60, true);
				}
			}
			if (this.type == 177)
			{
				Main.player[i].AddBuff(46, 1500, true);
				if (!Main.player[i].frozen && Main.rand.Next(10) == 0)
				{
					Main.player[i].AddBuff(47, Main.rand.Next(30, 120), true);
				}
			}
			if (this.type == 176)
			{
				if (Main.rand.Next(4) == 0)
				{
					Main.player[i].AddBuff(20, 1200, true);
					return;
				}
				if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(20, 300, true);
				}
			}
		}
		public void Damage()
		{
			if (this.type == 18 || this.type == 72 || this.type == 86 || this.type == 87 || this.aiStyle == 31 || this.aiStyle == 32 || this.type == 226)
			{
				return;
			}
			if (Main.projPet[this.type] && this.type != 266 && this.type != 317)
			{
				return;
			}
			Rectangle rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
			if (this.type == 85 || this.type == 101)
			{
				int num = 30;
				rectangle.X -= num;
				rectangle.Y -= num;
				rectangle.Width += num * 2;
				rectangle.Height += num * 2;
			}
			if (this.type == 188)
			{
				int num2 = 20;
				rectangle.X -= num2;
				rectangle.Y -= num2;
				rectangle.Width += num2 * 2;
				rectangle.Height += num2 * 2;
			}
			if (this.aiStyle == 29)
			{
				int num3 = 4;
				rectangle.X -= num3;
				rectangle.Y -= num3;
				rectangle.Width += num3 * 2;
				rectangle.Height += num3 * 2;
			}
			if (this.friendly && this.owner == Main.myPlayer)
			{
				if (((this.aiStyle == 16 || this.type == 41) && this.type != 338 && this.type != 339 && this.type != 340 && this.type != 341 && (this.timeLeft <= 1 || this.type == 108 || this.type == 164)) || (this.type == 286 && this.localAI[1] == -1f))
				{
					int myPlayer = Main.myPlayer;
					if (Main.player[myPlayer].active && !Main.player[myPlayer].dead && !Main.player[myPlayer].immune && (!this.ownerHitCheck || Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, Main.player[myPlayer].position, Main.player[myPlayer].width, Main.player[myPlayer].height)))
					{
						Rectangle value = new Rectangle((int)Main.player[myPlayer].position.X, (int)Main.player[myPlayer].position.Y, Main.player[myPlayer].width, Main.player[myPlayer].height);
						if (rectangle.Intersects(value))
						{
							if (Main.player[myPlayer].position.X + (float)(Main.player[myPlayer].width / 2) < this.position.X + (float)(this.width / 2))
							{
								this.direction = -1;
							}
							else
							{
								this.direction = 1;
							}
							int num4 = Main.DamageVar((float)this.damage);
							this.StatusPlayer(myPlayer);
							Main.player[myPlayer].Hurt(num4, this.direction, true, false, Lang.deathMsg(this.owner, -1, this.whoAmI, -1), false);
							if (Main.netMode != 0)
							{
								NetMessage.SendData(26, -1, -1, Lang.deathMsg(this.owner, -1, this.whoAmI, -1), myPlayer, (float)this.direction, (float)num4, 1f, 0);
							}
						}
					}
				}
				if (this.type != 69 && this.type != 70 && this.type != 10 && this.type != 11 && this.aiStyle != 45)
				{
					int num5 = (int)(this.position.X / 16f);
					int num6 = (int)((this.position.X + (float)this.width) / 16f) + 1;
					int num7 = (int)(this.position.Y / 16f);
					int num8 = (int)((this.position.Y + (float)this.height) / 16f) + 1;
					if (num5 < 0)
					{
						num5 = 0;
					}
					if (num6 > Main.maxTilesX)
					{
						num6 = Main.maxTilesX;
					}
					if (num7 < 0)
					{
						num7 = 0;
					}
					if (num8 > Main.maxTilesY)
					{
						num8 = Main.maxTilesY;
					}
					for (int i = num5; i < num6; i++)
					{
						for (int j = num7; j < num8; j++)
						{
							if (Main.tile[i, j] != null && Main.tileCut[(int)Main.tile[i, j].type] && Main.tile[i, j + 1] != null && Main.tile[i, j + 1].type != 78)
							{
								WorldGen.KillTile(i, j, false, false, false);
								if (Main.netMode != 0)
								{
									NetMessage.SendData(17, -1, -1, "", 0, (float)i, (float)j, 0f, 0);
								}
							}
						}
					}
				}
			}
			if (this.owner == Main.myPlayer)
			{
				if (this.damage > 0)
				{
					for (int k = 0; k < 200; k++)
					{
						if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && (((!Main.npc[k].friendly || this.type == 318 || (Main.npc[k].type == 22 && this.owner < 255 && Main.player[this.owner].killGuide)) && this.friendly) || (Main.npc[k].friendly && this.hostile)) && (this.owner < 0 || Main.npc[k].immune[this.owner] == 0 || this.penetrate == 1))
						{
							bool flag = false;
							if (this.type == 11 && (Main.npc[k].type == 47 || Main.npc[k].type == 57))
							{
								flag = true;
							}
							else if (this.type == 31 && Main.npc[k].type == 69)
							{
								flag = true;
							}
							if (!flag && (Main.npc[k].noTileCollide || !this.ownerHitCheck || Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, Main.npc[k].position, Main.npc[k].width, Main.npc[k].height)))
							{
								Rectangle value2 = new Rectangle((int)Main.npc[k].position.X, (int)Main.npc[k].position.Y, Main.npc[k].width, Main.npc[k].height);
								if (rectangle.Intersects(value2))
								{
									if (this.aiStyle == 3 && this.type != 301)
									{
										if (this.ai[0] == 0f)
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
										{
											this.timeLeft = 3;
										}
										if (Main.npc[k].position.X + (float)(Main.npc[k].width / 2) < this.position.X + (float)(this.width / 2))
										{
											this.direction = -1;
										}
										else
										{
											this.direction = 1;
										}
									}
									else if (this.aiStyle == 50)
									{
										if (Main.npc[k].position.X + (float)(Main.npc[k].width / 2) < this.position.X + (float)(this.width / 2))
										{
											this.direction = -1;
										}
										else
										{
											this.direction = 1;
										}
									}
									if (this.aiStyle == 39)
									{
										if (this.ai[1] == 0f)
										{
											this.ai[1] = (float)(k + 1);
											this.netUpdate = true;
										}
										if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) < this.position.X + (float)(this.width / 2))
										{
											this.direction = 1;
										}
										else
										{
											this.direction = -1;
										}
									}
									if (this.type == 41 && this.timeLeft > 1)
									{
										this.timeLeft = 1;
									}
									bool flag2 = false;
									if (this.melee && Main.rand.Next(1, 101) <= Main.player[this.owner].meleeCrit)
									{
										flag2 = true;
									}
									if (this.ranged && Main.rand.Next(1, 101) <= Main.player[this.owner].rangedCrit)
									{
										flag2 = true;
									}
									if (this.magic && Main.rand.Next(1, 101) <= Main.player[this.owner].magicCrit)
									{
										flag2 = true;
									}
									int num9 = Main.DamageVar((float)this.damage);
									if (this.type == 323 && (Main.npc[k].type == 158 || Main.npc[k].type == 159))
									{
										num9 *= 10;
									}
									if (this.type == 294)
									{
										this.damage = (int)((double)this.damage * 0.8);
									}
									if (this.type == 261)
									{
										float num10 = (float)Math.Sqrt((double)(this.velocity.X * this.velocity.X + this.velocity.Y * this.velocity.Y));
										if (num10 < 1f)
										{
											num10 = 1f;
										}
										num9 = (int)((float)num9 * num10 / 8f);
									}
									this.StatusNPC(k);
									if (this.type != 221 && this.type != 227)
									{
										Main.player[this.owner].onHit(Main.npc[k].center().X, Main.npc[k].center().Y);
									}
									if (this.type == 317)
									{
										this.ai[1] = -1f;
										this.netUpdate = true;
									}
									int num11 = (int)Main.npc[k].StrikeNPC(num9, this.knockBack, this.direction, flag2, false);
									if (num11 > 0 && Main.npc[k].lifeMax > 5 && Main.player[this.owner].ghostHeal)
									{
										this.ghostHeal(num11, new Vector2(Main.npc[k].center().X, Main.npc[k].center().Y));
									}
									if (this.type == 304 && num11 > 0 && Main.npc[k].lifeMax > 5)
									{
										this.vampireHeal(num11, new Vector2(Main.npc[k].center().X, Main.npc[k].center().Y));
									}
									if (this.melee && Main.player[this.owner].meleeEnchant == 7)
									{
										Projectile.NewProjectile(Main.npc[k].center().X, Main.npc[k].center().Y, Main.npc[k].velocity.X, Main.npc[k].velocity.Y, 289, 0, 0f, this.owner, 0f, 0f);
									}
									if (Main.npc[k].value > 0f && Main.player[this.owner].coins && Main.rand.Next(5) == 0)
									{
										int num12 = 71;
										if (Main.rand.Next(10) == 0)
										{
											num12 = 72;
										}
										if (Main.rand.Next(100) == 0)
										{
											num12 = 73;
										}
										int num13 = Item.NewItem((int)Main.npc[k].position.X, (int)Main.npc[k].position.Y, Main.npc[k].width, Main.npc[k].height, num12, 1, false, 0, false);
										Main.item[num13].stack = Main.rand.Next(1, 11);
										Main.item[num13].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
										Main.item[num13].velocity.X = (float)Main.rand.Next(10, 31) * 0.2f * (float)this.direction;
										if (Main.netMode == 1)
										{
											NetMessage.SendData(21, -1, -1, "", num13, 0f, 0f, 0f, 0);
										}
									}
									if (Main.netMode != 0)
									{
										if (flag2)
										{
											NetMessage.SendData(28, -1, -1, "", k, (float)num9, this.knockBack, (float)this.direction, 1);
										}
										else
										{
											NetMessage.SendData(28, -1, -1, "", k, (float)num9, this.knockBack, (float)this.direction, 0);
										}
									}
									if (this.type == 286)
									{
										Main.npc[k].immune[this.owner] = 5;
									}
									else if (this.type == 190)
									{
										Main.npc[k].immune[this.owner] = 8;
									}
									else if (this.type == 311)
									{
										Main.npc[k].immune[this.owner] = 7;
									}
									else if (this.penetrate != 1)
									{
										Main.npc[k].immune[this.owner] = 10;
									}
									if (this.penetrate > 0 && this.type != 317)
									{
										this.penetrate--;
										if (this.penetrate == 0)
										{
											break;
										}
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
									this.numHits++;
								}
							}
						}
					}
				}
				if (this.damage > 0 && Main.player[Main.myPlayer].hostile)
				{
					for (int l = 0; l < 255; l++)
					{
						if (l != this.owner && Main.player[l].active && !Main.player[l].dead && !Main.player[l].immune && Main.player[l].hostile && this.playerImmune[l] <= 0 && (Main.player[Main.myPlayer].team == 0 || Main.player[Main.myPlayer].team != Main.player[l].team) && (!this.ownerHitCheck || Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, Main.player[l].position, Main.player[l].width, Main.player[l].height)))
						{
							Rectangle value3 = new Rectangle((int)Main.player[l].position.X, (int)Main.player[l].position.Y, Main.player[l].width, Main.player[l].height);
							if (rectangle.Intersects(value3))
							{
								if (this.aiStyle == 3)
								{
									if (this.ai[0] == 0f)
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
									{
										this.timeLeft = 3;
									}
									if (Main.player[l].position.X + (float)(Main.player[l].width / 2) < this.position.X + (float)(this.width / 2))
									{
										this.direction = -1;
									}
									else
									{
										this.direction = 1;
									}
								}
								if (this.type == 41 && this.timeLeft > 1)
								{
									this.timeLeft = 1;
								}
								bool flag3 = false;
								if (this.melee && Main.rand.Next(1, 101) <= Main.player[this.owner].meleeCrit)
								{
									flag3 = true;
								}
								int num14 = Main.DamageVar((float)this.damage);
								if (!Main.player[l].immune)
								{
									this.StatusPvP(l);
								}
								if (this.type != 221 && this.type != 227)
								{
									Main.player[this.owner].onHit(Main.player[l].center().X, Main.player[l].center().Y);
								}
								int num15 = (int)Main.player[l].Hurt(num14, this.direction, true, false, Lang.deathMsg(this.owner, -1, this.whoAmI, -1), flag3);
								if (num15 > 0 && Main.player[this.owner].ghostHeal)
								{
									this.ghostHeal(num15, new Vector2(Main.player[l].center().X, Main.player[l].center().Y));
								}
								if (this.type == 304 && num15 > 0)
								{
									this.vampireHeal(num15, new Vector2(Main.player[l].center().X, Main.player[l].center().Y));
								}
								if (this.melee && Main.player[this.owner].meleeEnchant == 7)
								{
									Projectile.NewProjectile(Main.player[l].center().X, Main.player[l].center().Y, Main.player[l].velocity.X, Main.player[l].velocity.Y, 289, 0, 0f, this.owner, 0f, 0f);
								}
								if (Main.netMode != 0)
								{
									if (flag3)
									{
										NetMessage.SendData(26, -1, -1, Lang.deathMsg(this.owner, -1, this.whoAmI, -1), l, (float)this.direction, (float)num14, 1f, 1);
									}
									else
									{
										NetMessage.SendData(26, -1, -1, Lang.deathMsg(this.owner, -1, this.whoAmI, -1), l, (float)this.direction, (float)num14, 1f, 0);
									}
								}
								this.playerImmune[l] = 40;
								if (this.penetrate > 0)
								{
									this.penetrate--;
									if (this.penetrate == 0)
									{
										break;
									}
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
				for (int m = 0; m < 200; m++)
				{
					if (Main.npc[m].active)
					{
						if (Main.npc[m].type == 46)
						{
							Rectangle value4 = new Rectangle((int)Main.npc[m].position.X, (int)Main.npc[m].position.Y, Main.npc[m].width, Main.npc[m].height);
							if (rectangle.Intersects(value4))
							{
								Main.npc[m].Transform(47);
							}
						}
						else if (Main.npc[m].type == 55)
						{
							Rectangle value5 = new Rectangle((int)Main.npc[m].position.X, (int)Main.npc[m].position.Y, Main.npc[m].width, Main.npc[m].height);
							if (rectangle.Intersects(value5))
							{
								Main.npc[m].Transform(57);
							}
						}
					}
				}
			}
			if (Main.netMode != 2 && this.hostile && Main.myPlayer < 255 && this.damage > 0)
			{
				int myPlayer2 = Main.myPlayer;
				if (Main.player[myPlayer2].active && !Main.player[myPlayer2].dead && !Main.player[myPlayer2].immune)
				{
					Rectangle value6 = new Rectangle((int)Main.player[myPlayer2].position.X, (int)Main.player[myPlayer2].position.Y, Main.player[myPlayer2].width, Main.player[myPlayer2].height);
					if (rectangle.Intersects(value6))
					{
						int hitDirection = this.direction;
						if (Main.player[myPlayer2].position.X + (float)(Main.player[myPlayer2].width / 2) < this.position.X + (float)(this.width / 2))
						{
							hitDirection = -1;
						}
						else
						{
							hitDirection = 1;
						}
						int num16 = Main.DamageVar((float)this.damage);
						if (!Main.player[myPlayer2].immune)
						{
							this.StatusPlayer(myPlayer2);
						}
						Main.player[myPlayer2].Hurt(num16 * 2, hitDirection, false, false, Lang.deathMsg(-1, -1, this.whoAmI, -1), false);
					}
				}
			}
		}
		public void ProjLight()
		{
			if (this.light > 0f)
			{
				float num = this.light;
				float num2 = this.light;
				float num3 = this.light;
				if (this.type == 332)
				{
					num3 *= 0.1f;
					num2 *= 0.6f;
				}
				else if (this.type == 259)
				{
					num3 *= 0.1f;
				}
				else if (this.type == 329)
				{
					num3 *= 0.1f;
					num2 *= 0.9f;
				}
				else if (this.type == 2 || this.type == 82)
				{
					num2 *= 0.75f;
					num3 *= 0.55f;
				}
				else if (this.type == 172)
				{
					num2 *= 0.55f;
					num *= 0.35f;
				}
				else if (this.type == 308)
				{
					num2 *= 0.7f;
					num *= 0.1f;
				}
				else if (this.type == 304)
				{
					num2 *= 0.2f;
					num3 *= 0.1f;
				}
				else if (this.type == 263)
				{
					num2 *= 0.7f;
					num *= 0.1f;
				}
				else if (this.type == 274)
				{
					num2 *= 0.1f;
					num *= 0.7f;
				}
				else if (this.type == 254)
				{
					num *= 0.1f;
				}
				else if (this.type == 94)
				{
					num *= 0.5f;
					num2 *= 0f;
				}
				else if (this.type == 95 || this.type == 96 || this.type == 103 || this.type == 104)
				{
					num *= 0.35f;
					num2 *= 1f;
					num3 *= 0f;
				}
				else if (this.type == 4)
				{
					num2 *= 0.1f;
					num *= 0.5f;
				}
				else if (this.type == 257)
				{
					num2 *= 0.9f;
					num *= 0.1f;
				}
				else if (this.type == 9)
				{
					num2 *= 0.1f;
					num3 *= 0.6f;
				}
				else if (this.type == 92)
				{
					num2 *= 0.6f;
					num *= 0.8f;
				}
				else if (this.type == 93)
				{
					num2 *= 1f;
					num *= 1f;
					num3 *= 0.01f;
				}
				else if (this.type == 12)
				{
					num *= 0.9f;
					num2 *= 0.8f;
					num3 *= 0.1f;
				}
				else if (this.type == 14 || this.type == 110 || this.type == 180 || this.type == 242 || this.type == 302)
				{
					num2 *= 0.7f;
					num3 *= 0.1f;
				}
				else if (this.type == 15)
				{
					num2 *= 0.4f;
					num3 *= 0.1f;
					num = 1f;
				}
				else if (this.type == 16)
				{
					num *= 0.1f;
					num2 *= 0.4f;
					num3 = 1f;
				}
				else if (this.type == 18)
				{
					num2 *= 0.1f;
					num *= 0.6f;
				}
				else if (this.type == 19)
				{
					num2 *= 0.5f;
					num3 *= 0.1f;
				}
				else if (this.type == 20)
				{
					num *= 0.1f;
					num3 *= 0.3f;
				}
				else if (this.type == 22)
				{
					num = 0f;
					num2 = 0f;
				}
				else if (this.type == 27)
				{
					num *= 0f;
					num2 *= 0.3f;
					num3 = 1f;
				}
				else if (this.type == 34)
				{
					num2 *= 0.1f;
					num3 *= 0.1f;
				}
				else if (this.type == 36)
				{
					num = 0.8f;
					num2 *= 0.2f;
					num3 *= 0.6f;
				}
				else if (this.type == 41)
				{
					num2 *= 0.8f;
					num3 *= 0.6f;
				}
				else if (this.type == 44 || this.type == 45)
				{
					num3 = 1f;
					num *= 0.6f;
					num2 *= 0.1f;
				}
				else if (this.type == 50)
				{
					num *= 0.7f;
					num3 *= 0.8f;
				}
				else if (this.type == 53)
				{
					num *= 0.7f;
					num2 *= 0.8f;
				}
				else if (this.type == 72)
				{
					num *= 0.45f;
					num2 *= 0.75f;
					num3 = 1f;
				}
				else if (this.type == 86)
				{
					num *= 1f;
					num2 *= 0.45f;
					num3 = 0.75f;
				}
				else if (this.type == 87)
				{
					num *= 0.45f;
					num2 = 1f;
					num3 *= 0.75f;
				}
				else if (this.type == 73)
				{
					num *= 0.4f;
					num2 *= 0.6f;
					num3 *= 1f;
				}
				else if (this.type == 74)
				{
					num *= 1f;
					num2 *= 0.4f;
					num3 *= 0.6f;
				}
				else if (this.type == 284)
				{
					num *= 1f;
					num2 *= 0.1f;
					num3 *= 0.8f;
				}
				else if (this.type == 285)
				{
					num *= 0.1f;
					num2 *= 0.5f;
					num3 *= 1f;
				}
				else if (this.type == 286)
				{
					num *= 1f;
					num2 *= 0.5f;
					num3 *= 0.1f;
				}
				else if (this.type == 287)
				{
					num *= 0.9f;
					num2 *= 1f;
					num3 *= 0.4f;
				}
				else if (this.type == 283)
				{
					num *= 0.8f;
					num2 *= 0.1f;
				}
				else if (this.type == 76 || this.type == 77 || this.type == 78)
				{
					num *= 1f;
					num2 *= 0.3f;
					num3 *= 0.6f;
				}
				else if (this.type == 79)
				{
					num = (float)Main.DiscoR / 255f;
					num2 = (float)Main.DiscoG / 255f;
					num3 = (float)Main.DiscoB / 255f;
				}
				else if (this.type == 80)
				{
					num *= 0f;
					num2 *= 0.8f;
					num3 *= 1f;
				}
				else if (this.type == 83 || this.type == 88)
				{
					num *= 0.7f;
					num2 *= 0f;
					num3 *= 1f;
				}
				else if (this.type == 100)
				{
					num *= 1f;
					num2 *= 0.5f;
					num3 *= 0f;
				}
				else if (this.type == 84)
				{
					num *= 0.8f;
					num2 *= 0f;
					num3 *= 0.5f;
				}
				else if (this.type == 89 || this.type == 90)
				{
					num2 *= 0.2f;
					num3 *= 1f;
					num *= 0.05f;
				}
				else if (this.type == 106)
				{
					num *= 0f;
					num2 *= 0.5f;
					num3 *= 1f;
				}
				else if (this.type == 113)
				{
					num *= 0.25f;
					num2 *= 0.75f;
					num3 *= 1f;
				}
				else if (this.type == 114 || this.type == 115)
				{
					num *= 0.5f;
					num2 *= 0.05f;
					num3 *= 1f;
				}
				else if (this.type == 116)
				{
					num3 *= 0.25f;
				}
				else if (this.type == 131)
				{
					num *= 0.1f;
					num2 *= 0.4f;
				}
				else if (this.type == 132 || this.type == 157)
				{
					num *= 0.2f;
					num3 *= 0.6f;
				}
				else if (this.type == 156)
				{
					num *= 1f;
					num3 *= 0.6f;
					num2 = 0f;
				}
				else if (this.type == 173)
				{
					num *= 0.3f;
					num3 *= 1f;
					num2 = 0.4f;
				}
				else if (this.type == 207)
				{
					num *= 0.4f;
					num3 *= 0.4f;
				}
				else if (this.type == 253)
				{
					num = 0f;
					num2 *= 0.4f;
				}
				else if (this.type == 211)
				{
					num *= 0.5f;
					num2 *= 0.9f;
					num3 *= 1f;
					if (this.localAI[0] == 0f)
					{
						this.light = 1.5f;
					}
					else
					{
						this.light = 1f;
					}
				}
				else if (this.type == 209)
				{
					float num4 = (255f - (float)this.alpha) / 255f;
					num *= 0.3f;
					num2 *= 0.4f;
					num3 *= 1.75f;
					num3 *= num4;
					num *= num4;
					num2 *= num4;
				}
				else if (this.type == 226 || (this.type == 227 | this.type == 229))
				{
					num *= 0.25f;
					num2 *= 1f;
					num3 *= 0.5f;
				}
				else if (this.type == 251)
				{
					num = (float)Main.DiscoR / 255f;
					num2 = (float)Main.DiscoG / 255f;
					num3 = (float)Main.DiscoB / 255f;
					num = (num + 1f) / 2f;
					num2 = (num2 + 1f) / 2f;
					num3 = (num3 + 1f) / 2f;
					num *= this.light;
					num2 *= this.light;
					num3 *= this.light;
				}
				else if (this.type == 278 || this.type == 279)
				{
					num *= 1f;
					num2 *= 1f;
					num3 *= 0f;
				}
			}
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
			if (this.active)
			{
				if (Main.player[this.owner].frostBurn && (this.melee || this.ranged) && this.friendly && !this.hostile && Main.rand.Next(2 * (1 + this.maxUpdates)) == 0)
				{
					int num = Dust.NewDust(this.position, this.width, this.height, 135, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2f);
					Main.dust[num].noGravity = true;
					Main.dust[num].velocity *= 0.7f;
					Dust expr_F2_cp_0 = Main.dust[num];
					expr_F2_cp_0.velocity.Y = expr_F2_cp_0.velocity.Y - 0.5f;
				}
				if (this.melee && Main.player[this.owner].meleeEnchant > 0)
				{
					if (Main.player[this.owner].meleeEnchant == 1 && Main.rand.Next(3) == 0)
					{
						int num2 = Dust.NewDust(this.position, this.width, this.height, 171, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num2].noGravity = true;
						Main.dust[num2].fadeIn = 1.5f;
						Main.dust[num2].velocity *= 0.25f;
					}
					if (Main.player[this.owner].meleeEnchant == 1)
					{
						if (Main.rand.Next(3) == 0)
						{
							int num3 = Dust.NewDust(this.position, this.width, this.height, 171, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num3].noGravity = true;
							Main.dust[num3].fadeIn = 1.5f;
							Main.dust[num3].velocity *= 0.25f;
						}
					}
					else if (Main.player[this.owner].meleeEnchant == 2)
					{
						if (Main.rand.Next(2) == 0)
						{
							int num4 = Dust.NewDust(this.position, this.width, this.height, 75, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
							Main.dust[num4].noGravity = true;
							Main.dust[num4].velocity *= 0.7f;
							Dust expr_309_cp_0 = Main.dust[num4];
							expr_309_cp_0.velocity.Y = expr_309_cp_0.velocity.Y - 0.5f;
						}
					}
					else if (Main.player[this.owner].meleeEnchant == 3)
					{
						if (Main.rand.Next(2) == 0)
						{
							int num5 = Dust.NewDust(this.position, this.width, this.height, 6, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
							Main.dust[num5].noGravity = true;
							Main.dust[num5].velocity *= 0.7f;
							Dust expr_3D5_cp_0 = Main.dust[num5];
							expr_3D5_cp_0.velocity.Y = expr_3D5_cp_0.velocity.Y - 0.5f;
						}
					}
					else if (Main.player[this.owner].meleeEnchant == 4)
					{
						if (Main.rand.Next(2) == 0)
						{
							int num6 = Dust.NewDust(this.position, this.width, this.height, 57, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.1f);
							Main.dust[num6].noGravity = true;
							Dust expr_488_cp_0 = Main.dust[num6];
							expr_488_cp_0.velocity.X = expr_488_cp_0.velocity.X / 2f;
							Dust expr_4A6_cp_0 = Main.dust[num6];
							expr_4A6_cp_0.velocity.Y = expr_4A6_cp_0.velocity.Y / 2f;
						}
					}
					else if (Main.player[this.owner].meleeEnchant == 5)
					{
						if (Main.rand.Next(2) == 0)
						{
							int num7 = Dust.NewDust(this.position, this.width, this.height, 169, 0f, 0f, 100, default(Color), 1f);
							Dust expr_529_cp_0 = Main.dust[num7];
							expr_529_cp_0.velocity.X = expr_529_cp_0.velocity.X + (float)this.direction;
							Dust expr_549_cp_0 = Main.dust[num7];
							expr_549_cp_0.velocity.Y = expr_549_cp_0.velocity.Y + 0.2f;
							Main.dust[num7].noGravity = true;
						}
					}
					else if (Main.player[this.owner].meleeEnchant == 6)
					{
						if (Main.rand.Next(2) == 0)
						{
							int num8 = Dust.NewDust(this.position, this.width, this.height, 135, 0f, 0f, 100, default(Color), 1f);
							Dust expr_5DA_cp_0 = Main.dust[num8];
							expr_5DA_cp_0.velocity.X = expr_5DA_cp_0.velocity.X + (float)this.direction;
							Dust expr_5FA_cp_0 = Main.dust[num8];
							expr_5FA_cp_0.velocity.Y = expr_5FA_cp_0.velocity.Y + 0.2f;
							Main.dust[num8].noGravity = true;
						}
					}
					else if (Main.player[this.owner].meleeEnchant == 7)
					{
						if (Main.rand.Next(20) == 0)
						{
							int num9 = Main.rand.Next(139, 143);
							int num10 = Dust.NewDust(this.position, this.width, this.height, num9, this.velocity.X, this.velocity.Y, 0, default(Color), 1.2f);
							Dust expr_6AA_cp_0 = Main.dust[num10];
							expr_6AA_cp_0.velocity.X = expr_6AA_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
							Dust expr_6DE_cp_0 = Main.dust[num10];
							expr_6DE_cp_0.velocity.Y = expr_6DE_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
							Dust expr_712_cp_0 = Main.dust[num10];
							expr_712_cp_0.velocity.X = expr_712_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
							Dust expr_740_cp_0 = Main.dust[num10];
							expr_740_cp_0.velocity.Y = expr_740_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
							Main.dust[num10].scale *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
						}
						if (Main.rand.Next(40) == 0)
						{
							int num11 = Main.rand.Next(276, 283);
							int num12 = Gore.NewGore(this.position, this.velocity, num11, 1f);
							Gore expr_7DE_cp_0 = Main.gore[num12];
							expr_7DE_cp_0.velocity.X = expr_7DE_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
							Gore expr_812_cp_0 = Main.gore[num12];
							expr_812_cp_0.velocity.Y = expr_812_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
							Main.gore[num12].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
							Gore expr_875_cp_0 = Main.gore[num12];
							expr_875_cp_0.velocity.X = expr_875_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
							Gore expr_8A3_cp_0 = Main.gore[num12];
							expr_8A3_cp_0.velocity.Y = expr_8A3_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
						}
					}
					else if (Main.player[this.owner].meleeEnchant == 8 && Main.rand.Next(4) == 0)
					{
						int num13 = Dust.NewDust(this.position, this.width, this.height, 46, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num13].noGravity = true;
						Main.dust[num13].fadeIn = 1.5f;
						Main.dust[num13].velocity *= 0.25f;
					}
				}
				if (this.melee && Main.player[this.owner].magmaStone && Main.rand.Next(3) != 0)
				{
					int num14 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y - 4f), this.width + 8, this.height + 8, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 2f);
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num14].scale = 1.5f;
					}
					Main.dust[num14].noGravity = true;
					Dust expr_A3D_cp_0 = Main.dust[num14];
					expr_A3D_cp_0.velocity.X = expr_A3D_cp_0.velocity.X * 2f;
					Dust expr_A5B_cp_0 = Main.dust[num14];
					expr_A5B_cp_0.velocity.Y = expr_A5B_cp_0.velocity.Y * 2f;
				}
				if (this.minion)
				{
					this.minionPos = Main.player[this.owner].numMinions;
					if (this.minionPos >= Main.player[this.owner].maxMinions)
					{
						this.Kill();
					}
					Main.player[this.owner].numMinions++;
				}
				this.lastVelocity = this.velocity;
				float num15 = 1f + Math.Abs(this.velocity.X) / 3f;
				if (this.gfxOffY > 0f)
				{
					this.gfxOffY -= num15 * this.stepSpeed;
					if (this.gfxOffY < 0f)
					{
						this.gfxOffY = 0f;
					}
				}
				else if (this.gfxOffY < 0f)
				{
					this.gfxOffY += num15 * this.stepSpeed;
					if (this.gfxOffY > 0f)
					{
						this.gfxOffY = 0f;
					}
				}
				if (this.gfxOffY > 16f)
				{
					this.gfxOffY = 16f;
				}
				if (this.gfxOffY < -16f)
				{
					this.gfxOffY = -16f;
				}
				Vector2 value = this.velocity;
				if (this.position.X <= Main.leftWorld || this.position.X + (float)this.width >= Main.rightWorld || this.position.Y <= Main.topWorld || this.position.Y + (float)this.height >= Main.bottomWorld)
				{
					this.active = false;
					return;
				}
				this.whoAmI = i;
				if (this.soundDelay > 0)
				{
					this.soundDelay--;
				}
				this.netUpdate = false;
				for (int j = 0; j < 255; j++)
				{
					if (this.playerImmune[j] > 0)
					{
						this.playerImmune[j]--;
					}
				}
				this.AI();
				if (this.owner < 255 && !Main.player[this.owner].active)
				{
					this.Kill();
				}
				if (this.type == 242 || this.type == 302)
				{
					this.wet = false;
				}
				if (!this.ignoreWater)
				{
					bool flag;
					bool flag2;
					try
					{
						flag = Collision.LavaCollision(this.position, this.width, this.height);
						flag2 = Collision.WetCollision(this.position, this.width, this.height);
						if (flag)
						{
							this.lavaWet = true;
						}
						if (Collision.honey)
						{
							this.honeyWet = true;
						}
					}
					catch
					{
						this.active = false;
						return;
					}
					if (this.wet && !this.lavaWet)
					{
						if (this.type == 85 || this.type == 15 || this.type == 34 || this.type == 188)
						{
							this.Kill();
						}
						if (this.type == 2)
						{
							this.type = 1;
							this.light = 0f;
						}
					}
					if (this.type == 80)
					{
						flag2 = false;
						this.wet = false;
						if (flag && this.ai[0] >= 0f)
						{
							this.Kill();
						}
					}
					if (flag2)
					{
						if (this.type != 155 && this.wetCount == 0 && !this.wet)
						{
							if (!flag)
							{
								if (this.honeyWet)
								{
									for (int k = 0; k < 10; k++)
									{
										int num16 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 152, 0f, 0f, 0, default(Color), 1f);
										Dust expr_E4D_cp_0 = Main.dust[num16];
										expr_E4D_cp_0.velocity.Y = expr_E4D_cp_0.velocity.Y - 1f;
										Dust expr_E6B_cp_0 = Main.dust[num16];
										expr_E6B_cp_0.velocity.X = expr_E6B_cp_0.velocity.X * 2.5f;
										Main.dust[num16].scale = 1.3f;
										Main.dust[num16].alpha = 100;
										Main.dust[num16].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
								else
								{
									for (int l = 0; l < 10; l++)
									{
										int num17 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, Dust.dustWater(), 0f, 0f, 0, default(Color), 1f);
										Dust expr_F56_cp_0 = Main.dust[num17];
										expr_F56_cp_0.velocity.Y = expr_F56_cp_0.velocity.Y - 4f;
										Dust expr_F74_cp_0 = Main.dust[num17];
										expr_F74_cp_0.velocity.X = expr_F74_cp_0.velocity.X * 2.5f;
										Main.dust[num17].scale = 1.3f;
										Main.dust[num17].alpha = 100;
										Main.dust[num17].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
							}
							else
							{
								for (int m = 0; m < 10; m++)
								{
									int num18 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 35, 0f, 0f, 0, default(Color), 1f);
									Dust expr_105C_cp_0 = Main.dust[num18];
									expr_105C_cp_0.velocity.Y = expr_105C_cp_0.velocity.Y - 1.5f;
									Dust expr_107A_cp_0 = Main.dust[num18];
									expr_107A_cp_0.velocity.X = expr_107A_cp_0.velocity.X * 2.5f;
									Main.dust[num18].scale = 1.3f;
									Main.dust[num18].alpha = 100;
									Main.dust[num18].noGravity = true;
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
						{
							this.velocity.Y = this.velocity.Y * 0.5f;
						}
						else if (this.wetCount == 0)
						{
							this.wetCount = 10;
							if (!this.lavaWet)
							{
								if (this.honeyWet)
								{
									for (int n = 0; n < 10; n++)
									{
										int num19 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 152, 0f, 0f, 0, default(Color), 1f);
										Dust expr_11D0_cp_0 = Main.dust[num19];
										expr_11D0_cp_0.velocity.Y = expr_11D0_cp_0.velocity.Y - 1f;
										Dust expr_11EE_cp_0 = Main.dust[num19];
										expr_11EE_cp_0.velocity.X = expr_11EE_cp_0.velocity.X * 2.5f;
										Main.dust[num19].scale = 1.3f;
										Main.dust[num19].alpha = 100;
										Main.dust[num19].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
								else
								{
									for (int num20 = 0; num20 < 10; num20++)
									{
										int num21 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2)), this.width + 12, 24, Dust.dustWater(), 0f, 0f, 0, default(Color), 1f);
										Dust expr_12D3_cp_0 = Main.dust[num21];
										expr_12D3_cp_0.velocity.Y = expr_12D3_cp_0.velocity.Y - 4f;
										Dust expr_12F1_cp_0 = Main.dust[num21];
										expr_12F1_cp_0.velocity.X = expr_12F1_cp_0.velocity.X * 2.5f;
										Main.dust[num21].scale = 1.3f;
										Main.dust[num21].alpha = 100;
										Main.dust[num21].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
							}
							else
							{
								for (int num22 = 0; num22 < 10; num22++)
								{
									int num23 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 35, 0f, 0f, 0, default(Color), 1f);
									Dust expr_13D9_cp_0 = Main.dust[num23];
									expr_13D9_cp_0.velocity.Y = expr_13D9_cp_0.velocity.Y - 1.5f;
									Dust expr_13F7_cp_0 = Main.dust[num23];
									expr_13F7_cp_0.velocity.X = expr_13F7_cp_0.velocity.X * 2.5f;
									Main.dust[num23].scale = 1.3f;
									Main.dust[num23].alpha = 100;
									Main.dust[num23].noGravity = true;
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
					if (this.wetCount > 0)
					{
						this.wetCount -= 1;
					}
				}
				this.lastPosition = this.position;
				bool flag3 = false;
				if (this.tileCollide)
				{
					Vector2 vector = this.velocity;
					bool flag4 = true;
					if (this.type == 9 || this.type == 12 || this.type == 15 || this.type == 13 || this.type == 31 || this.type == 39 || this.type == 40)
					{
						flag4 = false;
					}
					if (Main.projPet[this.type])
					{
						flag4 = false;
						if (Main.player[this.owner].position.Y + (float)Main.player[this.owner].height - 12f > this.position.Y + (float)this.height)
						{
							flag4 = true;
						}
					}
					if (this.type == 317)
					{
						flag4 = true;
					}
					if (this.aiStyle == 10)
					{
						if (this.type == 42 || this.type == 65 || this.type == 68 || (this.type == 31 && this.ai[0] == 2f))
						{
							this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag4, flag4);
						}
						else
						{
							this.velocity = Collision.AnyCollision(this.position, this.velocity, this.width, this.height);
						}
					}
					else if (this.aiStyle == 29)
					{
						int num24 = this.width - 8;
						int num25 = this.height - 8;
						Vector2 vector2 = new Vector2(this.position.X + (float)(this.width / 2) - (float)(num24 / 2), this.position.Y + (float)(this.height / 2) - (float)(num25 / 2));
						this.velocity = Collision.TileCollision(vector2, this.velocity, num24, num25, flag4, flag4);
					}
					else if (this.aiStyle == 49)
					{
						int num26 = this.width - 8;
						int num27 = this.height - 8;
						Vector2 vector3 = new Vector2(this.position.X + (float)(this.width / 2) - (float)(num26 / 2), this.position.Y + (float)(this.height / 2) - (float)(num27 / 2));
						this.velocity = Collision.TileCollision(vector3, this.velocity, num26, num27, flag4, flag4);
					}
					else if (this.type == 250 || this.type == 267 || this.type == 297 || this.type == 323)
					{
						int num28 = 2;
						int num29 = 2;
						Vector2 vector4 = new Vector2(this.position.X + (float)(this.width / 2) - (float)(num28 / 2), this.position.Y + (float)(this.height / 2) - (float)(num29 / 2));
						this.velocity = Collision.TileCollision(vector4, this.velocity, num28, num29, flag4, flag4);
					}
					else if (this.type == 308)
					{
						int num30 = 26;
						int num31 = this.height;
						Vector2 vector5 = new Vector2(this.position.X + (float)(this.width / 2) - (float)(num30 / 2), this.position.Y + (float)(this.height / 2) - (float)(num31 / 2));
						this.velocity = Collision.TileCollision(vector5, this.velocity, num30, num31, flag4, flag4);
					}
					else if (this.type == 261 || this.type == 277)
					{
						int num32 = 26;
						int num33 = 26;
						Vector2 vector6 = new Vector2(this.position.X + (float)(this.width / 2) - (float)(num32 / 2), this.position.Y + (float)(this.height / 2) - (float)(num33 / 2));
						this.velocity = Collision.TileCollision(vector6, this.velocity, num32, num33, flag4, flag4);
					}
					else if (this.type == 106 || this.type == 262 || this.type == 271 || this.type == 270 || this.type == 272 || this.type == 273 || this.type == 274 || this.type == 280 || this.type == 288 || this.type == 301 || this.type == 320 || this.type == 333 || this.type == 335 || this.type == 343 || this.type == 344)
					{
						int num34 = 10;
						int num35 = 10;
						Vector2 vector7 = new Vector2(this.position.X + (float)(this.width / 2) - (float)(num34 / 2), this.position.Y + (float)(this.height / 2) - (float)(num35 / 2));
						this.velocity = Collision.TileCollision(vector7, this.velocity, num34, num35, flag4, flag4);
					}
					else if (this.type == 248 || this.type == 247)
					{
						int num36 = this.width - 12;
						int num37 = this.height - 12;
						Vector2 vector8 = new Vector2(this.position.X + (float)(this.width / 2) - (float)(num36 / 2), this.position.Y + (float)(this.height / 2) - (float)(num37 / 2));
						this.velocity = Collision.TileCollision(vector8, this.velocity, num36, num37, flag4, flag4);
					}
					else if (this.aiStyle == 18 || this.type == 254)
					{
						int num38 = this.width - 36;
						int num39 = this.height - 36;
						Vector2 vector9 = new Vector2(this.position.X + (float)(this.width / 2) - (float)(num38 / 2), this.position.Y + (float)(this.height / 2) - (float)(num39 / 2));
						this.velocity = Collision.TileCollision(vector9, this.velocity, num38, num39, flag4, flag4);
					}
					else if (this.type == 182 || this.type == 190 || this.type == 33 || this.type == 229 || this.type == 237 || this.type == 243)
					{
						int num40 = this.width - 20;
						int num41 = this.height - 20;
						Vector2 vector10 = new Vector2(this.position.X + (float)(this.width / 2) - (float)(num40 / 2), this.position.Y + (float)(this.height / 2) - (float)(num41 / 2));
						this.velocity = Collision.TileCollision(vector10, this.velocity, num40, num41, flag4, flag4);
					}
					else if (this.aiStyle == 27)
					{
						int num42 = 6;
						this.velocity = Collision.TileCollision(new Vector2(this.position.X + (float)num42, this.position.Y + (float)num42), this.velocity, this.width - num42 * 2, this.height - num42 * 2, flag4, flag4);
					}
					else if (this.wet)
					{
						if (this.honeyWet)
						{
							Vector2 vector11 = this.velocity;
							this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag4, flag4);
							value = this.velocity * 0.25f;
							if (this.velocity.X != vector11.X)
							{
								value.X = this.velocity.X;
							}
							if (this.velocity.Y != vector11.Y)
							{
								value.Y = this.velocity.Y;
							}
						}
						else
						{
							Vector2 vector12 = this.velocity;
							this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag4, flag4);
							value = this.velocity * 0.5f;
							if (this.velocity.X != vector12.X)
							{
								value.X = this.velocity.X;
							}
							if (this.velocity.Y != vector12.Y)
							{
								value.Y = this.velocity.Y;
							}
						}
					}
					else
					{
						this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag4, flag4);
						if (!Main.projPet[this.type])
						{
							Vector4 vector13 = Collision.SlopeCollision(this.position, this.velocity, this.width, this.height, 0f);
							if (this.position.X != vector13.X)
							{
								flag3 = true;
							}
							if (this.position.Y != vector13.Y)
							{
								flag3 = true;
							}
							if (this.velocity.X != vector13.Z)
							{
								flag3 = true;
							}
							if (this.velocity.Y != vector13.W)
							{
								flag3 = true;
							}
							this.position.X = vector13.X;
							this.position.Y = vector13.Y;
							this.velocity.X = vector13.Z;
							this.velocity.Y = vector13.W;
						}
					}
					if (vector != this.velocity)
					{
						flag3 = true;
					}
					if (flag3)
					{
						if (this.aiStyle == 54)
						{
							if (this.velocity.X != vector.X)
							{
								this.velocity.X = vector.X * -0.6f;
							}
							if (this.velocity.Y != vector.Y)
							{
								this.velocity.Y = vector.Y * -0.6f;
							}
						}
						else if (!Main.projPet[this.type])
						{
							if (this.type == 254)
							{
								this.tileCollide = false;
								this.velocity = this.lastVelocity;
								if (this.timeLeft > 30)
								{
									this.timeLeft = 30;
								}
							}
							else if (this.type == 225 && this.penetrate > 0)
							{
								this.velocity.X = -vector.X;
								this.velocity.Y = -vector.Y;
								this.penetrate--;
							}
							else if (this.type == 155)
							{
								if (this.ai[1] > 10f)
								{
									string text = string.Concat(new object[]
									{
										this.name,
										" was hit ",
										this.ai[1],
										" times before touching the ground!"
									});
									if (Main.netMode == 0)
									{
										Main.NewText(text, 255, 240, 20, false);
									}
									else if (Main.netMode == 2)
									{
										NetMessage.SendData(25, -1, -1, text, 255, 255f, 240f, 20f, 0);
									}
								}
								this.ai[1] = 0f;
								if (this.velocity.X != vector.X)
								{
									this.velocity.X = vector.X * -0.6f;
								}
								if (this.velocity.Y != vector.Y && vector.Y > 2f)
								{
									this.velocity.Y = vector.Y * -0.6f;
								}
							}
							else if (this.aiStyle == 33)
							{
								if (this.localAI[0] == 0f)
								{
									if (this.wet)
									{
										this.position += vector / 2f;
									}
									else
									{
										this.position += vector;
									}
									this.velocity *= 0f;
									this.localAI[0] = 1f;
								}
							}
							else if (this.type != 308)
							{
								if (this.type == 94)
								{
									if (this.velocity.X != vector.X)
									{
										this.velocity.X = -vector.X;
									}
									if (this.velocity.Y != vector.Y)
									{
										this.velocity.Y = -vector.Y;
									}
								}
								else if (this.type == 311)
								{
									if (this.velocity.X != vector.X)
									{
										this.velocity.X = -vector.X;
										this.ai[1] += 1f;
									}
									if (this.velocity.Y != vector.Y)
									{
										this.velocity.Y = -vector.Y;
										this.ai[1] += 1f;
									}
									if (this.ai[1] > 4f)
									{
										this.Kill();
									}
								}
								else if (this.type == 312)
								{
									if (this.velocity.X != vector.X)
									{
										this.velocity.X = -vector.X;
										this.ai[1] += 1f;
									}
									if (this.velocity.Y != vector.Y)
									{
										this.velocity.Y = -vector.Y;
										this.ai[1] += 1f;
									}
								}
								else if (this.type == 281)
								{
									float num43 = Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y);
									if (num43 < 2f || this.ai[1] == 2f)
									{
										this.ai[1] = 2f;
									}
									else
									{
										if (this.velocity.X != vector.X)
										{
											this.velocity.X = -vector.X * 0.5f;
										}
										if (this.velocity.Y != vector.Y)
										{
											this.velocity.Y = -vector.Y * 0.5f;
										}
									}
								}
								else if (this.type == 290 || this.type == 294)
								{
									if (this.velocity.X != vector.X)
									{
										this.position.X = this.position.X + this.velocity.X;
										this.velocity.X = -vector.X;
									}
									if (this.velocity.Y != vector.Y)
									{
										this.position.Y = this.position.Y + this.velocity.Y;
										this.velocity.Y = -vector.Y;
									}
								}
								else if ((this.type == 181 || this.type == 189) && this.penetrate > 0)
								{
									this.penetrate--;
									if (this.velocity.X != vector.X)
									{
										this.velocity.X = -vector.X;
									}
									if (this.velocity.Y != vector.Y)
									{
										this.velocity.Y = -vector.Y;
									}
								}
								else if (this.type == 307 && this.ai[1] < 5f)
								{
									this.ai[1] += 1f;
									if (this.velocity.X != vector.X)
									{
										this.velocity.X = -vector.X;
									}
									if (this.velocity.Y != vector.Y)
									{
										this.velocity.Y = -vector.Y;
									}
								}
								else if (this.type == 99)
								{
									if (this.velocity.Y != vector.Y && vector.Y > 5f)
									{
										Collision.HitTiles(this.position, this.velocity, this.width, this.height);
										Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
										this.velocity.Y = -vector.Y * 0.2f;
									}
									if (this.velocity.X != vector.X)
									{
										this.Kill();
									}
								}
								else if (this.type == 36)
								{
									if (this.penetrate > 1)
									{
										Collision.HitTiles(this.position, this.velocity, this.width, this.height);
										Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
										this.penetrate--;
										if (this.velocity.X != vector.X)
										{
											this.velocity.X = -vector.X;
										}
										if (this.velocity.Y != vector.Y)
										{
											this.velocity.Y = -vector.Y;
										}
									}
									else
									{
										this.Kill();
									}
								}
								else if (this.aiStyle == 21)
								{
									if (this.velocity.X != vector.X)
									{
										this.velocity.X = -vector.X;
									}
									if (this.velocity.Y != vector.Y)
									{
										this.velocity.Y = -vector.Y;
									}
								}
								else if (this.aiStyle == 17)
								{
									if (this.velocity.X != vector.X)
									{
										this.velocity.X = vector.X * -0.75f;
									}
									if (this.velocity.Y != vector.Y && (double)vector.Y > 1.5)
									{
										this.velocity.Y = vector.Y * -0.7f;
									}
								}
								else if (this.aiStyle == 15)
								{
									bool flag5 = false;
									if (vector.X != this.velocity.X)
									{
										if (Math.Abs(vector.X) > 4f)
										{
											flag5 = true;
										}
										this.position.X = this.position.X + this.velocity.X;
										this.velocity.X = -vector.X * 0.2f;
									}
									if (vector.Y != this.velocity.Y)
									{
										if (Math.Abs(vector.Y) > 4f)
										{
											flag5 = true;
										}
										this.position.Y = this.position.Y + this.velocity.Y;
										this.velocity.Y = -vector.Y * 0.2f;
									}
									this.ai[0] = 1f;
									if (flag5)
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
										if (this.velocity.X != vector.X)
										{
											this.velocity.X = -vector.X;
										}
										if (this.velocity.Y != vector.Y)
										{
											this.velocity.Y = -vector.Y;
										}
									}
									else
									{
										this.ai[0] = 1f;
										if (this.aiStyle == 3)
										{
											this.velocity.X = -vector.X;
											this.velocity.Y = -vector.Y;
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
										if (this.velocity.X != vector.X)
										{
											this.velocity.X = -vector.X;
										}
										if (this.velocity.Y != vector.Y)
										{
											this.velocity.Y = -vector.Y;
										}
									}
									else
									{
										this.ai[0] = 1f;
										if (this.aiStyle == 3)
										{
											this.velocity.X = -vector.X;
											this.velocity.Y = -vector.Y;
										}
									}
									this.netUpdate = true;
									Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
								}
								else if (this.aiStyle == 8 && this.type != 96)
								{
									Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
									this.ai[0] += 1f;
									if ((this.ai[0] >= 5f && this.type != 253) || (this.type == 253 && this.ai[0] >= 8f))
									{
										this.position += this.velocity;
										this.Kill();
									}
									else
									{
										if (this.type == 15 && this.velocity.Y > 4f)
										{
											if (this.velocity.Y != vector.Y)
											{
												this.velocity.Y = -vector.Y * 0.8f;
											}
										}
										else if (this.velocity.Y != vector.Y)
										{
											this.velocity.Y = -vector.Y;
										}
										if (this.velocity.X != vector.X)
										{
											this.velocity.X = -vector.X;
										}
									}
								}
								else if (this.aiStyle == 14)
								{
									if (this.type == 261 && ((this.velocity.X != vector.X && (vector.X < -3f || vector.X > 3f)) || (this.velocity.Y != vector.Y && (vector.Y < -3f || vector.Y > 3f))))
									{
										Collision.HitTiles(this.position, this.velocity, this.width, this.height);
										Main.PlaySound(0, (int)this.center().X, (int)this.center().Y, 1);
									}
									if (this.type >= 326 && this.type <= 328)
									{
										if (this.velocity.X != vector.X)
										{
											this.velocity.X = vector.X * -0.1f;
										}
									}
									else if (this.type == 50)
									{
										if (this.velocity.X != vector.X)
										{
											this.velocity.X = vector.X * -0.2f;
										}
										if (this.velocity.Y != vector.Y && (double)vector.Y > 1.5)
										{
											this.velocity.Y = vector.Y * -0.2f;
										}
									}
									else if (this.type == 185)
									{
										if (this.velocity.X != vector.X)
										{
											this.velocity.X = vector.X * -0.9f;
										}
										if (this.velocity.Y != vector.Y && vector.Y > 1f)
										{
											this.velocity.Y = vector.Y * -0.9f;
										}
									}
									else if (this.type == 277)
									{
										if (this.velocity.X != vector.X)
										{
											this.velocity.X = vector.X * -0.9f;
										}
										if (this.velocity.Y != vector.Y && vector.Y > 3f)
										{
											this.velocity.Y = vector.Y * -0.9f;
										}
									}
									else
									{
										if (this.velocity.X != vector.X)
										{
											this.velocity.X = vector.X * -0.5f;
										}
										if (this.velocity.Y != vector.Y && vector.Y > 1f)
										{
											this.velocity.Y = vector.Y * -0.5f;
										}
									}
								}
								else if (this.aiStyle == 16)
								{
									if (this.velocity.X != vector.X)
									{
										this.velocity.X = vector.X * -0.4f;
										if (this.type == 29)
										{
											this.velocity.X = this.velocity.X * 0.8f;
										}
									}
									if (this.velocity.Y != vector.Y && (double)vector.Y > 0.7 && this.type != 102)
									{
										this.velocity.Y = vector.Y * -0.4f;
										if (this.type == 29)
										{
											this.velocity.Y = this.velocity.Y * 0.8f;
										}
									}
									if (this.type == 134 || this.type == 137 || this.type == 140 || this.type == 143 || this.type == 303 || (this.type >= 338 && this.type <= 341))
									{
										this.velocity *= 0f;
										this.alpha = 255;
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
					{
						this.position += value;
					}
					else
					{
						this.position += this.velocity;
					}
					if (Main.projPet[this.type] && this.tileCollide)
					{
						Vector4 vector14 = Collision.SlopeCollision(this.position, this.velocity, this.width, this.height, 0f);
						if (this.position.X != vector14.X)
						{
						}
						if (this.position.Y != vector14.Y)
						{
						}
						if (this.velocity.X != vector14.Z)
						{
						}
						if (this.velocity.Y != vector14.W)
						{
						}
						this.position.X = vector14.X;
						this.position.Y = vector14.Y;
						this.velocity.X = vector14.Z;
						this.velocity.Y = vector14.W;
					}
				}
				if ((this.aiStyle != 3 || this.ai[0] != 1f) && (this.aiStyle != 7 || this.ai[0] != 1f) && (this.aiStyle != 13 || this.ai[0] != 1f) && (this.aiStyle != 15 || this.ai[0] != 1f) && this.aiStyle != 15 && this.aiStyle != 26)
				{
					if (this.velocity.X < 0f)
					{
						this.direction = -1;
					}
					else
					{
						this.direction = 1;
					}
				}
				if (this.active)
				{
					this.ProjLight();
					if (this.type == 2 || this.type == 82)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
					}
					else if (this.type == 172)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 135, 0f, 0f, 100, default(Color), 1f);
					}
					else if (this.type == 103)
					{
						int num44 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 75, 0f, 0f, 100, default(Color), 1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num44].noGravity = true;
							Main.dust[num44].scale *= 2f;
						}
					}
					else if (this.type == 278)
					{
						int num45 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 169, 0f, 0f, 100, default(Color), 1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num45].noGravity = true;
							Main.dust[num45].scale *= 1.5f;
						}
					}
					else if (this.type == 4)
					{
						if (Main.rand.Next(5) == 0)
						{
							Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 150, default(Color), 1.1f);
						}
					}
					else if (this.type == 5)
					{
						int num46 = Main.rand.Next(3);
						if (num46 == 0)
						{
							num46 = 15;
						}
						else if (num46 == 1)
						{
							num46 = 57;
						}
						else
						{
							num46 = 58;
						}
						Dust.NewDust(this.position, this.width, this.height, num46, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, default(Color), 1.2f);
					}
					this.Damage();
					if (Main.netMode != 1 && this.type == 99)
					{
						Collision.SwitchTiles(this.position, this.width, this.height, this.lastPosition, 3);
					}
					if (this.type == 94 || this.type == 301)
					{
						for (int num47 = this.oldPos.Length - 1; num47 > 0; num47--)
						{
							this.oldPos[num47] = this.oldPos[num47 - 1];
						}
						this.oldPos[0] = this.position;
					}
					this.timeLeft--;
					if (this.timeLeft <= 0)
					{
						this.Kill();
					}
					if (this.penetrate == 0)
					{
						this.Kill();
					}
					if (this.active && this.owner == Main.myPlayer)
					{
						if (this.netUpdate2)
						{
							this.netUpdate = true;
						}
						if (!this.active)
						{
							this.netSpam = 0;
						}
						if (this.netUpdate)
						{
							if (this.netSpam < 60)
							{
								this.netSpam += 5;
								NetMessage.SendData(27, -1, -1, "", i, 0f, 0f, 0f, 0);
								this.netUpdate2 = false;
							}
							else
							{
								this.netUpdate2 = true;
							}
						}
						if (this.netSpam > 0)
						{
							this.netSpam--;
						}
					}
					if (this.active && this.maxUpdates > 0)
					{
						this.numUpdates--;
						if (this.numUpdates >= 0)
						{
							this.Update(i);
						}
						else
						{
							this.numUpdates = this.maxUpdates;
						}
					}
					this.netUpdate = false;
					return;
				}
				return;
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
				if (this.type == 350)
				{
					this.alpha -= 100;
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
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
				if (this.type == 325)
				{
					this.alpha -= 100;
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
					if (this.alpha == 0)
					{
						int num8 = 2;
						if (Main.rand.Next(2) == 0)
						{
							int num9 = Dust.NewDust(new Vector2(this.center().X - (float)num8, this.center().Y - (float)num8 - 2f) - this.velocity * 0.5f, num8 * 2, num8 * 2, 6, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num9].scale *= 1.8f + (float)Main.rand.Next(10) * 0.1f;
							Main.dust[num9].velocity *= 0.2f;
							Main.dust[num9].noGravity = true;
						}
						if (Main.rand.Next(4) == 0)
						{
							int num10 = Dust.NewDust(new Vector2(this.center().X - (float)num8, this.center().Y - (float)num8 - 2f) - this.velocity * 0.5f, num8 * 2, num8 * 2, 31, 0f, 0f, 100, default(Color), 0.5f);
							Main.dust[num10].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
							Main.dust[num10].velocity *= 0.05f;
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
					int num11 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.6f);
					Main.dust[num11].noGravity = true;
					num11 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num11].noGravity = true;
				}
				else if (this.type == 55)
				{
					int num12 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 18, 0f, 0f, 0, default(Color), 0.9f);
					Main.dust[num12].noGravity = true;
				}
				else if (this.type == 91 && Main.rand.Next(2) == 0)
				{
					int num13;
					if (Main.rand.Next(2) == 0)
					{
						num13 = 15;
					}
					else
					{
						num13 = 58;
					}
					int num14 = Dust.NewDust(this.position, this.width, this.height, num13, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 150, default(Color), 0.9f);
					Main.dust[num14].velocity *= 0.25f;
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
					float num15 = (float)Math.Sqrt((double)(this.velocity.X * this.velocity.X + this.velocity.Y * this.velocity.Y));
					if (this.alpha > 0)
					{
						this.alpha -= (int)((byte)((double)num15 * 0.9));
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
				if (this.type != 350 && this.type != 349 && this.type != 348 && this.type != 5 && this.type != 325 && this.type != 323 && this.type != 14 && this.type != 270 && this.type != 180 && this.type != 259 && this.type != 242 && this.type != 302 && this.type != 20 && this.type != 36 && this.type != 38 && this.type != 55 && this.type != 83 && this.type != 84 && this.type != 88 && this.type != 89 && this.type != 98 && this.type != 100 && this.type != 265 && this.type != 104 && this.type != 110 && this.type != 184 && this.type != 257 && this.type != 248 && (this.type < 283 || this.type > 287) && this.type != 279 && this.type != 299 && (this.type < 158 || this.type > 161))
				{
					this.ai[0] += 1f;
				}
				if (this.type == 349)
				{
					this.frame = (int)this.ai[0];
					this.velocity.Y = this.velocity.Y + 0.2f;
					if (this.localAI[0] == 0f || this.localAI[0] == 2f)
					{
						this.scale += 0.01f;
						this.alpha -= 50;
						if (this.alpha <= 0)
						{
							this.localAI[0] = 1f;
							this.alpha = 0;
						}
					}
					else if (this.localAI[0] == 1f)
					{
						this.scale -= 0.01f;
						this.alpha += 50;
						if (this.alpha >= 255)
						{
							this.localAI[0] = 2f;
							this.alpha = 255;
						}
					}
				}
				if (this.type == 348)
				{
					if (this.localAI[1] == 0f)
					{
						this.localAI[1] = 1f;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
					}
					if (this.ai[0] == 0f || this.ai[0] == 2f)
					{
						this.scale += 0.01f;
						this.alpha -= 50;
						if (this.alpha <= 0)
						{
							this.ai[0] = 1f;
							this.alpha = 0;
						}
					}
					else if (this.ai[0] == 1f)
					{
						this.scale -= 0.01f;
						this.alpha += 50;
						if (this.alpha >= 255)
						{
							this.ai[0] = 2f;
							this.alpha = 255;
						}
					}
				}
				if (this.type == 299)
				{
					if (this.localAI[0] == 6f)
					{
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
						for (int i = 0; i < 40; i++)
						{
							int num16 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 181, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num16].velocity *= 3f;
							Main.dust[num16].velocity += this.velocity * 0.75f;
							Main.dust[num16].scale *= 1.2f;
							Main.dust[num16].noGravity = true;
						}
					}
					this.localAI[0] += 1f;
					if (this.localAI[0] > 6f)
					{
						for (int j = 0; j < 3; j++)
						{
							int num17 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 181, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 1f);
							Main.dust[num17].velocity *= 0.6f;
							Main.dust[num17].scale *= 1.4f;
							Main.dust[num17].noGravity = true;
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
						int num18 = Dust.NewDust(new Vector2(this.position.X + 4f, this.position.Y + 4f), this.width - 8, this.height - 8, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num18].position -= this.velocity * 2f;
						Main.dust[num18].noGravity = true;
						Dust expr_179F_cp_0 = Main.dust[num18];
						expr_179F_cp_0.velocity.X = expr_179F_cp_0.velocity.X * 0.3f;
						Dust expr_17BD_cp_0 = Main.dust[num18];
						expr_17BD_cp_0.velocity.Y = expr_17BD_cp_0.velocity.Y * 0.3f;
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
						int num19 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 163, this.velocity.X, this.velocity.Y, 100, default(Color), 1.2f);
						Main.dust[num19].noGravity = true;
						Main.dust[num19].velocity *= 0.3f;
						Main.dust[num19].velocity -= this.velocity * 0.4f;
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
							int num20 = Dust.NewDust(new Vector2(x, y), 1, 1, 75, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num20].alpha = this.alpha;
							Main.dust[num20].position.X = x;
							Main.dust[num20].position.Y = y;
							Main.dust[num20].velocity *= 0f;
							Main.dust[num20].noGravity = true;
						}
					}
					float num21 = (float)Math.Sqrt((double)(this.velocity.X * this.velocity.X + this.velocity.Y * this.velocity.Y));
					float num22 = this.localAI[0];
					if (num22 == 0f)
					{
						this.localAI[0] = num21;
						num22 = num21;
					}
					if (this.alpha > 0)
					{
						this.alpha -= 25;
					}
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
					float num23 = this.position.X;
					float num24 = this.position.Y;
					float num25 = 300f;
					bool flag = false;
					int num26 = 0;
					if (this.ai[1] == 0f)
					{
						for (int m = 0; m < 200; m++)
						{
							if (Main.npc[m].active && !Main.npc[m].dontTakeDamage && !Main.npc[m].friendly && Main.npc[m].lifeMax > 5 && (this.ai[1] == 0f || this.ai[1] == (float)(m + 1)))
							{
								float num27 = Main.npc[m].position.X + (float)(Main.npc[m].width / 2);
								float num28 = Main.npc[m].position.Y + (float)(Main.npc[m].height / 2);
								float num29 = Math.Abs(this.position.X + (float)(this.width / 2) - num27) + Math.Abs(this.position.Y + (float)(this.height / 2) - num28);
								if (num29 < num25 && Collision.CanHit(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2)), 1, 1, Main.npc[m].position, Main.npc[m].width, Main.npc[m].height))
								{
									num25 = num29;
									num23 = num27;
									num24 = num28;
									flag = true;
									num26 = m;
								}
							}
						}
						if (flag)
						{
							this.ai[1] = (float)(num26 + 1);
						}
						flag = false;
					}
					if (this.ai[1] != 0f)
					{
						int num30 = (int)(this.ai[1] - 1f);
						if (Main.npc[num30].active)
						{
							float num31 = Main.npc[num30].position.X + (float)(Main.npc[num30].width / 2);
							float num32 = Main.npc[num30].position.Y + (float)(Main.npc[num30].height / 2);
							float num33 = Math.Abs(this.position.X + (float)(this.width / 2) - num31) + Math.Abs(this.position.Y + (float)(this.height / 2) - num32);
							if (num33 < 1000f)
							{
								flag = true;
								num23 = Main.npc[num30].position.X + (float)(Main.npc[num30].width / 2);
								num24 = Main.npc[num30].position.Y + (float)(Main.npc[num30].height / 2);
							}
						}
					}
					if (flag)
					{
						float num34 = num22;
						Vector2 vector = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num35 = num23 - vector.X;
						float num36 = num24 - vector.Y;
						float num37 = (float)Math.Sqrt((double)(num35 * num35 + num36 * num36));
						num37 = num34 / num37;
						num35 *= num37;
						num36 *= num37;
						this.velocity.X = (this.velocity.X * 5f + num35) / 6f;
						this.velocity.Y = (this.velocity.Y * 5f + num36) / 6f;
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
				else if (this.type == 337)
				{
					if (this.position.Y > Main.player[this.owner].position.Y - 300f)
					{
						this.tileCollide = true;
					}
					if ((double)this.position.Y < Main.worldSurface * 16.0)
					{
						this.tileCollide = true;
					}
					this.frame = (int)this.ai[1];
					if (Main.rand.Next(2) == 0)
					{
						int num38 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 197, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num38].velocity *= 0.5f;
						Main.dust[num38].noGravity = true;
					}
				}
				else if (this.type == 344)
				{
					this.localAI[1] += 1f;
					if (this.localAI[1] > 5f)
					{
						this.alpha -= 50;
						if (this.alpha < 0)
						{
							this.alpha = 0;
						}
					}
					this.frame = (int)this.ai[1];
					if (this.localAI[1] > 20f)
					{
						this.localAI[1] = 20f;
						this.velocity.Y = this.velocity.Y + 0.15f;
					}
					this.rotation += Main.windSpeed * 0.2f;
					this.velocity.X = this.velocity.X + Main.windSpeed * 0.1f;
				}
				else if (this.type == 336 || this.type == 345)
				{
					if (this.type == 345 && this.localAI[0] == 0f)
					{
						this.localAI[0] = 1f;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 1);
					}
					if (this.ai[0] >= 50f)
					{
						this.ai[0] = 50f;
						this.velocity.Y = this.velocity.Y + 0.5f;
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
						int num39 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 67, this.velocity.X, this.velocity.Y, 100, default(Color), 1.2f);
						Main.dust[num39].noGravity = true;
						Main.dust[num39].velocity *= 0.3f;
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
				else if (this.type != 344)
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
					int num40 = Dust.NewDust(this.position, this.width, this.height, 57, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 0.3f);
					Dust expr_2898_cp_0 = Main.dust[num40];
					expr_2898_cp_0.velocity.X = expr_2898_cp_0.velocity.X * 0.3f;
					Dust expr_28B6_cp_0 = Main.dust[num40];
					expr_28B6_cp_0.velocity.Y = expr_28B6_cp_0.velocity.Y * 0.3f;
				}
				if (this.type == 304 && this.localAI[0] == 0f)
				{
					this.localAI[0] += 1f;
					this.alpha = 0;
				}
				if (this.type == 335)
				{
					this.frame = (int)this.ai[1];
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
								int num41 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
								Main.dust[num41].velocity *= 0.5f;
								Main.dust[num41].velocity += this.velocity * 0.1f;
							}
							for (int num42 = 0; num42 < 5; num42++)
							{
								int num43 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
								Main.dust[num43].noGravity = true;
								Main.dust[num43].velocity *= 3f;
								Main.dust[num43].velocity += this.velocity * 0.2f;
								num43 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
								Main.dust[num43].velocity *= 2f;
								Main.dust[num43].velocity += this.velocity * 0.3f;
							}
							for (int num44 = 0; num44 < 1; num44++)
							{
								int num45 = Gore.NewGore(new Vector2(this.position.X - 10f, this.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
								Main.gore[num45].position += this.velocity * 1.25f;
								Main.gore[num45].scale = 1.5f;
								Main.gore[num45].velocity += this.velocity * 0.5f;
								Main.gore[num45].velocity *= 0.02f;
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
							for (int num46 = 0; num46 < 10; num46++)
							{
								int num47 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
								Main.dust[num47].velocity *= 0.5f;
								Main.dust[num47].velocity += this.velocity * 0.1f;
							}
							for (int num48 = 0; num48 < 5; num48++)
							{
								int num49 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
								Main.dust[num49].noGravity = true;
								Main.dust[num49].velocity *= 3f;
								Main.dust[num49].velocity += this.velocity * 0.2f;
								num49 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
								Main.dust[num49].velocity *= 2f;
								Main.dust[num49].velocity += this.velocity * 0.3f;
							}
							for (int num50 = 0; num50 < 1; num50++)
							{
								int num51 = Gore.NewGore(new Vector2(this.position.X - 10f, this.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
								Main.gore[num51].position += this.velocity * 1.25f;
								Main.gore[num51].scale = 1.5f;
								Main.gore[num51].velocity += this.velocity * 0.5f;
								Main.gore[num51].velocity *= 0.02f;
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
							for (int num52 = 0; num52 < 7; num52++)
							{
								int num53 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
								Main.dust[num53].velocity *= 0.5f;
								Main.dust[num53].velocity += this.velocity * 0.1f;
							}
							for (int num54 = 0; num54 < 3; num54++)
							{
								int num55 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
								Main.dust[num55].noGravity = true;
								Main.dust[num55].velocity *= 3f;
								Main.dust[num55].velocity += this.velocity * 0.2f;
								num55 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
								Main.dust[num55].velocity *= 2f;
								Main.dust[num55].velocity += this.velocity * 0.3f;
							}
							for (int num56 = 0; num56 < 1; num56++)
							{
								int num57 = Gore.NewGore(new Vector2(this.position.X - 10f, this.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
								Main.gore[num57].position += this.velocity * 1.25f;
								Main.gore[num57].scale = 1.25f;
								Main.gore[num57].velocity += this.velocity * 0.5f;
								Main.gore[num57].velocity *= 0.02f;
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
				else if (this.type == 347)
				{
					this.ai[0] += 1f;
					if (this.ai[0] >= 5f)
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
						for (int num58 = 0; num58 < 4; num58++)
						{
							float num59 = this.velocity.X / 4f * (float)num58;
							float num60 = this.velocity.Y / 4f * (float)num58;
							int num61 = Dust.NewDust(this.position, this.width, this.height, 184, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num61].position.X = this.center().X - num59;
							Main.dust[num61].position.Y = this.center().Y - num60;
							Main.dust[num61].velocity *= 0f;
							Main.dust[num61].scale = 0.7f;
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
					for (int num62 = 0; num62 < 2; num62++)
					{
						int num63 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num63].noGravity = true;
						Dust expr_3AE8_cp_0 = Main.dust[num63];
						expr_3AE8_cp_0.velocity.X = expr_3AE8_cp_0.velocity.X * 0.3f;
						Dust expr_3B06_cp_0 = Main.dust[num63];
						expr_3B06_cp_0.velocity.Y = expr_3B06_cp_0.velocity.Y * 0.3f;
					}
				}
				else if (this.type == 33)
				{
					if (Main.rand.Next(1) == 0)
					{
						int num64 = Dust.NewDust(this.position, this.width, this.height, 40, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 0, default(Color), 1.4f);
						Main.dust[num64].noGravity = true;
					}
				}
				else if (this.type == 320)
				{
					if (Main.rand.Next(3) == 0)
					{
						int num65 = Dust.NewDust(this.position, this.width, this.height, 5, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 0, default(Color), 1.1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num65].scale = 0.9f;
							Main.dust[num65].velocity *= 0.2f;
						}
						else
						{
							Main.dust[num65].noGravity = true;
						}
					}
				}
				else if (this.type == 6)
				{
					if (Main.rand.Next(5) == 0)
					{
						int num66 = Main.rand.Next(3);
						if (num66 == 0)
						{
							num66 = 15;
						}
						else if (num66 == 1)
						{
							num66 = 57;
						}
						else
						{
							num66 = 58;
						}
						Dust.NewDust(this.position, this.width, this.height, num66, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 150, default(Color), 0.7f);
					}
				}
				else if (this.type == 113 && Main.rand.Next(1) == 0)
				{
					int num67 = Dust.NewDust(this.position, this.width, this.height, 76, this.velocity.X * 0.15f, this.velocity.Y * 0.15f, 0, default(Color), 1.1f);
					Main.dust[num67].noGravity = true;
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
							int num68 = Dust.NewDust(this.position, this.width, this.height, 57, 0f, 0f, 255, default(Color), 0.75f);
							Main.dust[num68].velocity *= 0.1f;
							Main.dust[num68].noGravity = true;
						}
						if (this.velocity.X > 0f)
						{
							this.spriteDirection = 1;
						}
						else if (this.velocity.X < 0f)
						{
							this.spriteDirection = -1;
						}
						float num69 = this.position.X;
						float num70 = this.position.Y;
						bool flag2 = false;
						if (this.ai[1] > 10f)
						{
							for (int num71 = 0; num71 < 200; num71++)
							{
								if (Main.npc[num71].active && !Main.npc[num71].dontTakeDamage && !Main.npc[num71].friendly && Main.npc[num71].lifeMax > 5)
								{
									float num72 = Main.npc[num71].position.X + (float)(Main.npc[num71].width / 2);
									float num73 = Main.npc[num71].position.Y + (float)(Main.npc[num71].height / 2);
									float num74 = Math.Abs(this.position.X + (float)(this.width / 2) - num72) + Math.Abs(this.position.Y + (float)(this.height / 2) - num73);
									if (num74 < 800f && Collision.CanHit(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2)), 1, 1, Main.npc[num71].position, Main.npc[num71].width, Main.npc[num71].height))
									{
										num69 = num72;
										num70 = num73;
										flag2 = true;
									}
								}
							}
						}
						if (!flag2)
						{
							num69 = this.position.X + (float)(this.width / 2) + this.velocity.X * 100f;
							num70 = this.position.Y + (float)(this.height / 2) + this.velocity.Y * 100f;
							if (this.ai[1] >= 30f)
							{
								this.ai[0] = 1f;
								this.ai[1] = 0f;
								this.netUpdate = true;
							}
						}
						float num75 = 12f;
						float num76 = 0.25f;
						Vector2 vector2 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num77 = num69 - vector2.X;
						float num78 = num70 - vector2.Y;
						float num79 = (float)Math.Sqrt((double)(num77 * num77 + num78 * num78));
						num79 = num75 / num79;
						num77 *= num79;
						num78 *= num79;
						if (this.velocity.X < num77)
						{
							this.velocity.X = this.velocity.X + num76;
							if (this.velocity.X < 0f && num77 > 0f)
							{
								this.velocity.X = this.velocity.X + num76 * 2f;
							}
						}
						else if (this.velocity.X > num77)
						{
							this.velocity.X = this.velocity.X - num76;
							if (this.velocity.X > 0f && num77 < 0f)
							{
								this.velocity.X = this.velocity.X - num76 * 2f;
							}
						}
						if (this.velocity.Y < num78)
						{
							this.velocity.Y = this.velocity.Y + num76;
							if (this.velocity.Y < 0f && num78 > 0f)
							{
								this.velocity.Y = this.velocity.Y + num76 * 2f;
							}
						}
						else if (this.velocity.Y > num78)
						{
							this.velocity.Y = this.velocity.Y - num76;
							if (this.velocity.Y > 0f && num78 < 0f)
							{
								this.velocity.Y = this.velocity.Y - num76 * 2f;
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
					float num80 = 9f;
					float num81 = 0.4f;
					if (this.type == 19)
					{
						num80 = 13f;
						num81 = 0.6f;
					}
					else if (this.type == 33)
					{
						num80 = 15f;
						num81 = 0.8f;
					}
					else if (this.type == 182)
					{
						num80 = 16f;
						num81 = 1.2f;
					}
					else if (this.type == 106)
					{
						num80 = 16f;
						num81 = 1.2f;
					}
					else if (this.type == 272)
					{
						num80 = 15f;
						num81 = 1f;
					}
					else if (this.type == 333)
					{
						num80 = 12f;
						num81 = 0.6f;
					}
					else if (this.type == 301)
					{
						num80 = 15f;
						num81 = 3f;
					}
					else if (this.type == 320)
					{
						num80 = 15f;
						num81 = 3f;
					}
					Vector2 vector3 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num82 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector3.X;
					float num83 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector3.Y;
					float num84 = (float)Math.Sqrt((double)(num82 * num82 + num83 * num83));
					if (num84 > 3000f)
					{
						this.Kill();
					}
					num84 = num80 / num84;
					num82 *= num84;
					num83 *= num84;
					if (this.velocity.X < num82)
					{
						this.velocity.X = this.velocity.X + num81;
						if (this.velocity.X < 0f && num82 > 0f)
						{
							this.velocity.X = this.velocity.X + num81;
						}
					}
					else if (this.velocity.X > num82)
					{
						this.velocity.X = this.velocity.X - num81;
						if (this.velocity.X > 0f && num82 < 0f)
						{
							this.velocity.X = this.velocity.X - num81;
						}
					}
					if (this.velocity.Y < num83)
					{
						this.velocity.Y = this.velocity.Y + num81;
						if (this.velocity.Y < 0f && num83 > 0f)
						{
							this.velocity.Y = this.velocity.Y + num81;
						}
					}
					else if (this.velocity.Y > num83)
					{
						this.velocity.Y = this.velocity.Y - num81;
						if (this.velocity.Y > 0f && num83 < 0f)
						{
							this.velocity.Y = this.velocity.Y - num81;
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
							int num85 = this.type;
							if (this.ai[1] >= 6f)
							{
								num85++;
							}
							int num86 = Projectile.NewProjectile(this.position.X + this.velocity.X + (float)(this.width / 2), this.position.Y + this.velocity.Y + (float)(this.height / 2), this.velocity.X, this.velocity.Y, num85, this.damage, this.knockBack, this.owner, 0f, 0f);
							Main.projectile[num86].damage = this.damage;
							Main.projectile[num86].ai[1] = this.ai[1] + 1f;
							NetMessage.SendData(27, -1, -1, "", num86, 0f, 0f, 0f, 0);
							return;
						}
						if ((this.type == 150 || this.type == 151) && Main.myPlayer == this.owner)
						{
							int num87 = this.type;
							if (this.type == 150)
							{
								num87 = 151;
							}
							else if (this.type == 151)
							{
								num87 = 150;
							}
							if (this.ai[1] >= 10f && this.type == 151)
							{
								num87 = 152;
							}
							int num88 = Projectile.NewProjectile(this.position.X + this.velocity.X + (float)(this.width / 2), this.position.Y + this.velocity.Y + (float)(this.height / 2), this.velocity.X, this.velocity.Y, num87, this.damage, this.knockBack, this.owner, 0f, 0f);
							Main.projectile[num88].damage = this.damage;
							Main.projectile[num88].ai[1] = this.ai[1] + 1f;
							NetMessage.SendData(27, -1, -1, "", num88, 0f, 0f, 0f, 0);
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
							for (int num89 = 0; num89 < 8; num89++)
							{
								int num90 = Dust.NewDust(this.position, this.width, this.height, 7, this.velocity.X * 0.025f, this.velocity.Y * 0.025f, 200, default(Color), 1.3f);
								Main.dust[num90].noGravity = true;
								Main.dust[num90].velocity *= 0.5f;
							}
						}
						else
						{
							for (int num91 = 0; num91 < 3; num91++)
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
					for (int num92 = 0; num92 < 30; num92++)
					{
						Dust.NewDust(this.position, this.width, this.height, 10 + this.type, this.velocity.X, this.velocity.Y, 50, default(Color), 1f);
					}
				}
				if (this.type == 10 || this.type == 11)
				{
					int num93 = (int)(this.position.X / 16f) - 1;
					int num94 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num95 = (int)(this.position.Y / 16f) - 1;
					int num96 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num93 < 0)
					{
						num93 = 0;
					}
					if (num94 > Main.maxTilesX)
					{
						num94 = Main.maxTilesX;
					}
					if (num95 < 0)
					{
						num95 = 0;
					}
					if (num96 > Main.maxTilesY)
					{
						num96 = Main.maxTilesY;
					}
					for (int num97 = num93; num97 < num94; num97++)
					{
						for (int num98 = num95; num98 < num96; num98++)
						{
							Vector2 vector4;
							vector4.X = (float)(num97 * 16);
							vector4.Y = (float)(num98 * 16);
							if (this.position.X + (float)this.width > vector4.X && this.position.X < vector4.X + 16f && this.position.Y + (float)this.height > vector4.Y && this.position.Y < vector4.Y + 16f && Main.myPlayer == this.owner && Main.tile[num97, num98].active())
							{
								if (this.type == 10)
								{
									if (Main.tile[num97, num98].type == 23 || Main.tile[num97, num98].type == 199)
									{
										Main.tile[num97, num98].type = 2;
										WorldGen.SquareTileFrame(num97, num98, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num97, num98, 1);
										}
									}
									if (Main.tile[num97, num98].type == 25 || Main.tile[num97, num98].type == 203)
									{
										Main.tile[num97, num98].type = 1;
										WorldGen.SquareTileFrame(num97, num98, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num97, num98, 1);
										}
									}
									if (Main.tile[num97, num98].type == 112 || Main.tile[num97, num98].type == 234)
									{
										Main.tile[num97, num98].type = 53;
										WorldGen.SquareTileFrame(num97, num98, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num97, num98, 1);
										}
									}
									if (Main.tile[num97, num98].type == 163 || Main.tile[num97, num98].type == 200)
									{
										Main.tile[num97, num98].type = 161;
										WorldGen.SquareTileFrame(num97, num98, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num97, num98, 1);
										}
									}
								}
								else if (this.type == 11)
								{
									if (Main.tile[num97, num98].type == 109)
									{
										Main.tile[num97, num98].type = 2;
										WorldGen.SquareTileFrame(num97, num98, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num97, num98, 1);
										}
									}
									if (Main.tile[num97, num98].type == 116)
									{
										Main.tile[num97, num98].type = 53;
										WorldGen.SquareTileFrame(num97, num98, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num97, num98, 1);
										}
									}
									if (Main.tile[num97, num98].type == 117)
									{
										Main.tile[num97, num98].type = 1;
										WorldGen.SquareTileFrame(num97, num98, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num97, num98, 1);
										}
									}
									if (Main.tile[num97, num98].type == 164)
									{
										Main.tile[num97, num98].type = 161;
										WorldGen.SquareTileFrame(num97, num98, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num97, num98, 1);
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
				float num99 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector5.X;
				float num100 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector5.Y;
				float num101 = (float)Math.Sqrt((double)(num99 * num99 + num100 * num100));
				this.rotation = (float)Math.Atan2((double)num100, (double)num99) - 1.57f;
				if (this.type == 256)
				{
					this.rotation = (float)Math.Atan2((double)num100, (double)num99) + 3.92500019f;
				}
				if (this.ai[0] == 0f)
				{
					if ((num101 > 300f && this.type == 13) || (num101 > 400f && this.type == 32) || (num101 > 440f && this.type == 73) || (num101 > 440f && this.type == 74) || (num101 > 250f && this.type == 165) || (num101 > 350f && this.type == 256) || (num101 > 500f && this.type == 315) || (num101 > 550f && this.type == 322) || (num101 > 400f && this.type == 331) || (num101 > 550f && this.type == 332))
					{
						this.ai[0] = 1f;
					}
					else if (this.type >= 230 && this.type <= 235)
					{
						int num102 = 300 + (this.type - 230) * 30;
						if (num101 > (float)num102)
						{
							this.ai[0] = 1f;
						}
					}
					int num103 = (int)(this.position.X / 16f) - 1;
					int num104 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num105 = (int)(this.position.Y / 16f) - 1;
					int num106 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num103 < 0)
					{
						num103 = 0;
					}
					if (num104 > Main.maxTilesX)
					{
						num104 = Main.maxTilesX;
					}
					if (num105 < 0)
					{
						num105 = 0;
					}
					if (num106 > Main.maxTilesY)
					{
						num106 = Main.maxTilesY;
					}
					for (int num107 = num103; num107 < num104; num107++)
					{
						int num108 = num105;
						while (num108 < num106)
						{
							if (Main.tile[num107, num108] == null)
							{
								Main.tile[num107, num108] = new Tile();
							}
							Vector2 vector6;
							vector6.X = (float)(num107 * 16);
							vector6.Y = (float)(num108 * 16);
							if (this.position.X + (float)this.width > vector6.X && this.position.X < vector6.X + 16f && this.position.Y + (float)this.height > vector6.Y && this.position.Y < vector6.Y + 16f && Main.tile[num107, num108].nactive() && Main.tileSolid[(int)Main.tile[num107, num108].type])
							{
								if (Main.player[this.owner].grapCount < 10)
								{
									Main.player[this.owner].grappling[Main.player[this.owner].grapCount] = this.whoAmI;
									Main.player[this.owner].grapCount++;
								}
								if (Main.myPlayer == this.owner)
								{
									int num109 = 0;
									int num110 = -1;
									int num111 = 100000;
									if (this.type == 73 || this.type == 74)
									{
										for (int num112 = 0; num112 < 1000; num112++)
										{
											if (num112 != this.whoAmI && Main.projectile[num112].active && Main.projectile[num112].owner == this.owner && Main.projectile[num112].aiStyle == 7 && Main.projectile[num112].ai[0] == 2f)
											{
												Main.projectile[num112].Kill();
											}
										}
									}
									else
									{
										int num113 = 3;
										if (this.type == 165)
										{
											num113 = 8;
										}
										if (this.type == 256)
										{
											num113 = 2;
										}
										for (int num114 = 0; num114 < 1000; num114++)
										{
											if (Main.projectile[num114].active && Main.projectile[num114].owner == this.owner && Main.projectile[num114].aiStyle == 7)
											{
												if (Main.projectile[num114].timeLeft < num111)
												{
													num110 = num114;
													num111 = Main.projectile[num114].timeLeft;
												}
												num109++;
											}
										}
										if (num109 > num113)
										{
											Main.projectile[num110].Kill();
										}
									}
								}
								WorldGen.KillTile(num107, num108, true, true, false);
								Main.PlaySound(0, num107 * 16, num108 * 16, 1);
								this.velocity.X = 0f;
								this.velocity.Y = 0f;
								this.ai[0] = 2f;
								this.position.X = (float)(num107 * 16 + 8 - this.width / 2);
								this.position.Y = (float)(num108 * 16 + 8 - this.height / 2);
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
								num108++;
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
					float num115 = 11f;
					if (this.type == 32)
					{
						num115 = 15f;
					}
					if (this.type == 73 || this.type == 74)
					{
						num115 = 17f;
					}
					if (this.type == 315)
					{
						num115 = 20f;
					}
					if (this.type == 322)
					{
						num115 = 22f;
					}
					if (this.type >= 230 && this.type <= 235)
					{
						num115 = 11f + (float)(this.type - 230) * 0.75f;
					}
					if (num101 < 24f)
					{
						this.Kill();
					}
					num101 = num115 / num101;
					num99 *= num101;
					num100 *= num101;
					this.velocity.X = num99;
					this.velocity.Y = num100;
					return;
				}
				if (this.ai[0] == 2f)
				{
					int num116 = (int)(this.position.X / 16f) - 1;
					int num117 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num118 = (int)(this.position.Y / 16f) - 1;
					int num119 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num116 < 0)
					{
						num116 = 0;
					}
					if (num117 > Main.maxTilesX)
					{
						num117 = Main.maxTilesX;
					}
					if (num118 < 0)
					{
						num118 = 0;
					}
					if (num119 > Main.maxTilesY)
					{
						num119 = Main.maxTilesY;
					}
					bool flag3 = true;
					for (int num120 = num116; num120 < num117; num120++)
					{
						for (int num121 = num118; num121 < num119; num121++)
						{
							if (Main.tile[num120, num121] == null)
							{
								Main.tile[num120, num121] = new Tile();
							}
							Vector2 vector7;
							vector7.X = (float)(num120 * 16);
							vector7.Y = (float)(num121 * 16);
							if (this.position.X + (float)(this.width / 2) > vector7.X && this.position.X + (float)(this.width / 2) < vector7.X + 16f && this.position.Y + (float)(this.height / 2) > vector7.Y && this.position.Y + (float)(this.height / 2) < vector7.Y + 16f && Main.tile[num120, num121].nactive() && Main.tileSolid[(int)Main.tile[num120, num121].type])
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
					for (int num122 = 0; num122 < 5; num122++)
					{
						float num123 = this.velocity.X / 3f * (float)num122;
						float num124 = this.velocity.Y / 3f * (float)num122;
						int num125 = 4;
						int num126 = Dust.NewDust(new Vector2(this.position.X + (float)num125, this.position.Y + (float)num125), this.width - num125 * 2, this.height - num125 * 2, 172, 0f, 0f, 100, default(Color), 1.2f);
						Main.dust[num126].noGravity = true;
						Main.dust[num126].velocity *= 0.1f;
						Main.dust[num126].velocity += this.velocity * 0.1f;
						Dust expr_6063_cp_0 = Main.dust[num126];
						expr_6063_cp_0.position.X = expr_6063_cp_0.position.X - num123;
						Dust expr_607E_cp_0 = Main.dust[num126];
						expr_607E_cp_0.position.Y = expr_607E_cp_0.position.Y - num124;
					}
					if (Main.rand.Next(5) == 0)
					{
						int num127 = 4;
						int num128 = Dust.NewDust(new Vector2(this.position.X + (float)num127, this.position.Y + (float)num127), this.width - num127 * 2, this.height - num127 * 2, 172, 0f, 0f, 100, default(Color), 0.6f);
						Main.dust[num128].velocity *= 0.25f;
						Main.dust[num128].velocity += this.velocity * 0.5f;
					}
				}
				else if (this.type == 95 || this.type == 96)
				{
					int num129 = Dust.NewDust(new Vector2(this.position.X + this.velocity.X, this.position.Y + this.velocity.Y), this.width, this.height, 75, this.velocity.X, this.velocity.Y, 100, default(Color), 3f * this.scale);
					Main.dust[num129].noGravity = true;
				}
				else if (this.type == 253)
				{
					for (int num130 = 0; num130 < 2; num130++)
					{
						int num131 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 135, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num131].noGravity = true;
						Dust expr_629C_cp_0 = Main.dust[num131];
						expr_629C_cp_0.velocity.X = expr_629C_cp_0.velocity.X * 0.3f;
						Dust expr_62BA_cp_0 = Main.dust[num131];
						expr_62BA_cp_0.velocity.Y = expr_62BA_cp_0.velocity.Y * 0.3f;
					}
				}
				else
				{
					for (int num132 = 0; num132 < 2; num132++)
					{
						int num133 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num133].noGravity = true;
						Dust expr_6367_cp_0 = Main.dust[num133];
						expr_6367_cp_0.velocity.X = expr_6367_cp_0.velocity.X * 0.3f;
						Dust expr_6385_cp_0 = Main.dust[num133];
						expr_6385_cp_0.velocity.Y = expr_6385_cp_0.velocity.Y * 0.3f;
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
					int num134 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 3.5f);
					Main.dust[num134].noGravity = true;
					Main.dust[num134].velocity *= 1.4f;
					num134 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 1.5f);
				}
				else if (this.type == 79)
				{
					if (this.soundDelay == 0 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 2f)
					{
						this.soundDelay = 10;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 9);
					}
					for (int num135 = 0; num135 < 1; num135++)
					{
						int num136 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 66, 0f, 0f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 2.5f);
						Main.dust[num136].velocity *= 0.1f;
						Main.dust[num136].velocity += this.velocity * 0.2f;
						Main.dust[num136].position.X = this.position.X + (float)(this.width / 2) + 4f + (float)Main.rand.Next(-2, 3);
						Main.dust[num136].position.Y = this.position.Y + (float)(this.height / 2) + (float)Main.rand.Next(-2, 3);
						Main.dust[num136].noGravity = true;
					}
				}
				else
				{
					if (this.soundDelay == 0 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 2f)
					{
						this.soundDelay = 10;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 9);
					}
					int num137 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 15, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num137].velocity *= 0.3f;
					Main.dust[num137].position.X = this.position.X + (float)(this.width / 2) + 4f + (float)Main.rand.Next(-4, 5);
					Main.dust[num137].position.Y = this.position.Y + (float)(this.height / 2) + (float)Main.rand.Next(-4, 5);
					Main.dust[num137].noGravity = true;
				}
				if (Main.myPlayer == this.owner && this.ai[0] == 0f)
				{
					if (Main.player[this.owner].channel)
					{
						float num138 = 12f;
						if (this.type == 16)
						{
							num138 = 15f;
						}
						Vector2 vector8 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num139 = (float)Main.mouseX + Main.screenPosition.X - vector8.X;
						float num140 = (float)Main.mouseY + Main.screenPosition.Y - vector8.Y;
						if (Main.player[this.owner].gravDir == -1f)
						{
							num140 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector8.Y;
						}
						float num141 = (float)Math.Sqrt((double)(num139 * num139 + num140 * num140));
						num141 = (float)Math.Sqrt((double)(num139 * num139 + num140 * num140));
						if (num141 > num138)
						{
							num141 = num138 / num141;
							num139 *= num141;
							num140 *= num141;
							int num142 = (int)(num139 * 1000f);
							int num143 = (int)(this.velocity.X * 1000f);
							int num144 = (int)(num140 * 1000f);
							int num145 = (int)(this.velocity.Y * 1000f);
							if (num142 != num143 || num144 != num145)
							{
								this.netUpdate = true;
							}
							this.velocity.X = num139;
							this.velocity.Y = num140;
						}
						else
						{
							int num146 = (int)(num139 * 1000f);
							int num147 = (int)(this.velocity.X * 1000f);
							int num148 = (int)(num140 * 1000f);
							int num149 = (int)(this.velocity.Y * 1000f);
							if (num146 != num147 || num148 != num149)
							{
								this.netUpdate = true;
							}
							this.velocity.X = num139;
							this.velocity.Y = num140;
						}
					}
					else if (this.ai[0] == 0f)
					{
						this.ai[0] = 1f;
						this.netUpdate = true;
						float num150 = 12f;
						Vector2 vector9 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num151 = (float)Main.mouseX + Main.screenPosition.X - vector9.X;
						float num152 = (float)Main.mouseY + Main.screenPosition.Y - vector9.Y;
						float num153 = (float)Math.Sqrt((double)(num151 * num151 + num152 * num152));
						if (num153 == 0f)
						{
							vector9 = new Vector2(Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2), Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2));
							num151 = this.position.X + (float)this.width * 0.5f - vector9.X;
							num152 = this.position.Y + (float)this.height * 0.5f - vector9.Y;
							num153 = (float)Math.Sqrt((double)(num151 * num151 + num152 * num152));
						}
						num153 = num150 / num153;
						num151 *= num153;
						num152 *= num153;
						this.velocity.X = num151;
						this.velocity.Y = num152;
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
						int num154 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 32, 0f, this.velocity.Y / 2f, 0, default(Color), 1f);
						Dust expr_6D64_cp_0 = Main.dust[num154];
						expr_6D64_cp_0.velocity.X = expr_6D64_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 39)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num155 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 38, 0f, this.velocity.Y / 2f, 0, default(Color), 1f);
						Dust expr_6DFE_cp_0 = Main.dust[num155];
						expr_6DFE_cp_0.velocity.X = expr_6DFE_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 40)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num156 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 36, 0f, this.velocity.Y / 2f, 0, default(Color), 1f);
						Main.dust[num156].velocity *= 0.4f;
					}
				}
				else if (this.type == 42 || this.type == 31)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num157 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 32, 0f, 0f, 0, default(Color), 1f);
						Dust expr_6F2F_cp_0 = Main.dust[num157];
						expr_6F2F_cp_0.velocity.X = expr_6F2F_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 56 || this.type == 65)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num158 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 0, default(Color), 1f);
						Dust expr_6FC7_cp_0 = Main.dust[num158];
						expr_6FC7_cp_0.velocity.X = expr_6FC7_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 67 || this.type == 68)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num159 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 51, 0f, 0f, 0, default(Color), 1f);
						Dust expr_705F_cp_0 = Main.dust[num159];
						expr_705F_cp_0.velocity.X = expr_705F_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 71)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num160 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 53, 0f, 0f, 0, default(Color), 1f);
						Dust expr_70ED_cp_0 = Main.dust[num160];
						expr_70ED_cp_0.velocity.X = expr_70ED_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 179)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num161 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 149, 0f, 0f, 0, default(Color), 1f);
						Dust expr_7181_cp_0 = Main.dust[num161];
						expr_7181_cp_0.velocity.X = expr_7181_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 241)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num162 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 36, 0f, 0f, 0, default(Color), 1f);
						Dust expr_720F_cp_0 = Main.dust[num162];
						expr_720F_cp_0.velocity.X = expr_720F_cp_0.velocity.X * 0.4f;
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
						float num163 = 12f;
						Vector2 vector10 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num164 = (float)Main.mouseX + Main.screenPosition.X - vector10.X;
						float num165 = (float)Main.mouseY + Main.screenPosition.Y - vector10.Y;
						float num166 = (float)Math.Sqrt((double)(num164 * num164 + num165 * num165));
						num166 = (float)Math.Sqrt((double)(num164 * num164 + num165 * num165));
						if (num166 > num163)
						{
							num166 = num163 / num166;
							num164 *= num166;
							num165 *= num166;
							if (num164 != this.velocity.X || num165 != this.velocity.Y)
							{
								this.netUpdate = true;
							}
							this.velocity.X = num164;
							this.velocity.Y = num165;
						}
						else
						{
							if (num164 != this.velocity.X || num165 != this.velocity.Y)
							{
								this.netUpdate = true;
							}
							this.velocity.X = num164;
							this.velocity.Y = num165;
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
						int num167 = 56;
						if (this.type == 86)
						{
							num167 = 73;
						}
						else if (this.type == 87)
						{
							num167 = 74;
						}
						int num168 = Dust.NewDust(this.position, this.width, this.height, num167, 0f, 0f, 200, default(Color), 0.8f);
						Main.dust[num168].velocity *= 0.3f;
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
				float num169 = 3f;
				if (this.type == 72 || this.type == 86 || this.type == 87)
				{
					num169 = 3.75f;
				}
				Vector2 vector11 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float num170 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector11.X;
				float num171 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector11.Y;
				int num172 = 70;
				if (this.type == 18)
				{
					if (Main.player[this.owner].controlUp)
					{
						num171 = Main.player[this.owner].position.Y - 40f - vector11.Y;
						num170 -= 6f;
						num172 = 4;
					}
					else if (Main.player[this.owner].controlDown)
					{
						num171 = Main.player[this.owner].position.Y + (float)Main.player[this.owner].height + 40f - vector11.Y;
						num170 -= 6f;
						num172 = 4;
					}
				}
				float num173 = (float)Math.Sqrt((double)(num170 * num170 + num171 * num171));
				num173 = (float)Math.Sqrt((double)(num170 * num170 + num171 * num171));
				if (this.type == 72 || this.type == 86 || this.type == 87)
				{
					num172 = 40;
				}
				if (num173 > 800f)
				{
					this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
					this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
					return;
				}
				if (num173 > (float)num172)
				{
					num173 = num169 / num173;
					num170 *= num173;
					num171 *= num173;
					this.velocity.X = num170;
					this.velocity.Y = num171;
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
					for (int num174 = 0; num174 < 3; num174++)
					{
						float num175 = this.velocity.X / 3f * (float)num174;
						float num176 = this.velocity.Y / 3f * (float)num174;
						int num177 = 14;
						int num178 = Dust.NewDust(new Vector2(this.position.X + (float)num177, this.position.Y + (float)num177), this.width - num177 * 2, this.height - num177 * 2, 170, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num178].noGravity = true;
						Main.dust[num178].velocity *= 0.1f;
						Main.dust[num178].velocity += this.velocity * 0.5f;
						Dust expr_7BF6_cp_0 = Main.dust[num178];
						expr_7BF6_cp_0.position.X = expr_7BF6_cp_0.position.X - num175;
						Dust expr_7C11_cp_0 = Main.dust[num178];
						expr_7C11_cp_0.position.Y = expr_7C11_cp_0.position.Y - num176;
					}
					if (Main.rand.Next(8) == 0)
					{
						int num179 = 16;
						int num180 = Dust.NewDust(new Vector2(this.position.X + (float)num179, this.position.Y + (float)num179), this.width - num179 * 2, this.height - num179 * 2, 170, 0f, 0f, 100, default(Color), 0.5f);
						Main.dust[num180].velocity *= 0.25f;
						Main.dust[num180].velocity += this.velocity * 0.5f;
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
						for (int num181 = 0; num181 < 1; num181++)
						{
							for (int num182 = 0; num182 < 3; num182++)
							{
								float num183 = this.velocity.X / 3f * (float)num182;
								float num184 = this.velocity.Y / 3f * (float)num182;
								int num185 = 6;
								int num186 = Dust.NewDust(new Vector2(this.position.X + (float)num185, this.position.Y + (float)num185), this.width - num185 * 2, this.height - num185 * 2, 172, 0f, 0f, 100, default(Color), 1.2f);
								Main.dust[num186].noGravity = true;
								Main.dust[num186].velocity *= 0.3f;
								Main.dust[num186].velocity += this.velocity * 0.5f;
								Dust expr_7E5C_cp_0 = Main.dust[num186];
								expr_7E5C_cp_0.position.X = expr_7E5C_cp_0.position.X - num183;
								Dust expr_7E77_cp_0 = Main.dust[num186];
								expr_7E77_cp_0.position.Y = expr_7E77_cp_0.position.Y - num184;
							}
							if (Main.rand.Next(8) == 0)
							{
								int num187 = 6;
								int num188 = Dust.NewDust(new Vector2(this.position.X + (float)num187, this.position.Y + (float)num187), this.width - num187 * 2, this.height - num187 * 2, 172, 0f, 0f, 100, default(Color), 0.75f);
								Main.dust[num188].velocity *= 0.5f;
								Main.dust[num188].velocity += this.velocity * 0.5f;
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
				float num189 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector12.X;
				float num190 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector12.Y;
				float num191 = (float)Math.Sqrt((double)(num189 * num189 + num190 * num190));
				if (this.ai[0] == 0f)
				{
					if (num191 > 700f)
					{
						this.ai[0] = 1f;
					}
					else if (this.type == 262 && num191 > 500f)
					{
						this.ai[0] = 1f;
					}
					else if (this.type == 271 && num191 > 200f)
					{
						this.ai[0] = 1f;
					}
					else if (this.type == 273 && num191 > 150f)
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
					this.rotation = (float)Math.Atan2((double)num190, (double)num189) - 1.57f;
					float num192 = 20f;
					if (this.type == 262)
					{
						num192 = 30f;
					}
					if (num191 < 50f)
					{
						this.Kill();
					}
					num191 = num192 / num191;
					num189 *= num191;
					num190 *= num191;
					this.velocity.X = num189;
					this.velocity.Y = num190;
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
				if (this.type == 346)
				{
					if (this.localAI[0] == 0f)
					{
						this.localAI[0] = 1f;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 1);
					}
					this.frame = (int)this.ai[1];
					if (this.owner == Main.myPlayer && this.timeLeft == 1)
					{
						for (int num193 = 0; num193 < 5; num193++)
						{
							float num194 = 10f;
							Vector2 vector13 = new Vector2(this.center().X, this.center().Y);
							float num195 = (float)Main.rand.Next(-20, 21);
							float num196 = (float)Main.rand.Next(-20, 0);
							float num197 = (float)Math.Sqrt((double)(num195 * num195 + num196 * num196));
							num197 = num194 / num197;
							num195 *= num197;
							num196 *= num197;
							num195 *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
							num196 *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
							Projectile.NewProjectile(vector13.X, vector13.Y, num195, num196, 347, 40, 0f, Main.myPlayer, 0f, this.ai[1]);
						}
					}
				}
				if (this.type == 196)
				{
					int num198 = Main.rand.Next(1, 3);
					for (int num199 = 0; num199 < num198; num199++)
					{
						int num200 = Dust.NewDust(this.position, this.width, this.height, 31, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num200].alpha += Main.rand.Next(100);
						Main.dust[num200].velocity *= 0.3f;
						Dust expr_8637_cp_0 = Main.dust[num200];
						expr_8637_cp_0.velocity.X = expr_8637_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.025f;
						Dust expr_8665_cp_0 = Main.dust[num200];
						expr_8665_cp_0.velocity.Y = expr_8665_cp_0.velocity.Y - (0.4f + (float)Main.rand.Next(-3, 14) * 0.15f);
						Main.dust[num200].fadeIn = 1.25f + (float)Main.rand.Next(20) * 0.15f;
					}
				}
				if (this.type == 53)
				{
					try
					{
						Vector2 value2 = Collision.TileCollision(this.position, this.velocity, this.width, this.height, false, false);
						int num201 = (int)(this.position.X / 16f) - 1;
						int num202 = (int)((this.position.X + (float)this.width) / 16f) + 2;
						int num203 = (int)(this.position.Y / 16f) - 1;
						int num204 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
						if (num201 < 0)
						{
							num201 = 0;
						}
						if (num202 > Main.maxTilesX)
						{
							num202 = Main.maxTilesX;
						}
						if (num203 < 0)
						{
							num203 = 0;
						}
						if (num204 > Main.maxTilesY)
						{
							num204 = Main.maxTilesY;
						}
						for (int num205 = num201; num205 < num202; num205++)
						{
							for (int num206 = num203; num206 < num204; num206++)
							{
								if (Main.tile[num205, num206] != null && Main.tile[num205, num206].nactive() && (Main.tileSolid[(int)Main.tile[num205, num206].type] || (Main.tileSolidTop[(int)Main.tile[num205, num206].type] && Main.tile[num205, num206].frameY == 0)))
								{
									Vector2 vector14;
									vector14.X = (float)(num205 * 16);
									vector14.Y = (float)(num206 * 16);
									if (this.position.X + (float)this.width > vector14.X && this.position.X < vector14.X + 16f && this.position.Y + (float)this.height > vector14.Y && this.position.Y < vector14.Y + 16f)
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
					int num207 = Dust.NewDust(this.position, this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
					Dust expr_8BC4_cp_0 = Main.dust[num207];
					expr_8BC4_cp_0.position.X = expr_8BC4_cp_0.position.X - 2f;
					Dust expr_8BE2_cp_0 = Main.dust[num207];
					expr_8BE2_cp_0.position.Y = expr_8BE2_cp_0.position.Y + 2f;
					Main.dust[num207].scale += (float)Main.rand.Next(50) * 0.01f;
					Main.dust[num207].noGravity = true;
					Dust expr_8C35_cp_0 = Main.dust[num207];
					expr_8C35_cp_0.velocity.Y = expr_8C35_cp_0.velocity.Y - 2f;
					if (Main.rand.Next(2) == 0)
					{
						int num208 = Dust.NewDust(this.position, this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
						Dust expr_8C9C_cp_0 = Main.dust[num208];
						expr_8C9C_cp_0.position.X = expr_8C9C_cp_0.position.X - 2f;
						Dust expr_8CBA_cp_0 = Main.dust[num208];
						expr_8CBA_cp_0.position.Y = expr_8CBA_cp_0.position.Y + 2f;
						Main.dust[num208].scale += 0.3f + (float)Main.rand.Next(50) * 0.01f;
						Main.dust[num208].noGravity = true;
						Main.dust[num208].velocity *= 0.1f;
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
					int num209 = Dust.NewDust(this.position, this.width, this.height, 172, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 100, default(Color), 1.5f);
					Main.dust[num209].noGravity = true;
					Dust expr_8E8C_cp_0 = Main.dust[num209];
					expr_8E8C_cp_0.velocity.X = expr_8E8C_cp_0.velocity.X / 2f;
					Dust expr_8EAA_cp_0 = Main.dust[num209];
					expr_8EAA_cp_0.velocity.Y = expr_8EAA_cp_0.velocity.Y / 2f;
				}
				else if (this.type == 35)
				{
					int num210 = Dust.NewDust(this.position, this.width, this.height, 6, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 100, default(Color), 3f);
					Main.dust[num210].noGravity = true;
					Dust expr_8F39_cp_0 = Main.dust[num210];
					expr_8F39_cp_0.velocity.X = expr_8F39_cp_0.velocity.X * 2f;
					Dust expr_8F57_cp_0 = Main.dust[num210];
					expr_8F57_cp_0.velocity.Y = expr_8F57_cp_0.velocity.Y * 2f;
				}
				else if (this.type == 154)
				{
					int num211 = Dust.NewDust(this.position, this.width, this.height, 115, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 140, default(Color), 1.5f);
					Main.dust[num211].noGravity = true;
					Main.dust[num211].velocity *= 0.25f;
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
				Vector2 vector15 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float num212 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector15.X;
				float num213 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector15.Y;
				float num214 = (float)Math.Sqrt((double)(num212 * num212 + num213 * num213));
				if (this.ai[0] == 0f)
				{
					float num215 = 160f;
					if (this.type == 63)
					{
						num215 *= 1.5f;
					}
					if (this.type == 247)
					{
						num215 *= 1.5f;
					}
					this.tileCollide = true;
					if (num214 > num215)
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
					float num216 = 14f / Main.player[this.owner].meleeSpeed;
					float num217 = 0.9f / Main.player[this.owner].meleeSpeed;
					float num218 = 300f;
					if (this.type == 63)
					{
						num218 *= 1.5f;
						num216 *= 1.5f;
						num217 *= 1.5f;
					}
					if (this.type == 247)
					{
						num218 *= 1.5f;
						num216 = 15.9f;
						num217 *= 2f;
					}
					Math.Abs(num212);
					Math.Abs(num213);
					if (this.ai[1] == 1f)
					{
						this.tileCollide = false;
					}
					if (!Main.player[this.owner].channel || num214 > num218 || !this.tileCollide)
					{
						this.ai[1] = 1f;
						if (this.tileCollide)
						{
							this.netUpdate = true;
						}
						this.tileCollide = false;
						if (num214 < 20f)
						{
							this.Kill();
						}
					}
					if (!this.tileCollide)
					{
						num217 *= 2f;
					}
					int num219 = 60;
					if (this.type == 247)
					{
						num219 = 100;
					}
					if (num214 > (float)num219 || !this.tileCollide)
					{
						num214 = num216 / num214;
						num212 *= num214;
						num213 *= num214;
						new Vector2(this.velocity.X, this.velocity.Y);
						float num220 = num212 - this.velocity.X;
						float num221 = num213 - this.velocity.Y;
						float num222 = (float)Math.Sqrt((double)(num220 * num220 + num221 * num221));
						num222 = num217 / num222;
						num220 *= num222;
						num221 *= num222;
						this.velocity.X = this.velocity.X * 0.98f;
						this.velocity.Y = this.velocity.Y * 0.98f;
						this.velocity.X = this.velocity.X + num220;
						this.velocity.Y = this.velocity.Y + num221;
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
					this.rotation = (float)Math.Atan2((double)num213, (double)num212) - this.velocity.X * 0.1f;
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
				float num223 = this.position.X;
				float num224 = this.position.Y;
				float num225 = 600f;
				bool flag4 = false;
				if (this.owner == Main.myPlayer)
				{
					this.localAI[1] += 1f;
					if (this.localAI[1] > 20f)
					{
						this.localAI[1] = 20f;
						for (int num226 = 0; num226 < 200; num226++)
						{
							if (Main.npc[num226].active && !Main.npc[num226].dontTakeDamage && !Main.npc[num226].friendly && Main.npc[num226].lifeMax > 5)
							{
								float num227 = Main.npc[num226].position.X + (float)(Main.npc[num226].width / 2);
								float num228 = Main.npc[num226].position.Y + (float)(Main.npc[num226].height / 2);
								float num229 = Math.Abs(this.position.X + (float)(this.width / 2) - num227) + Math.Abs(this.position.Y + (float)(this.height / 2) - num228);
								if (num229 < num225 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num226].position, Main.npc[num226].width, Main.npc[num226].height))
								{
									num225 = num229;
									num223 = num227;
									num224 = num228;
									flag4 = true;
								}
							}
						}
					}
				}
				if (flag4)
				{
					this.localAI[1] = 0f;
					float num230 = 14f;
					vector15 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					num212 = num223 - vector15.X;
					num213 = num224 - vector15.Y;
					num214 = (float)Math.Sqrt((double)(num212 * num212 + num213 * num213));
					num214 = num230 / num214;
					num212 *= num214;
					num213 *= num214;
					Projectile.NewProjectile(vector15.X, vector15.Y, num212, num213, 248, (int)((double)this.damage / 1.5), this.knockBack / 2f, Main.myPlayer, 0f, 0f);
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
						int num231 = (int)(this.position.X / 16f) - 1;
						int num232 = (int)((this.position.X + (float)this.width) / 16f) + 2;
						int num233 = (int)(this.position.Y / 16f) - 1;
						int num234 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
						if (num231 < 0)
						{
							num231 = 0;
						}
						if (num232 > Main.maxTilesX)
						{
							num232 = Main.maxTilesX;
						}
						if (num233 < 0)
						{
							num233 = 0;
						}
						if (num234 > Main.maxTilesY)
						{
							num234 = Main.maxTilesY;
						}
						for (int num235 = num231; num235 < num232; num235++)
						{
							for (int num236 = num233; num236 < num234; num236++)
							{
								if (Main.tile[num235, num236] != null && Main.tile[num235, num236].nactive() && (Main.tileSolid[(int)Main.tile[num235, num236].type] || (Main.tileSolidTop[(int)Main.tile[num235, num236].type] && Main.tile[num235, num236].frameY == 0)))
								{
									Vector2 vector16;
									vector16.X = (float)(num235 * 16);
									vector16.Y = (float)(num236 * 16);
									if (this.position.X + (float)this.width - 4f > vector16.X && this.position.X + 4f < vector16.X + 16f && this.position.Y + (float)this.height - 4f > vector16.Y && this.position.Y + 4f < vector16.Y + 16f)
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
					else if (this.type == 133 || this.type == 134 || this.type == 135 || this.type == 136 || this.type == 137 || this.type == 138 || this.type == 338 || this.type == 339)
					{
						this.position.X = this.position.X + (float)(this.width / 2);
						this.position.Y = this.position.Y + (float)(this.height / 2);
						this.width = 128;
						this.height = 128;
						this.position.X = this.position.X - (float)(this.width / 2);
						this.position.Y = this.position.Y - (float)(this.height / 2);
						this.knockBack = 8f;
					}
					else if (this.type == 139 || this.type == 140 || this.type == 141 || this.type == 142 || this.type == 143 || this.type == 144 || this.type == 340 || this.type == 341)
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
					if (this.type != 30 && this.type != 108 && this.type != 133 && this.type != 134 && this.type != 135 && this.type != 136 && this.type != 137 && this.type != 138 && this.type != 139 && this.type != 140 && this.type != 141 && this.type != 142 && this.type != 143 && this.type != 144 && this.type != 164 && this.type != 303 && this.type < 338 && this.type < 341)
					{
						this.damage = 0;
					}
					if (this.type == 338 || this.type == 339 || this.type == 340 || this.type == 341)
					{
						this.localAI[1] += 1f;
						if (this.localAI[1] > 6f)
						{
							this.alpha = 0;
						}
						else
						{
							this.alpha = (int)(255f - 42f * this.localAI[1]) + 100;
							if (this.alpha > 255)
							{
								this.alpha = 255;
							}
						}
						for (int num237 = 0; num237 < 2; num237++)
						{
							float num238 = 0f;
							float num239 = 0f;
							if (num237 == 1)
							{
								num238 = this.velocity.X * 0.5f;
								num239 = this.velocity.Y * 0.5f;
							}
							if (this.localAI[1] > 9f)
							{
								if (Main.rand.Next(2) == 0)
								{
									int num240 = Dust.NewDust(new Vector2(this.position.X + 3f + num238, this.position.Y + 3f + num239) - this.velocity * 0.5f, this.width - 8, this.height - 8, 6, 0f, 0f, 100, default(Color), 1f);
									Main.dust[num240].scale *= 1.4f + (float)Main.rand.Next(10) * 0.1f;
									Main.dust[num240].velocity *= 0.2f;
									Main.dust[num240].noGravity = true;
								}
								if (Main.rand.Next(2) == 0)
								{
									int num241 = Dust.NewDust(new Vector2(this.position.X + 3f + num238, this.position.Y + 3f + num239) - this.velocity * 0.5f, this.width - 8, this.height - 8, 31, 0f, 0f, 100, default(Color), 0.5f);
									Main.dust[num241].fadeIn = 0.5f + (float)Main.rand.Next(5) * 0.1f;
									Main.dust[num241].velocity *= 0.05f;
								}
							}
						}
						float num242 = this.position.X;
						float num243 = this.position.Y;
						float num244 = 600f;
						bool flag5 = false;
						this.ai[0] += 1f;
						if (this.ai[0] > 30f)
						{
							this.ai[0] = 30f;
							for (int num245 = 0; num245 < 200; num245++)
							{
								if (Main.npc[num245].active && !Main.npc[num245].dontTakeDamage && !Main.npc[num245].friendly && Main.npc[num245].lifeMax > 5)
								{
									float num246 = Main.npc[num245].position.X + (float)(Main.npc[num245].width / 2);
									float num247 = Main.npc[num245].position.Y + (float)(Main.npc[num245].height / 2);
									float num248 = Math.Abs(this.position.X + (float)(this.width / 2) - num246) + Math.Abs(this.position.Y + (float)(this.height / 2) - num247);
									if (num248 < num244 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num245].position, Main.npc[num245].width, Main.npc[num245].height))
									{
										num244 = num248;
										num242 = num246;
										num243 = num247;
										flag5 = true;
									}
								}
							}
						}
						if (!flag5)
						{
							num242 = this.position.X + (float)(this.width / 2) + this.velocity.X * 100f;
							num243 = this.position.Y + (float)(this.height / 2) + this.velocity.Y * 100f;
						}
						float num249 = 16f;
						Vector2 vector17 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num250 = num242 - vector17.X;
						float num251 = num243 - vector17.Y;
						float num252 = (float)Math.Sqrt((double)(num250 * num250 + num251 * num251));
						num252 = num249 / num252;
						num250 *= num252;
						num251 *= num252;
						this.velocity.X = (this.velocity.X * 11f + num250) / 12f;
						this.velocity.Y = (this.velocity.Y * 11f + num251) / 12f;
					}
					else if (this.type == 134 || this.type == 137 || this.type == 140 || this.type == 143 || this.type == 303)
					{
						if (Math.Abs(this.velocity.X) >= 8f || Math.Abs(this.velocity.Y) >= 8f)
						{
							for (int num253 = 0; num253 < 2; num253++)
							{
								float num254 = 0f;
								float num255 = 0f;
								if (num253 == 1)
								{
									num254 = this.velocity.X * 0.5f;
									num255 = this.velocity.Y * 0.5f;
								}
								int num256 = Dust.NewDust(new Vector2(this.position.X + 3f + num254, this.position.Y + 3f + num255) - this.velocity * 0.5f, this.width - 8, this.height - 8, 6, 0f, 0f, 100, default(Color), 1f);
								Main.dust[num256].scale *= 2f + (float)Main.rand.Next(10) * 0.1f;
								Main.dust[num256].velocity *= 0.2f;
								Main.dust[num256].noGravity = true;
								num256 = Dust.NewDust(new Vector2(this.position.X + 3f + num254, this.position.Y + 3f + num255) - this.velocity * 0.5f, this.width - 8, this.height - 8, 31, 0f, 0f, 100, default(Color), 0.5f);
								Main.dust[num256].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
								Main.dust[num256].velocity *= 0.05f;
							}
						}
						if (Math.Abs(this.velocity.X) < 15f && Math.Abs(this.velocity.Y) < 15f)
						{
							this.velocity *= 1.1f;
						}
					}
					else if (this.type == 133 || this.type == 136 || this.type == 139 || this.type == 142)
					{
						int num257 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num257].scale *= 1f + (float)Main.rand.Next(10) * 0.1f;
						Main.dust[num257].velocity *= 0.2f;
						Main.dust[num257].noGravity = true;
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
							int num258 = Dust.NewDust(new Vector2(this.position.X + 3f, this.position.Y + 3f) - this.velocity * 0.5f, this.width - 8, this.height - 8, 31, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num258].scale *= 1.6f + (float)Main.rand.Next(5) * 0.1f;
							Main.dust[num258].velocity *= 0.05f;
							Main.dust[num258].noGravity = true;
						}
					}
					else if (this.type != 30 && Main.rand.Next(2) == 0)
					{
						int num259 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num259].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
						Main.dust[num259].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
						Main.dust[num259].noGravity = true;
						if (Main.rand.Next(3) == 0)
						{
							num259 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num259].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
							Main.dust[num259].noGravity = true;
						}
					}
				}
				this.ai[0] += 1f;
				if (this.type == 338 || this.type == 339 || this.type == 340 || this.type == 341)
				{
					if (this.velocity.X < 0f)
					{
						this.spriteDirection = -1;
						this.rotation = (float)Math.Atan2((double)(-(double)this.velocity.Y), (double)(-(double)this.velocity.X)) - 1.57f;
					}
					else
					{
						this.spriteDirection = 1;
						this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
					}
				}
				else if (this.type == 134 || this.type == 137 || this.type == 140 || this.type == 143 || this.type == 303)
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
				if (this.type != 134 && this.type != 137 && this.type != 140 && this.type != 143 && this.type != 303 && (this.type < 338 || this.type > 341))
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
					int num260 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
					int num261 = (int)((this.position.Y + (float)this.height - 4f) / 16f);
					if (Main.tile[num260, num261] != null && !Main.tile[num260, num261].active())
					{
						int num262 = 0;
						if (this.type >= 201 && this.type <= 205)
						{
							num262 = this.type - 200;
						}
						WorldGen.PlaceTile(num260, num261, 85, false, false, this.owner, num262);
						if (Main.tile[num260, num261].active())
						{
							if (Main.netMode != 0)
							{
								NetMessage.SendData(17, -1, -1, "", 1, (float)num260, (float)num261, 85f, num262);
							}
							int num263 = Sign.ReadSign(num260, num261);
							if (num263 >= 0)
							{
								Sign.TextSign(num263, this.miscText);
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
					for (int num264 = 0; num264 < 2; num264++)
					{
						int num265 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 27, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num265].noGravity = true;
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
					else if (this.type == 342)
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
								if (Collision.CanHit(new Vector2(this.center().X + this.velocity.X * this.ai[0], this.center().Y + this.velocity.Y * this.ai[0]), this.width, this.height, Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height))
								{
									Projectile.NewProjectile(this.center().X + this.velocity.X * this.ai[0], this.center().Y + this.velocity.Y * this.ai[0], this.velocity.X * 2.4f, this.velocity.Y * 2.4f, 343, (int)((double)this.damage * 0.8), this.knockBack * 0.85f, this.owner, 0f, 0f);
								}
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
					int num266 = Dust.NewDust(this.position, this.width, this.height, 27, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.2f);
					Main.dust[num266].noGravity = true;
					Dust expr_C2D1_cp_0 = Main.dust[num266];
					expr_C2D1_cp_0.velocity.X = expr_C2D1_cp_0.velocity.X / 2f;
					Dust expr_C2F1_cp_0 = Main.dust[num266];
					expr_C2F1_cp_0.velocity.Y = expr_C2F1_cp_0.velocity.Y / 2f;
					num266 = Dust.NewDust(this.position - this.velocity * 2f, this.width, this.height, 27, 0f, 0f, 150, default(Color), 1.4f);
					Dust expr_C365_cp_0 = Main.dust[num266];
					expr_C365_cp_0.velocity.X = expr_C365_cp_0.velocity.X / 5f;
					Dust expr_C385_cp_0 = Main.dust[num266];
					expr_C385_cp_0.velocity.Y = expr_C385_cp_0.velocity.Y / 5f;
					return;
				}
				if (this.type == 105)
				{
					if (Main.rand.Next(3) == 0)
					{
						int num267 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 57, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 200, default(Color), 1.2f);
						Main.dust[num267].velocity += this.velocity * 0.3f;
						Main.dust[num267].velocity *= 0.2f;
					}
					if (Main.rand.Next(4) == 0)
					{
						int num268 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 43, 0f, 0f, 254, default(Color), 0.3f);
						Main.dust[num268].velocity += this.velocity * 0.5f;
						Main.dust[num268].velocity *= 0.5f;
						return;
					}
				}
				else if (this.type == 153)
				{
					int num269 = Dust.NewDust(this.position - this.velocity * 3f, this.width, this.height, 115, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 140, default(Color), 1f);
					Main.dust[num269].noGravity = true;
					Main.dust[num269].fadeIn = 1.25f;
					Main.dust[num269].velocity *= 0.25f;
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
						float num270 = Main.player[this.owner].inventory[Main.player[this.owner].selectedItem].shootSpeed * this.scale;
						Vector2 vector18 = new Vector2(Main.player[this.owner].position.X + (float)Main.player[this.owner].width * 0.5f, Main.player[this.owner].position.Y + (float)Main.player[this.owner].height * 0.5f);
						float num271 = (float)Main.mouseX + Main.screenPosition.X - vector18.X;
						float num272 = (float)Main.mouseY + Main.screenPosition.Y - vector18.Y;
						float num273 = (float)Math.Sqrt((double)(num271 * num271 + num272 * num272));
						num273 = (float)Math.Sqrt((double)(num271 * num271 + num272 * num272));
						num273 = num270 / num273;
						num271 *= num273;
						num272 *= num273;
						if (num271 != this.velocity.X || num272 != this.velocity.Y)
						{
							this.netUpdate = true;
						}
						this.velocity.X = num271;
						this.velocity.Y = num272;
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
					int num274 = Dust.NewDust(this.position + this.velocity * (float)Main.rand.Next(6, 10) * 0.1f, this.width, this.height, 31, 0f, 0f, 80, default(Color), 1.4f);
					Dust expr_CAA7_cp_0 = Main.dust[num274];
					expr_CAA7_cp_0.position.X = expr_CAA7_cp_0.position.X - 4f;
					Main.dust[num274].noGravity = true;
					Main.dust[num274].velocity *= 0.2f;
					Main.dust[num274].velocity.Y = (float)(-(float)Main.rand.Next(7, 13)) * 0.15f;
					return;
				}
			}
			else if (this.aiStyle == 21)
			{
				this.rotation = this.velocity.X * 0.1f;
				this.spriteDirection = -this.direction;
				if (Main.rand.Next(3) == 0)
				{
					int num275 = Dust.NewDust(this.position, this.width, this.height, 27, 0f, 0f, 80, default(Color), 1f);
					Main.dust[num275].noGravity = true;
					Main.dust[num275].velocity *= 0.2f;
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
					int num276 = (int)(this.position.X / 16f) - 1;
					int num277 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num278 = (int)(this.position.Y / 16f) - 1;
					int num279 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num276 < 0)
					{
						num276 = 0;
					}
					if (num277 > Main.maxTilesX)
					{
						num277 = Main.maxTilesX;
					}
					if (num278 < 0)
					{
						num278 = 0;
					}
					if (num279 > Main.maxTilesY)
					{
						num279 = Main.maxTilesY;
					}
					int num280 = (int)this.position.X + 4;
					int num281 = (int)this.position.Y + 4;
					for (int num282 = num276; num282 < num277; num282++)
					{
						for (int num283 = num278; num283 < num279; num283++)
						{
							if (Main.tile[num282, num283] != null && Main.tile[num282, num283].active() && Main.tile[num282, num283].type != 127 && Main.tileSolid[(int)Main.tile[num282, num283].type] && !Main.tileSolidTop[(int)Main.tile[num282, num283].type])
							{
								Vector2 vector19;
								vector19.X = (float)(num282 * 16);
								vector19.Y = (float)(num283 * 16);
								if ((float)(num280 + 8) > vector19.X && (float)num280 < vector19.X + 16f && (float)(num281 + 8) > vector19.Y && (float)num281 < vector19.Y + 16f)
								{
									this.Kill();
								}
							}
						}
					}
					int num284 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num284].noGravity = true;
					Main.dust[num284].velocity *= 0.3f;
					return;
				}
				if (this.ai[0] < 0f)
				{
					if (this.ai[0] == -1f)
					{
						for (int num285 = 0; num285 < 10; num285++)
						{
							int num286 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0f, 0f, 0, default(Color), 1.1f);
							Main.dust[num286].noGravity = true;
							Main.dust[num286].velocity *= 1.3f;
						}
					}
					else if (Main.rand.Next(30) == 0)
					{
						int num287 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num287].velocity *= 0.2f;
					}
					int num288 = (int)this.position.X / 16;
					int num289 = (int)this.position.Y / 16;
					if (Main.tile[num288, num289] == null || !Main.tile[num288, num289].active())
					{
						this.Kill();
					}
					this.ai[0] -= 1f;
					if (this.ai[0] <= -300f && (Main.myPlayer == this.owner || Main.netMode == 2) && Main.tile[num288, num289].active() && Main.tile[num288, num289].type == 127)
					{
						WorldGen.KillTile(num288, num289, false, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(17, -1, -1, "", 0, (float)num288, (float)num289, 0f, 0);
						}
						this.Kill();
						return;
					}
				}
				else
				{
					int num290 = (int)(this.position.X / 16f) - 1;
					int num291 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num292 = (int)(this.position.Y / 16f) - 1;
					int num293 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num290 < 0)
					{
						num290 = 0;
					}
					if (num291 > Main.maxTilesX)
					{
						num291 = Main.maxTilesX;
					}
					if (num292 < 0)
					{
						num292 = 0;
					}
					if (num293 > Main.maxTilesY)
					{
						num293 = Main.maxTilesY;
					}
					int num294 = (int)this.position.X + 4;
					int num295 = (int)this.position.Y + 4;
					for (int num296 = num290; num296 < num291; num296++)
					{
						for (int num297 = num292; num297 < num293; num297++)
						{
							if (Main.tile[num296, num297] != null && Main.tile[num296, num297].nactive() && Main.tile[num296, num297].type != 127 && Main.tileSolid[(int)Main.tile[num296, num297].type] && !Main.tileSolidTop[(int)Main.tile[num296, num297].type])
							{
								Vector2 vector20;
								vector20.X = (float)(num296 * 16);
								vector20.Y = (float)(num297 * 16);
								if ((float)(num294 + 8) > vector20.X && (float)num294 < vector20.X + 16f && (float)(num295 + 8) > vector20.Y && (float)num295 < vector20.Y + 16f)
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
						int num298 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num298].noGravity = true;
						Main.dust[num298].velocity *= 0.3f;
						int num299 = (int)this.ai[0];
						int num300 = (int)this.ai[1];
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
							int num301 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
							int num302 = (int)((this.position.Y + (float)(this.height / 2)) / 16f);
							bool flag6 = false;
							if (num301 == num299 && num302 == num300)
							{
								flag6 = true;
							}
							if (((this.velocity.X <= 0f && num301 <= num299) || (this.velocity.X >= 0f && num301 >= num299)) && ((this.velocity.Y <= 0f && num302 <= num300) || (this.velocity.Y >= 0f && num302 >= num300)))
							{
								flag6 = true;
							}
							if (flag6)
							{
								if (WorldGen.PlaceTile(num299, num300, 127, false, false, this.owner, 0))
								{
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 1, (float)((int)this.ai[0]), (float)((int)this.ai[1]), 127f, 0);
									}
									this.damage = 0;
									this.ai[0] = -1f;
									this.velocity *= 0f;
									this.alpha = 255;
									this.position.X = (float)(num299 * 16);
									this.position.Y = (float)(num300 * 16);
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
						float num303 = 1f;
						if (this.ai[0] == 8f)
						{
							num303 = 0.25f;
						}
						else if (this.ai[0] == 9f)
						{
							num303 = 0.5f;
						}
						else if (this.ai[0] == 10f)
						{
							num303 = 0.75f;
						}
						this.ai[0] += 1f;
						int num304 = 6;
						if (this.type == 101)
						{
							num304 = 75;
						}
						if (num304 == 6 || Main.rand.Next(2) == 0)
						{
							for (int num305 = 0; num305 < 1; num305++)
							{
								int num306 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num304, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 1f);
								if (Main.rand.Next(3) != 0 || (num304 == 75 && Main.rand.Next(3) == 0))
								{
									Main.dust[num306].noGravity = true;
									Main.dust[num306].scale *= 3f;
									Dust expr_D811_cp_0 = Main.dust[num306];
									expr_D811_cp_0.velocity.X = expr_D811_cp_0.velocity.X * 2f;
									Dust expr_D831_cp_0 = Main.dust[num306];
									expr_D831_cp_0.velocity.Y = expr_D831_cp_0.velocity.Y * 2f;
								}
								if (this.type == 188)
								{
									Main.dust[num306].scale *= 1.25f;
								}
								else
								{
									Main.dust[num306].scale *= 1.5f;
								}
								Dust expr_D896_cp_0 = Main.dust[num306];
								expr_D896_cp_0.velocity.X = expr_D896_cp_0.velocity.X * 1.2f;
								Dust expr_D8B6_cp_0 = Main.dust[num306];
								expr_D8B6_cp_0.velocity.Y = expr_D8B6_cp_0.velocity.Y * 1.2f;
								Main.dust[num306].scale *= num303;
								if (num304 == 75)
								{
									Main.dust[num306].velocity += this.velocity;
									if (!Main.dust[num306].noGravity)
									{
										Main.dust[num306].velocity *= 0.5f;
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
							int num307 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 70, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num307].noGravity = true;
							Main.dust[num307].velocity *= 0.5f;
							Main.dust[num307].scale *= 0.9f;
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
							float num308 = 0.5f;
							int i2 = (int)((this.position.X - 8f) / 16f);
							int num309 = (int)(this.position.Y / 16f);
							bool flag7 = false;
							bool flag8 = false;
							if (WorldGen.SolidTile(i2, num309) || WorldGen.SolidTile(i2, num309 + 1))
							{
								flag7 = true;
							}
							i2 = (int)((this.position.X + (float)this.width + 8f) / 16f);
							if (WorldGen.SolidTile(i2, num309) || WorldGen.SolidTile(i2, num309 + 1))
							{
								flag8 = true;
							}
							if (flag7)
							{
								this.velocity.X = num308;
							}
							else if (flag8)
							{
								this.velocity.X = -num308;
							}
							else
							{
								i2 = (int)((this.position.X - 8f - 16f) / 16f);
								num309 = (int)(this.position.Y / 16f);
								flag7 = false;
								flag8 = false;
								if (WorldGen.SolidTile(i2, num309) || WorldGen.SolidTile(i2, num309 + 1))
								{
									flag7 = true;
								}
								i2 = (int)((this.position.X + (float)this.width + 8f + 16f) / 16f);
								if (WorldGen.SolidTile(i2, num309) || WorldGen.SolidTile(i2, num309 + 1))
								{
									flag8 = true;
								}
								if (flag7)
								{
									this.velocity.X = num308;
								}
								else if (flag8)
								{
									this.velocity.X = -num308;
								}
								else
								{
									i2 = (int)((this.position.X + 4f) / 16f);
									num309 = (int)((this.position.Y + (float)this.height + 8f) / 16f);
									if (WorldGen.SolidTile(i2, num309) || WorldGen.SolidTile(i2, num309 + 1))
									{
										flag7 = true;
									}
									if (!flag7)
									{
										this.velocity.X = num308;
									}
									else
									{
										this.velocity.X = -num308;
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
						bool flag9 = false;
						bool flag10 = false;
						bool flag11 = false;
						bool flag12 = false;
						int num310 = 85;
						if (this.type == 324)
						{
							num310 = 120;
						}
						if (this.type == 112)
						{
							num310 = 100;
						}
						if (this.type == 127)
						{
							num310 = 50;
						}
						if (this.type >= 191 && this.type <= 194)
						{
							if (this.lavaWet)
							{
								this.ai[0] = 1f;
								this.ai[1] = 0f;
							}
							num310 = 60 + 30 * this.minionPos;
						}
						else if (this.type == 266)
						{
							num310 = 60 + 30 * this.minionPos;
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
							if (this.type == 334)
							{
								if (Main.player[Main.myPlayer].dead)
								{
									Main.player[Main.myPlayer].puppy = false;
								}
								if (Main.player[Main.myPlayer].puppy)
								{
									this.timeLeft = 2;
								}
							}
							if (this.type == 353)
							{
								if (Main.player[Main.myPlayer].dead)
								{
									Main.player[Main.myPlayer].grinch = false;
								}
								if (Main.player[Main.myPlayer].grinch)
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
							num310 = 10;
							int num311 = 40 * (this.minionPos + 1) * Main.player[this.owner].direction;
							if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) < this.position.X + (float)(this.width / 2) - (float)num310 + (float)num311)
							{
								flag9 = true;
							}
							else if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) > this.position.X + (float)(this.width / 2) + (float)num310 + (float)num311)
							{
								flag10 = true;
							}
						}
						else if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) < this.position.X + (float)(this.width / 2) - (float)num310)
						{
							flag9 = true;
						}
						else if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) > this.position.X + (float)(this.width / 2) + (float)num310)
						{
							flag10 = true;
						}
						if (this.type == 175)
						{
							float num312 = 0.1f;
							this.tileCollide = false;
							int num313 = 300;
							Vector2 vector21 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num314 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector21.X;
							float num315 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector21.Y;
							if (this.type == 127)
							{
								num315 = Main.player[this.owner].position.Y - vector21.Y;
							}
							float num316 = (float)Math.Sqrt((double)(num314 * num314 + num315 * num315));
							float num317 = 7f;
							if (num316 < (float)num313 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
							{
								this.ai[0] = 0f;
								if (this.velocity.Y < -6f)
								{
									this.velocity.Y = -6f;
								}
							}
							if (num316 < 150f)
							{
								if (Math.Abs(this.velocity.X) > 2f || Math.Abs(this.velocity.Y) > 2f)
								{
									this.velocity *= 0.99f;
								}
								num312 = 0.01f;
								if (num314 < -2f)
								{
									num314 = -2f;
								}
								if (num314 > 2f)
								{
									num314 = 2f;
								}
								if (num315 < -2f)
								{
									num315 = -2f;
								}
								if (num315 > 2f)
								{
									num315 = 2f;
								}
							}
							else
							{
								if (num316 > 300f)
								{
									num312 = 0.2f;
								}
								num316 = num317 / num316;
								num314 *= num316;
								num315 *= num316;
							}
							if (Math.Abs(num314) > Math.Abs(num315) || num312 == 0.05f)
							{
								if (this.velocity.X < num314)
								{
									this.velocity.X = this.velocity.X + num312;
									if (num312 > 0.05f && this.velocity.X < 0f)
									{
										this.velocity.X = this.velocity.X + num312;
									}
								}
								if (this.velocity.X > num314)
								{
									this.velocity.X = this.velocity.X - num312;
									if (num312 > 0.05f && this.velocity.X > 0f)
									{
										this.velocity.X = this.velocity.X - num312;
									}
								}
							}
							if (Math.Abs(num314) <= Math.Abs(num315) || num312 == 0.05f)
							{
								if (this.velocity.Y < num315)
								{
									this.velocity.Y = this.velocity.Y + num312;
									if (num312 > 0.05f && this.velocity.Y < 0f)
									{
										this.velocity.Y = this.velocity.Y + num312;
									}
								}
								if (this.velocity.Y > num315)
								{
									this.velocity.Y = this.velocity.Y - num312;
									if (num312 > 0.05f && this.velocity.Y > 0f)
									{
										this.velocity.Y = this.velocity.Y - num312;
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
							float num318 = 0.1f;
							this.tileCollide = false;
							int num319 = 300;
							Vector2 vector22 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num320 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector22.X;
							float num321 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector22.Y;
							if (this.type == 127)
							{
								num321 = Main.player[this.owner].position.Y - vector22.Y;
							}
							float num322 = (float)Math.Sqrt((double)(num320 * num320 + num321 * num321));
							float num323 = 3f;
							if (num322 > 500f)
							{
								this.localAI[0] = 10000f;
							}
							if (this.localAI[0] >= 10000f)
							{
								num323 = 14f;
							}
							if (num322 < (float)num319 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
							{
								this.ai[0] = 0f;
								if (this.velocity.Y < -6f)
								{
									this.velocity.Y = -6f;
								}
							}
							if (num322 < 150f)
							{
								if (Math.Abs(this.velocity.X) > 2f || Math.Abs(this.velocity.Y) > 2f)
								{
									this.velocity *= 0.99f;
								}
								num318 = 0.01f;
								if (num320 < -2f)
								{
									num320 = -2f;
								}
								if (num320 > 2f)
								{
									num320 = 2f;
								}
								if (num321 < -2f)
								{
									num321 = -2f;
								}
								if (num321 > 2f)
								{
									num321 = 2f;
								}
							}
							else
							{
								if (num322 > 300f)
								{
									num318 = 0.2f;
								}
								num322 = num323 / num322;
								num320 *= num322;
								num321 *= num322;
							}
							if (this.velocity.X < num320)
							{
								this.velocity.X = this.velocity.X + num318;
								if (num318 > 0.05f && this.velocity.X < 0f)
								{
									this.velocity.X = this.velocity.X + num318;
								}
							}
							if (this.velocity.X > num320)
							{
								this.velocity.X = this.velocity.X - num318;
								if (num318 > 0.05f && this.velocity.X > 0f)
								{
									this.velocity.X = this.velocity.X - num318;
								}
							}
							if (this.velocity.Y < num321)
							{
								this.velocity.Y = this.velocity.Y + num318;
								if (num318 > 0.05f && this.velocity.Y < 0f)
								{
									this.velocity.Y = this.velocity.Y + num318;
								}
							}
							if (this.velocity.Y > num321)
							{
								this.velocity.Y = this.velocity.Y - num318;
								if (num318 > 0.05f && this.velocity.Y > 0f)
								{
									this.velocity.Y = this.velocity.Y - num318;
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
								float num324 = this.velocity.X * 0.1f;
								if (this.rotation > num324)
								{
									this.rotation -= (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.01f;
									if (this.rotation < num324)
									{
										this.rotation = num324;
									}
								}
								if (this.rotation < num324)
								{
									this.rotation += (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.01f;
									if (this.rotation > num324)
									{
										this.rotation = num324;
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
							float num325 = 0.4f;
							this.tileCollide = false;
							int num326 = 100;
							Vector2 vector23 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num327 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector23.X;
							float num328 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector23.Y;
							num328 += (float)Main.rand.Next(-10, 21);
							num327 += (float)Main.rand.Next(-10, 21);
							num327 += (float)(60 * -(float)Main.player[this.owner].direction);
							num328 -= 60f;
							if (this.type == 127)
							{
								num328 = Main.player[this.owner].position.Y - vector23.Y;
							}
							float num329 = (float)Math.Sqrt((double)(num327 * num327 + num328 * num328));
							float num330 = 14f;
							if (num329 < (float)num326 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
							{
								this.ai[0] = 0f;
								if (this.velocity.Y < -6f)
								{
									this.velocity.Y = -6f;
								}
							}
							if (num329 < 50f)
							{
								if (Math.Abs(this.velocity.X) > 2f || Math.Abs(this.velocity.Y) > 2f)
								{
									this.velocity *= 0.99f;
								}
								num325 = 0.01f;
							}
							else
							{
								if (num329 < 100f)
								{
									num325 = 0.1f;
								}
								if (num329 > 300f)
								{
									num325 = 0.6f;
								}
								num329 = num330 / num329;
								num327 *= num329;
								num328 *= num329;
							}
							if (this.velocity.X < num327)
							{
								this.velocity.X = this.velocity.X + num325;
								if (num325 > 0.05f && this.velocity.X < 0f)
								{
									this.velocity.X = this.velocity.X + num325;
								}
							}
							if (this.velocity.X > num327)
							{
								this.velocity.X = this.velocity.X - num325;
								if (num325 > 0.05f && this.velocity.X > 0f)
								{
									this.velocity.X = this.velocity.X - num325;
								}
							}
							if (this.velocity.Y < num328)
							{
								this.velocity.Y = this.velocity.Y + num325;
								if (num325 > 0.05f && this.velocity.Y < 0f)
								{
									this.velocity.Y = this.velocity.Y + num325 * 2f;
								}
							}
							if (this.velocity.Y > num328)
							{
								this.velocity.Y = this.velocity.Y - num325;
								if (num325 > 0.05f && this.velocity.Y > 0f)
								{
									this.velocity.Y = this.velocity.Y - num325 * 2f;
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
							float num331 = 0.2f;
							float num332 = 5f;
							this.tileCollide = false;
							Vector2 vector24 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num333 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector24.X;
							float num334 = Main.player[this.owner].position.Y + Main.player[this.owner].gfxOffY + (float)(Main.player[this.owner].height / 2) - vector24.Y;
							if (Main.player[this.owner].controlLeft)
							{
								num333 -= 120f;
							}
							else if (Main.player[this.owner].controlRight)
							{
								num333 += 120f;
							}
							if (Main.player[this.owner].controlDown)
							{
								num334 += 120f;
							}
							else
							{
								if (Main.player[this.owner].controlUp)
								{
									num334 -= 120f;
								}
								num334 -= 60f;
							}
							float num335 = (float)Math.Sqrt((double)(num333 * num333 + num334 * num334));
							if (num335 > 1000f)
							{
								this.position.X = this.position.X + num333;
								this.position.Y = this.position.Y + num334;
							}
							if (this.localAI[0] == 1f)
							{
								if (num335 < 10f && Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y) < num332 && Main.player[this.owner].velocity.Y == 0f)
								{
									this.localAI[0] = 0f;
								}
								num332 = 12f;
								if (num335 < num332)
								{
									this.velocity.X = num333;
									this.velocity.Y = num334;
								}
								else
								{
									num335 = num332 / num335;
									this.velocity.X = num333 * num335;
									this.velocity.Y = num334 * num335;
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
								for (int num336 = 0; num336 < 2; num336++)
								{
									int num337 = Dust.NewDust(new Vector2(this.position.X + 3f, this.position.Y + 4f), 14, 14, 156, 0f, 0f, 0, default(Color), 1f);
									Main.dust[num337].velocity *= 0.2f;
									Main.dust[num337].noGravity = true;
									Main.dust[num337].scale = 1.25f;
								}
								return;
							}
							if (num335 > 200f)
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
							if (num335 < 10f)
							{
								this.velocity.X = num333;
								this.velocity.Y = num334;
								this.rotation = this.velocity.X * 0.05f;
								if (num335 < num332)
								{
									this.position += this.velocity;
									this.velocity *= 0f;
									num331 = 0f;
								}
								this.direction = -Main.player[this.owner].direction;
							}
							num335 = num332 / num335;
							num333 *= num335;
							num334 *= num335;
							if (this.velocity.X < num333)
							{
								this.velocity.X = this.velocity.X + num331;
								if (this.velocity.X < 0f)
								{
									this.velocity.X = this.velocity.X * 0.99f;
								}
							}
							if (this.velocity.X > num333)
							{
								this.velocity.X = this.velocity.X - num331;
								if (this.velocity.X > 0f)
								{
									this.velocity.X = this.velocity.X * 0.99f;
								}
							}
							if (this.velocity.Y < num334)
							{
								this.velocity.Y = this.velocity.Y + num331;
								if (this.velocity.Y < 0f)
								{
									this.velocity.Y = this.velocity.Y * 0.99f;
								}
							}
							if (this.velocity.Y > num334)
							{
								this.velocity.Y = this.velocity.Y - num331;
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
							float num338 = 0.1f;
							this.tileCollide = false;
							int num339 = 200;
							Vector2 vector25 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num340 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector25.X;
							float num341 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector25.Y;
							num341 -= 60f;
							num340 -= 2f;
							if (this.type == 127)
							{
								num341 = Main.player[this.owner].position.Y - vector25.Y;
							}
							float num342 = (float)Math.Sqrt((double)(num340 * num340 + num341 * num341));
							float num343 = 4f;
							float num344 = num342;
							if (num342 < (float)num339 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
							{
								this.ai[0] = 0f;
								if (this.velocity.Y < -6f)
								{
									this.velocity.Y = -6f;
								}
							}
							if (num342 < 4f)
							{
								this.velocity.X = num340;
								this.velocity.Y = num341;
								num338 = 0f;
							}
							else
							{
								if (num342 > 350f)
								{
									num338 = 0.2f;
									num343 = 10f;
								}
								num342 = num343 / num342;
								num340 *= num342;
								num341 *= num342;
							}
							if (this.velocity.X < num340)
							{
								this.velocity.X = this.velocity.X + num338;
								if (this.velocity.X < 0f)
								{
									this.velocity.X = this.velocity.X + num338;
								}
							}
							if (this.velocity.X > num340)
							{
								this.velocity.X = this.velocity.X - num338;
								if (this.velocity.X > 0f)
								{
									this.velocity.X = this.velocity.X - num338;
								}
							}
							if (this.velocity.Y < num341)
							{
								this.velocity.Y = this.velocity.Y + num338;
								if (this.velocity.Y < 0f)
								{
									this.velocity.Y = this.velocity.Y + num338;
								}
							}
							if (this.velocity.Y > num341)
							{
								this.velocity.Y = this.velocity.Y - num338;
								if (this.velocity.Y > 0f)
								{
									this.velocity.Y = this.velocity.Y - num338;
								}
							}
							this.direction = -Main.player[this.owner].direction;
							this.spriteDirection = 1;
							this.rotation = this.velocity.Y * 0.05f * (float)(-(float)this.direction);
							if (num344 >= 50f)
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
								int num345 = 500;
								if (this.type == 127)
								{
									num345 = 200;
								}
								if (this.type == 208)
								{
									num345 = 300;
								}
								if ((this.type >= 191 && this.type <= 194) || this.type == 266)
								{
									num345 += 40 * this.minionPos;
									if (this.localAI[0] > 0f)
									{
										num345 += 500;
									}
									if (this.type == 266 && this.localAI[0] > 0f)
									{
										num345 += 100;
									}
								}
								if (Main.player[this.owner].rocketDelay2 > 0)
								{
									this.ai[0] = 1f;
								}
								Vector2 vector26 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
								float num346 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector26.X;
								if (this.type >= 191)
								{
									int arg_105A0_0 = this.type;
								}
								float num347 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector26.Y;
								float num348 = (float)Math.Sqrt((double)(num346 * num346 + num347 * num347));
								if (num348 > 2000f)
								{
									this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
									this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
								}
								else if (num348 > (float)num345 || (Math.Abs(num347) > 300f && (((this.type < 191 || this.type > 194) && this.type != 266) || this.localAI[0] <= 0f)))
								{
									if (this.type != 324)
									{
										if (num347 > 0f && this.velocity.Y < 0f)
										{
											this.velocity.Y = 0f;
										}
										if (num347 < 0f && this.velocity.Y > 0f)
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
								float num349 = 0.2f;
								int num350 = 200;
								if (this.type == 127)
								{
									num350 = 100;
								}
								if (this.type >= 191 && this.type <= 194)
								{
									num349 = 0.5f;
									num350 = 100;
								}
								this.tileCollide = false;
								Vector2 vector27 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
								float num351 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector27.X;
								if ((this.type >= 191 && this.type <= 194) || this.type == 266)
								{
									num351 -= (float)(40 * Main.player[this.owner].direction);
									float num352 = 600f;
									bool flag13 = false;
									for (int num353 = 0; num353 < 200; num353++)
									{
										if (Main.npc[num353].active && !Main.npc[num353].dontTakeDamage && !Main.npc[num353].friendly && Main.npc[num353].lifeMax > 5)
										{
											float num354 = Main.npc[num353].position.X + (float)(Main.npc[num353].width / 2);
											float num355 = Main.npc[num353].position.Y + (float)(Main.npc[num353].height / 2);
											float num356 = Math.Abs(Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - num354) + Math.Abs(Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - num355);
											if (num356 < num352)
											{
												flag13 = true;
												break;
											}
										}
									}
									if (!flag13)
									{
										num351 -= (float)(40 * this.minionPos * Main.player[this.owner].direction);
									}
								}
								float num357 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector27.Y;
								if (this.type == 127)
								{
									num357 = Main.player[this.owner].position.Y - vector27.Y;
								}
								float num358 = (float)Math.Sqrt((double)(num351 * num351 + num357 * num357));
								float num359 = 10f;
								float num360 = num358;
								if (this.type == 111)
								{
									num359 = 11f;
								}
								if (this.type == 127)
								{
									num359 = 9f;
								}
								if (this.type == 324)
								{
									num359 = 20f;
								}
								if (this.type >= 191 && this.type <= 194)
								{
									num349 = 0.4f;
									num359 = 12f;
									if (num359 < Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y))
									{
										num359 = Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y);
									}
								}
								if (this.type == 208 && Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y) > 4f)
								{
									num350 = -1;
								}
								if (num358 < (float)num350 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
								{
									this.ai[0] = 0f;
									if (this.velocity.Y < -6f)
									{
										this.velocity.Y = -6f;
									}
								}
								if (num358 < 60f)
								{
									num351 = this.velocity.X;
									num357 = this.velocity.Y;
								}
								else
								{
									num358 = num359 / num358;
									num351 *= num358;
									num357 *= num358;
								}
								if (this.type == 324)
								{
									if (num360 > 1000f)
									{
										if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) < (double)num359 - 1.25)
										{
											this.velocity *= 1.025f;
										}
										if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) > (double)num359 + 1.25)
										{
											this.velocity *= 0.975f;
										}
									}
									else if (num360 > 600f)
									{
										if (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) < num359 - 1f)
										{
											this.velocity *= 1.05f;
										}
										if (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > num359 + 1f)
										{
											this.velocity *= 0.95f;
										}
									}
									else if (num360 > 400f)
									{
										if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) < (double)num359 - 0.5)
										{
											this.velocity *= 1.075f;
										}
										if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) > (double)num359 + 0.5)
										{
											this.velocity *= 0.925f;
										}
									}
									else
									{
										if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) < (double)num359 - 0.25)
										{
											this.velocity *= 1.1f;
										}
										if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) > (double)num359 + 0.25)
										{
											this.velocity *= 0.9f;
										}
									}
									this.velocity.X = (this.velocity.X * 34f + num351) / 35f;
									this.velocity.Y = (this.velocity.Y * 34f + num357) / 35f;
								}
								else
								{
									if (this.velocity.X < num351)
									{
										this.velocity.X = this.velocity.X + num349;
										if (this.velocity.X < 0f)
										{
											this.velocity.X = this.velocity.X + num349 * 1.5f;
										}
									}
									if (this.velocity.X > num351)
									{
										this.velocity.X = this.velocity.X - num349;
										if (this.velocity.X > 0f)
										{
											this.velocity.X = this.velocity.X - num349 * 1.5f;
										}
									}
									if (this.velocity.Y < num357)
									{
										this.velocity.Y = this.velocity.Y + num349;
										if (this.velocity.Y < 0f)
										{
											this.velocity.Y = this.velocity.Y + num349 * 1.5f;
										}
									}
									if (this.velocity.Y > num357)
									{
										this.velocity.Y = this.velocity.Y - num349;
										if (this.velocity.Y > 0f)
										{
											this.velocity.Y = this.velocity.Y - num349 * 1.5f;
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
								else if (this.type == 334)
								{
									this.frameCounter++;
									if (this.frameCounter > 1)
									{
										this.frame++;
										this.frameCounter = 0;
									}
									if (this.frame < 7 || this.frame > 10)
									{
										this.frame = 7;
									}
									this.rotation = this.velocity.X * 0.1f;
								}
								else if (this.type == 353)
								{
									this.frameCounter++;
									if (this.frameCounter > 6)
									{
										this.frame++;
										this.frameCounter = 0;
									}
									if (this.frame < 10 || this.frame > 13)
									{
										this.frame = 10;
									}
									this.rotation = this.velocity.X * 0.05f;
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
									for (int num361 = 0; num361 < 2; num361++)
									{
										int num362 = 4;
										int num363 = Dust.NewDust(new Vector2(this.center().X - (float)num362, this.center().Y - (float)num362) - this.velocity * 0f, num362 * 2, num362 * 2, 6, 0f, 0f, 100, default(Color), 1f);
										Main.dust[num363].scale *= 1.8f + (float)Main.rand.Next(10) * 0.1f;
										Main.dust[num363].velocity *= 0.2f;
										if (num361 == 1)
										{
											Main.dust[num363].position -= this.velocity * 0.5f;
										}
										Main.dust[num363].noGravity = true;
										num363 = Dust.NewDust(new Vector2(this.center().X - (float)num362, this.center().Y - (float)num362) - this.velocity * 0f, num362 * 2, num362 * 2, 31, 0f, 0f, 100, default(Color), 0.5f);
										Main.dust[num363].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
										Main.dust[num363].velocity *= 0.05f;
										if (num361 == 1)
										{
											Main.dust[num363].position -= this.velocity * 0.5f;
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
								if (this.type != 127 && this.type != 200 && this.type != 208 && this.type != 210 && this.type != 236 && this.type != 266 && this.type != 268 && this.type != 269 && this.type != 313 && this.type != 314 && this.type != 319 && this.type != 324 && this.type != 334 && this.type != 353)
								{
									int num364 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) - 4f, this.position.Y + (float)(this.height / 2) - 4f) - this.velocity, 8, 8, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.7f);
									Main.dust[num364].velocity.X = Main.dust[num364].velocity.X * 0.2f;
									Main.dust[num364].velocity.Y = Main.dust[num364].velocity.Y * 0.2f;
									Main.dust[num364].noGravity = true;
									return;
								}
							}
							else
							{
								if (this.type >= 191 && this.type <= 194)
								{
									float num365 = (float)(40 * this.minionPos);
									int num366 = 30;
									int num367 = 60;
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
										float num368 = this.position.X;
										float num369 = this.position.Y;
										float num370 = 100000f;
										float num371 = num370;
										int num372 = -1;
										for (int num373 = 0; num373 < 200; num373++)
										{
											if (Main.npc[num373].active && !Main.npc[num373].dontTakeDamage && !Main.npc[num373].friendly && Main.npc[num373].lifeMax > 5)
											{
												float num374 = Main.npc[num373].position.X + (float)(Main.npc[num373].width / 2);
												float num375 = Main.npc[num373].position.Y + (float)(Main.npc[num373].height / 2);
												float num376 = Math.Abs(this.position.X + (float)(this.width / 2) - num374) + Math.Abs(this.position.Y + (float)(this.height / 2) - num375);
												if (num376 < num370)
												{
													if (num372 == -1 && num376 <= num371)
													{
														num371 = num376;
														num368 = num374;
														num369 = num375;
													}
													if (Collision.CanHit(this.position, this.width, this.height, Main.npc[num373].position, Main.npc[num373].width, Main.npc[num373].height))
													{
														num370 = num376;
														num368 = num374;
														num369 = num375;
														num372 = num373;
													}
												}
											}
										}
										if (num372 == -1 && num371 < num370)
										{
											num370 = num371;
										}
										float num377 = 400f;
										if ((double)this.position.Y > Main.worldSurface * 16.0)
										{
											num377 = 200f;
										}
										if (num370 < num377 + num365 && num372 == -1)
										{
											float num378 = num368 - (this.position.X + (float)(this.width / 2));
											if (num378 < -5f)
											{
												flag9 = true;
												flag10 = false;
											}
											else if (num378 > 5f)
											{
												flag10 = true;
												flag9 = false;
											}
										}
										else if (num372 >= 0 && num370 < 800f + num365)
										{
											this.localAI[0] = (float)num367;
											float num379 = num368 - (this.position.X + (float)(this.width / 2));
											if (num379 > 300f || num379 < -300f)
											{
												if (num379 < -50f)
												{
													flag9 = true;
													flag10 = false;
												}
												else if (num379 > 50f)
												{
													flag10 = true;
													flag9 = false;
												}
											}
											else if (this.owner == Main.myPlayer)
											{
												this.ai[1] = (float)num366;
												float num380 = 12f;
												Vector2 vector28 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)(this.height / 2) - 8f);
												float num381 = num368 - vector28.X + (float)Main.rand.Next(-20, 21);
												float num382 = Math.Abs(num381) * 0.1f;
												num382 = num382 * (float)Main.rand.Next(0, 100) * 0.001f;
												float num383 = num369 - vector28.Y + (float)Main.rand.Next(-20, 21) - num382;
												float num384 = (float)Math.Sqrt((double)(num381 * num381 + num383 * num383));
												num384 = num380 / num384;
												num381 *= num384;
												num383 *= num384;
												int num385 = this.damage;
												int num386 = 195;
												int num387 = Projectile.NewProjectile(vector28.X, vector28.Y, num381, num383, num386, num385, this.knockBack, Main.myPlayer, 0f, 0f);
												Main.projectile[num387].timeLeft = 300;
												if (num381 < 0f)
												{
													this.direction = -1;
												}
												if (num381 > 0f)
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
									float num388 = (float)(40 * this.minionPos);
									int num389 = 60;
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
										float num390 = this.position.X;
										float num391 = this.position.Y;
										float num392 = 100000f;
										float num393 = num392;
										int num394 = -1;
										for (int num395 = 0; num395 < 200; num395++)
										{
											if (Main.npc[num395].active && !Main.npc[num395].dontTakeDamage && !Main.npc[num395].friendly && Main.npc[num395].lifeMax > 5)
											{
												float num396 = Main.npc[num395].position.X + (float)(Main.npc[num395].width / 2);
												float num397 = Main.npc[num395].position.Y + (float)(Main.npc[num395].height / 2);
												float num398 = Math.Abs(this.position.X + (float)(this.width / 2) - num396) + Math.Abs(this.position.Y + (float)(this.height / 2) - num397);
												if (num398 < num392)
												{
													if (num394 == -1 && num398 <= num393)
													{
														num393 = num398;
														num390 = num396;
														num391 = num397;
													}
													if (Collision.CanHit(this.position, this.width, this.height, Main.npc[num395].position, Main.npc[num395].width, Main.npc[num395].height))
													{
														num392 = num398;
														num390 = num396;
														num391 = num397;
														num394 = num395;
													}
												}
											}
										}
										if (num394 == -1 && num393 < num392)
										{
											num392 = num393;
										}
										float num399 = 300f;
										if ((double)this.position.Y > Main.worldSurface * 16.0)
										{
											num399 = 150f;
										}
										if (num392 < num399 + num388 && num394 == -1)
										{
											float num400 = num390 - (this.position.X + (float)(this.width / 2));
											if (num400 < -5f)
											{
												flag9 = true;
												flag10 = false;
											}
											else if (num400 > 5f)
											{
												flag10 = true;
												flag9 = false;
											}
										}
										if (num394 >= 0 && num392 < 800f + num388)
										{
											this.friendly = true;
											this.localAI[0] = (float)num389;
											float num401 = num390 - (this.position.X + (float)(this.width / 2));
											if (num401 < -10f)
											{
												flag9 = true;
												flag10 = false;
											}
											else if (num401 > 10f)
											{
												flag10 = true;
												flag9 = false;
											}
											if (num391 < this.center().Y - 100f && num401 > -50f && num401 < 50f && this.velocity.Y == 0f)
											{
												float num402 = Math.Abs(num391 - this.center().Y);
												if (num402 < 120f)
												{
													this.velocity.Y = -10f;
												}
												else if (num402 < 210f)
												{
													this.velocity.Y = -13f;
												}
												else if (num402 < 270f)
												{
													this.velocity.Y = -15f;
												}
												else if (num402 < 310f)
												{
													this.velocity.Y = -17f;
												}
												else if (num402 < 380f)
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
									flag9 = false;
									flag10 = false;
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
								float num403 = 0.08f;
								float num404 = 6.5f;
								if (this.type == 127)
								{
									num404 = 2f;
									num403 = 0.04f;
								}
								if (this.type == 112)
								{
									num404 = 6f;
									num403 = 0.06f;
								}
								if (this.type == 334)
								{
									num404 = 8f;
									num403 = 0.08f;
								}
								if (this.type == 268)
								{
									num404 = 8f;
									num403 = 0.4f;
								}
								if (this.type == 324)
								{
									num403 = 0.1f;
									num404 = 3f;
								}
								if ((this.type >= 191 && this.type <= 194) || this.type == 266)
								{
									num404 = 6f;
									num403 = 0.2f;
									if (num404 < Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y))
									{
										num404 = Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y);
										num403 = 0.3f;
									}
								}
								if (flag9)
								{
									if ((double)this.velocity.X > -3.5)
									{
										this.velocity.X = this.velocity.X - num403;
									}
									else
									{
										this.velocity.X = this.velocity.X - num403 * 0.25f;
									}
								}
								else if (flag10)
								{
									if ((double)this.velocity.X < 3.5)
									{
										this.velocity.X = this.velocity.X + num403;
									}
									else
									{
										this.velocity.X = this.velocity.X + num403 * 0.25f;
									}
								}
								else
								{
									this.velocity.X = this.velocity.X * 0.9f;
									if (this.velocity.X >= -num403 && this.velocity.X <= num403)
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
									flag9 = false;
									flag10 = false;
								}
								if (flag9 || flag10)
								{
									int num405 = (int)(this.position.X + (float)(this.width / 2)) / 16;
									int j2 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
									if (this.type == 236)
									{
										num405 += this.direction;
									}
									if (flag9)
									{
										num405--;
									}
									if (flag10)
									{
										num405++;
									}
									num405 += (int)this.velocity.X;
									if (WorldGen.SolidTile(num405, j2))
									{
										flag12 = true;
									}
								}
								if (Main.player[this.owner].position.Y + (float)Main.player[this.owner].height - 8f > this.position.Y + (float)this.height)
								{
									flag11 = true;
								}
								if (this.type == 268 && this.frameCounter < 10)
								{
									flag12 = false;
								}
								if (this.velocity.Y >= 0f)
								{
									int num406 = 0;
									if (this.velocity.X < 0f)
									{
										num406 = -1;
									}
									if (this.velocity.X > 0f)
									{
										num406 = 1;
									}
									Vector2 vector29 = this.position;
									vector29.X += this.velocity.X;
									int num407 = (int)((vector29.X + (float)(this.width / 2) + (float)((this.width / 2 + 1) * num406)) / 16f);
									int num408 = (int)((vector29.Y + (float)this.height - 1f) / 16f);
									bool flag14 = false;
									if (Main.tile[num407, num408] == null)
									{
										Main.tile[num407, num408] = new Tile();
									}
									if (num408 - 1 > 0 && Main.tile[num407, num408 - 1] == null)
									{
										Main.tile[num407, num408 - 1] = new Tile();
									}
									if (num408 - 2 > 0 && Main.tile[num407, num408 - 2] == null)
									{
										Main.tile[num407, num408 - 2] = new Tile();
									}
									if (num408 - 3 > 0 && Main.tile[num407, num408 - 3] == null)
									{
										Main.tile[num407, num408 - 3] = new Tile();
									}
									if (num408 - 4 > 0 && Main.tile[num407, num408 - 4] == null)
									{
										Main.tile[num407, num408 - 4] = new Tile();
									}
									if (num408 - 3 > 0 && Main.tile[num407 - num406, num408 - 3] == null)
									{
										Main.tile[num407 - num406, num408 - 3] = new Tile();
									}
									if ((float)(num407 * 16) < vector29.X + (float)this.width && (float)(num407 * 16 + 16) > vector29.X && ((Main.tile[num407, num408].nactive() && (Main.tile[num407, num408].slope() == 0 || (Main.tile[num407, num408].slope() == 1 && this.position.X + (float)(this.width / 2) < (float)(num407 * 16)) || (Main.tile[num407, num408].slope() == 2 && this.position.X + (float)(this.width / 2) > (float)(num407 * 16 + 16))) && (Main.tile[num407, num408 - 1].slope() == 0 || this.position.Y + (float)this.height > (float)(num408 * 16)) && ((Main.tileSolid[(int)Main.tile[num407, num408].type] && !Main.tileSolidTop[(int)Main.tile[num407, num408].type]) || (flag14 && Main.tileSolidTop[(int)Main.tile[num407, num408].type] && Main.tile[num407, num408].frameY == 0 && (!Main.tileSolid[(int)Main.tile[num407, num408 - 1].type] || !Main.tile[num407, num408 - 1].nactive())))) || (Main.tile[num407, num408 - 1].halfBrick() && Main.tile[num407, num408 - 1].nactive())) && (!Main.tile[num407, num408 - 1].nactive() || !Main.tileSolid[(int)Main.tile[num407, num408 - 1].type] || Main.tileSolidTop[(int)Main.tile[num407, num408 - 1].type] || Main.tile[num407, num408 - 1].slope() != 0 || (Main.tile[num407, num408 - 1].halfBrick() && (!Main.tile[num407, num408 - 4].nactive() || !Main.tileSolid[(int)Main.tile[num407, num408 - 4].type] || Main.tileSolidTop[(int)Main.tile[num407, num408 - 4].type]))) && (!Main.tile[num407, num408 - 2].nactive() || !Main.tileSolid[(int)Main.tile[num407, num408 - 2].type] || Main.tileSolidTop[(int)Main.tile[num407, num408 - 2].type]) && (!Main.tile[num407, num408 - 3].nactive() || !Main.tileSolid[(int)Main.tile[num407, num408 - 3].type] || Main.tileSolidTop[(int)Main.tile[num407, num408 - 3].type]) && (!Main.tile[num407 - num406, num408 - 3].nactive() || !Main.tileSolid[(int)Main.tile[num407 - num406, num408 - 3].type] || Main.tileSolidTop[(int)Main.tile[num407 - num406, num408 - 3].type]))
									{
										float num409 = (float)(num408 * 16);
										if (Main.tile[num407, num408].halfBrick())
										{
											num409 += 8f;
										}
										if (Main.tile[num407, num408 - 1].halfBrick())
										{
											num409 -= 8f;
										}
										if (num409 < vector29.Y + (float)this.height)
										{
											float num410 = vector29.Y + (float)this.height - num409;
											if ((double)num410 <= 16.1)
											{
												this.gfxOffY += this.position.Y + (float)this.height - num409;
												this.position.Y = num409 - (float)this.height;
												if (num410 < 9f)
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
									if (!flag11 && (this.velocity.X < 0f || this.velocity.X > 0f))
									{
										int num411 = (int)(this.position.X + (float)(this.width / 2)) / 16;
										int j3 = (int)(this.position.Y + (float)(this.height / 2)) / 16 + 1;
										if (flag9)
										{
											num411--;
										}
										if (flag10)
										{
											num411++;
										}
										WorldGen.SolidTile(num411, j3);
									}
									if (flag12)
									{
										int num412 = (int)(this.position.X + (float)(this.width / 2)) / 16;
										int num413 = (int)(this.position.Y + (float)this.height) / 16 + 1;
										if (WorldGen.SolidTile(num412, num413) || Main.tile[num412, num413].halfBrick() || Main.tile[num412, num413].slope() > 0 || this.type == 200)
										{
											if (this.type == 200)
											{
												this.velocity.Y = -3.1f;
											}
											else
											{
												try
												{
													num412 = (int)(this.position.X + (float)(this.width / 2)) / 16;
													num413 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
													if (flag9)
													{
														num412--;
													}
													if (flag10)
													{
														num412++;
													}
													num412 += (int)this.velocity.X;
													if (!WorldGen.SolidTile(num412, num413 - 1) && !WorldGen.SolidTile(num412, num413 - 2))
													{
														this.velocity.Y = -5.1f;
													}
													else if (!WorldGen.SolidTile(num412, num413 - 2))
													{
														this.velocity.Y = -7.1f;
													}
													else if (WorldGen.SolidTile(num412, num413 - 5))
													{
														this.velocity.Y = -11.1f;
													}
													else if (WorldGen.SolidTile(num412, num413 - 4))
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
									else if (this.type == 266 && (flag9 || flag10))
									{
										this.velocity.Y = this.velocity.Y - 6f;
									}
								}
								if (this.velocity.X > num404)
								{
									this.velocity.X = num404;
								}
								if (this.velocity.X < -num404)
								{
									this.velocity.X = -num404;
								}
								if (this.velocity.X < 0f)
								{
									this.direction = -1;
								}
								if (this.velocity.X > 0f)
								{
									this.direction = 1;
								}
								if (this.velocity.X > num403 && flag10)
								{
									this.direction = 1;
								}
								if (this.velocity.X < -num403 && flag9)
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
											int num414 = 3;
											this.frameCounter++;
											if (this.frameCounter < num414)
											{
												this.frame = 0;
											}
											else if (this.frameCounter < num414 * 2)
											{
												this.frame = 1;
											}
											else if (this.frameCounter < num414 * 3)
											{
												this.frame = 2;
											}
											else if (this.frameCounter < num414 * 4)
											{
												this.frame = 3;
											}
											else
											{
												this.frameCounter = num414 * 4;
											}
										}
										else
										{
											this.velocity.X = this.velocity.X * 0.8f;
											this.frameCounter++;
											int num415 = 3;
											if (this.frameCounter < num415)
											{
												this.frame = 0;
											}
											else if (this.frameCounter < num415 * 2)
											{
												this.frame = 1;
											}
											else if (this.frameCounter < num415 * 3)
											{
												this.frame = 2;
											}
											else if (this.frameCounter < num415 * 4)
											{
												this.frame = 3;
											}
											else if (flag9 || flag10)
											{
												this.velocity.X = this.velocity.X * 2f;
												this.frame = 4;
												this.velocity.Y = -6.1f;
												this.frameCounter = 0;
												for (int num416 = 0; num416 < 4; num416++)
												{
													int num417 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), this.width, 4, 5, 0f, 0f, 0, default(Color), 1f);
													Main.dust[num417].velocity += this.velocity;
													Main.dust[num417].velocity *= 0.4f;
												}
											}
											else
											{
												this.frameCounter = num415 * 4;
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
											int num418 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), this.width, 6, 76, 0f, 0f, 0, default(Color), 1f);
											Main.dust[num418].noGravity = true;
											Main.dust[num418].velocity *= 0.3f;
											Main.dust[num418].noLight = true;
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
									int num419 = (int)(this.center().X / 16f);
									int num420 = (int)(this.center().Y / 16f);
									if (Main.tile[num419, num420] != null && Main.tile[num419, num420].wall > 0)
									{
										this.position.Y = this.position.Y + (float)this.height;
										this.height = 34;
										this.position.Y = this.position.Y - (float)this.height;
										this.position.X = this.position.X + (float)(this.width / 2);
										this.width = 34;
										this.position.X = this.position.X - (float)(this.width / 2);
										float num421 = 4f;
										Vector2 vector30 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
										float num422 = Main.player[this.owner].center().X - vector30.X;
										float num423 = Main.player[this.owner].center().Y - vector30.Y;
										float num424 = (float)Math.Sqrt((double)(num422 * num422 + num423 * num423));
										float num425 = num421 / num424;
										num422 *= num425;
										num423 *= num425;
										if (num424 < 120f)
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
											this.velocity.X = (this.velocity.X * 9f + num422) / 10f;
											this.velocity.Y = (this.velocity.Y * 9f + num423) / 10f;
										}
										if (num424 >= 120f)
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
								else if (this.type == 334)
								{
									if (this.velocity.Y == 0f)
									{
										if (this.velocity.X == 0f)
										{
											if (this.frame > 0)
											{
												this.frameCounter += 2;
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
										else if ((double)this.velocity.X < -0.8 || (double)this.velocity.X > 0.8)
										{
											this.frameCounter += (int)Math.Abs((double)this.velocity.X * 0.75);
											this.frameCounter++;
											if (this.frameCounter > 6)
											{
												this.frame++;
												this.frameCounter = 0;
											}
											if (this.frame >= 7 || this.frame < 1)
											{
												this.frame = 1;
											}
										}
										else if (this.frame > 0)
										{
											this.frameCounter += 2;
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
										this.frame = 2;
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
								else if (this.type == 353)
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
											if (this.frame > 9)
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
									else if (this.velocity.Y < 0f)
									{
										this.frameCounter = 0;
										this.frame = 1;
									}
									else if (this.velocity.Y > 0f)
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
							for (int num426 = 5; num426 < 25; num426++)
							{
								float num427 = this.velocity.X * (30f / (float)num426);
								float num428 = this.velocity.Y * (30f / (float)num426);
								num427 *= 80f;
								num428 *= 80f;
								int num429 = Dust.NewDust(new Vector2(this.position.X - num427, this.position.Y - num428), 8, 8, 27, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 0.9f);
								Main.dust[num429].velocity *= 0.25f;
								Main.dust[num429].velocity -= this.velocity * 5f;
							}
						}
						if (this.localAI[1] > 7f && this.type == 173)
						{
							int num430 = Main.rand.Next(3);
							if (num430 == 0)
							{
								num430 = 15;
							}
							else if (num430 == 1)
							{
								num430 = 57;
							}
							else
							{
								num430 = 58;
							}
							int num431 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 4f + 2f, this.position.Y + 2f - this.velocity.Y * 4f), 8, 8, num430, 0f, 0f, 100, default(Color), 1.25f);
							Main.dust[num431].velocity *= 0.1f;
						}
						if (this.localAI[1] > 7f && this.type == 132)
						{
							int num432 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 4f + 2f, this.position.Y + 2f - this.velocity.Y * 4f), 8, 8, 107, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.25f);
							Main.dust[num432].velocity *= -0.25f;
							num432 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 4f + 2f, this.position.Y + 2f - this.velocity.Y * 4f), 8, 8, 107, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.25f);
							Main.dust[num432].velocity *= -0.25f;
							Main.dust[num432].position -= this.velocity * 0.5f;
						}
						if (this.localAI[1] < 15f)
						{
							this.localAI[1] += 1f;
						}
						else
						{
							if (this.type == 114 || this.type == 115)
							{
								int num433 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 4f), 8, 8, 27, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 0.6f);
								Main.dust[num433].velocity *= -0.25f;
							}
							else if (this.type == 116)
							{
								int num434 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 5f + 2f, this.position.Y + 2f - this.velocity.Y * 5f), 8, 8, 64, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.5f);
								Main.dust[num434].velocity *= -0.25f;
								Main.dust[num434].noGravity = true;
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
							for (int num435 = 0; num435 < 3; num435++)
							{
								int num436 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 137, this.velocity.X, this.velocity.Y, Main.rand.Next(0, 101), default(Color), 1f + (float)Main.rand.Next(-20, 40) * 0.01f);
								Main.dust[num436].noGravity = true;
								Main.dust[num436].velocity *= 0.3f;
							}
						}
						if (this.type == 118)
						{
							for (int num437 = 0; num437 < 2; num437++)
							{
								int num438 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 92, this.velocity.X, this.velocity.Y, 50, default(Color), 1.2f);
								Main.dust[num438].noGravity = true;
								Main.dust[num438].velocity *= 0.3f;
							}
						}
						if (this.type == 119 || this.type == 128)
						{
							for (int num439 = 0; num439 < 3; num439++)
							{
								int num440 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 92, this.velocity.X, this.velocity.Y, 50, default(Color), 1.2f);
								Main.dust[num440].noGravity = true;
								Main.dust[num440].velocity *= 0.3f;
							}
						}
						if (this.type == 309)
						{
							for (int num441 = 0; num441 < 3; num441++)
							{
								int num442 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 185, this.velocity.X, this.velocity.Y, 50, default(Color), 1.2f);
								Main.dust[num442].noGravity = true;
								Main.dust[num442].velocity *= 0.3f;
							}
						}
						if (this.type == 129)
						{
							for (int num443 = 0; num443 < 6; num443++)
							{
								int num444 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 106, this.velocity.X, this.velocity.Y, 100, default(Color), 1f);
								Main.dust[num444].noGravity = true;
								Main.dust[num444].velocity *= 0.1f + (float)Main.rand.Next(4) * 0.1f;
								Main.dust[num444].scale *= 1f + (float)Main.rand.Next(5) * 0.1f;
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
						int num445 = this.type - 121 + 86;
						for (int num446 = 0; num446 < 2; num446++)
						{
							int num447 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num445, this.velocity.X, this.velocity.Y, 50, default(Color), 1.2f);
							Main.dust[num447].noGravity = true;
							Main.dust[num447].velocity *= 0.3f;
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
							int num448 = 110;
							int num449 = 0;
							if (this.type == 146)
							{
								num448 = 111;
								num449 = 2;
							}
							if (this.type == 147)
							{
								num448 = 112;
								num449 = 1;
							}
							if (this.type == 148)
							{
								num448 = 113;
								num449 = 3;
							}
							if (this.type == 149)
							{
								num448 = 114;
								num449 = 4;
							}
							if (this.owner == Main.myPlayer)
							{
								WorldGen.Convert((int)(this.position.X + (float)(this.width / 2)) / 16, (int)(this.position.Y + (float)(this.height / 2)) / 16, num449, 2);
							}
							if (this.timeLeft > 133)
							{
								this.timeLeft = 133;
							}
							if (this.ai[0] > 7f)
							{
								float num450 = 1f;
								if (this.ai[0] == 8f)
								{
									num450 = 0.2f;
								}
								else if (this.ai[0] == 9f)
								{
									num450 = 0.4f;
								}
								else if (this.ai[0] == 10f)
								{
									num450 = 0.6f;
								}
								else if (this.ai[0] == 11f)
								{
									num450 = 0.8f;
								}
								this.ai[0] += 1f;
								for (int num451 = 0; num451 < 1; num451++)
								{
									int num452 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num448, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 1f);
									Main.dust[num452].noGravity = true;
									Main.dust[num452].scale *= 1.75f;
									Dust expr_1679B_cp_0 = Main.dust[num452];
									expr_1679B_cp_0.velocity.X = expr_1679B_cp_0.velocity.X * 2f;
									Dust expr_167BB_cp_0 = Main.dust[num452];
									expr_167BB_cp_0.velocity.Y = expr_167BB_cp_0.velocity.Y * 2f;
									Main.dust[num452].scale *= num450;
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
								for (int num453 = 0; num453 < 255; num453++)
								{
									Rectangle rectangle2 = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
									if (Main.player[num453].active)
									{
										Rectangle value3 = new Rectangle((int)Main.player[num453].position.X, (int)Main.player[num453].position.Y, Main.player[num453].width, Main.player[num453].height);
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
											this.velocity.X = (this.velocity.X + (float)Main.player[num453].direction * 1.75f) / 2f;
											this.velocity.X = this.velocity.X + Main.player[num453].velocity.X * 3f;
											this.velocity.Y = this.velocity.Y + Main.player[num453].velocity.Y;
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
								float num454 = 4f;
								float num455 = this.ai[0];
								float num456 = this.ai[1];
								if (num455 == 0f && num456 == 0f)
								{
									num455 = 1f;
								}
								float num457 = (float)Math.Sqrt((double)(num455 * num455 + num456 * num456));
								num457 = num454 / num457;
								num455 *= num457;
								num456 *= num457;
								if (this.alpha < 70)
								{
									int num458 = 127;
									if (this.type == 310)
									{
										num458 = 187;
									}
									int num459 = Dust.NewDust(new Vector2(this.position.X, this.position.Y - 2f), 6, 6, num458, this.velocity.X, this.velocity.Y, 100, default(Color), 1.6f);
									Main.dust[num459].noGravity = true;
									Dust expr_16DB0_cp_0 = Main.dust[num459];
									expr_16DB0_cp_0.position.X = expr_16DB0_cp_0.position.X - num455 * 1f;
									Dust expr_16DD5_cp_0 = Main.dust[num459];
									expr_16DD5_cp_0.position.Y = expr_16DD5_cp_0.position.Y - num456 * 1f;
									Dust expr_16DFA_cp_0 = Main.dust[num459];
									expr_16DFA_cp_0.velocity.X = expr_16DFA_cp_0.velocity.X - num455;
									Dust expr_16E19_cp_0 = Main.dust[num459];
									expr_16E19_cp_0.velocity.Y = expr_16E19_cp_0.velocity.Y - num456;
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
								int num460 = Dust.NewDust(new Vector2(this.position.X + 2f, this.position.Y + 20f), 8, 8, 6, this.velocity.X, this.velocity.Y, 100, default(Color), 1.2f);
								Main.dust[num460].noGravity = true;
								Main.dust[num460].velocity *= 0.2f;
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
									Vector2 vector31 = Collision.TileCollision(this.position, this.velocity, this.width, this.height, true, true);
									if (vector31 != this.velocity)
									{
										this.position += vector31;
										int num461 = (int)(this.position.X + (float)(this.width / 2)) / 16;
										int num462 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
										int num463 = 10;
										if (Main.tile[num461, num462] != null)
										{
											while (Main.tile[num461, num462] != null && Main.tile[num461, num462].active())
											{
												if (!Main.tileRope[(int)Main.tile[num461, num462].type])
												{
													break;
												}
												num462++;
											}
											while (num463 > 0)
											{
												num463--;
												if (Main.tile[num461, num462] == null)
												{
													break;
												}
												if (Main.tile[num461, num462].active() && (Main.tileCut[(int)Main.tile[num461, num462].type] || Main.tile[num461, num462].type == 165))
												{
													WorldGen.KillTile(num461, num462, false, false, false);
													NetMessage.SendData(17, -1, -1, "", 0, (float)num461, (float)num462, 0f, 0);
												}
												if (!Main.tile[num461, num462].active())
												{
													WorldGen.PlaceTile(num461, num462, 213, false, false, -1, 0);
													NetMessage.SendData(17, -1, -1, "", 1, (float)num461, (float)num462, 213f, 0);
													this.ai[1] += 1f;
												}
												else
												{
													num463 = 0;
												}
												num462++;
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
									for (int num464 = 0; num464 < 3; num464++)
									{
										float num465 = this.velocity.X / 3f * (float)num464;
										float num466 = this.velocity.Y / 3f * (float)num464;
										int num467 = Dust.NewDust(this.position, this.width, this.height, 184, 0f, 0f, 0, default(Color), 1f);
										Main.dust[num467].position.X = this.center().X - num465;
										Main.dust[num467].position.Y = this.center().Y - num466;
										Main.dust[num467].velocity *= 0f;
										Main.dust[num467].scale = 0.5f;
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
								float num468 = this.position.X;
								float num469 = this.position.Y;
								float num470 = 100000f;
								bool flag15 = false;
								this.ai[0] += 1f;
								if (this.ai[0] > 30f)
								{
									this.ai[0] = 30f;
									for (int num471 = 0; num471 < 200; num471++)
									{
										if (Main.npc[num471].active && !Main.npc[num471].dontTakeDamage && !Main.npc[num471].friendly && Main.npc[num471].lifeMax > 5 && (!Main.npc[num471].wet || this.type == 307))
										{
											float num472 = Main.npc[num471].position.X + (float)(Main.npc[num471].width / 2);
											float num473 = Main.npc[num471].position.Y + (float)(Main.npc[num471].height / 2);
											float num474 = Math.Abs(this.position.X + (float)(this.width / 2) - num472) + Math.Abs(this.position.Y + (float)(this.height / 2) - num473);
											if (num474 < 800f && num474 < num470 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num471].position, Main.npc[num471].width, Main.npc[num471].height))
											{
												num470 = num474;
												num468 = num472;
												num469 = num473;
												flag15 = true;
											}
										}
									}
								}
								if (!flag15)
								{
									num468 = this.position.X + (float)(this.width / 2) + this.velocity.X * 100f;
									num469 = this.position.Y + (float)(this.height / 2) + this.velocity.Y * 100f;
								}
								else if (this.type == 307)
								{
									this.friendly = true;
								}
								float num475 = 6f;
								float num476 = 0.1f;
								if (this.type == 189)
								{
									num475 = 7f;
									num476 = 0.15f;
								}
								if (this.type == 307)
								{
									num475 = 9f;
									num476 = 0.2f;
								}
								if (this.type == 316)
								{
									num475 = 10f;
									num476 = 0.25f;
								}
								Vector2 vector32 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
								float num477 = num468 - vector32.X;
								float num478 = num469 - vector32.Y;
								float num479 = (float)Math.Sqrt((double)(num477 * num477 + num478 * num478));
								num479 = num475 / num479;
								num477 *= num479;
								num478 *= num479;
								if (this.velocity.X < num477)
								{
									this.velocity.X = this.velocity.X + num476;
									if (this.velocity.X < 0f && num477 > 0f)
									{
										this.velocity.X = this.velocity.X + num476 * 2f;
									}
								}
								else if (this.velocity.X > num477)
								{
									this.velocity.X = this.velocity.X - num476;
									if (this.velocity.X > 0f && num477 < 0f)
									{
										this.velocity.X = this.velocity.X - num476 * 2f;
									}
								}
								if (this.velocity.Y < num478)
								{
									this.velocity.Y = this.velocity.Y + num476;
									if (this.velocity.Y < 0f && num478 > 0f)
									{
										this.velocity.Y = this.velocity.Y + num476 * 2f;
										return;
									}
								}
								else if (this.velocity.Y > num478)
								{
									this.velocity.Y = this.velocity.Y - num476;
									if (this.velocity.Y > 0f && num478 < 0f)
									{
										this.velocity.Y = this.velocity.Y - num476 * 2f;
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
									float num480 = this.position.Y - this.ai[1];
									if (num480 > 300f)
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
								Vector2 vector33 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
								float num481 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector33.X;
								float num482 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector33.Y;
								float num483 = (float)Math.Sqrt((double)(num481 * num481 + num482 * num482));
								if (!Main.player[this.owner].channel && this.alpha == 0)
								{
									this.ai[0] = 1f;
									this.ai[1] = -1f;
								}
								if (this.ai[1] > 0f && num483 > 1500f)
								{
									this.ai[1] = 0f;
									this.ai[0] = 1f;
								}
								if (this.ai[1] > 0f)
								{
									this.tileCollide = false;
									int num484 = (int)this.ai[1] - 1;
									if (Main.npc[num484].active && Main.npc[num484].life > 0)
									{
										float num485 = 16f;
										vector33 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
										num481 = Main.npc[num484].position.X + (float)(Main.npc[num484].width / 2) - vector33.X;
										num482 = Main.npc[num484].position.Y + (float)(Main.npc[num484].height / 2) - vector33.Y;
										num483 = (float)Math.Sqrt((double)(num481 * num481 + num482 * num482));
										if (num483 < num485)
										{
											this.velocity.X = num481;
											this.velocity.Y = num482;
											if (num483 > num485 / 2f)
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
											num483 = num485 / num483;
											num481 *= num483;
											num482 *= num483;
											this.velocity.X = num481;
											this.velocity.Y = num482;
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
										float num486 = this.position.X;
										float num487 = this.position.Y;
										float num488 = 3000f;
										int num489 = -1;
										for (int num490 = 0; num490 < 200; num490++)
										{
											if (Main.npc[num490].active && !Main.npc[num490].friendly && Main.npc[num490].lifeMax > 5)
											{
												float num491 = Main.npc[num490].position.X + (float)(Main.npc[num490].width / 2);
												float num492 = Main.npc[num490].position.Y + (float)(Main.npc[num490].height / 2);
												float num493 = Math.Abs(this.position.X + (float)(this.width / 2) - num491) + Math.Abs(this.position.Y + (float)(this.height / 2) - num492);
												if (num493 < num488 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num490].position, Main.npc[num490].width, Main.npc[num490].height))
												{
													num488 = num493;
													num486 = num491;
													num487 = num492;
													num489 = num490;
												}
											}
										}
										if (num489 >= 0)
										{
											float num494 = 16f;
											vector33 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
											num481 = num486 - vector33.X;
											num482 = num487 - vector33.Y;
											num483 = (float)Math.Sqrt((double)(num481 * num481 + num482 * num482));
											num483 = num494 / num483;
											num481 *= num483;
											num482 *= num483;
											this.velocity.X = num481;
											this.velocity.Y = num482;
											this.ai[0] = 0f;
											this.ai[1] = (float)(num489 + 1);
										}
									}
								}
								else if (this.ai[0] == 0f)
								{
									if (num483 > 700f)
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
									float num495 = 20f;
									if (num483 < 70f)
									{
										this.Kill();
									}
									num483 = num495 / num483;
									num481 *= num483;
									num482 *= num483;
									this.velocity.X = num481;
									this.velocity.Y = num482;
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
									float num496 = (float)Main.mouseTextColor / 200f - 0.35f;
									num496 *= 0.2f;
									this.scale = num496 + 0.95f;
									if (this.owner == Main.myPlayer)
									{
										if (this.ai[0] != 0f)
										{
											this.ai[0] -= 1f;
											return;
										}
										float num497 = this.position.X;
										float num498 = this.position.Y;
										float num499 = 700f;
										bool flag16 = false;
										for (int num500 = 0; num500 < 200; num500++)
										{
											if (Main.npc[num500].active && !Main.npc[num500].friendly && Main.npc[num500].lifeMax > 5)
											{
												float num501 = Main.npc[num500].position.X + (float)(Main.npc[num500].width / 2);
												float num502 = Main.npc[num500].position.Y + (float)(Main.npc[num500].height / 2);
												float num503 = Math.Abs(this.position.X + (float)(this.width / 2) - num501) + Math.Abs(this.position.Y + (float)(this.height / 2) - num502);
												if (num503 < num499 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num500].position, Main.npc[num500].width, Main.npc[num500].height))
												{
													num499 = num503;
													num497 = num501;
													num498 = num502;
													flag16 = true;
												}
											}
										}
										if (flag16)
										{
											float num504 = 12f;
											Vector2 vector34 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
											float num505 = num497 - vector34.X;
											float num506 = num498 - vector34.Y;
											float num507 = (float)Math.Sqrt((double)(num505 * num505 + num506 * num506));
											num507 = num504 / num507;
											num505 *= num507;
											num506 *= num507;
											Projectile.NewProjectile(this.center().X - 4f, this.center().Y, num505, num506, 227, 40, 5f, this.owner, 0f, 0f);
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
											for (int num508 = 0; num508 < 5; num508++)
											{
												int num509 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 157, 0f, 0f, 0, default(Color), 1f);
												Main.dust[num509].noGravity = true;
												Main.dust[num509].velocity *= 3f;
												Main.dust[num509].scale = 1.5f;
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
										int num510 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 157, 0f, 0f, 0, default(Color), 1f);
										Main.dust[num510].noGravity = true;
										Main.dust[num510].velocity *= 0.1f;
										Main.dust[num510].scale = 1.5f;
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
											float num511 = this.ai[0];
											float num512 = this.ai[1];
											if (num511 != 0f && num512 != 0f)
											{
												bool flag17 = false;
												bool flag18 = false;
												if ((this.velocity.X < 0f && this.center().X < num511) || (this.velocity.X > 0f && this.center().X > num511))
												{
													flag17 = true;
												}
												if ((this.velocity.Y < 0f && this.center().Y < num512) || (this.velocity.Y > 0f && this.center().Y > num512))
												{
													flag18 = true;
												}
												if (flag17 && flag18)
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
															int num513 = (int)(this.position.X + 14f + (float)Main.rand.Next(this.width - 28));
															int num514 = (int)(this.position.Y + (float)this.height + 4f);
															Projectile.NewProjectile((float)num513, (float)num514, 0f, 5f, 245, this.damage, 0f, this.owner, 0f, 0f);
														}
													}
												}
												else if (this.ai[0] > 8f)
												{
													this.ai[0] = 0f;
													if (this.owner == Main.myPlayer)
													{
														int num515 = (int)(this.position.X + 14f + (float)Main.rand.Next(this.width - 28));
														int num516 = (int)(this.position.Y + (float)this.height + 4f);
														Projectile.NewProjectile((float)num515, (float)num516, 0f, 5f, 239, this.damage, 0f, this.owner, 0f, 0f);
													}
												}
											}
											this.localAI[0] += 1f;
											if (this.localAI[0] >= 10f)
											{
												this.localAI[0] = 0f;
												int num517 = 0;
												int num518 = 0;
												float num519 = 0f;
												int num520 = this.type;
												for (int num521 = 0; num521 < 1000; num521++)
												{
													if (Main.projectile[num521].active && Main.projectile[num521].owner == this.owner && Main.projectile[num521].type == num520 && Main.projectile[num521].ai[1] < 3600f)
													{
														num517++;
														if (Main.projectile[num521].ai[1] > num519)
														{
															num518 = num521;
															num519 = Main.projectile[num521].ai[1];
														}
													}
												}
												if (this.type == 244)
												{
													if (num517 > 1)
													{
														Main.projectile[num518].netUpdate = true;
														Main.projectile[num518].ai[1] = 36000f;
														return;
													}
												}
												else if (num517 > 2)
												{
													Main.projectile[num518].netUpdate = true;
													Main.projectile[num518].ai[1] = 36000f;
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
											float num522 = 1f;
											if (this.velocity.Y < 0f)
											{
												num522 -= this.velocity.Y / 3f;
											}
											this.ai[0] += num522;
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
											float num523 = this.velocity.X;
											float num524 = this.velocity.Y;
											float num525 = (float)Math.Sqrt((double)(num523 * num523 + num524 * num524));
											num525 = 15.95f * this.scale / num525;
											num523 *= num525;
											num524 *= num525;
											this.velocity.X = num523;
											this.velocity.Y = num524;
											this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) - 1.57f;
											return;
										}
										int num526 = 300;
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
											this.timeLeft = num526;
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
										if (this.timeLeft > num526 - 10)
										{
											int num527 = num526 - this.timeLeft;
											this.alpha = 255 - (int)(255f * (float)num527 / 10f);
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
										for (int num528 = 0; num528 < 1000; num528++)
										{
											if (num528 != this.whoAmI && Main.projectile[num528].active && Main.projectile[num528].owner == this.owner && Main.projectile[num528].type == this.type && this.timeLeft > Main.projectile[num528].timeLeft && Main.projectile[num528].timeLeft > 30)
											{
												Main.projectile[num528].timeLeft = 30;
											}
										}
										int[] array = new int[20];
										int num529 = 0;
										float num530 = 300f;
										bool flag19 = false;
										for (int num531 = 0; num531 < 200; num531++)
										{
											if (Main.npc[num531].active && !Main.npc[num531].dontTakeDamage && !Main.npc[num531].friendly && Main.npc[num531].lifeMax > 5)
											{
												float num532 = Main.npc[num531].position.X + (float)(Main.npc[num531].width / 2);
												float num533 = Main.npc[num531].position.Y + (float)(Main.npc[num531].height / 2);
												float num534 = Math.Abs(this.position.X + (float)(this.width / 2) - num532) + Math.Abs(this.position.Y + (float)(this.height / 2) - num533);
												if (num534 < num530 && Collision.CanHit(this.center(), 1, 1, Main.npc[num531].center(), 1, 1))
												{
													if (num529 < 20)
													{
														array[num529] = num531;
														num529++;
													}
													flag19 = true;
												}
											}
										}
										if (this.timeLeft < 30)
										{
											flag19 = false;
										}
										if (flag19)
										{
											int num535 = Main.rand.Next(num529);
											num535 = array[num535];
											float num536 = Main.npc[num535].position.X + (float)(Main.npc[num535].width / 2);
											float num537 = Main.npc[num535].position.Y + (float)(Main.npc[num535].height / 2);
											this.localAI[0] += 1f;
											if (this.localAI[0] > 8f)
											{
												this.localAI[0] = 0f;
												float num538 = 6f;
												Vector2 value4 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
												value4 += this.velocity * 4f;
												float num539 = num536 - value4.X;
												float num540 = num537 - value4.Y;
												float num541 = (float)Math.Sqrt((double)(num539 * num539 + num540 * num540));
												num541 = num538 / num541;
												num539 *= num541;
												num540 *= num541;
												Projectile.NewProjectile(value4.X, value4.Y, num539, num540, 255, this.damage, this.knockBack, this.owner, 0f, 0f);
												return;
											}
										}
									}
									else if (this.aiStyle == 48)
									{
										if (this.type == 255)
										{
											for (int num542 = 0; num542 < 4; num542++)
											{
												Vector2 value5 = this.position;
												value5 -= this.velocity * ((float)num542 * 0.25f);
												this.alpha = 255;
												int num543 = Dust.NewDust(value5, 1, 1, 160, 0f, 0f, 0, default(Color), 1f);
												Main.dust[num543].position = value5;
												Dust expr_1A00E_cp_0 = Main.dust[num543];
												expr_1A00E_cp_0.position.X = expr_1A00E_cp_0.position.X + (float)(this.width / 2);
												Dust expr_1A032_cp_0 = Main.dust[num543];
												expr_1A032_cp_0.position.Y = expr_1A032_cp_0.position.Y + (float)(this.height / 2);
												Main.dust[num543].scale = (float)Main.rand.Next(70, 110) * 0.013f;
												Main.dust[num543].velocity *= 0.2f;
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
												for (int num544 = 0; num544 < 3; num544++)
												{
													Vector2 value6 = this.position;
													value6 -= this.velocity * ((float)num544 * 0.3334f);
													this.alpha = 255;
													int num545 = Dust.NewDust(value6, 1, 1, 173, 0f, 0f, 0, default(Color), 1f);
													Main.dust[num545].position = value6;
													Main.dust[num545].scale = (float)Main.rand.Next(70, 110) * 0.013f;
													Main.dust[num545].velocity *= 0.2f;
												}
												return;
											}
										}
										else if (this.type == 294)
										{
											this.localAI[0] += 1f;
											if (this.localAI[0] > 9f)
											{
												for (int num546 = 0; num546 < 4; num546++)
												{
													Vector2 value7 = this.position;
													value7 -= this.velocity * ((float)num546 * 0.25f);
													this.alpha = 255;
													int num547 = Dust.NewDust(value7, 1, 1, 173, 0f, 0f, 0, default(Color), 1f);
													Main.dust[num547].position = value7;
													Main.dust[num547].scale = (float)Main.rand.Next(70, 110) * 0.013f;
													Main.dust[num547].velocity *= 0.2f;
												}
												return;
											}
										}
										else
										{
											this.localAI[0] += 1f;
											if (this.localAI[0] > 3f)
											{
												for (int num548 = 0; num548 < 4; num548++)
												{
													Vector2 value8 = this.position;
													value8 -= this.velocity * ((float)num548 * 0.25f);
													this.alpha = 255;
													int num549 = Dust.NewDust(value8, 1, 1, 162, 0f, 0f, 0, default(Color), 1f);
													Main.dust[num549].position = value8;
													Dust expr_1A3CE_cp_0 = Main.dust[num549];
													expr_1A3CE_cp_0.position.X = expr_1A3CE_cp_0.position.X + (float)(this.width / 2);
													Dust expr_1A3F2_cp_0 = Main.dust[num549];
													expr_1A3F2_cp_0.position.Y = expr_1A3F2_cp_0.position.Y + (float)(this.height / 2);
													Main.dust[num549].scale = (float)Main.rand.Next(70, 110) * 0.013f;
													Main.dust[num549].velocity *= 0.2f;
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
													for (int num550 = 0; num550 < 10; num550++)
													{
														int num551 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
														Main.dust[num551].velocity *= 0.5f;
														Main.dust[num551].velocity += this.velocity * 0.1f;
													}
													for (int num552 = 0; num552 < 5; num552++)
													{
														int num553 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
														Main.dust[num553].noGravity = true;
														Main.dust[num553].velocity *= 3f;
														Main.dust[num553].velocity += this.velocity * 0.2f;
														num553 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
														Main.dust[num553].velocity *= 2f;
														Main.dust[num553].velocity += this.velocity * 0.3f;
													}
													for (int num554 = 0; num554 < 1; num554++)
													{
														int num555 = Gore.NewGore(new Vector2(this.position.X - 10f, this.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
														Main.gore[num555].position += this.velocity * 1.25f;
														Main.gore[num555].scale = 1.5f;
														Main.gore[num555].velocity += this.velocity * 0.5f;
														Main.gore[num555].velocity *= 0.02f;
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
											bool flag20 = false;
											bool flag21 = false;
											if (this.velocity.X < 0f && this.position.X < this.ai[0])
											{
												flag20 = true;
											}
											if (this.velocity.X > 0f && this.position.X > this.ai[0])
											{
												flag20 = true;
											}
											if (this.velocity.Y < 0f && this.position.Y < this.ai[1])
											{
												flag21 = true;
											}
											if (this.velocity.Y > 0f && this.position.Y > this.ai[1])
											{
												flag21 = true;
											}
											if (flag20 && flag21)
											{
												this.Kill();
											}
											for (int num556 = 0; num556 < 10; num556++)
											{
												int num557 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 174, 0f, 0f, 100, default(Color), 1.2f);
												Main.dust[num557].noGravity = true;
												Main.dust[num557].velocity *= 0.5f;
												Main.dust[num557].velocity += this.velocity * 0.1f;
											}
											return;
										}
										if (this.type == 295)
										{
											for (int num558 = 0; num558 < 8; num558++)
											{
												int num559 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 174, 0f, 0f, 100, default(Color), 1.2f);
												Main.dust[num559].noGravity = true;
												Main.dust[num559].velocity *= 0.5f;
												Main.dust[num559].velocity += this.velocity * 0.1f;
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
										float num560 = 25f;
										if (this.ai[0] > 180f)
										{
											num560 -= (this.ai[0] - 180f) / 2f;
										}
										if (num560 <= 0f)
										{
											num560 = 0f;
											this.Kill();
										}
										if (this.type == 296)
										{
											num560 *= 0.7f;
										}
										int num561 = 0;
										while ((float)num561 < num560)
										{
											float num562 = (float)Main.rand.Next(-10, 11);
											float num563 = (float)Main.rand.Next(-10, 11);
											float num564 = (float)Main.rand.Next(3, 9);
											float num565 = (float)Math.Sqrt((double)(num562 * num562 + num563 * num563));
											num565 = num564 / num565;
											num562 *= num565;
											num563 *= num565;
											int num566 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 174, 0f, 0f, 100, default(Color), 1.5f);
											Main.dust[num566].noGravity = true;
											Main.dust[num566].position.X = this.center().X;
											Main.dust[num566].position.Y = this.center().Y;
											Dust expr_1AE41_cp_0 = Main.dust[num566];
											expr_1AE41_cp_0.position.X = expr_1AE41_cp_0.position.X + (float)Main.rand.Next(-10, 11);
											Dust expr_1AE6B_cp_0 = Main.dust[num566];
											expr_1AE6B_cp_0.position.Y = expr_1AE6B_cp_0.position.Y + (float)Main.rand.Next(-10, 11);
											Main.dust[num566].velocity.X = num562;
											Main.dust[num566].velocity.Y = num563;
											num561++;
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
												for (int num567 = 0; num567 < 5; num567++)
												{
													int num568 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 175, 0f, 0f, 100, default(Color), 2f);
													Main.dust[num568].noGravity = true;
													Main.dust[num568].velocity *= 0f;
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
											for (int num569 = 0; num569 < 9; num569++)
											{
												int num570 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 175, 0f, 0f, 100, default(Color), 1.3f);
												Main.dust[num570].noGravity = true;
												Main.dust[num570].velocity *= 0f;
											}
										}
										float num571 = this.center().X;
										float num572 = this.center().Y;
										float num573 = 400f;
										bool flag22 = false;
										if (this.type == 297)
										{
											for (int num574 = 0; num574 < 200; num574++)
											{
												if (Main.npc[num574].active && !Main.npc[num574].dontTakeDamage && !Main.npc[num574].friendly && Main.npc[num574].lifeMax > 5 && Collision.CanHit(this.center(), 1, 1, Main.npc[num574].center(), 1, 1))
												{
													float num575 = Main.npc[num574].position.X + (float)(Main.npc[num574].width / 2);
													float num576 = Main.npc[num574].position.Y + (float)(Main.npc[num574].height / 2);
													float num577 = Math.Abs(this.position.X + (float)(this.width / 2) - num575) + Math.Abs(this.position.Y + (float)(this.height / 2) - num576);
													if (num577 < num573)
													{
														num573 = num577;
														num571 = num575;
														num572 = num576;
														flag22 = true;
													}
												}
											}
										}
										else
										{
											num573 = 200f;
											for (int num578 = 0; num578 < 255; num578++)
											{
												if (Main.player[num578].active && !Main.player[num578].dead)
												{
													float num579 = Main.player[num578].position.X + (float)(Main.player[num578].width / 2);
													float num580 = Main.player[num578].position.Y + (float)(Main.player[num578].height / 2);
													float num581 = Math.Abs(this.position.X + (float)(this.width / 2) - num579) + Math.Abs(this.position.Y + (float)(this.height / 2) - num580);
													if (num581 < num573)
													{
														num573 = num581;
														num571 = num579;
														num572 = num580;
														flag22 = true;
													}
												}
											}
										}
										if (flag22)
										{
											float num582 = 3f;
											if (this.type == 297)
											{
												num582 = 6f;
											}
											Vector2 vector35 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
											float num583 = num571 - vector35.X;
											float num584 = num572 - vector35.Y;
											float num585 = (float)Math.Sqrt((double)(num583 * num583 + num584 * num584));
											num585 = num582 / num585;
											num583 *= num585;
											num584 *= num585;
											if (this.type == 297)
											{
												this.velocity.X = (this.velocity.X * 20f + num583) / 21f;
												this.velocity.Y = (this.velocity.Y * 20f + num584) / 21f;
												return;
											}
											this.velocity.X = (this.velocity.X * 100f + num583) / 101f;
											this.velocity.Y = (this.velocity.Y * 100f + num584) / 101f;
											return;
										}
									}
									else if (this.aiStyle == 52)
									{
										int num586 = (int)this.ai[0];
										float num587 = 4f;
										Vector2 vector36 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
										float num588 = Main.player[num586].center().X - vector36.X;
										float num589 = Main.player[num586].center().Y - vector36.Y;
										float num590 = (float)Math.Sqrt((double)(num588 * num588 + num589 * num589));
										if (num590 < 50f && this.position.X < Main.player[num586].position.X + (float)Main.player[num586].width && this.position.X + (float)this.width > Main.player[num586].position.X && this.position.Y < Main.player[num586].position.Y + (float)Main.player[num586].height && this.position.Y + (float)this.height > Main.player[num586].position.Y)
										{
											if (this.owner == Main.myPlayer)
											{
												int num591 = (int)this.ai[1];
												Main.player[num586].HealEffect(num591, false);
												Main.player[num586].statLife += num591;
												if (Main.player[num586].statLife > Main.player[num586].statLifeMax)
												{
													Main.player[num586].statLife = Main.player[num586].statLifeMax;
												}
												NetMessage.SendData(66, -1, -1, "", num586, (float)num591, 0f, 0f, 0);
											}
											this.Kill();
										}
										num590 = num587 / num590;
										num588 *= num590;
										num589 *= num590;
										this.velocity.X = (this.velocity.X * 15f + num588) / 16f;
										this.velocity.Y = (this.velocity.Y * 15f + num589) / 16f;
										if (this.type == 305)
										{
											for (int num592 = 0; num592 < 3; num592++)
											{
												float num593 = this.velocity.X * 0.334f * (float)num592;
												float num594 = -(this.velocity.Y * 0.334f) * (float)num592;
												int num595 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 183, 0f, 0f, 100, default(Color), 1.1f);
												Main.dust[num595].noGravity = true;
												Main.dust[num595].velocity *= 0f;
												Dust expr_1B868_cp_0 = Main.dust[num595];
												expr_1B868_cp_0.position.X = expr_1B868_cp_0.position.X - num593;
												Dust expr_1B887_cp_0 = Main.dust[num595];
												expr_1B887_cp_0.position.Y = expr_1B887_cp_0.position.Y - num594;
											}
											return;
										}
										for (int num596 = 0; num596 < 5; num596++)
										{
											float num597 = this.velocity.X * 0.2f * (float)num596;
											float num598 = -(this.velocity.Y * 0.2f) * (float)num596;
											int num599 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 175, 0f, 0f, 100, default(Color), 1.3f);
											Main.dust[num599].noGravity = true;
											Main.dust[num599].velocity *= 0f;
											Dust expr_1B97F_cp_0 = Main.dust[num599];
											expr_1B97F_cp_0.position.X = expr_1B97F_cp_0.position.X - num597;
											Dust expr_1B99E_cp_0 = Main.dust[num599];
											expr_1B99E_cp_0.position.Y = expr_1B99E_cp_0.position.Y - num598;
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
											int num600 = 80;
											Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 46);
											for (int num601 = 0; num601 < num600; num601++)
											{
												int num602 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 16f), this.width, this.height - 16, 185, 0f, 0f, 0, default(Color), 1f);
												Main.dust[num602].velocity *= 2f;
												Main.dust[num602].noGravity = true;
												Main.dust[num602].scale *= 1.15f;
											}
										}
										this.velocity.X = 0f;
										this.velocity.Y = this.velocity.Y + 0.2f;
										if (this.velocity.Y > 16f)
										{
											this.velocity.Y = 16f;
										}
										bool flag23 = false;
										float num603 = this.center().X;
										float num604 = this.center().Y;
										float num605 = 1000f;
										for (int num606 = 0; num606 < 200; num606++)
										{
											if (Main.npc[num606].active && !Main.npc[num606].dontTakeDamage && !Main.npc[num606].friendly && Main.npc[num606].lifeMax > 5)
											{
												float num607 = Main.npc[num606].position.X + (float)(Main.npc[num606].width / 2);
												float num608 = Main.npc[num606].position.Y + (float)(Main.npc[num606].height / 2);
												float num609 = Math.Abs(this.position.X + (float)(this.width / 2) - num607) + Math.Abs(this.position.Y + (float)(this.height / 2) - num608);
												if (num609 < num605 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num606].position, Main.npc[num606].width, Main.npc[num606].height))
												{
													num605 = num609;
													num603 = num607;
													num604 = num608;
													flag23 = true;
												}
											}
										}
										if (flag23)
										{
											float num610 = num603;
											float num611 = num604;
											num603 -= this.center().X;
											num604 -= this.center().Y;
											if (num603 < 0f)
											{
												this.spriteDirection = -1;
											}
											else
											{
												this.spriteDirection = 1;
											}
											int num612;
											if (num604 > 0f)
											{
												num612 = 0;
											}
											else if (Math.Abs(num604) > Math.Abs(num603) * 3f)
											{
												num612 = 4;
											}
											else if (Math.Abs(num604) > Math.Abs(num603) * 2f)
											{
												num612 = 3;
											}
											else if (Math.Abs(num603) > Math.Abs(num604) * 3f)
											{
												num612 = 0;
											}
											else if (Math.Abs(num603) > Math.Abs(num604) * 2f)
											{
												num612 = 1;
											}
											else
											{
												num612 = 2;
											}
											this.frame = num612 * 2;
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
													float num613 = 6f;
													Vector2 vector37 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
													if (num612 == 0)
													{
														vector37.Y += 12f;
														vector37.X += (float)(24 * this.spriteDirection);
													}
													else if (num612 == 1)
													{
														vector37.Y += 0f;
														vector37.X += (float)(24 * this.spriteDirection);
													}
													else if (num612 == 2)
													{
														vector37.Y -= 2f;
														vector37.X += (float)(24 * this.spriteDirection);
													}
													else if (num612 == 3)
													{
														vector37.Y -= 6f;
														vector37.X += (float)(14 * this.spriteDirection);
													}
													else if (num612 == 4)
													{
														vector37.Y -= 14f;
														vector37.X += (float)(2 * this.spriteDirection);
													}
													if (this.spriteDirection < 0)
													{
														vector37.X += 10f;
													}
													float num614 = num610 - vector37.X;
													float num615 = num611 - vector37.Y;
													float num616 = (float)Math.Sqrt((double)(num614 * num614 + num615 * num615));
													num616 = num613 / num616;
													num614 *= num616;
													num615 *= num616;
													int num617 = this.damage;
													int num618 = 309;
													Projectile.NewProjectile(vector37.X, vector37.Y, num614, num615, num618, num617, this.knockBack, Main.myPlayer, 0f, 0f);
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
										for (int num619 = 0; num619 < 1000; num619++)
										{
											if (num619 != this.whoAmI && Main.projectile[num619].active && Main.projectile[num619].owner == this.owner && Main.projectile[num619].type == this.type && Math.Abs(this.position.X - Main.projectile[num619].position.X) + Math.Abs(this.position.Y - Main.projectile[num619].position.Y) < (float)this.width)
											{
												if (this.position.X < Main.projectile[num619].position.X)
												{
													this.velocity.X = this.velocity.X - 0.05f;
												}
												else
												{
													this.velocity.X = this.velocity.X + 0.05f;
												}
												if (this.position.Y < Main.projectile[num619].position.Y)
												{
													this.velocity.Y = this.velocity.Y - 0.05f;
												}
												else
												{
													this.velocity.Y = this.velocity.Y + 0.05f;
												}
											}
										}
										float num620 = this.position.X;
										float num621 = this.position.Y;
										float num622 = 800f;
										bool flag24 = false;
										int num623 = 500;
										if (this.ai[1] != 0f || this.friendly)
										{
											num623 = 1400;
										}
										if (Math.Abs(this.center().X - Main.player[this.owner].center().X) + Math.Abs(this.center().Y - Main.player[this.owner].center().Y) > (float)num623)
										{
											this.ai[0] = 1f;
										}
										if (this.ai[0] == 0f)
										{
											this.tileCollide = true;
											for (int num624 = 0; num624 < 200; num624++)
											{
												if (Main.npc[num624].active && !Main.npc[num624].dontTakeDamage && !Main.npc[num624].friendly && Main.npc[num624].lifeMax > 5)
												{
													float num625 = Main.npc[num624].position.X + (float)(Main.npc[num624].width / 2);
													float num626 = Main.npc[num624].position.Y + (float)(Main.npc[num624].height / 2);
													float num627 = Math.Abs(this.position.X + (float)(this.width / 2) - num625) + Math.Abs(this.position.Y + (float)(this.height / 2) - num626);
													if (num627 < num622 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num624].position, Main.npc[num624].width, Main.npc[num624].height))
													{
														num622 = num627;
														num620 = num625;
														num621 = num626;
														flag24 = true;
													}
												}
											}
										}
										else
										{
											this.tileCollide = false;
										}
										if (!flag24)
										{
											this.friendly = true;
											float num628 = 8f;
											if (this.ai[0] == 1f)
											{
												num628 = 12f;
											}
											Vector2 vector38 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
											float num629 = Main.player[this.owner].center().X - vector38.X;
											float num630 = Main.player[this.owner].center().Y - vector38.Y - 60f;
											float num631 = (float)Math.Sqrt((double)(num629 * num629 + num630 * num630));
											if (num631 < 100f && this.ai[0] == 1f && !Collision.SolidCollision(this.position, this.width, this.height))
											{
												this.ai[0] = 0f;
											}
											if (num631 > 2000f)
											{
												this.position.X = Main.player[this.owner].center().X - (float)(this.width / 2);
												this.position.Y = Main.player[this.owner].center().Y - (float)(this.width / 2);
											}
											if (num631 > 70f)
											{
												num631 = num628 / num631;
												num629 *= num631;
												num630 *= num631;
												this.velocity.X = (this.velocity.X * 20f + num629) / 21f;
												this.velocity.Y = (this.velocity.Y * 20f + num630) / 21f;
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
												float num632 = 8f;
												Vector2 vector39 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
												float num633 = num620 - vector39.X;
												float num634 = num621 - vector39.Y;
												float num635 = (float)Math.Sqrt((double)(num633 * num633 + num634 * num634));
												if (num635 < 100f)
												{
													num632 = 10f;
												}
												num635 = num632 / num635;
												num633 *= num635;
												num634 *= num635;
												this.velocity.X = (this.velocity.X * 14f + num633) / 15f;
												this.velocity.Y = (this.velocity.Y * 14f + num634) / 15f;
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
											int num636 = (int)this.ai[0];
											if (Main.npc[num636].active)
											{
												float num637 = 8f;
												Vector2 vector40 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
												float num638 = Main.npc[num636].position.X - vector40.X;
												float num639 = Main.npc[num636].position.Y - vector40.Y;
												float num640 = (float)Math.Sqrt((double)(num638 * num638 + num639 * num639));
												num640 = num637 / num640;
												num638 *= num640;
												num639 *= num640;
												this.velocity.X = (this.velocity.X * 14f + num638) / 15f;
												this.velocity.Y = (this.velocity.Y * 14f + num639) / 15f;
											}
											else
											{
												float num641 = 1000f;
												for (int num642 = 0; num642 < 200; num642++)
												{
													if (Main.npc[num642].active && !Main.npc[num642].dontTakeDamage && !Main.npc[num642].friendly && Main.npc[num642].lifeMax > 5)
													{
														float num643 = Main.npc[num642].position.X + (float)(Main.npc[num642].width / 2);
														float num644 = Main.npc[num642].position.Y + (float)(Main.npc[num642].height / 2);
														float num645 = Math.Abs(this.position.X + (float)(this.width / 2) - num643) + Math.Abs(this.position.Y + (float)(this.height / 2) - num644);
														if (num645 < num641 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num642].position, Main.npc[num642].width, Main.npc[num642].height))
														{
															num641 = num645;
															this.ai[0] = (float)num642;
														}
													}
												}
											}
											int num646 = 8;
											int num647 = Dust.NewDust(new Vector2(this.position.X + (float)num646, this.position.Y + (float)num646), this.width - num646 * 2, this.height - num646 * 2, 6, 0f, 0f, 0, default(Color), 1f);
											Main.dust[num647].velocity *= 0.5f;
											Main.dust[num647].velocity += this.velocity * 0.5f;
											Main.dust[num647].noGravity = true;
											Main.dust[num647].noLight = true;
											Main.dust[num647].scale = 1.4f;
											return;
										}
										this.Kill();
										return;
									}
									else
									{
										if (this.aiStyle == 56)
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
											return;
										}
										if (this.aiStyle == 57)
										{
											this.ai[0] += 1f;
											if (this.ai[0] > 30f)
											{
												this.ai[0] = 30f;
												this.velocity.Y = this.velocity.Y + 0.25f;
												this.velocity.X = this.velocity.X * 0.995f;
											}
											this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
											this.alpha -= 50;
											if (this.alpha < 0)
											{
												this.alpha = 0;
											}
											if (this.owner == Main.myPlayer)
											{
												this.localAI[0] += 1f;
												if (this.localAI[0] >= 4f)
												{
													this.localAI[0] = 0f;
													Projectile.NewProjectile(this.center().X, this.center().Y, 0f, 0f, 344, (int)((double)this.damage * 0.85), this.knockBack * 0.6f, this.owner, 0f, (float)Main.rand.Next(3));
													return;
												}
											}
										}
										else if (this.aiStyle == 58)
										{
											this.alpha -= 50;
											if (this.alpha < 0)
											{
												this.alpha = 0;
											}
											if (this.ai[0] == 0f)
											{
												this.frame = 0;
												this.ai[1] += 1f;
												if (this.ai[1] > 30f)
												{
													this.velocity.Y = this.velocity.Y + 0.1f;
												}
												if (this.velocity.Y >= 0f)
												{
													this.ai[0] = 1f;
												}
											}
											if (this.ai[0] == 1f)
											{
												this.frame = 1;
												this.velocity.Y = this.velocity.Y + 0.1f;
												if (this.velocity.Y > 3f)
												{
													this.velocity.Y = 3f;
												}
												this.velocity.X = this.velocity.X * 0.99f;
											}
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
		public void Kill()
		{
			if (!this.active)
			{
				return;
			}
			this.timeLeft = 0;
			if (this.type == 1 || this.type == 81 || this.type == 98)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int i = 0; i < 10; i++)
				{
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 7, 0f, 0f, 0, default(Color), 1f);
				}
			}
			if (this.type == 336 || this.type == 345)
			{
				for (int j = 0; j < 6; j++)
				{
					int num = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 196, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num].noGravity = true;
					Main.dust[num].scale = this.scale;
				}
			}
			if (this.type == 344)
			{
				for (int k = 0; k < 3; k++)
				{
					int num2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 197, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num2].noGravity = true;
					Main.dust[num2].scale = this.scale;
				}
			}
			else if (this.type == 343)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
				for (int l = 4; l < 31; l++)
				{
					float num3 = this.lastVelocity.X * (30f / (float)l);
					float num4 = this.lastVelocity.Y * (30f / (float)l);
					int num5 = Dust.NewDust(new Vector2(this.lastPosition.X - num3, this.lastPosition.Y - num4), 8, 8, 197, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.2f);
					Main.dust[num5].noGravity = true;
					Main.dust[num5].velocity *= 0.5f;
				}
			}
			else if (this.type == 349)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
				for (int m = 0; m < 3; m++)
				{
					int num6 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 76, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num6].noGravity = true;
					Main.dust[num6].noLight = true;
					Main.dust[num6].scale = 0.7f;
				}
			}
			if (this.type == 323)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int n = 0; n < 20; n++)
				{
					int num7 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 7, 0f, 0f, 0, default(Color), 1f);
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num7].noGravity = true;
						Main.dust[num7].scale = 1.3f;
						Main.dust[num7].velocity *= 1.5f;
						Main.dust[num7].velocity -= this.lastVelocity * 0.5f;
						Main.dust[num7].velocity *= 1.5f;
					}
					else
					{
						Main.dust[num7].velocity *= 0.75f;
						Main.dust[num7].velocity -= this.lastVelocity * 0.25f;
						Main.dust[num7].scale = 0.8f;
					}
				}
			}
			if (this.type == 346)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
				for (int num8 = 0; num8 < 10; num8++)
				{
					int num9 = 10;
					if (this.ai[1] == 1f)
					{
						num9 = 4;
					}
					int num10 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num9, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num10].noGravity = true;
				}
			}
			if (this.type == 335)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
				for (int num11 = 0; num11 < 10; num11++)
				{
					int num12 = 90 - (int)this.ai[1];
					int num13 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num12, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num13].noLight = true;
					Main.dust[num13].scale = 0.8f;
				}
			}
			if (this.type == 318)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num14 = 0; num14 < 10; num14++)
				{
					int num15 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 30, 0f, 0f, 0, default(Color), 1f);
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num15].noGravity = true;
					}
				}
			}
			else if (this.type == 311)
			{
				for (int num16 = 0; num16 < 5; num16++)
				{
					int num17 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 189, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num17].scale = 0.85f;
					Main.dust[num17].noGravity = true;
					Main.dust[num17].velocity += this.velocity * 0.5f;
				}
			}
			else if (this.type == 316)
			{
				for (int num18 = 0; num18 < 5; num18++)
				{
					int num19 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 195, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num19].scale = 0.85f;
					Main.dust[num19].noGravity = true;
					Main.dust[num19].velocity += this.velocity * 0.5f;
				}
			}
			else if (this.type == 184 || this.type == 195)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num20 = 0; num20 < 5; num20++)
				{
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 7, 0f, 0f, 0, default(Color), 1f);
				}
			}
			else if (this.type == 275 || this.type == 276)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num21 = 0; num21 < 5; num21++)
				{
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 7, 0f, 0f, 0, default(Color), 1f);
				}
			}
			else if (this.type == 291)
			{
				if (this.owner == Main.myPlayer)
				{
					Projectile.NewProjectile(this.center().X, this.center().Y, 0f, 0f, 292, this.damage, this.knockBack, this.owner, 0f, 0f);
				}
			}
			else if (this.type == 295)
			{
				if (this.owner == Main.myPlayer)
				{
					Projectile.NewProjectile(this.center().X, this.center().Y, 0f, 0f, 296, (int)((double)this.damage * 0.65), this.knockBack, this.owner, 0f, 0f);
				}
			}
			else if (this.type == 270)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 27);
				for (int num22 = 0; num22 < 20; num22++)
				{
					int num23 = Dust.NewDust(this.position, this.width, this.height, 26, 0f, 0f, 100, default(Color), 1f);
					Main.dust[num23].noGravity = true;
					Main.dust[num23].velocity *= 1.2f;
					Main.dust[num23].scale = 1.3f;
					Main.dust[num23].velocity -= this.lastVelocity * 0.3f;
					num23 = Dust.NewDust(new Vector2(this.position.X + 4f, this.position.Y + 4f), this.width - 8, this.height - 8, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num23].noGravity = true;
					Main.dust[num23].velocity *= 3f;
				}
			}
			else if (this.type == 265)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 27);
				for (int num24 = 0; num24 < 15; num24++)
				{
					int num25 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 163, 0f, 0f, 100, default(Color), 1.2f);
					Main.dust[num25].noGravity = true;
					Main.dust[num25].velocity *= 1.2f;
					Main.dust[num25].velocity -= this.lastVelocity * 0.3f;
				}
			}
			else if (this.type == 304)
			{
				for (int num26 = 0; num26 < 3; num26++)
				{
					int num27 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 182, 0f, 0f, 100, default(Color), 0.8f);
					Main.dust[num27].noGravity = true;
					Main.dust[num27].velocity *= 1.2f;
					Main.dust[num27].velocity -= this.lastVelocity * 0.3f;
				}
			}
			else if (this.type == 263)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
				for (int num28 = 0; num28 < 15; num28++)
				{
					int num29 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 92, this.velocity.X, this.velocity.Y, Main.rand.Next(0, 101), default(Color), 1f + (float)Main.rand.Next(40) * 0.01f);
					Main.dust[num29].noGravity = true;
					Main.dust[num29].velocity *= 2f;
				}
			}
			else if (this.type == 261)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num30 = 0; num30 < 5; num30++)
				{
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 148, 0f, 0f, 0, default(Color), 1f);
				}
			}
			else if (this.type == 229)
			{
				for (int num31 = 0; num31 < 25; num31++)
				{
					int num32 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 157, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num32].noGravity = true;
					Main.dust[num32].velocity *= 1.5f;
					Main.dust[num32].scale = 1.5f;
				}
			}
			else if (this.type == 239)
			{
				int num33 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), 2, 2, 154, 0f, 0f, 0, default(Color), 1f);
				Dust expr_10B6_cp_0 = Main.dust[num33];
				expr_10B6_cp_0.position.X = expr_10B6_cp_0.position.X - 2f;
				Main.dust[num33].alpha = 38;
				Main.dust[num33].velocity *= 0.1f;
				Main.dust[num33].velocity += -this.lastVelocity * 0.25f;
				Main.dust[num33].scale = 0.95f;
			}
			else if (this.type == 245)
			{
				int num34 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), 2, 2, 114, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num34].noGravity = true;
				Dust expr_11B4_cp_0 = Main.dust[num34];
				expr_11B4_cp_0.position.X = expr_11B4_cp_0.position.X - 2f;
				Main.dust[num34].alpha = 38;
				Main.dust[num34].velocity *= 0.1f;
				Main.dust[num34].velocity += -this.lastVelocity * 0.25f;
				Main.dust[num34].scale = 0.95f;
			}
			else if (this.type == 264)
			{
				int num35 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), 2, 2, 54, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num35].noGravity = true;
				Dust expr_12B2_cp_0 = Main.dust[num35];
				expr_12B2_cp_0.position.X = expr_12B2_cp_0.position.X - 2f;
				Main.dust[num35].alpha = 38;
				Main.dust[num35].velocity *= 0.1f;
				Main.dust[num35].velocity += -this.lastVelocity * 0.25f;
				Main.dust[num35].scale = 0.95f;
			}
			else if (this.type == 206 || this.type == 225)
			{
				Main.PlaySound(6, (int)this.position.X, (int)this.position.Y, 1);
				for (int num36 = 0; num36 < 5; num36++)
				{
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 40, 0f, 0f, 0, default(Color), 1f);
				}
			}
			else if (this.type == 227)
			{
				Main.PlaySound(6, (int)this.position.X, (int)this.position.Y, 1);
				for (int num37 = 0; num37 < 15; num37++)
				{
					int num38 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 157, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num38].noGravity = true;
					Main.dust[num38].velocity += this.lastVelocity;
					Main.dust[num38].scale = 1.5f;
				}
			}
			else if (this.type == 237 && this.owner == Main.myPlayer)
			{
				Projectile.NewProjectile(this.center().X, this.center().Y, 0f, 0f, 238, this.damage, this.knockBack, this.owner, 0f, 0f);
			}
			else if (this.type == 243 && this.owner == Main.myPlayer)
			{
				Projectile.NewProjectile(this.center().X, this.center().Y, 0f, 0f, 244, this.damage, this.knockBack, this.owner, 0f, 0f);
			}
			else if (this.type == 120)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num39 = 0; num39 < 10; num39++)
				{
					int num40 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 67, this.velocity.X, this.velocity.Y, 100, default(Color), 1f);
					if (num39 < 5)
					{
						Main.dust[num40].noGravity = true;
					}
					Main.dust[num40].velocity *= 0.2f;
				}
			}
			else if (this.type == 181 || this.type == 189)
			{
				for (int num41 = 0; num41 < 6; num41++)
				{
					int num42 = Dust.NewDust(this.position, this.width, this.height, 150, this.velocity.X, this.velocity.Y, 50, default(Color), 1f);
					Main.dust[num42].noGravity = true;
					Main.dust[num42].scale = 1f;
				}
			}
			else if (this.type == 178)
			{
				for (int num43 = 0; num43 < 85; num43++)
				{
					int num44 = Main.rand.Next(139, 143);
					int num45 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num44, this.velocity.X, this.velocity.Y, 0, default(Color), 1.2f);
					Dust expr_178F_cp_0 = Main.dust[num45];
					expr_178F_cp_0.velocity.X = expr_178F_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					Dust expr_17BD_cp_0 = Main.dust[num45];
					expr_17BD_cp_0.velocity.Y = expr_17BD_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					Dust expr_17EB_cp_0 = Main.dust[num45];
					expr_17EB_cp_0.velocity.X = expr_17EB_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Dust expr_181F_cp_0 = Main.dust[num45];
					expr_181F_cp_0.velocity.Y = expr_181F_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Dust expr_1853_cp_0 = Main.dust[num45];
					expr_1853_cp_0.velocity.X = expr_1853_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
					Dust expr_1881_cp_0 = Main.dust[num45];
					expr_1881_cp_0.velocity.Y = expr_1881_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
					Main.dust[num45].scale *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
				}
				for (int num46 = 0; num46 < 40; num46++)
				{
					int num47 = Main.rand.Next(276, 283);
					int num48 = Gore.NewGore(this.position, this.velocity, num47, 1f);
					Gore expr_1925_cp_0 = Main.gore[num48];
					expr_1925_cp_0.velocity.X = expr_1925_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					Gore expr_1953_cp_0 = Main.gore[num48];
					expr_1953_cp_0.velocity.Y = expr_1953_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					Gore expr_1981_cp_0 = Main.gore[num48];
					expr_1981_cp_0.velocity.X = expr_1981_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Gore expr_19B5_cp_0 = Main.gore[num48];
					expr_19B5_cp_0.velocity.Y = expr_19B5_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Main.gore[num48].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
					Gore expr_1A18_cp_0 = Main.gore[num48];
					expr_1A18_cp_0.velocity.X = expr_1A18_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
					Gore expr_1A46_cp_0 = Main.gore[num48];
					expr_1A46_cp_0.velocity.Y = expr_1A46_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
				}
			}
			else if (this.type == 289)
			{
				for (int num49 = 0; num49 < 30; num49++)
				{
					int num50 = Main.rand.Next(139, 143);
					int num51 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num50, this.velocity.X, this.velocity.Y, 0, default(Color), 1.2f);
					Dust expr_1B10_cp_0 = Main.dust[num51];
					expr_1B10_cp_0.velocity.X = expr_1B10_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					Dust expr_1B3E_cp_0 = Main.dust[num51];
					expr_1B3E_cp_0.velocity.Y = expr_1B3E_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					Dust expr_1B6C_cp_0 = Main.dust[num51];
					expr_1B6C_cp_0.velocity.X = expr_1B6C_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Dust expr_1BA0_cp_0 = Main.dust[num51];
					expr_1BA0_cp_0.velocity.Y = expr_1BA0_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Dust expr_1BD4_cp_0 = Main.dust[num51];
					expr_1BD4_cp_0.velocity.X = expr_1BD4_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
					Dust expr_1C02_cp_0 = Main.dust[num51];
					expr_1C02_cp_0.velocity.Y = expr_1C02_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
					Main.dust[num51].scale *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
				}
				for (int num52 = 0; num52 < 15; num52++)
				{
					int num53 = Main.rand.Next(276, 283);
					int num54 = Gore.NewGore(this.position, this.velocity, num53, 1f);
					Gore expr_1CA6_cp_0 = Main.gore[num54];
					expr_1CA6_cp_0.velocity.X = expr_1CA6_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					Gore expr_1CD4_cp_0 = Main.gore[num54];
					expr_1CD4_cp_0.velocity.Y = expr_1CD4_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					Gore expr_1D02_cp_0 = Main.gore[num54];
					expr_1D02_cp_0.velocity.X = expr_1D02_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Gore expr_1D36_cp_0 = Main.gore[num54];
					expr_1D36_cp_0.velocity.Y = expr_1D36_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Main.gore[num54].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
					Gore expr_1D99_cp_0 = Main.gore[num54];
					expr_1D99_cp_0.velocity.X = expr_1D99_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
					Gore expr_1DC7_cp_0 = Main.gore[num54];
					expr_1DC7_cp_0.velocity.Y = expr_1DC7_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
				}
			}
			else if (this.type == 171)
			{
				if (this.ai[1] == 0f)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				}
				if (this.ai[1] < 10f)
				{
					Vector2 vector = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num55 = -this.velocity.X;
					float num56 = -this.velocity.Y;
					float num57 = 1f;
					if (this.ai[0] <= 17f)
					{
						num57 = this.ai[0] / 17f;
					}
					int num58 = (int)(30f * num57);
					float num59 = 1f;
					if (this.ai[0] <= 30f)
					{
						num59 = this.ai[0] / 30f;
					}
					float num60 = 0.4f * num59;
					float num61 = num60;
					num56 += num61;
					for (int num62 = 0; num62 < num58; num62++)
					{
						float num63 = (float)Math.Sqrt((double)(num55 * num55 + num56 * num56));
						float num64 = 5.6f;
						if (Math.Abs(num55) + Math.Abs(num56) < 1f)
						{
							num64 *= Math.Abs(num55) + Math.Abs(num56) / 1f;
						}
						num63 = num64 / num63;
						num55 *= num63;
						num56 *= num63;
						Math.Atan2((double)num56, (double)num55);
						if ((float)num62 > this.ai[1])
						{
							for (int num65 = 0; num65 < 4; num65++)
							{
								int num66 = Dust.NewDust(vector, this.width, this.height, 129, 0f, 0f, 0, default(Color), 1f);
								Main.dust[num66].noGravity = true;
								Main.dust[num66].velocity *= 0.3f;
							}
						}
						vector.X += num55;
						vector.Y += num56;
						num55 = -this.velocity.X;
						num56 = -this.velocity.Y;
						num61 += num60;
						num56 += num61;
					}
				}
			}
			else if (this.type == 117)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num67 = 0; num67 < 10; num67++)
				{
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 26, 0f, 0f, 0, default(Color), 1f);
				}
			}
			else if (this.type == 166)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 51);
				for (int num68 = 0; num68 < 10; num68++)
				{
					int num69 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 76, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num69].noGravity = true;
					Main.dust[num69].velocity -= this.lastVelocity * 0.25f;
				}
			}
			else if (this.type == 158)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num70 = 0; num70 < 10; num70++)
				{
					int num71 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 9, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num71].noGravity = true;
					Main.dust[num71].velocity -= this.velocity * 0.5f;
				}
			}
			else if (this.type == 159)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num72 = 0; num72 < 10; num72++)
				{
					int num73 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 11, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num73].noGravity = true;
					Main.dust[num73].velocity -= this.velocity * 0.5f;
				}
			}
			else if (this.type == 160)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num74 = 0; num74 < 10; num74++)
				{
					int num75 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 19, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num75].noGravity = true;
					Main.dust[num75].velocity -= this.velocity * 0.5f;
				}
			}
			else if (this.type == 161)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num76 = 0; num76 < 10; num76++)
				{
					int num77 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 11, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num77].noGravity = true;
					Main.dust[num77].velocity -= this.velocity * 0.5f;
				}
			}
			else if (this.type >= 191 && this.type <= 194)
			{
				int num78 = Gore.NewGore(new Vector2(this.position.X - (float)(this.width / 2), this.position.Y - (float)(this.height / 2)), new Vector2(0f, 0f), Main.rand.Next(61, 64), this.scale);
				Main.gore[num78].velocity *= 0.1f;
			}
			else if (!Main.projPet[this.type])
			{
				if (this.type == 93)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num79 = 0; num79 < 10; num79++)
					{
						int num80 = Dust.NewDust(this.position, this.width, this.height, 57, 0f, 0f, 100, default(Color), 0.5f);
						Dust expr_261B_cp_0 = Main.dust[num80];
						expr_261B_cp_0.velocity.X = expr_261B_cp_0.velocity.X * 2f;
						Dust expr_2639_cp_0 = Main.dust[num80];
						expr_2639_cp_0.velocity.Y = expr_2639_cp_0.velocity.Y * 2f;
					}
				}
				else if (this.type == 99)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num81 = 0; num81 < 30; num81++)
					{
						int num82 = Dust.NewDust(this.position, this.width, this.height, 1, 0f, 0f, 0, default(Color), 1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num82].scale *= 1.4f;
						}
						this.velocity *= 1.9f;
					}
				}
				else if (this.type == 91 || this.type == 92)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num83 = 0; num83 < 10; num83++)
					{
						Dust.NewDust(this.position, this.width, this.height, 58, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, default(Color), 1.2f);
					}
					for (int num84 = 0; num84 < 3; num84++)
					{
						Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
					}
					if (this.type == 12 && this.damage < 500)
					{
						for (int num85 = 0; num85 < 10; num85++)
						{
							Dust.NewDust(this.position, this.width, this.height, 57, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, default(Color), 1.2f);
						}
						for (int num86 = 0; num86 < 3; num86++)
						{
							Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
						}
					}
					if ((this.type == 91 || (this.type == 92 && this.ai[0] > 0f)) && this.owner == Main.myPlayer)
					{
						float x = this.position.X + (float)Main.rand.Next(-400, 400);
						float y = this.position.Y - (float)Main.rand.Next(600, 900);
						Vector2 vector2 = new Vector2(x, y);
						float num87 = this.position.X + (float)(this.width / 2) - vector2.X;
						float num88 = this.position.Y + (float)(this.height / 2) - vector2.Y;
						int num89 = 22;
						float num90 = (float)Math.Sqrt((double)(num87 * num87 + num88 * num88));
						num90 = (float)num89 / num90;
						num87 *= num90;
						num88 *= num90;
						int num91 = this.damage;
						if (this.type == 91)
						{
							num91 = (int)((float)num91 * 0.5f);
						}
						int num92 = Projectile.NewProjectile(x, y, num87, num88, 92, num91, this.knockBack, this.owner, 0f, 0f);
						if (this.type == 91)
						{
							Main.projectile[num92].ai[1] = this.position.Y;
							Main.projectile[num92].ai[0] = 1f;
						}
						else
						{
							Main.projectile[num92].ai[1] = this.position.Y;
						}
					}
				}
				else if (this.type == 89)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num93 = 0; num93 < 5; num93++)
					{
						int num94 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 68, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num94].noGravity = true;
						Main.dust[num94].velocity *= 1.5f;
						Main.dust[num94].scale *= 0.9f;
					}
					if (this.type == 89 && this.owner == Main.myPlayer)
					{
						for (int num95 = 0; num95 < 3; num95++)
						{
							float num96 = -this.velocity.X * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
							float num97 = -this.velocity.Y * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
							Projectile.NewProjectile(this.position.X + num96, this.position.Y + num97, num96, num97, 90, (int)((double)this.damage * 0.5), 0f, this.owner, 0f, 0f);
						}
					}
				}
				else if (this.type == 177)
				{
					for (int num98 = 0; num98 < 20; num98++)
					{
						int num99 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 137, 0f, 0f, Main.rand.Next(0, 101), default(Color), 1f + (float)Main.rand.Next(-20, 40) * 0.01f);
						Main.dust[num99].velocity -= this.lastVelocity * 0.2f;
						if (Main.rand.Next(3) == 0)
						{
							Main.dust[num99].scale *= 0.8f;
							Main.dust[num99].velocity *= 0.5f;
						}
						else
						{
							Main.dust[num99].noGravity = true;
						}
					}
				}
				else if (this.type == 119 || this.type == 118 || this.type == 128)
				{
					int num100 = 10;
					if (this.type == 119)
					{
						num100 = 20;
					}
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
					for (int num101 = 0; num101 < num100; num101++)
					{
						int num102 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 92, 0f, 0f, 0, default(Color), 1f);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num102].velocity *= 2f;
							Main.dust[num102].noGravity = true;
							Main.dust[num102].scale *= 1.75f;
						}
						else
						{
							Main.dust[num102].scale *= 0.5f;
						}
					}
				}
				else if (this.type == 309)
				{
					int num103 = 10;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
					for (int num104 = 0; num104 < num103; num104++)
					{
						int num105 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 185, 0f, 0f, 0, default(Color), 1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num105].velocity *= 2f;
							Main.dust[num105].noGravity = true;
							Main.dust[num105].scale *= 1.75f;
						}
					}
				}
				else if (this.type == 308)
				{
					int num106 = 80;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
					for (int num107 = 0; num107 < num106; num107++)
					{
						int num108 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 16f), this.width, this.height - 16, 185, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num108].velocity *= 2f;
						Main.dust[num108].noGravity = true;
						Main.dust[num108].scale *= 1.15f;
					}
				}
				else if (this.aiStyle == 29)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					int num109 = this.type - 121 + 86;
					for (int num110 = 0; num110 < 15; num110++)
					{
						int num111 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num109, this.lastVelocity.X, this.lastVelocity.Y, 50, default(Color), 1.2f);
						Main.dust[num111].noGravity = true;
						Main.dust[num111].scale *= 1.25f;
						Main.dust[num111].velocity *= 0.5f;
					}
				}
				else if (this.type == 337)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
					for (int num112 = 0; num112 < 10; num112++)
					{
						int num113 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 197, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num113].noGravity = true;
					}
				}
				else if (this.type == 80)
				{
					if (this.ai[0] >= 0f)
					{
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
						for (int num114 = 0; num114 < 10; num114++)
						{
							Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0f, 0f, 0, default(Color), 1f);
						}
					}
					int num115 = (int)this.position.X / 16;
					int num116 = (int)this.position.Y / 16;
					if (Main.tile[num115, num116] == null)
					{
						Main.tile[num115, num116] = new Tile();
					}
					if (Main.tile[num115, num116].type == 127 && Main.tile[num115, num116].active())
					{
						WorldGen.KillTile(num115, num116, false, false, false);
					}
				}
				else if (this.type == 76 || this.type == 77 || this.type == 78)
				{
					for (int num117 = 0; num117 < 5; num117++)
					{
						int num118 = Dust.NewDust(this.position, this.width, this.height, 27, 0f, 0f, 80, default(Color), 1.5f);
						Main.dust[num118].noGravity = true;
					}
				}
				else if (this.type == 55)
				{
					for (int num119 = 0; num119 < 5; num119++)
					{
						int num120 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 18, 0f, 0f, 0, default(Color), 1.5f);
						Main.dust[num120].noGravity = true;
					}
				}
				else if (this.type == 51 || this.type == 267)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num121 = 0; num121 < 5; num121++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0, 0f, 0f, 0, default(Color), 0.7f);
					}
				}
				else if (this.type == 2 || this.type == 82)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num122 = 0; num122 < 20; num122++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
					}
				}
				else if (this.type == 172)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num123 = 0; num123 < 20; num123++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 135, 0f, 0f, 100, default(Color), 1f);
					}
				}
				else if (this.type == 103)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num124 = 0; num124 < 20; num124++)
					{
						int num125 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 75, 0f, 0f, 100, default(Color), 1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num125].scale *= 2.5f;
							Main.dust[num125].noGravity = true;
							Main.dust[num125].velocity *= 5f;
						}
					}
				}
				else if (this.type == 278)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num126 = 0; num126 < 20; num126++)
					{
						int num127 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 169, 0f, 0f, 100, default(Color), 1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num127].scale *= 1.5f;
							Main.dust[num127].noGravity = true;
							Main.dust[num127].velocity *= 5f;
						}
					}
				}
				else if (this.type == 3 || this.type == 48 || this.type == 54)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num128 = 0; num128 < 10; num128++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 1, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 0, default(Color), 0.75f);
					}
				}
				else if (this.type == 330)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num129 = 0; num129 < 10; num129++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 0, default(Color), 0.75f);
					}
				}
				else if (this.type == 4)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num130 = 0; num130 < 10; num130++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 150, default(Color), 1.1f);
					}
				}
				else if (this.type == 5)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num131 = 0; num131 < 60; num131++)
					{
						int num132 = Main.rand.Next(3);
						if (num132 == 0)
						{
							num132 = 15;
						}
						else if (num132 == 1)
						{
							num132 = 57;
						}
						else
						{
							num132 = 58;
						}
						Dust.NewDust(this.position, this.width, this.height, num132, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, default(Color), 1.5f);
					}
				}
				else if (this.type == 9 || this.type == 12)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num133 = 0; num133 < 10; num133++)
					{
						Dust.NewDust(this.position, this.width, this.height, 58, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, default(Color), 1.2f);
					}
					for (int num134 = 0; num134 < 3; num134++)
					{
						Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
					}
					if (this.type == 12 && this.damage < 100)
					{
						for (int num135 = 0; num135 < 10; num135++)
						{
							Dust.NewDust(this.position, this.width, this.height, 57, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, default(Color), 1.2f);
						}
						for (int num136 = 0; num136 < 3; num136++)
						{
							Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
						}
					}
				}
				else if (this.type == 281)
				{
					Main.PlaySound(4, (int)this.position.X, (int)this.position.Y, 1);
					int num137 = Gore.NewGore(this.position, new Vector2((float)Main.rand.Next(-20, 21) * 0.2f, (float)Main.rand.Next(-20, 21) * 0.2f), 76, 1f);
					Main.gore[num137].velocity -= this.velocity * 0.5f;
					num137 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2((float)Main.rand.Next(-20, 21) * 0.2f, (float)Main.rand.Next(-20, 21) * 0.2f), 77, 1f);
					Main.gore[num137].velocity -= this.velocity * 0.5f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int num138 = 0; num138 < 20; num138++)
					{
						int num139 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num139].velocity *= 1.4f;
					}
					for (int num140 = 0; num140 < 10; num140++)
					{
						int num141 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num141].noGravity = true;
						Main.dust[num141].velocity *= 5f;
						num141 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num141].velocity *= 3f;
					}
					num137 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num137].velocity *= 0.4f;
					Gore expr_3F5D_cp_0 = Main.gore[num137];
					expr_3F5D_cp_0.velocity.X = expr_3F5D_cp_0.velocity.X + 1f;
					Gore expr_3F7B_cp_0 = Main.gore[num137];
					expr_3F7B_cp_0.velocity.Y = expr_3F7B_cp_0.velocity.Y + 1f;
					num137 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num137].velocity *= 0.4f;
					Gore expr_3FF9_cp_0 = Main.gore[num137];
					expr_3FF9_cp_0.velocity.X = expr_3FF9_cp_0.velocity.X - 1f;
					Gore expr_4017_cp_0 = Main.gore[num137];
					expr_4017_cp_0.velocity.Y = expr_4017_cp_0.velocity.Y + 1f;
					num137 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num137].velocity *= 0.4f;
					Gore expr_4095_cp_0 = Main.gore[num137];
					expr_4095_cp_0.velocity.X = expr_4095_cp_0.velocity.X + 1f;
					Gore expr_40B3_cp_0 = Main.gore[num137];
					expr_40B3_cp_0.velocity.Y = expr_40B3_cp_0.velocity.Y - 1f;
					num137 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num137].velocity *= 0.4f;
					Gore expr_4131_cp_0 = Main.gore[num137];
					expr_4131_cp_0.velocity.X = expr_4131_cp_0.velocity.X - 1f;
					Gore expr_414F_cp_0 = Main.gore[num137];
					expr_414F_cp_0.velocity.Y = expr_414F_cp_0.velocity.Y - 1f;
					this.position.X = this.position.X + (float)(this.width / 2);
					this.position.Y = this.position.Y + (float)(this.height / 2);
					this.width = 128;
					this.height = 128;
					this.position.X = this.position.X - (float)(this.width / 2);
					this.position.Y = this.position.Y - (float)(this.height / 2);
					this.Damage();
				}
				else if (this.type == 162)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int num142 = 0; num142 < 20; num142++)
					{
						int num143 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num143].velocity *= 1.4f;
					}
					for (int num144 = 0; num144 < 10; num144++)
					{
						int num145 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num145].noGravity = true;
						Main.dust[num145].velocity *= 5f;
						num145 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num145].velocity *= 3f;
					}
					int num146 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num146].velocity *= 0.4f;
					Gore expr_4402_cp_0 = Main.gore[num146];
					expr_4402_cp_0.velocity.X = expr_4402_cp_0.velocity.X + 1f;
					Gore expr_4420_cp_0 = Main.gore[num146];
					expr_4420_cp_0.velocity.Y = expr_4420_cp_0.velocity.Y + 1f;
					num146 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num146].velocity *= 0.4f;
					Gore expr_449E_cp_0 = Main.gore[num146];
					expr_449E_cp_0.velocity.X = expr_449E_cp_0.velocity.X - 1f;
					Gore expr_44BC_cp_0 = Main.gore[num146];
					expr_44BC_cp_0.velocity.Y = expr_44BC_cp_0.velocity.Y + 1f;
					num146 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num146].velocity *= 0.4f;
					Gore expr_453A_cp_0 = Main.gore[num146];
					expr_453A_cp_0.velocity.X = expr_453A_cp_0.velocity.X + 1f;
					Gore expr_4558_cp_0 = Main.gore[num146];
					expr_4558_cp_0.velocity.Y = expr_4558_cp_0.velocity.Y - 1f;
					num146 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num146].velocity *= 0.4f;
					Gore expr_45D6_cp_0 = Main.gore[num146];
					expr_45D6_cp_0.velocity.X = expr_45D6_cp_0.velocity.X - 1f;
					Gore expr_45F4_cp_0 = Main.gore[num146];
					expr_45F4_cp_0.velocity.Y = expr_45F4_cp_0.velocity.Y - 1f;
					this.position.X = this.position.X + (float)(this.width / 2);
					this.position.Y = this.position.Y + (float)(this.height / 2);
					this.width = 128;
					this.height = 128;
					this.position.X = this.position.X - (float)(this.width / 2);
					this.position.Y = this.position.Y - (float)(this.height / 2);
					this.Damage();
				}
				else if (this.type == 240)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int num147 = 0; num147 < 20; num147++)
					{
						int num148 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num148].velocity *= 1.4f;
					}
					for (int num149 = 0; num149 < 10; num149++)
					{
						int num150 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num150].noGravity = true;
						Main.dust[num150].velocity *= 5f;
						num150 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num150].velocity *= 3f;
					}
					int num151 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num151].velocity *= 0.4f;
					Gore expr_48A7_cp_0 = Main.gore[num151];
					expr_48A7_cp_0.velocity.X = expr_48A7_cp_0.velocity.X + 1f;
					Gore expr_48C5_cp_0 = Main.gore[num151];
					expr_48C5_cp_0.velocity.Y = expr_48C5_cp_0.velocity.Y + 1f;
					num151 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num151].velocity *= 0.4f;
					Gore expr_4943_cp_0 = Main.gore[num151];
					expr_4943_cp_0.velocity.X = expr_4943_cp_0.velocity.X - 1f;
					Gore expr_4961_cp_0 = Main.gore[num151];
					expr_4961_cp_0.velocity.Y = expr_4961_cp_0.velocity.Y + 1f;
					num151 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num151].velocity *= 0.4f;
					Gore expr_49DF_cp_0 = Main.gore[num151];
					expr_49DF_cp_0.velocity.X = expr_49DF_cp_0.velocity.X + 1f;
					Gore expr_49FD_cp_0 = Main.gore[num151];
					expr_49FD_cp_0.velocity.Y = expr_49FD_cp_0.velocity.Y - 1f;
					num151 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num151].velocity *= 0.4f;
					Gore expr_4A7B_cp_0 = Main.gore[num151];
					expr_4A7B_cp_0.velocity.X = expr_4A7B_cp_0.velocity.X - 1f;
					Gore expr_4A99_cp_0 = Main.gore[num151];
					expr_4A99_cp_0.velocity.Y = expr_4A99_cp_0.velocity.Y - 1f;
					this.position.X = this.position.X + (float)(this.width / 2);
					this.position.Y = this.position.Y + (float)(this.height / 2);
					this.width = 96;
					this.height = 96;
					this.position.X = this.position.X - (float)(this.width / 2);
					this.position.Y = this.position.Y - (float)(this.height / 2);
					this.Damage();
				}
				else if (this.type == 283 || this.type == 282)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num152 = 0; num152 < 10; num152++)
					{
						int num153 = Dust.NewDust(this.position, this.width, this.height, 171, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num153].scale = (float)Main.rand.Next(1, 10) * 0.1f;
						Main.dust[num153].noGravity = true;
						Main.dust[num153].fadeIn = 1.5f;
						Main.dust[num153].velocity *= 0.75f;
					}
				}
				else if (this.type == 284)
				{
					for (int num154 = 0; num154 < 10; num154++)
					{
						int num155 = Main.rand.Next(139, 143);
						int num156 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num155, -this.velocity.X * 0.3f, -this.velocity.Y * 0.3f, 0, default(Color), 1.2f);
						Dust expr_4CC8_cp_0 = Main.dust[num156];
						expr_4CC8_cp_0.velocity.X = expr_4CC8_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
						Dust expr_4CF6_cp_0 = Main.dust[num156];
						expr_4CF6_cp_0.velocity.Y = expr_4CF6_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
						Dust expr_4D24_cp_0 = Main.dust[num156];
						expr_4D24_cp_0.velocity.X = expr_4D24_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
						Dust expr_4D58_cp_0 = Main.dust[num156];
						expr_4D58_cp_0.velocity.Y = expr_4D58_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
						Dust expr_4D8C_cp_0 = Main.dust[num156];
						expr_4D8C_cp_0.velocity.X = expr_4D8C_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
						Dust expr_4DBA_cp_0 = Main.dust[num156];
						expr_4DBA_cp_0.velocity.Y = expr_4DBA_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
						Main.dust[num156].scale *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
					}
					for (int num157 = 0; num157 < 5; num157++)
					{
						int num158 = Main.rand.Next(276, 283);
						int num159 = Gore.NewGore(this.position, -this.velocity * 0.3f, num158, 1f);
						Gore expr_4E6D_cp_0 = Main.gore[num159];
						expr_4E6D_cp_0.velocity.X = expr_4E6D_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
						Gore expr_4E9B_cp_0 = Main.gore[num159];
						expr_4E9B_cp_0.velocity.Y = expr_4E9B_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
						Gore expr_4EC9_cp_0 = Main.gore[num159];
						expr_4EC9_cp_0.velocity.X = expr_4EC9_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
						Gore expr_4EFD_cp_0 = Main.gore[num159];
						expr_4EFD_cp_0.velocity.Y = expr_4EFD_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
						Main.gore[num159].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
						Gore expr_4F60_cp_0 = Main.gore[num159];
						expr_4F60_cp_0.velocity.X = expr_4F60_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
						Gore expr_4F8E_cp_0 = Main.gore[num159];
						expr_4F8E_cp_0.velocity.Y = expr_4F8E_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
					}
				}
				else if (this.type == 286)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int num160 = 0; num160 < 7; num160++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
					}
					for (int num161 = 0; num161 < 3; num161++)
					{
						int num162 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num162].noGravity = true;
						Main.dust[num162].velocity *= 3f;
						num162 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num162].velocity *= 2f;
					}
					int num163 = Gore.NewGore(new Vector2(this.position.X - 10f, this.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num163].velocity *= 0.3f;
					Gore expr_51C3_cp_0 = Main.gore[num163];
					expr_51C3_cp_0.velocity.X = expr_51C3_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.05f;
					Gore expr_51F1_cp_0 = Main.gore[num163];
					expr_51F1_cp_0.velocity.Y = expr_51F1_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.05f;
					if (this.owner == Main.myPlayer)
					{
						this.localAI[1] = -1f;
						this.position.X = this.position.X + (float)(this.width / 2);
						this.position.Y = this.position.Y + (float)(this.height / 2);
						this.width = 80;
						this.height = 80;
						this.position.X = this.position.X - (float)(this.width / 2);
						this.position.Y = this.position.Y - (float)(this.height / 2);
						this.Damage();
					}
				}
				else if (this.type == 14 || this.type == 20 || this.type == 36 || this.type == 83 || this.type == 84 || this.type == 104 || this.type == 279 || this.type == 100 || this.type == 110 || this.type == 180 || this.type == 207 || this.type == 242 || this.type == 302 || this.type == 257 || this.type == 259 || this.type == 285 || this.type == 287)
				{
					Collision.HitTiles(this.position, this.velocity, this.width, this.height);
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
				}
				else if (this.type == 15 || this.type == 34 || this.type == 321)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num164 = 0; num164 < 20; num164++)
					{
						int num165 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num165].noGravity = true;
						Main.dust[num165].velocity *= 2f;
						num165 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, default(Color), 1f);
						Main.dust[num165].velocity *= 2f;
					}
				}
				else if (this.type == 253)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num166 = 0; num166 < 20; num166++)
					{
						int num167 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 135, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num167].noGravity = true;
						Main.dust[num167].velocity *= 2f;
						num167 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 135, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, default(Color), 1f);
						Main.dust[num167].velocity *= 2f;
					}
				}
				else if (this.type == 95 || this.type == 96)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num168 = 0; num168 < 20; num168++)
					{
						int num169 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 75, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, default(Color), 2f * this.scale);
						Main.dust[num169].noGravity = true;
						Main.dust[num169].velocity *= 2f;
						num169 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 75, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, default(Color), 1f * this.scale);
						Main.dust[num169].velocity *= 2f;
					}
				}
				else if (this.type == 79)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num170 = 0; num170 < 20; num170++)
					{
						int num171 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 66, 0f, 0f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 2f);
						Main.dust[num171].noGravity = true;
						Main.dust[num171].velocity *= 4f;
					}
				}
				else if (this.type == 16)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num172 = 0; num172 < 20; num172++)
					{
						int num173 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 15, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num173].noGravity = true;
						Main.dust[num173].velocity *= 2f;
						num173 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 15, 0f, 0f, 100, default(Color), 1f);
					}
				}
				else if (this.type == 17)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num174 = 0; num174 < 5; num174++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0, 0f, 0f, 0, default(Color), 1f);
					}
				}
				else if (this.type == 31 || this.type == 42)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num175 = 0; num175 < 5; num175++)
					{
						int num176 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 32, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num176].velocity *= 0.6f;
					}
				}
				else if (this.type == 109)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num177 = 0; num177 < 5; num177++)
					{
						int num178 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 51, 0f, 0f, 0, default(Color), 0.6f);
						Main.dust[num178].velocity *= 0.6f;
					}
				}
				else if (this.type == 39)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num179 = 0; num179 < 5; num179++)
					{
						int num180 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 38, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num180].velocity *= 0.6f;
					}
				}
				else if (this.type == 71)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num181 = 0; num181 < 5; num181++)
					{
						int num182 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 53, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num182].velocity *= 0.6f;
					}
				}
				else if (this.type == 40)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num183 = 0; num183 < 5; num183++)
					{
						int num184 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 36, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num184].velocity *= 0.6f;
					}
				}
				else if (this.type == 21)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num185 = 0; num185 < 10; num185++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 26, 0f, 0f, 0, default(Color), 0.8f);
					}
				}
				else if (this.type == 24)
				{
					for (int num186 = 0; num186 < 10; num186++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 1, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 0, default(Color), 0.75f);
					}
				}
				else if (this.type == 27)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num187 = 0; num187 < 30; num187++)
					{
						int num188 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 172, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 100, default(Color), 1f);
						Main.dust[num188].noGravity = true;
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 172, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 100, default(Color), 0.5f);
					}
				}
				else if (this.type == 38)
				{
					for (int num189 = 0; num189 < 10; num189++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 42, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 0, default(Color), 1f);
					}
				}
				else if (this.type == 44 || this.type == 45)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num190 = 0; num190 < 30; num190++)
					{
						int num191 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 27, this.velocity.X, this.velocity.Y, 100, default(Color), 1.7f);
						Main.dust[num191].noGravity = true;
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 27, this.velocity.X, this.velocity.Y, 100, default(Color), 1f);
					}
				}
				else if (this.type == 41)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int num192 = 0; num192 < 10; num192++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
					}
					for (int num193 = 0; num193 < 5; num193++)
					{
						int num194 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num194].noGravity = true;
						Main.dust[num194].velocity *= 3f;
						num194 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num194].velocity *= 2f;
					}
					int num195 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num195].velocity *= 0.4f;
					Gore expr_63F7_cp_0 = Main.gore[num195];
					expr_63F7_cp_0.velocity.X = expr_63F7_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.1f;
					Gore expr_6425_cp_0 = Main.gore[num195];
					expr_6425_cp_0.velocity.Y = expr_6425_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.1f;
					num195 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num195].velocity *= 0.4f;
					Gore expr_64B3_cp_0 = Main.gore[num195];
					expr_64B3_cp_0.velocity.X = expr_64B3_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.1f;
					Gore expr_64E1_cp_0 = Main.gore[num195];
					expr_64E1_cp_0.velocity.Y = expr_64E1_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.1f;
					if (this.owner == Main.myPlayer)
					{
						this.penetrate = -1;
						this.position.X = this.position.X + (float)(this.width / 2);
						this.position.Y = this.position.Y + (float)(this.height / 2);
						this.width = 64;
						this.height = 64;
						this.position.X = this.position.X - (float)(this.width / 2);
						this.position.Y = this.position.Y - (float)(this.height / 2);
						this.Damage();
					}
				}
				else if (this.type == 306)
				{
					Main.PlaySound(3, (int)this.position.X, (int)this.position.Y, 1);
					for (int num196 = 0; num196 < 20; num196++)
					{
						int num197 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 184, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num197].scale *= 1.1f;
						Main.dust[num197].noGravity = true;
					}
					for (int num198 = 0; num198 < 30; num198++)
					{
						int num199 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 184, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num199].velocity *= 2.5f;
						Main.dust[num199].scale *= 0.8f;
						Main.dust[num199].noGravity = true;
					}
					if (this.owner == Main.myPlayer)
					{
						int num200 = 2;
						if (Main.rand.Next(10) == 0)
						{
							num200++;
						}
						if (Main.rand.Next(10) == 0)
						{
							num200++;
						}
						for (int num201 = 0; num201 < num200; num201++)
						{
							float num202 = (float)Main.rand.Next(-35, 36) * 0.02f;
							float num203 = (float)Main.rand.Next(-35, 36) * 0.02f;
							num202 *= 10f;
							num203 *= 10f;
							Projectile.NewProjectile(this.position.X, this.position.Y, num202, num203, 307, (int)((double)this.damage * 0.55), (float)((int)((double)this.knockBack * 0.3)), Main.myPlayer, 0f, 0f);
						}
					}
				}
				else if (this.type == 183)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int num204 = 0; num204 < 20; num204++)
					{
						int num205 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num205].velocity *= 1f;
					}
					int num206 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Gore expr_68F6_cp_0 = Main.gore[num206];
					expr_68F6_cp_0.velocity.X = expr_68F6_cp_0.velocity.X + 1f;
					Gore expr_6914_cp_0 = Main.gore[num206];
					expr_6914_cp_0.velocity.Y = expr_6914_cp_0.velocity.Y + 1f;
					Main.gore[num206].velocity *= 0.3f;
					num206 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Gore expr_6992_cp_0 = Main.gore[num206];
					expr_6992_cp_0.velocity.X = expr_6992_cp_0.velocity.X - 1f;
					Gore expr_69B0_cp_0 = Main.gore[num206];
					expr_69B0_cp_0.velocity.Y = expr_69B0_cp_0.velocity.Y + 1f;
					Main.gore[num206].velocity *= 0.3f;
					num206 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Gore expr_6A2E_cp_0 = Main.gore[num206];
					expr_6A2E_cp_0.velocity.X = expr_6A2E_cp_0.velocity.X + 1f;
					Gore expr_6A4C_cp_0 = Main.gore[num206];
					expr_6A4C_cp_0.velocity.Y = expr_6A4C_cp_0.velocity.Y - 1f;
					Main.gore[num206].velocity *= 0.3f;
					num206 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Gore expr_6ACA_cp_0 = Main.gore[num206];
					expr_6ACA_cp_0.velocity.X = expr_6ACA_cp_0.velocity.X - 1f;
					Gore expr_6AE8_cp_0 = Main.gore[num206];
					expr_6AE8_cp_0.velocity.Y = expr_6AE8_cp_0.velocity.Y - 1f;
					Main.gore[num206].velocity *= 0.3f;
					if (this.owner == Main.myPlayer)
					{
						int num207 = Main.rand.Next(15, 25);
						for (int num208 = 0; num208 < num207; num208++)
						{
							float speedX = (float)Main.rand.Next(-35, 36) * 0.02f;
							float speedY = (float)Main.rand.Next(-35, 36) * 0.02f;
							Projectile.NewProjectile(this.position.X, this.position.Y, speedX, speedY, 181, this.damage, 0f, Main.myPlayer, 0f, 0f);
						}
					}
				}
				else if (this.aiStyle == 34)
				{
					if (this.owner != Main.myPlayer)
					{
						this.timeLeft = 60;
					}
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					if (this.type == 167)
					{
						for (int num209 = 0; num209 < 400; num209++)
						{
							float num210 = 16f;
							if (num209 < 300)
							{
								num210 = 12f;
							}
							if (num209 < 200)
							{
								num210 = 8f;
							}
							if (num209 < 100)
							{
								num210 = 4f;
							}
							int num211 = 130;
							int num212 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, num211, 0f, 0f, 100, default(Color), 1f);
							float num213 = Main.dust[num212].velocity.X;
							float num214 = Main.dust[num212].velocity.Y;
							if (num213 == 0f && num214 == 0f)
							{
								num213 = 1f;
							}
							float num215 = (float)Math.Sqrt((double)(num213 * num213 + num214 * num214));
							num215 = num210 / num215;
							num213 *= num215;
							num214 *= num215;
							Main.dust[num212].velocity *= 0.5f;
							Dust expr_6D27_cp_0 = Main.dust[num212];
							expr_6D27_cp_0.velocity.X = expr_6D27_cp_0.velocity.X + num213;
							Dust expr_6D42_cp_0 = Main.dust[num212];
							expr_6D42_cp_0.velocity.Y = expr_6D42_cp_0.velocity.Y + num214;
							Main.dust[num212].scale = 1.3f;
							Main.dust[num212].noGravity = true;
						}
					}
					if (this.type == 168)
					{
						for (int num216 = 0; num216 < 400; num216++)
						{
							float num217 = 2f * ((float)num216 / 100f);
							if (num216 > 100)
							{
								num217 = 10f;
							}
							if (num216 > 250)
							{
								num217 = 13f;
							}
							int num218 = 131;
							int num219 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, num218, 0f, 0f, 100, default(Color), 1f);
							float num220 = Main.dust[num219].velocity.X;
							float num221 = Main.dust[num219].velocity.Y;
							if (num220 == 0f && num221 == 0f)
							{
								num220 = 1f;
							}
							float num222 = (float)Math.Sqrt((double)(num220 * num220 + num221 * num221));
							num222 = num217 / num222;
							if (num216 <= 200)
							{
								num220 *= num222;
								num221 *= num222;
							}
							else
							{
								num220 = num220 * num222 * 1.25f;
								num221 = num221 * num222 * 0.75f;
							}
							Main.dust[num219].velocity *= 0.5f;
							Dust expr_6ECD_cp_0 = Main.dust[num219];
							expr_6ECD_cp_0.velocity.X = expr_6ECD_cp_0.velocity.X + num220;
							Dust expr_6EE8_cp_0 = Main.dust[num219];
							expr_6EE8_cp_0.velocity.Y = expr_6EE8_cp_0.velocity.Y + num221;
							if (num216 > 100)
							{
								Main.dust[num219].scale = 1.3f;
								Main.dust[num219].noGravity = true;
							}
						}
					}
					if (this.type == 169)
					{
						for (int num223 = 0; num223 < 400; num223++)
						{
							int num224 = 132;
							float num225 = 14f;
							if (num223 > 100)
							{
								num225 = 10f;
							}
							if (num223 > 100)
							{
								num224 = 133;
							}
							if (num223 > 200)
							{
								num225 = 6f;
							}
							if (num223 > 200)
							{
								num224 = 132;
							}
							if (num223 > 300)
							{
								num225 = 6f;
							}
							if (num223 > 300)
							{
								num224 = 133;
							}
							int num226 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, num224, 0f, 0f, 100, default(Color), 1f);
							float num227 = Main.dust[num226].velocity.X;
							float num228 = Main.dust[num226].velocity.Y;
							if (num227 == 0f && num228 == 0f)
							{
								num227 = 1f;
							}
							float num229 = (float)Math.Sqrt((double)(num227 * num227 + num228 * num228));
							num229 = num225 / num229;
							if (num223 > 300)
							{
								num227 = num227 * num229 * 0.5f;
								num228 *= num229;
							}
							else if (num223 > 200)
							{
								num227 *= num229;
								num228 = num228 * num229 * 0.5f;
							}
							else
							{
								num227 *= num229;
								num228 *= num229;
							}
							Main.dust[num226].velocity *= 0.5f;
							Dust expr_70C5_cp_0 = Main.dust[num226];
							expr_70C5_cp_0.velocity.X = expr_70C5_cp_0.velocity.X + num227;
							Dust expr_70E0_cp_0 = Main.dust[num226];
							expr_70E0_cp_0.velocity.Y = expr_70E0_cp_0.velocity.Y + num228;
							if (num223 <= 200)
							{
								Main.dust[num226].scale = 1.3f;
								Main.dust[num226].noGravity = true;
							}
						}
					}
					if (this.type == 170)
					{
						for (int num230 = 0; num230 < 400; num230++)
						{
							int num231 = 133;
							float num232 = 16f;
							if (num230 > 100)
							{
								num232 = 11f;
							}
							if (num230 > 100)
							{
								num231 = 134;
							}
							if (num230 > 200)
							{
								num232 = 8f;
							}
							if (num230 > 200)
							{
								num231 = 133;
							}
							if (num230 > 300)
							{
								num232 = 5f;
							}
							if (num230 > 300)
							{
								num231 = 134;
							}
							int num233 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, num231, 0f, 0f, 100, default(Color), 1f);
							float num234 = Main.dust[num233].velocity.X;
							float num235 = Main.dust[num233].velocity.Y;
							if (num234 == 0f && num235 == 0f)
							{
								num234 = 1f;
							}
							float num236 = (float)Math.Sqrt((double)(num234 * num234 + num235 * num235));
							num236 = num232 / num236;
							if (num230 > 300)
							{
								num234 = num234 * num236 * 0.7f;
								num235 *= num236;
							}
							else if (num230 > 200)
							{
								num234 *= num236;
								num235 = num235 * num236 * 0.7f;
							}
							else if (num230 > 100)
							{
								num234 = num234 * num236 * 0.7f;
								num235 *= num236;
							}
							else
							{
								num234 *= num236;
								num235 = num235 * num236 * 0.7f;
							}
							Main.dust[num233].velocity *= 0.5f;
							Dust expr_72E2_cp_0 = Main.dust[num233];
							expr_72E2_cp_0.velocity.X = expr_72E2_cp_0.velocity.X + num234;
							Dust expr_72FD_cp_0 = Main.dust[num233];
							expr_72FD_cp_0.velocity.Y = expr_72FD_cp_0.velocity.Y + num235;
							if (Main.rand.Next(3) != 0)
							{
								Main.dust[num233].scale = 1.3f;
								Main.dust[num233].noGravity = true;
							}
						}
					}
					this.position.X = this.position.X + (float)(this.width / 2);
					this.position.Y = this.position.Y + (float)(this.height / 2);
					this.width = 192;
					this.height = 192;
					this.position.X = this.position.X - (float)(this.width / 2);
					this.position.Y = this.position.Y - (float)(this.height / 2);
					this.penetrate = -1;
					this.Damage();
				}
				else if (this.type == 312)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					this.position.X = this.position.X + (float)(this.width / 2);
					this.position.Y = this.position.Y + (float)(this.height / 2);
					this.width = 22;
					this.height = 22;
					this.position.X = this.position.X - (float)(this.width / 2);
					this.position.Y = this.position.Y - (float)(this.height / 2);
					for (int num237 = 0; num237 < 30; num237++)
					{
						int num238 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num238].velocity *= 1.4f;
					}
					for (int num239 = 0; num239 < 20; num239++)
					{
						int num240 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 3.5f);
						Main.dust[num240].noGravity = true;
						Main.dust[num240].velocity *= 7f;
						num240 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num240].velocity *= 3f;
					}
					for (int num241 = 0; num241 < 2; num241++)
					{
						float scaleFactor = 0.4f;
						if (num241 == 1)
						{
							scaleFactor = 0.8f;
						}
						int num242 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num242].velocity *= scaleFactor;
						Gore expr_76A1_cp_0 = Main.gore[num242];
						expr_76A1_cp_0.velocity.X = expr_76A1_cp_0.velocity.X + 1f;
						Gore expr_76C1_cp_0 = Main.gore[num242];
						expr_76C1_cp_0.velocity.Y = expr_76C1_cp_0.velocity.Y + 1f;
						num242 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num242].velocity *= scaleFactor;
						Gore expr_7744_cp_0 = Main.gore[num242];
						expr_7744_cp_0.velocity.X = expr_7744_cp_0.velocity.X - 1f;
						Gore expr_7764_cp_0 = Main.gore[num242];
						expr_7764_cp_0.velocity.Y = expr_7764_cp_0.velocity.Y + 1f;
						num242 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num242].velocity *= scaleFactor;
						Gore expr_77E7_cp_0 = Main.gore[num242];
						expr_77E7_cp_0.velocity.X = expr_77E7_cp_0.velocity.X + 1f;
						Gore expr_7807_cp_0 = Main.gore[num242];
						expr_7807_cp_0.velocity.Y = expr_7807_cp_0.velocity.Y - 1f;
						num242 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num242].velocity *= scaleFactor;
						Gore expr_788A_cp_0 = Main.gore[num242];
						expr_788A_cp_0.velocity.X = expr_788A_cp_0.velocity.X - 1f;
						Gore expr_78AA_cp_0 = Main.gore[num242];
						expr_78AA_cp_0.velocity.Y = expr_78AA_cp_0.velocity.Y - 1f;
					}
					this.position.X = this.position.X + (float)(this.width / 2);
					this.position.Y = this.position.Y + (float)(this.height / 2);
					this.width = 128;
					this.height = 128;
					this.position.X = this.position.X - (float)(this.width / 2);
					this.position.Y = this.position.Y - (float)(this.height / 2);
					this.Damage();
				}
				else if (this.type == 133 || this.type == 134 || this.type == 135 || this.type == 136 || this.type == 137 || this.type == 138 || this.type == 303 || this.type == 338 || this.type == 339)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					this.position.X = this.position.X + (float)(this.width / 2);
					this.position.Y = this.position.Y + (float)(this.height / 2);
					this.width = 22;
					this.height = 22;
					this.position.X = this.position.X - (float)(this.width / 2);
					this.position.Y = this.position.Y - (float)(this.height / 2);
					for (int num243 = 0; num243 < 30; num243++)
					{
						int num244 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num244].velocity *= 1.4f;
					}
					for (int num245 = 0; num245 < 20; num245++)
					{
						int num246 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 3.5f);
						Main.dust[num246].noGravity = true;
						Main.dust[num246].velocity *= 7f;
						num246 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num246].velocity *= 3f;
					}
					for (int num247 = 0; num247 < 2; num247++)
					{
						float scaleFactor2 = 0.4f;
						if (num247 == 1)
						{
							scaleFactor2 = 0.8f;
						}
						int num248 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num248].velocity *= scaleFactor2;
						Gore expr_7C9E_cp_0 = Main.gore[num248];
						expr_7C9E_cp_0.velocity.X = expr_7C9E_cp_0.velocity.X + 1f;
						Gore expr_7CBE_cp_0 = Main.gore[num248];
						expr_7CBE_cp_0.velocity.Y = expr_7CBE_cp_0.velocity.Y + 1f;
						num248 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num248].velocity *= scaleFactor2;
						Gore expr_7D41_cp_0 = Main.gore[num248];
						expr_7D41_cp_0.velocity.X = expr_7D41_cp_0.velocity.X - 1f;
						Gore expr_7D61_cp_0 = Main.gore[num248];
						expr_7D61_cp_0.velocity.Y = expr_7D61_cp_0.velocity.Y + 1f;
						num248 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num248].velocity *= scaleFactor2;
						Gore expr_7DE4_cp_0 = Main.gore[num248];
						expr_7DE4_cp_0.velocity.X = expr_7DE4_cp_0.velocity.X + 1f;
						Gore expr_7E04_cp_0 = Main.gore[num248];
						expr_7E04_cp_0.velocity.Y = expr_7E04_cp_0.velocity.Y - 1f;
						num248 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num248].velocity *= scaleFactor2;
						Gore expr_7E87_cp_0 = Main.gore[num248];
						expr_7E87_cp_0.velocity.X = expr_7E87_cp_0.velocity.X - 1f;
						Gore expr_7EA7_cp_0 = Main.gore[num248];
						expr_7EA7_cp_0.velocity.Y = expr_7EA7_cp_0.velocity.Y - 1f;
					}
				}
				else if (this.type == 139 || this.type == 140 || this.type == 141 || this.type == 142 || this.type == 143 || this.type == 144 || this.type == 340 || this.type == 341)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					this.position.X = this.position.X + (float)(this.width / 2);
					this.position.Y = this.position.Y + (float)(this.height / 2);
					this.width = 80;
					this.height = 80;
					this.position.X = this.position.X - (float)(this.width / 2);
					this.position.Y = this.position.Y - (float)(this.height / 2);
					for (int num249 = 0; num249 < 40; num249++)
					{
						int num250 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num250].velocity *= 3f;
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num250].scale = 0.5f;
							Main.dust[num250].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
						}
					}
					for (int num251 = 0; num251 < 70; num251++)
					{
						int num252 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 3f);
						Main.dust[num252].noGravity = true;
						Main.dust[num252].velocity *= 5f;
						num252 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num252].velocity *= 2f;
					}
					for (int num253 = 0; num253 < 3; num253++)
					{
						float scaleFactor3 = 0.33f;
						if (num253 == 1)
						{
							scaleFactor3 = 0.66f;
						}
						if (num253 == 2)
						{
							scaleFactor3 = 1f;
						}
						int num254 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num254].velocity *= scaleFactor3;
						Gore expr_8282_cp_0 = Main.gore[num254];
						expr_8282_cp_0.velocity.X = expr_8282_cp_0.velocity.X + 1f;
						Gore expr_82A2_cp_0 = Main.gore[num254];
						expr_82A2_cp_0.velocity.Y = expr_82A2_cp_0.velocity.Y + 1f;
						num254 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num254].velocity *= scaleFactor3;
						Gore expr_8345_cp_0 = Main.gore[num254];
						expr_8345_cp_0.velocity.X = expr_8345_cp_0.velocity.X - 1f;
						Gore expr_8365_cp_0 = Main.gore[num254];
						expr_8365_cp_0.velocity.Y = expr_8365_cp_0.velocity.Y + 1f;
						num254 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num254].velocity *= scaleFactor3;
						Gore expr_8408_cp_0 = Main.gore[num254];
						expr_8408_cp_0.velocity.X = expr_8408_cp_0.velocity.X + 1f;
						Gore expr_8428_cp_0 = Main.gore[num254];
						expr_8428_cp_0.velocity.Y = expr_8428_cp_0.velocity.Y - 1f;
						num254 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num254].velocity *= scaleFactor3;
						Gore expr_84CB_cp_0 = Main.gore[num254];
						expr_84CB_cp_0.velocity.X = expr_84CB_cp_0.velocity.X - 1f;
						Gore expr_84EB_cp_0 = Main.gore[num254];
						expr_84EB_cp_0.velocity.Y = expr_84EB_cp_0.velocity.Y - 1f;
					}
					this.position.X = this.position.X + (float)(this.width / 2);
					this.position.Y = this.position.Y + (float)(this.height / 2);
					this.width = 10;
					this.height = 10;
					this.position.X = this.position.X - (float)(this.width / 2);
					this.position.Y = this.position.Y - (float)(this.height / 2);
				}
				else if (this.type == 246)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int num255 = 0; num255 < 10; num255++)
					{
						int num256 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num256].velocity *= 0.9f;
					}
					for (int num257 = 0; num257 < 5; num257++)
					{
						int num258 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num258].noGravity = true;
						Main.dust[num258].velocity *= 3f;
						num258 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num258].velocity *= 2f;
					}
					int num259 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num259].velocity *= 0.3f;
					Gore expr_87CC_cp_0 = Main.gore[num259];
					expr_87CC_cp_0.velocity.X = expr_87CC_cp_0.velocity.X + (float)Main.rand.Next(-1, 2);
					Gore expr_87F4_cp_0 = Main.gore[num259];
					expr_87F4_cp_0.velocity.Y = expr_87F4_cp_0.velocity.Y + (float)Main.rand.Next(-1, 2);
					if (this.owner == Main.myPlayer)
					{
						int num260 = Main.rand.Next(2, 6);
						for (int num261 = 0; num261 < num260; num261++)
						{
							float num262 = (float)Main.rand.Next(-100, 101);
							num262 += 0.01f;
							float num263 = (float)Main.rand.Next(-100, 101);
							num262 -= 0.01f;
							float num264 = (float)Math.Sqrt((double)(num262 * num262 + num263 * num263));
							num264 = 8f / num264;
							num262 *= num264;
							num263 *= num264;
							Projectile.NewProjectile(this.center().X - this.lastVelocity.X, this.center().Y - this.lastVelocity.Y, num262, num263, 249, this.damage, this.knockBack, this.owner, 0f, 0f);
						}
					}
					this.position.X = this.position.X + (float)(this.width / 2);
					this.position.Y = this.position.Y + (float)(this.height / 2);
					this.width = 150;
					this.height = 150;
					this.position.X = this.position.X - (float)(this.width / 2);
					this.position.Y = this.position.Y - (float)(this.height / 2);
					this.penetrate = -1;
					this.Damage();
				}
				else if (this.type == 249)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int num265 = 0; num265 < 7; num265++)
					{
						int num266 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num266].velocity *= 0.8f;
					}
					for (int num267 = 0; num267 < 2; num267++)
					{
						int num268 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num268].noGravity = true;
						Main.dust[num268].velocity *= 2.5f;
						num268 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num268].velocity *= 1.5f;
					}
					int num269 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num269].velocity *= 0.2f;
					Gore expr_8C01_cp_0 = Main.gore[num269];
					expr_8C01_cp_0.velocity.X = expr_8C01_cp_0.velocity.X + (float)Main.rand.Next(-1, 2);
					Gore expr_8C29_cp_0 = Main.gore[num269];
					expr_8C29_cp_0.velocity.Y = expr_8C29_cp_0.velocity.Y + (float)Main.rand.Next(-1, 2);
					this.position.X = this.position.X + (float)(this.width / 2);
					this.position.Y = this.position.Y + (float)(this.height / 2);
					this.width = 100;
					this.height = 100;
					this.position.X = this.position.X - (float)(this.width / 2);
					this.position.Y = this.position.Y - (float)(this.height / 2);
					this.penetrate = -1;
					this.Damage();
				}
				else if (this.type == 28 || this.type == 30 || this.type == 37 || this.type == 75 || this.type == 102 || this.type == 164)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					this.position.X = this.position.X + (float)(this.width / 2);
					this.position.Y = this.position.Y + (float)(this.height / 2);
					this.width = 22;
					this.height = 22;
					this.position.X = this.position.X - (float)(this.width / 2);
					this.position.Y = this.position.Y - (float)(this.height / 2);
					for (int num270 = 0; num270 < 20; num270++)
					{
						int num271 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num271].velocity *= 1.4f;
					}
					for (int num272 = 0; num272 < 10; num272++)
					{
						int num273 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num273].noGravity = true;
						Main.dust[num273].velocity *= 5f;
						num273 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num273].velocity *= 3f;
					}
					int num274 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num274].velocity *= 0.4f;
					Gore expr_8FBA_cp_0 = Main.gore[num274];
					expr_8FBA_cp_0.velocity.X = expr_8FBA_cp_0.velocity.X + 1f;
					Gore expr_8FDA_cp_0 = Main.gore[num274];
					expr_8FDA_cp_0.velocity.Y = expr_8FDA_cp_0.velocity.Y + 1f;
					num274 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num274].velocity *= 0.4f;
					Gore expr_905E_cp_0 = Main.gore[num274];
					expr_905E_cp_0.velocity.X = expr_905E_cp_0.velocity.X - 1f;
					Gore expr_907E_cp_0 = Main.gore[num274];
					expr_907E_cp_0.velocity.Y = expr_907E_cp_0.velocity.Y + 1f;
					num274 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num274].velocity *= 0.4f;
					Gore expr_9102_cp_0 = Main.gore[num274];
					expr_9102_cp_0.velocity.X = expr_9102_cp_0.velocity.X + 1f;
					Gore expr_9122_cp_0 = Main.gore[num274];
					expr_9122_cp_0.velocity.Y = expr_9122_cp_0.velocity.Y - 1f;
					num274 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num274].velocity *= 0.4f;
					Gore expr_91A6_cp_0 = Main.gore[num274];
					expr_91A6_cp_0.velocity.X = expr_91A6_cp_0.velocity.X - 1f;
					Gore expr_91C6_cp_0 = Main.gore[num274];
					expr_91C6_cp_0.velocity.Y = expr_91C6_cp_0.velocity.Y - 1f;
				}
				else if (this.type == 29 || this.type == 108)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					if (this.type == 29)
					{
						this.position.X = this.position.X + (float)(this.width / 2);
						this.position.Y = this.position.Y + (float)(this.height / 2);
						this.width = 200;
						this.height = 200;
						this.position.X = this.position.X - (float)(this.width / 2);
						this.position.Y = this.position.Y - (float)(this.height / 2);
					}
					for (int num275 = 0; num275 < 50; num275++)
					{
						int num276 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num276].velocity *= 1.4f;
					}
					for (int num277 = 0; num277 < 80; num277++)
					{
						int num278 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 3f);
						Main.dust[num278].noGravity = true;
						Main.dust[num278].velocity *= 5f;
						num278 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num278].velocity *= 3f;
					}
					for (int num279 = 0; num279 < 2; num279++)
					{
						int num280 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num280].scale = 1.5f;
						Gore expr_94CD_cp_0 = Main.gore[num280];
						expr_94CD_cp_0.velocity.X = expr_94CD_cp_0.velocity.X + 1.5f;
						Gore expr_94ED_cp_0 = Main.gore[num280];
						expr_94ED_cp_0.velocity.Y = expr_94ED_cp_0.velocity.Y + 1.5f;
						num280 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num280].scale = 1.5f;
						Gore expr_9586_cp_0 = Main.gore[num280];
						expr_9586_cp_0.velocity.X = expr_9586_cp_0.velocity.X - 1.5f;
						Gore expr_95A6_cp_0 = Main.gore[num280];
						expr_95A6_cp_0.velocity.Y = expr_95A6_cp_0.velocity.Y + 1.5f;
						num280 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num280].scale = 1.5f;
						Gore expr_963F_cp_0 = Main.gore[num280];
						expr_963F_cp_0.velocity.X = expr_963F_cp_0.velocity.X + 1.5f;
						Gore expr_965F_cp_0 = Main.gore[num280];
						expr_965F_cp_0.velocity.Y = expr_965F_cp_0.velocity.Y - 1.5f;
						num280 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num280].scale = 1.5f;
						Gore expr_96F8_cp_0 = Main.gore[num280];
						expr_96F8_cp_0.velocity.X = expr_96F8_cp_0.velocity.X - 1.5f;
						Gore expr_9718_cp_0 = Main.gore[num280];
						expr_9718_cp_0.velocity.Y = expr_9718_cp_0.velocity.Y - 1.5f;
					}
					this.position.X = this.position.X + (float)(this.width / 2);
					this.position.Y = this.position.Y + (float)(this.height / 2);
					this.width = 10;
					this.height = 10;
					this.position.X = this.position.X - (float)(this.width / 2);
					this.position.Y = this.position.Y - (float)(this.height / 2);
				}
				else if (this.type == 69)
				{
					Main.PlaySound(13, (int)this.position.X, (int)this.position.Y, 1);
					for (int num281 = 0; num281 < 5; num281++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 13, 0f, 0f, 0, default(Color), 1f);
					}
					for (int num282 = 0; num282 < 30; num282++)
					{
						int num283 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 33, 0f, -2f, 0, default(Color), 1.1f);
						Main.dust[num283].alpha = 100;
						Dust expr_98CA_cp_0 = Main.dust[num283];
						expr_98CA_cp_0.velocity.X = expr_98CA_cp_0.velocity.X * 1.5f;
						Main.dust[num283].velocity *= 3f;
					}
				}
				else if (this.type == 70)
				{
					Main.PlaySound(13, (int)this.position.X, (int)this.position.Y, 1);
					for (int num284 = 0; num284 < 5; num284++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 13, 0f, 0f, 0, default(Color), 1f);
					}
					for (int num285 = 0; num285 < 30; num285++)
					{
						int num286 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 52, 0f, -2f, 0, default(Color), 1.1f);
						Main.dust[num286].alpha = 100;
						Dust expr_9A20_cp_0 = Main.dust[num286];
						expr_9A20_cp_0.velocity.X = expr_9A20_cp_0.velocity.X * 1.5f;
						Main.dust[num286].velocity *= 3f;
					}
				}
				else if (this.type == 114 || this.type == 115)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num287 = 4; num287 < 31; num287++)
					{
						float num288 = this.lastVelocity.X * (30f / (float)num287);
						float num289 = this.lastVelocity.Y * (30f / (float)num287);
						int num290 = Dust.NewDust(new Vector2(this.position.X - num288, this.position.Y - num289), 8, 8, 27, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.4f);
						Main.dust[num290].noGravity = true;
						Main.dust[num290].velocity *= 0.5f;
						num290 = Dust.NewDust(new Vector2(this.position.X - num288, this.position.Y - num289), 8, 8, 27, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 0.9f);
						Main.dust[num290].velocity *= 0.5f;
					}
				}
				else if (this.type == 116)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num291 = 4; num291 < 31; num291++)
					{
						float num292 = this.lastVelocity.X * (30f / (float)num291);
						float num293 = this.lastVelocity.Y * (30f / (float)num291);
						int num294 = Dust.NewDust(new Vector2(this.position.X - num292, this.position.Y - num293), 8, 8, 64, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.8f);
						Main.dust[num294].noGravity = true;
						num294 = Dust.NewDust(new Vector2(this.position.X - num292, this.position.Y - num293), 8, 8, 64, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.4f);
						Main.dust[num294].noGravity = true;
					}
				}
				else if (this.type == 173)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num295 = 4; num295 < 24; num295++)
					{
						float num296 = this.lastVelocity.X * (30f / (float)num295);
						float num297 = this.lastVelocity.Y * (30f / (float)num295);
						int num298 = Main.rand.Next(3);
						if (num298 == 0)
						{
							num298 = 15;
						}
						else if (num298 == 1)
						{
							num298 = 57;
						}
						else
						{
							num298 = 58;
						}
						int num299 = Dust.NewDust(new Vector2(this.position.X - num296, this.position.Y - num297), 8, 8, num298, this.lastVelocity.X * 0.2f, this.lastVelocity.Y * 0.2f, 100, default(Color), 1.8f);
						Main.dust[num299].velocity *= 1.5f;
						Main.dust[num299].noGravity = true;
					}
				}
				else if (this.type == 132)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num300 = 4; num300 < 31; num300++)
					{
						float num301 = this.lastVelocity.X * (30f / (float)num300);
						float num302 = this.lastVelocity.Y * (30f / (float)num300);
						int num303 = Dust.NewDust(new Vector2(this.lastPosition.X - num301, this.lastPosition.Y - num302), 8, 8, 107, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.8f);
						Main.dust[num303].noGravity = true;
						Main.dust[num303].velocity *= 0.5f;
						num303 = Dust.NewDust(new Vector2(this.lastPosition.X - num301, this.lastPosition.Y - num302), 8, 8, 107, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.4f);
						Main.dust[num303].velocity *= 0.05f;
					}
				}
				else if (this.type == 156)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num304 = 4; num304 < 31; num304++)
					{
						float num305 = this.lastVelocity.X * (30f / (float)num304);
						float num306 = this.lastVelocity.Y * (30f / (float)num304);
						int num307 = Dust.NewDust(new Vector2(this.lastPosition.X - num305, this.lastPosition.Y - num306), 8, 8, 73, this.lastVelocity.X, this.lastVelocity.Y, 255, default(Color), 1.8f);
						Main.dust[num307].noGravity = true;
						Main.dust[num307].velocity *= 0.5f;
						num307 = Dust.NewDust(new Vector2(this.lastPosition.X - num305, this.lastPosition.Y - num306), 8, 8, 73, this.lastVelocity.X, this.lastVelocity.Y, 255, default(Color), 1.4f);
						Main.dust[num307].velocity *= 0.05f;
						Main.dust[num307].noGravity = true;
					}
				}
				else if (this.type == 157)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num308 = 4; num308 < 31; num308++)
					{
						int num309 = Dust.NewDust(this.position, this.width, this.height, 107, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.8f);
						Main.dust[num309].noGravity = true;
						Main.dust[num309].velocity *= 0.5f;
					}
				}
			}
			if (this.owner == Main.myPlayer)
			{
				if (this.type == 28 || this.type == 29 || this.type == 37 || this.type == 108 || this.type == 136 || this.type == 137 || this.type == 138 || this.type == 142 || this.type == 143 || this.type == 144 || this.type == 339 || this.type == 341)
				{
					int num310 = 3;
					if (this.type == 28 || this.type == 37)
					{
						num310 = 4;
					}
					if (this.type == 29)
					{
						num310 = 7;
					}
					if (this.type == 142 || this.type == 143 || this.type == 144 || this.type == 341)
					{
						num310 = 5;
					}
					if (this.type == 108)
					{
						num310 = 10;
					}
					int num311 = (int)(this.position.X / 16f - (float)num310);
					int num312 = (int)(this.position.X / 16f + (float)num310);
					int num313 = (int)(this.position.Y / 16f - (float)num310);
					int num314 = (int)(this.position.Y / 16f + (float)num310);
					if (num311 < 0)
					{
						num311 = 0;
					}
					if (num312 > Main.maxTilesX)
					{
						num312 = Main.maxTilesX;
					}
					if (num313 < 0)
					{
						num313 = 0;
					}
					if (num314 > Main.maxTilesY)
					{
						num314 = Main.maxTilesY;
					}
					bool flag = false;
					for (int num315 = num311; num315 <= num312; num315++)
					{
						for (int num316 = num313; num316 <= num314; num316++)
						{
							float num317 = Math.Abs((float)num315 - this.position.X / 16f);
							float num318 = Math.Abs((float)num316 - this.position.Y / 16f);
							double num319 = Math.Sqrt((double)(num317 * num317 + num318 * num318));
							if (num319 < (double)num310 && Main.tile[num315, num316] != null && Main.tile[num315, num316].wall == 0)
							{
								flag = true;
								break;
							}
						}
					}
					for (int num320 = num311; num320 <= num312; num320++)
					{
						for (int num321 = num313; num321 <= num314; num321++)
						{
							float num322 = Math.Abs((float)num320 - this.position.X / 16f);
							float num323 = Math.Abs((float)num321 - this.position.Y / 16f);
							double num324 = Math.Sqrt((double)(num322 * num322 + num323 * num323));
							if (num324 < (double)num310)
							{
								bool flag2 = true;
								if (Main.tile[num320, num321] != null && Main.tile[num320, num321].active())
								{
									flag2 = true;
									if (Main.tileDungeon[(int)Main.tile[num320, num321].type] || Main.tile[num320, num321].type == 21 || Main.tile[num320, num321].type == 26 || Main.tile[num320, num321].type == 107 || Main.tile[num320, num321].type == 108 || Main.tile[num320, num321].type == 111 || Main.tile[num320, num321].type == 226 || Main.tile[num320, num321].type == 237 || Main.tile[num320, num321].type == 221 || Main.tile[num320, num321].type == 222 || Main.tile[num320, num321].type == 223 || Main.tile[num320, num321].type == 211)
									{
										flag2 = false;
									}
									if (!Main.hardMode && Main.tile[num320, num321].type == 58)
									{
										flag2 = false;
									}
									if (flag2)
									{
										WorldGen.KillTile(num320, num321, false, false, false);
										if (!Main.tile[num320, num321].active() && Main.netMode != 0)
										{
											NetMessage.SendData(17, -1, -1, "", 0, (float)num320, (float)num321, 0f, 0);
										}
									}
								}
								if (flag2)
								{
									for (int num325 = num320 - 1; num325 <= num320 + 1; num325++)
									{
										for (int num326 = num321 - 1; num326 <= num321 + 1; num326++)
										{
											if (Main.tile[num325, num326] != null && Main.tile[num325, num326].wall > 0 && flag)
											{
												WorldGen.KillWall(num325, num326, false);
												if (Main.tile[num325, num326].wall == 0 && Main.netMode != 0)
												{
													NetMessage.SendData(17, -1, -1, "", 2, (float)num325, (float)num326, 0f, 0);
												}
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
					NetMessage.SendData(29, -1, -1, "", this.identity, (float)this.owner, 0f, 0f, 0);
				}
				if (!this.noDropItem)
				{
					int num327 = -1;
					if (this.aiStyle == 10)
					{
						int num328 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num329 = (int)(this.position.Y + (float)(this.width / 2)) / 16;
						int num330 = 0;
						int num331 = 2;
						if (this.type == 109)
						{
							num330 = 147;
							num331 = 0;
						}
						if (this.type == 31)
						{
							num330 = 53;
							num331 = 0;
						}
						if (this.type == 42)
						{
							num330 = 53;
							num331 = 0;
						}
						if (this.type == 56)
						{
							num330 = 112;
							num331 = 0;
						}
						if (this.type == 65)
						{
							num330 = 112;
							num331 = 0;
						}
						if (this.type == 67)
						{
							num330 = 116;
							num331 = 0;
						}
						if (this.type == 68)
						{
							num330 = 116;
							num331 = 0;
						}
						if (this.type == 71)
						{
							num330 = 123;
							num331 = 0;
						}
						if (this.type == 39)
						{
							num330 = 59;
							num331 = 176;
						}
						if (this.type == 40)
						{
							num330 = 57;
							num331 = 172;
						}
						if (this.type == 179)
						{
							num330 = 224;
							num331 = 0;
						}
						if (this.type == 241)
						{
							num330 = 234;
							num331 = 0;
						}
						if (Main.tile[num328, num329].halfBrick() && this.velocity.Y > 0f && Math.Abs(this.velocity.Y) > Math.Abs(this.velocity.X))
						{
							num329--;
						}
						if (!Main.tile[num328, num329].active())
						{
							WorldGen.PlaceTile(num328, num329, num330, false, true, -1, 0);
							if (Main.tile[num328, num329].active() && (int)Main.tile[num328, num329].type == num330)
							{
								NetMessage.SendData(17, -1, -1, "", 1, (float)num328, (float)num329, (float)num330, 0);
							}
							else if (num331 > 0)
							{
								num327 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num331, 1, false, 0, false);
							}
						}
						else if (num331 > 0)
						{
							num327 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num331, 1, false, 0, false);
						}
					}
					if (this.type == 1 && Main.rand.Next(3) == 0)
					{
						num327 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0, false);
					}
					if (this.type == 103 && Main.rand.Next(6) == 0)
					{
						if (Main.rand.Next(3) == 0)
						{
							num327 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 545, 1, false, 0, false);
						}
						else
						{
							num327 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0, false);
						}
					}
					if (this.type == 2 && Main.rand.Next(3) == 0)
					{
						if (Main.rand.Next(3) == 0)
						{
							num327 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 41, 1, false, 0, false);
						}
						else
						{
							num327 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0, false);
						}
					}
					if (this.type == 172 && Main.rand.Next(3) == 0)
					{
						if (Main.rand.Next(3) == 0)
						{
							num327 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 988, 1, false, 0, false);
						}
						else
						{
							num327 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0, false);
						}
					}
					if (this.type == 171)
					{
						if (this.ai[1] == 0f)
						{
							num327 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 985, 1, false, 0, false);
						}
						else if (this.ai[1] < 10f)
						{
							num327 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 965, (int)(10f - this.ai[1]), false, 0, false);
						}
					}
					if (this.type == 91 && Main.rand.Next(6) == 0)
					{
						num327 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 516, 1, false, 0, false);
					}
					if (this.type == 50 && Main.rand.Next(3) == 0)
					{
						num327 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 282, 1, false, 0, false);
					}
					if (this.type == 53 && Main.rand.Next(3) == 0)
					{
						num327 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 286, 1, false, 0, false);
					}
					if (this.type == 48 && Main.rand.Next(2) == 0)
					{
						num327 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 279, 1, false, 0, false);
					}
					if (this.type == 54 && Main.rand.Next(2) == 0)
					{
						num327 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 287, 1, false, 0, false);
					}
					if (this.type == 3 && Main.rand.Next(2) == 0)
					{
						num327 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 42, 1, false, 0, false);
					}
					if (this.type == 4 && Main.rand.Next(4) == 0)
					{
						num327 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 47, 1, false, 0, false);
					}
					if (this.type == 12 && this.damage > 100)
					{
						num327 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 75, 1, false, 0, false);
					}
					if (this.type == 155)
					{
						num327 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 859, 1, false, 0, false);
					}
					if (this.type == 21 && Main.rand.Next(2) == 0)
					{
						num327 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 154, 1, false, 0, false);
					}
					if (Main.netMode == 1 && num327 >= 0)
					{
						NetMessage.SendData(21, -1, -1, "", num327, 0f, 0f, 0f, 0);
					}
				}
				if (this.type == 69 || this.type == 70)
				{
					int num332 = (int)(this.position.X + (float)(this.width / 2)) / 16;
					int num333 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
					for (int num334 = num332 - 4; num334 <= num332 + 4; num334++)
					{
						for (int num335 = num333 - 4; num335 <= num333 + 4; num335++)
						{
							if (Math.Abs(num334 - num332) + Math.Abs(num335 - num333) < 6)
							{
								if (this.type == 69)
								{
									if (Main.tile[num334, num335].type == 2)
									{
										Main.tile[num334, num335].type = 109;
										WorldGen.SquareTileFrame(num334, num335, true);
										NetMessage.SendTileSquare(-1, num334, num335, 1);
									}
									else if (Main.tile[num334, num335].type == 1 || Main.tileMoss[(int)Main.tile[num334, num335].type])
									{
										Main.tile[num334, num335].type = 117;
										WorldGen.SquareTileFrame(num334, num335, true);
										NetMessage.SendTileSquare(-1, num334, num335, 1);
									}
									else if (Main.tile[num334, num335].type == 53 || Main.tile[num334, num335].type == 234)
									{
										Main.tile[num334, num335].type = 116;
										WorldGen.SquareTileFrame(num334, num335, true);
										NetMessage.SendTileSquare(-1, num334, num335, 1);
									}
									else if (Main.tile[num334, num335].type == 23 || Main.tile[num334, num335].type == 199)
									{
										Main.tile[num334, num335].type = 109;
										WorldGen.SquareTileFrame(num334, num335, true);
										NetMessage.SendTileSquare(-1, num334, num335, 1);
									}
									else if (Main.tile[num334, num335].type == 25 || Main.tile[num334, num335].type == 203)
									{
										Main.tile[num334, num335].type = 117;
										WorldGen.SquareTileFrame(num334, num335, true);
										NetMessage.SendTileSquare(-1, num334, num335, 1);
									}
									else if (Main.tile[num334, num335].type == 161 || Main.tile[num334, num335].type == 163 || Main.tile[num334, num335].type == 200)
									{
										Main.tile[num334, num335].type = 164;
										WorldGen.SquareTileFrame(num334, num335, true);
										NetMessage.SendTileSquare(-1, num334, num335, 1);
									}
									else if (Main.tile[num334, num335].type == 112)
									{
										Main.tile[num334, num335].type = 116;
										WorldGen.SquareTileFrame(num334, num335, true);
										NetMessage.SendTileSquare(-1, num334, num335, 1);
									}
									else if (Main.tile[num334, num335].type == 161 || Main.tile[num334, num335].type == 163)
									{
										Main.tile[num334, num335].type = 164;
										WorldGen.SquareTileFrame(num334, num335, true);
										NetMessage.SendTileSquare(-1, num334, num335, 1);
									}
								}
								else if (Main.tile[num334, num335].type == 2)
								{
									Main.tile[num334, num335].type = 23;
									WorldGen.SquareTileFrame(num334, num335, true);
									NetMessage.SendTileSquare(-1, num334, num335, 1);
								}
								else if (Main.tile[num334, num335].type == 1 || Main.tileMoss[(int)Main.tile[num334, num335].type])
								{
									Main.tile[num334, num335].type = 25;
									WorldGen.SquareTileFrame(num334, num335, true);
									NetMessage.SendTileSquare(-1, num334, num335, 1);
								}
								else if (Main.tile[num334, num335].type == 53)
								{
									Main.tile[num334, num335].type = 112;
									WorldGen.SquareTileFrame(num334, num335, true);
									NetMessage.SendTileSquare(-1, num334, num335, 1);
								}
								else if (Main.tile[num334, num335].type == 109)
								{
									Main.tile[num334, num335].type = 23;
									WorldGen.SquareTileFrame(num334, num335, true);
									NetMessage.SendTileSquare(-1, num334, num335, 1);
								}
								else if (Main.tile[num334, num335].type == 117)
								{
									Main.tile[num334, num335].type = 25;
									WorldGen.SquareTileFrame(num334, num335, true);
									NetMessage.SendTileSquare(-1, num334, num335, 1);
								}
								else if (Main.tile[num334, num335].type == 116)
								{
									Main.tile[num334, num335].type = 112;
									WorldGen.SquareTileFrame(num334, num335, true);
									NetMessage.SendTileSquare(-1, num334, num335, 1);
								}
								else if (Main.tile[num334, num335].type == 161 || Main.tile[num334, num335].type == 164 || Main.tile[num334, num335].type == 200)
								{
									Main.tile[num334, num335].type = 163;
									WorldGen.SquareTileFrame(num334, num335, true);
									NetMessage.SendTileSquare(-1, num334, num335, 1);
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
			if (this.type == 34 || this.type == 15 || this.type == 93 || this.type == 94 || this.type == 95 || this.type == 96 || this.type == 253 || this.type == 258 || (this.type == 102 && this.alpha < 255))
			{
				return new Color(200, 200, 200, 25);
			}
			if (this.type == 348 || this.type == 349)
			{
				return new Color(200, 200, 200, this.alpha);
			}
			if (this.type == 337)
			{
				return new Color(250, 250, 250, 150);
			}
			if (this.type == 343 || this.type == 344)
			{
				float num = 1f - (float)this.alpha / 255f;
				return new Color((int)(250f * num), (int)(250f * num), (int)(250f * num), (int)(100f * num));
			}
			if (this.type == 332)
			{
				return new Color(255, 255, 255, 255);
			}
			if (this.type == 329)
			{
				return new Color(200, 200, 200, 50);
			}
			if (this.type >= 326 && this.type <= 328)
			{
				return new Color(0, 0, 0, 0);
			}
			if (this.type == 324 && this.frame >= 6 && this.frame <= 9)
			{
				return new Color(255, 255, 255, 255);
			}
			if (this.type == 16)
			{
				return new Color(255, 255, 255, 0);
			}
			if (this.type == 321)
			{
				return new Color(200, 200, 200, 0);
			}
			if (this.type == 76 || this.type == 77 || this.type == 78)
			{
				return new Color(255, 255, 255, 0);
			}
			if (this.type == 308)
			{
				return new Color(200, 200, 255, 125);
			}
			if (this.type == 263)
			{
				if (this.timeLeft < 255)
				{
					return new Color(255, 255, 255, (int)((byte)this.timeLeft));
				}
				return new Color(255, 255, 255, 255);
			}
			else if (this.type == 274)
			{
				if (this.timeLeft < 85)
				{
					byte b = (byte)(this.timeLeft * 3);
					byte a = (byte)(100f * ((float)b / 255f));
					return new Color((int)b, (int)b, (int)b, (int)a);
				}
				return new Color(255, 255, 255, 100);
			}
			else
			{
				if (this.type == 5)
				{
					return new Color(255, 255, 255, 0);
				}
				if (this.type == 300 || this.type == 301)
				{
					return new Color(250, 250, 250, 50);
				}
				if (this.type == 304)
				{
					return new Color(255 - this.alpha, 255 - this.alpha, 255 - this.alpha, (int)((byte)((float)(255 - this.alpha) / 3f)));
				}
				if (this.type == 116 || this.type == 132 || this.type == 156 || this.type == 157 || this.type == 157 || this.type == 173)
				{
					if (this.localAI[1] >= 15f)
					{
						return new Color(255, 255, 255, this.alpha);
					}
					if (this.localAI[1] < 5f)
					{
						return new Color(0, 0, 0, 0);
					}
					int num2 = (int)((this.localAI[1] - 5f) / 10f * 255f);
					return new Color(num2, num2, num2, num2);
				}
				else
				{
					if (this.type == 254)
					{
						if (this.timeLeft < 30)
						{
							float num3 = (float)this.timeLeft / 30f;
							this.alpha = (int)(255f - 255f * num3);
						}
						return new Color(255 - this.alpha, 255 - this.alpha, 255 - this.alpha, 0);
					}
					if (this.type == 265)
					{
						if (this.alpha > 0)
						{
							return new Color(0, 0, 0, 0);
						}
						return new Color(255, 255, 255, 0);
					}
					else if (this.type == 270)
					{
						if (this.alpha > 0)
						{
							return new Color(0, 0, 0, 0);
						}
						return new Color(255, 255, 255, 200);
					}
					else if (this.type == 257)
					{
						if (this.alpha > 200)
						{
							return new Color(0, 0, 0, 0);
						}
						return new Color(255 - this.alpha, 255 - this.alpha, 255 - this.alpha, 0);
					}
					else if (this.type == 259)
					{
						if (this.alpha > 200)
						{
							return new Color(0, 0, 0, 0);
						}
						return new Color(255 - this.alpha, 255 - this.alpha, 255 - this.alpha, 0);
					}
					else
					{
						if (this.type >= 150 && this.type <= 152)
						{
							return new Color(255 - this.alpha, 255 - this.alpha, 255 - this.alpha, 255 - this.alpha);
						}
						if (this.type == 250)
						{
							return new Color(0, 0, 0, 0);
						}
						int num4;
						int num5;
						int num6;
						if (this.type == 251)
						{
							num4 = 255 - this.alpha;
							num5 = 255 - this.alpha;
							num6 = 255 - this.alpha;
							return new Color(num4, num5, num6, 0);
						}
						if (this.type == 131)
						{
							return new Color(255 - this.alpha, 255 - this.alpha, 255 - this.alpha, 0);
						}
						if (this.type == 211)
						{
							return new Color(255, 255, 255, 0);
						}
						if (this.type == 229)
						{
							return new Color(255, 255, 255, 50);
						}
						if (this.type == 221)
						{
							return new Color(255, 255, 255, 200);
						}
						if (this.type == 207)
						{
							num4 = 255 - this.alpha;
							num5 = 255 - this.alpha;
							num6 = 255 - this.alpha;
						}
						else if (this.type == 242)
						{
							if (this.alpha < 140)
							{
								return new Color(255, 255, 255, 100);
							}
							return new Color(0, 0, 0, 0);
						}
						else if (this.type == 209)
						{
							num4 = (int)newColor.R - this.alpha;
							num5 = (int)newColor.G - this.alpha;
							num6 = (int)newColor.B - this.alpha / 2;
						}
						else
						{
							if (this.type == 130)
							{
								return new Color(255, 255, 255, 175);
							}
							if (this.type == 182)
							{
								return new Color(255, 255, 255, 200);
							}
							if (this.type == 226)
							{
								num4 = 255;
								num5 = 255;
								num6 = 255;
								float num7 = (float)Main.mouseTextColor / 200f - 0.3f;
								num4 = (int)((float)num4 * num7);
								num5 = (int)((float)num5 * num7);
								num6 = (int)((float)num6 * num7);
								num4 += 50;
								if (num4 > 255)
								{
									num4 = 255;
								}
								num5 += 50;
								if (num5 > 255)
								{
									num5 = 255;
								}
								num6 += 50;
								if (num6 > 255)
								{
									num6 = 255;
								}
								return new Color(num4, num5, num6, 200);
							}
							if (this.type == 227)
							{
								num5 = (num4 = (num6 = 255));
								float num8 = (float)Main.mouseTextColor / 100f - 1.6f;
								num4 = (int)((float)num4 * num8);
								num5 = (int)((float)num5 * num8);
								num6 = (int)((float)num6 * num8);
								int a2 = (int)(100f * num8);
								num4 += 50;
								if (num4 > 255)
								{
									num4 = 255;
								}
								num5 += 50;
								if (num5 > 255)
								{
									num5 = 255;
								}
								num6 += 50;
								if (num6 > 255)
								{
									num6 = 255;
								}
								return new Color(num4, num5, num6, a2);
							}
							if (this.type == 114 || this.type == 115)
							{
								if (this.localAI[1] >= 15f)
								{
									return new Color(255, 255, 255, this.alpha);
								}
								if (this.localAI[1] < 5f)
								{
									return new Color(0, 0, 0, 0);
								}
								int num9 = (int)((this.localAI[1] - 5f) / 10f * 255f);
								return new Color(num9, num9, num9, num9);
							}
							else if (this.type == 83 || this.type == 88 || this.type == 89 || this.type == 90 || this.type == 100 || this.type == 104 || this.type == 279 || (this.type >= 283 && this.type <= 287))
							{
								if (this.alpha < 200)
								{
									return new Color(255 - this.alpha, 255 - this.alpha, 255 - this.alpha, 0);
								}
								return new Color(0, 0, 0, 0);
							}
							else
							{
								if (this.type == 34 || this.type == 35 || this.type == 15 || this.type == 19 || this.type == 44 || this.type == 45)
								{
									return Color.White;
								}
								if (this.type == 79)
								{
									num4 = Main.DiscoR;
									num5 = Main.DiscoG;
									num6 = Main.DiscoB;
									return default(Color);
								}
								if (this.type == 9 || this.type == 15 || this.type == 34 || this.type == 50 || this.type == 53 || this.type == 76 || this.type == 77 || this.type == 78 || this.type == 92 || this.type == 91)
								{
									num4 = (int)newColor.R - this.alpha / 3;
									num5 = (int)newColor.G - this.alpha / 3;
									num6 = (int)newColor.B - this.alpha / 3;
								}
								else
								{
									if (this.type == 18)
									{
										return new Color(255, 255, 255, 50);
									}
									if (this.type == 16 || this.type == 44 || this.type == 45)
									{
										num4 = (int)newColor.R;
										num5 = (int)newColor.G;
										num6 = (int)newColor.B;
									}
									else if (this.type == 12 || this.type == 72 || this.type == 86 || this.type == 87)
									{
										return new Color(255, 255, 255, (int)newColor.A - this.alpha);
									}
								}
							}
						}
						float num10 = (float)(255 - this.alpha) / 255f;
						num4 = (int)((float)newColor.R * num10);
						num5 = (int)((float)newColor.G * num10);
						num6 = (int)((float)newColor.B * num10);
						int num11 = (int)newColor.A - this.alpha;
						if (num11 < 0)
						{
							num11 = 0;
						}
						if (num11 > 255)
						{
							num11 = 255;
						}
						return new Color(num4, num5, num6, num11);
					}
				}
			}
		}
	}
}
