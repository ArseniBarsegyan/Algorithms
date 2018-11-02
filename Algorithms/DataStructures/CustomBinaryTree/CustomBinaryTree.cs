using System;
using System.Collections.Generic;

namespace DataStructures.CustomBinaryTree
{
    public class CustomBinaryTree<T> where T : IComparable<T>
    {
        public BinaryTreeNode<T> Root { get; set; }        

        /// <summary>
        /// Insert data into tree.
        /// </summary>
        /// <param name="data">data to be inserted.</param>
        public void Insert(T data)
        {
            // Create node
            var node = new BinaryTreeNode<T>(data);

            if (Root == null)
            {
                Root = node;
            }
            else
            {
                // Searching place to insert
                Insert(node, Root);
            }            
        }

        // Insertion algorithm - if value of node to be inserted > parent node's value
        // it should be righter, otherwise - lefter.
        private void Insert(BinaryTreeNode<T> nodeToInsert, BinaryTreeNode<T> parentNode)
        {
            if (nodeToInsert.CompareTo(parentNode) > 0)
            {
                // node to insert should be righter than parent node
                if (parentNode.RightChild == null)
                {
                    nodeToInsert.Parent = parentNode;
                    parentNode.RightChild = nodeToInsert;
                    return;
                }
                Insert(nodeToInsert, parentNode.RightChild);
            }
            else
            {
                // node to insert should be lefter than parent node
                if (parentNode.LeftChild == null)
                {
                    nodeToInsert.Parent = parentNode;
                    parentNode.LeftChild = nodeToInsert;
                    return;
                }
                Insert(nodeToInsert, parentNode.LeftChild);
            }
        }

        /// <summary>
        /// Delete first faced data in the tree.
        /// </summary>
        /// <param name="value">value to be deleted.</param>
        public void Delete(T data)
        {
            Find(data, Root);
        }

        // Deletion algorithm: if we found the value to delete, check its children and replace
        // node to be deleted with the child with less value.
        private void Find(T data, BinaryTreeNode<T> currentNode)
        {
            // Search for node to delete in the right side.
            if (data.CompareTo(currentNode.Data) > 0)
            {
                Find(data, currentNode.RightChild);
            }
            // Search for node to delete in the left side.
            else if (data.CompareTo(currentNode.Data) < 0)
            {
                Find(data, currentNode.LeftChild);
            }
            // We have found that node. Delete it and replace it with the child with less value.
            // Also parent node should refer to this child.
            else
            {
                RemoveNode(currentNode);                       
            }
        }

        // Remove node and update all links to it.
        private void RemoveNode(BinaryTreeNode<T> nodeToRemove)
        {
            if (nodeToRemove.Parent != null)
            {
                RefreshParentLinkToNewChild(nodeToRemove);
            }
            ReplaceNodeWithItsChild(nodeToRemove);
        }

        // If node has parent refresh parent's link to a new child.
        private void RefreshParentLinkToNewChild(BinaryTreeNode<T> nodeToRemove)
        {
            var parent = nodeToRemove.Parent;
            
            if (parent.LeftChild == nodeToRemove)
            {
                parent.LeftChild = ReplaceNodeWithItsChild(nodeToRemove);
            }
            else
            {
                parent.RightChild = ReplaceNodeWithItsChild(nodeToRemove);
            }
        }

        // Updates links of node's children so they point to 
        private BinaryTreeNode<T> ReplaceNodeWithItsChild(BinaryTreeNode<T> nodeToReplace)
        {
            // Replace node we have found with its left child (minimum value).
            if (nodeToReplace.LeftChild != null)
            {
                // Replace parent of right child.
                if (nodeToReplace.RightChild != null)
                {
                    nodeToReplace.RightChild.Parent = nodeToReplace.LeftChild;
                }
                nodeToReplace = nodeToReplace.LeftChild;
            }
            // Or if current node has only right child replace it with right child.
            else if (nodeToReplace.LeftChild == null && nodeToReplace.RightChild != null)
            {
                nodeToReplace = nodeToReplace.RightChild;
            }
            // otherwise this node is the last node. Simply set it null.
            else
            {
                nodeToReplace = null;
            }
            return nodeToReplace;
        }

        /// <summary>Traverses and prints the tree in
        /// Breadth-First Search (BFS) manner</summary>
        public void TraverseBFS()
        {
            PrintBFS(Root);
        }

        /// <summary>
        /// Breadth-First-Search algorithm.
        /// </summary>
        /// <param name="root">the root of the tree to be
        /// traversed</param>
        private void PrintBFS(BinaryTreeNode<T> root)
        {
            if (Root == null)
            {
                return;
            }
            Queue<BinaryTreeNode<T>> visitedNodes = new Queue<BinaryTreeNode<T>>();
            visitedNodes.Enqueue(Root);
            while (visitedNodes.Count > 0)
            {
                BinaryTreeNode<T> currentNode = visitedNodes.Dequeue();
                Console.WriteLine(currentNode.Data);

                if (currentNode.LeftChild != null)
                {
                    visitedNodes.Enqueue(currentNode.LeftChild);
                }

                if (currentNode.RightChild != null)
                {
                    visitedNodes.Enqueue(currentNode.RightChild);
                }
            }
        }
    }
}
