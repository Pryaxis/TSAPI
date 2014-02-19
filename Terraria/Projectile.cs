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
		public int maxPenetrate = 1;
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
				this.melee = true;
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
				this.ignoreWater = true;
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
				this.penetrate = 1;
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
				this.penetrate = 1;
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
				this.penetrate = 2;
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
				this.penetrate = 2;
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
				this.penetrate = 2;
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
				this.ignoreWater = true;
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
				this.scale = 1f;
				this.timeLeft *= 10;
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
				this.ignoreWater = true;
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
				this.penetrate = 4;
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
				this.penetrate = 3;
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
				this.penetrate = 5;
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
				this.penetrate = 3;
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
				this.melee = true;
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
			else if (this.type == 354)
			{
				this.name = "Crimsand Ball";
				this.knockBack = 6f;
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
				this.friendly = true;
				this.penetrate = -1;
				this.maxUpdates = 1;
			}
			else if (this.type == 355)
			{
				this.name = "Venom Fang";
				this.width = 12;
				this.height = 12;
				this.aiStyle = 1;
				this.alpha = 255;
				this.friendly = true;
				this.magic = true;
				this.penetrate = 7;
			}
			else if (this.type == 356)
			{
				this.name = "Spectre Wrath";
				this.width = 6;
				this.height = 6;
				this.aiStyle = 59;
				this.alpha = 255;
				this.magic = true;
				this.tileCollide = false;
				this.maxUpdates = 3;
			}
			else if (this.type == 357)
			{
				this.name = "Pulse Bolt";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 6;
				this.alpha = 255;
				this.maxUpdates = 2;
				this.scale = 1.2f;
				this.timeLeft = 600;
				this.ranged = true;
			}
			else if (this.type == 358)
			{
				this.name = "Water Gun";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 60;
				this.alpha = 255;
				this.penetrate = -1;
				this.maxUpdates = 2;
				this.ignoreWater = true;
			}
			else if (this.type == 359)
			{
				this.name = "Frost Bolt";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 28;
				this.alpha = 255;
				this.magic = true;
				this.penetrate = 2;
				this.friendly = true;
			}
			else
			{
				this.active = false;
			}
			this.width = (int)((float)this.width * this.scale);
			this.height = (int)((float)this.height * this.scale);
			this.maxPenetrate = this.penetrate;
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
				while (Main.projectile[num].velocity.X >= 16f || Main.projectile[num].velocity.X <= -16f || Main.projectile[num].velocity.Y >= 16f || Main.projectile[num].velocity.Y < -16f)
				{
					Projectile expr_18A_cp_0 = Main.projectile[num];
					expr_18A_cp_0.velocity.X = expr_18A_cp_0.velocity.X * 0.97f;
					Projectile expr_1A7_cp_0 = Main.projectile[num];
					expr_1A7_cp_0.velocity.Y = expr_1A7_cp_0.velocity.Y * 0.97f;
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
				else if (Type == 358)
				{
					Main.projectile[num].ai[1] = (float)Main.rand.Next(10, 31) * 0.1f;
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
					Main.npc[i].AddBuff(44, 180, false);
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
					Main.npc[i].AddBuff(44, 480, false);
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
				Main.npc[i].AddBuff(69, 600, false);
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
			if (this.type == 163 || this.type == 310)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.npc[i].AddBuff(24, 600, false);
					return;
				}
				Main.npc[i].AddBuff(24, 300, false);
				return;
			}
			else
			{
				if (this.type == 265)
				{
					Main.npc[i].AddBuff(20, 1800, false);
					return;
				}
				if (this.type == 355)
				{
					Main.npc[i].AddBuff(70, 1800, false);
				}
				return;
			}
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
			else if (this.type == 253)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(44, 480, false);
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
			if (this.type == 163 || this.type == 310)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.player[i].AddBuff(24, 600, true);
					return;
				}
				Main.player[i].AddBuff(24, 300, true);
				return;
			}
			else
			{
				if (this.type == 265)
				{
					Main.player[i].AddBuff(20, 1200, true);
					return;
				}
				if (this.type == 355)
				{
					Main.player[i].AddBuff(70, 1800, true);
				}
				return;
			}
		}
		public void ghostHurt(int dmg, Vector2 Position)
		{
			if (!this.magic)
			{
				return;
			}
			int num = this.damage / 2;
			if (dmg / 2 <= 1)
			{
				return;
			}
			int num2 = 1000;
			if (Main.player[Main.myPlayer].ghostDmg > (float)num2)
			{
				return;
			}
			Main.player[Main.myPlayer].ghostDmg += (float)num;
			int[] array = new int[200];
			int num3 = 0;
			int num4 = 0;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && !Main.npc[i].friendly && Main.npc[i].lifeMax > 5 && !Main.npc[i].dontTakeDamage)
				{
					float num5 = Math.Abs(Main.npc[i].position.X + (float)(Main.npc[i].width / 2) - this.position.X + (float)(this.width / 2)) + Math.Abs(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2) - this.position.Y + (float)(this.height / 2));
					if (num5 < 800f)
					{
						if (Collision.CanHit(this.position, 1, 1, Main.npc[i].position, Main.npc[i].width, Main.npc[i].height) && num5 > 50f)
						{
							array[num4] = i;
							num4++;
						}
						else if (num4 == 0)
						{
							array[num3] = i;
							num3++;
						}
					}
				}
			}
			if (num3 == 0 && num4 == 0)
			{
				return;
			}
			int num6;
			if (num4 > 0)
			{
				num6 = array[Main.rand.Next(num4)];
			}
			else
			{
				num6 = array[Main.rand.Next(num3)];
			}
			float num7 = 4f;
			float num8 = (float)Main.rand.Next(-100, 101);
			float num9 = (float)Main.rand.Next(-100, 101);
			float num10 = (float)Math.Sqrt((double)(num8 * num8 + num9 * num9));
			num10 = num7 / num10;
			num8 *= num10;
			num9 *= num10;
			Projectile.NewProjectile(Position.X, Position.Y, num8, num9, 356, num, 0f, this.owner, (float)num6, 0f);
		}
		public void ghostHeal(int dmg, Vector2 Position)
		{
			float num = 0.2f;
			num -= (float)this.numHits * 0.05f;
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
				if (Main.rand.Next(6) == 0)
				{
					Main.player[i].AddBuff(39, 480, true);
				}
				else if (Main.rand.Next(4) == 0)
				{
					Main.player[i].AddBuff(39, 300, true);
				}
				else if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(39, 180, true);
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
						if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && (((!Main.npc[k].friendly || this.type == 318 || (Main.npc[k].type == 22 && this.owner < 255 && Main.player[this.owner].killGuide) || (Main.npc[k].type == 54 && this.owner < 255 && Main.player[this.owner].killClothier)) && this.friendly) || (Main.npc[k].friendly && this.hostile)) && (this.owner < 0 || Main.npc[k].immune[this.owner] == 0 || this.maxPenetrate == 1))
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
									if (num11 > 0 && Main.npc[k].lifeMax > 5 && this.friendly && !this.hostile && this.aiStyle != 59)
									{
										if (Main.player[this.owner].ghostHeal)
										{
											this.ghostHeal(num11, new Vector2(Main.npc[k].center().X, Main.npc[k].center().Y));
										}
										if (Main.player[this.owner].ghostHurt)
										{
											this.ghostHurt(num11, new Vector2(Main.npc[k].center().X, Main.npc[k].center().Y));
										}
										if (this.melee && Main.player[this.owner].beetleOffense)
										{
											if (Main.player[this.owner].beetleOrbs == 0)
											{
												Main.player[this.owner].beetleCounter += (float)(num11 * 3);
											}
											else if (Main.player[this.owner].beetleOrbs == 1)
											{
												Main.player[this.owner].beetleCounter += (float)(num11 * 2);
											}
											else
											{
												Main.player[this.owner].beetleCounter += (float)num11;
											}
											Main.player[this.owner].beetleCountdown = 0;
										}
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
										if (this.type == 357)
										{
											this.damage = (int)((double)this.damage * 0.9);
										}
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
								if (num15 > 0 && Main.player[this.owner].ghostHeal && this.friendly && !this.hostile)
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
				if (this.type != 344)
				{
					if (Main.player[this.owner].frostBurn && (this.melee || this.ranged) && this.friendly && !this.hostile && Main.rand.Next(2 * (1 + this.maxUpdates)) == 0)
					{
						int num = Dust.NewDust(this.position, this.width, this.height, 135, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num].noGravity = true;
						Main.dust[num].velocity *= 0.7f;
						Dust expr_102_cp_0 = Main.dust[num];
						expr_102_cp_0.velocity.Y = expr_102_cp_0.velocity.Y - 0.5f;
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
								Dust expr_319_cp_0 = Main.dust[num4];
								expr_319_cp_0.velocity.Y = expr_319_cp_0.velocity.Y - 0.5f;
							}
						}
						else if (Main.player[this.owner].meleeEnchant == 3)
						{
							if (Main.rand.Next(2) == 0)
							{
								int num5 = Dust.NewDust(this.position, this.width, this.height, 6, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
								Main.dust[num5].noGravity = true;
								Main.dust[num5].velocity *= 0.7f;
								Dust expr_3E5_cp_0 = Main.dust[num5];
								expr_3E5_cp_0.velocity.Y = expr_3E5_cp_0.velocity.Y - 0.5f;
							}
						}
						else if (Main.player[this.owner].meleeEnchant == 4)
						{
							if (Main.rand.Next(2) == 0)
							{
								int num6 = Dust.NewDust(this.position, this.width, this.height, 57, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.1f);
								Main.dust[num6].noGravity = true;
								Dust expr_498_cp_0 = Main.dust[num6];
								expr_498_cp_0.velocity.X = expr_498_cp_0.velocity.X / 2f;
								Dust expr_4B6_cp_0 = Main.dust[num6];
								expr_4B6_cp_0.velocity.Y = expr_4B6_cp_0.velocity.Y / 2f;
							}
						}
						else if (Main.player[this.owner].meleeEnchant == 5)
						{
							if (Main.rand.Next(2) == 0)
							{
								int num7 = Dust.NewDust(this.position, this.width, this.height, 169, 0f, 0f, 100, default(Color), 1f);
								Dust expr_539_cp_0 = Main.dust[num7];
								expr_539_cp_0.velocity.X = expr_539_cp_0.velocity.X + (float)this.direction;
								Dust expr_559_cp_0 = Main.dust[num7];
								expr_559_cp_0.velocity.Y = expr_559_cp_0.velocity.Y + 0.2f;
								Main.dust[num7].noGravity = true;
							}
						}
						else if (Main.player[this.owner].meleeEnchant == 6)
						{
							if (Main.rand.Next(2) == 0)
							{
								int num8 = Dust.NewDust(this.position, this.width, this.height, 135, 0f, 0f, 100, default(Color), 1f);
								Dust expr_5EA_cp_0 = Main.dust[num8];
								expr_5EA_cp_0.velocity.X = expr_5EA_cp_0.velocity.X + (float)this.direction;
								Dust expr_60A_cp_0 = Main.dust[num8];
								expr_60A_cp_0.velocity.Y = expr_60A_cp_0.velocity.Y + 0.2f;
								Main.dust[num8].noGravity = true;
							}
						}
						else if (Main.player[this.owner].meleeEnchant == 7)
						{
							if (Main.rand.Next(20) == 0)
							{
								int num9 = Main.rand.Next(139, 143);
								int num10 = Dust.NewDust(this.position, this.width, this.height, num9, this.velocity.X, this.velocity.Y, 0, default(Color), 1.2f);
								Dust expr_6BA_cp_0 = Main.dust[num10];
								expr_6BA_cp_0.velocity.X = expr_6BA_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
								Dust expr_6EE_cp_0 = Main.dust[num10];
								expr_6EE_cp_0.velocity.Y = expr_6EE_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
								Dust expr_722_cp_0 = Main.dust[num10];
								expr_722_cp_0.velocity.X = expr_722_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
								Dust expr_750_cp_0 = Main.dust[num10];
								expr_750_cp_0.velocity.Y = expr_750_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
								Main.dust[num10].scale *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
							}
							if (Main.rand.Next(40) == 0)
							{
								int num11 = Main.rand.Next(276, 283);
								int num12 = Gore.NewGore(this.position, this.velocity, num11, 1f);
								Gore expr_7EE_cp_0 = Main.gore[num12];
								expr_7EE_cp_0.velocity.X = expr_7EE_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
								Gore expr_822_cp_0 = Main.gore[num12];
								expr_822_cp_0.velocity.Y = expr_822_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
								Main.gore[num12].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
								Gore expr_885_cp_0 = Main.gore[num12];
								expr_885_cp_0.velocity.X = expr_885_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
								Gore expr_8B3_cp_0 = Main.gore[num12];
								expr_8B3_cp_0.velocity.Y = expr_8B3_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
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
						Dust expr_A4D_cp_0 = Main.dust[num14];
						expr_A4D_cp_0.velocity.X = expr_A4D_cp_0.velocity.X * 2f;
						Dust expr_A6B_cp_0 = Main.dust[num14];
						expr_A6B_cp_0.velocity.Y = expr_A6B_cp_0.velocity.Y * 2f;
					}
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
										Dust expr_E5D_cp_0 = Main.dust[num16];
										expr_E5D_cp_0.velocity.Y = expr_E5D_cp_0.velocity.Y - 1f;
										Dust expr_E7B_cp_0 = Main.dust[num16];
										expr_E7B_cp_0.velocity.X = expr_E7B_cp_0.velocity.X * 2.5f;
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
										Dust expr_F66_cp_0 = Main.dust[num17];
										expr_F66_cp_0.velocity.Y = expr_F66_cp_0.velocity.Y - 4f;
										Dust expr_F84_cp_0 = Main.dust[num17];
										expr_F84_cp_0.velocity.X = expr_F84_cp_0.velocity.X * 2.5f;
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
									Dust expr_106C_cp_0 = Main.dust[num18];
									expr_106C_cp_0.velocity.Y = expr_106C_cp_0.velocity.Y - 1.5f;
									Dust expr_108A_cp_0 = Main.dust[num18];
									expr_108A_cp_0.velocity.X = expr_108A_cp_0.velocity.X * 2.5f;
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
										Dust expr_11E0_cp_0 = Main.dust[num19];
										expr_11E0_cp_0.velocity.Y = expr_11E0_cp_0.velocity.Y - 1f;
										Dust expr_11FE_cp_0 = Main.dust[num19];
										expr_11FE_cp_0.velocity.X = expr_11FE_cp_0.velocity.X * 2.5f;
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
										Dust expr_12E3_cp_0 = Main.dust[num21];
										expr_12E3_cp_0.velocity.Y = expr_12E3_cp_0.velocity.Y - 4f;
										Dust expr_1301_cp_0 = Main.dust[num21];
										expr_1301_cp_0.velocity.X = expr_1301_cp_0.velocity.X * 2.5f;
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
									Dust expr_13E9_cp_0 = Main.dust[num23];
									expr_13E9_cp_0.velocity.Y = expr_13E9_cp_0.velocity.Y - 1.5f;
									Dust expr_1407_cp_0 = Main.dust[num23];
									expr_1407_cp_0.velocity.X = expr_1407_cp_0.velocity.X * 2.5f;
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
						this.wetCount = (byte)(this.wetCount - 1);
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
						if (this.type == 42 || this.type == 65 || this.type == 68 || this.type == 354 || (this.type == 31 && this.ai[0] == 2f))
						{
							this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag4, flag4, 1);
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
						this.velocity = Collision.TileCollision(vector2, this.velocity, num24, num25, flag4, flag4, 1);
					}
					else if (this.aiStyle == 49)
					{
						int num26 = this.width - 8;
						int num27 = this.height - 8;
						Vector2 vector3 = new Vector2(this.position.X + (float)(this.width / 2) - (float)(num26 / 2), this.position.Y + (float)(this.height / 2) - (float)(num27 / 2));
						this.velocity = Collision.TileCollision(vector3, this.velocity, num26, num27, flag4, flag4, 1);
					}
					else if (this.type == 250 || this.type == 267 || this.type == 297 || this.type == 323)
					{
						int num28 = 2;
						int num29 = 2;
						Vector2 vector4 = new Vector2(this.position.X + (float)(this.width / 2) - (float)(num28 / 2), this.position.Y + (float)(this.height / 2) - (float)(num29 / 2));
						this.velocity = Collision.TileCollision(vector4, this.velocity, num28, num29, flag4, flag4, 1);
					}
					else if (this.type == 308)
					{
						int num30 = 26;
						int num31 = this.height;
						Vector2 vector5 = new Vector2(this.position.X + (float)(this.width / 2) - (float)(num30 / 2), this.position.Y + (float)(this.height / 2) - (float)(num31 / 2));
						this.velocity = Collision.TileCollision(vector5, this.velocity, num30, num31, flag4, flag4, 1);
					}
					else if (this.type == 261 || this.type == 277)
					{
						int num32 = 26;
						int num33 = 26;
						Vector2 vector6 = new Vector2(this.position.X + (float)(this.width / 2) - (float)(num32 / 2), this.position.Y + (float)(this.height / 2) - (float)(num33 / 2));
						this.velocity = Collision.TileCollision(vector6, this.velocity, num32, num33, flag4, flag4, 1);
					}
					else if (this.type == 106 || this.type == 262 || this.type == 271 || this.type == 270 || this.type == 272 || this.type == 273 || this.type == 274 || this.type == 280 || this.type == 288 || this.type == 301 || this.type == 320 || this.type == 333 || this.type == 335 || this.type == 343 || this.type == 344)
					{
						int num34 = 10;
						int num35 = 10;
						Vector2 vector7 = new Vector2(this.position.X + (float)(this.width / 2) - (float)(num34 / 2), this.position.Y + (float)(this.height / 2) - (float)(num35 / 2));
						this.velocity = Collision.TileCollision(vector7, this.velocity, num34, num35, flag4, flag4, 1);
					}
					else if (this.type == 248 || this.type == 247)
					{
						int num36 = this.width - 12;
						int num37 = this.height - 12;
						Vector2 vector8 = new Vector2(this.position.X + (float)(this.width / 2) - (float)(num36 / 2), this.position.Y + (float)(this.height / 2) - (float)(num37 / 2));
						this.velocity = Collision.TileCollision(vector8, this.velocity, num36, num37, flag4, flag4, 1);
					}
					else if (this.aiStyle == 18 || this.type == 254)
					{
						int num38 = this.width - 36;
						int num39 = this.height - 36;
						Vector2 vector9 = new Vector2(this.position.X + (float)(this.width / 2) - (float)(num38 / 2), this.position.Y + (float)(this.height / 2) - (float)(num39 / 2));
						this.velocity = Collision.TileCollision(vector9, this.velocity, num38, num39, flag4, flag4, 1);
					}
					else if (this.type == 182 || this.type == 190 || this.type == 33 || this.type == 229 || this.type == 237 || this.type == 243)
					{
						int num40 = this.width - 20;
						int num41 = this.height - 20;
						Vector2 vector10 = new Vector2(this.position.X + (float)(this.width / 2) - (float)(num40 / 2), this.position.Y + (float)(this.height / 2) - (float)(num41 / 2));
						this.velocity = Collision.TileCollision(vector10, this.velocity, num40, num41, flag4, flag4, 1);
					}
					else if (this.aiStyle == 27)
					{
						int num42 = 6;
						this.velocity = Collision.TileCollision(new Vector2(this.position.X + (float)num42, this.position.Y + (float)num42), this.velocity, this.width - num42 * 2, this.height - num42 * 2, flag4, flag4, 1);
					}
					else if (this.wet)
					{
						if (this.honeyWet)
						{
							Vector2 vector11 = this.velocity;
							this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag4, flag4, 1);
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
							this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag4, flag4, 1);
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
						this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag4, flag4, 1);
						if (!Main.projPet[this.type])
						{
							Vector4 vector13 = Collision.SlopeCollision(this.position, this.velocity, this.width, this.height, 0f, true);
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
								else if ((this.type == 181 || this.type == 189 || this.type == 357) && this.penetrate > 0)
								{
									if (this.type == 357)
									{
										this.damage = (int)((double)this.damage * 0.9);
									}
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
									if (this.wet)
									{
										value = this.velocity;
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
									if (this.type == 352)
									{
										if (this.localAI[1] == 0f)
										{
											this.localAI[1] = 1f;
										}
										this.alpha += (int)(25f * this.localAI[1]);
										if (this.alpha <= 0)
										{
											this.alpha = 0;
											this.localAI[1] = 1f;
										}
										else if (this.alpha >= 255)
										{
											this.alpha = 255;
											this.localAI[1] = -1f;
										}
										this.scale += this.localAI[1] * 0.01f;
									}
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
				if (this.aiStyle != 4 && this.aiStyle != 38 && (this.aiStyle != 7 || this.ai[0] != 2f))
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
						Vector4 vector14 = Collision.SlopeCollision(this.position, this.velocity, this.width, this.height, 0f, false);
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
						Collision.SwitchTiles(this, this.position, this.width, this.height, this.lastPosition, 3);
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
				if (this.type != 350 && this.type != 349 && this.type != 348 && this.type != 5 && this.type != 325 && this.type != 323 && this.type != 14 && this.type != 270 && this.type != 180 && this.type != 259 && this.type != 242 && this.type != 302 && this.type != 20 && this.type != 36 && this.type != 38 && this.type != 55 && this.type != 83 && this.type != 84 && this.type != 88 && this.type != 89 && this.type != 98 && this.type != 100 && this.type != 265 && this.type != 104 && this.type != 110 && this.type != 184 && this.type != 257 && this.type != 248 && (this.type < 283 || this.type > 287) && this.type != 279 && this.type != 299 && this.type != 355 && (this.type < 158 || this.type > 161))
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
						Dust expr_17AF_cp_0 = Main.dust[num18];
						expr_17AF_cp_0.velocity.X = expr_17AF_cp_0.velocity.X * 0.3f;
						Dust expr_17CD_cp_0 = Main.dust[num18];
						expr_17CD_cp_0.velocity.Y = expr_17CD_cp_0.velocity.Y * 0.3f;
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
				if (this.type == 355)
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
						int num20 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 205, this.velocity.X, this.velocity.Y, 100, default(Color), 1.2f);
						Main.dust[num20].noGravity = true;
						Main.dust[num20].velocity *= 0.3f;
						Main.dust[num20].velocity -= this.velocity * 0.4f;
					}
				}
				if (this.type == 357)
				{
					if (this.alpha < 170)
					{
						for (int l = 0; l < 10; l++)
						{
							float x = this.position.X - this.velocity.X / 10f * (float)l;
							float y = this.position.Y - this.velocity.Y / 10f * (float)l;
							int num21 = Dust.NewDust(new Vector2(x, y), 1, 1, 206, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num21].alpha = this.alpha;
							Main.dust[num21].position.X = x;
							Main.dust[num21].position.Y = y;
							Main.dust[num21].velocity *= 0f;
							Main.dust[num21].noGravity = true;
						}
					}
					if (this.alpha > 0)
					{
						this.alpha -= 25;
					}
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
				}
				else if (this.type == 207)
				{
					if (this.alpha < 170)
					{
						for (int m = 0; m < 10; m++)
						{
							float x2 = this.position.X - this.velocity.X / 10f * (float)m;
							float y2 = this.position.Y - this.velocity.Y / 10f * (float)m;
							int num22 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 75, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num22].alpha = this.alpha;
							Main.dust[num22].position.X = x2;
							Main.dust[num22].position.Y = y2;
							Main.dust[num22].velocity *= 0f;
							Main.dust[num22].noGravity = true;
						}
					}
					float num23 = (float)Math.Sqrt((double)(this.velocity.X * this.velocity.X + this.velocity.Y * this.velocity.Y));
					float num24 = this.localAI[0];
					if (num24 == 0f)
					{
						this.localAI[0] = num23;
						num24 = num23;
					}
					if (this.alpha > 0)
					{
						this.alpha -= 25;
					}
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
					float num25 = this.position.X;
					float num26 = this.position.Y;
					float num27 = 300f;
					bool flag = false;
					int num28 = 0;
					if (this.ai[1] == 0f)
					{
						for (int n = 0; n < 200; n++)
						{
							if (Main.npc[n].active && !Main.npc[n].dontTakeDamage && !Main.npc[n].friendly && Main.npc[n].lifeMax > 5 && (this.ai[1] == 0f || this.ai[1] == (float)(n + 1)))
							{
								float num29 = Main.npc[n].position.X + (float)(Main.npc[n].width / 2);
								float num30 = Main.npc[n].position.Y + (float)(Main.npc[n].height / 2);
								float num31 = Math.Abs(this.position.X + (float)(this.width / 2) - num29) + Math.Abs(this.position.Y + (float)(this.height / 2) - num30);
								if (num31 < num27 && Collision.CanHit(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2)), 1, 1, Main.npc[n].position, Main.npc[n].width, Main.npc[n].height))
								{
									num27 = num31;
									num25 = num29;
									num26 = num30;
									flag = true;
									num28 = n;
								}
							}
						}
						if (flag)
						{
							this.ai[1] = (float)(num28 + 1);
						}
						flag = false;
					}
					if (this.ai[1] != 0f)
					{
						int num32 = (int)(this.ai[1] - 1f);
						if (Main.npc[num32].active)
						{
							float num33 = Main.npc[num32].position.X + (float)(Main.npc[num32].width / 2);
							float num34 = Main.npc[num32].position.Y + (float)(Main.npc[num32].height / 2);
							float num35 = Math.Abs(this.position.X + (float)(this.width / 2) - num33) + Math.Abs(this.position.Y + (float)(this.height / 2) - num34);
							if (num35 < 1000f)
							{
								flag = true;
								num25 = Main.npc[num32].position.X + (float)(Main.npc[num32].width / 2);
								num26 = Main.npc[num32].position.Y + (float)(Main.npc[num32].height / 2);
							}
						}
					}
					if (flag)
					{
						float num36 = num24;
						Vector2 vector = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num37 = num25 - vector.X;
						float num38 = num26 - vector.Y;
						float num39 = (float)Math.Sqrt((double)(num37 * num37 + num38 * num38));
						num39 = num36 / num39;
						num37 *= num39;
						num38 *= num39;
						int num40 = 8;
						this.velocity.X = (this.velocity.X * (float)(num40 - 1) + num37) / (float)num40;
						this.velocity.Y = (this.velocity.Y * (float)(num40 - 1) + num38) / (float)num40;
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
						int num41 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 197, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num41].velocity *= 0.5f;
						Main.dust[num41].noGravity = true;
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
						int num42 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 67, this.velocity.X, this.velocity.Y, 100, default(Color), 1.2f);
						Main.dust[num42].noGravity = true;
						Main.dust[num42].velocity *= 0.3f;
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
					int num43 = Dust.NewDust(this.position, this.width, this.height, 57, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 0.3f);
					Dust expr_2AE3_cp_0 = Main.dust[num43];
					expr_2AE3_cp_0.velocity.X = expr_2AE3_cp_0.velocity.X * 0.3f;
					Dust expr_2B01_cp_0 = Main.dust[num43];
					expr_2B01_cp_0.velocity.Y = expr_2B01_cp_0.velocity.Y * 0.3f;
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
							for (int num44 = 0; num44 < 10; num44++)
							{
								int num45 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
								Main.dust[num45].velocity *= 0.5f;
								Main.dust[num45].velocity += this.velocity * 0.1f;
							}
							for (int num46 = 0; num46 < 5; num46++)
							{
								int num47 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
								Main.dust[num47].noGravity = true;
								Main.dust[num47].velocity *= 3f;
								Main.dust[num47].velocity += this.velocity * 0.2f;
								num47 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
								Main.dust[num47].velocity *= 2f;
								Main.dust[num47].velocity += this.velocity * 0.3f;
							}
							for (int num48 = 0; num48 < 1; num48++)
							{
								int num49 = Gore.NewGore(new Vector2(this.position.X - 10f, this.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
								Main.gore[num49].position += this.velocity * 1.25f;
								Main.gore[num49].scale = 1.5f;
								Main.gore[num49].velocity += this.velocity * 0.5f;
								Main.gore[num49].velocity *= 0.02f;
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
							for (int num50 = 0; num50 < 10; num50++)
							{
								int num51 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
								Main.dust[num51].velocity *= 0.5f;
								Main.dust[num51].velocity += this.velocity * 0.1f;
							}
							for (int num52 = 0; num52 < 5; num52++)
							{
								int num53 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
								Main.dust[num53].noGravity = true;
								Main.dust[num53].velocity *= 3f;
								Main.dust[num53].velocity += this.velocity * 0.2f;
								num53 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
								Main.dust[num53].velocity *= 2f;
								Main.dust[num53].velocity += this.velocity * 0.3f;
							}
							for (int num54 = 0; num54 < 1; num54++)
							{
								int num55 = Gore.NewGore(new Vector2(this.position.X - 10f, this.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
								Main.gore[num55].position += this.velocity * 1.25f;
								Main.gore[num55].scale = 1.5f;
								Main.gore[num55].velocity += this.velocity * 0.5f;
								Main.gore[num55].velocity *= 0.02f;
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
							for (int num56 = 0; num56 < 7; num56++)
							{
								int num57 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
								Main.dust[num57].velocity *= 0.5f;
								Main.dust[num57].velocity += this.velocity * 0.1f;
							}
							for (int num58 = 0; num58 < 3; num58++)
							{
								int num59 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
								Main.dust[num59].noGravity = true;
								Main.dust[num59].velocity *= 3f;
								Main.dust[num59].velocity += this.velocity * 0.2f;
								num59 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
								Main.dust[num59].velocity *= 2f;
								Main.dust[num59].velocity += this.velocity * 0.3f;
							}
							for (int num60 = 0; num60 < 1; num60++)
							{
								int num61 = Gore.NewGore(new Vector2(this.position.X - 10f, this.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
								Main.gore[num61].position += this.velocity * 1.25f;
								Main.gore[num61].scale = 1.25f;
								Main.gore[num61].velocity += this.velocity * 0.5f;
								Main.gore[num61].velocity *= 0.02f;
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
						for (int num62 = 0; num62 < 4; num62++)
						{
							float num63 = this.velocity.X / 4f * (float)num62;
							float num64 = this.velocity.Y / 4f * (float)num62;
							int num65 = Dust.NewDust(this.position, this.width, this.height, 184, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num65].position.X = this.center().X - num63;
							Main.dust[num65].position.Y = this.center().Y - num64;
							Main.dust[num65].velocity *= 0f;
							Main.dust[num65].scale = 0.7f;
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
					for (int num66 = 0; num66 < 2; num66++)
					{
						int num67 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num67].noGravity = true;
						Dust expr_3D33_cp_0 = Main.dust[num67];
						expr_3D33_cp_0.velocity.X = expr_3D33_cp_0.velocity.X * 0.3f;
						Dust expr_3D51_cp_0 = Main.dust[num67];
						expr_3D51_cp_0.velocity.Y = expr_3D51_cp_0.velocity.Y * 0.3f;
					}
				}
				else if (this.type == 33)
				{
					if (Main.rand.Next(1) == 0)
					{
						int num68 = Dust.NewDust(this.position, this.width, this.height, 40, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 0, default(Color), 1.4f);
						Main.dust[num68].noGravity = true;
					}
				}
				else if (this.type == 320)
				{
					if (Main.rand.Next(3) == 0)
					{
						int num69 = Dust.NewDust(this.position, this.width, this.height, 5, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 0, default(Color), 1.1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num69].scale = 0.9f;
							Main.dust[num69].velocity *= 0.2f;
						}
						else
						{
							Main.dust[num69].noGravity = true;
						}
					}
				}
				else if (this.type == 6)
				{
					if (Main.rand.Next(5) == 0)
					{
						int num70 = Main.rand.Next(3);
						if (num70 == 0)
						{
							num70 = 15;
						}
						else if (num70 == 1)
						{
							num70 = 57;
						}
						else
						{
							num70 = 58;
						}
						Dust.NewDust(this.position, this.width, this.height, num70, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 150, default(Color), 0.7f);
					}
				}
				else if (this.type == 113 && Main.rand.Next(1) == 0)
				{
					int num71 = Dust.NewDust(this.position, this.width, this.height, 76, this.velocity.X * 0.15f, this.velocity.Y * 0.15f, 0, default(Color), 1.1f);
					Main.dust[num71].noGravity = true;
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
							int num72 = Dust.NewDust(this.position, this.width, this.height, 57, 0f, 0f, 255, default(Color), 0.75f);
							Main.dust[num72].velocity *= 0.1f;
							Main.dust[num72].noGravity = true;
						}
						if (this.velocity.X > 0f)
						{
							this.spriteDirection = 1;
						}
						else if (this.velocity.X < 0f)
						{
							this.spriteDirection = -1;
						}
						float num73 = this.position.X;
						float num74 = this.position.Y;
						bool flag2 = false;
						if (this.ai[1] > 10f)
						{
							for (int num75 = 0; num75 < 200; num75++)
							{
								if (Main.npc[num75].active && !Main.npc[num75].dontTakeDamage && !Main.npc[num75].friendly && Main.npc[num75].lifeMax > 5)
								{
									float num76 = Main.npc[num75].position.X + (float)(Main.npc[num75].width / 2);
									float num77 = Main.npc[num75].position.Y + (float)(Main.npc[num75].height / 2);
									float num78 = Math.Abs(this.position.X + (float)(this.width / 2) - num76) + Math.Abs(this.position.Y + (float)(this.height / 2) - num77);
									if (num78 < 800f && Collision.CanHit(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2)), 1, 1, Main.npc[num75].position, Main.npc[num75].width, Main.npc[num75].height))
									{
										num73 = num76;
										num74 = num77;
										flag2 = true;
									}
								}
							}
						}
						if (!flag2)
						{
							num73 = this.position.X + (float)(this.width / 2) + this.velocity.X * 100f;
							num74 = this.position.Y + (float)(this.height / 2) + this.velocity.Y * 100f;
							if (this.ai[1] >= 30f)
							{
								this.ai[0] = 1f;
								this.ai[1] = 0f;
								this.netUpdate = true;
							}
						}
						float num79 = 12f;
						float num80 = 0.25f;
						Vector2 vector2 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num81 = num73 - vector2.X;
						float num82 = num74 - vector2.Y;
						float num83 = (float)Math.Sqrt((double)(num81 * num81 + num82 * num82));
						num83 = num79 / num83;
						num81 *= num83;
						num82 *= num83;
						if (this.velocity.X < num81)
						{
							this.velocity.X = this.velocity.X + num80;
							if (this.velocity.X < 0f && num81 > 0f)
							{
								this.velocity.X = this.velocity.X + num80 * 2f;
							}
						}
						else if (this.velocity.X > num81)
						{
							this.velocity.X = this.velocity.X - num80;
							if (this.velocity.X > 0f && num81 < 0f)
							{
								this.velocity.X = this.velocity.X - num80 * 2f;
							}
						}
						if (this.velocity.Y < num82)
						{
							this.velocity.Y = this.velocity.Y + num80;
							if (this.velocity.Y < 0f && num82 > 0f)
							{
								this.velocity.Y = this.velocity.Y + num80 * 2f;
							}
						}
						else if (this.velocity.Y > num82)
						{
							this.velocity.Y = this.velocity.Y - num80;
							if (this.velocity.Y > 0f && num82 < 0f)
							{
								this.velocity.Y = this.velocity.Y - num80 * 2f;
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
					float num84 = 9f;
					float num85 = 0.4f;
					if (this.type == 19)
					{
						num84 = 13f;
						num85 = 0.6f;
					}
					else if (this.type == 33)
					{
						num84 = 15f;
						num85 = 0.8f;
					}
					else if (this.type == 182)
					{
						num84 = 16f;
						num85 = 1.2f;
					}
					else if (this.type == 106)
					{
						num84 = 16f;
						num85 = 1.2f;
					}
					else if (this.type == 272)
					{
						num84 = 15f;
						num85 = 1f;
					}
					else if (this.type == 333)
					{
						num84 = 12f;
						num85 = 0.6f;
					}
					else if (this.type == 301)
					{
						num84 = 15f;
						num85 = 3f;
					}
					else if (this.type == 320)
					{
						num84 = 15f;
						num85 = 3f;
					}
					Vector2 vector3 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num86 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector3.X;
					float num87 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector3.Y;
					float num88 = (float)Math.Sqrt((double)(num86 * num86 + num87 * num87));
					if (num88 > 3000f)
					{
						this.Kill();
					}
					num88 = num84 / num88;
					num86 *= num88;
					num87 *= num88;
					if (this.velocity.X < num86)
					{
						this.velocity.X = this.velocity.X + num85;
						if (this.velocity.X < 0f && num86 > 0f)
						{
							this.velocity.X = this.velocity.X + num85;
						}
					}
					else if (this.velocity.X > num86)
					{
						this.velocity.X = this.velocity.X - num85;
						if (this.velocity.X > 0f && num86 < 0f)
						{
							this.velocity.X = this.velocity.X - num85;
						}
					}
					if (this.velocity.Y < num87)
					{
						this.velocity.Y = this.velocity.Y + num85;
						if (this.velocity.Y < 0f && num87 > 0f)
						{
							this.velocity.Y = this.velocity.Y + num85;
						}
					}
					else if (this.velocity.Y > num87)
					{
						this.velocity.Y = this.velocity.Y - num85;
						if (this.velocity.Y > 0f && num87 < 0f)
						{
							this.velocity.Y = this.velocity.Y - num85;
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
							int num89 = this.type;
							if (this.ai[1] >= 6f)
							{
								num89++;
							}
							int num90 = Projectile.NewProjectile(this.position.X + this.velocity.X + (float)(this.width / 2), this.position.Y + this.velocity.Y + (float)(this.height / 2), this.velocity.X, this.velocity.Y, num89, this.damage, this.knockBack, this.owner, 0f, 0f);
							Main.projectile[num90].damage = this.damage;
							Main.projectile[num90].ai[1] = this.ai[1] + 1f;
							NetMessage.SendData(27, -1, -1, "", num90, 0f, 0f, 0f, 0);
							return;
						}
						if ((this.type == 150 || this.type == 151) && Main.myPlayer == this.owner)
						{
							int num91 = this.type;
							if (this.type == 150)
							{
								num91 = 151;
							}
							else if (this.type == 151)
							{
								num91 = 150;
							}
							if (this.ai[1] >= 10f && this.type == 151)
							{
								num91 = 152;
							}
							int num92 = Projectile.NewProjectile(this.position.X + this.velocity.X + (float)(this.width / 2), this.position.Y + this.velocity.Y + (float)(this.height / 2), this.velocity.X, this.velocity.Y, num91, this.damage, this.knockBack, this.owner, 0f, 0f);
							Main.projectile[num92].damage = this.damage;
							Main.projectile[num92].ai[1] = this.ai[1] + 1f;
							NetMessage.SendData(27, -1, -1, "", num92, 0f, 0f, 0f, 0);
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
							for (int num93 = 0; num93 < 8; num93++)
							{
								int num94 = Dust.NewDust(this.position, this.width, this.height, 7, this.velocity.X * 0.025f, this.velocity.Y * 0.025f, 200, default(Color), 1.3f);
								Main.dust[num94].noGravity = true;
								Main.dust[num94].velocity *= 0.5f;
							}
						}
						else
						{
							for (int num95 = 0; num95 < 3; num95++)
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
					for (int num96 = 0; num96 < 30; num96++)
					{
						Dust.NewDust(this.position, this.width, this.height, 10 + this.type, this.velocity.X, this.velocity.Y, 50, default(Color), 1f);
					}
				}
				if (this.type == 10 || this.type == 11)
				{
					int num97 = (int)(this.position.X / 16f) - 1;
					int num98 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num99 = (int)(this.position.Y / 16f) - 1;
					int num100 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num97 < 0)
					{
						num97 = 0;
					}
					if (num98 > Main.maxTilesX)
					{
						num98 = Main.maxTilesX;
					}
					if (num99 < 0)
					{
						num99 = 0;
					}
					if (num100 > Main.maxTilesY)
					{
						num100 = Main.maxTilesY;
					}
					for (int num101 = num97; num101 < num98; num101++)
					{
						for (int num102 = num99; num102 < num100; num102++)
						{
							Vector2 vector4;
							vector4.X = (float)(num101 * 16);
							vector4.Y = (float)(num102 * 16);
							if (this.position.X + (float)this.width > vector4.X && this.position.X < vector4.X + 16f && this.position.Y + (float)this.height > vector4.Y && this.position.Y < vector4.Y + 16f && Main.myPlayer == this.owner && Main.tile[num101, num102].active())
							{
								if (this.type == 10)
								{
									if (Main.tile[num101, num102].type == 23 || Main.tile[num101, num102].type == 199)
									{
										Main.tile[num101, num102].type = 2;
										WorldGen.SquareTileFrame(num101, num102, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num101, num102, 1);
										}
									}
									if (Main.tile[num101, num102].type == 25 || Main.tile[num101, num102].type == 203)
									{
										Main.tile[num101, num102].type = 1;
										WorldGen.SquareTileFrame(num101, num102, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num101, num102, 1);
										}
									}
									if (Main.tile[num101, num102].type == 112 || Main.tile[num101, num102].type == 234)
									{
										Main.tile[num101, num102].type = 53;
										WorldGen.SquareTileFrame(num101, num102, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num101, num102, 1);
										}
									}
									if (Main.tile[num101, num102].type == 163 || Main.tile[num101, num102].type == 200)
									{
										Main.tile[num101, num102].type = 161;
										WorldGen.SquareTileFrame(num101, num102, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num101, num102, 1);
										}
									}
								}
								else if (this.type == 11)
								{
									if (Main.tile[num101, num102].type == 109)
									{
										Main.tile[num101, num102].type = 2;
										WorldGen.SquareTileFrame(num101, num102, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num101, num102, 1);
										}
									}
									if (Main.tile[num101, num102].type == 116)
									{
										Main.tile[num101, num102].type = 53;
										WorldGen.SquareTileFrame(num101, num102, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num101, num102, 1);
										}
									}
									if (Main.tile[num101, num102].type == 117)
									{
										Main.tile[num101, num102].type = 1;
										WorldGen.SquareTileFrame(num101, num102, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num101, num102, 1);
										}
									}
									if (Main.tile[num101, num102].type == 164)
									{
										Main.tile[num101, num102].type = 161;
										WorldGen.SquareTileFrame(num101, num102, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num101, num102, 1);
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
				float num103 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector5.X;
				float num104 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector5.Y;
				float num105 = (float)Math.Sqrt((double)(num103 * num103 + num104 * num104));
				this.rotation = (float)Math.Atan2((double)num104, (double)num103) - 1.57f;
				if (this.type == 256)
				{
					this.rotation = (float)Math.Atan2((double)num104, (double)num103) + 3.92500019f;
				}
				if (this.ai[0] == 0f)
				{
					if ((num105 > 300f && this.type == 13) || (num105 > 400f && this.type == 32) || (num105 > 440f && this.type == 73) || (num105 > 440f && this.type == 74) || (num105 > 250f && this.type == 165) || (num105 > 350f && this.type == 256) || (num105 > 500f && this.type == 315) || (num105 > 550f && this.type == 322) || (num105 > 400f && this.type == 331) || (num105 > 550f && this.type == 332))
					{
						this.ai[0] = 1f;
					}
					else if (this.type >= 230 && this.type <= 235)
					{
						int num106 = 300 + (this.type - 230) * 30;
						if (num105 > (float)num106)
						{
							this.ai[0] = 1f;
						}
					}
					int num107 = (int)(this.position.X / 16f) - 1;
					int num108 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num109 = (int)(this.position.Y / 16f) - 1;
					int num110 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num107 < 0)
					{
						num107 = 0;
					}
					if (num108 > Main.maxTilesX)
					{
						num108 = Main.maxTilesX;
					}
					if (num109 < 0)
					{
						num109 = 0;
					}
					if (num110 > Main.maxTilesY)
					{
						num110 = Main.maxTilesY;
					}
					for (int num111 = num107; num111 < num108; num111++)
					{
						int num112 = num109;
						while (num112 < num110)
						{
							if (Main.tile[num111, num112] == null)
							{
								Main.tile[num111, num112] = new Tile();
							}
							Vector2 vector6;
							vector6.X = (float)(num111 * 16);
							vector6.Y = (float)(num112 * 16);
							if (this.position.X + (float)this.width > vector6.X && this.position.X < vector6.X + 16f && this.position.Y + (float)this.height > vector6.Y && this.position.Y < vector6.Y + 16f && Main.tile[num111, num112].nactive() && Main.tileSolid[(int)Main.tile[num111, num112].type])
							{
								if (Main.player[this.owner].grapCount < 10)
								{
									Main.player[this.owner].grappling[Main.player[this.owner].grapCount] = this.whoAmI;
									Main.player[this.owner].grapCount++;
								}
								if (Main.myPlayer == this.owner)
								{
									int num113 = 0;
									int num114 = -1;
									int num115 = 100000;
									if (this.type == 73 || this.type == 74)
									{
										for (int num116 = 0; num116 < 1000; num116++)
										{
											if (num116 != this.whoAmI && Main.projectile[num116].active && Main.projectile[num116].owner == this.owner && Main.projectile[num116].aiStyle == 7 && Main.projectile[num116].ai[0] == 2f)
											{
												Main.projectile[num116].Kill();
											}
										}
									}
									else
									{
										int num117 = 3;
										if (this.type == 165)
										{
											num117 = 8;
										}
										if (this.type == 256)
										{
											num117 = 2;
										}
										for (int num118 = 0; num118 < 1000; num118++)
										{
											if (Main.projectile[num118].active && Main.projectile[num118].owner == this.owner && Main.projectile[num118].aiStyle == 7)
											{
												if (Main.projectile[num118].timeLeft < num115)
												{
													num114 = num118;
													num115 = Main.projectile[num118].timeLeft;
												}
												num113++;
											}
										}
										if (num113 > num117)
										{
											Main.projectile[num114].Kill();
										}
									}
								}
								WorldGen.KillTile(num111, num112, true, true, false);
								Main.PlaySound(0, num111 * 16, num112 * 16, 1);
								this.velocity.X = 0f;
								this.velocity.Y = 0f;
								this.ai[0] = 2f;
								this.position.X = (float)(num111 * 16 + 8 - this.width / 2);
								this.position.Y = (float)(num112 * 16 + 8 - this.height / 2);
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
								num112++;
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
					float num119 = 11f;
					if (this.type == 32)
					{
						num119 = 15f;
					}
					if (this.type == 73 || this.type == 74)
					{
						num119 = 17f;
					}
					if (this.type == 315)
					{
						num119 = 20f;
					}
					if (this.type == 322)
					{
						num119 = 22f;
					}
					if (this.type >= 230 && this.type <= 235)
					{
						num119 = 11f + (float)(this.type - 230) * 0.75f;
					}
					if (this.type == 332)
					{
						num119 = 17f;
					}
					if (num105 < 24f)
					{
						this.Kill();
					}
					num105 = num119 / num105;
					num103 *= num105;
					num104 *= num105;
					this.velocity.X = num103;
					this.velocity.Y = num104;
					return;
				}
				if (this.ai[0] == 2f)
				{
					int num120 = (int)(this.position.X / 16f) - 1;
					int num121 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num122 = (int)(this.position.Y / 16f) - 1;
					int num123 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num120 < 0)
					{
						num120 = 0;
					}
					if (num121 > Main.maxTilesX)
					{
						num121 = Main.maxTilesX;
					}
					if (num122 < 0)
					{
						num122 = 0;
					}
					if (num123 > Main.maxTilesY)
					{
						num123 = Main.maxTilesY;
					}
					bool flag3 = true;
					for (int num124 = num120; num124 < num121; num124++)
					{
						for (int num125 = num122; num125 < num123; num125++)
						{
							if (Main.tile[num124, num125] == null)
							{
								Main.tile[num124, num125] = new Tile();
							}
							Vector2 vector7;
							vector7.X = (float)(num124 * 16);
							vector7.Y = (float)(num125 * 16);
							if (this.position.X + (float)(this.width / 2) > vector7.X && this.position.X + (float)(this.width / 2) < vector7.X + 16f && this.position.Y + (float)(this.height / 2) > vector7.Y && this.position.Y + (float)(this.height / 2) < vector7.Y + 16f && Main.tile[num124, num125].nactive() && Main.tileSolid[(int)Main.tile[num124, num125].type])
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
					for (int num126 = 0; num126 < 5; num126++)
					{
						float num127 = this.velocity.X / 3f * (float)num126;
						float num128 = this.velocity.Y / 3f * (float)num126;
						int num129 = 4;
						int num130 = Dust.NewDust(new Vector2(this.position.X + (float)num129, this.position.Y + (float)num129), this.width - num129 * 2, this.height - num129 * 2, 172, 0f, 0f, 100, default(Color), 1.2f);
						Main.dust[num130].noGravity = true;
						Main.dust[num130].velocity *= 0.1f;
						Main.dust[num130].velocity += this.velocity * 0.1f;
						Dust expr_62C2_cp_0 = Main.dust[num130];
						expr_62C2_cp_0.position.X = expr_62C2_cp_0.position.X - num127;
						Dust expr_62DD_cp_0 = Main.dust[num130];
						expr_62DD_cp_0.position.Y = expr_62DD_cp_0.position.Y - num128;
					}
					if (Main.rand.Next(5) == 0)
					{
						int num131 = 4;
						int num132 = Dust.NewDust(new Vector2(this.position.X + (float)num131, this.position.Y + (float)num131), this.width - num131 * 2, this.height - num131 * 2, 172, 0f, 0f, 100, default(Color), 0.6f);
						Main.dust[num132].velocity *= 0.25f;
						Main.dust[num132].velocity += this.velocity * 0.5f;
					}
				}
				else if (this.type == 95 || this.type == 96)
				{
					int num133 = Dust.NewDust(new Vector2(this.position.X + this.velocity.X, this.position.Y + this.velocity.Y), this.width, this.height, 75, this.velocity.X, this.velocity.Y, 100, default(Color), 3f * this.scale);
					Main.dust[num133].noGravity = true;
				}
				else if (this.type == 253)
				{
					for (int num134 = 0; num134 < 2; num134++)
					{
						int num135 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 135, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num135].noGravity = true;
						Dust expr_64FB_cp_0 = Main.dust[num135];
						expr_64FB_cp_0.velocity.X = expr_64FB_cp_0.velocity.X * 0.3f;
						Dust expr_6519_cp_0 = Main.dust[num135];
						expr_6519_cp_0.velocity.Y = expr_6519_cp_0.velocity.Y * 0.3f;
					}
				}
				else
				{
					for (int num136 = 0; num136 < 2; num136++)
					{
						int num137 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num137].noGravity = true;
						Dust expr_65C6_cp_0 = Main.dust[num137];
						expr_65C6_cp_0.velocity.X = expr_65C6_cp_0.velocity.X * 0.3f;
						Dust expr_65E4_cp_0 = Main.dust[num137];
						expr_65E4_cp_0.velocity.Y = expr_65E4_cp_0.velocity.Y * 0.3f;
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
					int num138 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 3.5f);
					Main.dust[num138].noGravity = true;
					Main.dust[num138].velocity *= 1.4f;
					num138 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 1.5f);
				}
				else if (this.type == 79)
				{
					if (this.soundDelay == 0 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 2f)
					{
						this.soundDelay = 10;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 9);
					}
					for (int num139 = 0; num139 < 1; num139++)
					{
						int num140 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 66, 0f, 0f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 2.5f);
						Main.dust[num140].velocity *= 0.1f;
						Main.dust[num140].velocity += this.velocity * 0.2f;
						Main.dust[num140].position.X = this.position.X + (float)(this.width / 2) + 4f + (float)Main.rand.Next(-2, 3);
						Main.dust[num140].position.Y = this.position.Y + (float)(this.height / 2) + (float)Main.rand.Next(-2, 3);
						Main.dust[num140].noGravity = true;
					}
				}
				else
				{
					if (this.soundDelay == 0 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 2f)
					{
						this.soundDelay = 10;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 9);
					}
					int num141 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 15, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num141].velocity *= 0.3f;
					Main.dust[num141].position.X = this.position.X + (float)(this.width / 2) + 4f + (float)Main.rand.Next(-4, 5);
					Main.dust[num141].position.Y = this.position.Y + (float)(this.height / 2) + (float)Main.rand.Next(-4, 5);
					Main.dust[num141].noGravity = true;
				}
				if (Main.myPlayer == this.owner && this.ai[0] == 0f)
				{
					if (Main.player[this.owner].channel)
					{
						float num142 = 12f;
						if (this.type == 16)
						{
							num142 = 15f;
						}
						Vector2 vector8 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num143 = (float)Main.mouseX + Main.screenPosition.X - vector8.X;
						float num144 = (float)Main.mouseY + Main.screenPosition.Y - vector8.Y;
						if (Main.player[this.owner].gravDir == -1f)
						{
							num144 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector8.Y;
						}
						float num145 = (float)Math.Sqrt((double)(num143 * num143 + num144 * num144));
						num145 = (float)Math.Sqrt((double)(num143 * num143 + num144 * num144));
						if (num145 > num142)
						{
							num145 = num142 / num145;
							num143 *= num145;
							num144 *= num145;
							int num146 = (int)(num143 * 1000f);
							int num147 = (int)(this.velocity.X * 1000f);
							int num148 = (int)(num144 * 1000f);
							int num149 = (int)(this.velocity.Y * 1000f);
							if (num146 != num147 || num148 != num149)
							{
								this.netUpdate = true;
							}
							this.velocity.X = num143;
							this.velocity.Y = num144;
						}
						else
						{
							int num150 = (int)(num143 * 1000f);
							int num151 = (int)(this.velocity.X * 1000f);
							int num152 = (int)(num144 * 1000f);
							int num153 = (int)(this.velocity.Y * 1000f);
							if (num150 != num151 || num152 != num153)
							{
								this.netUpdate = true;
							}
							this.velocity.X = num143;
							this.velocity.Y = num144;
						}
					}
					else if (this.ai[0] == 0f)
					{
						this.ai[0] = 1f;
						this.netUpdate = true;
						float num154 = 12f;
						Vector2 vector9 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num155 = (float)Main.mouseX + Main.screenPosition.X - vector9.X;
						float num156 = (float)Main.mouseY + Main.screenPosition.Y - vector9.Y;
						float num157 = (float)Math.Sqrt((double)(num155 * num155 + num156 * num156));
						if (num157 == 0f)
						{
							vector9 = new Vector2(Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2), Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2));
							num155 = this.position.X + (float)this.width * 0.5f - vector9.X;
							num156 = this.position.Y + (float)this.height * 0.5f - vector9.Y;
							num157 = (float)Math.Sqrt((double)(num155 * num155 + num156 * num156));
						}
						num157 = num154 / num157;
						num155 *= num157;
						num156 *= num157;
						this.velocity.X = num155;
						this.velocity.Y = num156;
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
						int num158 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 32, 0f, this.velocity.Y / 2f, 0, default(Color), 1f);
						Dust expr_6FC3_cp_0 = Main.dust[num158];
						expr_6FC3_cp_0.velocity.X = expr_6FC3_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 39)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num159 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 38, 0f, this.velocity.Y / 2f, 0, default(Color), 1f);
						Dust expr_705D_cp_0 = Main.dust[num159];
						expr_705D_cp_0.velocity.X = expr_705D_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 40)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num160 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 36, 0f, this.velocity.Y / 2f, 0, default(Color), 1f);
						Main.dust[num160].velocity *= 0.4f;
					}
				}
				else if (this.type == 42 || this.type == 31)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num161 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 32, 0f, 0f, 0, default(Color), 1f);
						Dust expr_718E_cp_0 = Main.dust[num161];
						expr_718E_cp_0.velocity.X = expr_718E_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 56 || this.type == 65)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num162 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 0, default(Color), 1f);
						Dust expr_7226_cp_0 = Main.dust[num162];
						expr_7226_cp_0.velocity.X = expr_7226_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 67 || this.type == 68)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num163 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 51, 0f, 0f, 0, default(Color), 1f);
						Dust expr_72BE_cp_0 = Main.dust[num163];
						expr_72BE_cp_0.velocity.X = expr_72BE_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 71)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num164 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 53, 0f, 0f, 0, default(Color), 1f);
						Dust expr_734C_cp_0 = Main.dust[num164];
						expr_734C_cp_0.velocity.X = expr_734C_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 179)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num165 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 149, 0f, 0f, 0, default(Color), 1f);
						Dust expr_73E0_cp_0 = Main.dust[num165];
						expr_73E0_cp_0.velocity.X = expr_73E0_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 241 || this.type == 354)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num166 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 36, 0f, 0f, 0, default(Color), 1f);
						Dust expr_747B_cp_0 = Main.dust[num166];
						expr_747B_cp_0.velocity.X = expr_747B_cp_0.velocity.X * 0.4f;
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
						float num167 = 12f;
						Vector2 vector10 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num168 = (float)Main.mouseX + Main.screenPosition.X - vector10.X;
						float num169 = (float)Main.mouseY + Main.screenPosition.Y - vector10.Y;
						float num170 = (float)Math.Sqrt((double)(num168 * num168 + num169 * num169));
						num170 = (float)Math.Sqrt((double)(num168 * num168 + num169 * num169));
						if (num170 > num167)
						{
							num170 = num167 / num170;
							num168 *= num170;
							num169 *= num170;
							if (num168 != this.velocity.X || num169 != this.velocity.Y)
							{
								this.netUpdate = true;
							}
							this.velocity.X = num168;
							this.velocity.Y = num169;
						}
						else
						{
							if (num168 != this.velocity.X || num169 != this.velocity.Y)
							{
								this.netUpdate = true;
							}
							this.velocity.X = num168;
							this.velocity.Y = num169;
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
					if (this.type == 42 || this.type == 65 || this.type == 68 || this.type == 354)
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
						int num171 = 56;
						if (this.type == 86)
						{
							num171 = 73;
						}
						else if (this.type == 87)
						{
							num171 = 74;
						}
						int num172 = Dust.NewDust(this.position, this.width, this.height, num171, 0f, 0f, 200, default(Color), 0.8f);
						Main.dust[num172].velocity *= 0.3f;
					}
				}
				else
				{
					this.rotation += 0.02f;
				}
				if (Main.myPlayer == this.owner)
				{
					if (this.type == 72)
					{
						if (Main.player[Main.myPlayer].blueFairy)
						{
							this.timeLeft = 2;
						}
					}
					else if (this.type == 86)
					{
						if (Main.player[Main.myPlayer].redFairy)
						{
							this.timeLeft = 2;
						}
					}
					else if (this.type == 87)
					{
						if (Main.player[Main.myPlayer].greenFairy)
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
				float num173 = 3f;
				if (this.type == 72 || this.type == 86 || this.type == 87)
				{
					num173 = 3.75f;
				}
				Vector2 vector11 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float num174 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector11.X;
				float num175 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector11.Y;
				int num176 = 70;
				if (this.type == 18)
				{
					if (Main.player[this.owner].controlUp)
					{
						num175 = Main.player[this.owner].position.Y - 40f - vector11.Y;
						num174 -= 6f;
						num176 = 4;
					}
					else if (Main.player[this.owner].controlDown)
					{
						num175 = Main.player[this.owner].position.Y + (float)Main.player[this.owner].height + 40f - vector11.Y;
						num174 -= 6f;
						num176 = 4;
					}
				}
				float num177 = (float)Math.Sqrt((double)(num174 * num174 + num175 * num175));
				num177 = (float)Math.Sqrt((double)(num174 * num174 + num175 * num175));
				if (this.type == 72 || this.type == 86 || this.type == 87)
				{
					num176 = 40;
				}
				if (num177 > 800f)
				{
					this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
					this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
					return;
				}
				if (num177 > (float)num176)
				{
					num177 = num173 / num177;
					num174 *= num177;
					num175 *= num177;
					this.velocity.X = num174;
					this.velocity.Y = num175;
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
					for (int num178 = 0; num178 < 3; num178++)
					{
						float num179 = this.velocity.X / 3f * (float)num178;
						float num180 = this.velocity.Y / 3f * (float)num178;
						int num181 = 14;
						int num182 = Dust.NewDust(new Vector2(this.position.X + (float)num181, this.position.Y + (float)num181), this.width - num181 * 2, this.height - num181 * 2, 170, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num182].noGravity = true;
						Main.dust[num182].velocity *= 0.1f;
						Main.dust[num182].velocity += this.velocity * 0.5f;
						Dust expr_7EA8_cp_0 = Main.dust[num182];
						expr_7EA8_cp_0.position.X = expr_7EA8_cp_0.position.X - num179;
						Dust expr_7EC3_cp_0 = Main.dust[num182];
						expr_7EC3_cp_0.position.Y = expr_7EC3_cp_0.position.Y - num180;
					}
					if (Main.rand.Next(8) == 0)
					{
						int num183 = 16;
						int num184 = Dust.NewDust(new Vector2(this.position.X + (float)num183, this.position.Y + (float)num183), this.width - num183 * 2, this.height - num183 * 2, 170, 0f, 0f, 100, default(Color), 0.5f);
						Main.dust[num184].velocity *= 0.25f;
						Main.dust[num184].velocity += this.velocity * 0.5f;
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
						for (int num185 = 0; num185 < 1; num185++)
						{
							for (int num186 = 0; num186 < 3; num186++)
							{
								float num187 = this.velocity.X / 3f * (float)num186;
								float num188 = this.velocity.Y / 3f * (float)num186;
								int num189 = 6;
								int num190 = Dust.NewDust(new Vector2(this.position.X + (float)num189, this.position.Y + (float)num189), this.width - num189 * 2, this.height - num189 * 2, 172, 0f, 0f, 100, default(Color), 1.2f);
								Main.dust[num190].noGravity = true;
								Main.dust[num190].velocity *= 0.3f;
								Main.dust[num190].velocity += this.velocity * 0.5f;
								Dust expr_810E_cp_0 = Main.dust[num190];
								expr_810E_cp_0.position.X = expr_810E_cp_0.position.X - num187;
								Dust expr_8129_cp_0 = Main.dust[num190];
								expr_8129_cp_0.position.Y = expr_8129_cp_0.position.Y - num188;
							}
							if (Main.rand.Next(8) == 0)
							{
								int num191 = 6;
								int num192 = Dust.NewDust(new Vector2(this.position.X + (float)num191, this.position.Y + (float)num191), this.width - num191 * 2, this.height - num191 * 2, 172, 0f, 0f, 100, default(Color), 0.75f);
								Main.dust[num192].velocity *= 0.5f;
								Main.dust[num192].velocity += this.velocity * 0.5f;
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
				float num193 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector12.X;
				float num194 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector12.Y;
				float num195 = (float)Math.Sqrt((double)(num193 * num193 + num194 * num194));
				if (this.ai[0] == 0f)
				{
					if (num195 > 700f)
					{
						this.ai[0] = 1f;
					}
					else if (this.type == 262 && num195 > 500f)
					{
						this.ai[0] = 1f;
					}
					else if (this.type == 271 && num195 > 200f)
					{
						this.ai[0] = 1f;
					}
					else if (this.type == 273 && num195 > 150f)
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
					this.rotation = (float)Math.Atan2((double)num194, (double)num193) - 1.57f;
					float num196 = 20f;
					if (this.type == 262)
					{
						num196 = 30f;
					}
					if (num195 < 50f)
					{
						this.Kill();
					}
					num195 = num196 / num195;
					num193 *= num195;
					num194 *= num195;
					this.velocity.X = num193;
					this.velocity.Y = num194;
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
						for (int num197 = 0; num197 < 5; num197++)
						{
							float num198 = 10f;
							Vector2 vector13 = new Vector2(this.center().X, this.center().Y);
							float num199 = (float)Main.rand.Next(-20, 21);
							float num200 = (float)Main.rand.Next(-20, 0);
							float num201 = (float)Math.Sqrt((double)(num199 * num199 + num200 * num200));
							num201 = num198 / num201;
							num199 *= num201;
							num200 *= num201;
							num199 *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
							num200 *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
							Projectile.NewProjectile(vector13.X, vector13.Y, num199, num200, 347, 40, 0f, Main.myPlayer, 0f, this.ai[1]);
						}
					}
				}
				if (this.type == 196)
				{
					int num202 = Main.rand.Next(1, 3);
					for (int num203 = 0; num203 < num202; num203++)
					{
						int num204 = Dust.NewDust(this.position, this.width, this.height, 31, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num204].alpha += Main.rand.Next(100);
						Main.dust[num204].velocity *= 0.3f;
						Dust expr_88E9_cp_0 = Main.dust[num204];
						expr_88E9_cp_0.velocity.X = expr_88E9_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.025f;
						Dust expr_8917_cp_0 = Main.dust[num204];
						expr_8917_cp_0.velocity.Y = expr_8917_cp_0.velocity.Y - (0.4f + (float)Main.rand.Next(-3, 14) * 0.15f);
						Main.dust[num204].fadeIn = 1.25f + (float)Main.rand.Next(20) * 0.15f;
					}
				}
				if (this.type == 53)
				{
					try
					{
						Vector2 value2 = Collision.TileCollision(this.position, this.velocity, this.width, this.height, false, false, 1);
						int num205 = (int)(this.position.X / 16f) - 1;
						int num206 = (int)((this.position.X + (float)this.width) / 16f) + 2;
						int num207 = (int)(this.position.Y / 16f) - 1;
						int num208 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
						if (num205 < 0)
						{
							num205 = 0;
						}
						if (num206 > Main.maxTilesX)
						{
							num206 = Main.maxTilesX;
						}
						if (num207 < 0)
						{
							num207 = 0;
						}
						if (num208 > Main.maxTilesY)
						{
							num208 = Main.maxTilesY;
						}
						for (int num209 = num205; num209 < num206; num209++)
						{
							for (int num210 = num207; num210 < num208; num210++)
							{
								if (Main.tile[num209, num210] != null && Main.tile[num209, num210].nactive() && (Main.tileSolid[(int)Main.tile[num209, num210].type] || (Main.tileSolidTop[(int)Main.tile[num209, num210].type] && Main.tile[num209, num210].frameY == 0)))
								{
									Vector2 vector14;
									vector14.X = (float)(num209 * 16);
									vector14.Y = (float)(num210 * 16);
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
					int num211 = Dust.NewDust(this.position, this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
					Dust expr_8E77_cp_0 = Main.dust[num211];
					expr_8E77_cp_0.position.X = expr_8E77_cp_0.position.X - 2f;
					Dust expr_8E95_cp_0 = Main.dust[num211];
					expr_8E95_cp_0.position.Y = expr_8E95_cp_0.position.Y + 2f;
					Main.dust[num211].scale += (float)Main.rand.Next(50) * 0.01f;
					Main.dust[num211].noGravity = true;
					Dust expr_8EE8_cp_0 = Main.dust[num211];
					expr_8EE8_cp_0.velocity.Y = expr_8EE8_cp_0.velocity.Y - 2f;
					if (Main.rand.Next(2) == 0)
					{
						int num212 = Dust.NewDust(this.position, this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
						Dust expr_8F4F_cp_0 = Main.dust[num212];
						expr_8F4F_cp_0.position.X = expr_8F4F_cp_0.position.X - 2f;
						Dust expr_8F6D_cp_0 = Main.dust[num212];
						expr_8F6D_cp_0.position.Y = expr_8F6D_cp_0.position.Y + 2f;
						Main.dust[num212].scale += 0.3f + (float)Main.rand.Next(50) * 0.01f;
						Main.dust[num212].noGravity = true;
						Main.dust[num212].velocity *= 0.1f;
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
					int num213 = Dust.NewDust(this.position, this.width, this.height, 172, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 100, default(Color), 1.5f);
					Main.dust[num213].noGravity = true;
					Dust expr_913F_cp_0 = Main.dust[num213];
					expr_913F_cp_0.velocity.X = expr_913F_cp_0.velocity.X / 2f;
					Dust expr_915D_cp_0 = Main.dust[num213];
					expr_915D_cp_0.velocity.Y = expr_915D_cp_0.velocity.Y / 2f;
				}
				else if (this.type == 35)
				{
					int num214 = Dust.NewDust(this.position, this.width, this.height, 6, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 100, default(Color), 3f);
					Main.dust[num214].noGravity = true;
					Dust expr_91EC_cp_0 = Main.dust[num214];
					expr_91EC_cp_0.velocity.X = expr_91EC_cp_0.velocity.X * 2f;
					Dust expr_920A_cp_0 = Main.dust[num214];
					expr_920A_cp_0.velocity.Y = expr_920A_cp_0.velocity.Y * 2f;
				}
				else if (this.type == 154)
				{
					int num215 = Dust.NewDust(this.position, this.width, this.height, 115, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 140, default(Color), 1.5f);
					Main.dust[num215].noGravity = true;
					Main.dust[num215].velocity *= 0.25f;
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
				float num216 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector15.X;
				float num217 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector15.Y;
				float num218 = (float)Math.Sqrt((double)(num216 * num216 + num217 * num217));
				if (this.ai[0] == 0f)
				{
					float num219 = 160f;
					if (this.type == 63)
					{
						num219 *= 1.5f;
					}
					if (this.type == 247)
					{
						num219 *= 1.5f;
					}
					this.tileCollide = true;
					if (num218 > num219)
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
					float num220 = 14f / Main.player[this.owner].meleeSpeed;
					float num221 = 0.9f / Main.player[this.owner].meleeSpeed;
					float num222 = 300f;
					if (this.type == 63)
					{
						num222 *= 1.5f;
						num220 *= 1.5f;
						num221 *= 1.5f;
					}
					if (this.type == 247)
					{
						num222 *= 1.5f;
						num220 = 15.9f;
						num221 *= 2f;
					}
					Math.Abs(num216);
					Math.Abs(num217);
					if (this.ai[1] == 1f)
					{
						this.tileCollide = false;
					}
					if (!Main.player[this.owner].channel || num218 > num222 || !this.tileCollide)
					{
						this.ai[1] = 1f;
						if (this.tileCollide)
						{
							this.netUpdate = true;
						}
						this.tileCollide = false;
						if (num218 < 20f)
						{
							this.Kill();
						}
					}
					if (!this.tileCollide)
					{
						num221 *= 2f;
					}
					int num223 = 60;
					if (this.type == 247)
					{
						num223 = 100;
					}
					if (num218 > (float)num223 || !this.tileCollide)
					{
						num218 = num220 / num218;
						num216 *= num218;
						num217 *= num218;
						new Vector2(this.velocity.X, this.velocity.Y);
						float num224 = num216 - this.velocity.X;
						float num225 = num217 - this.velocity.Y;
						float num226 = (float)Math.Sqrt((double)(num224 * num224 + num225 * num225));
						num226 = num221 / num226;
						num224 *= num226;
						num225 *= num226;
						this.velocity.X = this.velocity.X * 0.98f;
						this.velocity.Y = this.velocity.Y * 0.98f;
						this.velocity.X = this.velocity.X + num224;
						this.velocity.Y = this.velocity.Y + num225;
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
					this.rotation = (float)Math.Atan2((double)num217, (double)num216) - this.velocity.X * 0.1f;
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
				float num227 = this.position.X;
				float num228 = this.position.Y;
				float num229 = 600f;
				bool flag4 = false;
				if (this.owner == Main.myPlayer)
				{
					this.localAI[1] += 1f;
					if (this.localAI[1] > 20f)
					{
						this.localAI[1] = 20f;
						for (int num230 = 0; num230 < 200; num230++)
						{
							if (Main.npc[num230].active && !Main.npc[num230].dontTakeDamage && !Main.npc[num230].friendly && Main.npc[num230].lifeMax > 5)
							{
								float num231 = Main.npc[num230].position.X + (float)(Main.npc[num230].width / 2);
								float num232 = Main.npc[num230].position.Y + (float)(Main.npc[num230].height / 2);
								float num233 = Math.Abs(this.position.X + (float)(this.width / 2) - num231) + Math.Abs(this.position.Y + (float)(this.height / 2) - num232);
								if (num233 < num229 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num230].position, Main.npc[num230].width, Main.npc[num230].height))
								{
									num229 = num233;
									num227 = num231;
									num228 = num232;
									flag4 = true;
								}
							}
						}
					}
				}
				if (flag4)
				{
					this.localAI[1] = 0f;
					float num234 = 14f;
					vector15 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					num216 = num227 - vector15.X;
					num217 = num228 - vector15.Y;
					num218 = (float)Math.Sqrt((double)(num216 * num216 + num217 * num217));
					num218 = num234 / num218;
					num216 *= num218;
					num217 *= num218;
					Projectile.NewProjectile(vector15.X, vector15.Y, num216, num217, 248, (int)((double)this.damage / 1.5), this.knockBack / 2f, Main.myPlayer, 0f, 0f);
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
						int num235 = (int)(this.position.X / 16f) - 1;
						int num236 = (int)((this.position.X + (float)this.width) / 16f) + 2;
						int num237 = (int)(this.position.Y / 16f) - 1;
						int num238 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
						if (num235 < 0)
						{
							num235 = 0;
						}
						if (num236 > Main.maxTilesX)
						{
							num236 = Main.maxTilesX;
						}
						if (num237 < 0)
						{
							num237 = 0;
						}
						if (num238 > Main.maxTilesY)
						{
							num238 = Main.maxTilesY;
						}
						for (int num239 = num235; num239 < num236; num239++)
						{
							for (int num240 = num237; num240 < num238; num240++)
							{
								if (Main.tile[num239, num240] != null && Main.tile[num239, num240].nactive() && (Main.tileSolid[(int)Main.tile[num239, num240].type] || (Main.tileSolidTop[(int)Main.tile[num239, num240].type] && Main.tile[num239, num240].frameY == 0)))
								{
									Vector2 vector16;
									vector16.X = (float)(num239 * 16);
									vector16.Y = (float)(num240 * 16);
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
						for (int num241 = 0; num241 < 2; num241++)
						{
							float num242 = 0f;
							float num243 = 0f;
							if (num241 == 1)
							{
								num242 = this.velocity.X * 0.5f;
								num243 = this.velocity.Y * 0.5f;
							}
							if (this.localAI[1] > 9f)
							{
								if (Main.rand.Next(2) == 0)
								{
									int num244 = Dust.NewDust(new Vector2(this.position.X + 3f + num242, this.position.Y + 3f + num243) - this.velocity * 0.5f, this.width - 8, this.height - 8, 6, 0f, 0f, 100, default(Color), 1f);
									Main.dust[num244].scale *= 1.4f + (float)Main.rand.Next(10) * 0.1f;
									Main.dust[num244].velocity *= 0.2f;
									Main.dust[num244].noGravity = true;
								}
								if (Main.rand.Next(2) == 0)
								{
									int num245 = Dust.NewDust(new Vector2(this.position.X + 3f + num242, this.position.Y + 3f + num243) - this.velocity * 0.5f, this.width - 8, this.height - 8, 31, 0f, 0f, 100, default(Color), 0.5f);
									Main.dust[num245].fadeIn = 0.5f + (float)Main.rand.Next(5) * 0.1f;
									Main.dust[num245].velocity *= 0.05f;
								}
							}
						}
						float num246 = this.position.X;
						float num247 = this.position.Y;
						float num248 = 600f;
						bool flag5 = false;
						this.ai[0] += 1f;
						if (this.ai[0] > 30f)
						{
							this.ai[0] = 30f;
							for (int num249 = 0; num249 < 200; num249++)
							{
								if (Main.npc[num249].active && !Main.npc[num249].dontTakeDamage && !Main.npc[num249].friendly && Main.npc[num249].lifeMax > 5)
								{
									float num250 = Main.npc[num249].position.X + (float)(Main.npc[num249].width / 2);
									float num251 = Main.npc[num249].position.Y + (float)(Main.npc[num249].height / 2);
									float num252 = Math.Abs(this.position.X + (float)(this.width / 2) - num250) + Math.Abs(this.position.Y + (float)(this.height / 2) - num251);
									if (num252 < num248 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num249].position, Main.npc[num249].width, Main.npc[num249].height))
									{
										num248 = num252;
										num246 = num250;
										num247 = num251;
										flag5 = true;
									}
								}
							}
						}
						if (!flag5)
						{
							num246 = this.position.X + (float)(this.width / 2) + this.velocity.X * 100f;
							num247 = this.position.Y + (float)(this.height / 2) + this.velocity.Y * 100f;
						}
						float num253 = 16f;
						Vector2 vector17 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num254 = num246 - vector17.X;
						float num255 = num247 - vector17.Y;
						float num256 = (float)Math.Sqrt((double)(num254 * num254 + num255 * num255));
						num256 = num253 / num256;
						num254 *= num256;
						num255 *= num256;
						this.velocity.X = (this.velocity.X * 11f + num254) / 12f;
						this.velocity.Y = (this.velocity.Y * 11f + num255) / 12f;
					}
					else if (this.type == 134 || this.type == 137 || this.type == 140 || this.type == 143 || this.type == 303)
					{
						if (Math.Abs(this.velocity.X) >= 8f || Math.Abs(this.velocity.Y) >= 8f)
						{
							for (int num257 = 0; num257 < 2; num257++)
							{
								float num258 = 0f;
								float num259 = 0f;
								if (num257 == 1)
								{
									num258 = this.velocity.X * 0.5f;
									num259 = this.velocity.Y * 0.5f;
								}
								int num260 = Dust.NewDust(new Vector2(this.position.X + 3f + num258, this.position.Y + 3f + num259) - this.velocity * 0.5f, this.width - 8, this.height - 8, 6, 0f, 0f, 100, default(Color), 1f);
								Main.dust[num260].scale *= 2f + (float)Main.rand.Next(10) * 0.1f;
								Main.dust[num260].velocity *= 0.2f;
								Main.dust[num260].noGravity = true;
								num260 = Dust.NewDust(new Vector2(this.position.X + 3f + num258, this.position.Y + 3f + num259) - this.velocity * 0.5f, this.width - 8, this.height - 8, 31, 0f, 0f, 100, default(Color), 0.5f);
								Main.dust[num260].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
								Main.dust[num260].velocity *= 0.05f;
							}
						}
						if (Math.Abs(this.velocity.X) < 15f && Math.Abs(this.velocity.Y) < 15f)
						{
							this.velocity *= 1.1f;
						}
					}
					else if (this.type == 133 || this.type == 136 || this.type == 139 || this.type == 142)
					{
						int num261 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num261].scale *= 1f + (float)Main.rand.Next(10) * 0.1f;
						Main.dust[num261].velocity *= 0.2f;
						Main.dust[num261].noGravity = true;
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
							int num262 = Dust.NewDust(new Vector2(this.position.X + 3f, this.position.Y + 3f) - this.velocity * 0.5f, this.width - 8, this.height - 8, 31, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num262].scale *= 1.6f + (float)Main.rand.Next(5) * 0.1f;
							Main.dust[num262].velocity *= 0.05f;
							Main.dust[num262].noGravity = true;
						}
					}
					else if (this.type != 30 && Main.rand.Next(2) == 0)
					{
						int num263 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num263].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
						Main.dust[num263].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
						Main.dust[num263].noGravity = true;
						if (Main.rand.Next(3) == 0)
						{
							num263 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num263].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
							Main.dust[num263].noGravity = true;
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
					int num264 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
					int num265 = (int)((this.position.Y + (float)this.height - 4f) / 16f);
					if (Main.tile[num264, num265] != null && !Main.tile[num264, num265].active())
					{
						int num266 = 0;
						if (this.type >= 201 && this.type <= 205)
						{
							num266 = this.type - 200;
						}
						WorldGen.PlaceTile(num264, num265, 85, false, false, this.owner, num266);
						if (Main.tile[num264, num265].active())
						{
							if (Main.netMode != 0)
							{
								NetMessage.SendData(17, -1, -1, "", 1, (float)num264, (float)num265, 85f, num266);
							}
							int num267 = Sign.ReadSign(num264, num265);
							if (num267 >= 0)
							{
								Sign.TextSign(num267, this.miscText);
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
					for (int num268 = 0; num268 < 2; num268++)
					{
						int num269 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 27, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num269].noGravity = true;
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
								if (Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, new Vector2(this.center().X + this.velocity.X * this.ai[0], this.center().Y + this.velocity.Y * this.ai[0]), this.width, this.height))
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
						Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), this.velocity.X, this.velocity.Y, 131, this.damage / 3, 0f, this.owner, 0f, 0f);
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
					int num270 = Dust.NewDust(this.position, this.width, this.height, 27, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.2f);
					Main.dust[num270].noGravity = true;
					Dust expr_C5C4_cp_0 = Main.dust[num270];
					expr_C5C4_cp_0.velocity.X = expr_C5C4_cp_0.velocity.X / 2f;
					Dust expr_C5E4_cp_0 = Main.dust[num270];
					expr_C5E4_cp_0.velocity.Y = expr_C5E4_cp_0.velocity.Y / 2f;
					num270 = Dust.NewDust(this.position - this.velocity * 2f, this.width, this.height, 27, 0f, 0f, 150, default(Color), 1.4f);
					Dust expr_C658_cp_0 = Main.dust[num270];
					expr_C658_cp_0.velocity.X = expr_C658_cp_0.velocity.X / 5f;
					Dust expr_C678_cp_0 = Main.dust[num270];
					expr_C678_cp_0.velocity.Y = expr_C678_cp_0.velocity.Y / 5f;
					return;
				}
				if (this.type == 105)
				{
					if (Main.rand.Next(3) == 0)
					{
						int num271 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 57, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 200, default(Color), 1.2f);
						Main.dust[num271].velocity += this.velocity * 0.3f;
						Main.dust[num271].velocity *= 0.2f;
					}
					if (Main.rand.Next(4) == 0)
					{
						int num272 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 43, 0f, 0f, 254, default(Color), 0.3f);
						Main.dust[num272].velocity += this.velocity * 0.5f;
						Main.dust[num272].velocity *= 0.5f;
						return;
					}
				}
				else if (this.type == 153)
				{
					int num273 = Dust.NewDust(this.position - this.velocity * 3f, this.width, this.height, 115, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 140, default(Color), 1f);
					Main.dust[num273].noGravity = true;
					Main.dust[num273].fadeIn = 1.25f;
					Main.dust[num273].velocity *= 0.25f;
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
						float num274 = Main.player[this.owner].inventory[Main.player[this.owner].selectedItem].shootSpeed * this.scale;
						Vector2 vector18 = new Vector2(Main.player[this.owner].position.X + (float)Main.player[this.owner].width * 0.5f, Main.player[this.owner].position.Y + (float)Main.player[this.owner].height * 0.5f);
						float num275 = (float)Main.mouseX + Main.screenPosition.X - vector18.X;
						float num276 = (float)Main.mouseY + Main.screenPosition.Y - vector18.Y;
						float num277 = (float)Math.Sqrt((double)(num275 * num275 + num276 * num276));
						num277 = (float)Math.Sqrt((double)(num275 * num275 + num276 * num276));
						num277 = num274 / num277;
						num275 *= num277;
						num276 *= num277;
						if (num275 != this.velocity.X || num276 != this.velocity.Y)
						{
							this.netUpdate = true;
						}
						this.velocity.X = num275;
						this.velocity.Y = num276;
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
					int num278 = Dust.NewDust(this.position + this.velocity * (float)Main.rand.Next(6, 10) * 0.1f, this.width, this.height, 31, 0f, 0f, 80, default(Color), 1.4f);
					Dust expr_CD9A_cp_0 = Main.dust[num278];
					expr_CD9A_cp_0.position.X = expr_CD9A_cp_0.position.X - 4f;
					Main.dust[num278].noGravity = true;
					Main.dust[num278].velocity *= 0.2f;
					Main.dust[num278].velocity.Y = (float)(-(float)Main.rand.Next(7, 13)) * 0.15f;
					return;
				}
			}
			else if (this.aiStyle == 21)
			{
				this.rotation = this.velocity.X * 0.1f;
				this.spriteDirection = -this.direction;
				if (Main.rand.Next(3) == 0)
				{
					int num279 = Dust.NewDust(this.position, this.width, this.height, 27, 0f, 0f, 80, default(Color), 1f);
					Main.dust[num279].noGravity = true;
					Main.dust[num279].velocity *= 0.2f;
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
					int num280 = (int)(this.position.X / 16f) - 1;
					int num281 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num282 = (int)(this.position.Y / 16f) - 1;
					int num283 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num280 < 0)
					{
						num280 = 0;
					}
					if (num281 > Main.maxTilesX)
					{
						num281 = Main.maxTilesX;
					}
					if (num282 < 0)
					{
						num282 = 0;
					}
					if (num283 > Main.maxTilesY)
					{
						num283 = Main.maxTilesY;
					}
					int num284 = (int)this.position.X + 4;
					int num285 = (int)this.position.Y + 4;
					for (int num286 = num280; num286 < num281; num286++)
					{
						for (int num287 = num282; num287 < num283; num287++)
						{
							if (Main.tile[num286, num287] != null && Main.tile[num286, num287].active() && Main.tile[num286, num287].type != 127 && Main.tileSolid[(int)Main.tile[num286, num287].type] && !Main.tileSolidTop[(int)Main.tile[num286, num287].type])
							{
								Vector2 vector19;
								vector19.X = (float)(num286 * 16);
								vector19.Y = (float)(num287 * 16);
								if ((float)(num284 + 8) > vector19.X && (float)num284 < vector19.X + 16f && (float)(num285 + 8) > vector19.Y && (float)num285 < vector19.Y + 16f)
								{
									this.Kill();
								}
							}
						}
					}
					int num288 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num288].noGravity = true;
					Main.dust[num288].velocity *= 0.3f;
					return;
				}
				if (this.ai[0] < 0f)
				{
					if (this.ai[0] == -1f)
					{
						for (int num289 = 0; num289 < 10; num289++)
						{
							int num290 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0f, 0f, 0, default(Color), 1.1f);
							Main.dust[num290].noGravity = true;
							Main.dust[num290].velocity *= 1.3f;
						}
					}
					else if (Main.rand.Next(30) == 0)
					{
						int num291 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num291].velocity *= 0.2f;
					}
					int num292 = (int)this.position.X / 16;
					int num293 = (int)this.position.Y / 16;
					if (Main.tile[num292, num293] == null || !Main.tile[num292, num293].active())
					{
						this.Kill();
					}
					this.ai[0] -= 1f;
					if (this.ai[0] <= -300f && (Main.myPlayer == this.owner || Main.netMode == 2) && Main.tile[num292, num293].active() && Main.tile[num292, num293].type == 127)
					{
						WorldGen.KillTile(num292, num293, false, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(17, -1, -1, "", 0, (float)num292, (float)num293, 0f, 0);
						}
						this.Kill();
						return;
					}
				}
				else
				{
					int num294 = (int)(this.position.X / 16f) - 1;
					int num295 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num296 = (int)(this.position.Y / 16f) - 1;
					int num297 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num294 < 0)
					{
						num294 = 0;
					}
					if (num295 > Main.maxTilesX)
					{
						num295 = Main.maxTilesX;
					}
					if (num296 < 0)
					{
						num296 = 0;
					}
					if (num297 > Main.maxTilesY)
					{
						num297 = Main.maxTilesY;
					}
					int num298 = (int)this.position.X + 4;
					int num299 = (int)this.position.Y + 4;
					for (int num300 = num294; num300 < num295; num300++)
					{
						for (int num301 = num296; num301 < num297; num301++)
						{
							if (Main.tile[num300, num301] != null && Main.tile[num300, num301].nactive() && Main.tile[num300, num301].type != 127 && Main.tileSolid[(int)Main.tile[num300, num301].type] && !Main.tileSolidTop[(int)Main.tile[num300, num301].type])
							{
								Vector2 vector20;
								vector20.X = (float)(num300 * 16);
								vector20.Y = (float)(num301 * 16);
								if ((float)(num298 + 8) > vector20.X && (float)num298 < vector20.X + 16f && (float)(num299 + 8) > vector20.Y && (float)num299 < vector20.Y + 16f)
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
						int num302 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num302].noGravity = true;
						Main.dust[num302].velocity *= 0.3f;
						int num303 = (int)this.ai[0];
						int num304 = (int)this.ai[1];
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
							int num305 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
							int num306 = (int)((this.position.Y + (float)(this.height / 2)) / 16f);
							bool flag6 = false;
							if (num305 == num303 && num306 == num304)
							{
								flag6 = true;
							}
							if (((this.velocity.X <= 0f && num305 <= num303) || (this.velocity.X >= 0f && num305 >= num303)) && ((this.velocity.Y <= 0f && num306 <= num304) || (this.velocity.Y >= 0f && num306 >= num304)))
							{
								flag6 = true;
							}
							if (flag6)
							{
								if (WorldGen.PlaceTile(num303, num304, 127, false, false, this.owner, 0))
								{
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 1, (float)((int)this.ai[0]), (float)((int)this.ai[1]), 127f, 0);
									}
									this.damage = 0;
									this.ai[0] = -1f;
									this.velocity *= 0f;
									this.alpha = 255;
									this.position.X = (float)(num303 * 16);
									this.position.Y = (float)(num304 * 16);
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
						float num307 = 1f;
						if (this.ai[0] == 8f)
						{
							num307 = 0.25f;
						}
						else if (this.ai[0] == 9f)
						{
							num307 = 0.5f;
						}
						else if (this.ai[0] == 10f)
						{
							num307 = 0.75f;
						}
						this.ai[0] += 1f;
						int num308 = 6;
						if (this.type == 101)
						{
							num308 = 75;
						}
						if (num308 == 6 || Main.rand.Next(2) == 0)
						{
							for (int num309 = 0; num309 < 1; num309++)
							{
								int num310 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num308, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 1f);
								if (Main.rand.Next(3) != 0 || (num308 == 75 && Main.rand.Next(3) == 0))
								{
									Main.dust[num310].noGravity = true;
									Main.dust[num310].scale *= 3f;
									Dust expr_DB04_cp_0 = Main.dust[num310];
									expr_DB04_cp_0.velocity.X = expr_DB04_cp_0.velocity.X * 2f;
									Dust expr_DB24_cp_0 = Main.dust[num310];
									expr_DB24_cp_0.velocity.Y = expr_DB24_cp_0.velocity.Y * 2f;
								}
								if (this.type == 188)
								{
									Main.dust[num310].scale *= 1.25f;
								}
								else
								{
									Main.dust[num310].scale *= 1.5f;
								}
								Dust expr_DB89_cp_0 = Main.dust[num310];
								expr_DB89_cp_0.velocity.X = expr_DB89_cp_0.velocity.X * 1.2f;
								Dust expr_DBA9_cp_0 = Main.dust[num310];
								expr_DBA9_cp_0.velocity.Y = expr_DBA9_cp_0.velocity.Y * 1.2f;
								Main.dust[num310].scale *= num307;
								if (num308 == 75)
								{
									Main.dust[num310].velocity += this.velocity;
									if (!Main.dust[num310].noGravity)
									{
										Main.dust[num310].velocity *= 0.5f;
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
							int num311 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 70, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num311].noGravity = true;
							Main.dust[num311].velocity *= 0.5f;
							Main.dust[num311].scale *= 0.9f;
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
							float num312 = 0.5f;
							int i2 = (int)((this.position.X - 8f) / 16f);
							int num313 = (int)(this.position.Y / 16f);
							bool flag7 = false;
							bool flag8 = false;
							if (WorldGen.SolidTile(i2, num313) || WorldGen.SolidTile(i2, num313 + 1))
							{
								flag7 = true;
							}
							i2 = (int)((this.position.X + (float)this.width + 8f) / 16f);
							if (WorldGen.SolidTile(i2, num313) || WorldGen.SolidTile(i2, num313 + 1))
							{
								flag8 = true;
							}
							if (flag7)
							{
								this.velocity.X = num312;
							}
							else if (flag8)
							{
								this.velocity.X = -num312;
							}
							else
							{
								i2 = (int)((this.position.X - 8f - 16f) / 16f);
								num313 = (int)(this.position.Y / 16f);
								flag7 = false;
								flag8 = false;
								if (WorldGen.SolidTile(i2, num313) || WorldGen.SolidTile(i2, num313 + 1))
								{
									flag7 = true;
								}
								i2 = (int)((this.position.X + (float)this.width + 8f + 16f) / 16f);
								if (WorldGen.SolidTile(i2, num313) || WorldGen.SolidTile(i2, num313 + 1))
								{
									flag8 = true;
								}
								if (flag7)
								{
									this.velocity.X = num312;
								}
								else if (flag8)
								{
									this.velocity.X = -num312;
								}
								else
								{
									i2 = (int)((this.position.X + 4f) / 16f);
									num313 = (int)((this.position.Y + (float)this.height + 8f) / 16f);
									if (WorldGen.SolidTile(i2, num313) || WorldGen.SolidTile(i2, num313 + 1))
									{
										flag7 = true;
									}
									if (!flag7)
									{
										this.velocity.X = num312;
									}
									else
									{
										this.velocity.X = -num312;
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
						int num314 = 85;
						if (this.type == 324)
						{
							num314 = 120;
						}
						if (this.type == 112)
						{
							num314 = 100;
						}
						if (this.type == 127)
						{
							num314 = 50;
						}
						if (this.type >= 191 && this.type <= 194)
						{
							if (this.lavaWet)
							{
								this.ai[0] = 1f;
								this.ai[1] = 0f;
							}
							num314 = 60 + 30 * this.minionPos;
						}
						else if (this.type == 266)
						{
							num314 = 60 + 30 * this.minionPos;
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
							num314 = 10;
							int num315 = 40 * (this.minionPos + 1) * Main.player[this.owner].direction;
							if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) < this.position.X + (float)(this.width / 2) - (float)num314 + (float)num315)
							{
								flag9 = true;
							}
							else if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) > this.position.X + (float)(this.width / 2) + (float)num314 + (float)num315)
							{
								flag10 = true;
							}
						}
						else if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) < this.position.X + (float)(this.width / 2) - (float)num314)
						{
							flag9 = true;
						}
						else if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) > this.position.X + (float)(this.width / 2) + (float)num314)
						{
							flag10 = true;
						}
						if (this.type == 175)
						{
							float num316 = 0.1f;
							this.tileCollide = false;
							int num317 = 300;
							Vector2 vector21 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num318 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector21.X;
							float num319 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector21.Y;
							if (this.type == 127)
							{
								num319 = Main.player[this.owner].position.Y - vector21.Y;
							}
							float num320 = (float)Math.Sqrt((double)(num318 * num318 + num319 * num319));
							float num321 = 7f;
							if (num320 < (float)num317 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
							{
								this.ai[0] = 0f;
								if (this.velocity.Y < -6f)
								{
									this.velocity.Y = -6f;
								}
							}
							if (num320 < 150f)
							{
								if (Math.Abs(this.velocity.X) > 2f || Math.Abs(this.velocity.Y) > 2f)
								{
									this.velocity *= 0.99f;
								}
								num316 = 0.01f;
								if (num318 < -2f)
								{
									num318 = -2f;
								}
								if (num318 > 2f)
								{
									num318 = 2f;
								}
								if (num319 < -2f)
								{
									num319 = -2f;
								}
								if (num319 > 2f)
								{
									num319 = 2f;
								}
							}
							else
							{
								if (num320 > 300f)
								{
									num316 = 0.2f;
								}
								num320 = num321 / num320;
								num318 *= num320;
								num319 *= num320;
							}
							if (Math.Abs(num318) > Math.Abs(num319) || num316 == 0.05f)
							{
								if (this.velocity.X < num318)
								{
									this.velocity.X = this.velocity.X + num316;
									if (num316 > 0.05f && this.velocity.X < 0f)
									{
										this.velocity.X = this.velocity.X + num316;
									}
								}
								if (this.velocity.X > num318)
								{
									this.velocity.X = this.velocity.X - num316;
									if (num316 > 0.05f && this.velocity.X > 0f)
									{
										this.velocity.X = this.velocity.X - num316;
									}
								}
							}
							if (Math.Abs(num318) <= Math.Abs(num319) || num316 == 0.05f)
							{
								if (this.velocity.Y < num319)
								{
									this.velocity.Y = this.velocity.Y + num316;
									if (num316 > 0.05f && this.velocity.Y < 0f)
									{
										this.velocity.Y = this.velocity.Y + num316;
									}
								}
								if (this.velocity.Y > num319)
								{
									this.velocity.Y = this.velocity.Y - num316;
									if (num316 > 0.05f && this.velocity.Y > 0f)
									{
										this.velocity.Y = this.velocity.Y - num316;
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
							float num322 = 0.1f;
							this.tileCollide = false;
							int num323 = 300;
							Vector2 vector22 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num324 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector22.X;
							float num325 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector22.Y;
							if (this.type == 127)
							{
								num325 = Main.player[this.owner].position.Y - vector22.Y;
							}
							float num326 = (float)Math.Sqrt((double)(num324 * num324 + num325 * num325));
							float num327 = 3f;
							if (num326 > 500f)
							{
								this.localAI[0] = 10000f;
							}
							if (this.localAI[0] >= 10000f)
							{
								num327 = 14f;
							}
							if (num326 < (float)num323 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
							{
								this.ai[0] = 0f;
								if (this.velocity.Y < -6f)
								{
									this.velocity.Y = -6f;
								}
							}
							if (num326 < 150f)
							{
								if (Math.Abs(this.velocity.X) > 2f || Math.Abs(this.velocity.Y) > 2f)
								{
									this.velocity *= 0.99f;
								}
								num322 = 0.01f;
								if (num324 < -2f)
								{
									num324 = -2f;
								}
								if (num324 > 2f)
								{
									num324 = 2f;
								}
								if (num325 < -2f)
								{
									num325 = -2f;
								}
								if (num325 > 2f)
								{
									num325 = 2f;
								}
							}
							else
							{
								if (num326 > 300f)
								{
									num322 = 0.2f;
								}
								num326 = num327 / num326;
								num324 *= num326;
								num325 *= num326;
							}
							if (this.velocity.X < num324)
							{
								this.velocity.X = this.velocity.X + num322;
								if (num322 > 0.05f && this.velocity.X < 0f)
								{
									this.velocity.X = this.velocity.X + num322;
								}
							}
							if (this.velocity.X > num324)
							{
								this.velocity.X = this.velocity.X - num322;
								if (num322 > 0.05f && this.velocity.X > 0f)
								{
									this.velocity.X = this.velocity.X - num322;
								}
							}
							if (this.velocity.Y < num325)
							{
								this.velocity.Y = this.velocity.Y + num322;
								if (num322 > 0.05f && this.velocity.Y < 0f)
								{
									this.velocity.Y = this.velocity.Y + num322;
								}
							}
							if (this.velocity.Y > num325)
							{
								this.velocity.Y = this.velocity.Y - num322;
								if (num322 > 0.05f && this.velocity.Y > 0f)
								{
									this.velocity.Y = this.velocity.Y - num322;
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
								float num328 = this.velocity.X * 0.1f;
								if (this.rotation > num328)
								{
									this.rotation -= (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.01f;
									if (this.rotation < num328)
									{
										this.rotation = num328;
									}
								}
								if (this.rotation < num328)
								{
									this.rotation += (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.01f;
									if (this.rotation > num328)
									{
										this.rotation = num328;
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
							float num329 = 0.4f;
							this.tileCollide = false;
							int num330 = 100;
							Vector2 vector23 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num331 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector23.X;
							float num332 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector23.Y;
							num332 += (float)Main.rand.Next(-10, 21);
							num331 += (float)Main.rand.Next(-10, 21);
							num331 += (float)(60 * -(float)Main.player[this.owner].direction);
							num332 -= 60f;
							if (this.type == 127)
							{
								num332 = Main.player[this.owner].position.Y - vector23.Y;
							}
							float num333 = (float)Math.Sqrt((double)(num331 * num331 + num332 * num332));
							float num334 = 14f;
							if (num333 < (float)num330 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
							{
								this.ai[0] = 0f;
								if (this.velocity.Y < -6f)
								{
									this.velocity.Y = -6f;
								}
							}
							if (num333 < 50f)
							{
								if (Math.Abs(this.velocity.X) > 2f || Math.Abs(this.velocity.Y) > 2f)
								{
									this.velocity *= 0.99f;
								}
								num329 = 0.01f;
							}
							else
							{
								if (num333 < 100f)
								{
									num329 = 0.1f;
								}
								if (num333 > 300f)
								{
									num329 = 0.6f;
								}
								num333 = num334 / num333;
								num331 *= num333;
								num332 *= num333;
							}
							if (this.velocity.X < num331)
							{
								this.velocity.X = this.velocity.X + num329;
								if (num329 > 0.05f && this.velocity.X < 0f)
								{
									this.velocity.X = this.velocity.X + num329;
								}
							}
							if (this.velocity.X > num331)
							{
								this.velocity.X = this.velocity.X - num329;
								if (num329 > 0.05f && this.velocity.X > 0f)
								{
									this.velocity.X = this.velocity.X - num329;
								}
							}
							if (this.velocity.Y < num332)
							{
								this.velocity.Y = this.velocity.Y + num329;
								if (num329 > 0.05f && this.velocity.Y < 0f)
								{
									this.velocity.Y = this.velocity.Y + num329 * 2f;
								}
							}
							if (this.velocity.Y > num332)
							{
								this.velocity.Y = this.velocity.Y - num329;
								if (num329 > 0.05f && this.velocity.Y > 0f)
								{
									this.velocity.Y = this.velocity.Y - num329 * 2f;
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
							float num335 = 0.2f;
							float num336 = 5f;
							this.tileCollide = false;
							Vector2 vector24 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num337 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector24.X;
							float num338 = Main.player[this.owner].position.Y + Main.player[this.owner].gfxOffY + (float)(Main.player[this.owner].height / 2) - vector24.Y;
							if (Main.player[this.owner].controlLeft)
							{
								num337 -= 120f;
							}
							else if (Main.player[this.owner].controlRight)
							{
								num337 += 120f;
							}
							if (Main.player[this.owner].controlDown)
							{
								num338 += 120f;
							}
							else
							{
								if (Main.player[this.owner].controlUp)
								{
									num338 -= 120f;
								}
								num338 -= 60f;
							}
							float num339 = (float)Math.Sqrt((double)(num337 * num337 + num338 * num338));
							if (num339 > 1000f)
							{
								this.position.X = this.position.X + num337;
								this.position.Y = this.position.Y + num338;
							}
							if (this.localAI[0] == 1f)
							{
								if (num339 < 10f && Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y) < num336 && Main.player[this.owner].velocity.Y == 0f)
								{
									this.localAI[0] = 0f;
								}
								num336 = 12f;
								if (num339 < num336)
								{
									this.velocity.X = num337;
									this.velocity.Y = num338;
								}
								else
								{
									num339 = num336 / num339;
									this.velocity.X = num337 * num339;
									this.velocity.Y = num338 * num339;
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
								for (int num340 = 0; num340 < 2; num340++)
								{
									int num341 = Dust.NewDust(new Vector2(this.position.X + 3f, this.position.Y + 4f), 14, 14, 156, 0f, 0f, 0, default(Color), 1f);
									Main.dust[num341].velocity *= 0.2f;
									Main.dust[num341].noGravity = true;
									Main.dust[num341].scale = 1.25f;
								}
								return;
							}
							if (num339 > 200f)
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
							if (num339 < 10f)
							{
								this.velocity.X = num337;
								this.velocity.Y = num338;
								this.rotation = this.velocity.X * 0.05f;
								if (num339 < num336)
								{
									this.position += this.velocity;
									this.velocity *= 0f;
									num335 = 0f;
								}
								this.direction = -Main.player[this.owner].direction;
							}
							num339 = num336 / num339;
							num337 *= num339;
							num338 *= num339;
							if (this.velocity.X < num337)
							{
								this.velocity.X = this.velocity.X + num335;
								if (this.velocity.X < 0f)
								{
									this.velocity.X = this.velocity.X * 0.99f;
								}
							}
							if (this.velocity.X > num337)
							{
								this.velocity.X = this.velocity.X - num335;
								if (this.velocity.X > 0f)
								{
									this.velocity.X = this.velocity.X * 0.99f;
								}
							}
							if (this.velocity.Y < num338)
							{
								this.velocity.Y = this.velocity.Y + num335;
								if (this.velocity.Y < 0f)
								{
									this.velocity.Y = this.velocity.Y * 0.99f;
								}
							}
							if (this.velocity.Y > num338)
							{
								this.velocity.Y = this.velocity.Y - num335;
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
							float num342 = 0.1f;
							this.tileCollide = false;
							int num343 = 200;
							Vector2 vector25 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num344 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector25.X;
							float num345 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector25.Y;
							num345 -= 60f;
							num344 -= 2f;
							if (this.type == 127)
							{
								num345 = Main.player[this.owner].position.Y - vector25.Y;
							}
							float num346 = (float)Math.Sqrt((double)(num344 * num344 + num345 * num345));
							float num347 = 4f;
							float num348 = num346;
							if (num346 < (float)num343 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
							{
								this.ai[0] = 0f;
								if (this.velocity.Y < -6f)
								{
									this.velocity.Y = -6f;
								}
							}
							if (num346 < 4f)
							{
								this.velocity.X = num344;
								this.velocity.Y = num345;
								num342 = 0f;
							}
							else
							{
								if (num346 > 350f)
								{
									num342 = 0.2f;
									num347 = 10f;
								}
								num346 = num347 / num346;
								num344 *= num346;
								num345 *= num346;
							}
							if (this.velocity.X < num344)
							{
								this.velocity.X = this.velocity.X + num342;
								if (this.velocity.X < 0f)
								{
									this.velocity.X = this.velocity.X + num342;
								}
							}
							if (this.velocity.X > num344)
							{
								this.velocity.X = this.velocity.X - num342;
								if (this.velocity.X > 0f)
								{
									this.velocity.X = this.velocity.X - num342;
								}
							}
							if (this.velocity.Y < num345)
							{
								this.velocity.Y = this.velocity.Y + num342;
								if (this.velocity.Y < 0f)
								{
									this.velocity.Y = this.velocity.Y + num342;
								}
							}
							if (this.velocity.Y > num345)
							{
								this.velocity.Y = this.velocity.Y - num342;
								if (this.velocity.Y > 0f)
								{
									this.velocity.Y = this.velocity.Y - num342;
								}
							}
							this.direction = -Main.player[this.owner].direction;
							this.spriteDirection = 1;
							this.rotation = this.velocity.Y * 0.05f * (float)(-(float)this.direction);
							if (num348 >= 50f)
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
								int num349 = 500;
								if (this.type == 127)
								{
									num349 = 200;
								}
								if (this.type == 208)
								{
									num349 = 300;
								}
								if ((this.type >= 191 && this.type <= 194) || this.type == 266)
								{
									num349 += 40 * this.minionPos;
									if (this.localAI[0] > 0f)
									{
										num349 += 500;
									}
									if (this.type == 266 && this.localAI[0] > 0f)
									{
										num349 += 100;
									}
								}
								if (Main.player[this.owner].rocketDelay2 > 0)
								{
									this.ai[0] = 1f;
								}
								Vector2 vector26 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
								float num350 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector26.X;
								if (this.type >= 191)
								{
									int arg_1088C_0 = this.type;
								}
								float num351 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector26.Y;
								float num352 = (float)Math.Sqrt((double)(num350 * num350 + num351 * num351));
								if (num352 > 2000f)
								{
									this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
									this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
								}
								else if (num352 > (float)num349 || (Math.Abs(num351) > 300f && (((this.type < 191 || this.type > 194) && this.type != 266) || this.localAI[0] <= 0f)))
								{
									if (this.type != 324)
									{
										if (num351 > 0f && this.velocity.Y < 0f)
										{
											this.velocity.Y = 0f;
										}
										if (num351 < 0f && this.velocity.Y > 0f)
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
								float num353 = 0.2f;
								int num354 = 200;
								if (this.type == 127)
								{
									num354 = 100;
								}
								if (this.type >= 191 && this.type <= 194)
								{
									num353 = 0.5f;
									num354 = 100;
								}
								this.tileCollide = false;
								Vector2 vector27 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
								float num355 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector27.X;
								if ((this.type >= 191 && this.type <= 194) || this.type == 266)
								{
									num355 -= (float)(40 * Main.player[this.owner].direction);
									float num356 = 600f;
									bool flag13 = false;
									for (int num357 = 0; num357 < 200; num357++)
									{
										if (Main.npc[num357].active && !Main.npc[num357].dontTakeDamage && !Main.npc[num357].friendly && Main.npc[num357].lifeMax > 5)
										{
											float num358 = Main.npc[num357].position.X + (float)(Main.npc[num357].width / 2);
											float num359 = Main.npc[num357].position.Y + (float)(Main.npc[num357].height / 2);
											float num360 = Math.Abs(Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - num358) + Math.Abs(Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - num359);
											if (num360 < num356)
											{
												flag13 = true;
												break;
											}
										}
									}
									if (!flag13)
									{
										num355 -= (float)(40 * this.minionPos * Main.player[this.owner].direction);
									}
								}
								float num361 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector27.Y;
								if (this.type == 127)
								{
									num361 = Main.player[this.owner].position.Y - vector27.Y;
								}
								float num362 = (float)Math.Sqrt((double)(num355 * num355 + num361 * num361));
								float num363 = 10f;
								float num364 = num362;
								if (this.type == 111)
								{
									num363 = 11f;
								}
								if (this.type == 127)
								{
									num363 = 9f;
								}
								if (this.type == 324)
								{
									num363 = 20f;
								}
								if (this.type >= 191 && this.type <= 194)
								{
									num353 = 0.4f;
									num363 = 12f;
									if (num363 < Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y))
									{
										num363 = Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y);
									}
								}
								if (this.type == 208 && Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y) > 4f)
								{
									num354 = -1;
								}
								if (num362 < (float)num354 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
								{
									this.ai[0] = 0f;
									if (this.velocity.Y < -6f)
									{
										this.velocity.Y = -6f;
									}
								}
								if (num362 < 60f)
								{
									num355 = this.velocity.X;
									num361 = this.velocity.Y;
								}
								else
								{
									num362 = num363 / num362;
									num355 *= num362;
									num361 *= num362;
								}
								if (this.type == 324)
								{
									if (num364 > 1000f)
									{
										if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) < (double)num363 - 1.25)
										{
											this.velocity *= 1.025f;
										}
										if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) > (double)num363 + 1.25)
										{
											this.velocity *= 0.975f;
										}
									}
									else if (num364 > 600f)
									{
										if (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) < num363 - 1f)
										{
											this.velocity *= 1.05f;
										}
										if (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > num363 + 1f)
										{
											this.velocity *= 0.95f;
										}
									}
									else if (num364 > 400f)
									{
										if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) < (double)num363 - 0.5)
										{
											this.velocity *= 1.075f;
										}
										if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) > (double)num363 + 0.5)
										{
											this.velocity *= 0.925f;
										}
									}
									else
									{
										if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) < (double)num363 - 0.25)
										{
											this.velocity *= 1.1f;
										}
										if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) > (double)num363 + 0.25)
										{
											this.velocity *= 0.9f;
										}
									}
									this.velocity.X = (this.velocity.X * 34f + num355) / 35f;
									this.velocity.Y = (this.velocity.Y * 34f + num361) / 35f;
								}
								else
								{
									if (this.velocity.X < num355)
									{
										this.velocity.X = this.velocity.X + num353;
										if (this.velocity.X < 0f)
										{
											this.velocity.X = this.velocity.X + num353 * 1.5f;
										}
									}
									if (this.velocity.X > num355)
									{
										this.velocity.X = this.velocity.X - num353;
										if (this.velocity.X > 0f)
										{
											this.velocity.X = this.velocity.X - num353 * 1.5f;
										}
									}
									if (this.velocity.Y < num361)
									{
										this.velocity.Y = this.velocity.Y + num353;
										if (this.velocity.Y < 0f)
										{
											this.velocity.Y = this.velocity.Y + num353 * 1.5f;
										}
									}
									if (this.velocity.Y > num361)
									{
										this.velocity.Y = this.velocity.Y - num353;
										if (this.velocity.Y > 0f)
										{
											this.velocity.Y = this.velocity.Y - num353 * 1.5f;
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
									for (int num365 = 0; num365 < 2; num365++)
									{
										int num366 = 4;
										int num367 = Dust.NewDust(new Vector2(this.center().X - (float)num366, this.center().Y - (float)num366) - this.velocity * 0f, num366 * 2, num366 * 2, 6, 0f, 0f, 100, default(Color), 1f);
										Main.dust[num367].scale *= 1.8f + (float)Main.rand.Next(10) * 0.1f;
										Main.dust[num367].velocity *= 0.2f;
										if (num365 == 1)
										{
											Main.dust[num367].position -= this.velocity * 0.5f;
										}
										Main.dust[num367].noGravity = true;
										num367 = Dust.NewDust(new Vector2(this.center().X - (float)num366, this.center().Y - (float)num366) - this.velocity * 0f, num366 * 2, num366 * 2, 31, 0f, 0f, 100, default(Color), 0.5f);
										Main.dust[num367].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
										Main.dust[num367].velocity *= 0.05f;
										if (num365 == 1)
										{
											Main.dust[num367].position -= this.velocity * 0.5f;
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
									int num368 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) - 4f, this.position.Y + (float)(this.height / 2) - 4f) - this.velocity, 8, 8, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.7f);
									Main.dust[num368].velocity.X = Main.dust[num368].velocity.X * 0.2f;
									Main.dust[num368].velocity.Y = Main.dust[num368].velocity.Y * 0.2f;
									Main.dust[num368].noGravity = true;
									return;
								}
							}
							else
							{
								if (this.type >= 191 && this.type <= 194)
								{
									float num369 = (float)(40 * this.minionPos);
									int num370 = 30;
									int num371 = 60;
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
										float num372 = this.position.X;
										float num373 = this.position.Y;
										float num374 = 100000f;
										float num375 = num374;
										int num376 = -1;
										for (int num377 = 0; num377 < 200; num377++)
										{
											if (Main.npc[num377].active && !Main.npc[num377].dontTakeDamage && !Main.npc[num377].friendly && Main.npc[num377].lifeMax > 5)
											{
												float num378 = Main.npc[num377].position.X + (float)(Main.npc[num377].width / 2);
												float num379 = Main.npc[num377].position.Y + (float)(Main.npc[num377].height / 2);
												float num380 = Math.Abs(this.position.X + (float)(this.width / 2) - num378) + Math.Abs(this.position.Y + (float)(this.height / 2) - num379);
												if (num380 < num374)
												{
													if (num376 == -1 && num380 <= num375)
													{
														num375 = num380;
														num372 = num378;
														num373 = num379;
													}
													if (Collision.CanHit(this.position, this.width, this.height, Main.npc[num377].position, Main.npc[num377].width, Main.npc[num377].height))
													{
														num374 = num380;
														num372 = num378;
														num373 = num379;
														num376 = num377;
													}
												}
											}
										}
										if (num376 == -1 && num375 < num374)
										{
											num374 = num375;
										}
										float num381 = 400f;
										if ((double)this.position.Y > Main.worldSurface * 16.0)
										{
											num381 = 200f;
										}
										if (num374 < num381 + num369 && num376 == -1)
										{
											float num382 = num372 - (this.position.X + (float)(this.width / 2));
											if (num382 < -5f)
											{
												flag9 = true;
												flag10 = false;
											}
											else if (num382 > 5f)
											{
												flag10 = true;
												flag9 = false;
											}
										}
										else if (num376 >= 0 && num374 < 800f + num369)
										{
											this.localAI[0] = (float)num371;
											float num383 = num372 - (this.position.X + (float)(this.width / 2));
											if (num383 > 300f || num383 < -300f)
											{
												if (num383 < -50f)
												{
													flag9 = true;
													flag10 = false;
												}
												else if (num383 > 50f)
												{
													flag10 = true;
													flag9 = false;
												}
											}
											else if (this.owner == Main.myPlayer)
											{
												this.ai[1] = (float)num370;
												float num384 = 12f;
												Vector2 vector28 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)(this.height / 2) - 8f);
												float num385 = num372 - vector28.X + (float)Main.rand.Next(-20, 21);
												float num386 = Math.Abs(num385) * 0.1f;
												num386 = num386 * (float)Main.rand.Next(0, 100) * 0.001f;
												float num387 = num373 - vector28.Y + (float)Main.rand.Next(-20, 21) - num386;
												float num388 = (float)Math.Sqrt((double)(num385 * num385 + num387 * num387));
												num388 = num384 / num388;
												num385 *= num388;
												num387 *= num388;
												int num389 = this.damage;
												int num390 = 195;
												int num391 = Projectile.NewProjectile(vector28.X, vector28.Y, num385, num387, num390, num389, this.knockBack, Main.myPlayer, 0f, 0f);
												Main.projectile[num391].timeLeft = 300;
												if (num385 < 0f)
												{
													this.direction = -1;
												}
												if (num385 > 0f)
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
									float num392 = (float)(40 * this.minionPos);
									int num393 = 60;
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
										float num394 = this.position.X;
										float num395 = this.position.Y;
										float num396 = 100000f;
										float num397 = num396;
										int num398 = -1;
										for (int num399 = 0; num399 < 200; num399++)
										{
											if (Main.npc[num399].active && !Main.npc[num399].dontTakeDamage && !Main.npc[num399].friendly && Main.npc[num399].lifeMax > 5)
											{
												float num400 = Main.npc[num399].position.X + (float)(Main.npc[num399].width / 2);
												float num401 = Main.npc[num399].position.Y + (float)(Main.npc[num399].height / 2);
												float num402 = Math.Abs(this.position.X + (float)(this.width / 2) - num400) + Math.Abs(this.position.Y + (float)(this.height / 2) - num401);
												if (num402 < num396)
												{
													if (num398 == -1 && num402 <= num397)
													{
														num397 = num402;
														num394 = num400;
														num395 = num401;
													}
													if (Collision.CanHit(this.position, this.width, this.height, Main.npc[num399].position, Main.npc[num399].width, Main.npc[num399].height))
													{
														num396 = num402;
														num394 = num400;
														num395 = num401;
														num398 = num399;
													}
												}
											}
										}
										if (num398 == -1 && num397 < num396)
										{
											num396 = num397;
										}
										float num403 = 300f;
										if ((double)this.position.Y > Main.worldSurface * 16.0)
										{
											num403 = 150f;
										}
										if (num396 < num403 + num392 && num398 == -1)
										{
											float num404 = num394 - (this.position.X + (float)(this.width / 2));
											if (num404 < -5f)
											{
												flag9 = true;
												flag10 = false;
											}
											else if (num404 > 5f)
											{
												flag10 = true;
												flag9 = false;
											}
										}
										if (num398 >= 0 && num396 < 800f + num392)
										{
											this.friendly = true;
											this.localAI[0] = (float)num393;
											float num405 = num394 - (this.position.X + (float)(this.width / 2));
											if (num405 < -10f)
											{
												flag9 = true;
												flag10 = false;
											}
											else if (num405 > 10f)
											{
												flag10 = true;
												flag9 = false;
											}
											if (num395 < this.center().Y - 100f && num405 > -50f && num405 < 50f && this.velocity.Y == 0f)
											{
												float num406 = Math.Abs(num395 - this.center().Y);
												if (num406 < 120f)
												{
													this.velocity.Y = -10f;
												}
												else if (num406 < 210f)
												{
													this.velocity.Y = -13f;
												}
												else if (num406 < 270f)
												{
													this.velocity.Y = -15f;
												}
												else if (num406 < 310f)
												{
													this.velocity.Y = -17f;
												}
												else if (num406 < 380f)
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
								float num407 = 0.08f;
								float num408 = 6.5f;
								if (this.type == 127)
								{
									num408 = 2f;
									num407 = 0.04f;
								}
								if (this.type == 112)
								{
									num408 = 6f;
									num407 = 0.06f;
								}
								if (this.type == 334)
								{
									num408 = 8f;
									num407 = 0.08f;
								}
								if (this.type == 268)
								{
									num408 = 8f;
									num407 = 0.4f;
								}
								if (this.type == 324)
								{
									num407 = 0.1f;
									num408 = 3f;
								}
								if ((this.type >= 191 && this.type <= 194) || this.type == 266)
								{
									num408 = 6f;
									num407 = 0.2f;
									if (num408 < Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y))
									{
										num408 = Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y);
										num407 = 0.3f;
									}
								}
								if (flag9)
								{
									if ((double)this.velocity.X > -3.5)
									{
										this.velocity.X = this.velocity.X - num407;
									}
									else
									{
										this.velocity.X = this.velocity.X - num407 * 0.25f;
									}
								}
								else if (flag10)
								{
									if ((double)this.velocity.X < 3.5)
									{
										this.velocity.X = this.velocity.X + num407;
									}
									else
									{
										this.velocity.X = this.velocity.X + num407 * 0.25f;
									}
								}
								else
								{
									this.velocity.X = this.velocity.X * 0.9f;
									if (this.velocity.X >= -num407 && this.velocity.X <= num407)
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
									int num409 = (int)(this.position.X + (float)(this.width / 2)) / 16;
									int j2 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
									if (this.type == 236)
									{
										num409 += this.direction;
									}
									if (flag9)
									{
										num409--;
									}
									if (flag10)
									{
										num409++;
									}
									num409 += (int)this.velocity.X;
									if (WorldGen.SolidTile(num409, j2))
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
									int num410 = 0;
									if (this.velocity.X < 0f)
									{
										num410 = -1;
									}
									if (this.velocity.X > 0f)
									{
										num410 = 1;
									}
									Vector2 vector29 = this.position;
									vector29.X += this.velocity.X;
									int num411 = (int)((vector29.X + (float)(this.width / 2) + (float)((this.width / 2 + 1) * num410)) / 16f);
									int num412 = (int)((vector29.Y + (float)this.height - 1f) / 16f);
									bool flag14 = false;
									if (Main.tile[num411, num412] == null)
									{
										Main.tile[num411, num412] = new Tile();
									}
									if (num412 - 1 > 0 && Main.tile[num411, num412 - 1] == null)
									{
										Main.tile[num411, num412 - 1] = new Tile();
									}
									if (num412 - 2 > 0 && Main.tile[num411, num412 - 2] == null)
									{
										Main.tile[num411, num412 - 2] = new Tile();
									}
									if (num412 - 3 > 0 && Main.tile[num411, num412 - 3] == null)
									{
										Main.tile[num411, num412 - 3] = new Tile();
									}
									if (num412 - 4 > 0 && Main.tile[num411, num412 - 4] == null)
									{
										Main.tile[num411, num412 - 4] = new Tile();
									}
									if (num412 - 3 > 0 && Main.tile[num411 - num410, num412 - 3] == null)
									{
										Main.tile[num411 - num410, num412 - 3] = new Tile();
									}
									if ((float)(num411 * 16) < vector29.X + (float)this.width && (float)(num411 * 16 + 16) > vector29.X && ((Main.tile[num411, num412].nactive() && (Main.tile[num411, num412].slope() == 0 || (Main.tile[num411, num412].slope() == 1 && this.position.X + (float)(this.width / 2) < (float)(num411 * 16)) || (Main.tile[num411, num412].slope() == 2 && this.position.X + (float)(this.width / 2) > (float)(num411 * 16 + 16))) && (Main.tile[num411, num412 - 1].slope() == 0 || this.position.Y + (float)this.height > (float)(num412 * 16)) && ((Main.tileSolid[(int)Main.tile[num411, num412].type] && !Main.tileSolidTop[(int)Main.tile[num411, num412].type]) || (flag14 && Main.tileSolidTop[(int)Main.tile[num411, num412].type] && Main.tile[num411, num412].frameY == 0 && (!Main.tileSolid[(int)Main.tile[num411, num412 - 1].type] || !Main.tile[num411, num412 - 1].nactive())))) || (Main.tile[num411, num412 - 1].halfBrick() && Main.tile[num411, num412 - 1].nactive())) && (!Main.tile[num411, num412 - 1].nactive() || !Main.tileSolid[(int)Main.tile[num411, num412 - 1].type] || Main.tileSolidTop[(int)Main.tile[num411, num412 - 1].type] || Main.tile[num411, num412 - 1].slope() != 0 || (Main.tile[num411, num412 - 1].halfBrick() && (!Main.tile[num411, num412 - 4].nactive() || !Main.tileSolid[(int)Main.tile[num411, num412 - 4].type] || Main.tileSolidTop[(int)Main.tile[num411, num412 - 4].type]))) && (!Main.tile[num411, num412 - 2].nactive() || !Main.tileSolid[(int)Main.tile[num411, num412 - 2].type] || Main.tileSolidTop[(int)Main.tile[num411, num412 - 2].type]) && (!Main.tile[num411, num412 - 3].nactive() || !Main.tileSolid[(int)Main.tile[num411, num412 - 3].type] || Main.tileSolidTop[(int)Main.tile[num411, num412 - 3].type]) && (!Main.tile[num411 - num410, num412 - 3].nactive() || !Main.tileSolid[(int)Main.tile[num411 - num410, num412 - 3].type] || Main.tileSolidTop[(int)Main.tile[num411 - num410, num412 - 3].type]))
									{
										float num413 = (float)(num412 * 16);
										if (Main.tile[num411, num412].halfBrick())
										{
											num413 += 8f;
										}
										if (Main.tile[num411, num412 - 1].halfBrick())
										{
											num413 -= 8f;
										}
										if (num413 < vector29.Y + (float)this.height)
										{
											float num414 = vector29.Y + (float)this.height - num413;
											if ((double)num414 <= 16.1)
											{
												this.gfxOffY += this.position.Y + (float)this.height - num413;
												this.position.Y = num413 - (float)this.height;
												if (num414 < 9f)
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
										int num415 = (int)(this.position.X + (float)(this.width / 2)) / 16;
										int j3 = (int)(this.position.Y + (float)(this.height / 2)) / 16 + 1;
										if (flag9)
										{
											num415--;
										}
										if (flag10)
										{
											num415++;
										}
										WorldGen.SolidTile(num415, j3);
									}
									if (flag12)
									{
										int num416 = (int)(this.position.X + (float)(this.width / 2)) / 16;
										int num417 = (int)(this.position.Y + (float)this.height) / 16 + 1;
										if (WorldGen.SolidTile(num416, num417) || Main.tile[num416, num417].halfBrick() || Main.tile[num416, num417].slope() > 0 || this.type == 200)
										{
											if (this.type == 200)
											{
												this.velocity.Y = -3.1f;
											}
											else
											{
												try
												{
													num416 = (int)(this.position.X + (float)(this.width / 2)) / 16;
													num417 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
													if (flag9)
													{
														num416--;
													}
													if (flag10)
													{
														num416++;
													}
													num416 += (int)this.velocity.X;
													if (!WorldGen.SolidTile(num416, num417 - 1) && !WorldGen.SolidTile(num416, num417 - 2))
													{
														this.velocity.Y = -5.1f;
													}
													else if (!WorldGen.SolidTile(num416, num417 - 2))
													{
														this.velocity.Y = -7.1f;
													}
													else if (WorldGen.SolidTile(num416, num417 - 5))
													{
														this.velocity.Y = -11.1f;
													}
													else if (WorldGen.SolidTile(num416, num417 - 4))
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
								if (this.velocity.X > num408)
								{
									this.velocity.X = num408;
								}
								if (this.velocity.X < -num408)
								{
									this.velocity.X = -num408;
								}
								if (this.velocity.X < 0f)
								{
									this.direction = -1;
								}
								if (this.velocity.X > 0f)
								{
									this.direction = 1;
								}
								if (this.velocity.X > num407 && flag10)
								{
									this.direction = 1;
								}
								if (this.velocity.X < -num407 && flag9)
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
											int num418 = 3;
											this.frameCounter++;
											if (this.frameCounter < num418)
											{
												this.frame = 0;
											}
											else if (this.frameCounter < num418 * 2)
											{
												this.frame = 1;
											}
											else if (this.frameCounter < num418 * 3)
											{
												this.frame = 2;
											}
											else if (this.frameCounter < num418 * 4)
											{
												this.frame = 3;
											}
											else
											{
												this.frameCounter = num418 * 4;
											}
										}
										else
										{
											this.velocity.X = this.velocity.X * 0.8f;
											this.frameCounter++;
											int num419 = 3;
											if (this.frameCounter < num419)
											{
												this.frame = 0;
											}
											else if (this.frameCounter < num419 * 2)
											{
												this.frame = 1;
											}
											else if (this.frameCounter < num419 * 3)
											{
												this.frame = 2;
											}
											else if (this.frameCounter < num419 * 4)
											{
												this.frame = 3;
											}
											else if (flag9 || flag10)
											{
												this.velocity.X = this.velocity.X * 2f;
												this.frame = 4;
												this.velocity.Y = -6.1f;
												this.frameCounter = 0;
												for (int num420 = 0; num420 < 4; num420++)
												{
													int num421 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), this.width, 4, 5, 0f, 0f, 0, default(Color), 1f);
													Main.dust[num421].velocity += this.velocity;
													Main.dust[num421].velocity *= 0.4f;
												}
											}
											else
											{
												this.frameCounter = num419 * 4;
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
											int num422 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), this.width, 6, 76, 0f, 0f, 0, default(Color), 1f);
											Main.dust[num422].noGravity = true;
											Main.dust[num422].velocity *= 0.3f;
											Main.dust[num422].noLight = true;
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
									int num423 = (int)(this.center().X / 16f);
									int num424 = (int)(this.center().Y / 16f);
									if (Main.tile[num423, num424] != null && Main.tile[num423, num424].wall > 0)
									{
										this.position.Y = this.position.Y + (float)this.height;
										this.height = 34;
										this.position.Y = this.position.Y - (float)this.height;
										this.position.X = this.position.X + (float)(this.width / 2);
										this.width = 34;
										this.position.X = this.position.X - (float)(this.width / 2);
										float num425 = 4f;
										Vector2 vector30 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
										float num426 = Main.player[this.owner].center().X - vector30.X;
										float num427 = Main.player[this.owner].center().Y - vector30.Y;
										float num428 = (float)Math.Sqrt((double)(num426 * num426 + num427 * num427));
										float num429 = num425 / num428;
										num426 *= num429;
										num427 *= num429;
										if (num428 < 120f)
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
											this.velocity.X = (this.velocity.X * 9f + num426) / 10f;
											this.velocity.Y = (this.velocity.Y * 9f + num427) / 10f;
										}
										if (num428 >= 120f)
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
							for (int num430 = 5; num430 < 25; num430++)
							{
								float num431 = this.velocity.X * (30f / (float)num430);
								float num432 = this.velocity.Y * (30f / (float)num430);
								num431 *= 80f;
								num432 *= 80f;
								int num433 = Dust.NewDust(new Vector2(this.position.X - num431, this.position.Y - num432), 8, 8, 27, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 0.9f);
								Main.dust[num433].velocity *= 0.25f;
								Main.dust[num433].velocity -= this.velocity * 5f;
							}
						}
						if (this.localAI[1] > 7f && this.type == 173)
						{
							int num434 = Main.rand.Next(3);
							if (num434 == 0)
							{
								num434 = 15;
							}
							else if (num434 == 1)
							{
								num434 = 57;
							}
							else
							{
								num434 = 58;
							}
							int num435 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 4f + 2f, this.position.Y + 2f - this.velocity.Y * 4f), 8, 8, num434, 0f, 0f, 100, default(Color), 1.25f);
							Main.dust[num435].velocity *= 0.1f;
						}
						if (this.localAI[1] > 7f && this.type == 132)
						{
							int num436 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 4f + 2f, this.position.Y + 2f - this.velocity.Y * 4f), 8, 8, 107, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.25f);
							Main.dust[num436].velocity *= -0.25f;
							num436 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 4f + 2f, this.position.Y + 2f - this.velocity.Y * 4f), 8, 8, 107, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.25f);
							Main.dust[num436].velocity *= -0.25f;
							Main.dust[num436].position -= this.velocity * 0.5f;
						}
						if (this.localAI[1] < 15f)
						{
							this.localAI[1] += 1f;
						}
						else
						{
							if (this.type == 114 || this.type == 115)
							{
								int num437 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 4f), 8, 8, 27, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 0.6f);
								Main.dust[num437].velocity *= -0.25f;
							}
							else if (this.type == 116)
							{
								int num438 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 5f + 2f, this.position.Y + 2f - this.velocity.Y * 5f), 8, 8, 64, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.5f);
								Main.dust[num438].velocity *= -0.25f;
								Main.dust[num438].noGravity = true;
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
							for (int num439 = 0; num439 < 3; num439++)
							{
								int num440 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 137, this.velocity.X, this.velocity.Y, Main.rand.Next(0, 101), default(Color), 1f + (float)Main.rand.Next(-20, 40) * 0.01f);
								Main.dust[num440].noGravity = true;
								Main.dust[num440].velocity *= 0.3f;
							}
						}
						if (this.type == 118)
						{
							for (int num441 = 0; num441 < 2; num441++)
							{
								int num442 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 92, this.velocity.X, this.velocity.Y, 50, default(Color), 1.2f);
								Main.dust[num442].noGravity = true;
								Main.dust[num442].velocity *= 0.3f;
							}
						}
						if (this.type == 119 || this.type == 128 || this.type == 359)
						{
							for (int num443 = 0; num443 < 3; num443++)
							{
								int num444 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 92, this.velocity.X, this.velocity.Y, 50, default(Color), 1.2f);
								Main.dust[num444].noGravity = true;
								Main.dust[num444].velocity *= 0.3f;
							}
						}
						if (this.type == 309)
						{
							for (int num445 = 0; num445 < 3; num445++)
							{
								int num446 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 185, this.velocity.X, this.velocity.Y, 50, default(Color), 1.2f);
								Main.dust[num446].noGravity = true;
								Main.dust[num446].velocity *= 0.3f;
							}
						}
						if (this.type == 129)
						{
							for (int num447 = 0; num447 < 6; num447++)
							{
								int num448 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 106, this.velocity.X, this.velocity.Y, 100, default(Color), 1f);
								Main.dust[num448].noGravity = true;
								Main.dust[num448].velocity *= 0.1f + (float)Main.rand.Next(4) * 0.1f;
								Main.dust[num448].scale *= 1f + (float)Main.rand.Next(5) * 0.1f;
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
						int num449 = this.type - 121 + 86;
						for (int num450 = 0; num450 < 2; num450++)
						{
							int num451 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num449, this.velocity.X, this.velocity.Y, 50, default(Color), 1.2f);
							Main.dust[num451].noGravity = true;
							Main.dust[num451].velocity *= 0.3f;
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
							int num452 = 110;
							int num453 = 0;
							if (this.type == 146)
							{
								num452 = 111;
								num453 = 2;
							}
							if (this.type == 147)
							{
								num452 = 112;
								num453 = 1;
							}
							if (this.type == 148)
							{
								num452 = 113;
								num453 = 3;
							}
							if (this.type == 149)
							{
								num452 = 114;
								num453 = 4;
							}
							if (this.owner == Main.myPlayer)
							{
								WorldGen.Convert((int)(this.position.X + (float)(this.width / 2)) / 16, (int)(this.position.Y + (float)(this.height / 2)) / 16, num453, 2);
							}
							if (this.timeLeft > 133)
							{
								this.timeLeft = 133;
							}
							if (this.ai[0] > 7f)
							{
								float num454 = 1f;
								if (this.ai[0] == 8f)
								{
									num454 = 0.2f;
								}
								else if (this.ai[0] == 9f)
								{
									num454 = 0.4f;
								}
								else if (this.ai[0] == 10f)
								{
									num454 = 0.6f;
								}
								else if (this.ai[0] == 11f)
								{
									num454 = 0.8f;
								}
								this.ai[0] += 1f;
								for (int num455 = 0; num455 < 1; num455++)
								{
									int num456 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num452, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 1f);
									Main.dust[num456].noGravity = true;
									Main.dust[num456].scale *= 1.75f;
									Dust expr_16A94_cp_0 = Main.dust[num456];
									expr_16A94_cp_0.velocity.X = expr_16A94_cp_0.velocity.X * 2f;
									Dust expr_16AB4_cp_0 = Main.dust[num456];
									expr_16AB4_cp_0.velocity.Y = expr_16AB4_cp_0.velocity.Y * 2f;
									Main.dust[num456].scale *= num454;
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
								for (int num457 = 0; num457 < 255; num457++)
								{
									Rectangle rectangle2 = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
									if (Main.player[num457].active)
									{
										Rectangle value3 = new Rectangle((int)Main.player[num457].position.X, (int)Main.player[num457].position.Y, Main.player[num457].width, Main.player[num457].height);
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
											this.velocity.X = (this.velocity.X + (float)Main.player[num457].direction * 1.75f) / 2f;
											this.velocity.X = this.velocity.X + Main.player[num457].velocity.X * 3f;
											this.velocity.Y = this.velocity.Y + Main.player[num457].velocity.Y;
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
								float num458 = 4f;
								float num459 = this.ai[0];
								float num460 = this.ai[1];
								if (num459 == 0f && num460 == 0f)
								{
									num459 = 1f;
								}
								float num461 = (float)Math.Sqrt((double)(num459 * num459 + num460 * num460));
								num461 = num458 / num461;
								num459 *= num461;
								num460 *= num461;
								if (this.alpha < 70)
								{
									int num462 = 127;
									if (this.type == 310)
									{
										num462 = 187;
									}
									int num463 = Dust.NewDust(new Vector2(this.position.X, this.position.Y - 2f), 6, 6, num462, this.velocity.X, this.velocity.Y, 100, default(Color), 1.6f);
									Main.dust[num463].noGravity = true;
									Dust expr_170A9_cp_0 = Main.dust[num463];
									expr_170A9_cp_0.position.X = expr_170A9_cp_0.position.X - num459 * 1f;
									Dust expr_170CE_cp_0 = Main.dust[num463];
									expr_170CE_cp_0.position.Y = expr_170CE_cp_0.position.Y - num460 * 1f;
									Dust expr_170F3_cp_0 = Main.dust[num463];
									expr_170F3_cp_0.velocity.X = expr_170F3_cp_0.velocity.X - num459;
									Dust expr_17112_cp_0 = Main.dust[num463];
									expr_17112_cp_0.velocity.Y = expr_17112_cp_0.velocity.Y - num460;
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
								int num464 = Dust.NewDust(new Vector2(this.position.X + 2f, this.position.Y + 20f), 8, 8, 6, this.velocity.X, this.velocity.Y, 100, default(Color), 1.2f);
								Main.dust[num464].noGravity = true;
								Main.dust[num464].velocity *= 0.2f;
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
									Vector2 vector31 = Collision.TileCollision(this.position, this.velocity, this.width, this.height, true, true, 1);
									bool flag15 = false;
									if (vector31 != this.velocity)
									{
										flag15 = true;
									}
									else
									{
										int num465 = (int)(this.center().X + this.velocity.X) / 16;
										int num466 = (int)(this.center().Y + this.velocity.Y) / 16;
										if (Main.tile[num465, num466] != null && Main.tile[num465, num466].active() && Main.tile[num465, num466].bottomSlope())
										{
											flag15 = true;
											this.position.Y = (float)(num466 * 16 + 16 + 8);
											this.position.X = (float)(num465 * 16 + 8);
										}
									}
									if (flag15)
									{
										int num467 = (int)(this.position.X + (float)(this.width / 2)) / 16;
										int num468 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
										this.position += vector31;
										int num469 = 10;
										if (Main.tile[num467, num468] != null)
										{
											while (Main.tile[num467, num468] != null && Main.tile[num467, num468].active())
											{
												if (!Main.tileRope[(int)Main.tile[num467, num468].type])
												{
													break;
												}
												num468++;
											}
											while (num469 > 0)
											{
												num469--;
												if (Main.tile[num467, num468] == null)
												{
													break;
												}
												if (Main.tile[num467, num468].active() && (Main.tileCut[(int)Main.tile[num467, num468].type] || Main.tile[num467, num468].type == 165))
												{
													WorldGen.KillTile(num467, num468, false, false, false);
													NetMessage.SendData(17, -1, -1, "", 0, (float)num467, (float)num468, 0f, 0);
												}
												if (!Main.tile[num467, num468].active())
												{
													WorldGen.PlaceTile(num467, num468, 213, false, false, -1, 0);
													NetMessage.SendData(17, -1, -1, "", 1, (float)num467, (float)num468, 213f, 0);
													this.ai[1] += 1f;
												}
												else
												{
													num469 = 0;
												}
												num468++;
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
									for (int num470 = 0; num470 < 3; num470++)
									{
										float num471 = this.velocity.X / 3f * (float)num470;
										float num472 = this.velocity.Y / 3f * (float)num470;
										int num473 = Dust.NewDust(this.position, this.width, this.height, 184, 0f, 0f, 0, default(Color), 1f);
										Main.dust[num473].position.X = this.center().X - num471;
										Main.dust[num473].position.Y = this.center().Y - num472;
										Main.dust[num473].velocity *= 0f;
										Main.dust[num473].scale = 0.5f;
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
								float num474 = this.position.X;
								float num475 = this.position.Y;
								float num476 = 100000f;
								bool flag16 = false;
								this.ai[0] += 1f;
								if (this.ai[0] > 30f)
								{
									this.ai[0] = 30f;
									for (int num477 = 0; num477 < 200; num477++)
									{
										if (Main.npc[num477].active && !Main.npc[num477].dontTakeDamage && !Main.npc[num477].friendly && Main.npc[num477].lifeMax > 5 && (!Main.npc[num477].wet || this.type == 307))
										{
											float num478 = Main.npc[num477].position.X + (float)(Main.npc[num477].width / 2);
											float num479 = Main.npc[num477].position.Y + (float)(Main.npc[num477].height / 2);
											float num480 = Math.Abs(this.position.X + (float)(this.width / 2) - num478) + Math.Abs(this.position.Y + (float)(this.height / 2) - num479);
											if (num480 < 800f && num480 < num476 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num477].position, Main.npc[num477].width, Main.npc[num477].height))
											{
												num476 = num480;
												num474 = num478;
												num475 = num479;
												flag16 = true;
											}
										}
									}
								}
								if (!flag16)
								{
									num474 = this.position.X + (float)(this.width / 2) + this.velocity.X * 100f;
									num475 = this.position.Y + (float)(this.height / 2) + this.velocity.Y * 100f;
								}
								else if (this.type == 307)
								{
									this.friendly = true;
								}
								float num481 = 6f;
								float num482 = 0.1f;
								if (this.type == 189)
								{
									num481 = 7f;
									num482 = 0.15f;
								}
								if (this.type == 307)
								{
									num481 = 9f;
									num482 = 0.2f;
								}
								if (this.type == 316)
								{
									num481 = 10f;
									num482 = 0.25f;
								}
								Vector2 vector32 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
								float num483 = num474 - vector32.X;
								float num484 = num475 - vector32.Y;
								float num485 = (float)Math.Sqrt((double)(num483 * num483 + num484 * num484));
								num485 = num481 / num485;
								num483 *= num485;
								num484 *= num485;
								if (this.velocity.X < num483)
								{
									this.velocity.X = this.velocity.X + num482;
									if (this.velocity.X < 0f && num483 > 0f)
									{
										this.velocity.X = this.velocity.X + num482 * 2f;
									}
								}
								else if (this.velocity.X > num483)
								{
									this.velocity.X = this.velocity.X - num482;
									if (this.velocity.X > 0f && num483 < 0f)
									{
										this.velocity.X = this.velocity.X - num482 * 2f;
									}
								}
								if (this.velocity.Y < num484)
								{
									this.velocity.Y = this.velocity.Y + num482;
									if (this.velocity.Y < 0f && num484 > 0f)
									{
										this.velocity.Y = this.velocity.Y + num482 * 2f;
										return;
									}
								}
								else if (this.velocity.Y > num484)
								{
									this.velocity.Y = this.velocity.Y - num482;
									if (this.velocity.Y > 0f && num484 < 0f)
									{
										this.velocity.Y = this.velocity.Y - num482 * 2f;
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
									float num486 = this.position.Y - this.ai[1];
									if (num486 > 300f)
									{
										this.velocity.Y = this.velocity.Y * -1f;
										this.ai[0] += 1f;
										return;
									}
								}
								else if (Collision.SolidCollision(this.position, this.width, this.height) || this.position.Y < this.ai[1])
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
								float num487 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector33.X;
								float num488 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector33.Y;
								float num489 = (float)Math.Sqrt((double)(num487 * num487 + num488 * num488));
								if (!Main.player[this.owner].channel && this.alpha == 0)
								{
									this.ai[0] = 1f;
									this.ai[1] = -1f;
								}
								if (this.ai[1] > 0f && num489 > 1500f)
								{
									this.ai[1] = 0f;
									this.ai[0] = 1f;
								}
								if (this.ai[1] > 0f)
								{
									this.tileCollide = false;
									int num490 = (int)this.ai[1] - 1;
									if (Main.npc[num490].active && Main.npc[num490].life > 0)
									{
										float num491 = 16f;
										vector33 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
										num487 = Main.npc[num490].position.X + (float)(Main.npc[num490].width / 2) - vector33.X;
										num488 = Main.npc[num490].position.Y + (float)(Main.npc[num490].height / 2) - vector33.Y;
										num489 = (float)Math.Sqrt((double)(num487 * num487 + num488 * num488));
										if (num489 < num491)
										{
											this.velocity.X = num487;
											this.velocity.Y = num488;
											if (num489 > num491 / 2f)
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
											num489 = num491 / num489;
											num487 *= num489;
											num488 *= num489;
											this.velocity.X = num487;
											this.velocity.Y = num488;
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
										float num492 = this.position.X;
										float num493 = this.position.Y;
										float num494 = 3000f;
										int num495 = -1;
										for (int num496 = 0; num496 < 200; num496++)
										{
											if (Main.npc[num496].active && !Main.npc[num496].friendly && Main.npc[num496].lifeMax > 5 && !Main.npc[num496].dontTakeDamage)
											{
												float num497 = Main.npc[num496].position.X + (float)(Main.npc[num496].width / 2);
												float num498 = Main.npc[num496].position.Y + (float)(Main.npc[num496].height / 2);
												float num499 = Math.Abs(this.position.X + (float)(this.width / 2) - num497) + Math.Abs(this.position.Y + (float)(this.height / 2) - num498);
												if (num499 < num494 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num496].position, Main.npc[num496].width, Main.npc[num496].height))
												{
													num494 = num499;
													num492 = num497;
													num493 = num498;
													num495 = num496;
												}
											}
										}
										if (num495 >= 0)
										{
											float num500 = 16f;
											vector33 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
											num487 = num492 - vector33.X;
											num488 = num493 - vector33.Y;
											num489 = (float)Math.Sqrt((double)(num487 * num487 + num488 * num488));
											num489 = num500 / num489;
											num487 *= num489;
											num488 *= num489;
											this.velocity.X = num487;
											this.velocity.Y = num488;
											this.ai[0] = 0f;
											this.ai[1] = (float)(num495 + 1);
										}
									}
								}
								else if (this.ai[0] == 0f)
								{
									if (num489 > 700f)
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
									float num501 = 20f;
									if (num489 < 70f)
									{
										this.Kill();
									}
									num489 = num501 / num489;
									num487 *= num489;
									num488 *= num489;
									this.velocity.X = num487;
									this.velocity.Y = num488;
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
									float num502 = (float)Main.mouseTextColor / 200f - 0.35f;
									num502 *= 0.2f;
									this.scale = num502 + 0.95f;
									if (this.owner == Main.myPlayer)
									{
										if (this.ai[0] != 0f)
										{
											this.ai[0] -= 1f;
											return;
										}
										float num503 = this.position.X;
										float num504 = this.position.Y;
										float num505 = 700f;
										bool flag17 = false;
										for (int num506 = 0; num506 < 200; num506++)
										{
											if (Main.npc[num506].active && !Main.npc[num506].friendly && Main.npc[num506].lifeMax > 5)
											{
												float num507 = Main.npc[num506].position.X + (float)(Main.npc[num506].width / 2);
												float num508 = Main.npc[num506].position.Y + (float)(Main.npc[num506].height / 2);
												float num509 = Math.Abs(this.position.X + (float)(this.width / 2) - num507) + Math.Abs(this.position.Y + (float)(this.height / 2) - num508);
												if (num509 < num505 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num506].position, Main.npc[num506].width, Main.npc[num506].height))
												{
													num505 = num509;
													num503 = num507;
													num504 = num508;
													flag17 = true;
												}
											}
										}
										if (flag17)
										{
											float num510 = 12f;
											Vector2 vector34 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
											float num511 = num503 - vector34.X;
											float num512 = num504 - vector34.Y;
											float num513 = (float)Math.Sqrt((double)(num511 * num511 + num512 * num512));
											num513 = num510 / num513;
											num511 *= num513;
											num512 *= num513;
											Projectile.NewProjectile(this.center().X - 4f, this.center().Y, num511, num512, 227, 50, 5f, this.owner, 0f, 0f);
											this.ai[0] = 50f;
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
											for (int num514 = 0; num514 < 5; num514++)
											{
												int num515 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 157, 0f, 0f, 0, default(Color), 1f);
												Main.dust[num515].noGravity = true;
												Main.dust[num515].velocity *= 3f;
												Main.dust[num515].scale = 1.5f;
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
										int num516 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 157, 0f, 0f, 0, default(Color), 1f);
										Main.dust[num516].noGravity = true;
										Main.dust[num516].velocity *= 0.1f;
										Main.dust[num516].scale = 1.5f;
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
											float num517 = this.ai[0];
											float num518 = this.ai[1];
											if (num517 != 0f && num518 != 0f)
											{
												bool flag18 = false;
												bool flag19 = false;
												if ((this.velocity.X < 0f && this.center().X < num517) || (this.velocity.X > 0f && this.center().X > num517))
												{
													flag18 = true;
												}
												if ((this.velocity.Y < 0f && this.center().Y < num518) || (this.velocity.Y > 0f && this.center().Y > num518))
												{
													flag19 = true;
												}
												if (flag18 && flag19)
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
															int num519 = (int)(this.position.X + 14f + (float)Main.rand.Next(this.width - 28));
															int num520 = (int)(this.position.Y + (float)this.height + 4f);
															Projectile.NewProjectile((float)num519, (float)num520, 0f, 5f, 245, this.damage, 0f, this.owner, 0f, 0f);
														}
													}
												}
												else if (this.ai[0] > 8f)
												{
													this.ai[0] = 0f;
													if (this.owner == Main.myPlayer)
													{
														int num521 = (int)(this.position.X + 14f + (float)Main.rand.Next(this.width - 28));
														int num522 = (int)(this.position.Y + (float)this.height + 4f);
														Projectile.NewProjectile((float)num521, (float)num522, 0f, 5f, 239, this.damage, 0f, this.owner, 0f, 0f);
													}
												}
											}
											this.localAI[0] += 1f;
											if (this.localAI[0] >= 10f)
											{
												this.localAI[0] = 0f;
												int num523 = 0;
												int num524 = 0;
												float num525 = 0f;
												int num526 = this.type;
												for (int num527 = 0; num527 < 1000; num527++)
												{
													if (Main.projectile[num527].active && Main.projectile[num527].owner == this.owner && Main.projectile[num527].type == num526 && Main.projectile[num527].ai[1] < 3600f)
													{
														num523++;
														if (Main.projectile[num527].ai[1] > num525)
														{
															num524 = num527;
															num525 = Main.projectile[num527].ai[1];
														}
													}
												}
												if (this.type == 244)
												{
													if (num523 > 1)
													{
														Main.projectile[num524].netUpdate = true;
														Main.projectile[num524].ai[1] = 36000f;
														return;
													}
												}
												else if (num523 > 2)
												{
													Main.projectile[num524].netUpdate = true;
													Main.projectile[num524].ai[1] = 36000f;
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
										int num528 = 600;
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
												if (this.timeLeft > num528)
												{
													this.timeLeft = num528;
												}
											}
											float num529 = 1f;
											if (this.velocity.Y < 0f)
											{
												num529 -= this.velocity.Y / 3f;
											}
											this.ai[0] += num529;
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
											float num530 = this.velocity.X;
											float num531 = this.velocity.Y;
											float num532 = (float)Math.Sqrt((double)(num530 * num530 + num531 * num531));
											num532 = 15.95f * this.scale / num532;
											num530 *= num532;
											num531 *= num532;
											this.velocity.X = num530;
											this.velocity.Y = num531;
											this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) - 1.57f;
											return;
										}
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
											this.timeLeft = num528;
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
										if (this.timeLeft > num528 - 10)
										{
											int num533 = num528 - this.timeLeft;
											this.alpha = 255 - (int)(255f * (float)num533 / 10f);
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
										for (int num534 = 0; num534 < 1000; num534++)
										{
											if (num534 != this.whoAmI && Main.projectile[num534].active && Main.projectile[num534].owner == this.owner && Main.projectile[num534].type == this.type && this.timeLeft > Main.projectile[num534].timeLeft && Main.projectile[num534].timeLeft > 30)
											{
												Main.projectile[num534].timeLeft = 30;
											}
										}
										int[] array = new int[20];
										int num535 = 0;
										float num536 = 300f;
										bool flag20 = false;
										for (int num537 = 0; num537 < 200; num537++)
										{
											if (Main.npc[num537].active && !Main.npc[num537].dontTakeDamage && !Main.npc[num537].friendly && Main.npc[num537].lifeMax > 5)
											{
												float num538 = Main.npc[num537].position.X + (float)(Main.npc[num537].width / 2);
												float num539 = Main.npc[num537].position.Y + (float)(Main.npc[num537].height / 2);
												float num540 = Math.Abs(this.position.X + (float)(this.width / 2) - num538) + Math.Abs(this.position.Y + (float)(this.height / 2) - num539);
												if (num540 < num536 && Collision.CanHit(this.center(), 1, 1, Main.npc[num537].center(), 1, 1))
												{
													if (num535 < 20)
													{
														array[num535] = num537;
														num535++;
													}
													flag20 = true;
												}
											}
										}
										if (this.timeLeft < 30)
										{
											flag20 = false;
										}
										if (flag20)
										{
											int num541 = Main.rand.Next(num535);
											num541 = array[num541];
											float num542 = Main.npc[num541].position.X + (float)(Main.npc[num541].width / 2);
											float num543 = Main.npc[num541].position.Y + (float)(Main.npc[num541].height / 2);
											this.localAI[0] += 1f;
											if (this.localAI[0] > 8f)
											{
												this.localAI[0] = 0f;
												float num544 = 6f;
												Vector2 value4 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
												value4 += this.velocity * 4f;
												float num545 = num542 - value4.X;
												float num546 = num543 - value4.Y;
												float num547 = (float)Math.Sqrt((double)(num545 * num545 + num546 * num546));
												num547 = num544 / num547;
												num545 *= num547;
												num546 *= num547;
												Projectile.NewProjectile(value4.X, value4.Y, num545, num546, 255, this.damage, this.knockBack, this.owner, 0f, 0f);
												return;
											}
										}
									}
									else if (this.aiStyle == 48)
									{
										if (this.type == 255)
										{
											for (int num548 = 0; num548 < 4; num548++)
											{
												Vector2 value5 = this.position;
												value5 -= this.velocity * ((float)num548 * 0.25f);
												this.alpha = 255;
												int num549 = Dust.NewDust(value5, 1, 1, 160, 0f, 0f, 0, default(Color), 1f);
												Main.dust[num549].position = value5;
												Dust expr_1A3FA_cp_0 = Main.dust[num549];
												expr_1A3FA_cp_0.position.X = expr_1A3FA_cp_0.position.X + (float)(this.width / 2);
												Dust expr_1A41E_cp_0 = Main.dust[num549];
												expr_1A41E_cp_0.position.Y = expr_1A41E_cp_0.position.Y + (float)(this.height / 2);
												Main.dust[num549].scale = (float)Main.rand.Next(70, 110) * 0.013f;
												Main.dust[num549].velocity *= 0.2f;
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
												for (int num550 = 0; num550 < 3; num550++)
												{
													Vector2 value6 = this.position;
													value6 -= this.velocity * ((float)num550 * 0.3334f);
													this.alpha = 255;
													int num551 = Dust.NewDust(value6, 1, 1, 173, 0f, 0f, 0, default(Color), 1f);
													Main.dust[num551].position = value6;
													Main.dust[num551].scale = (float)Main.rand.Next(70, 110) * 0.013f;
													Main.dust[num551].velocity *= 0.2f;
												}
												return;
											}
										}
										else if (this.type == 294)
										{
											this.localAI[0] += 1f;
											if (this.localAI[0] > 9f)
											{
												for (int num552 = 0; num552 < 4; num552++)
												{
													Vector2 value7 = this.position;
													value7 -= this.velocity * ((float)num552 * 0.25f);
													this.alpha = 255;
													int num553 = Dust.NewDust(value7, 1, 1, 173, 0f, 0f, 0, default(Color), 1f);
													Main.dust[num553].position = value7;
													Main.dust[num553].scale = (float)Main.rand.Next(70, 110) * 0.013f;
													Main.dust[num553].velocity *= 0.2f;
												}
												return;
											}
										}
										else
										{
											this.localAI[0] += 1f;
											if (this.localAI[0] > 3f)
											{
												for (int num554 = 0; num554 < 4; num554++)
												{
													Vector2 value8 = this.position;
													value8 -= this.velocity * ((float)num554 * 0.25f);
													this.alpha = 255;
													int num555 = Dust.NewDust(value8, 1, 1, 162, 0f, 0f, 0, default(Color), 1f);
													Main.dust[num555].position = value8;
													Dust expr_1A7BA_cp_0 = Main.dust[num555];
													expr_1A7BA_cp_0.position.X = expr_1A7BA_cp_0.position.X + (float)(this.width / 2);
													Dust expr_1A7DE_cp_0 = Main.dust[num555];
													expr_1A7DE_cp_0.position.Y = expr_1A7DE_cp_0.position.Y + (float)(this.height / 2);
													Main.dust[num555].scale = (float)Main.rand.Next(70, 110) * 0.013f;
													Main.dust[num555].velocity *= 0.2f;
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
													for (int num556 = 0; num556 < 10; num556++)
													{
														int num557 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
														Main.dust[num557].velocity *= 0.5f;
														Main.dust[num557].velocity += this.velocity * 0.1f;
													}
													for (int num558 = 0; num558 < 5; num558++)
													{
														int num559 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
														Main.dust[num559].noGravity = true;
														Main.dust[num559].velocity *= 3f;
														Main.dust[num559].velocity += this.velocity * 0.2f;
														num559 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
														Main.dust[num559].velocity *= 2f;
														Main.dust[num559].velocity += this.velocity * 0.3f;
													}
													for (int num560 = 0; num560 < 1; num560++)
													{
														int num561 = Gore.NewGore(new Vector2(this.position.X - 10f, this.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
														Main.gore[num561].position += this.velocity * 1.25f;
														Main.gore[num561].scale = 1.5f;
														Main.gore[num561].velocity += this.velocity * 0.5f;
														Main.gore[num561].velocity *= 0.02f;
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
											bool flag21 = false;
											bool flag22 = false;
											if (this.velocity.X < 0f && this.position.X < this.ai[0])
											{
												flag21 = true;
											}
											if (this.velocity.X > 0f && this.position.X > this.ai[0])
											{
												flag21 = true;
											}
											if (this.velocity.Y < 0f && this.position.Y < this.ai[1])
											{
												flag22 = true;
											}
											if (this.velocity.Y > 0f && this.position.Y > this.ai[1])
											{
												flag22 = true;
											}
											if (flag21 && flag22)
											{
												this.Kill();
											}
											for (int num562 = 0; num562 < 10; num562++)
											{
												int num563 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 174, 0f, 0f, 100, default(Color), 1.2f);
												Main.dust[num563].noGravity = true;
												Main.dust[num563].velocity *= 0.5f;
												Main.dust[num563].velocity += this.velocity * 0.1f;
											}
											return;
										}
										if (this.type == 295)
										{
											for (int num564 = 0; num564 < 8; num564++)
											{
												int num565 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 174, 0f, 0f, 100, default(Color), 1.2f);
												Main.dust[num565].noGravity = true;
												Main.dust[num565].velocity *= 0.5f;
												Main.dust[num565].velocity += this.velocity * 0.1f;
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
										float num566 = 25f;
										if (this.ai[0] > 180f)
										{
											num566 -= (this.ai[0] - 180f) / 2f;
										}
										if (num566 <= 0f)
										{
											num566 = 0f;
											this.Kill();
										}
										if (this.type == 296)
										{
											num566 *= 0.7f;
										}
										int num567 = 0;
										while ((float)num567 < num566)
										{
											float num568 = (float)Main.rand.Next(-10, 11);
											float num569 = (float)Main.rand.Next(-10, 11);
											float num570 = (float)Main.rand.Next(3, 9);
											float num571 = (float)Math.Sqrt((double)(num568 * num568 + num569 * num569));
											num571 = num570 / num571;
											num568 *= num571;
											num569 *= num571;
											int num572 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 174, 0f, 0f, 100, default(Color), 1.5f);
											Main.dust[num572].noGravity = true;
											Main.dust[num572].position.X = this.center().X;
											Main.dust[num572].position.Y = this.center().Y;
											Dust expr_1B22D_cp_0 = Main.dust[num572];
											expr_1B22D_cp_0.position.X = expr_1B22D_cp_0.position.X + (float)Main.rand.Next(-10, 11);
											Dust expr_1B257_cp_0 = Main.dust[num572];
											expr_1B257_cp_0.position.Y = expr_1B257_cp_0.position.Y + (float)Main.rand.Next(-10, 11);
											Main.dust[num572].velocity.X = num568;
											Main.dust[num572].velocity.Y = num569;
											num567++;
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
												for (int num573 = 0; num573 < 5; num573++)
												{
													int num574 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 175, 0f, 0f, 100, default(Color), 2f);
													Main.dust[num574].noGravity = true;
													Main.dust[num574].velocity *= 0f;
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
											for (int num575 = 0; num575 < 9; num575++)
											{
												int num576 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 175, 0f, 0f, 100, default(Color), 1.3f);
												Main.dust[num576].noGravity = true;
												Main.dust[num576].velocity *= 0f;
											}
										}
										float num577 = this.center().X;
										float num578 = this.center().Y;
										float num579 = 400f;
										bool flag23 = false;
										if (this.type == 297)
										{
											for (int num580 = 0; num580 < 200; num580++)
											{
												if (Main.npc[num580].active && !Main.npc[num580].dontTakeDamage && !Main.npc[num580].friendly && Main.npc[num580].lifeMax > 5 && Collision.CanHit(this.center(), 1, 1, Main.npc[num580].center(), 1, 1))
												{
													float num581 = Main.npc[num580].position.X + (float)(Main.npc[num580].width / 2);
													float num582 = Main.npc[num580].position.Y + (float)(Main.npc[num580].height / 2);
													float num583 = Math.Abs(this.position.X + (float)(this.width / 2) - num581) + Math.Abs(this.position.Y + (float)(this.height / 2) - num582);
													if (num583 < num579)
													{
														num579 = num583;
														num577 = num581;
														num578 = num582;
														flag23 = true;
													}
												}
											}
										}
										else
										{
											num579 = 200f;
											for (int num584 = 0; num584 < 255; num584++)
											{
												if (Main.player[num584].active && !Main.player[num584].dead)
												{
													float num585 = Main.player[num584].position.X + (float)(Main.player[num584].width / 2);
													float num586 = Main.player[num584].position.Y + (float)(Main.player[num584].height / 2);
													float num587 = Math.Abs(this.position.X + (float)(this.width / 2) - num585) + Math.Abs(this.position.Y + (float)(this.height / 2) - num586);
													if (num587 < num579)
													{
														num579 = num587;
														num577 = num585;
														num578 = num586;
														flag23 = true;
													}
												}
											}
										}
										if (flag23)
										{
											float num588 = 3f;
											if (this.type == 297)
											{
												num588 = 6f;
											}
											Vector2 vector35 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
											float num589 = num577 - vector35.X;
											float num590 = num578 - vector35.Y;
											float num591 = (float)Math.Sqrt((double)(num589 * num589 + num590 * num590));
											num591 = num588 / num591;
											num589 *= num591;
											num590 *= num591;
											if (this.type == 297)
											{
												this.velocity.X = (this.velocity.X * 20f + num589) / 21f;
												this.velocity.Y = (this.velocity.Y * 20f + num590) / 21f;
												return;
											}
											this.velocity.X = (this.velocity.X * 100f + num589) / 101f;
											this.velocity.Y = (this.velocity.Y * 100f + num590) / 101f;
											return;
										}
									}
									else if (this.aiStyle == 52)
									{
										int num592 = (int)this.ai[0];
										float num593 = 4f;
										Vector2 vector36 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
										float num594 = Main.player[num592].center().X - vector36.X;
										float num595 = Main.player[num592].center().Y - vector36.Y;
										float num596 = (float)Math.Sqrt((double)(num594 * num594 + num595 * num595));
										if (num596 < 50f && this.position.X < Main.player[num592].position.X + (float)Main.player[num592].width && this.position.X + (float)this.width > Main.player[num592].position.X && this.position.Y < Main.player[num592].position.Y + (float)Main.player[num592].height && this.position.Y + (float)this.height > Main.player[num592].position.Y)
										{
											if (this.owner == Main.myPlayer)
											{
												int num597 = (int)this.ai[1];
												Main.player[num592].statLife += num597;
												if (Main.player[num592].statLife > Main.player[num592].statLifeMax)
												{
													Main.player[num592].statLife = Main.player[num592].statLifeMax;
												}
												NetMessage.SendData(66, -1, -1, "", num592, (float)num597, 0f, 0f, 0);
											}
											this.Kill();
										}
										num596 = num593 / num596;
										num594 *= num596;
										num595 *= num596;
										this.velocity.X = (this.velocity.X * 15f + num594) / 16f;
										this.velocity.Y = (this.velocity.Y * 15f + num595) / 16f;
										if (this.type == 305)
										{
											for (int num598 = 0; num598 < 3; num598++)
											{
												float num599 = this.velocity.X * 0.334f * (float)num598;
												float num600 = -(this.velocity.Y * 0.334f) * (float)num598;
												int num601 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 183, 0f, 0f, 100, default(Color), 1.1f);
												Main.dust[num601].noGravity = true;
												Main.dust[num601].velocity *= 0f;
												Dust expr_1BC54_cp_0 = Main.dust[num601];
												expr_1BC54_cp_0.position.X = expr_1BC54_cp_0.position.X - num599;
												Dust expr_1BC73_cp_0 = Main.dust[num601];
												expr_1BC73_cp_0.position.Y = expr_1BC73_cp_0.position.Y - num600;
											}
											return;
										}
										for (int num602 = 0; num602 < 5; num602++)
										{
											float num603 = this.velocity.X * 0.2f * (float)num602;
											float num604 = -(this.velocity.Y * 0.2f) * (float)num602;
											int num605 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 175, 0f, 0f, 100, default(Color), 1.3f);
											Main.dust[num605].noGravity = true;
											Main.dust[num605].velocity *= 0f;
											Dust expr_1BD6B_cp_0 = Main.dust[num605];
											expr_1BD6B_cp_0.position.X = expr_1BD6B_cp_0.position.X - num603;
											Dust expr_1BD8A_cp_0 = Main.dust[num605];
											expr_1BD8A_cp_0.position.Y = expr_1BD8A_cp_0.position.Y - num604;
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
											int num606 = 80;
											Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 46);
											for (int num607 = 0; num607 < num606; num607++)
											{
												int num608 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 16f), this.width, this.height - 16, 185, 0f, 0f, 0, default(Color), 1f);
												Main.dust[num608].velocity *= 2f;
												Main.dust[num608].noGravity = true;
												Main.dust[num608].scale *= 1.15f;
											}
										}
										this.velocity.X = 0f;
										this.velocity.Y = this.velocity.Y + 0.2f;
										if (this.velocity.Y > 16f)
										{
											this.velocity.Y = 16f;
										}
										bool flag24 = false;
										float num609 = this.center().X;
										float num610 = this.center().Y;
										float num611 = 1000f;
										for (int num612 = 0; num612 < 200; num612++)
										{
											if (Main.npc[num612].active && !Main.npc[num612].dontTakeDamage && !Main.npc[num612].friendly && Main.npc[num612].lifeMax > 5)
											{
												float num613 = Main.npc[num612].position.X + (float)(Main.npc[num612].width / 2);
												float num614 = Main.npc[num612].position.Y + (float)(Main.npc[num612].height / 2);
												float num615 = Math.Abs(this.position.X + (float)(this.width / 2) - num613) + Math.Abs(this.position.Y + (float)(this.height / 2) - num614);
												if (num615 < num611 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num612].position, Main.npc[num612].width, Main.npc[num612].height))
												{
													num611 = num615;
													num609 = num613;
													num610 = num614;
													flag24 = true;
												}
											}
										}
										if (flag24)
										{
											float num616 = num609;
											float num617 = num610;
											num609 -= this.center().X;
											num610 -= this.center().Y;
											if (num609 < 0f)
											{
												this.spriteDirection = -1;
											}
											else
											{
												this.spriteDirection = 1;
											}
											int num618;
											if (num610 > 0f)
											{
												num618 = 0;
											}
											else if (Math.Abs(num610) > Math.Abs(num609) * 3f)
											{
												num618 = 4;
											}
											else if (Math.Abs(num610) > Math.Abs(num609) * 2f)
											{
												num618 = 3;
											}
											else if (Math.Abs(num609) > Math.Abs(num610) * 3f)
											{
												num618 = 0;
											}
											else if (Math.Abs(num609) > Math.Abs(num610) * 2f)
											{
												num618 = 1;
											}
											else
											{
												num618 = 2;
											}
											this.frame = num618 * 2;
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
													float num619 = 6f;
													Vector2 vector37 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
													if (num618 == 0)
													{
														vector37.Y += 12f;
														vector37.X += (float)(24 * this.spriteDirection);
													}
													else if (num618 == 1)
													{
														vector37.Y += 0f;
														vector37.X += (float)(24 * this.spriteDirection);
													}
													else if (num618 == 2)
													{
														vector37.Y -= 2f;
														vector37.X += (float)(24 * this.spriteDirection);
													}
													else if (num618 == 3)
													{
														vector37.Y -= 6f;
														vector37.X += (float)(14 * this.spriteDirection);
													}
													else if (num618 == 4)
													{
														vector37.Y -= 14f;
														vector37.X += (float)(2 * this.spriteDirection);
													}
													if (this.spriteDirection < 0)
													{
														vector37.X += 10f;
													}
													float num620 = num616 - vector37.X;
													float num621 = num617 - vector37.Y;
													float num622 = (float)Math.Sqrt((double)(num620 * num620 + num621 * num621));
													num622 = num619 / num622;
													num620 *= num622;
													num621 *= num622;
													int num623 = this.damage;
													int num624 = 309;
													Projectile.NewProjectile(vector37.X, vector37.Y, num620, num621, num624, num623, this.knockBack, Main.myPlayer, 0f, 0f);
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
										for (int num625 = 0; num625 < 1000; num625++)
										{
											if (num625 != this.whoAmI && Main.projectile[num625].active && Main.projectile[num625].owner == this.owner && Main.projectile[num625].type == this.type && Math.Abs(this.position.X - Main.projectile[num625].position.X) + Math.Abs(this.position.Y - Main.projectile[num625].position.Y) < (float)this.width)
											{
												if (this.position.X < Main.projectile[num625].position.X)
												{
													this.velocity.X = this.velocity.X - 0.05f;
												}
												else
												{
													this.velocity.X = this.velocity.X + 0.05f;
												}
												if (this.position.Y < Main.projectile[num625].position.Y)
												{
													this.velocity.Y = this.velocity.Y - 0.05f;
												}
												else
												{
													this.velocity.Y = this.velocity.Y + 0.05f;
												}
											}
										}
										float num626 = this.position.X;
										float num627 = this.position.Y;
										float num628 = 800f;
										bool flag25 = false;
										int num629 = 500;
										if (this.ai[1] != 0f || this.friendly)
										{
											num629 = 1400;
										}
										if (Math.Abs(this.center().X - Main.player[this.owner].center().X) + Math.Abs(this.center().Y - Main.player[this.owner].center().Y) > (float)num629)
										{
											this.ai[0] = 1f;
										}
										if (this.ai[0] == 0f)
										{
											this.tileCollide = true;
											for (int num630 = 0; num630 < 200; num630++)
											{
												if (Main.npc[num630].active && !Main.npc[num630].dontTakeDamage && !Main.npc[num630].friendly && Main.npc[num630].lifeMax > 5)
												{
													float num631 = Main.npc[num630].position.X + (float)(Main.npc[num630].width / 2);
													float num632 = Main.npc[num630].position.Y + (float)(Main.npc[num630].height / 2);
													float num633 = Math.Abs(this.position.X + (float)(this.width / 2) - num631) + Math.Abs(this.position.Y + (float)(this.height / 2) - num632);
													if (num633 < num628 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num630].position, Main.npc[num630].width, Main.npc[num630].height))
													{
														num628 = num633;
														num626 = num631;
														num627 = num632;
														flag25 = true;
													}
												}
											}
										}
										else
										{
											this.tileCollide = false;
										}
										if (!flag25)
										{
											this.friendly = true;
											float num634 = 8f;
											if (this.ai[0] == 1f)
											{
												num634 = 12f;
											}
											Vector2 vector38 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
											float num635 = Main.player[this.owner].center().X - vector38.X;
											float num636 = Main.player[this.owner].center().Y - vector38.Y - 60f;
											float num637 = (float)Math.Sqrt((double)(num635 * num635 + num636 * num636));
											if (num637 < 100f && this.ai[0] == 1f && !Collision.SolidCollision(this.position, this.width, this.height))
											{
												this.ai[0] = 0f;
											}
											if (num637 > 2000f)
											{
												this.position.X = Main.player[this.owner].center().X - (float)(this.width / 2);
												this.position.Y = Main.player[this.owner].center().Y - (float)(this.width / 2);
											}
											if (num637 > 70f)
											{
												num637 = num634 / num637;
												num635 *= num637;
												num636 *= num637;
												this.velocity.X = (this.velocity.X * 20f + num635) / 21f;
												this.velocity.Y = (this.velocity.Y * 20f + num636) / 21f;
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
												float num638 = 8f;
												Vector2 vector39 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
												float num639 = num626 - vector39.X;
												float num640 = num627 - vector39.Y;
												float num641 = (float)Math.Sqrt((double)(num639 * num639 + num640 * num640));
												if (num641 < 100f)
												{
													num638 = 10f;
												}
												num641 = num638 / num641;
												num639 *= num641;
												num640 *= num641;
												this.velocity.X = (this.velocity.X * 14f + num639) / 15f;
												this.velocity.Y = (this.velocity.Y * 14f + num640) / 15f;
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
											int num642 = (int)this.ai[0];
											if (Main.npc[num642].active)
											{
												float num643 = 8f;
												Vector2 vector40 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
												float num644 = Main.npc[num642].position.X - vector40.X;
												float num645 = Main.npc[num642].position.Y - vector40.Y;
												float num646 = (float)Math.Sqrt((double)(num644 * num644 + num645 * num645));
												num646 = num643 / num646;
												num644 *= num646;
												num645 *= num646;
												this.velocity.X = (this.velocity.X * 14f + num644) / 15f;
												this.velocity.Y = (this.velocity.Y * 14f + num645) / 15f;
											}
											else
											{
												float num647 = 1000f;
												for (int num648 = 0; num648 < 200; num648++)
												{
													if (Main.npc[num648].active && !Main.npc[num648].dontTakeDamage && !Main.npc[num648].friendly && Main.npc[num648].lifeMax > 5)
													{
														float num649 = Main.npc[num648].position.X + (float)(Main.npc[num648].width / 2);
														float num650 = Main.npc[num648].position.Y + (float)(Main.npc[num648].height / 2);
														float num651 = Math.Abs(this.position.X + (float)(this.width / 2) - num649) + Math.Abs(this.position.Y + (float)(this.height / 2) - num650);
														if (num651 < num647 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num648].position, Main.npc[num648].width, Main.npc[num648].height))
														{
															num647 = num651;
															this.ai[0] = (float)num648;
														}
													}
												}
											}
											int num652 = 8;
											int num653 = Dust.NewDust(new Vector2(this.position.X + (float)num652, this.position.Y + (float)num652), this.width - num652 * 2, this.height - num652 * 2, 6, 0f, 0f, 0, default(Color), 1f);
											Main.dust[num653].velocity *= 0.5f;
											Main.dust[num653].velocity += this.velocity * 0.5f;
											Main.dust[num653].noGravity = true;
											Main.dust[num653].noLight = true;
											Main.dust[num653].scale = 1.4f;
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
												if (this.velocity.Y > 16f)
												{
													this.velocity.Y = 16f;
												}
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
													int num654 = 0;
													for (int num655 = 0; num655 < 1000; num655++)
													{
														if (Main.projectile[num655].active && Main.projectile[num655].owner == this.owner && Main.projectile[num655].type == 344)
														{
															num654++;
														}
													}
													float num656 = (float)this.damage * 0.8f;
													if (num654 > 100)
													{
														float num657 = (float)(num654 - 100);
														num657 = 1f - num657 / 100f;
														num656 *= num657;
													}
													if (num654 > 100)
													{
														this.localAI[0] -= 1f;
													}
													if (num654 > 120)
													{
														this.localAI[0] -= 1f;
													}
													if (num654 > 140)
													{
														this.localAI[0] -= 1f;
													}
													if (num654 > 150)
													{
														this.localAI[0] -= 1f;
													}
													if (num654 > 160)
													{
														this.localAI[0] -= 1f;
													}
													if (num654 > 165)
													{
														this.localAI[0] -= 1f;
													}
													if (num654 > 170)
													{
														this.localAI[0] -= 2f;
													}
													if (num654 > 175)
													{
														this.localAI[0] -= 3f;
													}
													if (num654 > 180)
													{
														this.localAI[0] -= 4f;
													}
													if (num654 > 185)
													{
														this.localAI[0] -= 5f;
													}
													if (num654 > 190)
													{
														this.localAI[0] -= 6f;
													}
													if (num654 > 195)
													{
														this.localAI[0] -= 7f;
													}
													if (num656 > (float)this.damage * 0.1f)
													{
														Projectile.NewProjectile(this.center().X, this.center().Y, 0f, 0f, 344, (int)num656, this.knockBack * 0.55f, this.owner, 0f, (float)Main.rand.Next(3));
														return;
													}
												}
											}
										}
										else
										{
											if (this.aiStyle == 58)
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
												return;
											}
											if (this.aiStyle == 59)
											{
												this.ai[1] += 1f;
												if (this.ai[1] >= 60f)
												{
													this.friendly = true;
													int num658 = (int)this.ai[0];
													if (!Main.npc[num658].active)
													{
														int[] array2 = new int[200];
														int num659 = 0;
														for (int num660 = 0; num660 < 200; num660++)
														{
															if (Main.npc[num660].active && !Main.npc[num660].friendly && Main.npc[num660].lifeMax > 5 && !Main.npc[num660].dontTakeDamage)
															{
																float num661 = Math.Abs(Main.npc[num660].position.X + (float)(Main.npc[num660].width / 2) - this.position.X + (float)(this.width / 2)) + Math.Abs(Main.npc[num660].position.Y + (float)(Main.npc[num660].height / 2) - this.position.Y + (float)(this.height / 2));
																if (num661 < 800f)
																{
																	array2[num659] = num660;
																	num659++;
																}
															}
														}
														if (num659 == 0)
														{
															this.Kill();
															return;
														}
														num658 = array2[Main.rand.Next(num659)];
														this.ai[0] = (float)num658;
													}
													float num662 = 4f;
													Vector2 vector41 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
													float num663 = Main.npc[num658].center().X - vector41.X;
													float num664 = Main.npc[num658].center().Y - vector41.Y;
													float num665 = (float)Math.Sqrt((double)(num663 * num663 + num664 * num664));
													num665 = num662 / num665;
													num663 *= num665;
													num664 *= num665;
													int num666 = 30;
													this.velocity.X = (this.velocity.X * (float)(num666 - 1) + num663) / (float)num666;
													this.velocity.Y = (this.velocity.Y * (float)(num666 - 1) + num664) / (float)num666;
												}
												for (int num667 = 0; num667 < 5; num667++)
												{
													float num668 = this.velocity.X * 0.2f * (float)num667;
													float num669 = -(this.velocity.Y * 0.2f) * (float)num667;
													int num670 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 175, 0f, 0f, 100, default(Color), 1.3f);
													Main.dust[num670].noGravity = true;
													Main.dust[num670].velocity *= 0f;
													Dust expr_1DCBD_cp_0 = Main.dust[num670];
													expr_1DCBD_cp_0.position.X = expr_1DCBD_cp_0.position.X - num668;
													Dust expr_1DCDC_cp_0 = Main.dust[num670];
													expr_1DCDC_cp_0.position.Y = expr_1DCDC_cp_0.position.Y - num669;
												}
												return;
											}
											if (this.aiStyle == 60)
											{
												this.scale -= 0.015f;
												if (this.scale <= 0f)
												{
													this.velocity *= 5f;
													this.lastVelocity = this.velocity;
													this.Kill();
												}
												if (this.ai[0] > 3f)
												{
													if (this.owner == Main.myPlayer)
													{
														Rectangle rectangle3 = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
														for (int num671 = 0; num671 < 200; num671++)
														{
															if (Main.npc[num671].active && !Main.npc[num671].dontTakeDamage && Main.npc[num671].lifeMax > 1)
															{
																Rectangle value9 = new Rectangle((int)Main.npc[num671].position.X, (int)Main.npc[num671].position.Y, Main.npc[num671].width, Main.npc[num671].height);
																if (rectangle3.Intersects(value9))
																{
																	Main.npc[num671].AddBuff(103, 1500, false);
																	this.Kill();
																}
															}
														}
														for (int num672 = 0; num672 < 255; num672++)
														{
															if (num672 != this.owner && Main.player[num672].active && !Main.player[num672].dead)
															{
																Rectangle value10 = new Rectangle((int)Main.player[num672].position.X, (int)Main.player[num672].position.Y, Main.player[num672].width, Main.player[num672].height);
																if (rectangle3.Intersects(value10))
																{
																	Main.player[num672].AddBuff(103, 1500, false);
																	this.Kill();
																}
															}
														}
													}
													this.ai[0] += this.ai[1];
													if (this.ai[0] > 30f)
													{
														this.velocity.Y = this.velocity.Y + 0.1f;
													}
													for (int num673 = 0; num673 < 1; num673++)
													{
														for (int num674 = 0; num674 < 6; num674++)
														{
															float num675 = this.velocity.X / 6f * (float)num674;
															float num676 = this.velocity.Y / 6f * (float)num674;
															int num677 = 6;
															int num678 = Dust.NewDust(new Vector2(this.position.X + (float)num677, this.position.Y + (float)num677), this.width - num677 * 2, this.height - num677 * 2, 211, 0f, 0f, 75, default(Color), 1.2f);
															if (Main.rand.Next(2) == 0)
															{
																Main.dust[num678].alpha += 25;
															}
															if (Main.rand.Next(2) == 0)
															{
																Main.dust[num678].alpha += 25;
															}
															if (Main.rand.Next(2) == 0)
															{
																Main.dust[num678].alpha += 25;
															}
															Main.dust[num678].noGravity = true;
															Main.dust[num678].velocity *= 0.3f;
															Main.dust[num678].velocity += this.velocity * 0.5f;
															Main.dust[num678].position = this.center();
															Dust expr_1E13F_cp_0 = Main.dust[num678];
															expr_1E13F_cp_0.position.X = expr_1E13F_cp_0.position.X - num675;
															Dust expr_1E15E_cp_0 = Main.dust[num678];
															expr_1E15E_cp_0.position.Y = expr_1E15E_cp_0.position.Y - num676;
															Main.dust[num678].velocity *= 0.2f;
														}
														if (Main.rand.Next(4) == 0)
														{
															int num679 = 6;
															int num680 = Dust.NewDust(new Vector2(this.position.X + (float)num679, this.position.Y + (float)num679), this.width - num679 * 2, this.height - num679 * 2, 211, 0f, 0f, 75, default(Color), 0.65f);
															Main.dust[num680].velocity *= 0.5f;
															Main.dust[num680].velocity += this.velocity * 0.5f;
														}
													}
													return;
												}
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
			if (this.type == 358)
			{
				this.velocity = this.lastVelocity * 0.2f;
				for (int k = 0; k < 100; k++)
				{
					int num2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 211, 0f, 0f, 75, default(Color), 1.2f);
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num2].alpha += 25;
					}
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num2].alpha += 25;
					}
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num2].alpha += 25;
					}
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num2].scale = 0.6f;
					}
					else
					{
						Main.dust[num2].noGravity = true;
					}
					Main.dust[num2].velocity *= 0.3f;
					Main.dust[num2].velocity += this.velocity;
					Main.dust[num2].velocity *= 1f + (float)Main.rand.Next(-100, 101) * 0.01f;
					Dust expr_2CC_cp_0 = Main.dust[num2];
					expr_2CC_cp_0.velocity.X = expr_2CC_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.015f;
					Dust expr_2FA_cp_0 = Main.dust[num2];
					expr_2FA_cp_0.velocity.Y = expr_2FA_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.015f;
					Main.dust[num2].position = this.center();
				}
			}
			if (this.type == 344)
			{
				for (int l = 0; l < 3; l++)
				{
					int num3 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 197, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num3].noGravity = true;
					Main.dust[num3].scale = this.scale;
				}
			}
			else if (this.type == 343)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
				for (int m = 4; m < 31; m++)
				{
					float num4 = this.lastVelocity.X * (30f / (float)m);
					float num5 = this.lastVelocity.Y * (30f / (float)m);
					int num6 = Dust.NewDust(new Vector2(this.lastPosition.X - num4, this.lastPosition.Y - num5), 8, 8, 197, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.2f);
					Main.dust[num6].noGravity = true;
					Main.dust[num6].velocity *= 0.5f;
				}
			}
			else if (this.type == 349)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
				for (int n = 0; n < 3; n++)
				{
					int num7 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 76, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num7].noGravity = true;
					Main.dust[num7].noLight = true;
					Main.dust[num7].scale = 0.7f;
				}
			}
			if (this.type == 323)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num8 = 0; num8 < 20; num8++)
				{
					int num9 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 7, 0f, 0f, 0, default(Color), 1f);
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num9].noGravity = true;
						Main.dust[num9].scale = 1.3f;
						Main.dust[num9].velocity *= 1.5f;
						Main.dust[num9].velocity -= this.lastVelocity * 0.5f;
						Main.dust[num9].velocity *= 1.5f;
					}
					else
					{
						Main.dust[num9].velocity *= 0.75f;
						Main.dust[num9].velocity -= this.lastVelocity * 0.25f;
						Main.dust[num9].scale = 0.8f;
					}
				}
			}
			if (this.type == 346)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
				for (int num10 = 0; num10 < 10; num10++)
				{
					int num11 = 10;
					if (this.ai[1] == 1f)
					{
						num11 = 4;
					}
					int num12 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num11, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num12].noGravity = true;
				}
			}
			if (this.type == 335)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
				for (int num13 = 0; num13 < 10; num13++)
				{
					int num14 = 90 - (int)this.ai[1];
					int num15 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num14, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num15].noLight = true;
					Main.dust[num15].scale = 0.8f;
				}
			}
			if (this.type == 318)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num16 = 0; num16 < 10; num16++)
				{
					int num17 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 30, 0f, 0f, 0, default(Color), 1f);
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num17].noGravity = true;
					}
				}
			}
			else if (this.type == 311)
			{
				for (int num18 = 0; num18 < 5; num18++)
				{
					int num19 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 189, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num19].scale = 0.85f;
					Main.dust[num19].noGravity = true;
					Main.dust[num19].velocity += this.velocity * 0.5f;
				}
			}
			else if (this.type == 316)
			{
				for (int num20 = 0; num20 < 5; num20++)
				{
					int num21 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 195, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num21].scale = 0.85f;
					Main.dust[num21].noGravity = true;
					Main.dust[num21].velocity += this.velocity * 0.5f;
				}
			}
			else if (this.type == 184 || this.type == 195)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num22 = 0; num22 < 5; num22++)
				{
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 7, 0f, 0f, 0, default(Color), 1f);
				}
			}
			else if (this.type == 275 || this.type == 276)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num23 = 0; num23 < 5; num23++)
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
				for (int num24 = 0; num24 < 20; num24++)
				{
					int num25 = Dust.NewDust(this.position, this.width, this.height, 26, 0f, 0f, 100, default(Color), 1f);
					Main.dust[num25].noGravity = true;
					Main.dust[num25].velocity *= 1.2f;
					Main.dust[num25].scale = 1.3f;
					Main.dust[num25].velocity -= this.lastVelocity * 0.3f;
					num25 = Dust.NewDust(new Vector2(this.position.X + 4f, this.position.Y + 4f), this.width - 8, this.height - 8, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num25].noGravity = true;
					Main.dust[num25].velocity *= 3f;
				}
			}
			else if (this.type == 265)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 27);
				for (int num26 = 0; num26 < 15; num26++)
				{
					int num27 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 163, 0f, 0f, 100, default(Color), 1.2f);
					Main.dust[num27].noGravity = true;
					Main.dust[num27].velocity *= 1.2f;
					Main.dust[num27].velocity -= this.lastVelocity * 0.3f;
				}
			}
			else if (this.type == 355)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 27);
				for (int num28 = 0; num28 < 15; num28++)
				{
					int num29 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 205, 0f, 0f, 100, default(Color), 1.2f);
					Main.dust[num29].noGravity = true;
					Main.dust[num29].velocity *= 1.2f;
					Main.dust[num29].velocity -= this.lastVelocity * 0.3f;
				}
			}
			else if (this.type == 304)
			{
				for (int num30 = 0; num30 < 3; num30++)
				{
					int num31 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 182, 0f, 0f, 100, default(Color), 0.8f);
					Main.dust[num31].noGravity = true;
					Main.dust[num31].velocity *= 1.2f;
					Main.dust[num31].velocity -= this.lastVelocity * 0.3f;
				}
			}
			else if (this.type == 263)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
				for (int num32 = 0; num32 < 15; num32++)
				{
					int num33 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 92, this.velocity.X, this.velocity.Y, Main.rand.Next(0, 101), default(Color), 1f + (float)Main.rand.Next(40) * 0.01f);
					Main.dust[num33].noGravity = true;
					Main.dust[num33].velocity *= 2f;
				}
			}
			else if (this.type == 261)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num34 = 0; num34 < 5; num34++)
				{
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 148, 0f, 0f, 0, default(Color), 1f);
				}
			}
			else if (this.type == 229)
			{
				for (int num35 = 0; num35 < 25; num35++)
				{
					int num36 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 157, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num36].noGravity = true;
					Main.dust[num36].velocity *= 1.5f;
					Main.dust[num36].scale = 1.5f;
				}
			}
			else if (this.type == 239)
			{
				int num37 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), 2, 2, 154, 0f, 0f, 0, default(Color), 1f);
				Dust expr_13AB_cp_0 = Main.dust[num37];
				expr_13AB_cp_0.position.X = expr_13AB_cp_0.position.X - 2f;
				Main.dust[num37].alpha = 38;
				Main.dust[num37].velocity *= 0.1f;
				Main.dust[num37].velocity += -this.lastVelocity * 0.25f;
				Main.dust[num37].scale = 0.95f;
			}
			else if (this.type == 245)
			{
				int num38 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), 2, 2, 114, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num38].noGravity = true;
				Dust expr_14A9_cp_0 = Main.dust[num38];
				expr_14A9_cp_0.position.X = expr_14A9_cp_0.position.X - 2f;
				Main.dust[num38].alpha = 38;
				Main.dust[num38].velocity *= 0.1f;
				Main.dust[num38].velocity += -this.lastVelocity * 0.25f;
				Main.dust[num38].scale = 0.95f;
			}
			else if (this.type == 264)
			{
				int num39 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), 2, 2, 54, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num39].noGravity = true;
				Dust expr_15A7_cp_0 = Main.dust[num39];
				expr_15A7_cp_0.position.X = expr_15A7_cp_0.position.X - 2f;
				Main.dust[num39].alpha = 38;
				Main.dust[num39].velocity *= 0.1f;
				Main.dust[num39].velocity += -this.lastVelocity * 0.25f;
				Main.dust[num39].scale = 0.95f;
			}
			else if (this.type == 206 || this.type == 225)
			{
				Main.PlaySound(6, (int)this.position.X, (int)this.position.Y, 1);
				for (int num40 = 0; num40 < 5; num40++)
				{
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 40, 0f, 0f, 0, default(Color), 1f);
				}
			}
			else if (this.type == 227)
			{
				Main.PlaySound(6, (int)this.position.X, (int)this.position.Y, 1);
				for (int num41 = 0; num41 < 15; num41++)
				{
					int num42 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 157, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num42].noGravity = true;
					Main.dust[num42].velocity += this.lastVelocity;
					Main.dust[num42].scale = 1.5f;
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
				for (int num43 = 0; num43 < 10; num43++)
				{
					int num44 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 67, this.velocity.X, this.velocity.Y, 100, default(Color), 1f);
					if (num43 < 5)
					{
						Main.dust[num44].noGravity = true;
					}
					Main.dust[num44].velocity *= 0.2f;
				}
			}
			else if (this.type == 181 || this.type == 189)
			{
				for (int num45 = 0; num45 < 6; num45++)
				{
					int num46 = Dust.NewDust(this.position, this.width, this.height, 150, this.velocity.X, this.velocity.Y, 50, default(Color), 1f);
					Main.dust[num46].noGravity = true;
					Main.dust[num46].scale = 1f;
				}
			}
			else if (this.type == 178)
			{
				for (int num47 = 0; num47 < 85; num47++)
				{
					int num48 = Main.rand.Next(139, 143);
					int num49 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num48, this.velocity.X, this.velocity.Y, 0, default(Color), 1.2f);
					Dust expr_1A84_cp_0 = Main.dust[num49];
					expr_1A84_cp_0.velocity.X = expr_1A84_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					Dust expr_1AB2_cp_0 = Main.dust[num49];
					expr_1AB2_cp_0.velocity.Y = expr_1AB2_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					Dust expr_1AE0_cp_0 = Main.dust[num49];
					expr_1AE0_cp_0.velocity.X = expr_1AE0_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Dust expr_1B14_cp_0 = Main.dust[num49];
					expr_1B14_cp_0.velocity.Y = expr_1B14_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Dust expr_1B48_cp_0 = Main.dust[num49];
					expr_1B48_cp_0.velocity.X = expr_1B48_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
					Dust expr_1B76_cp_0 = Main.dust[num49];
					expr_1B76_cp_0.velocity.Y = expr_1B76_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
					Main.dust[num49].scale *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
				}
				for (int num50 = 0; num50 < 40; num50++)
				{
					int num51 = Main.rand.Next(276, 283);
					int num52 = Gore.NewGore(this.position, this.velocity, num51, 1f);
					Gore expr_1C1A_cp_0 = Main.gore[num52];
					expr_1C1A_cp_0.velocity.X = expr_1C1A_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					Gore expr_1C48_cp_0 = Main.gore[num52];
					expr_1C48_cp_0.velocity.Y = expr_1C48_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					Gore expr_1C76_cp_0 = Main.gore[num52];
					expr_1C76_cp_0.velocity.X = expr_1C76_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Gore expr_1CAA_cp_0 = Main.gore[num52];
					expr_1CAA_cp_0.velocity.Y = expr_1CAA_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Main.gore[num52].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
					Gore expr_1D0D_cp_0 = Main.gore[num52];
					expr_1D0D_cp_0.velocity.X = expr_1D0D_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
					Gore expr_1D3B_cp_0 = Main.gore[num52];
					expr_1D3B_cp_0.velocity.Y = expr_1D3B_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
				}
			}
			else if (this.type == 289)
			{
				for (int num53 = 0; num53 < 30; num53++)
				{
					int num54 = Main.rand.Next(139, 143);
					int num55 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num54, this.velocity.X, this.velocity.Y, 0, default(Color), 1.2f);
					Dust expr_1E05_cp_0 = Main.dust[num55];
					expr_1E05_cp_0.velocity.X = expr_1E05_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					Dust expr_1E33_cp_0 = Main.dust[num55];
					expr_1E33_cp_0.velocity.Y = expr_1E33_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					Dust expr_1E61_cp_0 = Main.dust[num55];
					expr_1E61_cp_0.velocity.X = expr_1E61_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Dust expr_1E95_cp_0 = Main.dust[num55];
					expr_1E95_cp_0.velocity.Y = expr_1E95_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Dust expr_1EC9_cp_0 = Main.dust[num55];
					expr_1EC9_cp_0.velocity.X = expr_1EC9_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
					Dust expr_1EF7_cp_0 = Main.dust[num55];
					expr_1EF7_cp_0.velocity.Y = expr_1EF7_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
					Main.dust[num55].scale *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
				}
				for (int num56 = 0; num56 < 15; num56++)
				{
					int num57 = Main.rand.Next(276, 283);
					int num58 = Gore.NewGore(this.position, this.velocity, num57, 1f);
					Gore expr_1F9B_cp_0 = Main.gore[num58];
					expr_1F9B_cp_0.velocity.X = expr_1F9B_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					Gore expr_1FC9_cp_0 = Main.gore[num58];
					expr_1FC9_cp_0.velocity.Y = expr_1FC9_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					Gore expr_1FF7_cp_0 = Main.gore[num58];
					expr_1FF7_cp_0.velocity.X = expr_1FF7_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Gore expr_202B_cp_0 = Main.gore[num58];
					expr_202B_cp_0.velocity.Y = expr_202B_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Main.gore[num58].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
					Gore expr_208E_cp_0 = Main.gore[num58];
					expr_208E_cp_0.velocity.X = expr_208E_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
					Gore expr_20BC_cp_0 = Main.gore[num58];
					expr_20BC_cp_0.velocity.Y = expr_20BC_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
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
					float num59 = -this.velocity.X;
					float num60 = -this.velocity.Y;
					float num61 = 1f;
					if (this.ai[0] <= 17f)
					{
						num61 = this.ai[0] / 17f;
					}
					int num62 = (int)(30f * num61);
					float num63 = 1f;
					if (this.ai[0] <= 30f)
					{
						num63 = this.ai[0] / 30f;
					}
					float num64 = 0.4f * num63;
					float num65 = num64;
					num60 += num65;
					for (int num66 = 0; num66 < num62; num66++)
					{
						float num67 = (float)Math.Sqrt((double)(num59 * num59 + num60 * num60));
						float num68 = 5.6f;
						if (Math.Abs(num59) + Math.Abs(num60) < 1f)
						{
							num68 *= Math.Abs(num59) + Math.Abs(num60) / 1f;
						}
						num67 = num68 / num67;
						num59 *= num67;
						num60 *= num67;
						Math.Atan2((double)num60, (double)num59);
						if ((float)num66 > this.ai[1])
						{
							for (int num69 = 0; num69 < 4; num69++)
							{
								int num70 = Dust.NewDust(vector, this.width, this.height, 129, 0f, 0f, 0, default(Color), 1f);
								Main.dust[num70].noGravity = true;
								Main.dust[num70].velocity *= 0.3f;
							}
						}
						vector.X += num59;
						vector.Y += num60;
						num59 = -this.velocity.X;
						num60 = -this.velocity.Y;
						num65 += num64;
						num60 += num65;
					}
				}
			}
			else if (this.type == 117)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num71 = 0; num71 < 10; num71++)
				{
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 26, 0f, 0f, 0, default(Color), 1f);
				}
			}
			else if (this.type == 166)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 51);
				for (int num72 = 0; num72 < 10; num72++)
				{
					int num73 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 76, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num73].noGravity = true;
					Main.dust[num73].velocity -= this.lastVelocity * 0.25f;
				}
			}
			else if (this.type == 158)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num74 = 0; num74 < 10; num74++)
				{
					int num75 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 9, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num75].noGravity = true;
					Main.dust[num75].velocity -= this.velocity * 0.5f;
				}
			}
			else if (this.type == 159)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num76 = 0; num76 < 10; num76++)
				{
					int num77 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 11, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num77].noGravity = true;
					Main.dust[num77].velocity -= this.velocity * 0.5f;
				}
			}
			else if (this.type == 160)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num78 = 0; num78 < 10; num78++)
				{
					int num79 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 19, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num79].noGravity = true;
					Main.dust[num79].velocity -= this.velocity * 0.5f;
				}
			}
			else if (this.type == 161)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num80 = 0; num80 < 10; num80++)
				{
					int num81 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 11, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num81].noGravity = true;
					Main.dust[num81].velocity -= this.velocity * 0.5f;
				}
			}
			else if (this.type >= 191 && this.type <= 194)
			{
				int num82 = Gore.NewGore(new Vector2(this.position.X - (float)(this.width / 2), this.position.Y - (float)(this.height / 2)), new Vector2(0f, 0f), Main.rand.Next(61, 64), this.scale);
				Main.gore[num82].velocity *= 0.1f;
			}
			else if (!Main.projPet[this.type])
			{
				if (this.type == 93)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num83 = 0; num83 < 10; num83++)
					{
						int num84 = Dust.NewDust(this.position, this.width, this.height, 57, 0f, 0f, 100, default(Color), 0.5f);
						Dust expr_2910_cp_0 = Main.dust[num84];
						expr_2910_cp_0.velocity.X = expr_2910_cp_0.velocity.X * 2f;
						Dust expr_292E_cp_0 = Main.dust[num84];
						expr_292E_cp_0.velocity.Y = expr_292E_cp_0.velocity.Y * 2f;
					}
				}
				else if (this.type == 99)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num85 = 0; num85 < 30; num85++)
					{
						int num86 = Dust.NewDust(this.position, this.width, this.height, 1, 0f, 0f, 0, default(Color), 1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num86].scale *= 1.4f;
						}
						this.velocity *= 1.9f;
					}
				}
				else if (this.type == 91 || this.type == 92)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num87 = 0; num87 < 10; num87++)
					{
						Dust.NewDust(this.position, this.width, this.height, 58, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, default(Color), 1.2f);
					}
					for (int num88 = 0; num88 < 3; num88++)
					{
						Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
					}
					if (this.type == 12 && this.damage < 500)
					{
						for (int num89 = 0; num89 < 10; num89++)
						{
							Dust.NewDust(this.position, this.width, this.height, 57, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, default(Color), 1.2f);
						}
						for (int num90 = 0; num90 < 3; num90++)
						{
							Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
						}
					}
					if ((this.type == 91 || (this.type == 92 && this.ai[0] > 0f)) && this.owner == Main.myPlayer)
					{
						float x = this.position.X + (float)Main.rand.Next(-400, 400);
						float y = this.position.Y - (float)Main.rand.Next(600, 900);
						Vector2 vector2 = new Vector2(x, y);
						float num91 = this.position.X + (float)(this.width / 2) - vector2.X;
						float num92 = this.position.Y + (float)(this.height / 2) - vector2.Y;
						int num93 = 22;
						float num94 = (float)Math.Sqrt((double)(num91 * num91 + num92 * num92));
						num94 = (float)num93 / num94;
						num91 *= num94;
						num92 *= num94;
						int num95 = this.damage;
						if (this.type == 91)
						{
							num95 = (int)((float)num95 * 0.5f);
						}
						int num96 = Projectile.NewProjectile(x, y, num91, num92, 92, num95, this.knockBack, this.owner, 0f, 0f);
						if (this.type == 91)
						{
							Main.projectile[num96].ai[1] = this.position.Y;
							Main.projectile[num96].ai[0] = 1f;
						}
						else
						{
							Main.projectile[num96].ai[1] = this.position.Y;
						}
					}
				}
				else if (this.type == 89)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num97 = 0; num97 < 5; num97++)
					{
						int num98 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 68, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num98].noGravity = true;
						Main.dust[num98].velocity *= 1.5f;
						Main.dust[num98].scale *= 0.9f;
					}
					if (this.type == 89 && this.owner == Main.myPlayer)
					{
						for (int num99 = 0; num99 < 3; num99++)
						{
							float num100 = -this.velocity.X * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
							float num101 = -this.velocity.Y * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
							Projectile.NewProjectile(this.position.X + num100, this.position.Y + num101, num100, num101, 90, (int)((double)this.damage * 0.5), 0f, this.owner, 0f, 0f);
						}
					}
				}
				else if (this.type == 177)
				{
					for (int num102 = 0; num102 < 20; num102++)
					{
						int num103 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 137, 0f, 0f, Main.rand.Next(0, 101), default(Color), 1f + (float)Main.rand.Next(-20, 40) * 0.01f);
						Main.dust[num103].velocity -= this.lastVelocity * 0.2f;
						if (Main.rand.Next(3) == 0)
						{
							Main.dust[num103].scale *= 0.8f;
							Main.dust[num103].velocity *= 0.5f;
						}
						else
						{
							Main.dust[num103].noGravity = true;
						}
					}
				}
				else if (this.type == 119 || this.type == 118 || this.type == 128 || this.type == 359)
				{
					int num104 = 10;
					if (this.type == 119 || this.type == 359)
					{
						num104 = 20;
					}
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
					for (int num105 = 0; num105 < num104; num105++)
					{
						int num106 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 92, 0f, 0f, 0, default(Color), 1f);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num106].velocity *= 2f;
							Main.dust[num106].noGravity = true;
							Main.dust[num106].scale *= 1.75f;
						}
						else
						{
							Main.dust[num106].scale *= 0.5f;
						}
					}
				}
				else if (this.type == 309)
				{
					int num107 = 10;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
					for (int num108 = 0; num108 < num107; num108++)
					{
						int num109 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 185, 0f, 0f, 0, default(Color), 1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num109].velocity *= 2f;
							Main.dust[num109].noGravity = true;
							Main.dust[num109].scale *= 1.75f;
						}
					}
				}
				else if (this.type == 308)
				{
					int num110 = 80;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
					for (int num111 = 0; num111 < num110; num111++)
					{
						int num112 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 16f), this.width, this.height - 16, 185, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num112].velocity *= 2f;
						Main.dust[num112].noGravity = true;
						Main.dust[num112].scale *= 1.15f;
					}
				}
				else if (this.aiStyle == 29)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					int num113 = this.type - 121 + 86;
					for (int num114 = 0; num114 < 15; num114++)
					{
						int num115 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num113, this.lastVelocity.X, this.lastVelocity.Y, 50, default(Color), 1.2f);
						Main.dust[num115].noGravity = true;
						Main.dust[num115].scale *= 1.25f;
						Main.dust[num115].velocity *= 0.5f;
					}
				}
				else if (this.type == 337)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
					for (int num116 = 0; num116 < 10; num116++)
					{
						int num117 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 197, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num117].noGravity = true;
					}
				}
				else if (this.type == 80)
				{
					if (this.ai[0] >= 0f)
					{
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
						for (int num118 = 0; num118 < 10; num118++)
						{
							Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0f, 0f, 0, default(Color), 1f);
						}
					}
					int num119 = (int)this.position.X / 16;
					int num120 = (int)this.position.Y / 16;
					if (Main.tile[num119, num120] == null)
					{
						Main.tile[num119, num120] = new Tile();
					}
					if (Main.tile[num119, num120].type == 127 && Main.tile[num119, num120].active())
					{
						WorldGen.KillTile(num119, num120, false, false, false);
					}
				}
				else if (this.type == 76 || this.type == 77 || this.type == 78)
				{
					for (int num121 = 0; num121 < 5; num121++)
					{
						int num122 = Dust.NewDust(this.position, this.width, this.height, 27, 0f, 0f, 80, default(Color), 1.5f);
						Main.dust[num122].noGravity = true;
					}
				}
				else if (this.type == 55)
				{
					for (int num123 = 0; num123 < 5; num123++)
					{
						int num124 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 18, 0f, 0f, 0, default(Color), 1.5f);
						Main.dust[num124].noGravity = true;
					}
				}
				else if (this.type == 51 || this.type == 267)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num125 = 0; num125 < 5; num125++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0, 0f, 0f, 0, default(Color), 0.7f);
					}
				}
				else if (this.type == 2 || this.type == 82)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num126 = 0; num126 < 20; num126++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
					}
				}
				else if (this.type == 172)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num127 = 0; num127 < 20; num127++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 135, 0f, 0f, 100, default(Color), 1f);
					}
				}
				else if (this.type == 103)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num128 = 0; num128 < 20; num128++)
					{
						int num129 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 75, 0f, 0f, 100, default(Color), 1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num129].scale *= 2.5f;
							Main.dust[num129].noGravity = true;
							Main.dust[num129].velocity *= 5f;
						}
					}
				}
				else if (this.type == 278)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num130 = 0; num130 < 20; num130++)
					{
						int num131 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 169, 0f, 0f, 100, default(Color), 1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num131].scale *= 1.5f;
							Main.dust[num131].noGravity = true;
							Main.dust[num131].velocity *= 5f;
						}
					}
				}
				else if (this.type == 3 || this.type == 48 || this.type == 54)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num132 = 0; num132 < 10; num132++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 1, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 0, default(Color), 0.75f);
					}
				}
				else if (this.type == 330)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num133 = 0; num133 < 10; num133++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 0, default(Color), 0.75f);
					}
				}
				else if (this.type == 4)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num134 = 0; num134 < 10; num134++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 150, default(Color), 1.1f);
					}
				}
				else if (this.type == 5)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num135 = 0; num135 < 60; num135++)
					{
						int num136 = Main.rand.Next(3);
						if (num136 == 0)
						{
							num136 = 15;
						}
						else if (num136 == 1)
						{
							num136 = 57;
						}
						else
						{
							num136 = 58;
						}
						Dust.NewDust(this.position, this.width, this.height, num136, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, default(Color), 1.5f);
					}
				}
				else if (this.type == 9 || this.type == 12)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num137 = 0; num137 < 10; num137++)
					{
						Dust.NewDust(this.position, this.width, this.height, 58, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, default(Color), 1.2f);
					}
					for (int num138 = 0; num138 < 3; num138++)
					{
						Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
					}
					if (this.type == 12 && this.damage < 100)
					{
						for (int num139 = 0; num139 < 10; num139++)
						{
							Dust.NewDust(this.position, this.width, this.height, 57, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, default(Color), 1.2f);
						}
						for (int num140 = 0; num140 < 3; num140++)
						{
							Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
						}
					}
				}
				else if (this.type == 281)
				{
					Main.PlaySound(4, (int)this.position.X, (int)this.position.Y, 1);
					int num141 = Gore.NewGore(this.position, new Vector2((float)Main.rand.Next(-20, 21) * 0.2f, (float)Main.rand.Next(-20, 21) * 0.2f), 76, 1f);
					Main.gore[num141].velocity -= this.velocity * 0.5f;
					num141 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2((float)Main.rand.Next(-20, 21) * 0.2f, (float)Main.rand.Next(-20, 21) * 0.2f), 77, 1f);
					Main.gore[num141].velocity -= this.velocity * 0.5f;
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
					num141 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num141].velocity *= 0.4f;
					Gore expr_426C_cp_0 = Main.gore[num141];
					expr_426C_cp_0.velocity.X = expr_426C_cp_0.velocity.X + 1f;
					Gore expr_428A_cp_0 = Main.gore[num141];
					expr_428A_cp_0.velocity.Y = expr_428A_cp_0.velocity.Y + 1f;
					num141 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num141].velocity *= 0.4f;
					Gore expr_4308_cp_0 = Main.gore[num141];
					expr_4308_cp_0.velocity.X = expr_4308_cp_0.velocity.X - 1f;
					Gore expr_4326_cp_0 = Main.gore[num141];
					expr_4326_cp_0.velocity.Y = expr_4326_cp_0.velocity.Y + 1f;
					num141 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num141].velocity *= 0.4f;
					Gore expr_43A4_cp_0 = Main.gore[num141];
					expr_43A4_cp_0.velocity.X = expr_43A4_cp_0.velocity.X + 1f;
					Gore expr_43C2_cp_0 = Main.gore[num141];
					expr_43C2_cp_0.velocity.Y = expr_43C2_cp_0.velocity.Y - 1f;
					num141 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num141].velocity *= 0.4f;
					Gore expr_4440_cp_0 = Main.gore[num141];
					expr_4440_cp_0.velocity.X = expr_4440_cp_0.velocity.X - 1f;
					Gore expr_445E_cp_0 = Main.gore[num141];
					expr_445E_cp_0.velocity.Y = expr_445E_cp_0.velocity.Y - 1f;
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
					for (int num146 = 0; num146 < 20; num146++)
					{
						int num147 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num147].velocity *= 1.4f;
					}
					for (int num148 = 0; num148 < 10; num148++)
					{
						int num149 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num149].noGravity = true;
						Main.dust[num149].velocity *= 5f;
						num149 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num149].velocity *= 3f;
					}
					int num150 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num150].velocity *= 0.4f;
					Gore expr_4711_cp_0 = Main.gore[num150];
					expr_4711_cp_0.velocity.X = expr_4711_cp_0.velocity.X + 1f;
					Gore expr_472F_cp_0 = Main.gore[num150];
					expr_472F_cp_0.velocity.Y = expr_472F_cp_0.velocity.Y + 1f;
					num150 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num150].velocity *= 0.4f;
					Gore expr_47AD_cp_0 = Main.gore[num150];
					expr_47AD_cp_0.velocity.X = expr_47AD_cp_0.velocity.X - 1f;
					Gore expr_47CB_cp_0 = Main.gore[num150];
					expr_47CB_cp_0.velocity.Y = expr_47CB_cp_0.velocity.Y + 1f;
					num150 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num150].velocity *= 0.4f;
					Gore expr_4849_cp_0 = Main.gore[num150];
					expr_4849_cp_0.velocity.X = expr_4849_cp_0.velocity.X + 1f;
					Gore expr_4867_cp_0 = Main.gore[num150];
					expr_4867_cp_0.velocity.Y = expr_4867_cp_0.velocity.Y - 1f;
					num150 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num150].velocity *= 0.4f;
					Gore expr_48E5_cp_0 = Main.gore[num150];
					expr_48E5_cp_0.velocity.X = expr_48E5_cp_0.velocity.X - 1f;
					Gore expr_4903_cp_0 = Main.gore[num150];
					expr_4903_cp_0.velocity.Y = expr_4903_cp_0.velocity.Y - 1f;
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
					for (int num151 = 0; num151 < 20; num151++)
					{
						int num152 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num152].velocity *= 1.4f;
					}
					for (int num153 = 0; num153 < 10; num153++)
					{
						int num154 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num154].noGravity = true;
						Main.dust[num154].velocity *= 5f;
						num154 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num154].velocity *= 3f;
					}
					int num155 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num155].velocity *= 0.4f;
					Gore expr_4BB6_cp_0 = Main.gore[num155];
					expr_4BB6_cp_0.velocity.X = expr_4BB6_cp_0.velocity.X + 1f;
					Gore expr_4BD4_cp_0 = Main.gore[num155];
					expr_4BD4_cp_0.velocity.Y = expr_4BD4_cp_0.velocity.Y + 1f;
					num155 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num155].velocity *= 0.4f;
					Gore expr_4C52_cp_0 = Main.gore[num155];
					expr_4C52_cp_0.velocity.X = expr_4C52_cp_0.velocity.X - 1f;
					Gore expr_4C70_cp_0 = Main.gore[num155];
					expr_4C70_cp_0.velocity.Y = expr_4C70_cp_0.velocity.Y + 1f;
					num155 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num155].velocity *= 0.4f;
					Gore expr_4CEE_cp_0 = Main.gore[num155];
					expr_4CEE_cp_0.velocity.X = expr_4CEE_cp_0.velocity.X + 1f;
					Gore expr_4D0C_cp_0 = Main.gore[num155];
					expr_4D0C_cp_0.velocity.Y = expr_4D0C_cp_0.velocity.Y - 1f;
					num155 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num155].velocity *= 0.4f;
					Gore expr_4D8A_cp_0 = Main.gore[num155];
					expr_4D8A_cp_0.velocity.X = expr_4D8A_cp_0.velocity.X - 1f;
					Gore expr_4DA8_cp_0 = Main.gore[num155];
					expr_4DA8_cp_0.velocity.Y = expr_4DA8_cp_0.velocity.Y - 1f;
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
					for (int num156 = 0; num156 < 10; num156++)
					{
						int num157 = Dust.NewDust(this.position, this.width, this.height, 171, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num157].scale = (float)Main.rand.Next(1, 10) * 0.1f;
						Main.dust[num157].noGravity = true;
						Main.dust[num157].fadeIn = 1.5f;
						Main.dust[num157].velocity *= 0.75f;
					}
				}
				else if (this.type == 284)
				{
					for (int num158 = 0; num158 < 10; num158++)
					{
						int num159 = Main.rand.Next(139, 143);
						int num160 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num159, -this.velocity.X * 0.3f, -this.velocity.Y * 0.3f, 0, default(Color), 1.2f);
						Dust expr_4FD7_cp_0 = Main.dust[num160];
						expr_4FD7_cp_0.velocity.X = expr_4FD7_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
						Dust expr_5005_cp_0 = Main.dust[num160];
						expr_5005_cp_0.velocity.Y = expr_5005_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
						Dust expr_5033_cp_0 = Main.dust[num160];
						expr_5033_cp_0.velocity.X = expr_5033_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
						Dust expr_5067_cp_0 = Main.dust[num160];
						expr_5067_cp_0.velocity.Y = expr_5067_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
						Dust expr_509B_cp_0 = Main.dust[num160];
						expr_509B_cp_0.velocity.X = expr_509B_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
						Dust expr_50C9_cp_0 = Main.dust[num160];
						expr_50C9_cp_0.velocity.Y = expr_50C9_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
						Main.dust[num160].scale *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
					}
					for (int num161 = 0; num161 < 5; num161++)
					{
						int num162 = Main.rand.Next(276, 283);
						int num163 = Gore.NewGore(this.position, -this.velocity * 0.3f, num162, 1f);
						Gore expr_517C_cp_0 = Main.gore[num163];
						expr_517C_cp_0.velocity.X = expr_517C_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
						Gore expr_51AA_cp_0 = Main.gore[num163];
						expr_51AA_cp_0.velocity.Y = expr_51AA_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
						Gore expr_51D8_cp_0 = Main.gore[num163];
						expr_51D8_cp_0.velocity.X = expr_51D8_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
						Gore expr_520C_cp_0 = Main.gore[num163];
						expr_520C_cp_0.velocity.Y = expr_520C_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
						Main.gore[num163].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
						Gore expr_526F_cp_0 = Main.gore[num163];
						expr_526F_cp_0.velocity.X = expr_526F_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
						Gore expr_529D_cp_0 = Main.gore[num163];
						expr_529D_cp_0.velocity.Y = expr_529D_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
					}
				}
				else if (this.type == 286)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int num164 = 0; num164 < 7; num164++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
					}
					for (int num165 = 0; num165 < 3; num165++)
					{
						int num166 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num166].noGravity = true;
						Main.dust[num166].velocity *= 3f;
						num166 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num166].velocity *= 2f;
					}
					int num167 = Gore.NewGore(new Vector2(this.position.X - 10f, this.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num167].velocity *= 0.3f;
					Gore expr_54D2_cp_0 = Main.gore[num167];
					expr_54D2_cp_0.velocity.X = expr_54D2_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.05f;
					Gore expr_5500_cp_0 = Main.gore[num167];
					expr_5500_cp_0.velocity.Y = expr_5500_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.05f;
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
				else if (this.type == 14 || this.type == 20 || this.type == 36 || this.type == 83 || this.type == 84 || this.type == 104 || this.type == 279 || this.type == 100 || this.type == 110 || this.type == 180 || this.type == 207 || this.type == 357 || this.type == 242 || this.type == 302 || this.type == 257 || this.type == 259 || this.type == 285 || this.type == 287)
				{
					Collision.HitTiles(this.position, this.velocity, this.width, this.height);
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
				}
				else if (this.type == 15 || this.type == 34 || this.type == 321)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num168 = 0; num168 < 20; num168++)
					{
						int num169 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num169].noGravity = true;
						Main.dust[num169].velocity *= 2f;
						num169 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, default(Color), 1f);
						Main.dust[num169].velocity *= 2f;
					}
				}
				else if (this.type == 253)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num170 = 0; num170 < 20; num170++)
					{
						int num171 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 135, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num171].noGravity = true;
						Main.dust[num171].velocity *= 2f;
						num171 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 135, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, default(Color), 1f);
						Main.dust[num171].velocity *= 2f;
					}
				}
				else if (this.type == 95 || this.type == 96)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num172 = 0; num172 < 20; num172++)
					{
						int num173 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 75, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, default(Color), 2f * this.scale);
						Main.dust[num173].noGravity = true;
						Main.dust[num173].velocity *= 2f;
						num173 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 75, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, default(Color), 1f * this.scale);
						Main.dust[num173].velocity *= 2f;
					}
				}
				else if (this.type == 79)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num174 = 0; num174 < 20; num174++)
					{
						int num175 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 66, 0f, 0f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 2f);
						Main.dust[num175].noGravity = true;
						Main.dust[num175].velocity *= 4f;
					}
				}
				else if (this.type == 16)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num176 = 0; num176 < 20; num176++)
					{
						int num177 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 15, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num177].noGravity = true;
						Main.dust[num177].velocity *= 2f;
						num177 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 15, 0f, 0f, 100, default(Color), 1f);
					}
				}
				else if (this.type == 17)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num178 = 0; num178 < 5; num178++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0, 0f, 0f, 0, default(Color), 1f);
					}
				}
				else if (this.type == 31 || this.type == 42)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num179 = 0; num179 < 5; num179++)
					{
						int num180 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 32, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num180].velocity *= 0.6f;
					}
				}
				else if (this.type == 109)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num181 = 0; num181 < 5; num181++)
					{
						int num182 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 51, 0f, 0f, 0, default(Color), 0.6f);
						Main.dust[num182].velocity *= 0.6f;
					}
				}
				else if (this.type == 39)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num183 = 0; num183 < 5; num183++)
					{
						int num184 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 38, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num184].velocity *= 0.6f;
					}
				}
				else if (this.type == 71)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num185 = 0; num185 < 5; num185++)
					{
						int num186 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 53, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num186].velocity *= 0.6f;
					}
				}
				else if (this.type == 40)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num187 = 0; num187 < 5; num187++)
					{
						int num188 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 36, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num188].velocity *= 0.6f;
					}
				}
				else if (this.type == 21)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num189 = 0; num189 < 10; num189++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 26, 0f, 0f, 0, default(Color), 0.8f);
					}
				}
				else if (this.type == 24)
				{
					for (int num190 = 0; num190 < 10; num190++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 1, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 0, default(Color), 0.75f);
					}
				}
				else if (this.type == 27)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num191 = 0; num191 < 30; num191++)
					{
						int num192 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 172, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 100, default(Color), 1f);
						Main.dust[num192].noGravity = true;
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 172, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 100, default(Color), 0.5f);
					}
				}
				else if (this.type == 38)
				{
					for (int num193 = 0; num193 < 10; num193++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 42, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 0, default(Color), 1f);
					}
				}
				else if (this.type == 44 || this.type == 45)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num194 = 0; num194 < 30; num194++)
					{
						int num195 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 27, this.velocity.X, this.velocity.Y, 100, default(Color), 1.7f);
						Main.dust[num195].noGravity = true;
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 27, this.velocity.X, this.velocity.Y, 100, default(Color), 1f);
					}
				}
				else if (this.type == 41)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int num196 = 0; num196 < 10; num196++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
					}
					for (int num197 = 0; num197 < 5; num197++)
					{
						int num198 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num198].noGravity = true;
						Main.dust[num198].velocity *= 3f;
						num198 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num198].velocity *= 2f;
					}
					int num199 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num199].velocity *= 0.4f;
					Gore expr_6716_cp_0 = Main.gore[num199];
					expr_6716_cp_0.velocity.X = expr_6716_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.1f;
					Gore expr_6744_cp_0 = Main.gore[num199];
					expr_6744_cp_0.velocity.Y = expr_6744_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.1f;
					num199 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num199].velocity *= 0.4f;
					Gore expr_67D2_cp_0 = Main.gore[num199];
					expr_67D2_cp_0.velocity.X = expr_67D2_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.1f;
					Gore expr_6800_cp_0 = Main.gore[num199];
					expr_6800_cp_0.velocity.Y = expr_6800_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.1f;
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
					for (int num200 = 0; num200 < 20; num200++)
					{
						int num201 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 184, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num201].scale *= 1.1f;
						Main.dust[num201].noGravity = true;
					}
					for (int num202 = 0; num202 < 30; num202++)
					{
						int num203 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 184, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num203].velocity *= 2.5f;
						Main.dust[num203].scale *= 0.8f;
						Main.dust[num203].noGravity = true;
					}
					if (this.owner == Main.myPlayer)
					{
						int num204 = 2;
						if (Main.rand.Next(10) == 0)
						{
							num204++;
						}
						if (Main.rand.Next(10) == 0)
						{
							num204++;
						}
						if (Main.rand.Next(10) == 0)
						{
							num204++;
						}
						for (int num205 = 0; num205 < num204; num205++)
						{
							float num206 = (float)Main.rand.Next(-35, 36) * 0.02f;
							float num207 = (float)Main.rand.Next(-35, 36) * 0.02f;
							num206 *= 10f;
							num207 *= 10f;
							Projectile.NewProjectile(this.position.X, this.position.Y, num206, num207, 307, (int)((double)this.damage * 0.7), (float)((int)((double)this.knockBack * 0.35)), Main.myPlayer, 0f, 0f);
						}
					}
				}
				else if (this.type == 183)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int num208 = 0; num208 < 20; num208++)
					{
						int num209 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num209].velocity *= 1f;
					}
					int num210 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Gore expr_6C29_cp_0 = Main.gore[num210];
					expr_6C29_cp_0.velocity.X = expr_6C29_cp_0.velocity.X + 1f;
					Gore expr_6C47_cp_0 = Main.gore[num210];
					expr_6C47_cp_0.velocity.Y = expr_6C47_cp_0.velocity.Y + 1f;
					Main.gore[num210].velocity *= 0.3f;
					num210 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Gore expr_6CC5_cp_0 = Main.gore[num210];
					expr_6CC5_cp_0.velocity.X = expr_6CC5_cp_0.velocity.X - 1f;
					Gore expr_6CE3_cp_0 = Main.gore[num210];
					expr_6CE3_cp_0.velocity.Y = expr_6CE3_cp_0.velocity.Y + 1f;
					Main.gore[num210].velocity *= 0.3f;
					num210 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Gore expr_6D61_cp_0 = Main.gore[num210];
					expr_6D61_cp_0.velocity.X = expr_6D61_cp_0.velocity.X + 1f;
					Gore expr_6D7F_cp_0 = Main.gore[num210];
					expr_6D7F_cp_0.velocity.Y = expr_6D7F_cp_0.velocity.Y - 1f;
					Main.gore[num210].velocity *= 0.3f;
					num210 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Gore expr_6DFD_cp_0 = Main.gore[num210];
					expr_6DFD_cp_0.velocity.X = expr_6DFD_cp_0.velocity.X - 1f;
					Gore expr_6E1B_cp_0 = Main.gore[num210];
					expr_6E1B_cp_0.velocity.Y = expr_6E1B_cp_0.velocity.Y - 1f;
					Main.gore[num210].velocity *= 0.3f;
					if (this.owner == Main.myPlayer)
					{
						int num211 = Main.rand.Next(15, 25);
						for (int num212 = 0; num212 < num211; num212++)
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
						for (int num213 = 0; num213 < 400; num213++)
						{
							float num214 = 16f;
							if (num213 < 300)
							{
								num214 = 12f;
							}
							if (num213 < 200)
							{
								num214 = 8f;
							}
							if (num213 < 100)
							{
								num214 = 4f;
							}
							int num215 = 130;
							int num216 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, num215, 0f, 0f, 100, default(Color), 1f);
							float num217 = Main.dust[num216].velocity.X;
							float num218 = Main.dust[num216].velocity.Y;
							if (num217 == 0f && num218 == 0f)
							{
								num217 = 1f;
							}
							float num219 = (float)Math.Sqrt((double)(num217 * num217 + num218 * num218));
							num219 = num214 / num219;
							num217 *= num219;
							num218 *= num219;
							Main.dust[num216].velocity *= 0.5f;
							Dust expr_705A_cp_0 = Main.dust[num216];
							expr_705A_cp_0.velocity.X = expr_705A_cp_0.velocity.X + num217;
							Dust expr_7075_cp_0 = Main.dust[num216];
							expr_7075_cp_0.velocity.Y = expr_7075_cp_0.velocity.Y + num218;
							Main.dust[num216].scale = 1.3f;
							Main.dust[num216].noGravity = true;
						}
					}
					if (this.type == 168)
					{
						for (int num220 = 0; num220 < 400; num220++)
						{
							float num221 = 2f * ((float)num220 / 100f);
							if (num220 > 100)
							{
								num221 = 10f;
							}
							if (num220 > 250)
							{
								num221 = 13f;
							}
							int num222 = 131;
							int num223 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, num222, 0f, 0f, 100, default(Color), 1f);
							float num224 = Main.dust[num223].velocity.X;
							float num225 = Main.dust[num223].velocity.Y;
							if (num224 == 0f && num225 == 0f)
							{
								num224 = 1f;
							}
							float num226 = (float)Math.Sqrt((double)(num224 * num224 + num225 * num225));
							num226 = num221 / num226;
							if (num220 <= 200)
							{
								num224 *= num226;
								num225 *= num226;
							}
							else
							{
								num224 = num224 * num226 * 1.25f;
								num225 = num225 * num226 * 0.75f;
							}
							Main.dust[num223].velocity *= 0.5f;
							Dust expr_7200_cp_0 = Main.dust[num223];
							expr_7200_cp_0.velocity.X = expr_7200_cp_0.velocity.X + num224;
							Dust expr_721B_cp_0 = Main.dust[num223];
							expr_721B_cp_0.velocity.Y = expr_721B_cp_0.velocity.Y + num225;
							if (num220 > 100)
							{
								Main.dust[num223].scale = 1.3f;
								Main.dust[num223].noGravity = true;
							}
						}
					}
					if (this.type == 169)
					{
						for (int num227 = 0; num227 < 400; num227++)
						{
							int num228 = 132;
							float num229 = 14f;
							if (num227 > 100)
							{
								num229 = 10f;
							}
							if (num227 > 100)
							{
								num228 = 133;
							}
							if (num227 > 200)
							{
								num229 = 6f;
							}
							if (num227 > 200)
							{
								num228 = 132;
							}
							if (num227 > 300)
							{
								num229 = 6f;
							}
							if (num227 > 300)
							{
								num228 = 133;
							}
							int num230 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, num228, 0f, 0f, 100, default(Color), 1f);
							float num231 = Main.dust[num230].velocity.X;
							float num232 = Main.dust[num230].velocity.Y;
							if (num231 == 0f && num232 == 0f)
							{
								num231 = 1f;
							}
							float num233 = (float)Math.Sqrt((double)(num231 * num231 + num232 * num232));
							num233 = num229 / num233;
							if (num227 > 300)
							{
								num231 = num231 * num233 * 0.5f;
								num232 *= num233;
							}
							else if (num227 > 200)
							{
								num231 *= num233;
								num232 = num232 * num233 * 0.5f;
							}
							else
							{
								num231 *= num233;
								num232 *= num233;
							}
							Main.dust[num230].velocity *= 0.5f;
							Dust expr_73F8_cp_0 = Main.dust[num230];
							expr_73F8_cp_0.velocity.X = expr_73F8_cp_0.velocity.X + num231;
							Dust expr_7413_cp_0 = Main.dust[num230];
							expr_7413_cp_0.velocity.Y = expr_7413_cp_0.velocity.Y + num232;
							if (num227 <= 200)
							{
								Main.dust[num230].scale = 1.3f;
								Main.dust[num230].noGravity = true;
							}
						}
					}
					if (this.type == 170)
					{
						for (int num234 = 0; num234 < 400; num234++)
						{
							int num235 = 133;
							float num236 = 16f;
							if (num234 > 100)
							{
								num236 = 11f;
							}
							if (num234 > 100)
							{
								num235 = 134;
							}
							if (num234 > 200)
							{
								num236 = 8f;
							}
							if (num234 > 200)
							{
								num235 = 133;
							}
							if (num234 > 300)
							{
								num236 = 5f;
							}
							if (num234 > 300)
							{
								num235 = 134;
							}
							int num237 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, num235, 0f, 0f, 100, default(Color), 1f);
							float num238 = Main.dust[num237].velocity.X;
							float num239 = Main.dust[num237].velocity.Y;
							if (num238 == 0f && num239 == 0f)
							{
								num238 = 1f;
							}
							float num240 = (float)Math.Sqrt((double)(num238 * num238 + num239 * num239));
							num240 = num236 / num240;
							if (num234 > 300)
							{
								num238 = num238 * num240 * 0.7f;
								num239 *= num240;
							}
							else if (num234 > 200)
							{
								num238 *= num240;
								num239 = num239 * num240 * 0.7f;
							}
							else if (num234 > 100)
							{
								num238 = num238 * num240 * 0.7f;
								num239 *= num240;
							}
							else
							{
								num238 *= num240;
								num239 = num239 * num240 * 0.7f;
							}
							Main.dust[num237].velocity *= 0.5f;
							Dust expr_762B_cp_0 = Main.dust[num237];
							expr_762B_cp_0.velocity.X = expr_762B_cp_0.velocity.X + num238;
							Dust expr_7646_cp_0 = Main.dust[num237];
							expr_7646_cp_0.velocity.Y = expr_7646_cp_0.velocity.Y + num239;
							if (Main.rand.Next(3) != 0)
							{
								Main.dust[num237].scale = 1.3f;
								Main.dust[num237].noGravity = true;
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
					for (int num241 = 0; num241 < 30; num241++)
					{
						int num242 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num242].velocity *= 1.4f;
					}
					for (int num243 = 0; num243 < 20; num243++)
					{
						int num244 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 3.5f);
						Main.dust[num244].noGravity = true;
						Main.dust[num244].velocity *= 7f;
						num244 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num244].velocity *= 3f;
					}
					for (int num245 = 0; num245 < 2; num245++)
					{
						float scaleFactor = 0.4f;
						if (num245 == 1)
						{
							scaleFactor = 0.8f;
						}
						int num246 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num246].velocity *= scaleFactor;
						Gore expr_7A01_cp_0 = Main.gore[num246];
						expr_7A01_cp_0.velocity.X = expr_7A01_cp_0.velocity.X + 1f;
						Gore expr_7A21_cp_0 = Main.gore[num246];
						expr_7A21_cp_0.velocity.Y = expr_7A21_cp_0.velocity.Y + 1f;
						num246 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num246].velocity *= scaleFactor;
						Gore expr_7AA4_cp_0 = Main.gore[num246];
						expr_7AA4_cp_0.velocity.X = expr_7AA4_cp_0.velocity.X - 1f;
						Gore expr_7AC4_cp_0 = Main.gore[num246];
						expr_7AC4_cp_0.velocity.Y = expr_7AC4_cp_0.velocity.Y + 1f;
						num246 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num246].velocity *= scaleFactor;
						Gore expr_7B47_cp_0 = Main.gore[num246];
						expr_7B47_cp_0.velocity.X = expr_7B47_cp_0.velocity.X + 1f;
						Gore expr_7B67_cp_0 = Main.gore[num246];
						expr_7B67_cp_0.velocity.Y = expr_7B67_cp_0.velocity.Y - 1f;
						num246 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num246].velocity *= scaleFactor;
						Gore expr_7BEA_cp_0 = Main.gore[num246];
						expr_7BEA_cp_0.velocity.X = expr_7BEA_cp_0.velocity.X - 1f;
						Gore expr_7C0A_cp_0 = Main.gore[num246];
						expr_7C0A_cp_0.velocity.Y = expr_7C0A_cp_0.velocity.Y - 1f;
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
					for (int num247 = 0; num247 < 30; num247++)
					{
						int num248 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num248].velocity *= 1.4f;
					}
					for (int num249 = 0; num249 < 20; num249++)
					{
						int num250 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 3.5f);
						Main.dust[num250].noGravity = true;
						Main.dust[num250].velocity *= 7f;
						num250 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num250].velocity *= 3f;
					}
					for (int num251 = 0; num251 < 2; num251++)
					{
						float scaleFactor2 = 0.4f;
						if (num251 == 1)
						{
							scaleFactor2 = 0.8f;
						}
						int num252 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num252].velocity *= scaleFactor2;
						Gore expr_7FFE_cp_0 = Main.gore[num252];
						expr_7FFE_cp_0.velocity.X = expr_7FFE_cp_0.velocity.X + 1f;
						Gore expr_801E_cp_0 = Main.gore[num252];
						expr_801E_cp_0.velocity.Y = expr_801E_cp_0.velocity.Y + 1f;
						num252 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num252].velocity *= scaleFactor2;
						Gore expr_80A1_cp_0 = Main.gore[num252];
						expr_80A1_cp_0.velocity.X = expr_80A1_cp_0.velocity.X - 1f;
						Gore expr_80C1_cp_0 = Main.gore[num252];
						expr_80C1_cp_0.velocity.Y = expr_80C1_cp_0.velocity.Y + 1f;
						num252 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num252].velocity *= scaleFactor2;
						Gore expr_8144_cp_0 = Main.gore[num252];
						expr_8144_cp_0.velocity.X = expr_8144_cp_0.velocity.X + 1f;
						Gore expr_8164_cp_0 = Main.gore[num252];
						expr_8164_cp_0.velocity.Y = expr_8164_cp_0.velocity.Y - 1f;
						num252 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num252].velocity *= scaleFactor2;
						Gore expr_81E7_cp_0 = Main.gore[num252];
						expr_81E7_cp_0.velocity.X = expr_81E7_cp_0.velocity.X - 1f;
						Gore expr_8207_cp_0 = Main.gore[num252];
						expr_8207_cp_0.velocity.Y = expr_8207_cp_0.velocity.Y - 1f;
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
					for (int num253 = 0; num253 < 40; num253++)
					{
						int num254 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num254].velocity *= 3f;
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num254].scale = 0.5f;
							Main.dust[num254].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
						}
					}
					for (int num255 = 0; num255 < 70; num255++)
					{
						int num256 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 3f);
						Main.dust[num256].noGravity = true;
						Main.dust[num256].velocity *= 5f;
						num256 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num256].velocity *= 2f;
					}
					for (int num257 = 0; num257 < 3; num257++)
					{
						float scaleFactor3 = 0.33f;
						if (num257 == 1)
						{
							scaleFactor3 = 0.66f;
						}
						if (num257 == 2)
						{
							scaleFactor3 = 1f;
						}
						int num258 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num258].velocity *= scaleFactor3;
						Gore expr_85E2_cp_0 = Main.gore[num258];
						expr_85E2_cp_0.velocity.X = expr_85E2_cp_0.velocity.X + 1f;
						Gore expr_8602_cp_0 = Main.gore[num258];
						expr_8602_cp_0.velocity.Y = expr_8602_cp_0.velocity.Y + 1f;
						num258 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num258].velocity *= scaleFactor3;
						Gore expr_86A5_cp_0 = Main.gore[num258];
						expr_86A5_cp_0.velocity.X = expr_86A5_cp_0.velocity.X - 1f;
						Gore expr_86C5_cp_0 = Main.gore[num258];
						expr_86C5_cp_0.velocity.Y = expr_86C5_cp_0.velocity.Y + 1f;
						num258 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num258].velocity *= scaleFactor3;
						Gore expr_8768_cp_0 = Main.gore[num258];
						expr_8768_cp_0.velocity.X = expr_8768_cp_0.velocity.X + 1f;
						Gore expr_8788_cp_0 = Main.gore[num258];
						expr_8788_cp_0.velocity.Y = expr_8788_cp_0.velocity.Y - 1f;
						num258 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num258].velocity *= scaleFactor3;
						Gore expr_882B_cp_0 = Main.gore[num258];
						expr_882B_cp_0.velocity.X = expr_882B_cp_0.velocity.X - 1f;
						Gore expr_884B_cp_0 = Main.gore[num258];
						expr_884B_cp_0.velocity.Y = expr_884B_cp_0.velocity.Y - 1f;
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
					for (int num259 = 0; num259 < 10; num259++)
					{
						int num260 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num260].velocity *= 0.9f;
					}
					for (int num261 = 0; num261 < 5; num261++)
					{
						int num262 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num262].noGravity = true;
						Main.dust[num262].velocity *= 3f;
						num262 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num262].velocity *= 2f;
					}
					int num263 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num263].velocity *= 0.3f;
					Gore expr_8B2C_cp_0 = Main.gore[num263];
					expr_8B2C_cp_0.velocity.X = expr_8B2C_cp_0.velocity.X + (float)Main.rand.Next(-1, 2);
					Gore expr_8B54_cp_0 = Main.gore[num263];
					expr_8B54_cp_0.velocity.Y = expr_8B54_cp_0.velocity.Y + (float)Main.rand.Next(-1, 2);
					if (this.owner == Main.myPlayer)
					{
						int num264 = Main.rand.Next(2, 6);
						for (int num265 = 0; num265 < num264; num265++)
						{
							float num266 = (float)Main.rand.Next(-100, 101);
							num266 += 0.01f;
							float num267 = (float)Main.rand.Next(-100, 101);
							num266 -= 0.01f;
							float num268 = (float)Math.Sqrt((double)(num266 * num266 + num267 * num267));
							num268 = 8f / num268;
							num266 *= num268;
							num267 *= num268;
							Projectile.NewProjectile(this.center().X - this.lastVelocity.X, this.center().Y - this.lastVelocity.Y, num266, num267, 249, this.damage, this.knockBack, this.owner, 0f, 0f);
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
					for (int num269 = 0; num269 < 7; num269++)
					{
						int num270 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num270].velocity *= 0.8f;
					}
					for (int num271 = 0; num271 < 2; num271++)
					{
						int num272 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num272].noGravity = true;
						Main.dust[num272].velocity *= 2.5f;
						num272 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num272].velocity *= 1.5f;
					}
					int num273 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num273].velocity *= 0.2f;
					Gore expr_8F61_cp_0 = Main.gore[num273];
					expr_8F61_cp_0.velocity.X = expr_8F61_cp_0.velocity.X + (float)Main.rand.Next(-1, 2);
					Gore expr_8F89_cp_0 = Main.gore[num273];
					expr_8F89_cp_0.velocity.Y = expr_8F89_cp_0.velocity.Y + (float)Main.rand.Next(-1, 2);
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
					for (int num274 = 0; num274 < 20; num274++)
					{
						int num275 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num275].velocity *= 1.4f;
					}
					for (int num276 = 0; num276 < 10; num276++)
					{
						int num277 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num277].noGravity = true;
						Main.dust[num277].velocity *= 5f;
						num277 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num277].velocity *= 3f;
					}
					int num278 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num278].velocity *= 0.4f;
					Gore expr_931A_cp_0 = Main.gore[num278];
					expr_931A_cp_0.velocity.X = expr_931A_cp_0.velocity.X + 1f;
					Gore expr_933A_cp_0 = Main.gore[num278];
					expr_933A_cp_0.velocity.Y = expr_933A_cp_0.velocity.Y + 1f;
					num278 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num278].velocity *= 0.4f;
					Gore expr_93BE_cp_0 = Main.gore[num278];
					expr_93BE_cp_0.velocity.X = expr_93BE_cp_0.velocity.X - 1f;
					Gore expr_93DE_cp_0 = Main.gore[num278];
					expr_93DE_cp_0.velocity.Y = expr_93DE_cp_0.velocity.Y + 1f;
					num278 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num278].velocity *= 0.4f;
					Gore expr_9462_cp_0 = Main.gore[num278];
					expr_9462_cp_0.velocity.X = expr_9462_cp_0.velocity.X + 1f;
					Gore expr_9482_cp_0 = Main.gore[num278];
					expr_9482_cp_0.velocity.Y = expr_9482_cp_0.velocity.Y - 1f;
					num278 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num278].velocity *= 0.4f;
					Gore expr_9506_cp_0 = Main.gore[num278];
					expr_9506_cp_0.velocity.X = expr_9506_cp_0.velocity.X - 1f;
					Gore expr_9526_cp_0 = Main.gore[num278];
					expr_9526_cp_0.velocity.Y = expr_9526_cp_0.velocity.Y - 1f;
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
					for (int num279 = 0; num279 < 50; num279++)
					{
						int num280 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num280].velocity *= 1.4f;
					}
					for (int num281 = 0; num281 < 80; num281++)
					{
						int num282 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 3f);
						Main.dust[num282].noGravity = true;
						Main.dust[num282].velocity *= 5f;
						num282 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num282].velocity *= 3f;
					}
					for (int num283 = 0; num283 < 2; num283++)
					{
						int num284 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num284].scale = 1.5f;
						Gore expr_982D_cp_0 = Main.gore[num284];
						expr_982D_cp_0.velocity.X = expr_982D_cp_0.velocity.X + 1.5f;
						Gore expr_984D_cp_0 = Main.gore[num284];
						expr_984D_cp_0.velocity.Y = expr_984D_cp_0.velocity.Y + 1.5f;
						num284 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num284].scale = 1.5f;
						Gore expr_98E6_cp_0 = Main.gore[num284];
						expr_98E6_cp_0.velocity.X = expr_98E6_cp_0.velocity.X - 1.5f;
						Gore expr_9906_cp_0 = Main.gore[num284];
						expr_9906_cp_0.velocity.Y = expr_9906_cp_0.velocity.Y + 1.5f;
						num284 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num284].scale = 1.5f;
						Gore expr_999F_cp_0 = Main.gore[num284];
						expr_999F_cp_0.velocity.X = expr_999F_cp_0.velocity.X + 1.5f;
						Gore expr_99BF_cp_0 = Main.gore[num284];
						expr_99BF_cp_0.velocity.Y = expr_99BF_cp_0.velocity.Y - 1.5f;
						num284 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num284].scale = 1.5f;
						Gore expr_9A58_cp_0 = Main.gore[num284];
						expr_9A58_cp_0.velocity.X = expr_9A58_cp_0.velocity.X - 1.5f;
						Gore expr_9A78_cp_0 = Main.gore[num284];
						expr_9A78_cp_0.velocity.Y = expr_9A78_cp_0.velocity.Y - 1.5f;
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
					for (int num285 = 0; num285 < 5; num285++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 13, 0f, 0f, 0, default(Color), 1f);
					}
					for (int num286 = 0; num286 < 30; num286++)
					{
						int num287 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 33, 0f, -2f, 0, default(Color), 1.1f);
						Main.dust[num287].alpha = 100;
						Dust expr_9C2A_cp_0 = Main.dust[num287];
						expr_9C2A_cp_0.velocity.X = expr_9C2A_cp_0.velocity.X * 1.5f;
						Main.dust[num287].velocity *= 3f;
					}
				}
				else if (this.type == 70)
				{
					Main.PlaySound(13, (int)this.position.X, (int)this.position.Y, 1);
					for (int num288 = 0; num288 < 5; num288++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 13, 0f, 0f, 0, default(Color), 1f);
					}
					for (int num289 = 0; num289 < 30; num289++)
					{
						int num290 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 52, 0f, -2f, 0, default(Color), 1.1f);
						Main.dust[num290].alpha = 100;
						Dust expr_9D80_cp_0 = Main.dust[num290];
						expr_9D80_cp_0.velocity.X = expr_9D80_cp_0.velocity.X * 1.5f;
						Main.dust[num290].velocity *= 3f;
					}
				}
				else if (this.type == 114 || this.type == 115)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num291 = 4; num291 < 31; num291++)
					{
						float num292 = this.lastVelocity.X * (30f / (float)num291);
						float num293 = this.lastVelocity.Y * (30f / (float)num291);
						int num294 = Dust.NewDust(new Vector2(this.position.X - num292, this.position.Y - num293), 8, 8, 27, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.4f);
						Main.dust[num294].noGravity = true;
						Main.dust[num294].velocity *= 0.5f;
						num294 = Dust.NewDust(new Vector2(this.position.X - num292, this.position.Y - num293), 8, 8, 27, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 0.9f);
						Main.dust[num294].velocity *= 0.5f;
					}
				}
				else if (this.type == 116)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num295 = 4; num295 < 31; num295++)
					{
						float num296 = this.lastVelocity.X * (30f / (float)num295);
						float num297 = this.lastVelocity.Y * (30f / (float)num295);
						int num298 = Dust.NewDust(new Vector2(this.position.X - num296, this.position.Y - num297), 8, 8, 64, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.8f);
						Main.dust[num298].noGravity = true;
						num298 = Dust.NewDust(new Vector2(this.position.X - num296, this.position.Y - num297), 8, 8, 64, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.4f);
						Main.dust[num298].noGravity = true;
					}
				}
				else if (this.type == 173)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num299 = 4; num299 < 24; num299++)
					{
						float num300 = this.lastVelocity.X * (30f / (float)num299);
						float num301 = this.lastVelocity.Y * (30f / (float)num299);
						int num302 = Main.rand.Next(3);
						if (num302 == 0)
						{
							num302 = 15;
						}
						else if (num302 == 1)
						{
							num302 = 57;
						}
						else
						{
							num302 = 58;
						}
						int num303 = Dust.NewDust(new Vector2(this.position.X - num300, this.position.Y - num301), 8, 8, num302, this.lastVelocity.X * 0.2f, this.lastVelocity.Y * 0.2f, 100, default(Color), 1.8f);
						Main.dust[num303].velocity *= 1.5f;
						Main.dust[num303].noGravity = true;
					}
				}
				else if (this.type == 132)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num304 = 4; num304 < 31; num304++)
					{
						float num305 = this.lastVelocity.X * (30f / (float)num304);
						float num306 = this.lastVelocity.Y * (30f / (float)num304);
						int num307 = Dust.NewDust(new Vector2(this.lastPosition.X - num305, this.lastPosition.Y - num306), 8, 8, 107, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.8f);
						Main.dust[num307].noGravity = true;
						Main.dust[num307].velocity *= 0.5f;
						num307 = Dust.NewDust(new Vector2(this.lastPosition.X - num305, this.lastPosition.Y - num306), 8, 8, 107, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.4f);
						Main.dust[num307].velocity *= 0.05f;
					}
				}
				else if (this.type == 156)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num308 = 4; num308 < 31; num308++)
					{
						float num309 = this.lastVelocity.X * (30f / (float)num308);
						float num310 = this.lastVelocity.Y * (30f / (float)num308);
						int num311 = Dust.NewDust(new Vector2(this.lastPosition.X - num309, this.lastPosition.Y - num310), 8, 8, 73, this.lastVelocity.X, this.lastVelocity.Y, 255, default(Color), 1.8f);
						Main.dust[num311].noGravity = true;
						Main.dust[num311].velocity *= 0.5f;
						num311 = Dust.NewDust(new Vector2(this.lastPosition.X - num309, this.lastPosition.Y - num310), 8, 8, 73, this.lastVelocity.X, this.lastVelocity.Y, 255, default(Color), 1.4f);
						Main.dust[num311].velocity *= 0.05f;
						Main.dust[num311].noGravity = true;
					}
				}
				else if (this.type == 157)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num312 = 4; num312 < 31; num312++)
					{
						int num313 = Dust.NewDust(this.position, this.width, this.height, 107, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.8f);
						Main.dust[num313].noGravity = true;
						Main.dust[num313].velocity *= 0.5f;
					}
				}
			}
			if (this.owner == Main.myPlayer)
			{
				if (this.type == 28 || this.type == 29 || this.type == 37 || this.type == 108 || this.type == 136 || this.type == 137 || this.type == 138 || this.type == 142 || this.type == 143 || this.type == 144 || this.type == 339 || this.type == 341)
				{
					int num314 = 3;
					if (this.type == 28 || this.type == 37)
					{
						num314 = 4;
					}
					if (this.type == 29)
					{
						num314 = 7;
					}
					if (this.type == 142 || this.type == 143 || this.type == 144 || this.type == 341)
					{
						num314 = 5;
					}
					if (this.type == 108)
					{
						num314 = 10;
					}
					int num315 = (int)(this.position.X / 16f - (float)num314);
					int num316 = (int)(this.position.X / 16f + (float)num314);
					int num317 = (int)(this.position.Y / 16f - (float)num314);
					int num318 = (int)(this.position.Y / 16f + (float)num314);
					if (num315 < 0)
					{
						num315 = 0;
					}
					if (num316 > Main.maxTilesX)
					{
						num316 = Main.maxTilesX;
					}
					if (num317 < 0)
					{
						num317 = 0;
					}
					if (num318 > Main.maxTilesY)
					{
						num318 = Main.maxTilesY;
					}
					bool flag = false;
					for (int num319 = num315; num319 <= num316; num319++)
					{
						for (int num320 = num317; num320 <= num318; num320++)
						{
							float num321 = Math.Abs((float)num319 - this.position.X / 16f);
							float num322 = Math.Abs((float)num320 - this.position.Y / 16f);
							double num323 = Math.Sqrt((double)(num321 * num321 + num322 * num322));
							if (num323 < (double)num314 && Main.tile[num319, num320] != null && Main.tile[num319, num320].wall == 0)
							{
								flag = true;
								break;
							}
						}
					}
					for (int num324 = num315; num324 <= num316; num324++)
					{
						for (int num325 = num317; num325 <= num318; num325++)
						{
							float num326 = Math.Abs((float)num324 - this.position.X / 16f);
							float num327 = Math.Abs((float)num325 - this.position.Y / 16f);
							double num328 = Math.Sqrt((double)(num326 * num326 + num327 * num327));
							if (num328 < (double)num314)
							{
								bool flag2 = true;
								if (Main.tile[num324, num325] != null && Main.tile[num324, num325].active())
								{
									flag2 = true;
									if (Main.tileDungeon[(int)Main.tile[num324, num325].type] || Main.tile[num324, num325].type == 21 || Main.tile[num324, num325].type == 26 || Main.tile[num324, num325].type == 107 || Main.tile[num324, num325].type == 108 || Main.tile[num324, num325].type == 111 || Main.tile[num324, num325].type == 226 || Main.tile[num324, num325].type == 237 || Main.tile[num324, num325].type == 221 || Main.tile[num324, num325].type == 222 || Main.tile[num324, num325].type == 223 || Main.tile[num324, num325].type == 211)
									{
										flag2 = false;
									}
									if (!Main.hardMode && Main.tile[num324, num325].type == 58)
									{
										flag2 = false;
									}
									if (flag2)
									{
										WorldGen.KillTile(num324, num325, false, false, false);
										if (!Main.tile[num324, num325].active() && Main.netMode != 0)
										{
											NetMessage.SendData(17, -1, -1, "", 0, (float)num324, (float)num325, 0f, 0);
										}
									}
								}
								if (flag2)
								{
									for (int num329 = num324 - 1; num329 <= num324 + 1; num329++)
									{
										for (int num330 = num325 - 1; num330 <= num325 + 1; num330++)
										{
											if (Main.tile[num329, num330] != null && Main.tile[num329, num330].wall > 0 && flag)
											{
												WorldGen.KillWall(num329, num330, false);
												if (Main.tile[num329, num330].wall == 0 && Main.netMode != 0)
												{
													NetMessage.SendData(17, -1, -1, "", 2, (float)num329, (float)num330, 0f, 0);
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
					int num331 = -1;
					if (this.aiStyle == 10)
					{
						int num332 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num333 = (int)(this.position.Y + (float)(this.width / 2)) / 16;
						int num334 = 0;
						int num335 = 2;
						if (this.type == 109)
						{
							num334 = 147;
							num335 = 0;
						}
						if (this.type == 31)
						{
							num334 = 53;
							num335 = 0;
						}
						if (this.type == 42)
						{
							num334 = 53;
							num335 = 0;
						}
						if (this.type == 56)
						{
							num334 = 112;
							num335 = 0;
						}
						if (this.type == 65)
						{
							num334 = 112;
							num335 = 0;
						}
						if (this.type == 67)
						{
							num334 = 116;
							num335 = 0;
						}
						if (this.type == 68)
						{
							num334 = 116;
							num335 = 0;
						}
						if (this.type == 71)
						{
							num334 = 123;
							num335 = 0;
						}
						if (this.type == 39)
						{
							num334 = 59;
							num335 = 176;
						}
						if (this.type == 40)
						{
							num334 = 57;
							num335 = 172;
						}
						if (this.type == 179)
						{
							num334 = 224;
							num335 = 0;
						}
						if (this.type == 241)
						{
							num334 = 234;
							num335 = 0;
						}
						if (this.type == 354)
						{
							num334 = 234;
							num335 = 0;
						}
						if (Main.tile[num332, num333].halfBrick() && this.velocity.Y > 0f && Math.Abs(this.velocity.Y) > Math.Abs(this.velocity.X))
						{
							num333--;
						}
						if (!Main.tile[num332, num333].active())
						{
							WorldGen.PlaceTile(num332, num333, num334, false, true, -1, 0);
							if (Main.tile[num332, num333].active() && (int)Main.tile[num332, num333].type == num334)
							{
								if (Main.tile[num332, num333 + 1].halfBrick() || Main.tile[num332, num333 + 1].slope() != 0)
								{
									WorldGen.SlopeTile(num332, num333 + 1, 0);
									if (Main.netMode == 2)
									{
										NetMessage.SendData(17, -1, -1, "", 14, (float)num332, (float)(num333 + 1), 0f, 0);
									}
								}
								if (Main.netMode != 0)
								{
									NetMessage.SendData(17, -1, -1, "", 1, (float)num332, (float)num333, (float)num334, 0);
								}
							}
							else if (num335 > 0)
							{
								num331 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num335, 1, false, 0, false);
							}
						}
						else if (num335 > 0)
						{
							num331 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num335, 1, false, 0, false);
						}
					}
					if (this.type == 1 && Main.rand.Next(3) == 0)
					{
						num331 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0, false);
					}
					if (this.type == 103 && Main.rand.Next(6) == 0)
					{
						if (Main.rand.Next(3) == 0)
						{
							num331 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 545, 1, false, 0, false);
						}
						else
						{
							num331 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0, false);
						}
					}
					if (this.type == 2 && Main.rand.Next(3) == 0)
					{
						if (Main.rand.Next(3) == 0)
						{
							num331 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 41, 1, false, 0, false);
						}
						else
						{
							num331 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0, false);
						}
					}
					if (this.type == 172 && Main.rand.Next(3) == 0)
					{
						if (Main.rand.Next(3) == 0)
						{
							num331 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 988, 1, false, 0, false);
						}
						else
						{
							num331 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0, false);
						}
					}
					if (this.type == 171)
					{
						if (this.ai[1] == 0f)
						{
							num331 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 985, 1, false, 0, false);
							Main.item[num331].noGrabDelay = 0;
						}
						else if (this.ai[1] < 10f)
						{
							num331 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 965, (int)(10f - this.ai[1]), false, 0, false);
							Main.item[num331].noGrabDelay = 0;
						}
					}
					if (this.type == 91 && Main.rand.Next(6) == 0)
					{
						num331 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 516, 1, false, 0, false);
					}
					if (this.type == 50 && Main.rand.Next(3) == 0)
					{
						num331 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 282, 1, false, 0, false);
					}
					if (this.type == 53 && Main.rand.Next(3) == 0)
					{
						num331 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 286, 1, false, 0, false);
					}
					if (this.type == 48 && Main.rand.Next(2) == 0)
					{
						num331 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 279, 1, false, 0, false);
					}
					if (this.type == 54 && Main.rand.Next(2) == 0)
					{
						num331 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 287, 1, false, 0, false);
					}
					if (this.type == 3 && Main.rand.Next(2) == 0)
					{
						num331 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 42, 1, false, 0, false);
					}
					if (this.type == 4 && Main.rand.Next(4) == 0)
					{
						num331 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 47, 1, false, 0, false);
					}
					if (this.type == 12 && this.damage > 500)
					{
						num331 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 75, 1, false, 0, false);
					}
					if (this.type == 155)
					{
						num331 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 859, 1, false, 0, false);
					}
					if (this.type == 21 && Main.rand.Next(2) == 0)
					{
						num331 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 154, 1, false, 0, false);
					}
					if (Main.netMode == 1 && num331 >= 0)
					{
						NetMessage.SendData(21, -1, -1, "", num331, 1f, 0f, 0f, 0);
					}
				}
				if (this.type == 69 || this.type == 70)
				{
					int num336 = (int)(this.position.X + (float)(this.width / 2)) / 16;
					int num337 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
					for (int num338 = num336 - 4; num338 <= num336 + 4; num338++)
					{
						for (int num339 = num337 - 4; num339 <= num337 + 4; num339++)
						{
							if (Math.Abs(num338 - num336) + Math.Abs(num339 - num337) < 6)
							{
								if (this.type == 69)
								{
									if (Main.tile[num338, num339].type == 2)
									{
										Main.tile[num338, num339].type = 109;
										WorldGen.SquareTileFrame(num338, num339, true);
										NetMessage.SendTileSquare(-1, num338, num339, 1);
									}
									else if (Main.tile[num338, num339].type == 1 || Main.tileMoss[(int)Main.tile[num338, num339].type])
									{
										Main.tile[num338, num339].type = 117;
										WorldGen.SquareTileFrame(num338, num339, true);
										NetMessage.SendTileSquare(-1, num338, num339, 1);
									}
									else if (Main.tile[num338, num339].type == 53 || Main.tile[num338, num339].type == 234)
									{
										Main.tile[num338, num339].type = 116;
										WorldGen.SquareTileFrame(num338, num339, true);
										NetMessage.SendTileSquare(-1, num338, num339, 1);
									}
									else if (Main.tile[num338, num339].type == 23 || Main.tile[num338, num339].type == 199)
									{
										Main.tile[num338, num339].type = 109;
										WorldGen.SquareTileFrame(num338, num339, true);
										NetMessage.SendTileSquare(-1, num338, num339, 1);
									}
									else if (Main.tile[num338, num339].type == 25 || Main.tile[num338, num339].type == 203)
									{
										Main.tile[num338, num339].type = 117;
										WorldGen.SquareTileFrame(num338, num339, true);
										NetMessage.SendTileSquare(-1, num338, num339, 1);
									}
									else if (Main.tile[num338, num339].type == 161 || Main.tile[num338, num339].type == 163 || Main.tile[num338, num339].type == 200)
									{
										Main.tile[num338, num339].type = 164;
										WorldGen.SquareTileFrame(num338, num339, true);
										NetMessage.SendTileSquare(-1, num338, num339, 1);
									}
									else if (Main.tile[num338, num339].type == 112)
									{
										Main.tile[num338, num339].type = 116;
										WorldGen.SquareTileFrame(num338, num339, true);
										NetMessage.SendTileSquare(-1, num338, num339, 1);
									}
									else if (Main.tile[num338, num339].type == 161 || Main.tile[num338, num339].type == 163)
									{
										Main.tile[num338, num339].type = 164;
										WorldGen.SquareTileFrame(num338, num339, true);
										NetMessage.SendTileSquare(-1, num338, num339, 1);
									}
								}
								else if (Main.tile[num338, num339].type == 2)
								{
									Main.tile[num338, num339].type = 23;
									WorldGen.SquareTileFrame(num338, num339, true);
									NetMessage.SendTileSquare(-1, num338, num339, 1);
								}
								else if (Main.tile[num338, num339].type == 1 || Main.tileMoss[(int)Main.tile[num338, num339].type])
								{
									Main.tile[num338, num339].type = 25;
									WorldGen.SquareTileFrame(num338, num339, true);
									NetMessage.SendTileSquare(-1, num338, num339, 1);
								}
								else if (Main.tile[num338, num339].type == 53)
								{
									Main.tile[num338, num339].type = 112;
									WorldGen.SquareTileFrame(num338, num339, true);
									NetMessage.SendTileSquare(-1, num338, num339, 1);
								}
								else if (Main.tile[num338, num339].type == 109)
								{
									Main.tile[num338, num339].type = 23;
									WorldGen.SquareTileFrame(num338, num339, true);
									NetMessage.SendTileSquare(-1, num338, num339, 1);
								}
								else if (Main.tile[num338, num339].type == 117)
								{
									Main.tile[num338, num339].type = 25;
									WorldGen.SquareTileFrame(num338, num339, true);
									NetMessage.SendTileSquare(-1, num338, num339, 1);
								}
								else if (Main.tile[num338, num339].type == 116)
								{
									Main.tile[num338, num339].type = 112;
									WorldGen.SquareTileFrame(num338, num339, true);
									NetMessage.SendTileSquare(-1, num338, num339, 1);
								}
								else if (Main.tile[num338, num339].type == 161 || Main.tile[num338, num339].type == 164 || Main.tile[num338, num339].type == 200)
								{
									Main.tile[num338, num339].type = 163;
									WorldGen.SquareTileFrame(num338, num339, true);
									NetMessage.SendTileSquare(-1, num338, num339, 1);
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
			if (this.type == 352)
			{
				return new Color(250, 250, 250, this.alpha);
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
					if (this.type == 265 || this.type == 355)
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
