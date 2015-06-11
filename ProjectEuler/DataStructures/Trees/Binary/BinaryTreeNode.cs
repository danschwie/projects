using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees.Binary
{
    public class BinaryTreeNode<T>
    {
        private T _value;
        private BinaryTreeNode<T> _leftChild;
        private BinaryTreeNode<T> _rightChild;
        private BinaryTreeNode<T> _leftParent;
        private BinaryTreeNode<T> _rightParent;

        public BinaryTreeNode(T value)
        {
            _value = value;
            _leftChild = null;
            _rightChild = null;
            _leftParent = null;
            _rightParent = null;
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

        public BinaryTreeNode<T> LeftChild
        {
            get
            {
                return _leftChild;
            }
            set
            {
                _leftChild = value;
            }
        }

        public BinaryTreeNode<T> RightChild
        {
            get
            {
                return _rightChild;
            }
            set
            {
                _rightChild = value;
            }
        }

        public BinaryTreeNode<T> LeftParent
        {
            get
            {
                return _leftParent;
            }
            set
            {
                _leftParent = value;
            }
        }

        public BinaryTreeNode<T> RightParent
        {
            get
            {
                return _rightParent;
            }
            set
            {
                _rightParent = value;
            }
        }

        public int RowNum { get; set; }

        public int CellNum { get; set; }

        public bool IsLeaf
        {
            get
            {
                return _leftChild == null && _rightChild == null;
            }
        }

        public static void DumpTree(BinaryTreeNode<T> node)
        {
            if (!node.IsLeaf)
            {
                Console.WriteLine(node);
                Console.WriteLine(" ");

                DumpTree(node.LeftChild);
                DumpTree(node.RightChild);
            }
        }

        public override string ToString()
        {
            return _value.ToString() + " " + RowNum + "|" + CellNum + "";
        }
    }
}
