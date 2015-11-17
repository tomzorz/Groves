using System;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Xaml;

namespace Groves.FakeMarkupExtensions.BuiltIn
{
	public class DebugFakeMarkupExtensionProvider : IFakeMarkupExtensionProvider
	{
		public string ProviderId => "Debug";

		public bool IsCacheable => true;

		public Func<object> GetResult(CustomResourceRequestInfo crri, params FakeMarkupExtensionToken[] args)
		{
			if(args.Count() != 1) throw new FakeMarkupExtensionException("Invalid token count for Debug provider.");
			switch (args[0].Value as string)
			{
				case "IsInDebugMode":
					var iidm = false;
#if DEBUG
					iidm = true;
#endif

					return () => GetConvertedValue(iidm, crri.PropertyType);
				case "!IsInDebugMode":
					var iidmn = true;
#if DEBUG
					iidmn = false;
#endif

					return () => GetConvertedValue(iidmn, crri.PropertyType);
				case "IsDebuggerAttached":
					return () => GetConvertedValue(Debugger.IsAttached, crri.PropertyType);
				case "!IsDebuggerAttached":
					return () => GetConvertedValue(!Debugger.IsAttached, crri.PropertyType);
			}
			throw new FakeMarkupExtensionException($"Debug provider doesn't provide result for token {args[0]}");
		}

		private object GetConvertedValue(bool result, string propertyType)
		{
			if (propertyType.ToUpper().Contains("STRING"))
			{
				return result.ToString();
			}
			if (propertyType.ToUpper().Contains("VISIBILITY"))
			{
				return result ? Visibility.Visible : Visibility.Collapsed;
			}
			return result;
		}
	}
}