namespace Desktop.Forms
{
    partial class Main
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbProfile = new System.Windows.Forms.Label();
            this.pnProfile = new System.Windows.Forms.Panel();
            this.lbOrders = new System.Windows.Forms.Label();
            this.pnOrders = new System.Windows.Forms.Panel();
            this.lbCatalogue = new System.Windows.Forms.Label();
            this.pnCatalogue = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1600, 109);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.lbProfile);
            this.panel2.Controls.Add(this.pnProfile);
            this.panel2.Controls.Add(this.lbOrders);
            this.panel2.Controls.Add(this.pnOrders);
            this.panel2.Controls.Add(this.lbCatalogue);
            this.panel2.Controls.Add(this.pnCatalogue);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(193, 739);
            this.panel2.TabIndex = 0;
            // 
            // lbProfile
            // 
            this.lbProfile.AutoSize = true;
            this.lbProfile.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbProfile.ForeColor = System.Drawing.Color.White;
            this.lbProfile.Location = new System.Drawing.Point(63, 688);
            this.lbProfile.Name = "lbProfile";
            this.lbProfile.Size = new System.Drawing.Size(86, 31);
            this.lbProfile.TabIndex = 8;
            this.lbProfile.Text = "Profile";
            this.lbProfile.Click += new System.EventHandler(this.lbProfile_Click);
            // 
            // pnProfile
            // 
            this.pnProfile.BackgroundImage = global::Desktop.Properties.Resources.user;
            this.pnProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnProfile.Location = new System.Drawing.Point(11, 675);
            this.pnProfile.Name = "pnProfile";
            this.pnProfile.Size = new System.Drawing.Size(46, 54);
            this.pnProfile.TabIndex = 7;
            this.pnProfile.Click += new System.EventHandler(this.pnProfile_Click);
            // 
            // lbOrders
            // 
            this.lbOrders.AutoSize = true;
            this.lbOrders.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbOrders.ForeColor = System.Drawing.Color.White;
            this.lbOrders.Location = new System.Drawing.Point(74, 268);
            this.lbOrders.Name = "lbOrders";
            this.lbOrders.Size = new System.Drawing.Size(85, 31);
            this.lbOrders.TabIndex = 6;
            this.lbOrders.Text = "Orders";
            this.lbOrders.Click += new System.EventHandler(this.lbOrders_Click);
            // 
            // pnOrders
            // 
            this.pnOrders.BackgroundImage = global::Desktop.Properties.Resources.order_delivery;
            this.pnOrders.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnOrders.Location = new System.Drawing.Point(11, 256);
            this.pnOrders.Name = "pnOrders";
            this.pnOrders.Size = new System.Drawing.Size(46, 54);
            this.pnOrders.TabIndex = 3;
            // 
            // lbCatalogue
            // 
            this.lbCatalogue.AutoSize = true;
            this.lbCatalogue.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbCatalogue.ForeColor = System.Drawing.Color.White;
            this.lbCatalogue.Location = new System.Drawing.Point(60, 183);
            this.lbCatalogue.Name = "lbCatalogue";
            this.lbCatalogue.Size = new System.Drawing.Size(122, 31);
            this.lbCatalogue.TabIndex = 5;
            this.lbCatalogue.Text = "Catalogue";
            this.lbCatalogue.Click += new System.EventHandler(this.lbCatalogue_Click);
            // 
            // pnCatalogue
            // 
            this.pnCatalogue.BackgroundImage = global::Desktop.Properties.Resources.catalogue;
            this.pnCatalogue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnCatalogue.Location = new System.Drawing.Point(11, 174);
            this.pnCatalogue.Name = "pnCatalogue";
            this.pnCatalogue.Size = new System.Drawing.Size(46, 54);
            this.pnCatalogue.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = global::Desktop.Properties.Resources.logo1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 109);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelContent
            // 
            this.panelContent.Location = new System.Drawing.Point(193, 106);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1408, 633);
            this.panelContent.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1602, 738);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.Text = "Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label lbProfile;
        private Panel pnProfile;
        private Label lbOrders;
        private Panel pnOrders;
        private Label lbCatalogue;
        private Panel pnCatalogue;
        private PictureBox pictureBox1;
        private Panel panelContent;
    }
}