namespace laba3b
{
    partial class Form1
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
            this.ListBoxFeeds = new System.Windows.Forms.ListBox();
            this.LabelPageTitle = new System.Windows.Forms.Label();
            this.TextBoxNewLink = new System.Windows.Forms.TextBox();
            this.ListBoxFeedItems = new System.Windows.Forms.ListBox();
            this.WebBrowserMain = new System.Windows.Forms.WebBrowser();
            this.ButtonAddFeed = new System.Windows.Forms.Button();
            this.ButtonBeginSending = new System.Windows.Forms.Button();
            this.ButtonAddRecipient = new System.Windows.Forms.Button();
            this.NumericUpDownHours = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDownDays = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDownMinutes = new System.Windows.Forms.NumericUpDown();
            this.LabelSeconds = new System.Windows.Forms.Label();
            this.LabelHours = new System.Windows.Forms.Label();
            this.LabelDays = new System.Windows.Forms.Label();
            this.ListBoxRecepients = new System.Windows.Forms.ListBox();
            this.TextBoxNewRecipient = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // ListBoxFeeds
            // 
            this.ListBoxFeeds.FormattingEnabled = true;
            this.ListBoxFeeds.ItemHeight = 16;
            this.ListBoxFeeds.Location = new System.Drawing.Point(12, 5);
            this.ListBoxFeeds.Name = "ListBoxFeeds";
            this.ListBoxFeeds.Size = new System.Drawing.Size(630, 132);
            this.ListBoxFeeds.TabIndex = 11;
            // 
            // LabelPageTitle
            // 
            this.LabelPageTitle.AutoSize = true;
            this.LabelPageTitle.Location = new System.Drawing.Point(743, 170);
            this.LabelPageTitle.Name = "LabelPageTitle";
            this.LabelPageTitle.Size = new System.Drawing.Size(0, 17);
            this.LabelPageTitle.TabIndex = 10;
            // 
            // TextBoxNewLink
            // 
            this.TextBoxNewLink.Location = new System.Drawing.Point(12, 142);
            this.TextBoxNewLink.Name = "TextBoxNewLink";
            this.TextBoxNewLink.Size = new System.Drawing.Size(486, 22);
            this.TextBoxNewLink.TabIndex = 9;
            this.TextBoxNewLink.Text = "https://www.ibm.com/developerworks/views/global/rss/libraryview.jsp";
            // 
            // ListBoxFeedItems
            // 
            this.ListBoxFeedItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListBoxFeedItems.FormattingEnabled = true;
            this.ListBoxFeedItems.HorizontalScrollbar = true;
            this.ListBoxFeedItems.ItemHeight = 16;
            this.ListBoxFeedItems.Location = new System.Drawing.Point(12, 170);
            this.ListBoxFeedItems.Name = "ListBoxFeedItems";
            this.ListBoxFeedItems.Size = new System.Drawing.Size(331, 500);
            this.ListBoxFeedItems.TabIndex = 8;
            this.ListBoxFeedItems.SelectedIndexChanged += new System.EventHandler(this.ListBoxFeedItems_SelectedIndexChanged);
            // 
            // WebBrowserMain
            // 
            this.WebBrowserMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WebBrowserMain.Location = new System.Drawing.Point(349, 202);
            this.WebBrowserMain.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBrowserMain.Name = "WebBrowserMain";
            this.WebBrowserMain.Size = new System.Drawing.Size(971, 468);
            this.WebBrowserMain.TabIndex = 7;
            // 
            // ButtonAddFeed
            // 
            this.ButtonAddFeed.Location = new System.Drawing.Point(504, 141);
            this.ButtonAddFeed.Name = "ButtonAddFeed";
            this.ButtonAddFeed.Size = new System.Drawing.Size(138, 23);
            this.ButtonAddFeed.TabIndex = 6;
            this.ButtonAddFeed.Text = "Add RSS feed";
            this.ButtonAddFeed.UseVisualStyleBackColor = true;
            this.ButtonAddFeed.Click += new System.EventHandler(this.ButtonAddFeed_Click);
            // 
            // ButtonBeginSending
            // 
            this.ButtonBeginSending.Location = new System.Drawing.Point(648, 141);
            this.ButtonBeginSending.Name = "ButtonBeginSending";
            this.ButtonBeginSending.Size = new System.Drawing.Size(138, 23);
            this.ButtonBeginSending.TabIndex = 12;
            this.ButtonBeginSending.Text = "Start sending news";
            this.ButtonBeginSending.UseVisualStyleBackColor = true;
            this.ButtonBeginSending.Click += new System.EventHandler(this.ButtonBeginSending_Click);
            // 
            // ButtonAddRecipient
            // 
            this.ButtonAddRecipient.Location = new System.Drawing.Point(792, 140);
            this.ButtonAddRecipient.Name = "ButtonAddRecipient";
            this.ButtonAddRecipient.Size = new System.Drawing.Size(137, 23);
            this.ButtonAddRecipient.TabIndex = 13;
            this.ButtonAddRecipient.Text = "Add recipient";
            this.ButtonAddRecipient.UseVisualStyleBackColor = true;
            this.ButtonAddRecipient.Click += new System.EventHandler(this.ButtonAddRecipient_Click);
            // 
            // NumericUpDownHours
            // 
            this.NumericUpDownHours.Location = new System.Drawing.Point(648, 55);
            this.NumericUpDownHours.Name = "NumericUpDownHours";
            this.NumericUpDownHours.Size = new System.Drawing.Size(61, 22);
            this.NumericUpDownHours.TabIndex = 14;
            // 
            // NumericUpDownDays
            // 
            this.NumericUpDownDays.Location = new System.Drawing.Point(648, 113);
            this.NumericUpDownDays.Name = "NumericUpDownDays";
            this.NumericUpDownDays.Size = new System.Drawing.Size(61, 22);
            this.NumericUpDownDays.TabIndex = 15;
            // 
            // NumericUpDownMinutes
            // 
            this.NumericUpDownMinutes.Location = new System.Drawing.Point(649, 5);
            this.NumericUpDownMinutes.Name = "NumericUpDownMinutes";
            this.NumericUpDownMinutes.Size = new System.Drawing.Size(60, 22);
            this.NumericUpDownMinutes.TabIndex = 16;
            // 
            // LabelSeconds
            // 
            this.LabelSeconds.AutoSize = true;
            this.LabelSeconds.Location = new System.Drawing.Point(716, 5);
            this.LabelSeconds.Name = "LabelSeconds";
            this.LabelSeconds.Size = new System.Drawing.Size(57, 17);
            this.LabelSeconds.TabIndex = 17;
            this.LabelSeconds.Text = "Minutes";
            // 
            // LabelHours
            // 
            this.LabelHours.AutoSize = true;
            this.LabelHours.Location = new System.Drawing.Point(716, 55);
            this.LabelHours.Name = "LabelHours";
            this.LabelHours.Size = new System.Drawing.Size(46, 17);
            this.LabelHours.TabIndex = 18;
            this.LabelHours.Text = "Hours";
            // 
            // LabelDays
            // 
            this.LabelDays.AutoSize = true;
            this.LabelDays.Location = new System.Drawing.Point(715, 113);
            this.LabelDays.Name = "LabelDays";
            this.LabelDays.Size = new System.Drawing.Size(40, 17);
            this.LabelDays.TabIndex = 19;
            this.LabelDays.Text = "Days";
            // 
            // ListBoxRecepients
            // 
            this.ListBoxRecepients.FormattingEnabled = true;
            this.ListBoxRecepients.ItemHeight = 16;
            this.ListBoxRecepients.Location = new System.Drawing.Point(793, 5);
            this.ListBoxRecepients.Name = "ListBoxRecepients";
            this.ListBoxRecepients.Size = new System.Drawing.Size(532, 132);
            this.ListBoxRecepients.TabIndex = 20;
            // 
            // TextBoxNewRecipient
            // 
            this.TextBoxNewRecipient.Location = new System.Drawing.Point(935, 141);
            this.TextBoxNewRecipient.Name = "TextBoxNewRecipient";
            this.TextBoxNewRecipient.Size = new System.Drawing.Size(390, 22);
            this.TextBoxNewRecipient.TabIndex = 21;
            this.TextBoxNewRecipient.Text = "andy844551@gmail.com";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 674);
            this.Controls.Add(this.TextBoxNewRecipient);
            this.Controls.Add(this.ListBoxRecepients);
            this.Controls.Add(this.LabelDays);
            this.Controls.Add(this.LabelHours);
            this.Controls.Add(this.LabelSeconds);
            this.Controls.Add(this.NumericUpDownMinutes);
            this.Controls.Add(this.NumericUpDownDays);
            this.Controls.Add(this.NumericUpDownHours);
            this.Controls.Add(this.ButtonAddRecipient);
            this.Controls.Add(this.ButtonBeginSending);
            this.Controls.Add(this.ListBoxFeeds);
            this.Controls.Add(this.LabelPageTitle);
            this.Controls.Add(this.TextBoxNewLink);
            this.Controls.Add(this.ListBoxFeedItems);
            this.Controls.Add(this.WebBrowserMain);
            this.Controls.Add(this.ButtonAddFeed);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownMinutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxFeeds;
        private System.Windows.Forms.Label LabelPageTitle;
        private System.Windows.Forms.TextBox TextBoxNewLink;
        private System.Windows.Forms.ListBox ListBoxFeedItems;
        private System.Windows.Forms.WebBrowser WebBrowserMain;
        private System.Windows.Forms.Button ButtonAddFeed;
        private System.Windows.Forms.Button ButtonBeginSending;
        private System.Windows.Forms.Button ButtonAddRecipient;
        private System.Windows.Forms.NumericUpDown NumericUpDownHours;
        private System.Windows.Forms.NumericUpDown NumericUpDownDays;
        private System.Windows.Forms.NumericUpDown NumericUpDownMinutes;
        private System.Windows.Forms.Label LabelSeconds;
        private System.Windows.Forms.Label LabelHours;
        private System.Windows.Forms.Label LabelDays;
        private System.Windows.Forms.ListBox ListBoxRecepients;
        private System.Windows.Forms.TextBox TextBoxNewRecipient;
    }
}

