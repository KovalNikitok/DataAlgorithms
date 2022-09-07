using System;
using System.Collections.Generic;

namespace DataStructures.Models.Items
{
    class TreeRecursionItem<T> where T : IComparable<T>
    {
        private T _data;
        public T Data 
        {
            get
            {
                if (_data == null)
                    throw new ArgumentNullException("Data has null reference.");
                return _data;
            }
            set
            {
                if(value != null)
                    _data = value;
            } 
        }
        public TreeRecursionItem<T> Left { get; private set; }
        public TreeRecursionItem<T> Right { get; private set; }

        public TreeRecursionItem() { }
        public TreeRecursionItem(T data)
        {
            Data = data;
        }
        public TreeRecursionItem(TreeRecursionItem<T> Item) : this(Item.Data)
        {
            Left = Item.Left;
            Right = Item.Right;
        }

        public bool Add(T data)
        {
            if (data == null)
                return false;
            if(Data == null)
            {
                Data = data;
                return true;
            }
            RecursiveAdd(data);
            return true;
        }

        private void RecursiveAdd(T data)
        {
            if(data.CompareTo(Data) < 0)
            {
                if (Left == null)
                {
                    Left = new TreeRecursionItem<T>(data);
                    return;
                }
                Left.RecursiveAdd(data);
            }
            else
            {
                if (Right == null)
                {
                    Right = new TreeRecursionItem<T>(data);
                    return;
                }
                Right.RecursiveAdd(data);
            }
        }
    }
}
