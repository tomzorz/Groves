namespace Groves.Collections
{
	public class SortDescription
	{
		public string PropertyName { get; private set; }
		public SortDirection Direction { get; private set; }

		public SortDescription(string propertyName, SortDirection direction)
		{
			PropertyName = propertyName;
			Direction = direction;
		}
	}
}