using System;

namespace DataStructures.BinarySearchTree
{
    public class BinarySearchTree<T> where T: IComparable<T>
    {
        /// <summary>
        /// The root of the tree
        /// </summary>
        private BinaryTreeNode<T> _root;

        /// <summary>
        /// Constructs the tree
        /// </summary>
        public BinarySearchTree()
        {
            _root = null;
        }

        /// <summary>Inserts new value in the binary search tree
        /// </summary>
        /// <param name="value">the value to be inserted</param>
        public void Insert(T value)
        {
            _root = Insert(value, null, _root);
        }

        /// <summary>
        /// Inserts node in the binary search tree by given value
        /// </summary>
        /// <param name="value">the new value</param>
        /// <param name="parentNode">the parent of the new node</param>
        /// <param name="node">current node</param>
        /// <returns>the inserted node</returns>
        private BinaryTreeNode<T> Insert(T value, BinaryTreeNode<T> parentNode, BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                node = new BinaryTreeNode<T>(value)
                {
                    _parent = parentNode
                };
            }
            else
            {
                int compareTo = value.CompareTo(node._value);

                if (compareTo < 0)
                {
                    node._leftChild = Insert(value, node, node._leftChild);
                }
                else if (compareTo > 0)
                {
                    node._rightChild = Insert(value, node, node._rightChild);
                }
            }
            return node;
        }

        /// <summary>Finds a given value in the tree and
        /// return the node which contains it if such exsists
        /// </summary>
        /// <param name="value">the value to be found</param>
        /// <returns>the found node or null if not found</returns>
        private BinaryTreeNode<T> Find(T value)
        {
            BinaryTreeNode<T> node = _root;
            while (node != null)
            {
                int compareTo = value.CompareTo(node._value);
                
                if (compareTo < 0)
                {
                    node = node._leftChild;
                }
                else if (compareTo > 0)
                {
                    node = node._rightChild;
                }
                else
                {
                    break;
                }
            }
            return node;
        }

        /// <summary>Returns whether given value exists in the tree
        /// </summary>
        /// <param name="value">the value to be checked</param>
        /// <returns>true if the value is found in the tree</returns>
        public bool Contains(T value)
        {
            bool found = Find(value) != null;
            return found;
        }

        /// <summary>Removes an element from the tree if exists
        /// </summary>
        /// <param name="value">the value to be deleted</param>
        public void Remove(T value)
        {
            BinaryTreeNode<T> nodeToDelete = Find(value);
            if (nodeToDelete != null)
            {
                Remove(nodeToDelete);
            }
        }

        private void Remove(BinaryTreeNode<T> node)
        {
            // Case 3: If the node has two children.
            // Note that if we get here at the end
            // the node will be with at most one child
            if (node._leftChild != null && node._rightChild != null)
            {
                BinaryTreeNode<T> replacement = node._rightChild;
                while(replacement._leftChild != null)
                {
                    replacement = replacement._leftChild;
                }
                node._value = replacement._value;
                node = replacement;
            }

            // Case 1 and 2: If the node has at most one child
            BinaryTreeNode<T> theChild = node._leftChild != null ? node._leftChild : node._rightChild;

            // If the element to be deleted has one child
            if (theChild != null)
            {
                theChild._parent = node._parent;

                // Handle the case when the element is the root
                if (node._parent == null)
                {
                    _root = theChild;
                }
                else
                {
                    // Replace the element with its child sub-tree
                    if (node._parent._leftChild == node)
                    {
                        node._parent._leftChild = theChild;
                    }
                    else
                    {
                        node._parent._rightChild = theChild;
                    }
                }
            }
            else
            {
                // Handle the case when the element is the root
                if (node._parent == null)
                {
                    _root = null;
                }
                else
                {
                    // Remove the element - it is a leaf
                    if (node._parent._leftChild == node)
                    {
                        node._parent._leftChild = null;
                    }
                    else
                    {
                        node._parent._rightChild = null;
                    }
                }
            }
        }

        /// <summary>Traverses and prints the tree</summary>
        public void PrintTreeDFS()
        {
            PrintTreeDFS(_root);
            Console.WriteLine();
        }

        /// tree starting from given root node.</summary>
        /// <param name="node">the starting node</param>
        private void PrintTreeDFS(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                PrintTreeDFS(node._leftChild);
                Console.WriteLine(node._value + " ");
                PrintTreeDFS(node._rightChild);
            }
        }
    }
}
