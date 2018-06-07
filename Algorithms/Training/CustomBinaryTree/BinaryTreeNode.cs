using System;

namespace Training.CustomBinaryTree
{
    public class BinaryTreeNode<T> : IComparable<BinaryTreeNode<T>> where T : IComparable<T>
    {
        public BinaryTreeNode(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public BinaryTreeNode<T> Parent { get; set; }
        public BinaryTreeNode<T> LeftChild { get; set; }
        public BinaryTreeNode<T> RightChild { get; set; }
        

        public int CompareTo(BinaryTreeNode<T> other)
        {
            return Data.CompareTo(other.Data);
        }
    }
}
