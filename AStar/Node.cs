namespace AStar
{
    /// <summary>
    /// A TNode is uniquely identified by its string Key.  A TNode also has a Data property of type object
    /// that can be used to store any extra information associated with the TNode.
    /// 
    /// A TNode has an X and Y properties that represent the node coordinates on a Grid Map and. It also has
    /// a Latitude and Longitude properites that represent the node coordinates on the Earth. 
    /// 
    /// The TNode has a property of type AdjacencyList, which represents the node's neighbors.  To add a neighbor,
    /// the TNode class exposes an AddDirected() method, which adds a directed edge with an (optional) weight to
    /// some other TNode.  These methods are marked internal, and are called by the Graph class.
    /// </summary>
    public partial class Node
    {
        #region Private Member Variables

        // private member variables

        // TNode's coordinates

        #endregion

        #region Public Properties

        /// <summary>
        /// Returns the TNode's Key.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Returns the TNode's Data.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Returns an AdjacencyList of the TNode's neighbors.
        /// </summary>
        public AdjacencyList Neighbors { get; private set; }

        /// <summary>
        /// Returns the TNode's Path Parent.
        /// </summary>
        public Node PathParent { get; set; }

        /// <summary>
        /// Returns the TNode's X coordinate.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Returns the TNode's Y coordinate.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Returns the Node's Latitude location on Earth.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Returns the Node's Longitude location on Earth.
        /// </summary>
        public double Longitude { get; set; }

        #endregion

        #region Constructors

        public Node(string key, object data) : this(key, data, null)
        {
        }

        public Node(string key, object data, int x, int y) : this(key, data, x, y, null)
        {
        }

        public Node(string key, object data, double latitude, double longitude)
            : this(key, data, latitude, longitude, null)
        {
        }

        public Node(string key, object data, AdjacencyList neighbors)
        {
            Key = key;
            Data = data;

            if (neighbors == null)
            {
                Neighbors = new AdjacencyList();
            }
            else
            {
                Neighbors = neighbors;
            }
        }

        public Node(string key, object data, int x, int y, AdjacencyList neighbors)
        {
            Key = key;
            Data = data;
            X = x;
            Y = y;

            if (neighbors == null)
            {
                Neighbors = new AdjacencyList();
            }
            else
            {
                Neighbors = neighbors;
            }
        }

        public Node(string key, object data, double latitude, double longitude, AdjacencyList neighbors)
        {
            Key = key;
            Data = data;
            Latitude = latitude;
            Longitude = longitude;

            if (neighbors == null)
            {
                Neighbors = new AdjacencyList();
            }
            else
            {
                Neighbors = neighbors;
            }
        }

        #endregion

        #region Public Methods

        #region Add Methods

        /// <summary>
        /// Adds an unweighted, directed edge from this node to the passed-in TNode n.
        /// </summary>
        internal void AddDirected(Node n)
        {
            AddDirected(new EdgeToNeighbor(n));
        }

        /// <summary>
        /// Adds a weighted, directed edge from this node to the passed-in TNode n.
        /// </summary>
        /// <param name="cost">The weight of the edge.</param>
        internal void AddDirected(Node n, int cost)
        {
            AddDirected(new EdgeToNeighbor(n, cost));
        }

        /// <summary>
        /// Adds a weighted, directed edge from this node to the passed-in TNode n.
        /// </summary>
        /// <param name="cost">The weight of the edge.</param>
        internal void AddDirected(Node n, double cost)
        {
            AddDirected(new EdgeToNeighbor(n, cost));
        }

        /// <summary>
        /// Adds an edge based on the data in the passed-in EdgeToNeighbor instance.
        /// </summary>
        internal void AddDirected(EdgeToNeighbor e)
        {
            Neighbors.Add(e);
        }

        #endregion

        public override string ToString()
        {
            return string.Format("Key = {0} | X, Y = [{1}, {2}] | Latitude, Longitude = [{3}, {4}] | Data = {5}",
                Key, X, Y, Latitude, Longitude, Data);
        }

        #endregion
    }
}
