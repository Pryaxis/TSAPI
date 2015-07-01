using System;

namespace Terraria.ID
{
	public static class MountID
	{
		public static int Count;

		static MountID()
		{
			MountID.Count = 14;
		}

		public static class Sets
		{
			public static SetFactory Factory;

			public static bool[] Cart;

			static Sets()
			{
				MountID.Sets.Factory = new SetFactory(MountID.Count);
				SetFactory factory = MountID.Sets.Factory;
				int[] numArray = new int[] { 6, 11, 13 };
				MountID.Sets.Cart = factory.CreateBoolSet(numArray);
			}
		}
	}
}