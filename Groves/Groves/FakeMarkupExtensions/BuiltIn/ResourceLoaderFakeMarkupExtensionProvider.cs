using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace Groves.FakeMarkupExtensions.BuiltIn
{
	public class ResourceLoaderFakeMarkupExtensionProvider : IFakeMarkupExtensionProvider
	{
		public string ProviderId => "ResourceLoader";

		public bool IsCacheable => true;

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