namespace TheatreDB.Forms
{
    partial class AdminForm
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
            this.usersButton = new System.Windows.Forms.Button();
            this.playsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usersButton
            // 
            this.usersButton.Location = new System.Drawing.Point(36, 60);
            this.usersButton.Name = "usersButton";
            this.usersButton.Size = new System.Drawing.Size(119, 23);
            this.usersButton.TabIndex = 0;
            this.usersButton.Text = "Пользователи";
            this.usersButton.UseVisualStyleBackColor = true;
            this.usersButton.Click += new System.EventHandler(this.customersButton_Click);
            // 
            // playsButton
            // 
            this.playsButton.Location = new System.Drawing.Point(36, 22);
            this.playsButton.Name = "playsButton";
            this.playsButton.Size = new System.Drawing.Size(119, 23);
            this.playsButton.TabIndex = 1;
            this.playsButton.Text = "Спектакли";
            this.playsButton.UseVisualStyleBackColor = true;
            this.playsButton.Click += new System.EventHandler(this.playsButton_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(187, 106);
            this.Controls.Add(this.playsButton);
            this.Controls.Add(this.usersButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminForm";
            this.Text = "Администрирование";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button usersButton;
        private System.Windows.Forms.Button playsButton;
    }
}