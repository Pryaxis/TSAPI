namespace Terraria.ID
{
	public static class MountID
	{
		public static class Sets
		{
			public static SetFactory Factory = new SetFactory(Count);

			public static bool[] Cart = Factory.CreateBoolSet(new int[]
			{
				6,
				11,
				13
			});
		}

		public static int Count = 15;
	}
}
