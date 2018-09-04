namespace View
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axCoPDFXCview1 = new AxPDFXCviewAxLib.AxCoPDFXCview();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblShadow = new System.Windows.Forms.Label();
            this.popup1 = new View.Popup();
            ((System.ComponentModel.ISupportInitialize)(this.axCoPDFXCview1)).BeginInit();
            this.SuspendLayout();
            // 
            // axCoPDFXCview1
            // 
            this.axCoPDFXCview1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axCoPDFXCview1.Enabled = true;
            this.axCoPDFXCview1.Location = new System.Drawing.Point(0, 0);
            this.axCoPDFXCview1.Name = "axCoPDFXCview1";
            this.axCoPDFXCview1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axCoPDFXCview1.OcxState")));
            this.axCoPDFXCview1.Size = new System.Drawing.Size(922, 871);
            this.axCoPDFXCview1.TabIndex = 0;
            this.axCoPDFXCview1.OnEvent += new AxPDFXCviewAxLib._IPDFXCviewEvents_OnEventEventHandler(this.axCoPDFXCview1_OnEvent);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "PDF files (*.pdf)|*.pdf";
            // 
            // lblShadow
            // 
            this.lblShadow.BackColor = System.Drawing.Color.Gray;
            this.lblShadow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblShadow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShadow.Location = new System.Drawing.Point(142, 78);
            this.lblShadow.Name = "lblShadow";
            this.lblShadow.Size = new System.Drawing.Size(184, 229);
            this.lblShadow.TabIndex = 2;
            this.lblShadow.Visible = false;
            // 
            // popup1
            // 
            this.popup1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.popup1.Comment = "";
            this.popup1.Location = new System.Drawing.Point(89, 34);
            this.popup1.Name = "popup1";
            this.popup1.Size = new System.Drawing.Size(357, 268);
            this.popup1.TabIndex = 4;
            this.popup1.Visible = false;
            this.popup1.Click += new System.EventHandler(this.popup1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 872);
            this.Controls.Add(this.popup1);
            this.Controls.Add(this.lblShadow);
            this.Controls.Add(this.axCoPDFXCview1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "PDF Map Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.axCoPDFXCview1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxPDFXCviewAxLib.AxCoPDFXCview axCoPDFXCview1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblShadow;
        private Popup popup1;
        // private MoreRealisticShadowLabel lblPopup;
    }
}

