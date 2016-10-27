namespace Project3_Mourya
{
    partial class Research_details
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
            this.txt_researchdetails = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_researchdetails
            // 
            this.txt_researchdetails.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txt_researchdetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_researchdetails.Location = new System.Drawing.Point(0, 0);
            this.txt_researchdetails.Margin = new System.Windows.Forms.Padding(2);
            this.txt_researchdetails.Multiline = true;
            this.txt_researchdetails.Name = "txt_researchdetails";
            this.txt_researchdetails.ReadOnly = true;
            this.txt_researchdetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_researchdetails.Size = new System.Drawing.Size(614, 423);
            this.txt_researchdetails.TabIndex = 0;
            // 
            // Research_details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 423);
            this.Controls.Add(this.txt_researchdetails);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Research_details";
            this.Text = "Citations";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_researchdetails;
    }
}