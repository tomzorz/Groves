using System;
using System.Linq;
using System.Reflection;
using Groves.Reflection;

namespace Groves.FakeMarkupExtensions.BuiltIn
{
	/// <summary>
	/// FME provider to grab static values by an assembly qualified name and a property name
	/// </summary>
	public class StaticFakeMarkupExtensionProvider : IFakeMarkupExtensionProvider
	{
		/// <summary>
		/// Id of the provider
		/// </summary>
		public string ProviderId => "Static";

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