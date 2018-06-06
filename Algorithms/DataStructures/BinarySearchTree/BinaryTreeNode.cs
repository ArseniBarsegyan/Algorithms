using System;

namespace DataStructures.BinarySearchTree
{
    /// <summary>Represents a binary tree node</summary>
    /// <typeparam name="T">Specifies the type for the values
    /// in the nodes</typeparam>
    internal class BinaryTreeNode<T> : IComparable<BinaryTreeNode<T>> where T : IComparable<T>
    {
        internal T _value;
        internal BinaryTreeNode<T> _parent;
        internal BinaryTreeNode<T> _leftChild;
        internal BinaryTreeNode<T> _rightChild;

        public BinaryTreeNode(T value)
        {
            _value = value;
            _parent = null;
            _leftChild = null;
            _rightChild = null;
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            BinaryTreeNode<T> other = obj as BinaryTreeNode<T>;
            return CompareTo(other) == 0;
        }

        public int CompareTo(BinaryTreeNode<T> other)
        {
            return _value.CompareTo(other._value);
        }
    }
}
