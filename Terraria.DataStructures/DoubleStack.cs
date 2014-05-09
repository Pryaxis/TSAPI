using System;
namespace Terraria.DataStructures
{
	public class DoubleStack<T1>
	{
		private T1[][] _segmentList;
		private readonly int _segmentSize;
		private int _segmentCount;
		private readonly int _segmentShiftPosition;
		private int _start;
		private int _end;
		private int _size;
		private int _last;
		public int Count
		{
			get
			{
				return this._size;
			}
		}
		public DoubleStack(int segmentSize = 1024, int initialSize = 0)
		{
			if (segmentSize < 16)
			{
				segmentSize = 16;
			}
			this._start = segmentSize / 2;
			this._end = this._start;
			this._size = 0;
			this._segmentShiftPosition = segmentSize + this._start;
			initialSize += this._start;
			int num = initialSize / segmentSize + 1;
			this._segmentList = new T1[num][];
			for (int i = 0; i < num; i++)
			{
				this._segmentList[i] = new T1[segmentSize];
			}
			this._segmentSize = segmentSize;
			this._segmentCount = num;
			this._last = this._segmentSize * this._segmentCount - 1;
		}
		public void PushFront(T1 front)
		{
			if (this._start == 0)
			{
				T1[][] array = new T1[this._segmentCount + 1][];
				for (int i = 0; i < this._segmentCount; i++)
				{
					array[i + 1] = this._segmentList[i];
				}
				array[0] = new T1[this._segmentSize];
				this._segmentList = array;
				this._segmentCount++;
				this._start += this._segmentSize;
				this._end += this._segmentSize;
				this._last += this._segmentSize;
			}
			this._start--;
			T1[] array2 = this._segmentList[this._start / this._segmentSize];
			int num = this._start % this._segmentSize;
			array2[num] = front;
			this._size++;
		}
		public T1 PopFront()
		{
			if (this._size == 0)
			{
				throw new InvalidOperationException("The DoubleStack is empty.");
			}
			T1[] array = this._segmentList[this._start / this._segmentSize];
			int num = this._start % this._segmentSize;
			T1 result = array[num];
			array[num] = default(T1);
			this._start++;
			this._size--;
			if (this._start >= this._segmentShiftPosition)
			{
				T1[] array2 = this._segmentList[0];
				for (int i = 0; i < this._segmentCount - 1; i++)
				{
					this._segmentList[i] = this._segmentList[i + 1];
				}
				this._segmentList[this._segmentCount - 1] = array2;
				this._start -= this._segmentSize;
				this._end -= this._segmentSize;
			}
			if (this._size == 0)
			{
				this._start = this._segmentSize / 2;
				this._end = this._start;
			}
			return result;
		}
		public T1 PeekFront()
		{
			if (this._size == 0)
			{
				throw new InvalidOperationException("The DoubleStack is empty.");
			}
			T1[] array = this._segmentList[this._start / this._segmentSize];
			int num = this._start % this._segmentSize;
			return array[num];
		}
		public void PushBack(T1 back)
		{
			if (this._end == this._last)
			{
				T1[][] array = new T1[this._segmentCount + 1][];
				for (int i = 0; i < this._segmentCount; i++)
				{
					array[i] = this._segmentList[i];
				}
				array[this._segmentCount] = new T1[this._segmentSize];
				this._segmentCount++;
				this._segmentList = array;
				this._last += this._segmentSize;
			}
			T1[] array2 = this._segmentList[this._end / this._segmentSize];
			int num = this._end % this._segmentSize;
			array2[num] = back;
			this._end++;
			this._size++;
		}
		public T1 PopBack()
		{
			if (this._size == 0)
			{
				throw new InvalidOperationException("The DoubleStack is empty.");
			}
			T1[] array = this._segmentList[this._end / this._segmentSize];
			int num = this._end % this._segmentSize;
			T1 result = array[num];
			array[num] = default(T1);
			this._end--;
			this._size--;
			if (this._size == 0)
			{
				this._start = this._segmentSize / 2;
				this._end = this._start;
			}
			return result;
		}
		public T1 PeekBack()
		{
			if (this._size == 0)
			{
				throw new InvalidOperationException("The DoubleStack is empty.");
			}
			T1[] array = this._segmentList[this._end / this._segmentSize];
			int num = this._end % this._segmentSize;
			return array[num];
		}
		public void Clear(bool quickClear = false)
		{
			if (!quickClear)
			{
				for (int i = 0; i < this._segmentCount; i++)
				{
					Array.Clear(this._segmentList[i], 0, this._segmentSize);
				}
			}
			this._start = this._segmentSize / 2;
			this._end = this._start;
			this._size = 0;
		}
	}
}
