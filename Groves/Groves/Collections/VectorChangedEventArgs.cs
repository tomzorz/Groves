using Windows.Foundation.Collections;

namespace Groves.Collections
{
	public class VectorChangedEventArgs : IVectorChangedEventArgs
	{
		public VectorChangedEventArgs(CollectionChange cc, int index = -1, object item = null)
		{
			CollectionChange = cc;
			Index = (uint)index;
		}

		public CollectionChange CollectionChange { get; }

		public uint Index { get; }
	}
}