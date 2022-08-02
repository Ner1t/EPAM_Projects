using System;
using System.Collections.Generic;


namespace Tree
{
    [Serializable]
    public class RecursiveTree<TData> : BinarySearchTreeAbstract<TData> where TData : IComparable<TData>
    {
        public override void Add(TData data)
        {
            if (data == null)
            {
                return;
            }

            Add(data, RootNode);
        }

        private void Add(TData data, Node<TData> currentNode = null)
        {
            if (IsEmpty)
            {
                RootNode = new Node<TData>(data);
            }

            else
            {
                int result = Compare(data, currentNode);
                if (result == 0)
                {
                    throw new InvalidOperationException($"Существует узел с таким же значением: {data}");
                }
                else if (result < 0)
                {
                    if (currentNode.LeftNode == null)
                    {
                        currentNode.LeftNode = new Node<TData>(data);
                    }
                    else
                    {
                        Add(data, currentNode.LeftNode);
                    }
                }
                else
                {
                    if (currentNode.RightNode == null)
                    {
                        currentNode.RightNode = new Node<TData>(data);
                    }
                    else
                    {
                        Add(data, currentNode.RightNode);
                    }
                }
            }
        }

        protected override Node<TData> Find(TData data, out Node<TData> parent)
        {
            (Node<TData> innerParent, Node<TData> node) = Find(data);
            parent = innerParent;
            return node;
        }
        public override Node<TData> Find(TData data)
        {
            (_, Node<TData> node) = Find(data);
            return node;
        }

        private (Node<TData> parent, Node<TData> node) Find(TData data, Node<TData> currentNode = null)
        {
            currentNode ??= RootNode;
            int result;

            if (currentNode == null)
            {
                return (null, null);
            }

            return (result = Compare(data, currentNode)) == 0
                ? (null, currentNode)
                : result < 0
                    ? (Compare(data, currentNode.LeftNode)) == 0
                        ? (currentNode, currentNode.LeftNode)
                       : Find(data, currentNode.LeftNode)
                    : (Compare(data, currentNode.RightNode)) == 0
                        ? (currentNode, currentNode.RightNode)
                       : Find(data, currentNode.RightNode);
        }

        private IEnumerable<TData> InOrder(Node<TData> node)
        {
            if (RootNode == null)
            {
                yield break;
            }

            if (node.LeftNode != null)
            {
                foreach (var element in InOrder(node.LeftNode))
                {
                    yield return element;
                }
            }
            yield return node.Data;

            if (node.RightNode != null)
            {
                foreach (var element in InOrder(node.RightNode))
                {
                    yield return element;
                }
            }
        }

        public override IEnumerator<TData> GetEnumerator()
        {
            return InOrder(RootNode).GetEnumerator();
        }

        public TData GetMax()
        {
            return RootNode == null ? default
                : GetMax(RootNode).Data;
        }

        public TData GetMin()
        {
            return RootNode == null ? default
                : GetMin(RootNode).Data;
        }
    }
}


