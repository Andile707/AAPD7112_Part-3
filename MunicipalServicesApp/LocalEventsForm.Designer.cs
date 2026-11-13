namespace MunicipalServicesApp
{
    partial class LocalEventsForm
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
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpEventDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lstEvents = new System.Windows.Forms.ListBox();
            this.lblRecommendations = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstRecommendations = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstSearchHistory = new System.Windows.Forms.ListBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(373, 38);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(238, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "LOCAL EVENTS & ANNOUNCEMENTS";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Find events in your community";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(35, 121);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(65, 16);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Category:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(119, 111);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(160, 24);
            this.cmbCategory.TabIndex = 3;
            this.cmbCategory.Text = "Local Events & Announcements";
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(39, 167);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(39, 16);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date:";
            // 
            // dtpEventDate
            // 
            this.dtpEventDate.Location = new System.Drawing.Point(119, 160);
            this.dtpEventDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEventDate.Name = "dtpEventDate";
            this.dtpEventDate.Size = new System.Drawing.Size(265, 22);
            this.dtpEventDate.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.OrangeRed;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(39, 223);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 28);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.OrangeRed;
            this.btnShowAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAll.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnShowAll.Location = new System.Drawing.Point(179, 223);
            this.btnShowAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(100, 28);
            this.btnShowAll.TabIndex = 7;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 288);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "UPCOMING EVENTS";
            // 
            // lstEvents
            // 
            this.lstEvents.FormattingEnabled = true;
            this.lstEvents.ItemHeight = 16;
            this.lstEvents.Location = new System.Drawing.Point(47, 331);
            this.lstEvents.Margin = new System.Windows.Forms.Padding(4);
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(529, 116);
            this.lstEvents.TabIndex = 9;
            // 
            // lblRecommendations
            // 
            this.lblRecommendations.AutoSize = true;
            this.lblRecommendations.Location = new System.Drawing.Point(47, 500);
            this.lblRecommendations.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecommendations.Name = "lblRecommendations";
            this.lblRecommendations.Size = new System.Drawing.Size(178, 16);
            this.lblRecommendations.TabIndex = 10;
            this.lblRecommendations.Text = "RECOMMENDED FOR YOU";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 534);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Based on your recent searches:";
            // 
            // lstRecommendations
            // 
            this.lstRecommendations.FormattingEnabled = true;
            this.lstRecommendations.ItemHeight = 16;
            this.lstRecommendations.Location = new System.Drawing.Point(61, 566);
            this.lstRecommendations.Margin = new System.Windows.Forms.Padding(4);
            this.lstRecommendations.Name = "lstRecommendations";
            this.lstRecommendations.Size = new System.Drawing.Size(389, 116);
            this.lstRecommendations.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(505, 534);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Recent Searches:";
            // 
            // lstSearchHistory
            // 
            this.lstSearchHistory.FormattingEnabled = true;
            this.lstSearchHistory.ItemHeight = 16;
            this.lstSearchHistory.Location = new System.Drawing.Point(509, 566);
            this.lstSearchHistory.Margin = new System.Windows.Forms.Padding(4);
            this.lstSearchHistory.Name = "lstSearchHistory";
            this.lstSearchHistory.Size = new System.Drawing.Size(363, 116);
            this.lstSearchHistory.TabIndex = 14;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.OrangeRed;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBack.Location = new System.Drawing.Point(61, 726);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(177, 44);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "Back to Main Menu";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // LocalEventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1067, 801);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lstSearchHistory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstRecommendations);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblRecommendations);
            this.Controls.Add(this.lstEvents);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpEventDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LocalEventsForm";
            this.Text = "LocalEventsForm";
            this.Load += new System.EventHandler(this.LocalEventsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpEventDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstEvents;
        private System.Windows.Forms.Label lblRecommendations;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstRecommendations;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstSearchHistory;
        private System.Windows.Forms.Button btnBack;
    }
}