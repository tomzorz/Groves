using System;

namespace Groves.FakeMarkupExtensions.BuiltIn
{
	public class NullFakeMarkupExtensionProvider : IFakeMarkupExtensionProvider
	{
		public string ProviderId => "Null";

		public bool IsCacheable => false;

		public Func<object> GetResult(CustomResourceRequestInfo crri, params FakeMarkupExtensionToken[] args)
		{
			return () => null;
		}
	}
}