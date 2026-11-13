using System;
using System.Collections.Generic;

namespace MunicipalServicesApp.DataStructures
{
    internal class ServiceRequestMST
    {
        private class Edge
        {
            public string From { get; set; }
            public string To { get; set; }
            public int Weight { get; set; }

            public Edge(string from, string to, int weight)
            {
                From = from;
                To = to;
                Weight = weight;
            }
        }

        private readonly List<Edge> edges =
            new List<Edge>();

        private readonly HashSet<string> vertices =
            new HashSet<string>(
                StringComparer.OrdinalIgnoreCase);

        public void AddIssue(ReportedIssue issue)
        {
            if (issue == null ||
                string.IsNullOrWhiteSpace(issue.ReferenceNumber))
            {
                return;
            }

            vertices.Add(issue.ReferenceNumber);
        }

        public void AddConnection(
            ReportedIssue firstIssue,
            ReportedIssue secondIssue)
        {
            if (firstIssue == null || secondIssue == null)
            {
                return;
            }

            if (firstIssue.ReferenceNumber.Equals(
                secondIssue.ReferenceNumber,
                StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            AddIssue(firstIssue);
            AddIssue(secondIssue);

            int weight =
                CalculateRelationshipWeight(
                    firstIssue,
                    secondIssue);

            edges.Add(
                new Edge(
                    firstIssue.ReferenceNumber,
                    secondIssue.ReferenceNumber,
                    weight));
        }

        private int CalculateRelationshipWeight(
            ReportedIssue firstIssue,
            ReportedIssue secondIssue)
        {
            int weight = 10;

            // Same category means the requests are strongly related.
            if (string.Equals(
                firstIssue.Category,
                secondIssue.Category,
                StringComparison.OrdinalIgnoreCase))
            {
                weight -= 5;
            }

            // Same location means the requests may belong
            // to the same municipal problem.
            if (string.Equals(
                firstIssue.Location,
                secondIssue.Location,
                StringComparison.OrdinalIgnoreCase))
            {
                weight -= 3;
            }

            // Same status gives an additional relationship.
            if (string.Equals(
                firstIssue.Status,
                secondIssue.Status,
                StringComparison.OrdinalIgnoreCase))
            {
                weight -= 1;
            }

            if (weight < 1)
            {
                weight = 1;
            }

            return weight;
        }

        public List<string> GenerateMinimumSpanningTree()
        {
            List<string> result =
                new List<string>();

            if (vertices.Count == 0)
            {
                return result;
            }

            List<Edge> sortedEdges =
                new List<Edge>(edges);

            sortedEdges.Sort(
                (first, second) =>
                    first.Weight.CompareTo(second.Weight));

            Dictionary<string, string> parent =
                new Dictionary<string, string>(
                    StringComparer.OrdinalIgnoreCase);

            foreach (string vertex in vertices)
            {
                parent[vertex] = vertex;
            }

            int edgesAdded = 0;

            foreach (Edge edge in sortedEdges)
            {
                string firstRoot =
                    Find(parent, edge.From);

                string secondRoot =
                    Find(parent, edge.To);

                if (!firstRoot.Equals(
                    secondRoot,
                    StringComparison.OrdinalIgnoreCase))
                {
                    parent[firstRoot] = secondRoot;

                    result.Add(
                        edge.From +
                        " <-> " +
                        edge.To +
                        " | Relationship Cost: " +
                        edge.Weight);

                    edgesAdded++;

                    if (edgesAdded == vertices.Count - 1)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        private string Find(
            Dictionary<string, string> parent,
            string vertex)
        {
            if (!parent[vertex].Equals(
                vertex,
                StringComparison.OrdinalIgnoreCase))
            {
                parent[vertex] =
                    Find(
                        parent,
                        parent[vertex]);
            }

            return parent[vertex];
        }

        public void BuildConnections(
            List<ReportedIssue> issues)
        {
            edges.Clear();
            vertices.Clear();

            if (issues == null)
            {
                return;
            }

            foreach (ReportedIssue issue in issues)
            {
                AddIssue(issue);
            }

            for (int i = 0; i < issues.Count; i++)
            {
                for (int j = i + 1; j < issues.Count; j++)
                {
                    AddConnection(
                        issues[i],
                        issues[j]);
                }
            }
        }
    }
}