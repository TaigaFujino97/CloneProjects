using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelPackageData;
using TravelPackageData.Models;

namespace TravelPackageGUI
{
    public partial class frmAddProducts : Form
    {
        public Package? selectedPackage; // Which product is currently being modified/deleted
        private TravelExpertsDataConnection dbConnection = new(); // A Class for accessing dbAccess from TechSupport db
        public frmAddProducts()
        {
            InitializeComponent();
        }
        private void DisplaySuppliers()  // Refreshes the Suppliers
        {
            dgvProducts.Columns.Clear(); // Clear any existing data.
            dgvProducts.DataSource = dbConnection.GetAllProductsAndSuppliers();  // Pulls a formatted list of data from the DB

            // add column for modify button
            DataGridViewCheckBoxColumn selectColumn = new();
            dgvProducts.Columns.Add(selectColumn);

            // format the column header
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod;
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // format the odd numbered rows
            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod;
        }
    }
}
