using System;

namespace Groves.FakeMarkupExtensions.BuiltIn
{
	/// <summary>
	/// FME null provider
	/// </summary>
	public class NullFakeMarkupExtensionProvider : IFakeMarkupExtensionProvider
	{
		/// <summary>
		/// Id of the provider
		/// </summary>
		public string ProviderId => "Null";

		/// <summary>
		/// True if the value returned by the provider is cacheable
		/// </summary>
		public bool IsCacheable => false;

		/// <summary>
		/// Gets the result by the provider
		/// </summary>
		/// <param name="crri">request information</param>
		/// <param name="args">request arguments</param>
		/// <returns>a Func providing the value</returns>
		public Func<object> GetResult(CustomResourceRequestInfo crri, params FakeMarkupExtensionToken[] args)
		{
			return () => null;
		}
	}
}