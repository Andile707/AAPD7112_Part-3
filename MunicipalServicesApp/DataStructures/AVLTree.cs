using System;

namespace MunicipalServicesApp.DataStructures
{
    internal class AVLTree
    {
        private class Node
        {
            public ReportedIssue Issue { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Height { get; set; }

            public Node(ReportedIssue issue)
            {
                Issue = issue;
                Height = 1;
            }
        }

        private Node root;

        public void Insert(ReportedIssue issue)
        {
            root = InsertRecursive(root, issue);
        }

        private Node InsertRecursive(Node current, ReportedIssue issue)
        {
            if (current == null)
            {
                return new Node(issue);
            }

            int comparison = string.Compare(
                issue.ReferenceNumber,
                current.Issue.ReferenceNumber,
                StringComparison.OrdinalIgnoreCase);

            if (comparison < 0)
            {
                current.Left = InsertRecursive(current.Left, issue);
            }
            else if (comparison > 0)
            {
                current.Right = InsertRecursive(current.Right, issue);
            }
            else
            {
                return current;
            }

            current.Height =
                1 + Math.Max(
                    GetHeight(current.Left),
                    GetHeight(current.Right));

            int balance = GetBalance(current);

            // Left Left case
            if (balance > 1 &&
                string.Compare(
                    issue.ReferenceNumber,
                    current.Left.Issue.ReferenceNumber,
                    StringComparison.OrdinalIgnoreCase) < 0)
            {
                return RotateRight(current);
            }

            // Right Right case
            if (balance < -1 &&
                string.Compare(
                    issue.ReferenceNumber,
                    current.Right.Issue.ReferenceNumber,
                    StringComparison.OrdinalIgnoreCase) > 0)
            {
                return RotateLeft(current);
            }

            // Left Right case
            if (balance > 1 &&
                string.Compare(
                    issue.ReferenceNumber,
                    current.Left.Issue.ReferenceNumber,
                    StringComparison.OrdinalIgnoreCase) > 0)
            {
                current.Left = RotateLeft(current.Left);
                return RotateRight(current);
            }

            // Right Left case
            if (balance < -1 &&
                string.Compare(
                    issue.ReferenceNumber,
                    current.Right.Issue.ReferenceNumber,
                    StringComparison.OrdinalIgnoreCase) < 0)
            {
                current.Right = RotateRight(current.Right);
                return RotateLeft(current);
            }

            return current;
        }

        public ReportedIssue Search(string referenceNumber)
        {
            return SearchRecursive(root, referenceNumber);
        }

        private ReportedIssue SearchRecursive(
            Node current,
            string referenceNumber)
        {
            if (current == null)
            {
                return null;
            }

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
                return SearchRecursive(
                    current.Left,
                    referenceNumber);
            }

            return SearchRecursive(
                current.Right,
                referenceNumber);
        }

        private int GetHeight(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Height;
        }

        private int GetBalance(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return GetHeight(node.Left) -
                   GetHeight(node.Right);
        }

        private Node RotateRight(Node y)
        {
            Node x = y.Left;
            Node temporarySubtree = x.Right;

            x.Right = y;
            y.Left = temporarySubtree;

            y.Height =
                1 + Math.Max(
                    GetHeight(y.Left),
                    GetHeight(y.Right));

            x.Height =
                1 + Math.Max(
                    GetHeight(x.Left),
                    GetHeight(x.Right));

            return x;
        }

        private Node RotateLeft(Node x)
        {
            Node y = x.Right;
            Node temporarySubtree = y.Left;

            y.Left = x;
            x.Right = temporarySubtree;

            x.Height =
                1 + Math.Max(
                    GetHeight(x.Left),
                    GetHeight(x.Right));

            y.Height =
                1 + Math.Max(
                    GetHeight(y.Left),
                    GetHeight(y.Right));

            return y;
        }
    }
}