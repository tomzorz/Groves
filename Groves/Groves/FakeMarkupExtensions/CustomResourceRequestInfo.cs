namespace Groves.FakeMarkupExtensions
{
	public class CustomResourceRequestInfo
	{
		public CustomResourceRequestInfo(string resourceId, string objectType, string propertyName, string propertyType)
		{
			ResourceId = resourceId;
			ObjectType = objectType;
			PropertyName = propertyName;
			PropertyType = propertyType;
		}

		public string ResourceId { get; }
        public string ObjectType { get; }
		public string PropertyName { get; }
		public string PropertyType { get; }
	}
}