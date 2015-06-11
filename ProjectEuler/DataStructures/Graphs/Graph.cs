using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Graphs
{
    public class Graph<T>
    {
        private List<Vertex<T>> _vertices;

        public Graph()
        {
            _vertices = new List<Vertex<T>>();
        }

        public List<Vertex<T>> Vertices
        {
            get
            {
                return _vertices;
            }
            set
            {
                _vertices = value;
            }
        }

        public void Add(Vertex<T> vertex)
        {
            _vertices.Add(vertex);
        }
    }
}
