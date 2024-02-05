namespace Desktop.Forms
{
    partial class CatalogueForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.itemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addedByEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DeleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ItemImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lbAddItem = new System.Windows.Forms.Label();
            this.pnAddItem = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeColumns = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemID,
            this.Image,
            this.itemName,
            this.dataGridViewTextBoxColumn1,
            this.subCategory,
            this.unit,
            this.price,
            this.addedByEmployee,
            this.EditButton,
            this.DeleteButton});
            this.dgvItems.GridColor = System.Drawing.Color.White;
            this.dgvItems.Location = new System.Drawing.Point(12, 109);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.RowHeadersWidth = 51;
            this.dgvItems.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvItems.RowTemplate.Height = 29;
            this.dgvItems.ShowEditingIcon = false;
            this.dgvItems.Size = new System.Drawing.Size(1384, 512);
            this.dgvItems.TabIndex = 0;
            this.dgvItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellClick);
            // 
            // itemID
            // 
            this.itemID.DataPropertyName = "ItemID";
            this.itemID.FillWeight = 72.6184F;
            this.itemID.HeaderText = "#";
            this.itemID.MinimumWidth = 6;
            this.itemID.Name = "itemID";
            this.itemID.ReadOnly = true;
            // 
            // Image
            // 
            this.Image.DataPropertyName = "ItemPicture";
            this.Image.FillWeight = 121.01F;
            this.Image.HeaderText = "Item picture";
            this.Image.MinimumWidth = 6;
            this.Image.Name = "Image";
            this.Image.ReadOnly = true;
            // 
            // itemName
            // 
            this.itemName.DataPropertyName = "ItemName";
            this.itemName.FillWeight = 121.01F;
            this.itemName.HeaderText = "Name";
            this.itemName.MinimumWidth = 6;
            this.itemName.Name = "itemName";
            this.itemName.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CategoryName";
            this.dataGridViewTextBoxColumn1.FillWeight = 121.01F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Category";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // subCategory
            // 
            this.subCategory.DataPropertyName = "Name";
            this.subCategory.FillWeight = 121.01F;
            this.subCategory.HeaderText = "Sub-category";
            this.subCategory.MinimumWidth = 6;
            this.subCategory.Name = "subCategory";
            this.subCategory.ReadOnly = true;
            // 
            // unit
            // 
            this.unit.DataPropertyName = "Unit";
            this.unit.FillWeight = 121.01F;
            this.unit.HeaderText = "Unit";
            this.unit.MinimumWidth = 6;
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            // 
            // price
            // 
            this.price.DataPropertyName = "Price";
            this.price.FillWeight = 121.01F;
            this.price.HeaderText = "Price";
            this.price.MinimumWidth = 6;
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // addedByEmployee
            // 
            this.addedByEmployee.DataPropertyName = "AddedByEmployee";
            this.addedByEmployee.FillWeight = 90.75856F;
            this.addedByEmployee.HeaderText = "Added by";
            this.addedByEmployee.MinimumWidth = 6;
            this.addedByEmployee.Name = "addedByEmployee";
            this.addedByEmployee.ReadOnly = true;
            // 
            // EditButton
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.EditButton.DefaultCellStyle = dataGridViewCellStyle1;
            this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditButton.HeaderText = "";
            this.EditButton.MinimumWidth = 6;
            this.EditButton.Name = "EditButton";
            this.EditButton.ReadOnly = true;
            this.EditButton.Text = "Edit";
            this.EditButton.UseColumnTextForButtonValue = true;
            // 
            // DeleteButton
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Salmon;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Salmon;
            this.DeleteButton.DefaultCellStyle = dataGridViewCellStyle2;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.HeaderText = "";
            this.DeleteButton.MinimumWidth = 6;
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.ReadOnly = true;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseColumnTextForButtonValue = true;
            // 
            // ItemImage
            // 
            this.ItemImage.HeaderText = "";
            this.ItemImage.MinimumWidth = 6;
            this.ItemImage.Name = "ItemImage";
            this.ItemImage.Width = 125;
            // 
            // Category
            // 
            this.Category.HeaderText = "";
            this.Category.MinimumWidth = 6;
            this.Category.Name = "Category";
            this.Category.Width = 125;
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(1075, 38);
            this.tbSearch.Multiline = true;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(289, 31);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // lbAddItem
            // 
            this.lbAddItem.AutoSize = true;
            this.lbAddItem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbAddItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbAddItem.Location = new System.Drawing.Point(61, 33);
            this.lbAddItem.Name = "lbAddItem";
            this.lbAddItem.Size = new System.Drawing.Size(113, 31);
            this.lbAddItem.TabIndex = 7;
            this.lbAddItem.Text = "Add Item";
            this.lbAddItem.Click += new System.EventHandler(this.lbAddItem_Click);
            // 
            // pnAddItem
            // 
            this.pnAddItem.BackgroundImage = global::Desktop.Properties.Resources.add;
            this.pnAddItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnAddItem.Location = new System.Drawing.Point(12, 24);
            this.pnAddItem.Name = "pnAddItem";
            this.pnAddItem.Size = new System.Drawing.Size(43, 48);
            this.pnAddItem.TabIndex = 6;
            this.pnAddItem.Click += new System.EventHandler(this.pnAddItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Desktop.Properties.Resources.search_interface_symbol;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(1370, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(26, 40);
            this.panel1.TabIndex = 8;
            // 
            // CatalogueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 633);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbAddItem);
            this.Controls.Add(this.pnAddItem);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.dgvItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CatalogueForm";
            this.Text = "CatalogueForm";
            this.Load += new System.EventHandler(this.CatalogueForm_Load);
            this.Shown += new System.EventHandler(this.CatalogueForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvItems;
        private DataGridViewImageColumn ItemImage;
        private DataGridViewTextBoxColumn Category;
        private TextBox tbSearch;
        private Label lbAddItem;
        private Panel pnAddItem;
        private Panel panel1;
        private DataGridViewTextBoxColumn itemID;
        private DataGridViewImageColumn Image;
        private DataGridViewTextBoxColumn itemName;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn subCategory;
        private DataGridViewTextBoxColumn unit;
        private DataGridViewTextBoxColumn price;
        private DataGridViewTextBoxColumn addedByEmployee;
        private DataGridViewButtonColumn EditButton;
        private DataGridViewButtonColumn DeleteButton;
    }
}