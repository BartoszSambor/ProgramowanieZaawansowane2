namespace passwordReq
{
    partial class ImageCheckBoxList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imageCheckBox4 = new passwordReq.ImageCheckBox();
            this.imageCheckBox3 = new passwordReq.ImageCheckBox();
            this.imageCheckBox2 = new passwordReq.ImageCheckBox();
            this.imageCheckBox1 = new passwordReq.ImageCheckBox();
            this.SuspendLayout();
            // 
            // imageCheckBox4
            // 
            this.imageCheckBox4.AutoSize = true;
            this.imageCheckBox4.IsChecked = false;
            this.imageCheckBox4.LabelText = " at least one digit";
            this.imageCheckBox4.Location = new System.Drawing.Point(3, 126);
            this.imageCheckBox4.Name = "imageCheckBox4";
            this.imageCheckBox4.Size = new System.Drawing.Size(190, 35);
            this.imageCheckBox4.TabIndex = 3;
            // 
            // imageCheckBox3
            // 
            this.imageCheckBox3.AutoSize = true;
            this.imageCheckBox3.IsChecked = false;
            this.imageCheckBox3.LabelText = "at least one capital letter";
            this.imageCheckBox3.Location = new System.Drawing.Point(3, 85);
            this.imageCheckBox3.Name = "imageCheckBox3";
            this.imageCheckBox3.Size = new System.Drawing.Size(190, 35);
            this.imageCheckBox3.TabIndex = 2;
            // 
            // imageCheckBox2
            // 
            this.imageCheckBox2.AutoSize = true;
            this.imageCheckBox2.IsChecked = false;
            this.imageCheckBox2.LabelText = "at least one special character";
            this.imageCheckBox2.Location = new System.Drawing.Point(3, 44);
            this.imageCheckBox2.Name = "imageCheckBox2";
            this.imageCheckBox2.Size = new System.Drawing.Size(190, 35);
            this.imageCheckBox2.TabIndex = 1;
            // 
            // imageCheckBox1
            // 
            this.imageCheckBox1.AutoSize = true;
            this.imageCheckBox1.IsChecked = false;
            this.imageCheckBox1.LabelText = "at least 8 charackers";
            this.imageCheckBox1.Location = new System.Drawing.Point(3, 3);
            this.imageCheckBox1.Name = "imageCheckBox1";
            this.imageCheckBox1.Size = new System.Drawing.Size(190, 35);
            this.imageCheckBox1.TabIndex = 0;
            // 
            // ImageCheckBoxList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.imageCheckBox4);
            this.Controls.Add(this.imageCheckBox3);
            this.Controls.Add(this.imageCheckBox2);
            this.Controls.Add(this.imageCheckBox1);
            this.Name = "ImageCheckBoxList";
            this.Size = new System.Drawing.Size(196, 164);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImageCheckBox imageCheckBox1;
        private ImageCheckBox imageCheckBox2;
        private ImageCheckBox imageCheckBox3;
        private ImageCheckBox imageCheckBox4;
    }
}
