using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace Terraria.GameContent.UI
{
	public class EmoteBubble
	{
		private const int frameSpeed = 8;

		private static int[] CountNPCs;

		public static Dictionary<int, EmoteBubble> byID;

		private static List<int> toClean;

		public static int NextID;

		public int ID;

		public WorldUIAnchor anchor;

		public int lifeTime;

		public int lifeTimeStart;

		public int emote;

		public int metadata;

		public int frameCounter;

		public int frame;

		static EmoteBubble()
		{
			EmoteBubble.CountNPCs = new int[540];
			EmoteBubble.byID = new Dictionary<int, EmoteBubble>();
			EmoteBubble.toClean = new List<int>();
		}

		public EmoteBubble(int emotion, WorldUIAnchor bubbleAnchor, int time = 180)
		{
			this.anchor = bubbleAnchor;
			this.emote = emotion;
			this.lifeTime = time;
			this.lifeTimeStart = time;
		}

		public static int AssignNewID()
		{
			int nextID = EmoteBubble.NextID;
			EmoteBubble.NextID = nextID + 1;
			return nextID;
		}

		public static WorldUIAnchor DeserializeNetAnchor(int type, int meta)
		{
			if (type == 0)
			{
				return new WorldUIAnchor(Main.npc[meta]);
			}
			if (type == 1)
			{
				return new WorldUIAnchor(Main.player[meta]);
			}
			if (type != 2)
			{
				throw new Exception("How did you end up getting this?");
			}
			return new WorldUIAnchor(Main.projectile[meta]);
		}

		private void Draw(SpriteBatch sb)
		{
			object obj;
			Texture2D texture2D = Main.extraTexture[48];
			SpriteEffects spriteEffect = SpriteEffects.None;
			Vector2 position = this.GetPosition(out spriteEffect);
			bool flag = (this.lifeTime < 6 ? true : this.lifeTimeStart - this.lifeTime < 6);
			Rectangle rectangle = texture2D.Frame(8, 33, (flag ? 0 : 1), 0);
			Vector2 vector2 = new Vector2((float)(rectangle.Width / 2), (float)rectangle.Height);
			sb.Draw(texture2D, position, new Rectangle?(rectangle), Color.White, 0f, vector2, 1f, spriteEffect, 0f);
			if (flag)
			{
				return;
			}
			if (this.emote >= 0)
			{
				if (this.emote == 87)
				{
					spriteEffect = SpriteEffects.None;
				}
				sb.Draw(texture2D, position, new Rectangle?(texture2D.Frame(8, 33, this.emote * 2 % 8 + this.frame, 1 + this.emote / 4)), Color.White, 0f, vector2, 1f, spriteEffect, 0f);
				return;
			}
			if (this.emote == -1)
			{
				texture2D = Main.npcHeadTexture[this.metadata];
				float width = 1f;
				if ((float)texture2D.Width / 22f > 1f)
				{
					width = 22f / (float)texture2D.Width;
				}
				if ((float)texture2D.Height / 16f > 1f / width)
				{
					width = 16f / (float)texture2D.Height;
				}
				SpriteBatch spriteBatch = sb;
				Texture2D texture2D1 = texture2D;
				Vector2 vector21 = position;
				obj = (spriteEffect.HasFlag(SpriteEffects.FlipHorizontally) ? 1 : -1);
				Rectangle? nullable = null;
				spriteBatch.Draw(texture2D1, vector21 + new Vector2((float)obj, (float)(-rectangle.Height + 3)), nullable, Color.White, 0f, new Vector2((float)(texture2D.Width / 2), 0f), width, spriteEffect, 0f);
			}
		}

		public static void DrawAll(SpriteBatch sb)
		{
			lock (EmoteBubble.byID)
			{
				foreach (KeyValuePair<int, EmoteBubble> keyValuePair in EmoteBubble.byID)
				{
					keyValuePair.Value.Draw(sb);
				}
			}
		}

		private Vector2 GetPosition(out SpriteEffects effect)
		{
			switch (this.anchor.type)
			{
				case WorldUIAnchor.AnchorType.Entity:
				{
					effect = (this.anchor.entity.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
					return (this.anchor.entity.Top + new Vector2((float)(-this.anchor.entity.direction * this.anchor.entity.width) * 0.75f, 2f)) - Main.screenPosition;
				}
				case WorldUIAnchor.AnchorType.Tile:
				{
					effect = SpriteEffects.None;
					return (this.anchor.pos - Main.screenPosition) + new Vector2(0f, -this.anchor.size.Y / 2f);
				}
				case WorldUIAnchor.AnchorType.Pos:
				{
					effect = SpriteEffects.None;
					return this.anchor.pos - Main.screenPosition;
				}
			}
			effect = SpriteEffects.None;
			return new Vector2((float)Main.screenWidth, (float)Main.screenHeight) / 2f;
		}

		public static int NewBubble(int emoticon, WorldUIAnchor bubbleAnchor, int time)
		{
			EmoteBubble emoteBubble = new EmoteBubble(emoticon, bubbleAnchor, time)
			{
				ID = EmoteBubble.AssignNewID()
			};
			EmoteBubble.byID[emoteBubble.ID] = emoteBubble;
			if (Main.netMode == 2)
			{
				Tuple<int, int> tuple = EmoteBubble.SerializeNetAnchor(bubbleAnchor);
				NetMessage.SendData(91, -1, -1, "", emoteBubble.ID, (float)tuple.Item1, (float)tuple.Item2, (float)time, emoticon, 0, 0);
			}
			return emoteBubble.ID;
		}

		public static int NewBubbleNPC(WorldUIAnchor bubbleAnchor, int time, WorldUIAnchor other = null)
		{
			EmoteBubble emoteBubble = new EmoteBubble(0, bubbleAnchor, time)
			{
				ID = EmoteBubble.AssignNewID()
			};
			EmoteBubble.byID[emoteBubble.ID] = emoteBubble;
			emoteBubble.PickNPCEmote(other);
			if (Main.netMode == 2)
			{
				Tuple<int, int> tuple = EmoteBubble.SerializeNetAnchor(bubbleAnchor);
				NetMessage.SendData(91, -1, -1, "", emoteBubble.ID, (float)tuple.Item1, (float)tuple.Item2, (float)time, emoteBubble.emote, emoteBubble.metadata, 0);
			}
			return emoteBubble.ID;
		}

		public void PickNPCEmote(WorldUIAnchor other = null)
		{
			Player player = Main.player[Player.FindClosest(((NPC)this.anchor.entity).Center, 0, 0)];
			List<int> nums = new List<int>();
			bool flag = false;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && Main.npc[i].boss)
				{
					flag = true;
				}
			}
			if (flag)
			{
				this.ProbeCombat(nums);
			}
			else
			{
				if (Main.rand.Next(3) == 0)
				{
					this.ProbeTownNPCs(nums);
				}
				if (Main.rand.Next(3) == 0)
				{
					this.ProbeEmotions(nums);
				}
				if (Main.rand.Next(3) == 0)
				{
					this.ProbeBiomes(nums, player);
				}
				if (Main.rand.Next(2) == 0)
				{
					this.ProbeCritters(nums);
				}
				if (Main.rand.Next(2) == 0)
				{
					this.ProbeItems(nums, player);
				}
				if (Main.rand.Next(5) == 0)
				{
					this.ProbeBosses(nums);
				}
				if (Main.rand.Next(2) == 0)
				{
					this.ProbeDebuffs(nums, player);
				}
				if (Main.rand.Next(2) == 0)
				{
					this.ProbeEvents(nums);
				}
				if (Main.rand.Next(2) == 0)
				{
					this.ProbeWeather(nums, player);
				}
				this.ProbeExceptions(nums, player, other);
			}
			if (nums.Count > 0)
			{
				this.emote = nums[Main.rand.Next(nums.Count)];
			}
		}

		private void ProbeBiomes(List<int> list, Player plr)
		{
			if ((double)(plr.position.Y / 16f) < Main.worldSurface * 0.45)
			{
				list.Add(22);
				return;
			}
			if ((double)(plr.position.Y / 16f) > Main.rockLayer + (double)(Main.maxTilesY / 2) - 100)
			{
				list.Add(31);
				return;
			}
			if ((double)(plr.position.Y / 16f) > Main.rockLayer)
			{
				list.Add(30);
				return;
			}
			if (plr.ZoneHoly)
			{
				list.Add(27);
				return;
			}
			if (plr.ZoneCorrupt)
			{
				list.Add(26);
				return;
			}
			if (plr.ZoneCrimson)
			{
				list.Add(25);
				return;
			}
			if (plr.ZoneJungle)
			{
				list.Add(24);
				return;
			}
			if (plr.ZoneSnow)
			{
				list.Add(32);
				return;
			}
			if ((double)(plr.position.Y / 16f) < Main.worldSurface && (plr.position.X < 4000f || plr.position.X > (float)(16 * (Main.maxTilesX - 250))))
			{
				list.Add(29);
				return;
			}
			if (plr.ZoneDesert)
			{
				list.Add(28);
				return;
			}
			list.Add(23);
		}

		private void ProbeBosses(List<int> list)
		{
			int num = 0;
			if (!NPC.downedBoss1 && !Main.dayTime || NPC.downedBoss1)
			{
				num = 1;
			}
			if (NPC.downedBoss2)
			{
				num = 2;
			}
			if (NPC.downedQueenBee || NPC.downedBoss3)
			{
				num = 3;
			}
			if (Main.hardMode)
			{
				num = 4;
			}
			if (NPC.downedMechBossAny)
			{
				num = 5;
			}
			if (NPC.downedPlantBoss)
			{
				num = 6;
			}
			if (NPC.downedGolemBoss)
			{
				num = 7;
			}
			if (NPC.downedAncientCultist)
			{
				num = 8;
			}
			int num1 = 10;
			if (NPC.downedMoonlord)
			{
				num1 = 1;
			}
			if (num >= 1 && num <= 2 || num >= 1 && Main.rand.Next(num1) == 0)
			{
				list.Add(39);
				if (!WorldGen.crimson)
				{
					list.Add(40);
				}
				else
				{
					list.Add(41);
				}
				list.Add(51);
			}
			if (num >= 2 && num <= 3 || num >= 2 && Main.rand.Next(num1) == 0)
			{
				list.Add(43);
				list.Add(42);
			}
			if (num >= 4 && num <= 5 || num >= 4 && Main.rand.Next(num1) == 0)
			{
				list.Add(44);
				list.Add(47);
				list.Add(45);
				list.Add(46);
			}
			if (num >= 5 && num <= 6 || num >= 5 && Main.rand.Next(num1) == 0)
			{
				if (!NPC.downedMechBoss1)
				{
					list.Add(47);
				}
				if (!NPC.downedMechBoss2)
				{
					list.Add(45);
				}
				if (!NPC.downedMechBoss3)
				{
					list.Add(46);
				}
				list.Add(48);
			}
			if (num == 6 || num >= 6 && Main.rand.Next(num1) == 0)
			{
				list.Add(48);
				list.Add(49);
				list.Add(50);
			}
			if (num == 7 || num >= 7 && Main.rand.Next(num1) == 0)
			{
				list.Add(49);
				list.Add(50);
				list.Add(52);
			}
			if (num == 8 || num >= 8 && Main.rand.Next(num1) == 0)
			{
				list.Add(52);
				list.Add(53);
			}
			if (NPC.downedPirates && Main.expertMode)
			{
				list.Add(59);
			}
			if (NPC.downedMartians)
			{
				list.Add(60);
			}
			if (NPC.downedChristmasIceQueen)
			{
				list.Add(57);
			}
			if (NPC.downedChristmasSantank)
			{
				list.Add(58);
			}
			if (NPC.downedChristmasTree)
			{
				list.Add(56);
			}
			if (NPC.downedHalloweenKing)
			{
				list.Add(55);
			}
			if (NPC.downedHalloweenTree)
			{
				list.Add(54);
			}
		}

		private void ProbeCombat(List<int> list)
		{
			list.Add(16);
			list.Add(1);
			list.Add(2);
			list.Add(91);
			list.Add(93);
			list.Add(84);
			list.Add(84);
		}

		private void ProbeCritters(List<int> list)
		{
			Vector2 center = this.anchor.entity.Center;
			float single = 1f;
			float single1 = 1f;
			if ((double)center.Y >= Main.rockLayer * 16)
			{
				single = 0.2f;
			}
			else
			{
				single1 = 0.2f;
			}
			if (Main.rand.NextFloat() <= single)
			{
				if (Main.dayTime)
				{
					list.Add(13);
					list.Add(12);
					list.Add(68);
					list.Add(62);
					list.Add(63);
					list.Add(69);
					list.Add(70);
				}
				if (!Main.dayTime || Main.dayTime && (Main.time < 5400 || Main.time > 48600))
				{
					list.Add(61);
				}
				if (NPC.downedGoblins)
				{
					list.Add(64);
				}
				if (NPC.downedFrost)
				{
					list.Add(66);
				}
				if (NPC.downedPirates)
				{
					list.Add(65);
				}
				if (NPC.downedMartians)
				{
					list.Add(71);
				}
				if (WorldGen.crimson)
				{
					list.Add(67);
				}
			}
			if (Main.rand.NextFloat() <= single1)
			{
				list.Add(72);
				list.Add(69);
			}
		}

		private void ProbeDebuffs(List<int> list, Player plr)
		{
			if (plr.Center.Y > (float)(Main.maxTilesY * 16 - 3200) || plr.onFire || ((NPC)this.anchor.entity).onFire || plr.onFire2)
			{
				list.Add(9);
			}
			if (Main.rand.Next(2) == 0)
			{
				list.Add(11);
			}
			if (plr.poisoned || ((NPC)this.anchor.entity).poisoned || plr.ZoneJungle)
			{
				list.Add(8);
			}
			if (plr.inventory[plr.selectedItem].type == 215 || Main.rand.Next(3) == 0)
			{
				list.Add(10);
			}
		}

		private void ProbeEmotions(List<int> list)
		{
			list.Add(0);
			list.Add(1);
			list.Add(2);
			list.Add(3);
			list.Add(15);
			list.Add(16);
			list.Add(17);
			list.Add(87);
			list.Add(91);
			if (Main.bloodMoon && !Main.dayTime)
			{
				Random random = Main.rand;
				int[] numArray = new int[] { 16, 1 };
				int num = Utils.SelectRandom<int>(random, numArray);
				list.Add(num);
				list.Add(num);
				list.Add(num);
			}
		}

		private void ProbeEvents(List<int> list)
		{
			if (Main.bloodMoon || !Main.dayTime && Main.rand.Next(4) == 0)
			{
				list.Add(18);
			}
			if (Main.eclipse || Main.hardMode && Main.rand.Next(4) == 0)
			{
				list.Add(19);
			}
			if ((!Main.dayTime || WorldGen.spawnMeteor) && WorldGen.shadowOrbSmashed)
			{
				list.Add(99);
			}
			if (Main.pumpkinMoon || (NPC.downedHalloweenKing || NPC.downedHalloweenTree) && !Main.dayTime)
			{
				list.Add(20);
			}
			if (Main.snowMoon || (NPC.downedChristmasIceQueen || NPC.downedChristmasSantank || NPC.downedChristmasTree) && !Main.dayTime)
			{
				list.Add(21);
			}
		}

		private void ProbeExceptions(List<int> list, Player plr, WorldUIAnchor other)
		{
			NPC nPC = (NPC)this.anchor.entity;
			if (nPC.type == 17)
			{
				list.Add(80);
				list.Add(85);
				list.Add(85);
				list.Add(85);
				list.Add(85);
			}
			else if (nPC.type == 18)
			{
				list.Add(73);
				list.Add(73);
				list.Add(84);
				list.Add(75);
			}
			else if (nPC.type == 19)
			{
				if (other != null && ((NPC)other.entity).type == 22)
				{
					list.Add(1);
					list.Add(1);
					list.Add(93);
					list.Add(92);
				}
				else if (other == null || ((NPC)other.entity).type != 22)
				{
					list.Add(82);
					list.Add(82);
					list.Add(85);
					list.Add(85);
					list.Add(77);
					list.Add(93);
				}
				else
				{
					list.Add(1);
					list.Add(1);
					list.Add(93);
					list.Add(92);
				}
			}
			else if (nPC.type == 20)
			{
				if (list.Contains(121))
				{
					list.Add(121);
					list.Add(121);
				}
				list.Add(14);
				list.Add(14);
			}
			else if (nPC.type == 22)
			{
				if (!Main.bloodMoon)
				{
					if (other == null || ((NPC)other.entity).type != 19)
					{
						list.Add(79);
					}
					else
					{
						list.Add(1);
						list.Add(1);
						list.Add(93);
						list.Add(92);
					}
				}
				if (!Main.dayTime)
				{
					list.Add(16);
					list.Add(16);
					list.Add(16);
				}
			}
			else if (nPC.type == 37)
			{
				list.Add(43);
				list.Add(43);
				list.Add(43);
				list.Add(72);
				list.Add(72);
			}
			else if (nPC.type == 38)
			{
				if (!Main.bloodMoon)
				{
					list.Add(77);
					list.Add(77);
					list.Add(81);
					list.Add(81);
					list.Add(81);
					list.Add(90);
					list.Add(90);
				}
				else
				{
					list.Add(77);
					list.Add(77);
					list.Add(77);
					list.Add(81);
				}
			}
			else if (nPC.type == 54)
			{
				if (!Main.bloodMoon)
				{
					if (list.Contains(111))
					{
						list.Add(111);
					}
					list.Add(17);
				}
				else
				{
					list.Add(43);
					list.Add(72);
					list.Add(1);
				}
			}
			else if (nPC.type == 107)
			{
				if (other == null || ((NPC)other.entity).type != 124)
				{
					if (list.Contains(111))
					{
						list.Add(111);
						list.Add(111);
						list.Add(111);
					}
					list.Add(91);
					list.Add(92);
					list.Add(91);
					list.Add(92);
				}
				else
				{
					list.Remove(111);
					list.Add(0);
					list.Add(0);
					list.Add(0);
					list.Add(17);
					list.Add(17);
					list.Add(86);
					list.Add(88);
					list.Add(88);
				}
			}
			else if (nPC.type == 108)
			{
				list.Add(100);
				list.Add(89);
				list.Add(11);
			}
			if (nPC.type == 124)
			{
				if (other != null && ((NPC)other.entity).type == 107)
				{
					list.Remove(111);
					list.Add(0);
					list.Add(0);
					list.Add(0);
					list.Add(17);
					list.Add(17);
					list.Add(88);
					list.Add(88);
					return;
				}
				if (list.Contains(109))
				{
					list.Add(109);
					list.Add(109);
					list.Add(109);
				}
				if (list.Contains(108))
				{
					list.Remove(108);
					if (!Main.hardMode)
					{
						list.Add(106);
						list.Add(106);
					}
					else
					{
						list.Add(108);
						list.Add(108);
					}
				}
				list.Add(43);
				list.Add(2);
				return;
			}
			if (nPC.type == 142)
			{
				list.Add(32);
				list.Add(66);
				list.Add(17);
				list.Add(15);
				list.Add(15);
				return;
			}
			if (nPC.type == 160)
			{
				list.Add(10);
				list.Add(89);
				list.Add(94);
				list.Add(8);
				return;
			}
			if (nPC.type == 178)
			{
				list.Add(83);
				list.Add(83);
				return;
			}
			if (nPC.type == 207)
			{
				list.Add(28);
				list.Add(95);
				list.Add(93);
				return;
			}
			if (nPC.type == 208)
			{
				list.Add(94);
				list.Add(17);
				list.Add(3);
				list.Add(77);
				return;
			}
			if (nPC.type == 209)
			{
				list.Add(48);
				list.Add(83);
				list.Add(5);
				list.Add(5);
				return;
			}
			if (nPC.type == 227)
			{
				list.Add(63);
				list.Add(68);
				return;
			}
			if (nPC.type == 228)
			{
				list.Add(24);
				list.Add(24);
				list.Add(95);
				list.Add(8);
				return;
			}
			if (nPC.type == 229)
			{
				list.Add(93);
				list.Add(9);
				list.Add(65);
				list.Add(120);
				list.Add(59);
				return;
			}
			if (nPC.type == 353)
			{
				if (list.Contains(104))
				{
					list.Add(104);
					list.Add(104);
				}
				if (list.Contains(111))
				{
					list.Add(111);
					list.Add(111);
				}
				list.Add(67);
				return;
			}
			if (nPC.type == 368)
			{
				list.Add(85);
				list.Add(7);
				list.Add(79);
				return;
			}
			if (nPC.type != 369)
			{
				if (nPC.type == 453)
				{
					list.Add(72);
					list.Add(69);
					list.Add(87);
					list.Add(3);
					return;
				}
				if (nPC.type == 441)
				{
					list.Add(100);
					list.Add(100);
					list.Add(1);
					list.Add(1);
					list.Add(1);
					list.Add(87);
				}
			}
			else if (!Main.bloodMoon)
			{
				list.Add(70);
				list.Add(70);
				list.Add(76);
				list.Add(76);
				list.Add(79);
				list.Add(79);
				if ((double)nPC.position.Y < Main.worldSurface)
				{
					list.Add(29);
					return;
				}
			}
		}

		private void ProbeItems(List<int> list, Player plr)
		{
			list.Add(7);
			list.Add(73);
			list.Add(74);
			list.Add(75);
			list.Add(78);
			list.Add(90);
			if (plr.statLife < plr.statLifeMax2 / 2)
			{
				list.Add(84);
			}
		}

		private void ProbeTownNPCs(List<int> list)
		{
			for (int i = 0; i < 540; i++)
			{
				EmoteBubble.CountNPCs[i] = 0;
			}
			for (int j = 0; j < 200; j++)
			{
				if (Main.npc[j].active)
				{
					EmoteBubble.CountNPCs[Main.npc[j].type] = EmoteBubble.CountNPCs[Main.npc[j].type] + 1;
				}
			}
			int num = ((NPC)this.anchor.entity).type;
			for (int k = 0; k < 540; k++)
			{
				if (NPCID.Sets.FaceEmote[k] > 0 && EmoteBubble.CountNPCs[k] > 0 && k != num)
				{
					list.Add(NPCID.Sets.FaceEmote[k]);
				}
			}
		}

		private void ProbeWeather(List<int> list, Player plr)
		{
			if (Main.cloudBGActive > 0f)
			{
				list.Add(96);
			}
			if (Main.cloudAlpha <= 0f)
			{
				list.Add(95);
			}
			else
			{
				if (!Main.dayTime)
				{
					list.Add(5);
				}
				list.Add(4);
				if (plr.ZoneSnow)
				{
					list.Add(98);
				}
				if (plr.position.X < 4000f || plr.position.X > (float)(Main.maxTilesX * 16 - 4000) && (double)plr.position.Y < Main.worldSurface / 16)
				{
					list.Add(97);
				}
			}
			if (plr.ZoneHoly)
			{
				list.Add(6);
			}
		}

		public static Tuple<int, int> SerializeNetAnchor(WorldUIAnchor anch)
		{
			if (anch.type != WorldUIAnchor.AnchorType.Entity)
			{
				return Tuple.Create<int, int>(0, 0);
			}
			int num = 0;
			if (anch.entity is NPC)
			{
				num = 0;
			}
			else if (anch.entity is Player)
			{
				num = 1;
			}
			else if (anch.entity is Projectile)
			{
				num = 2;
			}
			return Tuple.Create<int, int>(num, anch.entity.whoAmI);
		}

		private void Update()
		{
			EmoteBubble emoteBubble = this;
			int num = emoteBubble.lifeTime - 1;
			int num1 = num;
			emoteBubble.lifeTime = num;
			if (num1 <= 0)
			{
				return;
			}
			EmoteBubble emoteBubble1 = this;
			int num2 = emoteBubble1.frameCounter + 1;
			int num3 = num2;
			emoteBubble1.frameCounter = num2;
			if (num3 >= 8)
			{
				this.frameCounter = 0;
				EmoteBubble emoteBubble2 = this;
				int num4 = emoteBubble2.frame + 1;
				int num5 = num4;
				emoteBubble2.frame = num4;
				if (num5 >= 2)
				{
					this.frame = 0;
				}
			}
		}

		public static void UpdateAll()
		{
			lock (EmoteBubble.byID)
			{
				EmoteBubble.toClean.Clear();
				foreach (KeyValuePair<int, EmoteBubble> keyValuePair in EmoteBubble.byID)
				{
					keyValuePair.Value.Update();
					if (keyValuePair.Value.lifeTime > 0)
					{
						continue;
					}
					EmoteBubble.toClean.Add(keyValuePair.Key);
				}
				foreach (int num in EmoteBubble.toClean)
				{
					EmoteBubble.byID.Remove(num);
				}
				EmoteBubble.toClean.Clear();
			}
		}
	}
}