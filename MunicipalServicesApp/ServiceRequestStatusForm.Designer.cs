namespace MunicipalServicesApp
{
    partial class ServiceRequestStatusForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblRequests = new System.Windows.Forms.Label();
            this.lstServiceRequests = new System.Windows.Forms.ListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtReferenceNumber = new System.Windows.Forms.TextBox();
            this.btnTrack = new System.Windows.Forms.Button();
            this.rtbTrackingResult = new System.Windows.Forms.RichTextBox();
            this.btnPriority = new System.Windows.Forms.Button();
            this.btnRelated = new System.Windows.Forms.Button();
            this.btnBFS = new System.Windows.Forms.Button();
            this.btnDFS = new System.Windows.Forms.Button();
            this.btnMST = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.prgStatus = new System.Windows.Forms.ProgressBar();
            this.lblProgressPercentage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(79, 30);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(192, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "SERVICE REQUEST STATUS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 132);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reference Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 215);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "SERVICE REQUESTS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 379);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "TRACKING RESULT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 567);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Progress:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.OrangeRed;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBack.Location = new System.Drawing.Point(591, 716);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(188, 58);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back to Main Menu";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblRequests
            // 
            this.lblRequests.AutoSize = true;
            this.lblRequests.Location = new System.Drawing.Point(53, 71);
            this.lblRequests.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRequests.Name = "lblRequests";
            this.lblRequests.Size = new System.Drawing.Size(177, 16);
            this.lblRequests.TabIndex = 6;
            this.lblRequests.Text = "Submitted Service Requests";
            // 
            // lstServiceRequests
            // 
            this.lstServiceRequests.FormattingEnabled = true;
            this.lstServiceRequests.ItemHeight = 16;
            this.lstServiceRequests.Location = new System.Drawing.Point(57, 235);
            this.lstServiceRequests.Margin = new System.Windows.Forms.Padding(4);
            this.lstServiceRequests.Name = "lstServiceRequests";
            this.lstServiceRequests.Size = new System.Drawing.Size(380, 116);
            this.lstServiceRequests.TabIndex = 7;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.OrangeRed;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRefresh.Location = new System.Drawing.Point(53, 524);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(103, 39);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtReferenceNumber
            // 
            this.txtReferenceNumber.Location = new System.Drawing.Point(53, 153);
            this.txtReferenceNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtReferenceNumber.Name = "txtReferenceNumber";
            this.txtReferenceNumber.Size = new System.Drawing.Size(132, 22);
            this.txtReferenceNumber.TabIndex = 9;
            // 
            // btnTrack
            // 
            this.btnTrack.BackColor = System.Drawing.Color.OrangeRed;
            this.btnTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTrack.Location = new System.Drawing.Point(258, 153);
            this.btnTrack.Margin = new System.Windows.Forms.Padding(4);
            this.btnTrack.Name = "btnTrack";
            this.btnTrack.Size = new System.Drawing.Size(152, 39);
            this.btnTrack.TabIndex = 10;
            this.btnTrack.Text = "Track Request";
            this.btnTrack.UseVisualStyleBackColor = false;
            this.btnTrack.Click += new System.EventHandler(this.btnTrack_Click);
            // 
            // rtbTrackingResult
            // 
            this.rtbTrackingResult.Location = new System.Drawing.Point(57, 399);
            this.rtbTrackingResult.Margin = new System.Windows.Forms.Padding(4);
            this.rtbTrackingResult.Name = "rtbTrackingResult";
            this.rtbTrackingResult.ReadOnly = true;
            this.rtbTrackingResult.Size = new System.Drawing.Size(380, 117);
            this.rtbTrackingResult.TabIndex = 11;
            this.rtbTrackingResult.Text = "";
            // 
            // btnPriority
            // 
            this.btnPriority.BackColor = System.Drawing.Color.OrangeRed;
            this.btnPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPriority.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPriority.Location = new System.Drawing.Point(424, 151);
            this.btnPriority.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPriority.Name = "btnPriority";
            this.btnPriority.Size = new System.Drawing.Size(152, 39);
            this.btnPriority.TabIndex = 12;
            this.btnPriority.Text = "Highest Priority";
            this.btnPriority.UseVisualStyleBackColor = false;
            this.btnPriority.Click += new System.EventHandler(this.btnPriority_Click);
            // 
            // btnRelated
            // 
            this.btnRelated.BackColor = System.Drawing.Color.OrangeRed;
            this.btnRelated.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelated.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRelated.Location = new System.Drawing.Point(590, 150);
            this.btnRelated.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRelated.Name = "btnRelated";
            this.btnRelated.Size = new System.Drawing.Size(185, 39);
            this.btnRelated.TabIndex = 13;
            this.btnRelated.Text = "Related Requests";
            this.btnRelated.UseVisualStyleBackColor = false;
            this.btnRelated.Click += new System.EventHandler(this.btnRelated_Click);
            // 
            // btnBFS
            // 
            this.btnBFS.BackColor = System.Drawing.Color.OrangeRed;
            this.btnBFS.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBFS.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBFS.Location = new System.Drawing.Point(789, 150);
            this.btnBFS.Margin = new System.Windows.Forms.Padding(4);
            this.btnBFS.Name = "btnBFS";
            this.btnBFS.Size = new System.Drawing.Size(152, 39);
            this.btnBFS.TabIndex = 14;
            this.btnBFS.Text = "BFS";
            this.btnBFS.UseVisualStyleBackColor = false;
            this.btnBFS.Click += new System.EventHandler(this.btnBFS_Click);
            // 
            // btnDFS
            // 
            this.btnDFS.BackColor = System.Drawing.Color.OrangeRed;
            this.btnDFS.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDFS.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDFS.Location = new System.Drawing.Point(955, 151);
            this.btnDFS.Margin = new System.Windows.Forms.Padding(4);
            this.btnDFS.Name = "btnDFS";
            this.btnDFS.Size = new System.Drawing.Size(152, 39);
            this.btnDFS.TabIndex = 15;
            this.btnDFS.Text = "DFS";
            this.btnDFS.UseVisualStyleBackColor = false;
            this.btnDFS.Click += new System.EventHandler(this.btnDFS_Click);
            // 
            // btnMST
            // 
            this.btnMST.BackColor = System.Drawing.Color.OrangeRed;
            this.btnMST.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMST.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMST.Location = new System.Drawing.Point(1121, 153);
            this.btnMST.Margin = new System.Windows.Forms.Padding(4);
            this.btnMST.Name = "btnMST";
            this.btnMST.Size = new System.Drawing.Size(152, 39);
            this.btnMST.TabIndex = 16;
            this.btnMST.Text = "MST";
            this.btnMST.UseVisualStyleBackColor = false;
            this.btnMST.Click += new System.EventHandler(this.btnMST_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(57, 588);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(160, 24);
            this.cmbStatus.TabIndex = 17;
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.BackColor = System.Drawing.Color.OrangeRed;
            this.btnUpdateStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateStatus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdateStatus.Location = new System.Drawing.Point(53, 620);
            this.btnUpdateStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(143, 44);
            this.btnUpdateStatus.TabIndex = 18;
            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.UseVisualStyleBackColor = false;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // prgStatus
            // 
            this.prgStatus.Location = new System.Drawing.Point(53, 684);
            this.prgStatus.Margin = new System.Windows.Forms.Padding(4);
            this.prgStatus.Name = "prgStatus";
            this.prgStatus.Size = new System.Drawing.Size(133, 28);
            this.prgStatus.TabIndex = 19;
            // 
            // lblProgressPercentage
            // 
            this.lblProgressPercentage.AutoSize = true;
            this.lblProgressPercentage.Location = new System.Drawing.Point(53, 729);
            this.lblProgressPercentage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProgressPercentage.Name = "lblProgressPercentage";
            this.lblProgressPercentage.Size = new System.Drawing.Size(26, 16);
            this.lblProgressPercentage.TabIndex = 20;
            this.lblProgressPercentage.Text = "0%";
            // 
            // ServiceRequestStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1455, 799);
            this.Controls.Add(this.lblProgressPercentage);
            this.Controls.Add(this.prgStatus);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnMST);
            this.Controls.Add(this.btnDFS);
            this.Controls.Add(this.btnBFS);
            this.Controls.Add(this.btnRelated);
            this.Controls.Add(this.btnPriority);
            this.Controls.Add(this.rtbTrackingResult);
            this.Controls.Add(this.btnTrack);
            this.Controls.Add(this.txtReferenceNumber);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lstServiceRequests);
            this.Controls.Add(this.lblRequests);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ServiceRequestStatusForm";
            this.Text = "ServiceRequestStatusForm";
            this.Load += new System.EventHandler(this.ServiceRequestStatusForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblRequests;
        private System.Windows.Forms.ListBox lstServiceRequests;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtReferenceNumber;
        private System.Windows.Forms.Button btnTrack;
        private System.Windows.Forms.RichTextBox rtbTrackingResult;
        private System.Windows.Forms.Button btnPriority;
        private System.Windows.Forms.Button btnRelated;
        private System.Windows.Forms.Button btnBFS;
        private System.Windows.Forms.Button btnDFS;
        private System.Windows.Forms.Button btnMST;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.ProgressBar prgStatus;
        private System.Windows.Forms.Label lblProgressPercentage;
    }
}