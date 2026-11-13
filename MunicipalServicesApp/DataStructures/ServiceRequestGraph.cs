using System;
using System.Collections.Generic;

namespace MunicipalServicesApp.DataStructures
{
    internal class ServiceRequestGraph
    {
        private readonly Dictionary<string, ReportedIssue> issues;
        private readonly Dictionary<string, List<string>> adjacencyList;

        public ServiceRequestGraph()
        {
            issues = new Dictionary<string, ReportedIssue>(
                StringComparer.OrdinalIgnoreCase);

            adjacencyList = new Dictionary<string, List<string>>(
                StringComparer.OrdinalIgnoreCase);
        }

        // Add a service request as a vertex
        public void AddIssue(ReportedIssue issue)
        {
            if (issue == null ||
                string.IsNullOrWhiteSpace(issue.ReferenceNumber))
            {
                return;
            }

            if (!issues.ContainsKey(issue.ReferenceNumber))
            {
                issues.Add(issue.ReferenceNumber, issue);

                adjacencyList.Add(
                    issue.ReferenceNumber,
                    new List<string>());
            }
        }

        // Create a connection between two service requests
        public void AddEdge(
            string firstReferenceNumber,
            string secondReferenceNumber)
        {
            if (string.IsNullOrWhiteSpace(firstReferenceNumber) ||
                string.IsNullOrWhiteSpace(secondReferenceNumber))
            {
                return;
            }

            if (!adjacencyList.ContainsKey(firstReferenceNumber) ||
                !adjacencyList.ContainsKey(secondReferenceNumber))
            {
                return;
            }

            if (firstReferenceNumber.Equals(
                secondReferenceNumber,
                StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            // Undirected graph:
            // A connects to B and B connects to A.
            if (!adjacencyList[firstReferenceNumber]
                .Contains(secondReferenceNumber))
            {
                adjacencyList[firstReferenceNumber]
                    .Add(secondReferenceNumber);
            }

            if (!adjacencyList[secondReferenceNumber]
                .Contains(firstReferenceNumber))
            {
                adjacencyList[secondReferenceNumber]
                    .Add(firstReferenceNumber);
            }
        }

        // Connect requests that belong to the same category
        public void ConnectRelatedIssues(ReportedIssue newIssue)
        {
            if (newIssue == null)
            {
                return;
            }

            foreach (ReportedIssue existingIssue in issues.Values)
            {
                if (existingIssue.ReferenceNumber.Equals(
                    newIssue.ReferenceNumber,
                    StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (existingIssue.Category.Equals(
                    newIssue.Category,
                    StringComparison.OrdinalIgnoreCase))
                {
                    AddEdge(
                        existingIssue.ReferenceNumber,
                        newIssue.ReferenceNumber);
                }
            }
        }

        // Breadth-First Search
        public List<ReportedIssue> BreadthFirstSearch(
            string startingReferenceNumber)
        {
            List<ReportedIssue> result =
                new List<ReportedIssue>();

            if (string.IsNullOrWhiteSpace(startingReferenceNumber) ||
                !issues.ContainsKey(startingReferenceNumber))
            {
                return result;
            }

            Queue<string> queue =
                new Queue<string>();

            HashSet<string> visited =
                new HashSet<string>(
                    StringComparer.OrdinalIgnoreCase);

            queue.Enqueue(startingReferenceNumber);
            visited.Add(startingReferenceNumber);

            while (queue.Count > 0)
            {
                string currentReference =
                    queue.Dequeue();

                result.Add(issues[currentReference]);

                foreach (string neighbour in
                         adjacencyList[currentReference])
                {
                    if (!visited.Contains(neighbour))
                    {
                        visited.Add(neighbour);
                        queue.Enqueue(neighbour);
                    }
                }
            }

            return result;
        }

        // Depth-First Search
        public List<ReportedIssue> DepthFirstSearch(
            string startingReferenceNumber)
        {
            List<ReportedIssue> result =
                new List<ReportedIssue>();

            HashSet<string> visited =
                new HashSet<string>(
                    StringComparer.OrdinalIgnoreCase);

            DepthFirstSearchRecursive(
                startingReferenceNumber,
                visited,
                result);

            return result;
        }

        private void DepthFirstSearchRecursive(
            string referenceNumber,
            HashSet<string> visited,
            List<ReportedIssue> result)
        {
            if (string.IsNullOrWhiteSpace(referenceNumber) ||
                !issues.ContainsKey(referenceNumber) ||
                visited.Contains(referenceNumber))
            {
                return;
            }

            visited.Add(referenceNumber);

            result.Add(issues[referenceNumber]);

            foreach (string neighbour in
                     adjacencyList[referenceNumber])
            {
                DepthFirstSearchRecursive(
                    neighbour,
                    visited,
                    result);
            }
        }

        // Get only directly connected requests
        public List<ReportedIssue> GetRelatedIssues(
            string referenceNumber)
        {
            List<ReportedIssue> relatedIssues =
                new List<ReportedIssue>();

            if (string.IsNullOrWhiteSpace(referenceNumber) ||
                !adjacencyList.ContainsKey(referenceNumber))
            {
                return relatedIssues;
            }

            foreach (string neighbour in
                     adjacencyList[referenceNumber])
            {
                relatedIssues.Add(issues[neighbour]);
            }

            return relatedIssues;
        }
    }
}