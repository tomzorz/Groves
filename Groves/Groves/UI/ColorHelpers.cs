using System;
using System.Globalization;
using System.Reflection;
using Windows.UI;

namespace Groves.UI
{
    /// <summary>
    /// Color helpers
    /// </summary>
    public static class ColorHelpers
    {
	    /// <summary>
	    /// Creates a color from a hex value
	    /// </summary>
	    /// <param name="s">Hey value in #RRGGBB or #AARRGGBB format</param>
	    /// <returns>Color</returns>
	    public static Color FromHex(string s)
	    {
		    if (s.Length == 7)
		    {
				var r = byte.Parse(s.Substring(1, 2), NumberStyles.HexNumber);
				var g = byte.Parse(s.Substring(3, 2), NumberStyles.HexNumber);
				var b = byte.Parse(s.Substring(5, 2), NumberStyles.HexNumber);
			    return Color.FromArgb(255, r, g, b);
		    }
		    else
		    {
				var a = byte.Parse(s.Substring(1, 2), NumberStyles.HexNumber);
				var r = byte.Parse(s.Substring(3, 2), NumberStyles.HexNumber);
				var g = byte.Parse(s.Substring(5, 2), NumberStyles.HexNumber);
				var b = byte.Parse(s.Substring(7, 2), NumberStyles.HexNumber);
			    return Color.FromArgb(a, r, g, b);
			}
		}

		/// <summary>
		/// Create a Color from a Colors.XXX name
		/// </summary>
		/// <param name="s">name of color</param>
		/// <returns>Color</returns>
		/// <exception cref="Exception">Invalid color identifier.</exception>
		public static Color FromName(string s)
		{
			var prop = typeof(Colors).GetRuntimeProperty(s);
			if (prop != null)
			{
				return (Color)prop.GetValue(null);
			}
			throw new Exception($"Color {s} not found!");
		}
	}
}