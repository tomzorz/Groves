using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Resources;

namespace Groves.FakeMarkupExtensions
{
	/// <summary>
	/// Fake markup extension implementation
	/// </summary>
	public class FakeMarkupExtensionCustomResource : CustomXamlResourceLoader
	{
		//todo scenairos:
		/*
		https://wpdev.uservoice.com/forums/110705-dev-platform/suggestions/7232264-add-markup-extensions-to-and-improve-winrt-xaml
		https://github.com/DragonSpark/Framework/blob/5790cd6d4ba47faceaf4d1a98c6c5ab18c6fbc61/DragonSpark/Configuration/MetadataExtension.cs#L20
		https://xamlmarkupextensions.codeplex.com/
		alternator
		custom binding, multibinding? (add datacontextproxy for that)
		*/

		private readonly Dictionary<string, IFakeMarkupExtensionProvider> _providers;

		private readonly Dictionary<string, Func<object>> _cache;

		/// <summary>
		/// Construct an instance of the FME
		/// </summary>
		/// <param name="fmeps">list of the providers to use</param>
		public FakeMarkupExtensionCustomResource(params IFakeMarkupExtensionProvider[] fmeps)
		{
			_providers = new Dictionary<string, IFakeMarkupExtensionProvider>();
			foreach (var fakeMarkupExtensionProvider in fmeps)
			{
				_providers.Add(fakeMarkupExtensionProvider.ProviderId, fakeMarkupExtensionProvider);
			}
			_cache = new Dictionary<string, Func<object>>();
		}

		/// <summary>
		/// Get a resource by the {CustomResource ...} markup extension
		/// </summary>
		/// <param name="resourceId">if of the resource</param>
		/// <param name="objectType">expected type of the result</param>
		/// <param name="propertyName">name of the property where the value is assigned</param>
		/// <param name="propertyType">type of the property where the value is assigned</param>
		/// <returns>value</returns>
		/// <exception cref="FakeMarkupExtensionException">Something went wrong while grabbing the value.</exception>
		protected override object GetResource(string resourceId, string objectType, string propertyName, string propertyType)
		{
			var crri = new CustomResourceRequestInfo(resourceId, objectType, propertyName, propertyType);
			var cacheKey = resourceId + "&" + propertyType;
			// -- try getting result from cache
			Func<object> fo;
			if (_cache.TryGetValue(cacheKey, out fo))
			{
				return fo.Invoke();
			}
			// -- nopity nope
			var tokens = resourceId.Split('$').Select(x => x.Trim()).ToArray();
			// get provider
			IFakeMarkupExtensionProvider provider;
			if (!_providers.TryGetValue(tokens[0], out provider)) throw new FakeMarkupExtensionException($"No provider found with id {tokens[0]}");
			// get
			var paramTokens = tokens.Skip(1).Select(x => new FakeMarkupExtensionToken(x)).ToArray();
			var resultFunc = provider.GetResult(crri, paramTokens);
			// return result
			if (provider.IsCacheable) _cache[cacheKey] = resultFunc;
			return resultFunc.Invoke();
		}
	}
}