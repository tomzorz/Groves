using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Groves.Linq;
using Groves.Reflection;

namespace Groves.FakeMarkupExtensions.BuiltIn
{
	public class StaticFakeMarkupExtensionProvider : IFakeMarkupExtensionProvider
	{
		public string ProviderId => "Static";

		public bool IsCacheable => true;

		public Func<object> GetResult(CustomResourceRequestInfo crri, params FakeMarkupExtensionToken[] args)
		{
			if (args.Length != 6)
			{
				throw new FakeMarkupExtensionException($"StaticFakeMarkupExtensionProvider: invalid argument count in {crri.ResourceId}");
			}
			try
			{
				var aqn = $"{(string)args[0].Value}, {(string)args[1].Value}, Version={(string)args[2].Value}, Culture={(string)args[3].Value}, PublicKeyToken={(string)args[4].Value}";
				var test = Type.GetType(aqn).GetTypeInfo().DeclaredMembers.SingleOrDefault(x => x.Name == (string) args[5].Value);
				if (test == null) throw new MissingMemberException($"{(string) args[5].Value} does not exist in {aqn}");
				return () => test.GetValue(null);
			}
			catch (Exception e)
			{
				throw new FakeMarkupExtensionException($"StaticFakeMarkupExtensionProvider: type resolution failed in {crri.ResourceId}", e);
			}
		}
	}
}