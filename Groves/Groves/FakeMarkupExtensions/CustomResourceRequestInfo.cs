namespace Groves.FakeMarkupExtensions
{
	/// <summary>
	/// Wrapper class for the request information
	/// </summary>
	public class CustomResourceRequestInfo
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="resourceId">id of the resource</param>
		/// <param name="objectType">expected type of the result</param>
		/// <param name="propertyName">name of the property where the value is assigned</param>
		/// <param name="propertyType">type of the property where the value is assigned</param>
		public CustomResourceRequestInfo(string resourceId, string objectType, string propertyName, string propertyType)
		{
			ResourceId = resourceId;
			ObjectType = objectType;
			PropertyName = propertyName;
			PropertyType = propertyType;
		}

		/// <summary>
		/// id of the resource
		/// </summary>
		public string ResourceId { get; }

		/// <summary>
		/// expected type of the result
		/// </summary>
		public string ObjectType { get; }

		/// <summary>
		/// name of the property where the value is assigned
		/// </summary>
		public string PropertyName { get; }

		/// <summary>
		/// type of the property where the value is assigned
		/// </summary>
		public string PropertyType { get; }
	}
}