namespace View
{
    partial class Popup
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
            this.rchComment = new System.Windows.Forms.RichTextBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // rchComment
            // 
            this.rchComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(220)))), ((int)(((byte)(248)))));
            this.rchComment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rchComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rchComment.Location = new System.Drawing.Point(142, 10);
            this.rchComment.Name = "rchComment";
            this.rchComment.ReadOnly = true;
            this.rchComment.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rchComment.Size = new System.Drawing.Size(202, 245);
            this.rchComment.TabIndex = 0;
            this.rchComment.Text = "";
            this.rchComment.Click += new System.EventHandler(this.rchComment_Click);
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(11, 10);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(120, 120);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 1;
            this.picImage.TabStop = false;
            // 
            // Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.rchComment);
            this.Name = "Popup";
            this.Size = new System.Drawing.Size(354, 266);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchComment;
        private System.Windows.Forms.PictureBox picImage;
    }
}
