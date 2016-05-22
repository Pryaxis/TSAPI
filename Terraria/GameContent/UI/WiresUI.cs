using System;

namespace Terraria.GameContent.UI
{
	// Token: 0x02000126 RID: 294
	public class WiresUI
	{
		// Token: 0x170000B5 RID: 181
		public static bool Open
		{
			// Token: 0x06000B50 RID: 2896 RVA: 0x001FAF53 File Offset: 0x001F9153
			get
			{
				return WiresUI.radial.active;
			}
		}

		// Token: 0x0400129E RID: 4766
		private static WiresUI.WiresRadial radial = new WiresUI.WiresRadial();

		// Token: 0x02000127 RID: 295
		public static class Settings
		{
			// Token: 0x170000B9 RID: 185
			public static bool DrawToolAllowActuators
			{
				// Token: 0x06000B57 RID: 2903 RVA: 0x001FB064 File Offset: 0x001F9264
				get
				{
					int type = Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type;
					if (type == 3611)
					{
						WiresUI.Settings._lastActuatorEnabled = 2;
					}
					if (type == 3625)
					{
						WiresUI.Settings._lastActuatorEnabled = 1;
					}
					return WiresUI.Settings._lastActuatorEnabled == 2;
				}
			}

			// Token: 0x170000B8 RID: 184
			public static bool DrawToolModeUI
			{
				// Token: 0x06000B56 RID: 2902 RVA: 0x001FB01C File Offset: 0x001F921C
				get
				{
					int type = Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type;
					return type == 3611 || type == 3625;
				}
			}

			// Token: 0x170000B6 RID: 182
			public static bool DrawWires
			{
				// Token: 0x06000B54 RID: 2900 RVA: 0x001FAF8C File Offset: 0x001F918C
				get
				{
					return Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].mech || (Main.player[Main.myPlayer].InfoAccMechShowWires && Main.player[Main.myPlayer].builderAccStatus[8] == 0);
				}
			}

			// Token: 0x170000B7 RID: 183
			public static bool HideWires
			{
				// Token: 0x06000B55 RID: 2901 RVA: 0x001FAFEC File Offset: 0x001F91EC
				get
				{
					return Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type == 3620;
				}
			}

			// Token: 0x0400129F RID: 4767
			public static WiresUI.Settings.MultiToolMode ToolMode = WiresUI.Settings.MultiToolMode.Red;

			// Token: 0x040012A0 RID: 4768
			private static int _lastActuatorEnabled = 0;

			// Token: 0x02000128 RID: 296
			[Flags]
			public enum MultiToolMode
			{
				// Token: 0x040012A2 RID: 4770
				Red = 1,
				// Token: 0x040012A3 RID: 4771
				Green = 2,
				// Token: 0x040012A4 RID: 4772
				Blue = 4,
				// Token: 0x040012A5 RID: 4773
				Yellow = 8,
				// Token: 0x040012A6 RID: 4774
				Actuator = 16,
				// Token: 0x040012A7 RID: 4775
				Cutter = 32
			}
		}

		// Token: 0x02000129 RID: 297
		private class WiresRadial
		{
			// Token: 0x06000B59 RID: 2905 RVA: 0x001FB0CA File Offset: 0x001F92CA
			public void Update()
			{
			}

			// Token: 0x040012A9 RID: 4777
			public bool active;

			// Token: 0x040012AA RID: 4778
			public bool OnWiresMenu;

			// Token: 0x040012A8 RID: 4776
			public Vector2 position;

			// Token: 0x040012AB RID: 4779
			private float _lineOpacity;
		}
	}
}
