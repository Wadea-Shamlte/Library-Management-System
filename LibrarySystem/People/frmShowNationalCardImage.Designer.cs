namespace LibrarySystem.People
{
    partial class frmShowNationalCardImage
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
            this.btnClose = new System.Windows.Forms.Button();
            this.pbNationalCard = new System.Windows.Forms.PictureBox();
            this.lbNotFound = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbNationalCard)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::LibrarySystem.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1044, 601);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 28);
            this.btnClose.TabIndex = 56;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbNationalCard
            // 
            this.pbNationalCard.Location = new System.Drawing.Point(12, 12);
            this.pbNationalCard.Name = "pbNationalCard";
            this.pbNationalCard.Size = new System.Drawing.Size(1119, 571);
            this.pbNationalCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNationalCard.TabIndex = 0;
            this.pbNationalCard.TabStop = false;
            // 
            // lbNotFound
            // 
            this.lbNotFound.AutoSize = true;
            this.lbNotFound.Font = new System.Drawing.Font("Ebrima", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotFound.Location = new System.Drawing.Point(489, 300);
            this.lbNotFound.Name = "lbNotFound";
            this.lbNotFound.Size = new System.Drawing.Size(172, 40);
            this.lbNotFound.TabIndex = 57;
            this.lbNotFound.Text = "Not Found.";
            // 
            // frmShowNationalCardImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1143, 641);
            this.Controls.Add(this.lbNotFound);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pbNationalCard);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowNationalCardImage";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "National Card Image";
            this.Load += new System.EventHandler(this.frmShowNationalCardImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbNationalCard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbNationalCard;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbNotFound;
    }
}