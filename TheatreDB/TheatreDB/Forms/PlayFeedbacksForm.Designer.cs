namespace TheatreDB.Forms
{
    partial class PlayFeedbacksForm
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
            this.feedbackRichTextBox = new System.Windows.Forms.RichTextBox();
            this.leaveFeedbackButton = new System.Windows.Forms.Button();
            this.myFeedbackRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // feedbackRichTextBox
            // 
            this.feedbackRichTextBox.Location = new System.Drawing.Point(13, 13);
            this.feedbackRichTextBox.Name = "feedbackRichTextBox";
            this.feedbackRichTextBox.ReadOnly = true;
            this.feedbackRichTextBox.Size = new System.Drawing.Size(350, 320);
            this.feedbackRichTextBox.TabIndex = 0;
            this.feedbackRichTextBox.Text = "";
            // 
            // leaveFeedbackButton
            // 
            this.leaveFeedbackButton.Location = new System.Drawing.Point(134, 464);
            this.leaveFeedbackButton.Name = "leaveFeedbackButton";
            this.leaveFeedbackButton.Size = new System.Drawing.Size(108, 23);
            this.leaveFeedbackButton.TabIndex = 1;
            this.leaveFeedbackButton.Text = "Отправить отзыв";
            this.leaveFeedbackButton.UseVisualStyleBackColor = true;
            this.leaveFeedbackButton.Click += new System.EventHandler(this.leaveFeedbackButton_Click);
            // 
            // myFeedbackRichTextBox
            // 
            this.myFeedbackRichTextBox.Location = new System.Drawing.Point(13, 351);
            this.myFeedbackRichTextBox.Name = "myFeedbackRichTextBox";
            this.myFeedbackRichTextBox.Size = new System.Drawing.Size(349, 107);
            this.myFeedbackRichTextBox.TabIndex = 2;
            this.myFeedbackRichTextBox.Text = "";
            // 
            // FeedbacksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 495);
            this.Controls.Add(this.myFeedbackRichTextBox);
            this.Controls.Add(this.leaveFeedbackButton);
            this.Controls.Add(this.feedbackRichTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FeedbacksForm";
            this.Text = "Отзывы";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox feedbackRichTextBox;
        private System.Windows.Forms.Button leaveFeedbackButton;
        private System.Windows.Forms.RichTextBox myFeedbackRichTextBox;
    }
}