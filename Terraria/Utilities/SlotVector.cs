using System;
using System.Collections;
using System.Collections.Generic;namespace Terraria.Utilities
{	public class SlotVector<T> : IEnumerable<SlotVector<T>.ItemPair>, IEnumerable
	{		public SlotVector(int capacity)
		{
			this._array = new SlotVector<T>.ItemPair[capacity];
			this.Clear();
		}
		public SlotId Add(T value)
		{
			if (this._freeHead == 65535u)
			{
				return new SlotId(65535u);
			}
			uint freeHead = this._freeHead;
			SlotVector<T>.ItemPair itemPair = this._array[(int)((UIntPtr)freeHead)];
			if (this._freeHead >= this._usedSpaceLength)
			{
				this._usedSpaceLength = this._freeHead + 1u;
			}
			this._freeHead = itemPair.Id.Index;
			this._array[(int)((UIntPtr)freeHead)] = new SlotVector<T>.ItemPair(value, itemPair.Id.ToActive(freeHead));
			this._count++;
			return this._array[(int)((UIntPtr)freeHead)].Id;
		}
		public void Clear()
		{
			this._usedSpaceLength = 0u;
			this._count = 0;
			this._freeHead = 0u;
			uint num = 0u;
			while ((ulong)num < (ulong)((long)(this._array.Length - 1)))
			{
				this._array[(int)((UIntPtr)num)] = new SlotVector<T>.ItemPair(default(T), new SlotId(num + 1u));
				num += 1u;
			}
			this._array[this._array.Length - 1] = new SlotVector<T>.ItemPair(default(T), new SlotId(65535u));
		}
		public SlotVector<T>.ItemPair GetPair(int index)
		{
			if (this.Has(index))
			{
				return this._array[index];
			}
			return new SlotVector<T>.ItemPair(default(T), SlotId.Invalid);
		}
		public bool Has(SlotId id)
		{
			uint index = id.Index;
			return index >= 0u && (ulong)index < (ulong)((long)this._array.Length) && this._array[(int)((UIntPtr)index)].Id.IsActive && !(id != this._array[(int)((UIntPtr)index)].Id);
		}
		public bool Has(int index)
		{
			return index >= 0 && index < this._array.Length && this._array[index].Id.IsActive;
		}
		public bool Remove(SlotId id)
		{
			if (id.IsActive)
			{
				uint index = id.Index;
				this._array[(int)((UIntPtr)index)] = new SlotVector<T>.ItemPair(default(T), id.ToInactive(this._freeHead));
				this._freeHead = index;
				this._count--;
				return true;
			}
			return false;
		}
		IEnumerator<SlotVector<T>.ItemPair> IEnumerable<SlotVector<T>.ItemPair>.GetEnumerator()
		{
			return new SlotVector<T>.Enumerator(this);
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new SlotVector<T>.Enumerator(this);
		}
		public int Capacity
		{			get
			{
				return this._array.Length;
			}
		}
		public int Count
		{			get
			{
				return this._count;
			}
		}
		public T this[int index]
		{			get
			{
				if (index < 0 || index >= this._array.Length)
				{
					throw new IndexOutOfRangeException();
				}
				if (!this._array[index].Id.IsActive)
				{
					throw new KeyNotFoundException();
				}
				return this._array[index].Value;
			}			set
			{
				if (index < 0 || index >= this._array.Length)
				{
					throw new IndexOutOfRangeException();
				}
				if (!this._array[index].Id.IsActive)
				{
					throw new KeyNotFoundException();
				}
				this._array[index] = new SlotVector<T>.ItemPair(value, this._array[index].Id);
			}
		}
		public T this[SlotId id]
		{			get
			{
				uint index = id.Index;
				if (index < 0u || (ulong)index >= (ulong)((long)this._array.Length))
				{
					throw new IndexOutOfRangeException();
				}
				if (!this._array[(int)((UIntPtr)index)].Id.IsActive || id != this._array[(int)((UIntPtr)index)].Id)
				{
					throw new KeyNotFoundException();
				}
				return this._array[(int)((UIntPtr)index)].Value;
			}			set
			{
				uint index = id.Index;
				if (index < 0u || (ulong)index >= (ulong)((long)this._array.Length))
				{
					throw new IndexOutOfRangeException();
				}
				if (!this._array[(int)((UIntPtr)index)].Id.IsActive || id != this._array[(int)((UIntPtr)index)].Id)
				{
					throw new KeyNotFoundException();
				}
				this._array[(int)((UIntPtr)index)] = new SlotVector<T>.ItemPair(value, id);
			}
		}
		private const uint MAX_INDEX = 65535u;
		private SlotVector<T>.ItemPair[] _array;
		private int _count;
		private uint _freeHead;
		private uint _usedSpaceLength;
		public class Enumerator : IEnumerator<SlotVector<T>.ItemPair>, IDisposable, IEnumerator
		{			public Enumerator(SlotVector<T> slotVector)
			{
				this._slotVector = slotVector;
			}
			public bool MoveNext()
			{
				while ((long)(++this._index) < (long)((ulong)this._slotVector._usedSpaceLength))
				{
					if (this._slotVector.Has(this._index))
					{
						return true;
					}
				}
				return false;
			}
			public void Reset()
			{
				this._index = -1;
			}
			void IDisposable.Dispose()
			{
				this._slotVector = null;
			}
			SlotVector<T>.ItemPair IEnumerator<SlotVector<T>.ItemPair>.Current
			{				get
				{
					return this._slotVector.GetPair(this._index);
				}
			}
			object IEnumerator.Current
			{				get
				{
					return this._slotVector.GetPair(this._index);
				}
			}
			private int _index = -1;
			private SlotVector<T> _slotVector;
		}
		public struct ItemPair
		{			public ItemPair(T value, SlotId id)
			{
				this.Value = value;
				this.Id = id;
			}
			public readonly T Value;
			public readonly SlotId Id;
		}
	}
}
