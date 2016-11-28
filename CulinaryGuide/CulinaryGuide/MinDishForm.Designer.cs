namespace CulinaryGuide
{
    partial class MinDishForm
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
            this.PanelForImage = new System.Windows.Forms.Panel();
            this.panel24 = new System.Windows.Forms.Panel();
            this.panel25 = new System.Windows.Forms.Panel();
            this.descriptionLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.ingredientsFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.moreThanSixIngLbl = new System.Windows.Forms.LinkLabel();
            this.nameLinkBtn = new System.Windows.Forms.Button();
            this.PanelForImage.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelForImage
            // 
            this.PanelForImage.Controls.Add(this.panel24);
            this.PanelForImage.Controls.Add(this.panel11);
            this.PanelForImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelForImage.Location = new System.Drawing.Point(0, 80);
            this.PanelForImage.Name = "PanelForImage";
            this.PanelForImage.Size = new System.Drawing.Size(200, 195);
            this.PanelForImage.TabIndex = 1;
            // 
            // panel24
            // 
            this.panel24.AutoSize = true;
            this.panel24.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel24.BackColor = System.Drawing.Color.Transparent;
            this.panel24.Controls.Add(this.panel25);
            this.panel24.Controls.Add(this.label5);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel24.Location = new System.Drawing.Point(0, 90);
            this.panel24.Margin = new System.Windows.Forms.Padding(0);
            this.panel24.Name = "panel24";
            this.panel24.Padding = new System.Windows.Forms.Padding(5);
            this.panel24.Size = new System.Drawing.Size(200, 105);
            this.panel24.TabIndex = 8;
            // 
            // panel25
            // 
            this.panel25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel25.Controls.Add(this.descriptionLbl);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel25.ForeColor = System.Drawing.Color.DarkGreen;
            this.panel25.Location = new System.Drawing.Point(5, 18);
            this.panel25.Margin = new System.Windows.Forms.Padding(5);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(190, 82);
            this.panel25.TabIndex = 1;
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoEllipsis = true;
            this.descriptionLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionLbl.Location = new System.Drawing.Point(0, 0);
            this.descriptionLbl.MaximumSize = new System.Drawing.Size(190, 0);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Size = new System.Drawing.Size(188, 80);
            this.descriptionLbl.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.ForeColor = System.Drawing.Color.SeaGreen;
            this.label5.Location = new System.Drawing.Point(5, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Описание:";
            // 
            // panel11
            // 
            this.panel11.AutoSize = true;
            this.panel11.BackColor = System.Drawing.Color.Transparent;
            this.panel11.Controls.Add(this.ingredientsFLP);
            this.panel11.Controls.Add(this.label3);
            this.panel11.Controls.Add(this.moreThanSixIngLbl);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Margin = new System.Windows.Forms.Padding(0);
            this.panel11.MaximumSize = new System.Drawing.Size(200, 90);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(200, 90);
            this.panel11.TabIndex = 7;
            this.panel11.Paint += new System.Windows.Forms.PaintEventHandler(this.panel11_Paint);
            // 
            // ingredientsFLP
            // 
            this.ingredientsFLP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ingredientsFLP.AutoSize = true;
            this.ingredientsFLP.Location = new System.Drawing.Point(5, 20);
            this.ingredientsFLP.Margin = new System.Windows.Forms.Padding(5);
            this.ingredientsFLP.MaximumSize = new System.Drawing.Size(190, 60);
            this.ingredientsFLP.MinimumSize = new System.Drawing.Size(19, 0);
            this.ingredientsFLP.Name = "ingredientsFLP";
            this.ingredientsFLP.Size = new System.Drawing.Size(190, 10);
            this.ingredientsFLP.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.SeaGreen;
            this.label3.Location = new System.Drawing.Point(2, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ингридиенты";
            // 
            // moreThanSixIngLbl
            // 
            this.moreThanSixIngLbl.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.moreThanSixIngLbl.AutoSize = true;
            this.moreThanSixIngLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.moreThanSixIngLbl.Location = new System.Drawing.Point(80, 17);
            this.moreThanSixIngLbl.Name = "moreThanSixIngLbl";
            this.moreThanSixIngLbl.Size = new System.Drawing.Size(29, 20);
            this.moreThanSixIngLbl.TabIndex = 1;
            this.moreThanSixIngLbl.TabStop = true;
            this.moreThanSixIngLbl.Text = ". . .";
            this.moreThanSixIngLbl.Visible = false;
            // 
            // nameLinkBtn
            // 
            this.nameLinkBtn.AutoSize = true;
            this.nameLinkBtn.BackColor = System.Drawing.Color.SeaGreen;
            this.nameLinkBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.nameLinkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nameLinkBtn.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLinkBtn.Location = new System.Drawing.Point(0, 0);
            this.nameLinkBtn.MaximumSize = new System.Drawing.Size(0, 90);
            this.nameLinkBtn.Name = "nameLinkBtn";
            this.nameLinkBtn.Size = new System.Drawing.Size(200, 80);
            this.nameLinkBtn.TabIndex = 0;
            this.nameLinkBtn.UseVisualStyleBackColor = false;
            this.nameLinkBtn.Click += new System.EventHandler(this.nameLinkBtn_Click);
            // 
            // MinDishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.PanelForImage);
            this.Controls.Add(this.nameLinkBtn);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MinDishForm";
            this.Size = new System.Drawing.Size(200, 275);
            this.PanelForImage.ResumeLayout(false);
            this.PanelForImage.PerformLayout();
            this.panel24.ResumeLayout(false);
            this.panel24.PerformLayout();
            this.panel25.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel PanelForImage;
        private System.Windows.Forms.Panel panel24;
        private System.Windows.Forms.Panel panel25;
        private System.Windows.Forms.Label descriptionLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.FlowLayoutPanel ingredientsFLP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel moreThanSixIngLbl;
        private System.Windows.Forms.Button nameLinkBtn;
    }
}
