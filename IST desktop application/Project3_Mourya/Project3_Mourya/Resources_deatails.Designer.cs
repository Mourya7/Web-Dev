namespace Project3_Mourya
{
    partial class Resources_deatails
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
            this.txt_resourcedetails = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_resourcedetails
            // 
            this.txt_resourcedetails.Cursor = System.Windows.Forms.Cursors.Default;
            this.txt_resourcedetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_resourcedetails.Location = new System.Drawing.Point(0, 0);
            this.txt_resourcedetails.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_resourcedetails.Multiline = true;
            this.txt_resourcedetails.Name = "txt_resourcedetails";
            this.txt_resourcedetails.ReadOnly = true;
            this.txt_resourcedetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_resourcedetails.Size = new System.Drawing.Size(734, 531);
            this.txt_resourcedetails.TabIndex = 0;
            // 
            // Resources_deatails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 531);
            this.Controls.Add(this.txt_resourcedetails);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Resources_deatails";
            this.Text = "Resources";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_resourcedetails;
    }
}