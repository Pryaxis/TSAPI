using XNA;
using System;

namespace Terraria
{
	public class CombatText
	{
		public readonly static Color DamagedFriendly;

		public readonly static Color DamagedFriendlyCrit;

		public readonly static Color DamagedHostile;

		public readonly static Color DamagedHostileCrit;

		public readonly static Color OthersDamagedHostile;

		public readonly static Color OthersDamagedHostileCrit;

		public readonly static Color HealLife;

		public readonly static Color HealMana;

		public readonly static Color LifeRegen;

		public readonly static Color LifeRegenNegative;

		public Vector2 position;

		public Vector2 velocity;

		public float alpha;

		public int alphaDir = 1;

		public string text;

		public float scale = 1f;

		public float rotation;

		public Color color;

		public bool active;

		public int lifeTime;

		public bool crit;

		public bool dot;

		static CombatText()
		{
			CombatText.DamagedFriendly = new Color(255, 80, 90, 255);
			CombatText.DamagedFriendlyCrit = new Color(255, 100, 30, 255);
			CombatText.DamagedHostile = new Color(255, 160, 80, 255);
			CombatText.DamagedHostileCrit = new Color(255, 100, 30, 255);
			CombatText.OthersDamagedHostile = CombatText.DamagedHostile * 0.4f;
			CombatText.OthersDamagedHostileCrit = CombatText.DamagedHostileCrit * 0.4f;
			CombatText.HealLife = new Color(100, 255, 100, 255);
			CombatText.HealMana = new Color(100, 100, 255, 255);
			CombatText.LifeRegen = new Color(255, 60, 70, 255);
			CombatText.LifeRegenNegative = new Color(255, 140, 40, 255);
		}

		public CombatText()
		{
		}

		public static void clearAll()
		{
			for (int i = 0; i < 100; i++)
			{
				Main.combatText[i].active = false;
			}
		}

		public static int NewText(Rectangle location, Color color, string text, bool dramatic = false, bool dot = false)
		{
			if (Main.netMode == 2)
			{
				return 100;
			}
			for (int i = 0; i < 100; i++)
			{
				if (!Main.combatText[i].active)
				{
					int num = 0;
					if (dramatic)
					{
						num = 1;
					}
					Vector2 vector2 = Vector2.Zero;
					Main.combatText[i].alpha = 1f;
					Main.combatText[i].alphaDir = -1;
					Main.combatText[i].active = true;
					Main.combatText[i].scale = 0f;
					Main.combatText[i].rotation = 0f;
					Main.combatText[i].position.X = (float)location.X + (float)location.Width * 0.5f - vector2.X * 0.5f;
					Main.combatText[i].position.Y = (float)location.Y + (float)location.Height * 0.25f - vector2.Y * 0.5f;
					Main.combatText[i].position.X = Main.combatText[i].position.X + (float)Main.rand.Next(-(int)((double)location.Width * 0.5), (int)((double)location.Width * 0.5) + 1);
					Main.combatText[i].position.Y = Main.combatText[i].position.Y + (float)Main.rand.Next(-(int)((double)location.Height * 0.5), (int)((double)location.Height * 0.5) + 1);
					Main.combatText[i].color = color;
					Main.combatText[i].text = text;
					Main.combatText[i].velocity.Y = -7f;
					if (Main.player[Main.myPlayer].gravDir == -1f)
					{
						Main.combatText[i].velocity.Y = Main.combatText[i].velocity.Y * -1f;
						Main.combatText[i].position.Y = (float)location.Y + (float)location.Height * 0.75f + vector2.Y * 0.5f;
					}
					Main.combatText[i].lifeTime = 60;
					Main.combatText[i].crit = dramatic;
					Main.combatText[i].dot = dot;
					if (dramatic)
					{
						Main.combatText[i].text = text;
						CombatText combatText = Main.combatText[i];
						combatText.lifeTime = combatText.lifeTime * 2;
						Main.combatText[i].velocity.Y = Main.combatText[i].velocity.Y * 2f;
						Main.combatText[i].velocity.X = (float)Main.rand.Next(-25, 26) * 0.05f;
						Main.combatText[i].rotation = (float)(Main.combatText[i].lifeTime / 2) * 0.002f;
						if (Main.combatText[i].velocity.X < 0f)
						{
							CombatText combatText1 = Main.combatText[i];
							combatText1.rotation = combatText1.rotation * -1f;
						}
					}
					if (dot)
					{
						Main.combatText[i].velocity.Y = -4f;
						Main.combatText[i].lifeTime = 40;
					}
					return i;
				}
			}
			return 100;
		}

		public void Update()
		{
			if (this.active)
			{
				CombatText combatText = this;
				combatText.alpha = combatText.alpha + (float)this.alphaDir * 0.05f;
				if ((double)this.alpha <= 0.6)
				{
					this.alphaDir = 1;
				}
				if (this.alpha >= 1f)
				{
					this.alpha = 1f;
					this.alphaDir = -1;
				}
				if (!this.dot)
				{
					this.velocity.Y = this.velocity.Y * 0.92f;
					if (this.crit)
					{
						this.velocity.Y = this.velocity.Y * 0.92f;
					}
				}
				else
				{
					this.velocity.Y = this.velocity.Y + 0.15f;
				}
				this.velocity.X = this.velocity.X * 0.93f;
				CombatText combatText1 = this;
				combatText1.position = combatText1.position + this.velocity;
				CombatText combatText2 = this;
				combatText2.lifeTime = combatText2.lifeTime - 1;
				if (this.lifeTime > 0)
				{
					if (this.crit)
					{
						if (this.velocity.X >= 0f)
						{
							CombatText combatText3 = this;
							combatText3.rotation = combatText3.rotation - 0.001f;
						}
						else
						{
							CombatText combatText4 = this;
							combatText4.rotation = combatText4.rotation + 0.001f;
						}
					}
					if (!this.dot)
					{
						if (this.scale < 1f)
						{
							CombatText combatText5 = this;
							combatText5.scale = combatText5.scale + 0.1f;
						}
						if (this.scale > 1f)
						{
							this.scale = 1f;
						}
					}
					else
					{
						CombatText combatText6 = this;
						combatText6.scale = combatText6.scale + 0.5f;
						if ((double)this.scale > 0.8)
						{
							this.scale = 0.8f;
							return;
						}
					}
				}
				else
				{
					CombatText combatText7 = this;
					combatText7.scale = combatText7.scale - 0.1f;
					if ((double)this.scale < 0.1)
					{
						this.active = false;
					}
					this.lifeTime = 0;
					if (this.crit)
					{
						this.alphaDir = -1;
						CombatText combatText8 = this;
						combatText8.scale = combatText8.scale + 0.07f;
						return;
					}
				}
			}
		}

		public static void UpdateCombatText()
		{
			for (int i = 0; i < 100; i++)
			{
				if (Main.combatText[i].active)
				{
					Main.combatText[i].Update();
				}
			}
		}
	}
}