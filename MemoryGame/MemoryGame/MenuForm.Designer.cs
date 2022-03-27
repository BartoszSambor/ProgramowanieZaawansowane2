
namespace MemoryGame
{
    partial class MenuForm
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
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.buttonConfigure = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonStartGame.Location = new System.Drawing.Point(100, 28);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(75, 23);
            this.buttonStartGame.TabIndex = 0;
            this.buttonStartGame.Text = "Start";
            this.buttonStartGame.UseVisualStyleBackColor = false;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            // 
            // buttonConfigure
            // 
            this.buttonConfigure.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonConfigure.Location = new System.Drawing.Point(100, 97);
            this.buttonConfigure.Name = "buttonConfigure";
            this.buttonConfigure.Size = new System.Drawing.Size(75, 23);
            this.buttonConfigure.TabIndex = 1;
            this.buttonConfigure.Text = "Konfiguracja";
            this.buttonConfigure.UseVisualStyleBackColor = false;
            this.buttonConfigure.Click += new System.EventHandler(this.buttonConfigure_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button3.Location = new System.Drawing.Point(100, 164);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Wyjdź";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonConfigure);
            this.Controls.Add(this.buttonStartGame);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.Button buttonConfigure;
        private System.Windows.Forms.Button button3;
    }
}