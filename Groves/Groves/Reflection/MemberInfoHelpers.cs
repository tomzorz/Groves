using System;
using System.Reflection;

namespace Groves.Reflection
{
    /// <summary>
    /// Member info helpers
    /// </summary>
    public static class MemberInfoHelpers
    {
	    /// <summary>
	    /// Gets value by grabbing the exact thing that a memberinfo represents
	    /// </summary>
	    /// <param name="mi">memberinfo</param>
	    /// <param name="on">object to look on</param>
	    /// <returns>value of the memberinfo represented thing</returns>
	    /// <exception cref="Exception">Member not found by the given memberinfo.</exception>
	    public static object GetValue(this MemberInfo mi, object on)
	    {
		    var prop = mi as PropertyInfo;
		    if (prop != null) return prop.GetValue(on);
			var field = mi as FieldInfo;
			if (field != null) return field.GetValue(on);
			var method = mi as MethodInfo;
			if (method != null) return method.Invoke(on, null);
			throw new Exception($"Member {mi.Name} not found.");
		}
    }
}