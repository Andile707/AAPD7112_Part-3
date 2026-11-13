using System.Collections.Generic;
using MunicipalServicesApp.DataStructures;

namespace MunicipalServicesApp
{
    public static class IssueRepository
    {
        public static List<ReportedIssue> Issues { get; }
            = new List<ReportedIssue>();

        private static ServiceRequestBST requestTree
            = new ServiceRequestBST();

        private static AVLTree avlTree
            = new AVLTree();

        private static RedBlackTree redBlackTree
            = new RedBlackTree();

        private static MinHeap priorityHeap
            = new MinHeap();

        private static ServiceRequestGraph requestGraph
            = new ServiceRequestGraph();

        public static void AddIssue(ReportedIssue issue)
        {
            Issues.Add(issue);

            // Binary Search Tree
            requestTree.Insert(issue);

            // AVL Tree
            avlTree.Insert(issue);

            // Red-Black Tree
            redBlackTree.Insert(issue);

            // Min Heap
            priorityHeap.Insert(issue);

            // Graph
            requestGraph.AddIssue(issue);
            requestGraph.ConnectRelatedIssues(issue);
        }

        public static ReportedIssue FindByReferenceNumber(
            string referenceNumber)
        {
            if (string.IsNullOrWhiteSpace(referenceNumber))
            {
                return null;
            }

            return requestTree.Search(referenceNumber.Trim());
        }

        public static ReportedIssue FindByReferenceNumberAVL(
            string referenceNumber)
        {
            if (string.IsNullOrWhiteSpace(referenceNumber))
            {
                return null;
            }

            return avlTree.Search(referenceNumber.Trim());
        }

        public static ReportedIssue FindByReferenceNumberRedBlack(
            string referenceNumber)
        {
            if (string.IsNullOrWhiteSpace(referenceNumber))
            {
                return null;
            }

            return redBlackTree.Search(referenceNumber.Trim());
        }

        public static ReportedIssue GetHighestPriorityIssue()
        {
            return priorityHeap.Peek();
        }

        public static ReportedIssue RemoveHighestPriorityIssue()
        {
            return priorityHeap.RemoveMin();
        }

        public static List<ReportedIssue> GetRelatedIssues(
            string referenceNumber)
        {
            if (string.IsNullOrWhiteSpace(referenceNumber))
            {
                return new List<ReportedIssue>();
            }

            return requestGraph.GetRelatedIssues(
                referenceNumber.Trim());
        }

        public static List<ReportedIssue> SearchGraphBFS(
            string referenceNumber)
        {
            if (string.IsNullOrWhiteSpace(referenceNumber))
            {
                return new List<ReportedIssue>();
            }

            return requestGraph.BreadthFirstSearch(
                referenceNumber.Trim());
        }

        public static List<ReportedIssue> SearchGraphDFS(
            string referenceNumber)
        {
            if (string.IsNullOrWhiteSpace(referenceNumber))
            {
                return new List<ReportedIssue>();
            }

            return requestGraph.DepthFirstSearch(
                referenceNumber.Trim());
        }

        public static bool UpdateIssueStatus(
                string referenceNumber,
                  string newStatus)
        {
            if (string.IsNullOrWhiteSpace(referenceNumber) ||
                string.IsNullOrWhiteSpace(newStatus))
            {
                return false;
            }

            ReportedIssue issue =
                FindByReferenceNumberRedBlack(
                    referenceNumber.Trim());

            if (issue == null)
            {
                return false;
            }

            issue.Status = newStatus;

            return true;
        }
    }
}