using System;

namespace Tree
{
    public enum Side
    {
        Left,
        Right
    }
    public class Node<TData> where TData : IComparable<TData>
    {
        public Node<TData> LeftNode { get; set; }
        public Node<TData> RightNode { get; set; }

        public TData Data { get; init; }

        public Node(TData data)
        {
            Data = data;
        }

        public int CompareTo(TData other)
        {
            return Data.CompareTo(other);
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
