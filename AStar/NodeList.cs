using System;
using System.Collections;

namespace AStar
{
	/// <summary>
	/// The NodeList class represents a collection of nodes.  Internally, it uses a Hashtable instance to provide
	/// fast lookup via a <see cref="Node"/> class's <b>Key</b> value.  The <see cref="Graph"/> class maintains its
	/// list of nodes via this class.
	/// </summary>
	public class NodeList : IEnumerable
	{
		// private member variables
		private Hashtable data = new Hashtable();

		#region Public Methods
		/// <summary>
		/// Adds a new TNode to the NodeList.
		/// </summary>
		public virtual void Add(Node n)
		{
			data.Add(n.Key, n);
		}

		/// <summary>
		/// Removes a TNode from the NodeList.
		/// </summary>
		public virtual void Remove(Node n)
		{
			data.Remove(n.Key);
		}

		/// <summary>
		/// Determines if a node with a specified <b>Key</b> value exists in the NodeList.
		/// </summary>
		/// <param name="key">The <b>Key</b> value to search for.</param>
		/// <returns><b>True</b> if a TNode with the specified <b>Key</b> exists in the NodeList; <b>False</b> otherwise.</returns>
		public virtual bool ContainsKey(string key)
		{
			return data.ContainsKey(key);
		}

		/// <summary>
		/// Clears out all of the nodes from the NodeList.
		/// </summary>
		public virtual void Clear()
		{
			data.Clear();
		}

		/// <summary>
		/// Returns an enumerator that can be used to iterate through the Nodes.
		/// </summary>
		/// <returns></returns>
		public IEnumerator GetEnumerator()
		{
			return new NodeListEnumerator(data.GetEnumerator());
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// Returns a particular <see cref="Node"/> instance by index.
		/// </summary>
		public virtual Node this[string key]
		{
			get
			{
				return (Node) data[key];
			}
		}

		/// <summary>
		/// Returns the number of nodes in the NodeList.
		/// </summary>
		public virtual int Count
		{
			get
			{
				return data.Count;
			}
		}
		#endregion

		#region NodeList Enumerator
		/// <summary>
		/// The NodeListEnumerator method is a custom enumerator for the NodeList object.  It essentially serves
		/// as an enumerator over the NodeList's Hashtable class, but rather than returning DictionaryEntry values,
		/// it returns just the TNode object.
		/// <p />
		/// This allows for a developer using the Graph class to use a foreach to enumerate the Nodes in the graph.
		/// </summary>
		public class NodeListEnumerator : IEnumerator, IDisposable
		{
			IDictionaryEnumerator list;
			public NodeListEnumerator(IDictionaryEnumerator coll) 
			{
				list = coll;				
			}

			public void Reset() 
			{
				list.Reset();
			}

			public bool MoveNext()
			{
				return list.MoveNext();
			}

			public Node Current 
			{
				get 
				{
					return (Node) ((DictionaryEntry) list.Current).Value;
				}
			}

			// The current property on the IEnumerator interface:
			object IEnumerator.Current 
			{
				get 
				{
					return (Current);
				}
			}
		   
			public void Dispose()
			{			
				list = null;
			}
		}
		#endregion
	}
}