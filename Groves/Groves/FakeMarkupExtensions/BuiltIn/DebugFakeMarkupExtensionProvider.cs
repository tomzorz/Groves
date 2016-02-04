using System;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Xaml;

namespace Groves.FakeMarkupExtensions.BuiltIn
{
	/// <summary>
	/// FME provider giving access to debug information
	/// </summary>
	public class DebugFakeMarkupExtensionProvider : IFakeMarkupExtensionProvider
	{
		private readonly bool _isInDebugMode;
		private readonly bool _isDebuggerAttached;

		/// <summary>
		/// Id of the provider
		/// </summary>
		public string ProviderId => "Debug";

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
			if(args.Count() != 1) throw new FakeMarkupExtensionException("Invalid token count for Debug provider.");
			switch (args[0].Value as string)
			{
				case "IsInDebugMode":

					return () => GetConvertedValue(_isInDebugMode, crri.PropertyType);
				case "!IsInDebugMode":
					return () => GetConvertedValue(!_isInDebugMode, crri.PropertyType);
				case "IsDebuggerAttached":
					return () => GetConvertedValue(_isDebuggerAttached, crri.PropertyType);
				case "!IsDebuggerAttached":
					return () => GetConvertedValue(!_isDebuggerAttached, crri.PropertyType);
			}
			throw new FakeMarkupExtensionException($"Debug provider doesn't provide result for token {args[0]}");
		}

		/// <summary>
		/// Construct FME debug provider
		/// </summary>
		/// <param name="isInDebugMode">is in debug mdoe</param>
		/// <param name="isDebuggerAttached">is debugger attached</param>
		public DebugFakeMarkupExtensionProvider(bool isInDebugMode, bool isDebuggerAttached)
		{
			_isInDebugMode = isInDebugMode;
			_isDebuggerAttached = isDebuggerAttached;
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