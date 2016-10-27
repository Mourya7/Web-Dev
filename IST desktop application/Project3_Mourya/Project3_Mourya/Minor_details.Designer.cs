namespace Project3_Mourya
{
    partial class Minor_details
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
            this.txt_minordetails = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_minordetails
            // 
            this.txt_minordetails.Cursor = System.Windows.Forms.Cursors.Default;
            this.txt_minordetails.Location = new System.Drawing.Point(144, 78);
            this.txt_minordetails.Margin = new System.Windows.Forms.Padding(2);
            this.txt_minordetails.Multiline = true;
            this.txt_minordetails.Name = "txt_minordetails";
            this.txt_minordetails.ReadOnly = true;
            this.txt_minordetails.Size = new System.Drawing.Size(472, 308);
            this.txt_minordetails.TabIndex = 0;
            // 
            // Minor_details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 439);
            this.Controls.Add(this.txt_minordetails);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Minor_details";
            this.Text = "Minor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_minordetails;
    }
}