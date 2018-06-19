using System;

namespace Training.CustomDoubleLinkedList
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
        private DoubleLinkedListNode<T> _nodeToBeFind;

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

        // Comparing who stands first in the list - first or second node.
        private DoubleLinkedListNode<T> GetFirstNodeByOrder(DoubleLinkedListNode<T> firstNode, DoubleLinkedListNode<T> secondNode)
        {
            DoubleLinkedListNode<T> firstFacedNode = _head;

            while(firstFacedNode != null)
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

            // Swap head and tail
            if (preFirstNode == null && postFirstNode != null && preSecondNode != null && postSecondNode == null)
            {
                firstNode.Next = null;
                firstNode.Prev = preSecondNode;

                preSecondNode.Next = firstNode;
                postFirstNode.Prev = secondNode;

                secondNode.Prev = null;
                secondNode.Next = postFirstNode;

                _head = secondNode;
                _tail = firstNode;

                var temp = firstNode;
                firstNode = secondNode;
                secondNode = temp;                                
            }
            // Swap head with common element
            else if (preFirstNode == null && postFirstNode != null && preSecondNode != null && postSecondNode != null)
            {
                firstNode.Next = postSecondNode;
                firstNode.Prev = preSecondNode;

                secondNode.Prev = null;
                secondNode.Next = postFirstNode;

                postFirstNode.Prev = secondNode;

                preSecondNode.Next = firstNode;
                postSecondNode.Prev = firstNode;

                _head = secondNode;

                var temp = firstNode;
                firstNode = secondNode;
                secondNode = temp;                
            }
            // Swap tail with common element
            else if (preFirstNode != null && postFirstNode != null && preSecondNode != null && postSecondNode == null)
            {
                secondNode.Next = postFirstNode;
                secondNode.Prev = preFirstNode;

                firstNode.Next = null;
                firstNode.Prev = preSecondNode;

                preFirstNode.Next = secondNode;
                postFirstNode.Prev = secondNode;

                preSecondNode.Next = firstNode;

                _tail = firstNode;

                var temp = firstNode;
                firstNode = secondNode;
                secondNode = temp;                
            }
            // Swap between common elements
            else
            {
                firstNode.Next = postSecondNode;
                firstNode.Prev = preSecondNode;

                secondNode.Next = postFirstNode;
                secondNode.Prev = preFirstNode;

                preFirstNode.Next = secondNode;
                postFirstNode.Prev = secondNode;

                preSecondNode.Next = firstNode;
                postSecondNode.Prev = firstNode;

                var temp = firstNode;
                firstNode = secondNode;
                secondNode = temp;
            }
        }

        private void SwapNearbyNodes(DoubleLinkedListNode<T> firstNode, DoubleLinkedListNode<T> secondNode)
        {
            var prefirst = firstNode.Prev;
            var postSecond = secondNode.Next;

            // Swap only head and tail
            if (prefirst == null && postSecond == null)
            {
                _head.Next = null;
                _head.Prev = _tail;
                _tail.Next = _head;
                _tail.Prev = null;

                var temp = _head;
                _head = _tail;
                _tail = temp;
                return;
            }
            // Swap head and second element
            else if (prefirst == null && postSecond != null)
            {
                postSecond.Prev = _head;
                _head.Next = postSecond;
                _head.Prev = secondNode;
                secondNode.Prev = null;
                secondNode.Next = _head;

                var temp = secondNode;
                secondNode = _head;
                _head = temp;
            }
            // Swap between tail and pre-last element
            else if (postSecond == null && prefirst != null)
            {
                prefirst.Next = secondNode;
                secondNode.Prev = prefirst;
                secondNode.Next = firstNode;
                firstNode.Prev = secondNode;
                firstNode.Next = null;

                _tail = firstNode;
                var temp = firstNode;
                secondNode = firstNode;
                secondNode = temp;
            }
            // Swap between common nodes
            else
            {
                prefirst.Next = secondNode;
                secondNode.Prev = prefirst;
                secondNode.Next = firstNode;
                firstNode.Prev = secondNode;
                firstNode.Next = postSecond;
                postSecond.Prev = firstNode;

                var temp = firstNode;
                firstNode = secondNode;
                secondNode = temp;
            }
        }        

        // Get first node in sequence by value.
        private DoubleLinkedListNode<T> GetNodeByValue(T value)
        {
            DoubleLinkedListNode<T> nodeToBeFind = _head;

            while(nodeToBeFind != null)
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
        #endregion
    }
}
