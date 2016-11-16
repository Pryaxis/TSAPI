using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Terraria.Localization
{
	public class LocalizedText
	{
		internal LocalizedText(string text)
		{
			this._value = text;
		}

		public bool CanFormatWith(object obj)
		{
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(obj);
			MatchCollection matchCollection = LocalizedText._substitutionRegex.Matches(this._value);
			foreach (Match match in matchCollection)
			{
				string name = match.Groups[2].ToString();
				PropertyDescriptor propertyDescriptor = properties.Find(name, false);
				if (propertyDescriptor == null)
				{
					bool result = false;
					return result;
				}
				object value = propertyDescriptor.GetValue(obj);
				if (value == null)
				{
					bool result = false;
					return result;
				}
				if (match.Groups[1].Length != 0 && (((value as bool?) ?? false) ^ match.Groups[1].Length == 1))
				{
					bool result = false;
					return result;
				}
			}
			return true;
		}

		public string Format(object arg0)
		{
			return string.Format(this._value, arg0);
		}

		public string Format(params object[] args)
		{
			return string.Format(this._value, args);
		}

		public string Format(object arg0, object arg1)
		{
			return string.Format(this._value, arg0, arg1);
		}

		public string Format(object arg0, object arg1, object arg2)
		{
			return string.Format(this._value, arg0, arg1, arg2);
		}

		public string FormatWith(object obj)
		{
			string value = this._value;
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(obj);
			return LocalizedText._substitutionRegex.Replace(value, delegate(Match match)
			{
				if (match.Groups[1].Length != 0)
				{
					return "";
				}
				string name = match.Groups[2].ToString();
				PropertyDescriptor propertyDescriptor = properties.Find(name, false);
				if (propertyDescriptor == null)
				{
					return "";
				}
				return (propertyDescriptor.GetValue(obj) ?? "").ToString();
			});
		}

		internal void SetValue(string text)
		{
			this._value = text;
		}

		public override string ToString()
		{
			return this._value;
		}

		public string Value
		{
			get
			{
				return this._value;
			}
		}

		private static Regex _substitutionRegex = new Regex("{(\\?(?:!)?)?([a-zA-Z][\\w\\.]*)}", RegexOptions.Compiled);

		private string _value = "";
	}
}
