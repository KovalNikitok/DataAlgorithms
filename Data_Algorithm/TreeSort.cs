using System;
using System.Collections.Generic;
using Algorithms.DataStructures;

namespace Algorithms.DataAlgorithm
{
    public class TreeSort<T> : Algorithm<T> where T : IComparable<T>
    {
        public override void Sort(IList<T> collection)
        {
            var binaryTree = new BinaryTree<T>(collection);
            var sorted = binaryTree.Inorder();

            for(int i = 0; i < collection.Count; i++)
            {
                collection[i] = sorted[i];
            }
        }
    }
}
