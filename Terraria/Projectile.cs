using System;
using ServerApi;

namespace Terraria
{
	public class Projectile
	{
		public bool wet;
		public byte wetCount;
		public bool lavaWet;
		public int whoAmI;
		public static int maxAI = 2;
		public Vector2 position;
		public Vector2 lastPosition;
		public Vector2 velocity;
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
            switch (this.type)
            {
                case 1:
                    this.name = "Wooden Arrow";
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 1;
                    this.friendly = true;
                    this.ranged = true;
                    break;
                case 2:
                    this.name = "Fire Arrow";
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 1;
                    this.friendly = true;
                    this.light = 1f;
                    this.ranged = true;
                    break;
                case 3:
                    this.name = "Shuriken";
                    this.width = 22;
                    this.height = 22;
                    this.aiStyle = 2;
                    this.friendly = true;
                    this.penetrate = 4;
                    this.ranged = true;
                    break;
                case 4:
                    this.name = "Unholy Arrow";
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 1;
                    this.friendly = true;
                    this.light = 0.35f;
                    this.penetrate = 5;
                    this.ranged = true;
                    break;
                case 5:
                    this.name = "Jester's Arrow";
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 1;
                    this.friendly = true;
                    this.light = 0.4f;
                    this.penetrate = -1;
                    this.timeLeft = 40;
                    this.alpha = 100;
                    this.ignoreWater = true;
                    this.ranged = true;
                    break;
                case 6:
                    this.name = "Enchanted Boomerang";
                    this.width = 22;
                    this.height = 22;
                    this.aiStyle = 3;
                    this.friendly = true;
                    this.penetrate = -1;
                    this.melee = true;
                    this.light = 0.4f;
                    break;
                case 8:
                case 7:
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
                    break;
                case 9:
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
                    break;
                case 10:
                    this.name = "Purification Powder";
                    this.width = 64;
                    this.height = 64;
                    this.aiStyle = 6;
                    this.friendly = true;
                    this.tileCollide = false;
                    this.penetrate = -1;
                    this.alpha = 255;
                    this.ignoreWater = true;
                    break;
                case 11:
                    this.name = "Vile Powder";
                    this.width = 48;
                    this.height = 48;
                    this.aiStyle = 6;
                    this.friendly = true;
                    this.tileCollide = false;
                    this.penetrate = -1;
                    this.alpha = 255;
                    this.ignoreWater = true;
                    break;
                case 12:
                    this.name = "Falling Star";
                    this.width = 16;
                    this.height = 16;
                    this.aiStyle = 5;
                    this.friendly = true;
                    this.penetrate = -1;
                    this.alpha = 50;
                    this.light = 1f;
                    break;
                case 13:
                    this.name = "Hook";
                    this.width = 18;
                    this.height = 18;
                    this.aiStyle = 7;
                    this.friendly = true;
                    this.penetrate = -1;
                    this.tileCollide = false;
                    this.timeLeft *= 10;
                    break;
                case 14:
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
                    break;
                case 15:
                    this.name = "Ball of Fire";
                    this.width = 16;
                    this.height = 16;
                    this.aiStyle = 8;
                    this.friendly = true;
                    this.light = 0.8f;
                    this.alpha = 100;
                    this.magic = true;
                    break;
                case 16:
                    this.name = "Magic Missile";
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 9;
                    this.friendly = true;
                    this.light = 0.8f;
                    this.alpha = 100;
                    this.magic = true;
                    break;
                case 17:
                    this.name = "Dirt Ball";
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 10;
                    this.friendly = true;
                    break;
                case 18:
                    this.name = "Orb of Light";
                    this.width = 32;
                    this.height = 32;
                    this.aiStyle = 11;
                    this.friendly = true;
                    this.light = 0.45f;
                    this.alpha = 150;
                    this.tileCollide = false;
                    this.penetrate = -1;
                    this.timeLeft *= 5;
                    this.ignoreWater = true;
                    this.scale = 0.8f;
                    break;
                case 19:
                    this.name = "Flamarang";
                    this.width = 22;
                    this.height = 22;
                    this.aiStyle = 3;
                    this.friendly = true;
                    this.penetrate = -1;
                    this.light = 1f;
                    this.melee = true;
                    break;
                case 20:
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
                    break;
                case 21:
                    this.name = "Bone";
                    this.width = 16;
                    this.height = 16;
                    this.aiStyle = 2;
                    this.scale = 1.2f;
                    this.friendly = true;
                    this.ranged = true;
                    break;
                case 22:
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
                    break;
                case 23:
                    this.name = "Harpoon";
                    this.width = 4;
                    this.height = 4;
                    this.aiStyle = 13;
                    this.friendly = true;
                    this.penetrate = -1;
                    this.alpha = 255;
                    this.ranged = true;
                    break;
                case 24:
                    this.name = "Spiky Ball";
                    this.width = 14;
                    this.height = 14;
                    this.aiStyle = 14;
                    this.friendly = true;
                    this.penetrate = 6;
                    this.ranged = true;
                    break;
                case 25:
                    this.name = "Ball 'O Hurt";
                    this.width = 22;
                    this.height = 22;
                    this.aiStyle = 15;
                    this.friendly = true;
                    this.penetrate = -1;
                    this.melee = true;
                    this.scale = 0.8f;
                    break;
                case 26:
                    this.name = "Blue Moon";
                    this.width = 22;
                    this.height = 22;
                    this.aiStyle = 15;
                    this.friendly = true;
                    this.penetrate = -1;
                    this.melee = true;
                    this.scale = 0.8f;
                    break;
                case 27:
                    this.name = "Water Bolt";
                    this.width = 16;
                    this.height = 16;
                    this.aiStyle = 8;
                    this.friendly = true;
                    this.light = 0.8f;
                    this.alpha = 200;
                    this.timeLeft /= 2;
                    this.penetrate = 10;
                    this.magic = true;
                    break;
                case 28:
                    this.name = "Bomb";
                    this.width = 22;
                    this.height = 22;
                    this.aiStyle = 16;
                    this.friendly = true;
                    this.penetrate = -1;
                    break;
                case 29:
                    this.name = "Dynamite";
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 16;
                    this.friendly = true;
                    this.penetrate = -1;
                    break;
                case 30:
                    this.name = "Grenade";
                    this.width = 14;
                    this.height = 14;
                    this.aiStyle = 16;
                    this.friendly = true;
                    this.penetrate = -1;
                    this.ranged = true;
                    break;
                case 31:
                    this.name = "Sand Ball";
                    this.knockBack = 6f;
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 10;
                    this.friendly = true;
                    this.hostile = true;
                    this.penetrate = -1;
                    break;
                case 32:
                    this.name = "Ivy Whip";
                    this.width = 18;
                    this.height = 18;
                    this.aiStyle = 7;
                    this.friendly = true;
                    this.penetrate = -1;
                    this.tileCollide = false;
                    this.timeLeft *= 10;
                    break;
                case 33:
                    this.name = "Thorn Chakrum";
                    this.width = 28;
                    this.height = 28;
                    this.aiStyle = 3;
                    this.friendly = true;
                    this.scale = 0.9f;
                    this.penetrate = -1;
                    this.melee = true;
                    break;
                case 34:
                    this.name = "Flamelash";
                    this.width = 14;
                    this.height = 14;
                    this.aiStyle = 9;
                    this.friendly = true;
                    this.light = 0.8f;
                    this.alpha = 100;
                    this.penetrate = 1;
                    this.magic = true;
                    break;
                case 35:
                    this.name = "Sunfury";
                    this.width = 22;
                    this.height = 22;
                    this.aiStyle = 15;
                    this.friendly = true;
                    this.penetrate = -1;
                    this.melee = true;
                    this.scale = 0.8f;
                    break;
                case 36:
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
                    break;
                case 37:
                    this.name = "Sticky Bomb";
                    this.width = 22;
                    this.height = 22;
                    this.aiStyle = 16;
                    this.friendly = true;
                    this.penetrate = -1;
                    this.tileCollide = false;
                    break;
                case 38:
                    this.name = "Harpy Feather";
                    this.width = 14;
                    this.height = 14;
                    this.aiStyle = 0;
                    this.hostile = true;
                    this.penetrate = -1;
                    this.aiStyle = 1;
                    this.tileCollide = true;
                    break;
                case 39:
                    this.name = "Mud Ball";
                    this.knockBack = 6f;
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 10;
                    this.friendly = true;
                    this.hostile = true;
                    this.penetrate = -1;
                    break;
                case 40:
                    this.name = "Ash Ball";
                    this.knockBack = 6f;
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 10;
                    this.friendly = true;
                    this.hostile = true;
                    this.penetrate = -1;
                    break;
                case 41:
                    this.name = "Hellfire Arrow";
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 1;
                    this.friendly = true;
                    this.penetrate = -1;
                    this.ranged = true;
                    this.light = 0.3f;
                    break;
                case 42:
                    this.name = "Sand Ball";
                    this.knockBack = 8f;
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 10;
                    this.friendly = true;
                    this.maxUpdates = 1;
                    break;
                case 43:
                    this.name = "Tombstone";
                    this.knockBack = 12f;
                    this.width = 24;
                    this.height = 24;
                    this.aiStyle = 17;
                    this.penetrate = -1;
                    break;
                case 44:
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
                    break;
                case 45:
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
                    break;
                case 46:
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
                    break;
                case 47:
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
                    break;
                case 48:
                    this.name = "Throwing Knife";
                    this.width = 12;
                    this.height = 12;
                    this.aiStyle = 2;
                    this.friendly = true;
                    this.penetrate = 2;
                    this.ranged = true;
                    break;
                case 49:
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
                    break;
                case 50:
                    this.name = "Glowstick";
                    this.width = 6;
                    this.height = 6;
                    this.aiStyle = 14;
                    this.penetrate = -1;
                    this.alpha = 75;
                    this.light = 1f;
                    this.timeLeft *= 5;
                    break;
                case 51:
                    this.name = "Seed";
                    this.width = 8;
                    this.height = 8;
                    this.aiStyle = 1;
                    this.friendly = true;
                    break;
                case 52:
                    this.name = "Wooden Boomerang";
                    this.width = 22;
                    this.height = 22;
                    this.aiStyle = 3;
                    this.friendly = true;
                    this.penetrate = -1;
                    this.melee = true;
                    break;
                case 53:
                    this.name = "Sticky Glowstick";
                    this.width = 6;
                    this.height = 6;
                    this.aiStyle = 14;
                    this.penetrate = -1;
                    this.alpha = 75;
                    this.light = 1f;
                    this.timeLeft *= 5;
                    this.tileCollide = false;
                    break;
                case 54:
                    this.name = "Poisoned Knife";
                    this.width = 12;
                    this.height = 12;
                    this.aiStyle = 2;
                    this.friendly = true;
                    this.penetrate = 2;
                    this.ranged = true;
                    break;
                case 55:
                    this.name = "Stinger";
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 0;
                    this.hostile = true;
                    this.penetrate = -1;
                    this.aiStyle = 1;
                    this.tileCollide = true;
                    break;
                case 56:
                    this.name = "Ebonsand Ball";
                    this.knockBack = 6f;
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 10;
                    this.friendly = true;
                    this.hostile = true;
                    this.penetrate = -1;
                    break;
                case 57:
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
                    break;
                case 58:
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
                    break;
                case 59:
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
                    break;
                case 60:
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
                    break;
                case 61:
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
                    break;
                case 62:
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
                    break;
                case 63:
                    this.name = "The Dao of Pow";
                    this.width = 22;
                    this.height = 22;
                    this.aiStyle = 15;
                    this.friendly = true;
                    this.penetrate = -1;
                    this.melee = true;
                    break;
                case 64:
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
                    break;
                case 65:
                    this.name = "Ebonsand Ball";
                    this.knockBack = 6f;
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 10;
                    this.friendly = true;
                    this.penetrate = -1;
                    this.maxUpdates = 1;
                    break;
                case 66:
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
                    break;
                case 67:
                    this.name = "Pearl Sand Ball";
                    this.knockBack = 6f;
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 10;
                    this.friendly = true;
                    this.hostile = true;
                    this.penetrate = -1;
                    break;
                case 68:
                    this.name = "Pearl Sand Ball";
                    this.knockBack = 6f;
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 10;
                    this.friendly = true;
                    this.penetrate = -1;
                    this.maxUpdates = 1;
                    break;
                case 69:
                    this.name = "Holy Water";
                    this.width = 14;
                    this.height = 14;
                    this.aiStyle = 2;
                    this.friendly = true;
                    this.penetrate = 1;
                    break;
                case 70:
                    this.name = "Unholy Water";
                    this.width = 14;
                    this.height = 14;
                    this.aiStyle = 2;
                    this.friendly = true;
                    this.penetrate = 1;
                    break;
                case 71:
                    this.name = "Gravel Ball";
                    this.knockBack = 6f;
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 10;
                    this.friendly = true;
                    this.hostile = true;
                    this.penetrate = -1;
                    break;
                case 72:
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
                    break;
                case 74:
                case 73:
                    this.name = "Hook";
                    this.width = 18;
                    this.height = 18;
                    this.aiStyle = 7;
                    this.friendly = true;
                    this.penetrate = -1;
                    this.tileCollide = false;
                    this.timeLeft *= 10;
                    this.light = 0.4f;
                    break;
                case 75:
                    this.name = "Happy Bomb";
                    this.width = 22;
                    this.height = 22;
                    this.aiStyle = 16;
                    this.hostile = true;
                    this.penetrate = -1;
                    break;
                case 78:
                case 77:
                case 76:
                    if (this.type == 76)
                    {
                        this.width = 10;
                        this.height = 22;
                    }
                    else
                    {
                        if (this.type == 77)
                        {
                            this.width = 18;
                            this.height = 24;
                        }
                        else
                        {
                            this.width = 22;
                            this.height = 24;
                        }
                    }
                    this.name = "Note";
                    this.aiStyle = 21;
                    this.friendly = true;
                    this.ranged = true;
                    this.alpha = 100;
                    this.light = 0.3f;
                    this.penetrate = -1;
                    this.timeLeft = 180;
                    break;
                case 79:
                    this.name = "Rainbow";
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 9;
                    this.friendly = true;
                    this.light = 0.8f;
                    this.alpha = 255;
                    this.magic = true;
                    break;
                case 80:
                    this.name = "Ice Block";
                    this.width = 16;
                    this.height = 16;
                    this.aiStyle = 22;
                    this.friendly = true;
                    this.magic = true;
                    this.tileCollide = false;
                    this.light = 0.5f;
                    break;
                case 81:
                    this.name = "Wooden Arrow";
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 1;
                    this.hostile = true;
                    this.ranged = true;
                    break;
                case 82:
                    this.name = "Flaming Arrow";
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 1;
                    this.hostile = true;
                    this.ranged = true;
                    break;
                case 83:
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
                    break;
                case 84:
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
                    break;
                case 85:
                    this.name = "Flames";
                    this.width = 6;
                    this.height = 6;
                    this.aiStyle = 23;
                    this.friendly = true;
                    this.alpha = 255;
                    this.penetrate = 3;
                    this.maxUpdates = 2;
                    this.magic = true;
                    break;
                case 86:
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
                    break;
                case 87:
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
                    break;
                case 88:
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
                    break;
                case 89:
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
                    break;
                case 90:
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
                    break;
                case 91:
                    this.name = "Holy Arrow";
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 1;
                    this.friendly = true;
                    this.ranged = true;
                    break;
                case 92:
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
                    break;
                case 93:
                    this.light = 0.15f;
                    this.name = "Magic Dagger";
                    this.width = 12;
                    this.height = 12;
                    this.aiStyle = 2;
                    this.friendly = true;
                    this.penetrate = 2;
                    this.magic = true;
                    break;
                case 94:
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
                    break;
                case 95:
                    this.name = "Cursed Flame";
                    this.width = 16;
                    this.height = 16;
                    this.aiStyle = 8;
                    this.friendly = true;
                    this.light = 0.8f;
                    this.alpha = 100;
                    this.magic = true;
                    this.penetrate = 2;
                    break;
                case 96:
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
                    break;
                case 97:
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
                    break;
                case 98:
                    this.name = "Poison Dart";
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 1;
                    this.friendly = true;
                    this.hostile = true;
                    this.ranged = true;
                    this.penetrate = -1;
                    break;
                case 99:
                    this.name = "Boulder";
                    this.width = 31;
                    this.height = 31;
                    this.aiStyle = 25;
                    this.friendly = true;
                    this.hostile = true;
                    this.ranged = true;
                    this.penetrate = -1;
                    break;
                case 100:
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
                    break;
                case 101:
                    this.name = "Eye Fire";
                    this.width = 6;
                    this.height = 6;
                    this.aiStyle = 23;
                    this.hostile = true;
                    this.alpha = 255;
                    this.penetrate = -1;
                    this.maxUpdates = 3;
                    this.magic = true;
                    break;
                case 102:
                    this.name = "Bomb";
                    this.width = 22;
                    this.height = 22;
                    this.aiStyle = 16;
                    this.hostile = true;
                    this.penetrate = -1;
                    this.ranged = true;
                    break;
                case 103:
                    this.name = "Cursed Arrow";
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 1;
                    this.friendly = true;
                    this.light = 1f;
                    this.ranged = true;
                    break;
                case 104:
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
                    break;
                case 105:
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
                    break;
                case 106:
                    this.name = "Light Disc";
                    this.width = 32;
                    this.height = 32;
                    this.aiStyle = 3;
                    this.friendly = true;
                    this.penetrate = -1;
                    this.melee = true;
                    this.light = 0.4f;
                    break;
                case 107:
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
                    break;
                case 108:
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
                    break;
                case 109:
                    this.name = "Sand Ball";
                    this.knockBack = 6f;
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 10;
                    this.hostile = true;
                    this.scale = 0.9f;
                    this.penetrate = -1;
                    break;
                case 110:
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
                    break;
                case 111:
                    this.name = "Bunny";
                    this.width = 18;
                    this.height = 18;
                    this.aiStyle = 26;
                    this.friendly = true;
                    this.penetrate = -1;
                    this.timeLeft *= 5;
                    break;
                default:
                    this.active = false;
                    break;
            }
		    this.width = (int)((float)this.width * this.scale);
			this.height = (int)((float)this.height * this.scale);
			ServerApi.ServerApi.Hooks.InvokeProjectileSetDefaults(ref Type, this);
		}
		public static int NewProjectile(float X, float Y, float SpeedX, float SpeedY, int Type, int Damage, float KnockBack, int Owner = 255)
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
			Main.projectile[num].wet = Collision.WetCollision(Main.projectile[num].position, Main.projectile[num].width, Main.projectile[num].height);
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
			}
			return num;
		}
		public void StatusNPC(int i)
		{
			if (this.type == 2)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.npc[i].AddBuff(24, 180, false);
					return;
				}
			}
			else
			{
				if (this.type == 15)
				{
					if (Main.rand.Next(2) == 0)
					{
						Main.npc[i].AddBuff(24, 300, false);
						return;
					}
				}
				else
				{
					if (this.type == 19)
					{
						if (Main.rand.Next(5) == 0)
						{
							Main.npc[i].AddBuff(24, 180, false);
							return;
						}
					}
					else
					{
						if (this.type == 33)
						{
							if (Main.rand.Next(5) == 0)
							{
								Main.npc[i].AddBuff(20, 420, false);
								return;
							}
						}
						else
						{
							if (this.type == 34)
							{
								if (Main.rand.Next(2) == 0)
								{
									Main.npc[i].AddBuff(24, 240, false);
									return;
								}
							}
							else
							{
								if (this.type == 35)
								{
									if (Main.rand.Next(4) == 0)
									{
										Main.npc[i].AddBuff(24, 180, false);
										return;
									}
								}
								else
								{
									if (this.type == 54)
									{
										if (Main.rand.Next(2) == 0)
										{
											Main.npc[i].AddBuff(20, 600, false);
											return;
										}
									}
									else
									{
										if (this.type == 63)
										{
											if (Main.rand.Next(3) != 0)
											{
												Main.npc[i].AddBuff(31, 120, false);
												return;
											}
										}
										else
										{
											if (this.type == 85)
											{
												Main.npc[i].AddBuff(24, 1200, false);
												return;
											}
											if (this.type == 95 || this.type == 103 || this.type == 104)
											{
												Main.npc[i].AddBuff(39, 420, false);
												return;
											}
											if (this.type == 98)
											{
												Main.npc[i].AddBuff(20, 600, false);
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
		public void StatusPvP(int i)
		{
			if (this.type == 2)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.player[i].AddBuff(24, 180, false);
					return;
				}
			}
			else
			{
				if (this.type == 15)
				{
					if (Main.rand.Next(2) == 0)
					{
						Main.player[i].AddBuff(24, 300, false);
						return;
					}
				}
				else
				{
					if (this.type == 19)
					{
						if (Main.rand.Next(5) == 0)
						{
							Main.player[i].AddBuff(24, 180, false);
							return;
						}
					}
					else
					{
						if (this.type == 33)
						{
							if (Main.rand.Next(5) == 0)
							{
								Main.player[i].AddBuff(20, 420, false);
								return;
							}
						}
						else
						{
							if (this.type == 34)
							{
								if (Main.rand.Next(2) == 0)
								{
									Main.player[i].AddBuff(24, 240, false);
									return;
								}
							}
							else
							{
								if (this.type == 35)
								{
									if (Main.rand.Next(4) == 0)
									{
										Main.player[i].AddBuff(24, 180, false);
										return;
									}
								}
								else
								{
									if (this.type == 54)
									{
										if (Main.rand.Next(2) == 0)
										{
											Main.player[i].AddBuff(20, 600, false);
											return;
										}
									}
									else
									{
										if (this.type == 63)
										{
											if (Main.rand.Next(3) != 0)
											{
												Main.player[i].AddBuff(31, 120, true);
												return;
											}
										}
										else
										{
											if (this.type == 85)
											{
												Main.player[i].AddBuff(24, 1200, false);
												return;
											}
											if (this.type == 95 || this.type == 103 || this.type == 104)
											{
												Main.player[i].AddBuff(39, 420, true);
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
		public void StatusPlayer(int i)
		{
			if (this.type == 55 && Main.rand.Next(3) == 0)
			{
				Main.player[i].AddBuff(20, 600, true);
			}
			if (this.type == 44 && Main.rand.Next(3) == 0)
			{
				Main.player[i].AddBuff(22, 900, true);
			}
			if (this.type == 82 && Main.rand.Next(3) == 0)
			{
				Main.player[i].AddBuff(24, 420, true);
			}
			if ((this.type == 96 || this.type == 101) && Main.rand.Next(3) == 0)
			{
				Main.player[i].AddBuff(39, 480, true);
			}
			if (this.type == 98)
			{
				Main.player[i].AddBuff(20, 600, true);
			}
		}
        public void Damage()
        {
            if (this.type == 18 || this.type == 72 || (this.type == 86 || this.type == 87) || this.type == 111)
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
            if (this.friendly && this.owner == Main.myPlayer)
            {
                if ((this.aiStyle == 16 || this.type == 41) && (this.timeLeft <= 1 || this.type == 108))
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
                if (this.type != 69 && this.type != 70 && (this.type != 10 && this.type != 11))
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
                                        this.direction = (double)Main.npc[index].position.X + (double)(Main.npc[index].width / 2) >= (double)this.position.X + (double)(this.width / 2) ? 1 : -1;
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
                                    this.StatusNPC(index);
                                    Main.npc[index].StrikeNPC(Damage, this.knockBack, this.direction, crit, false);
                                    if (Main.netMode != 0)
                                    {
                                        if (crit)
                                            NetMessage.SendData(28, -1, -1, "", index, (float)Damage, this.knockBack, (float)this.direction, 1);
                                        else
                                            NetMessage.SendData(28, -1, -1, "", index, (float)Damage, this.knockBack, (float)this.direction, 0);
                                    }
                                    if (this.penetrate != 1)
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
                                Main.player[index].Hurt(Damage, this.direction, true, false, Lang.deathMsg(this.owner, -1, this.whoAmI, -1), Crit);
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
        public void Update(int i)
        {
            if (!this.active)
                return;
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
                    }
                    catch
                    {
                        this.active = false;
                        return;
                    }
                    if (this.wet && !this.lavaWet)
                    {
                        if (this.type == 85 || this.type == 15 || this.type == 34)
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
                        if ((int)this.wetCount == 0)
                        {
                            this.wetCount = (byte)10;
                            if (!this.wet)
                            {
                                if (!flag1)
                                {
                                    for (int index1 = 0; index1 < 10; ++index1)
                                    {
                                        int index2 = Dust.NewDust(new Vector2(this.position.X - 6f, (float)((double)this.position.Y + (double)(this.height / 2) - 8.0)), this.width + 12, 24, 33, 0.0f, 0.0f, 0, new Color(), 1f);
                                        Main.dust[index2].velocity.Y -= 4f;
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
                    }
                    else if (this.wet)
                    {
                        this.wet = false;
                        if ((int)this.wetCount == 0)
                        {
                            this.wetCount = (byte)10;
                            if (!this.lavaWet)
                            {
                                for (int index1 = 0; index1 < 10; ++index1)
                                {
                                    int index2 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2)), this.width + 12, 24, 33, 0.0f, 0.0f, 0, new Color(), 1f);
                                    Main.dust[index2].velocity.Y -= 4f;
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
                        this.lavaWet = false;
                    if ((int)this.wetCount > 0)
                        --this.wetCount;
                }
                this.lastPosition = this.position;
                if (this.tileCollide)
                {
                    Vector2 vector2_2 = this.velocity;
                    bool flag1 = true;
                    if (this.type == 9 || this.type == 12 || (this.type == 15 || this.type == 13) || (this.type == 31 || this.type == 39 || this.type == 40))
                        flag1 = false;
                    if (this.aiStyle == 10)
                        this.velocity = this.type == 42 || this.type == 65 || this.type == 68 || this.type == 31 && (double)this.ai[0] == 2.0 ? Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag1, flag1) : Collision.AnyCollision(this.position, this.velocity, this.width, this.height);
                    else if (this.aiStyle == 18)
                    {
                        int Width = this.width - 36;
                        int Height = this.height - 36;
                        this.velocity = Collision.TileCollision(new Vector2(this.position.X + (float)(this.width / 2) - (float)(Width / 2), this.position.Y + (float)(this.height / 2) - (float)(Height / 2)), this.velocity, Width, Height, flag1, flag1);
                    }
                    else if (this.wet)
                    {
                        Vector2 vector2_3 = this.velocity;
                        this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag1, flag1);
                        vector2_1 = this.velocity * 0.5f;
                        if ((double)this.velocity.X != (double)vector2_3.X)
                            vector2_1.X = this.velocity.X;
                        if ((double)this.velocity.Y != (double)vector2_3.Y)
                            vector2_1.Y = this.velocity.Y;
                    }
                    else
                        this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag1, flag1);
                    if (vector2_2 != this.velocity && this.type != 111)
                    {
                        if (this.type == 94)
                        {
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
                            if ((double)this.ai[0] >= 5.0)
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
                            if (this.type == 50)
                            {
                                if ((double)this.velocity.X != (double)vector2_2.X)
                                    this.velocity.X = vector2_2.X * -0.2f;
                                if ((double)this.velocity.Y != (double)vector2_2.Y && (double)vector2_2.Y > 1.5)
                                    this.velocity.Y = vector2_2.Y * -0.2f;
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
                        }
                        else if (this.aiStyle != 9 || this.owner == Main.myPlayer)
                        {
                            this.position += this.velocity;
                            this.Kill();
                        }
                    }
                }
                if (this.type != 7 && this.type != 8)
                {
                    if (this.wet)
                        this.position += vector2_1;
                    else
                        this.position += this.velocity;
                }
                if ((this.aiStyle != 3 || (double)this.ai[0] != 1.0) && (this.aiStyle != 7 || (double)this.ai[0] != 1.0) && ((this.aiStyle != 13 || (double)this.ai[0] != 1.0) && (this.aiStyle != 15 || (double)this.ai[0] != 1.0)) && (this.aiStyle != 15 && this.aiStyle != 26))
                    this.direction = (double)this.velocity.X >= 0.0 ? 1 : -1;
                if (!this.active)
                    return;
                if ((double)this.light > 0.0)
                {
                    float R = this.light;
                    float G = this.light;
                    float B = this.light;
                    if (this.type == 2 || this.type == 82)
                    {
                        G *= 0.75f;
                        B *= 0.55f;
                    }
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
                    else if (this.type == 14 || this.type == 110)
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
                        G *= 0.7f;
                        B *= 0.3f;
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
                    Lighting.addLight((int)(((double)this.position.X + (double)(this.width / 2)) / 16.0), (int)(((double)this.position.Y + (double)(this.height / 2)) / 16.0), R, G, B);
                }
                if (this.type == 2 || this.type == 82)
                    Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 1f);
                else if (this.type == 103)
                {
                    int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 75, 0.0f, 0.0f, 100, new Color(), 1f);
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[index].noGravity = true;
                        Main.dust[index].scale *= 2f;
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
                    Collision.SwitchTiles(this.position, this.width, this.height, this.lastPosition);
                if (this.type == 94)
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
                if (this.type == 83 && (double)this.ai[1] == 0.0)
                {
                    this.ai[1] = 1f;
                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 33);
                }
                if (this.type == 110 && (double)this.ai[1] == 0.0)
                {
                    this.ai[1] = 1f;
                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 11);
                }
                if (this.type == 84 && (double)this.ai[1] == 0.0)
                {
                    this.ai[1] = 1f;
                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 12);
                }
                if (this.type == 100 && (double)this.ai[1] == 0.0)
                {
                    this.ai[1] = 1f;
                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 33);
                }
                if (this.type == 98 && (double)this.ai[1] == 0.0)
                {
                    this.ai[1] = 1f;
                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 17);
                }
                if ((this.type == 81 || this.type == 82) && (double)this.ai[1] == 0.0)
                {
                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 5);
                    this.ai[1] = 1f;
                }
                if (this.type == 41)
                {
                    int index1 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0.0f, 0.0f, 100, new Color(), 1.6f);
                    Main.dust[index1].noGravity = true;
                    int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 2f);
                    Main.dust[index2].noGravity = true;
                }
                else if (this.type == 55)
                {
                    int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 18, 0.0f, 0.0f, 0, new Color(), 0.9f);
                    Main.dust[index].noGravity = true;
                }
                else if (this.type == 91 && Main.rand.Next(2) == 0)
                {
                    int index = Dust.NewDust(this.position, this.width, this.height, Main.rand.Next(2) != 0 ? 58 : 15, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 150, new Color(), 0.9f);
                    Main.dust[index].velocity *= 0.25f;
                }
                if (this.type == 20 || this.type == 14 || (this.type == 36 || this.type == 83) || (this.type == 84 || this.type == 89 || (this.type == 100 || this.type == 104)) || this.type == 110)
                {
                    if (this.alpha > 0)
                        this.alpha -= 15;
                    if (this.alpha < 0)
                        this.alpha = 0;
                }
                if (this.type == 88)
                {
                    if (this.alpha > 0)
                        this.alpha -= 10;
                    if (this.alpha < 0)
                        this.alpha = 0;
                }
                if (this.type != 5 && this.type != 14 && (this.type != 20 && this.type != 36) && (this.type != 38 && this.type != 55 && (this.type != 83 && this.type != 84)) && (this.type != 88 && this.type != 89 && (this.type != 98 && this.type != 100) && (this.type != 104 && this.type != 110)))
                    ++this.ai[0];
                if (this.type == 81 || this.type == 91)
                {
                    if ((double)this.ai[0] >= 20.0)
                    {
                        this.ai[0] = 20f;
                        this.velocity.Y += 0.07f;
                    }
                }
                else if ((double)this.ai[0] >= 15.0)
                {
                    this.ai[0] = 15f;
                    this.velocity.Y += 0.1f;
                }
                this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
                if ((double)this.velocity.Y <= 16.0)
                    return;
                this.velocity.Y = 16f;
            }
            else if (this.aiStyle == 2)
            {
                if (this.type == 93 && Main.rand.Next(5) == 0)
                {
                    int index = Dust.NewDust(this.position, this.width, this.height, 57, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, new Color(), 0.3f);
                    Main.dust[index].velocity.X *= 0.3f;
                    Main.dust[index].velocity.Y *= 0.3f;
                }
                this.rotation += (float)(((double)Math.Abs(this.velocity.X) + (double)Math.Abs(this.velocity.Y)) * 0.0299999993294477) * (float)this.direction;
                if (this.type == 69 || this.type == 70)
                {
                    ++this.ai[0];
                    if ((double)this.ai[0] >= 10.0)
                    {
                        this.velocity.Y += 0.25f;
                        this.velocity.X *= 0.99f;
                    }
                }
                else
                {
                    ++this.ai[0];
                    if ((double)this.ai[0] >= 20.0)
                    {
                        this.velocity.Y += 0.4f;
                        this.velocity.X *= 0.97f;
                    }
                    else if (this.type == 48 || this.type == 54 || this.type == 93)
                        this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
                }
                if ((double)this.velocity.Y > 16.0)
                    this.velocity.Y = 16f;
                if (this.type != 54 || Main.rand.Next(20) != 0)
                    return;
                Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 40, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 0, new Color(), 0.75f);
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
                    for (int index1 = 0; index1 < 2; ++index1)
                    {
                        int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, new Color(), 2f);
                        Main.dust[index2].noGravity = true;
                        Main.dust[index2].velocity.X *= 0.3f;
                        Main.dust[index2].velocity.Y *= 0.3f;
                    }
                }
                else if (this.type == 33)
                {
                    if (Main.rand.Next(1) == 0)
                    {
                        int index = Dust.NewDust(this.position, this.width, this.height, 40, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 0, new Color(), 1.4f);
                        Main.dust[index].noGravity = true;
                    }
                }
                else if (this.type == 6 && Main.rand.Next(5) == 0)
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
                    Dust.NewDust(this.position, this.width, this.height, Type, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 150, new Color(), 0.7f);
                }
                if ((double)this.ai[0] == 0.0)
                {
                    ++this.ai[1];
                    if (this.type == 106)
                    {
                        if ((double)this.ai[1] >= 45.0)
                        {
                            this.ai[0] = 1f;
                            this.ai[1] = 0.0f;
                            this.netUpdate = true;
                        }
                    }
                    else if ((double)this.ai[1] >= 30.0)
                    {
                        this.ai[0] = 1f;
                        this.ai[1] = 0.0f;
                        this.netUpdate = true;
                    }
                }
                else
                {
                    this.tileCollide = false;
                    float num1 = 9f;
                    float num2 = 0.4f;
                    if (this.type == 19)
                    {
                        num1 = 13f;
                        num2 = 0.6f;
                    }
                    else if (this.type == 33)
                    {
                        num1 = 15f;
                        num2 = 0.8f;
                    }
                    else if (this.type == 106)
                    {
                        num1 = 16f;
                        num2 = 1.2f;
                    }
                    Vector2 vector2 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                    float num3 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector2.X;
                    float num4 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector2.Y;
                    float num5 = (float)Math.Sqrt((double)num3 * (double)num3 + (double)num4 * (double)num4);
                    if ((double)num5 > 3000.0)
                        this.Kill();
                    float num6 = num1 / num5;
                    float num7 = num3 * num6;
                    float num8 = num4 * num6;
                    if ((double)this.velocity.X < (double)num7)
                    {
                        this.velocity.X += num2;
                        if ((double)this.velocity.X < 0.0 && (double)num7 > 0.0)
                            this.velocity.X += num2;
                    }
                    else if ((double)this.velocity.X > (double)num7)
                    {
                        this.velocity.X -= num2;
                        if ((double)this.velocity.X > 0.0 && (double)num7 < 0.0)
                            this.velocity.X -= num2;
                    }
                    if ((double)this.velocity.Y < (double)num8)
                    {
                        this.velocity.Y += num2;
                        if ((double)this.velocity.Y < 0.0 && (double)num8 > 0.0)
                            this.velocity.Y += num2;
                    }
                    else if ((double)this.velocity.Y > (double)num8)
                    {
                        this.velocity.Y -= num2;
                        if ((double)this.velocity.Y > 0.0 && (double)num8 < 0.0)
                            this.velocity.Y -= num2;
                    }
                    if (Main.myPlayer == this.owner && new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height).Intersects(new Rectangle((int)Main.player[this.owner].position.X, (int)Main.player[this.owner].position.Y, Main.player[this.owner].width, Main.player[this.owner].height)))
                        this.Kill();
                }
                if (this.type == 106)
                    this.rotation += 0.3f * (float)this.direction;
                else
                    this.rotation += 0.4f * (float)this.direction;
            }
            else if (this.aiStyle == 4)
            {
                this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
                if ((double)this.ai[0] == 0.0)
                {
                    this.alpha -= 50;
                    if (this.alpha > 0)
                        return;
                    this.alpha = 0;
                    this.ai[0] = 1f;
                    if ((double)this.ai[1] == 0.0)
                    {
                        ++this.ai[1];
                        this.position += this.velocity * 1f;
                    }
                    if (this.type != 7 || Main.myPlayer != this.owner)
                        return;
                    int Type = this.type;
                    if ((double)this.ai[1] >= 6.0)
                        ++Type;
                    int number = Projectile.NewProjectile(this.position.X + this.velocity.X + (float)(this.width / 2), this.position.Y + this.velocity.Y + (float)(this.height / 2), this.velocity.X, this.velocity.Y, Type, this.damage, this.knockBack, this.owner);
                    Main.projectile[number].damage = this.damage;
                    Main.projectile[number].ai[1] = this.ai[1] + 1f;
                    NetMessage.SendData(27, -1, -1, "", number, 0.0f, 0.0f, 0.0f, 0);
                }
                else
                {
                    if (this.alpha < 170 && this.alpha + 5 >= 170)
                    {
                        for (int index = 0; index < 3; ++index)
                            Dust.NewDust(this.position, this.width, this.height, 18, this.velocity.X * 0.025f, this.velocity.Y * 0.025f, 170, new Color(), 1.2f);
                        Dust.NewDust(this.position, this.width, this.height, 14, 0.0f, 0.0f, 170, new Color(), 1.1f);
                    }
                    this.alpha += 5;
                    if (this.alpha < (int)byte.MaxValue)
                        return;
                    this.Kill();
                }
            }
            else if (this.aiStyle == 5)
            {
                if (this.type == 92)
                {
                    if ((double)this.position.Y > (double)this.ai[1])
                        this.tileCollide = true;
                }
                else
                {
                    if ((double)this.ai[1] == 0.0 && !Collision.SolidCollision(this.position, this.width, this.height))
                    {
                        this.ai[1] = 1f;
                        this.netUpdate = true;
                    }
                    if ((double)this.ai[1] != 0.0)
                        this.tileCollide = true;
                }
                if (this.soundDelay == 0)
                {
                    this.soundDelay = 20 + Main.rand.Next(40);
                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 9);
                }
                if ((double)this.localAI[0] == 0.0)
                    this.localAI[0] = 1f;
                this.alpha += (int)(25.0 * (double)this.localAI[0]);
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
                this.rotation += (float)(((double)Math.Abs(this.velocity.X) + (double)Math.Abs(this.velocity.Y)) * 0.00999999977648258) * (float)this.direction;
                if ((double)this.ai[1] != 1.0 && this.type != 92)
                    return;
                this.light = 0.9f;
                if (Main.rand.Next(10) == 0)
                    Dust.NewDust(this.position, this.width, this.height, 58, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, new Color(), 1.2f);
                if (Main.rand.Next(20) != 0)
                    return;
                Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.2f, this.velocity.Y * 0.2f), Main.rand.Next(16, 18), 1f);
            }
            else if (this.aiStyle == 6)
            {
                this.velocity *= 0.95f;
                ++this.ai[0];
                if ((double)this.ai[0] == 180.0)
                    this.Kill();
                if ((double)this.ai[1] == 0.0)
                {
                    this.ai[1] = 1f;
                    for (int index = 0; index < 30; ++index)
                        Dust.NewDust(this.position, this.width, this.height, 10 + this.type, this.velocity.X, this.velocity.Y, 50, new Color(), 1f);
                }
                if (this.type != 10 && this.type != 11)
                    return;
                int num1 = (int)((double)this.position.X / 16.0) - 1;
                int num2 = (int)(((double)this.position.X + (double)this.width) / 16.0) + 2;
                int num3 = (int)((double)this.position.Y / 16.0) - 1;
                int num4 = (int)(((double)this.position.Y + (double)this.height) / 16.0) + 2;
                if (num1 < 0)
                    num1 = 0;
                if (num2 > Main.maxTilesX)
                    num2 = Main.maxTilesX;
                if (num3 < 0)
                    num3 = 0;
                if (num4 > Main.maxTilesY)
                    num4 = Main.maxTilesY;
                for (int index1 = num1; index1 < num2; ++index1)
                {
                    for (int index2 = num3; index2 < num4; ++index2)
                    {
                        Vector2 vector2;
                        vector2.X = (float)(index1 * 16);
                        vector2.Y = (float)(index2 * 16);
                        if ((double)this.position.X + (double)this.width > (double)vector2.X && (double)this.position.X < (double)vector2.X + 16.0 && ((double)this.position.Y + (double)this.height > (double)vector2.Y && (double)this.position.Y < (double)vector2.Y + 16.0) && (Main.myPlayer == this.owner && Main.tile[index1, index2].active))
                        {
                            if (this.type == 10)
                            {
                                if ((int)Main.tile[index1, index2].type == 23)
                                {
                                    Main.tile[index1, index2].type = (byte)2;
                                    WorldGen.SquareTileFrame(index1, index2, true);
                                    if (Main.netMode == 1)
                                        NetMessage.SendTileSquare(-1, index1, index2, 1);
                                }
                                if ((int)Main.tile[index1, index2].type == 25)
                                {
                                    Main.tile[index1, index2].type = (byte)1;
                                    WorldGen.SquareTileFrame(index1, index2, true);
                                    if (Main.netMode == 1)
                                        NetMessage.SendTileSquare(-1, index1, index2, 1);
                                }
                                if ((int)Main.tile[index1, index2].type == 112)
                                {
                                    Main.tile[index1, index2].type = (byte)53;
                                    WorldGen.SquareTileFrame(index1, index2, true);
                                    if (Main.netMode == 1)
                                        NetMessage.SendTileSquare(-1, index1, index2, 1);
                                }
                            }
                            else if (this.type == 11)
                            {
                                if ((int)Main.tile[index1, index2].type == 109)
                                {
                                    Main.tile[index1, index2].type = (byte)2;
                                    WorldGen.SquareTileFrame(index1, index2, true);
                                    if (Main.netMode == 1)
                                        NetMessage.SendTileSquare(-1, index1, index2, 1);
                                }
                                if ((int)Main.tile[index1, index2].type == 116)
                                {
                                    Main.tile[index1, index2].type = (byte)53;
                                    WorldGen.SquareTileFrame(index1, index2, true);
                                    if (Main.netMode == 1)
                                        NetMessage.SendTileSquare(-1, index1, index2, 1);
                                }
                                if ((int)Main.tile[index1, index2].type == 117)
                                {
                                    Main.tile[index1, index2].type = (byte)1;
                                    WorldGen.SquareTileFrame(index1, index2, true);
                                    if (Main.netMode == 1)
                                        NetMessage.SendTileSquare(-1, index1, index2, 1);
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
                }
                else
                {
                    Vector2 vector2_1 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                    float num1 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector2_1.X;
                    float num2 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector2_1.Y;
                    float num3 = (float)Math.Sqrt((double)num1 * (double)num1 + (double)num2 * (double)num2);
                    this.rotation = (float)Math.Atan2((double)num2, (double)num1) - 1.57f;
                    if ((double)this.ai[0] == 0.0)
                    {
                        if ((double)num3 > 300.0 && this.type == 13 || (double)num3 > 400.0 && this.type == 32 || ((double)num3 > 440.0 && this.type == 73 || (double)num3 > 440.0 && this.type == 74))
                            this.ai[0] = 1f;
                        int num4 = (int)((double)this.position.X / 16.0) - 1;
                        int num5 = (int)(((double)this.position.X + (double)this.width) / 16.0) + 2;
                        int num6 = (int)((double)this.position.Y / 16.0) - 1;
                        int num7 = (int)(((double)this.position.Y + (double)this.height) / 16.0) + 2;
                        if (num4 < 0)
                            num4 = 0;
                        if (num5 > Main.maxTilesX)
                            num5 = Main.maxTilesX;
                        if (num6 < 0)
                            num6 = 0;
                        if (num7 > Main.maxTilesY)
                            num7 = Main.maxTilesY;
                        for (int i = num4; i < num5; ++i)
                        {
                            for (int j = num6; j < num7; ++j)
                            {
                                Vector2 vector2_2;
                                vector2_2.X = (float)(i * 16);
                                vector2_2.Y = (float)(j * 16);
                                if ((double)this.position.X + (double)this.width > (double)vector2_2.X && (double)this.position.X < (double)vector2_2.X + 16.0 && ((double)this.position.Y + (double)this.height > (double)vector2_2.Y && (double)this.position.Y < (double)vector2_2.Y + 16.0) && (Main.tile[i, j].active && Main.tileSolid[(int)Main.tile[i, j].type]))
                                {
                                    if (Main.player[this.owner].grapCount < 10)
                                    {
                                        Main.player[this.owner].grappling[Main.player[this.owner].grapCount] = this.whoAmI;
                                        ++Main.player[this.owner].grapCount;
                                    }
                                    if (Main.myPlayer == this.owner)
                                    {
                                        int num8 = 0;
                                        int index1 = -1;
                                        int num9 = 100000;
                                        if (this.type == 73 || this.type == 74)
                                        {
                                            for (int index2 = 0; index2 < 1000; ++index2)
                                            {
                                                if (index2 != this.whoAmI && Main.projectile[index2].active && (Main.projectile[index2].owner == this.owner && Main.projectile[index2].aiStyle == 7) && (double)Main.projectile[index2].ai[0] == 2.0)
                                                    Main.projectile[index2].Kill();
                                            }
                                        }
                                        else
                                        {
                                            for (int index2 = 0; index2 < 1000; ++index2)
                                            {
                                                if (Main.projectile[index2].active && Main.projectile[index2].owner == this.owner && Main.projectile[index2].aiStyle == 7)
                                                {
                                                    if (Main.projectile[index2].timeLeft < num9)
                                                    {
                                                        index1 = index2;
                                                        num9 = Main.projectile[index2].timeLeft;
                                                    }
                                                    ++num8;
                                                }
                                            }
                                            if (num8 > 3)
                                                Main.projectile[index1].Kill();
                                        }
                                    }
                                    WorldGen.KillTile(i, j, true, true, false);
                                    Main.PlaySound(0, i * 16, j * 16, 1);
                                    this.velocity.X = 0.0f;
                                    this.velocity.Y = 0.0f;
                                    this.ai[0] = 2f;
                                    this.position.X = (float)(i * 16 + 8 - this.width / 2);
                                    this.position.Y = (float)(j * 16 + 8 - this.height / 2);
                                    this.damage = 0;
                                    this.netUpdate = true;
                                    if (Main.myPlayer == this.owner)
                                    {
                                        NetMessage.SendData(13, -1, -1, "", this.owner, 0.0f, 0.0f, 0.0f, 0);
                                        break;
                                    }
                                    else
                                        break;
                                }
                            }
                            if ((double)this.ai[0] == 2.0)
                                break;
                        }
                    }
                    else if ((double)this.ai[0] == 1.0)
                    {
                        float num4 = 11f;
                        if (this.type == 32)
                            num4 = 15f;
                        if (this.type == 73 || this.type == 74)
                            num4 = 17f;
                        if ((double)num3 < 24.0)
                            this.Kill();
                        float num5 = num4 / num3;
                        float num6 = num1 * num5;
                        float num7 = num2 * num5;
                        this.velocity.X = num6;
                        this.velocity.Y = num7;
                    }
                    else
                    {
                        if ((double)this.ai[0] != 2.0)
                            return;
                        int num4 = (int)((double)this.position.X / 16.0) - 1;
                        int num5 = (int)(((double)this.position.X + (double)this.width) / 16.0) + 2;
                        int num6 = (int)((double)this.position.Y / 16.0) - 1;
                        int num7 = (int)(((double)this.position.Y + (double)this.height) / 16.0) + 2;
                        if (num4 < 0)
                            num4 = 0;
                        if (num5 > Main.maxTilesX)
                            num5 = Main.maxTilesX;
                        if (num6 < 0)
                            num6 = 0;
                        if (num7 > Main.maxTilesY)
                            num7 = Main.maxTilesY;
                        bool flag = true;
                        for (int index1 = num4; index1 < num5; ++index1)
                        {
                            for (int index2 = num6; index2 < num7; ++index2)
                            {
                                Vector2 vector2_2;
                                vector2_2.X = (float)(index1 * 16);
                                vector2_2.Y = (float)(index2 * 16);
                                if ((double)this.position.X + (double)(this.width / 2) > (double)vector2_2.X && (double)this.position.X + (double)(this.width / 2) < (double)vector2_2.X + 16.0 && ((double)this.position.Y + (double)(this.height / 2) > (double)vector2_2.Y && (double)this.position.Y + (double)(this.height / 2) < (double)vector2_2.Y + 16.0) && (Main.tile[index1, index2].active && Main.tileSolid[(int)Main.tile[index1, index2].type]))
                                    flag = false;
                            }
                        }
                        if (flag)
                        {
                            this.ai[0] = 1f;
                        }
                        else
                        {
                            if (Main.player[this.owner].grapCount >= 10)
                                return;
                            Main.player[this.owner].grappling[Main.player[this.owner].grapCount] = this.whoAmI;
                            ++Main.player[this.owner].grapCount;
                        }
                    }
                }
            }
            else if (this.aiStyle == 8)
            {
                if (this.type == 96 && (double)this.localAI[0] == 0.0)
                {
                    this.localAI[0] = 1f;
                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 20);
                }
                if (this.type == 27)
                {
                    int index = Dust.NewDust(new Vector2(this.position.X + this.velocity.X, this.position.Y + this.velocity.Y), this.width, this.height, 29, this.velocity.X, this.velocity.Y, 100, new Color(), 3f);
                    Main.dust[index].noGravity = true;
                    if (Main.rand.Next(10) == 0)
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 29, this.velocity.X, this.velocity.Y, 100, new Color(), 1.4f);
                }
                else if (this.type == 95 || this.type == 96)
                {
                    int index = Dust.NewDust(new Vector2(this.position.X + this.velocity.X, this.position.Y + this.velocity.Y), this.width, this.height, 75, this.velocity.X, this.velocity.Y, 100, new Color(), 3f * this.scale);
                    Main.dust[index].noGravity = true;
                }
                else
                {
                    for (int index1 = 0; index1 < 2; ++index1)
                    {
                        int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, new Color(), 2f);
                        Main.dust[index2].noGravity = true;
                        Main.dust[index2].velocity.X *= 0.3f;
                        Main.dust[index2].velocity.Y *= 0.3f;
                    }
                }
                if (this.type != 27 && this.type != 96)
                    ++this.ai[1];
                if ((double)this.ai[1] >= 20.0)
                    this.velocity.Y += 0.2f;
                this.rotation += 0.3f * (float)this.direction;
                if ((double)this.velocity.Y <= 16.0)
                    return;
                this.velocity.Y = 16f;
            }
            else if (this.aiStyle == 9)
            {
                if (this.type == 34)
                {
                    int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, new Color(), 3.5f);
                    Main.dust[index].noGravity = true;
                    Main.dust[index].velocity *= 1.4f;
                    Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, new Color(), 1.5f);
                }
                else if (this.type == 79)
                {
                    if (this.soundDelay == 0 && (double)Math.Abs(this.velocity.X) + (double)Math.Abs(this.velocity.Y) > 2.0)
                    {
                        this.soundDelay = 10;
                        Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 9);
                    }
                    for (int index1 = 0; index1 < 1; ++index1)
                    {
                        int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 66, 0.0f, 0.0f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 2.5f);
                        Main.dust[index2].velocity *= 0.1f;
                        Main.dust[index2].velocity += this.velocity * 0.2f;
                        Main.dust[index2].position.X = (float)((double)this.position.X + (double)(this.width / 2) + 4.0) + (float)Main.rand.Next(-2, 3);
                        Main.dust[index2].position.Y = this.position.Y + (float)(this.height / 2) + (float)Main.rand.Next(-2, 3);
                        Main.dust[index2].noGravity = true;
                    }
                }
                else
                {
                    if (this.soundDelay == 0 && (double)Math.Abs(this.velocity.X) + (double)Math.Abs(this.velocity.Y) > 2.0)
                    {
                        this.soundDelay = 10;
                        Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 9);
                    }
                    int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 15, 0.0f, 0.0f, 100, new Color(), 2f);
                    Main.dust[index].velocity *= 0.3f;
                    Main.dust[index].position.X = (float)((double)this.position.X + (double)(this.width / 2) + 4.0) + (float)Main.rand.Next(-4, 5);
                    Main.dust[index].position.Y = this.position.Y + (float)(this.height / 2) + (float)Main.rand.Next(-4, 5);
                    Main.dust[index].noGravity = true;
                }
                if (Main.myPlayer == this.owner && (double)this.ai[0] == 0.0)
                {
                    if (Main.player[this.owner].channel)
                    {
                        float num1 = 12f;
                        if (this.type == 16)
                            num1 = 15f;
                        Vector2 vector2 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                        float num2 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
                        float num3 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
                        float num4 = (float)Math.Sqrt((double)num2 * (double)num2 + (double)num3 * (double)num3);
                        float num5 = (float)Math.Sqrt((double)num2 * (double)num2 + (double)num3 * (double)num3);
                        if ((double)num5 > (double)num1)
                        {
                            float num6 = num1 / num5;
                            float num7 = num2 * num6;
                            float num8 = num3 * num6;
                            if ((int)((double)num7 * 1000.0) != (int)((double)this.velocity.X * 1000.0) || (int)((double)num8 * 1000.0) != (int)((double)this.velocity.Y * 1000.0))
                                this.netUpdate = true;
                            this.velocity.X = num7;
                            this.velocity.Y = num8;
                        }
                        else
                        {
                            if ((int)((double)num2 * 1000.0) != (int)((double)this.velocity.X * 1000.0) || (int)((double)num3 * 1000.0) != (int)((double)this.velocity.Y * 1000.0))
                                this.netUpdate = true;
                            this.velocity.X = num2;
                            this.velocity.Y = num3;
                        }
                    }
                    else if ((double)this.ai[0] == 0.0)
                    {
                        this.ai[0] = 1f;
                        this.netUpdate = true;
                        float num1 = 12f;
                        Vector2 vector2 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                        float num2 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
                        float num3 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
                        float num4 = (float)Math.Sqrt((double)num2 * (double)num2 + (double)num3 * (double)num3);
                        if ((double)num4 == 0.0)
                        {
                            vector2 = new Vector2(Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2), Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2));
                            num2 = this.position.X + (float)this.width * 0.5f - vector2.X;
                            num3 = this.position.Y + (float)this.height * 0.5f - vector2.Y;
                            num4 = (float)Math.Sqrt((double)num2 * (double)num2 + (double)num3 * (double)num3);
                        }
                        float num5 = num1 / num4;
                        float num6 = num2 * num5;
                        float num7 = num3 * num5;
                        this.velocity.X = num6;
                        this.velocity.Y = num7;
                        if ((double)this.velocity.X == 0.0 && (double)this.velocity.Y == 0.0)
                            this.Kill();
                    }
                }
                if (this.type == 34)
                    this.rotation += 0.3f * (float)this.direction;
                else if ((double)this.velocity.X != 0.0 || (double)this.velocity.Y != 0.0)
                    this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) - 2.355f;
                if ((double)this.velocity.Y <= 16.0)
                    return;
                this.velocity.Y = 16f;
            }
            else if (this.aiStyle == 10)
            {
                if (this.type == 31 && (double)this.ai[0] != 2.0)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 32, 0.0f, this.velocity.Y / 2f, 0, new Color(), 1f);
                        Main.dust[index].velocity.X *= 0.4f;
                    }
                }
                else if (this.type == 39)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 38, 0.0f, this.velocity.Y / 2f, 0, new Color(), 1f);
                        Main.dust[index].velocity.X *= 0.4f;
                    }
                }
                else if (this.type == 40)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 36, 0.0f, this.velocity.Y / 2f, 0, new Color(), 1f);
                        Main.dust[index].velocity *= 0.4f;
                    }
                }
                else if (this.type == 42 || this.type == 31)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 32, 0.0f, 0.0f, 0, new Color(), 1f);
                        Main.dust[index].velocity.X *= 0.4f;
                    }
                }
                else if (this.type == 56 || this.type == 65)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0.0f, 0.0f, 0, new Color(), 1f);
                        Main.dust[index].velocity.X *= 0.4f;
                    }
                }
                else if (this.type == 67 || this.type == 68)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 51, 0.0f, 0.0f, 0, new Color(), 1f);
                        Main.dust[index].velocity.X *= 0.4f;
                    }
                }
                else if (this.type == 71)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 53, 0.0f, 0.0f, 0, new Color(), 1f);
                        Main.dust[index].velocity.X *= 0.4f;
                    }
                }
                else if (this.type != 109 && Main.rand.Next(20) == 0)
                    Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0, 0.0f, 0.0f, 0, new Color(), 1f);
                if (Main.myPlayer == this.owner && (double)this.ai[0] == 0.0)
                {
                    if (Main.player[this.owner].channel)
                    {
                        float num1 = 12f;
                        Vector2 vector2 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                        float num2 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
                        float num3 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
                        float num4 = (float)Math.Sqrt((double)num2 * (double)num2 + (double)num3 * (double)num3);
                        float num5 = (float)Math.Sqrt((double)num2 * (double)num2 + (double)num3 * (double)num3);
                        if ((double)num5 > (double)num1)
                        {
                            float num6 = num1 / num5;
                            float num7 = num2 * num6;
                            float num8 = num3 * num6;
                            if ((double)num7 != (double)this.velocity.X || (double)num8 != (double)this.velocity.Y)
                                this.netUpdate = true;
                            this.velocity.X = num7;
                            this.velocity.Y = num8;
                        }
                        else
                        {
                            if ((double)num2 != (double)this.velocity.X || (double)num3 != (double)this.velocity.Y)
                                this.netUpdate = true;
                            this.velocity.X = num2;
                            this.velocity.Y = num3;
                        }
                    }
                    else
                    {
                        this.ai[0] = 1f;
                        this.netUpdate = true;
                    }
                }
                if ((double)this.ai[0] == 1.0 && this.type != 109)
                {
                    if (this.type == 42 || this.type == 65 || this.type == 68)
                    {
                        ++this.ai[1];
                        if ((double)this.ai[1] >= 60.0)
                        {
                            this.ai[1] = 60f;
                            this.velocity.Y += 0.2f;
                        }
                    }
                    else
                        this.velocity.Y += 0.41f;
                }
                else if ((double)this.ai[0] == 2.0 && this.type != 109)
                {
                    this.velocity.Y += 0.2f;
                    if ((double)this.velocity.X < -0.04)
                        this.velocity.X += 0.04f;
                    else if ((double)this.velocity.X > 0.04)
                        this.velocity.X -= 0.04f;
                    else
                        this.velocity.X = 0.0f;
                }
                this.rotation += 0.1f;
                if ((double)this.velocity.Y <= 10.0)
                    return;
                this.velocity.Y = 10f;
            }
            else if (this.aiStyle == 11)
            {
                if (this.type == 72 || this.type == 86 || this.type == 87)
                {
                    if ((double)this.velocity.X > 0.0)
                        this.spriteDirection = -1;
                    else if ((double)this.velocity.X < 0.0)
                        this.spriteDirection = 1;
                    this.rotation = this.velocity.X * 0.1f;
                    this.frameCounter = this.frameCounter + 1;
                    if (this.frameCounter >= 4)
                    {
                        ++this.frame;
                        this.frameCounter = 0;
                    }
                    if (this.frame >= 4)
                        this.frame = 0;
                    if (Main.rand.Next(6) == 0)
                    {
                        int Type = 56;
                        if (this.type == 86)
                            Type = 73;
                        else if (this.type == 87)
                            Type = 74;
                        int index = Dust.NewDust(this.position, this.width, this.height, Type, 0.0f, 0.0f, 200, new Color(), 0.8f);
                        Main.dust[index].velocity *= 0.3f;
                    }
                }
                else
                    this.rotation += 0.02f;
                if (Main.myPlayer == this.owner)
                {
                    if (this.type == 72 || this.type == 86 || this.type == 87)
                    {
                        if (Main.player[Main.myPlayer].fairy)
                            this.timeLeft = 2;
                    }
                    else if (Main.player[Main.myPlayer].lightOrb)
                        this.timeLeft = 2;
                }
                if (!Main.player[this.owner].dead)
                {
                    float num1 = 2.5f;
                    if (this.type == 72 || this.type == 86 || this.type == 87)
                        num1 = 3.5f;
                    Vector2 vector2 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                    float num2 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector2.X;
                    float num3 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector2.Y;
                    float num4 = (float)Math.Sqrt((double)num2 * (double)num2 + (double)num3 * (double)num3);
                    float num5 = (float)Math.Sqrt((double)num2 * (double)num2 + (double)num3 * (double)num3);
                    int num6 = 70;
                    if (this.type == 72 || this.type == 86 || this.type == 87)
                        num6 = 40;
                    if ((double)num5 > 800.0)
                    {
                        this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
                        this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
                    }
                    else if ((double)num5 > (double)num6)
                    {
                        float num7 = num1 / num5;
                        float num8 = num2 * num7;
                        float num9 = num3 * num7;
                        this.velocity.X = num8;
                        this.velocity.Y = num9;
                    }
                    else
                    {
                        this.velocity.X = 0.0f;
                        this.velocity.Y = 0.0f;
                    }
                }
                else
                    this.Kill();
            }
            else if (this.aiStyle == 12)
            {
                this.scale -= 0.04f;
                if ((double)this.scale <= 0.0)
                    this.Kill();
                if ((double)this.ai[0] > 4.0)
                {
                    this.alpha = 150;
                    this.light = 0.8f;
                    int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 29, this.velocity.X, this.velocity.Y, 100, new Color(), 2.5f);
                    Main.dust[index].noGravity = true;
                    Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 29, this.velocity.X, this.velocity.Y, 100, new Color(), 1.5f);
                }
                else
                    ++this.ai[0];
                this.rotation += 0.3f * (float)this.direction;
            }
            else if (this.aiStyle == 13)
            {
                if (Main.player[this.owner].dead)
                {
                    this.Kill();
                }
                else
                {
                    Main.player[this.owner].itemAnimation = 5;
                    Main.player[this.owner].itemTime = 5;
                    Main.player[this.owner].direction = (double)this.position.X + (double)(this.width / 2) <= (double)Main.player[this.owner].position.X + (double)(Main.player[this.owner].width / 2) ? -1 : 1;
                    Vector2 vector2 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                    float num1 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector2.X;
                    float num2 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector2.Y;
                    float num3 = (float)Math.Sqrt((double)num1 * (double)num1 + (double)num2 * (double)num2);
                    if ((double)this.ai[0] == 0.0)
                    {
                        if ((double)num3 > 700.0)
                            this.ai[0] = 1f;
                        this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
                        ++this.ai[1];
                        if ((double)this.ai[1] > 2.0)
                            this.alpha = 0;
                        if ((double)this.ai[1] < 10.0)
                            return;
                        this.ai[1] = 15f;
                        this.velocity.Y += 0.3f;
                    }
                    else
                    {
                        if ((double)this.ai[0] != 1.0)
                            return;
                        this.tileCollide = false;
                        this.rotation = (float)Math.Atan2((double)num2, (double)num1) - 1.57f;
                        float num4 = 20f;
                        if ((double)num3 < 50.0)
                            this.Kill();
                        float num5 = num4 / num3;
                        float num6 = num1 * num5;
                        float num7 = num2 * num5;
                        this.velocity.X = num6;
                        this.velocity.Y = num7;
                    }
                }
            }
            else if (this.aiStyle == 14)
            {
                if (this.type == 53)
                {
                    try
                    {
                        int num1 = this.velocity != Collision.TileCollision(this.position, this.velocity, this.width, this.height, false, false) ? 1 : 0;
                        int num2 = (int)((double)this.position.X / 16.0) - 1;
                        int num3 = (int)(((double)this.position.X + (double)this.width) / 16.0) + 2;
                        int num4 = (int)((double)this.position.Y / 16.0) - 1;
                        int num5 = (int)(((double)this.position.Y + (double)this.height) / 16.0) + 2;
                        if (num2 < 0)
                            num2 = 0;
                        if (num3 > Main.maxTilesX)
                            num3 = Main.maxTilesX;
                        if (num4 < 0)
                            num4 = 0;
                        if (num5 > Main.maxTilesY)
                            num5 = Main.maxTilesY;
                        for (int index1 = num2; index1 < num3; ++index1)
                        {
                            for (int index2 = num4; index2 < num5; ++index2)
                            {
                                if (Main.tile[index1, index2] != null && Main.tile[index1, index2].active && (Main.tileSolid[(int)Main.tile[index1, index2].type] || Main.tileSolidTop[(int)Main.tile[index1, index2].type] && (int)Main.tile[index1, index2].frameY == 0))
                                {
                                    Vector2 vector2;
                                    vector2.X = (float)(index1 * 16);
                                    vector2.Y = (float)(index2 * 16);
                                    if ((double)this.position.X + (double)this.width > (double)vector2.X && (double)this.position.X < (double)vector2.X + 16.0 && ((double)this.position.Y + (double)this.height > (double)vector2.Y && (double)this.position.Y < (double)vector2.Y + 16.0))
                                    {
                                        this.velocity.X = 0.0f;
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
                ++this.ai[0];
                if ((double)this.ai[0] > 5.0)
                {
                    this.ai[0] = 5f;
                    if ((double)this.velocity.Y == 0.0 && (double)this.velocity.X != 0.0)
                    {
                        this.velocity.X *= 0.97f;
                        if ((double)this.velocity.X > -0.01 && (double)this.velocity.X < 0.01)
                        {
                            this.velocity.X = 0.0f;
                            this.netUpdate = true;
                        }
                    }
                    this.velocity.Y += 0.2f;
                }
                this.rotation += this.velocity.X * 0.1f;
                if ((double)this.velocity.Y <= 16.0)
                    return;
                this.velocity.Y = 16f;
            }
            else if (this.aiStyle == 15)
            {
                if (this.type == 25)
                {
                    if (Main.rand.Next(15) == 0)
                        Dust.NewDust(this.position, this.width, this.height, 14, 0.0f, 0.0f, 150, new Color(), 1.3f);
                }
                else if (this.type == 26)
                {
                    int index = Dust.NewDust(this.position, this.width, this.height, 29, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 100, new Color(), 2.5f);
                    Main.dust[index].noGravity = true;
                    Main.dust[index].velocity.X /= 2f;
                    Main.dust[index].velocity.Y /= 2f;
                }
                else if (this.type == 35)
                {
                    int index = Dust.NewDust(this.position, this.width, this.height, 6, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 100, new Color(), 3f);
                    Main.dust[index].noGravity = true;
                    Main.dust[index].velocity.X *= 2f;
                    Main.dust[index].velocity.Y *= 2f;
                }
                if (Main.player[this.owner].dead)
                {
                    this.Kill();
                }
                else
                {
                    Main.player[this.owner].itemAnimation = 10;
                    Main.player[this.owner].itemTime = 10;
                    if ((double)this.position.X + (double)(this.width / 2) > (double)Main.player[this.owner].position.X + (double)(Main.player[this.owner].width / 2))
                    {
                        Main.player[this.owner].direction = 1;
                        this.direction = 1;
                    }
                    else
                    {
                        Main.player[this.owner].direction = -1;
                        this.direction = -1;
                    }
                    Vector2 vector2_1 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                    float num1 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector2_1.X;
                    float num2 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector2_1.Y;
                    float num3 = (float)Math.Sqrt((double)num1 * (double)num1 + (double)num2 * (double)num2);
                    if ((double)this.ai[0] == 0.0)
                    {
                        float num4 = 160f;
                        if (this.type == 63)
                            num4 *= 1.5f;
                        this.tileCollide = true;
                        if ((double)num3 > (double)num4)
                        {
                            this.ai[0] = 1f;
                            this.netUpdate = true;
                        }
                        else if (!Main.player[this.owner].channel)
                        {
                            if ((double)this.velocity.Y < 0.0)
                                this.velocity.Y *= 0.9f;
                            ++this.velocity.Y;
                            this.velocity.X *= 0.9f;
                        }
                    }
                    else if ((double)this.ai[0] == 1.0)
                    {
                        float num4 = 14f / Main.player[this.owner].meleeSpeed;
                        float num5 = 0.9f / Main.player[this.owner].meleeSpeed;
                        float num6 = 300f;
                        if (this.type == 63)
                        {
                            num6 *= 1.5f;
                            num4 *= 1.5f;
                            num5 *= 1.5f;
                        }
                        double num7 = (double)Math.Abs(num1);
                        double num8 = (double)Math.Abs(num2);
                        if ((double)this.ai[1] == 1.0)
                            this.tileCollide = false;
                        if (!Main.player[this.owner].channel || (double)num3 > (double)num6 || !this.tileCollide)
                        {
                            this.ai[1] = 1f;
                            if (this.tileCollide)
                                this.netUpdate = true;
                            this.tileCollide = false;
                            if ((double)num3 < 20.0)
                                this.Kill();
                        }
                        if (!this.tileCollide)
                            num5 *= 2f;
                        if ((double)num3 > 60.0 || !this.tileCollide)
                        {
                            float num9 = num4 / num3;
                            num1 *= num9;
                            num2 *= num9;
                            Vector2 vector2_2 = new Vector2(this.velocity.X, this.velocity.Y);
                            float num10 = num1 - this.velocity.X;
                            float num11 = num2 - this.velocity.Y;
                            float num12 = (float)Math.Sqrt((double)num10 * (double)num10 + (double)num11 * (double)num11);
                            float num13 = num5 / num12;
                            float num14 = num10 * num13;
                            float num15 = num11 * num13;
                            this.velocity.X *= 0.98f;
                            this.velocity.Y *= 0.98f;
                            this.velocity.X += num14;
                            this.velocity.Y += num15;
                        }
                        else
                        {
                            if ((double)Math.Abs(this.velocity.X) + (double)Math.Abs(this.velocity.Y) < 6.0)
                            {
                                this.velocity.X *= 0.96f;
                                this.velocity.Y += 0.2f;
                            }
                            if ((double)Main.player[this.owner].velocity.X == 0.0)
                                this.velocity.X *= 0.96f;
                        }
                    }
                    this.rotation = (float)Math.Atan2((double)num2, (double)num1) - this.velocity.X * 0.1f;
                }
            }
            else if (this.aiStyle == 16)
            {
                if (this.type == 108)
                {
                    ++this.ai[0];
                    if ((double)this.ai[0] > 3.0)
                        this.Kill();
                }
                if (this.type == 37)
                {
                    try
                    {
                        int num1 = (int)((double)this.position.X / 16.0) - 1;
                        int num2 = (int)(((double)this.position.X + (double)this.width) / 16.0) + 2;
                        int num3 = (int)((double)this.position.Y / 16.0) - 1;
                        int num4 = (int)(((double)this.position.Y + (double)this.height) / 16.0) + 2;
                        if (num1 < 0)
                            num1 = 0;
                        if (num2 > Main.maxTilesX)
                            num2 = Main.maxTilesX;
                        if (num3 < 0)
                            num3 = 0;
                        if (num4 > Main.maxTilesY)
                            num4 = Main.maxTilesY;
                        for (int index1 = num1; index1 < num2; ++index1)
                        {
                            for (int index2 = num3; index2 < num4; ++index2)
                            {
                                if (Main.tile[index1, index2] != null && Main.tile[index1, index2].active && (Main.tileSolid[(int)Main.tile[index1, index2].type] || Main.tileSolidTop[(int)Main.tile[index1, index2].type] && (int)Main.tile[index1, index2].frameY == 0))
                                {
                                    Vector2 vector2;
                                    vector2.X = (float)(index1 * 16);
                                    vector2.Y = (float)(index2 * 16);
                                    if ((double)this.position.X + (double)this.width - 4.0 > (double)vector2.X && (double)this.position.X + 4.0 < (double)vector2.X + 16.0 && ((double)this.position.Y + (double)this.height - 4.0 > (double)vector2.Y && (double)this.position.Y + 4.0 < (double)vector2.Y + 16.0))
                                    {
                                        this.velocity.X = 0.0f;
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
                    if ((double)this.velocity.Y > 10.0)
                        this.velocity.Y = 10f;
                    if ((double)this.localAI[0] == 0.0)
                    {
                        this.localAI[0] = 1f;
                        Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
                    }
                    ++this.frameCounter;
                    if (this.frameCounter > 3)
                    {
                        ++this.frame;
                        this.frameCounter = 0;
                    }
                    if (this.frame > 1)
                        this.frame = 0;
                    if ((double)this.velocity.Y == 0.0)
                    {
                        this.position.X += (float)(this.width / 2);
                        this.position.Y += (float)(this.height / 2);
                        this.width = 128;
                        this.height = 128;
                        this.position.X -= (float)(this.width / 2);
                        this.position.Y -= (float)(this.height / 2);
                        this.damage = 40;
                        this.knockBack = 8f;
                        this.timeLeft = 3;
                        this.netUpdate = true;
                    }
                }
                if (this.owner == Main.myPlayer && this.timeLeft <= 3)
                {
                    this.ai[1] = 0.0f;
                    this.alpha = (int)byte.MaxValue;
                    if (this.type == 28 || this.type == 37 || this.type == 75)
                    {
                        this.position.X += (float)(this.width / 2);
                        this.position.Y += (float)(this.height / 2);
                        this.width = 128;
                        this.height = 128;
                        this.position.X -= (float)(this.width / 2);
                        this.position.Y -= (float)(this.height / 2);
                        this.damage = 100;
                        this.knockBack = 8f;
                    }
                    else if (this.type == 29)
                    {
                        this.position.X += (float)(this.width / 2);
                        this.position.Y += (float)(this.height / 2);
                        this.width = 250;
                        this.height = 250;
                        this.position.X -= (float)(this.width / 2);
                        this.position.Y -= (float)(this.height / 2);
                        this.damage = 250;
                        this.knockBack = 10f;
                    }
                    else if (this.type == 30)
                    {
                        this.position.X += (float)(this.width / 2);
                        this.position.Y += (float)(this.height / 2);
                        this.width = 128;
                        this.height = 128;
                        this.position.X -= (float)(this.width / 2);
                        this.position.Y -= (float)(this.height / 2);
                        this.knockBack = 8f;
                    }
                }
                else
                {
                    if (this.type != 30 && this.type != 108)
                        this.damage = 0;
                    if (this.type != 30 && Main.rand.Next(4) == 0)
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0.0f, 0.0f, 100, new Color(), 1f);
                }
                ++this.ai[0];
                if (this.type == 30 && (double)this.ai[0] > 10.0 || this.type != 30 && (double)this.ai[0] > 5.0)
                {
                    this.ai[0] = 10f;
                    if ((double)this.velocity.Y == 0.0 && (double)this.velocity.X != 0.0)
                    {
                        this.velocity.X *= 0.97f;
                        if (this.type == 29)
                            this.velocity.X *= 0.99f;
                        if ((double)this.velocity.X > -0.01 && (double)this.velocity.X < 0.01)
                        {
                            this.velocity.X = 0.0f;
                            this.netUpdate = true;
                        }
                    }
                    this.velocity.Y += 0.2f;
                }
                this.rotation += this.velocity.X * 0.1f;
            }
            else if (this.aiStyle == 17)
            {
                if ((double)this.velocity.Y == 0.0)
                    this.velocity.X *= 0.98f;
                this.rotation += this.velocity.X * 0.1f;
                this.velocity.Y += 0.2f;
                if (this.owner != Main.myPlayer)
                    return;
                int i1 = (int)(((double)this.position.X + (double)(this.width / 2)) / 16.0);
                int j = (int)(((double)this.position.Y + (double)this.height - 4.0) / 16.0);
                if (Main.tile[i1, j] == null || Main.tile[i1, j].active)
                    return;
                WorldGen.PlaceTile(i1, j, 85, false, false, -1, 0);
                if (!Main.tile[i1, j].active)
                    return;
                if (Main.netMode != 0)
                    NetMessage.SendData(17, -1, -1, "", 1, (float)i1, (float)j, 85f, 0);
                int i2 = Sign.ReadSign(i1, j);
                if (i2 >= 0)
                    Sign.TextSign(i2, this.miscText);
                this.Kill();
            }
            else if (this.aiStyle == 18)
            {
                if ((double)this.ai[1] == 0.0 && this.type == 44)
                {
                    this.ai[1] = 1f;
                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
                }
                this.rotation += (float)this.direction * 0.8f;
                ++this.ai[0];
                if ((double)this.ai[0] >= 30.0)
                {
                    if ((double)this.ai[0] < 100.0)
                        this.velocity *= 1.06f;
                    else
                        this.ai[0] = 200f;
                }
                for (int index1 = 0; index1 < 2; ++index1)
                {
                    int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 27, 0.0f, 0.0f, 100, new Color(), 1f);
                    Main.dust[index2].noGravity = true;
                }
            }
            else if (this.aiStyle == 19)
            {
                this.direction = Main.player[this.owner].direction;
                Main.player[this.owner].heldProj = this.whoAmI;
                Main.player[this.owner].itemTime = Main.player[this.owner].itemAnimation;
                this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
                this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
                if (this.type == 46)
                {
                    if ((double)this.ai[0] == 0.0)
                    {
                        this.ai[0] = 3f;
                        this.netUpdate = true;
                    }
                    if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
                        this.ai[0] -= 1.6f;
                    else
                        this.ai[0] += 1.4f;
                }
                else if (this.type == 105)
                {
                    if ((double)this.ai[0] == 0.0)
                    {
                        this.ai[0] = 3f;
                        this.netUpdate = true;
                    }
                    if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
                        this.ai[0] -= 2.4f;
                    else
                        this.ai[0] += 2.1f;
                }
                else if (this.type == 47)
                {
                    if ((double)this.ai[0] == 0.0)
                    {
                        this.ai[0] = 4f;
                        this.netUpdate = true;
                    }
                    if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
                        this.ai[0] -= 1.2f;
                    else
                        this.ai[0] += 0.9f;
                }
                else if (this.type == 49)
                {
                    if ((double)this.ai[0] == 0.0)
                    {
                        this.ai[0] = 4f;
                        this.netUpdate = true;
                    }
                    if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
                        this.ai[0] -= 1.1f;
                    else
                        this.ai[0] += 0.85f;
                }
                else if (this.type == 64)
                {
                    this.spriteDirection = -this.direction;
                    if ((double)this.ai[0] == 0.0)
                    {
                        this.ai[0] = 3f;
                        this.netUpdate = true;
                    }
                    if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
                        this.ai[0] -= 1.9f;
                    else
                        this.ai[0] += 1.7f;
                }
                else if (this.type == 66 || this.type == 97)
                {
                    this.spriteDirection = -this.direction;
                    if ((double)this.ai[0] == 0.0)
                    {
                        this.ai[0] = 3f;
                        this.netUpdate = true;
                    }
                    if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
                        this.ai[0] -= 2.1f;
                    else
                        this.ai[0] += 1.9f;
                }
                else if (this.type == 97)
                {
                    this.spriteDirection = -this.direction;
                    if ((double)this.ai[0] == 0.0)
                    {
                        this.ai[0] = 3f;
                        this.netUpdate = true;
                    }
                    if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
                        this.ai[0] -= 1.6f;
                    else
                        this.ai[0] += 1.4f;
                }
                this.position += this.velocity * this.ai[0];
                if (Main.player[this.owner].itemAnimation == 0)
                    this.Kill();
                this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 2.355f;
                if (this.spriteDirection == -1)
                    this.rotation -= 1.57f;
                if (this.type == 46)
                {
                    if (Main.rand.Next(5) == 0)
                        Dust.NewDust(this.position, this.width, this.height, 14, 0.0f, 0.0f, 150, new Color(), 1.4f);
                    int index1 = Dust.NewDust(this.position, this.width, this.height, 27, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, new Color(), 1.2f);
                    Main.dust[index1].noGravity = true;
                    Main.dust[index1].velocity.X /= 2f;
                    Main.dust[index1].velocity.Y /= 2f;
                    int index2 = Dust.NewDust(this.position - this.velocity * 2f, this.width, this.height, 27, 0.0f, 0.0f, 150, new Color(), 1.4f);
                    Main.dust[index2].velocity.X /= 5f;
                    Main.dust[index2].velocity.Y /= 5f;
                }
                else
                {
                    if (this.type != 105)
                        return;
                    if (Main.rand.Next(3) == 0)
                    {
                        int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 57, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 200, new Color(), 1.2f);
                        Main.dust[index].velocity += this.velocity * 0.3f;
                        Main.dust[index].velocity *= 0.2f;
                    }
                    if (Main.rand.Next(4) != 0)
                        return;
                    int index1 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 43, 0.0f, 0.0f, 254, new Color(), 0.3f);
                    Main.dust[index1].velocity += this.velocity * 0.5f;
                    Main.dust[index1].velocity *= 0.5f;
                }
            }
            else if (this.aiStyle == 20)
            {
                if (this.soundDelay <= 0)
                {
                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 22);
                    this.soundDelay = 30;
                }
                if (Main.myPlayer == this.owner)
                {
                    if (Main.player[this.owner].channel)
                    {
                        float num1 = Main.player[this.owner].inventory[Main.player[this.owner].selectedItem].shootSpeed * this.scale;
                        Vector2 vector2 = new Vector2(Main.player[this.owner].position.X + (float)Main.player[this.owner].width * 0.5f, Main.player[this.owner].position.Y + (float)Main.player[this.owner].height * 0.5f);
                        float num2 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
                        float num3 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
                        float num4 = (float)Math.Sqrt((double)num2 * (double)num2 + (double)num3 * (double)num3);
                        float num5 = (float)Math.Sqrt((double)num2 * (double)num2 + (double)num3 * (double)num3);
                        float num6 = num1 / num5;
                        float num7 = num2 * num6;
                        float num8 = num3 * num6;
                        if ((double)num7 != (double)this.velocity.X || (double)num8 != (double)this.velocity.Y)
                            this.netUpdate = true;
                        this.velocity.X = num7;
                        this.velocity.Y = num8;
                    }
                    else
                        this.Kill();
                }
                if ((double)this.velocity.X > 0.0)
                    Main.player[this.owner].direction = 1;
                else if ((double)this.velocity.X < 0.0)
                    Main.player[this.owner].direction = -1;
                this.spriteDirection = this.direction;
                Main.player[this.owner].direction = this.direction;
                Main.player[this.owner].heldProj = this.whoAmI;
                Main.player[this.owner].itemTime = 2;
                Main.player[this.owner].itemAnimation = 2;
                this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
                this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
                this.rotation = (float)(Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57000005245209);
                Main.player[this.owner].itemRotation = Main.player[this.owner].direction != 1 ? (float)Math.Atan2((double)this.velocity.Y * (double)this.direction, (double)this.velocity.X * (double)this.direction) : (float)Math.Atan2((double)this.velocity.Y * (double)this.direction, (double)this.velocity.X * (double)this.direction);
                this.velocity.X *= (float)(1.0 + (double)Main.rand.Next(-3, 4) * 0.00999999977648258);
                if (Main.rand.Next(6) != 0)
                    return;
                int index = Dust.NewDust(this.position + this.velocity * (float)Main.rand.Next(6, 10) * 0.1f, this.width, this.height, 31, 0.0f, 0.0f, 80, new Color(), 1.4f);
                Main.dust[index].position.X -= 4f;
                Main.dust[index].noGravity = true;
                Main.dust[index].velocity *= 0.2f;
                Main.dust[index].velocity.Y = (float)-Main.rand.Next(7, 13) * 0.15f;
            }
            else if (this.aiStyle == 21)
            {
                this.rotation = this.velocity.X * 0.1f;
                this.spriteDirection = -this.direction;
                if (Main.rand.Next(3) == 0)
                {
                    int index = Dust.NewDust(this.position, this.width, this.height, 27, 0.0f, 0.0f, 80, new Color(), 1f);
                    Main.dust[index].noGravity = true;
                    Main.dust[index].velocity *= 0.2f;
                }
                if ((double)this.ai[1] != 1.0)
                    return;
                this.ai[1] = 0.0f;
                Main.harpNote = this.ai[0];
                Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 26);
            }
            else if (this.aiStyle == 22)
            {
                if ((double)this.velocity.X == 0.0 && (double)this.velocity.Y == 0.0)
                    this.alpha = (int)byte.MaxValue;
                if ((double)this.ai[1] < 0.0)
                {
                    if ((double)this.velocity.X > 0.0)
                        this.rotation += 0.3f;
                    else
                        this.rotation -= 0.3f;
                    int num1 = (int)((double)this.position.X / 16.0) - 1;
                    int num2 = (int)(((double)this.position.X + (double)this.width) / 16.0) + 2;
                    int num3 = (int)((double)this.position.Y / 16.0) - 1;
                    int num4 = (int)(((double)this.position.Y + (double)this.height) / 16.0) + 2;
                    if (num1 < 0)
                        num1 = 0;
                    if (num2 > Main.maxTilesX)
                        num2 = Main.maxTilesX;
                    if (num3 < 0)
                        num3 = 0;
                    if (num4 > Main.maxTilesY)
                        num4 = Main.maxTilesY;
                    int num5 = (int)this.position.X + 4;
                    int num6 = (int)this.position.Y + 4;
                    for (int index1 = num1; index1 < num2; ++index1)
                    {
                        for (int index2 = num3; index2 < num4; ++index2)
                        {
                            if (Main.tile[index1, index2] != null && Main.tile[index1, index2].active && ((int)Main.tile[index1, index2].type != (int)sbyte.MaxValue && Main.tileSolid[(int)Main.tile[index1, index2].type]) && !Main.tileSolidTop[(int)Main.tile[index1, index2].type])
                            {
                                Vector2 vector2;
                                vector2.X = (float)(index1 * 16);
                                vector2.Y = (float)(index2 * 16);
                                if ((double)(num5 + 8) > (double)vector2.X && (double)num5 < (double)vector2.X + 16.0 && ((double)(num6 + 8) > (double)vector2.Y && (double)num6 < (double)vector2.Y + 16.0))
                                    this.Kill();
                            }
                        }
                    }
                    int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0.0f, 0.0f, 0, new Color(), 1f);
                    Main.dust[index].noGravity = true;
                    Main.dust[index].velocity *= 0.3f;
                }
                else if ((double)this.ai[0] < 0.0)
                {
                    if ((double)this.ai[0] == -1.0)
                    {
                        for (int index1 = 0; index1 < 10; ++index1)
                        {
                            int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0.0f, 0.0f, 0, new Color(), 1.1f);
                            Main.dust[index2].noGravity = true;
                            Main.dust[index2].velocity *= 1.3f;
                        }
                    }
                    else if (Main.rand.Next(30) == 0)
                    {
                        int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0.0f, 0.0f, 100, new Color(), 1f);
                        Main.dust[index].velocity *= 0.2f;
                    }
                    int i = (int)this.position.X / 16;
                    int j = (int)this.position.Y / 16;
                    if (Main.tile[i, j] == null || !Main.tile[i, j].active)
                        this.Kill();
                    --this.ai[0];
                    if ((double)this.ai[0] > -300.0 || Main.myPlayer != this.owner && Main.netMode != 2 || (!Main.tile[i, j].active || (int)Main.tile[i, j].type != (int)sbyte.MaxValue))
                        return;
                    WorldGen.KillTile(i, j, false, false, false);
                    if (Main.netMode == 1)
                        NetMessage.SendData(17, -1, -1, "", 0, (float)i, (float)j, 0.0f, 0);
                    this.Kill();
                }
                else
                {
                    int num1 = (int)((double)this.position.X / 16.0) - 1;
                    int num2 = (int)(((double)this.position.X + (double)this.width) / 16.0) + 2;
                    int num3 = (int)((double)this.position.Y / 16.0) - 1;
                    int num4 = (int)(((double)this.position.Y + (double)this.height) / 16.0) + 2;
                    if (num1 < 0)
                        num1 = 0;
                    if (num2 > Main.maxTilesX)
                        num2 = Main.maxTilesX;
                    if (num3 < 0)
                        num3 = 0;
                    if (num4 > Main.maxTilesY)
                        num4 = Main.maxTilesY;
                    int num5 = (int)this.position.X + 4;
                    int num6 = (int)this.position.Y + 4;
                    for (int index1 = num1; index1 < num2; ++index1)
                    {
                        for (int index2 = num3; index2 < num4; ++index2)
                        {
                            if (Main.tile[index1, index2] != null && Main.tile[index1, index2].active && ((int)Main.tile[index1, index2].type != (int)sbyte.MaxValue && Main.tileSolid[(int)Main.tile[index1, index2].type]) && !Main.tileSolidTop[(int)Main.tile[index1, index2].type])
                            {
                                Vector2 vector2;
                                vector2.X = (float)(index1 * 16);
                                vector2.Y = (float)(index2 * 16);
                                if ((double)(num5 + 8) > (double)vector2.X && (double)num5 < (double)vector2.X + 16.0 && ((double)(num6 + 8) > (double)vector2.Y && (double)num6 < (double)vector2.Y + 16.0))
                                    this.Kill();
                            }
                        }
                    }
                    if (this.lavaWet)
                        this.Kill();
                    if (!this.active)
                        return;
                    int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, 0.0f, 0.0f, 0, new Color(), 1f);
                    Main.dust[index].noGravity = true;
                    Main.dust[index].velocity *= 0.3f;
                    int i = (int)this.ai[0];
                    int j = (int)this.ai[1];
                    if ((double)this.velocity.X > 0.0)
                        this.rotation += 0.3f;
                    else
                        this.rotation -= 0.3f;
                    if (Main.myPlayer != this.owner)
                        return;
                    int num7 = (int)(((double)this.position.X + (double)(this.width / 2)) / 16.0);
                    int num8 = (int)(((double)this.position.Y + (double)(this.height / 2)) / 16.0);
                    bool flag = false;
                    if (num7 == i && num8 == j)
                        flag = true;
                    if (((double)this.velocity.X <= 0.0 && num7 <= i || (double)this.velocity.X >= 0.0 && num7 >= i) && ((double)this.velocity.Y <= 0.0 && num8 <= j || (double)this.velocity.Y >= 0.0 && num8 >= j))
                        flag = true;
                    if (!flag)
                        return;
                    if (WorldGen.PlaceTile(i, j, (int)sbyte.MaxValue, false, false, this.owner, 0))
                    {
                        if (Main.netMode == 1)
                            NetMessage.SendData(17, -1, -1, "", 1, (float)(int)this.ai[0], (float)(int)this.ai[1], (float)sbyte.MaxValue, 0);
                        this.damage = 0;
                        this.ai[0] = -1f;
                        this.velocity *= 0.0f;
                        this.alpha = (int)byte.MaxValue;
                        this.position.X = (float)(i * 16);
                        this.position.Y = (float)(j * 16);
                        this.netUpdate = true;
                    }
                    else
                        this.ai[1] = -1f;
                }
            }
            else if (this.aiStyle == 23)
            {
                if (this.timeLeft > 60)
                    this.timeLeft = 60;
                if ((double)this.ai[0] > 7.0)
                {
                    float num = 1f;
                    if ((double)this.ai[0] == 8.0)
                        num = 0.25f;
                    else if ((double)this.ai[0] == 9.0)
                        num = 0.5f;
                    else if ((double)this.ai[0] == 10.0)
                        num = 0.75f;
                    ++this.ai[0];
                    int Type = 6;
                    if (this.type == 101)
                        Type = 75;
                    if (Type == 6 || Main.rand.Next(2) == 0)
                    {
                        for (int index1 = 0; index1 < 1; ++index1)
                        {
                            int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, Type, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, new Color(), 1f);
                            if (Main.rand.Next(3) != 0 || Type == 75 && Main.rand.Next(3) == 0)
                            {
                                Main.dust[index2].noGravity = true;
                                Main.dust[index2].scale *= 3f;
                                Main.dust[index2].velocity.X *= 2f;
                                Main.dust[index2].velocity.Y *= 2f;
                            }
                            Main.dust[index2].scale *= 1.5f;
                            Main.dust[index2].velocity.X *= 1.2f;
                            Main.dust[index2].velocity.Y *= 1.2f;
                            Main.dust[index2].scale *= num;
                            if (Type == 75)
                            {
                                Main.dust[index2].velocity += this.velocity;
                                if (!Main.dust[index2].noGravity)
                                    Main.dust[index2].velocity *= 0.5f;
                            }
                        }
                    }
                }
                else
                    ++this.ai[0];
                this.rotation += 0.3f * (float)this.direction;
            }
            else if (this.aiStyle == 24)
            {
                this.light = this.scale * 0.5f;
                this.rotation += this.velocity.X * 0.2f;
                ++this.ai[1];
                if (this.type == 94)
                {
                    if (Main.rand.Next(4) == 0)
                    {
                        int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 70, 0.0f, 0.0f, 0, new Color(), 1f);
                        Main.dust[index].noGravity = true;
                        Main.dust[index].velocity *= 0.5f;
                        Main.dust[index].scale *= 0.9f;
                    }
                    this.velocity *= 0.985f;
                    if ((double)this.ai[1] <= 130.0)
                        return;
                    this.scale -= 0.05f;
                    if ((double)this.scale > 0.2)
                        return;
                    this.scale = 0.2f;
                    this.Kill();
                }
                else
                {
                    this.velocity *= 0.96f;
                    if ((double)this.ai[1] <= 15.0)
                        return;
                    this.scale -= 0.05f;
                    if ((double)this.scale > 0.2)
                        return;
                    this.scale = 0.2f;
                    this.Kill();
                }
            }
            else if (this.aiStyle == 25)
            {
                if ((double)this.ai[0] != 0.0 && (double)this.velocity.Y <= 0.0 && (double)this.velocity.X == 0.0)
                {
                    float num = 0.5f;
                    int i1 = (int)(((double)this.position.X - 8.0) / 16.0);
                    int j1 = (int)((double)this.position.Y / 16.0);
                    bool flag1 = false;
                    bool flag2 = false;
                    if (WorldGen.SolidTile(i1, j1) || WorldGen.SolidTile(i1, j1 + 1))
                        flag1 = true;
                    int i2 = (int)(((double)this.position.X + (double)this.width + 8.0) / 16.0);
                    if (WorldGen.SolidTile(i2, j1) || WorldGen.SolidTile(i2, j1 + 1))
                        flag2 = true;
                    if (flag1)
                        this.velocity.X = num;
                    else if (flag2)
                    {
                        this.velocity.X = -num;
                    }
                    else
                    {
                        int i3 = (int)(((double)this.position.X - 8.0 - 16.0) / 16.0);
                        int j2 = (int)((double)this.position.Y / 16.0);
                        bool flag3 = false;
                        bool flag4 = false;
                        if (WorldGen.SolidTile(i3, j2) || WorldGen.SolidTile(i3, j2 + 1))
                            flag3 = true;
                        int i4 = (int)(((double)this.position.X + (double)this.width + 8.0 + 16.0) / 16.0);
                        if (WorldGen.SolidTile(i4, j2) || WorldGen.SolidTile(i4, j2 + 1))
                            flag4 = true;
                        if (flag3)
                            this.velocity.X = num;
                        else if (flag4)
                        {
                            this.velocity.X = -num;
                        }
                        else
                        {
                            int i5 = (int)(((double)this.position.X + 4.0) / 16.0);
                            int j3 = (int)(((double)this.position.Y + (double)this.height + 8.0) / 16.0);
                            if (WorldGen.SolidTile(i5, j3) || WorldGen.SolidTile(i5, j3 + 1))
                                flag3 = true;
                            this.velocity.X = flag3 ? -num : num;
                        }
                    }
                }
                this.rotation += this.velocity.X * 0.06f;
                this.ai[0] = 1f;
                if ((double)this.velocity.Y > 16.0)
                    this.velocity.Y = 16f;
                if ((double)this.velocity.Y <= 6.0)
                {
                    if ((double)this.velocity.X > 0.0 && (double)this.velocity.X < 7.0)
                        this.velocity.X += 0.05f;
                    if ((double)this.velocity.X < 0.0 && (double)this.velocity.X > -7.0)
                        this.velocity.X -= 0.05f;
                }
                this.velocity.Y += 0.3f;
            }
            else
            {
                if (this.aiStyle != 26)
                    return;
                bool flag1 = false;
                bool flag2 = false;
                bool flag3 = false;
                bool flag4 = false;
                int num1 = 60;
                if (Main.myPlayer == this.owner)
                {
                    if (Main.player[Main.myPlayer].dead)
                        Main.player[Main.myPlayer].bunny = false;
                    if (Main.player[Main.myPlayer].bunny)
                        this.timeLeft = 2;
                }
                if ((double)Main.player[this.owner].position.X + (double)(Main.player[this.owner].width / 2) < (double)this.position.X + (double)(this.width / 2) - (double)num1)
                    flag1 = true;
                else if ((double)Main.player[this.owner].position.X + (double)(Main.player[this.owner].width / 2) > (double)this.position.X + (double)(this.width / 2) + (double)num1)
                    flag2 = true;
                if (Main.player[this.owner].rocketDelay2 > 0)
                    this.ai[0] = 1f;
                Vector2 vector2_1 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                float num2 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector2_1.X;
                float num3 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector2_1.Y;
                float num4 = (float)Math.Sqrt((double)num2 * (double)num2 + (double)num3 * (double)num3);
                if ((double)num4 > 2000.0)
                {
                    this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
                    this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
                }
                else if ((double)num4 > 500.0 || (double)Math.Abs(num3) > 300.0)
                {
                    this.ai[0] = 1f;
                    if ((double)num3 > 0.0 && (double)this.velocity.Y < 0.0)
                        this.velocity.Y = 0.0f;
                    if ((double)num3 < 0.0 && (double)this.velocity.Y > 0.0)
                        this.velocity.Y = 0.0f;
                }
                if ((double)this.ai[0] != 0.0)
                {
                    this.tileCollide = false;
                    Vector2 vector2_2 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                    float num5 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector2_2.X;
                    float num6 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector2_2.Y;
                    float num7 = (float)Math.Sqrt((double)num5 * (double)num5 + (double)num6 * (double)num6);
                    float num8 = 10f;
                    if ((double)num7 < 200.0 && (double)Main.player[this.owner].velocity.Y == 0.0 && ((double)this.position.Y + (double)this.height <= (double)Main.player[this.owner].position.Y + (double)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height)))
                    {
                        this.ai[0] = 0.0f;
                        if ((double)this.velocity.Y < -6.0)
                            this.velocity.Y = -6f;
                    }
                    float num9;
                    float num10;
                    if ((double)num7 < 60.0)
                    {
                        num9 = this.velocity.X;
                        num10 = this.velocity.Y;
                    }
                    else
                    {
                        float num11 = num8 / num7;
                        num9 = num5 * num11;
                        num10 = num6 * num11;
                    }
                    if ((double)this.velocity.X < (double)num9)
                    {
                        this.velocity.X += 0.2f;
                        if ((double)this.velocity.X < 0.0)
                            this.velocity.X += 0.3f;
                    }
                    if ((double)this.velocity.X > (double)num9)
                    {
                        this.velocity.X -= 0.2f;
                        if ((double)this.velocity.X > 0.0)
                            this.velocity.X -= 0.3f;
                    }
                    if ((double)this.velocity.Y < (double)num10)
                    {
                        this.velocity.Y += 0.2f;
                        if ((double)this.velocity.Y < 0.0)
                            this.velocity.Y += 0.3f;
                    }
                    if ((double)this.velocity.Y > (double)num10)
                    {
                        this.velocity.Y -= 0.2f;
                        if ((double)this.velocity.Y > 0.0)
                            this.velocity.Y -= 0.3f;
                    }
                    this.frame = 7;
                    if ((double)this.velocity.X > 0.5)
                        this.spriteDirection = -1;
                    else if ((double)this.velocity.X < -0.5)
                        this.spriteDirection = 1;
                    this.rotation = this.spriteDirection != -1 ? (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 3.14f : (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X);
                    int index = Dust.NewDust(new Vector2((float)((double)this.position.X + (double)(this.width / 2) - 4.0), (float)((double)this.position.Y + (double)(this.height / 2) - 4.0)) - this.velocity, 8, 8, 16, (float)(-(double)this.velocity.X * 0.5), this.velocity.Y * 0.5f, 50, new Color(), 1.7f);
                    Main.dust[index].velocity.X = Main.dust[index].velocity.X * 0.2f;
                    Main.dust[index].velocity.Y = Main.dust[index].velocity.Y * 0.2f;
                    Main.dust[index].noGravity = true;
                }
                else
                {
                    this.rotation = 0.0f;
                    this.tileCollide = true;
                    if (flag1)
                    {
                        if ((double)this.velocity.X > -3.5)
                            this.velocity.X -= 0.08f;
                        else
                            this.velocity.X -= 0.02f;
                    }
                    else if (flag2)
                    {
                        if ((double)this.velocity.X < 3.5)
                            this.velocity.X += 0.08f;
                        else
                            this.velocity.X += 0.02f;
                    }
                    else
                    {
                        this.velocity.X *= 0.9f;
                        if ((double)this.velocity.X >= -0.08 && (double)this.velocity.X <= 0.08)
                            this.velocity.X = 0.0f;
                    }
                    if (flag1 || flag2)
                    {
                        int num5 = (int)((double)this.position.X + (double)(this.width / 2)) / 16;
                        int j = (int)((double)this.position.Y + (double)(this.width / 2)) / 16;
                        if (flag1)
                            --num5;
                        if (flag2)
                            ++num5;
                        if (WorldGen.SolidTile(num5 + (int)this.velocity.X, j))
                            flag4 = true;
                    }
                    if ((double)Main.player[this.owner].position.Y + (double)Main.player[this.owner].height > (double)this.position.Y + (double)this.height)
                        flag3 = true;
                    if ((double)this.velocity.Y == 0.0)
                    {
                        if (!flag3 && ((double)this.velocity.X < 0.0 || (double)this.velocity.X > 0.0))
                        {
                            int i = (int)((double)this.position.X + (double)(this.width / 2)) / 16;
                            int j = (int)((double)this.position.Y + (double)(this.height / 2)) / 16 + 1;
                            if (flag1)
                                --i;
                            if (flag2)
                                ++i;
                            if (!WorldGen.SolidTile(i, j))
                                flag4 = true;
                        }
                        if (flag4 && WorldGen.SolidTile((int)((double)this.position.X + (double)(this.width / 2)) / 16, (int)((double)this.position.Y + (double)(this.height / 2)) / 16 + 1))
                            this.velocity.Y = -9.1f;
                    }
                    if ((double)this.velocity.X > 6.5)
                        this.velocity.X = 6.5f;
                    if ((double)this.velocity.X < -6.5)
                        this.velocity.X = -6.5f;
                    if ((double)this.velocity.X > 0.07 && flag2)
                        this.direction = 1;
                    if ((double)this.velocity.X < -0.07 && flag1)
                        this.direction = -1;
                    if (this.direction == -1)
                        this.spriteDirection = 1;
                    if (this.direction == 1)
                        this.spriteDirection = -1;
                    if ((double)this.velocity.Y == 0.0)
                    {
                        if ((double)this.velocity.X == 0.0)
                        {
                            this.frame = 0;
                            this.frameCounter = 0;
                        }
                        else if ((double)this.velocity.X < -0.8 || (double)this.velocity.X > 0.8)
                        {
                            this.frameCounter = this.frameCounter + (int)Math.Abs(this.velocity.X);
                            ++this.frameCounter;
                            if (this.frameCounter > 6)
                            {
                                ++this.frame;
                                this.frameCounter = 0;
                            }
                            if (this.frame >= 7)
                                this.frame = 0;
                        }
                        else
                        {
                            this.frame = 0;
                            this.frameCounter = 0;
                        }
                    }
                    else if ((double)this.velocity.Y < 0.0)
                    {
                        this.frameCounter = 0;
                        this.frame = 4;
                    }
                    else if ((double)this.velocity.Y > 0.0)
                    {
                        this.frameCounter = 0;
                        this.frame = 6;
                    }
                    this.velocity.Y += 0.4f;
                    if ((double)this.velocity.Y <= 10.0)
                        return;
                    this.velocity.Y = 10f;
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
            else if (this.type == 111)
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
                    int index = Projectile.NewProjectile(num1, num2, SpeedX, SpeedY, 92, Damage, this.knockBack, this.owner);
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
                        Projectile.NewProjectile(this.position.X + SpeedX, this.position.Y + SpeedY, SpeedX, SpeedY, 90, (int)((double)this.damage * 0.6), 0.0f, this.owner);
                    }
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
                if ((int)Main.tile[i, j].type == (int)sbyte.MaxValue && Main.tile[i, j].active)
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
            else if (this.type == 51)
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
            else if (this.type == 14 || this.type == 20 || (this.type == 36 || this.type == 83) || (this.type == 84 || this.type == 100 || this.type == 110))
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
                    int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 29, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 100, new Color(), 3f);
                    Main.dust[index2].noGravity = true;
                    Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 29, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 100, new Color(), 2f);
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
            else if (this.type == 28 || this.type == 30 || (this.type == 37 || this.type == 75) || this.type == 102)
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
            if (this.owner == Main.myPlayer)
            {
                if (this.type == 28 || this.type == 29 || (this.type == 37 || this.type == 75) || this.type == 108)
                {
                    int num1 = 3;
                    if (this.type == 29)
                        num1 = 7;
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
                                if (Main.tile[i1, j1] != null && Main.tile[i1, j1].active)
                                {
                                    flag2 = true;
                                    if (Main.tileDungeon[(int)Main.tile[i1, j1].type] || (int)Main.tile[i1, j1].type == 21 || ((int)Main.tile[i1, j1].type == 26 || (int)Main.tile[i1, j1].type == 107) || ((int)Main.tile[i1, j1].type == 108 || (int)Main.tile[i1, j1].type == 111))
                                        flag2 = false;
                                    if (!Main.hardMode && (int)Main.tile[i1, j1].type == 58)
                                        flag2 = false;
                                    if (flag2)
                                    {
                                        WorldGen.KillTile(i1, j1, false, false, false);
                                        if (!Main.tile[i1, j1].active && Main.netMode != 0)
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
                    if (!Main.tile[i, j].active)
                    {
                        WorldGen.PlaceTile(i, j, type, false, true, -1, 0);
                        if (Main.tile[i, j].active && (int)Main.tile[i, j].type == type)
                            NetMessage.SendData(17, -1, -1, "", 1, (float)i, (float)j, (float)type, 0);
                        else if (Type > 0)
                            number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, Type, 1, false, 0);
                    }
                    else if (Type > 0)
                        number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, Type, 1, false, 0);
                }
                if (this.type == 1 && Main.rand.Next(3) == 0)
                    number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0);
                if (this.type == 103 && Main.rand.Next(6) == 0)
                    number = Main.rand.Next(3) != 0 ? Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0) : Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 545, 1, false, 0);
                if (this.type == 2 && Main.rand.Next(3) == 0)
                    number = Main.rand.Next(3) != 0 ? Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0) : Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 41, 1, false, 0);
                if (this.type == 91 && Main.rand.Next(6) == 0)
                    number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 516, 1, false, 0);
                if (this.type == 50 && Main.rand.Next(3) == 0)
                    number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 282, 1, false, 0);
                if (this.type == 53 && Main.rand.Next(3) == 0)
                    number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 286, 1, false, 0);
                if (this.type == 48 && Main.rand.Next(2) == 0)
                    number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 279, 1, false, 0);
                if (this.type == 54 && Main.rand.Next(2) == 0)
                    number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 287, 1, false, 0);
                if (this.type == 3 && Main.rand.Next(2) == 0)
                    number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 42, 1, false, 0);
                if (this.type == 4 && Main.rand.Next(4) == 0)
                    number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 47, 1, false, 0);
                if (this.type == 12 && this.damage > 100)
                    number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 75, 1, false, 0);
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
                                    else if ((int)Main.tile[index1, index2].type == 1)
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
                                }
                                else if ((int)Main.tile[index1, index2].type == 2)
                                {
                                    Main.tile[index1, index2].type = (byte)23;
                                    WorldGen.SquareTileFrame(index1, index2, true);
                                    NetMessage.SendTileSquare(-1, index1, index2, 1);
                                }
                                else if ((int)Main.tile[index1, index2].type == 1)
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
                            }
                        }
                    }
                }
                if (this.type == 21 && Main.rand.Next(2) == 0)
                    number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 154, 1, false, 0);
                if (Main.netMode == 1 && number >= 0)
                    NetMessage.SendData(21, -1, -1, "", number, 0.0f, 0.0f, 0.0f, 0);
            }
            this.active = false;
        }
		public Color GetAlpha(Color newColor)
		{
			if (this.type == 34 || this.type == 15 || this.type == 93 || this.type == 94 || this.type == 95 || this.type == 96 || (this.type == 102 && this.alpha < 255))
			{
				return new Color(200, 200, 200, 25);
			}
			if (this.type == 83 || this.type == 88 || this.type == 89 || this.type == 90 || this.type == 100 || this.type == 104)
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
				int r;
				int g;
				int b;
				if (this.type == 79)
				{
					r = Main.DiscoR;
					g = Main.DiscoG;
					b = Main.DiscoB;
					return default(Color);
				}
				if (this.type == 9 || this.type == 15 || this.type == 34 || this.type == 50 || this.type == 53 || this.type == 76 || this.type == 77 || this.type == 78 || this.type == 92 || this.type == 91)
				{
					r = (int)newColor.R - this.alpha / 3;
					g = (int)newColor.G - this.alpha / 3;
					b = (int)newColor.B - this.alpha / 3;
				}
				else
				{
					if (this.type == 16 || this.type == 18 || this.type == 44 || this.type == 45)
					{
						r = (int)newColor.R;
						g = (int)newColor.G;
						b = (int)newColor.B;
					}
					else
					{
						if (this.type == 12 || this.type == 72 || this.type == 86 || this.type == 87)
						{
							return new Color(255, 255, 255, (int)newColor.A - this.alpha);
						}
						r = (int)newColor.R - this.alpha;
						g = (int)newColor.G - this.alpha;
						b = (int)newColor.B - this.alpha;
					}
				}
				int num = (int)newColor.A - this.alpha;
				if (num < 0)
				{
					num = 0;
				}
				if (num > 255)
				{
					num = 255;
				}
				return new Color(r, g, b, num);
			}
		}
	}
}
