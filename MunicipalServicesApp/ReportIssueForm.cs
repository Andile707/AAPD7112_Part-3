using System;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ReportIssueForm : Form
    {
        public ReportIssueForm()
        {
            InitializeComponent();
        }

        private void ReportIssueForm_Load(object sender, EventArgs e)
        {
            cmbCategory.Items.Clear();
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDown;
            cmbCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCategory.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbCategory.Items.Add("Roads");
            cmbCategory.Items.Add("Water and Sanitation");
            cmbCategory.Items.Add("Electricity");
            cmbCategory.Items.Add("Waste Management");
            cmbCategory.Items.Add("Public Safety");
            cmbCategory.Items.Add("Other");

            cmbCategory.SelectedIndex = -1;

            UpdateProgress();
        }

        private void UpdateProgress()
        {
            int progress = 0;

            if (!string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                progress += 25;
            }

            if (!string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                progress += 25;
            }

            if (!string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                progress += 25;
            }

            if (!string.IsNullOrWhiteSpace(txtAttachment.Text))
            {
                progress += 25;
            }

            progressReport.Value = progress;

            if (progress == 0)
            {
                lblProgress.Text = "Start completing the report.";
            }
            else if (progress <= 50)
            {
                lblProgress.Text = "Good start! Keep going.";
            }
            else if (progress < 100)
            {
                lblProgress.Text = "Almost there!";
            }
            else
            {
                lblProgress.Text =
                    "Great! Your report is ready to submit.";
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title =
                    "Select an image or document";

                openFileDialog.Filter =
                    "Supported Files|*.jpg;*.jpeg;*.png;*.pdf;*.doc;*.docx|" +
                    "Image Files|*.jpg;*.jpeg;*.png|" +
                    "PDF Files|*.pdf|" +
                    "Word Documents|*.doc;*.docx|" +
                    "All Files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtAttachment.Text =
                        openFileDialog.FileName;

                    UpdateProgress();
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show(
                    "Please enter the location of the issue.",
                    "Location Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtLocation.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show(
                    "Please select or enter a category.",
                    "Category Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbCategory.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show(
                    "Please provide a description of the issue.",
                    "Description Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDescription.Focus();
                return;
            }

            // Generate a unique reference number
            string referenceNumber =
                "MS-" +
                (IssueRepository.Issues.Count + 1)
                .ToString("D4");

            // Create the reported issue
            ReportedIssue issue = new ReportedIssue
            {
                ReferenceNumber = referenceNumber,
                Location = txtLocation.Text.Trim(),
                Category = cmbCategory.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                AttachmentPath = txtAttachment.Text.Trim(),
                DateReported = DateTime.Now,
                Status = "Submitted"
            };

            // Add to repository.
            // The repository inserts the issue into:
            // List
            // BST
            // AVL Tree
            // Red-Black Tree
            IssueRepository.AddIssue(issue);

            MessageBox.Show(
                "Your issue has been submitted successfully.\n\n" +
                "Reference Number: " + referenceNumber +
                "\nStatus: Submitted",
                "Report Submitted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ClearForm();
        }

        private void ClearForm()
        {
            txtLocation.Clear();
            cmbCategory.SelectedIndex = -1;
            cmbCategory.Text = "";
            txtDescription.Clear();
            txtAttachment.Clear();

            UpdateProgress();

            txtLocation.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLocation_TextChanged(
            object sender,
            EventArgs e)
        {
            UpdateProgress();
        }

        private void txtDescription_TextChanged(
            object sender,
            EventArgs e)
        {
            UpdateProgress();
        }

        private void cmbCategory_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            UpdateProgress();
        }

        private void cmbCategory_TextChanged(
          object sender,
            EventArgs e)
        {
            UpdateProgress();
        }

        private void txtAttachment_TextChanged(
            object sender,
            EventArgs e)
        {
            UpdateProgress();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }


        private void btnViewSubmittedIssues_Click(
            object sender, EventArgs e)
        {
            ServiceRequestStatusForm statusForm =
                new ServiceRequestStatusForm();

            statusForm.ShowDialog();
        }

    }
}