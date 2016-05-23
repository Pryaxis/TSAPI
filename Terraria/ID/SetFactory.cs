using System;
using System.Collections.Generic;

namespace Terraria.ID
{
	public class SetFactory
	{
		protected int _size;

		private Queue<int[]> _intBufferCache = new Queue<int[]>();

		private Queue<ushort[]> _ushortBufferCache = new Queue<ushort[]>();

		private Queue<bool[]> _boolBufferCache = new Queue<bool[]>();

		private object _queueLock = new object();

		public SetFactory(int size)
		{
			this._size = size;
		}

		protected bool[] GetBoolBuffer()
		{
			bool[] result;
			lock (this._queueLock)
			{
				if (this._boolBufferCache.Count == 0)
				{
					result = new bool[this._size];
				}
				else
				{
					result = this._boolBufferCache.Dequeue();
				}
			}
			return result;
		}

		protected int[] GetIntBuffer()
		{
			int[] result;
			lock (this._queueLock)
			{
				if (this._intBufferCache.Count == 0)
				{
					result = new int[this._size];
				}
				else
				{
					result = this._intBufferCache.Dequeue();
				}
			}
			return result;
		}

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

		public bool[] CreateBoolSet(params int[] types)
		{
			return this.CreateBoolSet(false, types);
		}

		public bool[] CreateBoolSet(bool defaultState, params int[] types)
		{
			bool[] boolBuffer = this.GetBoolBuffer();
			for (int i = 0; i < boolBuffer.Length; i++)
			{
				boolBuffer[i] = defaultState;
			}
			for (int j = 0; j < types.Length; j++)
			{
				boolBuffer[types[j]] = !defaultState;
			}
			return boolBuffer;
		}

		public int[] CreateIntSet(int defaultState, params int[] inputs)
		{
			if (inputs.Length % 2 != 0)
			{
				throw new Exception("You have a bad length for inputs on CreateArraySet");
			}
			int[] intBuffer = this.GetIntBuffer();
			for (int i = 0; i < intBuffer.Length; i++)
			{
				intBuffer[i] = defaultState;
			}
			for (int j = 0; j < inputs.Length; j += 2)
			{
				intBuffer[inputs[j]] = inputs[j + 1];
			}
			return intBuffer;
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

		public T[] CreateCustomSet<T>(T defaultState, params object[] inputs)
		{
			if (inputs.Length % 2 != 0)
			{
				throw new Exception("You have a bad length for inputs on CreateCustomSet");
			}
			T[] array = new T[this._size];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = defaultState;
			}
			for (int j = 0; j < inputs.Length; j += 2)
			{
				array[(int)((short)inputs[j])] = (T)((object)inputs[j + 1]);
			}
			return array;
		}
	}
}
