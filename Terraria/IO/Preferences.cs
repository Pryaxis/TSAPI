using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Terraria.IO
{
	public class Preferences
	{
		private Dictionary<string, object> _data = new Dictionary<string, object>();

		private readonly string _path;

		private readonly JsonSerializerSettings _serializerSettings;

		public readonly bool UseBson;

		private readonly object _lock = new object();

		public bool AutoSave;

		public Preferences(string path, bool parseAllTypes = false, bool useBson = false)
		{
			this._path = path;
			this.UseBson = useBson;
			if (!parseAllTypes)
			{
				this._serializerSettings = new JsonSerializerSettings();
				return;
			}
			JsonSerializerSettings jsonSerializerSetting = new JsonSerializerSettings()
			{
				TypeNameHandling = TypeNameHandling.Auto,
				MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead
			};
			this._serializerSettings = jsonSerializerSetting;
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
			bool flag;
			lock (this._lock)
			{
				if (File.Exists(this._path))
				{
					try
					{
						if (this.UseBson)
						{
							using (FileStream fileStream = File.OpenRead(this._path))
							{
								using (BsonReader bsonReader = new BsonReader(fileStream))
								{
									JsonSerializer jsonSerializer = JsonSerializer.Create(this._serializerSettings);
									this._data = jsonSerializer.Deserialize<Dictionary<string, object>>(bsonReader);
								}
							}
						}
						else
						{
							string str = File.ReadAllText(this._path);
							this._data = JsonConvert.DeserializeObject<Dictionary<string, object>>(str, this._serializerSettings);
						}
						if (this.OnLoad != null)
						{
							this.OnLoad(this);
						}
						flag = true;
					}
					catch (Exception)
					{
						flag = false;
					}
				}
				else
				{
					flag = false;
				}
			}
			return flag;
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
			bool flag;
			lock (this._lock)
			{
				try
				{
					if (this.OnSave != null)
					{
						this.OnSave(this);
					}
					if (createFile || File.Exists(this._path))
					{
						Directory.GetParent(this._path).Create();
						if (!createFile)
						{
							File.SetAttributes(this._path, FileAttributes.Normal);
						}
						if (this.UseBson)
						{
							using (FileStream fileStream = File.Create(this._path))
							{
								using (BsonWriter bsonWriter = new BsonWriter(fileStream))
								{
									File.SetAttributes(this._path, FileAttributes.Normal);
									JsonSerializer.Create(this._serializerSettings).Serialize(bsonWriter, this._data);
								}
							}
						}
						else
						{
							File.WriteAllText(this._path, JsonConvert.SerializeObject(this._data, Formatting.Indented, this._serializerSettings));
							File.SetAttributes(this._path, FileAttributes.Normal);
						}
					}
					else
					{
						flag = false;
						return flag;
					}
				}
				catch (Exception exception1)
				{
					Exception exception = exception1;
					Console.WriteLine(string.Concat("Unable to write file at: ", this._path));
					Console.WriteLine(exception.ToString());
					Monitor.Exit(this._lock);
					flag = false;
					return flag;
				}
				flag = true;
			}
			return flag;
		}

		public event Action<Preferences> OnLoad;

		public event Action<Preferences> OnSave;
	}
}