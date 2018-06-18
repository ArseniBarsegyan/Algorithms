namespace Training.CustomDoubleLinkedList
{
    public class DoubleLinkedListNode<T>
    {
        public T Data { get; set; }
        public DoubleLinkedListNode<T> Next { get; set; }
        public DoubleLinkedListNode<T> Prev { get; set; }

        public DoubleLinkedListNode(T data)
        {
            Data = data;
        }
    }
}
