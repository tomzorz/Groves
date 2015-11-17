using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Groves.UI;

namespace Groves.FakeMarkupExtensions
{
	public class FakeMarkupExtensionToken
	{
		public FakeMarkupExtensionToken(string s)
		{
			Source = s;
			if (s.Contains(":"))
			{
				var parts = s.Trim('(', ')').Split(':');
				var type = parts[0];
				var source = parts[1];
				switch (type)
				{
					case "int":
						ValueType = typeof(int);
						Value = int.Parse(source);
						break;
					case "float":
						ValueType = typeof(float);
						Value = float.Parse(source);
						break;
					case "double":
						ValueType = typeof(double);
						Value = double.Parse(source);
						break;
					case "byte":
						ValueType = typeof(byte);
						Value = byte.Parse(source);
						break;
					case "bool":
						ValueType = typeof(bool);
						Value = bool.Parse(source);
						break;
					case "brush":
						ValueType = typeof(SolidColorBrush);
						Value = new SolidColorBrush(source.Contains("#") ? ColorHelpers.FromHex(source) : ColorHelpers.FromName(source));
						break;
					case "visibility":
						ValueType = typeof(Visibility);
						switch (source)
						{
							case "Visible":
								Value = Visibility.Visible;
								break;
							case "Collapsed":
								Value = Visibility.Collapsed;
								break;
							default:
								throw new FakeMarkupExtensionException("Invalid value for Visibility token.");

						}
						break;
					default:
						throw new FakeMarkupExtensionException($"Could not find matching constant token type for value {s}");
				}
			}
			else
			{
				ValueType = typeof(string);
				Value = s;
			}
		}

		public object Value { get; set; }

		public string Source { get; set; }

		public Type ValueType { get; set; }
	}
}