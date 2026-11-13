using System;

namespace MunicipalServicesApp.DataStructures
{
    internal class RedBlackTree
    {
        private enum NodeColor
        {
            Red,
            Black
        }

        private class Node
        {
            public ReportedIssue Issue { get; set; }

            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node Parent { get; set; }

            public NodeColor Color { get; set; }

            public Node(ReportedIssue issue)
            {
                Issue = issue;
                Color = NodeColor.Red;
            }
        }

        private Node root;

        public void Insert(ReportedIssue issue)
        {
            Node newNode = new Node(issue);

            Node parent = null;
            Node current = root;

            while (current != null)
            {
                parent = current;

                int comparison = string.Compare(
                    issue.ReferenceNumber,
                    current.Issue.ReferenceNumber,
                    StringComparison.OrdinalIgnoreCase);

                if (comparison < 0)
                {
                    current = current.Left;
                }
                else if (comparison > 0)
                {
                    current = current.Right;
                }
                else
                {
                    return;
                }
            }

            newNode.Parent = parent;

            if (parent == null)
            {
                root = newNode;
            }
            else
            {
                int comparison = string.Compare(
                    issue.ReferenceNumber,
                    parent.Issue.ReferenceNumber,
                    StringComparison.OrdinalIgnoreCase);

                if (comparison < 0)
                {
                    parent.Left = newNode;
                }
                else
                {
                    parent.Right = newNode;
                }
            }

            FixInsert(newNode);
        }

        private void FixInsert(Node node)
        {
            while (node != root &&
                   node.Parent != null &&
                   node.Parent.Color == NodeColor.Red)
            {
                Node parent = node.Parent;
                Node grandparent = parent.Parent;

                if (grandparent == null)
                {
                    break;
                }

                if (parent == grandparent.Left)
                {
                    Node uncle = grandparent.Right;

                    if (uncle != null &&
                        uncle.Color == NodeColor.Red)
                    {
                        parent.Color = NodeColor.Black;
                        uncle.Color = NodeColor.Black;
                        grandparent.Color = NodeColor.Red;

                        node = grandparent;
                    }
                    else
                    {
                        if (node == parent.Right)
                        {
                            node = parent;
                            RotateLeft(node);

                            parent = node.Parent;
                            grandparent = parent?.Parent;
                        }

                        if (parent != null)
                        {
                            parent.Color = NodeColor.Black;
                        }

                        if (grandparent != null)
                        {
                            grandparent.Color = NodeColor.Red;
                            RotateRight(grandparent);
                        }
                    }
                }
                else
                {
                    Node uncle = grandparent.Left;

                    if (uncle != null &&
                        uncle.Color == NodeColor.Red)
                    {
                        parent.Color = NodeColor.Black;
                        uncle.Color = NodeColor.Black;
                        grandparent.Color = NodeColor.Red;

                        node = grandparent;
                    }
                    else
                    {
                        if (node == parent.Left)
                        {
                            node = parent;
                            RotateRight(node);

                            parent = node.Parent;
                            grandparent = parent?.Parent;
                        }

                        if (parent != null)
                        {
                            parent.Color = NodeColor.Black;
                        }

                        if (grandparent != null)
                        {
                            grandparent.Color = NodeColor.Red;
                            RotateLeft(grandparent);
                        }
                    }
                }
            }

            if (root != null)
            {
                root.Color = NodeColor.Black;
            }
        }

        private void RotateLeft(Node node)
        {
            Node rightChild = node.Right;

            if (rightChild == null)
            {
                return;
            }

            node.Right = rightChild.Left;

            if (rightChild.Left != null)
            {
                rightChild.Left.Parent = node;
            }

            rightChild.Parent = node.Parent;

            if (node.Parent == null)
            {
                root = rightChild;
            }
            else if (node == node.Parent.Left)
            {
                node.Parent.Left = rightChild;
            }
            else
            {
                node.Parent.Right = rightChild;
            }

            rightChild.Left = node;
            node.Parent = rightChild;
        }

        private void RotateRight(Node node)
        {
            Node leftChild = node.Left;

            if (leftChild == null)
            {
                return;
            }

            node.Left = leftChild.Right;

            if (leftChild.Right != null)
            {
                leftChild.Right.Parent = node;
            }

            leftChild.Parent = node.Parent;

            if (node.Parent == null)
            {
                root = leftChild;
            }
            else if (node == node.Parent.Right)
            {
                node.Parent.Right = leftChild;
            }
            else
            {
                node.Parent.Left = leftChild;
            }

            leftChild.Right = node;
            node.Parent = leftChild;
        }

        public ReportedIssue Search(string referenceNumber)
        {
            Node current = root;

            while (current != null)
            {
                int comparison = string.Compare(
                    referenceNumber,
                    current.Issue.ReferenceNumber,
                    StringComparison.OrdinalIgnoreCase);

                if (comparison == 0)
                {
                    return current.Issue;
                }

                if (comparison < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            return null;
        }
    }
}