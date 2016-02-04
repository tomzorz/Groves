using System;
using System.Collections.Generic;
using System.Linq;

namespace Groves.FakeMarkupExtensions.BuiltIn
{
    /// <summary>
    /// FME provider that can alternate between token values
    /// </summary>
    public class AlternatorFakeMarkupExtensionProvider : IFakeMarkupExtensionProvider
    {
	    /// <summary>
	    /// Id of the provider
	    /// </summary>
	    public string ProviderId => "Alternate";

	    /// <summary>
	    /// True if the value returned by the provider is cacheable
	    /// </summary>
	    public bool IsCacheable => true;

	    private readonly Dictionary<string, int> _state;

	    /// <summary>
	    /// Construct an alternator FME provider
	    /// </summary>
	    public AlternatorFakeMarkupExtensionProvider()
	    {
		    _state = new Dictionary<string, int>();
	    }

	    /// <summary>
	    /// Gets the result by the provider
	    /// </summary>
	    /// <param name="crri">request information</param>
	    /// <param name="args">request arguments</param>
	    /// <returns>a Func providing the value</returns>
	    public Func<object> GetResult(CustomResourceRequestInfo crri, params FakeMarkupExtensionToken[] args)
	    {
		    var id = Guid.NewGuid().ToString();
		    _state[id] = 0;
		    var vals = args.Select(x => x.Value).ToArray();
		    return () =>
		    {
			    if (_state[id] == vals.Length) _state[id] = 0;
			    return vals[_state[id]++];
		    };
	    }
    }
}