using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelPackageData.Models;

namespace TravelPackageGUI
{
    public partial class frmAddModifyPackage : Form
    {
        public bool isAdd; // true when Add, and false when Modify
        public Package? package; // new package data
        public List<Product?> products; // list of product
        public List<Supplier?> suppliers; // list of suppliers

        public frmAddModifyPackage()
        {
            InitializeComponent();
        }
        private void frmAddModifyPackage_Load(object sender, EventArgs e)
        {
            if (isAdd) // if the user selects the add button
            {
                pnlHider.Visible = true;
                Text = "Add Package";
            }
            else // if the user selects the modify button
            {
                pnlHider.Visible = false;
                Text = "Modify Package";
                DisplayPackage();
            }
        }

        private void DisplayPackage()
        {
            DateTime? startDateNullable = package!.PkgStartDate;
            DateTime? endDateNullable = package!.PkgEndDate;
            decimal? commissionNullable = package!.PkgAgencyCommission;
            if (package != null)
            {
                txtPackageID.Text = package.PackageId.ToString();
                txtName.Text = package.PkgName;
                if (startDateNullable.HasValue)
                {
                    txtStartDate.Text = startDateNullable.Value.ToString("yyyy-MM-dd");
                }
                else
                {
                    // Handle the case when startDateNullable is null
                    txtStartDate.Text = "N/A";  // Provide a default value or handle it as needed
                }
                if (endDateNullable.HasValue)
                {
                    txtEndDate.Text = endDateNullable.Value.ToString("yyyy-MM-dd");
                }
                else
                {
                    txtEndDate.Text = "N/A";
                }
                txtDesc.Text = package.PkgDesc;
                txtPrice.Text = package.PkgBasePrice.ToString("c");
                if (commissionNullable.HasValue)
                {
                    txtCommission.Text = commissionNullable.Value.ToString("c");
                }
                else
                {
                    txtCommission.Text = "N/A";
                }
            }
        }
        // Saves the new package to the data base if all entries are validated
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtName) &&
                Validator.IsPresent(txtDesc) &&
                Validator.IsPresent(txtPrice) &&
                Validator.IsValidDate(txtStartDate) &&
                Validator.IsValidDate(txtEndDate) &&
                Validator.IsValidEndDate(txtEndDate, txtStartDate) &&
                Validator.IsNonNegativeDecimal(txtPrice) &&
                Validator.IsNonNegativeDecimal(txtCommission) &&
                Validator.IsValidCommission(txtCommission, txtPrice)
                )
            {
                if (isAdd)
                {
                    package = new Package(); // creates an empty Customer object
                    GetPackageData(); // gathers product data to enter into the database
                }
                else // Modify
                {
                    GetPackageData(); // gathers product data to enter into the database
                }

                DialogResult = DialogResult.OK; // closes the form
            }
        }
        private void GetPackageData()
        {
            if (package != null)
            {
                package.PkgName = txtName.Text;
                package.PkgDesc = txtDesc.Text;
                if (!String.IsNullOrEmpty(txtStartDate.Text))
                {
                    package.PkgStartDate = Convert.ToDateTime(txtStartDate.Text);
                }
                if (!String.IsNullOrEmpty(txtEndDate.Text))
                {
                    package.PkgEndDate = Convert.ToDateTime(txtEndDate.Text);
                }
                if (!String.IsNullOrEmpty(txtPrice.Text))
                {
                    package.PkgBasePrice = Convert.ToDecimal(txtPrice.Text.Replace("$", "").Replace(",", ""));
                }
                if (!String.IsNullOrEmpty(txtCommission.Text))
                {
                    package.PkgAgencyCommission = Convert.ToDecimal(txtCommission.Text.Replace("$", "").Replace(",", ""));
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // !!!! TRYING TO GET PRODUCTS BTN TO OPEN ADDPRODUCTS FORM. IF ADD, ADDPRODUCTS FORM SHOWS ALL AVALAIBLE PRODUCTS AND SUPPLIERS COMBINATIONS
        // !!!! IF NOT ADD, ADDPRODUCTS FORM SHOWS THE CURRENT PRODUCTS AND SUPPLIERS COMBINATIONS. 
        private void btnProducts_Click(object sender, EventArgs e)
        {
            frmAddProducts thridForm = new frmAddProducts();
            DialogResult result = thridForm.ShowDialog();
            if (result == DialogResult.OK) // thrid form collected new data
            {
                // make selected package on this form the one from the other form
                package = thridForm.selectedPackage;

                try
                {
                    using (TravelExpertsContext db = new TravelExpertsContext())
                    {
                        if (package != null)
                        {

                        }
                    }
                }
                catch (DbUpdateException ex)
                {
                    string msg = "";
                    var sqlException =
                        (SqlException)ex.InnerException!;
                    foreach (SqlError error in sqlException.Errors)
                    {
                        msg += $"ERROR CODE {error.Number}: {error.Message}\\n";
                    }
                    MessageBox.Show(msg, "Database Error");
                    Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error while adding customer: " + ex.Message,
                        "Database Error");
                    Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Unanticipated error: " + ex.Message,
                        ex.GetType().ToString());
                    Close();
                }
            }
        }
    }
}
