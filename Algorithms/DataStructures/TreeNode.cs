using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class TreeNode<T>
    {
        private List<TreeNode<T>> _children;

        /// <summary>Constructs a tree node</summary>
        /// <param name="value">the value of the node</param>
        public TreeNode(T value)
        {
            Value = value;
            _children = new List<TreeNode<T>>();
        }

        /// <summary>The value of the node</summary>
        public T Value { get; set; }
        /// <summary>The number of node's children</summary>
        public int ChildrenCount => _children.Count;
        /// <summary>Shows whether the current node has a parent or not</summary>
        public bool HasParent { get; private set; }

        /// <summary>Adds child to the node</summary>
        /// <param name="child">the child to be added</param>
        public void AddChild(TreeNode<T> child)
        {
            if (child.HasParent)
            {
                throw new ArgumentException("The node already has a parent!");
            }

            child.HasParent = true;
            _children.Add(child);
        }

        public TreeNode<T> GetChild(int index)
        {
            return _children[index];
        }
    }
}
