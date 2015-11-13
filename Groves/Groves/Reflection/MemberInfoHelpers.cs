using System;
using System.Reflection;

namespace Groves.Reflection
{
    public static class MemberInfoHelpers
    {
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