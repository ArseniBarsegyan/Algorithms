namespace DataStructures.CustomLinkedList
{
    /// <summary>
    /// Provide additional functionality to LinkedList.
    /// </summary>
    public static class LinkedListHelper<T>
    {
        // Find Begining point of loop if list has a loop
        public static Node<T> FindBeginingOfLoop(Node<T> head)
        {
            Node<T> slow = head;
            Node<T> fast = head;

            // Finding first collision spot LOOP_ZIZE-k steps in linked list.
            while (fast?.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                // Collision.
                if (slow == fast)
                {
                    break;
                }
            }

            // There is no collision spot, so there is no loop.
            if (fast?.Next == null)
            {
                return null;
            }

            // Move slow runner to the start of the list.
            slow = head;
            while (slow != fast)
            {
                slow = slow.Next;
                fast = fast.Next;
            }

            return fast;
        }
    }
}
