
using System;
using Hooks;
namespace Terraria
{
	public class Projectile
	{
		public bool wet;
		public byte wetCount;
		public bool lavaWet;
		public int whoAmI;
		public static int maxAI = 2;
		public Microsoft.Xna.Framework.Vector2 position;
		public Microsoft.Xna.Framework.Vector2 lastPosition;
		public Microsoft.Xna.Framework.Vector2 velocity;
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
		public Microsoft.Xna.Framework.Vector2[] oldPos = new Microsoft.Xna.Framework.Vector2[10];
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
			this.position = default(Microsoft.Xna.Framework.Vector2);
			this.velocity = default(Microsoft.Xna.Framework.Vector2);
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
			else
			{
				if (this.type == 2)
				{
					this.name = "Fire Arrow";
					this.width = 10;
					this.height = 10;
					this.aiStyle = 1;
					this.friendly = true;
					this.light = 1f;
					this.ranged = true;
				}
				else
				{
					if (this.type == 3)
					{
						this.name = "Shuriken";
						this.width = 22;
						this.height = 22;
						this.aiStyle = 2;
						this.friendly = true;
						this.penetrate = 4;
						this.ranged = true;
					}
					else
					{
						if (this.type == 4)
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
						else
						{
							if (this.type == 5)
							{
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
							}
							else
							{
								if (this.type == 6)
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
								else
								{
									if (this.type == 7 || this.type == 8)
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
									else
									{
										if (this.type == 9)
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
										else
										{
											if (this.type == 10)
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
											else
											{
												if (this.type == 11)
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
												else
												{
													if (this.type == 12)
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
													else
													{
														if (this.type == 13)
														{
															this.name = "Hook";
															this.width = 18;
															this.height = 18;
															this.aiStyle = 7;
															this.friendly = true;
															this.penetrate = -1;
															this.tileCollide = false;
															this.timeLeft *= 10;
														}
														else
														{
															if (this.type == 14)
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
															else
															{
																if (this.type == 15)
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
																else
																{
																	if (this.type == 16)
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
																	else
																	{
																		if (this.type == 17)
																		{
																			this.name = "Dirt Ball";
																			this.width = 10;
																			this.height = 10;
																			this.aiStyle = 10;
																			this.friendly = true;
																		}
																		else
																		{
																			if (this.type == 18)
																			{
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
																			}
																			else
																			{
																				if (this.type == 19)
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
																				else
																				{
																					if (this.type == 20)
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
																					else
																					{
																						if (this.type == 21)
																						{
																							this.name = "Bone";
																							this.width = 16;
																							this.height = 16;
																							this.aiStyle = 2;
																							this.scale = 1.2f;
																							this.friendly = true;
																							this.ranged = true;
																						}
																						else
																						{
																							if (this.type == 22)
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
																							else
																							{
																								if (this.type == 23)
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
																								else
																								{
																									if (this.type == 24)
																									{
																										this.name = "Spiky Ball";
																										this.width = 14;
																										this.height = 14;
																										this.aiStyle = 14;
																										this.friendly = true;
																										this.penetrate = 6;
																										this.ranged = true;
																									}
																									else
																									{
																										if (this.type == 25)
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
																										else
																										{
																											if (this.type == 26)
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
																											else
																											{
																												if (this.type == 27)
																												{
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
																												}
																												else
																												{
																													if (this.type == 28)
																													{
																														this.name = "Bomb";
																														this.width = 22;
																														this.height = 22;
																														this.aiStyle = 16;
																														this.friendly = true;
																														this.penetrate = -1;
																													}
																													else
																													{
																														if (this.type == 29)
																														{
																															this.name = "Dynamite";
																															this.width = 10;
																															this.height = 10;
																															this.aiStyle = 16;
																															this.friendly = true;
																															this.penetrate = -1;
																														}
																														else
																														{
																															if (this.type == 30)
																															{
																																this.name = "Grenade";
																																this.width = 14;
																																this.height = 14;
																																this.aiStyle = 16;
																																this.friendly = true;
																																this.penetrate = -1;
																																this.ranged = true;
																															}
																															else
																															{
																																if (this.type == 31)
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
																																else
																																{
																																	if (this.type == 32)
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
																																	else
																																	{
																																		if (this.type == 33)
																																		{
																																			this.name = "Thorn Chakrum";
																																			this.width = 28;
																																			this.height = 28;
																																			this.aiStyle = 3;
																																			this.friendly = true;
																																			this.scale = 0.9f;
																																			this.penetrate = -1;
																																			this.melee = true;
																																		}
																																		else
																																		{
																																			if (this.type == 34)
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
																																			else
																																			{
																																				if (this.type == 35)
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
																																				else
																																				{
																																					if (this.type == 36)
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
																																					else
																																					{
																																						if (this.type == 37)
																																						{
																																							this.name = "Sticky Bomb";
																																							this.width = 22;
																																							this.height = 22;
																																							this.aiStyle = 16;
																																							this.friendly = true;
																																							this.penetrate = -1;
																																							this.tileCollide = false;
																																						}
																																						else
																																						{
																																							if (this.type == 38)
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
																																							else
																																							{
																																								if (this.type == 39)
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
																																								else
																																								{
																																									if (this.type == 40)
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
																																									else
																																									{
																																										if (this.type == 41)
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
																																										else
																																										{
																																											if (this.type == 42)
																																											{
																																												this.name = "Sand Ball";
																																												this.knockBack = 8f;
																																												this.width = 10;
																																												this.height = 10;
																																												this.aiStyle = 10;
																																												this.friendly = true;
																																												this.maxUpdates = 1;
																																											}
																																											else
																																											{
																																												if (this.type == 43)
																																												{
																																													this.name = "Tombstone";
																																													this.knockBack = 12f;
																																													this.width = 24;
																																													this.height = 24;
																																													this.aiStyle = 17;
																																													this.penetrate = -1;
																																												}
																																												else
																																												{
																																													if (this.type == 44)
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
																																													else
																																													{
																																														if (this.type == 45)
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
																																														else
																																														{
																																															if (this.type == 46)
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
																																															else
																																															{
																																																if (this.type == 47)
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
																																																else
																																																{
																																																	if (this.type == 48)
																																																	{
																																																		this.name = "Throwing Knife";
																																																		this.width = 12;
																																																		this.height = 12;
																																																		this.aiStyle = 2;
																																																		this.friendly = true;
																																																		this.penetrate = 2;
																																																		this.ranged = true;
																																																	}
																																																	else
																																																	{
																																																		if (this.type == 49)
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
																																																		else
																																																		{
																																																			if (this.type == 50)
																																																			{
																																																				this.name = "Glowstick";
																																																				this.width = 6;
																																																				this.height = 6;
																																																				this.aiStyle = 14;
																																																				this.penetrate = -1;
																																																				this.alpha = 75;
																																																				this.light = 1f;
																																																				this.timeLeft *= 5;
																																																			}
																																																			else
																																																			{
																																																				if (this.type == 51)
																																																				{
																																																					this.name = "Seed";
																																																					this.width = 8;
																																																					this.height = 8;
																																																					this.aiStyle = 1;
																																																					this.friendly = true;
																																																				}
																																																				else
																																																				{
																																																					if (this.type == 52)
																																																					{
																																																						this.name = "Wooden Boomerang";
																																																						this.width = 22;
																																																						this.height = 22;
																																																						this.aiStyle = 3;
																																																						this.friendly = true;
																																																						this.penetrate = -1;
																																																						this.melee = true;
																																																					}
																																																					else
																																																					{
																																																						if (this.type == 53)
																																																						{
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
																																																						else
																																																						{
																																																							if (this.type == 54)
																																																							{
																																																								this.name = "Poisoned Knife";
																																																								this.width = 12;
																																																								this.height = 12;
																																																								this.aiStyle = 2;
																																																								this.friendly = true;
																																																								this.penetrate = 2;
																																																								this.ranged = true;
																																																							}
																																																							else
																																																							{
																																																								if (this.type == 55)
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
																																																								else
																																																								{
																																																									if (this.type == 56)
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
																																																									else
																																																									{
																																																										if (this.type == 57)
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
																																																										else
																																																										{
																																																											if (this.type == 58)
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
																																																											else
																																																											{
																																																												if (this.type == 59)
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
																																																												else
																																																												{
																																																													if (this.type == 60)
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
																																																													else
																																																													{
																																																														if (this.type == 61)
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
																																																														else
																																																														{
																																																															if (this.type == 62)
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
																																																															else
																																																															{
																																																																if (this.type == 63)
																																																																{
																																																																	this.name = "The Dao of Pow";
																																																																	this.width = 22;
																																																																	this.height = 22;
																																																																	this.aiStyle = 15;
																																																																	this.friendly = true;
																																																																	this.penetrate = -1;
																																																																	this.melee = true;
																																																																}
																																																																else
																																																																{
																																																																	if (this.type == 64)
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
																																																																	else
																																																																	{
																																																																		if (this.type == 65)
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
																																																																		else
																																																																		{
																																																																			if (this.type == 66)
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
																																																																			else
																																																																			{
																																																																				if (this.type == 67)
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
																																																																				else
																																																																				{
																																																																					if (this.type == 68)
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
																																																																					else
																																																																					{
																																																																						if (this.type == 69)
																																																																						{
																																																																							this.name = "Holy Water";
																																																																							this.width = 14;
																																																																							this.height = 14;
																																																																							this.aiStyle = 2;
																																																																							this.friendly = true;
																																																																							this.penetrate = 1;
																																																																						}
																																																																						else
																																																																						{
																																																																							if (this.type == 70)
																																																																							{
																																																																								this.name = "Unholy Water";
																																																																								this.width = 14;
																																																																								this.height = 14;
																																																																								this.aiStyle = 2;
																																																																								this.friendly = true;
																																																																								this.penetrate = 1;
																																																																							}
																																																																							else
																																																																							{
																																																																								if (this.type == 71)
																																																																								{
																																																																									this.name = "Gravel Ball";
																																																																									this.knockBack = 6f;
																																																																									this.width = 10;
																																																																									this.height = 10;
																																																																									this.aiStyle = 10;
																																																																									this.friendly = true;
																																																																									this.hostile = true;
																																																																									this.penetrate = -1;
																																																																								}
																																																																								else
																																																																								{
																																																																									if (this.type == 72)
																																																																									{
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
																																																																									else
																																																																									{
																																																																										if (this.type == 73 || this.type == 74)
																																																																										{
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
																																																																										else
																																																																										{
																																																																											if (this.type == 75)
																																																																											{
																																																																												this.name = "Happy Bomb";
																																																																												this.width = 22;
																																																																												this.height = 22;
																																																																												this.aiStyle = 16;
																																																																												this.hostile = true;
																																																																												this.penetrate = -1;
																																																																											}
																																																																											else
																																																																											{
																																																																												if (this.type == 76 || this.type == 77 || this.type == 78)
																																																																												{
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
																																																																												}
																																																																												else
																																																																												{
																																																																													if (this.type == 79)
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
																																																																													else
																																																																													{
																																																																														if (this.type == 80)
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
																																																																														else
																																																																														{
																																																																															if (this.type == 81)
																																																																															{
																																																																																this.name = "Wooden Arrow";
																																																																																this.width = 10;
																																																																																this.height = 10;
																																																																																this.aiStyle = 1;
																																																																																this.hostile = true;
																																																																																this.ranged = true;
																																																																															}
																																																																															else
																																																																															{
																																																																																if (this.type == 82)
																																																																																{
																																																																																	this.name = "Flaming Arrow";
																																																																																	this.width = 10;
																																																																																	this.height = 10;
																																																																																	this.aiStyle = 1;
																																																																																	this.hostile = true;
																																																																																	this.ranged = true;
																																																																																}
																																																																																else
																																																																																{
																																																																																	if (this.type == 83)
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
																																																																																	else
																																																																																	{
																																																																																		if (this.type == 84)
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
																																																																																		else
																																																																																		{
																																																																																			if (this.type == 85)
																																																																																			{
																																																																																				this.name = "Flames";
																																																																																				this.width = 6;
																																																																																				this.height = 6;
																																																																																				this.aiStyle = 23;
																																																																																				this.friendly = true;
																																																																																				this.alpha = 255;
																																																																																				this.penetrate = 3;
																																																																																				this.maxUpdates = 2;
																																																																																				this.magic = true;
																																																																																			}
																																																																																			else
																																																																																			{
																																																																																				if (this.type == 86)
																																																																																				{
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
																																																																																				else
																																																																																				{
																																																																																					if (this.type == 87)
																																																																																					{
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
																																																																																					else
																																																																																					{
																																																																																						if (this.type == 88)
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
																																																																																						else
																																																																																						{
																																																																																							if (this.type == 89)
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
																																																																																							else
																																																																																							{
																																																																																								if (this.type == 90)
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
																																																																																								else
																																																																																								{
																																																																																									if (this.type == 91)
																																																																																									{
																																																																																										this.name = "Holy Arrow";
																																																																																										this.width = 10;
																																																																																										this.height = 10;
																																																																																										this.aiStyle = 1;
																																																																																										this.friendly = true;
																																																																																										this.ranged = true;
																																																																																									}
																																																																																									else
																																																																																									{
																																																																																										if (this.type == 92)
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
																																																																																										else
																																																																																										{
																																																																																											if (this.type == 93)
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
																																																																																											else
																																																																																											{
																																																																																												if (this.type == 94)
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
																																																																																												else
																																																																																												{
																																																																																													if (this.type == 95)
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
																																																																																													else
																																																																																													{
																																																																																														if (this.type == 96)
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
																																																																																														else
																																																																																														{
																																																																																															if (this.type == 97)
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
																																																																																															else
																																																																																															{
																																																																																																if (this.type == 98)
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
																																																																																																else
																																																																																																{
																																																																																																	if (this.type == 99)
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
																																																																																																	else
																																																																																																	{
																																																																																																		if (this.type == 100)
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
																																																																																																		else
																																																																																																		{
																																																																																																			if (this.type == 101)
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
																																																																																																			else
																																																																																																			{
																																																																																																				if (this.type == 102)
																																																																																																				{
																																																																																																					this.name = "Bomb";
																																																																																																					this.width = 22;
																																																																																																					this.height = 22;
																																																																																																					this.aiStyle = 16;
																																																																																																					this.hostile = true;
																																																																																																					this.penetrate = -1;
																																																																																																					this.ranged = true;
																																																																																																				}
																																																																																																				else
																																																																																																				{
																																																																																																					if (this.type == 103)
																																																																																																					{
																																																																																																						this.name = "Cursed Arrow";
																																																																																																						this.width = 10;
																																																																																																						this.height = 10;
																																																																																																						this.aiStyle = 1;
																																																																																																						this.friendly = true;
																																																																																																						this.light = 1f;
																																																																																																						this.ranged = true;
																																																																																																					}
																																																																																																					else
																																																																																																					{
																																																																																																						if (this.type == 104)
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
																																																																																																						else
																																																																																																						{
																																																																																																							if (this.type == 105)
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
																																																																																																							else
																																																																																																							{
																																																																																																								if (this.type == 106)
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
																																																																																																								else
																																																																																																								{
																																																																																																									if (this.type == 107)
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
																																																																																																									else
																																																																																																									{
																																																																																																										if (this.type == 108)
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
																																																																																																										else
																																																																																																										{
																																																																																																											this.active = false;
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
			this.width = (int)((float)this.width * this.scale);
			this.height = (int)((float)this.height * this.scale);
		    ProjectileHooks.OnSetDefaults(ref Type, this);
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
			if (this.type == 18 || this.type == 72 || this.type == 86 || this.type == 87)
			{
				return;
			}
			Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
			if (this.type == 85 || this.type == 101)
			{
				int num = 30;
				rectangle.X -= num;
				rectangle.Y -= num;
				rectangle.Width += num * 2;
				rectangle.Height += num * 2;
			}
			if (this.friendly && this.owner == Main.myPlayer)
			{
				if ((this.aiStyle == 16 || this.type == 41) && (this.timeLeft <= 1 || this.type == 108))
				{
					int myPlayer = Main.myPlayer;
					if (Main.player[myPlayer].active && !Main.player[myPlayer].dead && !Main.player[myPlayer].immune && (!this.ownerHitCheck || Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, Main.player[myPlayer].position, Main.player[myPlayer].width, Main.player[myPlayer].height)))
					{
						Microsoft.Xna.Framework.Rectangle value = new Microsoft.Xna.Framework.Rectangle((int)Main.player[myPlayer].position.X, (int)Main.player[myPlayer].position.Y, Main.player[myPlayer].width, Main.player[myPlayer].height);
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
							int num2 = Main.DamageVar((float)this.damage);
							this.StatusPlayer(myPlayer);
							Main.player[myPlayer].Hurt(num2, this.direction, true, false, Player.getDeathMessage(this.owner, -1, this.whoAmI, -1), false);
							if (Main.netMode != 0)
							{
								NetMessage.SendData(26, -1, -1, Player.getDeathMessage(this.owner, -1, this.whoAmI, -1), myPlayer, (float)this.direction, (float)num2, 1f, 0);
							}
						}
					}
				}
				if (this.type != 69 && this.type != 70 && this.type != 10 && this.type != 11)
				{
					int num3 = (int)(this.position.X / 16f);
					int num4 = (int)((this.position.X + (float)this.width) / 16f) + 1;
					int num5 = (int)(this.position.Y / 16f);
					int num6 = (int)((this.position.Y + (float)this.height) / 16f) + 1;
					if (num3 < 0)
					{
						num3 = 0;
					}
					if (num4 > Main.maxTilesX)
					{
						num4 = Main.maxTilesX;
					}
					if (num5 < 0)
					{
						num5 = 0;
					}
					if (num6 > Main.maxTilesY)
					{
						num6 = Main.maxTilesY;
					}
					for (int i = num3; i < num4; i++)
					{
						for (int j = num5; j < num6; j++)
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
						if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && (((!Main.npc[k].friendly || (Main.npc[k].type == 22 && this.owner < 255 && Main.player[this.owner].killGuide)) && this.friendly) || (Main.npc[k].friendly && this.hostile)) && (this.owner < 0 || Main.npc[k].immune[this.owner] == 0))
						{
							bool flag = false;
							if (this.type == 11 && (Main.npc[k].type == 47 || Main.npc[k].type == 57))
							{
								flag = true;
							}
							else
							{
								if (this.type == 31 && Main.npc[k].type == 69)
								{
									flag = true;
								}
							}
							if (!flag && (Main.npc[k].noTileCollide || !this.ownerHitCheck || Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, Main.npc[k].position, Main.npc[k].width, Main.npc[k].height)))
							{
								Microsoft.Xna.Framework.Rectangle value2 = new Microsoft.Xna.Framework.Rectangle((int)Main.npc[k].position.X, (int)Main.npc[k].position.Y, Main.npc[k].width, Main.npc[k].height);
								if (rectangle.Intersects(value2))
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
									else
									{
										if (this.aiStyle == 16)
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
									int num7 = Main.DamageVar((float)this.damage);
									this.StatusNPC(k);
									Main.npc[k].StrikeNPC(num7, this.knockBack, this.direction, flag2, false);
									if (Main.netMode != 0)
									{
										if (flag2)
										{
											NetMessage.SendData(28, -1, -1, "", k, (float)num7, this.knockBack, (float)this.direction, 1);
										}
										else
										{
											NetMessage.SendData(28, -1, -1, "", k, (float)num7, this.knockBack, (float)this.direction, 0);
										}
									}
									if (this.penetrate != 1)
									{
										Main.npc[k].immune[this.owner] = 10;
									}
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
									else
									{
										if (this.aiStyle == 13)
										{
											this.ai[0] = 1f;
											this.netUpdate = true;
										}
									}
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
							Microsoft.Xna.Framework.Rectangle value3 = new Microsoft.Xna.Framework.Rectangle((int)Main.player[l].position.X, (int)Main.player[l].position.Y, Main.player[l].width, Main.player[l].height);
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
								else
								{
									if (this.aiStyle == 16)
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
								int num8 = Main.DamageVar((float)this.damage);
								if (!Main.player[l].immune)
								{
									this.StatusPvP(l);
								}
								Main.player[l].Hurt(num8, this.direction, true, false, Player.getDeathMessage(this.owner, -1, this.whoAmI, -1), flag3);
								if (Main.netMode != 0)
								{
									if (flag3)
									{
										NetMessage.SendData(26, -1, -1, Player.getDeathMessage(this.owner, -1, this.whoAmI, -1), l, (float)this.direction, (float)num8, 1f, 1);
									}
									else
									{
										NetMessage.SendData(26, -1, -1, Player.getDeathMessage(this.owner, -1, this.whoAmI, -1), l, (float)this.direction, (float)num8, 1f, 0);
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
								else
								{
									if (this.aiStyle == 13)
									{
										this.ai[0] = 1f;
										this.netUpdate = true;
									}
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
							Microsoft.Xna.Framework.Rectangle value4 = new Microsoft.Xna.Framework.Rectangle((int)Main.npc[m].position.X, (int)Main.npc[m].position.Y, Main.npc[m].width, Main.npc[m].height);
							if (rectangle.Intersects(value4))
							{
								Main.npc[m].Transform(47);
							}
						}
						else
						{
							if (Main.npc[m].type == 55)
							{
								Microsoft.Xna.Framework.Rectangle value5 = new Microsoft.Xna.Framework.Rectangle((int)Main.npc[m].position.X, (int)Main.npc[m].position.Y, Main.npc[m].width, Main.npc[m].height);
								if (rectangle.Intersects(value5))
								{
									Main.npc[m].Transform(57);
								}
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
					Microsoft.Xna.Framework.Rectangle value6 = new Microsoft.Xna.Framework.Rectangle((int)Main.player[myPlayer2].position.X, (int)Main.player[myPlayer2].position.Y, Main.player[myPlayer2].width, Main.player[myPlayer2].height);
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
						int num9 = Main.DamageVar((float)this.damage);
						if (!Main.player[myPlayer2].immune)
						{
							this.StatusPlayer(myPlayer2);
						}
						Main.player[myPlayer2].Hurt(num9 * 2, hitDirection, false, false, Player.getDeathMessage(-1, -1, this.whoAmI, -1), false);
					}
				}
			}
		}
		public void Update(int i)
		{
			if (this.active)
			{
				Microsoft.Xna.Framework.Vector2 value = this.velocity;
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
					}
					catch
					{
						this.active = false;
						return;
					}
					if (this.wet && !this.lavaWet)
					{
						if (this.type == 85 || this.type == 15 || this.type == 34)
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
						if (this.wetCount == 0)
						{
							this.wetCount = 10;
							if (!this.wet)
							{
								if (!flag)
								{
									for (int k = 0; k < 10; k++)
									{
										int num = Dust.NewDust(new Microsoft.Xna.Framework.Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 33, 0f, 0f, 0, default(Microsoft.Xna.Framework.Color), 1f);
										Dust expr_263_cp_0 = Main.dust[num];
										expr_263_cp_0.velocity.Y = expr_263_cp_0.velocity.Y - 4f;
										Dust expr_281_cp_0 = Main.dust[num];
										expr_281_cp_0.velocity.X = expr_281_cp_0.velocity.X * 2.5f;
										Main.dust[num].scale = 1.3f;
										Main.dust[num].alpha = 100;
										Main.dust[num].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
								else
								{
									for (int l = 0; l < 10; l++)
									{
										int num2 = Dust.NewDust(new Microsoft.Xna.Framework.Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 35, 0f, 0f, 0, default(Microsoft.Xna.Framework.Color), 1f);
										Dust expr_369_cp_0 = Main.dust[num2];
										expr_369_cp_0.velocity.Y = expr_369_cp_0.velocity.Y - 1.5f;
										Dust expr_387_cp_0 = Main.dust[num2];
										expr_387_cp_0.velocity.X = expr_387_cp_0.velocity.X * 2.5f;
										Main.dust[num2].scale = 1.3f;
										Main.dust[num2].alpha = 100;
										Main.dust[num2].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
							}
							this.wet = true;
						}
					}
					else
					{
						if (this.wet)
						{
							this.wet = false;
							if (this.wetCount == 0)
							{
								this.wetCount = 10;
								if (!this.lavaWet)
								{
									for (int m = 0; m < 10; m++)
									{
										int num3 = Dust.NewDust(new Microsoft.Xna.Framework.Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2)), this.width + 12, 24, 33, 0f, 0f, 0, default(Microsoft.Xna.Framework.Color), 1f);
										Dust expr_4A0_cp_0 = Main.dust[num3];
										expr_4A0_cp_0.velocity.Y = expr_4A0_cp_0.velocity.Y - 4f;
										Dust expr_4BE_cp_0 = Main.dust[num3];
										expr_4BE_cp_0.velocity.X = expr_4BE_cp_0.velocity.X * 2.5f;
										Main.dust[num3].scale = 1.3f;
										Main.dust[num3].alpha = 100;
										Main.dust[num3].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
								else
								{
									for (int n = 0; n < 10; n++)
									{
										int num4 = Dust.NewDust(new Microsoft.Xna.Framework.Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 35, 0f, 0f, 0, default(Microsoft.Xna.Framework.Color), 1f);
										Dust expr_5A6_cp_0 = Main.dust[num4];
										expr_5A6_cp_0.velocity.Y = expr_5A6_cp_0.velocity.Y - 1.5f;
										Dust expr_5C4_cp_0 = Main.dust[num4];
										expr_5C4_cp_0.velocity.X = expr_5C4_cp_0.velocity.X * 2.5f;
										Main.dust[num4].scale = 1.3f;
										Main.dust[num4].alpha = 100;
										Main.dust[num4].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
							}
						}
					}
					if (!this.wet)
					{
						this.lavaWet = false;
					}
					if (this.wetCount > 0)
					{
						this.wetCount -= 1;
					}
				}
				this.lastPosition = this.position;
				if (this.tileCollide)
				{
					Microsoft.Xna.Framework.Vector2 value2 = this.velocity;
					bool flag3 = true;
					if (this.type == 9 || this.type == 12 || this.type == 15 || this.type == 13 || this.type == 31 || this.type == 39 || this.type == 40)
					{
						flag3 = false;
					}
					if (this.aiStyle == 10)
					{
						if (this.type == 42 || this.type == 65 || this.type == 68 || (this.type == 31 && this.ai[0] == 2f))
						{
							this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag3, flag3);
						}
						else
						{
							this.velocity = Collision.AnyCollision(this.position, this.velocity, this.width, this.height);
						}
					}
					else
					{
						if (this.aiStyle == 18)
						{
							int num5 = this.width - 36;
							int num6 = this.height - 36;
							Microsoft.Xna.Framework.Vector2 vector = new Microsoft.Xna.Framework.Vector2(this.position.X + (float)(this.width / 2) - (float)(num5 / 2), this.position.Y + (float)(this.height / 2) - (float)(num6 / 2));
							this.velocity = Collision.TileCollision(vector, this.velocity, num5, num6, flag3, flag3);
						}
						else
						{
							if (this.wet)
							{
								Microsoft.Xna.Framework.Vector2 vector2 = this.velocity;
								this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag3, flag3);
								value = this.velocity * 0.5f;
								if (this.velocity.X != vector2.X)
								{
									value.X = this.velocity.X;
								}
								if (this.velocity.Y != vector2.Y)
								{
									value.Y = this.velocity.Y;
								}
							}
							else
							{
								this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag3, flag3);
							}
						}
					}
					if (value2 != this.velocity)
					{
						if (this.type == 94)
						{
							if (this.velocity.X != value2.X)
							{
								this.velocity.X = -value2.X;
							}
							if (this.velocity.Y != value2.Y)
							{
								this.velocity.Y = -value2.Y;
							}
						}
						else
						{
							if (this.type == 99)
							{
								if (this.velocity.Y != value2.Y && value2.Y > 5f)
								{
									Collision.HitTiles(this.position, this.velocity, this.width, this.height);
									Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
									this.velocity.Y = -value2.Y * 0.2f;
								}
								if (this.velocity.X != value2.X)
								{
									this.Kill();
								}
							}
							else
							{
								if (this.type == 36)
								{
									if (this.penetrate > 1)
									{
										Collision.HitTiles(this.position, this.velocity, this.width, this.height);
										Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
										this.penetrate--;
										if (this.velocity.X != value2.X)
										{
											this.velocity.X = -value2.X;
										}
										if (this.velocity.Y != value2.Y)
										{
											this.velocity.Y = -value2.Y;
										}
									}
									else
									{
										this.Kill();
									}
								}
								else
								{
									if (this.aiStyle == 21)
									{
										if (this.velocity.X != value2.X)
										{
											this.velocity.X = -value2.X;
										}
										if (this.velocity.Y != value2.Y)
										{
											this.velocity.Y = -value2.Y;
										}
									}
									else
									{
										if (this.aiStyle == 17)
										{
											if (this.velocity.X != value2.X)
											{
												this.velocity.X = value2.X * -0.75f;
											}
											if (this.velocity.Y != value2.Y && (double)value2.Y > 1.5)
											{
												this.velocity.Y = value2.Y * -0.7f;
											}
										}
										else
										{
											if (this.aiStyle == 15)
											{
												bool flag4 = false;
												if (value2.X != this.velocity.X)
												{
													if (Math.Abs(value2.X) > 4f)
													{
														flag4 = true;
													}
													this.position.X = this.position.X + this.velocity.X;
													this.velocity.X = -value2.X * 0.2f;
												}
												if (value2.Y != this.velocity.Y)
												{
													if (Math.Abs(value2.Y) > 4f)
													{
														flag4 = true;
													}
													this.position.Y = this.position.Y + this.velocity.Y;
													this.velocity.Y = -value2.Y * 0.2f;
												}
												this.ai[0] = 1f;
												if (flag4)
												{
													this.netUpdate = true;
													Collision.HitTiles(this.position, this.velocity, this.width, this.height);
													Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
												}
											}
											else
											{
												if (this.aiStyle == 3 || this.aiStyle == 13)
												{
													Collision.HitTiles(this.position, this.velocity, this.width, this.height);
													if (this.type == 33 || this.type == 106)
													{
														if (this.velocity.X != value2.X)
														{
															this.velocity.X = -value2.X;
														}
														if (this.velocity.Y != value2.Y)
														{
															this.velocity.Y = -value2.Y;
														}
													}
													else
													{
														this.ai[0] = 1f;
														if (this.aiStyle == 3)
														{
															this.velocity.X = -value2.X;
															this.velocity.Y = -value2.Y;
														}
													}
													this.netUpdate = true;
													Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
												}
												else
												{
													if (this.aiStyle == 8 && this.type != 96)
													{
														Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
														this.ai[0] += 1f;
														if (this.ai[0] >= 5f)
														{
															this.position += this.velocity;
															this.Kill();
														}
														else
														{
															if (this.type == 15 && this.velocity.Y > 4f)
															{
																if (this.velocity.Y != value2.Y)
																{
																	this.velocity.Y = -value2.Y * 0.8f;
																}
															}
															else
															{
																if (this.velocity.Y != value2.Y)
																{
																	this.velocity.Y = -value2.Y;
																}
															}
															if (this.velocity.X != value2.X)
															{
																this.velocity.X = -value2.X;
															}
														}
													}
													else
													{
														if (this.aiStyle == 14)
														{
															if (this.type == 50)
															{
																if (this.velocity.X != value2.X)
																{
																	this.velocity.X = value2.X * -0.2f;
																}
																if (this.velocity.Y != value2.Y && (double)value2.Y > 1.5)
																{
																	this.velocity.Y = value2.Y * -0.2f;
																}
															}
															else
															{
																if (this.velocity.X != value2.X)
																{
																	this.velocity.X = value2.X * -0.5f;
																}
																if (this.velocity.Y != value2.Y && value2.Y > 1f)
																{
																	this.velocity.Y = value2.Y * -0.5f;
																}
															}
														}
														else
														{
															if (this.aiStyle == 16)
															{
																if (this.velocity.X != value2.X)
																{
																	this.velocity.X = value2.X * -0.4f;
																	if (this.type == 29)
																	{
																		this.velocity.X = this.velocity.X * 0.8f;
																	}
																}
																if (this.velocity.Y != value2.Y && (double)value2.Y > 0.7 && this.type != 102)
																{
																	this.velocity.Y = value2.Y * -0.4f;
																	if (this.type == 29)
																	{
																		this.velocity.Y = this.velocity.Y * 0.8f;
																	}
																}
															}
															else
															{
																if (this.aiStyle != 9 || this.owner == Main.myPlayer)
																{
																	this.position += this.velocity;
																	this.Kill();
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
				if (this.type == 7 || this.type == 8)
				{
					goto IL_10F3;
				}
				if (this.wet)
				{
					this.position += value;
					goto IL_10F3;
				}
				this.position += this.velocity;
				IL_10F3:
				if ((this.aiStyle != 3 || this.ai[0] != 1f) && (this.aiStyle != 7 || this.ai[0] != 1f) && (this.aiStyle != 13 || this.ai[0] != 1f) && (this.aiStyle != 15 || this.ai[0] != 1f) && this.aiStyle != 15)
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
				if (!this.active)
				{
					return;
				}
				if (this.light > 0f)
				{
					float num7 = this.light;
					float num8 = this.light;
					float num9 = this.light;
					if (this.type == 2 || this.type == 82)
					{
						num8 *= 0.75f;
						num9 *= 0.55f;
					}
					else
					{
						if (this.type == 94)
						{
							num7 *= 0.5f;
							num8 *= 0f;
						}
						else
						{
							if (this.type == 95 || this.type == 96 || this.type == 103 || this.type == 104)
							{
								num7 *= 0.35f;
								num8 *= 1f;
								num9 *= 0f;
							}
							else
							{
								if (this.type == 4)
								{
									num8 *= 0.1f;
									num7 *= 0.5f;
								}
								else
								{
									if (this.type == 9)
									{
										num8 *= 0.1f;
										num9 *= 0.6f;
									}
									else
									{
										if (this.type == 92)
										{
											num8 *= 0.6f;
											num7 *= 0.8f;
										}
										else
										{
											if (this.type == 93)
											{
												num8 *= 1f;
												num7 *= 1f;
												num9 *= 0.01f;
											}
											else
											{
												if (this.type == 12)
												{
													num7 *= 0.9f;
													num8 *= 0.8f;
													num9 *= 0.1f;
												}
												else
												{
													if (this.type == 14)
													{
														num8 *= 0.7f;
														num9 *= 0.1f;
													}
													else
													{
														if (this.type == 15)
														{
															num8 *= 0.4f;
															num9 *= 0.1f;
															num7 = 1f;
														}
														else
														{
															if (this.type == 16)
															{
																num7 *= 0.1f;
																num8 *= 0.4f;
																num9 = 1f;
															}
															else
															{
																if (this.type == 18)
																{
																	num8 *= 0.7f;
																	num9 *= 0.3f;
																}
																else
																{
																	if (this.type == 19)
																	{
																		num8 *= 0.5f;
																		num9 *= 0.1f;
																	}
																	else
																	{
																		if (this.type == 20)
																		{
																			num7 *= 0.1f;
																			num9 *= 0.3f;
																		}
																		else
																		{
																			if (this.type == 22)
																			{
																				num7 = 0f;
																				num8 = 0f;
																			}
																			else
																			{
																				if (this.type == 27)
																				{
																					num7 *= 0f;
																					num8 *= 0.3f;
																					num9 = 1f;
																				}
																				else
																				{
																					if (this.type == 34)
																					{
																						num8 *= 0.1f;
																						num9 *= 0.1f;
																					}
																					else
																					{
																						if (this.type == 36)
																						{
																							num7 = 0.8f;
																							num8 *= 0.2f;
																							num9 *= 0.6f;
																						}
																						else
																						{
																							if (this.type == 41)
																							{
																								num8 *= 0.8f;
																								num9 *= 0.6f;
																							}
																							else
																							{
																								if (this.type == 44 || this.type == 45)
																								{
																									num9 = 1f;
																									num7 *= 0.6f;
																									num8 *= 0.1f;
																								}
																								else
																								{
																									if (this.type == 50)
																									{
																										num7 *= 0.7f;
																										num9 *= 0.8f;
																									}
																									else
																									{
																										if (this.type == 53)
																										{
																											num7 *= 0.7f;
																											num8 *= 0.8f;
																										}
																										else
																										{
																											if (this.type == 72)
																											{
																												num7 *= 0.45f;
																												num8 *= 0.75f;
																												num9 = 1f;
																											}
																											else
																											{
																												if (this.type == 86)
																												{
																													num7 *= 1f;
																													num8 *= 0.45f;
																													num9 = 0.75f;
																												}
																												else
																												{
																													if (this.type == 87)
																													{
																														num7 *= 0.45f;
																														num8 = 1f;
																														num9 *= 0.75f;
																													}
																													else
																													{
																														if (this.type == 73)
																														{
																															num7 *= 0.4f;
																															num8 *= 0.6f;
																															num9 *= 1f;
																														}
																														else
																														{
																															if (this.type == 74)
																															{
																																num7 *= 1f;
																																num8 *= 0.4f;
																																num9 *= 0.6f;
																															}
																															else
																															{
																																if (this.type == 76 || this.type == 77 || this.type == 78)
																																{
																																	num7 *= 1f;
																																	num8 *= 0.3f;
																																	num9 *= 0.6f;
																																}
																																else
																																{
																																	if (this.type == 79)
																																	{
																																		num7 = (float)Main.DiscoR / 255f;
																																		num8 = (float)Main.DiscoG / 255f;
																																		num9 = (float)Main.DiscoB / 255f;
																																	}
																																	else
																																	{
																																		if (this.type == 80)
																																		{
																																			num7 *= 0f;
																																			num8 *= 0.8f;
																																			num9 *= 1f;
																																		}
																																		else
																																		{
																																			if (this.type == 83 || this.type == 88)
																																			{
																																				num7 *= 0.7f;
																																				num8 *= 0f;
																																				num9 *= 1f;
																																			}
																																			else
																																			{
																																				if (this.type == 100)
																																				{
																																					num7 *= 1f;
																																					num8 *= 0.5f;
																																					num9 *= 0f;
																																				}
																																				else
																																				{
																																					if (this.type == 84)
																																					{
																																						num7 *= 0.8f;
																																						num8 *= 0f;
																																						num9 *= 0.5f;
																																					}
																																					else
																																					{
																																						if (this.type == 89 || this.type == 90)
																																						{
																																							num8 *= 0.2f;
																																							num9 *= 1f;
																																							num7 *= 0.05f;
																																						}
																																						else
																																						{
																																							if (this.type == 106)
																																							{
																																								num7 *= 0f;
																																								num8 *= 0.5f;
																																								num9 *= 1f;
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
					Lighting.addLight((int)((this.position.X + (float)(this.width / 2)) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), num7, num8, num9);
				}
				if (this.type == 2 || this.type == 82)
				{
					Dust.NewDust(new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Microsoft.Xna.Framework.Color), 1f);
				}
				else
				{
					if (this.type == 103)
					{
						int num10 = Dust.NewDust(new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y), this.width, this.height, 75, 0f, 0f, 100, default(Microsoft.Xna.Framework.Color), 1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num10].noGravity = true;
							Main.dust[num10].scale *= 2f;
						}
					}
					else
					{
						if (this.type == 4)
						{
							if (Main.rand.Next(5) == 0)
							{
								Dust.NewDust(new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 150, default(Microsoft.Xna.Framework.Color), 1.1f);
							}
						}
						else
						{
							if (this.type == 5)
							{
								int num11 = Main.rand.Next(3);
								if (num11 == 0)
								{
									num11 = 15;
								}
								else
								{
									if (num11 == 1)
									{
										num11 = 57;
									}
									else
									{
										num11 = 58;
									}
								}
								Dust.NewDust(this.position, this.width, this.height, num11, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, default(Microsoft.Xna.Framework.Color), 1.2f);
							}
						}
					}
				}
				this.Damage();
				if (Main.netMode != 1 && this.type == 99)
				{
					Collision.SwitchTiles(this.position, this.width, this.height, this.lastPosition);
				}
				if (this.type == 94)
				{
					for (int num12 = this.oldPos.Length - 1; num12 > 0; num12--)
					{
						this.oldPos[num12] = this.oldPos[num12 - 1];
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
			}
		}
		public void AI()
		{
			if (this.aiStyle == 1)
			{
				if (this.type == 83 && this.ai[1] == 0f)
				{
					this.ai[1] = 1f;
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 33);
				}
				if (this.type == 84 && this.ai[1] == 0f)
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
				if ((this.type == 81 || this.type == 82) && this.ai[1] == 0f)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 5);
					this.ai[1] = 1f;
				}
				if (this.type == 41)
				{
					Microsoft.Xna.Framework.Vector2 arg_1C4_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
					int arg_1C4_1 = this.width;
					int arg_1C4_2 = this.height;
					int arg_1C4_3 = 31;
					float arg_1C4_4 = 0f;
					float arg_1C4_5 = 0f;
					int arg_1C4_6 = 100;
					Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
					int num = Dust.NewDust(arg_1C4_0, arg_1C4_1, arg_1C4_2, arg_1C4_3, arg_1C4_4, arg_1C4_5, arg_1C4_6, newColor, 1.6f);
					Main.dust[num].noGravity = true;
					Microsoft.Xna.Framework.Vector2 arg_21A_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
					int arg_21A_1 = this.width;
					int arg_21A_2 = this.height;
					int arg_21A_3 = 6;
					float arg_21A_4 = 0f;
					float arg_21A_5 = 0f;
					int arg_21A_6 = 100;
					newColor = default(Microsoft.Xna.Framework.Color);
					num = Dust.NewDust(arg_21A_0, arg_21A_1, arg_21A_2, arg_21A_3, arg_21A_4, arg_21A_5, arg_21A_6, newColor, 2f);
					Main.dust[num].noGravity = true;
				}
				else
				{
					if (this.type == 55)
					{
						Microsoft.Xna.Framework.Vector2 arg_27F_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
						int arg_27F_1 = this.width;
						int arg_27F_2 = this.height;
						int arg_27F_3 = 18;
						float arg_27F_4 = 0f;
						float arg_27F_5 = 0f;
						int arg_27F_6 = 0;
						Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
						int num2 = Dust.NewDust(arg_27F_0, arg_27F_1, arg_27F_2, arg_27F_3, arg_27F_4, arg_27F_5, arg_27F_6, newColor, 0.9f);
						Main.dust[num2].noGravity = true;
					}
					else
					{
						if (this.type == 91 && Main.rand.Next(2) == 0)
						{
							int num3 = Main.rand.Next(2);
							if (num3 == 0)
							{
								num3 = 15;
							}
							else
							{
								num3 = 58;
							}
							Microsoft.Xna.Framework.Vector2 arg_314_0 = this.position;
							int arg_314_1 = this.width;
							int arg_314_2 = this.height;
							int arg_314_3 = num3;
							float arg_314_4 = this.velocity.X * 0.25f;
							float arg_314_5 = this.velocity.Y * 0.25f;
							int arg_314_6 = 150;
							Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
							int num4 = Dust.NewDust(arg_314_0, arg_314_1, arg_314_2, arg_314_3, arg_314_4, arg_314_5, arg_314_6, newColor, 0.9f);
							Dust expr_321 = Main.dust[num4];
							expr_321.velocity *= 0.25f;
						}
					}
				}
				if (this.type == 20 || this.type == 14 || this.type == 36 || this.type == 83 || this.type == 84 || this.type == 89 || this.type == 100 || this.type == 104)
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
				if (this.type != 5 && this.type != 14 && this.type != 20 && this.type != 36 && this.type != 38 && this.type != 55 && this.type != 83 && this.type != 84 && this.type != 88 && this.type != 89 && this.type != 98 && this.type != 100 && this.type != 104)
				{
					this.ai[0] += 1f;
				}
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
					if (this.ai[0] >= 15f)
					{
						this.ai[0] = 15f;
						this.velocity.Y = this.velocity.Y + 0.1f;
					}
				}
				this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
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
						Microsoft.Xna.Framework.Vector2 arg_5CD_0 = this.position;
						int arg_5CD_1 = this.width;
						int arg_5CD_2 = this.height;
						int arg_5CD_3 = 57;
						float arg_5CD_4 = this.velocity.X * 0.2f + (float)(this.direction * 3);
						float arg_5CD_5 = this.velocity.Y * 0.2f;
						int arg_5CD_6 = 100;
						Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
						int num5 = Dust.NewDust(arg_5CD_0, arg_5CD_1, arg_5CD_2, arg_5CD_3, arg_5CD_4, arg_5CD_5, arg_5CD_6, newColor, 0.3f);
						Dust expr_5E1_cp_0 = Main.dust[num5];
						expr_5E1_cp_0.velocity.X = expr_5E1_cp_0.velocity.X * 0.3f;
						Dust expr_5FF_cp_0 = Main.dust[num5];
						expr_5FF_cp_0.velocity.Y = expr_5FF_cp_0.velocity.Y * 0.3f;
					}
					this.rotation += (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.03f * (float)this.direction;
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
					if (this.velocity.Y > 16f)
					{
						this.velocity.Y = 16f;
					}
					if (this.type == 54 && Main.rand.Next(20) == 0)
					{
						Microsoft.Xna.Framework.Vector2 arg_801_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
						int arg_801_1 = this.width;
						int arg_801_2 = this.height;
						int arg_801_3 = 40;
						float arg_801_4 = this.velocity.X * 0.1f;
						float arg_801_5 = this.velocity.Y * 0.1f;
						int arg_801_6 = 0;
						Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
						Dust.NewDust(arg_801_0, arg_801_1, arg_801_2, arg_801_3, arg_801_4, arg_801_5, arg_801_6, newColor, 0.75f);
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
							for (int i = 0; i < 2; i++)
							{
								Microsoft.Xna.Framework.Vector2 arg_8B2_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
								int arg_8B2_1 = this.width;
								int arg_8B2_2 = this.height;
								int arg_8B2_3 = 6;
								float arg_8B2_4 = this.velocity.X * 0.2f;
								float arg_8B2_5 = this.velocity.Y * 0.2f;
								int arg_8B2_6 = 100;
								Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
								int num6 = Dust.NewDust(arg_8B2_0, arg_8B2_1, arg_8B2_2, arg_8B2_3, arg_8B2_4, arg_8B2_5, arg_8B2_6, newColor, 2f);
								Main.dust[num6].noGravity = true;
								Dust expr_8D4_cp_0 = Main.dust[num6];
								expr_8D4_cp_0.velocity.X = expr_8D4_cp_0.velocity.X * 0.3f;
								Dust expr_8F2_cp_0 = Main.dust[num6];
								expr_8F2_cp_0.velocity.Y = expr_8F2_cp_0.velocity.Y * 0.3f;
							}
						}
						else
						{
							if (this.type == 33)
							{
								if (Main.rand.Next(1) == 0)
								{
									Microsoft.Xna.Framework.Vector2 arg_976_0 = this.position;
									int arg_976_1 = this.width;
									int arg_976_2 = this.height;
									int arg_976_3 = 40;
									float arg_976_4 = this.velocity.X * 0.25f;
									float arg_976_5 = this.velocity.Y * 0.25f;
									int arg_976_6 = 0;
									Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
									int num7 = Dust.NewDust(arg_976_0, arg_976_1, arg_976_2, arg_976_3, arg_976_4, arg_976_5, arg_976_6, newColor, 1.4f);
									Main.dust[num7].noGravity = true;
								}
							}
							else
							{
								if (this.type == 6 && Main.rand.Next(5) == 0)
								{
									int num8 = Main.rand.Next(3);
									if (num8 == 0)
									{
										num8 = 15;
									}
									else
									{
										if (num8 == 1)
										{
											num8 = 57;
										}
										else
										{
											num8 = 58;
										}
									}
									Microsoft.Xna.Framework.Vector2 arg_A19_0 = this.position;
									int arg_A19_1 = this.width;
									int arg_A19_2 = this.height;
									int arg_A19_3 = num8;
									float arg_A19_4 = this.velocity.X * 0.25f;
									float arg_A19_5 = this.velocity.Y * 0.25f;
									int arg_A19_6 = 150;
									Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
									Dust.NewDust(arg_A19_0, arg_A19_1, arg_A19_2, arg_A19_3, arg_A19_4, arg_A19_5, arg_A19_6, newColor, 0.7f);
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
								if (this.ai[1] >= 30f)
								{
									this.ai[0] = 1f;
									this.ai[1] = 0f;
									this.netUpdate = true;
								}
							}
						}
						else
						{
							this.tileCollide = false;
							float num9 = 9f;
							float num10 = 0.4f;
							if (this.type == 19)
							{
								num9 = 13f;
								num10 = 0.6f;
							}
							else
							{
								if (this.type == 33)
								{
									num9 = 15f;
									num10 = 0.8f;
								}
								else
								{
									if (this.type == 106)
									{
										num9 = 16f;
										num10 = 1.2f;
									}
								}
							}
							Microsoft.Xna.Framework.Vector2 vector = new Microsoft.Xna.Framework.Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num11 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector.X;
							float num12 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector.Y;
							float num13 = (float)Math.Sqrt((double)(num11 * num11 + num12 * num12));
							if (num13 > 3000f)
							{
								this.Kill();
							}
							num13 = num9 / num13;
							num11 *= num13;
							num12 *= num13;
							if (this.velocity.X < num11)
							{
								this.velocity.X = this.velocity.X + num10;
								if (this.velocity.X < 0f && num11 > 0f)
								{
									this.velocity.X = this.velocity.X + num10;
								}
							}
							else
							{
								if (this.velocity.X > num11)
								{
									this.velocity.X = this.velocity.X - num10;
									if (this.velocity.X > 0f && num11 < 0f)
									{
										this.velocity.X = this.velocity.X - num10;
									}
								}
							}
							if (this.velocity.Y < num12)
							{
								this.velocity.Y = this.velocity.Y + num10;
								if (this.velocity.Y < 0f && num12 > 0f)
								{
									this.velocity.Y = this.velocity.Y + num10;
								}
							}
							else
							{
								if (this.velocity.Y > num12)
								{
									this.velocity.Y = this.velocity.Y - num10;
									if (this.velocity.Y > 0f && num12 < 0f)
									{
										this.velocity.Y = this.velocity.Y - num10;
									}
								}
							}
							if (Main.myPlayer == this.owner)
							{
								Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
								Microsoft.Xna.Framework.Rectangle value = new Microsoft.Xna.Framework.Rectangle((int)Main.player[this.owner].position.X, (int)Main.player[this.owner].position.Y, Main.player[this.owner].width, Main.player[this.owner].height);
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
								this.alpha -= 50;
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
										int num14 = this.type;
										if (this.ai[1] >= 6f)
										{
											num14++;
										}
										int num15 = Projectile.NewProjectile(this.position.X + this.velocity.X + (float)(this.width / 2), this.position.Y + this.velocity.Y + (float)(this.height / 2), this.velocity.X, this.velocity.Y, num14, this.damage, this.knockBack, this.owner);
										Main.projectile[num15].damage = this.damage;
										Main.projectile[num15].ai[1] = this.ai[1] + 1f;
										NetMessage.SendData(27, -1, -1, "", num15, 0f, 0f, 0f, 0);
										return;
									}
								}
							}
							else
							{
								if (this.alpha < 170 && this.alpha + 5 >= 170)
								{
									Microsoft.Xna.Framework.Color newColor;
									for (int j = 0; j < 3; j++)
									{
										Microsoft.Xna.Framework.Vector2 arg_1065_0 = this.position;
										int arg_1065_1 = this.width;
										int arg_1065_2 = this.height;
										int arg_1065_3 = 18;
										float arg_1065_4 = this.velocity.X * 0.025f;
										float arg_1065_5 = this.velocity.Y * 0.025f;
										int arg_1065_6 = 170;
										newColor = default(Microsoft.Xna.Framework.Color);
										Dust.NewDust(arg_1065_0, arg_1065_1, arg_1065_2, arg_1065_3, arg_1065_4, arg_1065_5, arg_1065_6, newColor, 1.2f);
									}
									Microsoft.Xna.Framework.Vector2 arg_10A8_0 = this.position;
									int arg_10A8_1 = this.width;
									int arg_10A8_2 = this.height;
									int arg_10A8_3 = 14;
									float arg_10A8_4 = 0f;
									float arg_10A8_5 = 0f;
									int arg_10A8_6 = 170;
									newColor = default(Microsoft.Xna.Framework.Color);
									Dust.NewDust(arg_10A8_0, arg_10A8_1, arg_10A8_2, arg_10A8_3, arg_10A8_4, arg_10A8_5, arg_10A8_6, newColor, 1.1f);
								}
								this.alpha += 5;
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
										Microsoft.Xna.Framework.Vector2 arg_12CB_0 = this.position;
										int arg_12CB_1 = this.width;
										int arg_12CB_2 = this.height;
										int arg_12CB_3 = 58;
										float arg_12CB_4 = this.velocity.X * 0.5f;
										float arg_12CB_5 = this.velocity.Y * 0.5f;
										int arg_12CB_6 = 150;
										Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
										Dust.NewDust(arg_12CB_0, arg_12CB_1, arg_12CB_2, arg_12CB_3, arg_12CB_4, arg_12CB_5, arg_12CB_6, newColor, 1.2f);
									}
									if (Main.rand.Next(20) == 0)
									{
										Gore.NewGore(this.position, new Microsoft.Xna.Framework.Vector2(this.velocity.X * 0.2f, this.velocity.Y * 0.2f), Main.rand.Next(16, 18), 1f);
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
										for (int k = 0; k < 30; k++)
										{
											Microsoft.Xna.Framework.Vector2 arg_13E0_0 = this.position;
											int arg_13E0_1 = this.width;
											int arg_13E0_2 = this.height;
											int arg_13E0_3 = 10 + this.type;
											float arg_13E0_4 = this.velocity.X;
											float arg_13E0_5 = this.velocity.Y;
											int arg_13E0_6 = 50;
											Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
											Dust.NewDust(arg_13E0_0, arg_13E0_1, arg_13E0_2, arg_13E0_3, arg_13E0_4, arg_13E0_5, arg_13E0_6, newColor, 1f);
										}
									}
									if (this.type == 10 || this.type == 11)
									{
										int num16 = (int)(this.position.X / 16f) - 1;
										int num17 = (int)((this.position.X + (float)this.width) / 16f) + 2;
										int num18 = (int)(this.position.Y / 16f) - 1;
										int num19 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
										if (num16 < 0)
										{
											num16 = 0;
										}
										if (num17 > Main.maxTilesX)
										{
											num17 = Main.maxTilesX;
										}
										if (num18 < 0)
										{
											num18 = 0;
										}
										if (num19 > Main.maxTilesY)
										{
											num19 = Main.maxTilesY;
										}
										for (int l = num16; l < num17; l++)
										{
											for (int m = num18; m < num19; m++)
											{
												Microsoft.Xna.Framework.Vector2 vector2;
												vector2.X = (float)(l * 16);
												vector2.Y = (float)(m * 16);
												if (this.position.X + (float)this.width > vector2.X && this.position.X < vector2.X + 16f && this.position.Y + (float)this.height > vector2.Y && this.position.Y < vector2.Y + 16f && Main.myPlayer == this.owner && Main.tile[l, m].active)
												{
													if (this.type == 10)
													{
														if (Main.tile[l, m].type == 23)
														{
															Main.tile[l, m].type = 2;
															WorldGen.SquareTileFrame(l, m, true);
															if (Main.netMode == 1)
															{
																NetMessage.SendTileSquare(-1, l, m, 1);
															}
														}
														if (Main.tile[l, m].type == 25)
														{
															Main.tile[l, m].type = 1;
															WorldGen.SquareTileFrame(l, m, true);
															if (Main.netMode == 1)
															{
																NetMessage.SendTileSquare(-1, l, m, 1);
															}
														}
														if (Main.tile[l, m].type == 112)
														{
															Main.tile[l, m].type = 53;
															WorldGen.SquareTileFrame(l, m, true);
															if (Main.netMode == 1)
															{
																NetMessage.SendTileSquare(-1, l, m, 1);
															}
														}
													}
													else
													{
														if (this.type == 11)
														{
															if (Main.tile[l, m].type == 109)
															{
																Main.tile[l, m].type = 2;
																WorldGen.SquareTileFrame(l, m, true);
																if (Main.netMode == 1)
																{
																	NetMessage.SendTileSquare(-1, l, m, 1);
																}
															}
															if (Main.tile[l, m].type == 116)
															{
																Main.tile[l, m].type = 53;
																WorldGen.SquareTileFrame(l, m, true);
																if (Main.netMode == 1)
																{
																	NetMessage.SendTileSquare(-1, l, m, 1);
																}
															}
															if (Main.tile[l, m].type == 117)
															{
																Main.tile[l, m].type = 1;
																WorldGen.SquareTileFrame(l, m, true);
																if (Main.netMode == 1)
																{
																	NetMessage.SendTileSquare(-1, l, m, 1);
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
										Microsoft.Xna.Framework.Vector2 vector3 = new Microsoft.Xna.Framework.Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
										float num20 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector3.X;
										float num21 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector3.Y;
										float num22 = (float)Math.Sqrt((double)(num20 * num20 + num21 * num21));
										this.rotation = (float)Math.Atan2((double)num21, (double)num20) - 1.57f;
										if (this.ai[0] == 0f)
										{
											if ((num22 > 300f && this.type == 13) || (num22 > 400f && this.type == 32) || (num22 > 440f && this.type == 73) || (num22 > 440f && this.type == 74))
											{
												this.ai[0] = 1f;
											}
											int num23 = (int)(this.position.X / 16f) - 1;
											int num24 = (int)((this.position.X + (float)this.width) / 16f) + 2;
											int num25 = (int)(this.position.Y / 16f) - 1;
											int num26 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
											if (num23 < 0)
											{
												num23 = 0;
											}
											if (num24 > Main.maxTilesX)
											{
												num24 = Main.maxTilesX;
											}
											if (num25 < 0)
											{
												num25 = 0;
											}
											if (num26 > Main.maxTilesY)
											{
												num26 = Main.maxTilesY;
											}
											for (int n = num23; n < num24; n++)
											{
												int num27 = num25;
												while (num27 < num26)
												{
													if (Main.tile[n, num27] == null)
													{

													}
													Microsoft.Xna.Framework.Vector2 vector4;
													vector4.X = (float)(n * 16);
													vector4.Y = (float)(num27 * 16);
													if (this.position.X + (float)this.width > vector4.X && this.position.X < vector4.X + 16f && this.position.Y + (float)this.height > vector4.Y && this.position.Y < vector4.Y + 16f && Main.tile[n, num27].active && Main.tileSolid[(int)Main.tile[n, num27].type])
													{
														if (Main.player[this.owner].grapCount < 10)
														{
															Main.player[this.owner].grappling[Main.player[this.owner].grapCount] = this.whoAmI;
															Main.player[this.owner].grapCount++;
														}
														if (Main.myPlayer == this.owner)
														{
															int num28 = 0;
															int num29 = -1;
															int num30 = 100000;
															if (this.type == 73 || this.type == 74)
															{
																for (int num31 = 0; num31 < 1000; num31++)
																{
																	if (num31 != this.whoAmI && Main.projectile[num31].active && Main.projectile[num31].owner == this.owner && Main.projectile[num31].aiStyle == 7 && Main.projectile[num31].ai[0] == 2f)
																	{
																		Main.projectile[num31].Kill();
																	}
																}
															}
															else
															{
																for (int num32 = 0; num32 < 1000; num32++)
																{
																	if (Main.projectile[num32].active && Main.projectile[num32].owner == this.owner && Main.projectile[num32].aiStyle == 7)
																	{
																		if (Main.projectile[num32].timeLeft < num30)
																		{
																			num29 = num32;
																			num30 = Main.projectile[num32].timeLeft;
																		}
																		num28++;
																	}
																}
																if (num28 > 3)
																{
																	Main.projectile[num29].Kill();
																}
															}
														}
														WorldGen.KillTile(n, num27, true, true, false);
														Main.PlaySound(0, n * 16, num27 * 16, 1);
														this.velocity.X = 0f;
														this.velocity.Y = 0f;
														this.ai[0] = 2f;
														this.position.X = (float)(n * 16 + 8 - this.width / 2);
														this.position.Y = (float)(num27 * 16 + 8 - this.height / 2);
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
														num27++;
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
											float num33 = 11f;
											if (this.type == 32)
											{
												num33 = 15f;
											}
											if (this.type == 73 || this.type == 74)
											{
												num33 = 17f;
											}
											if (num22 < 24f)
											{
												this.Kill();
											}
											num22 = num33 / num22;
											num20 *= num22;
											num21 *= num22;
											this.velocity.X = num20;
											this.velocity.Y = num21;
											return;
										}
										if (this.ai[0] == 2f)
										{
											int num34 = (int)(this.position.X / 16f) - 1;
											int num35 = (int)((this.position.X + (float)this.width) / 16f) + 2;
											int num36 = (int)(this.position.Y / 16f) - 1;
											int num37 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
											if (num34 < 0)
											{
												num34 = 0;
											}
											if (num35 > Main.maxTilesX)
											{
												num35 = Main.maxTilesX;
											}
											if (num36 < 0)
											{
												num36 = 0;
											}
											if (num37 > Main.maxTilesY)
											{
												num37 = Main.maxTilesY;
											}
											bool flag = true;
											for (int num38 = num34; num38 < num35; num38++)
											{
												for (int num39 = num36; num39 < num37; num39++)
												{
													if (Main.tile[num38, num39] == null)
													{

													}
													Microsoft.Xna.Framework.Vector2 vector5;
													vector5.X = (float)(num38 * 16);
													vector5.Y = (float)(num39 * 16);
													if (this.position.X + (float)(this.width / 2) > vector5.X && this.position.X + (float)(this.width / 2) < vector5.X + 16f && this.position.Y + (float)(this.height / 2) > vector5.Y && this.position.Y + (float)(this.height / 2) < vector5.Y + 16f && Main.tile[num38, num39].active && Main.tileSolid[(int)Main.tile[num38, num39].type])
													{
														flag = false;
													}
												}
											}
											if (flag)
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
											if (this.type == 96 && this.localAI[0] == 0f)
											{
												this.localAI[0] = 1f;
												Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 20);
											}
											if (this.type == 27)
											{
												Microsoft.Xna.Framework.Vector2 arg_2059_0 = new Microsoft.Xna.Framework.Vector2(this.position.X + this.velocity.X, this.position.Y + this.velocity.Y);
												int arg_2059_1 = this.width;
												int arg_2059_2 = this.height;
												int arg_2059_3 = 29;
												float arg_2059_4 = this.velocity.X;
												float arg_2059_5 = this.velocity.Y;
												int arg_2059_6 = 100;
												Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
												int num40 = Dust.NewDust(arg_2059_0, arg_2059_1, arg_2059_2, arg_2059_3, arg_2059_4, arg_2059_5, arg_2059_6, newColor, 3f);
												Main.dust[num40].noGravity = true;
												if (Main.rand.Next(10) == 0)
												{
													Microsoft.Xna.Framework.Vector2 arg_20CF_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
													int arg_20CF_1 = this.width;
													int arg_20CF_2 = this.height;
													int arg_20CF_3 = 29;
													float arg_20CF_4 = this.velocity.X;
													float arg_20CF_5 = this.velocity.Y;
													int arg_20CF_6 = 100;
													newColor = default(Microsoft.Xna.Framework.Color);
													num40 = Dust.NewDust(arg_20CF_0, arg_20CF_1, arg_20CF_2, arg_20CF_3, arg_20CF_4, arg_20CF_5, arg_20CF_6, newColor, 1.4f);
												}
											}
											else
											{
												if (this.type == 95 || this.type == 96)
												{
													Microsoft.Xna.Framework.Vector2 arg_2161_0 = new Microsoft.Xna.Framework.Vector2(this.position.X + this.velocity.X, this.position.Y + this.velocity.Y);
													int arg_2161_1 = this.width;
													int arg_2161_2 = this.height;
													int arg_2161_3 = 75;
													float arg_2161_4 = this.velocity.X;
													float arg_2161_5 = this.velocity.Y;
													int arg_2161_6 = 100;
													Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
													int num41 = Dust.NewDust(arg_2161_0, arg_2161_1, arg_2161_2, arg_2161_3, arg_2161_4, arg_2161_5, arg_2161_6, newColor, 3f * this.scale);
													Main.dust[num41].noGravity = true;
												}
												else
												{
													for (int num42 = 0; num42 < 2; num42++)
													{
														Microsoft.Xna.Framework.Vector2 arg_21DE_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
														int arg_21DE_1 = this.width;
														int arg_21DE_2 = this.height;
														int arg_21DE_3 = 6;
														float arg_21DE_4 = this.velocity.X * 0.2f;
														float arg_21DE_5 = this.velocity.Y * 0.2f;
														int arg_21DE_6 = 100;
														Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
														int num43 = Dust.NewDust(arg_21DE_0, arg_21DE_1, arg_21DE_2, arg_21DE_3, arg_21DE_4, arg_21DE_5, arg_21DE_6, newColor, 2f);
														Main.dust[num43].noGravity = true;
														Dust expr_2200_cp_0 = Main.dust[num43];
														expr_2200_cp_0.velocity.X = expr_2200_cp_0.velocity.X * 0.3f;
														Dust expr_221E_cp_0 = Main.dust[num43];
														expr_221E_cp_0.velocity.Y = expr_221E_cp_0.velocity.Y * 0.3f;
													}
												}
											}
											if (this.type != 27 && this.type != 96)
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
													Microsoft.Xna.Framework.Vector2 arg_2349_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
													int arg_2349_1 = this.width;
													int arg_2349_2 = this.height;
													int arg_2349_3 = 6;
													float arg_2349_4 = this.velocity.X * 0.2f;
													float arg_2349_5 = this.velocity.Y * 0.2f;
													int arg_2349_6 = 100;
													Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
													int num44 = Dust.NewDust(arg_2349_0, arg_2349_1, arg_2349_2, arg_2349_3, arg_2349_4, arg_2349_5, arg_2349_6, newColor, 3.5f);
													Main.dust[num44].noGravity = true;
													Dust expr_2366 = Main.dust[num44];
													expr_2366.velocity *= 1.4f;
													Microsoft.Xna.Framework.Vector2 arg_23D6_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
													int arg_23D6_1 = this.width;
													int arg_23D6_2 = this.height;
													int arg_23D6_3 = 6;
													float arg_23D6_4 = this.velocity.X * 0.2f;
													float arg_23D6_5 = this.velocity.Y * 0.2f;
													int arg_23D6_6 = 100;
													newColor = default(Microsoft.Xna.Framework.Color);
													num44 = Dust.NewDust(arg_23D6_0, arg_23D6_1, arg_23D6_2, arg_23D6_3, arg_23D6_4, arg_23D6_5, arg_23D6_6, newColor, 1.5f);
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
														for (int num45 = 0; num45 < 1; num45++)
														{
															int num46 = Dust.NewDust(new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y), this.width, this.height, 66, 0f, 0f, 100, new Microsoft.Xna.Framework.Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 2.5f);
															Dust expr_24AC = Main.dust[num46];
															expr_24AC.velocity *= 0.1f;
															Dust expr_24C9 = Main.dust[num46];
															expr_24C9.velocity += this.velocity * 0.2f;
															Main.dust[num46].position.X = this.position.X + (float)(this.width / 2) + 4f + (float)Main.rand.Next(-2, 3);
															Main.dust[num46].position.Y = this.position.Y + (float)(this.height / 2) + (float)Main.rand.Next(-2, 3);
															Main.dust[num46].noGravity = true;
														}
													}
													else
													{
														if (this.soundDelay == 0 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 2f)
														{
															this.soundDelay = 10;
															Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 9);
														}
														Microsoft.Xna.Framework.Vector2 arg_2618_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
														int arg_2618_1 = this.width;
														int arg_2618_2 = this.height;
														int arg_2618_3 = 15;
														float arg_2618_4 = 0f;
														float arg_2618_5 = 0f;
														int arg_2618_6 = 100;
														Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
														int num47 = Dust.NewDust(arg_2618_0, arg_2618_1, arg_2618_2, arg_2618_3, arg_2618_4, arg_2618_5, arg_2618_6, newColor, 2f);
														Dust expr_2627 = Main.dust[num47];
														expr_2627.velocity *= 0.3f;
														Main.dust[num47].position.X = this.position.X + (float)(this.width / 2) + 4f + (float)Main.rand.Next(-4, 5);
														Main.dust[num47].position.Y = this.position.Y + (float)(this.height / 2) + (float)Main.rand.Next(-4, 5);
														Main.dust[num47].noGravity = true;
													}
												}
												if (Main.myPlayer == this.owner && this.ai[0] == 0f)
												{
													if (Main.player[this.owner].channel)
													{
														float num48 = 12f;
														if (this.type == 16)
														{
															num48 = 15f;
														}
														Microsoft.Xna.Framework.Vector2 vector6 = new Microsoft.Xna.Framework.Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
														float num49 = (float)Main.mouseX + Main.screenPosition.X - vector6.X;
														float num50 = (float)Main.mouseY + Main.screenPosition.Y - vector6.Y;
														float num51 = (float)Math.Sqrt((double)(num49 * num49 + num50 * num50));
														num51 = (float)Math.Sqrt((double)(num49 * num49 + num50 * num50));
														if (num51 > num48)
														{
															num51 = num48 / num51;
															num49 *= num51;
															num50 *= num51;
															int num52 = (int)(num49 * 1000f);
															int num53 = (int)(this.velocity.X * 1000f);
															int num54 = (int)(num50 * 1000f);
															int num55 = (int)(this.velocity.Y * 1000f);
															if (num52 != num53 || num54 != num55)
															{
																this.netUpdate = true;
															}
															this.velocity.X = num49;
															this.velocity.Y = num50;
														}
														else
														{
															int num56 = (int)(num49 * 1000f);
															int num57 = (int)(this.velocity.X * 1000f);
															int num58 = (int)(num50 * 1000f);
															int num59 = (int)(this.velocity.Y * 1000f);
															if (num56 != num57 || num58 != num59)
															{
																this.netUpdate = true;
															}
															this.velocity.X = num49;
															this.velocity.Y = num50;
														}
													}
													else
													{
														if (this.ai[0] == 0f)
														{
															this.ai[0] = 1f;
															this.netUpdate = true;
															float num60 = 12f;
															Microsoft.Xna.Framework.Vector2 vector7 = new Microsoft.Xna.Framework.Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
															float num61 = (float)Main.mouseX + Main.screenPosition.X - vector7.X;
															float num62 = (float)Main.mouseY + Main.screenPosition.Y - vector7.Y;
															float num63 = (float)Math.Sqrt((double)(num61 * num61 + num62 * num62));
															if (num63 == 0f)
															{
																vector7 = new Microsoft.Xna.Framework.Vector2(Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2), Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2));
																num61 = this.position.X + (float)this.width * 0.5f - vector7.X;
																num62 = this.position.Y + (float)this.height * 0.5f - vector7.Y;
																num63 = (float)Math.Sqrt((double)(num61 * num61 + num62 * num62));
															}
															num63 = num60 / num63;
															num61 *= num63;
															num62 *= num63;
															this.velocity.X = num61;
															this.velocity.Y = num62;
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
															Microsoft.Xna.Framework.Vector2 arg_2B92_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
															int arg_2B92_1 = this.width;
															int arg_2B92_2 = this.height;
															int arg_2B92_3 = 32;
															float arg_2B92_4 = 0f;
															float arg_2B92_5 = this.velocity.Y / 2f;
															int arg_2B92_6 = 0;
															Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
															int num64 = Dust.NewDust(arg_2B92_0, arg_2B92_1, arg_2B92_2, arg_2B92_3, arg_2B92_4, arg_2B92_5, arg_2B92_6, newColor, 1f);
															Dust expr_2BA6_cp_0 = Main.dust[num64];
															expr_2BA6_cp_0.velocity.X = expr_2BA6_cp_0.velocity.X * 0.4f;
														}
													}
													else
													{
														if (this.type == 39)
														{
															if (Main.rand.Next(2) == 0)
															{
																Microsoft.Xna.Framework.Vector2 arg_2C28_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																int arg_2C28_1 = this.width;
																int arg_2C28_2 = this.height;
																int arg_2C28_3 = 38;
																float arg_2C28_4 = 0f;
																float arg_2C28_5 = this.velocity.Y / 2f;
																int arg_2C28_6 = 0;
																Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																int num65 = Dust.NewDust(arg_2C28_0, arg_2C28_1, arg_2C28_2, arg_2C28_3, arg_2C28_4, arg_2C28_5, arg_2C28_6, newColor, 1f);
																Dust expr_2C3C_cp_0 = Main.dust[num65];
																expr_2C3C_cp_0.velocity.X = expr_2C3C_cp_0.velocity.X * 0.4f;
															}
														}
														else
														{
															if (this.type == 40)
															{
																if (Main.rand.Next(2) == 0)
																{
																	Microsoft.Xna.Framework.Vector2 arg_2CBE_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																	int arg_2CBE_1 = this.width;
																	int arg_2CBE_2 = this.height;
																	int arg_2CBE_3 = 36;
																	float arg_2CBE_4 = 0f;
																	float arg_2CBE_5 = this.velocity.Y / 2f;
																	int arg_2CBE_6 = 0;
																	Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																	int num66 = Dust.NewDust(arg_2CBE_0, arg_2CBE_1, arg_2CBE_2, arg_2CBE_3, arg_2CBE_4, arg_2CBE_5, arg_2CBE_6, newColor, 1f);
																	Dust expr_2CCD = Main.dust[num66];
																	expr_2CCD.velocity *= 0.4f;
																}
															}
															else
															{
																if (this.type == 42 || this.type == 31)
																{
																	if (Main.rand.Next(2) == 0)
																	{
																		Microsoft.Xna.Framework.Vector2 arg_2D4E_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																		int arg_2D4E_1 = this.width;
																		int arg_2D4E_2 = this.height;
																		int arg_2D4E_3 = 32;
																		float arg_2D4E_4 = 0f;
																		float arg_2D4E_5 = 0f;
																		int arg_2D4E_6 = 0;
																		Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																		int num67 = Dust.NewDust(arg_2D4E_0, arg_2D4E_1, arg_2D4E_2, arg_2D4E_3, arg_2D4E_4, arg_2D4E_5, arg_2D4E_6, newColor, 1f);
																		Dust expr_2D62_cp_0 = Main.dust[num67];
																		expr_2D62_cp_0.velocity.X = expr_2D62_cp_0.velocity.X * 0.4f;
																	}
																}
																else
																{
																	if (this.type == 56 || this.type == 65)
																	{
																		if (Main.rand.Next(2) == 0)
																		{
																			Microsoft.Xna.Framework.Vector2 arg_2DDF_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																			int arg_2DDF_1 = this.width;
																			int arg_2DDF_2 = this.height;
																			int arg_2DDF_3 = 14;
																			float arg_2DDF_4 = 0f;
																			float arg_2DDF_5 = 0f;
																			int arg_2DDF_6 = 0;
																			Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																			int num68 = Dust.NewDust(arg_2DDF_0, arg_2DDF_1, arg_2DDF_2, arg_2DDF_3, arg_2DDF_4, arg_2DDF_5, arg_2DDF_6, newColor, 1f);
																			Dust expr_2DF3_cp_0 = Main.dust[num68];
																			expr_2DF3_cp_0.velocity.X = expr_2DF3_cp_0.velocity.X * 0.4f;
																		}
																	}
																	else
																	{
																		if (this.type == 67 || this.type == 68)
																		{
																			if (Main.rand.Next(2) == 0)
																			{
																				Microsoft.Xna.Framework.Vector2 arg_2E70_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																				int arg_2E70_1 = this.width;
																				int arg_2E70_2 = this.height;
																				int arg_2E70_3 = 51;
																				float arg_2E70_4 = 0f;
																				float arg_2E70_5 = 0f;
																				int arg_2E70_6 = 0;
																				Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																				int num69 = Dust.NewDust(arg_2E70_0, arg_2E70_1, arg_2E70_2, arg_2E70_3, arg_2E70_4, arg_2E70_5, arg_2E70_6, newColor, 1f);
																				Dust expr_2E84_cp_0 = Main.dust[num69];
																				expr_2E84_cp_0.velocity.X = expr_2E84_cp_0.velocity.X * 0.4f;
																			}
																		}
																		else
																		{
																			if (this.type == 71)
																			{
																				if (Main.rand.Next(2) == 0)
																				{
																					Microsoft.Xna.Framework.Vector2 arg_2EF7_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																					int arg_2EF7_1 = this.width;
																					int arg_2EF7_2 = this.height;
																					int arg_2EF7_3 = 53;
																					float arg_2EF7_4 = 0f;
																					float arg_2EF7_5 = 0f;
																					int arg_2EF7_6 = 0;
																					Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																					int num70 = Dust.NewDust(arg_2EF7_0, arg_2EF7_1, arg_2EF7_2, arg_2EF7_3, arg_2EF7_4, arg_2EF7_5, arg_2EF7_6, newColor, 1f);
																					Dust expr_2F0B_cp_0 = Main.dust[num70];
																					expr_2F0B_cp_0.velocity.X = expr_2F0B_cp_0.velocity.X * 0.4f;
																				}
																			}
																			else
																			{
																				if (Main.rand.Next(20) == 0)
																				{
																					Microsoft.Xna.Framework.Vector2 arg_2F6E_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																					int arg_2F6E_1 = this.width;
																					int arg_2F6E_2 = this.height;
																					int arg_2F6E_3 = 0;
																					float arg_2F6E_4 = 0f;
																					float arg_2F6E_5 = 0f;
																					int arg_2F6E_6 = 0;
																					Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																					Dust.NewDust(arg_2F6E_0, arg_2F6E_1, arg_2F6E_2, arg_2F6E_3, arg_2F6E_4, arg_2F6E_5, arg_2F6E_6, newColor, 1f);
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
															float num71 = 12f;
															Microsoft.Xna.Framework.Vector2 vector8 = new Microsoft.Xna.Framework.Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
															float num72 = (float)Main.mouseX + Main.screenPosition.X - vector8.X;
															float num73 = (float)Main.mouseY + Main.screenPosition.Y - vector8.Y;
															float num74 = (float)Math.Sqrt((double)(num72 * num72 + num73 * num73));
															num74 = (float)Math.Sqrt((double)(num72 * num72 + num73 * num73));
															if (num74 > num71)
															{
																num74 = num71 / num74;
																num72 *= num74;
																num73 *= num74;
																if (num72 != this.velocity.X || num73 != this.velocity.Y)
																{
																	this.netUpdate = true;
																}
																this.velocity.X = num72;
																this.velocity.Y = num73;
															}
															else
															{
																if (num72 != this.velocity.X || num73 != this.velocity.Y)
																{
																	this.netUpdate = true;
																}
																this.velocity.X = num72;
																this.velocity.Y = num73;
															}
														}
														else
														{
															this.ai[0] = 1f;
															this.netUpdate = true;
														}
													}
													if (this.ai[0] == 1f)
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
														if (this.ai[0] == 2f)
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
																int num75 = 56;
																if (this.type == 86)
																{
																	num75 = 73;
																}
																else
																{
																	if (this.type == 87)
																	{
																		num75 = 74;
																	}
																}
																Microsoft.Xna.Framework.Vector2 arg_3389_0 = this.position;
																int arg_3389_1 = this.width;
																int arg_3389_2 = this.height;
																int arg_3389_3 = num75;
																float arg_3389_4 = 0f;
																float arg_3389_5 = 0f;
																int arg_3389_6 = 200;
																Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																int num76 = Dust.NewDust(arg_3389_0, arg_3389_1, arg_3389_2, arg_3389_3, arg_3389_4, arg_3389_5, arg_3389_6, newColor, 0.8f);
																Dust expr_3398 = Main.dust[num76];
																expr_3398.velocity *= 0.3f;
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
														float num77 = 2.5f;
														if (this.type == 72 || this.type == 86 || this.type == 87)
														{
															num77 = 3.5f;
														}
														Microsoft.Xna.Framework.Vector2 vector9 = new Microsoft.Xna.Framework.Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
														float num78 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector9.X;
														float num79 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector9.Y;
														float num80 = (float)Math.Sqrt((double)(num78 * num78 + num79 * num79));
														num80 = (float)Math.Sqrt((double)(num78 * num78 + num79 * num79));
														int num81 = 70;
														if (this.type == 72 || this.type == 86 || this.type == 87)
														{
															num81 = 40;
														}
														if (num80 > 800f)
														{
															this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
															this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
															return;
														}
														if (num80 > (float)num81)
														{
															num80 = num77 / num80;
															num78 *= num80;
															num79 *= num80;
															this.velocity.X = num78;
															this.velocity.Y = num79;
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
															this.scale -= 0.04f;
															if (this.scale <= 0f)
															{
																this.Kill();
															}
															if (this.ai[0] > 4f)
															{
																this.alpha = 150;
																this.light = 0.8f;
																Microsoft.Xna.Framework.Vector2 arg_36E9_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																int arg_36E9_1 = this.width;
																int arg_36E9_2 = this.height;
																int arg_36E9_3 = 29;
																float arg_36E9_4 = this.velocity.X;
																float arg_36E9_5 = this.velocity.Y;
																int arg_36E9_6 = 100;
																Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																int num82 = Dust.NewDust(arg_36E9_0, arg_36E9_1, arg_36E9_2, arg_36E9_3, arg_36E9_4, arg_36E9_5, arg_36E9_6, newColor, 2.5f);
																Main.dust[num82].noGravity = true;
																Microsoft.Xna.Framework.Vector2 arg_374E_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																int arg_374E_1 = this.width;
																int arg_374E_2 = this.height;
																int arg_374E_3 = 29;
																float arg_374E_4 = this.velocity.X;
																float arg_374E_5 = this.velocity.Y;
																int arg_374E_6 = 100;
																newColor = default(Microsoft.Xna.Framework.Color);
																Dust.NewDust(arg_374E_0, arg_374E_1, arg_374E_2, arg_374E_3, arg_374E_4, arg_374E_5, arg_374E_6, newColor, 1.5f);
															}
															else
															{
																this.ai[0] += 1f;
															}
															this.rotation += 0.3f * (float)this.direction;
															return;
														}
														if (this.aiStyle == 13)
														{
															if (Main.player[this.owner].dead)
															{
																this.Kill();
																return;
															}
															Main.player[this.owner].itemAnimation = 5;
															Main.player[this.owner].itemTime = 5;
															if (this.position.X + (float)(this.width / 2) > Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2))
															{
																Main.player[this.owner].direction = 1;
															}
															else
															{
																Main.player[this.owner].direction = -1;
															}
															Microsoft.Xna.Framework.Vector2 vector10 = new Microsoft.Xna.Framework.Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
															float num83 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector10.X;
															float num84 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector10.Y;
															float num85 = (float)Math.Sqrt((double)(num83 * num83 + num84 * num84));
															if (this.ai[0] == 0f)
															{
																if (num85 > 700f)
																{
																	this.ai[0] = 1f;
																}
																this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
																this.ai[1] += 1f;
																if (this.ai[1] > 2f)
																{
																	this.alpha = 0;
																}
																if (this.ai[1] >= 10f)
																{
																	this.ai[1] = 15f;
																	this.velocity.Y = this.velocity.Y + 0.3f;
																	return;
																}
															}
															else
															{
																if (this.ai[0] == 1f)
																{
																	this.tileCollide = false;
																	this.rotation = (float)Math.Atan2((double)num84, (double)num83) - 1.57f;
																	float num86 = 20f;
																	if (num85 < 50f)
																	{
																		this.Kill();
																	}
																	num85 = num86 / num85;
																	num83 *= num85;
																	num84 *= num85;
																	this.velocity.X = num83;
																	this.velocity.Y = num84;
																	return;
																}
															}
														}
														else
														{
															if (this.aiStyle == 14)
															{
																if (this.type == 53)
																{
																	try
																	{
																		Microsoft.Xna.Framework.Vector2 value2 = Collision.TileCollision(this.position, this.velocity, this.width, this.height, false, false);
																		//this.velocity != value2;
																		int num87 = (int)(this.position.X / 16f) - 1;
																		int num88 = (int)((this.position.X + (float)this.width) / 16f) + 2;
																		int num89 = (int)(this.position.Y / 16f) - 1;
																		int num90 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
																		if (num87 < 0)
																		{
																			num87 = 0;
																		}
																		if (num88 > Main.maxTilesX)
																		{
																			num88 = Main.maxTilesX;
																		}
																		if (num89 < 0)
																		{
																			num89 = 0;
																		}
																		if (num90 > Main.maxTilesY)
																		{
																			num90 = Main.maxTilesY;
																		}
																		for (int num91 = num87; num91 < num88; num91++)
																		{
																			for (int num92 = num89; num92 < num90; num92++)
																			{
																				if (Main.tile[num91, num92] != null && Main.tile[num91, num92].active && (Main.tileSolid[(int)Main.tile[num91, num92].type] || (Main.tileSolidTop[(int)Main.tile[num91, num92].type] && Main.tile[num91, num92].frameY == 0)))
																				{
																					Microsoft.Xna.Framework.Vector2 vector11;
																					vector11.X = (float)(num91 * 16);
																					vector11.Y = (float)(num92 * 16);
																					if (this.position.X + (float)this.width > vector11.X && this.position.X < vector11.X + 16f && this.position.Y + (float)this.height > vector11.Y && this.position.Y < vector11.Y + 16f)
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
																			Microsoft.Xna.Framework.Vector2 arg_3DD4_0 = this.position;
																			int arg_3DD4_1 = this.width;
																			int arg_3DD4_2 = this.height;
																			int arg_3DD4_3 = 14;
																			float arg_3DD4_4 = 0f;
																			float arg_3DD4_5 = 0f;
																			int arg_3DD4_6 = 150;
																			Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																			Dust.NewDust(arg_3DD4_0, arg_3DD4_1, arg_3DD4_2, arg_3DD4_3, arg_3DD4_4, arg_3DD4_5, arg_3DD4_6, newColor, 1.3f);
																		}
																	}
																	else
																	{
																		if (this.type == 26)
																		{
																			Microsoft.Xna.Framework.Vector2 arg_3E33_0 = this.position;
																			int arg_3E33_1 = this.width;
																			int arg_3E33_2 = this.height;
																			int arg_3E33_3 = 29;
																			float arg_3E33_4 = this.velocity.X * 0.4f;
																			float arg_3E33_5 = this.velocity.Y * 0.4f;
																			int arg_3E33_6 = 100;
																			Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																			int num93 = Dust.NewDust(arg_3E33_0, arg_3E33_1, arg_3E33_2, arg_3E33_3, arg_3E33_4, arg_3E33_5, arg_3E33_6, newColor, 2.5f);
																			Main.dust[num93].noGravity = true;
																			Dust expr_3E55_cp_0 = Main.dust[num93];
																			expr_3E55_cp_0.velocity.X = expr_3E55_cp_0.velocity.X / 2f;
																			Dust expr_3E73_cp_0 = Main.dust[num93];
																			expr_3E73_cp_0.velocity.Y = expr_3E73_cp_0.velocity.Y / 2f;
																		}
																		else
																		{
																			if (this.type == 35)
																			{
																				Microsoft.Xna.Framework.Vector2 arg_3EDC_0 = this.position;
																				int arg_3EDC_1 = this.width;
																				int arg_3EDC_2 = this.height;
																				int arg_3EDC_3 = 6;
																				float arg_3EDC_4 = this.velocity.X * 0.4f;
																				float arg_3EDC_5 = this.velocity.Y * 0.4f;
																				int arg_3EDC_6 = 100;
																				Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																				int num94 = Dust.NewDust(arg_3EDC_0, arg_3EDC_1, arg_3EDC_2, arg_3EDC_3, arg_3EDC_4, arg_3EDC_5, arg_3EDC_6, newColor, 3f);
																				Main.dust[num94].noGravity = true;
																				Dust expr_3EFE_cp_0 = Main.dust[num94];
																				expr_3EFE_cp_0.velocity.X = expr_3EFE_cp_0.velocity.X * 2f;
																				Dust expr_3F1C_cp_0 = Main.dust[num94];
																				expr_3F1C_cp_0.velocity.Y = expr_3F1C_cp_0.velocity.Y * 2f;
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
																		Main.player[this.owner].direction = 1;
																		this.direction = 1;
																	}
																	else
																	{
																		Main.player[this.owner].direction = -1;
																		this.direction = -1;
																	}
																	Microsoft.Xna.Framework.Vector2 vector12 = new Microsoft.Xna.Framework.Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
																	float num95 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector12.X;
																	float num96 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector12.Y;
																	float num97 = (float)Math.Sqrt((double)(num95 * num95 + num96 * num96));
																	if (this.ai[0] == 0f)
																	{
																		float num98 = 160f;
																		if (this.type == 63)
																		{
																			num98 *= 1.5f;
																		}
																		this.tileCollide = true;
																		if (num97 > num98)
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
																			float num99 = 14f / Main.player[this.owner].meleeSpeed;
																			float num100 = 0.9f / Main.player[this.owner].meleeSpeed;
																			float num101 = 300f;
																			if (this.type == 63)
																			{
																				num101 *= 1.5f;
																				num99 *= 1.5f;
																				num100 *= 1.5f;
																			}
																			Math.Abs(num95);
																			Math.Abs(num96);
																			if (this.ai[1] == 1f)
																			{
																				this.tileCollide = false;
																			}
																			if (!Main.player[this.owner].channel || num97 > num101 || !this.tileCollide)
																			{
																				this.ai[1] = 1f;
																				if (this.tileCollide)
																				{
																					this.netUpdate = true;
																				}
																				this.tileCollide = false;
																				if (num97 < 20f)
																				{
																					this.Kill();
																				}
																			}
																			if (!this.tileCollide)
																			{
																				num100 *= 2f;
																			}
																			if (num97 > 60f || !this.tileCollide)
																			{
																				num97 = num99 / num97;
																				num95 *= num97;
																				num96 *= num97;
																				new Microsoft.Xna.Framework.Vector2(this.velocity.X, this.velocity.Y);
																				float num102 = num95 - this.velocity.X;
																				float num103 = num96 - this.velocity.Y;
																				float num104 = (float)Math.Sqrt((double)(num102 * num102 + num103 * num103));
																				num104 = num100 / num104;
																				num102 *= num104;
																				num103 *= num104;
																				this.velocity.X = this.velocity.X * 0.98f;
																				this.velocity.Y = this.velocity.Y * 0.98f;
																				this.velocity.X = this.velocity.X + num102;
																				this.velocity.Y = this.velocity.Y + num103;
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
																	this.rotation = (float)Math.Atan2((double)num96, (double)num95) - this.velocity.X * 0.1f;
																	return;
																}
																else
																{
																	if (this.aiStyle == 16)
																	{
																		if (this.type == 108)
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
																				int num105 = (int)(this.position.X / 16f) - 1;
																				int num106 = (int)((this.position.X + (float)this.width) / 16f) + 2;
																				int num107 = (int)(this.position.Y / 16f) - 1;
																				int num108 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
																				if (num105 < 0)
																				{
																					num105 = 0;
																				}
																				if (num106 > Main.maxTilesX)
																				{
																					num106 = Main.maxTilesX;
																				}
																				if (num107 < 0)
																				{
																					num107 = 0;
																				}
																				if (num108 > Main.maxTilesY)
																				{
																					num108 = Main.maxTilesY;
																				}
																				for (int num109 = num105; num109 < num106; num109++)
																				{
																					for (int num110 = num107; num110 < num108; num110++)
																					{
																						if (Main.tile[num109, num110] != null && Main.tile[num109, num110].active && (Main.tileSolid[(int)Main.tile[num109, num110].type] || (Main.tileSolidTop[(int)Main.tile[num109, num110].type] && Main.tile[num109, num110].frameY == 0)))
																						{
																							Microsoft.Xna.Framework.Vector2 vector13;
																							vector13.X = (float)(num109 * 16);
																							vector13.Y = (float)(num110 * 16);
																							if (this.position.X + (float)this.width - 4f > vector13.X && this.position.X + 4f < vector13.X + 16f && this.position.Y + (float)this.height - 4f > vector13.Y && this.position.Y + 4f < vector13.Y + 16f)
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
																		if (this.owner == Main.myPlayer && this.timeLeft <= 3)
																		{
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
																				}
																			}
																		}
																		else
																		{
																			if (this.type != 30 && this.type != 108)
																			{
																				this.damage = 0;
																			}
																			if (this.type != 30 && Main.rand.Next(4) == 0)
																			{
																				Microsoft.Xna.Framework.Vector2 arg_4A5E_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																				int arg_4A5E_1 = this.width;
																				int arg_4A5E_2 = this.height;
																				int arg_4A5E_3 = 6;
																				float arg_4A5E_4 = 0f;
																				float arg_4A5E_5 = 0f;
																				int arg_4A5E_6 = 100;
																				Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																				Dust.NewDust(arg_4A5E_0, arg_4A5E_1, arg_4A5E_2, arg_4A5E_3, arg_4A5E_4, arg_4A5E_5, arg_4A5E_6, newColor, 1f);
																			}
																		}
																		this.ai[0] += 1f;
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
																		this.rotation += this.velocity.X * 0.1f;
																		return;
																	}
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
																			int num111 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
																			int num112 = (int)((this.position.Y + (float)this.height - 4f) / 16f);
																			if (Main.tile[num111, num112] != null && !Main.tile[num111, num112].active)
																			{
																				WorldGen.PlaceTile(num111, num112, 85, false, false, -1, 0);
																				if (Main.tile[num111, num112].active)
																				{
																					if (Main.netMode != 0)
																					{
																						NetMessage.SendData(17, -1, -1, "", 1, (float)num111, (float)num112, 85f, 0);
																					}
																					int num113 = Sign.ReadSign(num111, num112);
																					if (num113 >= 0)
																					{
																						Sign.TextSign(num113, this.miscText);
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
																			for (int num114 = 0; num114 < 2; num114++)
																			{
																				Microsoft.Xna.Framework.Vector2 arg_4E09_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																				int arg_4E09_1 = this.width;
																				int arg_4E09_2 = this.height;
																				int arg_4E09_3 = 27;
																				float arg_4E09_4 = 0f;
																				float arg_4E09_5 = 0f;
																				int arg_4E09_6 = 100;
																				Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																				int num115 = Dust.NewDust(arg_4E09_0, arg_4E09_1, arg_4E09_2, arg_4E09_3, arg_4E09_4, arg_4E09_5, arg_4E09_6, newColor, 1f);
																				Main.dust[num115].noGravity = true;
																			}
																			return;
																		}
																		if (this.aiStyle == 19)
																		{
																			this.direction = Main.player[this.owner].direction;
																			Main.player[this.owner].heldProj = this.whoAmI;
																			Main.player[this.owner].itemTime = Main.player[this.owner].itemAnimation;
																			this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
																			this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
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
																							if (this.type == 64)
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
																								if (this.type == 66 || this.type == 97)
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
																									if (this.type == 97)
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
																											this.ai[0] += 1.4f;
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																			this.position += this.velocity * this.ai[0];
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
																				Microsoft.Xna.Framework.Color newColor;
																				if (Main.rand.Next(5) == 0)
																				{
																					Microsoft.Xna.Framework.Vector2 arg_5434_0 = this.position;
																					int arg_5434_1 = this.width;
																					int arg_5434_2 = this.height;
																					int arg_5434_3 = 14;
																					float arg_5434_4 = 0f;
																					float arg_5434_5 = 0f;
																					int arg_5434_6 = 150;
																					newColor = default(Microsoft.Xna.Framework.Color);
																					Dust.NewDust(arg_5434_0, arg_5434_1, arg_5434_2, arg_5434_3, arg_5434_4, arg_5434_5, arg_5434_6, newColor, 1.4f);
																				}
																				Microsoft.Xna.Framework.Vector2 arg_548B_0 = this.position;
																				int arg_548B_1 = this.width;
																				int arg_548B_2 = this.height;
																				int arg_548B_3 = 27;
																				float arg_548B_4 = this.velocity.X * 0.2f + (float)(this.direction * 3);
																				float arg_548B_5 = this.velocity.Y * 0.2f;
																				int arg_548B_6 = 100;
																				newColor = default(Microsoft.Xna.Framework.Color);
																				int num116 = Dust.NewDust(arg_548B_0, arg_548B_1, arg_548B_2, arg_548B_3, arg_548B_4, arg_548B_5, arg_548B_6, newColor, 1.2f);
																				Main.dust[num116].noGravity = true;
																				Dust expr_54AD_cp_0 = Main.dust[num116];
																				expr_54AD_cp_0.velocity.X = expr_54AD_cp_0.velocity.X / 2f;
																				Dust expr_54CB_cp_0 = Main.dust[num116];
																				expr_54CB_cp_0.velocity.Y = expr_54CB_cp_0.velocity.Y / 2f;
																				Microsoft.Xna.Framework.Vector2 arg_5523_0 = this.position - this.velocity * 2f;
																				int arg_5523_1 = this.width;
																				int arg_5523_2 = this.height;
																				int arg_5523_3 = 27;
																				float arg_5523_4 = 0f;
																				float arg_5523_5 = 0f;
																				int arg_5523_6 = 150;
																				newColor = default(Microsoft.Xna.Framework.Color);
																				num116 = Dust.NewDust(arg_5523_0, arg_5523_1, arg_5523_2, arg_5523_3, arg_5523_4, arg_5523_5, arg_5523_6, newColor, 1.4f);
																				Dust expr_5537_cp_0 = Main.dust[num116];
																				expr_5537_cp_0.velocity.X = expr_5537_cp_0.velocity.X / 5f;
																				Dust expr_5555_cp_0 = Main.dust[num116];
																				expr_5555_cp_0.velocity.Y = expr_5555_cp_0.velocity.Y / 5f;
																				return;
																			}
																			if (this.type == 105)
																			{
																				if (Main.rand.Next(3) == 0)
																				{
																					Microsoft.Xna.Framework.Vector2 arg_55E3_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																					int arg_55E3_1 = this.width;
																					int arg_55E3_2 = this.height;
																					int arg_55E3_3 = 57;
																					float arg_55E3_4 = this.velocity.X * 0.2f;
																					float arg_55E3_5 = this.velocity.Y * 0.2f;
																					int arg_55E3_6 = 200;
																					Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																					int num117 = Dust.NewDust(arg_55E3_0, arg_55E3_1, arg_55E3_2, arg_55E3_3, arg_55E3_4, arg_55E3_5, arg_55E3_6, newColor, 1.2f);
																					Dust expr_55F2 = Main.dust[num117];
																					expr_55F2.velocity += this.velocity * 0.3f;
																					Dust expr_561A = Main.dust[num117];
																					expr_561A.velocity *= 0.2f;
																				}
																				if (Main.rand.Next(4) == 0)
																				{
																					Microsoft.Xna.Framework.Vector2 arg_5686_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																					int arg_5686_1 = this.width;
																					int arg_5686_2 = this.height;
																					int arg_5686_3 = 43;
																					float arg_5686_4 = 0f;
																					float arg_5686_5 = 0f;
																					int arg_5686_6 = 254;
																					Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																					int num118 = Dust.NewDust(arg_5686_0, arg_5686_1, arg_5686_2, arg_5686_3, arg_5686_4, arg_5686_5, arg_5686_6, newColor, 0.3f);
																					Dust expr_5695 = Main.dust[num118];
																					expr_5695.velocity += this.velocity * 0.5f;
																					Dust expr_56BD = Main.dust[num118];
																					expr_56BD.velocity *= 0.5f;
																					return;
																				}
																			}
																		}
																		else
																		{
																			if (this.aiStyle == 20)
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
																						float num119 = Main.player[this.owner].inventory[Main.player[this.owner].selectedItem].shootSpeed * this.scale;
																						Microsoft.Xna.Framework.Vector2 vector14 = new Microsoft.Xna.Framework.Vector2(Main.player[this.owner].position.X + (float)Main.player[this.owner].width * 0.5f, Main.player[this.owner].position.Y + (float)Main.player[this.owner].height * 0.5f);
																						float num120 = (float)Main.mouseX + Main.screenPosition.X - vector14.X;
																						float num121 = (float)Main.mouseY + Main.screenPosition.Y - vector14.Y;
																						float num122 = (float)Math.Sqrt((double)(num120 * num120 + num121 * num121));
																						num122 = (float)Math.Sqrt((double)(num120 * num120 + num121 * num121));
																						num122 = num119 / num122;
																						num120 *= num122;
																						num121 *= num122;
																						if (num120 != this.velocity.X || num121 != this.velocity.Y)
																						{
																							this.netUpdate = true;
																						}
																						this.velocity.X = num120;
																						this.velocity.Y = num121;
																					}
																					else
																					{
																						this.Kill();
																					}
																				}
																				if (this.velocity.X > 0f)
																				{
																					Main.player[this.owner].direction = 1;
																				}
																				else
																				{
																					if (this.velocity.X < 0f)
																					{
																						Main.player[this.owner].direction = -1;
																					}
																				}
																				this.spriteDirection = this.direction;
																				Main.player[this.owner].direction = this.direction;
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
																					Microsoft.Xna.Framework.Vector2 arg_5B04_0 = this.position + this.velocity * (float)Main.rand.Next(6, 10) * 0.1f;
																					int arg_5B04_1 = this.width;
																					int arg_5B04_2 = this.height;
																					int arg_5B04_3 = 31;
																					float arg_5B04_4 = 0f;
																					float arg_5B04_5 = 0f;
																					int arg_5B04_6 = 80;
																					Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																					int num123 = Dust.NewDust(arg_5B04_0, arg_5B04_1, arg_5B04_2, arg_5B04_3, arg_5B04_4, arg_5B04_5, arg_5B04_6, newColor, 1.4f);
																					Dust expr_5B18_cp_0 = Main.dust[num123];
																					expr_5B18_cp_0.position.X = expr_5B18_cp_0.position.X - 4f;
																					Main.dust[num123].noGravity = true;
																					Dust expr_5B3F = Main.dust[num123];
																					expr_5B3F.velocity *= 0.2f;
																					Main.dust[num123].velocity.Y = (float)(-(float)Main.rand.Next(7, 13)) * 0.15f;
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
																						Microsoft.Xna.Framework.Vector2 arg_5BE9_0 = this.position;
																						int arg_5BE9_1 = this.width;
																						int arg_5BE9_2 = this.height;
																						int arg_5BE9_3 = 27;
																						float arg_5BE9_4 = 0f;
																						float arg_5BE9_5 = 0f;
																						int arg_5BE9_6 = 80;
																						Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																						int num124 = Dust.NewDust(arg_5BE9_0, arg_5BE9_1, arg_5BE9_2, arg_5BE9_3, arg_5BE9_4, arg_5BE9_5, arg_5BE9_6, newColor, 1f);
																						Main.dust[num124].noGravity = true;
																						Dust expr_5C06 = Main.dust[num124];
																						expr_5C06.velocity *= 0.2f;
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
																							int num125 = (int)(this.position.X / 16f) - 1;
																							int num126 = (int)((this.position.X + (float)this.width) / 16f) + 2;
																							int num127 = (int)(this.position.Y / 16f) - 1;
																							int num128 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
																							if (num125 < 0)
																							{
																								num125 = 0;
																							}
																							if (num126 > Main.maxTilesX)
																							{
																								num126 = Main.maxTilesX;
																							}
																							if (num127 < 0)
																							{
																								num127 = 0;
																							}
																							if (num128 > Main.maxTilesY)
																							{
																								num128 = Main.maxTilesY;
																							}
																							int num129 = (int)this.position.X + 4;
																							int num130 = (int)this.position.Y + 4;
																							for (int num131 = num125; num131 < num126; num131++)
																							{
																								for (int num132 = num127; num132 < num128; num132++)
																								{
																									if (Main.tile[num131, num132] != null && Main.tile[num131, num132].active && Main.tile[num131, num132].type != 127 && Main.tileSolid[(int)Main.tile[num131, num132].type] && !Main.tileSolidTop[(int)Main.tile[num131, num132].type])
																									{
																										Microsoft.Xna.Framework.Vector2 vector15;
																										vector15.X = (float)(num131 * 16);
																										vector15.Y = (float)(num132 * 16);
																										if ((float)(num129 + 8) > vector15.X && (float)num129 < vector15.X + 16f && (float)(num130 + 8) > vector15.Y && (float)num130 < vector15.Y + 16f)
																										{
																											this.Kill();
																										}
																									}
																								}
																							}
																							Microsoft.Xna.Framework.Vector2 arg_5EF4_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																							int arg_5EF4_1 = this.width;
																							int arg_5EF4_2 = this.height;
																							int arg_5EF4_3 = 67;
																							float arg_5EF4_4 = 0f;
																							float arg_5EF4_5 = 0f;
																							int arg_5EF4_6 = 0;
																							Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																							int num133 = Dust.NewDust(arg_5EF4_0, arg_5EF4_1, arg_5EF4_2, arg_5EF4_3, arg_5EF4_4, arg_5EF4_5, arg_5EF4_6, newColor, 1f);
																							Main.dust[num133].noGravity = true;
																							Dust expr_5F11 = Main.dust[num133];
																							expr_5F11.velocity *= 0.3f;
																							return;
																						}
																						if (this.ai[0] < 0f)
																						{
																							if (this.ai[0] == -1f)
																							{
																								for (int num134 = 0; num134 < 10; num134++)
																								{
																									Microsoft.Xna.Framework.Vector2 arg_5F93_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																									int arg_5F93_1 = this.width;
																									int arg_5F93_2 = this.height;
																									int arg_5F93_3 = 67;
																									float arg_5F93_4 = 0f;
																									float arg_5F93_5 = 0f;
																									int arg_5F93_6 = 0;
																									Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																									int num135 = Dust.NewDust(arg_5F93_0, arg_5F93_1, arg_5F93_2, arg_5F93_3, arg_5F93_4, arg_5F93_5, arg_5F93_6, newColor, 1.1f);
																									Main.dust[num135].noGravity = true;
																									Dust expr_5FB0 = Main.dust[num135];
																									expr_5FB0.velocity *= 1.3f;
																								}
																							}
																							else
																							{
																								if (Main.rand.Next(30) == 0)
																								{
																									Microsoft.Xna.Framework.Vector2 arg_6028_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																									int arg_6028_1 = this.width;
																									int arg_6028_2 = this.height;
																									int arg_6028_3 = 67;
																									float arg_6028_4 = 0f;
																									float arg_6028_5 = 0f;
																									int arg_6028_6 = 100;
																									Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																									int num136 = Dust.NewDust(arg_6028_0, arg_6028_1, arg_6028_2, arg_6028_3, arg_6028_4, arg_6028_5, arg_6028_6, newColor, 1f);
																									Dust expr_6037 = Main.dust[num136];
																									expr_6037.velocity *= 0.2f;
																								}
																							}
																							int num137 = (int)this.position.X / 16;
																							int num138 = (int)this.position.Y / 16;
																							if (Main.tile[num137, num138] == null || !Main.tile[num137, num138].active)
																							{
																								this.Kill();
																							}
																							this.ai[0] -= 1f;
																							if (this.ai[0] <= -300f && (Main.myPlayer == this.owner || Main.netMode == 2) && Main.tile[num137, num138].active && Main.tile[num137, num138].type == 127)
																							{
																								WorldGen.KillTile(num137, num138, false, false, false);
																								if (Main.netMode == 1)
																								{
																									NetMessage.SendData(17, -1, -1, "", 0, (float)num137, (float)num138, 0f, 0);
																								}
																								this.Kill();
																								return;
																							}
																						}
																						else
																						{
																							int num139 = (int)(this.position.X / 16f) - 1;
																							int num140 = (int)((this.position.X + (float)this.width) / 16f) + 2;
																							int num141 = (int)(this.position.Y / 16f) - 1;
																							int num142 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
																							if (num139 < 0)
																							{
																								num139 = 0;
																							}
																							if (num140 > Main.maxTilesX)
																							{
																								num140 = Main.maxTilesX;
																							}
																							if (num141 < 0)
																							{
																								num141 = 0;
																							}
																							if (num142 > Main.maxTilesY)
																							{
																								num142 = Main.maxTilesY;
																							}
																							int num143 = (int)this.position.X + 4;
																							int num144 = (int)this.position.Y + 4;
																							for (int num145 = num139; num145 < num140; num145++)
																							{
																								for (int num146 = num141; num146 < num142; num146++)
																								{
																									if (Main.tile[num145, num146] != null && Main.tile[num145, num146].active && Main.tile[num145, num146].type != 127 && Main.tileSolid[(int)Main.tile[num145, num146].type] && !Main.tileSolidTop[(int)Main.tile[num145, num146].type])
																									{
																										Microsoft.Xna.Framework.Vector2 vector16;
																										vector16.X = (float)(num145 * 16);
																										vector16.Y = (float)(num146 * 16);
																										if ((float)(num143 + 8) > vector16.X && (float)num143 < vector16.X + 16f && (float)(num144 + 8) > vector16.Y && (float)num144 < vector16.Y + 16f)
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
																								Microsoft.Xna.Framework.Vector2 arg_6367_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																								int arg_6367_1 = this.width;
																								int arg_6367_2 = this.height;
																								int arg_6367_3 = 67;
																								float arg_6367_4 = 0f;
																								float arg_6367_5 = 0f;
																								int arg_6367_6 = 0;
																								Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																								int num147 = Dust.NewDust(arg_6367_0, arg_6367_1, arg_6367_2, arg_6367_3, arg_6367_4, arg_6367_5, arg_6367_6, newColor, 1f);
																								Main.dust[num147].noGravity = true;
																								Dust expr_6384 = Main.dust[num147];
																								expr_6384.velocity *= 0.3f;
																								int num148 = (int)this.ai[0];
																								int num149 = (int)this.ai[1];
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
																									int num150 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
																									int num151 = (int)((this.position.Y + (float)(this.height / 2)) / 16f);
																									bool flag2 = false;
																									if (num150 == num148 && num151 == num149)
																									{
																										flag2 = true;
																									}
																									if (((this.velocity.X <= 0f && num150 <= num148) || (this.velocity.X >= 0f && num150 >= num148)) && ((this.velocity.Y <= 0f && num151 <= num149) || (this.velocity.Y >= 0f && num151 >= num149)))
																									{
																										flag2 = true;
																									}
																									if (flag2)
																									{
																										if (WorldGen.PlaceTile(num148, num149, 127, false, false, this.owner, 0))
																										{
																											if (Main.netMode == 1)
																											{
																												NetMessage.SendData(17, -1, -1, "", 1, (float)((int)this.ai[0]), (float)((int)this.ai[1]), 127f, 0);
																											}
																											this.damage = 0;
																											this.ai[0] = -1f;
																											this.velocity *= 0f;
																											this.alpha = 255;
																											this.position.X = (float)(num148 * 16);
																											this.position.Y = (float)(num149 * 16);
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
																							if (this.timeLeft > 60)
																							{
																								this.timeLeft = 60;
																							}
																							if (this.ai[0] > 7f)
																							{
																								float num152 = 1f;
																								if (this.ai[0] == 8f)
																								{
																									num152 = 0.25f;
																								}
																								else
																								{
																									if (this.ai[0] == 9f)
																									{
																										num152 = 0.5f;
																									}
																									else
																									{
																										if (this.ai[0] == 10f)
																										{
																											num152 = 0.75f;
																										}
																									}
																								}
																								this.ai[0] += 1f;
																								int num153 = 6;
																								if (this.type == 101)
																								{
																									num153 = 75;
																								}
																								if (num153 == 6 || Main.rand.Next(2) == 0)
																								{
																									for (int num154 = 0; num154 < 1; num154++)
																									{
																										Microsoft.Xna.Framework.Vector2 arg_668B_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																										int arg_668B_1 = this.width;
																										int arg_668B_2 = this.height;
																										int arg_668B_3 = num153;
																										float arg_668B_4 = this.velocity.X * 0.2f;
																										float arg_668B_5 = this.velocity.Y * 0.2f;
																										int arg_668B_6 = 100;
																										Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																										int num155 = Dust.NewDust(arg_668B_0, arg_668B_1, arg_668B_2, arg_668B_3, arg_668B_4, arg_668B_5, arg_668B_6, newColor, 1f);
																										if (Main.rand.Next(3) != 0 || (num153 == 75 && Main.rand.Next(3) == 0))
																										{
																											Main.dust[num155].noGravity = true;
																											Main.dust[num155].scale *= 3f;
																											Dust expr_66E6_cp_0 = Main.dust[num155];
																											expr_66E6_cp_0.velocity.X = expr_66E6_cp_0.velocity.X * 2f;
																											Dust expr_6704_cp_0 = Main.dust[num155];
																											expr_6704_cp_0.velocity.Y = expr_6704_cp_0.velocity.Y * 2f;
																										}
																										Main.dust[num155].scale *= 1.5f;
																										Dust expr_673B_cp_0 = Main.dust[num155];
																										expr_673B_cp_0.velocity.X = expr_673B_cp_0.velocity.X * 1.2f;
																										Dust expr_6759_cp_0 = Main.dust[num155];
																										expr_6759_cp_0.velocity.Y = expr_6759_cp_0.velocity.Y * 1.2f;
																										Main.dust[num155].scale *= num152;
																										if (num153 == 75)
																										{
																											Dust expr_678E = Main.dust[num155];
																											expr_678E.velocity += this.velocity;
																											if (!Main.dust[num155].noGravity)
																											{
																												Dust expr_67BB = Main.dust[num155];
																												expr_67BB.velocity *= 0.5f;
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
																									Microsoft.Xna.Framework.Vector2 arg_68D2_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																									int arg_68D2_1 = this.width;
																									int arg_68D2_2 = this.height;
																									int arg_68D2_3 = 70;
																									float arg_68D2_4 = 0f;
																									float arg_68D2_5 = 0f;
																									int arg_68D2_6 = 0;
																									Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																									int num156 = Dust.NewDust(arg_68D2_0, arg_68D2_1, arg_68D2_2, arg_68D2_3, arg_68D2_4, arg_68D2_5, arg_68D2_6, newColor, 1f);
																									Main.dust[num156].noGravity = true;
																									Dust expr_68EF = Main.dust[num156];
																									expr_68EF.velocity *= 0.5f;
																									Main.dust[num156].scale *= 0.9f;
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
																									float num157 = 0.5f;
																									int i2 = (int)((this.position.X - 8f) / 16f);
																									int num158 = (int)(this.position.Y / 16f);
																									bool flag3 = false;
																									bool flag4 = false;
																									if (WorldGen.SolidTile(i2, num158) || WorldGen.SolidTile(i2, num158 + 1))
																									{
																										flag3 = true;
																									}
																									i2 = (int)((this.position.X + (float)this.width + 8f) / 16f);
																									if (WorldGen.SolidTile(i2, num158) || WorldGen.SolidTile(i2, num158 + 1))
																									{
																										flag4 = true;
																									}
																									if (flag3)
																									{
																										this.velocity.X = num157;
																									}
																									else
																									{
																										if (flag4)
																										{
																											this.velocity.X = -num157;
																										}
																										else
																										{
																											i2 = (int)((this.position.X - 8f - 16f) / 16f);
																											num158 = (int)(this.position.Y / 16f);
																											flag3 = false;
																											flag4 = false;
																											if (WorldGen.SolidTile(i2, num158) || WorldGen.SolidTile(i2, num158 + 1))
																											{
																												flag3 = true;
																											}
																											i2 = (int)((this.position.X + (float)this.width + 8f + 16f) / 16f);
																											if (WorldGen.SolidTile(i2, num158) || WorldGen.SolidTile(i2, num158 + 1))
																											{
																												flag4 = true;
																											}
																											if (flag3)
																											{
																												this.velocity.X = num157;
																											}
																											else
																											{
																												if (flag4)
																												{
																													this.velocity.X = -num157;
																												}
																												else
																												{
																													i2 = (int)((this.position.X + 4f) / 16f);
																													num158 = (int)((this.position.Y + (float)this.height + 8f) / 16f);
																													if (WorldGen.SolidTile(i2, num158) || WorldGen.SolidTile(i2, num158 + 1))
																													{
																														flag3 = true;
																													}
																													if (!flag3)
																													{
																														this.velocity.X = num157;
																													}
																													else
																													{
																														this.velocity.X = -num157;
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
			{
				return;
			}
			this.timeLeft = 0;
			if (this.type == 1 || this.type == 81 || this.type == 98)
			{
				Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
				for (int i = 0; i < 10; i++)
				{
					Microsoft.Xna.Framework.Vector2 arg_92_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
					int arg_92_1 = this.width;
					int arg_92_2 = this.height;
					int arg_92_3 = 7;
					float arg_92_4 = 0f;
					float arg_92_5 = 0f;
					int arg_92_6 = 0;
					Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
					Dust.NewDust(arg_92_0, arg_92_1, arg_92_2, arg_92_3, arg_92_4, arg_92_5, arg_92_6, newColor, 1f);
				}
			}
			else
			{
				if (this.type == 93)
				{
					Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
					for (int j = 0; j < 10; j++)
					{
						Microsoft.Xna.Framework.Vector2 arg_105_0 = this.position;
						int arg_105_1 = this.width;
						int arg_105_2 = this.height;
						int arg_105_3 = 57;
						float arg_105_4 = 0f;
						float arg_105_5 = 0f;
						int arg_105_6 = 100;
						Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
						int num = Dust.NewDust(arg_105_0, arg_105_1, arg_105_2, arg_105_3, arg_105_4, arg_105_5, arg_105_6, newColor, 0.5f);
						Dust expr_117_cp_0 = Main.dust[num];
						expr_117_cp_0.velocity.X = expr_117_cp_0.velocity.X * 2f;
						Dust expr_134_cp_0 = Main.dust[num];
						expr_134_cp_0.velocity.Y = expr_134_cp_0.velocity.Y * 2f;
					}
				}
				else
				{
					if (this.type == 99)
					{
						Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
						for (int k = 0; k < 30; k++)
						{
							Microsoft.Xna.Framework.Vector2 arg_1B0_0 = this.position;
							int arg_1B0_1 = this.width;
							int arg_1B0_2 = this.height;
							int arg_1B0_3 = 1;
							float arg_1B0_4 = 0f;
							float arg_1B0_5 = 0f;
							int arg_1B0_6 = 0;
							Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
							int num2 = Dust.NewDust(arg_1B0_0, arg_1B0_1, arg_1B0_2, arg_1B0_3, arg_1B0_4, arg_1B0_5, arg_1B0_6, newColor, 1f);
							if (Main.rand.Next(2) == 0)
							{
								Main.dust[num2].scale *= 1.4f;
							}
							this.velocity *= 1.9f;
						}
					}
					else
					{
						if (this.type == 91 || this.type == 92)
						{
							Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
							for (int l = 0; l < 10; l++)
							{
								Microsoft.Xna.Framework.Vector2 arg_287_0 = this.position;
								int arg_287_1 = this.width;
								int arg_287_2 = this.height;
								int arg_287_3 = 58;
								float arg_287_4 = this.velocity.X * 0.1f;
								float arg_287_5 = this.velocity.Y * 0.1f;
								int arg_287_6 = 150;
								Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
								Dust.NewDust(arg_287_0, arg_287_1, arg_287_2, arg_287_3, arg_287_4, arg_287_5, arg_287_6, newColor, 1.2f);
							}
							for (int m = 0; m < 3; m++)
							{
								Gore.NewGore(this.position, new Microsoft.Xna.Framework.Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
							}
							if (this.type == 12 && this.damage < 100)
							{
								for (int n = 0; n < 10; n++)
								{
									Microsoft.Xna.Framework.Vector2 arg_358_0 = this.position;
									int arg_358_1 = this.width;
									int arg_358_2 = this.height;
									int arg_358_3 = 57;
									float arg_358_4 = this.velocity.X * 0.1f;
									float arg_358_5 = this.velocity.Y * 0.1f;
									int arg_358_6 = 150;
									Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
									Dust.NewDust(arg_358_0, arg_358_1, arg_358_2, arg_358_3, arg_358_4, arg_358_5, arg_358_6, newColor, 1.2f);
								}
								for (int num3 = 0; num3 < 3; num3++)
								{
									Gore.NewGore(this.position, new Microsoft.Xna.Framework.Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
								}
							}
							if ((this.type == 91 || (this.type == 92 && this.ai[0] > 0f)) && this.owner == Main.myPlayer)
							{
								float x = this.position.X + (float)Main.rand.Next(-400, 400);
								float y = this.position.Y - (float)Main.rand.Next(600, 900);
								Microsoft.Xna.Framework.Vector2 vector = new Microsoft.Xna.Framework.Vector2(x, y);
								float num4 = this.position.X + (float)(this.width / 2) - vector.X;
								float num5 = this.position.Y + (float)(this.height / 2) - vector.Y;
								int num6 = 22;
								float num7 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
								num7 = (float)num6 / num7;
								num4 *= num7;
								num5 *= num7;
								int num8 = this.damage;
								if (this.type == 91)
								{
									num8 = (int)((float)num8 * 0.5f);
								}
								int num9 = Projectile.NewProjectile(x, y, num4, num5, 92, num8, this.knockBack, this.owner);
								if (this.type == 91)
								{
									Main.projectile[num9].ai[1] = this.position.Y;
									Main.projectile[num9].ai[0] = 1f;
								}
								else
								{
									Main.projectile[num9].ai[1] = this.position.Y;
								}
							}
						}
						else
						{
							if (this.type == 89)
							{
								Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
								for (int num10 = 0; num10 < 5; num10++)
								{
									Microsoft.Xna.Framework.Vector2 arg_5C6_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
									int arg_5C6_1 = this.width;
									int arg_5C6_2 = this.height;
									int arg_5C6_3 = 68;
									float arg_5C6_4 = 0f;
									float arg_5C6_5 = 0f;
									int arg_5C6_6 = 0;
									Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
									int num11 = Dust.NewDust(arg_5C6_0, arg_5C6_1, arg_5C6_2, arg_5C6_3, arg_5C6_4, arg_5C6_5, arg_5C6_6, newColor, 1f);
									Main.dust[num11].noGravity = true;
									Dust expr_5E3 = Main.dust[num11];
									expr_5E3.velocity *= 1.5f;
									Main.dust[num11].scale *= 0.9f;
								}
								if (this.type == 89 && this.owner == Main.myPlayer)
								{
									for (int num12 = 0; num12 < 3; num12++)
									{
										float num13 = -this.velocity.X * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
										float num14 = -this.velocity.Y * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
										Projectile.NewProjectile(this.position.X + num13, this.position.Y + num14, num13, num14, 90, (int)((double)this.damage * 0.6), 0f, this.owner);
									}
								}
							}
							else
							{
								if (this.type == 80)
								{
									if (this.ai[0] >= 0f)
									{
										Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
										for (int num15 = 0; num15 < 10; num15++)
										{
											Microsoft.Xna.Framework.Vector2 arg_794_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
											int arg_794_1 = this.width;
											int arg_794_2 = this.height;
											int arg_794_3 = 67;
											float arg_794_4 = 0f;
											float arg_794_5 = 0f;
											int arg_794_6 = 0;
											Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
											Dust.NewDust(arg_794_0, arg_794_1, arg_794_2, arg_794_3, arg_794_4, arg_794_5, arg_794_6, newColor, 1f);
										}
									}
									int num16 = (int)this.position.X / 16;
									int num17 = (int)this.position.Y / 16;
									if (Main.tile[num16, num17] == null)
									{

									}
									if (Main.tile[num16, num17].type == 127 && Main.tile[num16, num17].active)
									{
										WorldGen.KillTile(num16, num17, false, false, false);
									}
								}
								else
								{
									if (this.type == 76 || this.type == 77 || this.type == 78)
									{
										for (int num18 = 0; num18 < 5; num18++)
										{
											Microsoft.Xna.Framework.Vector2 arg_880_0 = this.position;
											int arg_880_1 = this.width;
											int arg_880_2 = this.height;
											int arg_880_3 = 27;
											float arg_880_4 = 0f;
											float arg_880_5 = 0f;
											int arg_880_6 = 80;
											Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
											int num19 = Dust.NewDust(arg_880_0, arg_880_1, arg_880_2, arg_880_3, arg_880_4, arg_880_5, arg_880_6, newColor, 1.5f);
											Main.dust[num19].noGravity = true;
										}
									}
									else
									{
										if (this.type == 55)
										{
											for (int num20 = 0; num20 < 5; num20++)
											{
												Microsoft.Xna.Framework.Vector2 arg_8F7_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
												int arg_8F7_1 = this.width;
												int arg_8F7_2 = this.height;
												int arg_8F7_3 = 18;
												float arg_8F7_4 = 0f;
												float arg_8F7_5 = 0f;
												int arg_8F7_6 = 0;
												Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
												int num21 = Dust.NewDust(arg_8F7_0, arg_8F7_1, arg_8F7_2, arg_8F7_3, arg_8F7_4, arg_8F7_5, arg_8F7_6, newColor, 1.5f);
												Main.dust[num21].noGravity = true;
											}
										}
										else
										{
											if (this.type == 51)
											{
												Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
												for (int num22 = 0; num22 < 5; num22++)
												{
													Microsoft.Xna.Framework.Vector2 arg_98C_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
													int arg_98C_1 = this.width;
													int arg_98C_2 = this.height;
													int arg_98C_3 = 0;
													float arg_98C_4 = 0f;
													float arg_98C_5 = 0f;
													int arg_98C_6 = 0;
													Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
													Dust.NewDust(arg_98C_0, arg_98C_1, arg_98C_2, arg_98C_3, arg_98C_4, arg_98C_5, arg_98C_6, newColor, 0.7f);
												}
											}
											else
											{
												if (this.type == 2 || this.type == 82)
												{
													Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
													for (int num23 = 0; num23 < 20; num23++)
													{
														Microsoft.Xna.Framework.Vector2 arg_A1C_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
														int arg_A1C_1 = this.width;
														int arg_A1C_2 = this.height;
														int arg_A1C_3 = 6;
														float arg_A1C_4 = 0f;
														float arg_A1C_5 = 0f;
														int arg_A1C_6 = 100;
														Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
														Dust.NewDust(arg_A1C_0, arg_A1C_1, arg_A1C_2, arg_A1C_3, arg_A1C_4, arg_A1C_5, arg_A1C_6, newColor, 1f);
													}
												}
												else
												{
													if (this.type == 103)
													{
														Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
														for (int num24 = 0; num24 < 20; num24++)
														{
															Microsoft.Xna.Framework.Vector2 arg_AAB_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
															int arg_AAB_1 = this.width;
															int arg_AAB_2 = this.height;
															int arg_AAB_3 = 75;
															float arg_AAB_4 = 0f;
															float arg_AAB_5 = 0f;
															int arg_AAB_6 = 100;
															Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
															int num25 = Dust.NewDust(arg_AAB_0, arg_AAB_1, arg_AAB_2, arg_AAB_3, arg_AAB_4, arg_AAB_5, arg_AAB_6, newColor, 1f);
															if (Main.rand.Next(2) == 0)
															{
																Main.dust[num25].scale *= 2.5f;
																Main.dust[num25].noGravity = true;
																Dust expr_AEE = Main.dust[num25];
																expr_AEE.velocity *= 5f;
															}
														}
													}
													else
													{
														if (this.type == 3 || this.type == 48 || this.type == 54)
														{
															Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
															for (int num26 = 0; num26 < 10; num26++)
															{
																Microsoft.Xna.Framework.Vector2 arg_BB5_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																int arg_BB5_1 = this.width;
																int arg_BB5_2 = this.height;
																int arg_BB5_3 = 1;
																float arg_BB5_4 = this.velocity.X * 0.1f;
																float arg_BB5_5 = this.velocity.Y * 0.1f;
																int arg_BB5_6 = 0;
																Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																Dust.NewDust(arg_BB5_0, arg_BB5_1, arg_BB5_2, arg_BB5_3, arg_BB5_4, arg_BB5_5, arg_BB5_6, newColor, 0.75f);
															}
														}
														else
														{
															if (this.type == 4)
															{
																Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
																for (int num27 = 0; num27 < 10; num27++)
																{
																	Microsoft.Xna.Framework.Vector2 arg_C43_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																	int arg_C43_1 = this.width;
																	int arg_C43_2 = this.height;
																	int arg_C43_3 = 14;
																	float arg_C43_4 = 0f;
																	float arg_C43_5 = 0f;
																	int arg_C43_6 = 150;
																	Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																	Dust.NewDust(arg_C43_0, arg_C43_1, arg_C43_2, arg_C43_3, arg_C43_4, arg_C43_5, arg_C43_6, newColor, 1.1f);
																}
															}
															else
															{
																if (this.type == 5)
																{
																	Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
																	for (int num28 = 0; num28 < 60; num28++)
																	{
																		int num29 = Main.rand.Next(3);
																		if (num29 == 0)
																		{
																			num29 = 15;
																		}
																		else
																		{
																			if (num29 == 1)
																			{
																				num29 = 57;
																			}
																			else
																			{
																				num29 = 58;
																			}
																		}
																		Microsoft.Xna.Framework.Vector2 arg_CFB_0 = this.position;
																		int arg_CFB_1 = this.width;
																		int arg_CFB_2 = this.height;
																		int arg_CFB_3 = num29;
																		float arg_CFB_4 = this.velocity.X * 0.5f;
																		float arg_CFB_5 = this.velocity.Y * 0.5f;
																		int arg_CFB_6 = 150;
																		Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																		Dust.NewDust(arg_CFB_0, arg_CFB_1, arg_CFB_2, arg_CFB_3, arg_CFB_4, arg_CFB_5, arg_CFB_6, newColor, 1.5f);
																	}
																}
																else
																{
																	if (this.type == 9 || this.type == 12)
																	{
																		Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
																		for (int num30 = 0; num30 < 10; num30++)
																		{
																			Microsoft.Xna.Framework.Vector2 arg_D9B_0 = this.position;
																			int arg_D9B_1 = this.width;
																			int arg_D9B_2 = this.height;
																			int arg_D9B_3 = 58;
																			float arg_D9B_4 = this.velocity.X * 0.1f;
																			float arg_D9B_5 = this.velocity.Y * 0.1f;
																			int arg_D9B_6 = 150;
																			Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																			Dust.NewDust(arg_D9B_0, arg_D9B_1, arg_D9B_2, arg_D9B_3, arg_D9B_4, arg_D9B_5, arg_D9B_6, newColor, 1.2f);
																		}
																		for (int num31 = 0; num31 < 3; num31++)
																		{
																			Gore.NewGore(this.position, new Microsoft.Xna.Framework.Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
																		}
																		if (this.type == 12 && this.damage < 100)
																		{
																			for (int num32 = 0; num32 < 10; num32++)
																			{
																				Microsoft.Xna.Framework.Vector2 arg_E6C_0 = this.position;
																				int arg_E6C_1 = this.width;
																				int arg_E6C_2 = this.height;
																				int arg_E6C_3 = 57;
																				float arg_E6C_4 = this.velocity.X * 0.1f;
																				float arg_E6C_5 = this.velocity.Y * 0.1f;
																				int arg_E6C_6 = 150;
																				Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																				Dust.NewDust(arg_E6C_0, arg_E6C_1, arg_E6C_2, arg_E6C_3, arg_E6C_4, arg_E6C_5, arg_E6C_6, newColor, 1.2f);
																			}
																			for (int num33 = 0; num33 < 3; num33++)
																			{
																				Gore.NewGore(this.position, new Microsoft.Xna.Framework.Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
																			}
																		}
																	}
																	else
																	{
																		if (this.type == 14 || this.type == 20 || this.type == 36 || this.type == 83 || this.type == 84 || this.type == 100)
																		{
																			Collision.HitTiles(this.position, this.velocity, this.width, this.height);
																			Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
																		}
																		else
																		{
																			if (this.type == 15 || this.type == 34)
																			{
																				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
																				for (int num34 = 0; num34 < 20; num34++)
																				{
																					Microsoft.Xna.Framework.Vector2 arg_FF3_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																					int arg_FF3_1 = this.width;
																					int arg_FF3_2 = this.height;
																					int arg_FF3_3 = 6;
																					float arg_FF3_4 = -this.velocity.X * 0.2f;
																					float arg_FF3_5 = -this.velocity.Y * 0.2f;
																					int arg_FF3_6 = 100;
																					Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																					int num35 = Dust.NewDust(arg_FF3_0, arg_FF3_1, arg_FF3_2, arg_FF3_3, arg_FF3_4, arg_FF3_5, arg_FF3_6, newColor, 2f);
																					Main.dust[num35].noGravity = true;
																					Dust expr_1010 = Main.dust[num35];
																					expr_1010.velocity *= 2f;
																					Microsoft.Xna.Framework.Vector2 arg_1082_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																					int arg_1082_1 = this.width;
																					int arg_1082_2 = this.height;
																					int arg_1082_3 = 6;
																					float arg_1082_4 = -this.velocity.X * 0.2f;
																					float arg_1082_5 = -this.velocity.Y * 0.2f;
																					int arg_1082_6 = 100;
																					newColor = default(Microsoft.Xna.Framework.Color);
																					num35 = Dust.NewDust(arg_1082_0, arg_1082_1, arg_1082_2, arg_1082_3, arg_1082_4, arg_1082_5, arg_1082_6, newColor, 1f);
																					Dust expr_1091 = Main.dust[num35];
																					expr_1091.velocity *= 2f;
																				}
																			}
																			else
																			{
																				if (this.type == 95 || this.type == 96)
																				{
																					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
																					for (int num36 = 0; num36 < 20; num36++)
																					{
																						Microsoft.Xna.Framework.Vector2 arg_115E_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																						int arg_115E_1 = this.width;
																						int arg_115E_2 = this.height;
																						int arg_115E_3 = 75;
																						float arg_115E_4 = -this.velocity.X * 0.2f;
																						float arg_115E_5 = -this.velocity.Y * 0.2f;
																						int arg_115E_6 = 100;
																						Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																						int num37 = Dust.NewDust(arg_115E_0, arg_115E_1, arg_115E_2, arg_115E_3, arg_115E_4, arg_115E_5, arg_115E_6, newColor, 2f * this.scale);
																						Main.dust[num37].noGravity = true;
																						Dust expr_117B = Main.dust[num37];
																						expr_117B.velocity *= 2f;
																						Microsoft.Xna.Framework.Vector2 arg_11F5_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																						int arg_11F5_1 = this.width;
																						int arg_11F5_2 = this.height;
																						int arg_11F5_3 = 75;
																						float arg_11F5_4 = -this.velocity.X * 0.2f;
																						float arg_11F5_5 = -this.velocity.Y * 0.2f;
																						int arg_11F5_6 = 100;
																						newColor = default(Microsoft.Xna.Framework.Color);
																						num37 = Dust.NewDust(arg_11F5_0, arg_11F5_1, arg_11F5_2, arg_11F5_3, arg_11F5_4, arg_11F5_5, arg_11F5_6, newColor, 1f * this.scale);
																						Dust expr_1204 = Main.dust[num37];
																						expr_1204.velocity *= 2f;
																					}
																				}
																				else
																				{
																					if (this.type == 79)
																					{
																						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
																						for (int num38 = 0; num38 < 20; num38++)
																						{
																							int num39 = Dust.NewDust(new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y), this.width, this.height, 66, 0f, 0f, 100, new Microsoft.Xna.Framework.Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 2f);
																							Main.dust[num39].noGravity = true;
																							Dust expr_12CD = Main.dust[num39];
																							expr_12CD.velocity *= 4f;
																						}
																					}
																					else
																					{
																						if (this.type == 16)
																						{
																							Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
																							for (int num40 = 0; num40 < 20; num40++)
																							{
																								Microsoft.Xna.Framework.Vector2 arg_1387_0 = new Microsoft.Xna.Framework.Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y);
																								int arg_1387_1 = this.width;
																								int arg_1387_2 = this.height;
																								int arg_1387_3 = 15;
																								float arg_1387_4 = 0f;
																								float arg_1387_5 = 0f;
																								int arg_1387_6 = 100;
																								Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																								int num41 = Dust.NewDust(arg_1387_0, arg_1387_1, arg_1387_2, arg_1387_3, arg_1387_4, arg_1387_5, arg_1387_6, newColor, 2f);
																								Main.dust[num41].noGravity = true;
																								Dust expr_13A4 = Main.dust[num41];
																								expr_13A4.velocity *= 2f;
																								Microsoft.Xna.Framework.Vector2 arg_1415_0 = new Microsoft.Xna.Framework.Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y);
																								int arg_1415_1 = this.width;
																								int arg_1415_2 = this.height;
																								int arg_1415_3 = 15;
																								float arg_1415_4 = 0f;
																								float arg_1415_5 = 0f;
																								int arg_1415_6 = 100;
																								newColor = default(Microsoft.Xna.Framework.Color);
																								num41 = Dust.NewDust(arg_1415_0, arg_1415_1, arg_1415_2, arg_1415_3, arg_1415_4, arg_1415_5, arg_1415_6, newColor, 1f);
																							}
																						}
																						else
																						{
																							if (this.type == 17)
																							{
																								Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
																								for (int num42 = 0; num42 < 5; num42++)
																								{
																									Microsoft.Xna.Framework.Vector2 arg_14A0_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																									int arg_14A0_1 = this.width;
																									int arg_14A0_2 = this.height;
																									int arg_14A0_3 = 0;
																									float arg_14A0_4 = 0f;
																									float arg_14A0_5 = 0f;
																									int arg_14A0_6 = 0;
																									Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																									Dust.NewDust(arg_14A0_0, arg_14A0_1, arg_14A0_2, arg_14A0_3, arg_14A0_4, arg_14A0_5, arg_14A0_6, newColor, 1f);
																								}
																							}
																							else
																							{
																								if (this.type == 31 || this.type == 42)
																								{
																									Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
																									for (int num43 = 0; num43 < 5; num43++)
																									{
																										Microsoft.Xna.Framework.Vector2 arg_1534_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																										int arg_1534_1 = this.width;
																										int arg_1534_2 = this.height;
																										int arg_1534_3 = 32;
																										float arg_1534_4 = 0f;
																										float arg_1534_5 = 0f;
																										int arg_1534_6 = 0;
																										Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																										int num44 = Dust.NewDust(arg_1534_0, arg_1534_1, arg_1534_2, arg_1534_3, arg_1534_4, arg_1534_5, arg_1534_6, newColor, 1f);
																										Dust expr_1543 = Main.dust[num44];
																										expr_1543.velocity *= 0.6f;
																									}
																								}
																								else
																								{
																									if (this.type == 39)
																									{
																										Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
																										for (int num45 = 0; num45 < 5; num45++)
																										{
																											Microsoft.Xna.Framework.Vector2 arg_15DC_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																											int arg_15DC_1 = this.width;
																											int arg_15DC_2 = this.height;
																											int arg_15DC_3 = 38;
																											float arg_15DC_4 = 0f;
																											float arg_15DC_5 = 0f;
																											int arg_15DC_6 = 0;
																											Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																											int num46 = Dust.NewDust(arg_15DC_0, arg_15DC_1, arg_15DC_2, arg_15DC_3, arg_15DC_4, arg_15DC_5, arg_15DC_6, newColor, 1f);
																											Dust expr_15EB = Main.dust[num46];
																											expr_15EB.velocity *= 0.6f;
																										}
																									}
																									else
																									{
																										if (this.type == 71)
																										{
																											Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
																											for (int num47 = 0; num47 < 5; num47++)
																											{
																												Microsoft.Xna.Framework.Vector2 arg_1684_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																												int arg_1684_1 = this.width;
																												int arg_1684_2 = this.height;
																												int arg_1684_3 = 53;
																												float arg_1684_4 = 0f;
																												float arg_1684_5 = 0f;
																												int arg_1684_6 = 0;
																												Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																												int num48 = Dust.NewDust(arg_1684_0, arg_1684_1, arg_1684_2, arg_1684_3, arg_1684_4, arg_1684_5, arg_1684_6, newColor, 1f);
																												Dust expr_1693 = Main.dust[num48];
																												expr_1693.velocity *= 0.6f;
																											}
																										}
																										else
																										{
																											if (this.type == 40)
																											{
																												Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
																												for (int num49 = 0; num49 < 5; num49++)
																												{
																													Microsoft.Xna.Framework.Vector2 arg_172C_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																													int arg_172C_1 = this.width;
																													int arg_172C_2 = this.height;
																													int arg_172C_3 = 36;
																													float arg_172C_4 = 0f;
																													float arg_172C_5 = 0f;
																													int arg_172C_6 = 0;
																													Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																													int num50 = Dust.NewDust(arg_172C_0, arg_172C_1, arg_172C_2, arg_172C_3, arg_172C_4, arg_172C_5, arg_172C_6, newColor, 1f);
																													Dust expr_173B = Main.dust[num50];
																													expr_173B.velocity *= 0.6f;
																												}
																											}
																											else
																											{
																												if (this.type == 21)
																												{
																													Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
																													for (int num51 = 0; num51 < 10; num51++)
																													{
																														Microsoft.Xna.Framework.Vector2 arg_17D1_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																														int arg_17D1_1 = this.width;
																														int arg_17D1_2 = this.height;
																														int arg_17D1_3 = 26;
																														float arg_17D1_4 = 0f;
																														float arg_17D1_5 = 0f;
																														int arg_17D1_6 = 0;
																														Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																														Dust.NewDust(arg_17D1_0, arg_17D1_1, arg_17D1_2, arg_17D1_3, arg_17D1_4, arg_17D1_5, arg_17D1_6, newColor, 0.8f);
																													}
																												}
																												else
																												{
																													if (this.type == 24)
																													{
																														for (int num52 = 0; num52 < 10; num52++)
																														{
																															Microsoft.Xna.Framework.Vector2 arg_1851_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																															int arg_1851_1 = this.width;
																															int arg_1851_2 = this.height;
																															int arg_1851_3 = 1;
																															float arg_1851_4 = this.velocity.X * 0.1f;
																															float arg_1851_5 = this.velocity.Y * 0.1f;
																															int arg_1851_6 = 0;
																															Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																															Dust.NewDust(arg_1851_0, arg_1851_1, arg_1851_2, arg_1851_3, arg_1851_4, arg_1851_5, arg_1851_6, newColor, 0.75f);
																														}
																													}
																													else
																													{
																														if (this.type == 27)
																														{
																															Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
																															for (int num53 = 0; num53 < 30; num53++)
																															{
																																Microsoft.Xna.Framework.Vector2 arg_18F9_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																int arg_18F9_1 = this.width;
																																int arg_18F9_2 = this.height;
																																int arg_18F9_3 = 29;
																																float arg_18F9_4 = this.velocity.X * 0.1f;
																																float arg_18F9_5 = this.velocity.Y * 0.1f;
																																int arg_18F9_6 = 100;
																																Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																																int num54 = Dust.NewDust(arg_18F9_0, arg_18F9_1, arg_18F9_2, arg_18F9_3, arg_18F9_4, arg_18F9_5, arg_18F9_6, newColor, 3f);
																																Main.dust[num54].noGravity = true;
																																Microsoft.Xna.Framework.Vector2 arg_196A_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																int arg_196A_1 = this.width;
																																int arg_196A_2 = this.height;
																																int arg_196A_3 = 29;
																																float arg_196A_4 = this.velocity.X * 0.1f;
																																float arg_196A_5 = this.velocity.Y * 0.1f;
																																int arg_196A_6 = 100;
																																newColor = default(Microsoft.Xna.Framework.Color);
																																Dust.NewDust(arg_196A_0, arg_196A_1, arg_196A_2, arg_196A_3, arg_196A_4, arg_196A_5, arg_196A_6, newColor, 2f);
																															}
																														}
																														else
																														{
																															if (this.type == 38)
																															{
																																for (int num55 = 0; num55 < 10; num55++)
																																{
																																	Microsoft.Xna.Framework.Vector2 arg_19EE_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																	int arg_19EE_1 = this.width;
																																	int arg_19EE_2 = this.height;
																																	int arg_19EE_3 = 42;
																																	float arg_19EE_4 = this.velocity.X * 0.1f;
																																	float arg_19EE_5 = this.velocity.Y * 0.1f;
																																	int arg_19EE_6 = 0;
																																	Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																																	Dust.NewDust(arg_19EE_0, arg_19EE_1, arg_19EE_2, arg_19EE_3, arg_19EE_4, arg_19EE_5, arg_19EE_6, newColor, 1f);
																																}
																															}
																															else
																															{
																																if (this.type == 44 || this.type == 45)
																																{
																																	Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
																																	for (int num56 = 0; num56 < 30; num56++)
																																	{
																																		Microsoft.Xna.Framework.Vector2 arg_1A94_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																		int arg_1A94_1 = this.width;
																																		int arg_1A94_2 = this.height;
																																		int arg_1A94_3 = 27;
																																		float arg_1A94_4 = this.velocity.X;
																																		float arg_1A94_5 = this.velocity.Y;
																																		int arg_1A94_6 = 100;
																																		Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																																		int num57 = Dust.NewDust(arg_1A94_0, arg_1A94_1, arg_1A94_2, arg_1A94_3, arg_1A94_4, arg_1A94_5, arg_1A94_6, newColor, 1.7f);
																																		Main.dust[num57].noGravity = true;
																																		Microsoft.Xna.Framework.Vector2 arg_1AF9_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																		int arg_1AF9_1 = this.width;
																																		int arg_1AF9_2 = this.height;
																																		int arg_1AF9_3 = 27;
																																		float arg_1AF9_4 = this.velocity.X;
																																		float arg_1AF9_5 = this.velocity.Y;
																																		int arg_1AF9_6 = 100;
																																		newColor = default(Microsoft.Xna.Framework.Color);
																																		Dust.NewDust(arg_1AF9_0, arg_1AF9_1, arg_1AF9_2, arg_1AF9_3, arg_1AF9_4, arg_1AF9_5, arg_1AF9_6, newColor, 1f);
																																	}
																																}
																																else
																																{
																																	if (this.type == 41)
																																	{
																																		Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
																																		for (int num58 = 0; num58 < 10; num58++)
																																		{
																																			Microsoft.Xna.Framework.Vector2 arg_1B89_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																			int arg_1B89_1 = this.width;
																																			int arg_1B89_2 = this.height;
																																			int arg_1B89_3 = 31;
																																			float arg_1B89_4 = 0f;
																																			float arg_1B89_5 = 0f;
																																			int arg_1B89_6 = 100;
																																			Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																																			Dust.NewDust(arg_1B89_0, arg_1B89_1, arg_1B89_2, arg_1B89_3, arg_1B89_4, arg_1B89_5, arg_1B89_6, newColor, 1.5f);
																																		}
																																		for (int num59 = 0; num59 < 5; num59++)
																																		{
																																			Microsoft.Xna.Framework.Vector2 arg_1BE6_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																			int arg_1BE6_1 = this.width;
																																			int arg_1BE6_2 = this.height;
																																			int arg_1BE6_3 = 6;
																																			float arg_1BE6_4 = 0f;
																																			float arg_1BE6_5 = 0f;
																																			int arg_1BE6_6 = 100;
																																			Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																																			int num60 = Dust.NewDust(arg_1BE6_0, arg_1BE6_1, arg_1BE6_2, arg_1BE6_3, arg_1BE6_4, arg_1BE6_5, arg_1BE6_6, newColor, 2.5f);
																																			Main.dust[num60].noGravity = true;
																																			Dust expr_1C03 = Main.dust[num60];
																																			expr_1C03.velocity *= 3f;
																																			Microsoft.Xna.Framework.Vector2 arg_1C5B_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																			int arg_1C5B_1 = this.width;
																																			int arg_1C5B_2 = this.height;
																																			int arg_1C5B_3 = 6;
																																			float arg_1C5B_4 = 0f;
																																			float arg_1C5B_5 = 0f;
																																			int arg_1C5B_6 = 100;
																																			newColor = default(Microsoft.Xna.Framework.Color);
																																			num60 = Dust.NewDust(arg_1C5B_0, arg_1C5B_1, arg_1C5B_2, arg_1C5B_3, arg_1C5B_4, arg_1C5B_5, arg_1C5B_6, newColor, 1.5f);
																																			Dust expr_1C6A = Main.dust[num60];
																																			expr_1C6A.velocity *= 2f;
																																		}
																																		Microsoft.Xna.Framework.Vector2 arg_1CC5_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																		Microsoft.Xna.Framework.Vector2 vector2 = default(Microsoft.Xna.Framework.Vector2);
																																		int num61 = Gore.NewGore(arg_1CC5_0, vector2, Main.rand.Next(61, 64), 1f);
																																		Gore expr_1CD4 = Main.gore[num61];
																																		expr_1CD4.velocity *= 0.4f;
																																		Gore expr_1CF6_cp_0 = Main.gore[num61];
																																		expr_1CF6_cp_0.velocity.X = expr_1CF6_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.1f;
																																		Gore expr_1D24_cp_0 = Main.gore[num61];
																																		expr_1D24_cp_0.velocity.Y = expr_1D24_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.1f;
																																		Microsoft.Xna.Framework.Vector2 arg_1D7D_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																		vector2 = default(Microsoft.Xna.Framework.Vector2);
																																		num61 = Gore.NewGore(arg_1D7D_0, vector2, Main.rand.Next(61, 64), 1f);
																																		Gore expr_1D8C = Main.gore[num61];
																																		expr_1D8C.velocity *= 0.4f;
																																		Gore expr_1DAE_cp_0 = Main.gore[num61];
																																		expr_1DAE_cp_0.velocity.X = expr_1DAE_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.1f;
																																		Gore expr_1DDC_cp_0 = Main.gore[num61];
																																		expr_1DDC_cp_0.velocity.Y = expr_1DDC_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.1f;
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
																																	else
																																	{
																																		if (this.type == 28 || this.type == 30 || this.type == 37 || this.type == 75 || this.type == 102)
																																		{
																																			Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
																																			this.position.X = this.position.X + (float)(this.width / 2);
																																			this.position.Y = this.position.Y + (float)(this.height / 2);
																																			this.width = 22;
																																			this.height = 22;
																																			this.position.X = this.position.X - (float)(this.width / 2);
																																			this.position.Y = this.position.Y - (float)(this.height / 2);
																																			for (int num62 = 0; num62 < 20; num62++)
																																			{
																																				Microsoft.Xna.Framework.Vector2 arg_1FB5_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																				int arg_1FB5_1 = this.width;
																																				int arg_1FB5_2 = this.height;
																																				int arg_1FB5_3 = 31;
																																				float arg_1FB5_4 = 0f;
																																				float arg_1FB5_5 = 0f;
																																				int arg_1FB5_6 = 100;
																																				Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																																				int num63 = Dust.NewDust(arg_1FB5_0, arg_1FB5_1, arg_1FB5_2, arg_1FB5_3, arg_1FB5_4, arg_1FB5_5, arg_1FB5_6, newColor, 1.5f);
																																				Dust expr_1FC4 = Main.dust[num63];
																																				expr_1FC4.velocity *= 1.4f;
																																			}
																																			for (int num64 = 0; num64 < 10; num64++)
																																			{
																																				Microsoft.Xna.Framework.Vector2 arg_2030_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																				int arg_2030_1 = this.width;
																																				int arg_2030_2 = this.height;
																																				int arg_2030_3 = 6;
																																				float arg_2030_4 = 0f;
																																				float arg_2030_5 = 0f;
																																				int arg_2030_6 = 100;
																																				Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																																				int num65 = Dust.NewDust(arg_2030_0, arg_2030_1, arg_2030_2, arg_2030_3, arg_2030_4, arg_2030_5, arg_2030_6, newColor, 2.5f);
																																				Main.dust[num65].noGravity = true;
																																				Dust expr_204D = Main.dust[num65];
																																				expr_204D.velocity *= 5f;
																																				Microsoft.Xna.Framework.Vector2 arg_20A5_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																				int arg_20A5_1 = this.width;
																																				int arg_20A5_2 = this.height;
																																				int arg_20A5_3 = 6;
																																				float arg_20A5_4 = 0f;
																																				float arg_20A5_5 = 0f;
																																				int arg_20A5_6 = 100;
																																				newColor = default(Microsoft.Xna.Framework.Color);
																																				num65 = Dust.NewDust(arg_20A5_0, arg_20A5_1, arg_20A5_2, arg_20A5_3, arg_20A5_4, arg_20A5_5, arg_20A5_6, newColor, 1.5f);
																																				Dust expr_20B4 = Main.dust[num65];
																																				expr_20B4.velocity *= 3f;
																																			}
																																			Microsoft.Xna.Framework.Vector2 arg_2110_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																			Microsoft.Xna.Framework.Vector2 vector2 = default(Microsoft.Xna.Framework.Vector2);
																																			int num66 = Gore.NewGore(arg_2110_0, vector2, Main.rand.Next(61, 64), 1f);
																																			Gore expr_211F = Main.gore[num66];
																																			expr_211F.velocity *= 0.4f;
																																			Gore expr_2141_cp_0 = Main.gore[num66];
																																			expr_2141_cp_0.velocity.X = expr_2141_cp_0.velocity.X + 1f;
																																			Gore expr_215F_cp_0 = Main.gore[num66];
																																			expr_215F_cp_0.velocity.Y = expr_215F_cp_0.velocity.Y + 1f;
																																			Microsoft.Xna.Framework.Vector2 arg_21A8_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																			vector2 = default(Microsoft.Xna.Framework.Vector2);
																																			num66 = Gore.NewGore(arg_21A8_0, vector2, Main.rand.Next(61, 64), 1f);
																																			Gore expr_21B7 = Main.gore[num66];
																																			expr_21B7.velocity *= 0.4f;
																																			Gore expr_21D9_cp_0 = Main.gore[num66];
																																			expr_21D9_cp_0.velocity.X = expr_21D9_cp_0.velocity.X - 1f;
																																			Gore expr_21F7_cp_0 = Main.gore[num66];
																																			expr_21F7_cp_0.velocity.Y = expr_21F7_cp_0.velocity.Y + 1f;
																																			Microsoft.Xna.Framework.Vector2 arg_2240_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																			vector2 = default(Microsoft.Xna.Framework.Vector2);
																																			num66 = Gore.NewGore(arg_2240_0, vector2, Main.rand.Next(61, 64), 1f);
																																			Gore expr_224F = Main.gore[num66];
																																			expr_224F.velocity *= 0.4f;
																																			Gore expr_2271_cp_0 = Main.gore[num66];
																																			expr_2271_cp_0.velocity.X = expr_2271_cp_0.velocity.X + 1f;
																																			Gore expr_228F_cp_0 = Main.gore[num66];
																																			expr_228F_cp_0.velocity.Y = expr_228F_cp_0.velocity.Y - 1f;
																																			Microsoft.Xna.Framework.Vector2 arg_22D8_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																			vector2 = default(Microsoft.Xna.Framework.Vector2);
																																			num66 = Gore.NewGore(arg_22D8_0, vector2, Main.rand.Next(61, 64), 1f);
																																			Gore expr_22E7 = Main.gore[num66];
																																			expr_22E7.velocity *= 0.4f;
																																			Gore expr_2309_cp_0 = Main.gore[num66];
																																			expr_2309_cp_0.velocity.X = expr_2309_cp_0.velocity.X - 1f;
																																			Gore expr_2327_cp_0 = Main.gore[num66];
																																			expr_2327_cp_0.velocity.Y = expr_2327_cp_0.velocity.Y - 1f;
																																		}
																																		else
																																		{
																																			if (this.type == 29 || this.type == 108)
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
																																				for (int num67 = 0; num67 < 50; num67++)
																																				{
																																					Microsoft.Xna.Framework.Vector2 arg_244C_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																					int arg_244C_1 = this.width;
																																					int arg_244C_2 = this.height;
																																					int arg_244C_3 = 31;
																																					float arg_244C_4 = 0f;
																																					float arg_244C_5 = 0f;
																																					int arg_244C_6 = 100;
																																					Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																																					int num68 = Dust.NewDust(arg_244C_0, arg_244C_1, arg_244C_2, arg_244C_3, arg_244C_4, arg_244C_5, arg_244C_6, newColor, 2f);
																																					Dust expr_245B = Main.dust[num68];
																																					expr_245B.velocity *= 1.4f;
																																				}
																																				for (int num69 = 0; num69 < 80; num69++)
																																				{
																																					Microsoft.Xna.Framework.Vector2 arg_24C7_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																					int arg_24C7_1 = this.width;
																																					int arg_24C7_2 = this.height;
																																					int arg_24C7_3 = 6;
																																					float arg_24C7_4 = 0f;
																																					float arg_24C7_5 = 0f;
																																					int arg_24C7_6 = 100;
																																					Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																																					int num70 = Dust.NewDust(arg_24C7_0, arg_24C7_1, arg_24C7_2, arg_24C7_3, arg_24C7_4, arg_24C7_5, arg_24C7_6, newColor, 3f);
																																					Main.dust[num70].noGravity = true;
																																					Dust expr_24E4 = Main.dust[num70];
																																					expr_24E4.velocity *= 5f;
																																					Microsoft.Xna.Framework.Vector2 arg_253C_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																					int arg_253C_1 = this.width;
																																					int arg_253C_2 = this.height;
																																					int arg_253C_3 = 6;
																																					float arg_253C_4 = 0f;
																																					float arg_253C_5 = 0f;
																																					int arg_253C_6 = 100;
																																					newColor = default(Microsoft.Xna.Framework.Color);
																																					num70 = Dust.NewDust(arg_253C_0, arg_253C_1, arg_253C_2, arg_253C_3, arg_253C_4, arg_253C_5, arg_253C_6, newColor, 2f);
																																					Dust expr_254B = Main.dust[num70];
																																					expr_254B.velocity *= 3f;
																																				}
																																				for (int num71 = 0; num71 < 2; num71++)
																																				{
																																					Microsoft.Xna.Framework.Vector2 arg_25CF_0 = new Microsoft.Xna.Framework.Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f);
																																					Microsoft.Xna.Framework.Vector2 vector2 = default(Microsoft.Xna.Framework.Vector2);
																																					int num72 = Gore.NewGore(arg_25CF_0, vector2, Main.rand.Next(61, 64), 1f);
																																					Main.gore[num72].scale = 1.5f;
																																					Gore expr_25F5_cp_0 = Main.gore[num72];
																																					expr_25F5_cp_0.velocity.X = expr_25F5_cp_0.velocity.X + 1.5f;
																																					Gore expr_2613_cp_0 = Main.gore[num72];
																																					expr_2613_cp_0.velocity.Y = expr_2613_cp_0.velocity.Y + 1.5f;
																																					Microsoft.Xna.Framework.Vector2 arg_267C_0 = new Microsoft.Xna.Framework.Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f);
																																					vector2 = default(Microsoft.Xna.Framework.Vector2);
																																					num72 = Gore.NewGore(arg_267C_0, vector2, Main.rand.Next(61, 64), 1f);
																																					Main.gore[num72].scale = 1.5f;
																																					Gore expr_26A2_cp_0 = Main.gore[num72];
																																					expr_26A2_cp_0.velocity.X = expr_26A2_cp_0.velocity.X - 1.5f;
																																					Gore expr_26C0_cp_0 = Main.gore[num72];
																																					expr_26C0_cp_0.velocity.Y = expr_26C0_cp_0.velocity.Y + 1.5f;
																																					Microsoft.Xna.Framework.Vector2 arg_2729_0 = new Microsoft.Xna.Framework.Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f);
																																					vector2 = default(Microsoft.Xna.Framework.Vector2);
																																					num72 = Gore.NewGore(arg_2729_0, vector2, Main.rand.Next(61, 64), 1f);
																																					Main.gore[num72].scale = 1.5f;
																																					Gore expr_274F_cp_0 = Main.gore[num72];
																																					expr_274F_cp_0.velocity.X = expr_274F_cp_0.velocity.X + 1.5f;
																																					Gore expr_276D_cp_0 = Main.gore[num72];
																																					expr_276D_cp_0.velocity.Y = expr_276D_cp_0.velocity.Y - 1.5f;
																																					Microsoft.Xna.Framework.Vector2 arg_27D6_0 = new Microsoft.Xna.Framework.Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f);
																																					vector2 = default(Microsoft.Xna.Framework.Vector2);
																																					num72 = Gore.NewGore(arg_27D6_0, vector2, Main.rand.Next(61, 64), 1f);
																																					Main.gore[num72].scale = 1.5f;
																																					Gore expr_27FC_cp_0 = Main.gore[num72];
																																					expr_27FC_cp_0.velocity.X = expr_27FC_cp_0.velocity.X - 1.5f;
																																					Gore expr_281A_cp_0 = Main.gore[num72];
																																					expr_281A_cp_0.velocity.Y = expr_281A_cp_0.velocity.Y - 1.5f;
																																				}
																																				this.position.X = this.position.X + (float)(this.width / 2);
																																				this.position.Y = this.position.Y + (float)(this.height / 2);
																																				this.width = 10;
																																				this.height = 10;
																																				this.position.X = this.position.X - (float)(this.width / 2);
																																				this.position.Y = this.position.Y - (float)(this.height / 2);
																																			}
																																			else
																																			{
																																				if (this.type == 69)
																																				{
																																					Main.PlaySound(13, (int)this.position.X, (int)this.position.Y, 1);
																																					for (int num73 = 0; num73 < 5; num73++)
																																					{
																																						Microsoft.Xna.Framework.Vector2 arg_292F_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																						int arg_292F_1 = this.width;
																																						int arg_292F_2 = this.height;
																																						int arg_292F_3 = 13;
																																						float arg_292F_4 = 0f;
																																						float arg_292F_5 = 0f;
																																						int arg_292F_6 = 0;
																																						Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																																						Dust.NewDust(arg_292F_0, arg_292F_1, arg_292F_2, arg_292F_3, arg_292F_4, arg_292F_5, arg_292F_6, newColor, 1f);
																																					}
																																					for (int num74 = 0; num74 < 30; num74++)
																																					{
																																						Microsoft.Xna.Framework.Vector2 arg_298B_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																						int arg_298B_1 = this.width;
																																						int arg_298B_2 = this.height;
																																						int arg_298B_3 = 33;
																																						float arg_298B_4 = 0f;
																																						float arg_298B_5 = -2f;
																																						int arg_298B_6 = 0;
																																						Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																																						int num75 = Dust.NewDust(arg_298B_0, arg_298B_1, arg_298B_2, arg_298B_3, arg_298B_4, arg_298B_5, arg_298B_6, newColor, 1.1f);
																																						Main.dust[num75].alpha = 100;
																																						Dust expr_29AE_cp_0 = Main.dust[num75];
																																						expr_29AE_cp_0.velocity.X = expr_29AE_cp_0.velocity.X * 1.5f;
																																						Dust expr_29C7 = Main.dust[num75];
																																						expr_29C7.velocity *= 3f;
																																					}
																																				}
																																				else
																																				{
																																					if (this.type == 70)
																																					{
																																						Main.PlaySound(13, (int)this.position.X, (int)this.position.Y, 1);
																																						for (int num76 = 0; num76 < 5; num76++)
																																						{
																																							Microsoft.Xna.Framework.Vector2 arg_2A65_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																							int arg_2A65_1 = this.width;
																																							int arg_2A65_2 = this.height;
																																							int arg_2A65_3 = 13;
																																							float arg_2A65_4 = 0f;
																																							float arg_2A65_5 = 0f;
																																							int arg_2A65_6 = 0;
																																							Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																																							Dust.NewDust(arg_2A65_0, arg_2A65_1, arg_2A65_2, arg_2A65_3, arg_2A65_4, arg_2A65_5, arg_2A65_6, newColor, 1f);
																																						}
																																						for (int num77 = 0; num77 < 30; num77++)
																																						{
																																							Microsoft.Xna.Framework.Vector2 arg_2AC1_0 = new Microsoft.Xna.Framework.Vector2(this.position.X, this.position.Y);
																																							int arg_2AC1_1 = this.width;
																																							int arg_2AC1_2 = this.height;
																																							int arg_2AC1_3 = 52;
																																							float arg_2AC1_4 = 0f;
																																							float arg_2AC1_5 = -2f;
																																							int arg_2AC1_6 = 0;
																																							Microsoft.Xna.Framework.Color newColor = default(Microsoft.Xna.Framework.Color);
																																							int num78 = Dust.NewDust(arg_2AC1_0, arg_2AC1_1, arg_2AC1_2, arg_2AC1_3, arg_2AC1_4, arg_2AC1_5, arg_2AC1_6, newColor, 1.1f);
																																							Main.dust[num78].alpha = 100;
																																							Dust expr_2AE4_cp_0 = Main.dust[num78];
																																							expr_2AE4_cp_0.velocity.X = expr_2AE4_cp_0.velocity.X * 1.5f;
																																							Dust expr_2AFD = Main.dust[num78];
																																							expr_2AFD.velocity *= 3f;
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
			if (this.owner == Main.myPlayer)
			{
				if (this.type == 28 || this.type == 29 || this.type == 37 || this.type == 75 || this.type == 108)
				{
					int num79 = 3;
					if (this.type == 29)
					{
						num79 = 7;
					}
					if (this.type == 108)
					{
						num79 = 10;
					}
					int num80 = (int)(this.position.X / 16f - (float)num79);
					int num81 = (int)(this.position.X / 16f + (float)num79);
					int num82 = (int)(this.position.Y / 16f - (float)num79);
					int num83 = (int)(this.position.Y / 16f + (float)num79);
					if (num80 < 0)
					{
						num80 = 0;
					}
					if (num81 > Main.maxTilesX)
					{
						num81 = Main.maxTilesX;
					}
					if (num82 < 0)
					{
						num82 = 0;
					}
					if (num83 > Main.maxTilesY)
					{
						num83 = Main.maxTilesY;
					}
					bool flag = false;
					for (int num84 = num80; num84 <= num81; num84++)
					{
						for (int num85 = num82; num85 <= num83; num85++)
						{
							float num86 = Math.Abs((float)num84 - this.position.X / 16f);
							float num87 = Math.Abs((float)num85 - this.position.Y / 16f);
							double num88 = Math.Sqrt((double)(num86 * num86 + num87 * num87));
							if (num88 < (double)num79 && Main.tile[num84, num85] != null && Main.tile[num84, num85].wall == 0)
							{
								flag = true;
								break;
							}
						}
					}
					for (int num89 = num80; num89 <= num81; num89++)
					{
						for (int num90 = num82; num90 <= num83; num90++)
						{
							float num91 = Math.Abs((float)num89 - this.position.X / 16f);
							float num92 = Math.Abs((float)num90 - this.position.Y / 16f);
							double num93 = Math.Sqrt((double)(num91 * num91 + num92 * num92));
							if (num93 < (double)num79)
							{
								bool flag2 = true;
								if (Main.tile[num89, num90] != null && Main.tile[num89, num90].active)
								{
									flag2 = true;
									if (Main.tileDungeon[(int)Main.tile[num89, num90].type] || Main.tile[num89, num90].type == 21 || Main.tile[num89, num90].type == 26 || Main.tile[num89, num90].type == 107 || Main.tile[num89, num90].type == 108 || Main.tile[num89, num90].type == 111)
									{
										flag2 = false;
									}
									if (!Main.hardMode && Main.tile[num89, num90].type == 58)
									{
										flag2 = false;
									}
									if (flag2)
									{
										WorldGen.KillTile(num89, num90, false, false, false);
										if (!Main.tile[num89, num90].active && Main.netMode != 0)
										{
											NetMessage.SendData(17, -1, -1, "", 0, (float)num89, (float)num90, 0f, 0);
										}
									}
								}
								if (flag2)
								{
									for (int num94 = num89 - 1; num94 <= num89 + 1; num94++)
									{
										for (int num95 = num90 - 1; num95 <= num90 + 1; num95++)
										{
											if (Main.tile[num94, num95] != null && Main.tile[num94, num95].wall > 0 && flag)
											{
												WorldGen.KillWall(num94, num95, false);
												if (Main.tile[num94, num95].wall == 0 && Main.netMode == 1)
												{
													NetMessage.SendData(17, -1, -1, "", 2, (float)num94, (float)num95, 0f, 0);
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
				int num96 = -1;
				if (this.aiStyle == 10)
				{
					int num97 = (int)(this.position.X + (float)(this.width / 2)) / 16;
					int num98 = (int)(this.position.Y + (float)(this.width / 2)) / 16;
					int num99 = 0;
					int num100 = 2;
					if (this.type == 31)
					{
						num99 = 53;
						num100 = 0;
					}
					if (this.type == 42)
					{
						num99 = 53;
						num100 = 0;
					}
					if (this.type == 56)
					{
						num99 = 112;
						num100 = 0;
					}
					if (this.type == 65)
					{
						num99 = 112;
						num100 = 0;
					}
					if (this.type == 67)
					{
						num99 = 116;
						num100 = 0;
					}
					if (this.type == 68)
					{
						num99 = 116;
						num100 = 0;
					}
					if (this.type == 71)
					{
						num99 = 123;
						num100 = 0;
					}
					if (this.type == 39)
					{
						num99 = 59;
						num100 = 176;
					}
					if (this.type == 40)
					{
						num99 = 57;
						num100 = 172;
					}
					if (!Main.tile[num97, num98].active)
					{
						WorldGen.PlaceTile(num97, num98, num99, false, true, -1, 0);
						if (Main.tile[num97, num98].active && (int)Main.tile[num97, num98].type == num99)
						{
							NetMessage.SendData(17, -1, -1, "", 1, (float)num97, (float)num98, (float)num99, 0);
						}
						else
						{
							if (num100 > 0)
							{
								num96 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num100, 1, false, 0);
							}
						}
					}
					else
					{
						if (num100 > 0)
						{
							num96 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num100, 1, false, 0);
						}
					}
				}
				if (this.type == 1 && Main.rand.Next(3) == 0)
				{
					num96 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0);
				}
				if (this.type == 103 && Main.rand.Next(6) == 0)
				{
					if (Main.rand.Next(3) == 0)
					{
						num96 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 545, 1, false, 0);
					}
					else
					{
						num96 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0);
					}
				}
				if (this.type == 2 && Main.rand.Next(3) == 0)
				{
					if (Main.rand.Next(3) == 0)
					{
						num96 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 41, 1, false, 0);
					}
					else
					{
						num96 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0);
					}
				}
				if (this.type == 91 && Main.rand.Next(6) == 0)
				{
					num96 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 516, 1, false, 0);
				}
				if (this.type == 50 && Main.rand.Next(3) == 0)
				{
					num96 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 282, 1, false, 0);
				}
				if (this.type == 53 && Main.rand.Next(3) == 0)
				{
					num96 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 286, 1, false, 0);
				}
				if (this.type == 48 && Main.rand.Next(2) == 0)
				{
					num96 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 279, 1, false, 0);
				}
				if (this.type == 54 && Main.rand.Next(2) == 0)
				{
					num96 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 287, 1, false, 0);
				}
				if (this.type == 3 && Main.rand.Next(2) == 0)
				{
					num96 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 42, 1, false, 0);
				}
				if (this.type == 4 && Main.rand.Next(4) == 0)
				{
					num96 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 47, 1, false, 0);
				}
				if (this.type == 12 && this.damage > 100)
				{
					num96 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 75, 1, false, 0);
				}
				if (this.type == 69 || this.type == 70)
				{
					int num101 = (int)(this.position.X + (float)(this.width / 2)) / 16;
					int num102 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
					for (int num103 = num101 - 4; num103 <= num101 + 4; num103++)
					{
						for (int num104 = num102 - 4; num104 <= num102 + 4; num104++)
						{
							if (Math.Abs(num103 - num101) + Math.Abs(num104 - num102) < 6)
							{
								if (this.type == 69)
								{
									if (Main.tile[num103, num104].type == 2)
									{
										Main.tile[num103, num104].type = 109;
										WorldGen.SquareTileFrame(num103, num104, true);
										NetMessage.SendTileSquare(-1, num103, num104, 1);
									}
									else
									{
										if (Main.tile[num103, num104].type == 1)
										{
											Main.tile[num103, num104].type = 117;
											WorldGen.SquareTileFrame(num103, num104, true);
											NetMessage.SendTileSquare(-1, num103, num104, 1);
										}
										else
										{
											if (Main.tile[num103, num104].type == 53)
											{
												Main.tile[num103, num104].type = 116;
												WorldGen.SquareTileFrame(num103, num104, true);
												NetMessage.SendTileSquare(-1, num103, num104, 1);
											}
											else
											{
												if (Main.tile[num103, num104].type == 23)
												{
													Main.tile[num103, num104].type = 109;
													WorldGen.SquareTileFrame(num103, num104, true);
													NetMessage.SendTileSquare(-1, num103, num104, 1);
												}
												else
												{
													if (Main.tile[num103, num104].type == 25)
													{
														Main.tile[num103, num104].type = 117;
														WorldGen.SquareTileFrame(num103, num104, true);
														NetMessage.SendTileSquare(-1, num103, num104, 1);
													}
													else
													{
														if (Main.tile[num103, num104].type == 112)
														{
															Main.tile[num103, num104].type = 116;
															WorldGen.SquareTileFrame(num103, num104, true);
															NetMessage.SendTileSquare(-1, num103, num104, 1);
														}
													}
												}
											}
										}
									}
								}
								else
								{
									if (Main.tile[num103, num104].type == 2)
									{
										Main.tile[num103, num104].type = 23;
										WorldGen.SquareTileFrame(num103, num104, true);
										NetMessage.SendTileSquare(-1, num103, num104, 1);
									}
									else
									{
										if (Main.tile[num103, num104].type == 1)
										{
											Main.tile[num103, num104].type = 25;
											WorldGen.SquareTileFrame(num103, num104, true);
											NetMessage.SendTileSquare(-1, num103, num104, 1);
										}
										else
										{
											if (Main.tile[num103, num104].type == 53)
											{
												Main.tile[num103, num104].type = 112;
												WorldGen.SquareTileFrame(num103, num104, true);
												NetMessage.SendTileSquare(-1, num103, num104, 1);
											}
											else
											{
												if (Main.tile[num103, num104].type == 109)
												{
													Main.tile[num103, num104].type = 23;
													WorldGen.SquareTileFrame(num103, num104, true);
													NetMessage.SendTileSquare(-1, num103, num104, 1);
												}
												else
												{
													if (Main.tile[num103, num104].type == 117)
													{
														Main.tile[num103, num104].type = 25;
														WorldGen.SquareTileFrame(num103, num104, true);
														NetMessage.SendTileSquare(-1, num103, num104, 1);
													}
													else
													{
														if (Main.tile[num103, num104].type == 116)
														{
															Main.tile[num103, num104].type = 112;
															WorldGen.SquareTileFrame(num103, num104, true);
															NetMessage.SendTileSquare(-1, num103, num104, 1);
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
				if (this.type == 21 && Main.rand.Next(2) == 0)
				{
					num96 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 154, 1, false, 0);
				}
				if (Main.netMode == 1 && num96 >= 0)
				{
					NetMessage.SendData(21, -1, -1, "", num96, 0f, 0f, 0f, 0);
				}
			}
			this.active = false;
		}
		public Microsoft.Xna.Framework.Color GetAlpha(Microsoft.Xna.Framework.Color newColor)
		{
			if (this.type == 34 || this.type == 15 || this.type == 93 || this.type == 94 || this.type == 95 || this.type == 96 || (this.type == 102 && this.alpha < 255))
			{
				return new Microsoft.Xna.Framework.Color(200, 200, 200, 25);
			}
			if (this.type == 83 || this.type == 88 || this.type == 89 || this.type == 90 || this.type == 100 || this.type == 104)
			{
				if (this.alpha < 200)
				{
					return new Microsoft.Xna.Framework.Color(255 - this.alpha, 255 - this.alpha, 255 - this.alpha, 0);
				}
				return new Microsoft.Xna.Framework.Color(0, 0, 0, 0);
			}
			else
			{
				if (this.type == 34 || this.type == 35 || this.type == 15 || this.type == 19 || this.type == 44 || this.type == 45)
				{
					return Microsoft.Xna.Framework.Color.White;
				}
				int r;
				int g;
				int b;
				if (this.type == 79)
				{
					r = Main.DiscoR;
					g = Main.DiscoG;
					b = Main.DiscoB;
					return default(Microsoft.Xna.Framework.Color);
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
							return new Microsoft.Xna.Framework.Color(255, 255, 255, (int)newColor.A - this.alpha);
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
				return new Microsoft.Xna.Framework.Color(r, g, b, num);
			}
		}
	}
}
