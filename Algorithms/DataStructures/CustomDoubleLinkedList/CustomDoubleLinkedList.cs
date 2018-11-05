using System;

namespace DataStructures.CustomDoubleLinkedList
{
    /// <summary>
    /// Custom double linked list.
    /// </summary>
    /// <typeparam name="T">Generic param.</typeparam>
    public class CustomDoubleLinkedList<T>
    {
        private DoubleLinkedListNode<T> _head;
        private DoubleLinkedListNode<T> _tail;
        private bool _contains;

        /// <summary>
        /// Return first value in list.
        /// </summary>
        public T First => _head.Data;

        /// <summary>
        /// Return last value in list.
        /// </summary>
        public T Last => _tail.Data;

        public int Count { get; private set; }

        /// <summary>
        /// Add value to the end of the list.
        /// </summary>
        /// <param name="value">value to be added.</param>
        public void Add(T value)
        {
            if (_head == null)
            {
                _head = new DoubleLinkedListNode<T>(value);
                _tail = _head;
                Count++;
            }
            else
            {
                AddData(value, _head);
            }
        }

        /// <summary>
        /// Insert value at the begining of the list.
        /// </summary>
        /// <param name="value">value to be inserted.</param>
        public void AddFirst(T value)
        {
            if (_head == null)
            {
                _head = new DoubleLinkedListNode<T>(value);
                _tail = _head;                
            }
            else if (_head != null && _head.Equals(_tail))
            {
                _head = new DoubleLinkedListNode<T>(value);
                _head.Next = _tail;
                _tail.Prev = _head;
            }
            else
            {
                var head = _head;
                var nodeAfterHead = _head.Next;

                _head = new DoubleLinkedListNode<T>(value);
                _head.Next = head;
                head.Prev = _head;
            }
            Count++;
        }

        public void Remove(T value)
        {
            RemoveData(value, _head);
        }

        /// <summary>
        /// Check if list contains a value.
        /// </summary>
        /// <param name="value">value to be checked.</param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            Check(value, _head);
            var result = _contains;
            _contains = false;
            return result;
        }

        /// <summary>
        /// Performs swap between elements.
        /// </summary>
        /// <param name="firstValue">first value to be swaped.</param>
        /// <param name="secondValue">second value to be swaped.</param>
        public bool Swap(T firstValue, T secondValue)
        {
            if (!Contains(firstValue))
            {
                return false;
            }

            if (!Contains(secondValue))
            {
                return false;
            }

            // Find nodes that contains that values. Since nodes already exists, don't check result.
            DoubleLinkedListNode<T> firstNode = GetNodeByValue(firstValue);
            DoubleLinkedListNode<T> secondNode = GetNodeByValue(secondValue);

            // Check if nodes stands nearby
            if (firstNode.Next != null && firstNode.Next.Equals(secondNode))
            {
                SwapNearbyNodes(firstNode, secondNode);
            }
            else if (secondNode.Next != null && secondNode.Next.Equals(firstNode))
            {
                SwapNearbyNodes(secondNode, firstNode);
            }
            else
            {
                // Check if first node before second, otherwise reverse params passed to method.
                var firstNodeByOrder = GetFirstNodeByOrder(firstNode, secondNode);

                // Swap values depending on their order.
                if (firstNodeByOrder.Equals(firstNode))
                {
                    SwapCommonNodes(firstNode, secondNode);
                }
                else
                {
                    SwapCommonNodes(secondNode, firstNode);
                }
            }

            return true;
        }          

        #region private_methods
        private void AddData(T value, DoubleLinkedListNode<T> currentNode)
        {
            if (currentNode.Next == null)
            {
                currentNode.Next = new DoubleLinkedListNode<T>(value);
                currentNode.Next.Prev = currentNode;
                _tail = currentNode.Next;
                Count++;                
            }
            else
            {
                AddData(value, currentNode.Next);
            }
        }

        private void RemoveData(T value, DoubleLinkedListNode<T> currentNode)
        {
            if (currentNode == null)
            {
                throw new ArgumentNullException("Can't find any value");
            }

            if (currentNode.Data.Equals(value))
            {
                // Deleting only one element - head and tail
                if (currentNode.Prev == null && currentNode.Next == null)
                {
                    _head = null;
                    _tail = null;
                }

                // Deleting first node.
                else if (currentNode.Prev == null && currentNode.Next != null)
                {
                    currentNode.Next.Prev = null;
                    _head = currentNode.Next;
                }

                // Deleting node in the middle.
                else if (currentNode.Next != null && currentNode.Prev != null)
                {
                    currentNode.Prev.Next = currentNode.Next;
                    currentNode.Next.Prev = currentNode.Prev;
                }
                // Deleting last node.
                else
                {
                    currentNode.Prev.Next = null;
                    _tail = currentNode.Prev;
                }

                currentNode = null;
                Count--;
            }
            else
            {
                RemoveData(value, currentNode.Next);
            }
        }

        private void Check(T value, DoubleLinkedListNode<T> currentNode)
        {
            if (currentNode == null)
            {
                _contains = false;
                return;
            }

            if (currentNode.Data.Equals(value))
            {
                _contains = true;
                return;
            }
            else
            {
                Check(value, currentNode.Next);
            }
        }

        // Get first node in sequence by value.
        private DoubleLinkedListNode<T> GetNodeByValue(T value)
        {
            DoubleLinkedListNode<T> nodeToBeFind = _head;

            while (nodeToBeFind != null)
            {
                if (nodeToBeFind.Data.Equals(value))
                {
                    return nodeToBeFind;
                }
                nodeToBeFind = nodeToBeFind.Next;
            }

            if (nodeToBeFind.Equals(_head))
            {
                nodeToBeFind = null;
            }
            return nodeToBeFind;
        }

        // Comparing who stands first in the list - first or second node.
        private DoubleLinkedListNode<T> GetFirstNodeByOrder(DoubleLinkedListNode<T> firstNode, DoubleLinkedListNode<T> secondNode)
        {
            DoubleLinkedListNode<T> firstFacedNode = _head;

            while (firstFacedNode != null)
            {
                if (firstFacedNode.Equals(firstNode))
                {
                    firstFacedNode = firstNode;
                    break;
                }
                else if (firstFacedNode.Equals(secondNode))
                {
                    firstFacedNode = secondNode;
                    break;
                }
                firstFacedNode = firstFacedNode.Next;
            }
            return firstFacedNode;
        }

        private void SwapCommonNodes(DoubleLinkedListNode<T> firstNode, DoubleLinkedListNode<T> secondNode)
        {
            var preFirstNode = firstNode.Prev;
            var postFirstNode = firstNode.Next;

            var preSecondNode = secondNode.Prev;
            var postSecondNode = secondNode.Next;

            UpdateCommonNodesLinks(firstNode, secondNode, preFirstNode, postFirstNode, preSecondNode, postSecondNode);
            SwapNodes(firstNode, secondNode);
            UpdateHeadAndTail(preFirstNode, firstNode, secondNode, postSecondNode);
        }        

        private void SwapNearbyNodes(DoubleLinkedListNode<T> firstNode, DoubleLinkedListNode<T> secondNode)
        {
            var prefirst = firstNode.Prev;
            var postSecond = secondNode.Next;

            UpdateNearbyNodesLinks(firstNode, secondNode, prefirst, postSecond);
            SwapNodes(firstNode, secondNode);
            UpdateHeadAndTail(prefirst, firstNode, secondNode, postSecond);          
        }

        // Update links of common nodes and their neighboring nodes.
        private void UpdateCommonNodesLinks(DoubleLinkedListNode<T> firstNode, DoubleLinkedListNode<T> secondNode, DoubleLinkedListNode<T> preFirstNode,
            DoubleLinkedListNode<T> postFirstNode, DoubleLinkedListNode<T> preSecondNode, DoubleLinkedListNode<T> postSecondNode)
        {
            firstNode.Prev = preSecondNode;
            firstNode.Next = postSecondNode;
            secondNode.Prev = preFirstNode;
            secondNode.Next = postFirstNode;
            if (preFirstNode != null)
            {
                preFirstNode.Next = secondNode;
            }
            postFirstNode.Prev = secondNode;
            preSecondNode.Next = firstNode;
            if (postSecondNode != null)
            {
                postSecondNode.Prev = firstNode;
            }
        }
                
        private void UpdateHeadAndTail(DoubleLinkedListNode<T> preFirstNode, DoubleLinkedListNode<T> firstNode, DoubleLinkedListNode<T> secondNode, DoubleLinkedListNode<T> postSecondNode)
        {
            // Swap head and tail.
            if (preFirstNode == null && postSecondNode == null)
            {
                _head = secondNode;
                _tail = firstNode;
            }
            // Swap head with common element.
            else if (preFirstNode == null)
            {
                _head = secondNode;
            }
            // Swap tail with common element.
            else if (postSecondNode == null)
            {
                _tail = firstNode;
            }
        }

        // Update links of nodes that stands nearby and update their neighboring nodes links.
        private void UpdateNearbyNodesLinks(DoubleLinkedListNode<T> firstNode, DoubleLinkedListNode<T> secondNode, DoubleLinkedListNode<T> prefirstNode, DoubleLinkedListNode<T> postSecondNode)
        {
            firstNode.Prev = secondNode;
            firstNode.Next = postSecondNode;
            secondNode.Prev = prefirstNode;
            secondNode.Next = firstNode;
            if (prefirstNode != null)
            {
                prefirstNode.Next = secondNode;
            }
            if (postSecondNode != null)
            {
                postSecondNode.Prev = firstNode;
            }
        }

        private void SwapNodes(DoubleLinkedListNode<T> firstNode, DoubleLinkedListNode<T> secondNode)
        {
            var temp = firstNode;
            firstNode = secondNode;
            secondNode = temp;
        }
        #endregion
    }
}
