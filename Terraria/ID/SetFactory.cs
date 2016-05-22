using System;
using System.Collections.Generic;

namespace Terraria.ID
{
	public class SetFactory
	{
		protected int _size;

		private Queue<int[]> _intBufferCache = new Queue<int[]>();

		private Queue<bool[]> _boolBufferCache = new Queue<bool[]>();

		private Queue<ushort[]> _ushortBufferCache = new Queue<ushort[]>();

		private object _queueLock = new object();

		public SetFactory(int size)
		{
			this._size = size;
		}

        #region 1.3.1
		protected ushort[] GetUshortBuffer()
		{
			ushort[] result;
			lock (this._queueLock)
			{
				if (this._ushortBufferCache.Count == 0)
				{
					result = new ushort[this._size];
				}
				else
				{
					result = this._ushortBufferCache.Dequeue();
				}
			}
			return result;
		}

		public ushort[] CreateUshortSet(ushort defaultState, params ushort[] inputs)
		{
			if (inputs.Length % 2 != 0)
			{
				throw new Exception("You have a bad length for inputs on CreateArraySet");
			}
			ushort[] ushortBuffer = this.GetUshortBuffer();
			for (int i = 0; i < ushortBuffer.Length; i++)
			{
				ushortBuffer[i] = defaultState;
			}
			for (int j = 0; j < inputs.Length; j += 2)
			{
				ushortBuffer[(int)inputs[j]] = inputs[j + 1];
			}
			return ushortBuffer;
		}

        #endregion


        public bool[] CreateBoolSet(params int[] types)
		{
			return this.CreateBoolSet(false, types);
		}

		public bool[] CreateBoolSet(bool defaultState, params int[] types)
		{
			bool[] boolBuffer = this.GetBoolBuffer();
			for (int i = 0; i < (int)boolBuffer.Length; i++)
			{
				boolBuffer[i] = defaultState;
			}
			for (int j = 0; j < (int)types.Length; j++)
			{
				boolBuffer[types[j]] = !defaultState;
			}
			return boolBuffer;
		}

		public T[] CreateCustomSet<T>(T defaultState, params object[] inputs)
		{
			if ((int)inputs.Length % 2 != 0)
			{
				throw new Exception("You have a bad length for inputs on CreateCustomSet");
			}
			T[] tArray = new T[this._size];
			for (int i = 0; i < (int)tArray.Length; i++)
			{
				tArray[i] = defaultState;
			}
			for (int j = 0; j < (int)inputs.Length; j = j + 2)
			{
				tArray[(short)inputs[j]] = (T)inputs[j + 1];
			}
			return tArray;
		}

		public int[] CreateIntSet(int defaultState, params int[] inputs)
		{
			if ((int)inputs.Length % 2 != 0)
			{
				throw new Exception("You have a bad length for inputs on CreateArraySet");
			}
			int[] intBuffer = this.GetIntBuffer();
			for (int i = 0; i < (int)intBuffer.Length; i++)
			{
				intBuffer[i] = defaultState;
			}
			for (int j = 0; j < (int)inputs.Length; j = j + 2)
			{
				intBuffer[inputs[j]] = inputs[j + 1];
			}
			return intBuffer;
		}

		protected bool[] GetBoolBuffer()
		{
			bool[] flagArray;
			lock (this._queueLock)
			{
				flagArray = (this._boolBufferCache.Count != 0 ? this._boolBufferCache.Dequeue() : new bool[this._size]);
			}
			return flagArray;
		}

		protected int[] GetIntBuffer()
		{
			int[] numArray;
			lock (this._queueLock)
			{
				numArray = (this._boolBufferCache.Count != 0 ? this._intBufferCache.Dequeue() : new int[this._size]);
			}
			return numArray;
		}

		public void Recycle<T>(T[] buffer)
		{
			lock (this._queueLock)
			{
				if (typeof(T).Equals(typeof(bool)))
				{
					this._boolBufferCache.Enqueue(buffer as bool[]);
				}
				else if (typeof(T).Equals(typeof(int)))
				{
					this._intBufferCache.Enqueue(buffer as int[]);
				}
			}
		}
	}
}