namespace TheatreDB.Forms
{
    partial class BuyTicketForm
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
            this.Label = new System.Windows.Forms.Label();
            this.dateСomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.hallСomboBox = new System.Windows.Forms.ComboBox();
            this.seatLabel = new System.Windows.Forms.Label();
            this.hallSeatsComboBox = new System.Windows.Forms.ComboBox();
            this.buyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Location = new System.Drawing.Point(13, 13);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(77, 13);
            this.Label.TabIndex = 0;
            this.Label.Text = "Дата и время";
            // 
            // dateСomboBox
            // 
            this.dateСomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dateСomboBox.FormattingEnabled = true;
            this.dateСomboBox.Location = new System.Drawing.Point(96, 10);
            this.dateСomboBox.Name = "dateСomboBox";
            this.dateСomboBox.Size = new System.Drawing.Size(132, 21);
            this.dateСomboBox.TabIndex = 1;
            this.dateСomboBox.SelectedIndexChanged += new System.EventHandler(this.dateСomboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Зал";
            // 
            // hallСomboBox
            // 
            this.hallСomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hallСomboBox.FormattingEnabled = true;
            this.hallСomboBox.Location = new System.Drawing.Point(96, 41);
            this.hallСomboBox.Name = "hallСomboBox";
            this.hallСomboBox.Size = new System.Drawing.Size(132, 21);
            this.hallСomboBox.TabIndex = 3;
            this.hallСomboBox.SelectedIndexChanged += new System.EventHandler(this.hallСomboBox_SelectedIndexChanged);
            // 
            // seatLabel
            // 
            this.seatLabel.AutoSize = true;
            this.seatLabel.Location = new System.Drawing.Point(13, 75);
            this.seatLabel.Name = "seatLabel";
            this.seatLabel.Size = new System.Drawing.Size(39, 13);
            this.seatLabel.TabIndex = 4;
            this.seatLabel.Text = "Место";
            // 
            // hallSeatsComboBox
            // 
            this.hallSeatsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hallSeatsComboBox.FormattingEnabled = true;
            this.hallSeatsComboBox.Location = new System.Drawing.Point(96, 72);
            this.hallSeatsComboBox.Name = "hallSeatsComboBox";
            this.hallSeatsComboBox.Size = new System.Drawing.Size(132, 21);
            this.hallSeatsComboBox.TabIndex = 5;
            this.hallSeatsComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // buyButton
            // 
            this.buyButton.Location = new System.Drawing.Point(86, 113);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(75, 23);
            this.buyButton.TabIndex = 6;
            this.buyButton.Text = "Купить";
            this.buyButton.UseVisualStyleBackColor = true;
            this.buyButton.Click += new System.EventHandler(this.buyButton_Click);
            // 
            // BuyTicketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 148);
            this.Controls.Add(this.buyButton);
            this.Controls.Add(this.hallSeatsComboBox);
            this.Controls.Add(this.seatLabel);
            this.Controls.Add(this.hallСomboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateСomboBox);
            this.Controls.Add(this.Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuyTicketForm";
            this.Text = "Покупка билета";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.ComboBox dateСomboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox hallСomboBox;
        private System.Windows.Forms.Label seatLabel;
        private System.Windows.Forms.ComboBox hallSeatsComboBox;
        private System.Windows.Forms.Button buyButton;
    }
}