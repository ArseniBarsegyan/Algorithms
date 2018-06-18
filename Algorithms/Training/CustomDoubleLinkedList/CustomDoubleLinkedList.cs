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

            // Find nodes that contains that values.
            DoubleLinkedListNode<T> firstNode = GetNodeByValue(firstValue);
            DoubleLinkedListNode<T> secondNode = GetNodeByValue(secondValue);

            Swap(firstNode, secondNode);
            return true;
        }

        // Swap two elements between each other.
        private void Swap(DoubleLinkedListNode<T> firstNode, DoubleLinkedListNode<T> secondNode)
        {
            // If there is only head and tail elements, i.e. count == 2 then swap them between each other.
            if (Count == 2)
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

            // Head can swap with tail, second element and common element.
            if (firstNode.Equals(_head))
            {                
                if (secondNode.Equals(_tail))
                {
                    SwapHeadAndTail(firstNode, secondNode);                                     
                }
                else if (firstNode.Next.Equals(secondNode))
                {
                    SwapHeadAndSecondElement(secondNode);
                }
                else
                {
                    SwapHeadAndCommonElement(firstNode, secondNode);
                }
            }
            // If order opposite.
            else if (secondNode.Equals(_head))
            {
                if (firstNode.Equals(_tail))
                {
                    SwapHeadAndTail(secondNode, firstNode);
                }
                else if (secondNode.Next.Equals(firstNode))
                {
                    SwapHeadAndSecondElement(firstNode);
                }
                else
                {
                    SwapHeadAndCommonElement(secondNode, firstNode);
                }
            }
            // Tail can swap with head, pre-last element and common element.
            else if (firstNode.Equals(_tail))
            {
                if (secondNode.Equals(_head))
                {
                    SwapHeadAndTail(secondNode, firstNode);
                }
                else if (secondNode.Prev.Equals(firstNode))
                {
                    SwapTailAndPreLastElement(secondNode);
                }
                else if (firstNode.Prev.Equals(secondNode))
                {
                    SwapTailAndPreLastElement(secondNode);
                }
                else
                {
                    SwapTailAndCommonElement(firstNode, secondNode);
                }
            }
            else if (secondNode.Equals(_tail))
            {
                if (firstNode.Equals(_head))
                {
                    SwapHeadAndTail(firstNode, secondNode);
                }
                else if (firstNode.Prev.Equals(secondNode))
                {
                    SwapTailAndPreLastElement(firstNode);
                }
                else if (secondNode.Prev.Equals(firstNode))
                {
                    SwapTailAndPreLastElement(firstNode);
                }
                else
                {
                    SwapTailAndCommonElement(secondNode, firstNode);
                }
            }
            // Swap between common elements.
            else
            {
                // Swap neighbours
                if (firstNode.Next.Equals(secondNode))
                {
                    SwapNeighbours(firstNode, secondNode);
                }
                else if (secondNode.Next.Equals(firstNode))
                {
                    SwapNeighbours(secondNode, firstNode);
                }
                // Swap not neighbours
                else
                {
                    SwapNotNeighbours(firstNode, secondNode);
                }                            
            }
        }

        #region swap_methods
        private void SwapHeadAndTail(DoubleLinkedListNode<T> head, DoubleLinkedListNode<T> tail)
        {
            var secondListNode = head.Next;
            var preLastListNode = tail.Prev;

            head.Next = null;
            head.Prev = preLastListNode;
            _tail = head;

            tail.Prev = null;
            tail.Next = secondListNode;
            _head = tail;

            secondListNode.Prev = _head;
            preLastListNode.Next = _tail;
        }

        private void SwapHeadAndSecondElement(DoubleLinkedListNode<T> secondNode)
        {
            var postSecondElement = secondNode.Next;
            postSecondElement.Prev = _head;

            _head.Next = postSecondElement;
            _head.Prev = secondNode;

            secondNode.Prev = null;
            secondNode.Next = _head;

            var temp = secondNode;
            secondNode = _head;
            _head = temp;
        }

        private void SwapHeadAndCommonElement(DoubleLinkedListNode<T> head, DoubleLinkedListNode<T> commonNode)
        {
            var secondNodeInList = head.Next;
            var preSecondNodeElement = commonNode.Prev;
            var postSecondNodeElement = commonNode.Next;

            head.Prev = preSecondNodeElement;
            head.Next = postSecondNodeElement;
            preSecondNodeElement.Next = head;
            postSecondNodeElement.Prev = head;

            commonNode.Prev = null;
            commonNode.Next = secondNodeInList;
            secondNodeInList.Prev = commonNode;
            _head = commonNode;
        }

        private void SwapTailAndPreLastElement(DoubleLinkedListNode<T> preLastElement)
        {
            var prePrelastElement = preLastElement.Prev;
            prePrelastElement.Next = _tail;

            _tail.Prev = prePrelastElement;
            _tail.Next = preLastElement;

            preLastElement.Prev = _tail;
            preLastElement.Next = null;

            var temp = preLastElement;
            preLastElement = _tail;
            _tail = temp;
        }

        private void SwapTailAndCommonElement(DoubleLinkedListNode<T> tail, DoubleLinkedListNode<T> commonNode)
        {
            var preLastListElement = tail.Prev;
            var preSecondNodeElement = commonNode.Prev;
            var postSecondNodeElement = commonNode.Next;

            preSecondNodeElement.Next = tail;
            postSecondNodeElement.Prev = tail;
            tail.Prev = preSecondNodeElement;
            tail.Next = postSecondNodeElement;

            commonNode.Next = null;
            commonNode.Prev = preLastListElement;
            preLastListElement.Next = commonNode;
            _tail = commonNode;
        }

        private void SwapNeighbours(DoubleLinkedListNode<T> leftNode, DoubleLinkedListNode<T> rightNode)
        {
            var preLeftNode = leftNode.Prev;
            var postRightNode = rightNode.Next;

            preLeftNode.Next = rightNode;
            postRightNode.Prev = leftNode;

            leftNode.Prev = rightNode;
            leftNode.Next = postRightNode;

            rightNode.Next = leftNode;
            rightNode.Prev = preLeftNode;

            var tempNode = leftNode;
            leftNode = rightNode;
            rightNode = tempNode;
        }

        private void SwapNotNeighbours(DoubleLinkedListNode<T> firstNode, DoubleLinkedListNode<T> secondNode)
        {
            var preFirstListElement = firstNode.Prev;
            var postFirstListElement = firstNode.Next;

            var preSecondListElement = secondNode.Prev;
            var postSecondListElement = secondNode.Next;

            preFirstListElement.Next = secondNode;
            postFirstListElement.Prev = secondNode;
            secondNode.Prev = preFirstListElement;
            secondNode.Next = postFirstListElement;

            preSecondListElement.Next = firstNode;
            postSecondListElement.Prev = firstNode;
            firstNode.Prev = preSecondListElement;
            firstNode.Next = postSecondListElement;

            var tempNode = firstNode;
            firstNode = secondNode;
            secondNode = tempNode;
        }
        #endregion

        // Get first node in sequence by value.
        private DoubleLinkedListNode<T> GetNodeByValue(T value)
        {
            FindNodeByValue(value, _head);
            return _nodeToBeFind;
        }

        // Finds node by value. Simple linear search. Since we use this method only in swap, we
        // suppose that such node exists.
        private void FindNodeByValue(T value, DoubleLinkedListNode<T> currentNode)
        {
            if (currentNode.Data.Equals(value))
            {
                _nodeToBeFind = currentNode;
            }
            else
            {
                FindNodeByValue(value, currentNode.Next);
            }
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
