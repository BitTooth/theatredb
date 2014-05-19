namespace TheatreDB.Forms
{
    partial class EditPlayForm
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
            this.repetLabel = new System.Windows.Forms.Label();
            this.instanceLabel = new System.Windows.Forms.Label();
            this.instanceTimePicker = new System.Windows.Forms.DateTimePicker();
            this.repetTimePicker = new System.Windows.Forms.DateTimePicker();
            this.prevRepetButton = new System.Windows.Forms.Button();
            this.nextRepetButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.prevInstButton = new System.Windows.Forms.Button();
            this.nextInstButton = new System.Windows.Forms.Button();
            this.repetAddButton = new System.Windows.Forms.Button();
            this.instAddButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // repetLabel
            // 
            this.repetLabel.AutoSize = true;
            this.repetLabel.Location = new System.Drawing.Point(13, 13);
            this.repetLabel.Name = "repetLabel";
            this.repetLabel.Size = new System.Drawing.Size(89, 13);
            this.repetLabel.TabIndex = 0;
            this.repetLabel.Text = "Дата репетиции";
            // 
            // instanceLabel
            // 
            this.instanceLabel.AutoSize = true;
            this.instanceLabel.Location = new System.Drawing.Point(13, 35);
            this.instanceLabel.Name = "instanceLabel";
            this.instanceLabel.Size = new System.Drawing.Size(96, 13);
            this.instanceLabel.TabIndex = 1;
            this.instanceLabel.Text = "Дата проведения";
            // 
            // instanceTimePicker
            // 
            this.instanceTimePicker.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.instanceTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.instanceTimePicker.Location = new System.Drawing.Point(115, 35);
            this.instanceTimePicker.Name = "instanceTimePicker";
            this.instanceTimePicker.Size = new System.Drawing.Size(141, 20);
            this.instanceTimePicker.TabIndex = 3;
            this.instanceTimePicker.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // repetTimePicker
            // 
            this.repetTimePicker.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.repetTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.repetTimePicker.Location = new System.Drawing.Point(115, 12);
            this.repetTimePicker.Name = "repetTimePicker";
            this.repetTimePicker.Size = new System.Drawing.Size(141, 20);
            this.repetTimePicker.TabIndex = 4;
            this.repetTimePicker.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // prevRepetButton
            // 
            this.prevRepetButton.Location = new System.Drawing.Point(262, 11);
            this.prevRepetButton.Name = "prevRepetButton";
            this.prevRepetButton.Size = new System.Drawing.Size(22, 22);
            this.prevRepetButton.TabIndex = 5;
            this.prevRepetButton.Text = "<";
            this.prevRepetButton.UseVisualStyleBackColor = true;
            this.prevRepetButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // nextRepetButton
            // 
            this.nextRepetButton.Location = new System.Drawing.Point(290, 11);
            this.nextRepetButton.Name = "nextRepetButton";
            this.nextRepetButton.Size = new System.Drawing.Size(22, 22);
            this.nextRepetButton.TabIndex = 6;
            this.nextRepetButton.Text = ">";
            this.nextRepetButton.UseVisualStyleBackColor = true;
            this.nextRepetButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(262, 62);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(88, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // prevInstButton
            // 
            this.prevInstButton.Location = new System.Drawing.Point(262, 34);
            this.prevInstButton.Name = "prevInstButton";
            this.prevInstButton.Size = new System.Drawing.Size(22, 22);
            this.prevInstButton.TabIndex = 8;
            this.prevInstButton.Text = "<";
            this.prevInstButton.UseVisualStyleBackColor = true;
            this.prevInstButton.Click += new System.EventHandler(this.prevInstButton_Click);
            // 
            // nextInstButton
            // 
            this.nextInstButton.Location = new System.Drawing.Point(290, 34);
            this.nextInstButton.Name = "nextInstButton";
            this.nextInstButton.Size = new System.Drawing.Size(22, 22);
            this.nextInstButton.TabIndex = 9;
            this.nextInstButton.Text = ">";
            this.nextInstButton.UseVisualStyleBackColor = true;
            this.nextInstButton.Click += new System.EventHandler(this.nextInstButton_Click);
            // 
            // repetAddButton
            // 
            this.repetAddButton.Location = new System.Drawing.Point(328, 11);
            this.repetAddButton.Name = "repetAddButton";
            this.repetAddButton.Size = new System.Drawing.Size(22, 22);
            this.repetAddButton.TabIndex = 10;
            this.repetAddButton.Text = "+";
            this.repetAddButton.UseVisualStyleBackColor = true;
            this.repetAddButton.Click += new System.EventHandler(this.repetAddButton_Click);
            // 
            // instAddButton
            // 
            this.instAddButton.Location = new System.Drawing.Point(328, 34);
            this.instAddButton.Name = "instAddButton";
            this.instAddButton.Size = new System.Drawing.Size(22, 22);
            this.instAddButton.TabIndex = 11;
            this.instAddButton.Text = "+";
            this.instAddButton.UseVisualStyleBackColor = true;
            this.instAddButton.Click += new System.EventHandler(this.instAddButton_Click);
            // 
            // EditPlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 94);
            this.Controls.Add(this.instAddButton);
            this.Controls.Add(this.repetAddButton);
            this.Controls.Add(this.nextInstButton);
            this.Controls.Add(this.prevInstButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.nextRepetButton);
            this.Controls.Add(this.prevRepetButton);
            this.Controls.Add(this.repetTimePicker);
            this.Controls.Add(this.instanceTimePicker);
            this.Controls.Add(this.instanceLabel);
            this.Controls.Add(this.repetLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditPlayForm";
            this.Text = "Редактирование";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label repetLabel;
        private System.Windows.Forms.Label instanceLabel;
        private System.Windows.Forms.DateTimePicker instanceTimePicker;
        private System.Windows.Forms.DateTimePicker repetTimePicker;
        private System.Windows.Forms.Button prevRepetButton;
        private System.Windows.Forms.Button nextRepetButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button prevInstButton;
        private System.Windows.Forms.Button nextInstButton;
        private System.Windows.Forms.Button repetAddButton;
        private System.Windows.Forms.Button instAddButton;
    }
}