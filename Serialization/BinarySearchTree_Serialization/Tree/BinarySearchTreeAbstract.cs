using System;
using System.Collections;
using System.Collections.Generic;

namespace Tree
{
    [Serializable]
    public abstract class BinarySearchTreeAbstract<TData> : IEnumerable<TData> where TData : IComparable<TData>
    {
        public Node<TData> RootNode { get; protected set; }

        public bool IsEmpty { get { return RootNode == null; } }

        public BinarySearchTreeAbstract() { }

        public BinarySearchTreeAbstract(IEnumerable<TData> collection)
        {
            AddRange(collection);
        }

        public abstract void Add(TData data);

        public void AddRange(IEnumerable<TData> data)
        {
            foreach (var i in data)
            {
                Add(i);
            }
        }

        public abstract Node<TData> Find(TData data);

        protected abstract Node<TData> Find(TData data, out Node<TData> parent);

        public abstract IEnumerator<TData> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        protected int Compare(TData data, Node<TData> node)
        {
            return data.CompareTo(node.Data);
        }

        public bool Remove(TData data)
        {
            if (IsEmpty)
            {
                return false;
            }

            Node<TData> nodeToRemove = Find(data, out Node<TData> parent);

            if (nodeToRemove == null)
            {
                return false;
            }

            if (nodeToRemove.LeftNode == null && nodeToRemove.RightNode == null)
            {
                RemoveNodeHavingNoChildren(nodeToRemove, parent);
            }

            else if (nodeToRemove.LeftNode == null || nodeToRemove.RightNode == null)
            {
                RemoveNodeHavingOneChild(nodeToRemove, parent);
            }

            else
            {
                RemoveNodeHavingBothChildren(nodeToRemove, parent);
            }
            return true;
        }

        private void ReplaceNode(Node<TData> nodeToChange, Node<TData> nodeToReplace, Node<TData> newNode)
        {
            if (nodeToChange.LeftNode == nodeToReplace)
            {
                nodeToChange.LeftNode = newNode;
            }
            else
            {
                nodeToChange.RightNode = newNode;
            }
        }

        private Node<TData> GetSingleChild(Node<TData> node)
        {
            return node.LeftNode ?? node.RightNode;
        }

        protected void RemoveNodeHavingNoChildren(Node<TData> nodeToRemove, Node<TData> parent)
        {
            if (parent == null)
            {
                RootNode = null;
            }

            ReplaceNode(parent, nodeToRemove, null);
        }

        protected void RemoveNodeHavingOneChild(Node<TData> nodeToRemove, Node<TData> parent)
        {
            if (parent == null)
            {
                RootNode = GetSingleChild(nodeToRemove);
            }

            if (nodeToRemove == parent.LeftNode)
            {
                parent.LeftNode = GetSingleChild(nodeToRemove);
            }

            else
            {
                parent.RightNode = GetSingleChild(nodeToRemove);
            }
        }

        protected void RemoveNodeHavingBothChildren(Node<TData> nodeToRemove, Node<TData> parent)
        {
            if (nodeToRemove.RightNode.LeftNode == null)
            {
                nodeToRemove.RightNode.LeftNode = nodeToRemove.LeftNode;

                if (parent == null)
                {
                    RootNode = nodeToRemove.RightNode;
                }
                else
                {
                    ReplaceNode(parent, nodeToRemove, nodeToRemove.RightNode);
                }
            }
            else
            {
                Node<TData> minNode = GetMin(nodeToRemove.RightNode);
                Find(minNode.Data, out Node<TData> parentMinNode);

                if (minNode.RightNode != null)
                {
                    parentMinNode.LeftNode = minNode.RightNode;
                }
                else
                {
                    parentMinNode.LeftNode = null;
                }

                ReplaceNode(parent, nodeToRemove, minNode);
                minNode.RightNode = nodeToRemove.RightNode;
                minNode.LeftNode = nodeToRemove.LeftNode;
            }
        }

        public Node<TData> GetMin(Node<TData> currentNode = null)
        {
            if (RootNode == null)
            {
                return null;
            }

            if (currentNode.LeftNode != null)
            {
                return GetMin(currentNode.LeftNode);
            }
            else
            {
                return currentNode;
            }
        }
        public Node<TData> GetMax(Node<TData> currentNode = null)
        {
            if (RootNode == null)
            {
                return null;
            }

            currentNode ??= RootNode;

            if (currentNode.RightNode != null)
            {
                return GetMax(currentNode.RightNode);
            }
            else
            {
                return currentNode;
            }
        }
    }
}