using System;

namespace Groves.FakeMarkupExtensions
{
	public class FakeMarkupExtensionException : Exception
	{
		public FakeMarkupExtensionException(string message) : base(message)
		{
		}

		public FakeMarkupExtensionException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}