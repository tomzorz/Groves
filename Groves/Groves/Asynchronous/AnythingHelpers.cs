using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Groves.Asynchronous
{
	/// <summary>
	/// Await anything helpers
	/// </summary>
	public static class AnythingHelpers
	{
		/// <summary>
		/// Wait for a timespan
		/// </summary>
		/// <param name="timeSpan">time to wait</param>
		/// <returns>awaitable</returns>
		public static TaskAwaiter GetAwaiter(this TimeSpan timeSpan)
		{
			return Task.Delay(timeSpan).GetAwaiter();
		}

		/// <summary>
		/// Wait for a double time
		/// </summary>
		/// <param name="fromSeconds">time to wait</param>
		/// <returns>awaitable</returns>
		public static TaskAwaiter GetAwaiter(this double fromSeconds)
		{
			return TimeSpan.FromSeconds(fromSeconds).GetAwaiter();
		}

		/// <summary>
		/// Wait for a datetime to happen
		/// </summary>
		/// <param name="dateTime">datetime to wait for</param>
		/// <returns>awaitable</returns>
		public static TaskAwaiter GetAwaiter(this DateTime dateTime)
		{
			return (dateTime - DateTime.Now).TotalSeconds.GetAwaiter();
		}
	}
}