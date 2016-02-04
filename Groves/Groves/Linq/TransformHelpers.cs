using System;
using System.Collections.Generic;

namespace Groves.Linq
{
	/// <summary>
	/// Transform helpers
	/// </summary>
	public static class TransformHelpers
	{
		/// <summary>
		/// Invokes an action on each element of sequence.
		/// </summary>
		/// <typeparam name="T">generic parameter</typeparam>
		/// <param name="e">enumerable</param>
		/// <param name="a">action</param>
		/// <returns>enumerable</returns>
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> e, Action<T> a)
		{
			foreach (var t in e)
			{
				a.Invoke(t);
				yield return t;
			}
		}

		/// <summary>
		/// Projects each element of a sequence into a new form until an exception is thrown.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <typeparam name="TResult">The type of the value returned by <paramref name="selector"/>.</typeparam>
		/// <param name="source">A sequence of values to invoke a transform function on.</param>
		/// <param name="selector">A transform function to apply to each element.</param>
		/// <returns>An IEnumerable of T whose elements are the result of invoking the transform function on each element of source.</returns>
		public static IEnumerable<TResult> SelectUntilException<TSource, TResult>(this IEnumerable<TSource> source,
			Func<TSource, TResult> selector)
		{
			TResult res = default(TResult);
			foreach (var s in source)
			{
				var success = false;
				try
				{
					res = selector.Invoke(s);
					success = true;
				}
				catch
				{
					// welp
				}
				if (!success) yield break;
				yield return res;
			}
		}

		/// <summary>
		/// Projects each element of a sequence into a new form, when this is unsuccessful it returns a fallback value as projection result
		/// </summary>
		/// <param name="source">A sequence of values to invoke a transform function on.</param>
		/// <param name="selector">A transform function to apply to each element.</param>
		/// <param name="fallback">A fallback item to use when the projection fails.</param>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <typeparam name="TResult">The type of the value returned by <paramref name="selector"/>.</typeparam>
		/// <returns>An IEnumerable of T whose elements are the result of invoking the transform function on each element of source.</returns>
		public static IEnumerable<TResult> SelectWithFallback<TSource, TResult>(this IEnumerable<TSource> source,
			Func<TSource, TResult> selector, TResult fallback)
		{
			TResult res = fallback;
			foreach (var s in source)
			{
				try
				{
					res = selector.Invoke(s);
				}
				catch
				{
					// welp
				}
				yield return res;
			}
		}
    }
}