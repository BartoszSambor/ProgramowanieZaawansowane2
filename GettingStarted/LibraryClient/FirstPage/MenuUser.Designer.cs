namespace LibraryClient.FirstPage
{
    partial class MenuUser
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
            this.buttonMyBooks = new System.Windows.Forms.Button();
            this.buttonHistory = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonSubscriptions = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonMyBooks
            // 
            this.buttonMyBooks.Location = new System.Drawing.Point(105, 12);
            this.buttonMyBooks.Name = "buttonMyBooks";
            this.buttonMyBooks.Size = new System.Drawing.Size(75, 23);
            this.buttonMyBooks.TabIndex = 5;
            this.buttonMyBooks.Text = "My books";
            this.buttonMyBooks.UseVisualStyleBackColor = true;
            this.buttonMyBooks.Click += new System.EventHandler(this.buttonMyBooks_Click);
            // 
            // buttonHistory
            // 
            this.buttonHistory.Location = new System.Drawing.Point(186, 12);
            this.buttonHistory.Name = "buttonHistory";
            this.buttonHistory.Size = new System.Drawing.Size(75, 23);
            this.buttonHistory.TabIndex = 4;
            this.buttonHistory.Text = "History";
            this.buttonHistory.UseVisualStyleBackColor = true;
            this.buttonHistory.Click += new System.EventHandler(this.buttonHistory_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(3, 12);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(96, 23);
            this.buttonBrowse.TabIndex = 3;
            this.buttonBrowse.Text = "Browse books";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonSubscriptions
            // 
            this.buttonSubscriptions.Location = new System.Drawing.Point(267, 12);
            this.buttonSubscriptions.Name = "buttonSubscriptions";
            this.buttonSubscriptions.Size = new System.Drawing.Size(90, 23);
            this.buttonSubscriptions.TabIndex = 6;
            this.buttonSubscriptions.Text = "Subscriptions";
            this.buttonSubscriptions.UseVisualStyleBackColor = true;
            this.buttonSubscriptions.Click += new System.EventHandler(this.buttonSubscriptions_Click);
            // 
            // MenuUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 63);
            this.Controls.Add(this.buttonSubscriptions);
            this.Controls.Add(this.buttonMyBooks);
            this.Controls.Add(this.buttonHistory);
            this.Controls.Add(this.buttonBrowse);
            this.Name = "MenuUser";
            this.Text = "MenuUser";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonMyBooks;
        private System.Windows.Forms.Button buttonHistory;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonSubscriptions;
    }
}