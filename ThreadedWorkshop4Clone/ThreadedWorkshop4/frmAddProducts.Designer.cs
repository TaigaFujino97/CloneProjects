namespace TravelPackageGUI
{
    partial class frmAddProducts
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
            dgvProducts = new DataGridView();
            Product = new DataGridViewTextBoxColumn();
            Supplier = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { Product, Supplier });
            dgvProducts.Location = new Point(12, 12);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 62;
            dgvProducts.Size = new Size(514, 225);
            dgvProducts.TabIndex = 0;
            // 
            // Product
            // 
            Product.HeaderText = "Product";
            Product.MinimumWidth = 8;
            Product.Name = "Product";
            Product.ReadOnly = true;
            Product.Width = 150;
            // 
            // Supplier
            // 
            Supplier.HeaderText = "Supplier";
            Supplier.MinimumWidth = 8;
            Supplier.Name = "Supplier";
            Supplier.ReadOnly = true;
            Supplier.Width = 150;
            // 
            // frmAddProducts
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvProducts);
            Name = "frmAddProducts";
            Text = "frmAddProducts";
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvProducts;
        private DataGridViewTextBoxColumn Product;
        private DataGridViewTextBoxColumn Supplier;
    }
}