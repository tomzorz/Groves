using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Windows.ApplicationModel;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Groves.DesignTime
{
	/// <summary>
	/// Collection helpers
	/// </summary>
	public static class CollectionHelpers
	{
		private static Random _rnd = new Random();
		private static DateTime _from = new DateTime(1970, 1, 1, 0, 0, 0);
        private static double _dateRange = (DateTime.Today - _from).TotalMinutes;

		private static class New<T> where T : new()
		{
			public static readonly Func<T> Instance = Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile();
		}

		private static Dictionary<Type, Func<object>> _propsDict = new Dictionary<Type, Func<object>>
		{
			[typeof(string)] = () => Path.GetRandomFileName().Replace(".", string.Empty),
			[typeof(int)] = () => _rnd.Next(0, int.MaxValue),
			[typeof(double)] = () => _rnd.Next(0, int.MaxValue -1) + _rnd.NextDouble(),
			[typeof(Brush)] = () => new SolidColorBrush(Color.FromArgb(255, (byte)_rnd.Next(0,255), (byte)_rnd.Next(0, 255), (byte)_rnd.Next(0, 255))),
			[typeof(DateTime)] = () => _from.AddMinutes(_rnd.NextDouble() * _dateRange)
		};

		/// <summary>
		/// Fill up an ICollection of T with random items
		/// </summary>
		/// <typeparam name="T">item type</typeparam>
		/// <param name="list">ICollection to fill up</param>
		/// <param name="count">count of random items to generate, defaults to 10</param>
		/// <remarks>
		/// Supported properties of T: string, int, double, Brush, DateTime
		/// </remarks>
		public static void FillUp<T>(this ICollection<T> list, int count = 10) where T : new()
		{
			if(!DesignMode.DesignModeEnabled && !Debugger.IsAttached) throw new Exception("DesignTime classes only function in the designer or in debug mode.");
			var tProps = typeof (T).GetTypeInfo().DeclaredProperties.Where(x => x.CanRead && x.CanWrite && _propsDict.Keys.Contains(x.PropertyType)).ToList();
			for (int i = 0; i < count; i++)
			{
				var o = New<T>.Instance();
				foreach (var propertyInfo in tProps)
				{
					propertyInfo.SetValue(o, _propsDict[propertyInfo.PropertyType].Invoke());
				}
				list.Add(o);
			}
        }
	}
}