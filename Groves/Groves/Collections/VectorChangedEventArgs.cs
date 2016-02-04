using Windows.Foundation.Collections;

namespace Groves.Collections
{
	/// <summary>
	/// Vector changed EventArgs
	/// </summary>
	public class VectorChangedEventArgs : IVectorChangedEventArgs
	{
		/// <summary>
		/// Construct an eventargs
		/// </summary>
		/// <param name="cc">collection change type</param>
		/// <param name="index">index of item changed</param>
		/// <param name="item">item changed</param>
		public VectorChangedEventArgs(CollectionChange cc, int index = -1, object item = null)
		{
			CollectionChange = cc;
			Index = (uint)index;
		}

		/// <summary>
		/// Gets the type of change that occurred in the vector.
		/// </summary>
		/// <returns>
		/// The type of change in the vector.
		/// </returns>
		public CollectionChange CollectionChange { get; }

		/// <summary>
		/// Gets the position where the change occurred in the vector.
		/// </summary>
		/// <returns>
		/// The zero-based position where the change occurred in the vector, if applicable.
		/// </returns>
		public uint Index { get; }
	}
}