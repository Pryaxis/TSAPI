using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Terraria;
using Terraria.GameContent.UI.Chat;

namespace Terraria.UI.Chat
{
	public static class ChatManager
	{
		private static ConcurrentDictionary<string, ITagHandler> _handlers;

		public readonly static Vector2[] ShadowDirections;

		static ChatManager()
		{
			ChatManager._handlers = new ConcurrentDictionary<string, ITagHandler>();
			Vector2[] unitX = new Vector2[] { -Vector2.UnitX, Vector2.UnitX, -Vector2.UnitY, Vector2.UnitY };
			ChatManager.ShadowDirections = unitX;
		}

		public static bool AddChatText(SpriteFont font, string text, Vector2 baseScale)
		{
			if (ChatManager.GetStringSize(font, string.Concat(Main.chatText, text), baseScale, -1f).X > (float)(Main.screenWidth - 330))
			{
				return false;
			}
			Main.chatText = string.Concat(Main.chatText, text);
			return true;
		}

		public static void ConvertNormalSnippets(TextSnippet[] snippets)
		{
			for (int i = 0; i < (int)snippets.Length; i++)
			{
				TextSnippet textSnippet = snippets[i];
				if (snippets[i].GetType() == typeof(TextSnippet))
				{
					PlainTagHandler.PlainSnippet plainSnippet = new PlainTagHandler.PlainSnippet(textSnippet.Text, textSnippet.Color, textSnippet.Scale);
					snippets[i] = plainSnippet;
				}
			}
		}

		public static Vector2 DrawColorCodedString(SpriteBatch spriteBatch, SpriteFont font, TextSnippet[] snippets, Vector2 position, Color baseColor, float rotation, Vector2 origin, Vector2 baseScale, out int hoveredSnippet, float maxWidth, bool ignoreColors = false)
		{
			Vector2 vector2;
			int num = -1;
			Vector2 vector21 = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			Vector2 x = position;
			Vector2 vector22 = x;
			float single = font.MeasureString(" ").X;
			Color visibleColor = baseColor;
			float scale = 1f;
			float single1 = 0f;
			for (int i = 0; i < (int)snippets.Length; i++)
			{
				TextSnippet textSnippet = snippets[i];
				textSnippet.Update();
				if (!ignoreColors)
				{
					visibleColor = textSnippet.GetVisibleColor();
				}
				scale = textSnippet.Scale;
				if (!textSnippet.UniqueDraw(false, out vector2, spriteBatch, x, visibleColor, scale))
				{
					string[] strArrays = textSnippet.Text.Split(new char[] { '\n' });
					string[] strArrays1 = strArrays;
					for (int j = 0; j < (int)strArrays1.Length; j++)
					{
						string str = strArrays1[j];
						string[] strArrays2 = str.Split(new char[] { ' ' });
						for (int k = 0; k < (int)strArrays2.Length; k++)
						{
							if (k != 0)
							{
								x.X = x.X + single * baseScale.X * scale;
							}
							if (maxWidth > 0f && x.X - position.X + font.MeasureString(strArrays2[k]).X * baseScale.X * scale > maxWidth)
							{
								x.X = position.X;
								x.Y = x.Y + (float)font.LineSpacing * single1 * baseScale.Y;
								vector22.Y = Math.Max(vector22.Y, x.Y);
								single1 = 0f;
							}
							if (single1 < scale)
							{
								single1 = scale;
							}
							spriteBatch.DrawString(font, strArrays2[k], x, visibleColor, rotation, origin, (baseScale * textSnippet.Scale) * scale, SpriteEffects.None, 0f);
							Vector2 vector23 = font.MeasureString(strArrays2[k]);
							if (vector21.Between(x, x + vector23))
							{
								num = i;
							}
							x.X = x.X + vector23.X * baseScale.X * scale;
							vector22.X = Math.Max(vector22.X, x.X);
						}
						if ((int)strArrays.Length > 1)
						{
							x.Y = x.Y + (float)font.LineSpacing * single1 * baseScale.Y;
							x.X = position.X;
							vector22.Y = Math.Max(vector22.Y, x.Y);
							single1 = 0f;
						}
					}
				}
				else
				{
					if (vector21.Between(x, x + vector2))
					{
						num = i;
					}
					x.X = x.X + vector2.X * baseScale.X * scale;
					vector22.X = Math.Max(vector22.X, x.X);
				}
			}
			hoveredSnippet = num;
			return vector22;
		}

		public static Vector2 DrawColorCodedString(SpriteBatch spriteBatch, SpriteFont font, string text, Vector2 position, Color baseColor, float rotation, Vector2 origin, Vector2 baseScale, float maxWidth = -1f, bool ignoreColors = false)
		{
			Vector2 x = position;
			Vector2 vector2 = x;
			string[] strArrays = text.Split(new char[] { '\n' });
			float single = font.MeasureString(" ").X;
			Color red = baseColor;
			float single1 = 1f;
			float single2 = 0f;
			string[] strArrays1 = strArrays;
			for (int i = 0; i < (int)strArrays1.Length; i++)
			{
				string str = strArrays1[i];
				string[] strArrays2 = str.Split(new char[] { ':' });
				for (int j = 0; j < (int)strArrays2.Length; j++)
				{
					string str1 = strArrays2[j];
					if (!str1.StartsWith("sss"))
					{
						string[] strArrays3 = str1.Split(new char[] { ' ' });
						for (int k = 0; k < (int)strArrays3.Length; k++)
						{
							if (k != 0)
							{
								x.X = x.X + single * baseScale.X * single1;
							}
							if (maxWidth > 0f && x.X - position.X + font.MeasureString(strArrays3[k]).X * baseScale.X * single1 > maxWidth)
							{
								x.X = position.X;
								x.Y = x.Y + (float)font.LineSpacing * single2 * baseScale.Y;
								vector2.Y = Math.Max(vector2.Y, x.Y);
								single2 = 0f;
							}
							if (single2 < single1)
							{
								single2 = single1;
							}
							spriteBatch.DrawString(font, strArrays3[k], x, red, rotation, origin, baseScale * single1, SpriteEffects.None, 0f);
							x.X = x.X + font.MeasureString(strArrays3[k]).X * baseScale.X * single1;
							vector2.X = Math.Max(vector2.X, x.X);
						}
					}
					else if (str1.StartsWith("sss1"))
					{
						if (!ignoreColors)
						{
							red = Color.Red;
						}
					}
					else if (str1.StartsWith("sss2"))
					{
						if (!ignoreColors)
						{
							red = Color.Blue;
						}
					}
					else if (str1.StartsWith("sssr") && !ignoreColors)
					{
						red = Color.White;
					}
				}
				x.X = position.X;
				x.Y = x.Y + (float)font.LineSpacing * single2 * baseScale.Y;
				vector2.Y = Math.Max(vector2.Y, x.Y);
				single2 = 0f;
			}
			return vector2;
		}

		public static void DrawColorCodedStringShadow(SpriteBatch spriteBatch, SpriteFont font, TextSnippet[] snippets, Vector2 position, Color baseColor, float rotation, Vector2 origin, Vector2 baseScale, float maxWidth = -1f, float spread = 2f)
		{
			int num;
			for (int i = 0; i < (int)ChatManager.ShadowDirections.Length; i++)
			{
				ChatManager.DrawColorCodedString(spriteBatch, font, snippets, position + (ChatManager.ShadowDirections[i] * spread), baseColor, rotation, origin, baseScale, out num, maxWidth, true);
			}
		}

		public static void DrawColorCodedStringShadow(SpriteBatch spriteBatch, SpriteFont font, string text, Vector2 position, Color baseColor, float rotation, Vector2 origin, Vector2 baseScale, float maxWidth = -1f, float spread = 2f)
		{
			for (int i = 0; i < (int)ChatManager.ShadowDirections.Length; i++)
			{
				ChatManager.DrawColorCodedString(spriteBatch, font, text, position + (ChatManager.ShadowDirections[i] * spread), baseColor, rotation, origin, baseScale, maxWidth, true);
			}
		}

		public static Vector2 DrawColorCodedStringWithShadow(SpriteBatch spriteBatch, SpriteFont font, TextSnippet[] snippets, Vector2 position, float rotation, Vector2 origin, Vector2 baseScale, out int hoveredSnippet, float maxWidth = -1f, float spread = 2f)
		{
			ChatManager.DrawColorCodedStringShadow(spriteBatch, font, snippets, position, Color.Black, rotation, origin, baseScale, maxWidth, spread);
			return ChatManager.DrawColorCodedString(spriteBatch, font, snippets, position, Color.White, rotation, origin, baseScale, out hoveredSnippet, maxWidth, false);
		}

		public static Vector2 DrawColorCodedStringWithShadow(SpriteBatch spriteBatch, SpriteFont font, string text, Vector2 position, Color baseColor, float rotation, Vector2 origin, Vector2 baseScale, float maxWidth = -1f, float spread = 2f)
		{
			int num;
			TextSnippet[] textSnippetArray = ChatManager.ParseMessage(text, baseColor);
			ChatManager.ConvertNormalSnippets(textSnippetArray);
			ChatManager.DrawColorCodedStringShadow(spriteBatch, font, textSnippetArray, position, Color.Black, rotation, origin, baseScale, maxWidth, spread);
			return ChatManager.DrawColorCodedString(spriteBatch, font, textSnippetArray, position, Color.White, rotation, origin, baseScale, out num, maxWidth, false);
		}

		private static ITagHandler GetHandler(string tagName)
		{
			string lower = tagName.ToLower();
			if (!ChatManager._handlers.ContainsKey(lower))
			{
				return null;
			}
			return ChatManager._handlers[lower];
		}

		public static Vector2 GetStringSize(SpriteFont font, string text, Vector2 baseScale, float maxWidth = -1f)
		{
			TextSnippet[] textSnippetArray = ChatManager.ParseMessage(text, Color.White);
			return ChatManager.GetStringSize(font, textSnippetArray, baseScale, maxWidth);
		}

		public static Vector2 GetStringSize(SpriteFont font, TextSnippet[] snippets, Vector2 baseScale, float maxWidth = -1f)
		{
			Vector2 vector2;
			Vector2 vector21 = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			Vector2 zero = Vector2.Zero;
			Vector2 x = zero;
			Vector2 vector22 = x;
			float single = font.MeasureString(" ").X;
			float scale = 1f;
			float single1 = 0f;
			for (int i = 0; i < (int)snippets.Length; i++)
			{
				TextSnippet textSnippet = snippets[i];
				textSnippet.Update();
				scale = textSnippet.Scale;
				Vector2 vector23 = new Vector2();
				Color color = new Color();
				if (!textSnippet.UniqueDraw(true, out vector2, null, vector23, color, 1f))
				{
					string[] strArrays = textSnippet.Text.Split(new char[] { '\n' });
					string[] strArrays1 = strArrays;
					for (int j = 0; j < (int)strArrays1.Length; j++)
					{
						string str = strArrays1[j];
						string[] strArrays2 = str.Split(new char[] { ' ' });
						for (int k = 0; k < (int)strArrays2.Length; k++)
						{
							if (k != 0)
							{
								x.X = x.X + single * baseScale.X * scale;
							}
							if (maxWidth > 0f && x.X - zero.X + font.MeasureString(strArrays2[k]).X * baseScale.X * scale > maxWidth)
							{
								x.X = zero.X;
								x.Y = x.Y + (float)font.LineSpacing * single1 * baseScale.Y;
								vector22.Y = Math.Max(vector22.Y, x.Y);
								single1 = 0f;
							}
							if (single1 < scale)
							{
								single1 = scale;
							}
							Vector2 vector24 = font.MeasureString(strArrays2[k]);
							vector21.Between(x, x + vector24);
							x.X = x.X + vector24.X * baseScale.X * scale;
							vector22.X = Math.Max(vector22.X, x.X);
							vector22.Y = Math.Max(vector22.Y, x.Y + vector24.Y);
						}
						if ((int)strArrays.Length > 1)
						{
							x.X = zero.X;
							x.Y = x.Y + (float)font.LineSpacing * single1 * baseScale.Y;
							vector22.Y = Math.Max(vector22.Y, x.Y);
							single1 = 0f;
						}
					}
				}
				else
				{
					x.X = x.X + vector2.X * baseScale.X * scale;
					vector22.X = Math.Max(vector22.X, x.X);
					vector22.Y = Math.Max(vector22.Y, x.Y + vector2.Y);
				}
			}
			return vector22;
		}

		public static TextSnippet[] ParseMessage(string text, Color baseColor)
		{
			MatchCollection matchCollections = ChatManager.Regexes.Format.Matches(text);
			List<TextSnippet> textSnippets = new List<TextSnippet>();
			int index = 0;
			foreach (Match match in matchCollections)
			{
				if (match.Index > index)
				{
					textSnippets.Add(new TextSnippet(text.Substring(index, match.Index - index)));
				}
				index = match.Index + match.Length;
				string value = match.Groups["tag"].Value;
				string str = match.Groups["text"].Value;
				string value1 = match.Groups["options"].Value;
				ITagHandler handler = ChatManager.GetHandler(value);
				if (handler == null)
				{
					textSnippets.Add(new TextSnippet(str, baseColor, 1f));
				}
				else
				{
					textSnippets.Add(handler.Parse(str, baseColor, value1));
					textSnippets[textSnippets.Count - 1].TextOriginal = match.ToString();
				}
			}
			if (text.Length > index)
			{
				textSnippets.Add(new TextSnippet(text.Substring(index, text.Length - index), baseColor, 1f));
			}
			return textSnippets.ToArray();
		}

		public static void Register<T>(params string[] names)
		where T : ITagHandler, new()
		{
			T t = default(T);
			T t1 = (t == null ? Activator.CreateInstance<T>() : default(T));
			for (int i = 0; i < (int)names.Length; i++)
			{
				ChatManager._handlers[names[i].ToLower()] = t1;
			}
		}

		public static Color WaveColor(Color color)
		{
			float single = (float)Main.mouseTextColor / 255f;
			color = Color.Lerp(color, Color.Black, 1f - single);
			color.A = Main.mouseTextColor;
			return color;
		}

		public static class Regexes
		{
			public readonly static Regex Format;

			static Regexes()
			{
				ChatManager.Regexes.Format = new Regex("(?<!\\\\)\\[(?<tag>[a-zA-Z]{1,10})(\\/(?<options>[^:]+))?:(?<text>.+?)(?<!\\\\)\\]", RegexOptions.Compiled);
			}
		}
	}
}