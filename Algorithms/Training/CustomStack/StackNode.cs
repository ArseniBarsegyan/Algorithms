namespace Training.CustomStack
{
    public class StackNode<T>
    {
        public StackNode(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public StackNode<T> Next { get; set; }
    }
}
