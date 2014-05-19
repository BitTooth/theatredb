namespace TheatreDB.Forms
{
    partial class NewPlayForm
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.storyLabel = new System.Windows.Forms.Label();
            this.storyRichTextBox = new System.Windows.Forms.RichTextBox();
            this.yearLabel = new System.Windows.Forms.Label();
            this.yearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.actsLabel = new System.Windows.Forms.Label();
            this.actsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.discountLabel = new System.Windows.Forms.Label();
            this.discountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(13, 13);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(57, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Название";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(89, 10);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(258, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // storyLabel
            // 
            this.storyLabel.AutoSize = true;
            this.storyLabel.Location = new System.Drawing.Point(13, 43);
            this.storyLabel.Name = "storyLabel";
            this.storyLabel.Size = new System.Drawing.Size(41, 13);
            this.storyLabel.TabIndex = 2;
            this.storyLabel.Text = "Сюжет";
            // 
            // storyRichTextBox
            // 
            this.storyRichTextBox.Location = new System.Drawing.Point(89, 40);
            this.storyRichTextBox.Name = "storyRichTextBox";
            this.storyRichTextBox.Size = new System.Drawing.Size(258, 131);
            this.storyRichTextBox.TabIndex = 3;
            this.storyRichTextBox.Text = "";
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(13, 186);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(25, 13);
            this.yearLabel.TabIndex = 4;
            this.yearLabel.Text = "Год";
            // 
            // yearNumericUpDown
            // 
            this.yearNumericUpDown.Location = new System.Drawing.Point(89, 184);
            this.yearNumericUpDown.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.yearNumericUpDown.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.yearNumericUpDown.Name = "yearNumericUpDown";
            this.yearNumericUpDown.Size = new System.Drawing.Size(67, 20);
            this.yearNumericUpDown.TabIndex = 5;
            this.yearNumericUpDown.Value = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            // 
            // actsLabel
            // 
            this.actsLabel.AutoSize = true;
            this.actsLabel.Location = new System.Drawing.Point(13, 217);
            this.actsLabel.Name = "actsLabel";
            this.actsLabel.Size = new System.Drawing.Size(67, 13);
            this.actsLabel.TabIndex = 6;
            this.actsLabel.Text = "Кол-о актов";
            // 
            // actsNumericUpDown
            // 
            this.actsNumericUpDown.Location = new System.Drawing.Point(89, 215);
            this.actsNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.actsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.actsNumericUpDown.Name = "actsNumericUpDown";
            this.actsNumericUpDown.Size = new System.Drawing.Size(67, 20);
            this.actsNumericUpDown.TabIndex = 7;
            this.actsNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // discountLabel
            // 
            this.discountLabel.AutoSize = true;
            this.discountLabel.Location = new System.Drawing.Point(13, 249);
            this.discountLabel.Name = "discountLabel";
            this.discountLabel.Size = new System.Drawing.Size(44, 13);
            this.discountLabel.TabIndex = 8;
            this.discountLabel.Text = "Скидка";
            // 
            // discountNumericUpDown
            // 
            this.discountNumericUpDown.Location = new System.Drawing.Point(89, 247);
            this.discountNumericUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.discountNumericUpDown.Name = "discountNumericUpDown";
            this.discountNumericUpDown.Size = new System.Drawing.Size(67, 20);
            this.discountNumericUpDown.TabIndex = 9;
            this.discountNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(217, 212);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // NewPlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 279);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.discountNumericUpDown);
            this.Controls.Add(this.discountLabel);
            this.Controls.Add(this.actsNumericUpDown);
            this.Controls.Add(this.actsLabel);
            this.Controls.Add(this.yearNumericUpDown);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.storyRichTextBox);
            this.Controls.Add(this.storyLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewPlayForm";
            this.Text = "Новый спектакль";
            ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label storyLabel;
        private System.Windows.Forms.RichTextBox storyRichTextBox;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.NumericUpDown yearNumericUpDown;
        private System.Windows.Forms.Label actsLabel;
        private System.Windows.Forms.NumericUpDown actsNumericUpDown;
        private System.Windows.Forms.Label discountLabel;
        private System.Windows.Forms.NumericUpDown discountNumericUpDown;
        private System.Windows.Forms.Button saveButton;
    }
}