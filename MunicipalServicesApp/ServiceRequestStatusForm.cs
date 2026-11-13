using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MunicipalServicesApp.DataStructures;

namespace MunicipalServicesApp
{
    public partial class ServiceRequestStatusForm : Form

    {
    
        public ServiceRequestStatusForm()
        {
            InitializeComponent();
        }

        private void ServiceRequestStatusForm_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.Clear();

            cmbStatus.Items.Add("Submitted");
            cmbStatus.Items.Add("In Progress");
            cmbStatus.Items.Add("Resolved");

            cmbStatus.SelectedIndex = 0;

            LoadServiceRequests();
        }

        private void LoadServiceRequests()
        {
            lstServiceRequests.Items.Clear();

            if (IssueRepository.Issues.Count == 0)
            {
                lstServiceRequests.Items.Add(
                    "No service requests have been submitted yet.");

                return;
            }

            foreach (ReportedIssue issue in IssueRepository.Issues)
            {
                string display =
                    issue.ReferenceNumber + " | " +
                    issue.Category + " | " +
                    issue.Location + " | " +
                    issue.Status;

                lstServiceRequests.Items.Add(display);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadServiceRequests();
        }

        private void btnTrack_Click(object sender, EventArgs e)
        {
            string referenceNumber =
                txtReferenceNumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(referenceNumber))
            {
                MessageBox.Show(
                    "Please enter a reference number.",
                    "Reference Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtReferenceNumber.Focus();
                return;
            }

            // Red-Black Tree lookup
            ReportedIssue foundIssue =
                IssueRepository.FindByReferenceNumberRedBlack(
                    referenceNumber);

            if (foundIssue == null)
            {
                rtbTrackingResult.Clear();

                MessageBox.Show(
                    "No service request was found with reference number " +
                    referenceNumber + ".",
                    "Request Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DisplayIssue(foundIssue);

            cmbStatus.SelectedItem = foundIssue.Status;

            UpdateStatusProgress(foundIssue.Status);
        }

        private void btnPriority_Click(object sender, EventArgs e)
        {
            ReportedIssue priorityIssue =
                IssueRepository.GetHighestPriorityIssue();

            if (priorityIssue == null)
            {
                rtbTrackingResult.Clear();

                MessageBox.Show(
                    "There are currently no service requests.",
                    "No Requests",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            rtbTrackingResult.Text =
                "HIGHEST PRIORITY SERVICE REQUEST" +
                Environment.NewLine +
                "--------------------------------" +
                Environment.NewLine +
                "Reference Number: " +
                priorityIssue.ReferenceNumber +
                Environment.NewLine +
                "Location: " +
                priorityIssue.Location +
                Environment.NewLine +
                "Category: " +
                priorityIssue.Category +
                Environment.NewLine +
                "Description: " +
                priorityIssue.Description +
                Environment.NewLine +
                "Date Reported: " +
                priorityIssue.DateReported
                    .ToString("dd MMMM yyyy HH:mm") +
                Environment.NewLine +
                "Status: " +
                priorityIssue.Status;
        }

        private void btnRelated_Click(object sender, EventArgs e)
        {
            string referenceNumber =
                txtReferenceNumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(referenceNumber))
            {
                MessageBox.Show(
                    "Please enter a reference number first.",
                    "Reference Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtReferenceNumber.Focus();
                return;
            }

            ReportedIssue selectedIssue =
                IssueRepository.FindByReferenceNumber(
                    referenceNumber);

            if (selectedIssue == null)
            {
                rtbTrackingResult.Clear();

                MessageBox.Show(
                    "No service request was found with reference number " +
                    referenceNumber + ".",
                    "Request Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            List<ReportedIssue> relatedIssues =
                IssueRepository.GetRelatedIssues(
                    referenceNumber);

            rtbTrackingResult.Clear();

            rtbTrackingResult.AppendText(
                "RELATED SERVICE REQUESTS" +
                Environment.NewLine);

            rtbTrackingResult.AppendText(
                "Category: " +
                selectedIssue.Category +
                Environment.NewLine);

            rtbTrackingResult.AppendText(
                "--------------------------------" +
                Environment.NewLine);

            if (relatedIssues.Count == 0)
            {
                rtbTrackingResult.AppendText(
                    "No related service requests were found.");

                return;
            }

            foreach (ReportedIssue issue in relatedIssues)
            {
                rtbTrackingResult.AppendText(
                    issue.ReferenceNumber +
                    " | " +
                    issue.Category +
                    " | " +
                    issue.Location +
                    " | " +
                    issue.Status +
                    Environment.NewLine);
            }
        }

        private void DisplayIssue(ReportedIssue foundIssue)
        {
            rtbTrackingResult.Text =
                "Reference Number: " +
                foundIssue.ReferenceNumber +
                Environment.NewLine +
                "Location: " +
                foundIssue.Location +
                Environment.NewLine +
                "Category: " +
                foundIssue.Category +
                Environment.NewLine +
                "Description: " +
                foundIssue.Description +
                Environment.NewLine +
                "Date Reported: " +
                foundIssue.DateReported
                    .ToString("dd MMMM yyyy HH:mm") +
                Environment.NewLine +
                "Status: " +
                foundIssue.Status;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void btnBFS_Click(object sender, EventArgs e)
        {
            string referenceNumber =
                txtReferenceNumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(referenceNumber))
            {
                MessageBox.Show(
                    "Please enter a reference number first.",
                    "Reference Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtReferenceNumber.Focus();
                return;
            }

            List<ReportedIssue> results =
                IssueRepository.SearchGraphBFS(referenceNumber);

            rtbTrackingResult.Clear();

            rtbTrackingResult.AppendText(
                "BREADTH-FIRST SEARCH" +
                Environment.NewLine +
                "Starting from: " + referenceNumber +
                Environment.NewLine +
                "--------------------------------" +
                Environment.NewLine);

            if (results.Count == 0)
            {
                rtbTrackingResult.AppendText(
                    "No requests were found.");
                return;
            }

            foreach (ReportedIssue issue in results)
            {
                rtbTrackingResult.AppendText(
                    issue.ReferenceNumber + " | " +
                    issue.Category + " | " +
                    issue.Location + " | " +
                    issue.Status +
                    Environment.NewLine);
            }
        }

        private void btnDFS_Click(object sender, EventArgs e)
        {
            string referenceNumber =
                txtReferenceNumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(referenceNumber))
            {
                MessageBox.Show(
                    "Please enter a reference number first.",
                    "Reference Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtReferenceNumber.Focus();
                return;
            }

            List<ReportedIssue> results =
                IssueRepository.SearchGraphDFS(referenceNumber);

            rtbTrackingResult.Clear();

            rtbTrackingResult.AppendText(
                "DEPTH-FIRST SEARCH" +
                Environment.NewLine +
                "Starting from: " + referenceNumber +
                Environment.NewLine +
                "--------------------------------" +
                Environment.NewLine);

            if (results.Count == 0)
            {
                rtbTrackingResult.AppendText(
                    "No requests were found.");
                return;
            }

            foreach (ReportedIssue issue in results)
            {
                rtbTrackingResult.AppendText(
                    issue.ReferenceNumber + " | " +
                    issue.Category + " | " +
                    issue.Location + " | " +
                    issue.Status +
                    Environment.NewLine);
            }
        }

        private void btnMST_Click(object sender, EventArgs e)
        {
            if (IssueRepository.Issues.Count < 2)
            {
                MessageBox.Show(
                    "At least two service requests are required " +
                    "to generate a Minimum Spanning Tree.",
                    "Not Enough Requests",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            ServiceRequestMST mst =
                new ServiceRequestMST();

            mst.BuildConnections(
                IssueRepository.Issues);

            List<string> results =
                mst.GenerateMinimumSpanningTree();

            rtbTrackingResult.Clear();

            rtbTrackingResult.AppendText(
                "MINIMUM SPANNING TREE" +
                Environment.NewLine +
                "Optimised service request relationships" +
                Environment.NewLine +
                "--------------------------------" +
                Environment.NewLine);

            foreach (string connection in results)
            {
                rtbTrackingResult.AppendText(
                    connection +
                    Environment.NewLine);
            }
        }

        private void UpdateStatusProgress(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                prgStatus.Value = 0;
                lblProgressPercentage.Text = "0%";
                return;
            }

            switch (status.ToLower())
            {
                case "submitted":
                    prgStatus.Value = 33;
                    lblProgressPercentage.Text = "33%";
                    break;

                case "in progress":
                    prgStatus.Value = 66;
                    lblProgressPercentage.Text = "66%";
                    break;

                case "resolved":
                    prgStatus.Value = 100;
                    lblProgressPercentage.Text = "100%";
                    break;

                default:
                    prgStatus.Value = 0;
                    lblProgressPercentage.Text = "0%";
                    break;
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            string referenceNumber =
                txtReferenceNumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(referenceNumber))
            {
                MessageBox.Show(
                    "Please enter a reference number first.",
                    "Reference Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtReferenceNumber.Focus();
                return;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please select a status.",
                    "Status Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string newStatus =
                cmbStatus.SelectedItem.ToString();

            bool updated =
                IssueRepository.UpdateIssueStatus(
                    referenceNumber,
                    newStatus);

            if (!updated)
            {
                MessageBox.Show(
                    "No service request was found with reference number " +
                    referenceNumber + ".",
                    "Request Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            ReportedIssue updatedIssue =
                IssueRepository.FindByReferenceNumberRedBlack(
                    referenceNumber);

            DisplayIssue(updatedIssue);

            UpdateStatusProgress(updatedIssue.Status);

            LoadServiceRequests();

            MessageBox.Show(
                "Service request status updated successfully.",
                "Status Updated",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}