using System;
using System.Linq.Expressions;
using Windows.UI.Xaml;

namespace Groves.UI
{
	/// <summary>
	/// Contains tools to avoid stringly-typing things
	/// </summary>
	public static class PropertyPathHelpers
	{
		/// <summary>
		/// Get PropertyPath from DependencyProperty
		/// </summary>
		/// <typeparam name="T">T</typeparam>
		/// <param name="expr">Eg.: "() => ColumnDefinition.WidthProperty"</param>
		/// <returns>Ready-to-use PropertyPath</returns>
		public static PropertyPath Get<T>(Expression<Func<T>> expr)
		{
			var body = (MemberExpression)expr.Body;
			return new PropertyPath($"({body.ToString().Replace("Property", string.Empty)})");
		}
	}
}