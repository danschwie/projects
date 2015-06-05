using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary.Objects
{
    public class Graph_old
    {
        private List<GraphNode> _nodes;

        #region - Constructors -

        public Graph_old()
        {
            _nodes = new List<GraphNode>();
        }

        public Graph_old(List<GraphNode> nodes)
        {
            _nodes = nodes;
        }

        #endregion

        #region - Properties -

        public int NumEdges
        {
            get
            {
                return _nodes.Sum(n => n.NumEdges);
            }
        }

        public int NumNodes
        {
            get
            {
                return _nodes.Count;
            }
        } 

        #endregion

        #region - Public Methods -

        public void Add(GraphNode node)
        {
            _nodes.Add(node);
        }

        public void DepthFirstTraversal(GraphNode rootNode)
        {
            if (rootNode.IsLeaf)
            {
                //return;
            }
            else
            {
                //return DepthFirstTraversal(
            }
        } 

        #endregion
    }

    public class GraphNode
    {
        private int _id;
        private List<Edge> _edges;

        public GraphNode(int id, List<Edge> edges)
        {
            _id = id;
            _edges = edges;
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public List<Edge> Edges
        {
            get
            {
                return _edges;
            }
        }

        public bool IsLeaf
        {
            get
            {
                return _edges.Count == 0;
            }
        }

        public int NumEdges
        {
            get
            {
                return _edges.Count;
            }
        }

        public bool HasEdge(Edge edge)
        {
            return HasEdge(edge.AdjacentNodeId);
        }

        public bool HasEdge(int destinationNodeId)
        {
            return _edges.Any(e => e.AdjacentNodeId == destinationNodeId);
        }
    }

    public class Edge
    {
        public int AdjacentNodeId
        {
            get;
            set;
        }

        public bool IsBiDirectional
        {
            get;
            set;
        }
    }
}
