using Training.CustomBinaryTree;

namespace Training
{    
    public class Program
    {
        public static void Main(string[] args)
        {
            //CustomLinkedList<string> list = new CustomLinkedList<string>();
            //list.Add("test 1");
            //list.Add("test 2");
            //list.Add("test 3");
            //list.Add("test 4");

            //list.Remove("test 2");
            //Console.WriteLine(list.Contains("test 2"));
            //Console.WriteLine(list.Contains("test 3"));
            CustomBinaryTree<int> tree = new CustomBinaryTree<int>();

            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(6);
            tree.Insert(8);
            tree.Insert(10);
            tree.Delete(8);

            tree.TraverseBFS();
        }
    }
}
