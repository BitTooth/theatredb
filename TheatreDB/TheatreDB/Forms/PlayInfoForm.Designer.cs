namespace TheatreDB.Forms
{
    partial class PlayInfoForm
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
            this.yearLabel = new System.Windows.Forms.Label();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.discountTextBox = new System.Windows.Forms.TextBox();
            this.discountLabel = new System.Windows.Forms.Label();
            this.actsTextBox = new System.Windows.Forms.TextBox();
            this.actsLabel = new System.Windows.Forms.Label();
            this.storyTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(12, 145);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(87, 13);
            this.yearLabel.TabIndex = 0;
            this.yearLabel.Text = "Год постановки";
            // 
            // yearTextBox
            // 
            this.yearTextBox.Location = new System.Drawing.Point(105, 142);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.ReadOnly = true;
            this.yearTextBox.Size = new System.Drawing.Size(52, 20);
            this.yearTextBox.TabIndex = 1;
            this.yearTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // discountTextBox
            // 
            this.discountTextBox.Location = new System.Drawing.Point(358, 142);
            this.discountTextBox.Name = "discountTextBox";
            this.discountTextBox.ReadOnly = true;
            this.discountTextBox.Size = new System.Drawing.Size(52, 20);
            this.discountTextBox.TabIndex = 3;
            this.discountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.discountTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // discountLabel
            // 
            this.discountLabel.AutoSize = true;
            this.discountLabel.Location = new System.Drawing.Point(308, 145);
            this.discountLabel.Name = "discountLabel";
            this.discountLabel.Size = new System.Drawing.Size(44, 13);
            this.discountLabel.TabIndex = 2;
            this.discountLabel.Text = "Скидка";
            this.discountLabel.Click += new System.EventHandler(this.discountLabel_Click);
            // 
            // actsTextBox
            // 
            this.actsTextBox.Location = new System.Drawing.Point(247, 142);
            this.actsTextBox.Name = "actsTextBox";
            this.actsTextBox.ReadOnly = true;
            this.actsTextBox.Size = new System.Drawing.Size(52, 20);
            this.actsTextBox.TabIndex = 5;
            this.actsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // actsLabel
            // 
            this.actsLabel.AutoSize = true;
            this.actsLabel.Location = new System.Drawing.Point(170, 145);
            this.actsLabel.Name = "actsLabel";
            this.actsLabel.Size = new System.Drawing.Size(71, 13);
            this.actsLabel.TabIndex = 4;
            this.actsLabel.Text = "Число актов";
            // 
            // storyTextBox
            // 
            this.storyTextBox.Location = new System.Drawing.Point(13, 13);
            this.storyTextBox.Name = "storyTextBox";
            this.storyTextBox.ReadOnly = true;
            this.storyTextBox.Size = new System.Drawing.Size(397, 118);
            this.storyTextBox.TabIndex = 6;
            this.storyTextBox.Text = "";
            // 
            // PlayInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 172);
            this.Controls.Add(this.storyTextBox);
            this.Controls.Add(this.actsTextBox);
            this.Controls.Add(this.actsLabel);
            this.Controls.Add(this.discountTextBox);
            this.Controls.Add(this.discountLabel);
            this.Controls.Add(this.yearTextBox);
            this.Controls.Add(this.yearLabel);
            this.Name = "PlayInfoForm";
            this.Text = "PlayInfoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.TextBox yearTextBox;
        private System.Windows.Forms.TextBox discountTextBox;
        private System.Windows.Forms.Label discountLabel;
        private System.Windows.Forms.TextBox actsTextBox;
        private System.Windows.Forms.Label actsLabel;
        private System.Windows.Forms.RichTextBox storyTextBox;
    }
}