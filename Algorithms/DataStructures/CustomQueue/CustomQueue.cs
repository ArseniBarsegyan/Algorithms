using System;

namespace DataStructures.CustomQueue
{
    /// <summary>
    /// Custom queue.
    /// </summary>
    /// <typeparam name="T">Generic param.</typeparam>
    public class CustomQueue<T>
    {
        private QueueNode<T> _head;
        private QueueNode<T> _tail;

        /// <summary>
        /// Returns count of elements in the stack.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Enqueue element to the queue.
        /// </summary>
        /// <param name="data">value to be pushed.</param>
        public void Enqueue(T data)
        {
            if (_head == null)
            {
                _head = new QueueNode<T>(data);
                _tail = _head;
                Count++;
            }
            else
            {
                EnqueueData(data, _head);
            }
        }

        /// <summary>
        /// Dequeue element from the queue.
        /// </summary>
        public T Dequeue()
        {
            if (_head == null)
            {
                throw new ArgumentNullException("Queue doesn't contain elements");
            }
            
            if (_head.Next == null)
            {
                var value = _head.Data;
                _head = null;
                _tail = null;
                Count--;
                return value;
            }
            else
            {
                var value = _head.Data;
                _head = _head.Next;
                Count--;
                return value;
            }
        }

        /// <summary>
        /// Returns first element from the queue without removing it.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (_head == null)
            {
                throw new ArgumentNullException("Queue doesn't contain elements");
            }

            return _head.Data;
        }        

        private void EnqueueData(T data, QueueNode<T> node)
        {
            if (node.Next == null)
            {
                var tail = new QueueNode<T>(data);
                node.Next = tail;
                _tail = tail;
                Count++;
            }
            else
            {
                EnqueueData(data, node.Next);
            }
        }
    }
}
