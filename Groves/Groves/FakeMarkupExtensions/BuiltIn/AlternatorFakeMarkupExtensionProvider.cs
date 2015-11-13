using System;
using System.Collections.Generic;
using System.Linq;

namespace Groves.FakeMarkupExtensions.BuiltIn
{
    public class AlternatorFakeMarkupExtensionProvider : IFakeMarkupExtensionProvider
    {
	    public string ProviderId => "Alternate";

	    public bool IsCacheable => true;

	    private readonly Dictionary<string, int> _state;

	    public AlternatorFakeMarkupExtensionProvider()
	    {
		    _state = new Dictionary<string, int>();
	    }

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