using System;
using System.Collections.Generic;

namespace Terraria.IO
{
	public class Preferences
	{
		private Dictionary<string, object> _data = new Dictionary<string, object>();

		private readonly string _path;

		public readonly bool UseBson;

		private readonly object _lock = new object();

		public bool AutoSave;

		public Preferences(string path, bool parseAllTypes = false, bool useBson = false)
		{
			this._path = path;
			this.UseBson = useBson;
		}

		public T Get<T>(string name, T defaultValue)
		{
			object obj;
			T t;
			lock (this._lock)
			{
				try
				{
					if (!this._data.TryGetValue(name, out obj))
					{
						t = defaultValue;
					}
					else
					{
						t = (!(obj is T) ? (T)Convert.ChangeType(obj, typeof(T)) : (T)obj);
					}
				}
				catch
				{
					t = defaultValue;
				}
			}
			return t;
		}

		public void Get<T>(string name, ref T currentValue)
		{
			currentValue = this.Get<T>(name, currentValue);
		}

		public bool Load()
		{
			return true;
		}

		public void Put(string name, object value)
		{
			lock (this._lock)
			{
				this._data[name] = value;
				if (this.AutoSave)
				{
					this.Save(true);
				}
			}
		}

		public bool Save(bool createFile = true)
		{
			return true;
		}
	}
}