namespace DataStructures.CustomLinkedList
{
    /// <summary>
    /// Node for <see cref="CustomLinkedList{T}"/>
    /// </summary>
    /// <typeparam name="T">generic param.</typeparam>
    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }
}
