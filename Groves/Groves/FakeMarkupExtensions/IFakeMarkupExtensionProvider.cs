using System;

namespace Groves.FakeMarkupExtensions
{
	public interface IFakeMarkupExtensionProvider
	{
		string ProviderId { get; }

		bool IsCacheable { get; }

		Func<object> GetResult(CustomResourceRequestInfo crri, params FakeMarkupExtensionToken[] args);
	}
}