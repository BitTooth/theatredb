namespace TheatreDB.Forms
{
    partial class TicketsForm
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
            this.ticketsListBox = new System.Windows.Forms.ListBox();
            this.playsListBox = new System.Windows.Forms.ListBox();
            this.buyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ticketsListBox
            // 
            this.ticketsListBox.FormattingEnabled = true;
            this.ticketsListBox.Location = new System.Drawing.Point(12, 103);
            this.ticketsListBox.MultiColumn = true;
            this.ticketsListBox.Name = "ticketsListBox";
            this.ticketsListBox.Size = new System.Drawing.Size(272, 186);
            this.ticketsListBox.TabIndex = 0;
            // 
            // playsListBox
            // 
            this.playsListBox.FormattingEnabled = true;
            this.playsListBox.Location = new System.Drawing.Point(12, 13);
            this.playsListBox.Name = "playsListBox";
            this.playsListBox.Size = new System.Drawing.Size(272, 82);
            this.playsListBox.TabIndex = 1;
            // 
            // buyButton
            // 
            this.buyButton.Location = new System.Drawing.Point(112, 295);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(75, 23);
            this.buyButton.TabIndex = 2;
            this.buyButton.Text = "Купить";
            this.buyButton.UseVisualStyleBackColor = true;
            // 
            // TicketsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 325);
            this.Controls.Add(this.buyButton);
            this.Controls.Add(this.playsListBox);
            this.Controls.Add(this.ticketsListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TicketsForm";
            this.Text = "Покупа билета";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TicketsForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ticketsListBox;
        private System.Windows.Forms.ListBox playsListBox;
        private System.Windows.Forms.Button buyButton;
    }
}