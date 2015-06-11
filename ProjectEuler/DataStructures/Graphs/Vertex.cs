using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Graphs
{
    public class Vertex<T>
    {
        private T _value;
        private List<Vertex<T>> _reachableVertices;

        public Vertex()
        {
            _reachableVertices = new List<Vertex<T>>();
        }

        public Vertex(T value)
        {
            _value = value;
            _reachableVertices = new List<Vertex<T>>();
        }

        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public void AddReachableVertex(Vertex<T> vertex)
        {
            ReachableVertices.Add(vertex);
        }

        public List<Vertex<T>> ReachableVertices
        {
            get 
            { 
                return _reachableVertices;
            }
        }

        public bool IsLeaf { get; set; }

        public bool HasParent { get; set; }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
