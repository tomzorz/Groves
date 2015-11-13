using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groves.FakeMarkupExtensions.BuiltIn
{
	public class DebugFakeMarkupExtensionProvider : IFakeMarkupExtensionProvider
	{
		public string ProviderId => "Debug";

		public bool IsCacheable => true;

		public Func<object> GetResult(CustomResourceRequestInfo crri, params FakeMarkupExtensionToken[] args)
		{
			if(args.Count() != 1) throw new FakeMarkupExtensionException("Invalid token count for Debug provider.");
			if (args[0].Value as string == "IsInDebugMode")
			{
				var iidm = false;
#if DEBUG
				iidm = true;
#endif
				return () => crri.PropertyType.ToUpper().Contains("STRING") ? (object)iidm.ToString() : (object)iidm;
			}
			if (args[0].Value as string == "IsDebuggerAttached")
			{
				return () => crri.PropertyType.ToUpper().Contains("STRING") ? (object)Debugger.IsAttached.ToString() : (object)Debugger.IsAttached;
			}
			throw new FakeMarkupExtensionException($"Debug provider doesn't provide result for token {args[0]}");
		}
	}
}
