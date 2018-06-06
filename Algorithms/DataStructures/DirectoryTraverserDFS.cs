using System;
using System.Collections.Generic;
using System.IO;

namespace DataStructures
{
    /// <summary>
    /// Sample class, which traverses recursively given directory
    /// based on the Depth-First-Search (DFS) algorithm
    /// </summary>
    public static class DirectoryTraverserDFS
    {
        /// <summary>
        /// Traverses and prints given directory recursively
        /// </summary>
        /// <param name="dir">the directory to be traversed</param>
        /// <param name="spaces">the spaces used for representation
        /// of the parent-child relation</param>
        private static void TraverseDir(DirectoryInfo dir, string spaces)
        {
            Console.WriteLine(spaces + dir.FullName);

            DirectoryInfo[] children = dir.GetDirectories();

            foreach(DirectoryInfo child in children)
            {
                TraverseDir(child, spaces + " ");
            }
        }

        /// <summary>
        /// Traverses and prints given directory with Breadth-First Search (BFS) algorithm
        /// </summary>
        /// <param name="directoryPath">the path to the directory
        /// which should be traversed</param>
        public static void TraverseDirBFS(string directoryPath)
        {
            Queue<DirectoryInfo> visitedDirsQueue = new Queue<DirectoryInfo>();
            visitedDirsQueue.Enqueue(new DirectoryInfo(directoryPath));

            while(visitedDirsQueue.Count > 0)
            {
                DirectoryInfo currentDir = visitedDirsQueue.Dequeue();
                Console.WriteLine(currentDir.FullName);

                DirectoryInfo[] children = currentDir.GetDirectories();

                foreach(DirectoryInfo child in children)
                {
                    visitedDirsQueue.Enqueue(child);
                }
            }
        }

        /// <summary>
        /// Traverses and prints given directory recursively
        /// </summary>
        /// <param name="directoryPath">the path to the directory
        /// which should be traversed</param>
        public static void TraverseDir(string directoryPath)
        {
            TraverseDir(new DirectoryInfo(directoryPath), string.Empty);
        }
    }
}
