using DataStructures.Models.Items;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    class BinaryTree<T> where T : IComparable<T>
    {
        public TreeRecursionItem<T> Root { get; private set; }

        public int Count { get; private set; }

        public BinaryTree()
        {
            Root = new TreeRecursionItem<T>();
            Count = 0;
        }

        public BinaryTree(T data)
        {
            Root = new TreeRecursionItem<T>(data);
            Count = 1;
        }

        public void Add(T data)
        {
            if (Count == 0)
            {
                Root.Data = data;
                Count = 1;
                return;
            }
            if (Root.Add(data))
                Count++;
        }

        // For copying
        public List<T> Preorder()
        {
            var itemsList = new List<T>(Count);
            if (itemsList != null)
                PreorderRecursion(Root, itemsList);
            return itemsList;
        }

        private void PreorderRecursion(TreeRecursionItem<T> item, List<T> itemsArray)
        {
            if (item == null)
                return;
            itemsArray.Add(item.Data);

            if (item.Left != null)
                PreorderRecursion(item.Left, itemsArray);
            if (item.Right != null)
                PreorderRecursion(item.Right, itemsArray);
        }

        // For deleting
        public List<T> Postorder()
        {
            var itemsList = new List<T>(Count);
            if(itemsList != null)
                PostorderRecursion(Root, itemsList);
            return itemsList;
        }

        private void PostorderRecursion(TreeRecursionItem<T> item, List<T> itemsArray)
        {
            if (item == null)
                return;

            if (item.Left != null)
            {
                PostorderRecursion(item.Left, itemsArray);
            }
            if (item.Right != null)
            {
                PostorderRecursion(item.Right, itemsArray);
            }
            itemsArray.Add(item.Data);
        }
        // For sorting
        public List<T> Inorder()
        {
            var itemsList = new List<T>(Count);
            if (itemsList != null)
                InorderRecursion(Root, itemsList);
            return itemsList;
        }

        
        private void InorderRecursion(TreeRecursionItem<T> item, List<T> itemsArray)
        {
            if (item == null)
                return;

            if (item.Left != null)
            {
                InorderRecursion(item.Left, itemsArray);
            }
            itemsArray.Add(item.Data);
            if (item.Right != null)
            {
                InorderRecursion(item.Right, itemsArray);
            }
        }

        public IEnumerator GetEnumerator()
        {
            if (Count <= 0)
                yield break;

            var itemsList = Inorder();
            foreach (var item in itemsList)
            {
                if (item != null)
                    yield return item;
            }
        }
    }
}
