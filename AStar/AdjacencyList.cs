using System;
using System.Collections;

namespace AStar
{
	/// <summary>
	/// AdjacencyList maintains a list of neighbors for a particular <see cref="Node"/>.  It is derived from CollectionBase
	/// and provides a strongly-typed collection of <see cref="EdgeToNeighbor"/> instances.
	/// </summary>
	public class AdjacencyList : CollectionBase
	{
		/// <summary>
		/// Adds a new <see cref="EdgeToNeighbor"/> instance to the AdjacencyList.
		/// </summary>
		/// <param name="e">The <see cref="EdgeToNeighbor"/> instance to add.</param>
		protected internal virtual void Add(EdgeToNeighbor e)
		{
			base.InnerList.Add(e);
		}

		/// <summary>
		/// Returns a particular <see cref="EdgeToNeighbor"/> instance by index.
		/// </summary>
		public virtual EdgeToNeighbor this[int index]
		{
			get { return (EdgeToNeighbor) base.InnerList[index]; }
			set { base.InnerList[index] = value; }
		}
	}
}
