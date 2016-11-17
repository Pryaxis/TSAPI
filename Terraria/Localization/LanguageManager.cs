using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Terraria.Localization
{
	public class LanguageManager
	{
		private LanguageManager()
		{
		}

		public bool Exists(string key)
		{
			return this._languageMap.ContainsKey(key);
		}

		public LocalizedText[] FindAll(Regex regex)
		{
			int num = 0;
			foreach (KeyValuePair<string, LocalizedText> current in this._languageMap)
			{
				if (regex.IsMatch(current.Key))
				{
					num++;
				}
			}
			LocalizedText[] array = new LocalizedText[num];
			int num2 = 0;
			foreach (KeyValuePair<string, LocalizedText> current2 in this._languageMap)
			{
				if (regex.IsMatch(current2.Key))
				{
					array[num2] = current2.Value;
					num2++;
				}
			}
			return array;
		}

		public LocalizedText[] FindAll(LanguageSearchFilter filter)
		{
			LinkedList<LocalizedText> linkedList = new LinkedList<LocalizedText>();
			foreach (KeyValuePair<string, LocalizedText> current in this._languageMap)
			{
				if (filter(current.Key, current.Value))
				{
					linkedList.AddLast(current.Value);
				}
			}
			return linkedList.ToArray<LocalizedText>();
		}

		public int GetCategorySize(string name)
		{
			if (this._categoryLists.ContainsKey(name))
			{
				return this._categoryLists[name].Count;
			}
			return 0;
		}

		public LocalizedText GetText(string key)
		{
			if (!this._languageMap.ContainsKey(key))
			{
				return new LocalizedText(key);
			}
			return this._languageMap[key];
		}

		public string GetTextValue(string key)
		{
			if (this._languageMap.ContainsKey(key))
			{
				return this._languageMap[key].Value;
			}
			return key;
		}

		public string GetTextValue(string key, object arg0)
		{
			if (this._languageMap.ContainsKey(key))
			{
				return this._languageMap[key].Format(arg0);
			}
			return key;
		}

		public string GetTextValue(string key, params object[] args)
		{
			if (this._languageMap.ContainsKey(key))
			{
				return this._languageMap[key].Format(args);
			}
			return key;
		}

		public string GetTextValue(string key, object arg0, object arg1)
		{
			if (this._languageMap.ContainsKey(key))
			{
				return this._languageMap[key].Format(arg0, arg1);
			}
			return key;
		}

		public string GetTextValue(string key, object arg0, object arg1, object arg2)
		{
			if (this._languageMap.ContainsKey(key))
			{
				return this._languageMap[key].Format(arg0, arg1, arg2);
			}
			return key;
		}

		public void LoadLanguageFromFileText(string fileText)
		{
			Dictionary<string, Dictionary<string, string>> dictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(fileText);
			foreach (KeyValuePair<string, Dictionary<string, string>> current in dictionary)
			{
				string arg_23_0 = current.Key;
				foreach (KeyValuePair<string, string> current2 in current.Value)
				{
					string key = current.Key + "." + current2.Key;
					if (this._languageMap.ContainsKey(key))
					{
						this._languageMap[key].SetValue(current2.Value);
					}
					else
					{
						this._languageMap.Add(key, new LocalizedText(current2.Value));
						if (!this._categoryLists.ContainsKey(current.Key))
						{
							this._categoryLists.Add(current.Key, new List<string>());
						}
						this._categoryLists[current.Key].Add(current2.Key);
					}
				}
			}
		}

		public LocalizedText RandomFromCategory(string categoryName, Random random = null)
		{
			if (!this._categoryLists.ContainsKey(categoryName))
			{
				return new LocalizedText(categoryName + ".RANDOM");
			}
			List<string> list = this._categoryLists[categoryName];
			return this.GetText(categoryName + "." + list[(random ?? Main.rand).Next(list.Count)]);
		}

		public void SetLanguage(string name)
		{
			if (this._language == name)
			{
				return;
			}
			if (this._language != "English" && name != "English")
			{
				foreach (KeyValuePair<string, LocalizedText> current in this._languageMap)
				{
					current.Value.SetValue(current.Key);
				}
				this.SetLanguage("English");
			}
			this._language = name;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			string[] array = Array.FindAll<string>(typeof(Program).Assembly.GetManifestResourceNames(), (string element) => element.StartsWith("Terraria.Localization.Content." + name) && element.EndsWith(".json"));
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text = array2[i];
				try
				{
					using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(text))
					{
						using (StreamReader streamReader = new StreamReader(manifestResourceStream))
						{
							string text2 = streamReader.ReadToEnd();
							if (text2 == null || text2.Length < 2)
							{
								Console.WriteLine("Failed to load language file: " + text);
								return;
							}
							this.LoadLanguageFromFileText(text2);
						}
					}
				}
				catch (Exception)
				{
					Console.WriteLine("Failed to load language file: " + text);
					return;
				}
			}
			if (this.OnLanguageChanged != null)
			{
				this.OnLanguageChanged(this);
				return;
			}
		}


		public event LanguageChangedCallback OnLanguageChanged;

		public static LanguageManager Instance = new LanguageManager();

		private Dictionary<string, List<string>> _categoryLists = new Dictionary<string, List<string>>();

		private string _language = "";

		private Dictionary<string, LocalizedText> _languageMap = new Dictionary<string, LocalizedText>();
	}
}
