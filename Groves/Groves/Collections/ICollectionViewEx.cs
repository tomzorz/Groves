using System;
using System.Collections;
using System.Collections.Generic;
using Windows.UI.Xaml.Data;

namespace Groves.Collections
{
	/// <summary>
	/// Extended ICollectionView with filtering and sorting
	/// </summary>
	public interface ICollectionViewEx : ICollectionView
	{
		/// <summary>
		/// Indicates whether this CollectionView can filter its items
		/// </summary>
		bool CanFilter { get; }

		/// <summary>
		/// Predicate used to filter the visisble items
		/// </summary>
		Predicate<object> Filter { get; set; }

		/// <summary>
		/// Indicates whether this CollectionView can sort its items
		/// </summary>
		bool CanSort { get; }

		/// <summary>
		/// SortDescriptions to sort the visible items
		/// </summary>
		IList<SortDescription> SortDescriptions { get; }

		/// <summary>
		/// Indicates whether this CollectionView can group its items
		/// </summary>
		bool CanGroup { get; }

		/// <summary>
		/// GroupDescriptions to group the visible items
		/// </summary>
		IList<object> GroupDescriptions { get; }

		/// <summary>
		/// Returns the source collection
		/// </summary>
		IEnumerable SourceCollection { get; }

		/// <summary>
		/// Stops refreshing until it is disposed
		/// </summary>
		/// <returns>An disposable object</returns>
		IDisposable DeferRefresh();

		/// <summary>
		/// Manually refreshes the view
		/// </summary>
		void Refresh();
	}
}