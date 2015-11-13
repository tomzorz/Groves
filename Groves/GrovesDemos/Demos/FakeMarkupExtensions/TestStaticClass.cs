namespace GrovesDemos.Demos.FakeMarkupExtensions
{
    public class TestStaticClass
    {
	    public static string TestField = "it works as a field";

		public static string TestProperty => "it works as a property";

		public static string TestMethod() => "it works as a method";
	}
}