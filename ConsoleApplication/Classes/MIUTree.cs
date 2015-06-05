using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Classes
{
    public class MIUTree
    {
        private Node _root;

        public MIUTree(string axiom)
        {
            _root = new Node(axiom);
        }

        public Node Root
        {
            get
            {
                return _root;
            }
        }

        public void Add(Node parent, Node child)
        {
            parent.Children.Add(child);
        }
    }

    public class Node
    {
        public Node(string theorem)
        {
            Theorem = theorem;
            Children = new List<Node>();
        }

        public List<Node> Children { get; set; }

        public string Theorem { get; set; }
    }
}
