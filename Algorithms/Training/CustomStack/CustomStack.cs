using System;

namespace Training.CustomStack
{
    /// <summary>
    /// Custom stack.
    /// </summary>
    /// <typeparam name="T">Generic param.</typeparam>
    public class CustomStack<T>
    {
        private StackNode<T> _head;
        private StackNode<T> _lastElement;

        /// <summary>
        /// Push element to stack.
        /// </summary>
        /// <param name="data">value to be pushed.</param>
        public void Push(T data)
        {
            if (_head == null)
            {
                _head = new StackNode<T>(data);
                Count++;
            }
            else
            {
                PushData(data, _head);
            }
        }

        /// <summary>
        /// Returns count of elements in the stack.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Remove last element from the stack and remove it.
        /// </summary>
        public T Pop()
        {
            if (_head == null)
            {
                throw new ArgumentNullException("Stack doesn't contain elements");
            }

            if (_head.Next == null)
            {
                _lastElement = _head;
                _head = null;
                Count--;
            }
            else
            {
                PopData(_head);
            }

            var value = _lastElement.Data;
            _lastElement = null;
            return value;
        }

        /// <summary>
        /// Returns last element from the stack without removing it.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (_head == null)
            {
                throw new ArgumentNullException("Stack doesn't contain elements");
            }

            if (_head.Next == null)
            {
                return _head.Data;
            }
            else
            {
                PeekData(_head);
            }
            var value = _lastElement.Data;
            _lastElement = null;
            return value;
        }

        #region private_methods
        private void PushData(T data, StackNode<T> node)
        {
            if (node.Next == null)
            {
                node.Next = new StackNode<T>(data);
                Count++;
            }
            else
            {
                PushData(data, node.Next);
            }
        }

        private void PopData(StackNode<T> node)
        {
            if (node.Next != null && node.Next.Next == null)
            {
                _lastElement = node.Next;
                node.Next = null;
                Count--;
            }
            else
            {
                PopData(node.Next);
            }
        }

        private void PeekData(StackNode<T> node)
        {
            if (node.Next != null && node.Next.Next == null)
            {
                _lastElement = node.Next;
            }
            else
            {
                PeekData(node.Next);
            }
        }
        #endregion
    }
}
