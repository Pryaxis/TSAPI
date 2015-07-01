using System;

namespace Terraria.Modules
{
	public class AnchorTypesModule
	{
		public int[] tileValid;

		public int[] tileInvalid;

		public int[] tileAlternates;

		public int[] wallValid;

		public AnchorTypesModule(AnchorTypesModule copyFrom = null)
		{
			if (copyFrom == null)
			{
				this.tileValid = null;
				this.tileInvalid = null;
				this.tileAlternates = null;
				this.wallValid = null;
				return;
			}
			if (copyFrom.tileValid != null)
			{
				this.tileValid = new int[(int)copyFrom.tileValid.Length];
				Array.Copy(copyFrom.tileValid, this.tileValid, (int)this.tileValid.Length);
			}
			else
			{
				this.tileValid = null;
			}
			if (copyFrom.tileInvalid != null)
			{
				this.tileInvalid = new int[(int)copyFrom.tileInvalid.Length];
				Array.Copy(copyFrom.tileInvalid, this.tileInvalid, (int)this.tileInvalid.Length);
			}
			else
			{
				this.tileInvalid = null;
			}
			if (copyFrom.tileAlternates != null)
			{
				this.tileAlternates = new int[(int)copyFrom.tileAlternates.Length];
				Array.Copy(copyFrom.tileAlternates, this.tileAlternates, (int)this.tileAlternates.Length);
			}
			else
			{
				this.tileAlternates = null;
			}
			if (copyFrom.wallValid == null)
			{
				this.wallValid = null;
				return;
			}
			this.wallValid = new int[(int)copyFrom.wallValid.Length];
			Array.Copy(copyFrom.wallValid, this.wallValid, (int)this.wallValid.Length);
		}
	}
}