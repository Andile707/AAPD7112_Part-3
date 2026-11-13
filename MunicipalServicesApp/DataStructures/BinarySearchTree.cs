using System;

namespace MunicipalServicesApp.DataStructures
{
    public class BinarySearchTree
    {
        private class Node
        {
            public string ReferenceNumber { get; set; }
            public ReportedIssue Issue { get; set; }

            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(ReportedIssue issue)
            {
                Issue = issue;
                ReferenceNumber = issue.ReferenceNumber;
                Left = null;
                Right = null;
            }
        }

        private Node root;

        public BinarySearchTree()
        {
            root = null;
        }

        // Insert a reported issue into the BST
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
                current.ReferenceNumber,
                StringComparison.OrdinalIgnoreCase);

            if (comparison < 0)
            {
                current.Left = InsertRecursive(current.Left, issue);
            }
            else if (comparison > 0)
            {
                current.Right = InsertRecursive(current.Right, issue);
            }

            return current;
        }

        // Search for an issue using its reference number
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
                current.ReferenceNumber,
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
    }
}