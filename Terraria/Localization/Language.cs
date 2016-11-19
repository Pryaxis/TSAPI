using System;
using System.Text.RegularExpressions;
using Terraria.Utilities;

namespace Terraria.Localization
{
	public static class Language
	{
		public static bool Exists(string key)
		{
			return LanguageManager.Instance.Exists(key);
		}

		public static LocalizedText[] FindAll(Regex regex)
		{
			return LanguageManager.Instance.FindAll(regex);
		}

		public static LocalizedText[] FindAll(LanguageSearchFilter filter)
		{
			return LanguageManager.Instance.FindAll(filter);
		}

		public static int GetCategorySize(string key)
		{
			return LanguageManager.Instance.GetCategorySize(key);
		}

		public static LocalizedText GetText(string key)
		{
			return LanguageManager.Instance.GetText(key);
		}

		public static string GetTextValue(string key)
		{
			return LanguageManager.Instance.GetTextValue(key);
		}

		public static string GetTextValue(string key, object arg0)
		{
			return LanguageManager.Instance.GetTextValue(key, arg0);
		}

		public static string GetTextValue(string key, params object[] args)
		{
			return LanguageManager.Instance.GetTextValue(key, args);
		}

		public static string GetTextValue(string key, object arg0, object arg1)
		{
			return LanguageManager.Instance.GetTextValue(key, arg0, arg1);
		}

		public static string GetTextValue(string key, object arg0, object arg1, object arg2)
		{
			return LanguageManager.Instance.GetTextValue(key, arg0, arg1, arg2);
		}

		public static string GetTextValueWith(string key, object obj)
		{
			return LanguageManager.Instance.GetText(key).FormatWith(obj);
		}

		public static LocalizedText RandomFromCategory(string categoryName, UnifiedRandom random = null)
		{
			return LanguageManager.Instance.RandomFromCategory(categoryName, random);
		}
	}
}
