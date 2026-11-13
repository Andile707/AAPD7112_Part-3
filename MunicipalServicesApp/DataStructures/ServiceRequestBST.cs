using System;

namespace MunicipalServicesApp.DataStructures
{
    internal class ServiceRequestBST
    {
        private class Node
        {
            public ReportedIssue Issue { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(ReportedIssue issue)
            {
                Issue = issue;
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
                return SearchRecursive(current.Left, referenceNumber);
            }

            return SearchRecursive(current.Right, referenceNumber);
        }
    }
}