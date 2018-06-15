using System;

namespace Training.CustomLinkedList
{
    /// <summary>
    /// Custom linked list.
    /// </summary>
    /// <typeparam name="T">generic param.</typeparam>
    public class CustomLinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        /// <summary>
        /// Add value to list.
        /// </summary>
        /// <param name="value">value to be added.</param>
        public void Add(T value)
        {
            Node<T> node = new Node<T>(value);

            if (_head == null)
            {
                _head = node;
                _tail = _head;
            }
            else
            {
                _tail.Next = node;
                _tail = node;
            }
        }

        /// <summary>
        /// Remove element by value.
        /// </summary>
        /// <param name="value">value to be removed.</param>
        public void Remove(T value)
        {
            var nodeToRemove = GetElementByValue(value);
            if (nodeToRemove == null)
            {
                throw new ArgumentNullException("Couldn't find any element");
            }
            UpdateLinks(_head, nodeToRemove);
        }

        // Update links between elements.
        private void UpdateLinks(Node<T> currentElement, Node<T> nodeToRemove)
        {
            // If we need to remove first element.
            if (nodeToRemove.Equals(_head))
            {
                if (nodeToRemove.Next == null)
                {
                    _tail = null;
                    _head = null;
                }
                else
                {
                    _head = nodeToRemove.Next;
                }
                return;
            }

            // If item isn't the last item.
            if (currentElement.Next.Equals(nodeToRemove))
            {
                var nextElement = nodeToRemove.Next;
                if (nextElement != null)
                {
                    currentElement.Next = nextElement;
                }
                else
                {
                    currentElement.Next = null;
                    _tail = currentElement;
                }
                return;
            }
            UpdateLinks(currentElement.Next, nodeToRemove);
        }

        /// <summary>
        /// Returns element by value.
        /// </summary>
        /// <param name="value">required value.</param>
        /// <returns></returns>
        public Node<T> GetElementByValue(T value)
        {
            return Search(value, _head);
        }

        public bool Contains(T value)
        {
            bool result = Search(value, _head) != null;
            return result;
        }

        // Searching node with value equals to passing value. Returns null if nothing find.
        private Node<T> Search(T value, Node<T> currentNode)
        {
            if (currentNode == null)
            {
                return null;
            }
            else if (currentNode.Value.Equals(value))
            {
                return currentNode;
            }
            else
            {
                return Search(value, currentNode.Next);
            }
        }        
    }
}
