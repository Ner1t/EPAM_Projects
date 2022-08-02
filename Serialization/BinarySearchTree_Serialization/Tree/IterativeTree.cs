using System;
using System.Collections.Generic;

namespace Tree
{
    [Serializable]
    public class IterativeTree<TData> : BinarySearchTreeAbstract<TData> where TData : IComparable<TData>
    {
        public override void Add(TData data)
        {
            Node<TData> newNode = new(data);

            if (RootNode == null)
            {
                RootNode = newNode;
                return;
            }

            Node<TData> currentNode = RootNode;
            while (true)
            {
                int result = Compare(newNode.Data, currentNode);
                if (result == 0)
                {
                    throw new InvalidOperationException($"Существует узел с таким же значением: {newNode.Data}");
                }

                else if (result < 0)
                {
                    if (currentNode.LeftNode == null)
                    {
                        currentNode.LeftNode = newNode;
                        return;
                    }
                    currentNode = currentNode.LeftNode;
                }
                else
                {
                    if (currentNode.RightNode == null)
                    {
                        currentNode.RightNode = newNode;
                        return;
                    }
                    currentNode = currentNode.RightNode;
                }
            }
        }

        public override Node<TData> Find(TData data)
        {
            return Find(data, out _);
        }

        protected override Node<TData> Find(TData data, out Node<TData> parent)
        {
            if (RootNode == null)
            {
                parent = null;
                return null;
            }

            Node<TData> currentNode = RootNode;
            Node<TData> parentNode = null;
            int result;

            if (Compare(data, RootNode) == 0)
            {
                parent = null;
                return RootNode;
            }

            do
            {
                result = Compare(data, currentNode);
                if (result == 0)
                {
                    parent = parentNode;
                    return currentNode;
                }

                else if (result < 0)
                {
                    if (currentNode.LeftNode == null)
                    {
                        parent = parentNode;
                        return null;
                    }
                    else
                    {
                        parentNode = currentNode;
                        currentNode = currentNode.LeftNode;
                    }
                }
                else
                {
                    if (currentNode.RightNode == null)
                    {
                        parent = parentNode;
                        return null;
                    }
                    else
                    {
                        parentNode = currentNode;
                        currentNode = currentNode.RightNode;
                    }
                }
            } while (result != 0);

            parent = null;
            return null;
        }

        public override IEnumerator<TData> GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }

        public IEnumerable<TData> InOrder()
        {
            if (RootNode == null)
            {
                yield break;
            }

            Stack<Node<TData>> stack = new();
            var currentNode = RootNode;

            while (stack.Count > 0 || currentNode != null)
            {
                if (currentNode == null)
                {
                    currentNode = stack.Pop();
                    yield return currentNode.Data;
                    currentNode = currentNode.RightNode;
                }
                else
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.LeftNode;
                }
            }
        }

        public TData GetMax()
        {
            if (RootNode == null)
            {
                return default;
            }

            Node<TData> currentNode = RootNode;

            while (currentNode.RightNode != null)
            {
                currentNode = currentNode.RightNode;
            }
            return currentNode.Data;
        }

        public TData GetMin()
        {
            if (RootNode == null)
            {
                return default;
            }

            Node<TData> currentNode = RootNode;

            while (currentNode.LeftNode != null)
            {
                currentNode = currentNode.LeftNode;
            }
            return currentNode.Data;
        }
    }
}
