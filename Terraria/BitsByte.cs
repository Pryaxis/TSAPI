using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Terraria
{
	public struct BitsByte
	{
		private static bool Null;

		private byte value;

		public bool this[int key]
		{
			get
			{
				return (this.value & 1 << (key & 31)) != 0;
			}
			set
			{
				if (value)
				{
					this.value |= (byte)(1 << (key & 31));
					return;
				}
				this.value &= (byte)(~(1 << (key & 31)));
			}
		}

		public BitsByte(bool b1 = false, bool b2 = false, bool b3 = false, bool b4 = false, bool b5 = false, bool b6 = false, bool b7 = false, bool b8 = false)
		{
			this.value = 0;
			this[0] = b1;
			this[1] = b2;
			this[2] = b3;
			this[3] = b4;
			this[4] = b5;
			this[5] = b6;
			this[6] = b7;
			this[7] = b8;
		}

		public void ClearAll()
		{
			this.@value = 0;
		}

		public static BitsByte[] ComposeBitsBytesChain(bool optimizeLength, params bool[] flags)
		{
			int i = flags.Length;
			int num = 0;
			while (i > 0)
			{
				num++;
				i -= 7;
			}
			BitsByte[] array = new BitsByte[num];
			int num2 = 0;
			int num3 = 0;
			for (int j = 0; j < flags.Length; j++)
			{
				array[num3][num2] = flags[j];
				num2++;
				if (num2 == 7 && num3 < num - 1)
				{
					array[num3][num2] = true;
					num2 = 0;
					num3++;
				}
			}
			if (optimizeLength)
			{
				int num4 = array.Length - 1;
				while (array[num4] == 0 && num4 > 0)
				{
					array[num4 - 1][7] = false;
					num4--;
				}
				Array.Resize<BitsByte>(ref array, num4 + 1);
			}
			return array;
		}

		public static BitsByte[] DecomposeBitsBytesChain(BinaryReader reader)
		{
			List<BitsByte> list = new List<BitsByte>();
			BitsByte item;
			do
			{
				item = reader.ReadByte();
				list.Add(item);
			}
			while (item[7]);
			return list.ToArray();
		}

		public static implicit operator Byte(BitsByte bb)
		{
			return bb.@value;
		}

		public static implicit operator BitsByte(byte b)
		{
			return new BitsByte()
			{
				@value = b
			};
		}

		public void Retrieve(ref bool b0)
		{
			this.Retrieve(ref b0, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null);
		}

		public void Retrieve(ref bool b0, ref bool b1)
		{
			this.Retrieve(ref b0, ref b1, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null);
		}

		public void Retrieve(ref bool b0, ref bool b1, ref bool b2)
		{
			this.Retrieve(ref b0, ref b1, ref b2, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null);
		}

		public void Retrieve(ref bool b0, ref bool b1, ref bool b2, ref bool b3)
		{
			this.Retrieve(ref b0, ref b1, ref b2, ref b3, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null);
		}

		public void Retrieve(ref bool b0, ref bool b1, ref bool b2, ref bool b3, ref bool b4)
		{
			this.Retrieve(ref b0, ref b1, ref b2, ref b3, ref b4, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null);
		}

		public void Retrieve(ref bool b0, ref bool b1, ref bool b2, ref bool b3, ref bool b4, ref bool b5)
		{
			this.Retrieve(ref b0, ref b1, ref b2, ref b3, ref b4, ref b5, ref BitsByte.Null, ref BitsByte.Null);
		}

		public void Retrieve(ref bool b0, ref bool b1, ref bool b2, ref bool b3, ref bool b4, ref bool b5, ref bool b6)
		{
			this.Retrieve(ref b0, ref b1, ref b2, ref b3, ref b4, ref b5, ref b6, ref BitsByte.Null);
		}

		public void Retrieve(ref bool b0, ref bool b1, ref bool b2, ref bool b3, ref bool b4, ref bool b5, ref bool b6, ref bool b7)
		{
			b0 = this[0];
			b1 = this[1];
			b2 = this[2];
			b3 = this[3];
			b4 = this[4];
			b5 = this[5];
			b6 = this[6];
			b7 = this[7];
		}

		public void SetAll()
		{
			this.@value = 255;
		}

		public static void SortOfAUnitTest()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			BinaryReader reader = new BinaryReader(memoryStream);
			bool arg_2B_0 = false;
			bool[] array = new bool[28];
			array[3] = true;
			array[14] = true;
			BitsByte[] array2 = BitsByte.ComposeBitsBytesChain(arg_2B_0, array);
			BitsByte[] array3 = array2;
			for (int i = 0; i < array3.Length; i++)
			{
				byte b = array3[i];
				binaryWriter.Write(b);
			}
			memoryStream.Position = 0L;
			BitsByte[] array4 = BitsByte.DecomposeBitsBytesChain(reader);
			string arg = "";
			string arg2 = "";
			BitsByte[] array5 = array2;
			for (int j = 0; j < array5.Length; j++)
			{
				BitsByte bb = array5[j];
				arg = arg + bb + ", ";
			}
			BitsByte[] array6 = array4;
			for (int k = 0; k < array6.Length; k++)
			{
				BitsByte bb2 = array6[k];
				arg2 = arg2 + bb2 + ", ";
			}
			Main.NewText("done", 255, 255, 255, false);
		}
	}
}