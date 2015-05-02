using System;
using XNA;

namespace Terraria
{
	public class Mount
	{
		private class MountData
		{
			public int textureWidth;
			public int textureHeight;
			public int xOffset;
			public int yOffset;
			public int[] playerYOffsets;
			public int bodyFrame;
			public int playerHeadOffset;
			public int heightBoost;
			public int buff;
			public int extraBuff;
			public int flightTimeMax;
			public float runSpeed;
			public float dashSpeed;
			public float swimSpeed;
			public float acceleration;
			public float jumpSpeed;
			public int jumpHeight;
			public float fallDamage;
			public int fatigueMax;
			public bool constantJump;
			public bool blockExtraJumps;
			public int spawnDust;
			public int totalFrames;
			public int standingFrameStart;
			public int standingFrameCount;
			public int standingFrameDelay;
			public int runningFrameStart;
			public int runningFrameCount;
			public int runningFrameDelay;
			public int flyingFrameStart;
			public int flyingFrameCount;
			public int flyingFrameDelay;
			public int inAirFrameStart;
			public int inAirFrameCount;
			public int inAirFrameDelay;
			public int idleFrameStart;
			public int idleFrameCount;
			public int idleFrameDelay;
			public bool idleFrameLoop;
			public int swimFrameStart;
			public int swimFrameCount;
			public int swimFrameDelay;
		}
		public const int None = -1;
		public const int Rudolph = 0;
		public const int Bunny = 1;
		public const int Pigron = 2;
		public const int Slime = 3;
		public const int Turtle = 4;
		public const int Bee = 5;
		public const int Minecart = 6;
		public const int maxMounts = 7;
		public const int FrameStanding = 0;
		public const int FrameRunning = 1;
		public const int FrameInAir = 2;
		public const int FrameFlying = 3;
		public const int FrameSwimming = 4;
		private static Mount.MountData[] mounts;
		private Mount.MountData _data;
		private int _type;
		private bool _flipDraw;
		private int _frame;
		private float _frameCounter;
		private int _frameExtra;
		private float _frameExtraCounter;
		private int _frameState;
		private int _flyTime;
		private int _idleTime;
		private int _idleTimeNext;
		private float _fatigue;
		private float _fatigueMax;
		private bool _active;
		public bool Active
		{
			get
			{
				return this._active;
			}
		}
		public int Type
		{
			get
			{
				return this._type;
			}
		}
		public int FlyTime
		{
			get
			{
				return this._flyTime;
			}
		}
		public int BuffType
		{
			get
			{
				return this._data.buff;
			}
		}
		public bool FlipDraw
		{
			get
			{
				return this._flipDraw;
			}
		}
		public int BodyFrame
		{
			get
			{
				return this._data.bodyFrame;
			}
		}
		public int XOffset
		{
			get
			{
				return this._data.xOffset;
			}
		}
		public int YOffset
		{
			get
			{
				return this._data.yOffset;
			}
		}
		public int PlayerOffset
		{
			get
			{
				if (!this._active)
				{
					return 0;
				}
				return this._data.playerYOffsets[this._frame];
			}
		}
		public int PlayerHeadOffset
		{
			get
			{
				if (!this._active)
				{
					return 0;
				}
				return this._data.playerHeadOffset;
			}
		}
		public int HeightBoost
		{
			get
			{
				return this._data.heightBoost;
			}
		}
		public float RunSpeed
		{
			get
			{
				if (this._type == 4 && this._frameState == 4)
				{
					return this._data.swimSpeed;
				}
				if (this._type == 5 && this._frameState == 2)
				{
					float num = this._fatigue / this._fatigueMax;
					return this._data.runSpeed + 4f * (1f - num);
				}
				return this._data.runSpeed;
			}
		}
		public float DashSpeed
		{
			get
			{
				return this._data.dashSpeed;
			}
		}
		public float Acceleration
		{
			get
			{
				return this._data.acceleration;
			}
		}
		public float FallDamage
		{
			get
			{
				return this._data.fallDamage;
			}
		}
		public bool AutoJump
		{
			get
			{
				return this._data.constantJump;
			}
		}
		public bool BlockExtraJumps
		{
			get
			{
				return this._data.blockExtraJumps;
			}
		}
		public Rectangle FrameRect
		{
			get
			{
				int num = this._data.textureHeight / this._data.totalFrames;
				return new Rectangle(0, num * this._frame, this._data.textureWidth, num);
			}
		}
		public Rectangle FrameRectExtra
		{
			get
			{
				int num = this._data.textureHeight / this._data.totalFrames;
				if (this._type == 5)
				{
					return new Rectangle(0, num * this._frameExtra, this._data.textureWidth, num);
				}
				return new Rectangle(0, num * this._frame, this._data.textureWidth, num);
			}
		}
		public Vector2 Origin
		{
			get
			{
				return new Vector2((float)this._data.textureWidth / 2f, (float)this._data.textureHeight / (2f * (float)this._data.totalFrames));
			}
		}
		public bool CanFly
		{
			get
			{
				return this._active && this._data.flightTimeMax != 0;
			}
		}
		public Mount()
		{
			this.Reset();
		}
		public void Reset()
		{
			this._active = false;
			this._type = -1;
			this._frame = 0;
			this._frameCounter = 0f;
			this._frameExtra = 0;
			this._frameExtraCounter = 0f;
			this._frameState = 0;
			this._flyTime = 0;
			this._idleTime = 0;
			this._idleTimeNext = -1;
			this._fatigueMax = 0f;
		}
		public static void Initialize()
		{
			Mount.mounts = new Mount.MountData[7];
			Mount.MountData mountData = new Mount.MountData();
			Mount.mounts[0] = mountData;
			mountData.spawnDust = 57;
			mountData.buff = 90;
			mountData.heightBoost = 20;
			mountData.flightTimeMax = 160;
			mountData.runSpeed = 5.5f;
			mountData.dashSpeed = 12f;
			mountData.acceleration = 0.09f;
			mountData.jumpHeight = 17;
			mountData.jumpSpeed = 5.31f;
			/*if (Main.netMode != 2)
			{
				mountData.backTexture = Main.rudolphMountTexture[0];
				mountData.backTextureExtra = null;
				mountData.frontTexture = Main.rudolphMountTexture[1];
				mountData.frontTextureExtra = Main.rudolphMountTexture[2];
				mountData.textureWidth = mountData.backTexture.Width;
				mountData.textureHeight = mountData.backTexture.Height;
				mountData.totalFrames = 12;
				int[] array = new int[mountData.totalFrames];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = 30;
				}
				array[1] += 2;
				array[11] += 2;
				mountData.playerYOffsets = array;
				mountData.xOffset = 13;
				mountData.bodyFrame = 3;
				mountData.yOffset = -7;
				mountData.playerHeadOffset = 22;
				mountData.standingFrameCount = 1;
				mountData.standingFrameDelay = 12;
				mountData.standingFrameStart = 0;
				mountData.runningFrameCount = 6;
				mountData.runningFrameDelay = 12;
				mountData.runningFrameStart = 6;
				mountData.flyingFrameCount = 6;
				mountData.flyingFrameDelay = 6;
				mountData.flyingFrameStart = 6;
				mountData.inAirFrameCount = 1;
				mountData.inAirFrameDelay = 12;
				mountData.inAirFrameStart = 1;
				mountData.idleFrameCount = 4;
				mountData.idleFrameDelay = 30;
				mountData.idleFrameStart = 2;
				mountData.idleFrameLoop = true;
			}*/
			mountData = new Mount.MountData();
			Mount.mounts[2] = mountData;
			mountData.spawnDust = 58;
			mountData.buff = 129;
			mountData.heightBoost = 20;
			mountData.flightTimeMax = 160;
			mountData.runSpeed = 5f;
			mountData.dashSpeed = 9f;
			mountData.acceleration = 0.08f;
			mountData.jumpHeight = 10;
			mountData.jumpSpeed = 6.01f;
			/*if (Main.netMode != 2)
			{
				mountData.backTexture = Main.pigronMountTexture;
				mountData.backTextureExtra = null;
				mountData.frontTexture = null;
				mountData.frontTextureExtra = null;
				mountData.textureWidth = mountData.backTexture.Width;
				mountData.textureHeight = mountData.backTexture.Height;
				mountData.totalFrames = 16;
				int[] array = new int[mountData.totalFrames];
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = 22;
				}
				array[12] += 2;
				array[13] += 4;
				array[14] += 2;
				mountData.playerYOffsets = array;
				mountData.xOffset = 1;
				mountData.bodyFrame = 3;
				mountData.yOffset = 8;
				mountData.playerHeadOffset = 22;
				mountData.standingFrameCount = 1;
				mountData.standingFrameDelay = 12;
				mountData.standingFrameStart = 7;
				mountData.runningFrameCount = 5;
				mountData.runningFrameDelay = 12;
				mountData.runningFrameStart = 11;
				mountData.flyingFrameCount = 6;
				mountData.flyingFrameDelay = 6;
				mountData.flyingFrameStart = 1;
				mountData.inAirFrameCount = 1;
				mountData.inAirFrameDelay = 12;
				mountData.inAirFrameStart = 0;
				mountData.idleFrameCount = 3;
				mountData.idleFrameDelay = 30;
				mountData.idleFrameStart = 8;
				mountData.idleFrameLoop = false;
			}*/
			mountData = new Mount.MountData();
			Mount.mounts[1] = mountData;
			mountData.spawnDust = 15;
			mountData.buff = 128;
			mountData.heightBoost = 20;
			mountData.flightTimeMax = 0;
			mountData.fallDamage = 0.8f;
			mountData.runSpeed = 4f;
			mountData.dashSpeed = 7.5f;
			mountData.acceleration = 0.13f;
			mountData.jumpHeight = 15;
			mountData.jumpSpeed = 5.01f;
			/*if (Main.netMode != 2)
			{
				mountData.backTexture = Main.bunnyMountTexture;
				mountData.backTextureExtra = null;
				mountData.frontTexture = null;
				mountData.frontTextureExtra = null;
				mountData.textureWidth = mountData.backTexture.Width;
				mountData.textureHeight = mountData.backTexture.Height;
				mountData.totalFrames = 7;
				int[] array = new int[mountData.totalFrames];
				for (int k = 0; k < array.Length; k++)
				{
					array[k] = 14;
				}
				array[2] += 2;
				array[3] += 4;
				array[4] += 8;
				array[5] += 8;
				mountData.playerYOffsets = array;
				mountData.xOffset = 1;
				mountData.bodyFrame = 3;
				mountData.yOffset = 4;
				mountData.playerHeadOffset = 22;
				mountData.standingFrameCount = 1;
				mountData.standingFrameDelay = 12;
				mountData.standingFrameStart = 0;
				mountData.runningFrameCount = 7;
				mountData.runningFrameDelay = 12;
				mountData.runningFrameStart = 0;
				mountData.flyingFrameCount = 6;
				mountData.flyingFrameDelay = 6;
				mountData.flyingFrameStart = 1;
				mountData.inAirFrameCount = 1;
				mountData.inAirFrameDelay = 12;
				mountData.inAirFrameStart = 5;
				mountData.idleFrameCount = 0;
				mountData.idleFrameDelay = 0;
				mountData.idleFrameStart = 0;
				mountData.idleFrameLoop = false;
			}*/
			mountData = new Mount.MountData();
			Mount.mounts[3] = mountData;
			mountData.spawnDust = 56;
			mountData.buff = 130;
			mountData.heightBoost = 20;
			mountData.flightTimeMax = 0;
			mountData.fallDamage = 0.5f;
			mountData.runSpeed = 4f;
			mountData.dashSpeed = 4f;
			mountData.acceleration = 0.08f;
			mountData.jumpHeight = 22;
			mountData.jumpSpeed = 7.25f;
			mountData.constantJump = true;
			/*if (Main.netMode != 2)
			{
				mountData.backTexture = Main.slimeMountTexture;
				mountData.backTextureExtra = null;
				mountData.frontTexture = null;
				mountData.frontTextureExtra = null;
				mountData.textureWidth = mountData.backTexture.Width;
				mountData.textureHeight = mountData.backTexture.Height;
				mountData.totalFrames = 4;
				int[] array = new int[mountData.totalFrames];
				for (int l = 0; l < array.Length; l++)
				{
					array[l] = 20;
				}
				array[1] += 2;
				array[3] -= 2;
				mountData.playerYOffsets = array;
				mountData.xOffset = 1;
				mountData.bodyFrame = 3;
				mountData.yOffset = 10;
				mountData.playerHeadOffset = 22;
				mountData.standingFrameCount = 1;
				mountData.standingFrameDelay = 12;
				mountData.standingFrameStart = 0;
				mountData.runningFrameCount = 4;
				mountData.runningFrameDelay = 12;
				mountData.runningFrameStart = 0;
				mountData.flyingFrameCount = 0;
				mountData.flyingFrameDelay = 0;
				mountData.flyingFrameStart = 0;
				mountData.inAirFrameCount = 1;
				mountData.inAirFrameDelay = 12;
				mountData.inAirFrameStart = 1;
				mountData.idleFrameCount = 0;
				mountData.idleFrameDelay = 0;
				mountData.idleFrameStart = 0;
				mountData.idleFrameLoop = false;
			}*/
			mountData = new Mount.MountData();
			Mount.mounts[6] = mountData;
			mountData.spawnDust = 213;
			mountData.buff = 118;
			mountData.extraBuff = 138;
			mountData.heightBoost = 10;
			mountData.flightTimeMax = 0;
			mountData.fallDamage = 1f;
			mountData.runSpeed = 13f;
			mountData.dashSpeed = 13f;
			mountData.acceleration = 0.04f;
			mountData.jumpHeight = 15;
			mountData.jumpSpeed = 5.15f;
			mountData.blockExtraJumps = true;
			/*if (Main.netMode != 2)
			{
				mountData.backTexture = null;
				mountData.backTextureExtra = null;
				mountData.frontTexture = Main.minecartMountTexture;
				mountData.frontTextureExtra = null;
				mountData.textureWidth = mountData.frontTexture.Width;
				mountData.textureHeight = mountData.frontTexture.Height;
				mountData.totalFrames = 3;
				int[] array = new int[mountData.totalFrames];
				for (int m = 0; m < array.Length; m++)
				{
					array[m] = 8;
				}
				mountData.playerYOffsets = array;
				mountData.xOffset = 1;
				mountData.bodyFrame = 3;
				mountData.yOffset = 13;
				mountData.playerHeadOffset = 14;
				mountData.standingFrameCount = 1;
				mountData.standingFrameDelay = 12;
				mountData.standingFrameStart = 0;
				mountData.runningFrameCount = 3;
				mountData.runningFrameDelay = 12;
				mountData.runningFrameStart = 0;
				mountData.flyingFrameCount = 0;
				mountData.flyingFrameDelay = 0;
				mountData.flyingFrameStart = 0;
				mountData.inAirFrameCount = 0;
				mountData.inAirFrameDelay = 0;
				mountData.inAirFrameStart = 0;
				mountData.idleFrameCount = 0;
				mountData.idleFrameDelay = 0;
				mountData.idleFrameStart = 0;
				mountData.idleFrameLoop = false;
			}*/
			mountData = new Mount.MountData();
			Mount.mounts[4] = mountData;
			mountData.spawnDust = 56;
			mountData.buff = 131;
			mountData.heightBoost = 26;
			mountData.flightTimeMax = 0;
			mountData.fallDamage = 1f;
			mountData.runSpeed = 2f;
			mountData.dashSpeed = 2f;
			mountData.swimSpeed = 6f;
			mountData.acceleration = 0.08f;
			mountData.jumpHeight = 10;
			mountData.jumpSpeed = 3.15f;
			/*if (Main.netMode != 2)
			{
				mountData.backTexture = Main.turtleMountTexture;
				mountData.backTextureExtra = null;
				mountData.frontTexture = null;
				mountData.frontTextureExtra = null;
				mountData.textureWidth = mountData.backTexture.Width;
				mountData.textureHeight = mountData.backTexture.Height;
				mountData.totalFrames = 12;
				int[] array = new int[mountData.totalFrames];
				for (int n = 0; n < array.Length; n++)
				{
					array[n] = 26;
				}
				mountData.playerYOffsets = array;
				mountData.xOffset = 1;
				mountData.bodyFrame = 3;
				mountData.yOffset = 13;
				mountData.playerHeadOffset = 30;
				mountData.standingFrameCount = 1;
				mountData.standingFrameDelay = 12;
				mountData.standingFrameStart = 0;
				mountData.runningFrameCount = 6;
				mountData.runningFrameDelay = 12;
				mountData.runningFrameStart = 0;
				mountData.flyingFrameCount = 0;
				mountData.flyingFrameDelay = 0;
				mountData.flyingFrameStart = 0;
				mountData.inAirFrameCount = 1;
				mountData.inAirFrameDelay = 12;
				mountData.inAirFrameStart = 3;
				mountData.idleFrameCount = 0;
				mountData.idleFrameDelay = 0;
				mountData.idleFrameStart = 0;
				mountData.idleFrameLoop = false;
				mountData.swimFrameCount = 6;
				mountData.swimFrameDelay = 12;
				mountData.swimFrameStart = 6;
			}*/
			mountData = new Mount.MountData();
			Mount.mounts[5] = mountData;
			mountData.spawnDust = 152;
			mountData.buff = 132;
			mountData.heightBoost = 16;
			mountData.flightTimeMax = 320;
			mountData.fatigueMax = 320;
			mountData.fallDamage = 0f;
			mountData.runSpeed = 2f;
			mountData.dashSpeed = 2f;
			mountData.acceleration = 0.16f;
			mountData.jumpHeight = 10;
			mountData.jumpSpeed = 4f;
			mountData.blockExtraJumps = true;
			/*if (Main.netMode != 2)
			{
				mountData.backTexture = Main.beeMountTexture[0];
				mountData.backTextureExtra = Main.beeMountTexture[1];
				mountData.frontTexture = null;
				mountData.frontTextureExtra = null;
				mountData.textureWidth = mountData.backTexture.Width;
				mountData.textureHeight = mountData.backTexture.Height;
				mountData.totalFrames = 12;
				int[] array = new int[mountData.totalFrames];
				for (int num = 0; num < array.Length; num++)
				{
					array[num] = 16;
				}
				array[8] = 18;
				mountData.playerYOffsets = array;
				mountData.xOffset = 1;
				mountData.bodyFrame = 3;
				mountData.yOffset = 4;
				mountData.playerHeadOffset = 18;
				mountData.standingFrameCount = 1;
				mountData.standingFrameDelay = 12;
				mountData.standingFrameStart = 0;
				mountData.runningFrameCount = 5;
				mountData.runningFrameDelay = 12;
				mountData.runningFrameStart = 0;
				mountData.flyingFrameCount = 3;
				mountData.flyingFrameDelay = 12;
				mountData.flyingFrameStart = 5;
				mountData.inAirFrameCount = 3;
				mountData.inAirFrameDelay = 12;
				mountData.inAirFrameStart = 5;
				mountData.idleFrameCount = 4;
				mountData.idleFrameDelay = 12;
				mountData.idleFrameStart = 8;
				mountData.idleFrameLoop = true;
				mountData.swimFrameCount = 0;
				mountData.swimFrameDelay = 12;
				mountData.swimFrameStart = 0;
			}*/
		}
		public static int GetHeightBoost(int MountType)
		{
			if (MountType <= -1 || MountType >= 7)
			{
				return 0;
			}
			return Mount.mounts[MountType].heightBoost;
		}
		public int JumpHeight(float xVelocity)
		{
			int num = this._data.jumpHeight;
			switch (this._type)
			{
			case 0:
				num += (int)(Math.Abs(xVelocity) / 4f);
				break;
			case 1:
				num += (int)(Math.Abs(xVelocity) / 2.5f);
				break;
			case 4:
				if (this._frameState == 4)
				{
					num += 5;
				}
				break;
			}
			return num;
		}
		public float JumpSpeed(float xVelocity)
		{
			float num = this._data.jumpSpeed;
			switch (this._type)
			{
			case 0:
			case 1:
				num += Math.Abs(xVelocity) / 7f;
				break;
			case 4:
				if (this._frameState == 4)
				{
					num += 2.5f;
				}
				break;
			}
			return num;
		}
		public bool CheckBuff(int buffID)
		{
			return this._data.buff == buffID || this._data.extraBuff == buffID;
		}
		public void FatigueRecovery()
		{
			if (this._fatigue > 2f)
			{
				this._fatigue -= 2f;
				return;
			}
			this._fatigue = 0f;
		}
		public bool Flight()
		{
			if (this._flyTime <= 0)
			{
				return false;
			}
			this._flyTime--;
			return true;
		}
		public bool Hover(Player mountedPlayer)
		{
			if (this._frameState == 2)
			{
				bool flag = true;
				float num = mountedPlayer.gravity / Player.defaultGravity;
				if (mountedPlayer.slowFall)
				{
					num /= 3f;
				}
				if (num < 0.25f)
				{
					num = 0.25f;
				}
				if (this._flyTime > 0)
				{
					this._flyTime--;
				}
				else if (this._fatigue < this._fatigueMax)
				{
					this._fatigue += num;
				}
				else
				{
					flag = false;
				}
				float num2 = this._fatigue / this._fatigueMax;
				float num3 = 4f * num2;
				float num4 = 4f * num2;
				if (num3 == 0f)
				{
					num3 = 0.001f;
				}
				if (num4 == 0f)
				{
					num4 = 0.001f;
				}
				float num5 = mountedPlayer.velocity.Y;
				if ((mountedPlayer.controlUp || mountedPlayer.controlJump) && flag)
				{
					num3 = -2f - 6f * (1f - num2);
					num5 -= this._data.acceleration;
				}
				else if (mountedPlayer.controlDown)
				{
					num5 += this._data.acceleration;
					num4 = 8f;
				}
				else
				{
					int arg_11C_0 = mountedPlayer.jump;
				}
				if (num5 < num3)
				{
					if (num3 - num5 < this._data.acceleration)
					{
						num5 = num3;
					}
					else
					{
						num5 += this._data.acceleration;
					}
				}
				else if (num5 > num4)
				{
					if (num5 - num4 < this._data.acceleration)
					{
						num5 = num4;
					}
					else
					{
						num5 -= this._data.acceleration;
					}
				}
				mountedPlayer.velocity.Y = num5;
			}
			else
			{
				mountedPlayer.velocity.Y = mountedPlayer.velocity.Y + mountedPlayer.gravity * mountedPlayer.gravDir;
			}
			return true;
		}
		public void UpdateFrame(int state, Vector2 velocity)
		{
			if (this._frameState != state)
			{
				this._frameState = state;
				this._frameCounter = 0f;
			}
			if (state != 0)
			{
				this._idleTime = 0;
			}
			if (this._type == 5 && state != 2)
			{
				this._frameExtra = 0;
				this._frameExtraCounter = 0f;
			}
			switch (state)
			{
			case 0:
				if (this._data.idleFrameCount != 0)
				{
					if (this._type == 5)
					{
						if (this._fatigue != 0f)
						{
							if (this._idleTime == 0)
							{
								this._idleTimeNext = this._idleTime + 1;
							}
						}
						else
						{
							this._idleTime = 0;
							this._idleTimeNext = 2;
						}
					}
					else if (this._idleTime == 0)
					{
						this._idleTimeNext = Main.rand.Next(900, 1500);
					}
					this._idleTime++;
				}
				this._frameCounter += 1f;
				if (this._data.idleFrameCount != 0 && this._idleTime >= this._idleTimeNext)
				{
					float num = (float)this._data.idleFrameDelay;
					if (this._type == 5)
					{
						num *= 2f - 1f * this._fatigue / this._fatigueMax;
					}
					int num2 = (int)((float)(this._idleTime - this._idleTimeNext) / num);
					if (num2 >= this._data.idleFrameCount)
					{
						if (this._data.idleFrameLoop)
						{
							this._idleTime = this._idleTimeNext;
							this._frame = this._data.idleFrameStart;
						}
						else
						{
							this._frameCounter = 0f;
							this._frame = this._data.standingFrameStart;
							this._idleTime = 0;
						}
					}
					else
					{
						this._frame = this._data.idleFrameStart + num2;
					}
					if (this._type == 5)
					{
						this._frameExtra = this._frame;
						return;
					}
				}
				else
				{
					if (this._frameCounter > (float)this._data.standingFrameDelay)
					{
						this._frameCounter -= (float)this._data.standingFrameDelay;
						this._frame++;
					}
					if (this._frame < this._data.standingFrameStart || this._frame >= this._data.standingFrameStart + this._data.standingFrameCount)
					{
						this._frame = this._data.standingFrameStart;
						return;
					}
				}
				break;
			case 1:
			{
				float num3;
				if (this._type == 6)
				{
					num3 = (this._flipDraw ? velocity.X : (-velocity.X));
				}
				else
				{
					num3 = Math.Abs(velocity.X);
				}
				this._frameCounter += num3;
				if (num3 >= 0f)
				{
					if (this._frameCounter > (float)this._data.runningFrameDelay)
					{
						this._frameCounter -= (float)this._data.runningFrameDelay;
						this._frame++;
					}
					if (this._frame < this._data.runningFrameStart || this._frame >= this._data.runningFrameStart + this._data.runningFrameCount)
					{
						this._frame = this._data.runningFrameStart;
						return;
					}
				}
				else
				{
					if (this._frameCounter < 0f)
					{
						this._frameCounter += (float)this._data.runningFrameDelay;
						this._frame--;
					}
					if (this._frame < this._data.runningFrameStart || this._frame >= this._data.runningFrameStart + this._data.runningFrameCount)
					{
						this._frame = this._data.runningFrameStart + this._data.runningFrameCount - 1;
						return;
					}
				}
				break;
			}
			case 2:
				this._frameCounter += 1f;
				if (this._frameCounter > (float)this._data.inAirFrameDelay)
				{
					this._frameCounter -= (float)this._data.inAirFrameDelay;
					this._frame++;
				}
				if (this._frame < this._data.inAirFrameStart || this._frame >= this._data.inAirFrameStart + this._data.inAirFrameCount)
				{
					this._frame = this._data.inAirFrameStart;
				}
				if (this._type == 4)
				{
					if (velocity.Y < 0f)
					{
						this._frame = 3;
						return;
					}
					this._frame = 6 + Main.debugToggle % 6;
					return;
				}
				else if (this._type == 5)
				{
					float num4 = this._fatigue / this._fatigueMax;
					this._frameExtraCounter += 6f - 4f * num4;
					if (this._frameExtraCounter > (float)this._data.flyingFrameDelay)
					{
						this._frameExtra++;
						this._frameExtraCounter -= (float)this._data.flyingFrameDelay;
					}
					if (this._frameExtra < this._data.flyingFrameStart || this._frameExtra >= this._data.flyingFrameStart + this._data.flyingFrameCount)
					{
						this._frameExtra = this._data.flyingFrameStart;
						return;
					}
				}
				break;
			case 3:
				this._frameCounter += 1f;
				if (this._frameCounter > (float)this._data.flyingFrameDelay)
				{
					this._frameCounter -= (float)this._data.flyingFrameDelay;
					this._frame++;
				}
				if (this._frame < this._data.flyingFrameStart || this._frame >= this._data.flyingFrameStart + this._data.flyingFrameCount)
				{
					this._frame = this._data.flyingFrameStart;
					return;
				}
				break;
			case 4:
				this._frameCounter += (float)((int)((Math.Abs(velocity.X) + Math.Abs(velocity.Y)) / 2f));
				if (this._frameCounter > (float)this._data.swimFrameDelay)
				{
					this._frameCounter -= (float)this._data.swimFrameDelay;
					this._frame++;
				}
				if (this._frame < this._data.swimFrameStart || this._frame >= this._data.swimFrameStart + this._data.swimFrameCount)
				{
					this._frame = this._data.swimFrameStart;
				}
				break;
			default:
				return;
			}
		}
		public void ResetFlightTime(float xVelocity)
		{
			this._flyTime = (this._active ? this._data.flightTimeMax : 0);
			if (this._type == 0)
			{
				this._flyTime += (int)(Math.Abs(xVelocity) * 20f);
			}
		}
		public void CheckMountBuff(Player mountedPlayer)
		{
			if (this._type == -1)
			{
				return;
			}
			for (int i = 0; i < 22; i++)
			{
				if (mountedPlayer.buffType[i] == this._data.buff)
				{
					return;
				}
				if (this._type == 6 && mountedPlayer.buffType[i] == this._data.extraBuff)
				{
					return;
				}
			}
			this.Dismount(mountedPlayer);
		}
		public void Dismount(Player mountedPlayer)
		{
			if (!this._active)
			{
				return;
			}
			this._active = false;
			mountedPlayer.ClearBuff(this._data.buff);
			if (this._type == 6)
			{
				mountedPlayer.ClearBuff(this._data.extraBuff);
				mountedPlayer.cartFlip = false;
				mountedPlayer.fullRotation = 0f;
				mountedPlayer.fullRotationOrigin = Vector2.Zero;
				mountedPlayer.lastBoost = Vector2.Zero;
			}
			if (Main.netMode != 2)
			{
				for (int i = 0; i < 100; i++)
				{
					if (this._type == 6)
					{
						if (i % 10 == 0)
						{
							int type = Main.rand.Next(61, 64);
							int num = Gore.NewGore(new Vector2(mountedPlayer.position.X - 20f, mountedPlayer.position.Y), Vector2.Zero, type, 1f);
							Main.gore[num].alpha = 100;
							Main.gore[num].velocity = Vector2.Transform(new Vector2(1f, 0f), Matrix.CreateRotationZ((float)(Main.rand.NextDouble() * 6.2831854820251465)));
						}
					}
					else
					{
						int num2 = Dust.NewDust(new Vector2(mountedPlayer.position.X - 20f, mountedPlayer.position.Y), mountedPlayer.width + 40, mountedPlayer.height, this._data.spawnDust, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num2].scale += (float)Main.rand.Next(-10, 21) * 0.01f;
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num2].scale *= 1.3f;
							Main.dust[num2].noGravity = true;
						}
						else
						{
							Main.dust[num2].velocity *= 0.5f;
						}
						Main.dust[num2].velocity += mountedPlayer.velocity * 0.8f;
					}
				}
			}
			this.Reset();
			mountedPlayer.position.Y = mountedPlayer.position.Y + (float)mountedPlayer.height;
			mountedPlayer.height = 42;
			mountedPlayer.position.Y = mountedPlayer.position.Y - (float)mountedPlayer.height;
			if (mountedPlayer.whoAmi == Main.myPlayer)
			{
				NetMessage.SendData(13, -1, -1, "", mountedPlayer.whoAmi, 0f, 0f, 0f, 0);
			}
		}
		public void SetMount(int m, Player mountedPlayer, bool faceLeft = false)
		{
			if (this._type == m || m <= -1 || m >= 7)
			{
				return;
			}
			if (m == 5 && mountedPlayer.wet)
			{
				return;
			}
			if (this._active)
			{
				mountedPlayer.ClearBuff(this._data.buff);
				if (this._type == 6)
				{
					mountedPlayer.ClearBuff(this._data.extraBuff);
				}
			}
			else
			{
				this._active = true;
			}
			this._flyTime = 0;
			this._type = m;
			this._data = Mount.mounts[m];
			this._fatigueMax = (float)this._data.fatigueMax;
			if (this._type == 6 && !faceLeft)
			{
				mountedPlayer.AddBuff(this._data.extraBuff, 3600, true);
				this._flipDraw = true;
			}
			else
			{
				mountedPlayer.AddBuff(this._data.buff, 3600, true);
				this._flipDraw = false;
			}
			mountedPlayer.position.Y = mountedPlayer.position.Y + (float)mountedPlayer.height;
			mountedPlayer.height = 42 + this._data.heightBoost;
			mountedPlayer.position.Y = mountedPlayer.position.Y - (float)mountedPlayer.height;
			if (Main.netMode != 2)
			{
				for (int i = 0; i < 100; i++)
				{
					if (this._type == 6)
					{
						if (i % 10 == 0)
						{
							int type = Main.rand.Next(61, 64);
							int num = Gore.NewGore(new Vector2(mountedPlayer.position.X - 20f, mountedPlayer.position.Y), Vector2.Zero, type, 1f);
							Main.gore[num].alpha = 100;
							Main.gore[num].velocity = Vector2.Transform(new Vector2(1f, 0f), Matrix.CreateRotationZ((float)(Main.rand.NextDouble() * 6.2831854820251465)));
						}
					}
					else
					{
						int num2 = Dust.NewDust(new Vector2(mountedPlayer.position.X - 20f, mountedPlayer.position.Y), mountedPlayer.width + 40, mountedPlayer.height, this._data.spawnDust, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num2].scale += (float)Main.rand.Next(-10, 21) * 0.01f;
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num2].scale *= 1.3f;
							Main.dust[num2].noGravity = true;
						}
						else
						{
							Main.dust[num2].velocity *= 0.5f;
						}
						Main.dust[num2].velocity += mountedPlayer.velocity * 0.8f;
					}
				}
			}
			if (mountedPlayer.whoAmi == Main.myPlayer)
			{
				NetMessage.SendData(13, -1, -1, "", mountedPlayer.whoAmi, 0f, 0f, 0f, 0);
			}
		}
	}
}
