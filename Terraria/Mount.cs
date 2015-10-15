
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Terraria.DataStructures;
using Terraria.GameContent.Achievements;
using Terraria.ID;

namespace Terraria
{
	public class Mount
	{
		public const int None = -1;

		public const int Rudolph = 0;

		public const int Bunny = 1;

		public const int Pigron = 2;

		public const int Slime = 3;

		public const int Turtle = 4;

		public const int Bee = 5;

		public const int Minecart = 6;

		public const int UFO = 7;

		public const int Drill = 8;

		public const int Scutlix = 9;

		public const int Unicorn = 10;

		public const int MinecartMech = 11;

		public const int CuteFishron = 12;

		public const int MinecartWood = 13;

		public const int maxMounts = 14;

		public const int FrameStanding = 0;

		public const int FrameRunning = 1;

		public const int FrameInAir = 2;

		public const int FrameFlying = 3;

		public const int FrameSwimming = 4;

		public const int FrameDashing = 5;

		public const int DrawBack = 0;

		public const int DrawBackExtra = 1;

		public const int DrawFront = 2;

		public const int DrawFrontExtra = 3;

		public const int scutlixBaseDamage = 50;

		public const int drillTextureWidth = 80;

		public const float drillRotationChange = 0.05235988f;

		public const float maxDrillLength = 48f;

		public static int currentShader;

		private static Mount.MountData[] mounts;

		private static Vector2[] scutlixEyePositions;

		private static Vector2 scutlixTextureSize;

		public static Vector2 drillDiodePoint1;

		public static Vector2 drillDiodePoint2;

		public static Vector2 drillTextureSize;

		public static int drillPickPower;

		public static int drillPickTime;

		public static int drillBeamCooldownMax;

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

		private bool _abilityCharging;

		private int _abilityCharge;

		private int _abilityCooldown;

		private int _abilityDuration;

		private bool _abilityActive;

		private bool _aiming;

		public List<DrillDebugDraw> _debugDraw;

		private object _mountSpecificData;

		private bool _active;

		public bool AbilityActive
		{
			get
			{
				return this._abilityActive;
			}
		}

		public float AbilityCharge
		{
			get
			{
				return (float)this._abilityCharge / (float)this._data.abilityChargeMax;
			}
		}

		public bool AbilityCharging
		{
			get
			{
				return this._abilityCharging;
			}
		}

		public bool AbilityReady
		{
			get
			{
				return this._abilityCooldown == 0;
			}
		}

		public float Acceleration
		{
			get
			{
				return this._data.acceleration;
			}
		}

		public bool Active
		{
			get
			{
				return this._active;
			}
		}

		public bool AllowDirectionChange
		{
			get
			{
				if (this._type != 9)
				{
					return true;
				}
				return this._abilityCooldown < this._data.abilityCooldown / 2;
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

		public int BodyFrame
		{
			get
			{
				return this._data.bodyFrame;
			}
		}

		public int BuffType
		{
			get
			{
				return this._data.buff;
			}
		}

		public bool CanFly
		{
			get
			{
				if (this._active && this._data.flightTimeMax != 0)
				{
					return true;
				}
				return false;
			}
		}

		public bool CanHover
		{
			get
			{
				if (this._active && this._data.usesHover)
				{
					return true;
				}
				return false;
			}
		}

		public bool Cart
		{
			get
			{
				if (this._data == null || !this._active)
				{
					return false;
				}
				return this._data.Minecart;
			}
		}

		public float DashSpeed
		{
			get
			{
				return this._data.dashSpeed;
			}
		}

		public bool Directional
		{
			get
			{
				if (this._data == null)
				{
					return true;
				}
				return this._data.MinecartDirectional;
			}
		}

		public float FallDamage
		{
			get
			{
				return this._data.fallDamage;
			}
		}

		public int FlyTime
		{
			get
			{
				return this._flyTime;
			}
		}

		public int HeightBoost
		{
			get
			{
				return this._data.heightBoost;
			}
		}

		public Vector2 Origin
		{
			get
			{
				return new Vector2();
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

		public int PlayerOffsetHitbox
		{
			get
			{
				if (!this._active)
				{
					return 0;
				}
				return this._data.playerYOffsets[0] - this._data.playerYOffsets[this._frame] + this._data.playerYOffsets[0] / 4;
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
				if (this._type == 12 && this._frameState == 4)
				{
					return this._data.swimSpeed;
				}
				if (this._type == 12 && this._frameState == 2)
				{
					return this._data.runSpeed + 11f;
				}
				if (this._type != 5 || this._frameState != 2)
				{
					return this._data.runSpeed;
				}
				float single = this._fatigue / this._fatigueMax;
				return this._data.runSpeed + 4f * (1f - single);
			}
		}

		public int Type
		{
			get
			{
				return this._type;
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

		static Mount()
		{
			Mount.currentShader = 0;
			Mount.drillDiodePoint1 = new Vector2(36f, -6f);
			Mount.drillDiodePoint2 = new Vector2(36f, 8f);
			Mount.drillPickPower = 210;
			Mount.drillPickTime = 6;
			Mount.drillBeamCooldownMax = 1;
		}

		public Mount()
		{
			this._debugDraw = new List<DrillDebugDraw>();
			this.Reset();
		}

		public void AbilityRecovery()
		{
			if (this._abilityCharging)
			{
				if (this._abilityCharge < this._data.abilityChargeMax)
				{
					Mount mount = this;
					mount._abilityCharge = mount._abilityCharge + 1;
				}
			}
			else if (this._abilityCharge > 0)
			{
				Mount mount1 = this;
				mount1._abilityCharge = mount1._abilityCharge - 1;
			}
			if (this._abilityCooldown > 0)
			{
				Mount mount2 = this;
				mount2._abilityCooldown = mount2._abilityCooldown - 1;
			}
			if (this._abilityDuration > 0)
			{
				Mount mount3 = this;
				mount3._abilityDuration = mount3._abilityDuration - 1;
			}
		}

		public bool AimAbility(Player mountedPlayer, Vector2 mousePosition)
		{
			Vector2 deadZone;
			Vector2 vector2 = new Vector2();
			this._aiming = true;
			switch (this._type)
			{
				case 8:
				{
					deadZone = this.ClampToDeadZone(mountedPlayer, mousePosition);
					deadZone = deadZone - mountedPlayer.Center;
					Mount.DrillMountData drillMountDatum = (Mount.DrillMountData)this._mountSpecificData;
					float rotation = deadZone.ToRotation();
					if (rotation < 0f)
					{
						rotation = rotation + 6.28318548f;
					}
					drillMountDatum.diodeRotationTarget = rotation;
					float single = drillMountDatum.diodeRotation % 6.28318548f;
					if (single < 0f)
					{
						single = single + 6.28318548f;
					}
					if (single < rotation)
					{
						if (rotation - single > 3.14159274f)
						{
							single = single + 6.28318548f;
						}
					}
					else if (single - rotation > 3.14159274f)
					{
						single = single - 6.28318548f;
					}
					drillMountDatum.diodeRotation = single;
					drillMountDatum.crosshairPosition = mousePosition;
					return true;
				}
				case 9:
				{
					int num = this._frameExtra;
					int num1 = mountedPlayer.direction;
					deadZone = this.ClampToDeadZone(mountedPlayer, mousePosition);
					deadZone = deadZone - mountedPlayer.Center;
					float degrees = MathHelper.ToDegrees(deadZone.ToRotation());
					if (degrees > 90f)
					{
						mountedPlayer.direction = -1;
						degrees = 180f - degrees;
					}
					else if (degrees >= -90f)
					{
						mountedPlayer.direction = 1;
					}
					else
					{
						mountedPlayer.direction = -1;
						degrees = -180f - degrees;
					}
					if ((mountedPlayer.direction <= 0 || mountedPlayer.velocity.X >= 0f) && (mountedPlayer.direction >= 0 || mountedPlayer.velocity.X <= 0f))
					{
						this._flipDraw = false;
					}
					else
					{
						this._flipDraw = true;
					}
					if (degrees >= 0f)
					{
						if ((double)degrees < 22.5)
						{
							this._frameExtra = 8;
						}
						else if ((double)degrees < 67.5)
						{
							this._frameExtra = 9;
						}
						else if ((double)degrees < 112.5)
						{
							this._frameExtra = 10;
						}
					}
					else if ((double)degrees > -22.5)
					{
						this._frameExtra = 8;
					}
					else if ((double)degrees > -67.5)
					{
						this._frameExtra = 7;
					}
					else if ((double)degrees > -112.5)
					{
						this._frameExtra = 6;
					}
					float abilityCharge = this.AbilityCharge;
					if (abilityCharge > 0f)
					{
						vector2.X = mountedPlayer.position.X + (float)(mountedPlayer.width / 2);
						vector2.Y = mountedPlayer.position.Y + (float)mountedPlayer.height;
					}
					if (this._frameExtra != num)
					{
						return true;
					}
					return mountedPlayer.direction != num1;
				}
			}
			return false;
		}

		public bool CanMount(int m, Player mountingPlayer)
		{
			int num = 42 + Mount.mounts[m].heightBoost;
			Vector2 vector2 = mountingPlayer.position + new Vector2(0f, (float)(mountingPlayer.height - num)) + mountingPlayer.velocity;
			return Collision.IsClearSpotHack(vector2, 2f, mountingPlayer.width, num, false, false, 1, true, false);
		}

		public bool CheckBuff(int buffID)
		{
			if (this._data.buff == buffID)
			{
				return true;
			}
			return this._data.extraBuff == buffID;
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
				if (this.Cart && mountedPlayer.buffType[i] == this._data.extraBuff)
				{
					return;
				}
			}
			this.Dismount(mountedPlayer);
		}

		private Vector2 ClampToDeadZone(Player mountedPlayer, Vector2 position)
		{
			int y;
			int x;
			switch (this._type)
			{
				case 8:
				{
					y = (int)Mount.drillTextureSize.Y;
					x = (int)Mount.drillTextureSize.X;
					break;
				}
				case 9:
				{
					y = (int)Mount.scutlixTextureSize.Y;
					x = (int)Mount.scutlixTextureSize.X;
					break;
				}
				default:
				{
					return position;
				}
			}
			Vector2 center = mountedPlayer.Center;
			position = position - center;
			if (position.X > (float)(-x) && position.X < (float)x && position.Y > (float)(-y) && position.Y < (float)y)
			{
				float single = (float)x / Math.Abs(position.X);
				float single1 = (float)y / Math.Abs(position.Y);
				if (single <= single1)
				{
					position = position * single;
				}
				else
				{
					position = position * single1;
				}
			}
			return position + center;
		}

		public void Dismount(Player mountedPlayer)
		{
			if (!this._active)
			{
				return;
			}
			bool cart = this.Cart;
			this._active = false;
			mountedPlayer.ClearBuff(this._data.buff);
			this._mountSpecificData = null;
			if (cart)
			{
				mountedPlayer.ClearBuff(this._data.extraBuff);
				mountedPlayer.cartFlip = false;
				mountedPlayer.lastBoost = Vector2.Zero;
			}
			mountedPlayer.fullRotation = 0f;
			mountedPlayer.fullRotationOrigin = Vector2.Zero;
			if (Main.netMode != 2)
			{
				for (int i = 0; i < 100; i++)
				{
					if (this._type != 6 && this._type != 11 && this._type != 13)
					{
					}
				}
			}
			this.Reset();
			mountedPlayer.position.Y = mountedPlayer.position.Y + (float)mountedPlayer.height;
			mountedPlayer.height = 42;
			mountedPlayer.position.Y = mountedPlayer.position.Y - (float)mountedPlayer.height;
			if (mountedPlayer.whoAmI == Main.myPlayer)
			{
				NetMessage.SendData((int)PacketTypes.PlayerUpdate, -1, -1, "", mountedPlayer.whoAmI, 0f, 0f, 0f, 0, 0, 0);
			}
		}

		public void Draw(int drawType, Player drawPlayer, Vector2 Position, Color drawColor, float shadow)
		{
		}

		private Point16 DrillSmartCursor(Player mountedPlayer, Mount.DrillMountData data)
		{
			Vector2 vector2;
			vector2 = (mountedPlayer.whoAmI != Main.myPlayer ? data.crosshairPosition : Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY));
			Vector2 center = mountedPlayer.Center;
			Vector2 vector21 = vector2 - center;
			float single = vector21.Length();
			if (single > 224f)
			{
				single = 224f;
			}
			single = single + 32f;
			vector21.Normalize();
			Vector2 vector22 = center;
			Vector2 vector23 = center + (vector21 * single);
			Point16 point16 = new Point16(-1, -1);
			if (!Utils.PlotTileLine(vector22, vector23, 65.6f, (int x, int y) => {
				point16 = new Point16(x, y);
				for (int i = 0; i < (int)data.beams.Length; i++)
				{
					if (data.beams[i].curTileTarget == point16)
					{
						return true;
					}
				}
				if (!WorldGen.CanKillTile(x, y))
				{
					return true;
				}
				if (Main.tile[x, y] != null && !Main.tile[x, y].inActive() && Main.tile[x, y].active())
				{
					return false;
				}
				return true;
			}))
			{
				return point16;
			}
			return new Point16(-1, -1);
		}

		public void FatigueRecovery()
		{
			if (this._fatigue <= 2f)
			{
				this._fatigue = 0f;
				return;
			}
			Mount mount = this;
			mount._fatigue = mount._fatigue - 2f;
		}

		public bool FindTileHeight(Vector2 position, int maxTilesDown, out float tileHeight)
		{
			int x = (int)(position.X / 16f);
			int y = (int)(position.Y / 16f);
			for (int i = 0; i <= maxTilesDown; i++)
			{
				Tile tile = Main.tile[x, y];
				bool flag = Main.tileSolid[tile.type];
				bool flag1 = Main.tileSolidTop[tile.type];
				if (tile.active())
				{
					if (!flag)
					{
					}
					else if (flag1)
					{
					}
				}
				y++;
			}
			tileHeight = 0f;
			return true;
		}

		public bool Flight()
		{
			if (this._flyTime <= 0)
			{
				return false;
			}
			Mount mount = this;
			mount._flyTime = mount._flyTime - 1;
			return true;
		}

		public static int GetHeightBoost(int MountType)
		{
			if (MountType <= -1 || MountType >= 14)
			{
				return 0;
			}
			return Mount.mounts[MountType].heightBoost;
		}

		public static Vector2 GetMinecartMechPoint(Player mountedPlayer, int offX, int offY)
		{
			int num = Math.Sign(mountedPlayer.velocity.X);
			if (num == 0)
			{
				num = mountedPlayer.direction;
			}
			float single = (float)offX;
			int num1 = Math.Sign(offX);
			if (mountedPlayer.direction != num)
			{
				single = single - (float)num1;
			}
			if (num == -1)
			{
				single = single - (float)num1;
			}
			Vector2 vector2 = (new Vector2(single * (float)num, (float)offY)).RotatedBy((double)mountedPlayer.fullRotation, new Vector2());
			Vector2 vector21 = (new Vector2(MathHelper.Lerp(0f, -8f, mountedPlayer.fullRotation / 0.7853982f), MathHelper.Lerp(0f, 2f, Math.Abs(mountedPlayer.fullRotation / 0.7853982f)))).RotatedBy((double)mountedPlayer.fullRotation, new Vector2());
			if (num == Math.Sign(mountedPlayer.fullRotation))
			{
				vector21 = vector21 * MathHelper.Lerp(1f, 0.6f, Math.Abs(mountedPlayer.fullRotation / 0.7853982f));
			}
			return (mountedPlayer.Bottom + vector2) + vector21;
		}

		public bool Hover(Player mountedPlayer)
		{
			if (this._frameState == 2 || this._frameState == 4)
			{
				bool flag = true;
				float single = 1f;
				float single1 = mountedPlayer.gravity / Player.defaultGravity;
				if (mountedPlayer.slowFall)
				{
					single1 = single1 / 3f;
				}
				if (single1 < 0.25f)
				{
					single1 = 0.25f;
				}
				if (this._type != 7 && this._type != 8 && this._type != 12)
				{
					if (this._flyTime > 0)
					{
						Mount mount = this;
						mount._flyTime = mount._flyTime - 1;
					}
					else if (this._fatigue >= this._fatigueMax)
					{
						flag = false;
					}
					else
					{
						Mount mount1 = this;
						mount1._fatigue = mount1._fatigue + single1;
					}
				}
				if (this._type == 12 && !mountedPlayer.MountFishronSpecial)
				{
					single = 0.5f;
				}
				float single2 = this._fatigue / this._fatigueMax;
				if (this._type == 7 || this._type == 8 || this._type == 12)
				{
					single2 = 0f;
				}
				float single3 = 4f * single2;
				float single4 = 4f * single2;
				if (single3 == 0f)
				{
					single3 = -0.001f;
				}
				if (single4 == 0f)
				{
					single4 = -0.001f;
				}
				float y = mountedPlayer.velocity.Y;
				if ((mountedPlayer.controlUp || mountedPlayer.controlJump) && flag)
				{
					single3 = -2f - 6f * (1f - single2);
					y = y - this._data.acceleration * single;
				}
				else if (!mountedPlayer.controlDown)
				{
					int num = mountedPlayer.jump;
				}
				else
				{
					y = y + this._data.acceleration * single;
					single4 = 8f;
				}
				if (y < single3)
				{
					y = (single3 - y >= this._data.acceleration ? y + this._data.acceleration * single : single3);
				}
				else if (y > single4)
				{
					y = (y - single4 >= this._data.acceleration ? y - this._data.acceleration * single : single4);
				}
				mountedPlayer.velocity.Y = y;
				mountedPlayer.fallStart = (int)(mountedPlayer.position.Y / 16f);
			}
			else if (this._type != 7 && this._type != 8 && this._type != 12)
			{
				mountedPlayer.velocity.Y = mountedPlayer.velocity.Y + mountedPlayer.gravity * mountedPlayer.gravDir;
			}
			else if (mountedPlayer.velocity.Y == 0f)
			{
				mountedPlayer.velocity.Y = 0.001f;
			}
			if (this._type == 7)
			{
				float x = mountedPlayer.velocity.X / this._data.dashSpeed;
				if ((double)x > 0.95)
				{
					x = 0.95f;
				}
				if ((double)x < -0.95)
				{
					x = -0.95f;
				}
				float single5 = 0.7853982f * x / 2f;
				mountedPlayer.fullRotation = single5;
			}
			else if (this._type == 8)
			{
				float x1 = mountedPlayer.velocity.X / this._data.dashSpeed;
				if ((double)x1 > 0.95)
				{
					x1 = 0.95f;
				}
				if ((double)x1 < -0.95)
				{
					x1 = -0.95f;
				}
				mountedPlayer.fullRotation = 0.7853982f * x1 / 2f;
				Mount.DrillMountData drillMountDatum = (Mount.DrillMountData)this._mountSpecificData;
				float x2 = drillMountDatum.outerRingRotation;
				x2 = x2 + mountedPlayer.velocity.X / 80f;
				if (x2 > 3.14159274f)
				{
					x2 = x2 - 6.28318548f;
				}
				else if (x2 < -3.14159274f)
				{
					x2 = x2 + 6.28318548f;
				}
				drillMountDatum.outerRingRotation = x2;
			}
			return true;
		}

		public static void Initialize()
		{
			Mount.mounts = new Mount.MountData[14];
			Mount.MountData mountDatum = new Mount.MountData();
			Mount.mounts[0] = mountDatum;
			mountDatum.spawnDust = 57;
			mountDatum.spawnDustNoGravity = false;
			mountDatum.buff = BuffID.Rudolph;
			mountDatum.heightBoost = 20;
			mountDatum.flightTimeMax = 160;
			mountDatum.runSpeed = 5.5f;
			mountDatum.dashSpeed = 12f;
			mountDatum.acceleration = 0.09f;
			mountDatum.jumpHeight = 17;
			mountDatum.jumpSpeed = 5.31f;
			mountDatum.totalFrames = 12;
			int[] numArray = new int[mountDatum.totalFrames];
			for (int i = 0; i < (int)numArray.Length; i++)
			{
				numArray[i] = 30;
			}
			numArray[1] = numArray[1] + 2;
			numArray[11] = numArray[11] + 2;
			mountDatum.playerYOffsets = numArray;
			mountDatum.xOffset = 13;
			mountDatum.bodyFrame = 3;
			mountDatum.yOffset = -7;
			mountDatum.playerHeadOffset = 22;
			mountDatum.standingFrameCount = 1;
			mountDatum.standingFrameDelay = 12;
			mountDatum.standingFrameStart = 0;
			mountDatum.runningFrameCount = 6;
			mountDatum.runningFrameDelay = 12;
			mountDatum.runningFrameStart = 6;
			mountDatum.flyingFrameCount = 6;
			mountDatum.flyingFrameDelay = 6;
			mountDatum.flyingFrameStart = 6;
			mountDatum.inAirFrameCount = 1;
			mountDatum.inAirFrameDelay = 12;
			mountDatum.inAirFrameStart = 1;
			mountDatum.idleFrameCount = 4;
			mountDatum.idleFrameDelay = 30;
			mountDatum.idleFrameStart = 2;
			mountDatum.idleFrameLoop = true;
			mountDatum.swimFrameCount = mountDatum.inAirFrameCount;
			mountDatum.swimFrameDelay = mountDatum.inAirFrameDelay;
			mountDatum.swimFrameStart = mountDatum.inAirFrameStart;
			mountDatum = new Mount.MountData();
			Mount.mounts[2] = mountDatum;
			mountDatum.spawnDust = 58;
			mountDatum.buff = BuffID.PigronMount;
			mountDatum.heightBoost = 20;
			mountDatum.flightTimeMax = 160;
			mountDatum.runSpeed = 5f;
			mountDatum.dashSpeed = 9f;
			mountDatum.acceleration = 0.08f;
			mountDatum.jumpHeight = 10;
			mountDatum.jumpSpeed = 6.01f;
			mountDatum.totalFrames = 16;
			numArray = new int[mountDatum.totalFrames];
			for (int j = 0; j < (int)numArray.Length; j++)
			{
				numArray[j] = 22;
			}
			numArray[12] = numArray[12] + 2;
			numArray[13] = numArray[13] + 4;
			numArray[14] = numArray[14] + 2;
			mountDatum.playerYOffsets = numArray;
			mountDatum.xOffset = 1;
			mountDatum.bodyFrame = 3;
			mountDatum.yOffset = 8;
			mountDatum.playerHeadOffset = 22;
			mountDatum.standingFrameCount = 1;
			mountDatum.standingFrameDelay = 12;
			mountDatum.standingFrameStart = 7;
			mountDatum.runningFrameCount = 5;
			mountDatum.runningFrameDelay = 12;
			mountDatum.runningFrameStart = 11;
			mountDatum.flyingFrameCount = 6;
			mountDatum.flyingFrameDelay = 6;
			mountDatum.flyingFrameStart = 1;
			mountDatum.inAirFrameCount = 1;
			mountDatum.inAirFrameDelay = 12;
			mountDatum.inAirFrameStart = 0;
			mountDatum.idleFrameCount = 3;
			mountDatum.idleFrameDelay = 30;
			mountDatum.idleFrameStart = 8;
			mountDatum.idleFrameLoop = false;
			mountDatum.swimFrameCount = mountDatum.inAirFrameCount;
			mountDatum.swimFrameDelay = mountDatum.inAirFrameDelay;
			mountDatum.swimFrameStart = mountDatum.inAirFrameStart;
			mountDatum = new Mount.MountData();
			Mount.mounts[1] = mountDatum;
			mountDatum.spawnDust = 15;
			mountDatum.buff = BuffID.BunnyMount;
			mountDatum.heightBoost = 20;
			mountDatum.flightTimeMax = 0;
			mountDatum.fallDamage = 0.8f;
			mountDatum.runSpeed = 4f;
			mountDatum.dashSpeed = 7.5f;
			mountDatum.acceleration = 0.13f;
			mountDatum.jumpHeight = 15;
			mountDatum.jumpSpeed = 5.01f;
			mountDatum.totalFrames = 7;
			numArray = new int[mountDatum.totalFrames];
			for (int k = 0; k < (int)numArray.Length; k++)
			{
				numArray[k] = 14;
			}
			numArray[2] = numArray[2] + 2;
			numArray[3] = numArray[3] + 4;
			numArray[4] = numArray[4] + 8;
			numArray[5] = numArray[5] + 8;
			mountDatum.playerYOffsets = numArray;
			mountDatum.xOffset = 1;
			mountDatum.bodyFrame = 3;
			mountDatum.yOffset = 4;
			mountDatum.playerHeadOffset = 22;
			mountDatum.standingFrameCount = 1;
			mountDatum.standingFrameDelay = 12;
			mountDatum.standingFrameStart = 0;
			mountDatum.runningFrameCount = 7;
			mountDatum.runningFrameDelay = 12;
			mountDatum.runningFrameStart = 0;
			mountDatum.flyingFrameCount = 6;
			mountDatum.flyingFrameDelay = 6;
			mountDatum.flyingFrameStart = 1;
			mountDatum.inAirFrameCount = 1;
			mountDatum.inAirFrameDelay = 12;
			mountDatum.inAirFrameStart = 5;
			mountDatum.idleFrameCount = 0;
			mountDatum.idleFrameDelay = 0;
			mountDatum.idleFrameStart = 0;
			mountDatum.idleFrameLoop = false;
			mountDatum.swimFrameCount = mountDatum.inAirFrameCount;
			mountDatum.swimFrameDelay = mountDatum.inAirFrameDelay;
			mountDatum.swimFrameStart = mountDatum.inAirFrameStart;
			mountDatum = new Mount.MountData();
			Mount.mounts[3] = mountDatum;
			mountDatum.spawnDust = 56;
			mountDatum.buff = BuffID.SlimeMount;
			mountDatum.heightBoost = 20;
			mountDatum.flightTimeMax = 0;
			mountDatum.fallDamage = 0.5f;
			mountDatum.runSpeed = 4f;
			mountDatum.dashSpeed = 4f;
			mountDatum.acceleration = 0.18f;
			mountDatum.jumpHeight = 12;
			mountDatum.jumpSpeed = 8.25f;
			mountDatum.constantJump = true;
			mountDatum.totalFrames = 4;
			numArray = new int[mountDatum.totalFrames];
			for (int l = 0; l < (int)numArray.Length; l++)
			{
				numArray[l] = 20;
			}
			numArray[1] = numArray[1] + 2;
			numArray[3] = numArray[3] - 2;
			mountDatum.playerYOffsets = numArray;
			mountDatum.xOffset = 1;
			mountDatum.bodyFrame = 3;
			mountDatum.yOffset = 10;
			mountDatum.playerHeadOffset = 22;
			mountDatum.standingFrameCount = 1;
			mountDatum.standingFrameDelay = 12;
			mountDatum.standingFrameStart = 0;
			mountDatum.runningFrameCount = 4;
			mountDatum.runningFrameDelay = 12;
			mountDatum.runningFrameStart = 0;
			mountDatum.flyingFrameCount = 0;
			mountDatum.flyingFrameDelay = 0;
			mountDatum.flyingFrameStart = 0;
			mountDatum.inAirFrameCount = 1;
			mountDatum.inAirFrameDelay = 12;
			mountDatum.inAirFrameStart = 1;
			mountDatum.idleFrameCount = 0;
			mountDatum.idleFrameDelay = 0;
			mountDatum.idleFrameStart = 0;
			mountDatum.idleFrameLoop = false;
			mountDatum = new Mount.MountData();
			Mount.mounts[6] = mountDatum;
			mountDatum.Minecart = true;
			mountDatum.MinecartDirectional = true;
			mountDatum.spawnDust = 213;
			mountDatum.buff = BuffID.MinecartLeft;
			mountDatum.extraBuff = 138;
			mountDatum.heightBoost = 10;
			mountDatum.flightTimeMax = 0;
			mountDatum.fallDamage = 1f;
			mountDatum.runSpeed = 13f;
			mountDatum.dashSpeed = 13f;
			mountDatum.acceleration = 0.04f;
			mountDatum.jumpHeight = 15;
			mountDatum.jumpSpeed = 5.15f;
			mountDatum.blockExtraJumps = true;
			mountDatum.totalFrames = 3;
			numArray = new int[mountDatum.totalFrames];
			for (int m = 0; m < (int)numArray.Length; m++)
			{
				numArray[m] = 8;
			}
			mountDatum.playerYOffsets = numArray;
			mountDatum.xOffset = 1;
			mountDatum.bodyFrame = 3;
			mountDatum.yOffset = 13;
			mountDatum.playerHeadOffset = 14;
			mountDatum.standingFrameCount = 1;
			mountDatum.standingFrameDelay = 12;
			mountDatum.standingFrameStart = 0;
			mountDatum.runningFrameCount = 3;
			mountDatum.runningFrameDelay = 12;
			mountDatum.runningFrameStart = 0;
			mountDatum.flyingFrameCount = 0;
			mountDatum.flyingFrameDelay = 0;
			mountDatum.flyingFrameStart = 0;
			mountDatum.inAirFrameCount = 0;
			mountDatum.inAirFrameDelay = 0;
			mountDatum.inAirFrameStart = 0;
			mountDatum.idleFrameCount = 0;
			mountDatum.idleFrameDelay = 0;
			mountDatum.idleFrameStart = 0;
			mountDatum.idleFrameLoop = false;
			mountDatum = new Mount.MountData();
			Mount.mounts[4] = mountDatum;
			mountDatum.spawnDust = 56;
			mountDatum.buff = BuffID.TurtleMount;
			mountDatum.heightBoost = 26;
			mountDatum.flightTimeMax = 0;
			mountDatum.fallDamage = 1f;
			mountDatum.runSpeed = 2f;
			mountDatum.dashSpeed = 2f;
			mountDatum.swimSpeed = 6f;
			mountDatum.acceleration = 0.08f;
			mountDatum.jumpHeight = 10;
			mountDatum.jumpSpeed = 3.15f;
			mountDatum.totalFrames = 12;
			numArray = new int[mountDatum.totalFrames];
			for (int n = 0; n < (int)numArray.Length; n++)
			{
				numArray[n] = 26;
			}
			mountDatum.playerYOffsets = numArray;
			mountDatum.xOffset = 1;
			mountDatum.bodyFrame = 3;
			mountDatum.yOffset = 13;
			mountDatum.playerHeadOffset = 30;
			mountDatum.standingFrameCount = 1;
			mountDatum.standingFrameDelay = 12;
			mountDatum.standingFrameStart = 0;
			mountDatum.runningFrameCount = 6;
			mountDatum.runningFrameDelay = 12;
			mountDatum.runningFrameStart = 0;
			mountDatum.flyingFrameCount = 0;
			mountDatum.flyingFrameDelay = 0;
			mountDatum.flyingFrameStart = 0;
			mountDatum.inAirFrameCount = 1;
			mountDatum.inAirFrameDelay = 12;
			mountDatum.inAirFrameStart = 3;
			mountDatum.idleFrameCount = 0;
			mountDatum.idleFrameDelay = 0;
			mountDatum.idleFrameStart = 0;
			mountDatum.idleFrameLoop = false;
			mountDatum.swimFrameCount = 6;
			mountDatum.swimFrameDelay = 12;
			mountDatum.swimFrameStart = 6;
			mountDatum = new Mount.MountData();
			Mount.mounts[5] = mountDatum;
			mountDatum.spawnDust = 152;
			mountDatum.buff = BuffID.BeeMount;
			mountDatum.heightBoost = 16;
			mountDatum.flightTimeMax = 320;
			mountDatum.fatigueMax = 320;
			mountDatum.fallDamage = 0f;
			mountDatum.usesHover = true;
			mountDatum.runSpeed = 2f;
			mountDatum.dashSpeed = 2f;
			mountDatum.acceleration = 0.16f;
			mountDatum.jumpHeight = 10;
			mountDatum.jumpSpeed = 4f;
			mountDatum.blockExtraJumps = true;
			mountDatum.totalFrames = 12;
			numArray = new int[mountDatum.totalFrames];
			for (int o = 0; o < (int)numArray.Length; o++)
			{
				numArray[o] = 16;
			}
			numArray[8] = 18;
			mountDatum.playerYOffsets = numArray;
			mountDatum.xOffset = 1;
			mountDatum.bodyFrame = 3;
			mountDatum.yOffset = 4;
			mountDatum.playerHeadOffset = 18;
			mountDatum.standingFrameCount = 1;
			mountDatum.standingFrameDelay = 12;
			mountDatum.standingFrameStart = 0;
			mountDatum.runningFrameCount = 5;
			mountDatum.runningFrameDelay = 12;
			mountDatum.runningFrameStart = 0;
			mountDatum.flyingFrameCount = 3;
			mountDatum.flyingFrameDelay = 12;
			mountDatum.flyingFrameStart = 5;
			mountDatum.inAirFrameCount = 3;
			mountDatum.inAirFrameDelay = 12;
			mountDatum.inAirFrameStart = 5;
			mountDatum.idleFrameCount = 4;
			mountDatum.idleFrameDelay = 12;
			mountDatum.idleFrameStart = 8;
			mountDatum.idleFrameLoop = true;
			mountDatum.swimFrameCount = 0;
			mountDatum.swimFrameDelay = 12;
			mountDatum.swimFrameStart = 0;
			mountDatum = new Mount.MountData();
			Mount.mounts[7] = mountDatum;
			mountDatum.spawnDust = 226;
			mountDatum.spawnDustNoGravity = true;
			mountDatum.buff = BuffID.UFOMount;
			mountDatum.heightBoost = 16;
			mountDatum.flightTimeMax = 320;
			mountDatum.fatigueMax = 320;
			mountDatum.fallDamage = 0f;
			mountDatum.usesHover = true;
			mountDatum.runSpeed = 8f;
			mountDatum.dashSpeed = 8f;
			mountDatum.acceleration = 0.16f;
			mountDatum.jumpHeight = 10;
			mountDatum.jumpSpeed = 4f;
			mountDatum.blockExtraJumps = true;
			mountDatum.totalFrames = 8;
			numArray = new int[mountDatum.totalFrames];
			for (int p = 0; p < (int)numArray.Length; p++)
			{
				numArray[p] = 16;
			}
			mountDatum.playerYOffsets = numArray;
			mountDatum.xOffset = 1;
			mountDatum.bodyFrame = 3;
			mountDatum.yOffset = 4;
			mountDatum.playerHeadOffset = 18;
			mountDatum.standingFrameCount = 8;
			mountDatum.standingFrameDelay = 4;
			mountDatum.standingFrameStart = 0;
			mountDatum.runningFrameCount = 8;
			mountDatum.runningFrameDelay = 4;
			mountDatum.runningFrameStart = 0;
			mountDatum.flyingFrameCount = 8;
			mountDatum.flyingFrameDelay = 4;
			mountDatum.flyingFrameStart = 0;
			mountDatum.inAirFrameCount = 8;
			mountDatum.inAirFrameDelay = 4;
			mountDatum.inAirFrameStart = 0;
			mountDatum.idleFrameCount = 0;
			mountDatum.idleFrameDelay = 12;
			mountDatum.idleFrameStart = 0;
			mountDatum.idleFrameLoop = true;
			mountDatum.swimFrameCount = 0;
			mountDatum.swimFrameDelay = 12;
			mountDatum.swimFrameStart = 0;
			mountDatum = new Mount.MountData();
			Mount.mounts[8] = mountDatum;
			mountDatum.spawnDust = 226;
			mountDatum.buff = BuffID.DrillMount;
			mountDatum.heightBoost = 16;
			mountDatum.flightTimeMax = 320;
			mountDatum.fatigueMax = 320;
			mountDatum.fallDamage = 1f;
			mountDatum.usesHover = true;
			mountDatum.swimSpeed = 4f;
			mountDatum.runSpeed = 6f;
			mountDatum.dashSpeed = 4f;
			mountDatum.acceleration = 0.16f;
			mountDatum.jumpHeight = 10;
			mountDatum.jumpSpeed = 4f;
			mountDatum.blockExtraJumps = true;
			mountDatum.emitsLight = true;
			mountDatum.lightColor = new Vector3(0.3f, 0.3f, 0.4f);
			mountDatum.totalFrames = 1;
			numArray = new int[mountDatum.totalFrames];
			for (int q = 0; q < (int)numArray.Length; q++)
			{
				numArray[q] = 4;
			}
			mountDatum.playerYOffsets = numArray;
			mountDatum.xOffset = 1;
			mountDatum.bodyFrame = 3;
			mountDatum.yOffset = 4;
			mountDatum.playerHeadOffset = 18;
			mountDatum.standingFrameCount = 1;
			mountDatum.standingFrameDelay = 12;
			mountDatum.standingFrameStart = 0;
			mountDatum.runningFrameCount = 1;
			mountDatum.runningFrameDelay = 12;
			mountDatum.runningFrameStart = 0;
			mountDatum.flyingFrameCount = 1;
			mountDatum.flyingFrameDelay = 12;
			mountDatum.flyingFrameStart = 0;
			mountDatum.inAirFrameCount = 1;
			mountDatum.inAirFrameDelay = 12;
			mountDatum.inAirFrameStart = 0;
			mountDatum.idleFrameCount = 0;
			mountDatum.idleFrameDelay = 12;
			mountDatum.idleFrameStart = 8;
			mountDatum.swimFrameCount = 0;
			mountDatum.swimFrameDelay = 12;
			mountDatum.swimFrameStart = 0;
			Mount.drillTextureSize = new Vector2(80f, 80f);
			mountDatum = new Mount.MountData();
			Mount.mounts[9] = mountDatum;
			mountDatum.spawnDust = 152;
			mountDatum.buff = BuffID.ScutlixMount;
			mountDatum.heightBoost = 16;
			mountDatum.flightTimeMax = 0;
			mountDatum.fatigueMax = 0;
			mountDatum.fallDamage = 0f;
			mountDatum.abilityChargeMax = 40;
			mountDatum.abilityCooldown = 20;
			mountDatum.abilityDuration = 0;
			mountDatum.runSpeed = 8f;
			mountDatum.dashSpeed = 8f;
			mountDatum.acceleration = 0.4f;
			mountDatum.jumpHeight = 22;
			mountDatum.jumpSpeed = 10.01f;
			mountDatum.blockExtraJumps = false;
			mountDatum.totalFrames = 12;
			numArray = new int[mountDatum.totalFrames];
			for (int r = 0; r < (int)numArray.Length; r++)
			{
				numArray[r] = 16;
			}
			mountDatum.playerYOffsets = numArray;
			mountDatum.xOffset = 1;
			mountDatum.bodyFrame = 3;
			mountDatum.yOffset = 6;
			mountDatum.playerHeadOffset = 18;
			mountDatum.standingFrameCount = 6;
			mountDatum.standingFrameDelay = 12;
			mountDatum.standingFrameStart = 6;
			mountDatum.runningFrameCount = 6;
			mountDatum.runningFrameDelay = 12;
			mountDatum.runningFrameStart = 0;
			mountDatum.flyingFrameCount = 0;
			mountDatum.flyingFrameDelay = 12;
			mountDatum.flyingFrameStart = 0;
			mountDatum.inAirFrameCount = 1;
			mountDatum.inAirFrameDelay = 12;
			mountDatum.inAirFrameStart = 1;
			mountDatum.idleFrameCount = 0;
			mountDatum.idleFrameDelay = 12;
			mountDatum.idleFrameStart = 6;
			mountDatum.idleFrameLoop = true;
			mountDatum.swimFrameCount = 0;
			mountDatum.swimFrameDelay = 12;
			mountDatum.swimFrameStart = 0;
			Mount.scutlixEyePositions = new Vector2[] { new Vector2(60f, 2f), new Vector2(70f, 6f), new Vector2(68f, 6f), new Vector2(76f, 12f), new Vector2(80f, 10f), new Vector2(84f, 18f), new Vector2(74f, 20f), new Vector2(76f, 24f), new Vector2(70f, 34f), new Vector2(76f, 34f) };
			Mount.scutlixTextureSize = new Vector2(45f, 54f);
			for (int s = 0; s < (int)Mount.scutlixEyePositions.Length; s++)
			{
				Mount.scutlixEyePositions[s] = Mount.scutlixEyePositions[s] - Mount.scutlixTextureSize;
			}
			mountDatum = new Mount.MountData();
			Mount.mounts[10] = mountDatum;
			mountDatum.spawnDust = 15;
			mountDatum.buff = BuffID.UnicornMount;
			mountDatum.heightBoost = 34;
			mountDatum.flightTimeMax = 0;
			mountDatum.fallDamage = 0.2f;
			mountDatum.runSpeed = 4f;
			mountDatum.dashSpeed = 12f;
			mountDatum.acceleration = 0.3f;
			mountDatum.jumpHeight = 10;
			mountDatum.jumpSpeed = 8.01f;
			mountDatum.totalFrames = 16;
			numArray = new int[mountDatum.totalFrames];
			for (int t = 0; t < (int)numArray.Length; t++)
			{
				numArray[t] = 28;
			}
			numArray[3] = numArray[3] + 2;
			numArray[4] = numArray[4] + 2;
			numArray[7] = numArray[7] + 2;
			numArray[8] = numArray[8] + 2;
			numArray[12] = numArray[12] + 2;
			numArray[13] = numArray[13] + 2;
			numArray[15] = numArray[15] + 4;
			mountDatum.playerYOffsets = numArray;
			mountDatum.xOffset = 5;
			mountDatum.bodyFrame = 3;
			mountDatum.yOffset = 1;
			mountDatum.playerHeadOffset = 31;
			mountDatum.standingFrameCount = 1;
			mountDatum.standingFrameDelay = 12;
			mountDatum.standingFrameStart = 0;
			mountDatum.runningFrameCount = 7;
			mountDatum.runningFrameDelay = 15;
			mountDatum.runningFrameStart = 1;
			mountDatum.dashingFrameCount = 6;
			mountDatum.dashingFrameDelay = 40;
			mountDatum.dashingFrameStart = 9;
			mountDatum.flyingFrameCount = 6;
			mountDatum.flyingFrameDelay = 6;
			mountDatum.flyingFrameStart = 1;
			mountDatum.inAirFrameCount = 1;
			mountDatum.inAirFrameDelay = 12;
			mountDatum.inAirFrameStart = 15;
			mountDatum.idleFrameCount = 0;
			mountDatum.idleFrameDelay = 0;
			mountDatum.idleFrameStart = 0;
			mountDatum.idleFrameLoop = false;
			mountDatum.swimFrameCount = mountDatum.inAirFrameCount;
			mountDatum.swimFrameDelay = mountDatum.inAirFrameDelay;
			mountDatum.swimFrameStart = mountDatum.inAirFrameStart;
			mountDatum = new Mount.MountData();
			Mount.mounts[11] = mountDatum;
			mountDatum.Minecart = true;
			mountDatum.spawnDust = 213;
			mountDatum.buff = BuffID.MinecartLeftMech;
			mountDatum.extraBuff = 166;
			mountDatum.heightBoost = 12;
			mountDatum.flightTimeMax = 0;
			mountDatum.fallDamage = 1f;
			mountDatum.runSpeed = 20f;
			mountDatum.dashSpeed = 20f;
			mountDatum.acceleration = 0.1f;
			mountDatum.jumpHeight = 15;
			mountDatum.jumpSpeed = 5.15f;
			mountDatum.blockExtraJumps = true;
			mountDatum.totalFrames = 3;
			numArray = new int[mountDatum.totalFrames];
			for (int u = 0; u < (int)numArray.Length; u++)
			{
				numArray[u] = 9;
			}
			mountDatum.playerYOffsets = numArray;
			mountDatum.xOffset = -1;
			mountDatum.bodyFrame = 3;
			mountDatum.yOffset = 11;
			mountDatum.playerHeadOffset = 14;
			mountDatum.standingFrameCount = 1;
			mountDatum.standingFrameDelay = 12;
			mountDatum.standingFrameStart = 0;
			mountDatum.runningFrameCount = 3;
			mountDatum.runningFrameDelay = 12;
			mountDatum.runningFrameStart = 0;
			mountDatum.flyingFrameCount = 0;
			mountDatum.flyingFrameDelay = 0;
			mountDatum.flyingFrameStart = 0;
			mountDatum.inAirFrameCount = 0;
			mountDatum.inAirFrameDelay = 0;
			mountDatum.inAirFrameStart = 0;
			mountDatum.idleFrameCount = 0;
			mountDatum.idleFrameDelay = 0;
			mountDatum.idleFrameStart = 0;
			mountDatum.idleFrameLoop = false;
			mountDatum = new Mount.MountData();
			Mount.mounts[12] = mountDatum;
			mountDatum.spawnDust = 15;
			mountDatum.buff = BuffID.CuteFishronMount;
			mountDatum.heightBoost = 20;
			mountDatum.flightTimeMax = 320;
			mountDatum.fatigueMax = 320;
			mountDatum.fallDamage = 0f;
			mountDatum.usesHover = true;
			mountDatum.runSpeed = 2f;
			mountDatum.dashSpeed = 1f;
			mountDatum.acceleration = 0.2f;
			mountDatum.jumpHeight = 4;
			mountDatum.jumpSpeed = 3f;
			mountDatum.swimSpeed = 16f;
			mountDatum.blockExtraJumps = true;
			mountDatum.totalFrames = 23;
			numArray = new int[mountDatum.totalFrames];
			for (int v = 0; v < (int)numArray.Length; v++)
			{
				numArray[v] = 12;
			}
			mountDatum.playerYOffsets = numArray;
			mountDatum.xOffset = 2;
			mountDatum.bodyFrame = 3;
			mountDatum.yOffset = 16;
			mountDatum.playerHeadOffset = 31;
			mountDatum.standingFrameCount = 1;
			mountDatum.standingFrameDelay = 12;
			mountDatum.standingFrameStart = 8;
			mountDatum.runningFrameCount = 7;
			mountDatum.runningFrameDelay = 14;
			mountDatum.runningFrameStart = 8;
			mountDatum.flyingFrameCount = 8;
			mountDatum.flyingFrameDelay = 16;
			mountDatum.flyingFrameStart = 0;
			mountDatum.inAirFrameCount = 8;
			mountDatum.inAirFrameDelay = 6;
			mountDatum.inAirFrameStart = 0;
			mountDatum.idleFrameCount = 0;
			mountDatum.idleFrameDelay = 0;
			mountDatum.idleFrameStart = 0;
			mountDatum.idleFrameLoop = false;
			mountDatum.swimFrameCount = 8;
			mountDatum.swimFrameDelay = 4;
			mountDatum.swimFrameStart = 15;
			mountDatum = new Mount.MountData();
			Mount.mounts[13] = mountDatum;
			mountDatum.Minecart = true;
			mountDatum.MinecartDirectional = true;
			mountDatum.spawnDust = 213;
			mountDatum.buff = BuffID.MinecartLeftWood;
			mountDatum.extraBuff = 185;
			mountDatum.heightBoost = 10;
			mountDatum.flightTimeMax = 0;
			mountDatum.fallDamage = 1f;
			mountDatum.runSpeed = 10f;
			mountDatum.dashSpeed = 10f;
			mountDatum.acceleration = 0.03f;
			mountDatum.jumpHeight = 12;
			mountDatum.jumpSpeed = 5.15f;
			mountDatum.blockExtraJumps = true;
			mountDatum.totalFrames = 3;
			numArray = new int[mountDatum.totalFrames];
			for (int w = 0; w < (int)numArray.Length; w++)
			{
				numArray[w] = 8;
			}
			mountDatum.playerYOffsets = numArray;
			mountDatum.xOffset = 1;
			mountDatum.bodyFrame = 3;
			mountDatum.yOffset = 13;
			mountDatum.playerHeadOffset = 14;
			mountDatum.standingFrameCount = 1;
			mountDatum.standingFrameDelay = 12;
			mountDatum.standingFrameStart = 0;
			mountDatum.runningFrameCount = 3;
			mountDatum.runningFrameDelay = 12;
			mountDatum.runningFrameStart = 0;
			mountDatum.flyingFrameCount = 0;
			mountDatum.flyingFrameDelay = 0;
			mountDatum.flyingFrameStart = 0;
			mountDatum.inAirFrameCount = 0;
			mountDatum.inAirFrameDelay = 0;
			mountDatum.inAirFrameStart = 0;
			mountDatum.idleFrameCount = 0;
			mountDatum.idleFrameDelay = 0;
			mountDatum.idleFrameStart = 0;
			mountDatum.idleFrameLoop = false;
		}

		public int JumpHeight(float xVelocity)
		{
			int num = this._data.jumpHeight;
			switch (this._type)
			{
				case 0:
				{
					num = num + (int)(Math.Abs(xVelocity) / 4f);
					return num;
				}
				case 1:
				{
					num = num + (int)(Math.Abs(xVelocity) / 2.5f);
					return num;
				}
				case 2:
				case 3:
				{
					return num;
				}
				case 4:
				{
					if (this._frameState != 4)
					{
						return num;
					}
					num = num + 5;
					return num;
				}
				default:
				{
					return num;
				}
			}
		}

		public float JumpSpeed(float xVelocity)
		{
			float single = this._data.jumpSpeed;
			switch (this._type)
			{
				case 0:
				case 1:
				{
					single = single + Math.Abs(xVelocity) / 7f;
					return single;
				}
				case 2:
				case 3:
				{
					return single;
				}
				case 4:
				{
					if (this._frameState != 4)
					{
						return single;
					}
					single = single + 2.5f;
					return single;
				}
				default:
				{
					return single;
				}
			}
		}

		public void Reset()
		{
			this._active = false;
			this._type = -1;
			this._flipDraw = false;
			this._frame = 0;
			this._frameCounter = 0f;
			this._frameExtra = 0;
			this._frameExtraCounter = 0f;
			this._frameState = 0;
			this._flyTime = 0;
			this._idleTime = 0;
			this._idleTimeNext = -1;
			this._fatigueMax = 0f;
			this._abilityCharging = false;
			this._abilityCharge = 0;
			this._aiming = false;
		}

		public void ResetFlightTime(float xVelocity)
		{
			this._flyTime = (this._active ? this._data.flightTimeMax : 0);
			if (this._type == 0)
			{
				Mount mount = this;
				mount._flyTime = mount._flyTime + (int)(Math.Abs(xVelocity) * 20f);
			}
		}

		public void ResetHeadPosition()
		{
			if (this._aiming)
			{
				this._aiming = false;
				this._frameExtra = 0;
				this._flipDraw = false;
			}
		}

		public void SetMount(int m, Player mountedPlayer, bool faceLeft = false)
		{
			if (this._type == m || m <= -1 || m >= 14)
			{
				return;
			}
			if (m == 5 && mountedPlayer.wet)
			{
				return;
			}
			if (!this._active)
			{
				this._active = true;
			}
			else
			{
				mountedPlayer.ClearBuff(this._data.buff);
				if (this.Cart)
				{
					mountedPlayer.ClearBuff(this._data.extraBuff);
					mountedPlayer.cartFlip = false;
					mountedPlayer.lastBoost = Vector2.Zero;
				}
				mountedPlayer.fullRotation = 0f;
				mountedPlayer.fullRotationOrigin = Vector2.Zero;
				this._mountSpecificData = null;
			}
			this._flyTime = 0;
			this._type = m;
			this._data = Mount.mounts[m];
			this._fatigueMax = (float)this._data.fatigueMax;
			if (!this.Cart || faceLeft || this.Directional)
			{
				mountedPlayer.AddBuff(this._data.buff, 3600, true);
				this._flipDraw = false;
			}
			else
			{
				mountedPlayer.AddBuff(this._data.extraBuff, 3600, true);
				this._flipDraw = true;
			}
			if (this._type == 9 && this._abilityCooldown < 20)
			{
				this._abilityCooldown = 20;
			}
			mountedPlayer.position.Y = mountedPlayer.position.Y + (float)mountedPlayer.height;
			for (int i = 0; i < (int)mountedPlayer.shadowPos.Length; i++)
			{
				mountedPlayer.shadowPos[i].Y = mountedPlayer.shadowPos[i].Y + (float)mountedPlayer.height;
			}
			mountedPlayer.height = 42 + this._data.heightBoost;
			mountedPlayer.position.Y = mountedPlayer.position.Y - (float)mountedPlayer.height;
			for (int j = 0; j < (int)mountedPlayer.shadowPos.Length; j++)
			{
				mountedPlayer.shadowPos[j].Y = mountedPlayer.shadowPos[j].Y - (float)mountedPlayer.height;
			}
			if (this._type == 7 || this._type == 8)
			{
				mountedPlayer.fullRotationOrigin = new Vector2((float)(mountedPlayer.width / 2), (float)(mountedPlayer.height / 2));
			}
			if (this._type == 8)
			{
				this._mountSpecificData = new Mount.DrillMountData();
			}
			if (Main.netMode != 2)
			{
			}
			if (mountedPlayer.whoAmI == Main.myPlayer)
			{
				NetMessage.SendData((int)PacketTypes.PlayerUpdate, -1, -1, "", mountedPlayer.whoAmI, 0f, 0f, 0f, 0, 0, 0);
			}
		}

		public void StartAbilityCharge(Player mountedPlayer)
		{
			if (Main.myPlayer != mountedPlayer.whoAmI)
			{
				if (this._type != 9)
				{
					return;
				}
				this._abilityCharging = true;
				return;
			}
			if (this._type != 9)
			{
				return;
			}
			float x = Main.screenPosition.X + (float)Main.mouseX;
			float y = Main.screenPosition.Y + (float)Main.mouseY;
			float single = x - mountedPlayer.position.X;
			float y1 = y - mountedPlayer.position.Y;
			Projectile.NewProjectile(x, y, 0f, 0f, ProjectileID.ScutlixLaserCrosshair, 0, 0f, mountedPlayer.whoAmI, single, y1);
			this._abilityCharging = true;
		}

		public void StopAbilityCharge()
		{
			if (this._type != 9)
			{
				return;
			}
			this._abilityCharging = false;
			this._abilityCooldown = this._data.abilityCooldown;
			this._abilityDuration = this._data.abilityDuration;
		}

		public void UpdateDrill(Player mountedPlayer, bool controlUp, bool controlDown)
		{
			// Serverside drill code causes the world to be permanently changed whilst on the DCU
//			Mount.DrillMountData drillMountDatum = (Mount.DrillMountData)this._mountSpecificData;
//			for (int i = 0; i < (int)drillMountDatum.beams.Length; i++)
//			{
//				Mount.DrillBeam negativeOne = drillMountDatum.beams[i];
//				if (negativeOne.cooldown > 1)
//				{
//					Mount.DrillBeam drillBeam = negativeOne;
//					drillBeam.cooldown = drillBeam.cooldown - 1;
//				}
//				else if (negativeOne.cooldown == 1)
//				{
//					negativeOne.cooldown = 0;
//					negativeOne.curTileTarget = Point16.NegativeOne;
//				}
//			}
//			drillMountDatum.diodeRotation = drillMountDatum.diodeRotation * 0.85f + 0.15f * drillMountDatum.diodeRotationTarget;
//			if (drillMountDatum.beamCooldown > 0)
//			{
//				Mount.DrillMountData drillMountDatum1 = drillMountDatum;
//				drillMountDatum1.beamCooldown = drillMountDatum1.beamCooldown - 1;
//			}
		}

		public void UpdateEffects(Player mountedPlayer)
		{
			mountedPlayer.autoJump = this.AutoJump;
			switch (this._type)
			{
				case 8:
				{
					if (mountedPlayer.ownedProjectileCounts[ProjectileID.DrillMountCrosshair] >= 1)
					{
						break;
					}
					this._abilityActive = false;
					return;
				}
				case 9:
				{
					Vector2 center = mountedPlayer.Center;
					Vector2 vector2 = center;
					bool flag = false;
					float single = 1500f;
					for (int i = 0; i < 200; i++)
					{
						NPC nPC = Main.npc[i];
						if (nPC.CanBeChasedBy(this, false))
						{
							float single1 = Vector2.Distance(nPC.Center, vector2);
							if ((Vector2.Distance(vector2, vector2) > single1 && single1 < single || !flag) && Collision.CanHitLine(center, 0, 0, nPC.position, nPC.width, nPC.height))
							{
								single = single1;
								vector2 = nPC.Center;
								flag = true;
							}
						}
					}
					bool flag1 = flag;
					float single2 = Math.Abs((vector2 - center).ToRotation());
					if (mountedPlayer.direction == 1 && (double)single2 > 1.04719759490799)
					{
						flag1 = false;
					}
					else if (mountedPlayer.direction == -1 && (double)single2 < 2.09439514610459)
					{
						flag1 = false;
					}
					else if (!Collision.CanHitLine(center, 0, 0, vector2, 0, 0))
					{
						flag1 = false;
					}
					if (!flag1)
					{
						this._abilityCharging = false;
						this.ResetHeadPosition();
						return;
					}
					if (this._abilityCooldown != 0 || mountedPlayer.whoAmI != Main.myPlayer)
					{
						this.AimAbility(mountedPlayer, vector2);
						this._abilityCharging = true;
						return;
					}
					this.AimAbility(mountedPlayer, vector2);
					this.StopAbilityCharge();
					this.UseAbility(mountedPlayer, vector2, false);
					return;
				}
				case 10:
				{
					mountedPlayer.doubleJumpUnicorn = true;
					if (Math.Abs(mountedPlayer.velocity.X) > mountedPlayer.mount.DashSpeed - mountedPlayer.mount.RunSpeed / 2f)
					{
						mountedPlayer.noKnockback = true;
					}
					if (mountedPlayer.itemAnimation <= 0 || mountedPlayer.inventory[mountedPlayer.selectedItem].type != 1260)
					{
						break;
					}
					AchievementsHelper.HandleSpecialEvent(mountedPlayer, 5);
					return;
				}
				case 11:
				{
					Vector3 vector3 = new Vector3(0.4f, 0.12f, 0.15f);
					float single3 = 1f + Math.Abs(mountedPlayer.velocity.X) / this.RunSpeed * 2.5f;
					Player player = mountedPlayer;
					player.statDefense = player.statDefense + (int)(2f * single3);
					int num = Math.Sign(mountedPlayer.velocity.X);
					if (num == 0)
					{
						num = mountedPlayer.direction;
					}
					if (Main.netMode != 2)
					{
						float single4 = -24f;
						if (mountedPlayer.direction != num)
						{
							single4 = -22f;
						}
						if (num == -1)
						{
							single4 = single4 + 1f;
						}
						Vector2 vector21 = (new Vector2(single4 * (float)num, -19f)).RotatedBy((double)mountedPlayer.fullRotation, new Vector2());
						Vector2 vector22 = (new Vector2(MathHelper.Lerp(0f, -8f, mountedPlayer.fullRotation / 0.7853982f), MathHelper.Lerp(0f, 2f, Math.Abs(mountedPlayer.fullRotation / 0.7853982f)))).RotatedBy((double)mountedPlayer.fullRotation, new Vector2());
						if (num == Math.Sign(mountedPlayer.fullRotation))
						{
							vector22 = vector22 * MathHelper.Lerp(1f, 0.6f, Math.Abs(mountedPlayer.fullRotation / 0.7853982f));
						}
						Vector2 bottom = (mountedPlayer.Bottom + vector21) + vector22;
						Vector2 vector23 = ((mountedPlayer.oldPosition + (mountedPlayer.Size * new Vector2(0.5f, 1f))) + vector21) + vector22;
						if (Vector2.Distance(bottom, vector23) <= 3f)
						{
						}
						else
						{
							int num1 = (int)Vector2.Distance(bottom, vector23) / 3;
							if (Vector2.Distance(bottom, vector23) % 3f != 0f)
							{
								num1++;
							}
						}
					}
					if (mountedPlayer.whoAmI != Main.myPlayer || mountedPlayer.velocity.X == 0f)
					{
						break;
					}
					Vector2 minecartMechPoint = Mount.GetMinecartMechPoint(mountedPlayer, 20, -19);
					int num2 = 60;
					int num3 = 0;
					float rotation = 0f;
					for (int k = 0; k < 200; k++)
					{
						NPC nPC1 = Main.npc[k];
						if (nPC1.active && nPC1.immune[mountedPlayer.whoAmI] <= 0 && !nPC1.dontTakeDamage && nPC1.Distance(minecartMechPoint) < 300f && nPC1.CanBeChasedBy(mountedPlayer, false) && Collision.CanHitLine(nPC1.position, nPC1.width, nPC1.height, minecartMechPoint, 0, 0))
						{
							if (Math.Abs(MathHelper.WrapAngle(MathHelper.WrapAngle(nPC1.AngleFrom(minecartMechPoint)) - MathHelper.WrapAngle((mountedPlayer.fullRotation + (float)num == -1f ? 3.14159274f : 0f)))) < 0.7853982f)
							{
								Vector2 size = (nPC1.position + (nPC1.Size * Utils.RandomVector2(Main.rand, 0f, 1f))) - minecartMechPoint;
								rotation = rotation + size.ToRotation();
								num3++;
								int num4 = Projectile.NewProjectile(minecartMechPoint.X, minecartMechPoint.Y, size.X, size.Y, 591, 0, 0f, mountedPlayer.whoAmI, (float)mountedPlayer.whoAmI, 0f);
								Main.projectile[num4].Center = nPC1.Center;
								Main.projectile[num4].damage = num2;
								Main.projectile[num4].Damage();
								Main.projectile[num4].damage = 0;
								Main.projectile[num4].Center = minecartMechPoint;
							}
						}
					}
					break;
				}
				case 12:
				{
					if (mountedPlayer.MountFishronSpecial)
					{
						Player player1 = mountedPlayer;
						player1.meleeDamage = player1.meleeDamage + 0.15f;
						Player player2 = mountedPlayer;
						player2.rangedDamage = player2.rangedDamage + 0.15f;
						Player player3 = mountedPlayer;
						player3.magicDamage = player3.magicDamage + 0.15f;
						Player player4 = mountedPlayer;
						player4.minionDamage = player4.minionDamage + 0.15f;
						Player player5 = mountedPlayer;
						player5.thrownDamage = player5.thrownDamage + 0.15f;
					}
					if (mountedPlayer.statLife <= mountedPlayer.statLifeMax2 / 2)
					{
						mountedPlayer.MountFishronSpecialCounter = 60f;
					}
					if (!mountedPlayer.wet)
					{
						break;
					}
					mountedPlayer.MountFishronSpecialCounter = 300f;
					return;
				}
				default:
				{
					return;
				}
			}
		}

		public void UpdateFrame(Player mountedPlayer, int state, Vector2 velocity)
		{
			Vector2 vector2 = new Vector2();
			float single;
			if (this._frameState != state)
			{
				this._frameState = state;
				this._frameCounter = 0f;
			}
			if (state != 0)
			{
				this._idleTime = 0;
			}
			switch (this._type)
			{
				case 5:
				{
					if (state == 2)
					{
						goto case 6;
					}
					this._frameExtra = 0;
					this._frameExtraCounter = 0f;
					goto case 6;
				}
				case 6:
				{
					switch (state)
					{
						case 0:
						{
							if (this._data.idleFrameCount != 0)
							{
								if (this._type != 5)
								{
									if (this._idleTime == 0)
									{
										this._idleTimeNext = Main.rand.Next(900, 1500);
									}
								}
								else if (this._fatigue == 0f)
								{
									this._idleTime = 0;
									this._idleTimeNext = 2;
								}
								else if (this._idleTime == 0)
								{
									this._idleTimeNext = this._idleTime + 1;
								}
								Mount mount = this;
								mount._idleTime = mount._idleTime + 1;
							}
							Mount mount1 = this;
							mount1._frameCounter = mount1._frameCounter + 1f;
							if (this._data.idleFrameCount == 0 || this._idleTime < this._idleTimeNext)
							{
								if (this._frameCounter > (float)this._data.standingFrameDelay)
								{
									Mount mount2 = this;
									mount2._frameCounter = mount2._frameCounter - (float)this._data.standingFrameDelay;
									Mount mount3 = this;
									mount3._frame = mount3._frame + 1;
								}
								if (this._frame >= this._data.standingFrameStart && this._frame < this._data.standingFrameStart + this._data.standingFrameCount)
								{
									break;
								}
								this._frame = this._data.standingFrameStart;
								return;
							}
							else
							{
								float single1 = (float)this._data.idleFrameDelay;
								if (this._type == 5)
								{
									single1 = single1 * (2f - 1f * this._fatigue / this._fatigueMax);
								}
								int num = (int)((float)(this._idleTime - this._idleTimeNext) / single1);
								if (num < this._data.idleFrameCount)
								{
									this._frame = this._data.idleFrameStart + num;
								}
								else if (!this._data.idleFrameLoop)
								{
									this._frameCounter = 0f;
									this._frame = this._data.standingFrameStart;
									this._idleTime = 0;
								}
								else
								{
									this._idleTime = this._idleTimeNext;
									this._frame = this._data.idleFrameStart;
								}
								if (this._type != 5)
								{
									break;
								}
								this._frameExtra = this._frame;
								return;
							}
						}
						case 1:
						{
							int num1 = this._type;
							if (num1 == 6)
							{
								single = (this._flipDraw ? velocity.X : -velocity.X);
							}
							else if (num1 == 9)
							{
								single = (!this._flipDraw ? Math.Abs(velocity.X) : -Math.Abs(velocity.X));
							}
							else if (num1 == 13)
							{
								single = (this._flipDraw ? velocity.X : -velocity.X);
							}
							else
							{
								single = Math.Abs(velocity.X);
							}
							Mount mount4 = this;
							mount4._frameCounter = mount4._frameCounter + single;
							if (single < 0f)
							{
								if (this._frameCounter < 0f)
								{
									Mount mount5 = this;
									mount5._frameCounter = mount5._frameCounter + (float)this._data.runningFrameDelay;
									Mount mount6 = this;
									mount6._frame = mount6._frame - 1;
								}
								if (this._frame >= this._data.runningFrameStart && this._frame < this._data.runningFrameStart + this._data.runningFrameCount)
								{
									break;
								}
								this._frame = this._data.runningFrameStart + this._data.runningFrameCount - 1;
								return;
							}
							else
							{
								if (this._frameCounter > (float)this._data.runningFrameDelay)
								{
									Mount mount7 = this;
									mount7._frameCounter = mount7._frameCounter - (float)this._data.runningFrameDelay;
									Mount mount8 = this;
									mount8._frame = mount8._frame + 1;
								}
								if (this._frame >= this._data.runningFrameStart && this._frame < this._data.runningFrameStart + this._data.runningFrameCount)
								{
									break;
								}
								this._frame = this._data.runningFrameStart;
								return;
							}
						}
						case 2:
						{
							Mount mount9 = this;
							mount9._frameCounter = mount9._frameCounter + 1f;
							if (this._frameCounter > (float)this._data.inAirFrameDelay)
							{
								Mount mount10 = this;
								mount10._frameCounter = mount10._frameCounter - (float)this._data.inAirFrameDelay;
								Mount mount11 = this;
								mount11._frame = mount11._frame + 1;
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
								this._frame = 6;
								return;
							}
							if (this._type != 5)
							{
								break;
							}
							float single2 = this._fatigue / this._fatigueMax;
							Mount mount12 = this;
							mount12._frameExtraCounter = mount12._frameExtraCounter + (6f - 4f * single2);
							if (this._frameExtraCounter > (float)this._data.flyingFrameDelay)
							{
								Mount mount13 = this;
								mount13._frameExtra = mount13._frameExtra + 1;
								Mount mount14 = this;
								mount14._frameExtraCounter = mount14._frameExtraCounter - (float)this._data.flyingFrameDelay;
							}
							if (this._frameExtra >= this._data.flyingFrameStart && this._frameExtra < this._data.flyingFrameStart + this._data.flyingFrameCount)
							{
								break;
							}
							this._frameExtra = this._data.flyingFrameStart;
							return;
						}
						case 3:
						{
							Mount mount15 = this;
							mount15._frameCounter = mount15._frameCounter + 1f;
							if (this._frameCounter > (float)this._data.flyingFrameDelay)
							{
								Mount mount16 = this;
								mount16._frameCounter = mount16._frameCounter - (float)this._data.flyingFrameDelay;
								Mount mount17 = this;
								mount17._frame = mount17._frame + 1;
							}
							if (this._frame >= this._data.flyingFrameStart && this._frame < this._data.flyingFrameStart + this._data.flyingFrameCount)
							{
								break;
							}
							this._frame = this._data.flyingFrameStart;
							return;
						}
						case 4:
						{
							Mount mount18 = this;
							mount18._frameCounter = mount18._frameCounter + (float)((int)((Math.Abs(velocity.X) + Math.Abs(velocity.Y)) / 2f));
							if (this._frameCounter > (float)this._data.swimFrameDelay)
							{
								Mount mount19 = this;
								mount19._frameCounter = mount19._frameCounter - (float)this._data.swimFrameDelay;
								Mount mount20 = this;
								mount20._frame = mount20._frame + 1;
							}
							if (this._frame >= this._data.swimFrameStart && this._frame < this._data.swimFrameStart + this._data.swimFrameCount)
							{
								break;
							}
							this._frame = this._data.swimFrameStart;
							return;
						}
						case 5:
						{
							int num2 = this._type;
							if (num2 == 6)
							{
								single = (this._flipDraw ? velocity.X : -velocity.X);
							}
							else if (num2 == 9)
							{
								single = (!this._flipDraw ? Math.Abs(velocity.X) : -Math.Abs(velocity.X));
							}
							else if (num2 == 13)
							{
								single = (this._flipDraw ? velocity.X : -velocity.X);
							}
							else
							{
								single = Math.Abs(velocity.X);
							}
							Mount mount21 = this;
							mount21._frameCounter = mount21._frameCounter + single;
							if (single < 0f)
							{
								if (this._frameCounter < 0f)
								{
									Mount mount22 = this;
									mount22._frameCounter = mount22._frameCounter + (float)this._data.dashingFrameDelay;
									Mount mount23 = this;
									mount23._frame = mount23._frame - 1;
								}
								if (this._frame >= this._data.dashingFrameStart && this._frame < this._data.dashingFrameStart + this._data.dashingFrameCount)
								{
									break;
								}
								this._frame = this._data.dashingFrameStart + this._data.dashingFrameCount - 1;
								break;
							}
							else
							{
								if (this._frameCounter > (float)this._data.dashingFrameDelay)
								{
									Mount mount24 = this;
									mount24._frameCounter = mount24._frameCounter - (float)this._data.dashingFrameDelay;
									Mount mount25 = this;
									mount25._frame = mount25._frame + 1;
								}
								if (this._frame >= this._data.dashingFrameStart && this._frame < this._data.dashingFrameStart + this._data.dashingFrameCount)
								{
									break;
								}
								this._frame = this._data.dashingFrameStart;
								return;
							}
						}
						default:
						{
							return;
						}
					}
					return;
				}
				case 7:
				{
					state = 2;
					goto case 6;
				}
				case 8:
				{
					if (state != 0 && state != 1)
					{
						goto case 6;
					}
					vector2.X = mountedPlayer.position.X;
					vector2.Y = mountedPlayer.position.Y + (float)mountedPlayer.height;
					int x = (int)(vector2.X / 16f);
					float y = vector2.Y / 16f;
					float tileRotation = 0f;
					float single3 = (float)mountedPlayer.width;
					while (single3 > 0f)
					{
						float single4 = (float)((x + 1) * 16);
						float x1 = single4 - vector2.X;
						if (x1 > single3)
						{
							x1 = single3;
						}
						tileRotation = tileRotation + Collision.GetTileRotation(vector2) * x1;
						single3 = single3 - x1;
						vector2.X = vector2.X + x1;
						x++;
					}
					float single5 = tileRotation / (float)mountedPlayer.width - mountedPlayer.fullRotation;
					float single6 = 0f;
					float single7 = 0.157079637f;
					if (single5 < 0f)
					{
						single6 = (single5 <= -single7 ? -single7 : single5);
					}
					else if (single5 > 0f)
					{
						single6 = (single5 >= single7 ? single7 : single5);
					}
					if (single6 == 0f)
					{
						goto case 6;
					}
					Player player = mountedPlayer;
					player.fullRotation = player.fullRotation + single6;
					if (mountedPlayer.fullRotation > 0.7853982f)
					{
						mountedPlayer.fullRotation = 0.7853982f;
					}
					if (mountedPlayer.fullRotation >= -0.7853982f)
					{
						goto case 6;
					}
					mountedPlayer.fullRotation = -0.7853982f;
					goto case 6;
				}
				case 9:
				{
					if (this._aiming)
					{
						goto case 6;
					}
					Mount mount26 = this;
					mount26._frameExtraCounter = mount26._frameExtraCounter + 1f;
					if (this._frameExtraCounter < 12f)
					{
						goto case 6;
					}
					this._frameExtraCounter = 0f;
					Mount mount27 = this;
					mount27._frameExtra = mount27._frameExtra + 1;
					if (this._frameExtra < 6)
					{
						goto case 6;
					}
					this._frameExtra = 0;
					goto case 6;
				}
				case 10:
				{
					bool flag = Math.Abs(velocity.X) > this.DashSpeed - this.RunSpeed / 2f;
					if (state == 1)
					{
						bool flag1 = false;
						if (!flag)
						{
							this._frameExtra = 0;
						}
						else
						{
							state = 5;
							if (this._frameExtra < 6)
							{
								flag1 = true;
							}
							Mount mount28 = this;
							mount28._frameExtra = mount28._frameExtra + 1;
						}
						if (flag1)
						{
							Vector2 center = mountedPlayer.Center + new Vector2((float)(mountedPlayer.width * mountedPlayer.direction), 0f);
							Vector2 vector21 = new Vector2(40f, 30f);
							float single8 = 6.28318548f * Main.rand.NextFloat();
						}
					}
					if (!flag)
					{
						goto case 6;
					}
					goto case 6;
				}
				default:
				{
					goto case 6;
				}
			}
		}

		public void UseAbility(Player mountedPlayer, Vector2 mousePosition, bool toggleOn)
		{
			Vector2 vector2 = new Vector2();
			Vector2 x = new Vector2();
			switch (this._type)
			{
				case 8:
				{
					if (Main.myPlayer != mountedPlayer.whoAmI)
					{
						this._abilityActive = toggleOn;
						break;
					}
					else
					{
						if (!toggleOn)
						{
							this._abilityActive = false;
							return;
						}
						if (this._abilityActive)
						{
							break;
						}
						if (mountedPlayer.whoAmI == Main.myPlayer)
						{
							float single = Main.screenPosition.X + (float)Main.mouseX;
							float y = Main.screenPosition.Y + (float)Main.mouseY;
							float x1 = single - mountedPlayer.position.X;
							float y1 = y - mountedPlayer.position.Y;
							Projectile.NewProjectile(single, y, 0f, 0f, ProjectileID.DrillMountCrosshair, 0, 0f, mountedPlayer.whoAmI, x1, y1);
						}
						this._abilityActive = true;
						return;
					}
				}
				case 9:
				{
					if (Main.myPlayer != mountedPlayer.whoAmI)
					{
						break;
					}
					mousePosition = this.ClampToDeadZone(mountedPlayer, mousePosition);
					x.X = mountedPlayer.position.X + (float)(mountedPlayer.width / 2);
					x.Y = mountedPlayer.position.Y + (float)mountedPlayer.height;
					int num = (this._frameExtra - 6) * 2;
					for (int i = 0; i < 2; i++)
					{
						vector2.Y = x.Y + Mount.scutlixEyePositions[num + i].Y + (float)this._data.yOffset;
						if (mountedPlayer.direction != -1)
						{
							vector2.X = x.X + Mount.scutlixEyePositions[num + i].X + (float)this._data.xOffset;
						}
						else
						{
							vector2.X = x.X - Mount.scutlixEyePositions[num + i].X - (float)this._data.xOffset;
						}
						Vector2 vector21 = mousePosition - vector2;
						vector21.Normalize();
						vector21 = vector21 * 14f;
						int num1 = 100;
						vector2 = vector2 + vector21;
						Projectile.NewProjectile(vector2.X, vector2.Y, vector21.X, vector21.Y, 606, num1, 0f, Main.myPlayer, 0f, 0f);
					}
					return;
				}
				default:
				{
					return;
				}
			}
		}

		public void UseDrill(Player mountedPlayer)
		{
			if (this._type != 8 || !this._abilityActive)
			{
				return;
			}
			Mount.DrillMountData drillMountData = (Mount.DrillMountData)this._mountSpecificData;
			if (drillMountData.beamCooldown == 0)
			{
				int i = 0;
				while (i < (int)drillMountData.beams.Length)
				{
					Mount.DrillBeam drillBeam = drillMountData.beams[i];
					if (drillBeam.cooldown == 0)
					{
						Point16 point = this.DrillSmartCursor(mountedPlayer, drillMountData);
						if (point != Point16.NegativeOne)
						{
							drillBeam.curTileTarget = point;
							int pickPower = Mount.drillPickPower;
							bool flag = mountedPlayer.whoAmI == Main.myPlayer;
							if (flag)
							{
								mountedPlayer.PickTile((int)point.X, (int)point.Y, pickPower);
							}
							if (flag)
							{
								Tile.SmoothSlope((int)point.X, (int)point.Y, true);
							}
							drillBeam.cooldown = Mount.drillPickTime;
							break;
						}
						break;
					}
					else
					{
						i++;
					}
				}
				drillMountData.beamCooldown = Mount.drillBeamCooldownMax;
			}
		}

		private class DrillBeam
		{
			public Point16 curTileTarget;

			public int cooldown;

			public DrillBeam()
			{
				this.curTileTarget = Point16.NegativeOne;
				this.cooldown = 0;
			}
		}

		private class DrillMountData
		{
			public float diodeRotationTarget;

			public float diodeRotation;

			public float outerRingRotation;

			public Mount.DrillBeam[] beams;

			public int beamCooldown;

			public Vector2 crosshairPosition;

			public DrillMountData()
			{
				this.beams = new Mount.DrillBeam[4];
				for (int i = 0; i < (int)this.beams.Length; i++)
				{
					this.beams[i] = new Mount.DrillBeam();
				}
			}
		}

		private class MountData
		{
			public int xOffset;

			public int yOffset;

			public int[] playerYOffsets;

			public int bodyFrame;

			public int playerHeadOffset;

			public int heightBoost;

			public int buff;

			public int extraBuff;

			public int flightTimeMax;

			public bool usesHover;

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

			public int abilityChargeMax;

			public int abilityDuration;

			public int abilityCooldown;

			public int spawnDust;

			public bool spawnDustNoGravity;

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

			public int dashingFrameStart;

			public int dashingFrameCount;

			public int dashingFrameDelay;

			public bool Minecart;

			public bool MinecartDirectional;

			public Vector3 lightColor;

			public bool emitsLight;

			public MountData()
			{
			}
		}
	}
}
