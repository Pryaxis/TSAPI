using System;
using System.Collections;
using System.Collections.Generic;

namespace Terraria.Utilities
{
	public class SlotVector<T> : IEnumerable<SlotVector<T>.ItemPair>, IEnumerable
	{
		public SlotVector(int capacity)
		{
			this._array = new ItemPair[capacity];
			this.Clear();
		}

		public SlotId Add(T value)
		{
			if (this._freeHead == MAX_INDEX)
			{
				return new SlotId(MAX_INDEX);
			}
			uint freeHead = this._freeHead;
			ItemPair itemPair = this._array[(int)(freeHead)];
			if (this._freeHead >= this._usedSpaceLength)
			{
				this._usedSpaceLength = this._freeHead + 1u;
			}
			this._freeHead = itemPair.Id.Index;
			this._array[(int)(freeHead)] = new ItemPair(value, itemPair.Id.ToActive(freeHead));
			this._count++;
			return this._array[(int)(freeHead)].Id;
		}

		public void Clear()
		{
			this._usedSpaceLength = 0u;
			this._count = 0;
			this._freeHead = 0u;
			int num = 0;
			while (num < this._array.Length - 1)
			{
				this._array[num] = new ItemPair(default(T), new SlotId((uint)num + 1));
				num += 1;
			}
			this._array[this._array.Length - 1] = new ItemPair(default(T), new SlotId(MAX_INDEX));
		}

		public ItemPair GetPair(int index)
		{
			if (this.Has(index))
			{
				return this._array[index];
			}
			return new ItemPair(default(T), SlotId.Invalid);
		}

		public bool Has(SlotId id)
		{
			uint index = id.Index;
			return index >= 0u && index < (ulong)this._array.Length && this._array[(int)index].Id.IsActive && !(id != this._array[(int)index].Id);
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
				this._array[(int)index] = new ItemPair(default(T), id.ToInactive(this._freeHead));
				this._freeHead = index;
				this._count--;
				return true;
			}
			return false;
		}

		IEnumerator<ItemPair> IEnumerable<ItemPair>.GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(this);
		}

		public int Capacity
		{
			get
			{
				return this._array.Length;
			}
		}

		public int Count
		{
			get
			{
				return this._count;
			}
		}

		public T this[int index]
		{
			get
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
			}
			set
			{
				if (index < 0 || index >= this._array.Length)
				{
					throw new IndexOutOfRangeException();
				}
				if (!this._array[index].Id.IsActive)
				{
					throw new KeyNotFoundException();
				}
				this._array[index] = new ItemPair(value, this._array[index].Id);
			}
		}

		public T this[SlotId id]
		{
			get
			{
				uint index = id.Index;
				if (index < 0u || index >= (ulong)this._array.Length)
				{
					throw new IndexOutOfRangeException();
				}
				if (!this._array[(int)index].Id.IsActive || id != this._array[(int)index].Id)
				{
					throw new KeyNotFoundException();
				}
				return this._array[(int)index].Value;
			}
			set
			{
				uint index = id.Index;
				if (index < 0u || index >= (ulong)this._array.Length)
				{
					throw new IndexOutOfRangeException();
				}
				if (!this._array[(int)index].Id.IsActive || id != this._array[(int)index].Id)
				{
					throw new KeyNotFoundException();
				}
				this._array[(int)index] = new ItemPair(value, id);
			}
		}

		private const uint MAX_INDEX = 65535u;

		private ItemPair[] _array;

		private int _count;

		private uint _freeHead;

		private uint _usedSpaceLength;

		public class Enumerator : IEnumerator<ItemPair>, IDisposable, IEnumerator
		{
			public Enumerator(SlotVector<T> slotVector)
			{
				this._slotVector = slotVector;
			}

			public bool MoveNext()
			{
				while (++this._index < (long)((ulong)this._slotVector._usedSpaceLength))
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

			ItemPair IEnumerator<ItemPair>.Current
			{
				get
				{
					return this._slotVector.GetPair(this._index);
				}
			}

			object IEnumerator.Current
			{
				get
				{
					return this._slotVector.GetPair(this._index);
				}
			}

			private int _index = -1;

			private SlotVector<T> _slotVector;
		}

		public struct ItemPair
		{
			public ItemPair(T value, SlotId id)
			{
				this.Value = value;
				this.Id = id;
			}

			public readonly T Value;

			public readonly SlotId Id;
		}
	}
}
