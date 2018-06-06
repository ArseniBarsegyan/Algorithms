using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class Tree<T>
    {
        /// <summary>Constructs the tree</summary>
        /// <param name="value">the value of the node</param>
        public Tree(T value)
        {
            Root = new TreeNode<T>(value);
        }

        /// <summary>Constructs the tree</summary>
        /// <param name="value">the value of the root node</param>
        /// <param name="children">the children of the root
        /// node</param>
        public Tree(T value, params Tree<T>[] children) : this(value)
        {
            foreach (var child in children)
            {
                Root.AddChild(child.Root);
            }
        }

        // The root of the tree
        public TreeNode<T> Root { get; private set; }

        /// <summary>
        /// Depth-First-Search algorithm.
        /// </summary>
        /// <param name="root">the root of the tree to be
        /// traversed</param>
        /// <param name="spaces">the spaces used for
        /// representation of the parent-child relation</param>
        private void PrintDFS(TreeNode<T> root, string spaces)
        {
            if (Root == null)
            {
                return;
            }
            Console.WriteLine(spaces + root.Value);

            TreeNode<T> child = null;

            for (int i = 0; i < root.ChildrenCount; i++)
            {
                child = root.GetChild(i);
                PrintDFS(child, spaces + " ");
            }
        }

        /// <summary>
        /// Breadth-First-Search algorithm.
        /// </summary>
        /// <param name="root">the root of the tree to be
        /// traversed</param>
        private void PrintBFS(TreeNode<T> root)
        {
            if (Root == null)
            {
                return;
            }
            Queue<TreeNode<T>> visitedNodes = new Queue<TreeNode<T>>();
            visitedNodes.Enqueue(Root);
            while (visitedNodes.Count > 0)
            {
                TreeNode<T> currentNode = visitedNodes.Dequeue();
                Console.WriteLine(currentNode.Value);
                
                for (int i = 0; i < currentNode.ChildrenCount; i++)
                {
                    visitedNodes.Enqueue(currentNode.GetChild(i));
                }
            }
        }

        /// <summary>Traverses and prints the tree in
        /// Breadth-First Search (BFS) manner</summary>
        public void TraverseBFS()
        {
            PrintBFS(Root);
        }

        /// <summary>Traverses and prints the tree in
        /// Depth-First Search (DFS) manner</summary>
        public void TraverseDFS()
        {
            PrintDFS(Root, string.Empty);
        }
    }
}
