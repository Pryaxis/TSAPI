using System;
using TerrariaApi.Server;
namespace Terraria
{
	public class Projectile
	{
		public int numHits;
		public bool bobber;
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
		public float minionSlots;
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
		public bool coldDamage;
		public bool noEnchantments;
		public int frameCounter;
		public int frame;
		public void SetDefaults(int Type)
		{
			this.bobber = false;
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
			this.minionSlots = 0f;
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
			this.position = Vector2.Zero;
			this.velocity = Vector2.Zero;
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
			this.coldDamage = false;
			this.noEnchantments = false;
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
				this.coldDamage = true;
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
				this.coldDamage = true;
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
				this.coldDamage = true;
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
				this.coldDamage = true;
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
				this.coldDamage = true;
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
				this.coldDamage = true;
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
				this.coldDamage = true;
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
				this.coldDamage = true;
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
				this.coldDamage = true;
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
				this.coldDamage = true;
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
				this.minionSlots = 1f;
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
				this.coldDamage = true;
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
				this.coldDamage = true;
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
				this.minionSlots = 1f;
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
				this.coldDamage = true;
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
				this.coldDamage = true;
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
				this.minionSlots = 1f;
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
				this.coldDamage = true;
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
				this.coldDamage = true;
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
				this.coldDamage = true;
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
				this.coldDamage = true;
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
				this.coldDamage = true;
			}
			else if (this.type == 349)
			{
				this.name = "Frost Shard";
				this.aiStyle = 1;
				this.width = 12;
				this.height = 12;
				this.hostile = true;
				this.penetrate = -1;
				this.coldDamage = true;
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
				this.coldDamage = true;
			}
			else if ((this.type >= 360 && this.type <= 366) || this.type == 381 || this.type == 382)
			{
				this.name = "Bobber";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 61;
				this.penetrate = -1;
				this.bobber = true;
			}
			else if (this.type == 367)
			{
				this.name = "Obsidian Swordfish";
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
			else if (this.type == 368)
			{
				this.name = "Swordfish";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 19;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 369)
			{
				this.name = "Sawtooth Shark";
				this.width = 22;
				this.height = 22;
				this.aiStyle = 20;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.hide = true;
				this.ownerHitCheck = true;
				this.melee = true;
			}
			else if (this.type == 370)
			{
				this.name = "Love Potion";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 2;
				this.friendly = true;
				this.penetrate = 1;
			}
			else if (this.type == 371)
			{
				this.name = "Foul Potion";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 2;
				this.friendly = true;
				this.penetrate = 1;
			}
			else if (this.type == 372)
			{
				this.name = "Fish Hook";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 7;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.timeLeft *= 10;
			}
			else if (this.type == 373)
			{
				this.netImportant = true;
				this.name = "Hornet";
				this.width = 24;
				this.height = 26;
				this.aiStyle = 62;
				this.penetrate = -1;
				this.timeLeft *= 5;
				this.minion = true;
				this.minionSlots = 1f;
				this.tileCollide = false;
				this.ignoreWater = true;
			}
			else if (this.type == 374)
			{
				this.name = "Hornet Stinger";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 0;
				this.friendly = true;
				this.penetrate = 1;
				this.aiStyle = 1;
				this.tileCollide = true;
				this.scale *= 0.9f;
			}
			else if (this.type == 375)
			{
				this.netImportant = true;
				this.name = "Flying Imp";
				this.width = 34;
				this.height = 26;
				this.aiStyle = 62;
				this.penetrate = -1;
				this.timeLeft *= 5;
				this.minion = true;
				this.minionSlots = 1f;
				this.tileCollide = false;
				this.ignoreWater = true;
			}
			else if (this.type == 376)
			{
				this.name = "Imp Fireball";
				this.width = 12;
				this.height = 12;
				this.aiStyle = 0;
				this.friendly = true;
				this.penetrate = -1;
				this.aiStyle = 1;
				this.tileCollide = true;
				this.timeLeft = 100;
				this.alpha = 255;
				this.maxUpdates = 1;
			}
			else if (this.type == 377)
			{
				this.name = "Spider Hiver";
				this.width = 66;
				this.height = 50;
				this.aiStyle = 53;
				this.timeLeft = 3600;
				this.ignoreWater = true;
			}
			else if (this.type == 378)
			{
				this.name = "Spider Egg";
				this.width = 16;
				this.height = 16;
				this.aiStyle = 14;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft = 60;
				this.scale = 0.9f;
			}
			else if (this.type == 379)
			{
				this.name = "Baby Spider";
				this.width = 14;
				this.height = 10;
				this.aiStyle = 63;
				this.friendly = true;
				this.timeLeft = 300;
				this.penetrate = 1;
			}
			else if (this.type == 380)
			{
				this.netImportant = true;
				this.name = "Zephyr Fish";
				this.width = 26;
				this.height = 26;
				this.aiStyle = 26;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft *= 5;
			}
			else if (this.type == 383)
			{
				this.name = "Anchor";
				this.width = 34;
				this.height = 34;
				this.aiStyle = 3;
				this.friendly = true;
				this.penetrate = -1;
				this.melee = true;
			}
			else if (this.type == 384)
			{
				this.name = "Sharknado";
				this.width = 150;
				this.height = 42;
				this.hostile = true;
				this.penetrate = -1;
				this.aiStyle = 64;
				this.tileCollide = false;
				this.ignoreWater = true;
				this.alpha = 255;
				this.timeLeft = 540;
			}
			else if (this.type == 385)
			{
				this.name = "Sharknado Bolt";
				this.width = 30;
				this.height = 30;
				this.hostile = true;
				this.penetrate = -1;
				this.aiStyle = 65;
				this.alpha = 255;
				this.timeLeft = 300;
			}
			else if (this.type == 386)
			{
				this.name = "Cthulunado";
				this.width = 150;
				this.height = 42;
				this.hostile = true;
				this.penetrate = -1;
				this.aiStyle = 64;
				this.tileCollide = false;
				this.ignoreWater = true;
				this.alpha = 255;
				this.timeLeft = 840;
			}
			else if (this.type == 387)
			{
				this.netImportant = true;
				this.name = "Retanimini";
				this.width = 40;
				this.height = 20;
				this.aiStyle = 66;
				this.penetrate = -1;
				this.timeLeft *= 5;
				this.minion = true;
				this.minionSlots = 0.5f;
				this.tileCollide = false;
				this.ignoreWater = true;
				this.friendly = true;
			}
			else if (this.type == 388)
			{
				this.netImportant = true;
				this.name = "Spazmamini";
				this.width = 40;
				this.height = 20;
				this.aiStyle = 66;
				this.penetrate = -1;
				this.timeLeft *= 5;
				this.minion = true;
				this.minionSlots = 0.5f;
				this.tileCollide = false;
				this.ignoreWater = true;
				this.friendly = true;
			}
			else if (this.type == 389)
			{
				this.name = "Mini Retina Laser";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 1;
				this.friendly = true;
				this.penetrate = 3;
				this.light = 0.75f;
				this.alpha = 255;
				this.maxUpdates = 2;
				this.scale = 1.2f;
				this.timeLeft = 600;
			}
			else if (this.type == 390 || this.type == 391 || this.type == 392)
			{
				this.name = "Venom Spider";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 26;
				this.penetrate = -1;
				this.netImportant = true;
				this.timeLeft *= 5;
				this.minion = true;
				this.minionSlots = 1f;
				if (this.type == 391)
				{
					this.name = "Jumper Spider";
				}
				if (this.type == 392)
				{
					this.name = "Dangerous Spider";
				}
			}
			else if (this.type == 393 || this.type == 394 || this.type == 395)
			{
				this.name = "One Eyed Pirate";
				this.width = 20;
				this.height = 30;
				this.aiStyle = 67;
				this.penetrate = -1;
				this.netImportant = true;
				this.timeLeft *= 5;
				this.minion = true;
				this.minionSlots = 1f;
				if (this.type == 394)
				{
					this.name = "Soulscourge Pirate";
				}
				if (this.type == 395)
				{
					this.name = "Pirate Captain";
				}
			}
			else if (this.type == 396)
			{
				this.name = "Slime Hook";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 7;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.timeLeft *= 10;
				this.alpha = 100;
			}
			else if (this.type == 397)
			{
				this.name = "Sticky Grenade";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 16;
				this.friendly = true;
				this.penetrate = -1;
				this.ranged = true;
				this.tileCollide = false;
			}
			else if (this.type == 398)
			{
				this.netImportant = true;
				this.name = "Mini Minotaur";
				this.width = 18;
				this.height = 38;
				this.aiStyle = 26;
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft *= 5;
			}
			else if (this.type == 399)
			{
				this.name = "Molotov Cocktail";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 68;
				this.friendly = true;
				this.penetrate = 1;
				this.alpha = 255;
				this.ranged = true;
				this.noEnchantments = true;
			}
			else if (this.type >= 400 && this.type <= 402)
			{
				this.name = "Molotov Fire";
				if (this.type == 400)
				{
					this.width = 14;
					this.height = 16;
				}
				else if (this.type == 401)
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
				this.friendly = true;
				this.penetrate = -1;
				this.timeLeft = 360;
				this.ranged = true;
				this.noEnchantments = true;
			}
			else if (this.type == 403)
			{
				this.netImportant = true;
				this.name = "Track Hook";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 7;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.timeLeft *= 10;
			}
			else if (this.type == 404)
			{
				this.name = "Flairon";
				this.width = 26;
				this.height = 26;
				this.aiStyle = 69;
				this.friendly = true;
				this.penetrate = -1;
				this.alpha = 255;
				this.melee = true;
			}
			else if (this.type == 405)
			{
				this.name = "Flairon Bubble";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 70;
				this.friendly = true;
				this.penetrate = 1;
				this.alpha = 255;
				this.timeLeft = 90;
				this.melee = true;
				this.noEnchantments = true;
			}
			else if (this.type == 406)
			{
				this.name = "Slime Gun";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 60;
				this.alpha = 255;
				this.penetrate = -1;
				this.maxUpdates = 2;
				this.ignoreWater = true;
			}
			else if (this.type == 407)
			{
				this.netImportant = true;
				this.name = "Tempest";
				this.width = 28;
				this.height = 40;
				this.aiStyle = 62;
				this.penetrate = -1;
				this.timeLeft *= 5;
				this.minion = true;
				this.friendly = true;
				this.minionSlots = 1f;
				this.tileCollide = false;
				this.ignoreWater = true;
			}
			else if (this.type == 408)
			{
				this.name = "Mini Sharkron";
				this.width = 10;
				this.height = 10;
				this.aiStyle = 1;
				this.friendly = true;
				this.alpha = 255;
				this.ignoreWater = true;
			}
			else if (this.type == 409)
			{
				this.name = "Typhoon";
				this.width = 30;
				this.height = 30;
				this.penetrate = -1;
				this.aiStyle = 71;
				this.alpha = 255;
				this.timeLeft = 360;
				this.friendly = true;
				this.tileCollide = true;
				this.maxUpdates = 2;
				this.magic = true;
				this.ignoreWater = true;
			}
			else if (this.type == 410)
			{
				this.name = "Bubble";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 72;
				this.friendly = true;
				this.penetrate = 1;
				this.alpha = 255;
				this.timeLeft = 50;
				this.magic = true;
				this.ignoreWater = true;
			}
			else if (this.type >= 411 && this.type <= 414)
			{
				switch (this.type)
				{
				case 411:
					this.name = "Copper Coins";
					break;
				case 412:
					this.name = "Silver Coins";
					break;
				case 413:
					this.name = "Gold Coins";
					break;
				case 414:
					this.name = "Platinum Coins";
					break;
				}
				this.width = 10;
				this.height = 10;
				this.aiStyle = 10;
			}
			else if (this.type == 415 || this.type == 416 || this.type == 417 || this.type == 418)
			{
				this.name = "Rocket";
				this.width = 14;
				this.height = 14;
				this.aiStyle = 34;
				this.friendly = true;
				this.ranged = true;
				this.timeLeft = 45;
			}
			else if (this.type >= 419 && this.type <= 422)
			{
				this.name = "Firework Fountain";
				this.width = 4;
				this.height = 4;
				this.aiStyle = 73;
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
		public static int NewProjectile(float X, float Y, float SpeedX, float SpeedY, int Type, int Damage, float KnockBack, int Owner = 255, float ai0 = 0f, float ai1 = 0f)
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
				else if (Type == 406)
				{
					Main.projectile[num].ai[1] = (float)Main.rand.Next(10, 21) * 0.1f;
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
				if (Type == 397)
				{
					Main.projectile[num].timeLeft = 180;
				}
				if (Type == 419)
				{
					Main.projectile[num].timeLeft = 600;
				}
				if (Type == 420)
				{
					Main.projectile[num].timeLeft = 600;
				}
				if (Type == 421)
				{
					Main.projectile[num].timeLeft = 600;
				}
				if (Type == 422)
				{
					Main.projectile[num].timeLeft = 600;
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
			if (this.melee && Main.player[this.owner].meleeEnchant > 0 && !this.noEnchantments)
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
					Main.npc[i].AddBuff(72, 120, false);
				}
			}
			if (this.type == 379)
			{
				Main.npc[i].AddBuff(70, 60 * Main.rand.Next(4, 7), false);
			}
			if (this.type >= 390 && this.type <= 392)
			{
				Main.npc[i].AddBuff(70, 60 * Main.rand.Next(2, 5), false);
			}
			if (this.type == 374)
			{
				Main.npc[i].AddBuff(20, 60 * Main.rand.Next(4, 7), false);
			}
			if (this.type == 376)
			{
				Main.npc[i].AddBuff(24, 60 * Main.rand.Next(3, 7), false);
			}
			if (this.type >= 399 && this.type <= 402)
			{
				Main.npc[i].AddBuff(24, 60 * Main.rand.Next(3, 7), false);
			}
			if (this.type == 295 || this.type == 296)
			{
				Main.npc[i].AddBuff(24, 60 * Main.rand.Next(8, 16), false);
			}
			if ((this.melee || this.ranged) && Main.player[this.owner].frostBurn && !this.noEnchantments)
			{
				Main.npc[i].AddBuff(44, 60 * Main.rand.Next(5, 15), false);
			}
			if (this.melee && Main.player[this.owner].magmaStone && !this.noEnchantments)
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
			if (this.type == 2 && Main.rand.Next(3) == 0)
			{
				Main.npc[i].AddBuff(24, 180, false);
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
				if (this.type == 98)
				{
					Main.npc[i].AddBuff(20, 600, false);
					return;
				}
				if (this.type == 184)
				{
					Main.npc[i].AddBuff(20, 900, false);
					return;
				}
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
			if (this.melee && Main.player[this.owner].meleeEnchant > 0 && !this.noEnchantments)
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
			if ((this.melee || this.ranged) && Main.player[this.owner].frostBurn && !this.noEnchantments)
			{
				Main.player[i].AddBuff(44, 60 * Main.rand.Next(1, 8), false);
			}
			if (this.melee && Main.player[this.owner].magmaStone && !this.noEnchantments)
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
					if (num5 < 800f && (float)(Main.player[i].statLifeMax2 - Main.player[i].statLife) > num3)
					{
						num3 = (float)(Main.player[i].statLifeMax2 - Main.player[i].statLife);
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
			if (this.type >= 399 && this.type <= 402)
			{
				Main.npc[i].AddBuff(24, 60 * Main.rand.Next(3, 7), false);
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
			if (this.type == 18 || this.type == 72 || this.type == 86 || this.type == 87 || this.aiStyle == 31 || this.aiStyle == 32 || this.type == 226 || this.type == 378)
			{
				return;
			}
			if (Main.projPet[this.type] && this.type != 266 && this.type != 407 && this.type != 317 && (this.type != 388 || this.ai[0] != 2f) && (this.type < 390 || this.type > 392) && (this.type < 393 || this.type > 395))
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
				if (this.type != 69 && this.type != 70 && this.type != 10 && this.type != 11 && this.aiStyle != 45 && this.type != 379 && this.type != 407)
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
									else if (this.aiStyle == 68)
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
									if (this.type >= 390 && this.type <= 392)
									{
										this.localAI[1] = 25f;
									}
									if (this.type == 286)
									{
										Main.npc[k].immune[this.owner] = 5;
									}
									else if (this.type == 246)
									{
										Main.npc[k].immune[this.owner] = 7;
									}
									else if (this.type == 249)
									{
										Main.npc[k].immune[this.owner] = 7;
									}
									else if (this.type == 190)
									{
										Main.npc[k].immune[this.owner] = 8;
									}
									else if (this.type == 409)
									{
										Main.npc[k].immune[this.owner] = 6;
									}
									else if (this.type == 407)
									{
										Main.npc[k].immune[this.owner] = 20;
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
									else if (this.aiStyle == 69)
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
								else if (this.aiStyle == 68)
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
								else if (this.aiStyle == 69)
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
						if (Main.player[myPlayer2].resistCold && this.coldDamage)
						{
							num16 = (int)((float)num16 * 0.7f);
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
				else if (this.type == 84 || this.type == 389)
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
				Lighting.addLight((int)((this.position.X + (float)(this.width / 2)) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), num, num2, num3);
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
					if (Main.player[this.owner].frostBurn && (this.melee || this.ranged) && this.friendly && !this.hostile && !this.noEnchantments && Main.rand.Next(2 * (1 + this.maxUpdates)) == 0)
					{
						int num = Dust.NewDust(this.position, this.width, this.height, 135, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num].noGravity = true;
						Main.dust[num].velocity *= 0.7f;
						Dust expr_10D_cp_0 = Main.dust[num];
						expr_10D_cp_0.velocity.Y = expr_10D_cp_0.velocity.Y - 0.5f;
					}
					if (this.melee && Main.player[this.owner].meleeEnchant > 0 && !this.noEnchantments)
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
								Dust expr_32F_cp_0 = Main.dust[num4];
								expr_32F_cp_0.velocity.Y = expr_32F_cp_0.velocity.Y - 0.5f;
							}
						}
						else if (Main.player[this.owner].meleeEnchant == 3)
						{
							if (Main.rand.Next(2) == 0)
							{
								int num5 = Dust.NewDust(this.position, this.width, this.height, 6, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
								Main.dust[num5].noGravity = true;
								Main.dust[num5].velocity *= 0.7f;
								Dust expr_3FB_cp_0 = Main.dust[num5];
								expr_3FB_cp_0.velocity.Y = expr_3FB_cp_0.velocity.Y - 0.5f;
							}
						}
						else if (Main.player[this.owner].meleeEnchant == 4)
						{
							if (Main.rand.Next(2) == 0)
							{
								int num6 = Dust.NewDust(this.position, this.width, this.height, 57, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.1f);
								Main.dust[num6].noGravity = true;
								Dust expr_4AE_cp_0 = Main.dust[num6];
								expr_4AE_cp_0.velocity.X = expr_4AE_cp_0.velocity.X / 2f;
								Dust expr_4CC_cp_0 = Main.dust[num6];
								expr_4CC_cp_0.velocity.Y = expr_4CC_cp_0.velocity.Y / 2f;
							}
						}
						else if (Main.player[this.owner].meleeEnchant == 5)
						{
							if (Main.rand.Next(2) == 0)
							{
								int num7 = Dust.NewDust(this.position, this.width, this.height, 169, 0f, 0f, 100, default(Color), 1f);
								Dust expr_54F_cp_0 = Main.dust[num7];
								expr_54F_cp_0.velocity.X = expr_54F_cp_0.velocity.X + (float)this.direction;
								Dust expr_56F_cp_0 = Main.dust[num7];
								expr_56F_cp_0.velocity.Y = expr_56F_cp_0.velocity.Y + 0.2f;
								Main.dust[num7].noGravity = true;
							}
						}
						else if (Main.player[this.owner].meleeEnchant == 6)
						{
							if (Main.rand.Next(2) == 0)
							{
								int num8 = Dust.NewDust(this.position, this.width, this.height, 135, 0f, 0f, 100, default(Color), 1f);
								Dust expr_600_cp_0 = Main.dust[num8];
								expr_600_cp_0.velocity.X = expr_600_cp_0.velocity.X + (float)this.direction;
								Dust expr_620_cp_0 = Main.dust[num8];
								expr_620_cp_0.velocity.Y = expr_620_cp_0.velocity.Y + 0.2f;
								Main.dust[num8].noGravity = true;
							}
						}
						else if (Main.player[this.owner].meleeEnchant == 7)
						{
							if (Main.rand.Next(20) == 0)
							{
								int num9 = Main.rand.Next(139, 143);
								int num10 = Dust.NewDust(this.position, this.width, this.height, num9, this.velocity.X, this.velocity.Y, 0, default(Color), 1.2f);
								Dust expr_6D0_cp_0 = Main.dust[num10];
								expr_6D0_cp_0.velocity.X = expr_6D0_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
								Dust expr_704_cp_0 = Main.dust[num10];
								expr_704_cp_0.velocity.Y = expr_704_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
								Dust expr_738_cp_0 = Main.dust[num10];
								expr_738_cp_0.velocity.X = expr_738_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
								Dust expr_766_cp_0 = Main.dust[num10];
								expr_766_cp_0.velocity.Y = expr_766_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
								Main.dust[num10].scale *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
							}
							if (Main.rand.Next(40) == 0)
							{
								int num11 = Main.rand.Next(276, 283);
								int num12 = Gore.NewGore(this.position, this.velocity, num11, 1f);
								Gore expr_804_cp_0 = Main.gore[num12];
								expr_804_cp_0.velocity.X = expr_804_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
								Gore expr_838_cp_0 = Main.gore[num12];
								expr_838_cp_0.velocity.Y = expr_838_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
								Main.gore[num12].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
								Gore expr_89B_cp_0 = Main.gore[num12];
								expr_89B_cp_0.velocity.X = expr_89B_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
								Gore expr_8C9_cp_0 = Main.gore[num12];
								expr_8C9_cp_0.velocity.Y = expr_8C9_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
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
					if (this.melee && Main.player[this.owner].magmaStone && !this.noEnchantments && Main.rand.Next(3) != 0)
					{
						int num14 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y - 4f), this.width + 8, this.height + 8, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 2f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num14].scale = 1.5f;
						}
						Main.dust[num14].noGravity = true;
						Dust expr_A6E_cp_0 = Main.dust[num14];
						expr_A6E_cp_0.velocity.X = expr_A6E_cp_0.velocity.X * 2f;
						Dust expr_A8C_cp_0 = Main.dust[num14];
						expr_A8C_cp_0.velocity.Y = expr_A8C_cp_0.velocity.Y * 2f;
					}
				}
				if (this.minion && this.numUpdates == 0)
				{
					this.minionPos = Main.player[this.owner].numMinions;
					if (Main.player[this.owner].slotsMinions + this.minionSlots > (float)Main.player[this.owner].maxMinions && this.owner == Main.myPlayer)
					{
						this.Kill();
					}
					else
					{
						Main.player[this.owner].numMinions++;
						Main.player[this.owner].slotsMinions += this.minionSlots;
					}
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
										Dust expr_ECC_cp_0 = Main.dust[num16];
										expr_ECC_cp_0.velocity.Y = expr_ECC_cp_0.velocity.Y - 1f;
										Dust expr_EEA_cp_0 = Main.dust[num16];
										expr_EEA_cp_0.velocity.X = expr_EEA_cp_0.velocity.X * 2.5f;
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
										Dust expr_FD5_cp_0 = Main.dust[num17];
										expr_FD5_cp_0.velocity.Y = expr_FD5_cp_0.velocity.Y - 4f;
										Dust expr_FF3_cp_0 = Main.dust[num17];
										expr_FF3_cp_0.velocity.X = expr_FF3_cp_0.velocity.X * 2.5f;
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
									Dust expr_10DB_cp_0 = Main.dust[num18];
									expr_10DB_cp_0.velocity.Y = expr_10DB_cp_0.velocity.Y - 1.5f;
									Dust expr_10F9_cp_0 = Main.dust[num18];
									expr_10F9_cp_0.velocity.X = expr_10F9_cp_0.velocity.X * 2.5f;
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
										Dust expr_124F_cp_0 = Main.dust[num19];
										expr_124F_cp_0.velocity.Y = expr_124F_cp_0.velocity.Y - 1f;
										Dust expr_126D_cp_0 = Main.dust[num19];
										expr_126D_cp_0.velocity.X = expr_126D_cp_0.velocity.X * 2.5f;
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
										Dust expr_1352_cp_0 = Main.dust[num21];
										expr_1352_cp_0.velocity.Y = expr_1352_cp_0.velocity.Y - 4f;
										Dust expr_1370_cp_0 = Main.dust[num21];
										expr_1370_cp_0.velocity.X = expr_1370_cp_0.velocity.X * 2.5f;
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
									Dust expr_1458_cp_0 = Main.dust[num23];
									expr_1458_cp_0.velocity.Y = expr_1458_cp_0.velocity.Y - 1.5f;
									Dust expr_1476_cp_0 = Main.dust[num23];
									expr_1476_cp_0.velocity.X = expr_1476_cp_0.velocity.X * 2.5f;
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
					if (this.type == 373)
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
							if (this.type == 379)
							{
								if (this.velocity.X != vector.X)
								{
									this.velocity.X = vector.X * -0.6f;
								}
								if (this.velocity.Y != vector.Y && vector.Y > 2f)
								{
									this.velocity.Y = vector.Y * -0.6f;
								}
							}
							else if (this.type == 409)
							{
								if (this.velocity.X != vector.X)
								{
									this.velocity.X = vector.X * -1f;
								}
								if (this.velocity.Y != vector.Y)
								{
									this.velocity.Y = vector.Y * -1f;
								}
							}
							else if (this.type == 254)
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
								else if (this.aiStyle == 3 || this.aiStyle == 13 || this.aiStyle == 69)
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
										if (this.aiStyle == 3 && this.type != 383)
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
								else if (this.aiStyle == 61)
								{
									if (this.velocity.X != vector.X)
									{
										this.velocity.X = vector.X * -0.3f;
									}
									if (this.velocity.Y != vector.Y && vector.Y > 1f)
									{
										this.velocity.Y = vector.Y * -0.3f;
									}
								}
								else if (this.aiStyle == 14)
								{
									if (this.type == 261 && ((this.velocity.X != vector.X && (vector.X < -3f || vector.X > 3f)) || (this.velocity.Y != vector.Y && (vector.Y < -3f || vector.Y > 3f))))
									{
										Collision.HitTiles(this.position, this.velocity, this.width, this.height);
										Main.PlaySound(0, (int)this.center().X, (int)this.center().Y, 1);
									}
									if (this.type >= 326 && this.type <= 328 && this.velocity.X != vector.X)
									{
										this.velocity.X = vector.X * -0.1f;
									}
									if (this.type >= 400 && this.type <= 402)
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
								else if (this.aiStyle == 68)
								{
									this.velocity *= 0f;
									this.alpha = 255;
									this.timeLeft = 3;
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
				if ((this.aiStyle != 3 || this.ai[0] != 1f) && (this.aiStyle != 7 || this.ai[0] != 1f) && (this.aiStyle != 13 || this.ai[0] != 1f) && (this.aiStyle != 15 || this.ai[0] != 1f) && this.aiStyle != 65 && this.aiStyle != 69 && this.aiStyle != 15 && this.aiStyle != 26 && this.aiStyle != 67)
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
					if (this.type == 94 || this.type == 301 || this.type == 388 || this.type == 385 || this.type == 408 || this.type == 409)
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
		public void FishingCheck()
		{
			int num = (int)(this.center().X / 16f);
			int num2 = (int)(this.center().Y / 16f);
			if (Main.tile[num, num2].liquid < 0)
			{
				num2++;
			}
			bool flag = false;
			bool flag2 = false;
			int num3 = num;
			int num4 = num;
			while (num3 > 10 && Main.tile[num3, num2].liquid > 0)
			{
				if (WorldGen.SolidTile(num3, num2))
				{
					break;
				}
				num3--;
			}
			while (num4 < Main.maxTilesX - 10 && Main.tile[num4, num2].liquid > 0 && !WorldGen.SolidTile(num4, num2))
			{
				num4++;
			}
			int num5 = 0;
			for (int i = num3; i <= num4; i++)
			{
				int num6 = num2;
				while (Main.tile[i, num6].liquid > 0 && !WorldGen.SolidTile(i, num6) && num6 < Main.maxTilesY - 10)
				{
					num5++;
					num6++;
					if (Main.tile[i, num6].lava())
					{
						flag = true;
					}
					else if (Main.tile[i, num6].honey())
					{
						flag2 = true;
					}
				}
			}
			if (flag2)
			{
				num5 = (int)((double)num5 * 1.5);
			}
			if (num5 < 75)
			{
				return;
			}
			int num7 = Main.player[this.owner].FishingLevel();
			if (num7 == 0)
			{
				return;
			}
			if (num7 < 0)
			{
				if (num7 == -1 && (num < 380 || num > Main.maxTilesX - 380) && num5 > 1000 && !NPC.AnyNPCs(370))
				{
					this.ai[1] = (float)(Main.rand.Next(-180, -60) - 100);
					this.localAI[1] = (float)num7;
					this.netUpdate = true;
				}
				return;
			}
			int num8 = 300;
			float num9 = (float)num5 / (float)num8;
			if (num9 < 1f)
			{
				num7 = (int)((float)num7 * num9);
			}
			int num10 = (num7 + 75) / 2;
			if (Main.player[this.owner].wet)
			{
				return;
			}
			if (Main.rand.Next(100) > num10)
			{
				return;
			}
			int num11 = 0;
			int num12;
			if ((double)num2 < Main.worldSurface * 0.4)
			{
				num12 = 0;
			}
			else if ((double)num2 < Main.worldSurface)
			{
				num12 = 1;
			}
			else if ((double)num2 < Main.rockLayer)
			{
				num12 = 2;
			}
			else if (num2 < Main.maxTilesY - 300)
			{
				num12 = 3;
			}
			else
			{
				num12 = 4;
			}
			int num13 = 150;
			int num14 = num13 / num7;
			int num15 = num13 * 2 / num7;
			int num16 = num13 * 7 / num7;
			int num17 = num13 * 15 / num7;
			int num18 = num13 * 30 / num7;
			if (num14 < 2)
			{
				num14 = 2;
			}
			if (num15 < 3)
			{
				num15 = 3;
			}
			if (num16 < 4)
			{
				num16 = 4;
			}
			if (num17 < 5)
			{
				num17 = 5;
			}
			if (num18 < 6)
			{
				num18 = 6;
			}
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			bool flag7 = false;
			if (Main.rand.Next(num14) == 0)
			{
				flag3 = true;
			}
			if (Main.rand.Next(num15) == 0)
			{
				flag4 = true;
			}
			if (Main.rand.Next(num16) == 0)
			{
				flag5 = true;
			}
			if (Main.rand.Next(num17) == 0)
			{
				flag6 = true;
			}
			if (Main.rand.Next(num18) == 0)
			{
				flag7 = true;
			}
			int num19 = 10;
			if (Main.player[this.owner].cratePotion)
			{
				num19 += 10;
			}
			int num20 = Main.anglerQuestItemNetIDs[Main.anglerQuest];
			if (Main.player[this.owner].HasItem(num20))
			{
				num20 = -1;
			}
			if (Main.anglerQuestFinished)
			{
				num20 = -1;
			}
			if (flag)
			{
				if (Main.player[this.owner].inventory[Main.player[this.owner].selectedItem].type != 2422)
				{
					return;
				}
				if (flag7)
				{
					num11 = 2331;
				}
				else if (flag6)
				{
					num11 = 2312;
				}
				else if (flag5)
				{
					num11 = 2315;
				}
			}
			else if (flag2)
			{
				if (flag5 || (flag4 && Main.rand.Next(2) == 0))
				{
					num11 = 2314;
				}
				else if (flag4 && num20 == 2451)
				{
					num11 = 2451;
				}
			}
			else if (Main.rand.Next(50) > num7 && Main.rand.Next(50) > num7 && num5 < num8)
			{
				num11 = Main.rand.Next(2337, 2340);
			}
			else if (Main.rand.Next(100) < num19)
			{
				if (flag6 || flag7)
				{
					num11 = 2336;
				}
				else if (flag4)
				{
					num11 = 2335;
				}
				else
				{
					num11 = 2334;
				}
			}
			else if (flag7 && Main.rand.Next(5) == 0)
			{
				num11 = 2423;
			}
			else if (flag7 && Main.rand.Next(10) == 0)
			{
				num11 = 2420;
			}
			else
			{
				bool flag8 = Main.player[this.owner].zoneEvil;
				bool flag9 = Main.player[this.owner].zoneBlood;
				if (flag8 && flag9)
				{
					if (Main.rand.Next(2) == 0)
					{
						flag9 = false;
					}
					else
					{
						flag8 = false;
					}
				}
				if (flag8)
				{
					if (flag7 && Main.hardMode && Main.player[this.owner].zoneSnow && num12 == 3)
					{
						num11 = 2429;
					}
					else if (flag5)
					{
						num11 = 2330;
					}
					else if (flag4 && num20 == 2454)
					{
						num11 = 2454;
					}
					else if (flag4 && num20 == 2485)
					{
						num11 = 2485;
					}
					else if (flag4 && num20 == 2457)
					{
						num11 = 2457;
					}
					else if (flag4)
					{
						num11 = 2318;
					}
				}
				else if (flag9)
				{
					if (flag7 && Main.hardMode && Main.player[this.owner].zoneSnow && num12 == 3)
					{
						num11 = 2429;
					}
					else if (flag4 && num20 == 2477)
					{
						num11 = 2477;
					}
					else if (flag4 && num20 == 2463)
					{
						num11 = 2463;
					}
					else if (flag4)
					{
						num11 = 2319;
					}
					else if (flag3)
					{
						num11 = 2305;
					}
				}
				else if (Main.player[this.owner].zoneHoly)
				{
					if (flag7 && Main.hardMode && Main.player[this.owner].zoneSnow && num12 == 3)
					{
						num11 = 2429;
					}
					else if (num12 > 1 && flag6)
					{
						num11 = 2317;
					}
					else if (num12 > 1 && flag5 && num20 == 2465)
					{
						num11 = 2465;
					}
					else if (num12 < 2 && flag5 && num20 == 2468)
					{
						num11 = 2468;
					}
					else if (flag5)
					{
						num11 = 2310;
					}
					else if (flag4 && num20 == 2471)
					{
						num11 = 2471;
					}
					else if (flag4)
					{
						num11 = 2307;
					}
				}
				if (num11 == 0 && Main.player[this.owner].zoneSnow)
				{
					if (num12 < 2 && flag4 && num20 == 2467)
					{
						num11 = 2467;
					}
					else if (num12 == 1 && flag4 && num20 == 2470)
					{
						num11 = 2470;
					}
					else if (num12 == 2 && flag4 && num20 == 2484)
					{
						num11 = 2484;
					}
					else if (num12 > 1 && flag4 && num20 == 2466)
					{
						num11 = 2466;
					}
					else if (flag4)
					{
						num11 = 2306;
					}
					else if (flag3)
					{
						num11 = 2299;
					}
				}
				if (num11 == 0 && Main.player[this.owner].zoneJungle)
				{
					if (num12 == 1 && flag4 && num20 == 2452)
					{
						num11 = 2452;
					}
					else if (num12 == 1 && flag4 && num20 == 2483)
					{
						num11 = 2483;
					}
					else if (num12 == 1 && flag4 && num20 == 2488)
					{
						num11 = 2488;
					}
					else if (num12 >= 1 && flag4 && num20 == 2486)
					{
						num11 = 2486;
					}
					else if (num12 > 1 && flag4)
					{
						num11 = 2311;
					}
					else if (flag4)
					{
						num11 = 2313;
					}
					else if (flag3)
					{
						num11 = 2302;
					}
				}
				if (num11 == 0 && Main.shroomTiles > 200 && flag4 && num20 == 2475)
				{
					num11 = 2475;
				}
				if (num11 == 0)
				{
					if (num12 <= 1 && (num < 380 || num > Main.maxTilesX - 380) && num5 > 1000)
					{
						if (flag6 && Main.rand.Next(2) == 0)
						{
							num11 = 2341;
						}
						else if (flag6)
						{
							num11 = 2342;
						}
						else if (flag5 && Main.rand.Next(5) == 0)
						{
							num11 = 2438;
						}
						else if (flag5 && Main.rand.Next(2) == 0)
						{
							num11 = 2332;
						}
						else if (flag4 && num20 == 2480)
						{
							num11 = 2480;
						}
						else if (flag4 && num20 == 2481)
						{
							num11 = 2481;
						}
						else if (flag4)
						{
							num11 = 2316;
						}
						else if (flag3 && Main.rand.Next(2) == 0)
						{
							num11 = 2301;
						}
						else if (flag3)
						{
							num11 = 2300;
						}
						else
						{
							num11 = 2297;
						}
					}
					else
					{
						int arg_976_0 = Main.sandTiles;
					}
				}
				if (num11 == 0)
				{
					if (num12 == 0 && flag4 && num20 == 2453)
					{
						num11 = 2453;
					}
					else if (num12 < 2 && flag4 && num20 == 2461)
					{
						num11 = 2461;
					}
					else if (num12 < 2 && flag4 && num20 == 2473)
					{
						num11 = 2473;
					}
					else if (num12 < 2 && flag4 && num20 == 2476)
					{
						num11 = 2476;
					}
					else if (num12 < 2 && flag4 && num20 == 2458)
					{
						num11 = 2458;
					}
					else if (num12 < 2 && flag4 && num20 == 2459)
					{
						num11 = 2459;
					}
					else if (num12 == 0 && flag4)
					{
						num11 = 2304;
					}
					else if (num12 > 0 && num12 < 3 && flag4 && num20 == 2455)
					{
						num11 = 2455;
					}
					else if (num12 == 1 && flag4 && num20 == 2479)
					{
						num11 = 2479;
					}
					else if (num12 == 1 && flag4 && num20 == 2456)
					{
						num11 = 2456;
					}
					else if (num12 == 1 && flag4 && num20 == 2474)
					{
						num11 = 2474;
					}
					else if (num12 > 1 && flag5 && Main.rand.Next(5) == 0)
					{
						if (Main.hardMode && Main.rand.Next(2) == 0)
						{
							num11 = 2437;
						}
						else
						{
							num11 = 2436;
						}
					}
					else if (num12 > 1 && flag7)
					{
						num11 = 2308;
					}
					else if (num12 > 1 && flag6)
					{
						num11 = 2320;
					}
					else if (num12 > 1 && flag5)
					{
						num11 = 2321;
					}
					else if (num12 > 1 && flag4 && num20 == 2478)
					{
						num11 = 2478;
					}
					else if (num12 > 1 && flag4 && num20 == 2450)
					{
						num11 = 2450;
					}
					else if (num12 > 1 && flag4 && num20 == 2464)
					{
						num11 = 2464;
					}
					else if (num12 > 1 && flag4 && num20 == 2469)
					{
						num11 = 2469;
					}
					else if (num12 > 2 && flag4 && num20 == 2462)
					{
						num11 = 2462;
					}
					else if (num12 > 2 && flag4 && num20 == 2482)
					{
						num11 = 2482;
					}
					else if (num12 > 2 && flag4 && num20 == 2472)
					{
						num11 = 2472;
					}
					else if (num12 > 2 && flag4 && num20 == 2460)
					{
						num11 = 2460;
					}
					else if (num12 > 1 && flag4)
					{
						num11 = 2303;
					}
					else if (num12 > 1 && flag3)
					{
						num11 = 2309;
					}
					else if (flag4 && num20 == 2487)
					{
						num11 = 2487;
					}
					else if (num5 > 1000 && flag3)
					{
						num11 = 2298;
					}
					else
					{
						num11 = 2290;
					}
				}
			}
			if (num11 > 0)
			{
				if (Main.player[this.owner].sonarPotion)
				{
					Item item = new Item();
					item.SetDefaults(num11, false);
					item.position = this.position;
					//ItemText.NewText(item, 1, true, false);
				}
				float num21 = (float)num7;
				this.ai[1] = (float)Main.rand.Next(-180, -60) - num21;
				this.localAI[1] = (float)num11;
				this.netUpdate = true;
			}
		}
		public void AI()
		{
			if(ServerApi.Hooks.InvokeProjectileAIUpdate(this))
			{
				return;
			}

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
				if (this.type == 408)
				{
					this.alpha -= 40;
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
					this.spriteDirection = this.direction;
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
				if (this.type == 408 && this.ai[1] == 0f)
				{
					this.ai[1] = 1f;
					Main.PlaySound(4, (int)this.position.X, (int)this.position.Y, 19);
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
				if (this.type == 389 && this.ai[1] == 0f)
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
				else if (this.type == 374)
				{
					if (this.localAI[0] == 0f)
					{
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 17);
						this.localAI[0] = 1f;
					}
					if (Main.rand.Next(2) == 0)
					{
						int num13 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 18, 0f, 0f, 0, default(Color), 0.9f);
						Main.dust[num13].noGravity = true;
						Main.dust[num13].velocity *= 0.5f;
					}
				}
				else if (this.type == 376)
				{
					if (this.localAI[0] == 0f)
					{
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 20);
					}
					this.localAI[0] += 1f;
					if (this.localAI[0] > 3f)
					{
						int num14 = 1;
						if (this.localAI[0] > 5f)
						{
							num14 = 2;
						}
						for (int i = 0; i < num14; i++)
						{
							int num15 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 2f), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 2f);
							Main.dust[num15].noGravity = true;
							Dust expr_109A_cp_0 = Main.dust[num15];
							expr_109A_cp_0.velocity.X = expr_109A_cp_0.velocity.X * 0.3f;
							Dust expr_10B8_cp_0 = Main.dust[num15];
							expr_10B8_cp_0.velocity.Y = expr_10B8_cp_0.velocity.Y * 0.3f;
							Main.dust[num15].noLight = true;
						}
						if (this.wet && !this.lavaWet)
						{
							this.Kill();
							return;
						}
					}
				}
				else if (this.type == 91 && Main.rand.Next(2) == 0)
				{
					int num16;
					if (Main.rand.Next(2) == 0)
					{
						num16 = 15;
					}
					else
					{
						num16 = 58;
					}
					int num17 = Dust.NewDust(this.position, this.width, this.height, num16, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 150, default(Color), 0.9f);
					Main.dust[num17].velocity *= 0.25f;
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
				if (this.type == 20 || this.type == 14 || this.type == 36 || this.type == 83 || this.type == 84 || this.type == 389 || this.type == 89 || this.type == 100 || this.type == 104 || this.type == 110 || this.type == 180 || this.type == 279 || (this.type >= 158 && this.type <= 161) || (this.type >= 283 && this.type <= 287))
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
					float num18 = (float)Math.Sqrt((double)(this.velocity.X * this.velocity.X + this.velocity.Y * this.velocity.Y));
					if (this.alpha > 0)
					{
						this.alpha -= (int)((byte)((double)num18 * 0.9));
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
				if (this.type != 376 && this.type != 350 && this.type != 349 && this.type != 348 && this.type != 5 && this.type != 325 && this.type != 323 && this.type != 14 && this.type != 270 && this.type != 180 && this.type != 259 && this.type != 242 && this.type != 302 && this.type != 20 && this.type != 36 && this.type != 38 && this.type != 55 && this.type != 83 && this.type != 84 && this.type != 389 && this.type != 88 && this.type != 89 && this.type != 98 && this.type != 100 && this.type != 265 && this.type != 104 && this.type != 110 && this.type != 184 && this.type != 257 && this.type != 248 && (this.type < 283 || this.type > 287) && this.type != 279 && this.type != 299 && this.type != 355 && (this.type < 158 || this.type > 161) && this.type != 374)
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
						for (int j = 0; j < 40; j++)
						{
							int num19 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 181, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num19].velocity *= 3f;
							Main.dust[num19].velocity += this.velocity * 0.75f;
							Main.dust[num19].scale *= 1.2f;
							Main.dust[num19].noGravity = true;
						}
					}
					this.localAI[0] += 1f;
					if (this.localAI[0] > 6f)
					{
						for (int k = 0; k < 3; k++)
						{
							int num20 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 181, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 1f);
							Main.dust[num20].velocity *= 0.6f;
							Main.dust[num20].scale *= 1.4f;
							Main.dust[num20].noGravity = true;
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
					for (int l = 0; l < 2; l++)
					{
						int num21 = Dust.NewDust(new Vector2(this.position.X + 4f, this.position.Y + 4f), this.width - 8, this.height - 8, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num21].position -= this.velocity * 2f;
						Main.dust[num21].noGravity = true;
						Dust expr_1B0E_cp_0 = Main.dust[num21];
						expr_1B0E_cp_0.velocity.X = expr_1B0E_cp_0.velocity.X * 0.3f;
						Dust expr_1B2C_cp_0 = Main.dust[num21];
						expr_1B2C_cp_0.velocity.Y = expr_1B2C_cp_0.velocity.Y * 0.3f;
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
						int num22 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 163, this.velocity.X, this.velocity.Y, 100, default(Color), 1.2f);
						Main.dust[num22].noGravity = true;
						Main.dust[num22].velocity *= 0.3f;
						Main.dust[num22].velocity -= this.velocity * 0.4f;
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
						int num23 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 205, this.velocity.X, this.velocity.Y, 100, default(Color), 1.2f);
						Main.dust[num23].noGravity = true;
						Main.dust[num23].velocity *= 0.3f;
						Main.dust[num23].velocity -= this.velocity * 0.4f;
					}
				}
				if (this.type == 357)
				{
					if (this.alpha < 170)
					{
						for (int m = 0; m < 10; m++)
						{
							float x = this.position.X - this.velocity.X / 10f * (float)m;
							float y = this.position.Y - this.velocity.Y / 10f * (float)m;
							int num24 = Dust.NewDust(new Vector2(x, y), 1, 1, 206, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num24].alpha = this.alpha;
							Main.dust[num24].position.X = x;
							Main.dust[num24].position.Y = y;
							Main.dust[num24].velocity *= 0f;
							Main.dust[num24].noGravity = true;
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
						for (int n = 0; n < 10; n++)
						{
							float x2 = this.position.X - this.velocity.X / 10f * (float)n;
							float y2 = this.position.Y - this.velocity.Y / 10f * (float)n;
							int num25 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 75, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num25].alpha = this.alpha;
							Main.dust[num25].position.X = x2;
							Main.dust[num25].position.Y = y2;
							Main.dust[num25].velocity *= 0f;
							Main.dust[num25].noGravity = true;
						}
					}
					float num26 = (float)Math.Sqrt((double)(this.velocity.X * this.velocity.X + this.velocity.Y * this.velocity.Y));
					float num27 = this.localAI[0];
					if (num27 == 0f)
					{
						this.localAI[0] = num26;
						num27 = num26;
					}
					if (this.alpha > 0)
					{
						this.alpha -= 25;
					}
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
					float num28 = this.position.X;
					float num29 = this.position.Y;
					float num30 = 300f;
					bool flag = false;
					int num31 = 0;
					if (this.ai[1] == 0f)
					{
						for (int num32 = 0; num32 < 200; num32++)
						{
							if (Main.npc[num32].active && !Main.npc[num32].dontTakeDamage && !Main.npc[num32].friendly && Main.npc[num32].lifeMax > 5 && (this.ai[1] == 0f || this.ai[1] == (float)(num32 + 1)))
							{
								float num33 = Main.npc[num32].position.X + (float)(Main.npc[num32].width / 2);
								float num34 = Main.npc[num32].position.Y + (float)(Main.npc[num32].height / 2);
								float num35 = Math.Abs(this.position.X + (float)(this.width / 2) - num33) + Math.Abs(this.position.Y + (float)(this.height / 2) - num34);
								if (num35 < num30 && Collision.CanHit(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2)), 1, 1, Main.npc[num32].position, Main.npc[num32].width, Main.npc[num32].height))
								{
									num30 = num35;
									num28 = num33;
									num29 = num34;
									flag = true;
									num31 = num32;
								}
							}
						}
						if (flag)
						{
							this.ai[1] = (float)(num31 + 1);
						}
						flag = false;
					}
					if (this.ai[1] != 0f)
					{
						int num36 = (int)(this.ai[1] - 1f);
						if (Main.npc[num36].active)
						{
							float num37 = Main.npc[num36].position.X + (float)(Main.npc[num36].width / 2);
							float num38 = Main.npc[num36].position.Y + (float)(Main.npc[num36].height / 2);
							float num39 = Math.Abs(this.position.X + (float)(this.width / 2) - num37) + Math.Abs(this.position.Y + (float)(this.height / 2) - num38);
							if (num39 < 1000f)
							{
								flag = true;
								num28 = Main.npc[num36].position.X + (float)(Main.npc[num36].width / 2);
								num29 = Main.npc[num36].position.Y + (float)(Main.npc[num36].height / 2);
							}
						}
					}
					if (flag)
					{
						float num40 = num27;
						Vector2 vector = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num41 = num28 - vector.X;
						float num42 = num29 - vector.Y;
						float num43 = (float)Math.Sqrt((double)(num41 * num41 + num42 * num42));
						num43 = num40 / num43;
						num41 *= num43;
						num42 *= num43;
						int num44 = 8;
						this.velocity.X = (this.velocity.X * (float)(num44 - 1) + num41) / (float)num44;
						this.velocity.Y = (this.velocity.Y * (float)(num44 - 1) + num42) / (float)num44;
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
						int num45 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 197, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num45].velocity *= 0.5f;
						Main.dust[num45].noGravity = true;
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
						int num46 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 67, this.velocity.X, this.velocity.Y, 100, default(Color), 1.2f);
						Main.dust[num46].noGravity = true;
						Main.dust[num46].velocity *= 0.3f;
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
					else if (this.type == 408)
					{
						if (this.ai[0] >= 45f)
						{
							this.ai[0] = 45f;
							this.velocity.Y = this.velocity.Y + 0.05f;
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
				else if (this.type == 408)
				{
					this.rotation = this.velocity.ToRotation();
					if (this.direction == -1)
					{
						this.rotation += 3.14159274f;
					}
				}
				else if (this.type != 344)
				{
					this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
				}
				if (this.velocity.Y > 16f)
				{
					this.velocity.Y = 16f;
				}
			}
			else if (this.aiStyle == 2)
			{
				if (this.type == 93 && Main.rand.Next(5) == 0)
				{
					int num47 = Dust.NewDust(this.position, this.width, this.height, 57, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 0.3f);
					Dust expr_2EC9_cp_0 = Main.dust[num47];
					expr_2EC9_cp_0.velocity.X = expr_2EC9_cp_0.velocity.X * 0.3f;
					Dust expr_2EE7_cp_0 = Main.dust[num47];
					expr_2EE7_cp_0.velocity.Y = expr_2EE7_cp_0.velocity.Y * 0.3f;
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
							for (int num48 = 0; num48 < 10; num48++)
							{
								int num49 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
								Main.dust[num49].velocity *= 0.5f;
								Main.dust[num49].velocity += this.velocity * 0.1f;
							}
							for (int num50 = 0; num50 < 5; num50++)
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
								Main.gore[num53].scale = 1.5f;
								Main.gore[num53].velocity += this.velocity * 0.5f;
								Main.gore[num53].velocity *= 0.02f;
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
							for (int num54 = 0; num54 < 10; num54++)
							{
								int num55 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
								Main.dust[num55].velocity *= 0.5f;
								Main.dust[num55].velocity += this.velocity * 0.1f;
							}
							for (int num56 = 0; num56 < 5; num56++)
							{
								int num57 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
								Main.dust[num57].noGravity = true;
								Main.dust[num57].velocity *= 3f;
								Main.dust[num57].velocity += this.velocity * 0.2f;
								num57 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
								Main.dust[num57].velocity *= 2f;
								Main.dust[num57].velocity += this.velocity * 0.3f;
							}
							for (int num58 = 0; num58 < 1; num58++)
							{
								int num59 = Gore.NewGore(new Vector2(this.position.X - 10f, this.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
								Main.gore[num59].position += this.velocity * 1.25f;
								Main.gore[num59].scale = 1.5f;
								Main.gore[num59].velocity += this.velocity * 0.5f;
								Main.gore[num59].velocity *= 0.02f;
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
							for (int num60 = 0; num60 < 7; num60++)
							{
								int num61 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
								Main.dust[num61].velocity *= 0.5f;
								Main.dust[num61].velocity += this.velocity * 0.1f;
							}
							for (int num62 = 0; num62 < 3; num62++)
							{
								int num63 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
								Main.dust[num63].noGravity = true;
								Main.dust[num63].velocity *= 3f;
								Main.dust[num63].velocity += this.velocity * 0.2f;
								num63 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
								Main.dust[num63].velocity *= 2f;
								Main.dust[num63].velocity += this.velocity * 0.3f;
							}
							for (int num64 = 0; num64 < 1; num64++)
							{
								int num65 = Gore.NewGore(new Vector2(this.position.X - 10f, this.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
								Main.gore[num65].position += this.velocity * 1.25f;
								Main.gore[num65].scale = 1.25f;
								Main.gore[num65].velocity += this.velocity * 0.5f;
								Main.gore[num65].velocity *= 0.02f;
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
						for (int num66 = 0; num66 < 4; num66++)
						{
							float num67 = this.velocity.X / 4f * (float)num66;
							float num68 = this.velocity.Y / 4f * (float)num66;
							int num69 = Dust.NewDust(this.position, this.width, this.height, 184, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num69].position.X = this.center().X - num67;
							Main.dust[num69].position.Y = this.center().Y - num68;
							Main.dust[num69].velocity *= 0f;
							Main.dust[num69].scale = 0.7f;
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
				else if (this.type == 370 || this.type == 371)
				{
					this.ai[0] += 1f;
					if (this.ai[0] >= 15f)
					{
						this.velocity.Y = this.velocity.Y + 0.3f;
						this.velocity.X = this.velocity.X * 0.98f;
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
				}
			}
			else if (this.aiStyle == 3)
			{
				if (this.soundDelay == 0 && this.type != 383)
				{
					this.soundDelay = 8;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 7);
				}
				if (this.type == 19)
				{
					for (int num70 = 0; num70 < 2; num70++)
					{
						int num71 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num71].noGravity = true;
						Dust expr_41A6_cp_0 = Main.dust[num71];
						expr_41A6_cp_0.velocity.X = expr_41A6_cp_0.velocity.X * 0.3f;
						Dust expr_41C4_cp_0 = Main.dust[num71];
						expr_41C4_cp_0.velocity.Y = expr_41C4_cp_0.velocity.Y * 0.3f;
					}
				}
				else if (this.type == 33)
				{
					if (Main.rand.Next(1) == 0)
					{
						int num72 = Dust.NewDust(this.position, this.width, this.height, 40, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 0, default(Color), 1.4f);
						Main.dust[num72].noGravity = true;
					}
				}
				else if (this.type == 320)
				{
					if (Main.rand.Next(3) == 0)
					{
						int num73 = Dust.NewDust(this.position, this.width, this.height, 5, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 0, default(Color), 1.1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num73].scale = 0.9f;
							Main.dust[num73].velocity *= 0.2f;
						}
						else
						{
							Main.dust[num73].noGravity = true;
						}
					}
				}
				else if (this.type == 6)
				{
					if (Main.rand.Next(5) == 0)
					{
						int num74 = Main.rand.Next(3);
						if (num74 == 0)
						{
							num74 = 15;
						}
						else if (num74 == 1)
						{
							num74 = 57;
						}
						else
						{
							num74 = 58;
						}
						Dust.NewDust(this.position, this.width, this.height, num74, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 150, default(Color), 0.7f);
					}
				}
				else if (this.type == 113 && Main.rand.Next(1) == 0)
				{
					int num75 = Dust.NewDust(this.position, this.width, this.height, 76, this.velocity.X * 0.15f, this.velocity.Y * 0.15f, 0, default(Color), 1.1f);
					Main.dust[num75].noGravity = true;
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
					if (this.type == 320 || this.type == 383)
					{
						if (this.ai[1] >= 10f)
						{
							this.velocity.Y = this.velocity.Y + 0.5f;
							if (this.type == 383 && this.velocity.Y < 0f)
							{
								this.velocity.Y = this.velocity.Y + 0.35f;
							}
							this.velocity.X = this.velocity.X * 0.95f;
							if (this.velocity.Y > 16f)
							{
								this.velocity.Y = 16f;
							}
							if (this.type == 383 && Vector2.Distance(this.center(), Main.player[this.owner].center()) > 800f)
							{
								this.ai[0] = 1f;
							}
						}
					}
					else if (this.type == 182)
					{
						if (Main.rand.Next(2) == 0)
						{
							int num76 = Dust.NewDust(this.position, this.width, this.height, 57, 0f, 0f, 255, default(Color), 0.75f);
							Main.dust[num76].velocity *= 0.1f;
							Main.dust[num76].noGravity = true;
						}
						if (this.velocity.X > 0f)
						{
							this.spriteDirection = 1;
						}
						else if (this.velocity.X < 0f)
						{
							this.spriteDirection = -1;
						}
						float num77 = this.position.X;
						float num78 = this.position.Y;
						bool flag2 = false;
						if (this.ai[1] > 10f)
						{
							for (int num79 = 0; num79 < 200; num79++)
							{
								if (Main.npc[num79].active && !Main.npc[num79].dontTakeDamage && !Main.npc[num79].friendly && Main.npc[num79].lifeMax > 5)
								{
									float num80 = Main.npc[num79].position.X + (float)(Main.npc[num79].width / 2);
									float num81 = Main.npc[num79].position.Y + (float)(Main.npc[num79].height / 2);
									float num82 = Math.Abs(this.position.X + (float)(this.width / 2) - num80) + Math.Abs(this.position.Y + (float)(this.height / 2) - num81);
									if (num82 < 800f && Collision.CanHit(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2)), 1, 1, Main.npc[num79].position, Main.npc[num79].width, Main.npc[num79].height))
									{
										num77 = num80;
										num78 = num81;
										flag2 = true;
									}
								}
							}
						}
						if (!flag2)
						{
							num77 = this.position.X + (float)(this.width / 2) + this.velocity.X * 100f;
							num78 = this.position.Y + (float)(this.height / 2) + this.velocity.Y * 100f;
							if (this.ai[1] >= 30f)
							{
								this.ai[0] = 1f;
								this.ai[1] = 0f;
								this.netUpdate = true;
							}
						}
						float num83 = 12f;
						float num84 = 0.25f;
						Vector2 vector2 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num85 = num77 - vector2.X;
						float num86 = num78 - vector2.Y;
						float num87 = (float)Math.Sqrt((double)(num85 * num85 + num86 * num86));
						num87 = num83 / num87;
						num85 *= num87;
						num86 *= num87;
						if (this.velocity.X < num85)
						{
							this.velocity.X = this.velocity.X + num84;
							if (this.velocity.X < 0f && num85 > 0f)
							{
								this.velocity.X = this.velocity.X + num84 * 2f;
							}
						}
						else if (this.velocity.X > num85)
						{
							this.velocity.X = this.velocity.X - num84;
							if (this.velocity.X > 0f && num85 < 0f)
							{
								this.velocity.X = this.velocity.X - num84 * 2f;
							}
						}
						if (this.velocity.Y < num86)
						{
							this.velocity.Y = this.velocity.Y + num84;
							if (this.velocity.Y < 0f && num86 > 0f)
							{
								this.velocity.Y = this.velocity.Y + num84 * 2f;
							}
						}
						else if (this.velocity.Y > num86)
						{
							this.velocity.Y = this.velocity.Y - num84;
							if (this.velocity.Y > 0f && num86 < 0f)
							{
								this.velocity.Y = this.velocity.Y - num84 * 2f;
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
					float num88 = 9f;
					float num89 = 0.4f;
					if (this.type == 19)
					{
						num88 = 13f;
						num89 = 0.6f;
					}
					else if (this.type == 33)
					{
						num88 = 15f;
						num89 = 0.8f;
					}
					else if (this.type == 182)
					{
						num88 = 16f;
						num89 = 1.2f;
					}
					else if (this.type == 106)
					{
						num88 = 16f;
						num89 = 1.2f;
					}
					else if (this.type == 272)
					{
						num88 = 15f;
						num89 = 1f;
					}
					else if (this.type == 333)
					{
						num88 = 12f;
						num89 = 0.6f;
					}
					else if (this.type == 301)
					{
						num88 = 15f;
						num89 = 3f;
					}
					else if (this.type == 320)
					{
						num88 = 15f;
						num89 = 3f;
					}
					else if (this.type == 383)
					{
						num88 = 16f;
						num89 = 4f;
					}
					Vector2 vector3 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num90 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector3.X;
					float num91 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector3.Y;
					float num92 = (float)Math.Sqrt((double)(num90 * num90 + num91 * num91));
					if (num92 > 3000f)
					{
						this.Kill();
					}
					num92 = num88 / num92;
					num90 *= num92;
					num91 *= num92;
					if (this.type == 383)
					{
						Vector2 vector4 = new Vector2(num90, num91) - this.velocity;
						if (vector4 != Vector2.Zero)
						{
							Vector2 value = vector4;
							value.Normalize();
							this.velocity += value * Math.Min(num89, vector4.Length());
						}
					}
					else if (this.velocity.X < num90)
					{
						this.velocity.X = this.velocity.X + num89;
						if (this.velocity.X < 0f && num90 > 0f)
						{
							this.velocity.X = this.velocity.X + num89;
						}
					}
					else if (this.velocity.X > num90)
					{
						this.velocity.X = this.velocity.X - num89;
						if (this.velocity.X > 0f && num90 < 0f)
						{
							this.velocity.X = this.velocity.X - num89;
						}
					}
					if (this.velocity.Y < num91)
					{
						this.velocity.Y = this.velocity.Y + num89;
						if (this.velocity.Y < 0f && num91 > 0f)
						{
							this.velocity.Y = this.velocity.Y + num89;
						}
					}
					else if (this.velocity.Y > num91)
					{
						this.velocity.Y = this.velocity.Y - num89;
						if (this.velocity.Y > 0f && num91 < 0f)
						{
							this.velocity.Y = this.velocity.Y - num89;
						}
					}
					if (Main.myPlayer == this.owner)
					{
						Rectangle rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
						Rectangle value2 = new Rectangle((int)Main.player[this.owner].position.X, (int)Main.player[this.owner].position.Y, Main.player[this.owner].width, Main.player[this.owner].height);
						if (rectangle.Intersects(value2))
						{
							this.Kill();
						}
					}
				}
				if (this.type == 106)
				{
					this.rotation += 0.3f * (float)this.direction;
				}
				else if (this.type == 383)
				{
					if (this.ai[0] == 0f)
					{
						Vector2 vector5 = this.velocity;
						vector5.Normalize();
						this.rotation = (float)Math.Atan2((double)vector5.Y, (double)vector5.X) + 1.57f;
					}
					else
					{
						Vector2 vector6 = this.center() - Main.player[this.owner].center();
						vector6.Normalize();
						this.rotation = (float)Math.Atan2((double)vector6.Y, (double)vector6.X) + 1.57f;
					}
				}
				else
				{
					this.rotation += 0.4f * (float)this.direction;
				}
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
							int num93 = this.type;
							if (this.ai[1] >= 6f)
							{
								num93++;
							}
							int num94 = Projectile.NewProjectile(this.position.X + this.velocity.X + (float)(this.width / 2), this.position.Y + this.velocity.Y + (float)(this.height / 2), this.velocity.X, this.velocity.Y, num93, this.damage, this.knockBack, this.owner, 0f, 0f);
							Main.projectile[num94].damage = this.damage;
							Main.projectile[num94].ai[1] = this.ai[1] + 1f;
							NetMessage.SendData(27, -1, -1, "", num94, 0f, 0f, 0f, 0);
						}
						else if ((this.type == 150 || this.type == 151) && Main.myPlayer == this.owner)
						{
							int num95 = this.type;
							if (this.type == 150)
							{
								num95 = 151;
							}
							else if (this.type == 151)
							{
								num95 = 150;
							}
							if (this.ai[1] >= 10f && this.type == 151)
							{
								num95 = 152;
							}
							int num96 = Projectile.NewProjectile(this.position.X + this.velocity.X + (float)(this.width / 2), this.position.Y + this.velocity.Y + (float)(this.height / 2), this.velocity.X, this.velocity.Y, num95, this.damage, this.knockBack, this.owner, 0f, 0f);
							Main.projectile[num96].damage = this.damage;
							Main.projectile[num96].ai[1] = this.ai[1] + 1f;
							NetMessage.SendData(27, -1, -1, "", num96, 0f, 0f, 0f, 0);
						}
					}
				}
				else
				{
					if (this.alpha < 170 && this.alpha + 5 >= 170)
					{
						if (this.type >= 150 && this.type <= 152)
						{
							for (int num97 = 0; num97 < 8; num97++)
							{
								int num98 = Dust.NewDust(this.position, this.width, this.height, 7, this.velocity.X * 0.025f, this.velocity.Y * 0.025f, 200, default(Color), 1.3f);
								Main.dust[num98].noGravity = true;
								Main.dust[num98].velocity *= 0.5f;
							}
						}
						else
						{
							for (int num99 = 0; num99 < 3; num99++)
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
					for (int num100 = 0; num100 < 30; num100++)
					{
						Dust.NewDust(this.position, this.width, this.height, 10 + this.type, this.velocity.X, this.velocity.Y, 50, default(Color), 1f);
					}
				}
				if (this.type == 10 || this.type == 11)
				{
					int num101 = (int)(this.position.X / 16f) - 1;
					int num102 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num103 = (int)(this.position.Y / 16f) - 1;
					int num104 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num101 < 0)
					{
						num101 = 0;
					}
					if (num102 > Main.maxTilesX)
					{
						num102 = Main.maxTilesX;
					}
					if (num103 < 0)
					{
						num103 = 0;
					}
					if (num104 > Main.maxTilesY)
					{
						num104 = Main.maxTilesY;
					}
					for (int num105 = num101; num105 < num102; num105++)
					{
						for (int num106 = num103; num106 < num104; num106++)
						{
							Vector2 vector7;
							vector7.X = (float)(num105 * 16);
							vector7.Y = (float)(num106 * 16);
							if (this.position.X + (float)this.width > vector7.X && this.position.X < vector7.X + 16f && this.position.Y + (float)this.height > vector7.Y && this.position.Y < vector7.Y + 16f && Main.myPlayer == this.owner && Main.tile[num105, num106].active())
							{
								if (this.type == 10)
								{
									if (Main.tile[num105, num106].type == 23 || Main.tile[num105, num106].type == 199)
									{
										Main.tile[num105, num106].type = 2;
										WorldGen.SquareTileFrame(num105, num106, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num105, num106, 1);
										}
									}
									if (Main.tile[num105, num106].type == 25 || Main.tile[num105, num106].type == 203)
									{
										Main.tile[num105, num106].type = 1;
										WorldGen.SquareTileFrame(num105, num106, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num105, num106, 1);
										}
									}
									if (Main.tile[num105, num106].type == 112 || Main.tile[num105, num106].type == 234)
									{
										Main.tile[num105, num106].type = 53;
										WorldGen.SquareTileFrame(num105, num106, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num105, num106, 1);
										}
									}
									if (Main.tile[num105, num106].type == 163 || Main.tile[num105, num106].type == 200)
									{
										Main.tile[num105, num106].type = 161;
										WorldGen.SquareTileFrame(num105, num106, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num105, num106, 1);
										}
									}
								}
								else if (this.type == 11)
								{
									if (Main.tile[num105, num106].type == 109)
									{
										Main.tile[num105, num106].type = 2;
										WorldGen.SquareTileFrame(num105, num106, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num105, num106, 1);
										}
									}
									if (Main.tile[num105, num106].type == 116)
									{
										Main.tile[num105, num106].type = 53;
										WorldGen.SquareTileFrame(num105, num106, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num105, num106, 1);
										}
									}
									if (Main.tile[num105, num106].type == 117)
									{
										Main.tile[num105, num106].type = 1;
										WorldGen.SquareTileFrame(num105, num106, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num105, num106, 1);
										}
									}
									if (Main.tile[num105, num106].type == 164)
									{
										Main.tile[num105, num106].type = 161;
										WorldGen.SquareTileFrame(num105, num106, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, num105, num106, 1);
										}
									}
								}
							}
						}
					}
				}
			}
			else if (this.aiStyle == 7)
			{
				if (Main.player[this.owner].dead)
				{
					this.Kill();
					return;
				}
				Vector2 vector8 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float num107 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector8.X;
				float num108 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector8.Y;
				float num109 = (float)Math.Sqrt((double)(num107 * num107 + num108 * num108));
				this.rotation = (float)Math.Atan2((double)num108, (double)num107) - 1.57f;
				if (this.type == 256)
				{
					this.rotation = (float)Math.Atan2((double)num108, (double)num107) + 3.92500019f;
				}
				if (this.ai[0] == 0f)
				{
					if ((num109 > 300f && this.type == 13) || (num109 > 400f && this.type == 32) || (num109 > 440f && this.type == 73) || (num109 > 440f && this.type == 74) || (num109 > 250f && this.type == 165) || (num109 > 350f && this.type == 256) || (num109 > 500f && this.type == 315) || (num109 > 550f && this.type == 322) || (num109 > 400f && this.type == 331) || (num109 > 550f && this.type == 332) || (num109 > 400f && this.type == 372) || (num109 > 400f && this.type == 396))
					{
						this.ai[0] = 1f;
					}
					else if (this.type >= 230 && this.type <= 235)
					{
						int num110 = 300 + (this.type - 230) * 30;
						if (num109 > (float)num110)
						{
							this.ai[0] = 1f;
						}
					}
					int num111 = (int)(this.position.X / 16f) - 1;
					int num112 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num113 = (int)(this.position.Y / 16f) - 1;
					int num114 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num111 < 0)
					{
						num111 = 0;
					}
					if (num112 > Main.maxTilesX)
					{
						num112 = Main.maxTilesX;
					}
					if (num113 < 0)
					{
						num113 = 0;
					}
					if (num114 > Main.maxTilesY)
					{
						num114 = Main.maxTilesY;
					}
					for (int num115 = num111; num115 < num112; num115++)
					{
						int num116 = num113;
						while (num116 < num114)
						{
							if (Main.tile[num115, num116] == null)
							{
								Main.tile[num115, num116] = new Tile();
							}
							Vector2 vector9;
							vector9.X = (float)(num115 * 16);
							vector9.Y = (float)(num116 * 16);
							if (this.position.X + (float)this.width > vector9.X && this.position.X < vector9.X + 16f && this.position.Y + (float)this.height > vector9.Y && this.position.Y < vector9.Y + 16f && Main.tile[num115, num116].nactive() && (Main.tileSolid[(int)Main.tile[num115, num116].type] || Main.tile[num115, num116].type == 314) && (this.type != 403 || Main.tile[num115, num116].type == 314))
							{
								if (Main.player[this.owner].grapCount < 10)
								{
									Main.player[this.owner].grappling[Main.player[this.owner].grapCount] = this.whoAmI;
									Main.player[this.owner].grapCount++;
								}
								if (Main.myPlayer == this.owner)
								{
									int num117 = 0;
									int num118 = -1;
									int num119 = 100000;
									if (this.type == 73 || this.type == 74)
									{
										for (int num120 = 0; num120 < 1000; num120++)
										{
											if (num120 != this.whoAmI && Main.projectile[num120].active && Main.projectile[num120].owner == this.owner && Main.projectile[num120].aiStyle == 7 && Main.projectile[num120].ai[0] == 2f)
											{
												Main.projectile[num120].Kill();
											}
										}
									}
									else
									{
										int num121 = 3;
										if (this.type == 165)
										{
											num121 = 8;
										}
										if (this.type == 256)
										{
											num121 = 2;
										}
										if (this.type == 372)
										{
											num121 = 1;
										}
										for (int num122 = 0; num122 < 1000; num122++)
										{
											if (Main.projectile[num122].active && Main.projectile[num122].owner == this.owner && Main.projectile[num122].aiStyle == 7)
											{
												if (Main.projectile[num122].timeLeft < num119)
												{
													num118 = num122;
													num119 = Main.projectile[num122].timeLeft;
												}
												num117++;
											}
										}
										if (num117 > num121)
										{
											Main.projectile[num118].Kill();
										}
									}
								}
								WorldGen.KillTile(num115, num116, true, true, false);
								Main.PlaySound(0, num115 * 16, num116 * 16, 1);
								this.velocity.X = 0f;
								this.velocity.Y = 0f;
								this.ai[0] = 2f;
								this.position.X = (float)(num115 * 16 + 8 - this.width / 2);
								this.position.Y = (float)(num116 * 16 + 8 - this.height / 2);
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
								num116++;
							}
						}
						if (this.ai[0] == 2f)
						{
							break;
						}
					}
				}
				else if (this.ai[0] == 1f)
				{
					float num123 = 11f;
					if (this.type == 32)
					{
						num123 = 15f;
					}
					if (this.type == 73 || this.type == 74)
					{
						num123 = 17f;
					}
					if (this.type == 315)
					{
						num123 = 20f;
					}
					if (this.type == 322)
					{
						num123 = 22f;
					}
					if (this.type >= 230 && this.type <= 235)
					{
						num123 = 11f + (float)(this.type - 230) * 0.75f;
					}
					if (this.type == 332)
					{
						num123 = 17f;
					}
					if (num109 < 24f)
					{
						this.Kill();
					}
					num109 = num123 / num109;
					num107 *= num109;
					num108 *= num109;
					this.velocity.X = num107;
					this.velocity.Y = num108;
				}
				else if (this.ai[0] == 2f)
				{
					int num124 = (int)(this.position.X / 16f) - 1;
					int num125 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num126 = (int)(this.position.Y / 16f) - 1;
					int num127 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num124 < 0)
					{
						num124 = 0;
					}
					if (num125 > Main.maxTilesX)
					{
						num125 = Main.maxTilesX;
					}
					if (num126 < 0)
					{
						num126 = 0;
					}
					if (num127 > Main.maxTilesY)
					{
						num127 = Main.maxTilesY;
					}
					bool flag3 = true;
					for (int num128 = num124; num128 < num125; num128++)
					{
						for (int num129 = num126; num129 < num127; num129++)
						{
							if (Main.tile[num128, num129] == null)
							{
								Main.tile[num128, num129] = new Tile();
							}
							Vector2 vector10;
							vector10.X = (float)(num128 * 16);
							vector10.Y = (float)(num129 * 16);
							if (this.position.X + (float)(this.width / 2) > vector10.X && this.position.X + (float)(this.width / 2) < vector10.X + 16f && this.position.Y + (float)(this.height / 2) > vector10.Y && this.position.Y + (float)(this.height / 2) < vector10.Y + 16f && Main.tile[num128, num129].nactive() && (Main.tileSolid[(int)Main.tile[num128, num129].type] || Main.tile[num128, num129].type == 314))
							{
								flag3 = false;
							}
						}
					}
					if (flag3)
					{
						this.ai[0] = 1f;
					}
					else if (Main.player[this.owner].grapCount < 10)
					{
						Main.player[this.owner].grappling[Main.player[this.owner].grapCount] = this.whoAmI;
						Main.player[this.owner].grapCount++;
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
					for (int num130 = 0; num130 < 5; num130++)
					{
						float num131 = this.velocity.X / 3f * (float)num130;
						float num132 = this.velocity.Y / 3f * (float)num130;
						int num133 = 4;
						int num134 = Dust.NewDust(new Vector2(this.position.X + (float)num133, this.position.Y + (float)num133), this.width - num133 * 2, this.height - num133 * 2, 172, 0f, 0f, 100, default(Color), 1.2f);
						Main.dust[num134].noGravity = true;
						Main.dust[num134].velocity *= 0.1f;
						Main.dust[num134].velocity += this.velocity * 0.1f;
						Dust expr_692D_cp_0 = Main.dust[num134];
						expr_692D_cp_0.position.X = expr_692D_cp_0.position.X - num131;
						Dust expr_6948_cp_0 = Main.dust[num134];
						expr_6948_cp_0.position.Y = expr_6948_cp_0.position.Y - num132;
					}
					if (Main.rand.Next(5) == 0)
					{
						int num135 = 4;
						int num136 = Dust.NewDust(new Vector2(this.position.X + (float)num135, this.position.Y + (float)num135), this.width - num135 * 2, this.height - num135 * 2, 172, 0f, 0f, 100, default(Color), 0.6f);
						Main.dust[num136].velocity *= 0.25f;
						Main.dust[num136].velocity += this.velocity * 0.5f;
					}
				}
				else if (this.type == 95 || this.type == 96)
				{
					int num137 = Dust.NewDust(new Vector2(this.position.X + this.velocity.X, this.position.Y + this.velocity.Y), this.width, this.height, 75, this.velocity.X, this.velocity.Y, 100, default(Color), 3f * this.scale);
					Main.dust[num137].noGravity = true;
				}
				else if (this.type == 253)
				{
					for (int num138 = 0; num138 < 2; num138++)
					{
						int num139 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 135, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num139].noGravity = true;
						Dust expr_6B66_cp_0 = Main.dust[num139];
						expr_6B66_cp_0.velocity.X = expr_6B66_cp_0.velocity.X * 0.3f;
						Dust expr_6B84_cp_0 = Main.dust[num139];
						expr_6B84_cp_0.velocity.Y = expr_6B84_cp_0.velocity.Y * 0.3f;
					}
				}
				else
				{
					for (int num140 = 0; num140 < 2; num140++)
					{
						int num141 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num141].noGravity = true;
						Dust expr_6C31_cp_0 = Main.dust[num141];
						expr_6C31_cp_0.velocity.X = expr_6C31_cp_0.velocity.X * 0.3f;
						Dust expr_6C4F_cp_0 = Main.dust[num141];
						expr_6C4F_cp_0.velocity.Y = expr_6C4F_cp_0.velocity.Y * 0.3f;
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
				}
			}
			else if (this.aiStyle == 9)
			{
				if (this.type == 34)
				{
					int num142 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 3.5f);
					Main.dust[num142].noGravity = true;
					Main.dust[num142].velocity *= 1.4f;
					num142 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 1.5f);
				}
				else if (this.type == 79)
				{
					if (this.soundDelay == 0 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 2f)
					{
						this.soundDelay = 10;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 9);
					}
					for (int num143 = 0; num143 < 1; num143++)
					{
						int num144 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 66, 0f, 0f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 2.5f);
						Main.dust[num144].velocity *= 0.1f;
						Main.dust[num144].velocity += this.velocity * 0.2f;
						Main.dust[num144].position.X = this.position.X + (float)(this.width / 2) + 4f + (float)Main.rand.Next(-2, 3);
						Main.dust[num144].position.Y = this.position.Y + (float)(this.height / 2) + (float)Main.rand.Next(-2, 3);
						Main.dust[num144].noGravity = true;
					}
				}
				else
				{
					if (this.soundDelay == 0 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 2f)
					{
						this.soundDelay = 10;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 9);
					}
					int num145 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 15, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num145].velocity *= 0.3f;
					Main.dust[num145].position.X = this.position.X + (float)(this.width / 2) + 4f + (float)Main.rand.Next(-4, 5);
					Main.dust[num145].position.Y = this.position.Y + (float)(this.height / 2) + (float)Main.rand.Next(-4, 5);
					Main.dust[num145].noGravity = true;
				}
				if (Main.myPlayer == this.owner && this.ai[0] == 0f)
				{
					if (Main.player[this.owner].channel)
					{
						float num146 = 12f;
						if (this.type == 16)
						{
							num146 = 15f;
						}
						Vector2 vector11 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num147 = (float)Main.mouseX + Main.screenPosition.X - vector11.X;
						float num148 = (float)Main.mouseY + Main.screenPosition.Y - vector11.Y;
						if (Main.player[this.owner].gravDir == -1f)
						{
							num148 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector11.Y;
						}
						float num149 = (float)Math.Sqrt((double)(num147 * num147 + num148 * num148));
						num149 = (float)Math.Sqrt((double)(num147 * num147 + num148 * num148));
						if (num149 > num146)
						{
							num149 = num146 / num149;
							num147 *= num149;
							num148 *= num149;
							int num150 = (int)(num147 * 1000f);
							int num151 = (int)(this.velocity.X * 1000f);
							int num152 = (int)(num148 * 1000f);
							int num153 = (int)(this.velocity.Y * 1000f);
							if (num150 != num151 || num152 != num153)
							{
								this.netUpdate = true;
							}
							this.velocity.X = num147;
							this.velocity.Y = num148;
						}
						else
						{
							int num154 = (int)(num147 * 1000f);
							int num155 = (int)(this.velocity.X * 1000f);
							int num156 = (int)(num148 * 1000f);
							int num157 = (int)(this.velocity.Y * 1000f);
							if (num154 != num155 || num156 != num157)
							{
								this.netUpdate = true;
							}
							this.velocity.X = num147;
							this.velocity.Y = num148;
						}
					}
					else if (this.ai[0] == 0f)
					{
						this.ai[0] = 1f;
						this.netUpdate = true;
						float num158 = 12f;
						Vector2 vector12 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num159 = (float)Main.mouseX + Main.screenPosition.X - vector12.X;
						float num160 = (float)Main.mouseY + Main.screenPosition.Y - vector12.Y;
						if (Main.player[this.owner].gravDir == -1f)
						{
							num160 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector12.Y;
						}
						float num161 = (float)Math.Sqrt((double)(num159 * num159 + num160 * num160));
						if (num161 == 0f)
						{
							vector12 = new Vector2(Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2), Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2));
							num159 = this.position.X + (float)this.width * 0.5f - vector12.X;
							num160 = this.position.Y + (float)this.height * 0.5f - vector12.Y;
							num161 = (float)Math.Sqrt((double)(num159 * num159 + num160 * num160));
						}
						num161 = num158 / num161;
						num159 *= num161;
						num160 *= num161;
						this.velocity.X = num159;
						this.velocity.Y = num160;
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
				}
			}
			else if (this.aiStyle == 10)
			{
				if (this.type == 31 && this.ai[0] != 2f)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num162 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 32, 0f, this.velocity.Y / 2f, 0, default(Color), 1f);
						Dust expr_7670_cp_0 = Main.dust[num162];
						expr_7670_cp_0.velocity.X = expr_7670_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 39)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num163 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 38, 0f, this.velocity.Y / 2f, 0, default(Color), 1f);
						Dust expr_770A_cp_0 = Main.dust[num163];
						expr_770A_cp_0.velocity.X = expr_770A_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type >= 411 && this.type <= 414)
				{
					if (Main.rand.Next(3) == 0)
					{
						int num164 = 9;
						if (this.type == 412 || this.type == 414)
						{
							num164 = 11;
						}
						if (this.type == 413)
						{
							num164 = 19;
						}
						int num165 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num164, 0f, this.velocity.Y / 2f, 0, default(Color), 1f);
						Main.dust[num165].noGravity = true;
						Main.dust[num165].velocity -= this.velocity * 0.5f;
					}
				}
				else if (this.type == 40)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num166 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 36, 0f, this.velocity.Y / 2f, 0, default(Color), 1f);
						Main.dust[num166].velocity *= 0.4f;
					}
				}
				else if (this.type == 42 || this.type == 31)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num167 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 32, 0f, 0f, 0, default(Color), 1f);
						Dust expr_7933_cp_0 = Main.dust[num167];
						expr_7933_cp_0.velocity.X = expr_7933_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 56 || this.type == 65)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num168 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 0, default(Color), 1f);
						Dust expr_79CB_cp_0 = Main.dust[num168];
						expr_79CB_cp_0.velocity.X = expr_79CB_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 67 || this.type == 68)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num169 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 51, 0f, 0f, 0, default(Color), 1f);
						Dust expr_7A63_cp_0 = Main.dust[num169];
						expr_7A63_cp_0.velocity.X = expr_7A63_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 71)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num170 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 53, 0f, 0f, 0, default(Color), 1f);
						Dust expr_7AF1_cp_0 = Main.dust[num170];
						expr_7AF1_cp_0.velocity.X = expr_7AF1_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 179)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num171 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 149, 0f, 0f, 0, default(Color), 1f);
						Dust expr_7B85_cp_0 = Main.dust[num171];
						expr_7B85_cp_0.velocity.X = expr_7B85_cp_0.velocity.X * 0.4f;
					}
				}
				else if (this.type == 241 || this.type == 354)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num172 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 36, 0f, 0f, 0, default(Color), 1f);
						Dust expr_7C20_cp_0 = Main.dust[num172];
						expr_7C20_cp_0.velocity.X = expr_7C20_cp_0.velocity.X * 0.4f;
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
						float num173 = 12f;
						Vector2 vector13 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num174 = (float)Main.mouseX + Main.screenPosition.X - vector13.X;
						float num175 = (float)Main.mouseY + Main.screenPosition.Y - vector13.Y;
						if (Main.player[this.owner].gravDir == -1f)
						{
							num175 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector13.Y;
						}
						float num176 = (float)Math.Sqrt((double)(num174 * num174 + num175 * num175));
						num176 = (float)Math.Sqrt((double)(num174 * num174 + num175 * num175));
						if (num176 > num173)
						{
							num176 = num173 / num176;
							num174 *= num176;
							num175 *= num176;
							if (num174 != this.velocity.X || num175 != this.velocity.Y)
							{
								this.netUpdate = true;
							}
							this.velocity.X = num174;
							this.velocity.Y = num175;
						}
						else
						{
							if (num174 != this.velocity.X || num175 != this.velocity.Y)
							{
								this.netUpdate = true;
							}
							this.velocity.X = num174;
							this.velocity.Y = num175;
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
						int num177 = 56;
						if (this.type == 86)
						{
							num177 = 73;
						}
						else if (this.type == 87)
						{
							num177 = 74;
						}
						int num178 = Dust.NewDust(this.position, this.width, this.height, num177, 0f, 0f, 200, default(Color), 0.8f);
						Main.dust[num178].velocity *= 0.3f;
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
				if (!Main.player[this.owner].dead)
				{
					float num179 = 3f;
					if (this.type == 72 || this.type == 86 || this.type == 87)
					{
						num179 = 3.75f;
					}
					Vector2 vector14 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num180 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector14.X;
					float num181 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector14.Y;
					int num182 = 70;
					if (this.type == 18)
					{
						if (Main.player[this.owner].controlUp)
						{
							num181 = Main.player[this.owner].position.Y - 40f - vector14.Y;
							num180 -= 6f;
							num182 = 4;
						}
						else if (Main.player[this.owner].controlDown)
						{
							num181 = Main.player[this.owner].position.Y + (float)Main.player[this.owner].height + 40f - vector14.Y;
							num180 -= 6f;
							num182 = 4;
						}
					}
					float num183 = (float)Math.Sqrt((double)(num180 * num180 + num181 * num181));
					num183 = (float)Math.Sqrt((double)(num180 * num180 + num181 * num181));
					if (this.type == 72 || this.type == 86 || this.type == 87)
					{
						num182 = 40;
					}
					if (num183 > 800f)
					{
						this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
						this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
					}
					else if (num183 > (float)num182)
					{
						num183 = num179 / num183;
						num180 *= num183;
						num181 *= num183;
						this.velocity.X = num180;
						this.velocity.Y = num181;
					}
					else
					{
						this.velocity.X = 0f;
						this.velocity.Y = 0f;
					}
				}
				else
				{
					this.Kill();
				}
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
					if (this.ai[0] > 3f)
					{
						this.velocity.Y = this.velocity.Y + 0.075f;
						for (int num184 = 0; num184 < 3; num184++)
						{
							float num185 = this.velocity.X / 3f * (float)num184;
							float num186 = this.velocity.Y / 3f * (float)num184;
							int num187 = 14;
							int num188 = Dust.NewDust(new Vector2(this.position.X + (float)num187, this.position.Y + (float)num187), this.width - num187 * 2, this.height - num187 * 2, 170, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num188].noGravity = true;
							Main.dust[num188].velocity *= 0.1f;
							Main.dust[num188].velocity += this.velocity * 0.5f;
							Dust expr_869B_cp_0 = Main.dust[num188];
							expr_869B_cp_0.position.X = expr_869B_cp_0.position.X - num185;
							Dust expr_86B6_cp_0 = Main.dust[num188];
							expr_86B6_cp_0.position.Y = expr_86B6_cp_0.position.Y - num186;
						}
						if (Main.rand.Next(8) == 0)
						{
							int num189 = 16;
							int num190 = Dust.NewDust(new Vector2(this.position.X + (float)num189, this.position.Y + (float)num189), this.width - num189 * 2, this.height - num189 * 2, 170, 0f, 0f, 100, default(Color), 0.5f);
							Main.dust[num190].velocity *= 0.25f;
							Main.dust[num190].velocity += this.velocity * 0.5f;
						}
					}
					else
					{
						this.ai[0] += 1f;
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
						for (int num191 = 0; num191 < 1; num191++)
						{
							for (int num192 = 0; num192 < 3; num192++)
							{
								float num193 = this.velocity.X / 3f * (float)num192;
								float num194 = this.velocity.Y / 3f * (float)num192;
								int num195 = 6;
								int num196 = Dust.NewDust(new Vector2(this.position.X + (float)num195, this.position.Y + (float)num195), this.width - num195 * 2, this.height - num195 * 2, 172, 0f, 0f, 100, default(Color), 1.2f);
								Main.dust[num196].noGravity = true;
								Main.dust[num196].velocity *= 0.3f;
								Main.dust[num196].velocity += this.velocity * 0.5f;
								Dust expr_8909_cp_0 = Main.dust[num196];
								expr_8909_cp_0.position.X = expr_8909_cp_0.position.X - num193;
								Dust expr_8924_cp_0 = Main.dust[num196];
								expr_8924_cp_0.position.Y = expr_8924_cp_0.position.Y - num194;
							}
							if (Main.rand.Next(8) == 0)
							{
								int num197 = 6;
								int num198 = Dust.NewDust(new Vector2(this.position.X + (float)num197, this.position.Y + (float)num197), this.width - num197 * 2, this.height - num197 * 2, 172, 0f, 0f, 100, default(Color), 0.75f);
								Main.dust[num198].velocity *= 0.5f;
								Main.dust[num198].velocity += this.velocity * 0.5f;
							}
						}
					}
					else
					{
						this.ai[0] += 1f;
					}
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
				Vector2 vector15 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float num199 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector15.X;
				float num200 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector15.Y;
				float num201 = (float)Math.Sqrt((double)(num199 * num199 + num200 * num200));
				if (this.ai[0] == 0f)
				{
					if (num201 > 700f)
					{
						this.ai[0] = 1f;
					}
					else if (this.type == 262 && num201 > 500f)
					{
						this.ai[0] = 1f;
					}
					else if (this.type == 271 && num201 > 200f)
					{
						this.ai[0] = 1f;
					}
					else if (this.type == 273 && num201 > 150f)
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
					if (this.type == 404 && this.ai[1] > 8f)
					{
						this.ai[1] = 0f;
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
					}
					else if (this.type == 271)
					{
						this.spriteDirection = 1;
					}
				}
				else if (this.ai[0] == 1f)
				{
					this.tileCollide = false;
					this.rotation = (float)Math.Atan2((double)num200, (double)num199) - 1.57f;
					float num202 = 20f;
					if (this.type == 262)
					{
						num202 = 30f;
					}
					if (num201 < 50f)
					{
						this.Kill();
					}
					num201 = num202 / num201;
					num199 *= num201;
					num200 *= num201;
					this.velocity.X = num199;
					this.velocity.Y = num200;
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
					}
					else if (this.type == 271)
					{
						this.spriteDirection = -1;
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
						for (int num203 = 0; num203 < 5; num203++)
						{
							float num204 = 10f;
							Vector2 vector16 = new Vector2(this.center().X, this.center().Y);
							float num205 = (float)Main.rand.Next(-20, 21);
							float num206 = (float)Main.rand.Next(-20, 0);
							float num207 = (float)Math.Sqrt((double)(num205 * num205 + num206 * num206));
							num207 = num204 / num207;
							num205 *= num207;
							num206 *= num207;
							num205 *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
							num206 *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
							Projectile.NewProjectile(vector16.X, vector16.Y, num205, num206, 347, 40, 0f, Main.myPlayer, 0f, this.ai[1]);
						}
					}
				}
				if (this.type == 196)
				{
					int num208 = Main.rand.Next(1, 3);
					for (int num209 = 0; num209 < num208; num209++)
					{
						int num210 = Dust.NewDust(this.position, this.width, this.height, 31, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num210].alpha += Main.rand.Next(100);
						Main.dust[num210].velocity *= 0.3f;
						Dust expr_91CC_cp_0 = Main.dust[num210];
						expr_91CC_cp_0.velocity.X = expr_91CC_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.025f;
						Dust expr_91FA_cp_0 = Main.dust[num210];
						expr_91FA_cp_0.velocity.Y = expr_91FA_cp_0.velocity.Y - (0.4f + (float)Main.rand.Next(-3, 14) * 0.15f);
						Main.dust[num210].fadeIn = 1.25f + (float)Main.rand.Next(20) * 0.15f;
					}
				}
				if (this.type == 53)
				{
					try
					{
						Vector2 value3 = Collision.TileCollision(this.position, this.velocity, this.width, this.height, false, false, 1);
						//this.velocity != value3; TODO:DECOMPILER BS
						int num211 = (int)(this.position.X / 16f) - 1;
						int num212 = (int)((this.position.X + (float)this.width) / 16f) + 2;
						int num213 = (int)(this.position.Y / 16f) - 1;
						int num214 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
						if (num211 < 0)
						{
							num211 = 0;
						}
						if (num212 > Main.maxTilesX)
						{
							num212 = Main.maxTilesX;
						}
						if (num213 < 0)
						{
							num213 = 0;
						}
						if (num214 > Main.maxTilesY)
						{
							num214 = Main.maxTilesY;
						}
						for (int num215 = num211; num215 < num212; num215++)
						{
							for (int num216 = num213; num216 < num214; num216++)
							{
								if (Main.tile[num215, num216] != null && Main.tile[num215, num216].nactive() && (Main.tileSolid[(int)Main.tile[num215, num216].type] || (Main.tileSolidTop[(int)Main.tile[num215, num216].type] && Main.tile[num215, num216].frameY == 0)))
								{
									Vector2 vector17;
									vector17.X = (float)(num215 * 16);
									vector17.Y = (float)(num216 * 16);
									if (this.position.X + (float)this.width > vector17.X && this.position.X < vector17.X + 16f && this.position.Y + (float)this.height > vector17.Y && this.position.Y < vector17.Y + 16f)
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
				else if (this.type == 378)
				{
					if (this.localAI[0] == 0f)
					{
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 17);
						this.localAI[0] += 1f;
					}
					Rectangle rectangle2 = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
					for (int num217 = 0; num217 < 200; num217++)
					{
						if (Main.npc[num217].active && !Main.npc[num217].friendly && Main.npc[num217].lifeMax > 5)
						{
							Rectangle value4 = new Rectangle((int)Main.npc[num217].position.X, (int)Main.npc[num217].position.Y, Main.npc[num217].width, Main.npc[num217].height);
							if (rectangle2.Intersects(value4))
							{
								this.Kill();
								return;
							}
						}
					}
					this.ai[0] += 1f;
					if (this.ai[0] > 10f)
					{
						this.ai[0] = 90f;
						if (this.velocity.Y == 0f && this.velocity.X != 0f)
						{
							this.velocity.X = this.velocity.X * 0.96f;
							if ((double)this.velocity.X > -0.01 && (double)this.velocity.X < 0.01)
							{
								this.Kill();
							}
						}
						this.velocity.Y = this.velocity.Y + 0.2f;
					}
					this.rotation += this.velocity.X * 0.1f;
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
				if ((this.type >= 326 && this.type <= 328) || (this.type >= 400 && this.type <= 402))
				{
					if (this.wet)
					{
						this.Kill();
					}
					if (this.ai[1] == 0f && this.type >= 326 && this.type <= 328)
					{
						this.ai[1] = 1f;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 13);
					}
					int num218 = Dust.NewDust(this.position, this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
					Dust expr_999B_cp_0 = Main.dust[num218];
					expr_999B_cp_0.position.X = expr_999B_cp_0.position.X - 2f;
					Dust expr_99B9_cp_0 = Main.dust[num218];
					expr_99B9_cp_0.position.Y = expr_99B9_cp_0.position.Y + 2f;
					Main.dust[num218].scale += (float)Main.rand.Next(50) * 0.01f;
					Main.dust[num218].noGravity = true;
					Dust expr_9A0C_cp_0 = Main.dust[num218];
					expr_9A0C_cp_0.velocity.Y = expr_9A0C_cp_0.velocity.Y - 2f;
					if (Main.rand.Next(2) == 0)
					{
						int num219 = Dust.NewDust(this.position, this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
						Dust expr_9A73_cp_0 = Main.dust[num219];
						expr_9A73_cp_0.position.X = expr_9A73_cp_0.position.X - 2f;
						Dust expr_9A91_cp_0 = Main.dust[num219];
						expr_9A91_cp_0.position.Y = expr_9A91_cp_0.position.Y + 2f;
						Main.dust[num219].scale += 0.3f + (float)Main.rand.Next(50) * 0.01f;
						Main.dust[num219].noGravity = true;
						Main.dust[num219].velocity *= 0.1f;
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
					int num220 = Dust.NewDust(this.position, this.width, this.height, 172, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 100, default(Color), 1.5f);
					Main.dust[num220].noGravity = true;
					Dust expr_9C67_cp_0 = Main.dust[num220];
					expr_9C67_cp_0.velocity.X = expr_9C67_cp_0.velocity.X / 2f;
					Dust expr_9C85_cp_0 = Main.dust[num220];
					expr_9C85_cp_0.velocity.Y = expr_9C85_cp_0.velocity.Y / 2f;
				}
				else if (this.type == 35)
				{
					int num221 = Dust.NewDust(this.position, this.width, this.height, 6, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 100, default(Color), 3f);
					Main.dust[num221].noGravity = true;
					Dust expr_9D1A_cp_0 = Main.dust[num221];
					expr_9D1A_cp_0.velocity.X = expr_9D1A_cp_0.velocity.X * 2f;
					Dust expr_9D3A_cp_0 = Main.dust[num221];
					expr_9D3A_cp_0.velocity.Y = expr_9D3A_cp_0.velocity.Y * 2f;
				}
				else if (this.type == 154)
				{
					int num222 = Dust.NewDust(this.position, this.width, this.height, 115, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 140, default(Color), 1.5f);
					Main.dust[num222].noGravity = true;
					Main.dust[num222].velocity *= 0.25f;
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
				Vector2 vector18 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float num223 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector18.X;
				float num224 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector18.Y;
				float num225 = (float)Math.Sqrt((double)(num223 * num223 + num224 * num224));
				if (this.ai[0] == 0f)
				{
					float num226 = 160f;
					if (this.type == 63)
					{
						num226 *= 1.5f;
					}
					if (this.type == 247)
					{
						num226 *= 1.5f;
					}
					this.tileCollide = true;
					if (num225 > num226)
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
					float num227 = 14f / Main.player[this.owner].meleeSpeed;
					float num228 = 0.9f / Main.player[this.owner].meleeSpeed;
					float num229 = 300f;
					if (this.type == 63)
					{
						num229 *= 1.5f;
						num227 *= 1.5f;
						num228 *= 1.5f;
					}
					if (this.type == 247)
					{
						num229 *= 1.5f;
						num227 = 15.9f;
						num228 *= 2f;
					}
					Math.Abs(num223);
					Math.Abs(num224);
					if (this.ai[1] == 1f)
					{
						this.tileCollide = false;
					}
					if (!Main.player[this.owner].channel || num225 > num229 || !this.tileCollide)
					{
						this.ai[1] = 1f;
						if (this.tileCollide)
						{
							this.netUpdate = true;
						}
						this.tileCollide = false;
						if (num225 < 20f)
						{
							this.Kill();
						}
					}
					if (!this.tileCollide)
					{
						num228 *= 2f;
					}
					int num230 = 60;
					if (this.type == 247)
					{
						num230 = 100;
					}
					if (num225 > (float)num230 || !this.tileCollide)
					{
						num225 = num227 / num225;
						num223 *= num225;
						num224 *= num225;
						new Vector2(this.velocity.X, this.velocity.Y);
						float num231 = num223 - this.velocity.X;
						float num232 = num224 - this.velocity.Y;
						float num233 = (float)Math.Sqrt((double)(num231 * num231 + num232 * num232));
						num233 = num228 / num233;
						num231 *= num233;
						num232 *= num233;
						this.velocity.X = this.velocity.X * 0.98f;
						this.velocity.Y = this.velocity.Y * 0.98f;
						this.velocity.X = this.velocity.X + num231;
						this.velocity.Y = this.velocity.Y + num232;
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
				if (this.type == 247)
				{
					if (this.velocity.X < 0f)
					{
						this.rotation -= (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.01f;
					}
					else
					{
						this.rotation += (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.01f;
					}
					float num234 = this.position.X;
					float num235 = this.position.Y;
					float num236 = 600f;
					bool flag4 = false;
					if (this.owner == Main.myPlayer)
					{
						this.localAI[1] += 1f;
						if (this.localAI[1] > 20f)
						{
							this.localAI[1] = 20f;
							for (int num237 = 0; num237 < 200; num237++)
							{
								if (Main.npc[num237].active && !Main.npc[num237].dontTakeDamage && !Main.npc[num237].friendly && Main.npc[num237].lifeMax > 5)
								{
									float num238 = Main.npc[num237].position.X + (float)(Main.npc[num237].width / 2);
									float num239 = Main.npc[num237].position.Y + (float)(Main.npc[num237].height / 2);
									float num240 = Math.Abs(this.position.X + (float)(this.width / 2) - num238) + Math.Abs(this.position.Y + (float)(this.height / 2) - num239);
									if (num240 < num236 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num237].position, Main.npc[num237].width, Main.npc[num237].height))
									{
										num236 = num240;
										num234 = num238;
										num235 = num239;
										flag4 = true;
									}
								}
							}
						}
					}
					if (flag4)
					{
						this.localAI[1] = 0f;
						float num241 = 14f;
						vector18 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						num223 = num234 - vector18.X;
						num224 = num235 - vector18.Y;
						num225 = (float)Math.Sqrt((double)(num223 * num223 + num224 * num224));
						num225 = num241 / num225;
						num223 *= num225;
						num224 *= num225;
						Projectile.NewProjectile(vector18.X, vector18.Y, num223, num224, 248, (int)((double)this.damage / 1.5), this.knockBack / 2f, Main.myPlayer, 0f, 0f);
					}
				}
				else
				{
					this.rotation = (float)Math.Atan2((double)num224, (double)num223) - this.velocity.X * 0.1f;
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
				if (this.type != 37)
				{
					if (this.type != 397)
					{
						goto IL_A9FB;
					}
				}
				try
				{
					int num242 = (int)(this.position.X / 16f) - 1;
					int num243 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num244 = (int)(this.position.Y / 16f) - 1;
					int num245 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num242 < 0)
					{
						num242 = 0;
					}
					if (num243 > Main.maxTilesX)
					{
						num243 = Main.maxTilesX;
					}
					if (num244 < 0)
					{
						num244 = 0;
					}
					if (num245 > Main.maxTilesY)
					{
						num245 = Main.maxTilesY;
					}
					for (int num246 = num242; num246 < num243; num246++)
					{
						for (int num247 = num244; num247 < num245; num247++)
						{
							if (Main.tile[num246, num247] != null && Main.tile[num246, num247].nactive() && (Main.tileSolid[(int)Main.tile[num246, num247].type] || (Main.tileSolidTop[(int)Main.tile[num246, num247].type] && Main.tile[num246, num247].frameY == 0)))
							{
								Vector2 vector19;
								vector19.X = (float)(num246 * 16);
								vector19.Y = (float)(num247 * 16);
								if (this.position.X + (float)this.width - 4f > vector19.X && this.position.X + 4f < vector19.X + 16f && this.position.Y + (float)this.height - 4f > vector19.Y && this.position.Y + 4f < vector19.Y + 16f)
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
				IL_A9FB:
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
					else if (this.type == 30 || this.type == 397)
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
					if (this.type != 30 && this.type != 397 && this.type != 108 && this.type != 133 && this.type != 134 && this.type != 135 && this.type != 136 && this.type != 137 && this.type != 138 && this.type != 139 && this.type != 140 && this.type != 141 && this.type != 142 && this.type != 143 && this.type != 144 && this.type != 164 && this.type != 303 && this.type < 338 && this.type < 341)
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
						for (int num248 = 0; num248 < 2; num248++)
						{
							float num249 = 0f;
							float num250 = 0f;
							if (num248 == 1)
							{
								num249 = this.velocity.X * 0.5f;
								num250 = this.velocity.Y * 0.5f;
							}
							if (this.localAI[1] > 9f)
							{
								if (Main.rand.Next(2) == 0)
								{
									int num251 = Dust.NewDust(new Vector2(this.position.X + 3f + num249, this.position.Y + 3f + num250) - this.velocity * 0.5f, this.width - 8, this.height - 8, 6, 0f, 0f, 100, default(Color), 1f);
									Main.dust[num251].scale *= 1.4f + (float)Main.rand.Next(10) * 0.1f;
									Main.dust[num251].velocity *= 0.2f;
									Main.dust[num251].noGravity = true;
								}
								if (Main.rand.Next(2) == 0)
								{
									int num252 = Dust.NewDust(new Vector2(this.position.X + 3f + num249, this.position.Y + 3f + num250) - this.velocity * 0.5f, this.width - 8, this.height - 8, 31, 0f, 0f, 100, default(Color), 0.5f);
									Main.dust[num252].fadeIn = 0.5f + (float)Main.rand.Next(5) * 0.1f;
									Main.dust[num252].velocity *= 0.05f;
								}
							}
						}
						float num253 = this.position.X;
						float num254 = this.position.Y;
						float num255 = 600f;
						bool flag5 = false;
						this.ai[0] += 1f;
						if (this.ai[0] > 30f)
						{
							this.ai[0] = 30f;
							for (int num256 = 0; num256 < 200; num256++)
							{
								if (Main.npc[num256].active && !Main.npc[num256].dontTakeDamage && !Main.npc[num256].friendly && Main.npc[num256].lifeMax > 5)
								{
									float num257 = Main.npc[num256].position.X + (float)(Main.npc[num256].width / 2);
									float num258 = Main.npc[num256].position.Y + (float)(Main.npc[num256].height / 2);
									float num259 = Math.Abs(this.position.X + (float)(this.width / 2) - num257) + Math.Abs(this.position.Y + (float)(this.height / 2) - num258);
									if (num259 < num255 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num256].position, Main.npc[num256].width, Main.npc[num256].height))
									{
										num255 = num259;
										num253 = num257;
										num254 = num258;
										flag5 = true;
									}
								}
							}
						}
						if (!flag5)
						{
							num253 = this.position.X + (float)(this.width / 2) + this.velocity.X * 100f;
							num254 = this.position.Y + (float)(this.height / 2) + this.velocity.Y * 100f;
						}
						float num260 = 16f;
						Vector2 vector20 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num261 = num253 - vector20.X;
						float num262 = num254 - vector20.Y;
						float num263 = (float)Math.Sqrt((double)(num261 * num261 + num262 * num262));
						num263 = num260 / num263;
						num261 *= num263;
						num262 *= num263;
						this.velocity.X = (this.velocity.X * 11f + num261) / 12f;
						this.velocity.Y = (this.velocity.Y * 11f + num262) / 12f;
					}
					else if (this.type == 134 || this.type == 137 || this.type == 140 || this.type == 143 || this.type == 303)
					{
						if (Math.Abs(this.velocity.X) >= 8f || Math.Abs(this.velocity.Y) >= 8f)
						{
							for (int num264 = 0; num264 < 2; num264++)
							{
								float num265 = 0f;
								float num266 = 0f;
								if (num264 == 1)
								{
									num265 = this.velocity.X * 0.5f;
									num266 = this.velocity.Y * 0.5f;
								}
								int num267 = Dust.NewDust(new Vector2(this.position.X + 3f + num265, this.position.Y + 3f + num266) - this.velocity * 0.5f, this.width - 8, this.height - 8, 6, 0f, 0f, 100, default(Color), 1f);
								Main.dust[num267].scale *= 2f + (float)Main.rand.Next(10) * 0.1f;
								Main.dust[num267].velocity *= 0.2f;
								Main.dust[num267].noGravity = true;
								num267 = Dust.NewDust(new Vector2(this.position.X + 3f + num265, this.position.Y + 3f + num266) - this.velocity * 0.5f, this.width - 8, this.height - 8, 31, 0f, 0f, 100, default(Color), 0.5f);
								Main.dust[num267].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
								Main.dust[num267].velocity *= 0.05f;
							}
						}
						if (Math.Abs(this.velocity.X) < 15f && Math.Abs(this.velocity.Y) < 15f)
						{
							this.velocity *= 1.1f;
						}
					}
					else if (this.type == 133 || this.type == 136 || this.type == 139 || this.type == 142)
					{
						int num268 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num268].scale *= 1f + (float)Main.rand.Next(10) * 0.1f;
						Main.dust[num268].velocity *= 0.2f;
						Main.dust[num268].noGravity = true;
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
							int num269 = Dust.NewDust(new Vector2(this.position.X + 3f, this.position.Y + 3f) - this.velocity * 0.5f, this.width - 8, this.height - 8, 31, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num269].scale *= 1.6f + (float)Main.rand.Next(5) * 0.1f;
							Main.dust[num269].velocity *= 0.05f;
							Main.dust[num269].noGravity = true;
						}
					}
					else if (this.type != 30 && this.type != 397 && Main.rand.Next(2) == 0)
					{
						int num270 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num270].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
						Main.dust[num270].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
						Main.dust[num270].noGravity = true;
						Main.dust[num270].position = this.center() + new Vector2(0f, (float)(-(float)this.height / 2)).Rotate((double)this.rotation, default(Vector2)) * 1.1f;
						Main.rand.Next(2);
						num270 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num270].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
						Main.dust[num270].noGravity = true;
						Main.dust[num270].position = this.center() + new Vector2(0f, (float)(-(float)this.height / 2 - 6)).Rotate((double)this.rotation, default(Vector2)) * 1.1f;
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
				else if (((this.type == 30 || this.type == 397) && this.ai[0] > 10f) || (this.type != 30 && this.type != 397 && this.ai[0] > 5f))
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
					int num271 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
					int num272 = (int)((this.position.Y + (float)this.height - 4f) / 16f);
					if (Main.tile[num271, num272] != null && !Main.tile[num271, num272].active())
					{
						int num273 = 0;
						if (this.type >= 201 && this.type <= 205)
						{
							num273 = this.type - 200;
						}
						WorldGen.PlaceTile(num271, num272, 85, false, false, this.owner, num273);
						if (Main.tile[num271, num272].active())
						{
							if (Main.netMode != 0)
							{
								NetMessage.SendData(17, -1, -1, "", 1, (float)num271, (float)num272, 85f, num273);
							}
							int num274 = Sign.ReadSign(num271, num272);
							if (num274 >= 0)
							{
								Sign.TextSign(num274, this.miscText);
							}
							this.Kill();
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
				if (this.type == 263 || this.type == 274)
				{
					if (this.type == 274 && this.velocity.X < 0f)
					{
						this.spriteDirection = -1;
					}
					this.rotation += (float)this.direction * 0.05f;
					this.rotation += (float)this.direction * 0.5f * ((float)this.timeLeft / 180f);
					if (this.type == 274)
					{
						this.velocity *= 0.96f;
					}
					else
					{
						this.velocity *= 0.95f;
					}
				}
				else
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
					for (int num275 = 0; num275 < 2; num275++)
					{
						int num276 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 27, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num276].noGravity = true;
					}
				}
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
					else if (this.type == 367)
					{
						this.spriteDirection = -this.direction;
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
							this.ai[0] += 1.5f;
						}
					}
					else if (this.type == 368)
					{
						this.spriteDirection = -this.direction;
						if (this.ai[0] == 0f)
						{
							this.ai[0] = 3f;
							this.netUpdate = true;
						}
						if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
						{
							this.ai[0] -= 1.5f;
						}
						else
						{
							this.ai[0] += 1.4f;
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
					int num277 = Dust.NewDust(this.position, this.width, this.height, 27, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.2f);
					Main.dust[num277].noGravity = true;
					Dust expr_D417_cp_0 = Main.dust[num277];
					expr_D417_cp_0.velocity.X = expr_D417_cp_0.velocity.X / 2f;
					Dust expr_D437_cp_0 = Main.dust[num277];
					expr_D437_cp_0.velocity.Y = expr_D437_cp_0.velocity.Y / 2f;
					num277 = Dust.NewDust(this.position - this.velocity * 2f, this.width, this.height, 27, 0f, 0f, 150, default(Color), 1.4f);
					Dust expr_D4AB_cp_0 = Main.dust[num277];
					expr_D4AB_cp_0.velocity.X = expr_D4AB_cp_0.velocity.X / 5f;
					Dust expr_D4CB_cp_0 = Main.dust[num277];
					expr_D4CB_cp_0.velocity.Y = expr_D4CB_cp_0.velocity.Y / 5f;
				}
				else if (this.type == 105)
				{
					if (Main.rand.Next(3) == 0)
					{
						int num278 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 57, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 200, default(Color), 1.2f);
						Main.dust[num278].velocity += this.velocity * 0.3f;
						Main.dust[num278].velocity *= 0.2f;
					}
					if (Main.rand.Next(4) == 0)
					{
						int num279 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 43, 0f, 0f, 254, default(Color), 0.3f);
						Main.dust[num279].velocity += this.velocity * 0.5f;
						Main.dust[num279].velocity *= 0.5f;
					}
				}
				else if (this.type == 153)
				{
					int num280 = Dust.NewDust(this.position - this.velocity * 3f, this.width, this.height, 115, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 140, default(Color), 1f);
					Main.dust[num280].noGravity = true;
					Main.dust[num280].fadeIn = 1.25f;
					Main.dust[num280].velocity *= 0.25f;
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
						float num281 = Main.player[this.owner].inventory[Main.player[this.owner].selectedItem].shootSpeed * this.scale;
						Vector2 vector21 = new Vector2(Main.player[this.owner].position.X + (float)Main.player[this.owner].width * 0.5f, Main.player[this.owner].position.Y + (float)Main.player[this.owner].height * 0.5f);
						float num282 = (float)Main.mouseX + Main.screenPosition.X - vector21.X;
						float num283 = (float)Main.mouseY + Main.screenPosition.Y - vector21.Y;
						if (Main.player[this.owner].gravDir == -1f)
						{
							num283 = (float)(Main.screenHeight - Main.mouseY) + Main.screenPosition.Y - vector21.Y;
						}
						float num284 = (float)Math.Sqrt((double)(num282 * num282 + num283 * num283));
						num284 = (float)Math.Sqrt((double)(num282 * num282 + num283 * num283));
						num284 = num281 / num284;
						num282 *= num284;
						num283 *= num284;
						if (num282 != this.velocity.X || num283 != this.velocity.Y)
						{
							this.netUpdate = true;
						}
						this.velocity.X = num282;
						this.velocity.Y = num283;
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
					int num285 = Dust.NewDust(this.position + this.velocity * (float)Main.rand.Next(6, 10) * 0.1f, this.width, this.height, 31, 0f, 0f, 80, default(Color), 1.4f);
					Dust expr_DC36_cp_0 = Main.dust[num285];
					expr_DC36_cp_0.position.X = expr_DC36_cp_0.position.X - 4f;
					Main.dust[num285].noGravity = true;
					Main.dust[num285].velocity *= 0.2f;
					Main.dust[num285].velocity.Y = (float)(-(float)Main.rand.Next(7, 13)) * 0.15f;
				}
			}
			else if (this.aiStyle == 21)
			{
				this.rotation = this.velocity.X * 0.1f;
				this.spriteDirection = -this.direction;
				if (Main.rand.Next(3) == 0)
				{
					int num286 = Dust.NewDust(this.position, this.width, this.height, 27, 0f, 0f, 80, default(Color), 1f);
					Main.dust[num286].noGravity = true;
					Main.dust[num286].velocity *= 0.2f;
				}
				if (this.ai[1] == 1f)
				{
					this.ai[1] = 0f;
					Main.harpNote = this.ai[0];
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 26);
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
					int num287 = (int)(this.position.X / 16f) - 1;
					int num288 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num289 = (int)(this.position.Y / 16f) - 1;
					int num290 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num287 < 0)
					{
						num287 = 0;
					}
					if (num288 > Main.maxTilesX)
					{
						num288 = Main.maxTilesX;
					}
					if (num289 < 0)
					{
						num289 = 0;
					}
					if (num290 > Main.maxTilesY)
					{
						num290 = Main.maxTilesY;
					}
					int num291 = (int)this.position.X + 4;
					int num292 = (int)this.position.Y + 4;
					for (int num293 = num287; num293 < num288; num293++)
					{
						for (int num294 = num289; num294 < num290; num294++)
						{
							if (Main.tile[num293, num294] != null && Main.tile[num293, num294].active() && Main.tile[num293, num294].type != 127 && Main.tileSolid[(int)Main.tile[num293, num294].type] && !Main.tileSolidTop[(int)Main.tile[num293, num294].type])
							{
								Vector2 vector22;
								vector22.X = (float)(num293 * 16);
								vector22.Y = (float)(num294 * 16);
								if ((float)(num291 + 8) > vector22.X && (float)num291 < vector22.X + 16f && (float)(num292 + 8) > vector22.Y && (float)num292 < vector22.Y + 16f)
								{
									this.Kill();
								}
							}
						}
					}
					int num295 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num295].noGravity = true;
					Main.dust[num295].velocity *= 0.3f;
				}
				else if (this.ai[0] < 0f)
				{
					if (this.ai[0] == -1f)
					{
						for (int num296 = 0; num296 < 10; num296++)
						{
							int num297 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0f, 0f, 0, default(Color), 1.1f);
							Main.dust[num297].noGravity = true;
							Main.dust[num297].velocity *= 1.3f;
						}
					}
					else if (Main.rand.Next(30) == 0)
					{
						int num298 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num298].velocity *= 0.2f;
					}
					int num299 = (int)this.position.X / 16;
					int num300 = (int)this.position.Y / 16;
					if (Main.tile[num299, num300] == null || !Main.tile[num299, num300].active())
					{
						this.Kill();
					}
					this.ai[0] -= 1f;
					if (this.ai[0] <= -300f && (Main.myPlayer == this.owner || Main.netMode == 2) && Main.tile[num299, num300].active() && Main.tile[num299, num300].type == 127)
					{
						WorldGen.KillTile(num299, num300, false, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(17, -1, -1, "", 0, (float)num299, (float)num300, 0f, 0);
						}
						this.Kill();
					}
				}
				else
				{
					int num301 = (int)(this.position.X / 16f) - 1;
					int num302 = (int)((this.position.X + (float)this.width) / 16f) + 2;
					int num303 = (int)(this.position.Y / 16f) - 1;
					int num304 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
					if (num301 < 0)
					{
						num301 = 0;
					}
					if (num302 > Main.maxTilesX)
					{
						num302 = Main.maxTilesX;
					}
					if (num303 < 0)
					{
						num303 = 0;
					}
					if (num304 > Main.maxTilesY)
					{
						num304 = Main.maxTilesY;
					}
					int num305 = (int)this.position.X + 4;
					int num306 = (int)this.position.Y + 4;
					for (int num307 = num301; num307 < num302; num307++)
					{
						for (int num308 = num303; num308 < num304; num308++)
						{
							if (Main.tile[num307, num308] != null && Main.tile[num307, num308].nactive() && Main.tile[num307, num308].type != 127 && Main.tileSolid[(int)Main.tile[num307, num308].type] && !Main.tileSolidTop[(int)Main.tile[num307, num308].type])
							{
								Vector2 vector23;
								vector23.X = (float)(num307 * 16);
								vector23.Y = (float)(num308 * 16);
								if ((float)(num305 + 8) > vector23.X && (float)num305 < vector23.X + 16f && (float)(num306 + 8) > vector23.Y && (float)num306 < vector23.Y + 16f)
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
						int num309 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num309].noGravity = true;
						Main.dust[num309].velocity *= 0.3f;
						int num310 = (int)this.ai[0];
						int num311 = (int)this.ai[1];
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
							int num312 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
							int num313 = (int)((this.position.Y + (float)(this.height / 2)) / 16f);
							bool flag6 = false;
							if (num312 == num310 && num313 == num311)
							{
								flag6 = true;
							}
							if (((this.velocity.X <= 0f && num312 <= num310) || (this.velocity.X >= 0f && num312 >= num310)) && ((this.velocity.Y <= 0f && num313 <= num311) || (this.velocity.Y >= 0f && num313 >= num311)))
							{
								flag6 = true;
							}
							if (flag6)
							{
								if (WorldGen.PlaceTile(num310, num311, 127, false, false, this.owner, 0))
								{
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 1, (float)((int)this.ai[0]), (float)((int)this.ai[1]), 127f, 0);
									}
									this.damage = 0;
									this.ai[0] = -1f;
									this.velocity *= 0f;
									this.alpha = 255;
									this.position.X = (float)(num310 * 16);
									this.position.Y = (float)(num311 * 16);
									this.netUpdate = true;
								}
								else
								{
									this.ai[1] = -1f;
								}
							}
						}
					}
				}
			}
			else if (this.aiStyle == 23)
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
					float num314 = 1f;
					if (this.ai[0] == 8f)
					{
						num314 = 0.25f;
					}
					else if (this.ai[0] == 9f)
					{
						num314 = 0.5f;
					}
					else if (this.ai[0] == 10f)
					{
						num314 = 0.75f;
					}
					this.ai[0] += 1f;
					int num315 = 6;
					if (this.type == 101)
					{
						num315 = 75;
					}
					if (num315 == 6 || Main.rand.Next(2) == 0)
					{
						for (int num316 = 0; num316 < 1; num316++)
						{
							int num317 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num315, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 1f);
							if (Main.rand.Next(3) != 0 || (num315 == 75 && Main.rand.Next(3) == 0))
							{
								Main.dust[num317].noGravity = true;
								Main.dust[num317].scale *= 3f;
								Dust expr_E9B8_cp_0 = Main.dust[num317];
								expr_E9B8_cp_0.velocity.X = expr_E9B8_cp_0.velocity.X * 2f;
								Dust expr_E9D8_cp_0 = Main.dust[num317];
								expr_E9D8_cp_0.velocity.Y = expr_E9D8_cp_0.velocity.Y * 2f;
							}
							if (this.type == 188)
							{
								Main.dust[num317].scale *= 1.25f;
							}
							else
							{
								Main.dust[num317].scale *= 1.5f;
							}
							Dust expr_EA3D_cp_0 = Main.dust[num317];
							expr_EA3D_cp_0.velocity.X = expr_EA3D_cp_0.velocity.X * 1.2f;
							Dust expr_EA5D_cp_0 = Main.dust[num317];
							expr_EA5D_cp_0.velocity.Y = expr_EA5D_cp_0.velocity.Y * 1.2f;
							Main.dust[num317].scale *= num314;
							if (num315 == 75)
							{
								Main.dust[num317].velocity += this.velocity;
								if (!Main.dust[num317].noGravity)
								{
									Main.dust[num317].velocity *= 0.5f;
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
			}
			else if (this.aiStyle == 24)
			{
				this.light = this.scale * 0.5f;
				this.rotation += this.velocity.X * 0.2f;
				this.ai[1] += 1f;
				if (this.type == 94)
				{
					if (Main.rand.Next(4) == 0)
					{
						int num318 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 70, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num318].noGravity = true;
						Main.dust[num318].velocity *= 0.5f;
						Main.dust[num318].scale *= 0.9f;
					}
					this.velocity *= 0.985f;
					if (this.ai[1] > 130f)
					{
						this.scale -= 0.05f;
						if ((double)this.scale <= 0.2)
						{
							this.scale = 0.2f;
							this.Kill();
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
						}
					}
				}
			}
			else if (this.aiStyle == 25)
			{
				if (this.ai[0] != 0f && this.velocity.Y <= 0f && this.velocity.X == 0f)
				{
					float num319 = 0.5f;
					int i2 = (int)((this.position.X - 8f) / 16f);
					int num320 = (int)(this.position.Y / 16f);
					bool flag7 = false;
					bool flag8 = false;
					if (WorldGen.SolidTile(i2, num320) || WorldGen.SolidTile(i2, num320 + 1))
					{
						flag7 = true;
					}
					i2 = (int)((this.position.X + (float)this.width + 8f) / 16f);
					if (WorldGen.SolidTile(i2, num320) || WorldGen.SolidTile(i2, num320 + 1))
					{
						flag8 = true;
					}
					if (flag7)
					{
						this.velocity.X = num319;
					}
					else if (flag8)
					{
						this.velocity.X = -num319;
					}
					else
					{
						i2 = (int)((this.position.X - 8f - 16f) / 16f);
						num320 = (int)(this.position.Y / 16f);
						flag7 = false;
						flag8 = false;
						if (WorldGen.SolidTile(i2, num320) || WorldGen.SolidTile(i2, num320 + 1))
						{
							flag7 = true;
						}
						i2 = (int)((this.position.X + (float)this.width + 8f + 16f) / 16f);
						if (WorldGen.SolidTile(i2, num320) || WorldGen.SolidTile(i2, num320 + 1))
						{
							flag8 = true;
						}
						if (flag7)
						{
							this.velocity.X = num319;
						}
						else if (flag8)
						{
							this.velocity.X = -num319;
						}
						else
						{
							i2 = (int)((this.position.X + 4f) / 16f);
							num320 = (int)((this.position.Y + (float)this.height + 8f) / 16f);
							if (WorldGen.SolidTile(i2, num320) || WorldGen.SolidTile(i2, num320 + 1))
							{
								flag7 = true;
							}
							if (!flag7)
							{
								this.velocity.X = num319;
							}
							else
							{
								this.velocity.X = -num319;
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
			}
			else if (this.aiStyle == 26)
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
				int num321 = 85;
				if (this.type == 324)
				{
					num321 = 120;
				}
				if (this.type == 112)
				{
					num321 = 100;
				}
				if (this.type == 127)
				{
					num321 = 50;
				}
				if (this.type >= 191 && this.type <= 194)
				{
					if (this.lavaWet)
					{
						this.ai[0] = 1f;
						this.ai[1] = 0f;
					}
					num321 = 60 + 30 * this.minionPos;
				}
				else if (this.type == 266)
				{
					num321 = 60 + 30 * this.minionPos;
				}
				if (this.type == 111)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].bunny = false;
					}
					if (Main.player[this.owner].bunny)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 112)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].penguin = false;
					}
					if (Main.player[this.owner].penguin)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 334)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].puppy = false;
					}
					if (Main.player[this.owner].puppy)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 353)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].grinch = false;
					}
					if (Main.player[this.owner].grinch)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 127)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].turtle = false;
					}
					if (Main.player[this.owner].turtle)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 175)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].eater = false;
					}
					if (Main.player[this.owner].eater)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 197)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].skeletron = false;
					}
					if (Main.player[this.owner].skeletron)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 198)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].hornet = false;
					}
					if (Main.player[this.owner].hornet)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 199)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].tiki = false;
					}
					if (Main.player[this.owner].tiki)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 200)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].lizard = false;
					}
					if (Main.player[this.owner].lizard)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 208)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].parrot = false;
					}
					if (Main.player[this.owner].parrot)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 209)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].truffle = false;
					}
					if (Main.player[this.owner].truffle)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 210)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].sapling = false;
					}
					if (Main.player[this.owner].sapling)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 324)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].cSapling = false;
					}
					if (Main.player[this.owner].cSapling)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 313)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].spider = false;
					}
					if (Main.player[this.owner].spider)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 314)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].squashling = false;
					}
					if (Main.player[this.owner].squashling)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 211)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].wisp = false;
					}
					if (Main.player[this.owner].wisp)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 236)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].dino = false;
					}
					if (Main.player[this.owner].dino)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 266)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].slime = false;
					}
					if (Main.player[this.owner].slime)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 268)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].eyeSpring = false;
					}
					if (Main.player[this.owner].eyeSpring)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 269)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].snowman = false;
					}
					if (Main.player[this.owner].snowman)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 319)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].blackCat = false;
					}
					if (Main.player[this.owner].blackCat)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 380)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].zephyrfish = false;
					}
					if (Main.player[this.owner].zephyrfish)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type >= 191 && this.type <= 194)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].pygmy = false;
					}
					if (Main.player[this.owner].pygmy)
					{
						this.timeLeft = Main.rand.Next(2, 10);
					}
				}
				if (this.type >= 390 && this.type <= 392)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].spiderMinion = false;
					}
					if (Main.player[this.owner].spiderMinion)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 398)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].miniMinotaur = false;
					}
					if (Main.player[this.owner].miniMinotaur)
					{
						this.timeLeft = 2;
					}
				}
				if ((this.type >= 191 && this.type <= 194) || this.type == 266 || (this.type >= 390 && this.type <= 392))
				{
					num321 = 10;
					int num322 = 40 * (this.minionPos + 1) * Main.player[this.owner].direction;
					if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) < this.position.X + (float)(this.width / 2) - (float)num321 + (float)num322)
					{
						flag9 = true;
					}
					else if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) > this.position.X + (float)(this.width / 2) + (float)num321 + (float)num322)
					{
						flag10 = true;
					}
				}
				else if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) < this.position.X + (float)(this.width / 2) - (float)num321)
				{
					flag9 = true;
				}
				else if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) > this.position.X + (float)(this.width / 2) + (float)num321)
				{
					flag10 = true;
				}
				if (this.type == 175)
				{
					float num323 = 0.1f;
					this.tileCollide = false;
					int num324 = 300;
					Vector2 vector24 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num325 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector24.X;
					float num326 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector24.Y;
					if (this.type == 127)
					{
						num326 = Main.player[this.owner].position.Y - vector24.Y;
					}
					float num327 = (float)Math.Sqrt((double)(num325 * num325 + num326 * num326));
					float num328 = 7f;
					if (num327 < (float)num324 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
					{
						this.ai[0] = 0f;
						if (this.velocity.Y < -6f)
						{
							this.velocity.Y = -6f;
						}
					}
					if (num327 < 150f)
					{
						if (Math.Abs(this.velocity.X) > 2f || Math.Abs(this.velocity.Y) > 2f)
						{
							this.velocity *= 0.99f;
						}
						num323 = 0.01f;
						if (num325 < -2f)
						{
							num325 = -2f;
						}
						if (num325 > 2f)
						{
							num325 = 2f;
						}
						if (num326 < -2f)
						{
							num326 = -2f;
						}
						if (num326 > 2f)
						{
							num326 = 2f;
						}
					}
					else
					{
						if (num327 > 300f)
						{
							num323 = 0.2f;
						}
						num327 = num328 / num327;
						num325 *= num327;
						num326 *= num327;
					}
					if (Math.Abs(num325) > Math.Abs(num326) || num323 == 0.05f)
					{
						if (this.velocity.X < num325)
						{
							this.velocity.X = this.velocity.X + num323;
							if (num323 > 0.05f && this.velocity.X < 0f)
							{
								this.velocity.X = this.velocity.X + num323;
							}
						}
						if (this.velocity.X > num325)
						{
							this.velocity.X = this.velocity.X - num323;
							if (num323 > 0.05f && this.velocity.X > 0f)
							{
								this.velocity.X = this.velocity.X - num323;
							}
						}
					}
					if (Math.Abs(num325) <= Math.Abs(num326) || num323 == 0.05f)
					{
						if (this.velocity.Y < num326)
						{
							this.velocity.Y = this.velocity.Y + num323;
							if (num323 > 0.05f && this.velocity.Y < 0f)
							{
								this.velocity.Y = this.velocity.Y + num323;
							}
						}
						if (this.velocity.Y > num326)
						{
							this.velocity.Y = this.velocity.Y - num323;
							if (num323 > 0.05f && this.velocity.Y > 0f)
							{
								this.velocity.Y = this.velocity.Y - num323;
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
					}
				}
				else if (this.type == 197)
				{
					float num329 = 0.1f;
					this.tileCollide = false;
					int num330 = 300;
					Vector2 vector25 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num331 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector25.X;
					float num332 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector25.Y;
					if (this.type == 127)
					{
						num332 = Main.player[this.owner].position.Y - vector25.Y;
					}
					float num333 = (float)Math.Sqrt((double)(num331 * num331 + num332 * num332));
					float num334 = 3f;
					if (num333 > 500f)
					{
						this.localAI[0] = 10000f;
					}
					if (this.localAI[0] >= 10000f)
					{
						num334 = 14f;
					}
					if (num333 < (float)num330 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
					{
						this.ai[0] = 0f;
						if (this.velocity.Y < -6f)
						{
							this.velocity.Y = -6f;
						}
					}
					if (num333 < 150f)
					{
						if (Math.Abs(this.velocity.X) > 2f || Math.Abs(this.velocity.Y) > 2f)
						{
							this.velocity *= 0.99f;
						}
						num329 = 0.01f;
						if (num331 < -2f)
						{
							num331 = -2f;
						}
						if (num331 > 2f)
						{
							num331 = 2f;
						}
						if (num332 < -2f)
						{
							num332 = -2f;
						}
						if (num332 > 2f)
						{
							num332 = 2f;
						}
					}
					else
					{
						if (num333 > 300f)
						{
							num329 = 0.2f;
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
							this.velocity.Y = this.velocity.Y + num329;
						}
					}
					if (this.velocity.Y > num332)
					{
						this.velocity.Y = this.velocity.Y - num329;
						if (num329 > 0.05f && this.velocity.Y > 0f)
						{
							this.velocity.Y = this.velocity.Y - num329;
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
						float num335 = this.velocity.X * 0.1f;
						if (this.rotation > num335)
						{
							this.rotation -= (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.01f;
							if (this.rotation < num335)
							{
								this.rotation = num335;
							}
						}
						if (this.rotation < num335)
						{
							this.rotation += (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.01f;
							if (this.rotation > num335)
							{
								this.rotation = num335;
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
					}
				}
				else if (this.type == 198 || this.type == 380)
				{
					float num336 = 0.4f;
					if (this.type == 380)
					{
						num336 = 0.3f;
					}
					this.tileCollide = false;
					int num337 = 100;
					Vector2 vector26 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num338 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector26.X;
					float num339 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector26.Y;
					num339 += (float)Main.rand.Next(-10, 21);
					num338 += (float)Main.rand.Next(-10, 21);
					num338 += (float)(60 * -(float)Main.player[this.owner].direction);
					num339 -= 60f;
					if (this.type == 127)
					{
						num339 = Main.player[this.owner].position.Y - vector26.Y;
					}
					float num340 = (float)Math.Sqrt((double)(num338 * num338 + num339 * num339));
					float num341 = 14f;
					if (this.type == 380)
					{
						num341 = 6f;
					}
					if (num340 < (float)num337 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
					{
						this.ai[0] = 0f;
						if (this.velocity.Y < -6f)
						{
							this.velocity.Y = -6f;
						}
					}
					if (num340 < 50f)
					{
						if (Math.Abs(this.velocity.X) > 2f || Math.Abs(this.velocity.Y) > 2f)
						{
							this.velocity *= 0.99f;
						}
						num336 = 0.01f;
					}
					else
					{
						if (this.type == 380)
						{
							if (num340 < 100f)
							{
								num336 = 0.1f;
							}
							if (num340 > 300f)
							{
								num336 = 0.4f;
							}
						}
						else if (this.type == 198)
						{
							if (num340 < 100f)
							{
								num336 = 0.1f;
							}
							if (num340 > 300f)
							{
								num336 = 0.6f;
							}
						}
						num340 = num341 / num340;
						num338 *= num340;
						num339 *= num340;
					}
					if (this.velocity.X < num338)
					{
						this.velocity.X = this.velocity.X + num336;
						if (num336 > 0.05f && this.velocity.X < 0f)
						{
							this.velocity.X = this.velocity.X + num336;
						}
					}
					if (this.velocity.X > num338)
					{
						this.velocity.X = this.velocity.X - num336;
						if (num336 > 0.05f && this.velocity.X > 0f)
						{
							this.velocity.X = this.velocity.X - num336;
						}
					}
					if (this.velocity.Y < num339)
					{
						this.velocity.Y = this.velocity.Y + num336;
						if (num336 > 0.05f && this.velocity.Y < 0f)
						{
							this.velocity.Y = this.velocity.Y + num336 * 2f;
						}
					}
					if (this.velocity.Y > num339)
					{
						this.velocity.Y = this.velocity.Y - num336;
						if (num336 > 0.05f && this.velocity.Y > 0f)
						{
							this.velocity.Y = this.velocity.Y - num336 * 2f;
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
					int num342 = 2;
					if (this.type == 380)
					{
						num342 = 5;
					}
					if (this.frameCounter > num342)
					{
						this.frame++;
						this.frameCounter = 0;
					}
					if (this.frame > 3)
					{
						this.frame = 0;
					}
				}
				else if (this.type == 211)
				{
					float num343 = 0.2f;
					float num344 = 5f;
					this.tileCollide = false;
					Vector2 vector27 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num345 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector27.X;
					float num346 = Main.player[this.owner].position.Y + Main.player[this.owner].gfxOffY + (float)(Main.player[this.owner].height / 2) - vector27.Y;
					if (Main.player[this.owner].controlLeft)
					{
						num345 -= 120f;
					}
					else if (Main.player[this.owner].controlRight)
					{
						num345 += 120f;
					}
					if (Main.player[this.owner].controlDown)
					{
						num346 += 120f;
					}
					else
					{
						if (Main.player[this.owner].controlUp)
						{
							num346 -= 120f;
						}
						num346 -= 60f;
					}
					float num347 = (float)Math.Sqrt((double)(num345 * num345 + num346 * num346));
					if (num347 > 1000f)
					{
						this.position.X = this.position.X + num345;
						this.position.Y = this.position.Y + num346;
					}
					if (this.localAI[0] == 1f)
					{
						if (num347 < 10f && Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y) < num344 && Main.player[this.owner].velocity.Y == 0f)
						{
							this.localAI[0] = 0f;
						}
						num344 = 12f;
						if (num347 < num344)
						{
							this.velocity.X = num345;
							this.velocity.Y = num346;
						}
						else
						{
							num347 = num344 / num347;
							this.velocity.X = num345 * num347;
							this.velocity.Y = num346 * num347;
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
						for (int num348 = 0; num348 < 2; num348++)
						{
							int num349 = Dust.NewDust(new Vector2(this.position.X + 3f, this.position.Y + 4f), 14, 14, 156, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num349].velocity *= 0.2f;
							Main.dust[num349].noGravity = true;
							Main.dust[num349].scale = 1.25f;
						}
					}
					else
					{
						if (num347 > 200f)
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
						if (num347 < 10f)
						{
							this.velocity.X = num345;
							this.velocity.Y = num346;
							this.rotation = this.velocity.X * 0.05f;
							if (num347 < num344)
							{
								this.position += this.velocity;
								this.velocity *= 0f;
								num343 = 0f;
							}
							this.direction = -Main.player[this.owner].direction;
						}
						num347 = num344 / num347;
						num345 *= num347;
						num346 *= num347;
						if (this.velocity.X < num345)
						{
							this.velocity.X = this.velocity.X + num343;
							if (this.velocity.X < 0f)
							{
								this.velocity.X = this.velocity.X * 0.99f;
							}
						}
						if (this.velocity.X > num345)
						{
							this.velocity.X = this.velocity.X - num343;
							if (this.velocity.X > 0f)
							{
								this.velocity.X = this.velocity.X * 0.99f;
							}
						}
						if (this.velocity.Y < num346)
						{
							this.velocity.Y = this.velocity.Y + num343;
							if (this.velocity.Y < 0f)
							{
								this.velocity.Y = this.velocity.Y * 0.99f;
							}
						}
						if (this.velocity.Y > num346)
						{
							this.velocity.Y = this.velocity.Y - num343;
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
						}
					}
				}
				else if (this.type == 199)
				{
					float num350 = 0.1f;
					this.tileCollide = false;
					int num351 = 200;
					Vector2 vector28 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num352 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector28.X;
					float num353 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector28.Y;
					num353 -= 60f;
					num352 -= 2f;
					if (this.type == 127)
					{
						num353 = Main.player[this.owner].position.Y - vector28.Y;
					}
					float num354 = (float)Math.Sqrt((double)(num352 * num352 + num353 * num353));
					float num355 = 4f;
					float num356 = num354;
					if (num354 < (float)num351 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
					{
						this.ai[0] = 0f;
						if (this.velocity.Y < -6f)
						{
							this.velocity.Y = -6f;
						}
					}
					if (num354 < 4f)
					{
						this.velocity.X = num352;
						this.velocity.Y = num353;
						num350 = 0f;
					}
					else
					{
						if (num354 > 350f)
						{
							num350 = 0.2f;
							num355 = 10f;
						}
						num354 = num355 / num354;
						num352 *= num354;
						num353 *= num354;
					}
					if (this.velocity.X < num352)
					{
						this.velocity.X = this.velocity.X + num350;
						if (this.velocity.X < 0f)
						{
							this.velocity.X = this.velocity.X + num350;
						}
					}
					if (this.velocity.X > num352)
					{
						this.velocity.X = this.velocity.X - num350;
						if (this.velocity.X > 0f)
						{
							this.velocity.X = this.velocity.X - num350;
						}
					}
					if (this.velocity.Y < num353)
					{
						this.velocity.Y = this.velocity.Y + num350;
						if (this.velocity.Y < 0f)
						{
							this.velocity.Y = this.velocity.Y + num350;
						}
					}
					if (this.velocity.Y > num353)
					{
						this.velocity.Y = this.velocity.Y - num350;
						if (this.velocity.Y > 0f)
						{
							this.velocity.Y = this.velocity.Y - num350;
						}
					}
					this.direction = -Main.player[this.owner].direction;
					this.spriteDirection = 1;
					this.rotation = this.velocity.Y * 0.05f * (float)(-(float)this.direction);
					if (num356 >= 50f)
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
						}
					}
				}
				else
				{
					if (this.ai[1] == 0f)
					{
						int num357 = 500;
						if (this.type == 127)
						{
							num357 = 200;
						}
						if (this.type == 208)
						{
							num357 = 300;
						}
						if ((this.type >= 191 && this.type <= 194) || this.type == 266 || (this.type >= 390 && this.type <= 392))
						{
							num357 += 40 * this.minionPos;
							if (this.localAI[0] > 0f)
							{
								num357 += 500;
							}
							if (this.type == 266 && this.localAI[0] > 0f)
							{
								num357 += 100;
							}
						}
						if (Main.player[this.owner].rocketDelay2 > 0)
						{
							this.ai[0] = 1f;
						}
						Vector2 vector29 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num358 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector29.X;
						if (this.type >= 191)
						{
							int arg_11967_0 = this.type;
						}
						float num359 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector29.Y;
						float num360 = (float)Math.Sqrt((double)(num358 * num358 + num359 * num359));
						if (num360 > 2000f)
						{
							this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
							this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
						}
						else if (num360 > (float)num357 || (Math.Abs(num359) > 300f && (((this.type < 191 || this.type > 194) && this.type != 266 && (this.type < 390 || this.type > 392)) || this.localAI[0] <= 0f)))
						{
							if (this.type != 324)
							{
								if (num359 > 0f && this.velocity.Y < 0f)
								{
									this.velocity.Y = 0f;
								}
								if (num359 < 0f && this.velocity.Y > 0f)
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
						}
						else
						{
							this.velocity.X = 0f;
							this.velocity.Y = 0f;
							this.alpha += 5;
							if (this.alpha > 255)
							{
								this.alpha = 255;
							}
						}
					}
					else if (this.ai[0] != 0f)
					{
						float num361 = 0.2f;
						int num362 = 200;
						if (this.type == 127)
						{
							num362 = 100;
						}
						if (this.type >= 191 && this.type <= 194)
						{
							num361 = 0.5f;
							num362 = 100;
						}
						this.tileCollide = false;
						Vector2 vector30 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num363 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector30.X;
						if ((this.type >= 191 && this.type <= 194) || this.type == 266 || (this.type >= 390 && this.type <= 392))
						{
							num363 -= (float)(40 * Main.player[this.owner].direction);
							float num364 = 600f;
							bool flag13 = false;
							for (int num365 = 0; num365 < 200; num365++)
							{
								if (Main.npc[num365].active && !Main.npc[num365].dontTakeDamage && !Main.npc[num365].friendly && Main.npc[num365].lifeMax > 5)
								{
									float num366 = Main.npc[num365].position.X + (float)(Main.npc[num365].width / 2);
									float num367 = Main.npc[num365].position.Y + (float)(Main.npc[num365].height / 2);
									float num368 = Math.Abs(Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - num366) + Math.Abs(Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - num367);
									if (num368 < num364)
									{
										flag13 = true;
										break;
									}
								}
							}
							if (!flag13)
							{
								num363 -= (float)(40 * this.minionPos * Main.player[this.owner].direction);
							}
						}
						float num369 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector30.Y;
						if (this.type == 127)
						{
							num369 = Main.player[this.owner].position.Y - vector30.Y;
						}
						float num370 = (float)Math.Sqrt((double)(num363 * num363 + num369 * num369));
						float num371 = 10f;
						float num372 = num370;
						if (this.type == 111)
						{
							num371 = 11f;
						}
						if (this.type == 127)
						{
							num371 = 9f;
						}
						if (this.type == 324)
						{
							num371 = 20f;
						}
						if (this.type >= 191 && this.type <= 194)
						{
							num361 = 0.4f;
							num371 = 12f;
							if (num371 < Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y))
							{
								num371 = Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y);
							}
						}
						if (this.type == 208 && Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y) > 4f)
						{
							num362 = -1;
						}
						if (num370 < (float)num362 && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
						{
							this.ai[0] = 0f;
							if (this.velocity.Y < -6f)
							{
								this.velocity.Y = -6f;
							}
						}
						if (num370 < 60f)
						{
							num363 = this.velocity.X;
							num369 = this.velocity.Y;
						}
						else
						{
							num370 = num371 / num370;
							num363 *= num370;
							num369 *= num370;
						}
						if (this.type == 324)
						{
							if (num372 > 1000f)
							{
								if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) < (double)num371 - 1.25)
								{
									this.velocity *= 1.025f;
								}
								if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) > (double)num371 + 1.25)
								{
									this.velocity *= 0.975f;
								}
							}
							else if (num372 > 600f)
							{
								if (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) < num371 - 1f)
								{
									this.velocity *= 1.05f;
								}
								if (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > num371 + 1f)
								{
									this.velocity *= 0.95f;
								}
							}
							else if (num372 > 400f)
							{
								if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) < (double)num371 - 0.5)
								{
									this.velocity *= 1.075f;
								}
								if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) > (double)num371 + 0.5)
								{
									this.velocity *= 0.925f;
								}
							}
							else
							{
								if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) < (double)num371 - 0.25)
								{
									this.velocity *= 1.1f;
								}
								if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) > (double)num371 + 0.25)
								{
									this.velocity *= 0.9f;
								}
							}
							this.velocity.X = (this.velocity.X * 34f + num363) / 35f;
							this.velocity.Y = (this.velocity.Y * 34f + num369) / 35f;
						}
						else
						{
							if (this.velocity.X < num363)
							{
								this.velocity.X = this.velocity.X + num361;
								if (this.velocity.X < 0f)
								{
									this.velocity.X = this.velocity.X + num361 * 1.5f;
								}
							}
							if (this.velocity.X > num363)
							{
								this.velocity.X = this.velocity.X - num361;
								if (this.velocity.X > 0f)
								{
									this.velocity.X = this.velocity.X - num361 * 1.5f;
								}
							}
							if (this.velocity.Y < num369)
							{
								this.velocity.Y = this.velocity.Y + num361;
								if (this.velocity.Y < 0f)
								{
									this.velocity.Y = this.velocity.Y + num361 * 1.5f;
								}
							}
							if (this.velocity.Y > num369)
							{
								this.velocity.Y = this.velocity.Y - num361;
								if (this.velocity.Y > 0f)
								{
									this.velocity.Y = this.velocity.Y - num361 * 1.5f;
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
						if (this.type == 398)
						{
							if ((double)this.velocity.X > 0.5)
							{
								this.spriteDirection = 1;
							}
							else if ((double)this.velocity.X < -0.5)
							{
								this.spriteDirection = -1;
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
						else if (this.type >= 390 && this.type <= 392)
						{
							int num373 = (int)(this.center().X / 16f);
							int num374 = (int)(this.center().Y / 16f);
							if (Main.tile[num373, num374] != null && Main.tile[num373, num374].wall > 0)
							{
								this.rotation = this.velocity.ToRotation() + 1.57079637f;
								this.frameCounter += (int)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y));
								if (this.frameCounter > 5)
								{
									this.frame++;
									this.frameCounter = 0;
								}
								if (this.frame > 7)
								{
									this.frame = 4;
								}
								if (this.frame < 4)
								{
									this.frame = 7;
								}
							}
							else
							{
								this.frameCounter++;
								if (this.frameCounter > 2)
								{
									this.frame++;
									this.frameCounter = 0;
								}
								if (this.frame < 8 || this.frame > 10)
								{
									this.frame = 8;
								}
								this.rotation = this.velocity.X * 0.1f;
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
							Lighting.addLight((int)this.center().X / 16, (int)this.center().Y / 16, 0.9f, 0.6f, 0.2f);
							for (int num375 = 0; num375 < 2; num375++)
							{
								int num376 = 4;
								int num377 = Dust.NewDust(new Vector2(this.center().X - (float)num376, this.center().Y - (float)num376) - this.velocity * 0f, num376 * 2, num376 * 2, 6, 0f, 0f, 100, default(Color), 1f);
								Main.dust[num377].scale *= 1.8f + (float)Main.rand.Next(10) * 0.1f;
								Main.dust[num377].velocity *= 0.2f;
								if (num375 == 1)
								{
									Main.dust[num377].position -= this.velocity * 0.5f;
								}
								Main.dust[num377].noGravity = true;
								num377 = Dust.NewDust(new Vector2(this.center().X - (float)num376, this.center().Y - (float)num376) - this.velocity * 0f, num376 * 2, num376 * 2, 31, 0f, 0f, 100, default(Color), 0.5f);
								Main.dust[num377].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
								Main.dust[num377].velocity *= 0.05f;
								if (num375 == 1)
								{
									Main.dust[num377].position -= this.velocity * 0.5f;
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
						else if (this.type == 398)
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
							this.rotation = this.velocity.X * 0.1f;
						}
						else if (this.spriteDirection == -1)
						{
							this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X);
						}
						else
						{
							this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 3.14f;
						}
						if ((this.type < 191 || this.type > 194) && this.type != 398 && this.type != 390 && this.type != 391 && this.type != 392 && this.type != 127 && this.type != 200 && this.type != 208 && this.type != 210 && this.type != 236 && this.type != 266 && this.type != 268 && this.type != 269 && this.type != 313 && this.type != 314 && this.type != 319 && this.type != 324 && this.type != 334 && this.type != 353)
						{
							int num378 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) - 4f, this.position.Y + (float)(this.height / 2) - 4f) - this.velocity, 8, 8, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.7f);
							Main.dust[num378].velocity.X = Main.dust[num378].velocity.X * 0.2f;
							Main.dust[num378].velocity.Y = Main.dust[num378].velocity.Y * 0.2f;
							Main.dust[num378].noGravity = true;
						}
					}
					else
					{
						if (this.type >= 191 && this.type <= 194)
						{
							float num379 = (float)(40 * this.minionPos);
							int num380 = 30;
							int num381 = 60;
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
								float num382 = this.position.X;
								float num383 = this.position.Y;
								float num384 = 100000f;
								float num385 = num384;
								int num386 = -1;
								for (int num387 = 0; num387 < 200; num387++)
								{
									if (Main.npc[num387].active && !Main.npc[num387].dontTakeDamage && !Main.npc[num387].friendly && Main.npc[num387].lifeMax > 5)
									{
										float num388 = Main.npc[num387].position.X + (float)(Main.npc[num387].width / 2);
										float num389 = Main.npc[num387].position.Y + (float)(Main.npc[num387].height / 2);
										float num390 = Math.Abs(this.position.X + (float)(this.width / 2) - num388) + Math.Abs(this.position.Y + (float)(this.height / 2) - num389);
										if (num390 < num384)
										{
											if (num386 == -1 && num390 <= num385)
											{
												num385 = num390;
												num382 = num388;
												num383 = num389;
											}
											if (Collision.CanHit(this.position, this.width, this.height, Main.npc[num387].position, Main.npc[num387].width, Main.npc[num387].height))
											{
												num384 = num390;
												num382 = num388;
												num383 = num389;
												num386 = num387;
											}
										}
									}
								}
								if (num386 == -1 && num385 < num384)
								{
									num384 = num385;
								}
								float num391 = 400f;
								if ((double)this.position.Y > Main.worldSurface * 16.0)
								{
									num391 = 200f;
								}
								if (num384 < num391 + num379 && num386 == -1)
								{
									float num392 = num382 - (this.position.X + (float)(this.width / 2));
									if (num392 < -5f)
									{
										flag9 = true;
										flag10 = false;
									}
									else if (num392 > 5f)
									{
										flag10 = true;
										flag9 = false;
									}
								}
								else if (num386 >= 0 && num384 < 800f + num379)
								{
									this.localAI[0] = (float)num381;
									float num393 = num382 - (this.position.X + (float)(this.width / 2));
									if (num393 > 300f || num393 < -300f)
									{
										if (num393 < -50f)
										{
											flag9 = true;
											flag10 = false;
										}
										else if (num393 > 50f)
										{
											flag10 = true;
											flag9 = false;
										}
									}
									else if (this.owner == Main.myPlayer)
									{
										this.ai[1] = (float)num380;
										float num394 = 12f;
										Vector2 vector31 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)(this.height / 2) - 8f);
										float num395 = num382 - vector31.X + (float)Main.rand.Next(-20, 21);
										float num396 = Math.Abs(num395) * 0.1f;
										num396 = num396 * (float)Main.rand.Next(0, 100) * 0.001f;
										float num397 = num383 - vector31.Y + (float)Main.rand.Next(-20, 21) - num396;
										float num398 = (float)Math.Sqrt((double)(num395 * num395 + num397 * num397));
										num398 = num394 / num398;
										num395 *= num398;
										num397 *= num398;
										int num399 = this.damage;
										int num400 = 195;
										int num401 = Projectile.NewProjectile(vector31.X, vector31.Y, num395, num397, num400, num399, this.knockBack, Main.myPlayer, 0f, 0f);
										Main.projectile[num401].timeLeft = 300;
										if (num395 < 0f)
										{
											this.direction = -1;
										}
										if (num395 > 0f)
										{
											this.direction = 1;
										}
										this.netUpdate = true;
									}
								}
							}
						}
						bool flag14 = false;
						Vector2 vector32 = Vector2.Zero;
						if (this.type == 266 || (this.type >= 390 && this.type <= 392))
						{
							float num402 = (float)(40 * this.minionPos);
							int num403 = 60;
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
								float num404 = this.position.X;
								float num405 = this.position.Y;
								float num406 = 100000f;
								float num407 = num406;
								int num408 = -1;
								for (int num409 = 0; num409 < 200; num409++)
								{
									if (Main.npc[num409].active && !Main.npc[num409].dontTakeDamage && !Main.npc[num409].friendly && Main.npc[num409].lifeMax > 5)
									{
										float num410 = Main.npc[num409].position.X + (float)(Main.npc[num409].width / 2);
										float num411 = Main.npc[num409].position.Y + (float)(Main.npc[num409].height / 2);
										float num412 = Math.Abs(this.position.X + (float)(this.width / 2) - num410) + Math.Abs(this.position.Y + (float)(this.height / 2) - num411);
										if (num412 < num406)
										{
											if (num408 == -1 && num412 <= num407)
											{
												num407 = num412;
												num404 = num410;
												num405 = num411;
											}
											if (Collision.CanHit(this.position, this.width, this.height, Main.npc[num409].position, Main.npc[num409].width, Main.npc[num409].height))
											{
												num406 = num412;
												num404 = num410;
												num405 = num411;
												num408 = num409;
											}
										}
									}
								}
								if (num408 == -1 && num407 < num406)
								{
									num406 = num407;
								}
								else if (num408 >= 0)
								{
									flag14 = true;
									vector32 = new Vector2(num404, num405) - this.center();
								}
								float num413 = 300f;
								if ((double)this.position.Y > Main.worldSurface * 16.0)
								{
									num413 = 150f;
								}
								if (this.type >= 390 && this.type <= 392)
								{
									num413 = 500f;
									if ((double)this.position.Y > Main.worldSurface * 16.0)
									{
										num413 = 250f;
									}
								}
								if (num406 < num413 + num402 && num408 == -1)
								{
									float num414 = num404 - (this.position.X + (float)(this.width / 2));
									if (num414 < -5f)
									{
										flag9 = true;
										flag10 = false;
									}
									else if (num414 > 5f)
									{
										flag10 = true;
										flag9 = false;
									}
								}
								bool flag15 = false;
								if (this.type >= 390 && this.type <= 392 && this.localAI[1] > 0f)
								{
									flag15 = true;
									this.localAI[1] -= 1f;
								}
								if (num408 >= 0 && num406 < 800f + num402)
								{
									this.friendly = true;
									this.localAI[0] = (float)num403;
									float num415 = num404 - (this.position.X + (float)(this.width / 2));
									if (num415 < -10f)
									{
										flag9 = true;
										flag10 = false;
									}
									else if (num415 > 10f)
									{
										flag10 = true;
										flag9 = false;
									}
									if (num405 < this.center().Y - 100f && num415 > -50f && num415 < 50f && this.velocity.Y == 0f)
									{
										float num416 = Math.Abs(num405 - this.center().Y);
										if (num416 < 120f)
										{
											this.velocity.Y = -10f;
										}
										else if (num416 < 210f)
										{
											this.velocity.Y = -13f;
										}
										else if (num416 < 270f)
										{
											this.velocity.Y = -15f;
										}
										else if (num416 < 310f)
										{
											this.velocity.Y = -17f;
										}
										else if (num416 < 380f)
										{
											this.velocity.Y = -18f;
										}
									}
									if (flag15)
									{
										this.friendly = false;
										if (this.velocity.X < 0f)
										{
											flag9 = true;
										}
										else if (this.velocity.X > 0f)
										{
											flag10 = true;
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
						else if (this.type >= 191 && this.type <= 194 && this.localAI[0] == 0f)
						{
							this.direction = Main.player[this.owner].direction;
						}
						else if (this.type >= 390 && this.type <= 392)
						{
							int num417 = (int)(this.center().X / 16f);
							int num418 = (int)(this.center().Y / 16f);
							if (Main.tile[num417, num418] != null && Main.tile[num417, num418].wall > 0)
							{
								flag10 = (flag9 = false);
							}
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
						float num419 = 0.08f;
						float num420 = 6.5f;
						if (this.type == 127)
						{
							num420 = 2f;
							num419 = 0.04f;
						}
						if (this.type == 112)
						{
							num420 = 6f;
							num419 = 0.06f;
						}
						if (this.type == 334)
						{
							num420 = 8f;
							num419 = 0.08f;
						}
						if (this.type == 268)
						{
							num420 = 8f;
							num419 = 0.4f;
						}
						if (this.type == 324)
						{
							num419 = 0.1f;
							num420 = 3f;
						}
						if ((this.type >= 191 && this.type <= 194) || this.type == 266 || (this.type >= 390 && this.type <= 392))
						{
							num420 = 6f;
							num419 = 0.2f;
							if (num420 < Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y))
							{
								num420 = Math.Abs(Main.player[this.owner].velocity.X) + Math.Abs(Main.player[this.owner].velocity.Y);
								num419 = 0.3f;
							}
						}
						if (this.type >= 390 && this.type <= 392)
						{
							num419 *= 2f;
						}
						if (flag9)
						{
							if ((double)this.velocity.X > -3.5)
							{
								this.velocity.X = this.velocity.X - num419;
							}
							else
							{
								this.velocity.X = this.velocity.X - num419 * 0.25f;
							}
						}
						else if (flag10)
						{
							if ((double)this.velocity.X < 3.5)
							{
								this.velocity.X = this.velocity.X + num419;
							}
							else
							{
								this.velocity.X = this.velocity.X + num419 * 0.25f;
							}
						}
						else
						{
							this.velocity.X = this.velocity.X * 0.9f;
							if (this.velocity.X >= -num419 && this.velocity.X <= num419)
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
							int num421 = (int)(this.position.X + (float)(this.width / 2)) / 16;
							int j2 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
							if (this.type == 236)
							{
								num421 += this.direction;
							}
							if (flag9)
							{
								num421--;
							}
							if (flag10)
							{
								num421++;
							}
							num421 += (int)this.velocity.X;
							if (WorldGen.SolidTile(num421, j2))
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
						Collision.StepUp(ref this.position, ref this.velocity, this.width, this.height, ref this.stepSpeed, ref this.gfxOffY, 1, false);
						if (this.velocity.Y == 0f || this.type == 200)
						{
							if (!flag11 && (this.velocity.X < 0f || this.velocity.X > 0f))
							{
								int num422 = (int)(this.position.X + (float)(this.width / 2)) / 16;
								int j3 = (int)(this.position.Y + (float)(this.height / 2)) / 16 + 1;
								if (flag9)
								{
									num422--;
								}
								if (flag10)
								{
									num422++;
								}
								WorldGen.SolidTile(num422, j3);
							}
							if (flag12)
							{
								int num423 = (int)(this.position.X + (float)(this.width / 2)) / 16;
								int num424 = (int)(this.position.Y + (float)this.height) / 16 + 1;
								if (WorldGen.SolidTile(num423, num424) || Main.tile[num423, num424].halfBrick() || Main.tile[num423, num424].slope() > 0 || this.type == 200)
								{
									if (this.type == 200)
									{
										this.velocity.Y = -3.1f;
									}
									else
									{
										try
										{
											num423 = (int)(this.position.X + (float)(this.width / 2)) / 16;
											num424 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
											if (flag9)
											{
												num423--;
											}
											if (flag10)
											{
												num423++;
											}
											num423 += (int)this.velocity.X;
											if (!WorldGen.SolidTile(num423, num424 - 1) && !WorldGen.SolidTile(num423, num424 - 2))
											{
												this.velocity.Y = -5.1f;
											}
											else if (!WorldGen.SolidTile(num423, num424 - 2))
											{
												this.velocity.Y = -7.1f;
											}
											else if (WorldGen.SolidTile(num423, num424 - 5))
											{
												this.velocity.Y = -11.1f;
											}
											else if (WorldGen.SolidTile(num423, num424 - 4))
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
						if (this.velocity.X > num420)
						{
							this.velocity.X = num420;
						}
						if (this.velocity.X < -num420)
						{
							this.velocity.X = -num420;
						}
						if (this.velocity.X < 0f)
						{
							this.direction = -1;
						}
						if (this.velocity.X > 0f)
						{
							this.direction = 1;
						}
						if (this.velocity.X > num419 && flag10)
						{
							this.direction = 1;
						}
						if (this.velocity.X < -num419 && flag9)
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
						if (this.type == 398)
						{
							this.spriteDirection = this.direction;
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
									int num425 = 3;
									this.frameCounter++;
									if (this.frameCounter < num425)
									{
										this.frame = 0;
									}
									else if (this.frameCounter < num425 * 2)
									{
										this.frame = 1;
									}
									else if (this.frameCounter < num425 * 3)
									{
										this.frame = 2;
									}
									else if (this.frameCounter < num425 * 4)
									{
										this.frame = 3;
									}
									else
									{
										this.frameCounter = num425 * 4;
									}
								}
								else
								{
									this.velocity.X = this.velocity.X * 0.8f;
									this.frameCounter++;
									int num426 = 3;
									if (this.frameCounter < num426)
									{
										this.frame = 0;
									}
									else if (this.frameCounter < num426 * 2)
									{
										this.frame = 1;
									}
									else if (this.frameCounter < num426 * 3)
									{
										this.frame = 2;
									}
									else if (this.frameCounter < num426 * 4)
									{
										this.frame = 3;
									}
									else if (flag9 || flag10)
									{
										this.velocity.X = this.velocity.X * 2f;
										this.frame = 4;
										this.velocity.Y = -6.1f;
										this.frameCounter = 0;
										for (int num427 = 0; num427 < 4; num427++)
										{
											int num428 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), this.width, 4, 5, 0f, 0f, 0, default(Color), 1f);
											Main.dust[num428].velocity += this.velocity;
											Main.dust[num428].velocity *= 0.4f;
										}
									}
									else
									{
										this.frameCounter = num426 * 4;
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
									int num429 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), this.width, 6, 76, 0f, 0f, 0, default(Color), 1f);
									Main.dust[num429].noGravity = true;
									Main.dust[num429].velocity *= 0.3f;
									Main.dust[num429].noLight = true;
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
							}
						}
						else if (this.type == 313)
						{
							int num430 = (int)(this.center().X / 16f);
							int num431 = (int)(this.center().Y / 16f);
							if (Main.tile[num430, num431] != null && Main.tile[num430, num431].wall > 0)
							{
								this.position.Y = this.position.Y + (float)this.height;
								this.height = 34;
								this.position.Y = this.position.Y - (float)this.height;
								this.position.X = this.position.X + (float)(this.width / 2);
								this.width = 34;
								this.position.X = this.position.X - (float)(this.width / 2);
								float num432 = 4f;
								Vector2 vector33 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
								float num433 = Main.player[this.owner].center().X - vector33.X;
								float num434 = Main.player[this.owner].center().Y - vector33.Y;
								float num435 = (float)Math.Sqrt((double)(num433 * num433 + num434 * num434));
								float num436 = num432 / num435;
								num433 *= num436;
								num434 *= num436;
								if (num435 < 120f)
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
									this.velocity.X = (this.velocity.X * 9f + num433) / 10f;
									this.velocity.Y = (this.velocity.Y * 9f + num434) / 10f;
								}
								if (num435 >= 120f)
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
								}
							}
						}
						else if (this.type >= 390 && this.type <= 392)
						{
							int num437 = (int)(this.center().X / 16f);
							int num438 = (int)(this.center().Y / 16f);
							if (Main.tile[num437, num438] != null && Main.tile[num437, num438].wall > 0)
							{
								this.position.Y = this.position.Y + (float)this.height;
								this.height = 34;
								this.position.Y = this.position.Y - (float)this.height;
								this.position.X = this.position.X + (float)(this.width / 2);
								this.width = 34;
								this.position.X = this.position.X - (float)(this.width / 2);
								float scaleFactor = 9f;
								float num439 = (float)(40 * (this.minionPos + 1));
								Vector2 vector34 = Main.player[this.owner].center() - this.center();
								if (flag14)
								{
									vector34 = vector32;
									num439 = 10f;
								}
								if (vector34.Length() < num439)
								{
									this.velocity *= 0.9f;
									if ((double)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) < 0.1)
									{
										this.velocity *= 0f;
									}
								}
								else if (vector34.Length() < 800f || !flag14)
								{
									this.velocity = (this.velocity * 9f + Vector2.Normalize(vector34) * scaleFactor) / 10f;
								}
								if (vector34.Length() >= num439)
								{
									this.spriteDirection = this.direction;
									this.rotation = this.velocity.ToRotation() + 1.57079637f;
								}
								else
								{
									this.rotation = vector34.ToRotation() + 1.57079637f;
								}
								this.frameCounter += (int)(Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y));
								if (this.frameCounter > 5)
								{
									this.frame++;
									this.frameCounter = 0;
								}
								if (this.frame > 7)
								{
									this.frame = 4;
								}
								if (this.frame < 4)
								{
									this.frame = 7;
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
								if (this.frame >= 4 && this.frame <= 7)
								{
									Vector2 vector35 = Main.player[this.owner].center() - this.center();
									if (flag14)
									{
										vector35 = vector32;
									}
									float num440 = -vector35.Y;
									if (vector35.Y <= 0f)
									{
										if (num440 < 120f)
										{
											this.velocity.Y = -10f;
										}
										else if (num440 < 210f)
										{
											this.velocity.Y = -13f;
										}
										else if (num440 < 270f)
										{
											this.velocity.Y = -15f;
										}
										else if (num440 < 310f)
										{
											this.velocity.Y = -17f;
										}
										else if (num440 < 380f)
										{
											this.velocity.Y = -18f;
										}
									}
								}
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
										if (this.frameCounter > 5)
										{
											this.frame++;
											this.frameCounter = 0;
										}
										if (this.frame > 2)
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
									this.frame = 3;
								}
								this.velocity.Y = this.velocity.Y + 0.4f;
								if (this.velocity.Y > 10f)
								{
									this.velocity.Y = 10f;
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
							}
						}
						else if (this.type == 398)
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
									if (this.frame >= 5)
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
							else if (this.velocity.Y != 0f)
							{
								this.frameCounter = 0;
								this.frame = 5;
							}
							this.velocity.Y = this.velocity.Y + 0.4f;
							if (this.velocity.Y > 10f)
							{
								this.velocity.Y = 10f;
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
					for (int num441 = 5; num441 < 25; num441++)
					{
						float num442 = this.velocity.X * (30f / (float)num441);
						float num443 = this.velocity.Y * (30f / (float)num441);
						num442 *= 80f;
						num443 *= 80f;
						int num444 = Dust.NewDust(new Vector2(this.position.X - num442, this.position.Y - num443), 8, 8, 27, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 0.9f);
						Main.dust[num444].velocity *= 0.25f;
						Main.dust[num444].velocity -= this.velocity * 5f;
					}
				}
				if (this.localAI[1] > 7f && this.type == 173)
				{
					int num445 = Main.rand.Next(3);
					if (num445 == 0)
					{
						num445 = 15;
					}
					else if (num445 == 1)
					{
						num445 = 57;
					}
					else
					{
						num445 = 58;
					}
					int num446 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 4f + 2f, this.position.Y + 2f - this.velocity.Y * 4f), 8, 8, num445, 0f, 0f, 100, default(Color), 1.25f);
					Main.dust[num446].velocity *= 0.1f;
				}
				if (this.localAI[1] > 7f && this.type == 132)
				{
					int num447 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 4f + 2f, this.position.Y + 2f - this.velocity.Y * 4f), 8, 8, 107, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.25f);
					Main.dust[num447].velocity *= -0.25f;
					num447 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 4f + 2f, this.position.Y + 2f - this.velocity.Y * 4f), 8, 8, 107, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.25f);
					Main.dust[num447].velocity *= -0.25f;
					Main.dust[num447].position -= this.velocity * 0.5f;
				}
				if (this.localAI[1] < 15f)
				{
					this.localAI[1] += 1f;
				}
				else
				{
					if (this.type == 114 || this.type == 115)
					{
						int num448 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 4f), 8, 8, 27, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 0.6f);
						Main.dust[num448].velocity *= -0.25f;
					}
					else if (this.type == 116)
					{
						int num449 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 5f + 2f, this.position.Y + 2f - this.velocity.Y * 5f), 8, 8, 64, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.5f);
						Main.dust[num449].velocity *= -0.25f;
						Main.dust[num449].noGravity = true;
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
				}
			}
			else if (this.aiStyle == 28)
			{
				if (this.type == 177)
				{
					for (int num450 = 0; num450 < 3; num450++)
					{
						int num451 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 137, this.velocity.X, this.velocity.Y, Main.rand.Next(0, 101), default(Color), 1f + (float)Main.rand.Next(-20, 40) * 0.01f);
						Main.dust[num451].noGravity = true;
						Main.dust[num451].velocity *= 0.3f;
					}
				}
				if (this.type == 118)
				{
					for (int num452 = 0; num452 < 2; num452++)
					{
						int num453 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 92, this.velocity.X, this.velocity.Y, 50, default(Color), 1.2f);
						Main.dust[num453].noGravity = true;
						Main.dust[num453].velocity *= 0.3f;
					}
				}
				if (this.type == 119 || this.type == 128 || this.type == 359)
				{
					for (int num454 = 0; num454 < 3; num454++)
					{
						int num455 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 92, this.velocity.X, this.velocity.Y, 50, default(Color), 1.2f);
						Main.dust[num455].noGravity = true;
						Main.dust[num455].velocity *= 0.3f;
					}
				}
				if (this.type == 309)
				{
					for (int num456 = 0; num456 < 3; num456++)
					{
						int num457 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 185, this.velocity.X, this.velocity.Y, 50, default(Color), 1.2f);
						Main.dust[num457].noGravity = true;
						Main.dust[num457].velocity *= 0.3f;
					}
				}
				if (this.type == 129)
				{
					for (int num458 = 0; num458 < 6; num458++)
					{
						int num459 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 106, this.velocity.X, this.velocity.Y, 100, default(Color), 1f);
						Main.dust[num459].noGravity = true;
						Main.dust[num459].velocity *= 0.1f + (float)Main.rand.Next(4) * 0.1f;
						Main.dust[num459].scale *= 1f + (float)Main.rand.Next(5) * 0.1f;
					}
				}
				if (this.ai[1] == 0f)
				{
					this.ai[1] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 28);
				}
			}
			else if (this.aiStyle == 29)
			{
				int num460 = this.type - 121 + 86;
				for (int num461 = 0; num461 < 2; num461++)
				{
					int num462 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num460, this.velocity.X, this.velocity.Y, 50, default(Color), 1.2f);
					Main.dust[num462].noGravity = true;
					Main.dust[num462].velocity *= 0.3f;
				}
				if (this.ai[1] == 0f)
				{
					this.ai[1] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
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
				}
			}
			else if (this.aiStyle == 31)
			{
				int num463 = 110;
				int num464 = 0;
				if (this.type == 146)
				{
					num463 = 111;
					num464 = 2;
				}
				if (this.type == 147)
				{
					num463 = 112;
					num464 = 1;
				}
				if (this.type == 148)
				{
					num463 = 113;
					num464 = 3;
				}
				if (this.type == 149)
				{
					num463 = 114;
					num464 = 4;
				}
				if (this.owner == Main.myPlayer)
				{
					WorldGen.Convert((int)(this.position.X + (float)(this.width / 2)) / 16, (int)(this.position.Y + (float)(this.height / 2)) / 16, num464, 2);
				}
				if (this.timeLeft > 133)
				{
					this.timeLeft = 133;
				}
				if (this.ai[0] > 7f)
				{
					float num465 = 1f;
					if (this.ai[0] == 8f)
					{
						num465 = 0.2f;
					}
					else if (this.ai[0] == 9f)
					{
						num465 = 0.4f;
					}
					else if (this.ai[0] == 10f)
					{
						num465 = 0.6f;
					}
					else if (this.ai[0] == 11f)
					{
						num465 = 0.8f;
					}
					this.ai[0] += 1f;
					for (int num466 = 0; num466 < 1; num466++)
					{
						int num467 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num463, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, default(Color), 1f);
						Main.dust[num467].noGravity = true;
						Main.dust[num467].scale *= 1.75f;
						Dust expr_18033_cp_0 = Main.dust[num467];
						expr_18033_cp_0.velocity.X = expr_18033_cp_0.velocity.X * 2f;
						Dust expr_18053_cp_0 = Main.dust[num467];
						expr_18053_cp_0.velocity.Y = expr_18053_cp_0.velocity.Y * 2f;
						Main.dust[num467].scale *= num465;
					}
				}
				else
				{
					this.ai[0] += 1f;
				}
				this.rotation += 0.3f * (float)this.direction;
			}
			else if (this.aiStyle == 32)
			{
				this.timeLeft = 10;
				this.ai[0] += 1f;
				if (this.ai[0] >= 20f)
				{
					this.ai[0] = 15f;
					for (int num468 = 0; num468 < 255; num468++)
					{
						Rectangle rectangle3 = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
						if (Main.player[num468].active)
						{
							Rectangle value5 = new Rectangle((int)Main.player[num468].position.X, (int)Main.player[num468].position.Y, Main.player[num468].width, Main.player[num468].height);
							if (rectangle3.Intersects(value5))
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
								this.velocity.X = (this.velocity.X + (float)Main.player[num468].direction * 1.75f) / 2f;
								this.velocity.X = this.velocity.X + Main.player[num468].velocity.X * 3f;
								this.velocity.Y = this.velocity.Y + Main.player[num468].velocity.Y;
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
				}
			}
			else if (this.aiStyle == 33)
			{
				if (this.alpha > 0)
				{
					this.alpha -= 50;
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
				}
				float num469 = 4f;
				float num470 = this.ai[0];
				float num471 = this.ai[1];
				if (num470 == 0f && num471 == 0f)
				{
					num470 = 1f;
				}
				float num472 = (float)Math.Sqrt((double)(num470 * num470 + num471 * num471));
				num472 = num469 / num472;
				num470 *= num472;
				num471 *= num472;
				if (this.alpha < 70)
				{
					int num473 = 127;
					if (this.type == 310)
					{
						num473 = 187;
					}
					int num474 = Dust.NewDust(new Vector2(this.position.X, this.position.Y - 2f), 6, 6, num473, this.velocity.X, this.velocity.Y, 100, default(Color), 1.6f);
					Main.dust[num474].noGravity = true;
					Dust expr_18650_cp_0 = Main.dust[num474];
					expr_18650_cp_0.position.X = expr_18650_cp_0.position.X - num470 * 1f;
					Dust expr_18675_cp_0 = Main.dust[num474];
					expr_18675_cp_0.position.Y = expr_18675_cp_0.position.Y - num471 * 1f;
					Dust expr_1869A_cp_0 = Main.dust[num474];
					expr_1869A_cp_0.velocity.X = expr_1869A_cp_0.velocity.X - num470;
					Dust expr_186B9_cp_0 = Main.dust[num474];
					expr_186B9_cp_0.velocity.Y = expr_186B9_cp_0.velocity.Y - num471;
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
			}
			else if (this.aiStyle == 34)
			{
				if (this.type >= 415 && this.type <= 418)
				{
					this.ai[0] += 1f;
					if (this.ai[0] > 4f)
					{
						int num475 = Dust.NewDust(new Vector2(this.position.X + 2f, this.position.Y + 20f), 8, 8, 6, this.velocity.X, this.velocity.Y, 100, default(Color), 1.2f);
						Main.dust[num475].noGravity = true;
						Main.dust[num475].velocity *= 0.2f;
					}
				}
				else
				{
					int num476 = Dust.NewDust(new Vector2(this.position.X + 2f, this.position.Y + 20f), 8, 8, 6, this.velocity.X, this.velocity.Y, 100, default(Color), 1.2f);
					Main.dust[num476].noGravity = true;
					Main.dust[num476].velocity *= 0.2f;
				}
			}
			else if (this.aiStyle == 35)
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
					Vector2 vector36 = Collision.TileCollision(this.position, this.velocity, this.width, this.height, true, true, 1);
					bool flag16 = false;
					if (vector36 != this.velocity)
					{
						flag16 = true;
					}
					else
					{
						int num477 = (int)(this.center().X + this.velocity.X) / 16;
						int num478 = (int)(this.center().Y + this.velocity.Y) / 16;
						if (Main.tile[num477, num478] != null && Main.tile[num477, num478].active() && Main.tile[num477, num478].bottomSlope())
						{
							flag16 = true;
							this.position.Y = (float)(num478 * 16 + 16 + 8);
							this.position.X = (float)(num477 * 16 + 8);
						}
					}
					if (flag16)
					{
						int num479 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num480 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
						this.position += vector36;
						int num481 = 10;
						if (Main.tile[num479, num480] != null)
						{
							while (Main.tile[num479, num480] != null && Main.tile[num479, num480].active())
							{
								if (!Main.tileRope[(int)Main.tile[num479, num480].type])
								{
									break;
								}
								num480++;
							}
							while (num481 > 0)
							{
								num481--;
								if (Main.tile[num479, num480] == null)
								{
									break;
								}
								if (Main.tile[num479, num480].active() && (Main.tileCut[(int)Main.tile[num479, num480].type] || Main.tile[num479, num480].type == 165))
								{
									WorldGen.KillTile(num479, num480, false, false, false);
									NetMessage.SendData(17, -1, -1, "", 0, (float)num479, (float)num480, 0f, 0);
								}
								if (!Main.tile[num479, num480].active())
								{
									WorldGen.PlaceTile(num479, num480, 213, false, false, -1, 0);
									NetMessage.SendData(17, -1, -1, "", 1, (float)num479, (float)num480, 213f, 0);
									this.ai[1] += 1f;
								}
								else
								{
									num481 = 0;
								}
								num480++;
							}
							this.Kill();
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
					for (int num482 = 0; num482 < 3; num482++)
					{
						float num483 = this.velocity.X / 3f * (float)num482;
						float num484 = this.velocity.Y / 3f * (float)num482;
						int num485 = Dust.NewDust(this.position, this.width, this.height, 184, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num485].position.X = this.center().X - num483;
						Main.dust[num485].position.Y = this.center().Y - num484;
						Main.dust[num485].velocity *= 0f;
						Main.dust[num485].scale = 0.5f;
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
				float num486 = this.position.X;
				float num487 = this.position.Y;
				float num488 = 100000f;
				bool flag17 = false;
				this.ai[0] += 1f;
				if (this.ai[0] > 30f)
				{
					this.ai[0] = 30f;
					for (int num489 = 0; num489 < 200; num489++)
					{
						if (Main.npc[num489].active && !Main.npc[num489].dontTakeDamage && !Main.npc[num489].friendly && Main.npc[num489].lifeMax > 5 && (!Main.npc[num489].wet || this.type == 307))
						{
							float num490 = Main.npc[num489].position.X + (float)(Main.npc[num489].width / 2);
							float num491 = Main.npc[num489].position.Y + (float)(Main.npc[num489].height / 2);
							float num492 = Math.Abs(this.position.X + (float)(this.width / 2) - num490) + Math.Abs(this.position.Y + (float)(this.height / 2) - num491);
							if (num492 < 800f && num492 < num488 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num489].position, Main.npc[num489].width, Main.npc[num489].height))
							{
								num488 = num492;
								num486 = num490;
								num487 = num491;
								flag17 = true;
							}
						}
					}
				}
				if (!flag17)
				{
					num486 = this.position.X + (float)(this.width / 2) + this.velocity.X * 100f;
					num487 = this.position.Y + (float)(this.height / 2) + this.velocity.Y * 100f;
				}
				else if (this.type == 307)
				{
					this.friendly = true;
				}
				float num493 = 6f;
				float num494 = 0.1f;
				if (this.type == 189)
				{
					num493 = 7f;
					num494 = 0.15f;
				}
				if (this.type == 307)
				{
					num493 = 9f;
					num494 = 0.2f;
				}
				if (this.type == 316)
				{
					num493 = 10f;
					num494 = 0.25f;
				}
				Vector2 vector37 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float num495 = num486 - vector37.X;
				float num496 = num487 - vector37.Y;
				float num497 = (float)Math.Sqrt((double)(num495 * num495 + num496 * num496));
				num497 = num493 / num497;
				num495 *= num497;
				num496 *= num497;
				if (this.velocity.X < num495)
				{
					this.velocity.X = this.velocity.X + num494;
					if (this.velocity.X < 0f && num495 > 0f)
					{
						this.velocity.X = this.velocity.X + num494 * 2f;
					}
				}
				else if (this.velocity.X > num495)
				{
					this.velocity.X = this.velocity.X - num494;
					if (this.velocity.X > 0f && num495 < 0f)
					{
						this.velocity.X = this.velocity.X - num494 * 2f;
					}
				}
				if (this.velocity.Y < num496)
				{
					this.velocity.Y = this.velocity.Y + num494;
					if (this.velocity.Y < 0f && num496 > 0f)
					{
						this.velocity.Y = this.velocity.Y + num494 * 2f;
					}
				}
				else if (this.velocity.Y > num496)
				{
					this.velocity.Y = this.velocity.Y - num494;
					if (this.velocity.Y > 0f && num496 < 0f)
					{
						this.velocity.Y = this.velocity.Y - num494 * 2f;
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
					}
					else
					{
						float num498 = this.position.Y - this.ai[1];
						if (num498 > 300f)
						{
							this.velocity.Y = this.velocity.Y * -1f;
							this.ai[0] += 1f;
						}
					}
				}
				else if (Collision.SolidCollision(this.position, this.width, this.height) || this.position.Y < this.ai[1])
				{
					this.Kill();
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
				Vector2 vector38 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float num499 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector38.X;
				float num500 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector38.Y;
				float num501 = (float)Math.Sqrt((double)(num499 * num499 + num500 * num500));
				if (!Main.player[this.owner].channel && this.alpha == 0)
				{
					this.ai[0] = 1f;
					this.ai[1] = -1f;
				}
				if (this.ai[1] > 0f && num501 > 1500f)
				{
					this.ai[1] = 0f;
					this.ai[0] = 1f;
				}
				if (this.ai[1] > 0f)
				{
					this.tileCollide = false;
					int num502 = (int)this.ai[1] - 1;
					if (Main.npc[num502].active && Main.npc[num502].life > 0)
					{
						float num503 = 16f;
						vector38 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						num499 = Main.npc[num502].position.X + (float)(Main.npc[num502].width / 2) - vector38.X;
						num500 = Main.npc[num502].position.Y + (float)(Main.npc[num502].height / 2) - vector38.Y;
						num501 = (float)Math.Sqrt((double)(num499 * num499 + num500 * num500));
						if (num501 < num503)
						{
							this.velocity.X = num499;
							this.velocity.Y = num500;
							if (num501 > num503 / 2f)
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
							num501 = num503 / num501;
							num499 *= num501;
							num500 *= num501;
							this.velocity.X = num499;
							this.velocity.Y = num500;
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
						float num504 = this.position.X;
						float num505 = this.position.Y;
						float num506 = 3000f;
						int num507 = -1;
						for (int num508 = 0; num508 < 200; num508++)
						{
							if (Main.npc[num508].active && !Main.npc[num508].friendly && Main.npc[num508].lifeMax > 5 && !Main.npc[num508].dontTakeDamage)
							{
								float num509 = Main.npc[num508].position.X + (float)(Main.npc[num508].width / 2);
								float num510 = Main.npc[num508].position.Y + (float)(Main.npc[num508].height / 2);
								float num511 = Math.Abs(this.position.X + (float)(this.width / 2) - num509) + Math.Abs(this.position.Y + (float)(this.height / 2) - num510);
								if (num511 < num506 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num508].position, Main.npc[num508].width, Main.npc[num508].height))
								{
									num506 = num511;
									num504 = num509;
									num505 = num510;
									num507 = num508;
								}
							}
						}
						if (num507 >= 0)
						{
							float num512 = 16f;
							vector38 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							num499 = num504 - vector38.X;
							num500 = num505 - vector38.Y;
							num501 = (float)Math.Sqrt((double)(num499 * num499 + num500 * num500));
							num501 = num512 / num501;
							num499 *= num501;
							num500 *= num501;
							this.velocity.X = num499;
							this.velocity.Y = num500;
							this.ai[0] = 0f;
							this.ai[1] = (float)(num507 + 1);
						}
					}
				}
				else if (this.ai[0] == 0f)
				{
					if (num501 > 700f)
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
					float num513 = 20f;
					if (num501 < 70f)
					{
						this.Kill();
					}
					num501 = num513 / num501;
					num499 *= num501;
					num500 *= num501;
					this.velocity.X = num499;
					this.velocity.Y = num500;
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
				}
			}
			else if (this.aiStyle == 40)
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
			}
			else if (this.aiStyle == 41)
			{
				if (this.localAI[0] == 0f)
				{
					this.localAI[0] = 1f;
					this.frame = Main.rand.Next(3);
				}
				this.rotation += this.velocity.X * 0.01f;
			}
			else if (this.aiStyle == 42)
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
				float num514 = (float)Main.mouseTextColor / 200f - 0.35f;
				num514 *= 0.2f;
				this.scale = num514 + 0.95f;
				if (this.owner == Main.myPlayer)
				{
					if (this.ai[0] == 0f)
					{
						float num515 = this.position.X;
						float num516 = this.position.Y;
						float num517 = 700f;
						bool flag18 = false;
						for (int num518 = 0; num518 < 200; num518++)
						{
							if (Main.npc[num518].active && !Main.npc[num518].friendly && Main.npc[num518].lifeMax > 5)
							{
								float num519 = Main.npc[num518].position.X + (float)(Main.npc[num518].width / 2);
								float num520 = Main.npc[num518].position.Y + (float)(Main.npc[num518].height / 2);
								float num521 = Math.Abs(this.position.X + (float)(this.width / 2) - num519) + Math.Abs(this.position.Y + (float)(this.height / 2) - num520);
								if (num521 < num517 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num518].position, Main.npc[num518].width, Main.npc[num518].height))
								{
									num517 = num521;
									num515 = num519;
									num516 = num520;
									flag18 = true;
								}
							}
						}
						if (flag18)
						{
							float num522 = 12f;
							Vector2 vector39 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num523 = num515 - vector39.X;
							float num524 = num516 - vector39.Y;
							float num525 = (float)Math.Sqrt((double)(num523 * num523 + num524 * num524));
							num525 = num522 / num525;
							num523 *= num525;
							num524 *= num525;
							Projectile.NewProjectile(this.center().X - 4f, this.center().Y, num523, num524, 227, 50, 5f, this.owner, 0f, 0f);
							this.ai[0] = 50f;
						}
					}
					else
					{
						this.ai[0] -= 1f;
					}
				}
			}
			else if (this.aiStyle == 43)
			{
				if (this.localAI[1] == 0f)
				{
					Main.PlaySound(6, (int)this.position.X, (int)this.position.Y, 1);
					this.localAI[1] += 1f;
					for (int num526 = 0; num526 < 5; num526++)
					{
						int num527 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 157, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num527].noGravity = true;
						Main.dust[num527].velocity *= 3f;
						Main.dust[num527].scale = 1.5f;
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
				int num528 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 157, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num528].noGravity = true;
				Main.dust[num528].velocity *= 0.1f;
				Main.dust[num528].scale = 1.5f;
			}
			else if (this.aiStyle == 44)
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
				}
			}
			else if (this.aiStyle == 45)
			{
				if (this.type == 237 || this.type == 243)
				{
					float num529 = this.ai[0];
					float num530 = this.ai[1];
					if (num529 != 0f && num530 != 0f)
					{
						bool flag19 = false;
						bool flag20 = false;
						if ((this.velocity.X < 0f && this.center().X < num529) || (this.velocity.X > 0f && this.center().X > num529))
						{
							flag19 = true;
						}
						if ((this.velocity.Y < 0f && this.center().Y < num530) || (this.velocity.Y > 0f && this.center().Y > num530))
						{
							flag20 = true;
						}
						if (flag19 && flag20)
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
									int num531 = (int)(this.position.X + 14f + (float)Main.rand.Next(this.width - 28));
									int num532 = (int)(this.position.Y + (float)this.height + 4f);
									Projectile.NewProjectile((float)num531, (float)num532, 0f, 5f, 245, this.damage, 0f, this.owner, 0f, 0f);
								}
							}
						}
						else if (this.ai[0] > 8f)
						{
							this.ai[0] = 0f;
							if (this.owner == Main.myPlayer)
							{
								int num533 = (int)(this.position.X + 14f + (float)Main.rand.Next(this.width - 28));
								int num534 = (int)(this.position.Y + (float)this.height + 4f);
								Projectile.NewProjectile((float)num533, (float)num534, 0f, 5f, 239, this.damage, 0f, this.owner, 0f, 0f);
							}
						}
					}
					this.localAI[0] += 1f;
					if (this.localAI[0] >= 10f)
					{
						this.localAI[0] = 0f;
						int num535 = 0;
						int num536 = 0;
						float num537 = 0f;
						int num538 = this.type;
						for (int num539 = 0; num539 < 1000; num539++)
						{
							if (Main.projectile[num539].active && Main.projectile[num539].owner == this.owner && Main.projectile[num539].type == num538 && Main.projectile[num539].ai[1] < 3600f)
							{
								num535++;
								if (Main.projectile[num539].ai[1] > num537)
								{
									num536 = num539;
									num537 = Main.projectile[num539].ai[1];
								}
							}
						}
						if (this.type == 244)
						{
							if (num535 > 1)
							{
								Main.projectile[num536].netUpdate = true;
								Main.projectile[num536].ai[1] = 36000f;
							}
						}
						else if (num535 > 2)
						{
							Main.projectile[num536].netUpdate = true;
							Main.projectile[num536].ai[1] = 36000f;
						}
					}
				}
				else if (this.type == 239)
				{
					this.alpha = 50;
				}
				else if (this.type == 245)
				{
					this.alpha = 100;
				}
				else if (this.type == 264)
				{
					this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
				}
			}
			else if (this.aiStyle == 46)
			{
				int num540 = 600;
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
						if (this.timeLeft > num540)
						{
							this.timeLeft = num540;
						}
					}
					float num541 = 1f;
					if (this.velocity.Y < 0f)
					{
						num541 -= this.velocity.Y / 3f;
					}
					this.ai[0] += num541;
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
					float num542 = this.velocity.X;
					float num543 = this.velocity.Y;
					float num544 = (float)Math.Sqrt((double)(num542 * num542 + num543 * num543));
					num544 = 15.95f * this.scale / num544;
					num542 *= num544;
					num543 *= num544;
					this.velocity.X = num542;
					this.velocity.Y = num543;
					this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) - 1.57f;
				}
				else
				{
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
						this.timeLeft = num540;
					}
					this.velocity.X = this.velocity.X * 0.98f;
					this.velocity.Y = this.velocity.Y * 0.98f;
					if (this.rotation == 0f)
					{
						this.alpha = 255;
					}
					else if (this.timeLeft < 10)
					{
						this.alpha = 255 - (int)(255f * (float)this.timeLeft / 10f);
					}
					else if (this.timeLeft > num540 - 10)
					{
						int num545 = num540 - this.timeLeft;
						this.alpha = 255 - (int)(255f * (float)num545 / 10f);
					}
					else
					{
						this.alpha = 0;
					}
				}
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
				for (int num546 = 0; num546 < 1000; num546++)
				{
					if (num546 != this.whoAmI && Main.projectile[num546].active && Main.projectile[num546].owner == this.owner && Main.projectile[num546].type == this.type && this.timeLeft > Main.projectile[num546].timeLeft && Main.projectile[num546].timeLeft > 30)
					{
						Main.projectile[num546].timeLeft = 30;
					}
				}
				int[] array = new int[20];
				int num547 = 0;
				float num548 = 300f;
				bool flag21 = false;
				for (int num549 = 0; num549 < 200; num549++)
				{
					if (Main.npc[num549].active && !Main.npc[num549].dontTakeDamage && !Main.npc[num549].friendly && Main.npc[num549].lifeMax > 5)
					{
						float num550 = Main.npc[num549].position.X + (float)(Main.npc[num549].width / 2);
						float num551 = Main.npc[num549].position.Y + (float)(Main.npc[num549].height / 2);
						float num552 = Math.Abs(this.position.X + (float)(this.width / 2) - num550) + Math.Abs(this.position.Y + (float)(this.height / 2) - num551);
						if (num552 < num548 && Collision.CanHit(this.center(), 1, 1, Main.npc[num549].center(), 1, 1))
						{
							if (num547 < 20)
							{
								array[num547] = num549;
								num547++;
							}
							flag21 = true;
						}
					}
				}
				if (this.timeLeft < 30)
				{
					flag21 = false;
				}
				if (flag21)
				{
					int num553 = Main.rand.Next(num547);
					num553 = array[num553];
					float num554 = Main.npc[num553].position.X + (float)(Main.npc[num553].width / 2);
					float num555 = Main.npc[num553].position.Y + (float)(Main.npc[num553].height / 2);
					this.localAI[0] += 1f;
					if (this.localAI[0] > 8f)
					{
						this.localAI[0] = 0f;
						float num556 = 6f;
						Vector2 value6 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						value6 += this.velocity * 4f;
						float num557 = num554 - value6.X;
						float num558 = num555 - value6.Y;
						float num559 = (float)Math.Sqrt((double)(num557 * num557 + num558 * num558));
						num559 = num556 / num559;
						num557 *= num559;
						num558 *= num559;
						Projectile.NewProjectile(value6.X, value6.Y, num557, num558, 255, this.damage, this.knockBack, this.owner, 0f, 0f);
					}
				}
			}
			else if (this.aiStyle == 48)
			{
				if (this.type == 255)
				{
					for (int num560 = 0; num560 < 4; num560++)
					{
						Vector2 value7 = this.position;
						value7 -= this.velocity * ((float)num560 * 0.25f);
						this.alpha = 255;
						int num561 = Dust.NewDust(value7, 1, 1, 160, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num561].position = value7;
						Dust expr_1BAF2_cp_0 = Main.dust[num561];
						expr_1BAF2_cp_0.position.X = expr_1BAF2_cp_0.position.X + (float)(this.width / 2);
						Dust expr_1BB16_cp_0 = Main.dust[num561];
						expr_1BB16_cp_0.position.Y = expr_1BB16_cp_0.position.Y + (float)(this.height / 2);
						Main.dust[num561].scale = (float)Main.rand.Next(70, 110) * 0.013f;
						Main.dust[num561].velocity *= 0.2f;
					}
				}
				else if (this.type == 290)
				{
					if (this.localAI[0] == 0f)
					{
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
					}
					this.localAI[0] += 1f;
					if (this.localAI[0] > 3f)
					{
						for (int num562 = 0; num562 < 3; num562++)
						{
							Vector2 value8 = this.position;
							value8 -= this.velocity * ((float)num562 * 0.3334f);
							this.alpha = 255;
							int num563 = Dust.NewDust(value8, 1, 1, 173, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num563].position = value8;
							Main.dust[num563].scale = (float)Main.rand.Next(70, 110) * 0.013f;
							Main.dust[num563].velocity *= 0.2f;
						}
					}
				}
				else if (this.type == 294)
				{
					this.localAI[0] += 1f;
					if (this.localAI[0] > 9f)
					{
						for (int num564 = 0; num564 < 4; num564++)
						{
							Vector2 value9 = this.position;
							value9 -= this.velocity * ((float)num564 * 0.25f);
							this.alpha = 255;
							int num565 = Dust.NewDust(value9, 1, 1, 173, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num565].position = value9;
							Main.dust[num565].scale = (float)Main.rand.Next(70, 110) * 0.013f;
							Main.dust[num565].velocity *= 0.2f;
						}
					}
				}
				else
				{
					this.localAI[0] += 1f;
					if (this.localAI[0] > 3f)
					{
						for (int num566 = 0; num566 < 4; num566++)
						{
							Vector2 value10 = this.position;
							value10 -= this.velocity * ((float)num566 * 0.25f);
							this.alpha = 255;
							int num567 = Dust.NewDust(value10, 1, 1, 162, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num567].position = value10;
							Dust expr_1BEBE_cp_0 = Main.dust[num567];
							expr_1BEBE_cp_0.position.X = expr_1BEBE_cp_0.position.X + (float)(this.width / 2);
							Dust expr_1BEE2_cp_0 = Main.dust[num567];
							expr_1BEE2_cp_0.position.Y = expr_1BEE2_cp_0.position.Y + (float)(this.height / 2);
							Main.dust[num567].scale = (float)Main.rand.Next(70, 110) * 0.013f;
							Main.dust[num567].velocity *= 0.2f;
						}
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
							for (int num568 = 0; num568 < 10; num568++)
							{
								int num569 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
								Main.dust[num569].velocity *= 0.5f;
								Main.dust[num569].velocity += this.velocity * 0.1f;
							}
							for (int num570 = 0; num570 < 5; num570++)
							{
								int num571 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
								Main.dust[num571].noGravity = true;
								Main.dust[num571].velocity *= 3f;
								Main.dust[num571].velocity += this.velocity * 0.2f;
								num571 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
								Main.dust[num571].velocity *= 2f;
								Main.dust[num571].velocity += this.velocity * 0.3f;
							}
							for (int num572 = 0; num572 < 1; num572++)
							{
								int num573 = Gore.NewGore(new Vector2(this.position.X - 10f, this.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
								Main.gore[num573].position += this.velocity * 1.25f;
								Main.gore[num573].scale = 1.5f;
								Main.gore[num573].velocity += this.velocity * 0.5f;
								Main.gore[num573].velocity *= 0.02f;
							}
						}
					}
				}
				else if (this.ai[1] == 2f)
				{
					this.rotation = 0f;
					this.velocity.X = this.velocity.X * 0.95f;
					this.velocity.Y = this.velocity.Y + 0.2f;
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
					bool flag22 = false;
					bool flag23 = false;
					if (this.velocity.X < 0f && this.position.X < this.ai[0])
					{
						flag22 = true;
					}
					if (this.velocity.X > 0f && this.position.X > this.ai[0])
					{
						flag22 = true;
					}
					if (this.velocity.Y < 0f && this.position.Y < this.ai[1])
					{
						flag23 = true;
					}
					if (this.velocity.Y > 0f && this.position.Y > this.ai[1])
					{
						flag23 = true;
					}
					if (flag22 && flag23)
					{
						this.Kill();
					}
					for (int num574 = 0; num574 < 10; num574++)
					{
						int num575 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 174, 0f, 0f, 100, default(Color), 1.2f);
						Main.dust[num575].noGravity = true;
						Main.dust[num575].velocity *= 0.5f;
						Main.dust[num575].velocity += this.velocity * 0.1f;
					}
				}
				else if (this.type == 295)
				{
					for (int num576 = 0; num576 < 8; num576++)
					{
						int num577 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 174, 0f, 0f, 100, default(Color), 1.2f);
						Main.dust[num577].noGravity = true;
						Main.dust[num577].velocity *= 0.5f;
						Main.dust[num577].velocity += this.velocity * 0.1f;
					}
				}
				else
				{
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
					float num578 = 25f;
					if (this.ai[0] > 180f)
					{
						num578 -= (this.ai[0] - 180f) / 2f;
					}
					if (num578 <= 0f)
					{
						num578 = 0f;
						this.Kill();
					}
					if (this.type == 296)
					{
						num578 *= 0.7f;
					}
					int num579 = 0;
					while ((float)num579 < num578)
					{
						float num580 = (float)Main.rand.Next(-10, 11);
						float num581 = (float)Main.rand.Next(-10, 11);
						float num582 = (float)Main.rand.Next(3, 9);
						float num583 = (float)Math.Sqrt((double)(num580 * num580 + num581 * num581));
						num583 = num582 / num583;
						num580 *= num583;
						num581 *= num583;
						int num584 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 174, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num584].noGravity = true;
						Main.dust[num584].position.X = this.center().X;
						Main.dust[num584].position.Y = this.center().Y;
						Dust expr_1C945_cp_0 = Main.dust[num584];
						expr_1C945_cp_0.position.X = expr_1C945_cp_0.position.X + (float)Main.rand.Next(-10, 11);
						Dust expr_1C96F_cp_0 = Main.dust[num584];
						expr_1C96F_cp_0.position.Y = expr_1C96F_cp_0.position.Y + (float)Main.rand.Next(-10, 11);
						Main.dust[num584].velocity.X = num580;
						Main.dust[num584].velocity.Y = num581;
						num579++;
					}
				}
			}
			else if (this.aiStyle == 51)
			{
				if (this.type == 297)
				{
					this.localAI[0] += 1f;
					if (this.localAI[0] > 4f)
					{
						for (int num585 = 0; num585 < 5; num585++)
						{
							int num586 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 175, 0f, 0f, 100, default(Color), 2f);
							Main.dust[num586].noGravity = true;
							Main.dust[num586].velocity *= 0f;
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
					for (int num587 = 0; num587 < 9; num587++)
					{
						int num588 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 175, 0f, 0f, 100, default(Color), 1.3f);
						Main.dust[num588].noGravity = true;
						Main.dust[num588].velocity *= 0f;
					}
				}
				float num589 = this.center().X;
				float num590 = this.center().Y;
				float num591 = 400f;
				bool flag24 = false;
				if (this.type == 297)
				{
					for (int num592 = 0; num592 < 200; num592++)
					{
						if (Main.npc[num592].active && !Main.npc[num592].dontTakeDamage && !Main.npc[num592].friendly && Main.npc[num592].lifeMax > 5 && Collision.CanHit(this.center(), 1, 1, Main.npc[num592].center(), 1, 1))
						{
							float num593 = Main.npc[num592].position.X + (float)(Main.npc[num592].width / 2);
							float num594 = Main.npc[num592].position.Y + (float)(Main.npc[num592].height / 2);
							float num595 = Math.Abs(this.position.X + (float)(this.width / 2) - num593) + Math.Abs(this.position.Y + (float)(this.height / 2) - num594);
							if (num595 < num591)
							{
								num591 = num595;
								num589 = num593;
								num590 = num594;
								flag24 = true;
							}
						}
					}
				}
				else
				{
					num591 = 200f;
					for (int num596 = 0; num596 < 255; num596++)
					{
						if (Main.player[num596].active && !Main.player[num596].dead)
						{
							float num597 = Main.player[num596].position.X + (float)(Main.player[num596].width / 2);
							float num598 = Main.player[num596].position.Y + (float)(Main.player[num596].height / 2);
							float num599 = Math.Abs(this.position.X + (float)(this.width / 2) - num597) + Math.Abs(this.position.Y + (float)(this.height / 2) - num598);
							if (num599 < num591)
							{
								num591 = num599;
								num589 = num597;
								num590 = num598;
								flag24 = true;
							}
						}
					}
				}
				if (flag24)
				{
					float num600 = 3f;
					if (this.type == 297)
					{
						num600 = 6f;
					}
					Vector2 vector40 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num601 = num589 - vector40.X;
					float num602 = num590 - vector40.Y;
					float num603 = (float)Math.Sqrt((double)(num601 * num601 + num602 * num602));
					num603 = num600 / num603;
					num601 *= num603;
					num602 *= num603;
					if (this.type == 297)
					{
						this.velocity.X = (this.velocity.X * 20f + num601) / 21f;
						this.velocity.Y = (this.velocity.Y * 20f + num602) / 21f;
					}
					else
					{
						this.velocity.X = (this.velocity.X * 100f + num601) / 101f;
						this.velocity.Y = (this.velocity.Y * 100f + num602) / 101f;
					}
				}
			}
			else if (this.aiStyle == 52)
			{
				int num604 = (int)this.ai[0];
				float num605 = 4f;
				Vector2 vector41 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float num606 = Main.player[num604].center().X - vector41.X;
				float num607 = Main.player[num604].center().Y - vector41.Y;
				float num608 = (float)Math.Sqrt((double)(num606 * num606 + num607 * num607));
				if (num608 < 50f && this.position.X < Main.player[num604].position.X + (float)Main.player[num604].width && this.position.X + (float)this.width > Main.player[num604].position.X && this.position.Y < Main.player[num604].position.Y + (float)Main.player[num604].height && this.position.Y + (float)this.height > Main.player[num604].position.Y)
				{
					if (this.owner == Main.myPlayer)
					{
						int num609 = (int)this.ai[1];
						Main.player[num604].HealEffect(num609, false);
						Main.player[num604].statLife += num609;
						if (Main.player[num604].statLife > Main.player[num604].statLifeMax2)
						{
							Main.player[num604].statLife = Main.player[num604].statLifeMax2;
						}
						NetMessage.SendData(66, -1, -1, "", num604, (float)num609, 0f, 0f, 0);
					}
					this.Kill();
				}
				num608 = num605 / num608;
				num606 *= num608;
				num607 *= num608;
				this.velocity.X = (this.velocity.X * 15f + num606) / 16f;
				this.velocity.Y = (this.velocity.Y * 15f + num607) / 16f;
				if (this.type == 305)
				{
					for (int num610 = 0; num610 < 3; num610++)
					{
						float num611 = this.velocity.X * 0.334f * (float)num610;
						float num612 = -(this.velocity.Y * 0.334f) * (float)num610;
						int num613 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 183, 0f, 0f, 100, default(Color), 1.1f);
						Main.dust[num613].noGravity = true;
						Main.dust[num613].velocity *= 0f;
						Dust expr_1D378_cp_0 = Main.dust[num613];
						expr_1D378_cp_0.position.X = expr_1D378_cp_0.position.X - num611;
						Dust expr_1D397_cp_0 = Main.dust[num613];
						expr_1D397_cp_0.position.Y = expr_1D397_cp_0.position.Y - num612;
					}
				}
				else
				{
					for (int num614 = 0; num614 < 5; num614++)
					{
						float num615 = this.velocity.X * 0.2f * (float)num614;
						float num616 = -(this.velocity.Y * 0.2f) * (float)num614;
						int num617 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 175, 0f, 0f, 100, default(Color), 1.3f);
						Main.dust[num617].noGravity = true;
						Main.dust[num617].velocity *= 0f;
						Dust expr_1D493_cp_0 = Main.dust[num617];
						expr_1D493_cp_0.position.X = expr_1D493_cp_0.position.X - num615;
						Dust expr_1D4B2_cp_0 = Main.dust[num617];
						expr_1D4B2_cp_0.position.Y = expr_1D4B2_cp_0.position.Y - num616;
					}
				}
			}
			else if (this.aiStyle == 53)
			{
				if (this.localAI[0] == 0f)
				{
					this.localAI[1] = 1f;
					this.localAI[0] = 1f;
					this.ai[0] = 120f;
					int num618 = 80;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 46);
					if (this.type == 308)
					{
						for (int num619 = 0; num619 < num618; num619++)
						{
							int num620 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 16f), this.width, this.height - 16, 185, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num620].velocity *= 2f;
							Main.dust[num620].noGravity = true;
							Main.dust[num620].scale *= 1.15f;
						}
					}
					if (this.type == 377)
					{
						this.frame = 4;
						num618 = 40;
						for (int num621 = 0; num621 < num618; num621++)
						{
							int num622 = Dust.NewDust(this.position + Vector2.UnitY * 16f, this.width, this.height - 16, 171, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num622].scale = (float)Main.rand.Next(1, 10) * 0.1f;
							Main.dust[num622].noGravity = true;
							Main.dust[num622].fadeIn = 1.5f;
							Main.dust[num622].velocity *= 0.75f;
						}
					}
				}
				this.velocity.X = 0f;
				this.velocity.Y = this.velocity.Y + 0.2f;
				if (this.velocity.Y > 16f)
				{
					this.velocity.Y = 16f;
				}
				bool flag25 = false;
				float num623 = this.center().X;
				float num624 = this.center().Y;
				float num625 = 1000f;
				for (int num626 = 0; num626 < 200; num626++)
				{
					if (Main.npc[num626].active && !Main.npc[num626].dontTakeDamage && !Main.npc[num626].friendly && Main.npc[num626].lifeMax > 5)
					{
						float num627 = Main.npc[num626].position.X + (float)(Main.npc[num626].width / 2);
						float num628 = Main.npc[num626].position.Y + (float)(Main.npc[num626].height / 2);
						float num629 = Math.Abs(this.position.X + (float)(this.width / 2) - num627) + Math.Abs(this.position.Y + (float)(this.height / 2) - num628);
						if (num629 < num625 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num626].position, Main.npc[num626].width, Main.npc[num626].height))
						{
							num625 = num629;
							num623 = num627;
							num624 = num628;
							flag25 = true;
						}
					}
				}
				if (flag25)
				{
					float num630 = num623;
					float num631 = num624;
					num623 -= this.center().X;
					num624 -= this.center().Y;
					if (num623 < 0f)
					{
						this.spriteDirection = -1;
					}
					else
					{
						this.spriteDirection = 1;
					}
					int num632;
					if (num624 > 0f)
					{
						num632 = 0;
					}
					else if (Math.Abs(num624) > Math.Abs(num623) * 3f)
					{
						num632 = 4;
					}
					else if (Math.Abs(num624) > Math.Abs(num623) * 2f)
					{
						num632 = 3;
					}
					else if (Math.Abs(num623) > Math.Abs(num624) * 3f)
					{
						num632 = 0;
					}
					else if (Math.Abs(num623) > Math.Abs(num624) * 2f)
					{
						num632 = 1;
					}
					else
					{
						num632 = 2;
					}
					if (this.type == 308)
					{
						this.frame = num632 * 2;
					}
					else if (this.type == 377)
					{
						this.frame = num632;
					}
					if (this.ai[0] > 40f && this.localAI[1] == 0f && this.type == 308)
					{
						this.frame++;
					}
					if (this.ai[0] <= 0f)
					{
						this.localAI[1] = 0f;
						this.ai[0] = 60f;
						if (Main.myPlayer == this.owner)
						{
							float num633 = 6f;
							int num634 = 309;
							if (this.type == 377)
							{
								num634 = 378;
								num633 = 9f;
							}
							Vector2 vector42 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							if (num632 == 0)
							{
								vector42.Y += 12f;
								vector42.X += (float)(24 * this.spriteDirection);
							}
							else if (num632 == 1)
							{
								vector42.Y += 0f;
								vector42.X += (float)(24 * this.spriteDirection);
							}
							else if (num632 == 2)
							{
								vector42.Y -= 2f;
								vector42.X += (float)(24 * this.spriteDirection);
							}
							else if (num632 == 3)
							{
								vector42.Y -= 6f;
								vector42.X += (float)(14 * this.spriteDirection);
							}
							else if (num632 == 4)
							{
								vector42.Y -= 14f;
								vector42.X += (float)(2 * this.spriteDirection);
							}
							if (this.spriteDirection < 0)
							{
								vector42.X += 10f;
							}
							float num635 = num630 - vector42.X;
							float num636 = num631 - vector42.Y;
							float num637 = (float)Math.Sqrt((double)(num635 * num635 + num636 * num636));
							num637 = num633 / num637;
							num635 *= num637;
							num636 *= num637;
							int num638 = this.damage;
							Projectile.NewProjectile(vector42.X, vector42.Y, num635, num636, num634, num638, this.knockBack, Main.myPlayer, 0f, 0f);
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
				for (int num639 = 0; num639 < 1000; num639++)
				{
					if (num639 != this.whoAmI && Main.projectile[num639].active && Main.projectile[num639].owner == this.owner && Main.projectile[num639].type == this.type && Math.Abs(this.position.X - Main.projectile[num639].position.X) + Math.Abs(this.position.Y - Main.projectile[num639].position.Y) < (float)this.width)
					{
						if (this.position.X < Main.projectile[num639].position.X)
						{
							this.velocity.X = this.velocity.X - 0.05f;
						}
						else
						{
							this.velocity.X = this.velocity.X + 0.05f;
						}
						if (this.position.Y < Main.projectile[num639].position.Y)
						{
							this.velocity.Y = this.velocity.Y - 0.05f;
						}
						else
						{
							this.velocity.Y = this.velocity.Y + 0.05f;
						}
					}
				}
				float num640 = this.position.X;
				float num641 = this.position.Y;
				float num642 = 800f;
				bool flag26 = false;
				int num643 = 500;
				if (this.ai[1] != 0f || this.friendly)
				{
					num643 = 1400;
				}
				if (Math.Abs(this.center().X - Main.player[this.owner].center().X) + Math.Abs(this.center().Y - Main.player[this.owner].center().Y) > (float)num643)
				{
					this.ai[0] = 1f;
				}
				if (this.ai[0] == 0f)
				{
					this.tileCollide = true;
					for (int num644 = 0; num644 < 200; num644++)
					{
						if (Main.npc[num644].active && !Main.npc[num644].dontTakeDamage && !Main.npc[num644].friendly && Main.npc[num644].lifeMax > 5)
						{
							float num645 = Main.npc[num644].position.X + (float)(Main.npc[num644].width / 2);
							float num646 = Main.npc[num644].position.Y + (float)(Main.npc[num644].height / 2);
							float num647 = Math.Abs(this.position.X + (float)(this.width / 2) - num645) + Math.Abs(this.position.Y + (float)(this.height / 2) - num646);
							if (num647 < num642 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num644].position, Main.npc[num644].width, Main.npc[num644].height))
							{
								num642 = num647;
								num640 = num645;
								num641 = num646;
								flag26 = true;
							}
						}
					}
				}
				else
				{
					this.tileCollide = false;
				}
				if (!flag26)
				{
					this.friendly = true;
					float num648 = 8f;
					if (this.ai[0] == 1f)
					{
						num648 = 12f;
					}
					Vector2 vector43 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num649 = Main.player[this.owner].center().X - vector43.X;
					float num650 = Main.player[this.owner].center().Y - vector43.Y - 60f;
					float num651 = (float)Math.Sqrt((double)(num649 * num649 + num650 * num650));
					if (num651 < 100f && this.ai[0] == 1f && !Collision.SolidCollision(this.position, this.width, this.height))
					{
						this.ai[0] = 0f;
					}
					if (num651 > 2000f)
					{
						this.position.X = Main.player[this.owner].center().X - (float)(this.width / 2);
						this.position.Y = Main.player[this.owner].center().Y - (float)(this.width / 2);
					}
					if (num651 > 70f)
					{
						num651 = num648 / num651;
						num649 *= num651;
						num650 *= num651;
						this.velocity.X = (this.velocity.X * 20f + num649) / 21f;
						this.velocity.Y = (this.velocity.Y * 20f + num650) / 21f;
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
						float num652 = 8f;
						Vector2 vector44 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num653 = num640 - vector44.X;
						float num654 = num641 - vector44.Y;
						float num655 = (float)Math.Sqrt((double)(num653 * num653 + num654 * num654));
						if (num655 < 100f)
						{
							num652 = 10f;
						}
						num655 = num652 / num655;
						num653 *= num655;
						num654 *= num655;
						this.velocity.X = (this.velocity.X * 14f + num653) / 15f;
						this.velocity.Y = (this.velocity.Y * 14f + num654) / 15f;
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
					int num656 = (int)this.ai[0];
					if (Main.npc[num656].active)
					{
						float num657 = 8f;
						Vector2 vector45 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num658 = Main.npc[num656].position.X - vector45.X;
						float num659 = Main.npc[num656].position.Y - vector45.Y;
						float num660 = (float)Math.Sqrt((double)(num658 * num658 + num659 * num659));
						num660 = num657 / num660;
						num658 *= num660;
						num659 *= num660;
						this.velocity.X = (this.velocity.X * 14f + num658) / 15f;
						this.velocity.Y = (this.velocity.Y * 14f + num659) / 15f;
					}
					else
					{
						float num661 = 1000f;
						for (int num662 = 0; num662 < 200; num662++)
						{
							if (Main.npc[num662].active && !Main.npc[num662].dontTakeDamage && !Main.npc[num662].friendly && Main.npc[num662].lifeMax > 5)
							{
								float num663 = Main.npc[num662].position.X + (float)(Main.npc[num662].width / 2);
								float num664 = Main.npc[num662].position.Y + (float)(Main.npc[num662].height / 2);
								float num665 = Math.Abs(this.position.X + (float)(this.width / 2) - num663) + Math.Abs(this.position.Y + (float)(this.height / 2) - num664);
								if (num665 < num661 && Collision.CanHit(this.position, this.width, this.height, Main.npc[num662].position, Main.npc[num662].width, Main.npc[num662].height))
								{
									num661 = num665;
									this.ai[0] = (float)num662;
								}
							}
						}
					}
					int num666 = 8;
					int num667 = Dust.NewDust(new Vector2(this.position.X + (float)num666, this.position.Y + (float)num666), this.width - num666 * 2, this.height - num666 * 2, 6, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num667].velocity *= 0.5f;
					Main.dust[num667].velocity += this.velocity * 0.5f;
					Main.dust[num667].noGravity = true;
					Main.dust[num667].noLight = true;
					Main.dust[num667].scale = 1.4f;
				}
				else
				{
					this.Kill();
				}
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
			else if (this.aiStyle == 57)
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
						int num668 = 0;
						for (int num669 = 0; num669 < 1000; num669++)
						{
							if (Main.projectile[num669].active && Main.projectile[num669].owner == this.owner && Main.projectile[num669].type == 344)
							{
								num668++;
							}
						}
						float num670 = (float)this.damage * 0.8f;
						if (num668 > 100)
						{
							float num671 = (float)(num668 - 100);
							num671 = 1f - num671 / 100f;
							num670 *= num671;
						}
						if (num668 > 100)
						{
							this.localAI[0] -= 1f;
						}
						if (num668 > 120)
						{
							this.localAI[0] -= 1f;
						}
						if (num668 > 140)
						{
							this.localAI[0] -= 1f;
						}
						if (num668 > 150)
						{
							this.localAI[0] -= 1f;
						}
						if (num668 > 160)
						{
							this.localAI[0] -= 1f;
						}
						if (num668 > 165)
						{
							this.localAI[0] -= 1f;
						}
						if (num668 > 170)
						{
							this.localAI[0] -= 2f;
						}
						if (num668 > 175)
						{
							this.localAI[0] -= 3f;
						}
						if (num668 > 180)
						{
							this.localAI[0] -= 4f;
						}
						if (num668 > 185)
						{
							this.localAI[0] -= 5f;
						}
						if (num668 > 190)
						{
							this.localAI[0] -= 6f;
						}
						if (num668 > 195)
						{
							this.localAI[0] -= 7f;
						}
						if (num670 > (float)this.damage * 0.1f)
						{
							Projectile.NewProjectile(this.center().X, this.center().Y, 0f, 0f, 344, (int)num670, this.knockBack * 0.55f, this.owner, 0f, (float)Main.rand.Next(3));
						}
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
			else if (this.aiStyle == 59)
			{
				this.ai[1] += 1f;
				if (this.ai[1] >= 60f)
				{
					this.friendly = true;
					int num672 = (int)this.ai[0];
					if (!Main.npc[num672].active)
					{
						int[] array2 = new int[200];
						int num673 = 0;
						for (int num674 = 0; num674 < 200; num674++)
						{
							if (Main.npc[num674].active && !Main.npc[num674].friendly && Main.npc[num674].lifeMax > 5 && !Main.npc[num674].dontTakeDamage)
							{
								float num675 = Math.Abs(Main.npc[num674].position.X + (float)(Main.npc[num674].width / 2) - this.position.X + (float)(this.width / 2)) + Math.Abs(Main.npc[num674].position.Y + (float)(Main.npc[num674].height / 2) - this.position.Y + (float)(this.height / 2));
								if (num675 < 800f)
								{
									array2[num673] = num674;
									num673++;
								}
							}
						}
						if (num673 == 0)
						{
							this.Kill();
							return;
						}
						num672 = array2[Main.rand.Next(num673)];
						this.ai[0] = (float)num672;
					}
					float num676 = 4f;
					Vector2 vector46 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num677 = Main.npc[num672].center().X - vector46.X;
					float num678 = Main.npc[num672].center().Y - vector46.Y;
					float num679 = (float)Math.Sqrt((double)(num677 * num677 + num678 * num678));
					num679 = num676 / num679;
					num677 *= num679;
					num678 *= num679;
					int num680 = 30;
					this.velocity.X = (this.velocity.X * (float)(num680 - 1) + num677) / (float)num680;
					this.velocity.Y = (this.velocity.Y * (float)(num680 - 1) + num678) / (float)num680;
				}
				for (int num681 = 0; num681 < 5; num681++)
				{
					float num682 = this.velocity.X * 0.2f * (float)num681;
					float num683 = -(this.velocity.Y * 0.2f) * (float)num681;
					int num684 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 175, 0f, 0f, 100, default(Color), 1.3f);
					Main.dust[num684].noGravity = true;
					Main.dust[num684].velocity *= 0f;
					Dust expr_1F565_cp_0 = Main.dust[num684];
					expr_1F565_cp_0.position.X = expr_1F565_cp_0.position.X - num682;
					Dust expr_1F584_cp_0 = Main.dust[num684];
					expr_1F584_cp_0.position.Y = expr_1F584_cp_0.position.Y - num683;
				}
			}
			else if (this.aiStyle == 60)
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
					int num685 = 103;
					if (this.type == 406)
					{
						num685 = 137;
					}
					if (this.owner == Main.myPlayer)
					{
						Rectangle rectangle4 = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
						for (int num686 = 0; num686 < 200; num686++)
						{
							if (Main.npc[num686].active && !Main.npc[num686].dontTakeDamage && Main.npc[num686].lifeMax > 1)
							{
								Rectangle value11 = new Rectangle((int)Main.npc[num686].position.X, (int)Main.npc[num686].position.Y, Main.npc[num686].width, Main.npc[num686].height);
								if (rectangle4.Intersects(value11))
								{
									Main.npc[num686].AddBuff(num685, 1500, false);
									this.Kill();
								}
							}
						}
						for (int num687 = 0; num687 < 255; num687++)
						{
							if (num687 != this.owner && Main.player[num687].active && !Main.player[num687].dead)
							{
								Rectangle value12 = new Rectangle((int)Main.player[num687].position.X, (int)Main.player[num687].position.Y, Main.player[num687].width, Main.player[num687].height);
								if (rectangle4.Intersects(value12))
								{
									Main.player[num687].AddBuff(num685, 1500, false);
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
					if (this.type == 358)
					{
						for (int num688 = 0; num688 < 1; num688++)
						{
							for (int num689 = 0; num689 < 6; num689++)
							{
								float num690 = this.velocity.X / 6f * (float)num689;
								float num691 = this.velocity.Y / 6f * (float)num689;
								int num692 = 6;
								int num693 = Dust.NewDust(new Vector2(this.position.X + (float)num692, this.position.Y + (float)num692), this.width - num692 * 2, this.height - num692 * 2, 211, 0f, 0f, 75, default(Color), 1.2f);
								if (Main.rand.Next(2) == 0)
								{
									Main.dust[num693].alpha += 25;
								}
								if (Main.rand.Next(2) == 0)
								{
									Main.dust[num693].alpha += 25;
								}
								if (Main.rand.Next(2) == 0)
								{
									Main.dust[num693].alpha += 25;
								}
								Main.dust[num693].noGravity = true;
								Main.dust[num693].velocity *= 0.3f;
								Main.dust[num693].velocity += this.velocity * 0.5f;
								Main.dust[num693].position = this.center();
								Dust expr_1FA1B_cp_0 = Main.dust[num693];
								expr_1FA1B_cp_0.position.X = expr_1FA1B_cp_0.position.X - num690;
								Dust expr_1FA3A_cp_0 = Main.dust[num693];
								expr_1FA3A_cp_0.position.Y = expr_1FA3A_cp_0.position.Y - num691;
								Main.dust[num693].velocity *= 0.2f;
							}
							if (Main.rand.Next(4) == 0)
							{
								int num694 = 6;
								int num695 = Dust.NewDust(new Vector2(this.position.X + (float)num694, this.position.Y + (float)num694), this.width - num694 * 2, this.height - num694 * 2, 211, 0f, 0f, 75, default(Color), 0.65f);
								Main.dust[num695].velocity *= 0.5f;
								Main.dust[num695].velocity += this.velocity * 0.5f;
							}
						}
					}
					if (this.type == 406)
					{
						int num696 = 175;
						Color newColor = new Color(0, 80, 255, 100);
						for (int num697 = 0; num697 < 6; num697++)
						{
							Vector2 vector47 = this.velocity * (float)num697 / 6f;
							int num698 = 6;
							int num699 = Dust.NewDust(this.position + Vector2.One * 6f, this.width - num698 * 2, this.height - num698 * 2, 4, 0f, 0f, num696, newColor, 1.2f);
							if (Main.rand.Next(2) == 0)
							{
								Main.dust[num699].alpha += 25;
							}
							if (Main.rand.Next(2) == 0)
							{
								Main.dust[num699].alpha += 25;
							}
							if (Main.rand.Next(2) == 0)
							{
								Main.dust[num699].alpha += 25;
							}
							Main.dust[num699].noGravity = true;
							Main.dust[num699].velocity *= 0.3f;
							Main.dust[num699].velocity += this.velocity * 0.5f;
							Main.dust[num699].position = this.center();
							Dust expr_1FCF7_cp_0 = Main.dust[num699];
							expr_1FCF7_cp_0.position.X = expr_1FCF7_cp_0.position.X - vector47.X;
							Dust expr_1FD1B_cp_0 = Main.dust[num699];
							expr_1FD1B_cp_0.position.Y = expr_1FD1B_cp_0.position.Y - vector47.Y;
							Main.dust[num699].velocity *= 0.2f;
						}
						if (Main.rand.Next(4) == 0)
						{
							int num700 = 6;
							int num701 = Dust.NewDust(this.position + Vector2.One * 6f, this.width - num700 * 2, this.height - num700 * 2, 4, 0f, 0f, num696, newColor, 1.2f);
							Main.dust[num701].velocity *= 0.5f;
							Main.dust[num701].velocity += this.velocity * 0.5f;
						}
					}
				}
				else
				{
					this.ai[0] += 1f;
				}
			}
			else if (this.aiStyle == 61)
			{
				this.timeLeft = 60;
				if (Main.player[this.owner].inventory[Main.player[this.owner].selectedItem].fishingPole == 0)
				{
					this.Kill();
				}
				else if (Main.player[this.owner].inventory[Main.player[this.owner].selectedItem].shoot != this.type)
				{
					this.Kill();
				}
				else if (Main.player[this.owner].pulley)
				{
					this.Kill();
				}
				else if (Main.player[this.owner].mount.Active)
				{
					this.Kill();
				}
				else if (Main.player[this.owner].dead)
				{
					this.Kill();
				}
				if (this.ai[1] > 0f && this.localAI[1] >= 0f)
				{
					this.localAI[1] = -1f;
					if (!this.lavaWet && !this.honeyWet)
					{
						for (int num702 = 0; num702 < 100; num702++)
						{
							int num703 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y - 10f), this.width + 12, 24, Dust.dustWater(), 0f, 0f, 0, default(Color), 1f);
							Dust expr_1FFB3_cp_0 = Main.dust[num703];
							expr_1FFB3_cp_0.velocity.Y = expr_1FFB3_cp_0.velocity.Y - 4f;
							Dust expr_1FFD3_cp_0 = Main.dust[num703];
							expr_1FFD3_cp_0.velocity.X = expr_1FFD3_cp_0.velocity.X * 2.5f;
							Main.dust[num703].scale = 0.8f;
							Main.dust[num703].alpha = 100;
							Main.dust[num703].noGravity = true;
						}
						Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 0);
					}
				}
				if (this.ai[0] >= 1f)
				{
					if (this.ai[0] == 2f)
					{
						this.ai[0] += 1f;
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 17);
						if (!this.lavaWet && !this.honeyWet)
						{
							for (int num704 = 0; num704 < 100; num704++)
							{
								int num705 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y - 10f), this.width + 12, 24, Dust.dustWater(), 0f, 0f, 0, default(Color), 1f);
								Dust expr_2013C_cp_0 = Main.dust[num705];
								expr_2013C_cp_0.velocity.Y = expr_2013C_cp_0.velocity.Y - 4f;
								Dust expr_2015C_cp_0 = Main.dust[num705];
								expr_2015C_cp_0.velocity.X = expr_2015C_cp_0.velocity.X * 2.5f;
								Main.dust[num705].scale = 0.8f;
								Main.dust[num705].alpha = 100;
								Main.dust[num705].noGravity = true;
							}
							Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 0);
						}
					}
					if (this.localAI[0] < 100f)
					{
						this.localAI[0] += 1f;
					}
					this.tileCollide = false;
					float num706 = 15.9f;
					int num707 = 10;
					Vector2 vector48 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num708 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector48.X;
					float num709 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector48.Y;
					float num710 = (float)Math.Sqrt((double)(num708 * num708 + num709 * num709));
					if (num710 > 3000f)
					{
						this.Kill();
					}
					num710 = num706 / num710;
					num708 *= num710;
					num709 *= num710;
					this.velocity.X = (this.velocity.X * (float)(num707 - 1) + num708) / (float)num707;
					this.velocity.Y = (this.velocity.Y * (float)(num707 - 1) + num709) / (float)num707;
					if (Main.myPlayer == this.owner)
					{
						Rectangle rectangle5 = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
						Rectangle value13 = new Rectangle((int)Main.player[this.owner].position.X, (int)Main.player[this.owner].position.Y, Main.player[this.owner].width, Main.player[this.owner].height);
						if (rectangle5.Intersects(value13))
						{
							if (this.ai[1] > 0f && this.ai[1] < 2749f)
							{
								int num711 = (int)this.ai[1];
								Item item = new Item();
								item.SetDefaults(num711, false);
								Item item2 = Main.player[this.owner].GetItem(this.owner, item, false);
								if (item2.stack > 0)
								{
									int number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num711, 1, false, 0, true);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(21, -1, -1, "", number, 1f, 0f, 0f, 0);
									}
								}
								else
								{
									item.position.X = this.center().X - (float)(item.width / 2);
									item.position.Y = this.center().Y - (float)(item.height / 2);
									item.active = true;
									//ItemText.NewText(item, 0, false, false);
								}
							}
							this.Kill();
						}
					}
					this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
				}
				else
				{
					bool flag27 = false;
					Vector2 vector49 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num712 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector49.X;
					float num713 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector49.Y;
					this.rotation = (float)Math.Atan2((double)num713, (double)num712) + 1.57f;
					float num714 = (float)Math.Sqrt((double)(num712 * num712 + num713 * num713));
					if (num714 > 900f)
					{
						this.ai[0] = 1f;
					}
					if (this.wet)
					{
						this.rotation = 0f;
						this.velocity.X = this.velocity.X * 0.9f;
						int num715 = (int)(this.center().X + (float)((this.width / 2 + 8) * this.direction)) / 16;
						int num716 = (int)(this.center().Y / 16f);
						float arg_20703_0 = this.position.Y / 16f;
						int num717 = (int)((this.position.Y + (float)this.height) / 16f);
						if (Main.tile[num715, num716] == null)
						{
							Main.tile[num715, num716] = new Tile();
						}
						if (Main.tile[num715, num717] == null)
						{
							Main.tile[num715, num717] = new Tile();
						}
						if (this.velocity.Y > 0f)
						{
							this.velocity.Y = this.velocity.Y * 0.5f;
						}
						num715 = (int)(this.center().X / 16f);
						num716 = (int)(this.center().Y / 16f);
						float num718 = this.position.Y + (float)this.height;
						if (Main.tile[num715, num716 - 1] == null)
						{
							Main.tile[num715, num716 - 1] = new Tile();
						}
						if (Main.tile[num715, num716] == null)
						{
							Main.tile[num715, num716] = new Tile();
						}
						if (Main.tile[num715, num716 + 1] == null)
						{
							Main.tile[num715, num716 + 1] = new Tile();
						}
						if (Main.tile[num715, num716 - 1].liquid > 0)
						{
							num718 = (float)(num716 * 16);
							num718 -= (float)(Main.tile[num715, num716 - 1].liquid / 16);
						}
						else if (Main.tile[num715, num716].liquid > 0)
						{
							num718 = (float)((num716 + 1) * 16);
							num718 -= (float)(Main.tile[num715, num716].liquid / 16);
						}
						else if (Main.tile[num715, num716 + 1].liquid > 0)
						{
							num718 = (float)((num716 + 2) * 16);
							num718 -= (float)(Main.tile[num715, num716 + 1].liquid / 16);
						}
						if (this.center().Y > num718)
						{
							this.velocity.Y = this.velocity.Y - 0.1f;
							if (this.velocity.Y < -8f)
							{
								this.velocity.Y = -8f;
							}
							if (this.center().Y + this.velocity.Y < num718)
							{
								this.velocity.Y = num718 - this.center().Y;
							}
						}
						else
						{
							this.velocity.Y = num718 - this.center().Y;
						}
						if ((double)this.velocity.Y >= -0.01 && (double)this.velocity.Y <= 0.01)
						{
							flag27 = true;
						}
					}
					else
					{
						if (this.velocity.Y == 0f)
						{
							this.velocity.X = this.velocity.X * 0.95f;
						}
						this.velocity.X = this.velocity.X * 0.98f;
						this.velocity.Y = this.velocity.Y + 0.2f;
						if (this.velocity.Y > 15.9f)
						{
							this.velocity.Y = 15.9f;
						}
					}
					if (this.ai[1] != 0f)
					{
						flag27 = true;
					}
					if (flag27)
					{
						if (this.ai[1] == 0f && Main.myPlayer == this.owner)
						{
							int num719 = Main.player[this.owner].FishingLevel();
							if (num719 == -9000)
							{
								this.localAI[1] += 5f;
								this.localAI[1] += (float)Main.rand.Next(1, 3);
								if (this.localAI[1] > 660f)
								{
									this.localAI[1] = 0f;
									this.FishingCheck();
								}
							}
							else
							{
								if (Main.rand.Next(300) < num719)
								{
									this.localAI[1] += (float)Main.rand.Next(1, 3);
								}
								this.localAI[1] += (float)(num719 / 30);
								this.localAI[1] += (float)Main.rand.Next(1, 3);
								if (Main.rand.Next(60) == 0)
								{
									this.localAI[1] += 60f;
								}
								if (this.localAI[1] > 660f)
								{
									this.localAI[1] = 0f;
									this.FishingCheck();
								}
							}
						}
						else if (this.ai[1] < 0f)
						{
							if (this.velocity.Y == 0f || (this.honeyWet && (double)this.velocity.Y >= -0.01 && (double)this.velocity.Y <= 0.01))
							{
								this.velocity.Y = (float)Main.rand.Next(100, 500) * 0.015f;
								this.velocity.X = (float)Main.rand.Next(-100, 101) * 0.015f;
								this.wet = false;
								this.lavaWet = false;
								this.honeyWet = false;
							}
							this.ai[1] += (float)Main.rand.Next(1, 5);
							if (this.ai[1] >= 0f)
							{
								this.ai[1] = 0f;
								this.localAI[1] = 0f;
								this.netUpdate = true;
							}
						}
					}
				}
			}
			if (this.aiStyle == 62)
			{
				if (this.type == 373)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].hornetMinion = false;
					}
					if (Main.player[this.owner].hornetMinion)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 375)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].impMinion = false;
					}
					if (Main.player[this.owner].impMinion)
					{
						this.timeLeft = 2;
					}
				}
				if (this.type == 407)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].sharknadoMinion = false;
					}
					if (Main.player[this.owner].sharknadoMinion)
					{
						this.timeLeft = 2;
					}
				}
				float num720 = 0.05f;
				float num721 = (float)this.width;
				if (this.type == 407)
				{
					num720 = 0.1f;
					num721 *= 2f;
				}
				for (int num722 = 0; num722 < 1000; num722++)
				{
					if (num722 != this.whoAmI && Main.projectile[num722].active && Main.projectile[num722].owner == this.owner && Main.projectile[num722].type == this.type && Math.Abs(this.position.X - Main.projectile[num722].position.X) + Math.Abs(this.position.Y - Main.projectile[num722].position.Y) < num721)
					{
						if (this.position.X < Main.projectile[num722].position.X)
						{
							this.velocity.X = this.velocity.X - num720;
						}
						else
						{
							this.velocity.X = this.velocity.X + num720;
						}
						if (this.position.Y < Main.projectile[num722].position.Y)
						{
							this.velocity.Y = this.velocity.Y - num720;
						}
						else
						{
							this.velocity.Y = this.velocity.Y + num720;
						}
					}
				}
				Vector2 vector50 = this.position;
				float num723 = 400f;
				bool flag28 = false;
				this.tileCollide = true;
				if (this.type == 407)
				{
					this.tileCollide = false;
					if (Collision.SolidCollision(this.position, this.width, this.height))
					{
						this.alpha += 20;
						if (this.alpha > 150)
						{
							this.alpha = 150;
						}
					}
					else
					{
						this.alpha -= 50;
						if (this.alpha < 60)
						{
							this.alpha = 60;
						}
					}
				}
				if (this.type == 407)
				{
					Vector2 vector51 = Main.player[this.owner].center();
					for (int num724 = 0; num724 < 200; num724++)
					{
						NPC nPC = Main.npc[num724];
						if (nPC.active && !nPC.dontTakeDamage && !nPC.friendly && nPC.lifeMax > 5)
						{
							float num725 = Vector2.Distance(nPC.center(), vector51);
							if (((Vector2.Distance(vector51, vector50) > num725 && num725 < num723) || !flag28) && Collision.CanHitLine(this.position, this.width, this.height, nPC.position, nPC.width, nPC.height))
							{
								num723 = num725;
								vector50 = nPC.center();
								flag28 = true;
							}
						}
					}
				}
				else
				{
					for (int num726 = 0; num726 < 200; num726++)
					{
						NPC nPC2 = Main.npc[num726];
						if (nPC2.active && !nPC2.dontTakeDamage && !nPC2.friendly && nPC2.lifeMax > 5)
						{
							float num727 = Vector2.Distance(nPC2.center(), this.center());
							if (((Vector2.Distance(this.center(), vector50) > num727 && num727 < num723) || !flag28) && Collision.CanHitLine(this.position, this.width, this.height, nPC2.position, nPC2.width, nPC2.height))
							{
								num723 = num727;
								vector50 = nPC2.center();
								flag28 = true;
							}
						}
					}
				}
				int num728 = 500;
				if (flag28)
				{
					num728 = 1000;
				}
				Player player = Main.player[this.owner];
				if (Vector2.Distance(player.center(), this.center()) > (float)num728)
				{
					this.ai[0] = 1f;
					this.netUpdate = true;
				}
				if (this.ai[0] == 1f)
				{
					this.tileCollide = false;
				}
				if (flag28 && this.ai[0] == 0f)
				{
					Vector2 vector52 = vector50 - this.center();
					float num729 = vector52.Length();
					vector52.Normalize();
					if (this.type == 407)
					{
						if (num729 > 400f)
						{
							float scaleFactor2 = 2f;
							vector52 *= scaleFactor2;
							this.velocity = (this.velocity * 20f + vector52) / 21f;
						}
						else
						{
							this.velocity *= 0.96f;
						}
					}
					if (num729 > 200f)
					{
						float scaleFactor3 = 6f;
						vector52 *= scaleFactor3;
						this.velocity.X = (this.velocity.X * 40f + vector52.X) / 41f;
						this.velocity.Y = (this.velocity.Y * 40f + vector52.Y) / 41f;
					}
					else if (this.type == 375)
					{
						if (num729 < 150f)
						{
							float num730 = 4f;
							vector52 *= -num730;
							this.velocity.X = (this.velocity.X * 40f + vector52.X) / 41f;
							this.velocity.Y = (this.velocity.Y * 40f + vector52.Y) / 41f;
						}
						else
						{
							this.velocity *= 0.97f;
						}
					}
					else if (this.velocity.Y > -1f)
					{
						this.velocity.Y = this.velocity.Y - 0.1f;
					}
				}
				else
				{
					if (!Collision.CanHitLine(this.center(), 1, 1, Main.player[this.owner].center(), 1, 1))
					{
						this.ai[0] = 1f;
					}
					float num731 = 6f;
					if (this.ai[0] == 1f)
					{
						num731 = 15f;
					}
					if (this.type == 407)
					{
						num731 = 9f;
					}
					Vector2 value14 = this.center();
					Vector2 vector53 = player.center() - value14 + new Vector2(0f, -60f);
					if (this.type == 407)
					{
						vector53 += new Vector2(0f, 40f);
					}
					if (this.type == 375)
					{
						this.ai[1] = 3600f;
						this.netUpdate = true;
						vector53 = player.center() - value14;
						int num732 = 1;
						for (int num733 = 0; num733 < this.whoAmI; num733++)
						{
							if (Main.projectile[num733].active && Main.projectile[num733].owner == this.owner && Main.projectile[num733].type == this.type)
							{
								num732++;
							}
						}
						vector53.X -= (float)(10 * Main.player[this.owner].direction);
						vector53.X -= (float)(num732 * 40 * Main.player[this.owner].direction);
						vector53.Y -= 10f;
					}
					float num734 = vector53.Length();
					if (num734 > 200f && num731 < 9f)
					{
						num731 = 9f;
					}
					if (this.type == 375)
					{
						num731 = (float)((int)((double)num731 * 0.75));
					}
					if (num734 < 100f && this.ai[0] == 1f && !Collision.SolidCollision(this.position, this.width, this.height))
					{
						this.ai[0] = 0f;
						this.netUpdate = true;
					}
					if (num734 > 2000f)
					{
						this.position.X = Main.player[this.owner].center().X - (float)(this.width / 2);
						this.position.Y = Main.player[this.owner].center().Y - (float)(this.width / 2);
					}
					if (this.type == 375)
					{
						if (num734 > 10f)
						{
							vector53.Normalize();
							if (num734 < 50f)
							{
								num731 /= 2f;
							}
							vector53 *= num731;
							this.velocity = (this.velocity * 20f + vector53) / 21f;
						}
						else
						{
							this.direction = Main.player[this.owner].direction;
							this.velocity *= 0.9f;
						}
					}
					else if (this.type == 407)
					{
						if (Math.Abs(vector53.X) > 40f || Math.Abs(vector53.Y) > 10f)
						{
							vector53.Normalize();
							vector53 *= num731;
							vector53 *= new Vector2(1.25f, 0.65f);
							this.velocity = (this.velocity * 20f + vector53) / 21f;
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
					}
					else if (num734 > 70f)
					{
						vector53.Normalize();
						vector53 *= num731;
						this.velocity = (this.velocity * 20f + vector53) / 21f;
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
				}
				this.rotation = this.velocity.X * 0.05f;
				this.frameCounter++;
				if (this.type == 373)
				{
					if (this.frameCounter > 1)
					{
						this.frame++;
						this.frameCounter = 0;
					}
					if (this.frame > 2)
					{
						this.frame = 0;
					}
				}
				if (this.type == 375)
				{
					if (this.frameCounter >= 16)
					{
						this.frameCounter = 0;
					}
					this.frame = this.frameCounter / 4;
					if (this.ai[1] > 0f && this.ai[1] < 16f)
					{
						this.frame += 4;
					}
					if (Main.rand.Next(6) == 0)
					{
						int num735 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num735].velocity *= 0.3f;
						Main.dust[num735].noGravity = true;
						Main.dust[num735].noLight = true;
					}
				}
				if (this.type == 407)
				{
					int num736 = 2;
					if (this.frameCounter >= 6 * num736)
					{
						this.frameCounter = 0;
					}
					this.frame = this.frameCounter / num736;
					if (Main.rand.Next(5) == 0)
					{
						int num737 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 217, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num737].velocity *= 0.3f;
						Main.dust[num737].noGravity = true;
						Main.dust[num737].noLight = true;
					}
				}
				if (this.velocity.X > 0f)
				{
					this.spriteDirection = (this.direction = -1);
				}
				else if (this.velocity.X < 0f)
				{
					this.spriteDirection = (this.direction = 1);
				}
				if (this.type == 373)
				{
					if (this.ai[1] > 0f)
					{
						this.ai[1] += (float)Main.rand.Next(1, 4);
					}
					if (this.ai[1] > 90f)
					{
						this.ai[1] = 0f;
						this.netUpdate = true;
					}
				}
				else if (this.type == 375)
				{
					if (this.ai[1] > 0f)
					{
						this.ai[1] += 1f;
						if (Main.rand.Next(3) == 0)
						{
							this.ai[1] += 1f;
						}
					}
					if (this.ai[1] > (float)Main.rand.Next(180, 900))
					{
						this.ai[1] = 0f;
						this.netUpdate = true;
					}
				}
				else if (this.type == 407)
				{
					if (this.ai[1] > 0f)
					{
						this.ai[1] += 1f;
						if (Main.rand.Next(3) != 0)
						{
							this.ai[1] += 1f;
						}
					}
					if (this.ai[1] > 60f)
					{
						this.ai[1] = 0f;
						this.netUpdate = true;
					}
				}
				if (this.ai[0] == 0f)
				{
					float scaleFactor4 = 0f;
					int num738 = 0;
					if (this.type == 373)
					{
						scaleFactor4 = 10f;
						num738 = 374;
					}
					else if (this.type == 375)
					{
						scaleFactor4 = 11f;
						num738 = 376;
					}
					else if (this.type == 407)
					{
						scaleFactor4 = 14f;
						num738 = 408;
					}
					if (flag28)
					{
						if (this.type == 375)
						{
							if ((vector50 - this.center()).X > 0f)
							{
								this.spriteDirection = (this.direction = -1);
							}
							else if ((vector50 - this.center()).X < 0f)
							{
								this.spriteDirection = (this.direction = 1);
							}
						}
						if ((this.type != 407 || !Collision.SolidCollision(this.position, this.width, this.height)) && this.ai[1] == 0f)
						{
							this.ai[1] += 1f;
							if (Main.myPlayer == this.owner)
							{
								Vector2 value15 = vector50 - this.center();
								value15.Normalize();
								value15 *= scaleFactor4;
								int num739 = Projectile.NewProjectile(this.center().X, this.center().Y, value15.X, value15.Y, num738, this.damage, 0f, Main.myPlayer, 0f, 0f);
								Main.projectile[num739].timeLeft = 300;
								Main.projectile[num739].netUpdate = true;
								this.netUpdate = true;
							}
						}
					}
				}
			}
			if (this.aiStyle == 63)
			{
				if (!Main.player[this.owner].active)
				{
					this.active = false;
					return;
				}
				Vector2 value16 = this.position;
				bool flag29 = false;
				float num740 = 500f;
				for (int num741 = 0; num741 < 200; num741++)
				{
					NPC nPC3 = Main.npc[num741];
					if (nPC3.active && !nPC3.dontTakeDamage && !nPC3.friendly && nPC3.lifeMax > 5)
					{
						float num742 = Vector2.Distance(nPC3.center(), this.center());
						if (((Vector2.Distance(this.center(), value16) > num742 && num742 < num740) || !flag29) && Collision.CanHit(this.position, this.width, this.height, nPC3.position, nPC3.width, nPC3.height))
						{
							num740 = num742;
							value16 = nPC3.center();
							flag29 = true;
						}
					}
				}
				if (!flag29)
				{
					this.velocity.X = this.velocity.X * 0.95f;
				}
				else
				{
					float num743 = 5f;
					float num744 = 0.08f;
					if (this.velocity.Y == 0f)
					{
						bool flag30 = false;
						if (this.center().Y - 50f > value16.Y)
						{
							flag30 = true;
						}
						if (flag30)
						{
							this.velocity.Y = -6f;
						}
					}
					else
					{
						num743 = 8f;
						num744 = 0.12f;
					}
					this.velocity.X = this.velocity.X + (float)Math.Sign(value16.X - this.center().X) * num744;
					if (this.velocity.X < -num743)
					{
						this.velocity.X = -num743;
					}
					if (this.velocity.X > num743)
					{
						this.velocity.X = num743;
					}
				}
				float num745 = 0f;
				Collision.StepUp(ref this.position, ref this.velocity, this.width, this.height, ref num745, ref this.gfxOffY, 1, false);
				if (this.velocity.Y != 0f)
				{
					this.frame = 3;
				}
				else
				{
					if (Math.Abs(this.velocity.X) > 0.2f)
					{
						this.frameCounter++;
					}
					if (this.frameCounter >= 9)
					{
						this.frameCounter = 0;
					}
					if (this.frameCounter >= 6)
					{
						this.frame = 2;
					}
					else if (this.frameCounter >= 3)
					{
						this.frame = 1;
					}
					else
					{
						this.frame = 0;
					}
				}
				if (this.velocity.X != 0f)
				{
					this.direction = Math.Sign(this.velocity.X);
				}
				this.spriteDirection = -this.direction;
				this.velocity.Y = this.velocity.Y + 0.2f;
				if (this.velocity.Y > 16f)
				{
					this.velocity.Y = 16f;
				}
			}
			else if (this.aiStyle == 64)
			{
				int num746 = 10;
				int num747 = 15;
				float num748 = 1f;
				int num749 = 150;
				int num750 = 42;
				if (this.type == 386)
				{
					num746 = 16;
					num747 = 16;
					num748 = 1.5f;
				}
				if (this.velocity.X != 0f)
				{
					this.direction = (this.spriteDirection = -Math.Sign(this.velocity.X));
				}
				this.frameCounter++;
				if (this.frameCounter > 2)
				{
					this.frame++;
					this.frameCounter = 0;
				}
				if (this.frame >= 6)
				{
					this.frame = 0;
				}
				if (this.localAI[0] == 0f && Main.myPlayer == this.owner)
				{
					this.localAI[0] = 1f;
					this.position.X = this.position.X + (float)(this.width / 2);
					this.position.Y = this.position.Y + (float)(this.height / 2);
					this.scale = ((float)(num746 + num747) - this.ai[1]) * num748 / (float)(num747 + num746);
					this.width = (int)((float)num749 * this.scale);
					this.height = (int)((float)num750 * this.scale);
					this.position.X = this.position.X - (float)(this.width / 2);
					this.position.Y = this.position.Y - (float)(this.height / 2);
					this.netUpdate = true;
				}
				if (this.ai[1] != -1f)
				{
					this.scale = ((float)(num746 + num747) - this.ai[1]) * num748 / (float)(num747 + num746);
					this.width = (int)((float)num749 * this.scale);
					this.height = (int)((float)num750 * this.scale);
				}
				if (!Collision.SolidCollision(this.position, this.width, this.height))
				{
					this.alpha -= 30;
					if (this.alpha < 60)
					{
						this.alpha = 60;
					}
					if (this.type == 386 && this.alpha < 100)
					{
						this.alpha = 100;
					}
				}
				else
				{
					this.alpha += 30;
					if (this.alpha > 150)
					{
						this.alpha = 150;
					}
				}
				if (this.ai[0] > 0f)
				{
					this.ai[0] -= 1f;
				}
				if (this.ai[0] == 1f && this.ai[1] > 0f && this.owner == Main.myPlayer)
				{
					this.netUpdate = true;
					Vector2 vector54 = this.center();
					vector54.Y -= (float)num750 * this.scale / 2f;
					float num751 = ((float)(num746 + num747) - this.ai[1] + 1f) * num748 / (float)(num747 + num746);
					vector54.Y -= (float)num750 * num751 / 2f;
					vector54.Y += 2f;
					Projectile.NewProjectile(vector54.X, vector54.Y, this.velocity.X, this.velocity.Y, this.type, this.damage, this.knockBack, this.owner, 10f, this.ai[1] - 1f);
					int num752 = 4;
					if (this.type == 386)
					{
						num752 = 2;
					}
					if ((int)this.ai[1] % num752 == 0 && this.ai[1] != 0f)
					{
						int num753 = 372;
						if (this.type == 386)
						{
							num753 = 373;
						}
						int num754 = NPC.NewNPC((int)vector54.X, (int)vector54.Y, num753, 0);
						Main.npc[num754].velocity = this.velocity;
						Main.npc[num754].netUpdate = true;
						if (this.type == 386)
						{
							Main.npc[num754].ai[2] = (float)this.width;
							Main.npc[num754].ai[3] = -1.5f;
						}
					}
				}
				if (this.ai[0] <= 0f)
				{
					float num755 = 0.104719758f;
					float num756 = (float)this.width / 5f;
					if (this.type == 386)
					{
						num756 *= 2f;
					}
					float num757 = (float)(Math.Cos((double)(num755 * -(double)this.ai[0])) - 0.5) * num756;
					this.position.X = this.position.X - num757 * (float)(-(float)this.direction);
					this.ai[0] -= 1f;
					num757 = (float)(Math.Cos((double)(num755 * -(double)this.ai[0])) - 0.5) * num756;
					this.position.X = this.position.X + num757 * (float)(-(float)this.direction);
				}
			}
			else if (this.aiStyle == 65)
			{
				if (this.ai[1] > 0f)
				{
					int num758 = (int)this.ai[1] - 1;
					if (num758 < 255)
					{
						this.localAI[0] += 1f;
						if (this.localAI[0] > 10f)
						{
							int num759 = 6;
							for (int num760 = 0; num760 < num759; num760++)
							{
								Vector2 vector55 = Vector2.Normalize(this.velocity) * new Vector2((float)this.width / 2f, (float)this.height) * 0.75f;
								vector55 = vector55.Rotate((double)(num760 - (num759 / 2 - 1)) * 3.1415926535897931 / (double)((float)num759), default(Vector2)) + this.center();
								Vector2 value17 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - 1.57079637f).ToRotationVector2() * (float)Main.rand.Next(3, 8);
								int num761 = Dust.NewDust(vector55 + value17, 0, 0, 172, value17.X * 2f, value17.Y * 2f, 100, default(Color), 1.4f);
								Main.dust[num761].noGravity = true;
								Main.dust[num761].noLight = true;
								Main.dust[num761].velocity /= 4f;
								Main.dust[num761].velocity -= this.velocity;
							}
							this.alpha -= 5;
							if (this.alpha < 100)
							{
								this.alpha = 100;
							}
							this.rotation += this.velocity.X * 0.1f;
							this.frame = (int)(this.localAI[0] / 3f) % 3;
						}
						Vector2 value18 = Main.player[num758].center() - this.center();
						float num762 = 4f;
						num762 += this.localAI[0] / 20f;
						this.velocity = Vector2.Normalize(value18) * num762;
						if (value18.Length() < 50f)
						{
							this.Kill();
						}
					}
				}
				else
				{
					float num763 = 0.209439516f;
					float num764 = 4f;
					float num765 = (float)(Math.Cos((double)(num763 * this.ai[0])) - 0.5) * num764;
					this.velocity.Y = this.velocity.Y - num765;
					this.ai[0] += 1f;
					num765 = (float)(Math.Cos((double)(num763 * this.ai[0])) - 0.5) * num764;
					this.velocity.Y = this.velocity.Y + num765;
					this.localAI[0] += 1f;
					if (this.localAI[0] > 10f)
					{
						this.alpha -= 5;
						if (this.alpha < 100)
						{
							this.alpha = 100;
						}
						this.rotation += this.velocity.X * 0.1f;
						this.frame = (int)(this.localAI[0] / 3f) % 3;
					}
				}
				if (this.wet)
				{
					this.position.Y = this.position.Y - 16f;
					this.Kill();
				}
			}
			else if (this.aiStyle == 66)
			{
				if (this.type == 387 || this.type == 388)
				{
					if (Main.player[this.owner].dead)
					{
						Main.player[this.owner].twinsMinion = false;
					}
					if (Main.player[this.owner].twinsMinion)
					{
						this.timeLeft = 2;
					}
				}
				float num766 = 0.05f;
				for (int num767 = 0; num767 < 1000; num767++)
				{
					if (num767 != this.whoAmI && Main.projectile[num767].active && Main.projectile[num767].owner == this.owner && (Main.projectile[num767].type == 387 || Main.projectile[num767].type == 388) && Math.Abs(this.position.X - Main.projectile[num767].position.X) + Math.Abs(this.position.Y - Main.projectile[num767].position.Y) < (float)this.width)
					{
						if (this.position.X < Main.projectile[num767].position.X)
						{
							this.velocity.X = this.velocity.X - num766;
						}
						else
						{
							this.velocity.X = this.velocity.X + num766;
						}
						if (this.position.Y < Main.projectile[num767].position.Y)
						{
							this.velocity.Y = this.velocity.Y - num766;
						}
						else
						{
							this.velocity.Y = this.velocity.Y + num766;
						}
					}
				}
				if (this.ai[0] == 2f && this.type == 388)
				{
					this.ai[1] += 1f;
					this.maxUpdates = 1;
					this.rotation = this.velocity.ToRotation() + 3.14159274f;
					this.frameCounter++;
					if (this.frameCounter > 1)
					{
						this.frame++;
						this.frameCounter = 0;
					}
					if (this.frame > 2)
					{
						this.frame = 0;
					}
					if (this.ai[1] <= 40f)
					{
						return;
					}
					this.ai[1] = 1f;
					this.ai[0] = 0f;
					this.maxUpdates = 0;
					this.numUpdates = 0;
					this.netUpdate = true;
				}
				Vector2 vector56 = this.position;
				float num768 = 400f;
				bool flag31 = false;
				if (this.ai[0] != 1f)
				{
					this.tileCollide = true;
				}
				for (int num769 = 0; num769 < 200; num769++)
				{
					NPC nPC4 = Main.npc[num769];
					if (nPC4.active && !nPC4.dontTakeDamage && !nPC4.friendly && nPC4.lifeMax > 5)
					{
						float num770 = Vector2.Distance(nPC4.center(), this.center());
						if (((Vector2.Distance(this.center(), vector56) > num770 && num770 < num768) || !flag31) && Collision.CanHitLine(this.position, this.width, this.height, nPC4.position, nPC4.width, nPC4.height))
						{
							num768 = num770;
							vector56 = nPC4.center();
							flag31 = true;
						}
					}
				}
				int num771 = 500;
				if (flag31)
				{
					num771 = 1000;
				}
				Player player2 = Main.player[this.owner];
				if (Vector2.Distance(player2.center(), this.center()) > (float)num771)
				{
					this.ai[0] = 1f;
					this.tileCollide = false;
					this.netUpdate = true;
				}
				if (flag31 && this.ai[0] == 0f)
				{
					Vector2 vector57 = vector56 - this.center();
					float num772 = vector57.Length();
					vector57.Normalize();
					if (num772 > 200f)
					{
						float scaleFactor5 = 6f;
						if (this.type == 388)
						{
							scaleFactor5 = 8f;
						}
						vector57 *= scaleFactor5;
						this.velocity = (this.velocity * 40f + vector57) / 41f;
					}
					else
					{
						float num773 = 4f;
						vector57 *= -num773;
						this.velocity = (this.velocity * 40f + vector57) / 41f;
					}
				}
				else
				{
					float num774 = 6f;
					if (this.ai[0] == 1f)
					{
						num774 = 15f;
					}
					Vector2 value19 = this.center();
					Vector2 vector58 = player2.center() - value19 + new Vector2(0f, -60f);
					float num775 = vector58.Length();
					if (num775 > 200f && num774 < 8f)
					{
						num774 = 8f;
					}
					if (num775 < 150f && this.ai[0] == 1f && !Collision.SolidCollision(this.position, this.width, this.height))
					{
						this.ai[0] = 0f;
						this.netUpdate = true;
					}
					if (num775 > 2000f)
					{
						this.position.X = Main.player[this.owner].center().X - (float)(this.width / 2);
						this.position.Y = Main.player[this.owner].center().Y - (float)(this.height / 2);
						this.netUpdate = true;
					}
					if (num775 > 70f)
					{
						vector58.Normalize();
						vector58 *= num774;
						this.velocity = (this.velocity * 40f + vector58) / 41f;
					}
					else if (this.velocity.X == 0f && this.velocity.Y == 0f)
					{
						this.velocity.X = -0.15f;
						this.velocity.Y = -0.05f;
					}
				}
				if (this.type == 388)
				{
					this.rotation = this.velocity.ToRotation() + 3.14159274f;
				}
				if (this.type == 387)
				{
					if (flag31)
					{
						this.rotation = (vector56 - this.center()).ToRotation() + 3.14159274f;
					}
					else
					{
						this.rotation = this.velocity.ToRotation() + 3.14159274f;
					}
				}
				this.frameCounter++;
				if (this.frameCounter > 3)
				{
					this.frame++;
					this.frameCounter = 0;
				}
				if (this.frame > 2)
				{
					this.frame = 0;
				}
				if (this.ai[1] > 0f)
				{
					this.ai[1] += (float)Main.rand.Next(1, 4);
				}
				if (this.ai[1] > 90f && this.type == 387)
				{
					this.ai[1] = 0f;
					this.netUpdate = true;
				}
				if (this.ai[1] > 40f && this.type == 388)
				{
					this.ai[1] = 0f;
					this.netUpdate = true;
				}
				if (this.ai[0] == 0f)
				{
					if (this.type == 387)
					{
						float scaleFactor6 = 8f;
						int num776 = 389;
						if (flag31 && this.ai[1] == 0f)
						{
							this.ai[1] += 1f;
							if (Main.myPlayer == this.owner && Collision.CanHitLine(this.position, this.width, this.height, vector56, 0, 0))
							{
								Vector2 value20 = vector56 - this.center();
								value20.Normalize();
								value20 *= scaleFactor6;
								int num777 = Projectile.NewProjectile(this.center().X, this.center().Y, value20.X, value20.Y, num776, (int)((float)this.damage * 0.8f), 0f, Main.myPlayer, 0f, 0f);
								Main.projectile[num777].timeLeft = 300;
								this.netUpdate = true;
							}
						}
					}
					if (this.type == 388 && this.ai[1] == 0f && flag31 && num768 < 500f)
					{
						this.ai[1] += 1f;
						if (Main.myPlayer == this.owner)
						{
							this.ai[0] = 2f;
							Vector2 value21 = vector56 - this.center();
							value21.Normalize();
							this.velocity = value21 * 8f;
							this.netUpdate = true;
						}
					}
				}
			}
			else if (this.aiStyle == 67)
			{
				Player player3 = Main.player[this.owner];
				if (!player3.active)
				{
					this.active = false;
					return;
				}
				if (player3.dead)
				{
					player3.pirateMinion = false;
				}
				if (player3.pirateMinion)
				{
					this.timeLeft = 2;
				}
				Vector2 vector59 = player3.center();
				vector59.X -= (float)((15 + player3.width / 2) * player3.direction);
				vector59.X -= (float)(this.minionPos * 40 * player3.direction);
				if (this.ai[0] == 0f)
				{
					float num778 = 500f;
					if (Main.player[this.owner].rocketDelay2 > 0)
					{
						this.ai[0] = 1f;
						this.netUpdate = true;
					}
					Vector2 vector60 = player3.center() - this.center();
					if (vector60.Length() > 2000f)
					{
						this.position = player3.center() - new Vector2((float)this.width, (float)this.height) / 2f;
					}
					else if (vector60.Length() > num778 || Math.Abs(vector60.Y) > 300f)
					{
						this.ai[0] = 1f;
						this.netUpdate = true;
						if (this.velocity.Y > 0f && vector60.Y < 0f)
						{
							this.velocity.Y = 0f;
						}
						if (this.velocity.Y < 0f && vector60.Y > 0f)
						{
							this.velocity.Y = 0f;
						}
					}
				}
				int num779 = -1;
				float num780 = 450f;
				int num781 = 15;
				if (this.ai[0] == 0f)
				{
					for (int num782 = 0; num782 < 200; num782++)
					{
						NPC nPC5 = Main.npc[num782];
						if (nPC5.active && !nPC5.dontTakeDamage && !nPC5.friendly && nPC5.lifeMax > 5)
						{
							float num783 = (nPC5.center() - this.center()).Length();
							if (num783 < num780)
							{
								num779 = num782;
								num780 = num783;
							}
						}
					}
				}
				if (this.ai[0] == 1f)
				{
					this.tileCollide = false;
					float num784 = 0.2f;
					float num785 = 10f;
					int num786 = 200;
					if (num785 < Math.Abs(player3.velocity.X) + Math.Abs(player3.velocity.Y))
					{
						num785 = Math.Abs(player3.velocity.X) + Math.Abs(player3.velocity.Y);
					}
					Vector2 value22 = player3.center() - this.center();
					float num787 = value22.Length();
					if (num787 > 2000f)
					{
						this.position = player3.center() - new Vector2((float)this.width, (float)this.height) / 2f;
					}
					if (num787 < (float)num786 && player3.velocity.Y == 0f && this.position.Y + (float)this.height <= player3.position.Y + (float)player3.height && !Collision.SolidCollision(this.position, this.width, this.height))
					{
						this.ai[0] = 0f;
						this.netUpdate = true;
						if (this.velocity.Y < -6f)
						{
							this.velocity.Y = -6f;
						}
					}
					if (num787 >= 60f)
					{
						value22.Normalize();
						value22 *= num785;
						if (this.velocity.X < value22.X)
						{
							this.velocity.X = this.velocity.X + num784;
							if (this.velocity.X < 0f)
							{
								this.velocity.X = this.velocity.X + num784 * 1.5f;
							}
						}
						if (this.velocity.X > value22.X)
						{
							this.velocity.X = this.velocity.X - num784;
							if (this.velocity.X > 0f)
							{
								this.velocity.X = this.velocity.X - num784 * 1.5f;
							}
						}
						if (this.velocity.Y < value22.Y)
						{
							this.velocity.Y = this.velocity.Y + num784;
							if (this.velocity.Y < 0f)
							{
								this.velocity.Y = this.velocity.Y + num784 * 1.5f;
							}
						}
						if (this.velocity.Y > value22.Y)
						{
							this.velocity.Y = this.velocity.Y - num784;
							if (this.velocity.Y > 0f)
							{
								this.velocity.Y = this.velocity.Y - num784 * 1.5f;
							}
						}
					}
					if (this.velocity.X != 0f)
					{
						this.spriteDirection = Math.Sign(this.velocity.X);
					}
					this.frameCounter++;
					if (this.frameCounter > 3)
					{
						this.frame++;
						this.frameCounter = 0;
					}
					if (this.frame < 10 | this.frame > 13)
					{
						this.frame = 10;
					}
					this.rotation = this.velocity.X * 0.1f;
				}
				if (this.ai[0] == 2f)
				{
					this.friendly = true;
					this.spriteDirection = this.direction;
					this.rotation = 0f;
					this.frame = 4 + (int)((float)num781 - this.ai[1]) / (num781 / 3);
					if (this.velocity.Y != 0f)
					{
						this.frame += 3;
					}
					this.velocity.Y = this.velocity.Y + 0.4f;
					if (this.velocity.Y > 10f)
					{
						this.velocity.Y = 10f;
					}
					this.ai[1] -= 1f;
					if (this.ai[1] <= 0f)
					{
						this.ai[1] = 0f;
						this.ai[0] = 0f;
						this.friendly = false;
						this.netUpdate = true;
						return;
					}
				}
				if (num779 >= 0)
				{
					float num788 = 400f;
					float num789 = 20f;
					if ((double)this.position.Y > Main.worldSurface * 16.0)
					{
						num788 = 200f;
					}
					NPC nPC6 = Main.npc[num779];
					Vector2 vector61 = nPC6.center();
					float num790 = (vector61 - this.center()).Length();
					Collision.CanHit(this.position, this.width, this.height, nPC6.position, nPC6.width, nPC6.height);
					if (num790 < num788)
					{
						vector59 = vector61;
						if (vector61.Y < this.center().Y - 30f && this.velocity.Y == 0f)
						{
							float num791 = Math.Abs(vector61.Y - this.center().Y);
							if (num791 < 120f)
							{
								this.velocity.Y = -10f;
							}
							else if (num791 < 210f)
							{
								this.velocity.Y = -13f;
							}
							else if (num791 < 270f)
							{
								this.velocity.Y = -15f;
							}
							else if (num791 < 310f)
							{
								this.velocity.Y = -17f;
							}
							else if (num791 < 380f)
							{
								this.velocity.Y = -18f;
							}
						}
					}
					if (num790 < num789)
					{
						this.ai[0] = 2f;
						this.ai[1] = (float)num781;
						this.netUpdate = true;
					}
				}
				if (this.ai[0] == 0f)
				{
					this.tileCollide = true;
					float num792 = 0.5f;
					float num793 = 4f;
					float num794 = 4f;
					float num795 = 0.1f;
					if (num794 < Math.Abs(player3.velocity.X) + Math.Abs(player3.velocity.Y))
					{
						num794 = Math.Abs(player3.velocity.X) + Math.Abs(player3.velocity.Y);
						num792 = 0.7f;
					}
					int num796 = 0;
					bool flag32 = false;
					float num797 = vector59.X - this.center().X;
					if (Math.Abs(num797) > 5f)
					{
						if (num797 < 0f)
						{
							num796 = -1;
							if (this.velocity.X > -num793)
							{
								this.velocity.X = this.velocity.X - num792;
							}
							else
							{
								this.velocity.X = this.velocity.X - num795;
							}
						}
						else
						{
							num796 = 1;
							if (this.velocity.X < num793)
							{
								this.velocity.X = this.velocity.X + num792;
							}
							else
							{
								this.velocity.X = this.velocity.X + num795;
							}
						}
					}
					else
					{
						this.velocity.X = this.velocity.X * 0.9f;
						if (Math.Abs(this.velocity.X) < num792 * 2f)
						{
							this.velocity.X = 0f;
						}
					}
					if (num796 != 0)
					{
						int num798 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num799 = (int)this.position.Y / 16;
						num798 += num796;
						num798 += (int)this.velocity.X;
						for (int num800 = num799; num800 < num799 + this.height / 16 + 1; num800++)
						{
							if (WorldGen.SolidTile(num798, num800))
							{
								flag32 = true;
							}
						}
					}
					Collision.StepUp(ref this.position, ref this.velocity, this.width, this.height, ref this.stepSpeed, ref this.gfxOffY, 1, false);
					if (this.velocity.Y == 0f && flag32)
					{
						int num801 = 0;
						while (num801 < 3)
						{
							int num802 = (int)(this.position.X + (float)(this.width / 2)) / 16;
							if (num801 == 0)
							{
								num802 = (int)this.position.X / 16;
							}
							if (num801 == 2)
							{
								num802 = (int)(this.position.X + (float)this.width) / 16;
							}
							int num803 = (int)(this.position.Y + (float)this.height) / 16 + 1;

							if (WorldGen.SolidTile(num802, num803) || Main.tile[num802, num803].halfBrick())
							{
							}
							else
							{
								if (Main.tile[num802, num803].slope() <= 0)
								{
									num801++;
									continue;
								}
							}
							try
							{
								IL_24434:
								num802 = (int)(this.position.X + (float)(this.width / 2)) / 16;
								num803 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
								num802 += num796;
								num802 += (int)this.velocity.X;
								if (!WorldGen.SolidTile(num802, num803 - 1) && !WorldGen.SolidTile(num802, num803 - 2))
								{
									this.velocity.Y = -5.1f;
								}
								else if (!WorldGen.SolidTile(num802, num803 - 2))
								{
									this.velocity.Y = -7.1f;
								}
								else if (WorldGen.SolidTile(num802, num803 - 5))
								{
									this.velocity.Y = -11.1f;
								}
								else if (WorldGen.SolidTile(num802, num803 - 4))
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
							num801++;
							continue;
						}
					}
					if (this.velocity.X > num794)
					{
						this.velocity.X = num794;
					}
					if (this.velocity.X < -num794)
					{
						this.velocity.X = -num794;
					}
					if (this.velocity.X < 0f)
					{
						this.direction = -1;
					}
					if (this.velocity.X > 0f)
					{
						this.direction = 1;
					}
					if (this.velocity.X > num792 && num796 == 1)
					{
						this.direction = 1;
					}
					if (this.velocity.X < -num792 && num796 == -1)
					{
						this.direction = -1;
					}
					this.spriteDirection = this.direction;
					this.rotation = 0f;
					if (this.velocity.Y == 0f)
					{
						if (this.velocity.X == 0f)
						{
							this.frame = 0;
							this.frameCounter = 0;
						}
						else if (Math.Abs(this.velocity.X) >= 0.5f)
						{
							this.frameCounter += (int)Math.Abs(this.velocity.X);
							this.frameCounter++;
							if (this.frameCounter > 10)
							{
								this.frame++;
								this.frameCounter = 0;
							}
							if (this.frame >= 4)
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
					else if (this.velocity.Y != 0f)
					{
						this.frameCounter = 0;
						this.frame = 14;
					}
					this.velocity.Y = this.velocity.Y + 0.4f;
					if (this.velocity.Y > 10f)
					{
						this.velocity.Y = 10f;
					}
				}
				this.localAI[0] += 1f;
				if (this.velocity.X == 0f)
				{
					this.localAI[0] += 1f;
				}
				if (this.localAI[0] >= (float)Main.rand.Next(900, 1200))
				{
					this.localAI[0] = 0f;
					for (int num804 = 0; num804 < 6; num804++)
					{
						int num805 = Dust.NewDust(this.center() + Vector2.UnitX * (float)(-(float)this.direction) * 8f - Vector2.One * 5f + Vector2.UnitY * 8f, 3, 6, 216, (float)(-(float)this.direction), 1f, 0, default(Color), 1f);
						Main.dust[num805].velocity /= 2f;
						Main.dust[num805].scale = 0.8f;
					}
					int num806 = Gore.NewGore(this.center() + Vector2.UnitX * (float)(-(float)this.direction) * 8f, Vector2.Zero, Main.rand.Next(580, 583), 1f);
					Main.gore[num806].velocity /= 2f;
					Main.gore[num806].velocity.Y = Math.Abs(Main.gore[num806].velocity.Y);
					Main.gore[num806].velocity.X = -Math.Abs(Main.gore[num806].velocity.X) * (float)this.direction;
				}
			}
			else if (this.aiStyle == 68)
			{
				this.rotation += 0.25f * (float)this.direction;
				this.ai[0] += 1f;
				if (this.ai[0] >= 3f)
				{
					this.alpha -= 40;
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
				}
				if (this.ai[0] >= 15f)
				{
					this.velocity.Y = this.velocity.Y + 0.2f;
					if (this.velocity.Y > 16f)
					{
						this.velocity.Y = 16f;
					}
					this.velocity.X = this.velocity.X * 0.99f;
				}
				if (this.alpha == 0)
				{
					Vector2 vector62 = new Vector2(4f, -8f);
					float num807 = this.rotation;
					if (this.direction == -1)
					{
						vector62.X = -4f;
					}
					vector62 = vector62.Rotate((double)num807, default(Vector2));
					for (int num808 = 0; num808 < 1; num808++)
					{
						int num809 = Dust.NewDust(this.center() + vector62 - Vector2.One * 5f, 4, 4, 6, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num809].scale = 1.5f;
						Main.dust[num809].noGravity = true;
						Main.dust[num809].velocity = Main.dust[num809].velocity * 0.25f + Vector2.Normalize(vector62) * 1f;
						Main.dust[num809].velocity = Main.dust[num809].velocity.Rotate((double)(-1.57079637f * (float)this.direction), default(Vector2));
					}
				}
				this.spriteDirection = this.direction;
				if (this.owner == Main.myPlayer && this.timeLeft <= 3)
				{
					this.tileCollide = false;
					this.alpha = 255;
					this.position.X = this.position.X + (float)(this.width / 2);
					this.position.Y = this.position.Y + (float)(this.height / 2);
					this.width = 80;
					this.height = 80;
					this.position.X = this.position.X - (float)(this.width / 2);
					this.position.Y = this.position.Y - (float)(this.height / 2);
					this.knockBack = 8f;
				}
				if (this.wet && this.timeLeft > 3)
				{
					this.timeLeft = 3;
				}
			}
			else if (this.aiStyle == 69)
			{
				Vector2 vector63 = Main.player[this.owner].center() - this.center();
				this.rotation = vector63.ToRotation() - 1.57f;
				if (Main.player[this.owner].dead)
				{
					this.Kill();
					return;
				}
				Main.player[this.owner].itemAnimation = 10;
				Main.player[this.owner].itemTime = 10;
				if (vector63.X < 0f)
				{
					Main.player[this.owner].ChangeDir(1);
					this.direction = 1;
				}
				else
				{
					Main.player[this.owner].ChangeDir(-1);
					this.direction = -1;
				}
				Main.player[this.owner].itemRotation = (vector63 * -1f * (float)this.direction).ToRotation();
				this.spriteDirection = ((vector63.X > 0f) ? -1 : 1);
				if (this.ai[0] == 0f && vector63.Length() > 400f)
				{
					this.ai[0] = 1f;
				}
				if (this.ai[0] == 1f || this.ai[0] == 2f)
				{
					float num810 = vector63.Length();
					if (num810 > 1500f)
					{
						this.Kill();
						return;
					}
					if (num810 > 600f)
					{
						this.ai[0] = 2f;
					}
					this.tileCollide = false;
					float num811 = 20f;
					if (this.ai[0] == 2f)
					{
						num811 = 40f;
					}
					this.velocity = Vector2.Normalize(vector63) * num811;
					if (vector63.Length() < num811)
					{
						this.Kill();
						return;
					}
				}
				this.ai[1] += 1f;
				if (this.ai[1] > 5f)
				{
					this.alpha = 0;
				}
				if ((int)this.ai[1] % 3 == 0 && this.owner == Main.myPlayer)
				{
					Vector2 vector64 = vector63 * -1f;
					vector64.Normalize();
					vector64 *= (float)Main.rand.Next(45, 65) * 0.1f;
					vector64 = vector64.Rotate((Main.rand.NextDouble() - 0.5) * 1.5707963705062866, default(Vector2));
					Projectile.NewProjectile(this.center().X, this.center().Y, vector64.X, vector64.Y, 405, this.damage, this.knockBack, this.owner, -10f, 0f);
				}
			}
			else if (this.aiStyle == 70)
			{
				if (this.ai[0] == 0f)
				{
					float num812 = 500f;
					int num813 = -1;
					for (int num814 = 0; num814 < 200; num814++)
					{
						NPC nPC7 = Main.npc[num814];
						if (nPC7.active && !nPC7.dontTakeDamage && !nPC7.friendly && nPC7.lifeMax > 5 && Collision.CanHit(this.position, this.width, this.height, nPC7.position, nPC7.width, nPC7.height))
						{
							float num815 = (nPC7.center() - this.center()).Length();
							if (num815 < num812)
							{
								num813 = num814;
								num812 = num815;
							}
						}
					}
					this.ai[0] = (float)(num813 + 1);
					if (this.ai[0] == 0f)
					{
						this.ai[0] = -15f;
					}
					if (this.ai[0] > 0f)
					{
						float scaleFactor7 = (float)Main.rand.Next(35, 75) / 10f;
						this.velocity = Vector2.Normalize(Main.npc[(int)this.ai[0] - 1].center() - this.center() + new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101))) * scaleFactor7;
						this.netUpdate = true;
					}
				}
				else if (this.ai[0] > 0f)
				{
					Vector2 value23 = Vector2.Normalize(Main.npc[(int)this.ai[0] - 1].center() - this.center());
					this.velocity = (this.velocity * 40f + value23 * 12f) / 41f;
				}
				else
				{
					this.ai[0] += 1f;
					this.alpha -= 25;
					if (this.alpha < 50)
					{
						this.alpha = 50;
					}
					this.velocity *= 0.95f;
				}
				if (this.ai[1] == 0f)
				{
					this.ai[1] = (float)Main.rand.Next(80, 121) / 100f;
					this.netUpdate = true;
				}
				this.scale = this.ai[1];
			}
			else if (this.aiStyle == 71)
			{
				this.localAI[1] += 1f;
				if (this.localAI[1] > 10f && Main.rand.Next(3) == 0)
				{
					int num816 = 6;
					for (int num817 = 0; num817 < num816; num817++)
					{
						Vector2 vector65 = Vector2.Normalize(this.velocity) * new Vector2((float)this.width, (float)this.height) / 2f;
						vector65 = vector65.Rotate((double)(num817 - (num816 / 2 - 1)) * 3.1415926535897931 / (double)((float)num816), default(Vector2)) + this.center();
						Vector2 value24 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - 1.57079637f).ToRotationVector2() * (float)Main.rand.Next(3, 8);
						int num818 = Dust.NewDust(vector65 + value24, 0, 0, 217, value24.X * 2f, value24.Y * 2f, 100, default(Color), 1.4f);
						Main.dust[num818].noGravity = true;
						Main.dust[num818].noLight = true;
						Main.dust[num818].velocity /= 4f;
						Main.dust[num818].velocity -= this.velocity;
					}
					this.alpha -= 5;
					if (this.alpha < 50)
					{
						this.alpha = 50;
					}
					this.rotation += this.velocity.X * 0.1f;
					this.frame = (int)(this.localAI[1] / 3f) % 3;
					Lighting.addLight((int)this.center().X / 16, (int)this.center().Y / 16, 0.1f, 0.4f, 0.6f);
				}
				int num819 = -1;
				Vector2 vector66 = this.center();
				float num820 = 500f;
				if (this.localAI[0] > 0f)
				{
					this.localAI[0] -= 1f;
				}
				if (this.ai[0] == 0f && this.localAI[0] == 0f)
				{
					for (int num821 = 0; num821 < 200; num821++)
					{
						NPC nPC8 = Main.npc[num821];
						if (nPC8.active && !nPC8.dontTakeDamage && !nPC8.friendly && nPC8.lifeMax > 5 && (this.ai[0] == 0f || this.ai[0] == (float)(num821 + 1)))
						{
							Vector2 vector67 = nPC8.center();
							float num822 = Vector2.Distance(vector67, vector66);
							if (num822 < num820 && Collision.CanHit(this.position, this.width, this.height, nPC8.position, nPC8.width, nPC8.height))
							{
								num820 = num822;
								vector66 = vector67;
								num819 = num821;
							}
						}
					}
					if (num819 >= 0)
					{
						this.ai[0] = (float)(num819 + 1);
						this.netUpdate = true;
					}
				}
				if (this.localAI[0] == 0f && this.ai[0] == 0f)
				{
					this.localAI[0] = 30f;
				}
				bool flag33 = false;
				if (this.ai[0] != 0f)
				{
					int num823 = (int)(this.ai[0] - 1f);
					if (Main.npc[num823].active && !Main.npc[num823].dontTakeDamage && Main.npc[num823].immune[this.owner] == 0)
					{
						float num824 = Main.npc[num823].position.X + (float)(Main.npc[num823].width / 2);
						float num825 = Main.npc[num823].position.Y + (float)(Main.npc[num823].height / 2);
						float num826 = Math.Abs(this.position.X + (float)(this.width / 2) - num824) + Math.Abs(this.position.Y + (float)(this.height / 2) - num825);
						if (num826 < 1000f)
						{
							flag33 = true;
							vector66 = Main.npc[num823].center();
						}
					}
					else
					{
						this.ai[0] = 0f;
						flag33 = false;
						this.netUpdate = true;
					}
				}
				if (flag33)
				{
					Vector2 v = vector66 - this.center();
					float num827 = this.velocity.ToRotation();
					float num828 = v.ToRotation();
					double num829 = (double)(num828 - num827);
					if (num829 > 3.1415926535897931)
					{
						num829 -= 6.2831853071795862;
					}
					if (num829 < -3.1415926535897931)
					{
						num829 += 6.2831853071795862;
					}
					this.velocity = this.velocity.Rotate(num829 * 0.10000000149011612, default(Vector2));
				}
				float num830 = this.velocity.Length();
				this.velocity.Normalize();
				this.velocity *= num830 + 0.0025f;
			}
			else if (this.aiStyle == 72)
			{
				this.localAI[0] += 1f;
				if (this.localAI[0] > 5f)
				{
					this.alpha -= 25;
					if (this.alpha < 50)
					{
						this.alpha = 50;
					}
				}
				this.velocity *= 0.96f;
				if (this.ai[1] == 0f)
				{
					this.ai[1] = (float)Main.rand.Next(60, 121) / 100f;
					this.netUpdate = true;
				}
				this.scale = this.ai[1];
				this.position = this.center();
				int num831 = 14;
				int num832 = 14;
				this.width = (int)((float)num831 * this.ai[1]);
				this.height = (int)((float)num832 * this.ai[1]);
				this.position -= new Vector2((float)(this.width / 2), (float)(this.height / 2));
			}
			if (this.aiStyle == 73)
			{
				int num833 = (int)this.ai[0];
				int num834 = (int)this.ai[1];
				Tile tile = Main.tile[num833, num834];
				if (tile == null || !tile.active() || tile.type != 338)
				{
					this.Kill();
					return;
				}
				float num835 = 2f;
				float num836 = (float)this.timeLeft / 60f;
				if (num836 < 1f)
				{
					num835 *= num836;
				}
				if (this.type == 419)
				{
					for (int num837 = 0; num837 < 2; num837++)
					{
						Vector2 vector68 = new Vector2(0f, -num835);
						vector68 *= 0.85f + (float)Main.rand.NextDouble() * 0.2f;
						vector68 = vector68.Rotate((Main.rand.NextDouble() - 0.5) * 1.5707963705062866, default(Vector2));
						int num838 = Dust.NewDust(this.position, this.width, this.height, 222, 0f, 0f, 100, default(Color), 1f);
						Dust dust = Main.dust[num838];
						dust.scale = 1f + (float)Main.rand.NextDouble() * 0.3f;
						dust.velocity *= 0.5f;
						if (dust.velocity.Y > 0f)
						{
							Dust expr_25C1E_cp_0 = dust;
							expr_25C1E_cp_0.velocity.Y = expr_25C1E_cp_0.velocity.Y * -1f;
						}
						dust.position -= new Vector2((float)(2 + Main.rand.Next(-2, 3)), 0f);
						dust.velocity += vector68;
						dust.scale = 0.6f;
						dust.fadeIn = dust.scale + 0.2f;
						Dust expr_25CA4_cp_0 = dust;
						expr_25CA4_cp_0.velocity.Y = expr_25CA4_cp_0.velocity.Y * 2f;
					}
				}
				if (this.type == 420)
				{
					for (int num839 = 0; num839 < 2; num839++)
					{
						Vector2 vector69 = new Vector2(0f, -num835);
						vector69 *= 0.85f + (float)Main.rand.NextDouble() * 0.2f;
						vector69 = vector69.Rotate((Main.rand.NextDouble() - 0.5) * 1.5707963705062866, default(Vector2));
						int num840 = 219;
						if (Main.rand.Next(5) == 0)
						{
							num840 = 222;
						}
						int num841 = Dust.NewDust(this.position, this.width, this.height, num840, 0f, 0f, 100, default(Color), 1f);
						Dust dust2 = Main.dust[num841];
						dust2.scale = 1f + (float)Main.rand.NextDouble() * 0.3f;
						dust2.velocity *= 0.5f;
						if (dust2.velocity.Y > 0f)
						{
							Dust expr_25E15_cp_0 = dust2;
							expr_25E15_cp_0.velocity.Y = expr_25E15_cp_0.velocity.Y * -1f;
						}
						dust2.position -= new Vector2((float)(2 + Main.rand.Next(-2, 3)), 0f);
						dust2.velocity += vector69;
						Dust expr_25E75_cp_0 = dust2;
						expr_25E75_cp_0.velocity.X = expr_25E75_cp_0.velocity.X * 0.5f;
						dust2.scale = 0.6f;
						dust2.fadeIn = dust2.scale + 0.2f;
						Dust expr_25EB5_cp_0 = dust2;
						expr_25EB5_cp_0.velocity.Y = expr_25EB5_cp_0.velocity.Y * 2f;
					}
				}
				if (this.type == 421)
				{
					for (int num842 = 0; num842 < 2; num842++)
					{
						Vector2 vector70 = new Vector2(0f, -num835);
						vector70 *= 0.85f + (float)Main.rand.NextDouble() * 0.2f;
						vector70 = vector70.Rotate((Main.rand.NextDouble() - 0.5) * 0.78539818525314331, default(Vector2));
						int num843 = Dust.NewDust(this.position, this.width, this.height, 221, 0f, 0f, 100, default(Color), 1f);
						Dust dust3 = Main.dust[num843];
						dust3.scale = 1f + (float)Main.rand.NextDouble() * 0.3f;
						dust3.velocity *= 0.1f;
						if (dust3.velocity.Y > 0f)
						{
							Dust expr_26008_cp_0 = dust3;
							expr_26008_cp_0.velocity.Y = expr_26008_cp_0.velocity.Y * -1f;
						}
						dust3.position -= new Vector2((float)(2 + Main.rand.Next(-2, 3)), 0f);
						dust3.velocity += vector70;
						dust3.scale = 0.6f;
						dust3.fadeIn = dust3.scale + 0.2f;
						Dust expr_2608E_cp_0 = dust3;
						expr_2608E_cp_0.velocity.Y = expr_2608E_cp_0.velocity.Y * 2.5f;
					}
					if (this.timeLeft % 10 == 0)
					{
						float num844 = 0.85f + (float)Main.rand.NextDouble() * 0.2f;
						for (int num845 = 0; num845 < 9; num845++)
						{
							Vector2 value25 = new Vector2((float)(num845 - 4) / 5f, -num835 * num844);
							int num846 = Dust.NewDust(this.position, this.width, this.height, 222, 0f, 0f, 100, default(Color), 1f);
							Dust dust4 = Main.dust[num846];
							dust4.scale = 0.7f + (float)Main.rand.NextDouble() * 0.3f;
							dust4.velocity *= 0f;
							if (dust4.velocity.Y > 0f)
							{
								Dust expr_261AA_cp_0 = dust4;
								expr_261AA_cp_0.velocity.Y = expr_261AA_cp_0.velocity.Y * -1f;
							}
							dust4.position -= new Vector2((float)(2 + Main.rand.Next(-2, 3)), 0f);
							dust4.velocity += value25;
							dust4.scale = 0.6f;
							dust4.fadeIn = dust4.scale + 0.2f;
							Dust expr_26230_cp_0 = dust4;
							expr_26230_cp_0.velocity.Y = expr_26230_cp_0.velocity.Y * 2f;
						}
					}
				}
				if (this.type == 422)
				{
					for (int num847 = 0; num847 < 2; num847++)
					{
						Vector2 vector71 = new Vector2(0f, -num835);
						vector71 *= 0.85f + (float)Main.rand.NextDouble() * 0.2f;
						vector71 = vector71.Rotate((Main.rand.NextDouble() - 0.5) * 1.5707963705062866, default(Vector2));
						int num848 = Dust.NewDust(this.position, this.width, this.height, 219 + Main.rand.Next(5), 0f, 0f, 100, default(Color), 1f);
						Dust dust5 = Main.dust[num848];
						dust5.scale = 1f + (float)Main.rand.NextDouble() * 0.3f;
						dust5.velocity *= 0.5f;
						if (dust5.velocity.Y > 0f)
						{
							Dust expr_26390_cp_0 = dust5;
							expr_26390_cp_0.velocity.Y = expr_26390_cp_0.velocity.Y * -1f;
						}
						dust5.position -= new Vector2((float)(2 + Main.rand.Next(-2, 3)), 0f);
						dust5.velocity += vector71;
						dust5.scale = 0.6f;
						dust5.fadeIn = dust5.scale + 0.2f;
						Dust expr_26416_cp_0 = dust5;
						expr_26416_cp_0.velocity.Y = expr_26416_cp_0.velocity.Y * 2f;
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
			if (this.type == 405)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 54);
				this.center();
				for (int i = 0; i < 20; i++)
				{
					int num = 10;
					//((float)Main.rand.NextDouble() * 6.28318548f).ToRotationVector2() * (float)Main.rand.Next(24, 41) / 8f; TODO:DECOMPILER BS
					int num2 = Dust.NewDust(this.center() - Vector2.One * (float)num, num * 2, num * 2, 212, 0f, 0f, 0, default(Color), 1f);
					Dust dust = Main.dust[num2];
					Vector2 value = Vector2.Normalize(dust.position - this.center());
					dust.position = this.center() + value * (float)num * this.scale;
					if (i < 30)
					{
						dust.velocity = value * dust.velocity.Length();
					}
					else
					{
						dust.velocity = value * (float)Main.rand.Next(45, 91) / 10f;
					}
					dust.color = Main.hslToRgb((float)(0.40000000596046448 + Main.rand.NextDouble() * 0.20000000298023224), 0.9f, 0.5f);
					dust.color = Color.Lerp(dust.color, Color.White, 0.3f);
					dust.noGravity = true;
					dust.scale = 0.7f;
				}
			}
			if (this.type == 410)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 54);
				this.center();
				for (int j = 0; j < 10; j++)
				{
					int num3 = (int)(10f * this.ai[1]);
					//((float)Main.rand.NextDouble() * 6.28318548f).ToRotationVector2() * (float)Main.rand.Next(24, 41) / 8f; TODO: DECOMPIlerBS
					int num4 = Dust.NewDust(this.center() - Vector2.One * (float)num3, num3 * 2, num3 * 2, 212, 0f, 0f, 0, default(Color), 1f);
					Dust dust2 = Main.dust[num4];
					Vector2 value2 = Vector2.Normalize(dust2.position - this.center());
					dust2.position = this.center() + value2 * (float)num3 * this.scale;
					if (j < 30)
					{
						dust2.velocity = value2 * dust2.velocity.Length();
					}
					else
					{
						dust2.velocity = value2 * (float)Main.rand.Next(45, 91) / 10f;
					}
					dust2.color = Main.hslToRgb((float)(0.40000000596046448 + Main.rand.NextDouble() * 0.20000000298023224), 0.9f, 0.5f);
					dust2.color = Color.Lerp(dust2.color, Color.White, 0.3f);
					dust2.noGravity = true;
					dust2.scale = 0.7f;
				}
			}
			if (this.type == 408)
			{
				for (int k = 0; k < 15; k++)
				{
					int num5 = Dust.NewDust(this.center() - Vector2.One * 10f, 50, 50, 5, 0f, -2f, 0, default(Color), 1f);
					Main.dust[num5].velocity /= 2f;
				}
				int num6 = 10;
				int num7 = Gore.NewGore(this.center(), this.velocity * 0.8f, 584, 1f);
				Main.gore[num7].timeLeft /= num6;
				num7 = Gore.NewGore(this.center(), this.velocity * 0.9f, 585, 1f);
				Main.gore[num7].timeLeft /= num6;
				num7 = Gore.NewGore(this.center(), this.velocity * 1f, 586, 1f);
				Main.gore[num7].timeLeft /= num6;
			}
			if (this.type == 385)
			{
				Main.PlaySound(4, (int)this.center().X, (int)this.center().Y, 19);
				int num8 = 36;
				for (int l = 0; l < num8; l++)
				{
					Vector2 vector = Vector2.Normalize(this.velocity) * new Vector2((float)this.width / 2f, (float)this.height) * 0.75f;
					vector = vector.Rotate((double)((float)(l - (num8 / 2 - 1)) * 6.28318548f / (float)num8), default(Vector2)) + this.center();
					Vector2 value3 = vector - this.center();
					int num9 = Dust.NewDust(vector + value3, 0, 0, 172, value3.X * 2f, value3.Y * 2f, 100, default(Color), 1.4f);
					Main.dust[num9].noGravity = true;
					Main.dust[num9].noLight = true;
					Main.dust[num9].velocity = value3;
				}
				if (this.owner == Main.myPlayer)
				{
					if (this.ai[1] < 1f)
					{
						int num10 = Projectile.NewProjectile(this.center().X - (float)(this.direction * 30), this.center().Y - 4f, (float)(-(float)this.direction) * 0.01f, 0f, 384, 40, 4f, this.owner, 16f, 15f);
						Main.projectile[num10].netUpdate = true;
					}
					else
					{
						int num11 = (int)(this.center().Y / 16f);
						int num12 = (int)(this.center().X / 16f);
						int num13 = 100;
						if (num12 < 10)
						{
							num12 = 10;
						}
						if (num12 > Main.maxTilesX - 10)
						{
							num12 = Main.maxTilesX - 10;
						}
						if (num11 < 10)
						{
							num11 = 10;
						}
						if (num11 > Main.maxTilesY - num13 - 10)
						{
							num11 = Main.maxTilesY - num13 - 10;
						}
						for (int m = num11; m < num11 + num13; m++)
						{
							Tile tile = Main.tile[num12, m];
							if (tile.active() && (Main.tileSolid[(int)tile.type] || tile.liquid != 0))
							{
								num11 = m;
								break;
							}
						}
						int num14 = Projectile.NewProjectile((float)(num12 * 16 + 8), (float)(num11 * 16 - 24), 0f, 0f, 386, 80, 4f, Main.myPlayer, 16f, 24f);
						Main.projectile[num14].netUpdate = true;
					}
				}
			}
			if (this.type == 399)
			{
				Main.PlaySound(13, (int)this.position.X, (int)this.position.Y, 1);
				Vector2 value4 = new Vector2(20f, 20f);
				for (int n = 0; n < 5; n++)
				{
					Dust.NewDust(this.center() - value4 / 2f, (int)value4.X, (int)value4.Y, 12, 0f, 0f, 0, Color.Red, 1f);
				}
				for (int num15 = 0; num15 < 10; num15++)
				{
					int num16 = Dust.NewDust(this.center() - value4 / 2f, (int)value4.X, (int)value4.Y, 31, 0f, 0f, 100, default(Color), 1.5f);
					Main.dust[num16].velocity *= 1.4f;
				}
				for (int num17 = 0; num17 < 20; num17++)
				{
					int num18 = Dust.NewDust(this.center() - value4 / 2f, (int)value4.X, (int)value4.Y, 6, 0f, 0f, 100, default(Color), 2.5f);
					Main.dust[num18].noGravity = true;
					Main.dust[num18].velocity *= 5f;
					num18 = Dust.NewDust(this.center() - value4 / 2f, (int)value4.X, (int)value4.Y, 6, 0f, 0f, 100, default(Color), 1.5f);
					Main.dust[num18].velocity *= 3f;
				}
				if (Main.myPlayer == this.owner)
				{
					for (int num19 = 0; num19 < 6; num19++)
					{
						float num20 = -this.velocity.X * (float)Main.rand.Next(20, 50) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
						float num21 = -Math.Abs(this.velocity.Y) * (float)Main.rand.Next(30, 50) * 0.01f + (float)Main.rand.Next(-20, 5) * 0.4f;
						Projectile.NewProjectile(this.center().X + num20, this.center().Y + num21, num20, num21, 400 + Main.rand.Next(3), (int)((double)this.damage * 0.5), 0f, this.owner, 0f, 0f);
					}
				}
			}
			if (this.type == 384 || this.type == 386)
			{
				for (int num22 = 0; num22 < 20; num22++)
				{
					int num23 = Dust.NewDust(this.position, this.width, this.height, 212, (float)(this.direction * 2), 0f, 100, default(Color), 1.4f);
					Dust dust3 = Main.dust[num23];
					dust3.color = Color.CornflowerBlue;
					dust3.color = Color.Lerp(dust3.color, Color.White, 0.3f);
					dust3.noGravity = true;
				}
			}
			if (this.type == 1 || this.type == 81 || this.type == 98)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num24 = 0; num24 < 10; num24++)
				{
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 7, 0f, 0f, 0, default(Color), 1f);
				}
			}
			if (this.type == 336 || this.type == 345)
			{
				for (int num25 = 0; num25 < 6; num25++)
				{
					int num26 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 196, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num26].noGravity = true;
					Main.dust[num26].scale = this.scale;
				}
			}
			if (this.type == 358)
			{
				this.velocity = this.lastVelocity * 0.2f;
				for (int num27 = 0; num27 < 100; num27++)
				{
					int num28 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 211, 0f, 0f, 75, default(Color), 1.2f);
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num28].alpha += 25;
					}
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num28].alpha += 25;
					}
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num28].alpha += 25;
					}
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num28].scale = 0.6f;
					}
					else
					{
						Main.dust[num28].noGravity = true;
					}
					Main.dust[num28].velocity *= 0.3f;
					Main.dust[num28].velocity += this.velocity;
					Main.dust[num28].velocity *= 1f + (float)Main.rand.Next(-100, 101) * 0.01f;
					Dust expr_E2D_cp_0 = Main.dust[num28];
					expr_E2D_cp_0.velocity.X = expr_E2D_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.015f;
					Dust expr_E5B_cp_0 = Main.dust[num28];
					expr_E5B_cp_0.velocity.Y = expr_E5B_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.015f;
					Main.dust[num28].position = this.center();
				}
			}
			if (this.type == 406)
			{
				int num29 = 175;
				Color newColor = new Color(0, 80, 255, 100);
				this.velocity = this.lastVelocity * 0.2f;
				for (int num30 = 0; num30 < 40; num30++)
				{
					int num31 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 4, 0f, 0f, num29, newColor, 1.6f);
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num31].alpha += 25;
					}
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num31].alpha += 25;
					}
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num31].alpha += 25;
					}
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num31].scale = 0.6f;
					}
					else
					{
						Main.dust[num31].noGravity = true;
					}
					Main.dust[num31].velocity *= 0.3f;
					Main.dust[num31].velocity += this.velocity;
					Main.dust[num31].velocity *= 1f + (float)Main.rand.Next(-100, 101) * 0.01f;
					Dust expr_1039_cp_0 = Main.dust[num31];
					expr_1039_cp_0.velocity.X = expr_1039_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.015f;
					Dust expr_1067_cp_0 = Main.dust[num31];
					expr_1067_cp_0.velocity.Y = expr_1067_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.015f;
					Main.dust[num31].position = this.center();
				}
			}
			if (this.type == 344)
			{
				for (int num32 = 0; num32 < 3; num32++)
				{
					int num33 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 197, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num33].noGravity = true;
					Main.dust[num33].scale = this.scale;
				}
			}
			else if (this.type == 343)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
				for (int num34 = 4; num34 < 31; num34++)
				{
					float num35 = this.lastVelocity.X * (30f / (float)num34);
					float num36 = this.lastVelocity.Y * (30f / (float)num34);
					int num37 = Dust.NewDust(new Vector2(this.lastPosition.X - num35, this.lastPosition.Y - num36), 8, 8, 197, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.2f);
					Main.dust[num37].noGravity = true;
					Main.dust[num37].velocity *= 0.5f;
				}
			}
			else if (this.type == 349)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
				for (int num38 = 0; num38 < 3; num38++)
				{
					int num39 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 76, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num39].noGravity = true;
					Main.dust[num39].noLight = true;
					Main.dust[num39].scale = 0.7f;
				}
			}
			if (this.type == 323)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num40 = 0; num40 < 20; num40++)
				{
					int num41 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 7, 0f, 0f, 0, default(Color), 1f);
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num41].noGravity = true;
						Main.dust[num41].scale = 1.3f;
						Main.dust[num41].velocity *= 1.5f;
						Main.dust[num41].velocity -= this.lastVelocity * 0.5f;
						Main.dust[num41].velocity *= 1.5f;
					}
					else
					{
						Main.dust[num41].velocity *= 0.75f;
						Main.dust[num41].velocity -= this.lastVelocity * 0.25f;
						Main.dust[num41].scale = 0.8f;
					}
				}
			}
			if (this.type == 346)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
				for (int num42 = 0; num42 < 10; num42++)
				{
					int num43 = 10;
					if (this.ai[1] == 1f)
					{
						num43 = 4;
					}
					int num44 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num43, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num44].noGravity = true;
				}
			}
			if (this.type == 335)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
				for (int num45 = 0; num45 < 10; num45++)
				{
					int num46 = 90 - (int)this.ai[1];
					int num47 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num46, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num47].noLight = true;
					Main.dust[num47].scale = 0.8f;
				}
			}
			if (this.type == 318)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num48 = 0; num48 < 10; num48++)
				{
					int num49 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 30, 0f, 0f, 0, default(Color), 1f);
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num49].noGravity = true;
					}
				}
			}
			if (this.type == 378)
			{
				for (int num50 = 0; num50 < 10; num50++)
				{
					int num51 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 30, 0f, 0f, 0, default(Color), 1f);
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num51].noGravity = true;
					}
				}
			}
			else if (this.type == 311)
			{
				for (int num52 = 0; num52 < 5; num52++)
				{
					int num53 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 189, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num53].scale = 0.85f;
					Main.dust[num53].noGravity = true;
					Main.dust[num53].velocity += this.velocity * 0.5f;
				}
			}
			else if (this.type == 316)
			{
				for (int num54 = 0; num54 < 5; num54++)
				{
					int num55 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 195, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num55].scale = 0.85f;
					Main.dust[num55].noGravity = true;
					Main.dust[num55].velocity += this.velocity * 0.5f;
				}
			}
			else if (this.type == 184 || this.type == 195)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num56 = 0; num56 < 5; num56++)
				{
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 7, 0f, 0f, 0, default(Color), 1f);
				}
			}
			else if (this.type == 275 || this.type == 276)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num57 = 0; num57 < 5; num57++)
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
				for (int num58 = 0; num58 < 20; num58++)
				{
					int num59 = Dust.NewDust(this.position, this.width, this.height, 26, 0f, 0f, 100, default(Color), 1f);
					Main.dust[num59].noGravity = true;
					Main.dust[num59].velocity *= 1.2f;
					Main.dust[num59].scale = 1.3f;
					Main.dust[num59].velocity -= this.lastVelocity * 0.3f;
					num59 = Dust.NewDust(new Vector2(this.position.X + 4f, this.position.Y + 4f), this.width - 8, this.height - 8, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num59].noGravity = true;
					Main.dust[num59].velocity *= 3f;
				}
			}
			else if (this.type == 265)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 27);
				for (int num60 = 0; num60 < 15; num60++)
				{
					int num61 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 163, 0f, 0f, 100, default(Color), 1.2f);
					Main.dust[num61].noGravity = true;
					Main.dust[num61].velocity *= 1.2f;
					Main.dust[num61].velocity -= this.lastVelocity * 0.3f;
				}
			}
			else if (this.type == 355)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 27);
				for (int num62 = 0; num62 < 15; num62++)
				{
					int num63 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 205, 0f, 0f, 100, default(Color), 1.2f);
					Main.dust[num63].noGravity = true;
					Main.dust[num63].velocity *= 1.2f;
					Main.dust[num63].velocity -= this.lastVelocity * 0.3f;
				}
			}
			else if (this.type == 304)
			{
				for (int num64 = 0; num64 < 3; num64++)
				{
					int num65 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 182, 0f, 0f, 100, default(Color), 0.8f);
					Main.dust[num65].noGravity = true;
					Main.dust[num65].velocity *= 1.2f;
					Main.dust[num65].velocity -= this.lastVelocity * 0.3f;
				}
			}
			else if (this.type == 263)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
				for (int num66 = 0; num66 < 15; num66++)
				{
					int num67 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 92, this.velocity.X, this.velocity.Y, Main.rand.Next(0, 101), default(Color), 1f + (float)Main.rand.Next(40) * 0.01f);
					Main.dust[num67].noGravity = true;
					Main.dust[num67].velocity *= 2f;
				}
			}
			else if (this.type == 261)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num68 = 0; num68 < 5; num68++)
				{
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 148, 0f, 0f, 0, default(Color), 1f);
				}
			}
			else if (this.type == 229)
			{
				for (int num69 = 0; num69 < 25; num69++)
				{
					int num70 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 157, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num70].noGravity = true;
					Main.dust[num70].velocity *= 1.5f;
					Main.dust[num70].scale = 1.5f;
				}
			}
			else if (this.type == 239)
			{
				int num71 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), 2, 2, 154, 0f, 0f, 0, default(Color), 1f);
				Dust expr_21A2_cp_0 = Main.dust[num71];
				expr_21A2_cp_0.position.X = expr_21A2_cp_0.position.X - 2f;
				Main.dust[num71].alpha = 38;
				Main.dust[num71].velocity *= 0.1f;
				Main.dust[num71].velocity += -this.lastVelocity * 0.25f;
				Main.dust[num71].scale = 0.95f;
			}
			else if (this.type == 245)
			{
				int num72 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), 2, 2, 114, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num72].noGravity = true;
				Dust expr_22A0_cp_0 = Main.dust[num72];
				expr_22A0_cp_0.position.X = expr_22A0_cp_0.position.X - 2f;
				Main.dust[num72].alpha = 38;
				Main.dust[num72].velocity *= 0.1f;
				Main.dust[num72].velocity += -this.lastVelocity * 0.25f;
				Main.dust[num72].scale = 0.95f;
			}
			else if (this.type == 264)
			{
				int num73 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), 2, 2, 54, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num73].noGravity = true;
				Dust expr_239E_cp_0 = Main.dust[num73];
				expr_239E_cp_0.position.X = expr_239E_cp_0.position.X - 2f;
				Main.dust[num73].alpha = 38;
				Main.dust[num73].velocity *= 0.1f;
				Main.dust[num73].velocity += -this.lastVelocity * 0.25f;
				Main.dust[num73].scale = 0.95f;
			}
			else if (this.type == 206 || this.type == 225)
			{
				Main.PlaySound(6, (int)this.position.X, (int)this.position.Y, 1);
				for (int num74 = 0; num74 < 5; num74++)
				{
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 40, 0f, 0f, 0, default(Color), 1f);
				}
			}
			else if (this.type == 227)
			{
				Main.PlaySound(6, (int)this.position.X, (int)this.position.Y, 1);
				for (int num75 = 0; num75 < 15; num75++)
				{
					int num76 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 157, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num76].noGravity = true;
					Main.dust[num76].velocity += this.lastVelocity;
					Main.dust[num76].scale = 1.5f;
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
				for (int num77 = 0; num77 < 10; num77++)
				{
					int num78 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 67, this.velocity.X, this.velocity.Y, 100, default(Color), 1f);
					if (num77 < 5)
					{
						Main.dust[num78].noGravity = true;
					}
					Main.dust[num78].velocity *= 0.2f;
				}
			}
			else if (this.type == 181 || this.type == 189)
			{
				for (int num79 = 0; num79 < 6; num79++)
				{
					int num80 = Dust.NewDust(this.position, this.width, this.height, 150, this.velocity.X, this.velocity.Y, 50, default(Color), 1f);
					Main.dust[num80].noGravity = true;
					Main.dust[num80].scale = 1f;
				}
			}
			else if (this.type == 178)
			{
				for (int num81 = 0; num81 < 85; num81++)
				{
					int num82 = Main.rand.Next(139, 143);
					int num83 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num82, this.velocity.X, this.velocity.Y, 0, default(Color), 1.2f);
					Dust expr_287B_cp_0 = Main.dust[num83];
					expr_287B_cp_0.velocity.X = expr_287B_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					Dust expr_28A9_cp_0 = Main.dust[num83];
					expr_28A9_cp_0.velocity.Y = expr_28A9_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					Dust expr_28D7_cp_0 = Main.dust[num83];
					expr_28D7_cp_0.velocity.X = expr_28D7_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Dust expr_290B_cp_0 = Main.dust[num83];
					expr_290B_cp_0.velocity.Y = expr_290B_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Dust expr_293F_cp_0 = Main.dust[num83];
					expr_293F_cp_0.velocity.X = expr_293F_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
					Dust expr_296D_cp_0 = Main.dust[num83];
					expr_296D_cp_0.velocity.Y = expr_296D_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
					Main.dust[num83].scale *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
				}
				for (int num84 = 0; num84 < 40; num84++)
				{
					int num85 = Main.rand.Next(276, 283);
					int num86 = Gore.NewGore(this.position, this.velocity, num85, 1f);
					Gore expr_2A11_cp_0 = Main.gore[num86];
					expr_2A11_cp_0.velocity.X = expr_2A11_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					Gore expr_2A3F_cp_0 = Main.gore[num86];
					expr_2A3F_cp_0.velocity.Y = expr_2A3F_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					Gore expr_2A6D_cp_0 = Main.gore[num86];
					expr_2A6D_cp_0.velocity.X = expr_2A6D_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Gore expr_2AA1_cp_0 = Main.gore[num86];
					expr_2AA1_cp_0.velocity.Y = expr_2AA1_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Main.gore[num86].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
					Gore expr_2B04_cp_0 = Main.gore[num86];
					expr_2B04_cp_0.velocity.X = expr_2B04_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
					Gore expr_2B32_cp_0 = Main.gore[num86];
					expr_2B32_cp_0.velocity.Y = expr_2B32_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
				}
			}
			else if (this.type == 289)
			{
				for (int num87 = 0; num87 < 30; num87++)
				{
					int num88 = Main.rand.Next(139, 143);
					int num89 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num88, this.velocity.X, this.velocity.Y, 0, default(Color), 1.2f);
					Dust expr_2BFC_cp_0 = Main.dust[num89];
					expr_2BFC_cp_0.velocity.X = expr_2BFC_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					Dust expr_2C2A_cp_0 = Main.dust[num89];
					expr_2C2A_cp_0.velocity.Y = expr_2C2A_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					Dust expr_2C58_cp_0 = Main.dust[num89];
					expr_2C58_cp_0.velocity.X = expr_2C58_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Dust expr_2C8C_cp_0 = Main.dust[num89];
					expr_2C8C_cp_0.velocity.Y = expr_2C8C_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Dust expr_2CC0_cp_0 = Main.dust[num89];
					expr_2CC0_cp_0.velocity.X = expr_2CC0_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
					Dust expr_2CEE_cp_0 = Main.dust[num89];
					expr_2CEE_cp_0.velocity.Y = expr_2CEE_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
					Main.dust[num89].scale *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
				}
				for (int num90 = 0; num90 < 15; num90++)
				{
					int num91 = Main.rand.Next(276, 283);
					int num92 = Gore.NewGore(this.position, this.velocity, num91, 1f);
					Gore expr_2D92_cp_0 = Main.gore[num92];
					expr_2D92_cp_0.velocity.X = expr_2D92_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					Gore expr_2DC0_cp_0 = Main.gore[num92];
					expr_2DC0_cp_0.velocity.Y = expr_2DC0_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					Gore expr_2DEE_cp_0 = Main.gore[num92];
					expr_2DEE_cp_0.velocity.X = expr_2DEE_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Gore expr_2E22_cp_0 = Main.gore[num92];
					expr_2E22_cp_0.velocity.Y = expr_2E22_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
					Main.gore[num92].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
					Gore expr_2E85_cp_0 = Main.gore[num92];
					expr_2E85_cp_0.velocity.X = expr_2E85_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
					Gore expr_2EB3_cp_0 = Main.gore[num92];
					expr_2EB3_cp_0.velocity.Y = expr_2EB3_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
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
					Vector2 vector2 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num93 = -this.velocity.X;
					float num94 = -this.velocity.Y;
					float num95 = 1f;
					if (this.ai[0] <= 17f)
					{
						num95 = this.ai[0] / 17f;
					}
					int num96 = (int)(30f * num95);
					float num97 = 1f;
					if (this.ai[0] <= 30f)
					{
						num97 = this.ai[0] / 30f;
					}
					float num98 = 0.4f * num97;
					float num99 = num98;
					num94 += num99;
					for (int num100 = 0; num100 < num96; num100++)
					{
						float num101 = (float)Math.Sqrt((double)(num93 * num93 + num94 * num94));
						float num102 = 5.6f;
						if (Math.Abs(num93) + Math.Abs(num94) < 1f)
						{
							num102 *= Math.Abs(num93) + Math.Abs(num94) / 1f;
						}
						num101 = num102 / num101;
						num93 *= num101;
						num94 *= num101;
						Math.Atan2((double)num94, (double)num93);
						if ((float)num100 > this.ai[1])
						{
							for (int num103 = 0; num103 < 4; num103++)
							{
								int num104 = Dust.NewDust(vector2, this.width, this.height, 129, 0f, 0f, 0, default(Color), 1f);
								Main.dust[num104].noGravity = true;
								Main.dust[num104].velocity *= 0.3f;
							}
						}
						vector2.X += num93;
						vector2.Y += num94;
						num93 = -this.velocity.X;
						num94 = -this.velocity.Y;
						num99 += num98;
						num94 += num99;
					}
				}
			}
			else if (this.type == 117)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num105 = 0; num105 < 10; num105++)
				{
					Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 26, 0f, 0f, 0, default(Color), 1f);
				}
			}
			else if (this.type == 166)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 51);
				for (int num106 = 0; num106 < 10; num106++)
				{
					int num107 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 76, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num107].noGravity = true;
					Main.dust[num107].velocity -= this.lastVelocity * 0.25f;
				}
			}
			else if (this.type == 158)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num108 = 0; num108 < 10; num108++)
				{
					int num109 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 9, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num109].noGravity = true;
					Main.dust[num109].velocity -= this.velocity * 0.5f;
				}
			}
			else if (this.type == 159)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num110 = 0; num110 < 10; num110++)
				{
					int num111 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 11, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num111].noGravity = true;
					Main.dust[num111].velocity -= this.velocity * 0.5f;
				}
			}
			else if (this.type == 160)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num112 = 0; num112 < 10; num112++)
				{
					int num113 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 19, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num113].noGravity = true;
					Main.dust[num113].velocity -= this.velocity * 0.5f;
				}
			}
			else if (this.type == 161)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int num114 = 0; num114 < 10; num114++)
				{
					int num115 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 11, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num115].noGravity = true;
					Main.dust[num115].velocity -= this.velocity * 0.5f;
				}
			}
			else if (this.type >= 191 && this.type <= 194)
			{
				int num116 = Gore.NewGore(new Vector2(this.position.X - (float)(this.width / 2), this.position.Y - (float)(this.height / 2)), new Vector2(0f, 0f), Main.rand.Next(61, 64), this.scale);
				Main.gore[num116].velocity *= 0.1f;
			}
			else if (!Main.projPet[this.type])
			{
				if (this.type == 93)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num117 = 0; num117 < 10; num117++)
					{
						int num118 = Dust.NewDust(this.position, this.width, this.height, 57, 0f, 0f, 100, default(Color), 0.5f);
						Dust expr_3707_cp_0 = Main.dust[num118];
						expr_3707_cp_0.velocity.X = expr_3707_cp_0.velocity.X * 2f;
						Dust expr_3725_cp_0 = Main.dust[num118];
						expr_3725_cp_0.velocity.Y = expr_3725_cp_0.velocity.Y * 2f;
					}
				}
				else if (this.type == 99)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num119 = 0; num119 < 30; num119++)
					{
						int num120 = Dust.NewDust(this.position, this.width, this.height, 1, 0f, 0f, 0, default(Color), 1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num120].scale *= 1.4f;
						}
						this.velocity *= 1.9f;
					}
				}
				else if (this.type == 91 || this.type == 92)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num121 = 0; num121 < 10; num121++)
					{
						Dust.NewDust(this.position, this.width, this.height, 58, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, default(Color), 1.2f);
					}
					for (int num122 = 0; num122 < 3; num122++)
					{
						Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
					}
					if (this.type == 12 && this.damage < 500)
					{
						for (int num123 = 0; num123 < 10; num123++)
						{
							Dust.NewDust(this.position, this.width, this.height, 57, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, default(Color), 1.2f);
						}
						for (int num124 = 0; num124 < 3; num124++)
						{
							Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
						}
					}
					if ((this.type == 91 || (this.type == 92 && this.ai[0] > 0f)) && this.owner == Main.myPlayer)
					{
						float x = this.position.X + (float)Main.rand.Next(-400, 400);
						float y = this.position.Y - (float)Main.rand.Next(600, 900);
						Vector2 vector3 = new Vector2(x, y);
						float num125 = this.position.X + (float)(this.width / 2) - vector3.X;
						float num126 = this.position.Y + (float)(this.height / 2) - vector3.Y;
						int num127 = 22;
						float num128 = (float)Math.Sqrt((double)(num125 * num125 + num126 * num126));
						num128 = (float)num127 / num128;
						num125 *= num128;
						num126 *= num128;
						int num129 = this.damage;
						if (this.type == 91)
						{
							num129 = (int)((float)num129 * 0.5f);
						}
						int num130 = Projectile.NewProjectile(x, y, num125, num126, 92, num129, this.knockBack, this.owner, 0f, 0f);
						if (this.type == 91)
						{
							Main.projectile[num130].ai[1] = this.position.Y;
							Main.projectile[num130].ai[0] = 1f;
						}
						else
						{
							Main.projectile[num130].ai[1] = this.position.Y;
						}
					}
				}
				else if (this.type == 89)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num131 = 0; num131 < 5; num131++)
					{
						int num132 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 68, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num132].noGravity = true;
						Main.dust[num132].velocity *= 1.5f;
						Main.dust[num132].scale *= 0.9f;
					}
					if (this.type == 89 && this.owner == Main.myPlayer)
					{
						for (int num133 = 0; num133 < 3; num133++)
						{
							float num134 = -this.velocity.X * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
							float num135 = -this.velocity.Y * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
							Projectile.NewProjectile(this.position.X + num134, this.position.Y + num135, num134, num135, 90, (int)((double)this.damage * 0.5), 0f, this.owner, 0f, 0f);
						}
					}
				}
				else if (this.type == 177)
				{
					for (int num136 = 0; num136 < 20; num136++)
					{
						int num137 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 137, 0f, 0f, Main.rand.Next(0, 101), default(Color), 1f + (float)Main.rand.Next(-20, 40) * 0.01f);
						Main.dust[num137].velocity -= this.lastVelocity * 0.2f;
						if (Main.rand.Next(3) == 0)
						{
							Main.dust[num137].scale *= 0.8f;
							Main.dust[num137].velocity *= 0.5f;
						}
						else
						{
							Main.dust[num137].noGravity = true;
						}
					}
				}
				else if (this.type == 119 || this.type == 118 || this.type == 128 || this.type == 359)
				{
					int num138 = 10;
					if (this.type == 119 || this.type == 359)
					{
						num138 = 20;
					}
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
					for (int num139 = 0; num139 < num138; num139++)
					{
						int num140 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 92, 0f, 0f, 0, default(Color), 1f);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num140].velocity *= 2f;
							Main.dust[num140].noGravity = true;
							Main.dust[num140].scale *= 1.75f;
						}
						else
						{
							Main.dust[num140].scale *= 0.5f;
						}
					}
				}
				else if (this.type == 309)
				{
					int num141 = 10;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
					for (int num142 = 0; num142 < num141; num142++)
					{
						int num143 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 185, 0f, 0f, 0, default(Color), 1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num143].velocity *= 2f;
							Main.dust[num143].noGravity = true;
							Main.dust[num143].scale *= 1.75f;
						}
					}
				}
				else if (this.type == 308)
				{
					int num144 = 80;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
					for (int num145 = 0; num145 < num144; num145++)
					{
						int num146 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 16f), this.width, this.height - 16, 185, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num146].velocity *= 2f;
						Main.dust[num146].noGravity = true;
						Main.dust[num146].scale *= 1.15f;
					}
				}
				else if (this.aiStyle == 29)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					int num147 = this.type - 121 + 86;
					for (int num148 = 0; num148 < 15; num148++)
					{
						int num149 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num147, this.lastVelocity.X, this.lastVelocity.Y, 50, default(Color), 1.2f);
						Main.dust[num149].noGravity = true;
						Main.dust[num149].scale *= 1.25f;
						Main.dust[num149].velocity *= 0.5f;
					}
				}
				else if (this.type == 337)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
					for (int num150 = 0; num150 < 10; num150++)
					{
						int num151 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 197, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num151].noGravity = true;
					}
				}
				else if (this.type == 379 || this.type == 377)
				{
					for (int num152 = 0; num152 < 5; num152++)
					{
						int num153 = Dust.NewDust(this.position, this.width, this.height, 171, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num153].scale = (float)Main.rand.Next(1, 10) * 0.1f;
						Main.dust[num153].noGravity = true;
						Main.dust[num153].fadeIn = 1.5f;
						Main.dust[num153].velocity *= 0.75f;
					}
				}
				else if (this.type == 80)
				{
					if (this.ai[0] >= 0f)
					{
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
						for (int num154 = 0; num154 < 10; num154++)
						{
							Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0f, 0f, 0, default(Color), 1f);
						}
					}
					int num155 = (int)this.position.X / 16;
					int num156 = (int)this.position.Y / 16;
					if (Main.tile[num155, num156] == null)
					{
						Main.tile[num155, num156] = new Tile();
					}
					if (Main.tile[num155, num156].type == 127 && Main.tile[num155, num156].active())
					{
						WorldGen.KillTile(num155, num156, false, false, false);
					}
				}
				else if (this.type == 76 || this.type == 77 || this.type == 78)
				{
					for (int num157 = 0; num157 < 5; num157++)
					{
						int num158 = Dust.NewDust(this.position, this.width, this.height, 27, 0f, 0f, 80, default(Color), 1.5f);
						Main.dust[num158].noGravity = true;
					}
				}
				else if (this.type == 55)
				{
					for (int num159 = 0; num159 < 5; num159++)
					{
						int num160 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 18, 0f, 0f, 0, default(Color), 1.5f);
						Main.dust[num160].noGravity = true;
					}
				}
				else if (this.type == 51 || this.type == 267)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num161 = 0; num161 < 5; num161++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0, 0f, 0f, 0, default(Color), 0.7f);
					}
				}
				else if (this.type == 2 || this.type == 82)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num162 = 0; num162 < 20; num162++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
					}
				}
				else if (this.type == 172)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num163 = 0; num163 < 20; num163++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 135, 0f, 0f, 100, default(Color), 1f);
					}
				}
				else if (this.type == 103)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num164 = 0; num164 < 20; num164++)
					{
						int num165 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 75, 0f, 0f, 100, default(Color), 1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num165].scale *= 2.5f;
							Main.dust[num165].noGravity = true;
							Main.dust[num165].velocity *= 5f;
						}
					}
				}
				else if (this.type == 278)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num166 = 0; num166 < 20; num166++)
					{
						int num167 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 169, 0f, 0f, 100, default(Color), 1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num167].scale *= 1.5f;
							Main.dust[num167].noGravity = true;
							Main.dust[num167].velocity *= 5f;
						}
					}
				}
				else if (this.type == 3 || this.type == 48 || this.type == 54)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num168 = 0; num168 < 10; num168++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 1, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 0, default(Color), 0.75f);
					}
				}
				else if (this.type == 330)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num169 = 0; num169 < 10; num169++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 0, default(Color), 0.75f);
					}
				}
				else if (this.type == 4)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num170 = 0; num170 < 10; num170++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 150, default(Color), 1.1f);
					}
				}
				else if (this.type == 5)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num171 = 0; num171 < 60; num171++)
					{
						int num172 = Main.rand.Next(3);
						if (num172 == 0)
						{
							num172 = 15;
						}
						else if (num172 == 1)
						{
							num172 = 57;
						}
						else
						{
							num172 = 58;
						}
						Dust.NewDust(this.position, this.width, this.height, num172, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, default(Color), 1.5f);
					}
				}
				else if (this.type == 9 || this.type == 12)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num173 = 0; num173 < 10; num173++)
					{
						Dust.NewDust(this.position, this.width, this.height, 58, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, default(Color), 1.2f);
					}
					for (int num174 = 0; num174 < 3; num174++)
					{
						Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
					}
					if (this.type == 12 && this.damage < 100)
					{
						for (int num175 = 0; num175 < 10; num175++)
						{
							Dust.NewDust(this.position, this.width, this.height, 57, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, default(Color), 1.2f);
						}
						for (int num176 = 0; num176 < 3; num176++)
						{
							Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
						}
					}
				}
				else if (this.type == 281)
				{
					Main.PlaySound(4, (int)this.position.X, (int)this.position.Y, 1);
					int num177 = Gore.NewGore(this.position, new Vector2((float)Main.rand.Next(-20, 21) * 0.2f, (float)Main.rand.Next(-20, 21) * 0.2f), 76, 1f);
					Main.gore[num177].velocity -= this.velocity * 0.5f;
					num177 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2((float)Main.rand.Next(-20, 21) * 0.2f, (float)Main.rand.Next(-20, 21) * 0.2f), 77, 1f);
					Main.gore[num177].velocity -= this.velocity * 0.5f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int num178 = 0; num178 < 20; num178++)
					{
						int num179 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num179].velocity *= 1.4f;
					}
					for (int num180 = 0; num180 < 10; num180++)
					{
						int num181 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num181].noGravity = true;
						Main.dust[num181].velocity *= 5f;
						num181 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num181].velocity *= 3f;
					}
					num177 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num177].velocity *= 0.4f;
					Gore expr_5136_cp_0 = Main.gore[num177];
					expr_5136_cp_0.velocity.X = expr_5136_cp_0.velocity.X + 1f;
					Gore expr_5154_cp_0 = Main.gore[num177];
					expr_5154_cp_0.velocity.Y = expr_5154_cp_0.velocity.Y + 1f;
					num177 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num177].velocity *= 0.4f;
					Gore expr_51D2_cp_0 = Main.gore[num177];
					expr_51D2_cp_0.velocity.X = expr_51D2_cp_0.velocity.X - 1f;
					Gore expr_51F0_cp_0 = Main.gore[num177];
					expr_51F0_cp_0.velocity.Y = expr_51F0_cp_0.velocity.Y + 1f;
					num177 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num177].velocity *= 0.4f;
					Gore expr_526E_cp_0 = Main.gore[num177];
					expr_526E_cp_0.velocity.X = expr_526E_cp_0.velocity.X + 1f;
					Gore expr_528C_cp_0 = Main.gore[num177];
					expr_528C_cp_0.velocity.Y = expr_528C_cp_0.velocity.Y - 1f;
					num177 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num177].velocity *= 0.4f;
					Gore expr_530A_cp_0 = Main.gore[num177];
					expr_530A_cp_0.velocity.X = expr_530A_cp_0.velocity.X - 1f;
					Gore expr_5328_cp_0 = Main.gore[num177];
					expr_5328_cp_0.velocity.Y = expr_5328_cp_0.velocity.Y - 1f;
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
					for (int num182 = 0; num182 < 20; num182++)
					{
						int num183 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num183].velocity *= 1.4f;
					}
					for (int num184 = 0; num184 < 10; num184++)
					{
						int num185 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num185].noGravity = true;
						Main.dust[num185].velocity *= 5f;
						num185 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num185].velocity *= 3f;
					}
					int num186 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num186].velocity *= 0.4f;
					Gore expr_55DB_cp_0 = Main.gore[num186];
					expr_55DB_cp_0.velocity.X = expr_55DB_cp_0.velocity.X + 1f;
					Gore expr_55F9_cp_0 = Main.gore[num186];
					expr_55F9_cp_0.velocity.Y = expr_55F9_cp_0.velocity.Y + 1f;
					num186 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num186].velocity *= 0.4f;
					Gore expr_5677_cp_0 = Main.gore[num186];
					expr_5677_cp_0.velocity.X = expr_5677_cp_0.velocity.X - 1f;
					Gore expr_5695_cp_0 = Main.gore[num186];
					expr_5695_cp_0.velocity.Y = expr_5695_cp_0.velocity.Y + 1f;
					num186 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num186].velocity *= 0.4f;
					Gore expr_5713_cp_0 = Main.gore[num186];
					expr_5713_cp_0.velocity.X = expr_5713_cp_0.velocity.X + 1f;
					Gore expr_5731_cp_0 = Main.gore[num186];
					expr_5731_cp_0.velocity.Y = expr_5731_cp_0.velocity.Y - 1f;
					num186 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num186].velocity *= 0.4f;
					Gore expr_57AF_cp_0 = Main.gore[num186];
					expr_57AF_cp_0.velocity.X = expr_57AF_cp_0.velocity.X - 1f;
					Gore expr_57CD_cp_0 = Main.gore[num186];
					expr_57CD_cp_0.velocity.Y = expr_57CD_cp_0.velocity.Y - 1f;
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
					for (int num187 = 0; num187 < 20; num187++)
					{
						int num188 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num188].velocity *= 1.4f;
					}
					for (int num189 = 0; num189 < 10; num189++)
					{
						int num190 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num190].noGravity = true;
						Main.dust[num190].velocity *= 5f;
						num190 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num190].velocity *= 3f;
					}
					int num191 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num191].velocity *= 0.4f;
					Gore expr_5A80_cp_0 = Main.gore[num191];
					expr_5A80_cp_0.velocity.X = expr_5A80_cp_0.velocity.X + 1f;
					Gore expr_5A9E_cp_0 = Main.gore[num191];
					expr_5A9E_cp_0.velocity.Y = expr_5A9E_cp_0.velocity.Y + 1f;
					num191 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num191].velocity *= 0.4f;
					Gore expr_5B1C_cp_0 = Main.gore[num191];
					expr_5B1C_cp_0.velocity.X = expr_5B1C_cp_0.velocity.X - 1f;
					Gore expr_5B3A_cp_0 = Main.gore[num191];
					expr_5B3A_cp_0.velocity.Y = expr_5B3A_cp_0.velocity.Y + 1f;
					num191 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num191].velocity *= 0.4f;
					Gore expr_5BB8_cp_0 = Main.gore[num191];
					expr_5BB8_cp_0.velocity.X = expr_5BB8_cp_0.velocity.X + 1f;
					Gore expr_5BD6_cp_0 = Main.gore[num191];
					expr_5BD6_cp_0.velocity.Y = expr_5BD6_cp_0.velocity.Y - 1f;
					num191 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num191].velocity *= 0.4f;
					Gore expr_5C54_cp_0 = Main.gore[num191];
					expr_5C54_cp_0.velocity.X = expr_5C54_cp_0.velocity.X - 1f;
					Gore expr_5C72_cp_0 = Main.gore[num191];
					expr_5C72_cp_0.velocity.Y = expr_5C72_cp_0.velocity.Y - 1f;
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
					for (int num192 = 0; num192 < 10; num192++)
					{
						int num193 = Dust.NewDust(this.position, this.width, this.height, 171, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num193].scale = (float)Main.rand.Next(1, 10) * 0.1f;
						Main.dust[num193].noGravity = true;
						Main.dust[num193].fadeIn = 1.5f;
						Main.dust[num193].velocity *= 0.75f;
					}
				}
				else if (this.type == 284)
				{
					for (int num194 = 0; num194 < 10; num194++)
					{
						int num195 = Main.rand.Next(139, 143);
						int num196 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num195, -this.velocity.X * 0.3f, -this.velocity.Y * 0.3f, 0, default(Color), 1.2f);
						Dust expr_5EA1_cp_0 = Main.dust[num196];
						expr_5EA1_cp_0.velocity.X = expr_5EA1_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
						Dust expr_5ECF_cp_0 = Main.dust[num196];
						expr_5ECF_cp_0.velocity.Y = expr_5ECF_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
						Dust expr_5EFD_cp_0 = Main.dust[num196];
						expr_5EFD_cp_0.velocity.X = expr_5EFD_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
						Dust expr_5F31_cp_0 = Main.dust[num196];
						expr_5F31_cp_0.velocity.Y = expr_5F31_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
						Dust expr_5F65_cp_0 = Main.dust[num196];
						expr_5F65_cp_0.velocity.X = expr_5F65_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
						Dust expr_5F93_cp_0 = Main.dust[num196];
						expr_5F93_cp_0.velocity.Y = expr_5F93_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
						Main.dust[num196].scale *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
					}
					for (int num197 = 0; num197 < 5; num197++)
					{
						int num198 = Main.rand.Next(276, 283);
						int num199 = Gore.NewGore(this.position, -this.velocity * 0.3f, num198, 1f);
						Gore expr_6046_cp_0 = Main.gore[num199];
						expr_6046_cp_0.velocity.X = expr_6046_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
						Gore expr_6074_cp_0 = Main.gore[num199];
						expr_6074_cp_0.velocity.Y = expr_6074_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
						Gore expr_60A2_cp_0 = Main.gore[num199];
						expr_60A2_cp_0.velocity.X = expr_60A2_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
						Gore expr_60D6_cp_0 = Main.gore[num199];
						expr_60D6_cp_0.velocity.Y = expr_60D6_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
						Main.gore[num199].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
						Gore expr_6139_cp_0 = Main.gore[num199];
						expr_6139_cp_0.velocity.X = expr_6139_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
						Gore expr_6167_cp_0 = Main.gore[num199];
						expr_6167_cp_0.velocity.Y = expr_6167_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
					}
				}
				else if (this.type == 286)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int num200 = 0; num200 < 7; num200++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
					}
					for (int num201 = 0; num201 < 3; num201++)
					{
						int num202 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num202].noGravity = true;
						Main.dust[num202].velocity *= 3f;
						num202 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num202].velocity *= 2f;
					}
					int num203 = Gore.NewGore(new Vector2(this.position.X - 10f, this.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num203].velocity *= 0.3f;
					Gore expr_639C_cp_0 = Main.gore[num203];
					expr_639C_cp_0.velocity.X = expr_639C_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.05f;
					Gore expr_63CA_cp_0 = Main.gore[num203];
					expr_63CA_cp_0.velocity.Y = expr_63CA_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.05f;
					if (this.owner == Main.myPlayer)
					{
						this.localAI[1] = -1f;
						this.maxPenetrate = 0;
						this.position.X = this.position.X + (float)(this.width / 2);
						this.position.Y = this.position.Y + (float)(this.height / 2);
						this.width = 80;
						this.height = 80;
						this.position.X = this.position.X - (float)(this.width / 2);
						this.position.Y = this.position.Y - (float)(this.height / 2);
						this.Damage();
					}
				}
				else if (this.type == 14 || this.type == 20 || this.type == 36 || this.type == 83 || this.type == 84 || this.type == 389 || this.type == 104 || this.type == 279 || this.type == 100 || this.type == 110 || this.type == 180 || this.type == 207 || this.type == 357 || this.type == 242 || this.type == 302 || this.type == 257 || this.type == 259 || this.type == 285 || this.type == 287)
				{
					Collision.HitTiles(this.position, this.velocity, this.width, this.height);
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
				}
				else if (this.type == 15 || this.type == 34 || this.type == 321)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num204 = 0; num204 < 20; num204++)
					{
						int num205 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num205].noGravity = true;
						Main.dust[num205].velocity *= 2f;
						num205 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, default(Color), 1f);
						Main.dust[num205].velocity *= 2f;
					}
				}
				else if (this.type == 253)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num206 = 0; num206 < 20; num206++)
					{
						int num207 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 135, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num207].noGravity = true;
						Main.dust[num207].velocity *= 2f;
						num207 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 135, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, default(Color), 1f);
						Main.dust[num207].velocity *= 2f;
					}
				}
				else if (this.type == 95 || this.type == 96)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num208 = 0; num208 < 20; num208++)
					{
						int num209 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 75, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, default(Color), 2f * this.scale);
						Main.dust[num209].noGravity = true;
						Main.dust[num209].velocity *= 2f;
						num209 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 75, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, default(Color), 1f * this.scale);
						Main.dust[num209].velocity *= 2f;
					}
				}
				else if (this.type == 79)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num210 = 0; num210 < 20; num210++)
					{
						int num211 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 66, 0f, 0f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 2f);
						Main.dust[num211].noGravity = true;
						Main.dust[num211].velocity *= 4f;
					}
				}
				else if (this.type == 16)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num212 = 0; num212 < 20; num212++)
					{
						int num213 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 15, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num213].noGravity = true;
						Main.dust[num213].velocity *= 2f;
						num213 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 15, 0f, 0f, 100, default(Color), 1f);
					}
				}
				else if (this.type == 17)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num214 = 0; num214 < 5; num214++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0, 0f, 0f, 0, default(Color), 1f);
					}
				}
				else if (this.type == 31 || this.type == 42)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num215 = 0; num215 < 5; num215++)
					{
						int num216 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 32, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num216].velocity *= 0.6f;
					}
				}
				else if (this.type >= 411 && this.type <= 414)
				{
					int num217 = 9;
					if (this.type == 412 || this.type == 414)
					{
						num217 = 11;
					}
					if (this.type == 413)
					{
						num217 = 19;
					}
					for (int num218 = 0; num218 < 5; num218++)
					{
						int num219 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num217, 0f, this.velocity.Y / 2f, 0, default(Color), 1f);
						Main.dust[num219].noGravity = true;
						Main.dust[num219].velocity -= this.velocity * 0.5f;
					}
				}
				else if (this.type == 109)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num220 = 0; num220 < 5; num220++)
					{
						int num221 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 51, 0f, 0f, 0, default(Color), 0.6f);
						Main.dust[num221].velocity *= 0.6f;
					}
				}
				else if (this.type == 39)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num222 = 0; num222 < 5; num222++)
					{
						int num223 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 38, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num223].velocity *= 0.6f;
					}
				}
				else if (this.type == 71)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num224 = 0; num224 < 5; num224++)
					{
						int num225 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 53, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num225].velocity *= 0.6f;
					}
				}
				else if (this.type == 40)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num226 = 0; num226 < 5; num226++)
					{
						int num227 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 36, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num227].velocity *= 0.6f;
					}
				}
				else if (this.type == 21)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int num228 = 0; num228 < 10; num228++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 26, 0f, 0f, 0, default(Color), 0.8f);
					}
				}
				else if (this.type == 24)
				{
					for (int num229 = 0; num229 < 10; num229++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 1, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 0, default(Color), 0.75f);
					}
				}
				else if (this.type == 27)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num230 = 0; num230 < 30; num230++)
					{
						int num231 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 172, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 100, default(Color), 1f);
						Main.dust[num231].noGravity = true;
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 172, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 100, default(Color), 0.5f);
					}
				}
				else if (this.type == 38)
				{
					for (int num232 = 0; num232 < 10; num232++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 42, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 0, default(Color), 1f);
					}
				}
				else if (this.type == 44 || this.type == 45)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num233 = 0; num233 < 30; num233++)
					{
						int num234 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 27, this.velocity.X, this.velocity.Y, 100, default(Color), 1.7f);
						Main.dust[num234].noGravity = true;
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 27, this.velocity.X, this.velocity.Y, 100, default(Color), 1f);
					}
				}
				else if (this.type == 41)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int num235 = 0; num235 < 10; num235++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
					}
					for (int num236 = 0; num236 < 5; num236++)
					{
						int num237 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num237].noGravity = true;
						Main.dust[num237].velocity *= 3f;
						num237 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num237].velocity *= 2f;
					}
					int num238 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num238].velocity *= 0.4f;
					Gore expr_772C_cp_0 = Main.gore[num238];
					expr_772C_cp_0.velocity.X = expr_772C_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.1f;
					Gore expr_775C_cp_0 = Main.gore[num238];
					expr_775C_cp_0.velocity.Y = expr_775C_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.1f;
					num238 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num238].velocity *= 0.4f;
					Gore expr_77F0_cp_0 = Main.gore[num238];
					expr_77F0_cp_0.velocity.X = expr_77F0_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.1f;
					Gore expr_7820_cp_0 = Main.gore[num238];
					expr_7820_cp_0.velocity.Y = expr_7820_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.1f;
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
					for (int num239 = 0; num239 < 20; num239++)
					{
						int num240 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 184, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num240].scale *= 1.1f;
						Main.dust[num240].noGravity = true;
					}
					for (int num241 = 0; num241 < 30; num241++)
					{
						int num242 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 184, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num242].velocity *= 2.5f;
						Main.dust[num242].scale *= 0.8f;
						Main.dust[num242].noGravity = true;
					}
					if (this.owner == Main.myPlayer)
					{
						int num243 = 2;
						if (Main.rand.Next(10) == 0)
						{
							num243++;
						}
						if (Main.rand.Next(10) == 0)
						{
							num243++;
						}
						if (Main.rand.Next(10) == 0)
						{
							num243++;
						}
						for (int num244 = 0; num244 < num243; num244++)
						{
							float num245 = (float)Main.rand.Next(-35, 36) * 0.02f;
							float num246 = (float)Main.rand.Next(-35, 36) * 0.02f;
							num245 *= 10f;
							num246 *= 10f;
							Projectile.NewProjectile(this.position.X, this.position.Y, num245, num246, 307, (int)((double)this.damage * 0.7), (float)((int)((double)this.knockBack * 0.35)), Main.myPlayer, 0f, 0f);
						}
					}
				}
				else if (this.type == 183)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int num247 = 0; num247 < 20; num247++)
					{
						int num248 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num248].velocity *= 1f;
					}
					int num249 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Gore expr_7CA5_cp_0 = Main.gore[num249];
					expr_7CA5_cp_0.velocity.X = expr_7CA5_cp_0.velocity.X + 1f;
					Gore expr_7CC5_cp_0 = Main.gore[num249];
					expr_7CC5_cp_0.velocity.Y = expr_7CC5_cp_0.velocity.Y + 1f;
					Main.gore[num249].velocity *= 0.3f;
					num249 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Gore expr_7D49_cp_0 = Main.gore[num249];
					expr_7D49_cp_0.velocity.X = expr_7D49_cp_0.velocity.X - 1f;
					Gore expr_7D69_cp_0 = Main.gore[num249];
					expr_7D69_cp_0.velocity.Y = expr_7D69_cp_0.velocity.Y + 1f;
					Main.gore[num249].velocity *= 0.3f;
					num249 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Gore expr_7DED_cp_0 = Main.gore[num249];
					expr_7DED_cp_0.velocity.X = expr_7DED_cp_0.velocity.X + 1f;
					Gore expr_7E0D_cp_0 = Main.gore[num249];
					expr_7E0D_cp_0.velocity.Y = expr_7E0D_cp_0.velocity.Y - 1f;
					Main.gore[num249].velocity *= 0.3f;
					num249 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Gore expr_7E91_cp_0 = Main.gore[num249];
					expr_7E91_cp_0.velocity.X = expr_7E91_cp_0.velocity.X - 1f;
					Gore expr_7EB1_cp_0 = Main.gore[num249];
					expr_7EB1_cp_0.velocity.Y = expr_7EB1_cp_0.velocity.Y - 1f;
					Main.gore[num249].velocity *= 0.3f;
					if (this.owner == Main.myPlayer)
					{
						int num250 = Main.rand.Next(15, 25);
						for (int num251 = 0; num251 < num250; num251++)
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
						for (int num252 = 0; num252 < 400; num252++)
						{
							float num253 = 16f;
							if (num252 < 300)
							{
								num253 = 12f;
							}
							if (num252 < 200)
							{
								num253 = 8f;
							}
							if (num252 < 100)
							{
								num253 = 4f;
							}
							int num254 = 130;
							int num255 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, num254, 0f, 0f, 100, default(Color), 1f);
							float num256 = Main.dust[num255].velocity.X;
							float num257 = Main.dust[num255].velocity.Y;
							if (num256 == 0f && num257 == 0f)
							{
								num256 = 1f;
							}
							float num258 = (float)Math.Sqrt((double)(num256 * num256 + num257 * num257));
							num258 = num253 / num258;
							num256 *= num258;
							num257 *= num258;
							Main.dust[num255].velocity *= 0.5f;
							Dust expr_814D_cp_0 = Main.dust[num255];
							expr_814D_cp_0.velocity.X = expr_814D_cp_0.velocity.X + num256;
							Dust expr_816C_cp_0 = Main.dust[num255];
							expr_816C_cp_0.velocity.Y = expr_816C_cp_0.velocity.Y + num257;
							Main.dust[num255].scale = 1.3f;
							Main.dust[num255].noGravity = true;
						}
					}
					if (this.type == 168)
					{
						for (int num259 = 0; num259 < 400; num259++)
						{
							float num260 = 2f * ((float)num259 / 100f);
							if (num259 > 100)
							{
								num260 = 10f;
							}
							if (num259 > 250)
							{
								num260 = 13f;
							}
							int num261 = 131;
							int num262 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, num261, 0f, 0f, 100, default(Color), 1f);
							float num263 = Main.dust[num262].velocity.X;
							float num264 = Main.dust[num262].velocity.Y;
							if (num263 == 0f && num264 == 0f)
							{
								num263 = 1f;
							}
							float num265 = (float)Math.Sqrt((double)(num263 * num263 + num264 * num264));
							num265 = num260 / num265;
							if (num259 <= 200)
							{
								num263 *= num265;
								num264 *= num265;
							}
							else
							{
								num263 = num263 * num265 * 1.25f;
								num264 = num264 * num265 * 0.75f;
							}
							Main.dust[num262].velocity *= 0.5f;
							Dust expr_8353_cp_0 = Main.dust[num262];
							expr_8353_cp_0.velocity.X = expr_8353_cp_0.velocity.X + num263;
							Dust expr_8372_cp_0 = Main.dust[num262];
							expr_8372_cp_0.velocity.Y = expr_8372_cp_0.velocity.Y + num264;
							if (num259 > 100)
							{
								Main.dust[num262].scale = 1.3f;
								Main.dust[num262].noGravity = true;
							}
						}
					}
					if (this.type == 169)
					{
						Vector2 vector4 = ((float)Main.rand.NextDouble() * 6.28318548f).ToRotationVector2();
						float num266 = (float)Main.rand.Next(5, 9);
						float num267 = (float)Main.rand.Next(12, 17);
						float value5 = (float)Main.rand.Next(3, 7);
						float num268 = 20f;
						for (float num269 = 0f; num269 < num266; num269 += 1f)
						{
							for (int num270 = 0; num270 < 2; num270++)
							{
								Vector2 value6 = vector4.Rotate((double)(((num270 == 0) ? 1f : -1f) * 6.28318548f / (num266 * 2f)), default(Vector2));
								for (float num271 = 0f; num271 < num268; num271 += 1f)
								{
									Vector2 value7 = Vector2.Lerp(vector4, value6, num271 / num268);
									float scaleFactor = MathHelper.Lerp(num267, value5, num271 / num268);
									int num272 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, 133, 0f, 0f, 100, default(Color), 1.3f);
									Main.dust[num272].velocity *= 0.1f;
									Main.dust[num272].noGravity = true;
									Main.dust[num272].velocity += value7 * scaleFactor;
								}
							}
							vector4 = vector4.Rotate((double)(6.28318548f / num266), default(Vector2));
						}
						for (float num273 = 0f; num273 < num266; num273 += 1f)
						{
							for (int num274 = 0; num274 < 2; num274++)
							{
								Vector2 value8 = vector4.Rotate((double)(((num274 == 0) ? 1f : -1f) * 6.28318548f / (num266 * 2f)), default(Vector2));
								for (float num275 = 0f; num275 < num268; num275 += 1f)
								{
									Vector2 value9 = Vector2.Lerp(vector4, value8, num275 / num268);
									float scaleFactor2 = MathHelper.Lerp(num267, value5, num275 / num268) / 2f;
									int num276 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, 133, 0f, 0f, 100, default(Color), 1.3f);
									Main.dust[num276].velocity *= 0.1f;
									Main.dust[num276].noGravity = true;
									Main.dust[num276].velocity += value9 * scaleFactor2;
								}
							}
							vector4 = vector4.Rotate((double)(6.28318548f / num266), default(Vector2));
						}
						for (int num277 = 0; num277 < 100; num277++)
						{
							float num278 = num267;
							int num279 = 132;
							int num280 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, num279, 0f, 0f, 100, default(Color), 1f);
							float num281 = Main.dust[num280].velocity.X;
							float num282 = Main.dust[num280].velocity.Y;
							if (num281 == 0f && num282 == 0f)
							{
								num281 = 1f;
							}
							float num283 = (float)Math.Sqrt((double)(num281 * num281 + num282 * num282));
							num283 = num278 / num283;
							num281 *= num283;
							num282 *= num283;
							Main.dust[num280].velocity *= 0.5f;
							Dust expr_88AD_cp_0 = Main.dust[num280];
							expr_88AD_cp_0.velocity.X = expr_88AD_cp_0.velocity.X + num281;
							Dust expr_88CC_cp_0 = Main.dust[num280];
							expr_88CC_cp_0.velocity.Y = expr_88CC_cp_0.velocity.Y + num282;
							Main.dust[num280].scale = 1.3f;
							Main.dust[num280].noGravity = true;
						}
					}
					if (this.type == 170)
					{
						for (int num284 = 0; num284 < 400; num284++)
						{
							int num285 = 133;
							float num286 = 16f;
							if (num284 > 100)
							{
								num286 = 11f;
							}
							if (num284 > 100)
							{
								num285 = 134;
							}
							if (num284 > 200)
							{
								num286 = 8f;
							}
							if (num284 > 200)
							{
								num285 = 133;
							}
							if (num284 > 300)
							{
								num286 = 5f;
							}
							if (num284 > 300)
							{
								num285 = 134;
							}
							int num287 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, num285, 0f, 0f, 100, default(Color), 1f);
							float num288 = Main.dust[num287].velocity.X;
							float num289 = Main.dust[num287].velocity.Y;
							if (num288 == 0f && num289 == 0f)
							{
								num288 = 1f;
							}
							float num290 = (float)Math.Sqrt((double)(num288 * num288 + num289 * num289));
							num290 = num286 / num290;
							if (num284 > 300)
							{
								num288 = num288 * num290 * 0.7f;
								num289 *= num290;
							}
							else if (num284 > 200)
							{
								num288 *= num290;
								num289 = num289 * num290 * 0.7f;
							}
							else if (num284 > 100)
							{
								num288 = num288 * num290 * 0.7f;
								num289 *= num290;
							}
							else
							{
								num288 *= num290;
								num289 = num289 * num290 * 0.7f;
							}
							Main.dust[num287].velocity *= 0.5f;
							Dust expr_8B48_cp_0 = Main.dust[num287];
							expr_8B48_cp_0.velocity.X = expr_8B48_cp_0.velocity.X + num288;
							Dust expr_8B67_cp_0 = Main.dust[num287];
							expr_8B67_cp_0.velocity.Y = expr_8B67_cp_0.velocity.Y + num289;
							if (Main.rand.Next(3) != 0)
							{
								Main.dust[num287].scale = 1.3f;
								Main.dust[num287].noGravity = true;
							}
						}
					}
					if (this.type == 415)
					{
						Vector2 vector5 = ((float)Main.rand.NextDouble() * 6.28318548f).ToRotationVector2();
						float num291 = (float)Main.rand.Next(5, 9);
						float num292 = (float)Main.rand.Next(10, 15) * 0.66f;
						float num293 = (float)Main.rand.Next(4, 7) / 2f;
						int num294 = 30;
						int num295 = 0;
						while ((float)num295 < (float)num294 * num291)
						{
							if (num295 % num294 == 0)
							{
								vector5 = vector5.Rotate((double)(6.28318548f / num291), default(Vector2));
							}
							float scaleFactor3 = MathHelper.Lerp(num293, num292, (float)(num295 % num294) / (float)num294);
							int num296 = 130;
							int num297 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, num296, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num297].velocity *= 0.1f;
							Main.dust[num297].velocity += vector5 * scaleFactor3;
							Main.dust[num297].scale = 1.3f;
							Main.dust[num297].noGravity = true;
							num295++;
						}
						for (int num298 = 0; num298 < 100; num298++)
						{
							float num299 = num292;
							if (num298 < 30)
							{
								num299 = (num293 + num292) / 2f;
							}
							int num300 = 130;
							int num301 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, num300, 0f, 0f, 100, default(Color), 1f);
							float num302 = Main.dust[num301].velocity.X;
							float num303 = Main.dust[num301].velocity.Y;
							if (num302 == 0f && num303 == 0f)
							{
								num302 = 1f;
							}
							float num304 = (float)Math.Sqrt((double)(num302 * num302 + num303 * num303));
							num304 = num299 / num304;
							num302 *= num304;
							num303 *= num304;
							Main.dust[num301].velocity *= 0.5f;
							Dust expr_8EAE_cp_0 = Main.dust[num301];
							expr_8EAE_cp_0.velocity.X = expr_8EAE_cp_0.velocity.X + num302;
							Dust expr_8ECD_cp_0 = Main.dust[num301];
							expr_8ECD_cp_0.velocity.Y = expr_8ECD_cp_0.velocity.Y + num303;
							Main.dust[num301].scale = 1.3f;
							Main.dust[num301].noGravity = true;
						}
					}
					if (this.type == 416)
					{
						Vector2 vector6 = ((float)Main.rand.NextDouble() * 6.28318548f).ToRotationVector2();
						Vector2 vector7 = vector6;
						float num305 = (float)(Main.rand.Next(3, 6) * 2);
						int num306 = 20;
						float num307 = (Main.rand.Next(2) == 0) ? 1f : -1f;
						bool flag = true;
						int num308 = 0;
						while ((float)num308 < (float)num306 * num305)
						{
							if (num308 % num306 == 0)
							{
								vector7 = vector7.Rotate((double)(num307 * (6.28318548f / num305)), default(Vector2));
								vector6 = vector7;
								flag = !flag;
							}
							else
							{
								float num309 = 6.28318548f / ((float)num306 * num305);
								vector6 = vector6.Rotate((double)(num309 * num307 * 3f), default(Vector2));
							}
							float scaleFactor4 = MathHelper.Lerp(1f, 8f, (float)(num308 % num306) / (float)num306);
							int num310 = 131;
							int num311 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, num310, 0f, 0f, 100, default(Color), 1.4f);
							Main.dust[num311].velocity *= 0.1f;
							Main.dust[num311].velocity += vector6 * scaleFactor4;
							if (flag)
							{
								Main.dust[num311].scale = 0.9f;
							}
							Main.dust[num311].noGravity = true;
							num308++;
						}
					}
					if (this.type == 417)
					{
						float num312 = (float)Main.rand.NextDouble() * 6.28318548f;
						float num313 = (float)Main.rand.NextDouble() * 6.28318548f;
						float num314 = 4f + (float)Main.rand.NextDouble() * 3f;
						float num315 = 4f + (float)Main.rand.NextDouble() * 3f;
						float num316 = num314;
						if (num315 > num316)
						{
							num316 = num315;
						}
						for (int num317 = 0; num317 < 150; num317++)
						{
							int num318 = 132;
							float scaleFactor5 = num316;
							if (num317 > 50)
							{
								scaleFactor5 = num315;
							}
							if (num317 > 50)
							{
								num318 = 133;
							}
							if (num317 > 100)
							{
								scaleFactor5 = num314;
							}
							if (num317 > 100)
							{
								num318 = 132;
							}
							int num319 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, num318, 0f, 0f, 100, default(Color), 1f);
							Vector2 vector8 = Main.dust[num319].velocity;
							vector8.Normalize();
							vector8 *= scaleFactor5;
							if (num317 > 100)
							{
								vector8.X *= 0.5f;
								vector8 = vector8.Rotate((double)num312, default(Vector2));
							}
							else if (num317 > 50)
							{
								vector8.Y *= 0.5f;
								vector8 = vector8.Rotate((double)num313, default(Vector2));
							}
							Main.dust[num319].velocity *= 0.2f;
							Main.dust[num319].velocity += vector8;
							if (num317 <= 200)
							{
								Main.dust[num319].scale = 1.3f;
								Main.dust[num319].noGravity = true;
							}
						}
					}
					if (this.type == 418)
					{
						Vector2 vector9 = ((float)Main.rand.NextDouble() * 6.28318548f).ToRotationVector2();
						float num320 = (float)Main.rand.Next(5, 12);
						float num321 = (float)Main.rand.Next(9, 14) * 0.66f;
						float num322 = (float)Main.rand.Next(2, 4) * 0.66f;
						float num323 = 15f;
						for (float num324 = 0f; num324 < num320; num324 += 1f)
						{
							for (int num325 = 0; num325 < 2; num325++)
							{
								Vector2 value10 = vector9.Rotate((double)(((num325 == 0) ? 1f : -1f) * 6.28318548f / (num320 * 2f)), default(Vector2));
								for (float num326 = 0f; num326 < num323; num326 += 1f)
								{
									Vector2 value11 = Vector2.SmoothStep(vector9, value10, num326 / num323);
									float scaleFactor6 = MathHelper.SmoothStep(num321, num322, num326 / num323);
									int num327 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, 134, 0f, 0f, 100, default(Color), 1.3f);
									Main.dust[num327].velocity *= 0.1f;
									Main.dust[num327].noGravity = true;
									Main.dust[num327].velocity += value11 * scaleFactor6;
								}
							}
							vector9 = vector9.Rotate((double)(6.28318548f / num320), default(Vector2));
						}
						for (int num328 = 0; num328 < 120; num328++)
						{
							float num329 = num321;
							int num330 = 133;
							if (num328 < 80)
							{
								num329 = num322 - 0.5f;
							}
							else
							{
								num330 = 131;
							}
							int num331 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), 6, 6, num330, 0f, 0f, 100, default(Color), 1f);
							float num332 = Main.dust[num331].velocity.X;
							float num333 = Main.dust[num331].velocity.Y;
							if (num332 == 0f && num333 == 0f)
							{
								num332 = 1f;
							}
							float num334 = (float)Math.Sqrt((double)(num332 * num332 + num333 * num333));
							num334 = num329 / num334;
							num332 *= num334;
							num333 *= num334;
							Main.dust[num331].velocity *= 0.2f;
							Dust expr_96DD_cp_0 = Main.dust[num331];
							expr_96DD_cp_0.velocity.X = expr_96DD_cp_0.velocity.X + num332;
							Dust expr_96FC_cp_0 = Main.dust[num331];
							expr_96FC_cp_0.velocity.Y = expr_96FC_cp_0.velocity.Y + num333;
							Main.dust[num331].scale = 1.3f;
							Main.dust[num331].noGravity = true;
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
					for (int num335 = 0; num335 < 30; num335++)
					{
						int num336 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num336].velocity *= 1.4f;
					}
					for (int num337 = 0; num337 < 20; num337++)
					{
						int num338 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 3.5f);
						Main.dust[num338].noGravity = true;
						Main.dust[num338].velocity *= 7f;
						num338 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num338].velocity *= 3f;
					}
					for (int num339 = 0; num339 < 2; num339++)
					{
						float scaleFactor7 = 0.4f;
						if (num339 == 1)
						{
							scaleFactor7 = 0.8f;
						}
						int num340 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num340].velocity *= scaleFactor7;
						Gore expr_9AB3_cp_0 = Main.gore[num340];
						expr_9AB3_cp_0.velocity.X = expr_9AB3_cp_0.velocity.X + 1f;
						Gore expr_9AD3_cp_0 = Main.gore[num340];
						expr_9AD3_cp_0.velocity.Y = expr_9AD3_cp_0.velocity.Y + 1f;
						num340 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num340].velocity *= scaleFactor7;
						Gore expr_9B56_cp_0 = Main.gore[num340];
						expr_9B56_cp_0.velocity.X = expr_9B56_cp_0.velocity.X - 1f;
						Gore expr_9B76_cp_0 = Main.gore[num340];
						expr_9B76_cp_0.velocity.Y = expr_9B76_cp_0.velocity.Y + 1f;
						num340 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num340].velocity *= scaleFactor7;
						Gore expr_9BF9_cp_0 = Main.gore[num340];
						expr_9BF9_cp_0.velocity.X = expr_9BF9_cp_0.velocity.X + 1f;
						Gore expr_9C19_cp_0 = Main.gore[num340];
						expr_9C19_cp_0.velocity.Y = expr_9C19_cp_0.velocity.Y - 1f;
						num340 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num340].velocity *= scaleFactor7;
						Gore expr_9C9C_cp_0 = Main.gore[num340];
						expr_9C9C_cp_0.velocity.X = expr_9C9C_cp_0.velocity.X - 1f;
						Gore expr_9CBC_cp_0 = Main.gore[num340];
						expr_9CBC_cp_0.velocity.Y = expr_9CBC_cp_0.velocity.Y - 1f;
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
					for (int num341 = 0; num341 < 30; num341++)
					{
						int num342 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num342].velocity *= 1.4f;
					}
					for (int num343 = 0; num343 < 20; num343++)
					{
						int num344 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 3.5f);
						Main.dust[num344].noGravity = true;
						Main.dust[num344].velocity *= 7f;
						num344 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num344].velocity *= 3f;
					}
					for (int num345 = 0; num345 < 2; num345++)
					{
						float scaleFactor8 = 0.4f;
						if (num345 == 1)
						{
							scaleFactor8 = 0.8f;
						}
						int num346 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num346].velocity *= scaleFactor8;
						Gore expr_A0B0_cp_0 = Main.gore[num346];
						expr_A0B0_cp_0.velocity.X = expr_A0B0_cp_0.velocity.X + 1f;
						Gore expr_A0D0_cp_0 = Main.gore[num346];
						expr_A0D0_cp_0.velocity.Y = expr_A0D0_cp_0.velocity.Y + 1f;
						num346 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num346].velocity *= scaleFactor8;
						Gore expr_A153_cp_0 = Main.gore[num346];
						expr_A153_cp_0.velocity.X = expr_A153_cp_0.velocity.X - 1f;
						Gore expr_A173_cp_0 = Main.gore[num346];
						expr_A173_cp_0.velocity.Y = expr_A173_cp_0.velocity.Y + 1f;
						num346 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num346].velocity *= scaleFactor8;
						Gore expr_A1F6_cp_0 = Main.gore[num346];
						expr_A1F6_cp_0.velocity.X = expr_A1F6_cp_0.velocity.X + 1f;
						Gore expr_A216_cp_0 = Main.gore[num346];
						expr_A216_cp_0.velocity.Y = expr_A216_cp_0.velocity.Y - 1f;
						num346 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num346].velocity *= scaleFactor8;
						Gore expr_A299_cp_0 = Main.gore[num346];
						expr_A299_cp_0.velocity.X = expr_A299_cp_0.velocity.X - 1f;
						Gore expr_A2B9_cp_0 = Main.gore[num346];
						expr_A2B9_cp_0.velocity.Y = expr_A2B9_cp_0.velocity.Y - 1f;
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
					for (int num347 = 0; num347 < 40; num347++)
					{
						int num348 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num348].velocity *= 3f;
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num348].scale = 0.5f;
							Main.dust[num348].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
						}
					}
					for (int num349 = 0; num349 < 70; num349++)
					{
						int num350 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 3f);
						Main.dust[num350].noGravity = true;
						Main.dust[num350].velocity *= 5f;
						num350 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num350].velocity *= 2f;
					}
					for (int num351 = 0; num351 < 3; num351++)
					{
						float scaleFactor9 = 0.33f;
						if (num351 == 1)
						{
							scaleFactor9 = 0.66f;
						}
						if (num351 == 2)
						{
							scaleFactor9 = 1f;
						}
						int num352 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num352].velocity *= scaleFactor9;
						Gore expr_A694_cp_0 = Main.gore[num352];
						expr_A694_cp_0.velocity.X = expr_A694_cp_0.velocity.X + 1f;
						Gore expr_A6B4_cp_0 = Main.gore[num352];
						expr_A6B4_cp_0.velocity.Y = expr_A6B4_cp_0.velocity.Y + 1f;
						num352 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num352].velocity *= scaleFactor9;
						Gore expr_A757_cp_0 = Main.gore[num352];
						expr_A757_cp_0.velocity.X = expr_A757_cp_0.velocity.X - 1f;
						Gore expr_A777_cp_0 = Main.gore[num352];
						expr_A777_cp_0.velocity.Y = expr_A777_cp_0.velocity.Y + 1f;
						num352 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num352].velocity *= scaleFactor9;
						Gore expr_A81A_cp_0 = Main.gore[num352];
						expr_A81A_cp_0.velocity.X = expr_A81A_cp_0.velocity.X + 1f;
						Gore expr_A83A_cp_0 = Main.gore[num352];
						expr_A83A_cp_0.velocity.Y = expr_A83A_cp_0.velocity.Y - 1f;
						num352 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num352].velocity *= scaleFactor9;
						Gore expr_A8DD_cp_0 = Main.gore[num352];
						expr_A8DD_cp_0.velocity.X = expr_A8DD_cp_0.velocity.X - 1f;
						Gore expr_A8FD_cp_0 = Main.gore[num352];
						expr_A8FD_cp_0.velocity.Y = expr_A8FD_cp_0.velocity.Y - 1f;
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
					for (int num353 = 0; num353 < 10; num353++)
					{
						int num354 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num354].velocity *= 0.9f;
					}
					for (int num355 = 0; num355 < 5; num355++)
					{
						int num356 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num356].noGravity = true;
						Main.dust[num356].velocity *= 3f;
						num356 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num356].velocity *= 2f;
					}
					int num357 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num357].velocity *= 0.3f;
					Gore expr_ABDE_cp_0 = Main.gore[num357];
					expr_ABDE_cp_0.velocity.X = expr_ABDE_cp_0.velocity.X + (float)Main.rand.Next(-1, 2);
					Gore expr_AC06_cp_0 = Main.gore[num357];
					expr_AC06_cp_0.velocity.Y = expr_AC06_cp_0.velocity.Y + (float)Main.rand.Next(-1, 2);
					this.position.X = this.position.X + (float)(this.width / 2);
					this.position.Y = this.position.Y + (float)(this.height / 2);
					this.width = 150;
					this.height = 150;
					this.position.X = this.position.X - (float)(this.width / 2);
					this.position.Y = this.position.Y - (float)(this.height / 2);
					this.penetrate = -1;
					this.maxPenetrate = 0;
					this.Damage();
					if (this.owner == Main.myPlayer)
					{
						int num358 = Main.rand.Next(2, 6);
						for (int num359 = 0; num359 < num358; num359++)
						{
							float num360 = (float)Main.rand.Next(-100, 101);
							num360 += 0.01f;
							float num361 = (float)Main.rand.Next(-100, 101);
							num360 -= 0.01f;
							float num362 = (float)Math.Sqrt((double)(num360 * num360 + num361 * num361));
							num362 = 8f / num362;
							num360 *= num362;
							num361 *= num362;
							int num363 = Projectile.NewProjectile(this.center().X - this.lastVelocity.X, this.center().Y - this.lastVelocity.Y, num360, num361, 249, this.damage, this.knockBack, this.owner, 0f, 0f);
							Main.projectile[num363].maxPenetrate = 0;
						}
					}
				}
				else if (this.type == 249)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					for (int num364 = 0; num364 < 7; num364++)
					{
						int num365 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num365].velocity *= 0.8f;
					}
					for (int num366 = 0; num366 < 2; num366++)
					{
						int num367 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num367].noGravity = true;
						Main.dust[num367].velocity *= 2.5f;
						num367 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num367].velocity *= 1.5f;
					}
					int num368 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num368].velocity *= 0.2f;
					Gore expr_B02D_cp_0 = Main.gore[num368];
					expr_B02D_cp_0.velocity.X = expr_B02D_cp_0.velocity.X + (float)Main.rand.Next(-1, 2);
					Gore expr_B055_cp_0 = Main.gore[num368];
					expr_B055_cp_0.velocity.Y = expr_B055_cp_0.velocity.Y + (float)Main.rand.Next(-1, 2);
					this.position.X = this.position.X + (float)(this.width / 2);
					this.position.Y = this.position.Y + (float)(this.height / 2);
					this.width = 100;
					this.height = 100;
					this.position.X = this.position.X - (float)(this.width / 2);
					this.position.Y = this.position.Y - (float)(this.height / 2);
					this.penetrate = -1;
					this.Damage();
				}
				else if (this.type == 28 || this.type == 30 || this.type == 37 || this.type == 75 || this.type == 102 || this.type == 164 || this.type == 397)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
					this.position.X = this.position.X + (float)(this.width / 2);
					this.position.Y = this.position.Y + (float)(this.height / 2);
					this.width = 22;
					this.height = 22;
					this.position.X = this.position.X - (float)(this.width / 2);
					this.position.Y = this.position.Y - (float)(this.height / 2);
					for (int num369 = 0; num369 < 20; num369++)
					{
						int num370 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num370].velocity *= 1.4f;
					}
					for (int num371 = 0; num371 < 10; num371++)
					{
						int num372 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num372].noGravity = true;
						Main.dust[num372].velocity *= 5f;
						num372 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num372].velocity *= 3f;
					}
					int num373 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num373].velocity *= 0.4f;
					Gore expr_B3F3_cp_0 = Main.gore[num373];
					expr_B3F3_cp_0.velocity.X = expr_B3F3_cp_0.velocity.X + 1f;
					Gore expr_B413_cp_0 = Main.gore[num373];
					expr_B413_cp_0.velocity.Y = expr_B413_cp_0.velocity.Y + 1f;
					num373 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num373].velocity *= 0.4f;
					Gore expr_B497_cp_0 = Main.gore[num373];
					expr_B497_cp_0.velocity.X = expr_B497_cp_0.velocity.X - 1f;
					Gore expr_B4B7_cp_0 = Main.gore[num373];
					expr_B4B7_cp_0.velocity.Y = expr_B4B7_cp_0.velocity.Y + 1f;
					num373 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num373].velocity *= 0.4f;
					Gore expr_B53B_cp_0 = Main.gore[num373];
					expr_B53B_cp_0.velocity.X = expr_B53B_cp_0.velocity.X + 1f;
					Gore expr_B55B_cp_0 = Main.gore[num373];
					expr_B55B_cp_0.velocity.Y = expr_B55B_cp_0.velocity.Y - 1f;
					num373 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num373].velocity *= 0.4f;
					Gore expr_B5DF_cp_0 = Main.gore[num373];
					expr_B5DF_cp_0.velocity.X = expr_B5DF_cp_0.velocity.X - 1f;
					Gore expr_B5FF_cp_0 = Main.gore[num373];
					expr_B5FF_cp_0.velocity.Y = expr_B5FF_cp_0.velocity.Y - 1f;
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
					for (int num374 = 0; num374 < 50; num374++)
					{
						int num375 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num375].velocity *= 1.4f;
					}
					for (int num376 = 0; num376 < 80; num376++)
					{
						int num377 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 3f);
						Main.dust[num377].noGravity = true;
						Main.dust[num377].velocity *= 5f;
						num377 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num377].velocity *= 3f;
					}
					for (int num378 = 0; num378 < 2; num378++)
					{
						int num379 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num379].scale = 1.5f;
						Gore expr_B906_cp_0 = Main.gore[num379];
						expr_B906_cp_0.velocity.X = expr_B906_cp_0.velocity.X + 1.5f;
						Gore expr_B926_cp_0 = Main.gore[num379];
						expr_B926_cp_0.velocity.Y = expr_B926_cp_0.velocity.Y + 1.5f;
						num379 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num379].scale = 1.5f;
						Gore expr_B9BF_cp_0 = Main.gore[num379];
						expr_B9BF_cp_0.velocity.X = expr_B9BF_cp_0.velocity.X - 1.5f;
						Gore expr_B9DF_cp_0 = Main.gore[num379];
						expr_B9DF_cp_0.velocity.Y = expr_B9DF_cp_0.velocity.Y + 1.5f;
						num379 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num379].scale = 1.5f;
						Gore expr_BA78_cp_0 = Main.gore[num379];
						expr_BA78_cp_0.velocity.X = expr_BA78_cp_0.velocity.X + 1.5f;
						Gore expr_BA98_cp_0 = Main.gore[num379];
						expr_BA98_cp_0.velocity.Y = expr_BA98_cp_0.velocity.Y - 1.5f;
						num379 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
						Main.gore[num379].scale = 1.5f;
						Gore expr_BB31_cp_0 = Main.gore[num379];
						expr_BB31_cp_0.velocity.X = expr_BB31_cp_0.velocity.X - 1.5f;
						Gore expr_BB51_cp_0 = Main.gore[num379];
						expr_BB51_cp_0.velocity.Y = expr_BB51_cp_0.velocity.Y - 1.5f;
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
					for (int num380 = 0; num380 < 5; num380++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 13, 0f, 0f, 0, default(Color), 1f);
					}
					for (int num381 = 0; num381 < 30; num381++)
					{
						int num382 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 33, 0f, -2f, 0, default(Color), 1.1f);
						Main.dust[num382].alpha = 100;
						Dust expr_BD03_cp_0 = Main.dust[num382];
						expr_BD03_cp_0.velocity.X = expr_BD03_cp_0.velocity.X * 1.5f;
						Main.dust[num382].velocity *= 3f;
					}
				}
				else if (this.type == 70)
				{
					Main.PlaySound(13, (int)this.position.X, (int)this.position.Y, 1);
					for (int num383 = 0; num383 < 5; num383++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 13, 0f, 0f, 0, default(Color), 1f);
					}
					for (int num384 = 0; num384 < 30; num384++)
					{
						int num385 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 52, 0f, -2f, 0, default(Color), 1.1f);
						Main.dust[num385].alpha = 100;
						Dust expr_BE59_cp_0 = Main.dust[num385];
						expr_BE59_cp_0.velocity.X = expr_BE59_cp_0.velocity.X * 1.5f;
						Main.dust[num385].velocity *= 3f;
					}
				}
				else if (this.type == 114 || this.type == 115)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num386 = 4; num386 < 31; num386++)
					{
						float num387 = this.lastVelocity.X * (30f / (float)num386);
						float num388 = this.lastVelocity.Y * (30f / (float)num386);
						int num389 = Dust.NewDust(new Vector2(this.position.X - num387, this.position.Y - num388), 8, 8, 27, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.4f);
						Main.dust[num389].noGravity = true;
						Main.dust[num389].velocity *= 0.5f;
						num389 = Dust.NewDust(new Vector2(this.position.X - num387, this.position.Y - num388), 8, 8, 27, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 0.9f);
						Main.dust[num389].velocity *= 0.5f;
					}
				}
				else if (this.type == 116)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num390 = 4; num390 < 31; num390++)
					{
						float num391 = this.lastVelocity.X * (30f / (float)num390);
						float num392 = this.lastVelocity.Y * (30f / (float)num390);
						int num393 = Dust.NewDust(new Vector2(this.position.X - num391, this.position.Y - num392), 8, 8, 64, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.8f);
						Main.dust[num393].noGravity = true;
						num393 = Dust.NewDust(new Vector2(this.position.X - num391, this.position.Y - num392), 8, 8, 64, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.4f);
						Main.dust[num393].noGravity = true;
					}
				}
				else if (this.type == 173)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num394 = 4; num394 < 24; num394++)
					{
						float num395 = this.lastVelocity.X * (30f / (float)num394);
						float num396 = this.lastVelocity.Y * (30f / (float)num394);
						int num397 = Main.rand.Next(3);
						if (num397 == 0)
						{
							num397 = 15;
						}
						else if (num397 == 1)
						{
							num397 = 57;
						}
						else
						{
							num397 = 58;
						}
						int num398 = Dust.NewDust(new Vector2(this.position.X - num395, this.position.Y - num396), 8, 8, num397, this.lastVelocity.X * 0.2f, this.lastVelocity.Y * 0.2f, 100, default(Color), 1.8f);
						Main.dust[num398].velocity *= 1.5f;
						Main.dust[num398].noGravity = true;
					}
				}
				else if (this.type == 132)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num399 = 4; num399 < 31; num399++)
					{
						float num400 = this.lastVelocity.X * (30f / (float)num399);
						float num401 = this.lastVelocity.Y * (30f / (float)num399);
						int num402 = Dust.NewDust(new Vector2(this.lastPosition.X - num400, this.lastPosition.Y - num401), 8, 8, 107, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.8f);
						Main.dust[num402].noGravity = true;
						Main.dust[num402].velocity *= 0.5f;
						num402 = Dust.NewDust(new Vector2(this.lastPosition.X - num400, this.lastPosition.Y - num401), 8, 8, 107, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.4f);
						Main.dust[num402].velocity *= 0.05f;
					}
				}
				else if (this.type == 156)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num403 = 4; num403 < 31; num403++)
					{
						float num404 = this.lastVelocity.X * (30f / (float)num403);
						float num405 = this.lastVelocity.Y * (30f / (float)num403);
						int num406 = Dust.NewDust(new Vector2(this.lastPosition.X - num404, this.lastPosition.Y - num405), 8, 8, 73, this.lastVelocity.X, this.lastVelocity.Y, 255, default(Color), 1.8f);
						Main.dust[num406].noGravity = true;
						Main.dust[num406].velocity *= 0.5f;
						num406 = Dust.NewDust(new Vector2(this.lastPosition.X - num404, this.lastPosition.Y - num405), 8, 8, 73, this.lastVelocity.X, this.lastVelocity.Y, 255, default(Color), 1.4f);
						Main.dust[num406].velocity *= 0.05f;
						Main.dust[num406].noGravity = true;
					}
				}
				else if (this.type == 157)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
					for (int num407 = 4; num407 < 31; num407++)
					{
						int num408 = Dust.NewDust(this.position, this.width, this.height, 107, this.lastVelocity.X, this.lastVelocity.Y, 100, default(Color), 1.8f);
						Main.dust[num408].noGravity = true;
						Main.dust[num408].velocity *= 0.5f;
					}
				}
				else if (this.type == 370)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 4);
					for (int num409 = 0; num409 < 5; num409++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 13, 0f, 0f, 0, default(Color), 1f);
					}
					for (int num410 = 0; num410 < 30; num410++)
					{
						Vector2 value12 = new Vector2((float)Main.rand.Next(-10, 11), (float)Main.rand.Next(-10, 11));
						value12.Normalize();
						int num411 = Gore.NewGore(this.center() + value12 * 10f, value12 * (float)Main.rand.Next(4, 9) * 0.66f + Vector2.UnitY * 1.5f, 331, (float)Main.rand.Next(40, 141) * 0.01f);
						Main.gore[num411].sticky = false;
					}
				}
				else if (this.type == 371)
				{
					Main.PlaySound(13, (int)this.position.X, (int)this.position.Y, 1);
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 16);
					for (int num412 = 0; num412 < 5; num412++)
					{
						Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 13, 0f, 0f, 0, default(Color), 1f);
					}
					for (int num413 = 0; num413 < 30; num413++)
					{
						Vector2 value13 = new Vector2((float)Main.rand.Next(-10, 11), (float)Main.rand.Next(-10, 11));
						value13.Normalize();
						value13 *= 0.4f;
						int num414 = Gore.NewGore(this.center() + value13 * 10f, value13 * (float)Main.rand.Next(4, 9) * 0.66f + Vector2.UnitY * 1.5f, Main.rand.Next(435, 438), (float)Main.rand.Next(20, 100) * 0.01f);
						Main.gore[num414].sticky = false;
					}
				}
			}
			if (this.owner == Main.myPlayer)
			{
				if (this.type == 28 || this.type == 29 || this.type == 37 || this.type == 108 || this.type == 136 || this.type == 137 || this.type == 138 || this.type == 142 || this.type == 143 || this.type == 144 || this.type == 339 || this.type == 341)
				{
					int num415 = 3;
					if (this.type == 28 || this.type == 37)
					{
						num415 = 4;
					}
					if (this.type == 29)
					{
						num415 = 7;
					}
					if (this.type == 142 || this.type == 143 || this.type == 144 || this.type == 341)
					{
						num415 = 5;
					}
					if (this.type == 108)
					{
						num415 = 10;
					}
					int num416 = (int)(this.position.X / 16f - (float)num415);
					int num417 = (int)(this.position.X / 16f + (float)num415);
					int num418 = (int)(this.position.Y / 16f - (float)num415);
					int num419 = (int)(this.position.Y / 16f + (float)num415);
					if (num416 < 0)
					{
						num416 = 0;
					}
					if (num417 > Main.maxTilesX)
					{
						num417 = Main.maxTilesX;
					}
					if (num418 < 0)
					{
						num418 = 0;
					}
					if (num419 > Main.maxTilesY)
					{
						num419 = Main.maxTilesY;
					}
					bool flag2 = false;
					for (int num420 = num416; num420 <= num417; num420++)
					{
						for (int num421 = num418; num421 <= num419; num421++)
						{
							float num422 = Math.Abs((float)num420 - this.position.X / 16f);
							float num423 = Math.Abs((float)num421 - this.position.Y / 16f);
							double num424 = Math.Sqrt((double)(num422 * num422 + num423 * num423));
							if (num424 < (double)num415 && Main.tile[num420, num421] != null && Main.tile[num420, num421].wall == 0)
							{
								flag2 = true;
								break;
							}
						}
					}
					for (int num425 = num416; num425 <= num417; num425++)
					{
						for (int num426 = num418; num426 <= num419; num426++)
						{
							float num427 = Math.Abs((float)num425 - this.position.X / 16f);
							float num428 = Math.Abs((float)num426 - this.position.Y / 16f);
							double num429 = Math.Sqrt((double)(num427 * num427 + num428 * num428));
							if (num429 < (double)num415)
							{
								bool flag3 = true;
								if (Main.tile[num425, num426] != null && Main.tile[num425, num426].active())
								{
									flag3 = true;
									if (Main.tileDungeon[(int)Main.tile[num425, num426].type] || Main.tile[num425, num426].type == 21 || Main.tile[num425, num426].type == 26 || Main.tile[num425, num426].type == 107 || Main.tile[num425, num426].type == 108 || Main.tile[num425, num426].type == 111 || Main.tile[num425, num426].type == 226 || Main.tile[num425, num426].type == 237 || Main.tile[num425, num426].type == 221 || Main.tile[num425, num426].type == 222 || Main.tile[num425, num426].type == 223 || Main.tile[num425, num426].type == 211)
									{
										flag3 = false;
									}
									if (!Main.hardMode && Main.tile[num425, num426].type == 58)
									{
										flag3 = false;
									}
									if (flag3)
									{
										WorldGen.KillTile(num425, num426, false, false, false);
										if (!Main.tile[num425, num426].active() && Main.netMode != 0)
										{
											NetMessage.SendData(17, -1, -1, "", 0, (float)num425, (float)num426, 0f, 0);
										}
									}
								}
								if (flag3)
								{
									for (int num430 = num425 - 1; num430 <= num425 + 1; num430++)
									{
										for (int num431 = num426 - 1; num431 <= num426 + 1; num431++)
										{
											if (Main.tile[num430, num431] != null && Main.tile[num430, num431].wall > 0 && flag2)
											{
												WorldGen.KillWall(num430, num431, false);
												if (Main.tile[num430, num431].wall == 0 && Main.netMode != 0)
												{
													NetMessage.SendData(17, -1, -1, "", 2, (float)num430, (float)num431, 0f, 0);
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
					int num432 = -1;
					if (this.aiStyle == 10)
					{
						int num433 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num434 = (int)(this.position.Y + (float)(this.width / 2)) / 16;
						int num435 = 0;
						int num436 = 2;
						if (this.type == 109)
						{
							num435 = 147;
							num436 = 0;
						}
						if (this.type == 31)
						{
							num435 = 53;
							num436 = 0;
						}
						if (this.type == 42)
						{
							num435 = 53;
							num436 = 0;
						}
						if (this.type == 56)
						{
							num435 = 112;
							num436 = 0;
						}
						if (this.type == 65)
						{
							num435 = 112;
							num436 = 0;
						}
						if (this.type == 67)
						{
							num435 = 116;
							num436 = 0;
						}
						if (this.type == 68)
						{
							num435 = 116;
							num436 = 0;
						}
						if (this.type == 71)
						{
							num435 = 123;
							num436 = 0;
						}
						if (this.type == 39)
						{
							num435 = 59;
							num436 = 176;
						}
						if (this.type == 40)
						{
							num435 = 57;
							num436 = 172;
						}
						if (this.type == 179)
						{
							num435 = 224;
							num436 = 0;
						}
						if (this.type == 241)
						{
							num435 = 234;
							num436 = 0;
						}
						if (this.type == 354)
						{
							num435 = 234;
							num436 = 0;
						}
						if (this.type == 411)
						{
							num435 = 330;
							num436 = 71;
						}
						if (this.type == 412)
						{
							num435 = 331;
							num436 = 72;
						}
						if (this.type == 413)
						{
							num435 = 332;
							num436 = 73;
						}
						if (this.type == 414)
						{
							num435 = 333;
							num436 = 74;
						}
						if (Main.tile[num433, num434].halfBrick() && this.velocity.Y > 0f && Math.Abs(this.velocity.Y) > Math.Abs(this.velocity.X))
						{
							num434--;
						}
						if (!Main.tile[num433, num434].active())
						{
							WorldGen.PlaceTile(num433, num434, num435, false, true, -1, 0);
							if (Main.tile[num433, num434].active() && (int)Main.tile[num433, num434].type == num435)
							{
								if (Main.tile[num433, num434 + 1].halfBrick() || Main.tile[num433, num434 + 1].slope() != 0)
								{
									WorldGen.SlopeTile(num433, num434 + 1, 0);
									if (Main.netMode == 2)
									{
										NetMessage.SendData(17, -1, -1, "", 14, (float)num433, (float)(num434 + 1), 0f, 0);
									}
								}
								if (Main.netMode != 0)
								{
									NetMessage.SendData(17, -1, -1, "", 1, (float)num433, (float)num434, (float)num435, 0);
								}
							}
							else if (num436 > 0)
							{
								num432 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num436, 1, false, 0, false);
							}
						}
						else if (num436 > 0)
						{
							num432 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num436, 1, false, 0, false);
						}
					}
					if (this.type == 1 && Main.rand.Next(3) == 0)
					{
						num432 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0, false);
					}
					if (this.type == 103 && Main.rand.Next(6) == 0)
					{
						if (Main.rand.Next(3) == 0)
						{
							num432 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 545, 1, false, 0, false);
						}
						else
						{
							num432 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0, false);
						}
					}
					if (this.type == 2 && Main.rand.Next(3) == 0)
					{
						if (Main.rand.Next(3) == 0)
						{
							num432 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 41, 1, false, 0, false);
						}
						else
						{
							num432 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0, false);
						}
					}
					if (this.type == 172 && Main.rand.Next(3) == 0)
					{
						if (Main.rand.Next(3) == 0)
						{
							num432 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 988, 1, false, 0, false);
						}
						else
						{
							num432 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0, false);
						}
					}
					if (this.type == 171)
					{
						if (this.ai[1] == 0f)
						{
							num432 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 985, 1, false, 0, false);
							Main.item[num432].noGrabDelay = 0;
						}
						else if (this.ai[1] < 10f)
						{
							num432 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 965, (int)(10f - this.ai[1]), false, 0, false);
							Main.item[num432].noGrabDelay = 0;
						}
					}
					if (this.type == 91 && Main.rand.Next(6) == 0)
					{
						num432 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 516, 1, false, 0, false);
					}
					if (this.type == 50 && Main.rand.Next(3) == 0)
					{
						num432 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 282, 1, false, 0, false);
					}
					if (this.type == 53 && Main.rand.Next(3) == 0)
					{
						num432 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 286, 1, false, 0, false);
					}
					if (this.type == 48 && Main.rand.Next(2) == 0)
					{
						num432 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 279, 1, false, 0, false);
					}
					if (this.type == 54 && Main.rand.Next(2) == 0)
					{
						num432 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 287, 1, false, 0, false);
					}
					if (this.type == 3 && Main.rand.Next(2) == 0)
					{
						num432 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 42, 1, false, 0, false);
					}
					if (this.type == 4 && Main.rand.Next(4) == 0)
					{
						num432 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 47, 1, false, 0, false);
					}
					if (this.type == 12 && this.damage > 500)
					{
						num432 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 75, 1, false, 0, false);
					}
					if (this.type == 155)
					{
						num432 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 859, 1, false, 0, false);
					}
					if (this.type == 21 && Main.rand.Next(2) == 0)
					{
						num432 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 154, 1, false, 0, false);
					}
					if (Main.netMode == 1 && num432 >= 0)
					{
						NetMessage.SendData(21, -1, -1, "", num432, 1f, 0f, 0f, 0);
					}
				}
				if (this.type == 69 || this.type == 70)
				{
					int num437 = (int)(this.position.X + (float)(this.width / 2)) / 16;
					int num438 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
					for (int num439 = num437 - 4; num439 <= num437 + 4; num439++)
					{
						for (int num440 = num438 - 4; num440 <= num438 + 4; num440++)
						{
							if (Math.Abs(num439 - num437) + Math.Abs(num440 - num438) < 6)
							{
								if (this.type == 69)
								{
									if (Main.tile[num439, num440].type == 2)
									{
										Main.tile[num439, num440].type = 109;
										WorldGen.SquareTileFrame(num439, num440, true);
										NetMessage.SendTileSquare(-1, num439, num440, 1);
									}
									else if (Main.tile[num439, num440].type == 1 || Main.tileMoss[(int)Main.tile[num439, num440].type])
									{
										Main.tile[num439, num440].type = 117;
										WorldGen.SquareTileFrame(num439, num440, true);
										NetMessage.SendTileSquare(-1, num439, num440, 1);
									}
									else if (Main.tile[num439, num440].type == 53 || Main.tile[num439, num440].type == 234)
									{
										Main.tile[num439, num440].type = 116;
										WorldGen.SquareTileFrame(num439, num440, true);
										NetMessage.SendTileSquare(-1, num439, num440, 1);
									}
									else if (Main.tile[num439, num440].type == 23 || Main.tile[num439, num440].type == 199)
									{
										Main.tile[num439, num440].type = 109;
										WorldGen.SquareTileFrame(num439, num440, true);
										NetMessage.SendTileSquare(-1, num439, num440, 1);
									}
									else if (Main.tile[num439, num440].type == 25 || Main.tile[num439, num440].type == 203)
									{
										Main.tile[num439, num440].type = 117;
										WorldGen.SquareTileFrame(num439, num440, true);
										NetMessage.SendTileSquare(-1, num439, num440, 1);
									}
									else if (Main.tile[num439, num440].type == 161 || Main.tile[num439, num440].type == 163 || Main.tile[num439, num440].type == 200)
									{
										Main.tile[num439, num440].type = 164;
										WorldGen.SquareTileFrame(num439, num440, true);
										NetMessage.SendTileSquare(-1, num439, num440, 1);
									}
									else if (Main.tile[num439, num440].type == 112)
									{
										Main.tile[num439, num440].type = 116;
										WorldGen.SquareTileFrame(num439, num440, true);
										NetMessage.SendTileSquare(-1, num439, num440, 1);
									}
									else if (Main.tile[num439, num440].type == 161 || Main.tile[num439, num440].type == 163)
									{
										Main.tile[num439, num440].type = 164;
										WorldGen.SquareTileFrame(num439, num440, true);
										NetMessage.SendTileSquare(-1, num439, num440, 1);
									}
								}
								else if (Main.tile[num439, num440].type == 2)
								{
									Main.tile[num439, num440].type = 23;
									WorldGen.SquareTileFrame(num439, num440, true);
									NetMessage.SendTileSquare(-1, num439, num440, 1);
								}
								else if (Main.tile[num439, num440].type == 1 || Main.tileMoss[(int)Main.tile[num439, num440].type])
								{
									Main.tile[num439, num440].type = 25;
									WorldGen.SquareTileFrame(num439, num440, true);
									NetMessage.SendTileSquare(-1, num439, num440, 1);
								}
								else if (Main.tile[num439, num440].type == 53)
								{
									Main.tile[num439, num440].type = 112;
									WorldGen.SquareTileFrame(num439, num440, true);
									NetMessage.SendTileSquare(-1, num439, num440, 1);
								}
								else if (Main.tile[num439, num440].type == 109)
								{
									Main.tile[num439, num440].type = 23;
									WorldGen.SquareTileFrame(num439, num440, true);
									NetMessage.SendTileSquare(-1, num439, num440, 1);
								}
								else if (Main.tile[num439, num440].type == 117)
								{
									Main.tile[num439, num440].type = 25;
									WorldGen.SquareTileFrame(num439, num440, true);
									NetMessage.SendTileSquare(-1, num439, num440, 1);
								}
								else if (Main.tile[num439, num440].type == 116)
								{
									Main.tile[num439, num440].type = 112;
									WorldGen.SquareTileFrame(num439, num440, true);
									NetMessage.SendTileSquare(-1, num439, num440, 1);
								}
								else if (Main.tile[num439, num440].type == 161 || Main.tile[num439, num440].type == 164 || Main.tile[num439, num440].type == 200)
								{
									Main.tile[num439, num440].type = 163;
									WorldGen.SquareTileFrame(num439, num440, true);
									NetMessage.SendTileSquare(-1, num439, num440, 1);
								}
							}
						}
					}
				}
				if (this.type == 370 || this.type == 371)
				{
					float num441 = 80f;
					int num442 = 119;
					if (this.type == 371)
					{
						num442 = 120;
					}
					for (int num443 = 0; num443 < 255; num443++)
					{
						Player player = Main.player[num443];
						if (player.active && !player.dead && Vector2.Distance(this.center(), player.center()) < num441)
						{
							player.AddBuff(num442, 1800, true);
						}
					}
					for (int num444 = 0; num444 < 200; num444++)
					{
						NPC nPC = Main.npc[num444];
						if (nPC.active && nPC.life > 0 && Vector2.Distance(this.center(), nPC.center()) < num441)
						{
							nPC.AddBuff(num442, 1800, false);
						}
					}
				}
				if (this.type == 378)
				{
					int num445 = Main.rand.Next(2, 4);
					if (Main.rand.Next(5) == 0)
					{
						num445++;
					}
					for (int num446 = 0; num446 < num445; num446++)
					{
						float num447 = this.velocity.X;
						float num448 = this.velocity.Y;
						num447 *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
						num448 *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
						Projectile.NewProjectile(this.center().X, this.center().Y, num447, num448, 379, this.damage, this.knockBack, this.owner, 0f, 0f);
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
			if (this.type == 409)
			{
				return new Color(250, 250, 250, 200);
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
				return Color.Transparent;
			}
			if (this.type >= 400 && this.type <= 402)
			{
				return Color.Transparent;
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
						return Color.Transparent;
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
							return Color.Transparent;
						}
						return new Color(255, 255, 255, 0);
					}
					else if (this.type == 270)
					{
						if (this.alpha > 0)
						{
							return Color.Transparent;
						}
						return new Color(255, 255, 255, 200);
					}
					else if (this.type == 257)
					{
						if (this.alpha > 200)
						{
							return Color.Transparent;
						}
						return new Color(255 - this.alpha, 255 - this.alpha, 255 - this.alpha, 0);
					}
					else if (this.type == 259)
					{
						if (this.alpha > 200)
						{
							return Color.Transparent;
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
							return Color.Transparent;
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
							return Color.Transparent;
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
									return Color.Transparent;
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
								return Color.Transparent;
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
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"name:",
				this.name,
				", active:",
				this.active,
				", whoAmI:",
				this.whoAmI
			});
		}
	}
}
