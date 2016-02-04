using System;
using Windows.ApplicationModel.Resources;

namespace Groves.FakeMarkupExtensions.BuiltIn
{
	/// <summary>
	/// FME provider to grab resources from the ResourceLoader
	/// </summary>
	public class ResourceLoaderFakeMarkupExtensionProvider : IFakeMarkupExtensionProvider
	{
		/// <summary>
		/// Id of the provider
		/// </summary>
		public string ProviderId => "ResourceLoader";

		/// <summary>
		/// True if the value returned by the provider is cacheable
		/// </summary>
		public bool IsCacheable => true;

		/// <summary>
		/// Gets the result by the provider
		/// </summary>
		/// <param name="crri">request information</param>
		/// <param name="args">request arguments</param>
		/// <returns>a Func providing the value</returns>
		public Func<object> GetResult(CustomResourceRequestInfo crri, params FakeMarkupExtensionToken[] args)
		{
			var resourceId = args[0].Value as string;
			if(string.IsNullOrWhiteSpace(resourceId)) throw new FakeMarkupExtensionException("ResourceLoader token 0 is null or whitespace.");
			var assembly = args.Length == 2 ? args[1].Value as string : null;
			return (string.IsNullOrWhiteSpace(assembly)
				? (Func<object>)(() => ResourceLoader.GetForCurrentView().GetString(resourceId))
				: (Func<object>)(() => ResourceLoader.GetForCurrentView($"/{assembly}/Resources").GetString(resourceId)));
		}
	}
}