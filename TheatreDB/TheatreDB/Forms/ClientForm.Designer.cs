namespace TheatreDB.Forms
{
    partial class ClientForm
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
            this.genreLabel = new System.Windows.Forms.Label();
            this.genresСomboBox = new System.Windows.Forms.ComboBox();
            this.playsListBox = new System.Windows.Forms.ListBox();
            this.ticketButton = new System.Windows.Forms.Button();
            this.feedbacksButton = new System.Windows.Forms.Button();
            this.infoButton = new System.Windows.Forms.Button();
            this.dividerLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.actorsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Location = new System.Drawing.Point(13, 13);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(36, 13);
            this.genreLabel.TabIndex = 0;
            this.genreLabel.Text = "Жанр";
            // 
            // genresСomboBox
            // 
            this.genresСomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genresСomboBox.FormattingEnabled = true;
            this.genresСomboBox.Location = new System.Drawing.Point(55, 10);
            this.genresСomboBox.Name = "genresСomboBox";
            this.genresСomboBox.Size = new System.Drawing.Size(121, 21);
            this.genresСomboBox.TabIndex = 1;
            this.genresСomboBox.SelectedIndexChanged += new System.EventHandler(this.genresСomboBox_SelectedIndexChanged);
            // 
            // playsListBox
            // 
            this.playsListBox.FormattingEnabled = true;
            this.playsListBox.Location = new System.Drawing.Point(12, 37);
            this.playsListBox.Name = "playsListBox";
            this.playsListBox.Size = new System.Drawing.Size(366, 160);
            this.playsListBox.TabIndex = 2;
            this.playsListBox.SelectedIndexChanged += new System.EventHandler(this.playsListBox_SelectedIndexChanged);
            // 
            // ticketButton
            // 
            this.ticketButton.Location = new System.Drawing.Point(148, 207);
            this.ticketButton.Name = "ticketButton";
            this.ticketButton.Size = new System.Drawing.Size(99, 23);
            this.ticketButton.TabIndex = 3;
            this.ticketButton.Text = "Купить билет";
            this.ticketButton.UseVisualStyleBackColor = true;
            this.ticketButton.Click += new System.EventHandler(this.ticketButton_Click);
            // 
            // feedbacksButton
            // 
            this.feedbacksButton.Location = new System.Drawing.Point(253, 207);
            this.feedbacksButton.Name = "feedbacksButton";
            this.feedbacksButton.Size = new System.Drawing.Size(99, 23);
            this.feedbacksButton.TabIndex = 4;
            this.feedbacksButton.Text = "Отзывы";
            this.feedbacksButton.UseVisualStyleBackColor = true;
            this.feedbacksButton.Click += new System.EventHandler(this.feedbacksButton_Click);
            // 
            // infoButton
            // 
            this.infoButton.Location = new System.Drawing.Point(43, 207);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(99, 23);
            this.infoButton.TabIndex = 5;
            this.infoButton.Text = "Описание";
            this.infoButton.UseVisualStyleBackColor = true;
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // dividerLabel
            // 
            this.dividerLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dividerLabel.Location = new System.Drawing.Point(16, 242);
            this.dividerLabel.Name = "dividerLabel";
            this.dividerLabel.Size = new System.Drawing.Size(357, 2);
            this.dividerLabel.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Актеры театра";
            // 
            // actorsListBox
            // 
            this.actorsListBox.FormattingEnabled = true;
            this.actorsListBox.Location = new System.Drawing.Point(19, 274);
            this.actorsListBox.Name = "actorsListBox";
            this.actorsListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.actorsListBox.Size = new System.Drawing.Size(351, 108);
            this.actorsListBox.TabIndex = 8;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 393);
            this.Controls.Add(this.actorsListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dividerLabel);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.feedbacksButton);
            this.Controls.Add(this.ticketButton);
            this.Controls.Add(this.playsListBox);
            this.Controls.Add(this.genresСomboBox);
            this.Controls.Add(this.genreLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientForm";
            this.Text = "Спектакли и актеры";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.ComboBox genresСomboBox;
        private System.Windows.Forms.ListBox playsListBox;
        private System.Windows.Forms.Button ticketButton;
        private System.Windows.Forms.Button feedbacksButton;
        private System.Windows.Forms.Button infoButton;
        private System.Windows.Forms.Label dividerLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox actorsListBox;
    }
}