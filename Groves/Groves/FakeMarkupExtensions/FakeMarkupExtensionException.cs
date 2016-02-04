using System;

namespace Groves.FakeMarkupExtensions
{
	/// <summary>
	/// Fake markup extension exception class
	/// </summary>
	public class FakeMarkupExtensionException : Exception
	{
		/// <summary>
		/// Create a FME exception with a message
		/// </summary>
		/// <param name="message">message</param>
		public FakeMarkupExtensionException(string message) : base(message)
		{
		}

		/// <summary>
		/// Create a FME exception with a message and an inner exception
		/// </summary>
		/// <param name="message">message</param>
		/// <param name="innerException">source exception</param>
		public FakeMarkupExtensionException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}