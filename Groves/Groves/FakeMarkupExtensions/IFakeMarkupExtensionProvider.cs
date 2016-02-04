using System;

namespace Groves.FakeMarkupExtensions
{
	/// <summary>
	/// Fake markup extension provider interface
	/// </summary>
	public interface IFakeMarkupExtensionProvider
	{
		/// <summary>
		/// Id of the provider
		/// </summary>
		string ProviderId { get; }

		/// <summary>
		/// True if the value returned by the provider is cacheable
		/// </summary>
		bool IsCacheable { get; }

		/// <summary>
		/// Gets the result by the provider
		/// </summary>
		/// <param name="crri">request information</param>
		/// <param name="args">request arguments</param>
		/// <returns>a Func providing the value</returns>
		Func<object> GetResult(CustomResourceRequestInfo crri, params FakeMarkupExtensionToken[] args);
	}
}