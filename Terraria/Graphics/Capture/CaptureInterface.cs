using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Terraria;
using Terraria.UI.Chat;

namespace Terraria.Graphics.Capture
{
	internal class CaptureInterface
	{
		private const Keys KeyToggleActive = Keys.F1;

		private const float CameraMaxFrame = 5f;

		private const float CameraMaxWait = 60f;

		private static Dictionary<int, CaptureInterface.CaptureInterfaceMode> Modes;

		public bool Active;

		public static bool JustActivated;

		private bool KeyToggleActiveHeld;

		public int SelectedMode;

		public int HoveredMode;

		public static bool EdgeAPinned;

		public static bool EdgeBPinned;

		public static Point EdgeA;

		public static Point EdgeB;

		public static bool CameraLock;

		private static float CameraFrame;

		private static float CameraWaiting;

		private static CaptureSettings CameraSettings;

		static CaptureInterface()
		{
			CaptureInterface.Modes = CaptureInterface.FillModes();
			CaptureInterface.JustActivated = false;
			CaptureInterface.EdgeAPinned = false;
			CaptureInterface.EdgeBPinned = false;
			CaptureInterface.EdgeA = new Point();
			CaptureInterface.EdgeB = new Point();
			CaptureInterface.CameraLock = false;
			CaptureInterface.CameraFrame = 0f;
			CaptureInterface.CameraWaiting = 0f;
		}

		public CaptureInterface()
		{
		}

		private static void ConstraintPoints()
		{
			int num = Lighting.offScreenTiles;
			if (CaptureInterface.EdgeAPinned)
			{
				CaptureInterface.PointWorldClamp(ref CaptureInterface.EdgeA, num);
			}
			if (CaptureInterface.EdgeBPinned)
			{
				CaptureInterface.PointWorldClamp(ref CaptureInterface.EdgeB, num);
			}
		}

		public void Draw(SpriteBatch sb)
		{
			if (!this.Active)
			{
				return;
			}
			foreach (CaptureInterface.CaptureInterfaceMode value in CaptureInterface.Modes.Values)
			{
				value.Draw(sb);
			}
			Main.mouseText = false;
			Main.instance.GUIBarsDraw();
			this.DrawButtons(sb);
			Main.instance.DrawMouseOver();
			Utils.DrawBorderStringBig(sb, Lang.inter[81], new Vector2((float)Main.screenWidth * 0.5f, 100f), Color.White, 1f, 0.5f, 0.5f, -1);
			Color color = Main.cursorColor;
			float single = Main.cursorScale;
			Vector2 vector2 = new Vector2();
			Utils.DrawCursorSingle(sb, color, float.NaN, single, vector2, 0, 0);
			this.DrawCameraLock(sb);
		}

		private void DrawButtons(SpriteBatch sb)
		{
			Vector2 vector2 = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			int num = 9;
			for (int i = 0; i < num; i++)
			{
				Texture2D texture2D = Main.inventoryBackTexture;
				float single = 0.8f;
				Vector2 vector21 = new Vector2((float)(24 + 46 * i), 24f);
				Color color = Main.inventoryBack * 0.8f;
				if (this.SelectedMode == 0 && i == 2)
				{
					texture2D = Main.inventoryBack14Texture;
				}
				else if (this.SelectedMode == 1 && i == 3)
				{
					texture2D = Main.inventoryBack14Texture;
				}
				else if (this.SelectedMode == 2 && i == 6)
				{
					texture2D = Main.inventoryBack14Texture;
				}
				else if (i >= 2 && i <= 3)
				{
					texture2D = Main.inventoryBack2Texture;
				}
				Rectangle? nullable = null;
				Vector2 vector22 = new Vector2();
				sb.Draw(texture2D, vector21, nullable, color, 0f, vector22, single, SpriteEffects.None, 0f);
				switch (i)
				{
					case 0:
					{
						texture2D = Main.cameraTexture[7];
						break;
					}
					case 1:
					{
						texture2D = Main.cameraTexture[0];
						break;
					}
					case 2:
					case 3:
					case 4:
					{
						texture2D = Main.cameraTexture[i];
						break;
					}
					case 5:
					{
						texture2D = (Main.mapFullscreen ? Main.mapIconTexture[0] : Main.mapIconTexture[4]);
						break;
					}
					case 6:
					{
						texture2D = Main.cameraTexture[1];
						break;
					}
					case 7:
					{
						texture2D = Main.cameraTexture[6];
						break;
					}
					case 8:
					{
						texture2D = Main.cameraTexture[5];
						break;
					}
				}
				Rectangle? nullable1 = null;
				sb.Draw(texture2D, vector21 + (new Vector2(26f) * single), nullable1, Color.White, 0f, texture2D.Size() / 2f, 1f, SpriteEffects.None, 0f);
				bool flag = false;
				int num1 = i;
				if (num1 != 1)
				{
					switch (num1)
					{
						case 5:
						{
							if (Main.mapEnabled)
							{
								break;
							}
							flag = true;
							break;
						}
						case 7:
						{
							if (!Main.graphics.IsFullScreen)
							{
								break;
							}
							flag = true;
							break;
						}
					}
				}
				else if (!CaptureInterface.EdgeAPinned || !CaptureInterface.EdgeBPinned)
				{
					flag = true;
				}
				if (flag)
				{
					Rectangle? nullable2 = null;
					sb.Draw(Main.cdTexture, vector21 + (new Vector2(26f) * single), nullable2, Color.White * 0.65f, 0f, Main.cdTexture.Size() / 2f, 1f, SpriteEffects.None, 0f);
				}
			}
			string str = "";
			switch (this.HoveredMode)
			{
				case -1:
				{
					int hoveredMode = this.HoveredMode;
					if (hoveredMode != 1)
					{
						switch (hoveredMode)
						{
							case 5:
							{
								if (Main.mapEnabled)
								{
									break;
								}
								str = string.Concat(str, "\n", Lang.inter[114]);
								break;
							}
							case 7:
							{
								if (!Main.graphics.IsFullScreen)
								{
									break;
								}
								str = string.Concat(str, "\n", Lang.inter[113]);
								break;
							}
						}
					}
					else if (!CaptureInterface.EdgeAPinned || !CaptureInterface.EdgeBPinned)
					{
						str = string.Concat(str, "\n", Lang.inter[112]);
					}
					if (str != "")
					{
						Main.instance.MouseText(str, 0, 0);
					}
					return;
				}
				case 0:
				{
					str = Lang.inter[111];
					goto case -1;
				}
				case 1:
				{
					str = Lang.inter[67];
					goto case -1;
				}
				case 2:
				{
					str = Lang.inter[69];
					goto case -1;
				}
				case 3:
				{
					str = Lang.inter[70];
					goto case -1;
				}
				case 4:
				{
					str = Lang.inter[78];
					goto case -1;
				}
				case 5:
				{
					str = (Main.mapFullscreen ? Lang.inter[109] : Lang.inter[108]);
					goto case -1;
				}
				case 6:
				{
					str = Lang.inter[68];
					goto case -1;
				}
				case 7:
				{
					str = Lang.inter[110];
					goto case -1;
				}
				case 8:
				{
					str = Lang.inter[71];
					goto case -1;
				}
				default:
				{
					str = "???";
					goto case -1;
				}
			}
		}

		private void DrawCameraLock(SpriteBatch sb)
		{
			if (CaptureInterface.CameraFrame == 0f)
			{
				return;
			}
			sb.Draw(Main.magicPixel, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), new Rectangle?(new Rectangle(0, 0, 1, 1)), Color.Black * (CaptureInterface.CameraFrame / 5f));
			if (CaptureInterface.CameraFrame != 5f)
			{
				return;
			}
			float cameraWaiting = CaptureInterface.CameraWaiting - 60f + 5f;
			if (cameraWaiting <= 0f)
			{
				return;
			}
			cameraWaiting = cameraWaiting / 5f;
			float progress = CaptureManager.Instance.GetProgress() * 100f;
			if (progress > 100f)
			{
				progress = 100f;
			}
			string str = string.Concat(progress.ToString("##"), " ");
			string str1 = "/ 100%";
			Vector2 vector2 = Main.fontDeathText.MeasureString(str);
			Vector2 vector21 = Main.fontDeathText.MeasureString(str1);
			Vector2 vector22 = new Vector2(-vector2.X, -vector2.Y / 2f);
			Vector2 vector23 = new Vector2(0f, -vector21.Y / 2f);
			ChatManager.DrawColorCodedStringWithShadow(sb, Main.fontDeathText, str, (new Vector2((float)Main.screenWidth, (float)Main.screenHeight) / 2f) + vector22, Color.White * cameraWaiting, 0f, Vector2.Zero, Vector2.One, -1f, 2f);
			ChatManager.DrawColorCodedStringWithShadow(sb, Main.fontDeathText, str1, (new Vector2((float)Main.screenWidth, (float)Main.screenHeight) / 2f) + vector23, Color.White * cameraWaiting, 0f, Vector2.Zero, Vector2.One, -1f, 2f);
		}

		public static void EndCamera()
		{
			CaptureInterface.CameraLock = false;
		}

		private static Dictionary<int, CaptureInterface.CaptureInterfaceMode> FillModes()
		{
			Dictionary<int, CaptureInterface.CaptureInterfaceMode> nums = new Dictionary<int, CaptureInterface.CaptureInterfaceMode>()
			{
				{ 0, new CaptureInterface.ModeEdgeSelection() },
				{ 1, new CaptureInterface.ModeDragBounds() },
				{ 2, new CaptureInterface.ModeChangeSettings() }
			};
			return nums;
		}

		public static Rectangle GetArea()
		{
			int num = Math.Min(CaptureInterface.EdgeA.X, CaptureInterface.EdgeB.X);
			int num1 = Math.Min(CaptureInterface.EdgeA.Y, CaptureInterface.EdgeB.Y);
			int num2 = Math.Abs(CaptureInterface.EdgeA.X - CaptureInterface.EdgeB.X);
			int num3 = Math.Abs(CaptureInterface.EdgeA.Y - CaptureInterface.EdgeB.Y);
			return new Rectangle(num, num1, num2 + 1, num3 + 1);
		}

		private static bool GetMapCoords(int PinX, int PinY, int Goal, out Point result)
		{
			if (!Main.mapFullscreen)
			{
				result = new Point(-1, -1);
				return false;
			}
			float single = 0f;
			float single1 = 0f;
			float single2 = 2f;
			int num = Main.maxTilesX / Main.textureMaxWidth;
			int num1 = Main.maxTilesY / Main.textureMaxHeight;
			float single3 = 10f;
			float single4 = 10f;
			float single5 = (float)(Main.maxTilesX - 10);
			float single6 = (float)(Main.maxTilesY - 10);
			single = 200f;
			single1 = 300f;
			single2 = Main.mapFullscreenScale;
			float single7 = (float)Main.screenWidth / (float)Main.maxTilesX * 0.8f;
			if (Main.mapFullscreenScale < single7)
			{
				Main.mapFullscreenScale = single7;
			}
			if (Main.mapFullscreenScale > 16f)
			{
				Main.mapFullscreenScale = 16f;
			}
			single2 = Main.mapFullscreenScale;
			if (Main.mapFullscreenPos.X < single3)
			{
				Main.mapFullscreenPos.X = single3;
			}
			if (Main.mapFullscreenPos.X > single5)
			{
				Main.mapFullscreenPos.X = single5;
			}
			if (Main.mapFullscreenPos.Y < single4)
			{
				Main.mapFullscreenPos.Y = single4;
			}
			if (Main.mapFullscreenPos.Y > single6)
			{
				Main.mapFullscreenPos.Y = single6;
			}
			float x = Main.mapFullscreenPos.X;
			float y = Main.mapFullscreenPos.Y;
			x = x * single2;
			y = y * single2;
			single = -x + (float)(Main.screenWidth / 2);
			single1 = -y + (float)(Main.screenHeight / 2);
			single = single + single3 * single2;
			single1 = single1 + single4 * single2;
			float single8 = (float)(Main.maxTilesX / 840);
			single8 = single8 * Main.mapFullscreenScale;
			float single9 = single;
			float single10 = single1;
			float width = (float)Main.mapTexture.Width;
			float height = (float)Main.mapTexture.Height;
			if (Main.maxTilesX == 8400)
			{
				single8 = single8 * 0.999f;
				single9 = single9 - 40.6f * single8;
				single10 = single1 - 5f * single8;
				width = width - 8.045f;
				width = width * single8;
				height = height + 0.12f;
				height = height * single8;
				if ((double)single8 < 1.2)
				{
					height = height + 1f;
				}
			}
			else if (Main.maxTilesX == 6400)
			{
				single8 = single8 * 1.09f;
				single9 = single9 - 38.8f * single8;
				single10 = single1 - 3.85f * single8;
				width = width - 13.6f;
				width = width * single8;
				height = height - 6.92f;
				height = height * single8;
				if ((double)single8 < 1.2)
				{
					height = height + 2f;
				}
			}
			else if (Main.maxTilesX == 6300)
			{
				single8 = single8 * 1.09f;
				single9 = single9 - 39.8f * single8;
				single10 = single1 - 4.08f * single8;
				width = width - 26.69f;
				width = width * single8;
				height = height - 6.92f;
				height = height * single8;
				if ((double)single8 < 1.2)
				{
					height = height + 2f;
				}
			}
			else if (Main.maxTilesX == 4200)
			{
				single8 = single8 * 0.998f;
				single9 = single9 - 37.3f * single8;
				single10 = single10 - 1.7f * single8;
				width = width - 16f;
				width = width * single8;
				height = height - 8.31f;
				height = height * single8;
			}
			if (Goal != 0)
			{
				if (Goal != 1)
				{
					result = new Point(-1, -1);
					return false;
				}
				Vector2 vector2 = new Vector2(single, single1);
				Vector2 vector21 = (new Vector2((float)PinX, (float)PinY) * single2) - new Vector2(10f * single2);
				result = (vector2 + vector21).ToPoint();
				return true;
			}
			int pinX = (int)((-single + (float)PinX) / single2 + single3);
			int pinY = (int)((-single1 + (float)PinY) / single2 + single4);
			bool flag = false;
			if ((float)pinX < single3)
			{
				flag = true;
			}
			if ((float)pinX >= single5)
			{
				flag = true;
			}
			if ((float)pinY < single4)
			{
				flag = true;
			}
			if ((float)pinY >= single6)
			{
				flag = true;
			}
			if (!flag)
			{
				result = new Point(pinX, pinY);
				return true;
			}
			result = new Point(-1, -1);
			return false;
		}

		private static void PointWorldClamp(ref Point point, int fluff)
		{
			if (point.X < fluff)
			{
				point.X = fluff;
			}
			if (point.X > Main.maxTilesX - 1 - fluff)
			{
				point.X = Main.maxTilesX - 1 - fluff;
			}
			if (point.Y < fluff)
			{
				point.Y = fluff;
			}
			if (point.Y > Main.maxTilesY - 1 - fluff)
			{
				point.Y = Main.maxTilesY - 1 - fluff;
			}
		}

		public static void ResetFocus()
		{
			CaptureInterface.EdgeAPinned = false;
			CaptureInterface.EdgeBPinned = false;
			CaptureInterface.EdgeA = new Point(-1, -1);
			CaptureInterface.EdgeB = new Point(-1, -1);
		}

		public void Scrolling()
		{
			int scrollWheelValue = (Main.mouseState.ScrollWheelValue - Main.oldMouseWheel) / 120;
			scrollWheelValue = scrollWheelValue % 30;
			if (scrollWheelValue < 0)
			{
				scrollWheelValue = scrollWheelValue + 30;
			}
			int selectedMode = this.SelectedMode;
			CaptureInterface captureInterface = this;
			captureInterface.SelectedMode = captureInterface.SelectedMode - scrollWheelValue;
			while (this.SelectedMode < 0)
			{
				CaptureInterface selectedMode1 = this;
				selectedMode1.SelectedMode = selectedMode1.SelectedMode + 2;
			}
			while (this.SelectedMode > 2)
			{
				CaptureInterface captureInterface1 = this;
				captureInterface1.SelectedMode = captureInterface1.SelectedMode - 2;
			}
			if (this.SelectedMode != selectedMode)
			{
				Main.PlaySound(12, -1, -1, 1);
			}
		}

		public static void StartCamera(CaptureSettings settings)
		{
			Main.PlaySound(40, -1, -1, 1);
			CaptureInterface.CameraSettings = settings;
			CaptureInterface.CameraLock = true;
			CaptureInterface.CameraWaiting = 0f;
		}

		public void ToggleCamera(bool On = true)
		{
			if (CaptureInterface.CameraLock)
			{
				return;
			}
			bool active = this.Active;
			this.Active = (!CaptureInterface.Modes.ContainsKey(this.SelectedMode) ? false : On);
			if (active != this.Active)
			{
				Main.PlaySound(12, -1, -1, 1);
			}
			foreach (KeyValuePair<int, CaptureInterface.CaptureInterfaceMode> mode in CaptureInterface.Modes)
			{
				mode.Value.ToggleActive((!this.Active ? false : mode.Key == this.SelectedMode));
			}
			if (On && !active)
			{
				CaptureInterface.JustActivated = true;
			}
		}

		public void Update()
		{
			this.UpdateCamera();
			if (CaptureInterface.CameraLock)
			{
				return;
			}
			bool flag = Main.keyState.IsKeyDown(Keys.F1);
			if (flag && !this.KeyToggleActiveHeld && (Main.mouseItem.type == 0 || this.Active))
			{
				this.ToggleCamera(!this.Active);
			}
			this.KeyToggleActiveHeld = flag;
			if (!this.Active)
			{
				return;
			}
			Main.blockMouse = true;
			if (CaptureInterface.JustActivated && Main.mouseLeftRelease && !Main.mouseLeft)
			{
				CaptureInterface.JustActivated = false;
			}
			Vector2 vector2 = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			if (this.UpdateButtons(vector2) && Main.mouseLeft)
			{
				return;
			}
			foreach (KeyValuePair<int, CaptureInterface.CaptureInterfaceMode> mode in CaptureInterface.Modes)
			{
				mode.Value.Selected = mode.Key == this.SelectedMode;
				mode.Value.Update();
			}
		}

		private bool UpdateButtons(Vector2 mouse)
		{
			this.HoveredMode = -1;
			bool isFullScreen = !Main.graphics.IsFullScreen;
			int num = 9;
			for (int i = 0; i < num; i++)
			{
				Rectangle rectangle = new Rectangle(24 + 46 * i, 24, 42, 42);
				if (rectangle.Contains(mouse.ToPoint()))
				{
					this.HoveredMode = i;
					bool flag = (!Main.mouseLeft ? false : Main.mouseLeftRelease);
					int num1 = 0;
					int num2 = num1;
					num1 = num2 + 1;
					if (i == num2 && flag)
					{
						CaptureSettings captureSetting = new CaptureSettings();
						Point tileCoordinates = Main.screenPosition.ToTileCoordinates();
						Point point = (Main.screenPosition + new Vector2((float)Main.screenWidth, (float)Main.screenHeight)).ToTileCoordinates();
						captureSetting.Area = new Rectangle(tileCoordinates.X, tileCoordinates.Y, point.X - tileCoordinates.X + 1, point.Y - tileCoordinates.Y + 1);
						captureSetting.Biome = CaptureBiome.Biomes[CaptureInterface.Settings.BiomeChoice];
						captureSetting.CaptureBackground = !CaptureInterface.Settings.TransparentBackground;
						captureSetting.CaptureEntities = CaptureInterface.Settings.IncludeEntities;
						captureSetting.UseScaling = CaptureInterface.Settings.PackImage;
						CaptureInterface.StartCamera(captureSetting);
					}
					int num3 = num1;
					num1 = num3 + 1;
					if (i == num3 && flag && CaptureInterface.EdgeAPinned && CaptureInterface.EdgeBPinned)
					{
						CaptureSettings captureSetting1 = new CaptureSettings()
						{
							Area = CaptureInterface.GetArea(),
							Biome = CaptureBiome.Biomes[CaptureInterface.Settings.BiomeChoice],
							CaptureBackground = !CaptureInterface.Settings.TransparentBackground,
							CaptureEntities = CaptureInterface.Settings.IncludeEntities,
							UseScaling = CaptureInterface.Settings.PackImage
						};
						CaptureInterface.StartCamera(captureSetting1);
					}
					int num4 = num1;
					num1 = num4 + 1;
					if (i == num4 && flag && this.SelectedMode != 0)
					{
						this.SelectedMode = 0;
						this.ToggleCamera(true);
					}
					int num5 = num1;
					num1 = num5 + 1;
					if (i == num5 && flag && this.SelectedMode != 1)
					{
						this.SelectedMode = 1;
						this.ToggleCamera(true);
					}
					int num6 = num1;
					num1 = num6 + 1;
					if (i == num6 && flag)
					{
						CaptureInterface.ResetFocus();
					}
					int num7 = num1;
					num1 = num7 + 1;
					if (i == num7 && flag && Main.mapEnabled)
					{
						Main.mapFullscreen = !Main.mapFullscreen;
					}
					int num8 = num1;
					num1 = num8 + 1;
					if (i == num8 && flag && this.SelectedMode != 2)
					{
						this.SelectedMode = 2;
						this.ToggleCamera(true);
					}
					int num9 = num1;
					num1 = num9 + 1;
					if (i == num9 && flag && isFullScreen)
					{
						object[] savePath = new object[] { Main.SavePath, Path.DirectorySeparatorChar, "Captures", Path.DirectorySeparatorChar };
						Process.Start(string.Concat(savePath));
					}
					int num10 = num1;
					num1 = num10 + 1;
					if (i == num10 && flag)
					{
						this.ToggleCamera(false);
						Main.blockMouse = true;
						Main.mouseLeftRelease = false;
					}
					return true;
				}
			}
			return false;
		}

		private void UpdateCamera()
		{
			if (CaptureInterface.CameraLock && CaptureInterface.CameraFrame == 4f)
			{
				CaptureManager.Instance.Capture(CaptureInterface.CameraSettings);
			}
			CaptureInterface.CameraFrame = CaptureInterface.CameraFrame + (float)CaptureInterface.CameraLock.ToDirectionInt();
			if (CaptureInterface.CameraFrame < 0f)
			{
				CaptureInterface.CameraFrame = 0f;
			}
			if (CaptureInterface.CameraFrame > 5f)
			{
				CaptureInterface.CameraFrame = 5f;
			}
			if (CaptureInterface.CameraFrame == 5f)
			{
				CaptureInterface.CameraWaiting = CaptureInterface.CameraWaiting + 1f;
			}
			if (CaptureInterface.CameraWaiting > 60f)
			{
				CaptureInterface.CameraWaiting = 60f;
			}
		}

		public bool UsingMap()
		{
			if (CaptureInterface.CameraLock)
			{
				return true;
			}
			return CaptureInterface.Modes[this.SelectedMode].UsingMap();
		}

		private abstract class CaptureInterfaceMode
		{
			public bool Selected;

			protected CaptureInterfaceMode()
			{
			}

			public abstract void Draw(SpriteBatch sb);

			public abstract void ToggleActive(bool tickedOn);

			public abstract void Update();

			public abstract bool UsingMap();
		}

		private class ModeChangeSettings : CaptureInterface.CaptureInterfaceMode
		{
			private const int ButtonsCount = 7;

			private int hoveredButton;

			private bool inUI;

			public ModeChangeSettings()
			{
			}

			private int BiomeWater(int index)
			{
				switch (index)
				{
					case 0:
					{
						return 0;
					}
					case 1:
					{
						return 2;
					}
					case 2:
					{
						return 3;
					}
					case 3:
					{
						return 4;
					}
					case 4:
					{
						return 5;
					}
					case 5:
					{
						return 6;
					}
					case 6:
					{
						return 7;
					}
					case 7:
					{
						return 8;
					}
					case 8:
					{
						return 9;
					}
					case 9:
					{
						return 10;
					}
				}
				return 0;
			}

			private void ButtonDraw(int button, ref string key, ref string value)
			{
				switch (button)
				{
					case 0:
					{
						key = Lang.inter[74];
						value = Lang.inter[73 - CaptureInterface.Settings.PackImage.ToInt()];
						return;
					}
					case 1:
					{
						key = Lang.inter[75];
						value = Lang.inter[73 - CaptureInterface.Settings.IncludeEntities.ToInt()];
						return;
					}
					case 2:
					{
						key = Lang.inter[76];
						value = Lang.inter[73 - (!CaptureInterface.Settings.TransparentBackground).ToInt()];
						return;
					}
					case 3:
					case 4:
					case 5:
					{
						return;
					}
					case 6:
					{
						key = string.Concat("      ", Lang.menu[86]);
						value = "";
						return;
					}
					default:
					{
						return;
					}
				}
			}

			public override void Draw(SpriteBatch sb)
			{
				if (!this.Selected)
				{
					return;
				}
				((CaptureInterface.ModeDragBounds)CaptureInterface.Modes[1]).currentAim = -1;
				((CaptureInterface.ModeDragBounds)CaptureInterface.Modes[1]).DrawMarkedArea(sb);
				Rectangle rect = this.GetRect();
				Utils.DrawInvBG(sb, rect, new Color(63, 65, 151, 255) * 0.485f);
				for (int i = 0; i < 7; i++)
				{
					string str = "";
					string str1 = "";
					this.ButtonDraw(i, ref str, ref str1);
					Color white = Color.White;
					if (i == this.hoveredButton)
					{
						white = Color.Gold;
					}
					ChatManager.DrawColorCodedStringWithShadow(sb, Main.fontItemStack, str, rect.TopLeft() + new Vector2(20f, (float)(20 + 20 * i)), white, 0f, Vector2.Zero, Vector2.One, -1f, 2f);
					ChatManager.DrawColorCodedStringWithShadow(sb, Main.fontItemStack, str1, rect.TopRight() + new Vector2(-20f, (float)(20 + 20 * i)), white, 0f, Main.fontItemStack.MeasureString(str1) * Vector2.UnitX, Vector2.One, -1f, 2f);
				}
				this.DrawWaterChoices(sb, (rect.TopLeft() + new Vector2((float)(rect.Width / 2 - 58), 90f)).ToPoint(), Main.MouseScreen.ToPoint());
			}

			private void DrawWaterChoices(SpriteBatch spritebatch, Point start, Point mouse)
			{
				Rectangle rectangle = new Rectangle(0, 0, 20, 20);
				for (int i = 0; i < 2; i++)
				{
					for (int j = 0; j < 5; j++)
					{
						if (i != 1 || j != 3)
						{
							int num = j + i * 5;
							rectangle.X = start.X + 24 * j + 12 * i;
							rectangle.Y = start.Y + 24 * i;
							if (i == 1 && j == 4)
							{
								rectangle.X = rectangle.X - 24;
							}
							int num1 = 0;
							if (rectangle.Contains(mouse))
							{
								if (Main.mouseLeft && Main.mouseLeftRelease)
								{
									CaptureInterface.Settings.BiomeChoice = this.BiomeWater(num);
								}
								num1++;
							}
							if (CaptureInterface.Settings.BiomeChoice == this.BiomeWater(num))
							{
								num1 = num1 + 2;
							}
							Texture2D texture2D = Main.liquidTexture[this.BiomeWater(num)];
							int num2 = (int)Main.wFrame * 18;
							Color white = Color.White;
							float single = 1f;
							if (num1 < 2)
							{
								single = single * 0.5f;
							}
							if (num1 % 2 != 1)
							{
								spritebatch.Draw(Main.magicPixel, rectangle.TopLeft(), new Rectangle?(new Rectangle(0, 0, 1, 1)), Color.White * single, 0f, Vector2.Zero, new Vector2(20f), SpriteEffects.None, 0f);
							}
							else
							{
								spritebatch.Draw(Main.magicPixel, rectangle.TopLeft(), new Rectangle?(new Rectangle(0, 0, 1, 1)), Color.Gold, 0f, Vector2.Zero, new Vector2(20f), SpriteEffects.None, 0f);
							}
							spritebatch.Draw(texture2D, rectangle.TopLeft() + new Vector2(2f), new Rectangle?(new Rectangle(num2, 0, 16, 16)), Color.White * single);
						}
					}
				}
			}

			private Rectangle GetRect()
			{
				Rectangle rectangle = new Rectangle(0, 0, 224, 170);
				if (CaptureInterface.Settings.ScreenAnchor == 0)
				{
					rectangle.X = 227 - rectangle.Width / 2;
					rectangle.Y = 80;
					int num = 0;
					Player player = Main.player[Main.myPlayer];
					while (num < (int)player.buffTime.Length && player.buffTime[num] > 0)
					{
						num++;
					}
					int num1 = num / 11 + (num % 11 >= 3 ? 1 : 0);
					rectangle.Y = rectangle.Y + 48 * num1;
				}
				return rectangle;
			}

			private void PressButton(int button)
			{
				switch (button)
				{
					case 0:
					{
						CaptureInterface.Settings.PackImage = !CaptureInterface.Settings.PackImage;
						return;
					}
					case 1:
					{
						CaptureInterface.Settings.IncludeEntities = !CaptureInterface.Settings.IncludeEntities;
						return;
					}
					case 2:
					{
						CaptureInterface.Settings.TransparentBackground = !CaptureInterface.Settings.TransparentBackground;
						return;
					}
					case 3:
					case 4:
					case 5:
					{
						return;
					}
					case 6:
					{
						CaptureInterface.Settings.PackImage = false;
						CaptureInterface.Settings.IncludeEntities = true;
						CaptureInterface.Settings.TransparentBackground = false;
						CaptureInterface.Settings.BiomeChoice = 0;
						return;
					}
					default:
					{
						return;
					}
				}
			}

			public override void ToggleActive(bool tickedOn)
			{
				if (tickedOn)
				{
					this.hoveredButton = -1;
				}
			}

			public override void Update()
			{
				if (!this.Selected)
				{
					return;
				}
				if (CaptureInterface.JustActivated)
				{
					return;
				}
				Point point = new Point(Main.mouseX, Main.mouseY);
				this.hoveredButton = -1;
				Rectangle rect = this.GetRect();
				this.inUI = rect.Contains(point);
				rect.Inflate(-20, -20);
				rect.Height = 16;
				int y = rect.Y;
				int num = 0;
				while (num < 7)
				{
					rect.Y = y + num * 20;
					if (!rect.Contains(point))
					{
						num++;
					}
					else
					{
						this.hoveredButton = num;
						break;
					}
				}
				if (Main.mouseLeft && Main.mouseLeftRelease && this.hoveredButton != -1)
				{
					this.PressButton(this.hoveredButton);
				}
			}

			public override bool UsingMap()
			{
				return this.inUI;
			}
		}

		private class ModeDragBounds : CaptureInterface.CaptureInterfaceMode
		{
			public int currentAim;

			private bool dragging;

			private int caughtEdge;

			private bool inMap;

			public ModeDragBounds()
			{
			}

			private void DragBounds(Vector2 mouse)
			{
				Point tileCoordinates;
				Rectangle rectangle;
				Rectangle rectangle1;
				Rectangle rectangle2;
				Point point;
				Point point1;
				Point point2;
				if (!CaptureInterface.EdgeAPinned || !CaptureInterface.EdgeBPinned)
				{
					bool flag = false;
					if (Main.mouseLeft)
					{
						flag = true;
					}
					if (flag)
					{
						bool mapCoords = true;
						if (Main.mapFullscreen)
						{
							mapCoords = CaptureInterface.GetMapCoords((int)mouse.X, (int)mouse.Y, 0, out tileCoordinates);
						}
						else
						{
							tileCoordinates = (Main.screenPosition + mouse).ToTileCoordinates();
						}
						if (mapCoords)
						{
							if (!CaptureInterface.EdgeAPinned)
							{
								CaptureInterface.EdgeAPinned = true;
								CaptureInterface.EdgeA = tileCoordinates;
							}
							if (!CaptureInterface.EdgeBPinned)
							{
								CaptureInterface.EdgeBPinned = true;
								CaptureInterface.EdgeB = tileCoordinates;
							}
						}
						this.currentAim = 3;
						this.caughtEdge = 1;
					}
				}
				int num = Math.Min(CaptureInterface.EdgeA.X, CaptureInterface.EdgeB.X);
				int num1 = Math.Min(CaptureInterface.EdgeA.Y, CaptureInterface.EdgeB.Y);
				int num2 = Math.Abs(CaptureInterface.EdgeA.X - CaptureInterface.EdgeB.X);
				int num3 = Math.Abs(CaptureInterface.EdgeA.Y - CaptureInterface.EdgeB.Y);
				bool flag1 = Main.player[Main.myPlayer].gravDir == -1f;
				int num4 = 1 - flag1.ToInt();
				int num5 = flag1.ToInt();
				if (Main.mapFullscreen)
				{
					CaptureInterface.GetMapCoords(num, num1, 1, out point);
					CaptureInterface.GetMapCoords(num + num2 + 1, num1 + num3 + 1, 1, out point1);
					rectangle2 = new Rectangle(point.X, point.Y, point1.X - point.X, point1.Y - point.Y);
					rectangle1 = new Rectangle(0, 0, Main.screenWidth + 1, Main.screenHeight + 1);
					Rectangle.Intersect(ref rectangle1, ref rectangle2, out rectangle);
					if (rectangle.Width == 0 || rectangle.Height == 0)
					{
						return;
					}
					rectangle.Offset(-rectangle1.X, -rectangle1.Y);
				}
				else
				{
					rectangle2 = Main.ReverseGravitySupport(new Rectangle(num * 16, num1 * 16, (num2 + 1) * 16, (num3 + 1) * 16));
					rectangle1 = Main.ReverseGravitySupport(new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth + 1, Main.screenHeight + 1));
					Rectangle.Intersect(ref rectangle1, ref rectangle2, out rectangle);
					if (rectangle.Width == 0 || rectangle.Height == 0)
					{
						return;
					}
					rectangle.Offset(-rectangle1.X, -rectangle1.Y);
				}
				this.dragging = false;
				if (!Main.mouseLeft)
				{
					this.currentAim = -1;
				}
				if (this.currentAim == -1)
				{
					this.caughtEdge = -1;
					Rectangle rectangle3 = rectangle2;
					rectangle3.Offset(-rectangle1.X, -rectangle1.Y);
					this.inMap = rectangle3.Contains(mouse.ToPoint());
					int num6 = 0;
					while (num6 < 4)
					{
						Rectangle bound = this.GetBound(rectangle3, num6);
						bound.Inflate(8, 8);
						if (!bound.Contains(mouse.ToPoint()))
						{
							num6++;
						}
						else
						{
							this.currentAim = num6;
							if (num6 == 0)
							{
								if (CaptureInterface.EdgeA.Y >= CaptureInterface.EdgeB.Y)
								{
									this.caughtEdge = num4;
									break;
								}
								else
								{
									this.caughtEdge = num5;
									break;
								}
							}
							else if (num6 == 1)
							{
								if (CaptureInterface.EdgeA.Y < CaptureInterface.EdgeB.Y)
								{
									this.caughtEdge = num4;
									break;
								}
								else
								{
									this.caughtEdge = num5;
									break;
								}
							}
							else if (num6 != 2)
							{
								if (num6 != 3)
								{
									break;
								}
								if (CaptureInterface.EdgeA.X < CaptureInterface.EdgeB.X)
								{
									this.caughtEdge = 1;
									break;
								}
								else
								{
									this.caughtEdge = 0;
									break;
								}
							}
							else if (CaptureInterface.EdgeA.X >= CaptureInterface.EdgeB.X)
							{
								this.caughtEdge = 1;
								break;
							}
							else
							{
								this.caughtEdge = 0;
								break;
							}
						}
					}
				}
				else
				{
					this.dragging = true;
					Point tileCoordinates1 = new Point();
					if (Main.mapFullscreen)
					{
						if (!CaptureInterface.GetMapCoords((int)mouse.X, (int)mouse.Y, 0, out point2))
						{
							return;
						}
						tileCoordinates1 = point2;
					}
					else
					{
						tileCoordinates1 = Main.MouseWorld.ToTileCoordinates();
					}
					switch (this.currentAim)
					{
						case 0:
						case 1:
						{
							if (this.caughtEdge == 0)
							{
								CaptureInterface.EdgeA.Y = tileCoordinates1.Y;
							}
							if (this.caughtEdge != 1)
							{
								break;
							}
							CaptureInterface.EdgeB.Y = tileCoordinates1.Y;
							break;
						}
						case 2:
						case 3:
						{
							if (this.caughtEdge == 0)
							{
								CaptureInterface.EdgeA.X = tileCoordinates1.X;
							}
							if (this.caughtEdge != 1)
							{
								break;
							}
							CaptureInterface.EdgeB.X = tileCoordinates1.X;
							break;
						}
					}
				}
				CaptureInterface.ConstraintPoints();
			}

			public override void Draw(SpriteBatch sb)
			{
				if (!this.Selected)
				{
					return;
				}
				this.DrawMarkedArea(sb);
			}

			private void DrawBound(SpriteBatch sb, Rectangle r, int mode)
			{
				if (mode == 0)
				{
					sb.Draw(Main.magicPixel, r, Color.Silver);
					return;
				}
				if (mode == 1)
				{
					Rectangle rectangle = new Rectangle(r.X - 2, r.Y, r.Width + 4, r.Height);
					sb.Draw(Main.magicPixel, rectangle, Color.White);
					rectangle = new Rectangle(r.X, r.Y - 2, r.Width, r.Height + 4);
					sb.Draw(Main.magicPixel, rectangle, Color.White);
					sb.Draw(Main.magicPixel, r, Color.White);
					return;
				}
				if (mode == 2)
				{
					Rectangle rectangle1 = new Rectangle(r.X - 2, r.Y, r.Width + 4, r.Height);
					sb.Draw(Main.magicPixel, rectangle1, Color.Gold);
					rectangle1 = new Rectangle(r.X, r.Y - 2, r.Width, r.Height + 4);
					sb.Draw(Main.magicPixel, rectangle1, Color.Gold);
					sb.Draw(Main.magicPixel, r, Color.Gold);
				}
			}

			public void DrawMarkedArea(SpriteBatch sb)
			{
				Rectangle rectangle;
				Rectangle rectangle1;
				Rectangle rectangle2;
				Point point;
				Point point1;
				if (!CaptureInterface.EdgeAPinned || !CaptureInterface.EdgeBPinned)
				{
					return;
				}
				int num = Math.Min(CaptureInterface.EdgeA.X, CaptureInterface.EdgeB.X);
				int num1 = Math.Min(CaptureInterface.EdgeA.Y, CaptureInterface.EdgeB.Y);
				int num2 = Math.Abs(CaptureInterface.EdgeA.X - CaptureInterface.EdgeB.X);
				int num3 = Math.Abs(CaptureInterface.EdgeA.Y - CaptureInterface.EdgeB.Y);
				if (Main.mapFullscreen)
				{
					CaptureInterface.GetMapCoords(num, num1, 1, out point);
					CaptureInterface.GetMapCoords(num + num2 + 1, num1 + num3 + 1, 1, out point1);
					rectangle = new Rectangle(point.X, point.Y, point1.X - point.X, point1.Y - point.Y);
					rectangle1 = new Rectangle(0, 0, Main.screenWidth + 1, Main.screenHeight + 1);
					Rectangle.Intersect(ref rectangle1, ref rectangle, out rectangle2);
					if (rectangle2.Width == 0 || rectangle2.Height == 0)
					{
						return;
					}
					rectangle2.Offset(-rectangle1.X, -rectangle1.Y);
				}
				else
				{
					rectangle = Main.ReverseGravitySupport(new Rectangle(num * 16, num1 * 16, (num2 + 1) * 16, (num3 + 1) * 16));
					rectangle1 = Main.ReverseGravitySupport(new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth + 1, Main.screenHeight + 1));
					Rectangle.Intersect(ref rectangle1, ref rectangle, out rectangle2);
					if (rectangle2.Width == 0 || rectangle2.Height == 0)
					{
						return;
					}
					rectangle2.Offset(-rectangle1.X, -rectangle1.Y);
				}
				sb.Draw(Main.magicPixel, rectangle2, CaptureInterface.Settings.MarkedAreaColor);
				Rectangle empty = Rectangle.Empty;
				for (int i = 0; i < 2; i++)
				{
					if (this.currentAim == i)
					{
						empty = new Rectangle(rectangle2.X, rectangle2.Y + (i == 1 ? rectangle2.Height : -2), rectangle2.Width, 2);
					}
					else
					{
						this.DrawBound(sb, new Rectangle(rectangle2.X, rectangle2.Y + (i == 1 ? rectangle2.Height : -2), rectangle2.Width, 2), 0);
					}
					if (this.currentAim == i + 2)
					{
						empty = new Rectangle(rectangle2.X + (i == 1 ? rectangle2.Width : -2), rectangle2.Y, 2, rectangle2.Height);
					}
					else
					{
						this.DrawBound(sb, new Rectangle(rectangle2.X + (i == 1 ? rectangle2.Width : -2), rectangle2.Y, 2, rectangle2.Height), 0);
					}
				}
				if (empty != Rectangle.Empty)
				{
					this.DrawBound(sb, empty, 1 + this.dragging.ToInt());
				}
			}

			private Rectangle GetBound(Rectangle drawbox, int boundIndex)
			{
				if (boundIndex == 0)
				{
					return new Rectangle(drawbox.X, drawbox.Y - 2, drawbox.Width, 2);
				}
				if (boundIndex == 1)
				{
					return new Rectangle(drawbox.X, drawbox.Y + drawbox.Height, drawbox.Width, 2);
				}
				if (boundIndex == 2)
				{
					return new Rectangle(drawbox.X - 2, drawbox.Y, 2, drawbox.Height);
				}
				if (boundIndex != 3)
				{
					return Rectangle.Empty;
				}
				return new Rectangle(drawbox.X + drawbox.Width, drawbox.Y, 2, drawbox.Height);
			}

			public override void ToggleActive(bool tickedOn)
			{
				if (!tickedOn)
				{
					this.currentAim = -1;
				}
			}

			public override void Update()
			{
				if (!this.Selected)
				{
					return;
				}
				if (CaptureInterface.JustActivated)
				{
					return;
				}
				Vector2 vector2 = new Vector2((float)Main.mouseX, (float)Main.mouseY);
				this.DragBounds(vector2);
			}

			public override bool UsingMap()
			{
				return this.caughtEdge != -1;
			}
		}

		private class ModeEdgeSelection : CaptureInterface.CaptureInterfaceMode
		{
			public ModeEdgeSelection()
			{
			}

			public override void Draw(SpriteBatch sb)
			{
				if (!this.Selected)
				{
					return;
				}
				this.DrawMarkedArea(sb);
				this.DrawCursors(sb);
			}

			private void DrawCursors(SpriteBatch sb)
			{
				float single = 1f / Main.cursorScale;
				float single1 = 0.8f / single;
				Vector2 vector2 = Main.screenPosition + new Vector2(30f);
				Vector2 vector21 = (vector2 + new Vector2((float)Main.screenWidth, (float)Main.screenHeight)) - new Vector2(60f);
				if (Main.mapFullscreen)
				{
					vector2 = vector2 - Main.screenPosition;
					vector21 = vector21 - Main.screenPosition;
				}
				Vector3 hsl = Main.rgbToHsl(Main.cursorColor);
				Color rgb = Main.hslToRgb((hsl.X + 0.33f) % 1f, hsl.Y, hsl.Z);
				Color color = Main.hslToRgb((hsl.X - 0.33f) % 1f, hsl.Y, hsl.Z);
				Color white = Color.White;
				color = white;
				rgb = white;
				bool flag = Main.player[Main.myPlayer].gravDir == -1f;
				if (CaptureInterface.EdgeAPinned)
				{
					int num = 0;
					float rotation = 0f;
					Vector2 zero = Vector2.Zero;
					if (Main.mapFullscreen)
					{
						Point edgeA = CaptureInterface.EdgeA;
						if (!CaptureInterface.EdgeBPinned)
						{
							CaptureInterface.GetMapCoords(edgeA.X, edgeA.Y, 1, out edgeA);
						}
						else
						{
							int num1 = (CaptureInterface.EdgeA.X > CaptureInterface.EdgeB.X).ToInt();
							int num2 = (CaptureInterface.EdgeA.Y > CaptureInterface.EdgeB.Y).ToInt();
							edgeA.X = edgeA.X + num1;
							edgeA.Y = edgeA.Y + num2;
							CaptureInterface.GetMapCoords(edgeA.X, edgeA.Y, 1, out edgeA);
							Point edgeB = CaptureInterface.EdgeB;
							edgeB.X = edgeB.X + (1 - num1);
							edgeB.Y = edgeB.Y + (1 - num2);
							CaptureInterface.GetMapCoords(edgeB.X, edgeB.Y, 1, out edgeB);
							zero = edgeA.ToVector2();
							zero = Vector2.Clamp(zero, vector2, vector21);
							rotation = (edgeB.ToVector2() - zero).ToRotation();
						}
						Utils.DrawCursorSingle(sb, rgb, rotation - 1.57079637f, Main.cursorScale * single, edgeA.ToVector2(), 4, 0);
					}
					else
					{
						Vector2 one = CaptureInterface.EdgeA.ToVector2() * 16f;
						if (CaptureInterface.EdgeBPinned)
						{
							Vector2 vector22 = new Vector2((float)((CaptureInterface.EdgeA.X > CaptureInterface.EdgeB.X).ToInt() * 16), (float)((CaptureInterface.EdgeA.Y > CaptureInterface.EdgeB.Y).ToInt() * 16));
							one = one + vector22;
							zero = Vector2.Clamp(one, vector2, vector21);
							rotation = ((((CaptureInterface.EdgeB.ToVector2() * 16f) + new Vector2(16f)) - vector22) - zero).ToRotation();
							if (zero != one)
							{
								rotation = (one - zero).ToRotation();
								num = 1;
							}
							if (flag)
							{
								rotation = rotation * -1f;
							}
						}
						else
						{
							num = 1;
							one = one + (Vector2.One * 8f);
							zero = one;
							rotation = ((-one + Main.ReverseGravitySupport(new Vector2((float)Main.mouseX, (float)Main.mouseY), 0f)) + Main.screenPosition).ToRotation();
							if (flag)
							{
								rotation = -rotation;
							}
							zero = Vector2.Clamp(one, vector2, vector21);
							if (zero != one)
							{
								rotation = (one - zero).ToRotation();
							}
						}
						Utils.DrawCursorSingle(sb, rgb, rotation - 1.57079637f, Main.cursorScale * single, Main.ReverseGravitySupport(zero - Main.screenPosition, 0f), 4, num);
					}
				}
				else
				{
					Utils.DrawCursorSingle(sb, rgb, 3.926991f, Main.cursorScale * single * single1, new Vector2((float)Main.mouseX - 5f + 12f, (float)Main.mouseY + 2.5f + 12f), 4, 0);
				}
				if (!CaptureInterface.EdgeBPinned)
				{
					Utils.DrawCursorSingle(sb, color, 0.7853982f, Main.cursorScale * single * single1, new Vector2((float)Main.mouseX + 2.5f + 12f, (float)Main.mouseY - 5f + 12f), 5, 0);
					return;
				}
				int num3 = 0;
				float rotation1 = 0f;
				Vector2 zero1 = Vector2.Zero;
				if (Main.mapFullscreen)
				{
					Point x = CaptureInterface.EdgeB;
					if (!CaptureInterface.EdgeAPinned)
					{
						CaptureInterface.GetMapCoords(x.X, x.Y, 1, out x);
					}
					else
					{
						int num4 = (CaptureInterface.EdgeB.X >= CaptureInterface.EdgeA.X).ToInt();
						int num5 = (CaptureInterface.EdgeB.Y >= CaptureInterface.EdgeA.Y).ToInt();
						x.X = x.X + num4;
						x.Y = x.Y + num5;
						CaptureInterface.GetMapCoords(x.X, x.Y, 1, out x);
						Point y = CaptureInterface.EdgeA;
						y.X = y.X + (1 - num4);
						y.Y = y.Y + (1 - num5);
						CaptureInterface.GetMapCoords(y.X, y.Y, 1, out y);
						zero1 = x.ToVector2();
						zero1 = Vector2.Clamp(zero1, vector2, vector21);
						rotation1 = (y.ToVector2() - zero1).ToRotation();
					}
					Utils.DrawCursorSingle(sb, color, rotation1 - 1.57079637f, Main.cursorScale * single, x.ToVector2(), 5, 0);
					return;
				}
				Vector2 one1 = CaptureInterface.EdgeB.ToVector2() * 16f;
				if (CaptureInterface.EdgeAPinned)
				{
					Vector2 vector23 = new Vector2((float)((CaptureInterface.EdgeB.X >= CaptureInterface.EdgeA.X).ToInt() * 16), (float)((CaptureInterface.EdgeB.Y >= CaptureInterface.EdgeA.Y).ToInt() * 16));
					one1 = one1 + vector23;
					zero1 = Vector2.Clamp(one1, vector2, vector21);
					rotation1 = ((((CaptureInterface.EdgeA.ToVector2() * 16f) + new Vector2(16f)) - vector23) - zero1).ToRotation();
					if (zero1 != one1)
					{
						rotation1 = (one1 - zero1).ToRotation();
						num3 = 1;
					}
					if (flag)
					{
						rotation1 = rotation1 * -1f;
					}
				}
				else
				{
					num3 = 1;
					one1 = one1 + (Vector2.One * 8f);
					zero1 = one1;
					rotation1 = ((-one1 + Main.ReverseGravitySupport(new Vector2((float)Main.mouseX, (float)Main.mouseY), 0f)) + Main.screenPosition).ToRotation();
					if (flag)
					{
						rotation1 = -rotation1;
					}
					zero1 = Vector2.Clamp(one1, vector2, vector21);
					if (zero1 != one1)
					{
						rotation1 = (one1 - zero1).ToRotation();
					}
				}
				Utils.DrawCursorSingle(sb, color, rotation1 - 1.57079637f, Main.cursorScale * single, Main.ReverseGravitySupport(zero1 - Main.screenPosition, 0f), 5, num3);
			}

			private void DrawMarkedArea(SpriteBatch sb)
			{
				Rectangle rectangle;
				Point point;
				Point point1;
				Rectangle rectangle1;
				if (!CaptureInterface.EdgeAPinned || !CaptureInterface.EdgeBPinned)
				{
					return;
				}
				int num = Math.Min(CaptureInterface.EdgeA.X, CaptureInterface.EdgeB.X);
				int num1 = Math.Min(CaptureInterface.EdgeA.Y, CaptureInterface.EdgeB.Y);
				int num2 = Math.Abs(CaptureInterface.EdgeA.X - CaptureInterface.EdgeB.X);
				int num3 = Math.Abs(CaptureInterface.EdgeA.Y - CaptureInterface.EdgeB.Y);
				if (!Main.mapFullscreen)
				{
					Rectangle rectangle2 = Main.ReverseGravitySupport(new Rectangle(num * 16, num1 * 16, (num2 + 1) * 16, (num3 + 1) * 16));
					Rectangle rectangle3 = Main.ReverseGravitySupport(new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth + 1, Main.screenHeight + 1));
					Rectangle.Intersect(ref rectangle3, ref rectangle2, out rectangle);
					if (rectangle.Width == 0 || rectangle.Height == 0)
					{
						return;
					}
					rectangle.Offset(-rectangle3.X, -rectangle3.Y);
					sb.Draw(Main.magicPixel, rectangle, CaptureInterface.Settings.MarkedAreaColor);
					for (int i = 0; i < 2; i++)
					{
						sb.Draw(Main.magicPixel, new Rectangle(rectangle.X, rectangle.Y + (i == 1 ? rectangle.Height : -2), rectangle.Width, 2), Color.White);
						sb.Draw(Main.magicPixel, new Rectangle(rectangle.X + (i == 1 ? rectangle.Width : -2), rectangle.Y, 2, rectangle.Height), Color.White);
					}
					return;
				}
				CaptureInterface.GetMapCoords(num, num1, 1, out point);
				CaptureInterface.GetMapCoords(num + num2 + 1, num1 + num3 + 1, 1, out point1);
				Rectangle rectangle4 = new Rectangle(point.X, point.Y, point1.X - point.X, point1.Y - point.Y);
				Rectangle rectangle5 = new Rectangle(0, 0, Main.screenWidth + 1, Main.screenHeight + 1);
				Rectangle.Intersect(ref rectangle5, ref rectangle4, out rectangle1);
				if (rectangle1.Width == 0 || rectangle1.Height == 0)
				{
					return;
				}
				rectangle1.Offset(-rectangle5.X, -rectangle5.Y);
				sb.Draw(Main.magicPixel, rectangle1, CaptureInterface.Settings.MarkedAreaColor);
				for (int j = 0; j < 2; j++)
				{
					sb.Draw(Main.magicPixel, new Rectangle(rectangle1.X, rectangle1.Y + (j == 1 ? rectangle1.Height : -2), rectangle1.Width, 2), Color.White);
					sb.Draw(Main.magicPixel, new Rectangle(rectangle1.X + (j == 1 ? rectangle1.Width : -2), rectangle1.Y, 2, rectangle1.Height), Color.White);
				}
			}

			private void EdgePlacement(Vector2 mouse)
			{
				Point point;
				if (CaptureInterface.JustActivated)
				{
					return;
				}
				if (!Main.mapFullscreen)
				{
					if (Main.mouseLeft)
					{
						CaptureInterface.EdgeAPinned = true;
						CaptureInterface.EdgeA = Main.MouseWorld.ToTileCoordinates();
					}
					if (Main.mouseRight)
					{
						CaptureInterface.EdgeBPinned = true;
						CaptureInterface.EdgeB = Main.MouseWorld.ToTileCoordinates();
					}
				}
				else if (CaptureInterface.GetMapCoords((int)mouse.X, (int)mouse.Y, 0, out point))
				{
					if (Main.mouseLeft)
					{
						CaptureInterface.EdgeAPinned = true;
						CaptureInterface.EdgeA = point;
					}
					if (Main.mouseRight)
					{
						CaptureInterface.EdgeBPinned = true;
						CaptureInterface.EdgeB = point;
					}
				}
				CaptureInterface.ConstraintPoints();
			}

			public override void ToggleActive(bool tickedOn)
			{
			}

			public override void Update()
			{
				if (!this.Selected)
				{
					return;
				}
				Vector2 vector2 = new Vector2((float)Main.mouseX, (float)Main.mouseY);
				this.EdgePlacement(vector2);
			}

			public override bool UsingMap()
			{
				return true;
			}
		}

		public static class Settings
		{
			public static bool PackImage;

			public static bool IncludeEntities;

			public static bool TransparentBackground;

			public static int BiomeChoice;

			public static int ScreenAnchor;

			public static Color MarkedAreaColor;

			static Settings()
			{
				CaptureInterface.Settings.PackImage = true;
				CaptureInterface.Settings.IncludeEntities = true;
				CaptureInterface.Settings.TransparentBackground = false;
				CaptureInterface.Settings.BiomeChoice = 0;
				CaptureInterface.Settings.ScreenAnchor = 0;
				CaptureInterface.Settings.MarkedAreaColor = new Color(0.8f, 0.8f, 0.8f, 0f) * 0.3f;
			}
		}
	}
}