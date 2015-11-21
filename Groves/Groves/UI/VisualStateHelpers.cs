using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;

namespace Groves.UI
{
	/// <summary>
	/// Tools to help with VisualStates
	/// </summary>
	public static class VisualStateHelpers
	{
		/// <summary>
		/// Create a new VisualState with the preferred name at runtime
		/// </summary>
		/// <param name="name">name of the new VisualState</param>
		/// <returns>Named VisualState</returns>
		public static VisualState CreateNew(string name)
		{
			var vs = (VisualState)XamlReader.Load($"<VisualState x:Name=\"{name}\"" +
														   " xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"" +
														   " xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" />");
			return vs;
		}
	}
}